using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UsertypeDefTools
{
	class PythonCodeExport
	{
		List<BaseType> m_types;

		public PythonCodeExport(List<BaseType> types)
		{
			m_types = types;
		}

		internal bool Save(string dir)
		{
			foreach( var type in m_types )
			{
				var userType = type as UserType;
				if( userType != null )
				{
					var path = Path.Combine( dir, userType.TypeName + ".py" );
					File.WriteAllText( path, GeneratePythonCode( userType ), Encoding.UTF8 );
				}
			}
			return true;
		}

		string GeneratePythonCode(UserType type)
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine( @"# -*- coding: utf-8 -*-" );
			sb.AppendLine( @"import KBEngine" );
			sb.AppendLine();
			sb.AppendFormat( "class {0}(dict):", type.TypeName );
			sb.AppendLine();
			sb.Append( "\t" ); sb.AppendLine( @"def __init__(self):" );
			sb.Append( "\t\t" ); sb.AppendLine( @"dict.__init__(self)" );
			sb.AppendLine();

			//asDict
			sb.Append( "\t" ); sb.AppendLine( @"def asDict(self):" );
			sb.Append( "\t\t" ); sb.AppendLine( @"dct = {" );
			foreach( var item in type.Properties )
			{
				sb.Append( "\t\t\t" ); sb.AppendFormat( "\"{0}\": self[\"{0}\"],", item.FieldName ); sb.AppendLine();
			}
			sb.Append( "\t\t" ); sb.AppendLine( @"}" );
			sb.Append( "\t\t" ); sb.AppendLine( @"return dct" );
			sb.AppendLine();

			//createFromDict
			sb.Append( "\t" ); sb.AppendLine( @"def createFromDict(self, dictData):" );
			foreach( var item in type.Properties )
			{
				sb.Append( "\t\t" ); sb.AppendFormat( "self[\"{0}\"]= dictData[\"{0}\"]", item.FieldName ); sb.AppendLine();
			}
			sb.Append( "\t\t" ); sb.AppendLine( @"return self" );
			sb.AppendLine();

			//PICKLER
			var pickler = string.Format( "{0}_PICKLER", type.TypeName );
			sb.AppendFormat( "class {0}:", pickler ); sb.AppendLine();
			sb.Append( "\t" ); sb.AppendLine( @"def __init__(self):" );
			sb.Append( "\t\t" ); sb.AppendLine( @"pass" );
			sb.AppendLine();
			//PICKLER.createObjFromDict
			sb.Append( "\t" ); sb.AppendLine( @"def createObjFromDict(self, dct):" );
			sb.Append( "\t\t" ); sb.AppendFormat( "return {0}().createFromDict(dct)", type.TypeName ); sb.AppendLine();
			sb.AppendLine();
			//PICKLER.getDictFromObj
			sb.Append( "\t" ); sb.AppendLine( @"def getDictFromObj(self, obj):" );
			sb.Append( "\t\t" ); sb.AppendLine( "return obj.asDict()" );
			sb.AppendLine();
			//PICKLER.isSameType
			sb.Append( "\t" ); sb.AppendLine( @"def isSameType(self, obj):" );
			sb.Append( "\t\t" ); sb.AppendFormat( "return isinstance(obj, {0})", type.TypeName ); sb.AppendLine();
			sb.AppendLine();

			//inst
			sb.AppendFormat( "inst = {0}()", pickler );
			return sb.ToString();
		}
	}
}
