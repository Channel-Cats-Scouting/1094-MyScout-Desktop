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
            this.TeamList = new System.Windows.Forms.ListView();
            this.TeamPnl = new System.Windows.Forms.Panel();
            this.TeamBtnPnl = new System.Windows.Forms.Panel();
            this.RmTeamBtn = new System.Windows.Forms.Button();
            this.AddTeamBtn = new System.Windows.Forms.Button();
            this.MainPnl = new System.Windows.Forms.Panel();
            this.AddaTeamLbl = new System.Windows.Forms.Label();
            this.ScoringPnl = new System.Windows.Forms.Panel();
            this.TeamnmLbl = new System.Windows.Forms.Label();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numbercolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TeamPnl.SuspendLayout();
            this.TeamBtnPnl.SuspendLayout();
            this.MainPnl.SuspendLayout();
            this.ScoringPnl.SuspendLayout();
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
            this.TeamList.Size = new System.Drawing.Size(200, 233);
            this.TeamList.TabIndex = 0;
            this.TeamList.UseCompatibleStateImageBehavior = false;
            this.TeamList.View = System.Windows.Forms.View.Details;
            this.TeamList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // TeamPnl
            // 
            this.TeamPnl.Controls.Add(this.TeamList);
            this.TeamPnl.Controls.Add(this.TeamBtnPnl);
            this.TeamPnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.TeamPnl.Location = new System.Drawing.Point(0, 0);
            this.TeamPnl.Name = "TeamPnl";
            this.TeamPnl.Size = new System.Drawing.Size(200, 261);
            this.TeamPnl.TabIndex = 1;
            // 
            // TeamBtnPnl
            // 
            this.TeamBtnPnl.Controls.Add(this.RmTeamBtn);
            this.TeamBtnPnl.Controls.Add(this.AddTeamBtn);
            this.TeamBtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TeamBtnPnl.Location = new System.Drawing.Point(0, 233);
            this.TeamBtnPnl.Name = "TeamBtnPnl";
            this.TeamBtnPnl.Size = new System.Drawing.Size(200, 28);
            this.TeamBtnPnl.TabIndex = 2;
            // 
            // RmTeamBtn
            // 
            this.RmTeamBtn.Enabled = false;
            this.RmTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RmTeamBtn.Location = new System.Drawing.Point(0, 2);
            this.RmTeamBtn.Name = "RmTeamBtn";
            this.RmTeamBtn.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.RmTeamBtn.Size = new System.Drawing.Size(85, 23);
            this.RmTeamBtn.TabIndex = 3;
            this.RmTeamBtn.Text = "&Remove Team";
            this.RmTeamBtn.UseVisualStyleBackColor = true;
            this.RmTeamBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddTeamBtn
            // 
            this.AddTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddTeamBtn.Location = new System.Drawing.Point(101, 2);
            this.AddTeamBtn.Name = "AddTeamBtn";
            this.AddTeamBtn.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.AddTeamBtn.Size = new System.Drawing.Size(96, 23);
            this.AddTeamBtn.TabIndex = 2;
            this.AddTeamBtn.Text = "&Add Team";
            this.AddTeamBtn.UseVisualStyleBackColor = true;
            this.AddTeamBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainPnl
            // 
            this.MainPnl.Controls.Add(this.AddaTeamLbl);
            this.MainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPnl.Location = new System.Drawing.Point(200, 0);
            this.MainPnl.Name = "MainPnl";
            this.MainPnl.Size = new System.Drawing.Size(386, 261);
            this.MainPnl.TabIndex = 2;
            // 
            // AddaTeamLbl
            // 
            this.AddaTeamLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddaTeamLbl.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddaTeamLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AddaTeamLbl.Location = new System.Drawing.Point(0, 0);
            this.AddaTeamLbl.Name = "AddaTeamLbl";
            this.AddaTeamLbl.Size = new System.Drawing.Size(386, 261);
            this.AddaTeamLbl.TabIndex = 0;
            this.AddaTeamLbl.Text = "Add a Team to Begin";
            this.AddaTeamLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoringPnl
            // 
            this.ScoringPnl.Controls.Add(this.TeamnmLbl);
            this.ScoringPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScoringPnl.Location = new System.Drawing.Point(200, 0);
            this.ScoringPnl.Name = "ScoringPnl";
            this.ScoringPnl.Size = new System.Drawing.Size(386, 261);
            this.ScoringPnl.TabIndex = 1;
            this.ScoringPnl.Visible = false;
            // 
            // TeamnmLbl
            // 
            this.TeamnmLbl.AutoSize = true;
            this.TeamnmLbl.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.TeamnmLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TeamnmLbl.Location = new System.Drawing.Point(6, 9);
            this.TeamnmLbl.Name = "TeamnmLbl";
            this.TeamnmLbl.Size = new System.Drawing.Size(240, 37);
            this.TeamnmLbl.TabIndex = 0;
            this.TeamnmLbl.Text = "Team Name (1094)";
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            // 
            // numbercolumn
            // 
            this.numbercolumn.Text = "ID";
            this.numbercolumn.Width = 40;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 261);
            this.Controls.Add(this.ScoringPnl);
            this.Controls.Add(this.MainPnl);
            this.Controls.Add(this.TeamPnl);
            this.Name = "MainFrm";
            this.Text = "First Stronghold Scoring";
            this.TeamPnl.ResumeLayout(false);
            this.TeamBtnPnl.ResumeLayout(false);
            this.MainPnl.ResumeLayout(false);
            this.ScoringPnl.ResumeLayout(false);
            this.ScoringPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView TeamList;
        private System.Windows.Forms.Panel TeamPnl;
        private System.Windows.Forms.Panel TeamBtnPnl;
        private System.Windows.Forms.Button AddTeamBtn;
        private System.Windows.Forms.Button RmTeamBtn;
        private System.Windows.Forms.Panel MainPnl;
        private System.Windows.Forms.Label AddaTeamLbl;
        private System.Windows.Forms.Panel ScoringPnl;
        private System.Windows.Forms.Label TeamnmLbl;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader numbercolumn;
    }
}

