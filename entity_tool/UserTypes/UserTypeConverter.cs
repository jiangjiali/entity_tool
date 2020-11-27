using System;
using System.ComponentModel;
using System.Linq;

namespace UsertypeDefTools
{
	class UserTypeConverter : TypeConverter
	{
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			var strs = ( from t in BaseType.AllTypes
						 where t != context.Instance
						 select t.TypeName ).ToArray();
			return new StandardValuesCollection( strs );
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if( sourceType == typeof( string ) )
			{
				return true;
			}
			return base.CanConvertFrom( context, sourceType );
		}

		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if( value is string )
				return value.ToString();
			return base.ConvertFrom( context, culture, value );
		}
	}
}
