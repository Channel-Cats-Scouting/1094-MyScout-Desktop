﻿namespace MyScout
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
            this.GameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BeginDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderPnl = new System.Windows.Forms.Panel();
            this.GameNameLbl = new System.Windows.Forms.Label();
            this.GameDataWarning = new System.Windows.Forms.Label();
            this.MngGamesBtn = new System.Windows.Forms.Button();
            this.EventBtnPnl = new System.Windows.Forms.Panel();
            this.RemoveEventBtn = new System.Windows.Forms.Button();
            this.EditEventBtn = new System.Windows.Forms.Button();
            this.AddEventBtn = new System.Windows.Forms.Button();
            this.preScoutButton = new System.Windows.Forms.Button();
            this.TeamPnl = new System.Windows.Forms.Panel();
            this.TeamNamePnl = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TeamNameLbl = new System.Windows.Forms.Label();
            this.MainPnl = new System.Windows.Forms.Panel();
            this.AllianceBtnPnl = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.RedAllianceBtn1 = new System.Windows.Forms.Button();
            this.RedAllianceBtn2 = new System.Windows.Forms.Button();
            this.RedAllianceBtn3 = new System.Windows.Forms.Button();
            this.BlueAllianceBtn1 = new System.Windows.Forms.Button();
            this.BlueAllianceBtn2 = new System.Windows.Forms.Button();
            this.BlueAllianceBtn3 = new System.Windows.Forms.Button();
            this.EventPnl.SuspendLayout();
            this.HeaderPnl.SuspendLayout();
            this.EventBtnPnl.SuspendLayout();
            this.TeamPnl.SuspendLayout();
            this.TeamNamePnl.SuspendLayout();
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
            this.ChooseAnEventLbl.Size = new System.Drawing.Size(1102, 69);
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
            this.EventPnl.Size = new System.Drawing.Size(1102, 590);
            this.EventPnl.TabIndex = 1;
            // 
            // EventList
            // 
            this.EventList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.GameHeader,
            this.BeginDateHeader,
            this.EndDateHeader});
            this.EventList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventList.FullRowSelect = true;
            this.EventList.Location = new System.Drawing.Point(0, 69);
            this.EventList.MultiSelect = false;
            this.EventList.Name = "EventList";
            this.EventList.Size = new System.Drawing.Size(1102, 468);
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
            // GameHeader
            // 
            this.GameHeader.Text = "Game";
            this.GameHeader.Width = 125;
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
            this.HeaderPnl.Controls.Add(this.GameNameLbl);
            this.HeaderPnl.Controls.Add(this.GameDataWarning);
            this.HeaderPnl.Controls.Add(this.MngGamesBtn);
            this.HeaderPnl.Controls.Add(this.ChooseAnEventLbl);
            this.HeaderPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPnl.Location = new System.Drawing.Point(0, 0);
            this.HeaderPnl.Name = "HeaderPnl";
            this.HeaderPnl.Size = new System.Drawing.Size(1102, 69);
            this.HeaderPnl.TabIndex = 3;
            // 
            // GameNameLbl
            // 
            this.GameNameLbl.AutoSize = true;
            this.GameNameLbl.Location = new System.Drawing.Point(253, 9);
            this.GameNameLbl.MaximumSize = new System.Drawing.Size(125, 0);
            this.GameNameLbl.Name = "GameNameLbl";
            this.GameNameLbl.Size = new System.Drawing.Size(0, 13);
            this.GameNameLbl.TabIndex = 3;
            // 
            // GameDataWarning
            // 
            this.GameDataWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameDataWarning.ForeColor = System.Drawing.Color.Red;
            this.GameDataWarning.Location = new System.Drawing.Point(377, 9);
            this.GameDataWarning.Name = "GameDataWarning";
            this.GameDataWarning.Size = new System.Drawing.Size(346, 57);
            this.GameDataWarning.TabIndex = 2;
            this.GameDataWarning.Text = "No Game Data :(";
            this.GameDataWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MngGamesBtn
            // 
            this.MngGamesBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MngGamesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MngGamesBtn.Location = new System.Drawing.Point(5, 4);
            this.MngGamesBtn.Name = "MngGamesBtn";
            this.MngGamesBtn.Size = new System.Drawing.Size(242, 57);
            this.MngGamesBtn.TabIndex = 1;
            this.MngGamesBtn.Text = "Manage Games";
            this.MngGamesBtn.UseVisualStyleBackColor = true;
            this.MngGamesBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // EventBtnPnl
            // 
            this.EventBtnPnl.Controls.Add(this.RemoveEventBtn);
            this.EventBtnPnl.Controls.Add(this.EditEventBtn);
            this.EventBtnPnl.Controls.Add(this.AddEventBtn);
            this.EventBtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EventBtnPnl.Location = new System.Drawing.Point(0, 537);
            this.EventBtnPnl.Name = "EventBtnPnl";
            this.EventBtnPnl.Size = new System.Drawing.Size(1102, 53);
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
            this.EditEventBtn.Size = new System.Drawing.Size(616, 53);
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
            this.AddEventBtn.Location = new System.Drawing.Point(865, 0);
            this.AddEventBtn.Name = "AddEventBtn";
            this.AddEventBtn.Size = new System.Drawing.Size(234, 53);
            this.AddEventBtn.TabIndex = 0;
            this.AddEventBtn.Text = "&Add Event";
            this.AddEventBtn.UseVisualStyleBackColor = true;
            this.AddEventBtn.Click += new System.EventHandler(this.AddEventBtn_Click);
            // 
            // preScoutButton
            // 
            this.preScoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.preScoutButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.preScoutButton.Location = new System.Drawing.Point(702, 14);
            this.preScoutButton.Name = "preScoutButton";
            this.preScoutButton.Size = new System.Drawing.Size(233, 59);
            this.preScoutButton.TabIndex = 1;
            this.preScoutButton.Text = "Pre-Scout Event";
            this.preScoutButton.UseVisualStyleBackColor = true;
            this.preScoutButton.Click += new System.EventHandler(this.preScoutButton_Click);
            // 
            // TeamPnl
            // 
            this.TeamPnl.Controls.Add(this.TeamNamePnl);
            this.TeamPnl.Controls.Add(this.MainPnl);
            this.TeamPnl.Controls.Add(this.AllianceBtnPnl);
            this.TeamPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamPnl.Location = new System.Drawing.Point(0, 0);
            this.TeamPnl.Name = "TeamPnl";
            this.TeamPnl.Size = new System.Drawing.Size(1102, 590);
            this.TeamPnl.TabIndex = 4;
            this.TeamPnl.Visible = false;
            // 
            // TeamNamePnl
            // 
            this.TeamNamePnl.BackColor = System.Drawing.Color.Transparent;
            this.TeamNamePnl.BackgroundImage = global::MyScout.Properties.Resources.bg;
            this.TeamNamePnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeamNamePnl.Controls.Add(this.button2);
            this.TeamNamePnl.Controls.Add(this.button6);
            this.TeamNamePnl.Controls.Add(this.button5);
            this.TeamNamePnl.Controls.Add(this.label1);
            this.TeamNamePnl.Controls.Add(this.preScoutButton);
            this.TeamNamePnl.Controls.Add(this.TeamNameLbl);
            this.TeamNamePnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TeamNamePnl.Location = new System.Drawing.Point(155, 0);
            this.TeamNamePnl.Name = "TeamNamePnl";
            this.TeamNamePnl.Size = new System.Drawing.Size(947, 90);
            this.TeamNamePnl.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(5, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 59);
            this.button2.TabIndex = 4;
            this.button2.Text = "&Save Event";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.Cursor = System.Windows.Forms.Cursors.Default;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.Location = new System.Drawing.Point(301, 44);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(42, 40);
            this.button6.TabIndex = 3;
            this.button6.Text = "<-";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Location = new System.Drawing.Point(597, 43);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 40);
            this.button5.TabIndex = 2;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(371, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Round 1 of 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TeamNameLbl
            // 
            this.TeamNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TeamNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.TeamNameLbl.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.TeamNameLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TeamNameLbl.Location = new System.Drawing.Point(160, 0);
            this.TeamNameLbl.Name = "TeamNameLbl";
            this.TeamNameLbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.TeamNameLbl.Size = new System.Drawing.Size(624, 88);
            this.TeamNameLbl.TabIndex = 0;
            this.TeamNameLbl.Text = "No Team Selected";
            this.TeamNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPnl
            // 
            this.MainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPnl.Enabled = false;
            this.MainPnl.Location = new System.Drawing.Point(155, 0);
            this.MainPnl.Margin = new System.Windows.Forms.Padding(2);
            this.MainPnl.Name = "MainPnl";
            this.MainPnl.Size = new System.Drawing.Size(947, 590);
            this.MainPnl.TabIndex = 14;
            // 
            // AllianceBtnPnl
            // 
            this.AllianceBtnPnl.BackColor = System.Drawing.Color.Transparent;
            this.AllianceBtnPnl.BackgroundImage = global::MyScout.Properties.Resources.bg;
            this.AllianceBtnPnl.Controls.Add(this.button1);
            this.AllianceBtnPnl.Controls.Add(this.BackBtn);
            this.AllianceBtnPnl.Controls.Add(this.RedAllianceBtn1);
            this.AllianceBtnPnl.Controls.Add(this.RedAllianceBtn2);
            this.AllianceBtnPnl.Controls.Add(this.RedAllianceBtn3);
            this.AllianceBtnPnl.Controls.Add(this.BlueAllianceBtn1);
            this.AllianceBtnPnl.Controls.Add(this.BlueAllianceBtn2);
            this.AllianceBtnPnl.Controls.Add(this.BlueAllianceBtn3);
            this.AllianceBtnPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.AllianceBtnPnl.Location = new System.Drawing.Point(0, 0);
            this.AllianceBtnPnl.Name = "AllianceBtnPnl";
            this.AllianceBtnPnl.Size = new System.Drawing.Size(155, 590);
            this.AllianceBtnPnl.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.Location = new System.Drawing.Point(12, 523);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // RedAllianceBtn1
            // 
            this.RedAllianceBtn1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedAllianceBtn1.BackColor = System.Drawing.Color.Red;
            this.RedAllianceBtn1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.RedAllianceBtn1.FlatAppearance.BorderSize = 0;
            this.RedAllianceBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedAllianceBtn1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.RedAllianceBtn1.ForeColor = System.Drawing.Color.White;
            this.RedAllianceBtn1.Location = new System.Drawing.Point(12, 118);
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
            this.RedAllianceBtn2.Location = new System.Drawing.Point(12, 188);
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
            this.RedAllianceBtn3.Location = new System.Drawing.Point(12, 257);
            this.RedAllianceBtn3.Name = "RedAllianceBtn3";
            this.RedAllianceBtn3.Size = new System.Drawing.Size(128, 55);
            this.RedAllianceBtn3.TabIndex = 3;
            this.RedAllianceBtn3.Text = "----";
            this.RedAllianceBtn3.UseVisualStyleBackColor = false;
            this.RedAllianceBtn3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamBtn_MouseClick);
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
            this.BlueAllianceBtn1.Location = new System.Drawing.Point(12, 328);
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
            this.BlueAllianceBtn2.Location = new System.Drawing.Point(12, 393);
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
            this.BlueAllianceBtn3.Location = new System.Drawing.Point(12, 458);
            this.BlueAllianceBtn3.Name = "BlueAllianceBtn3";
            this.BlueAllianceBtn3.Size = new System.Drawing.Size(128, 55);
            this.BlueAllianceBtn3.TabIndex = 6;
            this.BlueAllianceBtn3.Text = "----";
            this.BlueAllianceBtn3.UseVisualStyleBackColor = false;
            this.BlueAllianceBtn3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamBtn_MouseClick);
            // 
            // MainFrm
            // 
            this.AcceptButton = this.AddEventBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MyScout.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1102, 590);
            this.Controls.Add(this.TeamPnl);
            this.Controls.Add(this.EventPnl);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1118, 629);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyScout 2017";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.EventPnl.ResumeLayout(false);
            this.HeaderPnl.ResumeLayout(false);
            this.HeaderPnl.PerformLayout();
            this.EventBtnPnl.ResumeLayout(false);
            this.TeamPnl.ResumeLayout(false);
            this.TeamNamePnl.ResumeLayout(false);
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
        private System.Windows.Forms.Panel TeamNamePnl;
        private System.Windows.Forms.Label TeamNameLbl;
        private System.Windows.Forms.Panel MainPnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button preScoutButton;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Panel AllianceBtnPnl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button RedAllianceBtn1;
        private System.Windows.Forms.Button RedAllianceBtn2;
        private System.Windows.Forms.Button RedAllianceBtn3;
        private System.Windows.Forms.Button BlueAllianceBtn1;
        private System.Windows.Forms.Button BlueAllianceBtn2;
        private System.Windows.Forms.Button BlueAllianceBtn3;
        private System.Windows.Forms.Button MngGamesBtn;
        private System.Windows.Forms.Label GameDataWarning;
        private System.Windows.Forms.Label GameNameLbl;
        private System.Windows.Forms.ColumnHeader GameHeader;
    }
}

