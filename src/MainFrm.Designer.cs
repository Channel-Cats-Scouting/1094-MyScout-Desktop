namespace _2016Scoring
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
            this.TeamList = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numbercolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ScoringPnl = new System.Windows.Forms.Panel();
            this.TeamnmLbl = new System.Windows.Forms.LinkLabel();
            this.TeamBtnPnl = new System.Windows.Forms.Panel();
            this.RmTeamBtn = new System.Windows.Forms.Button();
            this.AddTeamBtn = new System.Windows.Forms.Button();
            this.MainPnl = new System.Windows.Forms.Panel();
            this.AddaTeamLbl = new System.Windows.Forms.Label();
            this.MainSC = new System.Windows.Forms.SplitContainer();
            this.EventPnl = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.eventList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChooseEventLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RmEventBtn = new System.Windows.Forms.Button();
            this.AddEventBtn = new System.Windows.Forms.Button();
            this.TeamPnl = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.eventLbl = new System.Windows.Forms.Label();
            this.ScoringPnl.SuspendLayout();
            this.TeamBtnPnl.SuspendLayout();
            this.MainPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSC)).BeginInit();
            this.MainSC.Panel1.SuspendLayout();
            this.MainSC.Panel2.SuspendLayout();
            this.MainSC.SuspendLayout();
            this.EventPnl.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TeamPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TeamList
            // 
            this.TeamList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.numbercolumn});
            this.TeamList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamList.FullRowSelect = true;
            this.TeamList.Location = new System.Drawing.Point(0, 0);
            this.TeamList.MultiSelect = false;
            this.TeamList.Name = "TeamList";
            this.TeamList.Size = new System.Drawing.Size(201, 170);
            this.TeamList.TabIndex = 0;
            this.TeamList.UseCompatibleStateImageBehavior = false;
            this.TeamList.View = System.Windows.Forms.View.Details;
            this.TeamList.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 150;
            // 
            // numbercolumn
            // 
            this.numbercolumn.Text = "ID";
            this.numbercolumn.Width = 40;
            // 
            // ScoringPnl
            // 
            this.ScoringPnl.Controls.Add(this.TeamnmLbl);
            this.ScoringPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScoringPnl.Location = new System.Drawing.Point(0, 0);
            this.ScoringPnl.Name = "ScoringPnl";
            this.ScoringPnl.Size = new System.Drawing.Size(381, 221);
            this.ScoringPnl.TabIndex = 1;
            this.ScoringPnl.Visible = false;
            // 
            // TeamnmLbl
            // 
            this.TeamnmLbl.ActiveLinkColor = System.Drawing.Color.LightBlue;
            this.TeamnmLbl.AutoSize = true;
            this.TeamnmLbl.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.TeamnmLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TeamnmLbl.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.TeamnmLbl.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.TeamnmLbl.Location = new System.Drawing.Point(3, 9);
            this.TeamnmLbl.Name = "TeamnmLbl";
            this.TeamnmLbl.Size = new System.Drawing.Size(240, 37);
            this.TeamnmLbl.TabIndex = 0;
            this.TeamnmLbl.TabStop = true;
            this.TeamnmLbl.Text = "Team Name (1094)";
            this.TeamnmLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TeamnmLbl_LinkClicked);
            // 
            // TeamBtnPnl
            // 
            this.TeamBtnPnl.BackColor = System.Drawing.Color.White;
            this.TeamBtnPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeamBtnPnl.Controls.Add(this.RmTeamBtn);
            this.TeamBtnPnl.Controls.Add(this.AddTeamBtn);
            this.TeamBtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TeamBtnPnl.Location = new System.Drawing.Point(0, 170);
            this.TeamBtnPnl.Margin = new System.Windows.Forms.Padding(0);
            this.TeamBtnPnl.Name = "TeamBtnPnl";
            this.TeamBtnPnl.Size = new System.Drawing.Size(201, 51);
            this.TeamBtnPnl.TabIndex = 2;
            // 
            // RmTeamBtn
            // 
            this.RmTeamBtn.Enabled = false;
            this.RmTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RmTeamBtn.Location = new System.Drawing.Point(0, 2);
            this.RmTeamBtn.Name = "RmTeamBtn";
            this.RmTeamBtn.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RmTeamBtn.Size = new System.Drawing.Size(96, 44);
            this.RmTeamBtn.TabIndex = 3;
            this.RmTeamBtn.Text = "&Remove Team";
            this.RmTeamBtn.UseVisualStyleBackColor = true;
            this.RmTeamBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddTeamBtn
            // 
            this.AddTeamBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddTeamBtn.Enabled = false;
            this.AddTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddTeamBtn.Location = new System.Drawing.Point(101, 2);
            this.AddTeamBtn.Name = "AddTeamBtn";
            this.AddTeamBtn.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddTeamBtn.Size = new System.Drawing.Size(96, 44);
            this.AddTeamBtn.TabIndex = 2;
            this.AddTeamBtn.Text = "&Add Team";
            this.AddTeamBtn.UseVisualStyleBackColor = true;
            this.AddTeamBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainPnl
            // 
            this.MainPnl.Controls.Add(this.AddaTeamLbl);
            this.MainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPnl.Location = new System.Drawing.Point(0, 0);
            this.MainPnl.Name = "MainPnl";
            this.MainPnl.Size = new System.Drawing.Size(381, 221);
            this.MainPnl.TabIndex = 2;
            // 
            // AddaTeamLbl
            // 
            this.AddaTeamLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddaTeamLbl.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddaTeamLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AddaTeamLbl.Location = new System.Drawing.Point(0, 0);
            this.AddaTeamLbl.Name = "AddaTeamLbl";
            this.AddaTeamLbl.Size = new System.Drawing.Size(381, 221);
            this.AddaTeamLbl.TabIndex = 0;
            this.AddaTeamLbl.Text = "Add a Team to Begin";
            this.AddaTeamLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainSC
            // 
            this.MainSC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSC.Location = new System.Drawing.Point(0, 40);
            this.MainSC.Name = "MainSC";
            // 
            // MainSC.Panel1
            // 
            this.MainSC.Panel1.Controls.Add(this.TeamList);
            this.MainSC.Panel1.Controls.Add(this.TeamBtnPnl);
            // 
            // MainSC.Panel2
            // 
            this.MainSC.Panel2.Controls.Add(this.ScoringPnl);
            this.MainSC.Panel2.Controls.Add(this.MainPnl);
            this.MainSC.Size = new System.Drawing.Size(586, 221);
            this.MainSC.SplitterDistance = 201;
            this.MainSC.TabIndex = 1;
            // 
            // EventPnl
            // 
            this.EventPnl.Controls.Add(this.panel3);
            this.EventPnl.Controls.Add(this.panel2);
            this.EventPnl.Controls.Add(this.panel1);
            this.EventPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventPnl.Location = new System.Drawing.Point(0, 0);
            this.EventPnl.Name = "EventPnl";
            this.EventPnl.Size = new System.Drawing.Size(586, 261);
            this.EventPnl.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.eventList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(586, 164);
            this.panel3.TabIndex = 3;
            // 
            // eventList
            // 
            this.eventList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.eventList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventList.FullRowSelect = true;
            this.eventList.Location = new System.Drawing.Point(0, 0);
            this.eventList.MultiSelect = false;
            this.eventList.Name = "eventList";
            this.eventList.Size = new System.Drawing.Size(586, 164);
            this.eventList.TabIndex = 0;
            this.eventList.UseCompatibleStateImageBehavior = false;
            this.eventList.View = System.Windows.Forms.View.Details;
            this.eventList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.eventList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ChooseEventLbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 46);
            this.panel2.TabIndex = 2;
            // 
            // ChooseEventLbl
            // 
            this.ChooseEventLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseEventLbl.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.ChooseEventLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChooseEventLbl.Location = new System.Drawing.Point(0, 0);
            this.ChooseEventLbl.Name = "ChooseEventLbl";
            this.ChooseEventLbl.Size = new System.Drawing.Size(586, 46);
            this.ChooseEventLbl.TabIndex = 0;
            this.ChooseEventLbl.Text = "Please choose an event";
            this.ChooseEventLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RmEventBtn);
            this.panel1.Controls.Add(this.AddEventBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 51);
            this.panel1.TabIndex = 1;
            // 
            // RmEventBtn
            // 
            this.RmEventBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RmEventBtn.Location = new System.Drawing.Point(4, 0);
            this.RmEventBtn.Name = "RmEventBtn";
            this.RmEventBtn.Size = new System.Drawing.Size(288, 51);
            this.RmEventBtn.TabIndex = 1;
            this.RmEventBtn.Text = "&Remove Event";
            this.RmEventBtn.UseVisualStyleBackColor = true;
            this.RmEventBtn.Click += new System.EventHandler(this.RmEventBtn_Click);
            // 
            // AddEventBtn
            // 
            this.AddEventBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddEventBtn.Location = new System.Drawing.Point(298, 0);
            this.AddEventBtn.Name = "AddEventBtn";
            this.AddEventBtn.Size = new System.Drawing.Size(288, 51);
            this.AddEventBtn.TabIndex = 0;
            this.AddEventBtn.Text = "&Add Event";
            this.AddEventBtn.UseVisualStyleBackColor = true;
            this.AddEventBtn.Click += new System.EventHandler(this.AddEventBtn_Click);
            // 
            // TeamPnl
            // 
            this.TeamPnl.Controls.Add(this.eventLbl);
            this.TeamPnl.Controls.Add(this.backBtn);
            this.TeamPnl.Controls.Add(this.MainSC);
            this.TeamPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamPnl.Location = new System.Drawing.Point(0, 0);
            this.TeamPnl.Name = "TeamPnl";
            this.TeamPnl.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.TeamPnl.Size = new System.Drawing.Size(586, 261);
            this.TeamPnl.TabIndex = 1;
            // 
            // backBtn
            // 
            this.backBtn.BackgroundImage = global::_2016Scoring.Properties.Resources.left_round;
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Location = new System.Drawing.Point(7, 5);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(43, 29);
            this.backBtn.TabIndex = 2;
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // eventLbl
            // 
            this.eventLbl.AutoSize = true;
            this.eventLbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.eventLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.eventLbl.Location = new System.Drawing.Point(56, 10);
            this.eventLbl.Name = "eventLbl";
            this.eventLbl.Size = new System.Drawing.Size(83, 19);
            this.eventLbl.TabIndex = 3;
            this.eventLbl.Text = "Event Name";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 261);
            this.Controls.Add(this.EventPnl);
            this.Controls.Add(this.TeamPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First Stronghold Scoring";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ScoringPnl.ResumeLayout(false);
            this.ScoringPnl.PerformLayout();
            this.TeamBtnPnl.ResumeLayout(false);
            this.MainPnl.ResumeLayout(false);
            this.MainSC.Panel1.ResumeLayout(false);
            this.MainSC.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSC)).EndInit();
            this.MainSC.ResumeLayout(false);
            this.EventPnl.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.TeamPnl.ResumeLayout(false);
            this.TeamPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView TeamList;
        private System.Windows.Forms.Panel ScoringPnl;
        private System.Windows.Forms.Panel TeamBtnPnl;
        private System.Windows.Forms.Button AddTeamBtn;
        private System.Windows.Forms.Button RmTeamBtn;
        private System.Windows.Forms.Panel MainPnl;
        private System.Windows.Forms.Label AddaTeamLbl;
        private System.Windows.Forms.LinkLabel TeamnmLbl;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader numbercolumn;
        private System.Windows.Forms.SplitContainer MainSC;
        private System.Windows.Forms.Panel EventPnl;
        private System.Windows.Forms.Label ChooseEventLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RmEventBtn;
        private System.Windows.Forms.Button AddEventBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView eventList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel TeamPnl;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label eventLbl;
    }
}

