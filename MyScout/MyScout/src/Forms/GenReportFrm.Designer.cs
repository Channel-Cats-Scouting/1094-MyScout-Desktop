namespace MyScout
{
    partial class GenReportFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.reportTypeCB = new System.Windows.Forms.ComboBox();
            this.GenBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.outListBox = new System.Windows.Forms.ListBox();
            this.dataListBox = new System.Windows.Forms.ListBox();
            this.MoveUpBtn = new System.Windows.Forms.Button();
            this.MoveDownBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generate a(n):";
            // 
            // reportTypeCB
            // 
            this.reportTypeCB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.reportTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportTypeCB.FormattingEnabled = true;
            this.reportTypeCB.Items.AddRange(new object[] {
            "Event Report",
            "Round Report",
            "Prescout Report"});
            this.reportTypeCB.Location = new System.Drawing.Point(129, 9);
            this.reportTypeCB.Name = "reportTypeCB";
            this.reportTypeCB.Size = new System.Drawing.Size(126, 28);
            this.reportTypeCB.TabIndex = 1;
            this.reportTypeCB.Text = "Event Report";
            this.reportTypeCB.SelectedIndexChanged += new System.EventHandler(this.reportTypeCB_SelectedIndexChanged);
            // 
            // GenBtn
            // 
            this.GenBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GenBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenBtn.Location = new System.Drawing.Point(542, 7);
            this.GenBtn.Name = "GenBtn";
            this.GenBtn.Size = new System.Drawing.Size(81, 30);
            this.GenBtn.TabIndex = 5;
            this.GenBtn.Text = "Generate";
            this.GenBtn.UseVisualStyleBackColor = true;
            this.GenBtn.Click += new System.EventHandler(this.GenBtn_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(261, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 30);
            this.button3.TabIndex = 7;
            this.button3.Text = "Save Profile";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(381, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "Load Profile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // outListBox
            // 
            this.outListBox.FormattingEnabled = true;
            this.outListBox.Location = new System.Drawing.Point(13, 46);
            this.outListBox.Name = "outListBox";
            this.outListBox.Size = new System.Drawing.Size(221, 355);
            this.outListBox.TabIndex = 9;
            // 
            // dataListBox
            // 
            this.dataListBox.FormattingEnabled = true;
            this.dataListBox.Location = new System.Drawing.Point(402, 43);
            this.dataListBox.Name = "dataListBox";
            this.dataListBox.Size = new System.Drawing.Size(221, 355);
            this.dataListBox.TabIndex = 10;
            this.dataListBox.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.dataListBox.Enter += new System.EventHandler(this.dataListBox_Enter);
            this.dataListBox.Leave += new System.EventHandler(this.dataListBox_Leave);
            // 
            // MoveUpBtn
            // 
            this.MoveUpBtn.Image = global::MyScout.Properties.Resources.uparrow1;
            this.MoveUpBtn.Location = new System.Drawing.Point(240, 151);
            this.MoveUpBtn.Name = "MoveUpBtn";
            this.MoveUpBtn.Size = new System.Drawing.Size(32, 32);
            this.MoveUpBtn.TabIndex = 11;
            this.MoveUpBtn.UseVisualStyleBackColor = true;
            // 
            // MoveDownBtn
            // 
            this.MoveDownBtn.Image = global::MyScout.Properties.Resources.downarrow;
            this.MoveDownBtn.Location = new System.Drawing.Point(240, 219);
            this.MoveDownBtn.Name = "MoveDownBtn";
            this.MoveDownBtn.Size = new System.Drawing.Size(32, 32);
            this.MoveDownBtn.TabIndex = 12;
            this.MoveDownBtn.UseVisualStyleBackColor = true;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(321, 190);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 13;
            this.AddBtn.Text = "<-- Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Location = new System.Drawing.Point(240, 190);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.RemoveBtn.TabIndex = 14;
            this.RemoveBtn.Text = "Remove -->";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            // 
            // GenReportFrm
            // 
            this.AcceptButton = this.GenBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MyScout.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(635, 419);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.MoveDownBtn);
            this.Controls.Add(this.MoveUpBtn);
            this.Controls.Add(this.dataListBox);
            this.Controls.Add(this.outListBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.GenBtn);
            this.Controls.Add(this.reportTypeCB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenReportFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Report";
            this.Load += new System.EventHandler(this.GenReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reportTypeCB;
        private System.Windows.Forms.Button GenBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox outListBox;
        private System.Windows.Forms.ListBox dataListBox;
        private System.Windows.Forms.Button MoveUpBtn;
        private System.Windows.Forms.Button MoveDownBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button RemoveBtn;
    }
}