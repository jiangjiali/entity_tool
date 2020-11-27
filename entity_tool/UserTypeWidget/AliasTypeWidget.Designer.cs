namespace UsertypeDefTools.Widget
{
	partial class AliasTypeWidget
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
            this.m_cbb_realType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "TypeName:";
            // 
            // m_txt_typeName
            // 
            this.m_txt_typeName.Location = new System.Drawing.Point(117, 10);
            this.m_txt_typeName.Name = "m_txt_typeName";
            this.m_txt_typeName.Size = new System.Drawing.Size(236, 21);
            this.m_txt_typeName.TabIndex = 1;
            this.m_txt_typeName.TextChanged += new System.EventHandler(this.m_txt_typeName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "RealType:";
            // 
            // m_cbb_realType
            // 
            this.m_cbb_realType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbb_realType.FormattingEnabled = true;
            this.m_cbb_realType.Location = new System.Drawing.Point(117, 37);
            this.m_cbb_realType.Name = "m_cbb_realType";
            this.m_cbb_realType.Size = new System.Drawing.Size(236, 20);
            this.m_cbb_realType.TabIndex = 3;
            this.m_cbb_realType.SelectedIndexChanged += new System.EventHandler(this.m_cbb_realType_SelectedIndexChanged);
            // 
            // AliasTypeWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_cbb_realType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txt_typeName);
            this.Controls.Add(this.label1);
            this.Name = "AliasTypeWidget";
            this.Size = new System.Drawing.Size(356, 67);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txt_typeName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox m_cbb_realType;
	}
}
