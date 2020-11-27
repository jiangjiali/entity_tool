namespace UsertypeDefTools.Widget
{
	partial class UserTypeWidget
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.m_txt_typeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txt_implementedBy = new System.Windows.Forms.TextBox();
            this.m_label_properties = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "TypeName:";
            // 
            // m_txt_typeName
            // 
            this.m_txt_typeName.Location = new System.Drawing.Point(77, 8);
            this.m_txt_typeName.Name = "m_txt_typeName";
            this.m_txt_typeName.Size = new System.Drawing.Size(249, 21);
            this.m_txt_typeName.TabIndex = 1;
            this.m_txt_typeName.TextChanged += new System.EventHandler(this.m_txt_typeName_TextChanged);
            this.m_txt_typeName.Enter += new System.EventHandler(this.m_txt_typeName_Enter);
            this.m_txt_typeName.Leave += new System.EventHandler(this.m_txt_typeName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ImplementedBy:";
            // 
            // m_txt_implementedBy
            // 
            this.m_txt_implementedBy.Location = new System.Drawing.Point(107, 44);
            this.m_txt_implementedBy.Name = "m_txt_implementedBy";
            this.m_txt_implementedBy.Size = new System.Drawing.Size(219, 21);
            this.m_txt_implementedBy.TabIndex = 3;
            this.m_txt_implementedBy.TextChanged += new System.EventHandler(this.m_txt_implementedBy_TextChanged);
            // 
            // m_label_properties
            // 
            this.m_label_properties.AutoSize = true;
            this.m_label_properties.Location = new System.Drawing.Point(12, 76);
            this.m_label_properties.Name = "m_label_properties";
            this.m_label_properties.Size = new System.Drawing.Size(71, 12);
            this.m_label_properties.TabIndex = 4;
            this.m_label_properties.Text = "Properties:";
            // 
            // UserTypeWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_label_properties);
            this.Controls.Add(this.m_txt_implementedBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txt_typeName);
            this.Controls.Add(this.label1);
            this.Name = "UserTypeWidget";
            this.Size = new System.Drawing.Size(329, 99);
            this.Load += new System.EventHandler(this.UserTypeWidget_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserTypeWidget_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txt_typeName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txt_implementedBy;
		private System.Windows.Forms.Label m_label_properties;
	}
}
