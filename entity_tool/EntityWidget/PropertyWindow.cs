using System;
using System.Linq;
using System.Windows.Forms;

namespace UsertypeDefTools.EntityWidget
{
	public partial class PropertyWindow : Form
	{
        private EntityDef m_entity;

		public PropertyWindow(EntityDef entity, EntityDef.Property property)
		{
			InitializeComponent();

			Initlize( entity, property );
		}

		void Initlize(EntityDef entity, EntityDef.Property property)
		{
			m_entity = entity;

			var strs = ( from t in BaseType.AllTypes
						 select t.TypeName ).ToArray();
			m_cbb_type.Items.AddRange( strs );

			if( property == null )
				Property = new EntityDef.Property();
			else
				Property = property;

			m_txt_name.Text = Property.Name;
			m_cbb_type.SelectedItem = Property.Type.TypeName;
			m_txt_default.Text = Property.Default == null ? "" : Property.Default;
			m_txt_utype.Text = Property.Utype.HasValue ? Property.Utype.ToString() : "";

			foreach( EntityDef.Flags item in Enum.GetValues( typeof( EntityDef.Flags ) ) )
				m_cbb_flags.Items.Add( item );

			m_cbb_flags.SelectedItem = Property.Flags;

			m_cb_persistent.Checked = Property.Persistent.HasValue ? Property.Persistent.Value : false;
			m_txt_databaseLength.Text = Property.DatabaseLength.HasValue ? Property.DatabaseLength.ToString() : "";

			foreach( EntityDef.IndexType item in Enum.GetValues( typeof( EntityDef.IndexType ) ) )
				m_cbb_index.Items.Add( item );

			m_cbb_index.Items.Add( "" );

			if( Property.IndexType.HasValue )
				m_cbb_index.SelectedItem = Property.IndexType.Value;
			else
				m_cbb_index.SelectedItem = "";
		}

		private void btn_OK_Click(object sender, EventArgs e)
		{
			string name = m_txt_name.Text.Trim();
			if( string.IsNullOrEmpty( name ) )
			{
				MessageBox.Show( "属性名称不能为空" );
				return;
			}
			if( m_entity.Properties.Any( p => p.Name == name && p != Property ) )
			{
				MessageBox.Show( "属性名重复" );
				return;
			}
			Property.Name = name;

			Property.Type = BaseType.AllTypes.Find( t => t.TypeName.Equals( (string)m_cbb_type.SelectedItem ) );

			var defaultStr = m_txt_default.Text.Trim();
			if( string.IsNullOrEmpty( defaultStr ) )
				Property.Default = null;
			else
				Property.Default = defaultStr;

			var utypeStr = m_txt_utype.Text.Trim();
			if( !string.IsNullOrEmpty( utypeStr ) )
			{
                ushort utype;
				if(ushort.TryParse( utypeStr, out utype ) )
					Property.Utype = utype;
				else
				{
					MessageBox.Show( "Utype 必须为16位整数" );
					return;
				}
			}

			Property.Flags = (EntityDef.Flags)m_cbb_flags.SelectedItem;

			Property.Persistent = m_cb_persistent.Checked;

			var databaseLStr = m_txt_databaseLength.Text.Trim();
			if( !string.IsNullOrEmpty( databaseLStr ) )
			{
				uint dl;
				if( uint.TryParse( databaseLStr, out dl ) )
					Property.DatabaseLength = dl;
				else
				{
					MessageBox.Show( "DatabaseLength 必须为uint类型" );
					return;
				}
			}

			try
			{
				Property.IndexType = (EntityDef.IndexType)m_cbb_index.SelectedItem;
			}
			catch( Exception )
			{
				Property.IndexType = null;
			}

			DialogResult = DialogResult.OK;
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

        public EntityDef.Property Property { get; private set; }
    }
}
