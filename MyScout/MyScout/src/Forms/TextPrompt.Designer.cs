namespace MyScout
{
    partial class TextPrompt
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
            this.confirmBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.promptTextBox = new System.Windows.Forms.TextBox();
            this.promptLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(12, 76);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 0;
            this.confirmBtn.Text = "Accept";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(97, 76);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // promptTextBox
            // 
            this.promptTextBox.Location = new System.Drawing.Point(13, 29);
            this.promptTextBox.Name = "promptTextBox";
            this.promptTextBox.Size = new System.Drawing.Size(159, 20);
            this.promptTextBox.TabIndex = 2;
            // 
            // promptLbl
            // 
            this.promptLbl.AutoSize = true;
            this.promptLbl.Location = new System.Drawing.Point(12, 13);
            this.promptLbl.Name = "promptLbl";
            this.promptLbl.Size = new System.Drawing.Size(0, 13);
            this.promptLbl.TabIndex = 3;
            // 
            // TextPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 111);
            this.Controls.Add(this.promptLbl);
            this.Controls.Add(this.promptTextBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.confirmBtn);
            this.Name = "TextPrompt";
            this.Text = "Save";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox promptTextBox;
        private System.Windows.Forms.Label promptLbl;
    }
}