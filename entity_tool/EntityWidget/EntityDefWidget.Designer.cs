namespace UsertypeDefTools.Widget
{
	partial class EntityDefWidget
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
            this.m_txt_name = new System.Windows.Forms.TextBox();
            this.m_cb_isInterface = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbb_parent = new System.Windows.Forms.ComboBox();
            this.m_cb_isRegistered = new System.Windows.Forms.CheckBox();
            this.m_cb_hasClient = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optimized = new System.Windows.Forms.CheckBox();
            this.m_txt_roll = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txt_pitch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txt_yaw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txt_position = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lb_implements = new System.Windows.Forms.ListBox();
            this.m_lb_unImplements = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.m_lv_properties = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.m_btn_newProperty = new System.Windows.Forms.Button();
            this.m_btn_deleteProperty = new System.Windows.Forms.Button();
            this.m_btn_alterProperty = new System.Windows.Forms.Button();
            this.m_lv_clientMethods = new System.Windows.Forms.ListView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_lv_baseMethods = new System.Windows.Forms.ListView();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lv_cellMethods = new System.Windows.Forms.ListView();
            this.m_btn_alterClientMethod = new System.Windows.Forms.Button();
            this.m_btn_delClientMethod = new System.Windows.Forms.Button();
            this.m_btn_newClientMethod = new System.Windows.Forms.Button();
            this.m_btn_alterBaseMethod = new System.Windows.Forms.Button();
            this.m_btn_delBaseMethod = new System.Windows.Forms.Button();
            this.m_btn_newBaseMethod = new System.Windows.Forms.Button();
            this.m_btn_alterCellMethod = new System.Windows.Forms.Button();
            this.m_btn_delCellMethod = new System.Windows.Forms.Button();
            this.m_btn_newCellMethod = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txt_name
            // 
            this.m_txt_name.Location = new System.Drawing.Point(56, 7);
            this.m_txt_name.Name = "m_txt_name";
            this.m_txt_name.Size = new System.Drawing.Size(150, 21);
            this.m_txt_name.TabIndex = 1;
            this.m_txt_name.Leave += new System.EventHandler(this.m_txt_name_Leave);
            // 
            // m_cb_isInterface
            // 
            this.m_cb_isInterface.AutoSize = true;
            this.m_cb_isInterface.Location = new System.Drawing.Point(14, 253);
            this.m_cb_isInterface.Name = "m_cb_isInterface";
            this.m_cb_isInterface.Size = new System.Drawing.Size(90, 16);
            this.m_cb_isInterface.TabIndex = 2;
            this.m_cb_isInterface.Text = "IsInterface";
            this.m_cb_isInterface.UseVisualStyleBackColor = true;
            this.m_cb_isInterface.Visible = false;
            this.m_cb_isInterface.CheckedChanged += new System.EventHandler(this.m_cb_isInterface_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parent:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Visible = false;
            // 
            // m_cbb_parent
            // 
            this.m_cbb_parent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbb_parent.FormattingEnabled = true;
            this.m_cbb_parent.Location = new System.Drawing.Point(285, 253);
            this.m_cbb_parent.Name = "m_cbb_parent";
            this.m_cbb_parent.Size = new System.Drawing.Size(126, 20);
            this.m_cbb_parent.TabIndex = 4;
            this.m_cbb_parent.Visible = false;
            // 
            // m_cb_isRegistered
            // 
            this.m_cb_isRegistered.AutoSize = true;
            this.m_cb_isRegistered.Location = new System.Drawing.Point(110, 253);
            this.m_cb_isRegistered.Name = "m_cb_isRegistered";
            this.m_cb_isRegistered.Size = new System.Drawing.Size(96, 16);
            this.m_cb_isRegistered.TabIndex = 5;
            this.m_cb_isRegistered.Text = "IsRegistered";
            this.m_cb_isRegistered.UseVisualStyleBackColor = true;
            this.m_cb_isRegistered.Visible = false;
            this.m_cb_isRegistered.CheckedChanged += new System.EventHandler(this.m_cb_isRegistered_CheckedChanged);
            // 
            // m_cb_hasClient
            // 
            this.m_cb_hasClient.AutoSize = true;
            this.m_cb_hasClient.Location = new System.Drawing.Point(56, 38);
            this.m_cb_hasClient.Name = "m_cb_hasClient";
            this.m_cb_hasClient.Size = new System.Drawing.Size(78, 16);
            this.m_cb_hasClient.TabIndex = 6;
            this.m_cb_hasClient.Text = "HasClient";
            this.m_cb_hasClient.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optimized);
            this.groupBox1.Controls.Add(this.m_txt_roll);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_txt_pitch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_txt_yaw);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_txt_position);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(396, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 215);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volatile";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // optimized
            // 
            this.optimized.AutoSize = true;
            this.optimized.Location = new System.Drawing.Point(50, 177);
            this.optimized.Name = "optimized";
            this.optimized.Size = new System.Drawing.Size(78, 16);
            this.optimized.TabIndex = 9;
            this.optimized.Text = "optimized";
            this.optimized.UseVisualStyleBackColor = true;
            this.optimized.CheckedChanged += new System.EventHandler(this.optimized_CheckedChanged);
            // 
            // m_txt_roll
            // 
            this.m_txt_roll.Location = new System.Drawing.Point(72, 132);
            this.m_txt_roll.Name = "m_txt_roll";
            this.m_txt_roll.Size = new System.Drawing.Size(81, 21);
            this.m_txt_roll.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Roll:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_txt_pitch
            // 
            this.m_txt_pitch.Location = new System.Drawing.Point(72, 55);
            this.m_txt_pitch.Name = "m_txt_pitch";
            this.m_txt_pitch.Size = new System.Drawing.Size(81, 21);
            this.m_txt_pitch.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pitch:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_txt_yaw
            // 
            this.m_txt_yaw.Location = new System.Drawing.Point(72, 100);
            this.m_txt_yaw.Name = "m_txt_yaw";
            this.m_txt_yaw.Size = new System.Drawing.Size(81, 21);
            this.m_txt_yaw.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Yaw:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txt_position
            // 
            this.m_txt_position.Location = new System.Drawing.Point(72, 23);
            this.m_txt_position.Name = "m_txt_position";
            this.m_txt_position.Size = new System.Drawing.Size(81, 21);
            this.m_txt_position.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Position:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "Interfaces:";
            // 
            // m_lb_implements
            // 
            this.m_lb_implements.FormattingEnabled = true;
            this.m_lb_implements.ItemHeight = 12;
            this.m_lb_implements.Location = new System.Drawing.Point(16, 101);
            this.m_lb_implements.Name = "m_lb_implements";
            this.m_lb_implements.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.m_lb_implements.Size = new System.Drawing.Size(124, 124);
            this.m_lb_implements.TabIndex = 11;
            // 
            // m_lb_unImplements
            // 
            this.m_lb_unImplements.FormattingEnabled = true;
            this.m_lb_unImplements.ItemHeight = 12;
            this.m_lb_unImplements.Location = new System.Drawing.Point(204, 101);
            this.m_lb_unImplements.Name = "m_lb_unImplements";
            this.m_lb_unImplements.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.m_lb_unImplements.Size = new System.Drawing.Size(139, 124);
            this.m_lb_unImplements.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(202, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "UnInterfaces:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(158, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // m_lv_properties
            // 
            this.m_lv_properties.FullRowSelect = true;
            this.m_lv_properties.HideSelection = false;
            this.m_lv_properties.Location = new System.Drawing.Point(607, 22);
            this.m_lv_properties.MultiSelect = false;
            this.m_lv_properties.Name = "m_lv_properties";
            this.m_lv_properties.Size = new System.Drawing.Size(494, 203);
            this.m_lv_properties.TabIndex = 16;
            this.m_lv_properties.UseCompatibleStateImageBehavior = false;
            this.m_lv_properties.SelectedIndexChanged += new System.EventHandler(this.m_lv_properties_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(605, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "Properties:";
            // 
            // m_btn_newProperty
            // 
            this.m_btn_newProperty.Location = new System.Drawing.Point(720, 230);
            this.m_btn_newProperty.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_newProperty.Name = "m_btn_newProperty";
            this.m_btn_newProperty.Size = new System.Drawing.Size(62, 28);
            this.m_btn_newProperty.TabIndex = 18;
            this.m_btn_newProperty.Text = "新建";
            this.m_btn_newProperty.UseVisualStyleBackColor = true;
            this.m_btn_newProperty.Click += new System.EventHandler(this.m_btn_newProperty_Click);
            // 
            // m_btn_deleteProperty
            // 
            this.m_btn_deleteProperty.Location = new System.Drawing.Point(830, 230);
            this.m_btn_deleteProperty.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_deleteProperty.Name = "m_btn_deleteProperty";
            this.m_btn_deleteProperty.Size = new System.Drawing.Size(62, 28);
            this.m_btn_deleteProperty.TabIndex = 19;
            this.m_btn_deleteProperty.Text = "删除";
            this.m_btn_deleteProperty.UseVisualStyleBackColor = true;
            this.m_btn_deleteProperty.Click += new System.EventHandler(this.m_btn_deleteProperty_Click);
            // 
            // m_btn_alterProperty
            // 
            this.m_btn_alterProperty.Location = new System.Drawing.Point(940, 230);
            this.m_btn_alterProperty.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_alterProperty.Name = "m_btn_alterProperty";
            this.m_btn_alterProperty.Size = new System.Drawing.Size(62, 28);
            this.m_btn_alterProperty.TabIndex = 20;
            this.m_btn_alterProperty.Text = "修改";
            this.m_btn_alterProperty.UseVisualStyleBackColor = true;
            this.m_btn_alterProperty.Click += new System.EventHandler(this.m_btn_alterProperty_Click);
            // 
            // m_lv_clientMethods
            // 
            this.m_lv_clientMethods.FullRowSelect = true;
            this.m_lv_clientMethods.HideSelection = false;
            this.m_lv_clientMethods.Location = new System.Drawing.Point(16, 309);
            this.m_lv_clientMethods.MultiSelect = false;
            this.m_lv_clientMethods.Name = "m_lv_clientMethods";
            this.m_lv_clientMethods.Size = new System.Drawing.Size(348, 295);
            this.m_lv_clientMethods.TabIndex = 21;
            this.m_lv_clientMethods.UseCompatibleStateImageBehavior = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 294);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "ClientMethods:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(385, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "BaseMethods:";
            // 
            // m_lv_baseMethods
            // 
            this.m_lv_baseMethods.FullRowSelect = true;
            this.m_lv_baseMethods.HideSelection = false;
            this.m_lv_baseMethods.Location = new System.Drawing.Point(385, 309);
            this.m_lv_baseMethods.MultiSelect = false;
            this.m_lv_baseMethods.Name = "m_lv_baseMethods";
            this.m_lv_baseMethods.Size = new System.Drawing.Size(348, 295);
            this.m_lv_baseMethods.TabIndex = 23;
            this.m_lv_baseMethods.UseCompatibleStateImageBehavior = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(753, 294);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "CellMethods:";
            // 
            // m_lv_cellMethods
            // 
            this.m_lv_cellMethods.FullRowSelect = true;
            this.m_lv_cellMethods.HideSelection = false;
            this.m_lv_cellMethods.Location = new System.Drawing.Point(753, 309);
            this.m_lv_cellMethods.MultiSelect = false;
            this.m_lv_cellMethods.Name = "m_lv_cellMethods";
            this.m_lv_cellMethods.Size = new System.Drawing.Size(348, 295);
            this.m_lv_cellMethods.TabIndex = 25;
            this.m_lv_cellMethods.UseCompatibleStateImageBehavior = false;
            // 
            // m_btn_alterClientMethod
            // 
            this.m_btn_alterClientMethod.Location = new System.Drawing.Point(218, 609);
            this.m_btn_alterClientMethod.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_alterClientMethod.Name = "m_btn_alterClientMethod";
            this.m_btn_alterClientMethod.Size = new System.Drawing.Size(62, 28);
            this.m_btn_alterClientMethod.TabIndex = 29;
            this.m_btn_alterClientMethod.Text = "修改";
            this.m_btn_alterClientMethod.UseVisualStyleBackColor = true;
            this.m_btn_alterClientMethod.Click += new System.EventHandler(this.m_btn_alterClientMethod_Click);
            // 
            // m_btn_delClientMethod
            // 
            this.m_btn_delClientMethod.Location = new System.Drawing.Point(144, 609);
            this.m_btn_delClientMethod.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_delClientMethod.Name = "m_btn_delClientMethod";
            this.m_btn_delClientMethod.Size = new System.Drawing.Size(62, 28);
            this.m_btn_delClientMethod.TabIndex = 28;
            this.m_btn_delClientMethod.Text = "删除";
            this.m_btn_delClientMethod.UseVisualStyleBackColor = true;
            this.m_btn_delClientMethod.Click += new System.EventHandler(this.m_btn_delClientMethod_Click);
            // 
            // m_btn_newClientMethod
            // 
            this.m_btn_newClientMethod.Location = new System.Drawing.Point(69, 609);
            this.m_btn_newClientMethod.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_newClientMethod.Name = "m_btn_newClientMethod";
            this.m_btn_newClientMethod.Size = new System.Drawing.Size(62, 28);
            this.m_btn_newClientMethod.TabIndex = 27;
            this.m_btn_newClientMethod.Text = "新建";
            this.m_btn_newClientMethod.UseVisualStyleBackColor = true;
            this.m_btn_newClientMethod.Click += new System.EventHandler(this.m_btn_newClientMethod_Click);
            // 
            // m_btn_alterBaseMethod
            // 
            this.m_btn_alterBaseMethod.Location = new System.Drawing.Point(597, 609);
            this.m_btn_alterBaseMethod.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_alterBaseMethod.Name = "m_btn_alterBaseMethod";
            this.m_btn_alterBaseMethod.Size = new System.Drawing.Size(62, 28);
            this.m_btn_alterBaseMethod.TabIndex = 32;
            this.m_btn_alterBaseMethod.Text = "修改";
            this.m_btn_alterBaseMethod.UseVisualStyleBackColor = true;
            this.m_btn_alterBaseMethod.Click += new System.EventHandler(this.m_btn_alterBaseMethod_Click);
            // 
            // m_btn_delBaseMethod
            // 
            this.m_btn_delBaseMethod.Location = new System.Drawing.Point(515, 609);
            this.m_btn_delBaseMethod.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_delBaseMethod.Name = "m_btn_delBaseMethod";
            this.m_btn_delBaseMethod.Size = new System.Drawing.Size(62, 28);
            this.m_btn_delBaseMethod.TabIndex = 31;
            this.m_btn_delBaseMethod.Text = "删除";
            this.m_btn_delBaseMethod.UseVisualStyleBackColor = true;
            this.m_btn_delBaseMethod.Click += new System.EventHandler(this.m_btn_delBaseMethod_Click);
            // 
            // m_btn_newBaseMethod
            // 
            this.m_btn_newBaseMethod.Location = new System.Drawing.Point(433, 609);
            this.m_btn_newBaseMethod.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_newBaseMethod.Name = "m_btn_newBaseMethod";
            this.m_btn_newBaseMethod.Size = new System.Drawing.Size(62, 28);
            this.m_btn_newBaseMethod.TabIndex = 30;
            this.m_btn_newBaseMethod.Text = "新建";
            this.m_btn_newBaseMethod.UseVisualStyleBackColor = true;
            this.m_btn_newBaseMethod.Click += new System.EventHandler(this.m_btn_newBaseMethod_Click);
            // 
            // m_btn_alterCellMethod
            // 
            this.m_btn_alterCellMethod.Location = new System.Drawing.Point(976, 609);
            this.m_btn_alterCellMethod.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_alterCellMethod.Name = "m_btn_alterCellMethod";
            this.m_btn_alterCellMethod.Size = new System.Drawing.Size(62, 28);
            this.m_btn_alterCellMethod.TabIndex = 35;
            this.m_btn_alterCellMethod.Text = "修改";
            this.m_btn_alterCellMethod.UseVisualStyleBackColor = true;
            this.m_btn_alterCellMethod.Click += new System.EventHandler(this.m_btn_alterCellMethod_Click);
            // 
            // m_btn_delCellMethod
            // 
            this.m_btn_delCellMethod.Location = new System.Drawing.Point(899, 609);
            this.m_btn_delCellMethod.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_delCellMethod.Name = "m_btn_delCellMethod";
            this.m_btn_delCellMethod.Size = new System.Drawing.Size(62, 28);
            this.m_btn_delCellMethod.TabIndex = 34;
            this.m_btn_delCellMethod.Text = "删除";
            this.m_btn_delCellMethod.UseVisualStyleBackColor = true;
            this.m_btn_delCellMethod.Click += new System.EventHandler(this.m_btn_delCellMethod_Click);
            // 
            // m_btn_newCellMethod
            // 
            this.m_btn_newCellMethod.Location = new System.Drawing.Point(822, 609);
            this.m_btn_newCellMethod.Margin = new System.Windows.Forms.Padding(2);
            this.m_btn_newCellMethod.Name = "m_btn_newCellMethod";
            this.m_btn_newCellMethod.Size = new System.Drawing.Size(62, 28);
            this.m_btn_newCellMethod.TabIndex = 33;
            this.m_btn_newCellMethod.Text = "新建";
            this.m_btn_newCellMethod.UseVisualStyleBackColor = true;
            this.m_btn_newCellMethod.Click += new System.EventHandler(this.m_btn_newCellMethod_Click);
            // 
            // EntityDefWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.m_btn_alterCellMethod);
            this.Controls.Add(this.m_btn_delCellMethod);
            this.Controls.Add(this.m_btn_newCellMethod);
            this.Controls.Add(this.m_btn_alterBaseMethod);
            this.Controls.Add(this.m_btn_delBaseMethod);
            this.Controls.Add(this.m_btn_newBaseMethod);
            this.Controls.Add(this.m_btn_alterClientMethod);
            this.Controls.Add(this.m_btn_delClientMethod);
            this.Controls.Add(this.m_btn_newClientMethod);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.m_lv_cellMethods);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_lv_baseMethods);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_lv_clientMethods);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_lb_unImplements);
            this.Controls.Add(this.m_lb_implements);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_cb_hasClient);
            this.Controls.Add(this.m_cb_isRegistered);
            this.Controls.Add(this.m_cbb_parent);
            this.Controls.Add(this.m_cb_isInterface);
            this.Controls.Add(this.m_txt_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btn_alterProperty);
            this.Controls.Add(this.m_btn_deleteProperty);
            this.Controls.Add(this.m_btn_newProperty);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_lv_properties);
            this.Controls.Add(this.label2);
            this.Name = "EntityDefWidget";
            this.Size = new System.Drawing.Size(1116, 653);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txt_name;
		private System.Windows.Forms.CheckBox m_cb_isInterface;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox m_cbb_parent;
		private System.Windows.Forms.CheckBox m_cb_isRegistered;
		private System.Windows.Forms.CheckBox m_cb_hasClient;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txt_position;
		private System.Windows.Forms.TextBox m_txt_pitch;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox m_txt_yaw;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox m_txt_roll;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ListBox m_lb_implements;
		private System.Windows.Forms.ListBox m_lb_unImplements;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListView m_lv_properties;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button m_btn_newProperty;
        private System.Windows.Forms.Button m_btn_deleteProperty;
        private System.Windows.Forms.Button m_btn_alterProperty;
		private System.Windows.Forms.ListView m_lv_clientMethods;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ListView m_lv_baseMethods;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ListView m_lv_cellMethods;
        private System.Windows.Forms.Button m_btn_alterClientMethod;
        private System.Windows.Forms.Button m_btn_delClientMethod;
        private System.Windows.Forms.Button m_btn_newClientMethod;
        private System.Windows.Forms.Button m_btn_alterBaseMethod;
        private System.Windows.Forms.Button m_btn_delBaseMethod;
        private System.Windows.Forms.Button m_btn_newBaseMethod;
        private System.Windows.Forms.Button m_btn_alterCellMethod;
        private System.Windows.Forms.Button m_btn_delCellMethod;
        private System.Windows.Forms.Button m_btn_newCellMethod;
        private System.Windows.Forms.CheckBox optimized;
    }
}
