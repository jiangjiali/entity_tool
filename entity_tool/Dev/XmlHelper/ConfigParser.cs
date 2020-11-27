using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Dev
{
	public class ConfigParser<TConfig>
		where TConfig : class, new()
	{
		static readonly Type[] ConvertTypes = new Type[]
		{ 
            typeof( bool ),
			typeof( sbyte ), typeof( byte ),
			typeof( short ), typeof( ushort ),
			typeof( int ), typeof( uint ), 
			typeof( long ), typeof( ulong ),
			typeof( float ), typeof( double ), typeof( decimal ), 
            typeof( string ), typeof( TimeSpan ), typeof( DateTime ), typeof( Version )
        };

		bool m_caseSensitive;
		TConfig m_config;

		Dictionary<MemberInfo, object[]> m_attributesMappingByMemberInfo = new Dictionary<MemberInfo, object[]>();
		Dictionary<Type, object[]> m_attributesMappingByType = new Dictionary<Type, object[]>();

		public ConfigParser(string xmlString, bool caseSensitive = true)
		{
			var xml = new XmlDocument();
			xml.LoadXml( xmlString.TrimBomOfXml() );

			ParseDocument( xml, caseSensitive );
		}

		public ConfigParser(XmlDocument xml, bool caseSensitive = true)
		{
			ParseDocument( xml, caseSensitive );
		}

		void ParseDocument(XmlDocument xml, bool caseSensitive)
		{
			m_caseSensitive = caseSensitive;
			m_config = new TConfig();

			ParseObject( typeof( TConfig ), m_config, xml.DocumentElement );
		}

		void ParseObject(Type type, object obj, XmlElement node)
		{
			if( node == null )
				return;

			var attr = GetCustomAttribute<SerializableAttribute>( type );
			if( attr == null )
				throw new InvalidOperationException( "Object must have 'Serializable' attribute" );

			// Iterate through properties
			foreach( var mi in GetMembers( type ) )
			{
				if( ParseText( mi, obj, node ) )
					continue;

				if( ParseAttribute( mi, obj, node ) )
					continue;

				if( ParseArray( mi, obj, node ) )
					continue;

				if( ParseElement( mi, obj, node ) )
					continue;
			}
		}

		bool IsConvertType(Type type)
		{
			return Array.Exists( ConvertTypes, t => t == type );
		}

		bool ParseText(MemberInfo mi, object obj, XmlElement node)
		{
			var attr = GetCustomAttribute<XmlTextAttribute>( mi );
			if( attr != null )
			{
				var textValue = node.InnerText;

				if( !string.IsNullOrEmpty( textValue ) )
				{
					var propValue = ConvertValue( textValue, GetMemberType( mi ) );
					SetMemberValue( mi, obj, propValue );
				}

				return true;
			}

			return false;
		}

		bool ParseAttribute(MemberInfo mi, object obj, XmlElement node)
		{
			var attr = GetCustomAttribute<XmlAttributeAttribute>( mi );
			if( attr != null )
			{
				// Set attribute name of property
				var attrName = attr.AttributeName;
				if( string.IsNullOrEmpty( attrName ) )
					attrName = mi.Name;

				string attrValue = null;
				if( m_caseSensitive )
				{
					attrValue = node.GetAttribute( attrName );
				}
				else
				{
					foreach( XmlAttribute nodeAttr in node.Attributes )
					{
						if( nodeAttr.LocalName.ToLower() == attrName.ToLower() )
						{
							attrValue = nodeAttr.Value;
							break;
						}
					}
				}

				var type = GetMemberType( mi );
				if( !string.IsNullOrEmpty( attrValue ) )
				{
					if( type.IsEnum )
					{
						var flags = GetCustomAttributes<FlagsAttribute>( type );
						if( flags.Length != 0 )
							attrValue = string.Join( ",", attrValue.Split( (char[])null, StringSplitOptions.RemoveEmptyEntries ) );

						var propValue = Enum.Parse( type, attrValue );
						SetMemberValue( mi, obj, propValue );
					}
					else if( type.IsArray )
					{
						var arrayAttr = GetCustomAttribute<XmlArrayAttribute>( mi );
						if( arrayAttr == null )
							throw new InvalidOperationException( "Must have 'XmlArray' attribute" );

						var elemType = type.GetElementType();
						var values = attrValue.Split( (char[])null, StringSplitOptions.RemoveEmptyEntries );
						var array = Array.CreateInstance( elemType, values.Length );
						for( int i = 0; i < values.Length; i++ )
							array.SetValue( ConvertValue( values[i], elemType ), i );

						SetMemberValue( mi, obj, array );

					}
					else
					{
						var propValue = ConvertValue( attrValue, type );
						SetMemberValue( mi, obj, propValue );
					}
				}

				return true;
			}

			return false;
		}

		bool ParseElement(MemberInfo mi, object obj, XmlElement node)
		{
			var attr = GetCustomAttribute<XmlElementAttribute>( mi );
			if( attr != null )
			{
				var type = GetMemberType( mi );
				IEnumerable<XmlElement> elements;
				if( !string.IsNullOrEmpty( attr.ElementName ) )
					elements = GetElementsByTagName( node, attr.ElementName );
				else if( GetCustomAttribute<XmlIncludeAttribute>( type ) != null )
					elements = GetElementsByType( node, type );
				else
					elements = GetElementsByTagName( node, mi.Name );

				var found = false;
				foreach( var elem in elements )
				{
					if( !found )
					{
						var elemType = ParseType( elem, type );
						var value = ParseValue( elemType, elem );
						if( value != null )
							SetMemberValue( mi, obj, value );
					}
					else
						throw new InvalidOperationException( string.Format( "Found two element '{0}'", elem.LocalName ) );
				}

				return true;
			}

			return false;
		}

		bool ParseArray(MemberInfo mi, object obj, XmlElement node)
		{
			var attr = GetCustomAttribute<XmlArrayAttribute>( mi );
			if( attr != null )
			{
				var memberType = GetMemberType( mi );
				// Check property type
				if( !memberType.IsArray )
					throw new InvalidOperationException( "Cannot add XmlArray attribute to a non-array property" );

				if( memberType.GetArrayRank() > 1 )
					throw new InvalidOperationException( "Cannot add XmlArray attribute to a multi-dimension array property" );

				// Create list
				var itemType = memberType.GetElementType();
				var listType = ( typeof( List<> ) ).MakeGenericType( itemType );
				var list = (IList)Activator.CreateInstance( listType );

				// Find array element
				XmlElement arrayElem = null;
				var elemAttr = GetCustomAttribute<XmlElementAttribute>( mi );
				if( elemAttr != null )
				{
					if( string.IsNullOrEmpty( elemAttr.ElementName ) )
					{
						arrayElem = node;
					}
					else
					{
						arrayElem = GetParentByTagName( node, elemAttr.ElementName );
						if( arrayElem == null )
							return true;
					}
				}
				else
				{
					// Set element name of array
					var arrayName = string.IsNullOrEmpty( attr.ElementName ) ? mi.Name : attr.ElementName;

					foreach( var childNode in GetElementsByTagName( node, arrayName ) )
					{
						if( arrayElem == null )
							arrayElem = childNode;
						else
							throw new InvalidOperationException( string.Format( "Found multiple array element: '{0}'", elemAttr.ElementName ) );
					}

					if( arrayElem == null )
						return true;
				}

				// Find child elements
				var itemAttr = GetCustomAttribute<XmlArrayItemAttribute>( mi );
				var itemElements = !string.IsNullOrEmpty( itemAttr.ElementName ) ? GetElementsByTagName( arrayElem, itemAttr.ElementName ) : GetElementsByType( arrayElem, itemType );

				foreach( var itemNode in itemElements )
				{
					var type = IsConvertType( itemType ) ? itemType : ParseType( itemNode, itemType );
					var value = ParseValue( type, itemNode );
					if( value != null )
						list.Add( value );
				}

				if( list.Count > 0 )
				{
					var array = Array.CreateInstance( itemType, list.Count );
					list.CopyTo( array, 0 );
					SetMemberValue( mi, obj, array );
				}

				return true;
			}

			return false;
		}

		object ParseValue(Type type, XmlElement node)
		{
			if( IsConvertType( type ) )
			{
				var textValue = node.InnerText.Trim();
				if( !string.IsNullOrEmpty( textValue ) )
				{
					return ConvertValue( textValue, type );
				}
				else
					return null;
			}
			else
			{
				var value = Activator.CreateInstance( type );
				ParseObject( type, value, node );
				return value;
			}
		}

		Type ParseType(XmlElement node, Type baseType)
		{
			var typeName = node.LocalName;

			var includeAttrs = GetCustomAttributes<XmlIncludeAttribute>( baseType );
			if( includeAttrs.Length == 0 )
				return baseType;

			foreach( var includeAttr in includeAttrs )
			{
				var type = ( includeAttr as XmlIncludeAttribute ).Type;
				var typeAttrs = GetCustomAttributes<XmlTypeAttribute>( type );

				foreach( var typeAttr in typeAttrs )
				{
					if( ( typeAttr as XmlTypeAttribute ).TypeName == typeName )
						return type;
				}
			}

			throw new InvalidOperationException( string.Format( "'{0}' is not a valid type of '{1}'", typeName, baseType.FullName ) );
		}

		object ConvertValue(string value, Type type)
		{
			if( type.IsEnum )
				return Enum.Parse( type, value );
			if( type == typeof( TimeSpan ) )
				return TimeSpan.Parse( value );
			if( type == typeof( DateTime ) )
			{
				var time = DateTime.Parse( value );
				return DateTime.SpecifyKind( time, DateTimeKind.Local );
			}
			if( type == typeof( Version ) )
				return new Version( value );
			else
				return Convert.ChangeType( value, type );
		}

		XmlElement GetParentByTagName(XmlElement node, string tagName)
		{
			if( !m_caseSensitive )
				tagName = tagName.ToLower();

			var parent = node;
			while( parent != null )
			{
				if( ( m_caseSensitive ? parent.LocalName : parent.LocalName.ToLower() ) == tagName )
					return parent;

				parent = parent.ParentNode as XmlElement;
			}

			return parent;
		}

		IEnumerable<XmlElement> GetElementsByTagName(XmlElement node, string tagName)
		{
			if( !m_caseSensitive )
				tagName = tagName.ToLower();

			foreach( var childNode in node.ChildNodes )
			{
				var element = childNode as XmlElement;
				if( tagName == null || ( element != null && ( m_caseSensitive ? element.LocalName : element.LocalName.ToLower() ) == tagName ) )
					yield return element;
			}
		}

		IEnumerable<XmlElement> GetElementsByType(XmlElement node, Type baseType)
		{
			// Get type names
			List<string> typeNames = new List<string>();
			var includeAttrs = GetCustomAttributes<XmlIncludeAttribute>( baseType );
			if( includeAttrs.Length == 0 )
			{
				typeNames.Add( baseType.Name );
			}
			else
			{
				foreach( var attr in includeAttrs )
				{
					var type = ( attr as XmlIncludeAttribute ).Type;
					var typeAttrs = GetCustomAttributes<XmlTypeAttribute>( type );

					if( typeAttrs.Length == 0 )
						throw new InvalidOperationException( "Missing 'XmlType' attribute" );

					if( typeAttrs.Length > 1 )
						throw new InvalidOperationException( "Found multiple 'XmlType' attribute" );

					typeNames.Add( ( typeAttrs[0] as XmlTypeAttribute ).TypeName );
				}
			}

			foreach( var childNode in node.ChildNodes )
			{
				var element = childNode as XmlElement;
				if( element != null && typeNames.Contains( element.LocalName ) )
					yield return element;
			}
		}

		IEnumerable<MemberInfo> GetMembers(Type type)
		{
			foreach( var fi in type.GetFields( BindingFlags.Public | BindingFlags.Instance ) )
				yield return fi;

			foreach( var pi in type.GetProperties( BindingFlags.Public | BindingFlags.Instance ) )
				yield return pi;
		}

		Type GetMemberType(MemberInfo mi)
		{
			if( mi is PropertyInfo )
				return ( (PropertyInfo)mi ).PropertyType;
			else if( mi is FieldInfo )
				return ( (FieldInfo)mi ).FieldType;
			else
				throw new InvalidOperationException();
		}

		void SetMemberValue(MemberInfo mi, object obj, object value)
		{
			if( mi is PropertyInfo )
				( (PropertyInfo)mi ).SetValue( obj, value, null );
			else if( mi is FieldInfo )
				( (FieldInfo)mi ).SetValue( obj, value );
			else
				throw new InvalidOperationException();
		}

		TAttribute GetCustomAttribute<TAttribute>(MemberInfo mi)
			where TAttribute : Attribute
		{
			object[] attrs;
			if( !m_attributesMappingByMemberInfo.TryGetValue( mi, out attrs ) )
			{
				attrs = mi.GetCustomAttributes( false );
				m_attributesMappingByMemberInfo.Add( mi, attrs );
			}

			if( attrs.Length == 0 )
				return null;

			//if( attrs.Length > 1 )
			//	throw new InvalidOperationException( string.Format( "Duplicate attribute '{0}'", typeof( TAttribute ).FullName ) );

			foreach( var a in attrs )
			{
				if( a is TAttribute )
					return (TAttribute)a;
			}

			return null;
		}

		TAttribute GetCustomAttribute<TAttribute>(Type type)
			where TAttribute : Attribute
		{
			object[] attrs;
			if( !m_attributesMappingByType.TryGetValue( type, out attrs ) )
			{
				attrs = type.GetCustomAttributes( false );
				m_attributesMappingByType.Add( type, attrs );
			}

			if( attrs.Length == 0 )
				return null;

			//if( attrs.Length > 1 )
			//	throw new InvalidOperationException( string.Format( "Duplicate attribute '{0}'", typeof( TAttribute ).FullName ) );

			foreach( var a in attrs )
			{
				if( a is TAttribute )
					return (TAttribute)a;
			}

			return null;
		}

		TAttribute[] GetCustomAttributes<TAttribute>(Type type)
			where TAttribute : Attribute
		{
			object[] attrs;
			if( !m_attributesMappingByType.TryGetValue( type, out attrs ) )
			{
				attrs = type.GetCustomAttributes( false );
				m_attributesMappingByType.Add( type, attrs );
			}

			return Array.ConvertAll( Array.FindAll( attrs, attr => attr is TAttribute ), attr => (TAttribute)attr );
		}

		public TConfig Config
		{
			get { return m_config; }
		}
	}

	public static class StringFormatter
	{
		public static string MessageIds(IEnumerable<uint> ids)
		{
			var sb = new StringBuilder();

			var e = ids.GetEnumerator();
			if( e == null || !e.MoveNext() )
				return "{}";

			sb.AppendFormat( "{{ {0}", e.Current );

			while( e.MoveNext() )
				sb.AppendFormat( ", {0}", e.Current );

			sb.Append( " }" );

			return sb.ToString();
		}

		public static string Join(IEnumerable<string> names)
		{
			var sb = new StringBuilder();

			var e = names.GetEnumerator();
			if( e == null || !e.MoveNext() )
				return "{}";

			sb.AppendFormat( "{{ {0}", e.Current );

			while( e.MoveNext() )
				sb.AppendFormat( ", {0}", e.Current );

			sb.Append( " }" );

			return sb.ToString();
		}

		public static string TrimBomOfXml(this string xml)
		{
			if( string.IsNullOrEmpty( xml ) )
				return xml;

			if( xml[0] != '<' )
				return xml.TrimStart(); // Remove BOM
			else
				return xml;
		}
	}
}