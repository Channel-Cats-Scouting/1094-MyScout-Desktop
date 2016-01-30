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
            this.MainPnl = new System.Windows.Forms.Panel();
            this.AGroupBx = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.AHighGoalLbl = new System.Windows.Forms.Label();
            this.AHighGoalNUD = new System.Windows.Forms.NumericUpDown();
            this.ALowGoalLbl = new System.Windows.Forms.Label();
            this.ALowGoalNUD = new System.Windows.Forms.NumericUpDown();
            this.ACommentsLbl = new System.Windows.Forms.Label();
            this.ACommentsTxtBx = new System.Windows.Forms.TextBox();
            this.TGroupBx = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.TCommentsLbl = new System.Windows.Forms.Label();
            this.TLowGoalLbl = new System.Windows.Forms.Label();
            this.TLowGoalNUD = new System.Windows.Forms.NumericUpDown();
            this.TScaledTowerChkbx = new System.Windows.Forms.CheckBox();
            this.TChallengedTowerChkbx = new System.Windows.Forms.CheckBox();
            this.TCommentsTxtbx = new System.Windows.Forms.TextBox();
            this.THighGoalLbl = new System.Windows.Forms.Label();
            this.THighGoalNUD = new System.Windows.Forms.NumericUpDown();
            this.RDGroupBx = new System.Windows.Forms.GroupBox();
            this.DiedCombobx = new System.Windows.Forms.ComboBox();
            this.DiedChkbx = new System.Windows.Forms.CheckBox();
            this.RDCommentsLbl = new System.Windows.Forms.Label();
            this.RDComments = new System.Windows.Forms.TextBox();
            this.HPGroupBx = new System.Windows.Forms.GroupBox();
            this.HPCommentsTxtbx = new System.Windows.Forms.TextBox();
            this.AllianceBtnPnl = new System.Windows.Forms.Panel();
            this.BackBtn = new System.Windows.Forms.Button();
            this.BlueAllianceBtn1 = new System.Windows.Forms.Button();
            this.BlueAllianceBtn2 = new System.Windows.Forms.Button();
            this.BlueAllianceBtn3 = new System.Windows.Forms.Button();
            this.RedAllianceBtn1 = new System.Windows.Forms.Button();
            this.RedAllianceBtn2 = new System.Windows.Forms.Button();
            this.RedAllianceBtn3 = new System.Windows.Forms.Button();
            this.EventPnl.SuspendLayout();
            this.HeaderPnl.SuspendLayout();
            this.EventBtnPnl.SuspendLayout();
            this.TeamPnl.SuspendLayout();
            this.TeamNamePnl.SuspendLayout();
            this.MainPnl.SuspendLayout();
            this.AGroupBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AHighGoalNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALowGoalNUD)).BeginInit();
            this.TGroupBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLowGoalNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.THighGoalNUD)).BeginInit();
            this.RDGroupBx.SuspendLayout();
            this.HPGroupBx.SuspendLayout();
            this.AllianceBtnPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChooseAnEventLbl
            // 
            this.ChooseAnEventLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseAnEventLbl.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.ChooseAnEventLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChooseAnEventLbl.Location = new System.Drawing.Point(0, 0);
            this.ChooseAnEventLbl.Name = "ChooseAnEventLbl";
            this.ChooseAnEventLbl.Size = new System.Drawing.Size(596, 69);
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
            this.EventPnl.Size = new System.Drawing.Size(596, 461);
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
            this.EventList.Size = new System.Drawing.Size(596, 339);
            this.EventList.TabIndex = 2;
            this.EventList.UseCompatibleStateImageBehavior = false;
            this.EventList.View = System.Windows.Forms.View.Details;
            this.EventList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EventList_MouseDoubleClick);
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 290;
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
            this.HeaderPnl.Size = new System.Drawing.Size(596, 69);
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
            this.EventBtnPnl.Size = new System.Drawing.Size(596, 53);
            this.EventBtnPnl.TabIndex = 1;
            // 
            // RemoveEventBtn
            // 
            this.RemoveEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RemoveEventBtn.Location = new System.Drawing.Point(3, 0);
            this.RemoveEventBtn.Name = "RemoveEventBtn";
            this.RemoveEventBtn.Size = new System.Drawing.Size(196, 53);
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
            this.EditEventBtn.Location = new System.Drawing.Point(200, 0);
            this.EditEventBtn.Name = "EditEventBtn";
            this.EditEventBtn.Size = new System.Drawing.Size(196, 53);
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
            this.AddEventBtn.Location = new System.Drawing.Point(397, 0);
            this.AddEventBtn.Name = "AddEventBtn";
            this.AddEventBtn.Size = new System.Drawing.Size(196, 53);
            this.AddEventBtn.TabIndex = 0;
            this.AddEventBtn.Text = "&Add Event";
            this.AddEventBtn.UseVisualStyleBackColor = true;
            this.AddEventBtn.Click += new System.EventHandler(this.AddEventBtn_Click);
            // 
            // TeamPnl
            // 
            this.TeamPnl.Controls.Add(this.TeamNamePnl);
            this.TeamPnl.Controls.Add(this.MainPnl);
            this.TeamPnl.Controls.Add(this.AllianceBtnPnl);
            this.TeamPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamPnl.Location = new System.Drawing.Point(0, 0);
            this.TeamPnl.Name = "TeamPnl";
            this.TeamPnl.Size = new System.Drawing.Size(596, 461);
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
            this.TeamNamePnl.Size = new System.Drawing.Size(441, 90);
            this.TeamNamePnl.TabIndex = 3;
            // 
            // TeamNameLbl
            // 
            this.TeamNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamNameLbl.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.TeamNameLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TeamNameLbl.Location = new System.Drawing.Point(0, 0);
            this.TeamNameLbl.Name = "TeamNameLbl";
            this.TeamNameLbl.Size = new System.Drawing.Size(439, 88);
            this.TeamNameLbl.TabIndex = 0;
            this.TeamNameLbl.Text = "No Team Selected";
            this.TeamNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPnl
            // 
            this.MainPnl.Controls.Add(this.AGroupBx);
            this.MainPnl.Controls.Add(this.TGroupBx);
            this.MainPnl.Controls.Add(this.RDGroupBx);
            this.MainPnl.Controls.Add(this.HPGroupBx);
            this.MainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPnl.Enabled = false;
            this.MainPnl.Location = new System.Drawing.Point(155, 0);
            this.MainPnl.Margin = new System.Windows.Forms.Padding(2);
            this.MainPnl.Name = "MainPnl";
            this.MainPnl.Size = new System.Drawing.Size(441, 461);
            this.MainPnl.TabIndex = 14;
            // 
            // AGroupBx
            // 
            this.AGroupBx.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AGroupBx.Controls.Add(this.radioButton3);
            this.AGroupBx.Controls.Add(this.radioButton2);
            this.AGroupBx.Controls.Add(this.radioButton1);
            this.AGroupBx.Controls.Add(this.comboBox1);
            this.AGroupBx.Controls.Add(this.AHighGoalLbl);
            this.AGroupBx.Controls.Add(this.AHighGoalNUD);
            this.AGroupBx.Controls.Add(this.ALowGoalLbl);
            this.AGroupBx.Controls.Add(this.ALowGoalNUD);
            this.AGroupBx.Controls.Add(this.ACommentsLbl);
            this.AGroupBx.Controls.Add(this.ACommentsTxtBx);
            this.AGroupBx.Location = new System.Drawing.Point(3, 93);
            this.AGroupBx.Name = "AGroupBx";
            this.AGroupBx.Size = new System.Drawing.Size(428, 92);
            this.AGroupBx.TabIndex = 4;
            this.AGroupBx.TabStop = false;
            this.AGroupBx.Text = "Autonomous";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton3.Location = new System.Drawing.Point(34, 46);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 18);
            this.radioButton3.TabIndex = 16;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Did nothing";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton2.Location = new System.Drawing.Point(84, 66);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(69, 18);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Crossed";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1.Location = new System.Drawing.Point(6, 66);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 18);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Reached";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Portcullis",
            "Cheval de Frise",
            "Moat",
            "Ramparts",
            "Drawbridge",
            "Sally Port",
            "Rock Wall",
            "Rough Terrain",
            "Low Bar"});
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // AHighGoalLbl
            // 
            this.AHighGoalLbl.AutoSize = true;
            this.AHighGoalLbl.Location = new System.Drawing.Point(151, 12);
            this.AHighGoalLbl.Name = "AHighGoalLbl";
            this.AHighGoalLbl.Size = new System.Drawing.Size(54, 13);
            this.AHighGoalLbl.TabIndex = 10;
            this.AHighGoalLbl.Text = "High Goal";
            // 
            // AHighGoalNUD
            // 
            this.AHighGoalNUD.Location = new System.Drawing.Point(154, 28);
            this.AHighGoalNUD.Name = "AHighGoalNUD";
            this.AHighGoalNUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AHighGoalNUD.Size = new System.Drawing.Size(52, 20);
            this.AHighGoalNUD.TabIndex = 7;
            // 
            // ALowGoalLbl
            // 
            this.ALowGoalLbl.AutoSize = true;
            this.ALowGoalLbl.Location = new System.Drawing.Point(154, 51);
            this.ALowGoalLbl.Name = "ALowGoalLbl";
            this.ALowGoalLbl.Size = new System.Drawing.Size(52, 13);
            this.ALowGoalLbl.TabIndex = 11;
            this.ALowGoalLbl.Text = "Low Goal";
            // 
            // ALowGoalNUD
            // 
            this.ALowGoalNUD.Location = new System.Drawing.Point(154, 65);
            this.ALowGoalNUD.Name = "ALowGoalNUD";
            this.ALowGoalNUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ALowGoalNUD.Size = new System.Drawing.Size(52, 20);
            this.ALowGoalNUD.TabIndex = 8;
            // 
            // ACommentsLbl
            // 
            this.ACommentsLbl.AutoSize = true;
            this.ACommentsLbl.Location = new System.Drawing.Point(212, 28);
            this.ACommentsLbl.Name = "ACommentsLbl";
            this.ACommentsLbl.Size = new System.Drawing.Size(56, 39);
            this.ACommentsLbl.TabIndex = 12;
            this.ACommentsLbl.Text = "Auto\r\nComments\r\n--->\r\n";
            this.ACommentsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ACommentsTxtBx
            // 
            this.ACommentsTxtBx.Location = new System.Drawing.Point(274, 13);
            this.ACommentsTxtBx.Multiline = true;
            this.ACommentsTxtBx.Name = "ACommentsTxtBx";
            this.ACommentsTxtBx.Size = new System.Drawing.Size(147, 70);
            this.ACommentsTxtBx.TabIndex = 9;
            // 
            // TGroupBx
            // 
            this.TGroupBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TGroupBx.Controls.Add(this.label1);
            this.TGroupBx.Controls.Add(this.radioButton4);
            this.TGroupBx.Controls.Add(this.radioButton6);
            this.TGroupBx.Controls.Add(this.numericUpDown2);
            this.TGroupBx.Controls.Add(this.comboBox2);
            this.TGroupBx.Controls.Add(this.TCommentsLbl);
            this.TGroupBx.Controls.Add(this.TLowGoalLbl);
            this.TGroupBx.Controls.Add(this.TLowGoalNUD);
            this.TGroupBx.Controls.Add(this.TScaledTowerChkbx);
            this.TGroupBx.Controls.Add(this.TChallengedTowerChkbx);
            this.TGroupBx.Controls.Add(this.TCommentsTxtbx);
            this.TGroupBx.Controls.Add(this.THighGoalLbl);
            this.TGroupBx.Controls.Add(this.THighGoalNUD);
            this.TGroupBx.Location = new System.Drawing.Point(4, 192);
            this.TGroupBx.Name = "TGroupBx";
            this.TGroupBx.Size = new System.Drawing.Size(265, 257);
            this.TGroupBx.TabIndex = 5;
            this.TGroupBx.TabStop = false;
            this.TGroupBx.Text = "Tele-Op";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Defenses:\r\n";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Enabled = false;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton4.Location = new System.Drawing.Point(6, 58);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(85, 18);
            this.radioButton4.TabIndex = 29;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Did nothing";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Enabled = false;
            this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton6.Location = new System.Drawing.Point(6, 78);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(75, 18);
            this.radioButton6.TabIndex = 27;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Reached";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(87, 78);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown2.TabIndex = 26;
            // 
            // comboBox2
            // 
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Portcullis",
            "Cheval de Frise",
            "Moat",
            "Ramparts",
            "Drawbridge",
            "Sally Port",
            "Rock Wall",
            "Rough Terrain",
            "Low Bar"});
            this.comboBox2.Location = new System.Drawing.Point(6, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(135, 21);
            this.comboBox2.TabIndex = 17;
            // 
            // TCommentsLbl
            // 
            this.TCommentsLbl.AutoSize = true;
            this.TCommentsLbl.Location = new System.Drawing.Point(159, 13);
            this.TCommentsLbl.Name = "TCommentsLbl";
            this.TCommentsLbl.Size = new System.Drawing.Size(100, 13);
            this.TCommentsLbl.TabIndex = 23;
            this.TCommentsLbl.Text = "Tele-Op Comments:\r\n";
            // 
            // TLowGoalLbl
            // 
            this.TLowGoalLbl.AutoSize = true;
            this.TLowGoalLbl.Location = new System.Drawing.Point(6, 164);
            this.TLowGoalLbl.Name = "TLowGoalLbl";
            this.TLowGoalLbl.Size = new System.Drawing.Size(52, 13);
            this.TLowGoalLbl.TabIndex = 19;
            this.TLowGoalLbl.Text = "Low Goal";
            this.TLowGoalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLowGoalNUD
            // 
            this.TLowGoalNUD.Location = new System.Drawing.Point(9, 180);
            this.TLowGoalNUD.Name = "TLowGoalNUD";
            this.TLowGoalNUD.Size = new System.Drawing.Size(62, 20);
            this.TLowGoalNUD.TabIndex = 18;
            // 
            // TScaledTowerChkbx
            // 
            this.TScaledTowerChkbx.AutoSize = true;
            this.TScaledTowerChkbx.Location = new System.Drawing.Point(9, 211);
            this.TScaledTowerChkbx.Name = "TScaledTowerChkbx";
            this.TScaledTowerChkbx.Size = new System.Drawing.Size(92, 17);
            this.TScaledTowerChkbx.TabIndex = 25;
            this.TScaledTowerChkbx.Text = "Scaled Tower";
            this.TScaledTowerChkbx.UseVisualStyleBackColor = true;
            // 
            // TChallengedTowerChkbx
            // 
            this.TChallengedTowerChkbx.AutoSize = true;
            this.TChallengedTowerChkbx.Location = new System.Drawing.Point(9, 228);
            this.TChallengedTowerChkbx.Name = "TChallengedTowerChkbx";
            this.TChallengedTowerChkbx.Size = new System.Drawing.Size(112, 17);
            this.TChallengedTowerChkbx.TabIndex = 24;
            this.TChallengedTowerChkbx.Text = "Challenged Tower";
            this.TChallengedTowerChkbx.UseVisualStyleBackColor = true;
            // 
            // TCommentsTxtbx
            // 
            this.TCommentsTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCommentsTxtbx.Location = new System.Drawing.Point(166, 31);
            this.TCommentsTxtbx.Multiline = true;
            this.TCommentsTxtbx.Name = "TCommentsTxtbx";
            this.TCommentsTxtbx.Size = new System.Drawing.Size(82, 220);
            this.TCommentsTxtbx.TabIndex = 22;
            // 
            // THighGoalLbl
            // 
            this.THighGoalLbl.AutoSize = true;
            this.THighGoalLbl.Location = new System.Drawing.Point(84, 163);
            this.THighGoalLbl.Name = "THighGoalLbl";
            this.THighGoalLbl.Size = new System.Drawing.Size(54, 13);
            this.THighGoalLbl.TabIndex = 21;
            this.THighGoalLbl.Text = "High Goal";
            // 
            // THighGoalNUD
            // 
            this.THighGoalNUD.Location = new System.Drawing.Point(87, 180);
            this.THighGoalNUD.Name = "THighGoalNUD";
            this.THighGoalNUD.Size = new System.Drawing.Size(62, 20);
            this.THighGoalNUD.TabIndex = 20;
            // 
            // RDGroupBx
            // 
            this.RDGroupBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RDGroupBx.Controls.Add(this.DiedCombobx);
            this.RDGroupBx.Controls.Add(this.DiedChkbx);
            this.RDGroupBx.Controls.Add(this.RDCommentsLbl);
            this.RDGroupBx.Controls.Add(this.RDComments);
            this.RDGroupBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDGroupBx.Location = new System.Drawing.Point(278, 192);
            this.RDGroupBx.Name = "RDGroupBx";
            this.RDGroupBx.Size = new System.Drawing.Size(151, 155);
            this.RDGroupBx.TabIndex = 6;
            this.RDGroupBx.TabStop = false;
            this.RDGroupBx.Text = "DEATH";
            // 
            // DiedCombobx
            // 
            this.DiedCombobx.Enabled = false;
            this.DiedCombobx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DiedCombobx.FormattingEnabled = true;
            this.DiedCombobx.Items.AddRange(new object[] {
            "Portcullis",
            "Cheval de Frise",
            "Moat",
            "Ramparts",
            "Drawbridge",
            "Sally Port",
            "Rock Wall",
            "Rough Terrain",
            "Low Bar"});
            this.DiedCombobx.Location = new System.Drawing.Point(6, 23);
            this.DiedCombobx.Name = "DiedCombobx";
            this.DiedCombobx.Size = new System.Drawing.Size(135, 21);
            this.DiedCombobx.TabIndex = 31;
            // 
            // DiedChkbx
            // 
            this.DiedChkbx.AutoSize = true;
            this.DiedChkbx.Location = new System.Drawing.Point(9, 0);
            this.DiedChkbx.Name = "DiedChkbx";
            this.DiedChkbx.Size = new System.Drawing.Size(52, 17);
            this.DiedChkbx.TabIndex = 3;
            this.DiedChkbx.Text = "Died";
            this.DiedChkbx.UseVisualStyleBackColor = true;
            this.DiedChkbx.CheckedChanged += new System.EventHandler(this.DiedChkbx_CheckedChanged);
            // 
            // RDCommentsLbl
            // 
            this.RDCommentsLbl.AutoSize = true;
            this.RDCommentsLbl.Enabled = false;
            this.RDCommentsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDCommentsLbl.Location = new System.Drawing.Point(32, 52);
            this.RDCommentsLbl.Name = "RDCommentsLbl";
            this.RDCommentsLbl.Size = new System.Drawing.Size(91, 13);
            this.RDCommentsLbl.TabIndex = 24;
            this.RDCommentsLbl.Text = "Death Comments:";
            this.RDCommentsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RDComments
            // 
            this.RDComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.RDComments.Enabled = false;
            this.RDComments.Location = new System.Drawing.Point(6, 68);
            this.RDComments.Multiline = true;
            this.RDComments.Name = "RDComments";
            this.RDComments.Size = new System.Drawing.Size(140, 81);
            this.RDComments.TabIndex = 23;
            // 
            // HPGroupBx
            // 
            this.HPGroupBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HPGroupBx.Controls.Add(this.HPCommentsTxtbx);
            this.HPGroupBx.Location = new System.Drawing.Point(278, 348);
            this.HPGroupBx.Name = "HPGroupBx";
            this.HPGroupBx.Size = new System.Drawing.Size(153, 101);
            this.HPGroupBx.TabIndex = 7;
            this.HPGroupBx.TabStop = false;
            this.HPGroupBx.Text = "Human Player";
            // 
            // HPCommentsTxtbx
            // 
            this.HPCommentsTxtbx.Location = new System.Drawing.Point(6, 19);
            this.HPCommentsTxtbx.Multiline = true;
            this.HPCommentsTxtbx.Name = "HPCommentsTxtbx";
            this.HPCommentsTxtbx.Size = new System.Drawing.Size(140, 76);
            this.HPCommentsTxtbx.TabIndex = 1;
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
            this.BlueAllianceBtn1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BlueAllianceBtn1.FlatAppearance.BorderSize = 0;
            this.BlueAllianceBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlueAllianceBtn1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.BlueAllianceBtn1.ForeColor = System.Drawing.Color.White;
            this.BlueAllianceBtn1.Location = new System.Drawing.Point(12, 257);
            this.BlueAllianceBtn1.Name = "BlueAllianceBtn1";
            this.BlueAllianceBtn1.Size = new System.Drawing.Size(128, 55);
            this.BlueAllianceBtn1.TabIndex = 4;
            this.BlueAllianceBtn1.Text = "----";
            this.BlueAllianceBtn1.UseVisualStyleBackColor = false;
            this.BlueAllianceBtn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamBtn_MouseClick);
            // 
            // BlueAllianceBtn2
            // 
            this.BlueAllianceBtn2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueAllianceBtn2.BackColor = System.Drawing.Color.Blue;
            this.BlueAllianceBtn2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BlueAllianceBtn2.FlatAppearance.BorderSize = 0;
            this.BlueAllianceBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlueAllianceBtn2.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.BlueAllianceBtn2.ForeColor = System.Drawing.Color.White;
            this.BlueAllianceBtn2.Location = new System.Drawing.Point(12, 325);
            this.BlueAllianceBtn2.Name = "BlueAllianceBtn2";
            this.BlueAllianceBtn2.Size = new System.Drawing.Size(128, 55);
            this.BlueAllianceBtn2.TabIndex = 5;
            this.BlueAllianceBtn2.Text = "----";
            this.BlueAllianceBtn2.UseVisualStyleBackColor = false;
            this.BlueAllianceBtn2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamBtn_MouseClick);
            // 
            // BlueAllianceBtn3
            // 
            this.BlueAllianceBtn3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueAllianceBtn3.BackColor = System.Drawing.Color.Blue;
            this.BlueAllianceBtn3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BlueAllianceBtn3.FlatAppearance.BorderSize = 0;
            this.BlueAllianceBtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlueAllianceBtn3.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.BlueAllianceBtn3.ForeColor = System.Drawing.Color.White;
            this.BlueAllianceBtn3.Location = new System.Drawing.Point(12, 393);
            this.BlueAllianceBtn3.Name = "BlueAllianceBtn3";
            this.BlueAllianceBtn3.Size = new System.Drawing.Size(128, 55);
            this.BlueAllianceBtn3.TabIndex = 6;
            this.BlueAllianceBtn3.Text = "----";
            this.BlueAllianceBtn3.UseVisualStyleBackColor = false;
            this.BlueAllianceBtn3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamBtn_MouseClick);
            // 
            // RedAllianceBtn1
            // 
            this.RedAllianceBtn1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedAllianceBtn1.BackColor = System.Drawing.Color.Red;
            this.RedAllianceBtn1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RedAllianceBtn1.FlatAppearance.BorderSize = 0;
            this.RedAllianceBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedAllianceBtn1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.RedAllianceBtn1.ForeColor = System.Drawing.Color.White;
            this.RedAllianceBtn1.Location = new System.Drawing.Point(12, 53);
            this.RedAllianceBtn1.Name = "RedAllianceBtn1";
            this.RedAllianceBtn1.Size = new System.Drawing.Size(128, 55);
            this.RedAllianceBtn1.TabIndex = 1;
            this.RedAllianceBtn1.Text = "----";
            this.RedAllianceBtn1.UseVisualStyleBackColor = false;
            this.RedAllianceBtn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamBtn_MouseClick);
            // 
            // RedAllianceBtn2
            // 
            this.RedAllianceBtn2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedAllianceBtn2.BackColor = System.Drawing.Color.Red;
            this.RedAllianceBtn2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RedAllianceBtn2.FlatAppearance.BorderSize = 0;
            this.RedAllianceBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedAllianceBtn2.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.RedAllianceBtn2.ForeColor = System.Drawing.Color.White;
            this.RedAllianceBtn2.Location = new System.Drawing.Point(12, 121);
            this.RedAllianceBtn2.Name = "RedAllianceBtn2";
            this.RedAllianceBtn2.Size = new System.Drawing.Size(128, 55);
            this.RedAllianceBtn2.TabIndex = 2;
            this.RedAllianceBtn2.Text = "----";
            this.RedAllianceBtn2.UseVisualStyleBackColor = false;
            this.RedAllianceBtn2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamBtn_MouseClick);
            // 
            // RedAllianceBtn3
            // 
            this.RedAllianceBtn3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedAllianceBtn3.BackColor = System.Drawing.Color.Red;
            this.RedAllianceBtn3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RedAllianceBtn3.FlatAppearance.BorderSize = 0;
            this.RedAllianceBtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedAllianceBtn3.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.RedAllianceBtn3.ForeColor = System.Drawing.Color.White;
            this.RedAllianceBtn3.Location = new System.Drawing.Point(12, 189);
            this.RedAllianceBtn3.Name = "RedAllianceBtn3";
            this.RedAllianceBtn3.Size = new System.Drawing.Size(128, 55);
            this.RedAllianceBtn3.TabIndex = 3;
            this.RedAllianceBtn3.Text = "----";
            this.RedAllianceBtn3.UseVisualStyleBackColor = false;
            this.RedAllianceBtn3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamBtn_MouseClick);
            // 
            // MainFrm
            // 
            this.AcceptButton = this.AddEventBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(596, 461);
            this.Controls.Add(this.TeamPnl);
            this.Controls.Add(this.EventPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(612, 500);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyScout 2016";
            this.EventPnl.ResumeLayout(false);
            this.HeaderPnl.ResumeLayout(false);
            this.EventBtnPnl.ResumeLayout(false);
            this.TeamPnl.ResumeLayout(false);
            this.TeamNamePnl.ResumeLayout(false);
            this.MainPnl.ResumeLayout(false);
            this.AGroupBx.ResumeLayout(false);
            this.AGroupBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AHighGoalNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALowGoalNUD)).EndInit();
            this.TGroupBx.ResumeLayout(false);
            this.TGroupBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TLowGoalNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.THighGoalNUD)).EndInit();
            this.RDGroupBx.ResumeLayout(false);
            this.RDGroupBx.PerformLayout();
            this.HPGroupBx.ResumeLayout(false);
            this.HPGroupBx.PerformLayout();
            this.AllianceBtnPnl.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox AGroupBx;
        private System.Windows.Forms.GroupBox RDGroupBx;
        private System.Windows.Forms.GroupBox TGroupBx;
        private System.Windows.Forms.Label ACommentsLbl;
        private System.Windows.Forms.Label ALowGoalLbl;
        private System.Windows.Forms.Label AHighGoalLbl;
        private System.Windows.Forms.TextBox ACommentsTxtBx;
        private System.Windows.Forms.NumericUpDown ALowGoalNUD;
        private System.Windows.Forms.NumericUpDown AHighGoalNUD;
        private System.Windows.Forms.GroupBox HPGroupBx;
        private System.Windows.Forms.TextBox HPCommentsTxtbx;
        private System.Windows.Forms.Label TLowGoalLbl;
        private System.Windows.Forms.NumericUpDown TLowGoalNUD;
        private System.Windows.Forms.Label TCommentsLbl;
        private System.Windows.Forms.TextBox TCommentsTxtbx;
        private System.Windows.Forms.Label THighGoalLbl;
        private System.Windows.Forms.NumericUpDown THighGoalNUD;
        private System.Windows.Forms.CheckBox DiedChkbx;
        private System.Windows.Forms.TextBox RDComments;
        private System.Windows.Forms.Label RDCommentsLbl;
        private System.Windows.Forms.CheckBox TScaledTowerChkbx;
        private System.Windows.Forms.CheckBox TChallengedTowerChkbx;
        private System.Windows.Forms.Panel MainPnl;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DiedCombobx;
    }
}

