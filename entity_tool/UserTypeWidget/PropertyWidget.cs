using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UsertypeDefTools.Widget
{
	public partial class PropertyWidget : UserControl
	{
		UserType m_parent;
		UserType.Field m_field;

		public PropertyWidget(UserType parent,UserType.Field field, Point location, int index)
		{
			InitializeComponent();
			m_parent = parent;
			m_field = field;

			Location = new Point( location.X, location.Y + ( Size.Height + 10 ) * index );

			Initialize();
		}

		private void Initialize()
		{
			m_txt_fieldName.Text = m_field.FieldName;

			var strs = ( from t in BaseType.AllTypes
						 where t != MainWindow.Instance.CurrentSelectedType
						 select t.TypeName ).ToArray();
			m_cbb_type.Items.AddRange( strs );
			m_cbb_type.Items.Add( ArrayType.ArrayTyteStr );

			if( m_field.Type != null )
				m_cbb_type.SelectedIndex = m_cbb_type.Items.IndexOf( m_field.Type.TypeName );
			else
				m_cbb_type.SelectedIndex = 0;

			m_cbb_type_SelectedIndexChanged( null, null );
		}

		private void m_cbb_type_SelectedIndexChanged(object sender, EventArgs e)
		{
			var typeName = m_cbb_type.SelectedItem.ToString();
			if( typeName == ArrayType.ArrayTyteStr )
			{
				var arrayType = m_field.Type as ArrayType;
				if( arrayType == null )
				{
                    arrayType = new ArrayType(BaseType.AllTypes[0]);
					m_field.Type = arrayType;
				}

				var widget = new ArrayTypeWidget( arrayType, new Point( Location.X + Size.Width + 30, Location.Y + Size.Height - 10 ) );
				MainWindow.Instance.Panel.Controls.Add( widget );
				MainWindow.Instance.AddLineToPanel(
					() => { return PointToScreen( Point.Add( m_cbb_type.Location, m_cbb_type.Size ) ); },
					() => { return widget.PointToScreen( Point.Empty ); } );
				MainWindow.Instance.Panel.Refresh();
			}
			else
			{
				var needRefresh = m_field.Type is ArrayType;

				var realType = BaseType.AllTypes.First( (ee) => ee.TypeName == typeName );
				if( realType != null )
					m_field.Type = realType;
				else
					MessageBox.Show( string.Format( "没有类型：{0}", typeName ) );

				if( needRefresh )
					MainWindow.Instance.RefreshPanel();
			}
		}

		private void m_txt_fieldName_TextChanged(object sender, EventArgs e)
		{
			m_field.FieldName = m_txt_fieldName.Text;
		}

		private void PropertyWidget_Enter(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.Fixed3D;
		}

		private void PropertyWidget_Leave(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.FixedSingle;
		}

		private void PropertyWidget_MouseDown(object sender, MouseEventArgs e)
		{
			if( e.Button == MouseButtons.Right )
			{
				ContextMenu con = new ContextMenu();

				MenuItem delType = new MenuItem( "删除类型" );
				delType.Click += new EventHandler( OnClick_Delete );

				con.MenuItems.Add( delType );
				ContextMenu = con;
			}
		}

		private void OnClick_Delete(object sender, EventArgs e)
		{
			m_parent.Properties.Remove( m_field );
			Parent.Controls.Remove( this );
			MainWindow.Instance.RefreshPanel();
		}
	}
}
