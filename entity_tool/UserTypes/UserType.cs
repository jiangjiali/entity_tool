using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

public interface IType
{
	string TypeName { get; }
	string GetCSharpTypeString();
}

public class BaseType : IType
{
	public static List<BaseType> AllTypes;
	public static int BaseTypeCount;

    static BaseType()
	{
		InitBaseType();
	}

	private static void InitBaseType()
	{
		AllTypes = new List<BaseType>();
		AllTypes.Add( new BaseType( "UINT8" ) );
		AllTypes.Add( new BaseType( "UINT16" ) );
		AllTypes.Add( new BaseType( "UINT32" ) );
		AllTypes.Add( new BaseType( "UINT64" ) );

		AllTypes.Add( new BaseType( "INT8" ) );
		AllTypes.Add( new BaseType( "INT16" ) );
		AllTypes.Add( new BaseType( "INT32" ) );
		AllTypes.Add( new BaseType( "INT64" ) );

		AllTypes.Add( new BaseType( "FLOAT" ) );
		AllTypes.Add( new BaseType( "DOUBLE" ) );

		AllTypes.Add( new BaseType( "VECTOR2" ) );
		AllTypes.Add( new BaseType( "VECTOR3" ) );
		AllTypes.Add( new BaseType( "VECTOR4" ) );

		AllTypes.Add( new BaseType( "STRING" ) );
		AllTypes.Add( new BaseType( "UNICODE" ) );
		AllTypes.Add( new BaseType( "PYTHON" ) );
		AllTypes.Add( new BaseType( "PY_DICT" ) );
		AllTypes.Add( new BaseType( "PY_TUPLE" ) );
		AllTypes.Add( new BaseType( "PY_LIST" ) );
		AllTypes.Add( new BaseType( "MAILBOX" ) );
		AllTypes.Add( new BaseType( "BLOB" ) );
        AllTypes.Add(new BaseType("ENTITYCALL"));

        BaseTypeCount = AllTypes.Count;
	}

	public virtual string GetCSharpTypeString()
	{
		switch( TypeName )
		{
			case "UINT8":
				return "Byte";
			case "UINT16":
				return "UInt16";
			case "UINT32":
				return "UInt32";
			case "UINT64":
				return "UInt64";

			case "INT8":
				return "SByte";
			case "INT16":
				return "Int16";
			case "INT32":
				return "Int32";
			case "INT64":
				return "Int64";

			case "FLOAT":
				return "float";
			case "DOUBLE":
				return "double";

			case "VECTOR2":
				return "Vector2";
			case "VECTOR3":
				return "Vector3";
			case "VECTOR4":
				return "Vector4";

			case "STRING":
				return "string";
			case "UNICODE":
				return "string";
			case "PYTHON":
				return "byte[]";
			case "PY_DICT":
				return "byte[]";
			case "PY_TUPLE":
				return "byte[]";
			case "PY_LIST":
				return "byte[]";
			case "MAILBOX":
				return "byte[]";
			case "BLOB":
				return "byte[]";
			default:
				throw new InvalidOperationException( "GetCSharpTypeString() " + TypeName );
		}
	}

	public BaseType(string typeName)
	{
		TypeName = typeName;
	}

	public static string[] AllTypeNamesExlude(BaseType type)
	{
		return ( from t in AllTypes
				 where t != type
				 select t.TypeName ).ToArray();
	}

    public string TypeName { get; set; }

    public static void WriteToFile(string path)
	{
		XmlDocument doc = new XmlDocument();

		XmlElement root = doc.CreateElement( "root" );

		foreach( var item in AllTypes )
		{
			if( item.GetType() == typeof( BaseType ) )
				continue;

			root.AppendChild( item.GenerateXmlNode( doc ) );
		}

		doc.AppendChild( root );

		using( FileStream fileStream = new FileStream( path, FileMode.Create ) )
		{
			using( XmlTextWriter writer = new XmlTextWriter( fileStream, Encoding.UTF8 ) )
			{
				writer.Formatting = Formatting.Indented;
				writer.Indentation = 1;
				writer.IndentChar = '\t';
				doc.WriteTo( writer );

				writer.Close();
			}
			fileStream.Close();
		}
	}

	public static void LoadFromFile(string path)
	{
		var xml = File.ReadAllText( path );
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml( xml );
		var root = xmlDoc.SelectSingleNode( "root" );
		InitBaseType();
		foreach( XmlNode xmlNode in root.ChildNodes )
		{
			if( xmlNode.FirstChild.InnerText.Trim() == "FIXED_DICT" )
				AllTypes.Add( new UserType( xmlNode.Name ) );
			else
				AllTypes.Add( new AliasType( xmlNode.Name, null ) );
		}
		int index = BaseTypeCount;
		foreach( XmlNode xmlNode in root.ChildNodes )
			AllTypes[index++].InitWithXmlNode( xmlNode );

		UsertypeDefTools.MainWindow.Instance.RefershTypeTreeView();
	}

	protected virtual void InitWithXmlNode(XmlNode xmlNode)
	{
	}

	protected virtual XmlNode GenerateXmlNode(XmlDocument doc)
	{
		throw new InvalidOperationException( "BaseType can't serialize" );
	}
}

public class AliasType : BaseType
{
    public AliasType(string aliasName, IType realType)
		: base( aliasName )
	{
		RealType = realType;
	}

    public IType RealType { get; set; } = AllTypes[0];

    protected override XmlNode GenerateXmlNode(XmlDocument doc)
	{
		var e = doc.CreateElement( TypeName );

		if( RealType is BaseType )
			e.InnerText = RealType.TypeName;
		else
		{
			var array = RealType as ArrayType;
			if( array == null )
				throw new InvalidOperationException();

			e.InnerXml = array.GetXmlText();
		}

		return e;
	}

	protected override void InitWithXmlNode(XmlNode xmlNode)
	{
		RealType = xmlNode.GetIType();
	}

	public override string GetCSharpTypeString()
	{
		return RealType.GetCSharpTypeString();
	}
}

public class UserType : BaseType
{
	public class Field
	{
		public string FieldName;
		public IType Type = AllTypes[0];

		internal XmlNode GenerateXmlNode(XmlDocument doc)
		{
			var type = doc.CreateElement( FieldName );
			var e = doc.CreateElement( "Type" );

			if( Type is BaseType )
				e.InnerText = Type.TypeName;
			else
			{
				var array = Type as ArrayType;
				if( array == null )
					throw new InvalidOperationException();

				e.InnerXml = array.GetXmlText();
			}

			type.AppendChild( e );
			return type;
		}

		internal void InitWithXmlNode(XmlNode xmlNode)
		{
			FieldName = xmlNode.Name.Trim();

			Type = xmlNode.SelectSingleNode( "Type" ).GetIType();
		}
	}

	public string ImplementedBy;
	public List<Field> Properties = new List<Field>();

	public UserType(string userTypeName): base( userTypeName )
	{

	}

	protected override XmlNode GenerateXmlNode(XmlDocument doc)
	{
		var e = doc.CreateElement( TypeName );

		e.InnerText = "FIXED_DICT";

		if( !string.IsNullOrEmpty( ImplementedBy ) )
		{
			var impl = doc.CreateElement( "implementedBy" );
			impl.InnerText = ImplementedBy;
			e.AppendChild( impl );
		}

		var p = doc.CreateElement( "Properties" );
		foreach( var item in Properties )
			p.AppendChild( item.GenerateXmlNode( doc ) );

		e.AppendChild( p );

		return e;
	}

	protected override void InitWithXmlNode(XmlNode xmlNode)
	{
		var implNode = xmlNode.SelectSingleNode( "implementedBy" );
		if( implNode != null )
			ImplementedBy = implNode.InnerText.Trim();

		foreach( XmlNode item in xmlNode.SelectSingleNode( "Properties" ) )
		{
			var field = new Field();
			field.InitWithXmlNode( item );
			Properties.Add( field );
		}
	}

	public override string GetCSharpTypeString()
	{
		return TypeName;
	}
}

public class ArrayType : IType
{
	public static readonly string ArrayTyteStr = "Array...";

    public ArrayType(IType type)
	{
		ElementType = type;
	}

	internal ArrayType(XmlNode xmlNode)
	{
		ElementType = xmlNode.GetIType();
	}

	public string TypeName
	{
		get { return ArrayTyteStr; }
	}

    public IType ElementType { get; set; } = BaseType.AllTypes[0];

    internal string GetXmlText()
	{
		var array = ElementType as ArrayType;
		if( array != null )
			return string.Format( "ARRAY <of> {0} </of>", array.GetXmlText() );

		return string.Format( "ARRAY <of> {0} </of>", ElementType.TypeName );
	}

	public string GetCSharpTypeString()
	{
		return string.Format( "List<{0}>", ElementType.GetCSharpTypeString() );
	}
}


static class ITypeHelper
{
	public static IType GetIType(this XmlNode xmlNode)
	{
		if ( xmlNode.FirstChild.InnerText.Trim() != "ARRAY" )
			return BaseType.AllTypes.Find( e => e.TypeName == xmlNode.InnerText.Trim() );
		else
			return new ArrayType( xmlNode.SelectSingleNode( "of" ) );
	}
}