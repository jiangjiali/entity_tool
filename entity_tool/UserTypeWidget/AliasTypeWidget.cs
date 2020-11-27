using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UsertypeDefTools.Widget
{
	public partial class AliasTypeWidget : UserControl
	{
		AliasType m_type;

		int m_cbbLastIndex;

		public AliasTypeWidget(AliasType aliasType)
		{
			InitializeComponent();
			m_type = aliasType;

			Initialize();
		}

		private void Initialize()
		{
			m_txt_typeName.Text = m_type.TypeName;
			var strs = ( from t in BaseType.AllTypes
						 where t != m_type
						 select t.TypeName ).ToArray();
			m_cbb_realType.Items.AddRange( strs );
			m_cbb_realType.Items.Add( ArrayType.ArrayTyteStr );

			if( m_type.RealType != null )
				m_cbb_realType.SelectedIndex = m_cbb_realType.Items.IndexOf( m_type.RealType.TypeName );
			else
				m_cbb_realType.SelectedIndex = 0;

			m_cbbLastIndex = m_cbb_realType.SelectedIndex;
			m_cbb_realType_SelectedIndexChanged( null, null );
		}

		private void m_cbb_realType_SelectedIndexChanged(object sender, EventArgs e)
		{
			var typeName = m_cbb_realType.SelectedItem.ToString();
			if( typeName == ArrayType.ArrayTyteStr )
			{
				var arrayType = m_type.RealType as ArrayType;
				if( arrayType == null )
				{
                    arrayType = new ArrayType(BaseType.AllTypes[0]);
					m_type.RealType = arrayType;
				}

				var widget = new ArrayTypeWidget( arrayType, new Point( Location.X + Size.Width + 30, Location.Y + Size.Height - 10 ) );
				MainWindow.Instance.Panel.Controls.Add( widget );
				MainWindow.Instance.AddLineToPanel(
					() => { return PointToScreen( Point.Add( m_cbb_realType.Location, m_cbb_realType.Size ) ); },
					() => { return widget.PointToScreen( Point.Empty ); } );
				MainWindow.Instance.Panel.Refresh();
			}
			else
			{
				var needRefresh = m_type.RealType is ArrayType;

				var realType = BaseType.AllTypes.First( (ee) => ee.TypeName == typeName );
				if( realType != null )
					m_type.RealType = realType;
				else
					MessageBox.Show( string.Format( "没有类型：{0}", typeName ) );

				if( needRefresh )
					MainWindow.Instance.RefreshPanel();
			}

			m_cbbLastIndex = m_cbb_realType.SelectedIndex;
		}

		private void m_txt_typeName_TextChanged(object sender, EventArgs e)
		{
			m_type.TypeName = m_txt_typeName.Text;
		}
	}
}
