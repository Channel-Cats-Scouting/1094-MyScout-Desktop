namespace MyScout
{
    partial class TeamFrm
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
            this.MainLbl = new System.Windows.Forms.Label();
            this.LblPnl = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MainPnl = new System.Windows.Forms.Panel();
            this.TeamList = new System.Windows.Forms.ListView();
            this.IDHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnPnl = new System.Windows.Forms.Panel();
            this.EditTeamBtn = new System.Windows.Forms.Button();
            this.RemoveTeamBtn = new System.Windows.Forms.Button();
            this.AddTeamBtn = new System.Windows.Forms.Button();
            this.SelectTeamButton = new System.Windows.Forms.Button();
            this.LblPnl.SuspendLayout();
            this.MainPnl.SuspendLayout();
            this.BtnPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLbl
            // 
            this.MainLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLbl.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.MainLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.MainLbl.Location = new System.Drawing.Point(0, 0);
            this.MainLbl.Name = "MainLbl";
            this.MainLbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.MainLbl.Size = new System.Drawing.Size(484, 81);
            this.MainLbl.TabIndex = 0;
            this.MainLbl.Text = "Choose a Team";
            this.MainLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPnl
            // 
            this.LblPnl.Controls.Add(this.textBox1);
            this.LblPnl.Controls.Add(this.MainLbl);
            this.LblPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPnl.Location = new System.Drawing.Point(0, 0);
            this.LblPnl.Name = "LblPnl";
            this.LblPnl.Size = new System.Drawing.Size(484, 81);
            this.LblPnl.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(465, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainPnl
            // 
            this.MainPnl.Controls.Add(this.TeamList);
            this.MainPnl.Controls.Add(this.BtnPnl);
            this.MainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPnl.Location = new System.Drawing.Point(0, 81);
            this.MainPnl.Name = "MainPnl";
            this.MainPnl.Size = new System.Drawing.Size(484, 214);
            this.MainPnl.TabIndex = 2;
            // 
            // TeamList
            // 
            this.TeamList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDHeader,
            this.NameHeader});
            this.TeamList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamList.FullRowSelect = true;
            this.TeamList.Location = new System.Drawing.Point(0, 0);
            this.TeamList.MultiSelect = false;
            this.TeamList.Name = "TeamList";
            this.TeamList.Size = new System.Drawing.Size(484, 162);
            this.TeamList.TabIndex = 1;
            this.TeamList.UseCompatibleStateImageBehavior = false;
            this.TeamList.View = System.Windows.Forms.View.Details;
            this.TeamList.DoubleClick += new System.EventHandler(this.TeamList_DoubleClick);
            // 
            // IDHeader
            // 
            this.IDHeader.Text = "ID";
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 420;
            // 
            // BtnPnl
            // 
            this.BtnPnl.Controls.Add(this.SelectTeamButton);
            this.BtnPnl.Controls.Add(this.EditTeamBtn);
            this.BtnPnl.Controls.Add(this.RemoveTeamBtn);
            this.BtnPnl.Controls.Add(this.AddTeamBtn);
            this.BtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnPnl.Location = new System.Drawing.Point(0, 162);
            this.BtnPnl.Name = "BtnPnl";
            this.BtnPnl.Size = new System.Drawing.Size(484, 52);
            this.BtnPnl.TabIndex = 0;
            // 
            // EditTeamBtn
            // 
            this.EditTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.EditTeamBtn.Location = new System.Drawing.Point(122, 3);
            this.EditTeamBtn.Name = "EditTeamBtn";
            this.EditTeamBtn.Size = new System.Drawing.Size(113, 46);
            this.EditTeamBtn.TabIndex = 3;
            this.EditTeamBtn.Text = "&Edit Team";
            this.EditTeamBtn.UseVisualStyleBackColor = true;
            this.EditTeamBtn.Click += new System.EventHandler(this.EditTeamBtn_Click);
            // 
            // RemoveTeamBtn
            // 
            this.RemoveTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RemoveTeamBtn.Location = new System.Drawing.Point(3, 3);
            this.RemoveTeamBtn.Name = "RemoveTeamBtn";
            this.RemoveTeamBtn.Size = new System.Drawing.Size(113, 46);
            this.RemoveTeamBtn.TabIndex = 2;
            this.RemoveTeamBtn.Text = "&Remove Team";
            this.RemoveTeamBtn.UseVisualStyleBackColor = true;
            this.RemoveTeamBtn.Click += new System.EventHandler(this.RemoveTeamBtn_Click);
            // 
            // AddTeamBtn
            // 
            this.AddTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddTeamBtn.Location = new System.Drawing.Point(240, 3);
            this.AddTeamBtn.Name = "AddTeamBtn";
            this.AddTeamBtn.Size = new System.Drawing.Size(118, 46);
            this.AddTeamBtn.TabIndex = 0;
            this.AddTeamBtn.Text = "&Add Team";
            this.AddTeamBtn.UseVisualStyleBackColor = true;
            this.AddTeamBtn.Click += new System.EventHandler(this.AddTeamBtn_Click);
            // 
            // SelectTeamButton
            // 
            this.SelectTeamButton.Location = new System.Drawing.Point(365, 4);
            this.SelectTeamButton.Name = "SelectTeamButton";
            this.SelectTeamButton.Size = new System.Drawing.Size(116, 45);
            this.SelectTeamButton.TabIndex = 4;
            this.SelectTeamButton.Text = "Select Team";
            this.SelectTeamButton.UseVisualStyleBackColor = true;
            this.SelectTeamButton.Click += new System.EventHandler(this.SelectTeamButton_Click);
            // 
            // TeamFrm
            // 
            this.AcceptButton = this.AddTeamBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 295);
            this.Controls.Add(this.MainPnl);
            this.Controls.Add(this.LblPnl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeamFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teams";
            this.Load += new System.EventHandler(this.TeamFrm_Load);
            this.LblPnl.ResumeLayout(false);
            this.LblPnl.PerformLayout();
            this.MainPnl.ResumeLayout(false);
            this.BtnPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MainLbl;
        private System.Windows.Forms.Panel LblPnl;
        private System.Windows.Forms.Panel MainPnl;
        private System.Windows.Forms.Panel BtnPnl;
        private System.Windows.Forms.Button AddTeamBtn;
        private System.Windows.Forms.Button RemoveTeamBtn;
        private System.Windows.Forms.ListView TeamList;
        private System.Windows.Forms.ColumnHeader IDHeader;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.Button EditTeamBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SelectTeamButton;
    }
}