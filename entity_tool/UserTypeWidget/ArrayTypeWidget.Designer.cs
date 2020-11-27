namespace UsertypeDefTools.Widget
{
	partial class ArrayTypeWidget
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
			this.m_cbb_type = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_cbb_type
			// 
			this.m_cbb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbb_type.FormattingEnabled = true;
			this.m_cbb_type.Location = new System.Drawing.Point(59, 4);
			this.m_cbb_type.Name = "m_cbb_type";
			this.m_cbb_type.Size = new System.Drawing.Size(139, 20);
			this.m_cbb_type.TabIndex = 0;
			this.m_cbb_type.SelectedIndexChanged += new System.EventHandler(this.m_cbb_type_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "Type:";
			// 
			// ArrayTypeWidget
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_cbb_type);
			this.Name = "ArrayTypeWidget";
			this.Size = new System.Drawing.Size(201, 27);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox m_cbb_type;
		private System.Windows.Forms.Label label1;
	}
}
