using System.Windows.Forms;

namespace UsertypeDefTools.Widget
{
	public partial class BaseTypeWidget : UserControl
	{
		BaseType m_type;
		public BaseTypeWidget(BaseType bt)
		{
			m_type = bt;
			InitializeComponent();

			m_txt_name.Text = m_type.TypeName;
		}
	}
}
