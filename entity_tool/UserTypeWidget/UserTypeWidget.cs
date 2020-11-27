using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UsertypeDefTools.Widget
{
	public partial class UserTypeWidget : UserControl
	{
		UserType m_type;
		string m_typeName;

		public UserTypeWidget(UserType userType)
		{
			InitializeComponent();
			m_type = userType;

			Initialize();
		}

		private void Initialize()
		{
			m_txt_typeName.Text = m_type.TypeName;
			m_txt_implementedBy.Text = m_type.ImplementedBy;

			int index = 0;
			foreach( var item in m_type.Properties )
			{
				NewProperty( item, index++ );
			}
			MainWindow.Instance.Panel.Refresh();

		}

		private void UserTypeWidget_MouseDown(object sender, MouseEventArgs e)
		{
			if( e.Button == MouseButtons.Right )
			{
				ContextMenu con = new ContextMenu();

				MenuItem newType = new MenuItem( "添加属性" );
				newType.Click += new EventHandler( Click_NewProperty );

				con.MenuItems.Add( newType );

				ContextMenu = con;
			}
		}

		private void Click_NewProperty(object sender, EventArgs e)
		{
			var field = new UserType.Field();

			m_type.Properties.Add( field );

			NewProperty( field, m_type.Properties.Count - 1 );

			MainWindow.Instance.Panel.Refresh();
		}

		private void NewProperty(UserType.Field field, int index)
		{
			var widget = new PropertyWidget( m_type, field, new Point( Location.X + Size.Width + 30, Location.Y + Size.Height ), index );

			widget.Location = new Point( Location.X + Size.Width + 30, Location.Y + Size.Height + ( widget.Size.Height + 10 ) * index );

			MainWindow.Instance.Panel.Controls.Add( widget );

			MainWindow.Instance.AddLineToPanel(
					() => { return PointToScreen( Point.Add( m_label_properties.Location, m_label_properties.Size ) ); },
					() => { return widget.PointToScreen( Point.Empty ); } );
		}

		private void m_txt_typeName_TextChanged(object sender, EventArgs e)
		{
			m_type.TypeName = m_txt_typeName.Text;
            MainWindow.Instance.UpdateNodeName( m_type );
			//m_txt_implementedBy.Text = m_type.TypeName + "." + m_type.TypeName.ToLower() + "_inst";
		}

		private void m_txt_implementedBy_TextChanged(object sender, EventArgs e)
		{
			m_type.ImplementedBy = m_txt_implementedBy.Text;
		}

		private void m_txt_typeName_Leave(object sender, EventArgs e)
		{
			if( BaseType.AllTypes.Any( a => a != m_type && a.TypeName.ToLower() == m_type.TypeName.ToLower() ) )
			{
				m_type.TypeName = m_typeName;
                MainWindow.Instance.UpdateNodeName( m_type );
				m_txt_typeName.Text = m_type.TypeName;
				MessageBox.Show("TypeName 必须唯一", "提示" );
			}
		}

		private void m_txt_typeName_Enter(object sender, EventArgs e)
		{
			m_typeName = m_type.TypeName;
		}

        private void UserTypeWidget_Load(object sender, EventArgs e)
        {

        }
    }
}
