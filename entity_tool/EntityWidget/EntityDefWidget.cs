using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UsertypeDefTools.EntityWidget;

namespace UsertypeDefTools.Widget
{
    public partial class EntityDefWidget : UserControl
    {
        EntityDef m_entity;

        public EntityDefWidget()
        {
            InitializeComponent();
        }

        public void Reset(EntityDef entity)
        {
            m_entity = entity;

            m_txt_name.Text = m_entity.Name;
            m_cb_isInterface.Checked = m_entity.IsInterface;
            m_cb_isRegistered.Checked = m_entity.IsRegistered;
            m_cb_hasClient.Checked = m_entity.HasClient;
            m_cbb_parent.Items.Clear();
            //foreach (var item in EntityDef.AllEntityDefs.Values)
            //    m_cbb_parent.Items.Add(item.Name);
            //m_cbb_parent.Items.Add("");
            //if (m_entity.Parent != null)
            //    m_cbb_parent.SelectedItem = m_entity.Parent.Name;
            //else
            //    m_cbb_parent.SelectedItem = "";

            m_lb_implements.Items.Clear();
            foreach (var item in m_entity.Implements)
                m_lb_implements.Items.Add(item.Name);

            m_lb_unImplements.Items.Clear();
            foreach (var item in from e in AllEntityDefs.Values where !m_entity.Implements.Any(a => a.Name == e.Name) && e.IsInterface == true select e)
                m_lb_unImplements.Items.Add(item.Name);

            m_txt_position.Text = "";
            m_txt_yaw.Text = "";
            m_txt_pitch.Text = "";
            m_txt_roll.Text = "";
            optimized.Checked = false;
            var v = m_entity.Volatile;
            if (v != null)
            {
                if (v.Position.HasValue)
                    m_txt_position.Text = v.Position.Value.ToString();
                if (v.Yaw.HasValue)
                    m_txt_yaw.Text = v.Yaw.Value.ToString();
                if (v.Pitch.HasValue)
                    m_txt_pitch.Text = v.Pitch.Value.ToString();
                if (v.Roll.HasValue)
                    m_txt_roll.Text = v.Roll.Value.ToString();
                if (v.optimized=="true")
                    optimized.Checked = true;
                else
                    optimized.Checked = false;
            }

            ResetPropertiesView();
            ResetMethodsView(m_lv_clientMethods, m_entity.ClientMethods);
            ResetMethodsView(m_lv_baseMethods, m_entity.BaseMethods);
            ResetMethodsView(m_lv_cellMethods, m_entity.CellMethods);
        }

        private void ResetPropertiesView()
        {
            m_lv_properties.View = View.Details;
            m_lv_properties.Items.Clear();
            m_lv_properties.Columns.Clear();
            m_lv_properties.Columns.Add("Name");
            m_lv_properties.Columns.Add("Type");
            m_lv_properties.Columns.Add("Default");
            m_lv_properties.Columns.Add("Utype");
            m_lv_properties.Columns.Add("Flags");
            m_lv_properties.Columns.Add("Persistent");
            m_lv_properties.Columns.Add("DatabaseLength");
            m_lv_properties.Columns.Add("IndexType");

            m_lv_properties.BeginUpdate();
            foreach (var item in m_entity.Properties)
            {
                m_lv_properties.Items.Add(new ListViewItem(new string[] { 
                    item.Name,
                    item.Type.TypeName,
                    item.Default == null?"":item.Default,
                    item.Utype.HasValue?item.Utype.ToString():"",
                    item.Flags.ToString(),
                    item.Persistent.HasValue?item.Persistent.ToString():"",
                    item.DatabaseLength.HasValue?item.DatabaseLength.ToString():"",
                    item.IndexType.HasValue?item.IndexType.ToString():"",
                }));
            }
            m_lv_properties.EndUpdate();

            foreach (ColumnHeader item in m_lv_properties.Columns)
                item.Width = -1;
        }

        private void ResetMethodsView(ListView lv, List<EntityDef.Method> methods)
        {
            lv.View = View.Details;

            lv.Items.Clear();
            lv.Columns.Clear();
            lv.Columns.Add("Function");
            lv.Columns.Add("Exposed");
            lv.Columns.Add("Utype");
            lv.BeginUpdate();
            foreach (var item in methods)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}(", item.Name);
                int i = 0;
                foreach (var arg in item.Args)
                {
                    if (i > 0)
                        sb.Append(", ");
                    sb.AppendFormat("{0} arg{1}", arg.TypeName, i);
                    ++i;
                }
                sb.Append(')');
                ListViewItem lvi = new ListViewItem(new string[]{
					sb.ToString(),
					item.Exposed.ToString(),
					item.Utype.HasValue? item.Utype.ToString():"",
				});
                lvi.Name = item.Name;
                lv.Items.Add(lvi);
            }
            lv.EndUpdate();

            var b = lv.Items.Count == 0 ? -1 : 0;
            lv.Columns[0].Width = -1 + b;
            lv.Columns[1].Width = -2;
            lv.Columns[2].Width = -1 + b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //添加implement
            List<Object> removeList = new List<object>();
            foreach (var item in m_lb_unImplements.SelectedItems)
            {
                m_entity.Implements.Add(AllEntityDefs[item.ToString()]);
                m_lb_implements.Items.Add(item);
                removeList.Add(item);
            }

            foreach (var item in removeList)
                m_lb_unImplements.Items.Remove(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //取消implement
            List<Object> removeList = new List<object>();
            foreach (var item in m_lb_implements.SelectedItems)
            {
                m_entity.Implements.Remove(AllEntityDefs[item.ToString()]);
                m_lb_unImplements.Items.Add(item);
                removeList.Add(item);
            }

            foreach (var item in removeList)
                m_lb_implements.Items.Remove(item);
        }

        Dictionary<string, EntityDef> AllEntityDefs
        {
            get { return EntityDef.AllEntityDefs; }
        }

        bool MakeSureSelectOne(ListView lv)
        {
            if (lv.SelectedItems.Count != 1)
            {
                MessageBox.Show("选择一条记录进行操作");
                return false;
            }
            return true;
        }

        private void m_btn_alterProperty_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }

            if (!MakeSureSelectOne(m_lv_properties))
                return;

            var p = m_lv_properties.SelectedItems[0];
            PropertyWindow pw = new PropertyWindow(m_entity, m_entity.Properties.First(n => n.Name == p.SubItems[0].Text));
            var r = pw.ShowDialog();
            if (r == DialogResult.OK)
                ResetPropertiesView();
        }

        private void m_btn_newProperty_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }

            PropertyWindow pw = new PropertyWindow(m_entity, null);
            var r = pw.ShowDialog();
            if (r == DialogResult.OK)
            {
                m_entity.Properties.Add(pw.Property);
                ResetPropertiesView();
            }
        }

        private void m_btn_deleteProperty_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }

            if (!MakeSureSelectOne(m_lv_properties))
                return;

            if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var p = m_lv_properties.SelectedItems[0];
                m_entity.Properties.RemoveAll(n => n.Name == p.SubItems[0].Text);
                ResetPropertiesView();
            }

        }

        #region ClientMethods event

        private void m_btn_newClientMethod_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }
            NewMethod(m_entity.ClientMethods, m_lv_clientMethods);
        }

        private void m_btn_delClientMethod_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }
            DeleteMethod(m_entity.ClientMethods, m_lv_clientMethods);
        }

        private void m_btn_alterClientMethod_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }
            AlterMethod(m_entity.ClientMethods, m_lv_clientMethods);
        }

        #endregion

        #region BaseMethods event

        private void m_btn_newBaseMethod_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }
            NewMethod(m_entity.BaseMethods, m_lv_baseMethods);
        }

        private void m_btn_delBaseMethod_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }
            DeleteMethod(m_entity.BaseMethods, m_lv_baseMethods);
        }

        private void m_btn_alterBaseMethod_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }
            AlterMethod(m_entity.BaseMethods, m_lv_baseMethods);
        }

        #endregion

        #region CellMethods event

        private void m_btn_newCellMethod_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }
            NewMethod(m_entity.CellMethods, m_lv_cellMethods);
        }

        private void m_btn_delCellMethod_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }
            DeleteMethod(m_entity.CellMethods, m_lv_cellMethods);
        }

        private void m_btn_alterCellMethod_Click(object sender, EventArgs e)
        {
            if (m_entity == null)
            {
                MessageBox.Show("没有加载", "提示");
                return;
            }
            AlterMethod(m_entity.CellMethods, m_lv_cellMethods);
        }

        #endregion

        #region Helper

        void NewMethod(List<EntityDef.Method> methods, ListView lv)
        {
            MethodWindow mw = new MethodWindow(methods, null);
            if (mw.ShowDialog() == DialogResult.OK)
            {
                methods.Add(mw.Method);
                ResetMethodsView(lv, methods);
            }
        }

        void DeleteMethod(List<EntityDef.Method> methods, ListView lv)
        {
            if (!MakeSureSelectOne(lv))
                return;

            if (MessageBox.Show("确定删除？", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var p = lv.SelectedItems[0];
                methods.RemoveAll(n => n.Name == p.Name);
                ResetMethodsView(lv, methods);
            }
        }

        void AlterMethod(List<EntityDef.Method> methods, ListView lv)
        {
            if (!MakeSureSelectOne(lv))
                return;

            var p = lv.SelectedItems[0];
            MethodWindow pw = new MethodWindow(methods, methods.Find(b => b.Name == p.Name));
            var r = pw.ShowDialog();
            if (r == DialogResult.OK)
                ResetMethodsView(lv, methods);
        }

        #endregion

        public bool ValidateEntityDefData()
        {
            if (!AllEntityDefs.Any(e => e.Value == m_entity))
                return true;

            var name = m_txt_name.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Entity名字不能为空");
                return false;
            }

            if (AllEntityDefs.Any(e => e.Value.Name == name && e.Value != m_entity))
            {
                MessageBox.Show("entity名字重复");
                return false;
            }
            m_entity.Name = name;

            var parent = m_cbb_parent.SelectedItem as string;

            //m_entity.Parent = AllEntityDefs.Values.FirstOrDefault(e => e.Name == parent);

            m_entity.IsInterface = m_cb_isInterface.Checked;
            m_entity.IsRegistered = m_cb_isRegistered.Checked;
            m_entity.HasClient = m_cb_hasClient.Checked;


            var volatiles = new Dictionary<TextBox, string>();
            {
                volatiles.Add(m_txt_position, "Position");
                volatiles.Add(m_txt_yaw, "Yaw");
                volatiles.Add(m_txt_pitch, "Pitch");
                volatiles.Add(m_txt_roll, "Roll");
            }
            float?[] values = new float?[4];
            int i = 0;
            foreach (var item in volatiles)
            {
                if (!SetDefVolatile(item.Key, item.Value, out values[i]))
                    return false;
                ++i;
            }

            if (values.Any(e => e != null))
            {
                m_entity.Volatile = new EntityDef.DefVolatile();
                m_entity.Volatile.Position = values[0];
                m_entity.Volatile.Yaw = values[1];
                m_entity.Volatile.Pitch = values[2];
                m_entity.Volatile.Roll = values[3];
                
            }
            else
            {
                if (optimized.Checked ==false)
                    m_entity.Volatile = null;
                else
                {
                    m_entity.Volatile = new EntityDef.DefVolatile();
                    m_entity.Volatile.Position = null;
                    m_entity.Volatile.Yaw = null;
                    m_entity.Volatile.Pitch = null;
                    m_entity.Volatile.Roll = null;
                    m_entity.Volatile.optimized = optimized.Checked ? "true" : "false";
                }
            }
                

            return true;
        }

        bool SetDefVolatile(TextBox tb, string des, out float? value)
        {
            value = null;
            var str = tb.Text.Trim();
            if (!string.IsNullOrEmpty(str))
            {
                float p;
                if (float.TryParse(str, out p))
                    value = p;
                else
                {
                    MessageBox.Show(des + "只能是浮点数");
                    return false;
                }
            }
            return true;
        }

        private void m_cb_isInterface_CheckedChanged(object sender, EventArgs e)
        {
            if (m_cb_isInterface.Checked)
            {
                m_cbb_parent.SelectedItem = "";
                m_cb_isRegistered.Checked = false;
                m_cb_hasClient.Checked = false;
            }
            m_cbb_parent.Enabled = !m_cb_isInterface.Checked;
            m_cb_isRegistered.Enabled = !m_cb_isInterface.Checked;
            m_cb_hasClient.Enabled = !m_cb_isInterface.Checked;
        }

        private void m_cb_isRegistered_CheckedChanged(object sender, EventArgs e)
        {
            if (m_entity.IsInterface && m_cb_isRegistered.Checked)
            {
                MessageBox.Show("接口不能被注册");
                m_cb_isRegistered.Checked = false;
            }
            m_cb_hasClient.Enabled = m_cb_isRegistered.Checked;
        }

		private void m_txt_name_Leave(object sender, EventArgs e)
		{
			if( ValidateEntityDefData() )
				MainWindow.Instance.RefreshEntityTree();
		}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void m_lv_properties_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void optimized_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
