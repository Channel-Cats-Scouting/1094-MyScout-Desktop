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
            this.TGroupBx = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.TCommentsLbl = new System.Windows.Forms.Label();
            this.TLowGoalLbl = new System.Windows.Forms.Label();
            this.TLowGoalNUD = new System.Windows.Forms.NumericUpDown();
            this.TScaledTowerChkbx = new System.Windows.Forms.CheckBox();
            this.TChallengedTowerChkbx = new System.Windows.Forms.CheckBox();
            this.TCommentsTxtbx = new System.Windows.Forms.TextBox();
            this.THighGoalLbl = new System.Windows.Forms.Label();
            this.THighGoalNUD = new System.Windows.Forms.NumericUpDown();
            this.RDGroupBx = new System.Windows.Forms.GroupBox();
            this.RDDefenseLbl = new System.Windows.Forms.Label();
            this.RDDefenseChkbx = new System.Windows.Forms.ComboBox();
            this.RDDied = new System.Windows.Forms.CheckBox();
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
            this.TGroupBx.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.ChooseAnEventLbl.Size = new System.Drawing.Size(630, 69);
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
            this.EventPnl.Size = new System.Drawing.Size(630, 461);
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
            this.EventList.Size = new System.Drawing.Size(630, 339);
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
            this.HeaderPnl.Size = new System.Drawing.Size(630, 69);
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
            this.EventBtnPnl.Size = new System.Drawing.Size(630, 53);
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
            this.EditEventBtn.Size = new System.Drawing.Size(230, 53);
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
            this.AddEventBtn.Location = new System.Drawing.Point(431, 0);
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
            this.TeamPnl.Size = new System.Drawing.Size(630, 461);
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
            this.TeamNamePnl.Size = new System.Drawing.Size(475, 90);
            this.TeamNamePnl.TabIndex = 3;
            // 
            // TeamNameLbl
            // 
            this.TeamNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamNameLbl.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.TeamNameLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TeamNameLbl.Location = new System.Drawing.Point(0, 0);
            this.TeamNameLbl.Name = "TeamNameLbl";
            this.TeamNameLbl.Size = new System.Drawing.Size(473, 88);
            this.TeamNameLbl.TabIndex = 0;
            this.TeamNameLbl.Text = "No Team Selected";
            this.TeamNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPnl
            // 
            this.MainPnl.Controls.Add(this.TGroupBx);
            this.MainPnl.Controls.Add(this.RDGroupBx);
            this.MainPnl.Controls.Add(this.HPGroupBx);
            this.MainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPnl.Enabled = false;
            this.MainPnl.Location = new System.Drawing.Point(155, 0);
            this.MainPnl.Margin = new System.Windows.Forms.Padding(2);
            this.MainPnl.Name = "MainPnl";
            this.MainPnl.Size = new System.Drawing.Size(475, 461);
            this.MainPnl.TabIndex = 14;
            // 
            // TGroupBx
            // 
            this.TGroupBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TGroupBx.Controls.Add(this.groupBox1);
            this.TGroupBx.Controls.Add(this.radioButton2);
            this.TGroupBx.Controls.Add(this.radioButton1);
            this.TGroupBx.Controls.Add(this.TCommentsLbl);
            this.TGroupBx.Controls.Add(this.TLowGoalLbl);
            this.TGroupBx.Controls.Add(this.TLowGoalNUD);
            this.TGroupBx.Controls.Add(this.TScaledTowerChkbx);
            this.TGroupBx.Controls.Add(this.TChallengedTowerChkbx);
            this.TGroupBx.Controls.Add(this.TCommentsTxtbx);
            this.TGroupBx.Controls.Add(this.THighGoalLbl);
            this.TGroupBx.Controls.Add(this.THighGoalNUD);
            this.TGroupBx.Location = new System.Drawing.Point(4, 96);
            this.TGroupBx.Name = "TGroupBx";
            this.TGroupBx.Size = new System.Drawing.Size(298, 353);
            this.TGroupBx.TabIndex = 5;
            this.TGroupBx.TabStop = false;
            this.TGroupBx.Text = "                                                 ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Location = new System.Drawing.Point(6, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 142);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Defenses";
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
            this.comboBox2.Location = new System.Drawing.Point(9, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(166, 21);
            this.comboBox2.TabIndex = 17;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(43, 104);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(97, 20);
            this.numericUpDown2.TabIndex = 26;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Enabled = false;
            this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton6.Location = new System.Drawing.Point(108, 46);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(75, 18);
            this.radioButton6.TabIndex = 27;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Reached";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Times Crossed:";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Enabled = false;
            this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton4.Location = new System.Drawing.Point(9, 46);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(85, 18);
            this.radioButton4.TabIndex = 29;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Did nothing";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton2.Location = new System.Drawing.Point(10, -1);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 18);
            this.radioButton2.TabIndex = 32;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Autonomous";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1.Location = new System.Drawing.Point(106, -1);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 18);
            this.radioButton1.TabIndex = 31;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tele-Op";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // TCommentsLbl
            // 
            this.TCommentsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TCommentsLbl.AutoSize = true;
            this.TCommentsLbl.Location = new System.Drawing.Point(214, 25);
            this.TCommentsLbl.Name = "TCommentsLbl";
            this.TCommentsLbl.Size = new System.Drawing.Size(59, 13);
            this.TCommentsLbl.TabIndex = 23;
            this.TCommentsLbl.Text = "Comments:\r\n";
            // 
            // TLowGoalLbl
            // 
            this.TLowGoalLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TLowGoalLbl.AutoSize = true;
            this.TLowGoalLbl.Location = new System.Drawing.Point(6, 221);
            this.TLowGoalLbl.Name = "TLowGoalLbl";
            this.TLowGoalLbl.Size = new System.Drawing.Size(52, 13);
            this.TLowGoalLbl.TabIndex = 19;
            this.TLowGoalLbl.Text = "Low Goal";
            this.TLowGoalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLowGoalNUD
            // 
            this.TLowGoalNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TLowGoalNUD.Location = new System.Drawing.Point(9, 238);
            this.TLowGoalNUD.Name = "TLowGoalNUD";
            this.TLowGoalNUD.Size = new System.Drawing.Size(62, 20);
            this.TLowGoalNUD.TabIndex = 18;
            // 
            // TScaledTowerChkbx
            // 
            this.TScaledTowerChkbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TScaledTowerChkbx.AutoSize = true;
            this.TScaledTowerChkbx.Enabled = false;
            this.TScaledTowerChkbx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TScaledTowerChkbx.Location = new System.Drawing.Point(9, 295);
            this.TScaledTowerChkbx.Name = "TScaledTowerChkbx";
            this.TScaledTowerChkbx.Size = new System.Drawing.Size(98, 18);
            this.TScaledTowerChkbx.TabIndex = 25;
            this.TScaledTowerChkbx.Text = "Scaled Tower";
            this.TScaledTowerChkbx.UseVisualStyleBackColor = true;
            // 
            // TChallengedTowerChkbx
            // 
            this.TChallengedTowerChkbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TChallengedTowerChkbx.AutoSize = true;
            this.TChallengedTowerChkbx.Enabled = false;
            this.TChallengedTowerChkbx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TChallengedTowerChkbx.Location = new System.Drawing.Point(9, 312);
            this.TChallengedTowerChkbx.Name = "TChallengedTowerChkbx";
            this.TChallengedTowerChkbx.Size = new System.Drawing.Size(118, 18);
            this.TChallengedTowerChkbx.TabIndex = 24;
            this.TChallengedTowerChkbx.Text = "Challenged Tower";
            this.TChallengedTowerChkbx.UseVisualStyleBackColor = true;
            // 
            // TCommentsTxtbx
            // 
            this.TCommentsTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCommentsTxtbx.Location = new System.Drawing.Point(195, 44);
            this.TCommentsTxtbx.Multiline = true;
            this.TCommentsTxtbx.Name = "TCommentsTxtbx";
            this.TCommentsTxtbx.Size = new System.Drawing.Size(97, 301);
            this.TCommentsTxtbx.TabIndex = 22;
            // 
            // THighGoalLbl
            // 
            this.THighGoalLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.THighGoalLbl.AutoSize = true;
            this.THighGoalLbl.Location = new System.Drawing.Point(111, 221);
            this.THighGoalLbl.Name = "THighGoalLbl";
            this.THighGoalLbl.Size = new System.Drawing.Size(54, 13);
            this.THighGoalLbl.TabIndex = 21;
            this.THighGoalLbl.Text = "High Goal";
            // 
            // THighGoalNUD
            // 
            this.THighGoalNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.THighGoalNUD.Location = new System.Drawing.Point(114, 238);
            this.THighGoalNUD.Name = "THighGoalNUD";
            this.THighGoalNUD.Size = new System.Drawing.Size(62, 20);
            this.THighGoalNUD.TabIndex = 20;
            // 
            // RDGroupBx
            // 
            this.RDGroupBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RDGroupBx.Controls.Add(this.RDDefenseLbl);
            this.RDGroupBx.Controls.Add(this.RDDefenseChkbx);
            this.RDGroupBx.Controls.Add(this.RDDied);
            this.RDGroupBx.Controls.Add(this.RDCommentsLbl);
            this.RDGroupBx.Controls.Add(this.RDComments);
            this.RDGroupBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDGroupBx.Location = new System.Drawing.Point(314, 96);
            this.RDGroupBx.Name = "RDGroupBx";
            this.RDGroupBx.Size = new System.Drawing.Size(151, 184);
            this.RDGroupBx.TabIndex = 6;
            this.RDGroupBx.TabStop = false;
            this.RDGroupBx.Text = "     ";
            // 
            // RDDefenseLbl
            // 
            this.RDDefenseLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RDDefenseLbl.AutoSize = true;
            this.RDDefenseLbl.Enabled = false;
            this.RDDefenseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDDefenseLbl.Location = new System.Drawing.Point(8, 24);
            this.RDDefenseLbl.Name = "RDDefenseLbl";
            this.RDDefenseLbl.Size = new System.Drawing.Size(135, 13);
            this.RDDefenseLbl.TabIndex = 32;
            this.RDDefenseLbl.Text = "Defense That Killed Robot:";
            // 
            // RDDefenseChkbx
            // 
            this.RDDefenseChkbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RDDefenseChkbx.Enabled = false;
            this.RDDefenseChkbx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RDDefenseChkbx.FormattingEnabled = true;
            this.RDDefenseChkbx.Items.AddRange(new object[] {
            "Portcullis",
            "Cheval de Frise",
            "Moat",
            "Ramparts",
            "Drawbridge",
            "Sally Port",
            "Rock Wall",
            "Rough Terrain",
            "Low Bar"});
            this.RDDefenseChkbx.Location = new System.Drawing.Point(8, 40);
            this.RDDefenseChkbx.Name = "RDDefenseChkbx";
            this.RDDefenseChkbx.Size = new System.Drawing.Size(135, 21);
            this.RDDefenseChkbx.TabIndex = 31;
            // 
            // RDDied
            // 
            this.RDDied.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RDDied.AutoSize = true;
            this.RDDied.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDDied.Location = new System.Drawing.Point(9, 0);
            this.RDDied.Name = "RDDied";
            this.RDDied.Size = new System.Drawing.Size(52, 17);
            this.RDDied.TabIndex = 3;
            this.RDDied.Text = "Died";
            this.RDDied.UseVisualStyleBackColor = true;
            this.RDDied.CheckedChanged += new System.EventHandler(this.DiedChkbx_CheckedChanged);
            // 
            // RDCommentsLbl
            // 
            this.RDCommentsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RDCommentsLbl.AutoSize = true;
            this.RDCommentsLbl.Enabled = false;
            this.RDCommentsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDCommentsLbl.Location = new System.Drawing.Point(32, 73);
            this.RDCommentsLbl.Name = "RDCommentsLbl";
            this.RDCommentsLbl.Size = new System.Drawing.Size(91, 13);
            this.RDCommentsLbl.TabIndex = 24;
            this.RDCommentsLbl.Text = "Death Comments:";
            this.RDCommentsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RDComments
            // 
            this.RDComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RDComments.Enabled = false;
            this.RDComments.Location = new System.Drawing.Point(6, 93);
            this.RDComments.Multiline = true;
            this.RDComments.Name = "RDComments";
            this.RDComments.Size = new System.Drawing.Size(140, 85);
            this.RDComments.TabIndex = 23;
            // 
            // HPGroupBx
            // 
            this.HPGroupBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HPGroupBx.Controls.Add(this.HPCommentsTxtbx);
            this.HPGroupBx.Location = new System.Drawing.Point(312, 286);
            this.HPGroupBx.Name = "HPGroupBx";
            this.HPGroupBx.Size = new System.Drawing.Size(153, 163);
            this.HPGroupBx.TabIndex = 7;
            this.HPGroupBx.TabStop = false;
            this.HPGroupBx.Text = "Human Player";
            // 
            // HPCommentsTxtbx
            // 
            this.HPCommentsTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HPCommentsTxtbx.Location = new System.Drawing.Point(6, 19);
            this.HPCommentsTxtbx.Multiline = true;
            this.HPCommentsTxtbx.Name = "HPCommentsTxtbx";
            this.HPCommentsTxtbx.Size = new System.Drawing.Size(140, 136);
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
            this.ClientSize = new System.Drawing.Size(630, 461);
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
            this.TGroupBx.ResumeLayout(false);
            this.TGroupBx.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox RDGroupBx;
        private System.Windows.Forms.GroupBox TGroupBx;
        private System.Windows.Forms.GroupBox HPGroupBx;
        private System.Windows.Forms.TextBox HPCommentsTxtbx;
        private System.Windows.Forms.Label TLowGoalLbl;
        private System.Windows.Forms.NumericUpDown TLowGoalNUD;
        private System.Windows.Forms.Label TCommentsLbl;
        private System.Windows.Forms.TextBox TCommentsTxtbx;
        private System.Windows.Forms.Label THighGoalLbl;
        private System.Windows.Forms.NumericUpDown THighGoalNUD;
        private System.Windows.Forms.CheckBox RDDied;
        private System.Windows.Forms.TextBox RDComments;
        private System.Windows.Forms.Label RDCommentsLbl;
        private System.Windows.Forms.CheckBox TScaledTowerChkbx;
        private System.Windows.Forms.CheckBox TChallengedTowerChkbx;
        private System.Windows.Forms.Panel MainPnl;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox RDDefenseChkbx;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RDDefenseLbl;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

