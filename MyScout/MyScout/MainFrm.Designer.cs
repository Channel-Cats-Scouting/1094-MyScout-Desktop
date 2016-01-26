namespace MyScout
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.ChooseAnEventLbl = new System.Windows.Forms.Label();
            this.EventPnl = new System.Windows.Forms.Panel();
            this.EventList = new System.Windows.Forms.ListView();
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BeginDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderPnl = new System.Windows.Forms.Panel();
            this.EventBtnPnl = new System.Windows.Forms.Panel();
            this.RemoveEventBtn = new System.Windows.Forms.Button();
            this.EditEventBtn = new System.Windows.Forms.Button();
            this.AddEventBtn = new System.Windows.Forms.Button();
            this.TeamPnl = new System.Windows.Forms.Panel();
            this.TeamNamePnl = new System.Windows.Forms.Panel();
            this.TeamNameLbl = new System.Windows.Forms.Label();
            this.AllianceBtnPnl = new System.Windows.Forms.Panel();
            this.BackBtn = new System.Windows.Forms.Button();
            this.BlueAllianceBtn1 = new System.Windows.Forms.Button();
            this.BlueAllianceBtn2 = new System.Windows.Forms.Button();
            this.BlueAllianceBtn3 = new System.Windows.Forms.Button();
            this.RedAllianceBtn1 = new System.Windows.Forms.Button();
            this.RedAllianceBtn2 = new System.Windows.Forms.Button();
            this.RedAllianceBtn3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EventPnl.SuspendLayout();
            this.HeaderPnl.SuspendLayout();
            this.EventBtnPnl.SuspendLayout();
            this.TeamPnl.SuspendLayout();
            this.TeamNamePnl.SuspendLayout();
            this.AllianceBtnPnl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // ChooseAnEventLbl
            // 
            this.ChooseAnEventLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseAnEventLbl.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.ChooseAnEventLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChooseAnEventLbl.Location = new System.Drawing.Point(0, 0);
            this.ChooseAnEventLbl.Name = "ChooseAnEventLbl";
            this.ChooseAnEventLbl.Size = new System.Drawing.Size(784, 69);
            this.ChooseAnEventLbl.TabIndex = 0;
            this.ChooseAnEventLbl.Text = "Choose an Event to Begin";
            this.ChooseAnEventLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventPnl
            // 
            this.EventPnl.Controls.Add(this.EventList);
            this.EventPnl.Controls.Add(this.HeaderPnl);
            this.EventPnl.Controls.Add(this.EventBtnPnl);
            this.EventPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventPnl.Location = new System.Drawing.Point(0, 0);
            this.EventPnl.Name = "EventPnl";
            this.EventPnl.Size = new System.Drawing.Size(784, 461);
            this.EventPnl.TabIndex = 1;
            // 
            // EventList
            // 
            this.EventList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.BeginDateHeader,
            this.EndDateHeader});
            this.EventList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventList.FullRowSelect = true;
            this.EventList.Location = new System.Drawing.Point(0, 69);
            this.EventList.MultiSelect = false;
            this.EventList.Name = "EventList";
            this.EventList.Size = new System.Drawing.Size(784, 339);
            this.EventList.TabIndex = 2;
            this.EventList.UseCompatibleStateImageBehavior = false;
            this.EventList.View = System.Windows.Forms.View.Details;
            this.EventList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EventList_MouseDoubleClick);
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 479;
            // 
            // BeginDateHeader
            // 
            this.BeginDateHeader.Text = "Begin Date";
            this.BeginDateHeader.Width = 150;
            // 
            // EndDateHeader
            // 
            this.EndDateHeader.Text = "End Date";
            this.EndDateHeader.Width = 150;
            // 
            // HeaderPnl
            // 
            this.HeaderPnl.Controls.Add(this.ChooseAnEventLbl);
            this.HeaderPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPnl.Location = new System.Drawing.Point(0, 0);
            this.HeaderPnl.Name = "HeaderPnl";
            this.HeaderPnl.Size = new System.Drawing.Size(784, 69);
            this.HeaderPnl.TabIndex = 3;
            // 
            // EventBtnPnl
            // 
            this.EventBtnPnl.Controls.Add(this.RemoveEventBtn);
            this.EventBtnPnl.Controls.Add(this.EditEventBtn);
            this.EventBtnPnl.Controls.Add(this.AddEventBtn);
            this.EventBtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EventBtnPnl.Location = new System.Drawing.Point(0, 408);
            this.EventBtnPnl.Name = "EventBtnPnl";
            this.EventBtnPnl.Size = new System.Drawing.Size(784, 53);
            this.EventBtnPnl.TabIndex = 1;
            // 
            // RemoveEventBtn
            // 
            this.RemoveEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RemoveEventBtn.Location = new System.Drawing.Point(3, 0);
            this.RemoveEventBtn.Name = "RemoveEventBtn";
            this.RemoveEventBtn.Size = new System.Drawing.Size(250, 53);
            this.RemoveEventBtn.TabIndex = 2;
            this.RemoveEventBtn.Text = "&Remove Event";
            this.RemoveEventBtn.UseVisualStyleBackColor = true;
            this.RemoveEventBtn.Click += new System.EventHandler(this.RemoveEventBtn_Click);
            // 
            // EditEventBtn
            // 
            this.EditEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.EditEventBtn.Location = new System.Drawing.Point(267, 0);
            this.EditEventBtn.Name = "EditEventBtn";
            this.EditEventBtn.Size = new System.Drawing.Size(250, 53);
            this.EditEventBtn.TabIndex = 1;
            this.EditEventBtn.Text = "&Edit Event";
            this.EditEventBtn.UseVisualStyleBackColor = true;
            this.EditEventBtn.Click += new System.EventHandler(this.EditEventBtn_Click);
            // 
            // AddEventBtn
            // 
            this.AddEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddEventBtn.Location = new System.Drawing.Point(531, 0);
            this.AddEventBtn.Name = "AddEventBtn";
            this.AddEventBtn.Size = new System.Drawing.Size(250, 53);
            this.AddEventBtn.TabIndex = 0;
            this.AddEventBtn.Text = "&Add Event";
            this.AddEventBtn.UseVisualStyleBackColor = true;
            this.AddEventBtn.Click += new System.EventHandler(this.AddEventBtn_Click);
            // 
            // TeamPnl
            // 
            this.TeamPnl.Controls.Add(this.TeamNamePnl);
            this.TeamPnl.Controls.Add(this.groupBox3);
            this.TeamPnl.Controls.Add(this.groupBox2);
            this.TeamPnl.Controls.Add(this.groupBox1);
            this.TeamPnl.Controls.Add(this.AllianceBtnPnl);
            this.TeamPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamPnl.Location = new System.Drawing.Point(0, 0);
            this.TeamPnl.Name = "TeamPnl";
            this.TeamPnl.Size = new System.Drawing.Size(784, 461);
            this.TeamPnl.TabIndex = 4;
            this.TeamPnl.Visible = false;
            // 
            // TeamNamePnl
            // 
            this.TeamNamePnl.BackColor = System.Drawing.Color.White;
            this.TeamNamePnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeamNamePnl.Controls.Add(this.TeamNameLbl);
            this.TeamNamePnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TeamNamePnl.Location = new System.Drawing.Point(155, 0);
            this.TeamNamePnl.Name = "TeamNamePnl";
            this.TeamNamePnl.Size = new System.Drawing.Size(629, 90);
            this.TeamNamePnl.TabIndex = 3;
            // 
            // TeamNameLbl
            // 
            this.TeamNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamNameLbl.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.TeamNameLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TeamNameLbl.Location = new System.Drawing.Point(0, 0);
            this.TeamNameLbl.Name = "TeamNameLbl";
            this.TeamNameLbl.Size = new System.Drawing.Size(627, 88);
            this.TeamNameLbl.TabIndex = 0;
            this.TeamNameLbl.Text = "No Team Selected";
            this.TeamNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllianceBtnPnl
            // 
            this.AllianceBtnPnl.Controls.Add(this.BackBtn);
            this.AllianceBtnPnl.Controls.Add(this.BlueAllianceBtn1);
            this.AllianceBtnPnl.Controls.Add(this.BlueAllianceBtn2);
            this.AllianceBtnPnl.Controls.Add(this.BlueAllianceBtn3);
            this.AllianceBtnPnl.Controls.Add(this.RedAllianceBtn1);
            this.AllianceBtnPnl.Controls.Add(this.RedAllianceBtn2);
            this.AllianceBtnPnl.Controls.Add(this.RedAllianceBtn3);
            this.AllianceBtnPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.AllianceBtnPnl.Location = new System.Drawing.Point(0, 0);
            this.AllianceBtnPnl.Name = "AllianceBtnPnl";
            this.AllianceBtnPnl.Size = new System.Drawing.Size(155, 461);
            this.AllianceBtnPnl.TabIndex = 2;
            // 
            // BackBtn
            // 
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Image = ((System.Drawing.Image)(resources.GetObject("BackBtn.Image")));
            this.BackBtn.Location = new System.Drawing.Point(7, 3);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(40, 40);
            this.BackBtn.TabIndex = 0;
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // BlueAllianceBtn1
            // 
            this.BlueAllianceBtn1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueAllianceBtn1.BackColor = System.Drawing.Color.Blue;
            this.BlueAllianceBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlueAllianceBtn1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.BlueAllianceBtn1.ForeColor = System.Drawing.Color.White;
            this.BlueAllianceBtn1.Location = new System.Drawing.Point(12, 257);
            this.BlueAllianceBtn1.Name = "BlueAllianceBtn1";
            this.BlueAllianceBtn1.Size = new System.Drawing.Size(128, 55);
            this.BlueAllianceBtn1.TabIndex = 4;
            this.BlueAllianceBtn1.Text = "----";
            this.BlueAllianceBtn1.UseVisualStyleBackColor = false;
            // 
            // BlueAllianceBtn2
            // 
            this.BlueAllianceBtn2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueAllianceBtn2.BackColor = System.Drawing.Color.Blue;
            this.BlueAllianceBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlueAllianceBtn2.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.BlueAllianceBtn2.ForeColor = System.Drawing.Color.White;
            this.BlueAllianceBtn2.Location = new System.Drawing.Point(12, 325);
            this.BlueAllianceBtn2.Name = "BlueAllianceBtn2";
            this.BlueAllianceBtn2.Size = new System.Drawing.Size(128, 55);
            this.BlueAllianceBtn2.TabIndex = 5;
            this.BlueAllianceBtn2.Text = "----";
            this.BlueAllianceBtn2.UseVisualStyleBackColor = false;
            // 
            // BlueAllianceBtn3
            // 
            this.BlueAllianceBtn3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueAllianceBtn3.BackColor = System.Drawing.Color.Blue;
            this.BlueAllianceBtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlueAllianceBtn3.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.BlueAllianceBtn3.ForeColor = System.Drawing.Color.White;
            this.BlueAllianceBtn3.Location = new System.Drawing.Point(12, 393);
            this.BlueAllianceBtn3.Name = "BlueAllianceBtn3";
            this.BlueAllianceBtn3.Size = new System.Drawing.Size(128, 55);
            this.BlueAllianceBtn3.TabIndex = 6;
            this.BlueAllianceBtn3.Text = "----";
            this.BlueAllianceBtn3.UseVisualStyleBackColor = false;
            // 
            // RedAllianceBtn1
            // 
            this.RedAllianceBtn1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedAllianceBtn1.BackColor = System.Drawing.Color.Red;
            this.RedAllianceBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedAllianceBtn1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.RedAllianceBtn1.ForeColor = System.Drawing.Color.White;
            this.RedAllianceBtn1.Location = new System.Drawing.Point(12, 53);
            this.RedAllianceBtn1.Name = "RedAllianceBtn1";
            this.RedAllianceBtn1.Size = new System.Drawing.Size(128, 55);
            this.RedAllianceBtn1.TabIndex = 1;
            this.RedAllianceBtn1.Text = "----";
            this.RedAllianceBtn1.UseVisualStyleBackColor = false;
            // 
            // RedAllianceBtn2
            // 
            this.RedAllianceBtn2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedAllianceBtn2.BackColor = System.Drawing.Color.Red;
            this.RedAllianceBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedAllianceBtn2.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.RedAllianceBtn2.ForeColor = System.Drawing.Color.White;
            this.RedAllianceBtn2.Location = new System.Drawing.Point(12, 121);
            this.RedAllianceBtn2.Name = "RedAllianceBtn2";
            this.RedAllianceBtn2.Size = new System.Drawing.Size(128, 55);
            this.RedAllianceBtn2.TabIndex = 2;
            this.RedAllianceBtn2.Text = "----";
            this.RedAllianceBtn2.UseVisualStyleBackColor = false;
            // 
            // RedAllianceBtn3
            // 
            this.RedAllianceBtn3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedAllianceBtn3.BackColor = System.Drawing.Color.Red;
            this.RedAllianceBtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedAllianceBtn3.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.RedAllianceBtn3.ForeColor = System.Drawing.Color.White;
            this.RedAllianceBtn3.Location = new System.Drawing.Point(12, 189);
            this.RedAllianceBtn3.Name = "RedAllianceBtn3";
            this.RedAllianceBtn3.Size = new System.Drawing.Size(128, 55);
            this.RedAllianceBtn3.TabIndex = 3;
            this.RedAllianceBtn3.Text = "----";
            this.RedAllianceBtn3.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.checkBox9);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(161, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Autonomous";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Portcullis";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(7, 43);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(83, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Tippy Ramp";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(7, 66);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(50, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Moat";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(96, 66);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(76, 17);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "Salley Port";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(96, 43);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(80, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Drawbridge";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(96, 20);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(71, 17);
            this.checkBox6.TabIndex = 3;
            this.checkBox6.Text = "Ramparts";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(185, 43);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(94, 17);
            this.checkBox8.TabIndex = 6;
            this.checkBox8.Text = "Rough Terrain";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(185, 20);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(76, 17);
            this.checkBox9.TabIndex = 5;
            this.checkBox9.Text = "Rock Wall";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(285, 29);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown1.TabIndex = 7;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(285, 66);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown2.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown2.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(429, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 70);
            this.textBox1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "High Goal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Low Goal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 39);
            this.label4.TabIndex = 12;
            this.label4.Text = "Auto\r\nComments\r\n--->\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(163, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 257);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(656, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(116, 211);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // MainFrm
            // 
            this.AcceptButton = this.AddEventBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.TeamPnl);
            this.Controls.Add(this.EventPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyScout 2016";
            this.EventPnl.ResumeLayout(false);
            this.HeaderPnl.ResumeLayout(false);
            this.EventBtnPnl.ResumeLayout(false);
            this.TeamPnl.ResumeLayout(false);
            this.TeamNamePnl.ResumeLayout(false);
            this.AllianceBtnPnl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ChooseAnEventLbl;
        private System.Windows.Forms.Panel EventPnl;
        private System.Windows.Forms.Panel EventBtnPnl;
        private System.Windows.Forms.Button AddEventBtn;
        private System.Windows.Forms.Button RemoveEventBtn;
        private System.Windows.Forms.Button EditEventBtn;
        private System.Windows.Forms.ListView EventList;
        private System.Windows.Forms.Panel HeaderPnl;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ColumnHeader BeginDateHeader;
        private System.Windows.Forms.ColumnHeader EndDateHeader;
        private System.Windows.Forms.Panel TeamPnl;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button RedAllianceBtn1;
        private System.Windows.Forms.Panel AllianceBtnPnl;
        private System.Windows.Forms.Button RedAllianceBtn2;
        private System.Windows.Forms.Button RedAllianceBtn3;
        private System.Windows.Forms.Button BlueAllianceBtn1;
        private System.Windows.Forms.Button BlueAllianceBtn2;
        private System.Windows.Forms.Button BlueAllianceBtn3;
        private System.Windows.Forms.Panel TeamNamePnl;
        private System.Windows.Forms.Label TeamNameLbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}

