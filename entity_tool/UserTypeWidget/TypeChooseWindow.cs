using System;
using System.Linq;
using System.Windows.Forms;

namespace UsertypeDefTools
{
    public partial class TypeChooseWindow : Form
    {
        public TypeChooseWindow()
        {
            InitializeComponent();
        }

        private void m_btn_ok_Click(object sender, EventArgs e)
        {
            var typeName = TypeName;
            if (string.IsNullOrEmpty(typeName))
            {
                MessageBox.Show("类型名称不能为空");
                return;
            }

            if ((from type in BaseType.AllTypes
                 select type.TypeName).Any(a => a == typeName))
            {
                MessageBox.Show("类型名称已存在");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public string TypeName
        {
            get { return m_txt_typeName.Text.Trim(); }
        }

        public Type Type
        {
            get
            {

                if (m_radioBtn_aliasType.Checked)
                    return typeof(AliasType);

                if (m_radioBtn_userType.Checked)
                    return typeof(UserType);

                throw new InvalidOperationException("m_cbb_type.SelectedIndex");
            }
        }

    }
}
