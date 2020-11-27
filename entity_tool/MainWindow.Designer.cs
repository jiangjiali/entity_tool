namespace UsertypeDefTools
{
	partial class MainWindow
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.m_typeTreeView = new System.Windows.Forms.TreeView();
            this.m_type_panel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pythonExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_entity_panel = new System.Windows.Forms.Panel();
            this.m_entityTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_typeTreeView
            // 
            this.m_typeTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_typeTreeView.Location = new System.Drawing.Point(9, 4);
            this.m_typeTreeView.Name = "m_typeTreeView";
            this.m_typeTreeView.Size = new System.Drawing.Size(189, 649);
            this.m_typeTreeView.TabIndex = 0;
            this.m_typeTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_treeView_AfterSelect);
            this.m_typeTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_treeView_MouseDown);
            // 
            // m_type_panel
            // 
            this.m_type_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_type_panel.AutoScroll = true;
            this.m_type_panel.Location = new System.Drawing.Point(204, 4);
            this.m_type_panel.Name = "m_type_panel";
            this.m_type_panel.Size = new System.Drawing.Size(1096, 649);
            this.m_type_panel.TabIndex = 2;
            this.m_type_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panel_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.pythonExportToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1314, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F);
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.openToolStripMenuItem.Text = "加载";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F);
            this.saveToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + S";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.saveToolStripMenuItem.Text = "保存";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // pythonExportToolStripMenuItem
            // 
            this.pythonExportToolStripMenuItem.Name = "pythonExportToolStripMenuItem";
            this.pythonExportToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.pythonExportToolStripMenuItem.Text = "导出Python";
            this.pythonExportToolStripMenuItem.Click += new System.EventHandler(this.pythonExportToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.exportToolStripMenuItem.Text = "导出C#";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1309, 684);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_typeTreeView);
            this.tabPage1.Controls.Add(this.m_type_panel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1301, 658);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "类型定义";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_entity_panel);
            this.tabPage2.Controls.Add(this.m_entityTreeView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1301, 658);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "实体定义";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // m_entity_panel
            // 
            this.m_entity_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_entity_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_entity_panel.Location = new System.Drawing.Point(177, 3);
            this.m_entity_panel.Name = "m_entity_panel";
            this.m_entity_panel.Size = new System.Drawing.Size(1119, 650);
            this.m_entity_panel.TabIndex = 1;
            // 
            // m_entityTreeView
            // 
            this.m_entityTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_entityTreeView.Location = new System.Drawing.Point(3, 3);
            this.m_entityTreeView.Margin = new System.Windows.Forms.Padding(2);
            this.m_entityTreeView.Name = "m_entityTreeView";
            this.m_entityTreeView.Size = new System.Drawing.Size(169, 650);
            this.m_entityTreeView.TabIndex = 0;
            this.m_entityTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_entityTreeView_BeforeSelect);
            this.m_entityTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_entityTreeView_AfterSelect);
            this.m_entityTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_entityTreeView_MouseDown);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 711);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实体编辑工具";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView m_typeTreeView;
		private System.Windows.Forms.Panel m_type_panel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView m_entityTreeView;
		private System.Windows.Forms.Panel m_entity_panel;
        private System.Windows.Forms.ToolStripMenuItem pythonExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}

