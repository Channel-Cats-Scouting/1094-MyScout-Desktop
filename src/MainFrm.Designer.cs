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
            this.TeamBtnPnl = new System.Windows.Forms.Panel();
            this.RmTeamBtn = new System.Windows.Forms.Button();
            this.AddTeamBtn = new System.Windows.Forms.Button();
            this.MainPnl = new System.Windows.Forms.Panel();
            this.AddaTeamLbl = new System.Windows.Forms.Label();
            this.TeamnmLbl = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ScoringPnl.SuspendLayout();
            this.TeamBtnPnl.SuspendLayout();
            this.MainPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.TeamList.Size = new System.Drawing.Size(201, 210);
            this.TeamList.TabIndex = 0;
            this.TeamList.UseCompatibleStateImageBehavior = false;
            this.TeamList.View = System.Windows.Forms.View.Details;
            this.TeamList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
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
            this.ScoringPnl.Size = new System.Drawing.Size(381, 261);
            this.ScoringPnl.TabIndex = 1;
            this.ScoringPnl.Visible = false;
            // 
            // TeamBtnPnl
            // 
            this.TeamBtnPnl.BackColor = System.Drawing.Color.White;
            this.TeamBtnPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeamBtnPnl.Controls.Add(this.RmTeamBtn);
            this.TeamBtnPnl.Controls.Add(this.AddTeamBtn);
            this.TeamBtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TeamBtnPnl.Location = new System.Drawing.Point(0, 210);
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
            this.MainPnl.Size = new System.Drawing.Size(381, 261);
            this.MainPnl.TabIndex = 2;
            // 
            // AddaTeamLbl
            // 
            this.AddaTeamLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddaTeamLbl.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddaTeamLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AddaTeamLbl.Location = new System.Drawing.Point(0, 0);
            this.AddaTeamLbl.Name = "AddaTeamLbl";
            this.AddaTeamLbl.Size = new System.Drawing.Size(381, 261);
            this.AddaTeamLbl.TabIndex = 0;
            this.AddaTeamLbl.Text = "Add a Team to Begin";
            this.AddaTeamLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TeamList);
            this.splitContainer1.Panel1.Controls.Add(this.TeamBtnPnl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ScoringPnl);
            this.splitContainer1.Panel2.Controls.Add(this.MainPnl);
            this.splitContainer1.Size = new System.Drawing.Size(586, 261);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 1;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 261);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.Text = "First Stronghold Scoring";
            this.ScoringPnl.ResumeLayout(false);
            this.ScoringPnl.PerformLayout();
            this.TeamBtnPnl.ResumeLayout(false);
            this.MainPnl.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

