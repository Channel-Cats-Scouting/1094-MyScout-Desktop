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
            this.DefenseGBx = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DefenseCBx = new System.Windows.Forms.ComboBox();
            this.ReachedRB = new System.Windows.Forms.RadioButton();
            this.TimesCrossedLbl = new System.Windows.Forms.Label();
            this.DidNothingRB = new System.Windows.Forms.RadioButton();
            this.TimesCrossed = new System.Windows.Forms.Label();
            this.AutonomousRB = new System.Windows.Forms.RadioButton();
            this.TeleOpRB = new System.Windows.Forms.RadioButton();
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
            this.DefenseGBx.SuspendLayout();
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
            this.ChooseAnEventLbl.Size = new System.Drawing.Size(781, 69);
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
            this.EventPnl.Size = new System.Drawing.Size(781, 561);
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
            this.EventList.Size = new System.Drawing.Size(781, 439);
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
            this.HeaderPnl.Size = new System.Drawing.Size(781, 69);
            this.HeaderPnl.TabIndex = 3;
            // 
            // EventBtnPnl
            // 
            this.EventBtnPnl.Controls.Add(this.RemoveEventBtn);
            this.EventBtnPnl.Controls.Add(this.EditEventBtn);
            this.EventBtnPnl.Controls.Add(this.AddEventBtn);
            this.EventBtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EventBtnPnl.Location = new System.Drawing.Point(0, 508);
            this.EventBtnPnl.Name = "EventBtnPnl";
            this.EventBtnPnl.Size = new System.Drawing.Size(781, 53);
            this.EventBtnPnl.TabIndex = 1;
            // 
            // RemoveEventBtn
            // 
            this.RemoveEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RemoveEventBtn.Location = new System.Drawing.Point(3, 0);
            this.RemoveEventBtn.Name = "RemoveEventBtn";
            this.RemoveEventBtn.Size = new System.Drawing.Size(234, 53);
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
            this.EditEventBtn.Location = new System.Drawing.Point(243, 0);
            this.EditEventBtn.Name = "EditEventBtn";
            this.EditEventBtn.Size = new System.Drawing.Size(295, 53);
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
            this.AddEventBtn.Location = new System.Drawing.Point(544, 0);
            this.AddEventBtn.Name = "AddEventBtn";
            this.AddEventBtn.Size = new System.Drawing.Size(234, 53);
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
            this.TeamPnl.Size = new System.Drawing.Size(781, 561);
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
            this.TeamNamePnl.Size = new System.Drawing.Size(626, 90);
            this.TeamNamePnl.TabIndex = 3;
            // 
            // TeamNameLbl
            // 
            this.TeamNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamNameLbl.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.TeamNameLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TeamNameLbl.Location = new System.Drawing.Point(0, 0);
            this.TeamNameLbl.Name = "TeamNameLbl";
            this.TeamNameLbl.Size = new System.Drawing.Size(624, 88);
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
            this.MainPnl.Size = new System.Drawing.Size(626, 561);
            this.MainPnl.TabIndex = 14;
            // 
            // TGroupBx
            // 
            this.TGroupBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TGroupBx.Controls.Add(this.DefenseGBx);
            this.TGroupBx.Controls.Add(this.AutonomousRB);
            this.TGroupBx.Controls.Add(this.TeleOpRB);
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
            this.TGroupBx.Size = new System.Drawing.Size(298, 453);
            this.TGroupBx.TabIndex = 5;
            this.TGroupBx.TabStop = false;
            this.TGroupBx.Text = "                                                 ";
            // 
            // DefenseGBx
            // 
            this.DefenseGBx.Controls.Add(this.button3);
            this.DefenseGBx.Controls.Add(this.button4);
            this.DefenseGBx.Controls.Add(this.button2);
            this.DefenseGBx.Controls.Add(this.button1);
            this.DefenseGBx.Controls.Add(this.DefenseCBx);
            this.DefenseGBx.Controls.Add(this.ReachedRB);
            this.DefenseGBx.Controls.Add(this.TimesCrossedLbl);
            this.DefenseGBx.Controls.Add(this.DidNothingRB);
            this.DefenseGBx.Controls.Add(this.TimesCrossed);
            this.DefenseGBx.Location = new System.Drawing.Point(6, 38);
            this.DefenseGBx.Name = "DefenseGBx";
            this.DefenseGBx.Size = new System.Drawing.Size(183, 274);
            this.DefenseGBx.TabIndex = 33;
            this.DefenseGBx.TabStop = false;
            this.DefenseGBx.Text = "Defenses";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(8, 231);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 33);
            this.button3.TabIndex = 33;
            this.button3.Text = "▼";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Location = new System.Drawing.Point(8, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 33);
            this.button4.TabIndex = 32;
            this.button4.Text = "▲";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(8, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "▼";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(8, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "▲";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DefenseCBx
            // 
            this.DefenseCBx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DefenseCBx.FormattingEnabled = true;
            this.DefenseCBx.Items.AddRange(new object[] {
            "Portcullis",
            "Cheval de Frise",
            "Moat",
            "Ramparts",
            "Drawbridge",
            "Sally Port",
            "Rock Wall",
            "Rough Terrain",
            "Low Bar"});
            this.DefenseCBx.Location = new System.Drawing.Point(8, 45);
            this.DefenseCBx.Name = "DefenseCBx";
            this.DefenseCBx.Size = new System.Drawing.Size(166, 21);
            this.DefenseCBx.TabIndex = 17;
            this.DefenseCBx.SelectedIndexChanged += new System.EventHandler(this.DefenseCBx_SelectedIndexChanged);
            // 
            // ReachedRB
            // 
            this.ReachedRB.AutoSize = true;
            this.ReachedRB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ReachedRB.Location = new System.Drawing.Point(108, 107);
            this.ReachedRB.Name = "ReachedRB";
            this.ReachedRB.Size = new System.Drawing.Size(75, 18);
            this.ReachedRB.TabIndex = 27;
            this.ReachedRB.TabStop = true;
            this.ReachedRB.Text = "Reached";
            this.ReachedRB.UseVisualStyleBackColor = true;
            this.ReachedRB.CheckedChanged += new System.EventHandler(this.ReachedRB_CheckedChanged);
            // 
            // TimesCrossedLbl
            // 
            this.TimesCrossedLbl.AutoSize = true;
            this.TimesCrossedLbl.Enabled = false;
            this.TimesCrossedLbl.Location = new System.Drawing.Point(52, 129);
            this.TimesCrossedLbl.Name = "TimesCrossedLbl";
            this.TimesCrossedLbl.Size = new System.Drawing.Size(79, 13);
            this.TimesCrossedLbl.TabIndex = 27;
            this.TimesCrossedLbl.Text = "Times Crossed:";
            // 
            // DidNothingRB
            // 
            this.DidNothingRB.AutoSize = true;
            this.DidNothingRB.Checked = true;
            this.DidNothingRB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DidNothingRB.Location = new System.Drawing.Point(9, 107);
            this.DidNothingRB.Name = "DidNothingRB";
            this.DidNothingRB.Size = new System.Drawing.Size(85, 18);
            this.DidNothingRB.TabIndex = 29;
            this.DidNothingRB.TabStop = true;
            this.DidNothingRB.Text = "Did nothing";
            this.DidNothingRB.UseVisualStyleBackColor = true;
            // 
            // TimesCrossed
            // 
            this.TimesCrossed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimesCrossed.Enabled = false;
            this.TimesCrossed.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.TimesCrossed.Location = new System.Drawing.Point(3, 16);
            this.TimesCrossed.Name = "TimesCrossed";
            this.TimesCrossed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.TimesCrossed.Size = new System.Drawing.Size(177, 255);
            this.TimesCrossed.TabIndex = 34;
            this.TimesCrossed.Text = "0";
            this.TimesCrossed.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // AutonomousRB
            // 
            this.AutonomousRB.AutoSize = true;
            this.AutonomousRB.Checked = true;
            this.AutonomousRB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AutonomousRB.Location = new System.Drawing.Point(10, -1);
            this.AutonomousRB.Name = "AutonomousRB";
            this.AutonomousRB.Size = new System.Drawing.Size(90, 18);
            this.AutonomousRB.TabIndex = 32;
            this.AutonomousRB.TabStop = true;
            this.AutonomousRB.Text = "Autonomous";
            this.AutonomousRB.UseVisualStyleBackColor = true;
            // 
            // TeleOpRB
            // 
            this.TeleOpRB.AutoSize = true;
            this.TeleOpRB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TeleOpRB.Location = new System.Drawing.Point(106, -1);
            this.TeleOpRB.Name = "TeleOpRB";
            this.TeleOpRB.Size = new System.Drawing.Size(69, 18);
            this.TeleOpRB.TabIndex = 31;
            this.TeleOpRB.TabStop = true;
            this.TeleOpRB.Text = "Tele-Op";
            this.TeleOpRB.UseVisualStyleBackColor = true;
            this.TeleOpRB.CheckedChanged += new System.EventHandler(this.TeleOpRB_CheckedChanged);
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
            this.TLowGoalLbl.Location = new System.Drawing.Point(6, 350);
            this.TLowGoalLbl.Name = "TLowGoalLbl";
            this.TLowGoalLbl.Size = new System.Drawing.Size(52, 13);
            this.TLowGoalLbl.TabIndex = 19;
            this.TLowGoalLbl.Text = "Low Goal";
            this.TLowGoalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLowGoalNUD
            // 
            this.TLowGoalNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TLowGoalNUD.Location = new System.Drawing.Point(9, 367);
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
            this.TScaledTowerChkbx.Location = new System.Drawing.Point(9, 407);
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
            this.TChallengedTowerChkbx.Location = new System.Drawing.Point(9, 424);
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
            this.TCommentsTxtbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TCommentsTxtbx.Location = new System.Drawing.Point(195, 44);
            this.TCommentsTxtbx.Multiline = true;
            this.TCommentsTxtbx.Name = "TCommentsTxtbx";
            this.TCommentsTxtbx.Size = new System.Drawing.Size(97, 401);
            this.TCommentsTxtbx.TabIndex = 22;
            // 
            // THighGoalLbl
            // 
            this.THighGoalLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.THighGoalLbl.AutoSize = true;
            this.THighGoalLbl.Location = new System.Drawing.Point(111, 350);
            this.THighGoalLbl.Name = "THighGoalLbl";
            this.THighGoalLbl.Size = new System.Drawing.Size(54, 13);
            this.THighGoalLbl.TabIndex = 21;
            this.THighGoalLbl.Text = "High Goal";
            // 
            // THighGoalNUD
            // 
            this.THighGoalNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.THighGoalNUD.Location = new System.Drawing.Point(114, 367);
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
            this.RDGroupBx.Location = new System.Drawing.Point(468, 96);
            this.RDGroupBx.Name = "RDGroupBx";
            this.RDGroupBx.Size = new System.Drawing.Size(151, 284);
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
            this.RDComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RDComments.Enabled = false;
            this.RDComments.Location = new System.Drawing.Point(6, 93);
            this.RDComments.Multiline = true;
            this.RDComments.Name = "RDComments";
            this.RDComments.Size = new System.Drawing.Size(140, 185);
            this.RDComments.TabIndex = 23;
            // 
            // HPGroupBx
            // 
            this.HPGroupBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HPGroupBx.Controls.Add(this.HPCommentsTxtbx);
            this.HPGroupBx.Location = new System.Drawing.Point(466, 386);
            this.HPGroupBx.Name = "HPGroupBx";
            this.HPGroupBx.Size = new System.Drawing.Size(153, 163);
            this.HPGroupBx.TabIndex = 7;
            this.HPGroupBx.TabStop = false;
            this.HPGroupBx.Text = "Human Player";
            // 
            // HPCommentsTxtbx
            // 
            this.HPCommentsTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HPCommentsTxtbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.AllianceBtnPnl.Size = new System.Drawing.Size(155, 561);
            this.AllianceBtnPnl.TabIndex = 2;
            // 
            // BackBtn
            // 
            this.BackBtn.BackgroundImage = global::MyScout.Properties.Resources.backbtn;
            this.BackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.BlueAllianceBtn1.Location = new System.Drawing.Point(12, 307);
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
            this.BlueAllianceBtn2.Location = new System.Drawing.Point(12, 375);
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
            this.BlueAllianceBtn3.Location = new System.Drawing.Point(12, 443);
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
            this.RedAllianceBtn1.Location = new System.Drawing.Point(12, 103);
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
            this.RedAllianceBtn2.Location = new System.Drawing.Point(12, 171);
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
            this.RedAllianceBtn3.Location = new System.Drawing.Point(12, 239);
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
            this.ClientSize = new System.Drawing.Size(781, 561);
            this.Controls.Add(this.TeamPnl);
            this.Controls.Add(this.EventPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(612, 500);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyScout 2016";
            this.ResizeEnd += new System.EventHandler(this.MainFrm_ResizeEnd);
            this.EventPnl.ResumeLayout(false);
            this.HeaderPnl.ResumeLayout(false);
            this.EventBtnPnl.ResumeLayout(false);
            this.TeamPnl.ResumeLayout(false);
            this.TeamNamePnl.ResumeLayout(false);
            this.MainPnl.ResumeLayout(false);
            this.TGroupBx.ResumeLayout(false);
            this.TGroupBx.PerformLayout();
            this.DefenseGBx.ResumeLayout(false);
            this.DefenseGBx.PerformLayout();
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
        private System.Windows.Forms.RadioButton DidNothingRB;
        private System.Windows.Forms.RadioButton ReachedRB;
        private System.Windows.Forms.ComboBox DefenseCBx;
        private System.Windows.Forms.ComboBox RDDefenseChkbx;
        private System.Windows.Forms.RadioButton AutonomousRB;
        private System.Windows.Forms.RadioButton TeleOpRB;
        private System.Windows.Forms.Label TimesCrossedLbl;
        private System.Windows.Forms.Label RDDefenseLbl;
        private System.Windows.Forms.GroupBox DefenseGBx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label TimesCrossed;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

