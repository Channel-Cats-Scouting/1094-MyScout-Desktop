namespace _2016Scoring
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
            this.BtnPnl = new System.Windows.Forms.Panel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.NameTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberTBx = new System.Windows.Forms.TextBox();
            this.BtnPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPnl
            // 
            this.BtnPnl.BackColor = System.Drawing.SystemColors.Control;
            this.BtnPnl.Controls.Add(this.CancelBtn);
            this.BtnPnl.Controls.Add(this.OkBtn);
            this.BtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnPnl.Location = new System.Drawing.Point(0, 142);
            this.BtnPnl.Name = "BtnPnl";
            this.BtnPnl.Size = new System.Drawing.Size(284, 30);
            this.BtnPnl.TabIndex = 0;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CancelBtn.Location = new System.Drawing.Point(125, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Enabled = false;
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OkBtn.Location = new System.Drawing.Point(206, 4);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 0;
            this.OkBtn.Text = "&OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // NameTbx
            // 
            this.NameTbx.Location = new System.Drawing.Point(12, 35);
            this.NameTbx.Name = "NameTbx";
            this.NameTbx.Size = new System.Drawing.Size(260, 20);
            this.NameTbx.TabIndex = 0;
            this.NameTbx.TextChanged += new System.EventHandler(this.Control_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Team Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "&Team Number:";
            // 
            // NumberTBx
            // 
            this.NumberTBx.Location = new System.Drawing.Point(12, 94);
            this.NumberTBx.Name = "NumberTBx";
            this.NumberTBx.Size = new System.Drawing.Size(260, 20);
            this.NumberTBx.TabIndex = 1;
            this.NumberTBx.TextChanged += new System.EventHandler(this.Control_TextChanged);
            this.NumberTBx.Enter += new System.EventHandler(this.NumberBx_Enter);
            this.NumberTBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumberBx_KeyDown);
            this.NumberTBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberTBx_KeyPress);
            // 
            // TeamFrm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(284, 172);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumberTBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnPnl);
            this.Controls.Add(this.NameTbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeamFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a Team";
            this.Load += new System.EventHandler(this.TeamFrm_Load);
            this.BtnPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel BtnPnl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox NameTbx;
        public System.Windows.Forms.TextBox NumberTBx;
    }
}