using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UsertypeDefTools.Widget
{
	public partial class ArrayTypeWidget : UserControl
	{
		ArrayType m_arrayType;

		public ArrayTypeWidget(ArrayType arrayType, Point localtion)
		{
			InitializeComponent();

			Location = localtion;

			m_arrayType = arrayType;

			m_cbb_type.Items.AddRange( BaseType.AllTypeNamesExlude( MainWindow.Instance.CurrentSelectedType as BaseType ) );
			m_cbb_type.Items.Add( ArrayType.ArrayTyteStr );

			if( m_arrayType.ElementType != null )
				m_cbb_type.SelectedIndex = m_cbb_type.Items.IndexOf( m_arrayType.ElementType.TypeName );
			else
				m_cbb_type.SelectedIndex = 0;
		}

		private void m_cbb_type_SelectedIndexChanged(object sender, EventArgs e)
		{
			var typeName = m_cbb_type.SelectedItem.ToString();
			if( typeName == ArrayType.ArrayTyteStr )
			{
				var arrayType = m_arrayType.ElementType as ArrayType;
				if( arrayType == null )
				{
                    arrayType = new ArrayType(BaseType.AllTypes[0]);
					m_arrayType.ElementType = arrayType;
				}

				var widget = new ArrayTypeWidget( arrayType, new Point( Location.X + Size.Width + 30, Location.Y + Size.Height ) );
				MainWindow.Instance.Panel.Controls.Add( widget );
				MainWindow.Instance.AddLineToPanel(
					() => { return PointToScreen( Point.Add( m_cbb_type.Location, m_cbb_type.Size ) ); },
					() => { return widget.PointToScreen( Point.Empty ); } );
				MainWindow.Instance.Panel.Refresh();
			}
			else
			{
				var needRefresh = m_arrayType.ElementType is ArrayType;

				var elementType = BaseType.AllTypes.First( (ee) => ee.TypeName == typeName );
				if( elementType != null )
					m_arrayType.ElementType = elementType;
				else
					MessageBox.Show( string.Format( "没有类型：{0}", typeName ) );

				if( needRefresh )
					MainWindow.Instance.RefreshPanel();
			}

		}
	}
}
