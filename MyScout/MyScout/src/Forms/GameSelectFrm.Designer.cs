namespace MyScout
{
    partial class GameSelectFrm
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
            this.gameListBox = new System.Windows.Forms.ListBox();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.fullDescLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameListBox
            // 
            this.gameListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameListBox.FormattingEnabled = true;
            this.gameListBox.ItemHeight = 18;
            this.gameListBox.Location = new System.Drawing.Point(12, 41);
            this.gameListBox.Name = "gameListBox";
            this.gameListBox.Size = new System.Drawing.Size(271, 400);
            this.gameListBox.TabIndex = 0;
            this.gameListBox.SelectedIndexChanged += new System.EventHandler(this.gameListBox_SelectedIndexChanged);
            this.gameListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gameListBox_MouseDoubleClick);
            // 
            // acceptBtn
            // 
            this.acceptBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.acceptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptBtn.Location = new System.Drawing.Point(12, 451);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(190, 33);
            this.acceptBtn.TabIndex = 1;
            this.acceptBtn.Text = "Accept";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(206, 451);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 33);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a Valid Game Data File";
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.fullNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullNameLabel.Location = new System.Drawing.Point(313, 41);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(56, 13);
            this.fullNameLabel.TabIndex = 4;
            this.fullNameLabel.Text = "fullName";
            // 
            // fullDescLabel
            // 
            this.fullDescLabel.AutoSize = true;
            this.fullDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.fullDescLabel.Location = new System.Drawing.Point(313, 64);
            this.fullDescLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.fullDescLabel.Name = "fullDescLabel";
            this.fullDescLabel.Size = new System.Drawing.Size(45, 13);
            this.fullDescLabel.TabIndex = 5;
            this.fullDescLabel.Text = "fullDesc";
            // 
            // GameSelectFrm
            // 
            this.AcceptButton = this.acceptBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyScout.Properties.Resources.bg;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(571, 496);
            this.Controls.Add(this.fullDescLabel);
            this.Controls.Add(this.fullNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.gameListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSelectFrm";
            this.ShowInTaskbar = false;
            this.Text = "Game Select";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox gameListBox;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.Label fullDescLabel;
    }
}