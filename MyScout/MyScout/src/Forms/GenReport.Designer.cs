namespace MyScout
{
    partial class GenReport
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
            this.totalScoreRB = new System.Windows.Forms.RadioButton();
            this.crossScoreRB = new System.Windows.Forms.RadioButton();
            this.autoScoreRB = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.roundNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.roundNumLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.roundNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generate a(n)";
            // 
            // reportTypeCB
            // 
            this.reportTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportTypeCB.FormattingEnabled = true;
            this.reportTypeCB.Items.AddRange(new object[] {
            "Event Report",
            "Round Report"});
            this.reportTypeCB.Location = new System.Drawing.Point(128, 10);
            this.reportTypeCB.Name = "reportTypeCB";
            this.reportTypeCB.Size = new System.Drawing.Size(126, 28);
            this.reportTypeCB.TabIndex = 1;
            this.reportTypeCB.Text = "Event Report";
            this.reportTypeCB.SelectedIndexChanged += new System.EventHandler(this.reportTypeCB_SelectedIndexChanged);
            // 
            // totalScoreRB
            // 
            this.totalScoreRB.AutoSize = true;
            this.totalScoreRB.Location = new System.Drawing.Point(128, 44);
            this.totalScoreRB.Name = "totalScoreRB";
            this.totalScoreRB.Size = new System.Drawing.Size(116, 17);
            this.totalScoreRB.TabIndex = 2;
            this.totalScoreRB.TabStop = true;
            this.totalScoreRB.Text = "Sort by Total Score";
            this.totalScoreRB.UseVisualStyleBackColor = true;
            // 
            // crossScoreRB
            // 
            this.crossScoreRB.AutoSize = true;
            this.crossScoreRB.Location = new System.Drawing.Point(128, 68);
            this.crossScoreRB.Name = "crossScoreRB";
            this.crossScoreRB.Size = new System.Drawing.Size(118, 17);
            this.crossScoreRB.TabIndex = 3;
            this.crossScoreRB.TabStop = true;
            this.crossScoreRB.Text = "Sort by Cross Score";
            this.crossScoreRB.UseVisualStyleBackColor = true;
            // 
            // autoScoreRB
            // 
            this.autoScoreRB.AutoSize = true;
            this.autoScoreRB.Location = new System.Drawing.Point(128, 91);
            this.autoScoreRB.Name = "autoScoreRB";
            this.autoScoreRB.Size = new System.Drawing.Size(114, 17);
            this.autoScoreRB.TabIndex = 4;
            this.autoScoreRB.TabStop = true;
            this.autoScoreRB.Text = "Sort by Auto Score";
            this.autoScoreRB.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 64);
            this.button1.TabIndex = 5;
            this.button1.Text = "GENERATE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // roundNumUpDown
            // 
            this.roundNumUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundNumUpDown.Location = new System.Drawing.Point(163, 114);
            this.roundNumUpDown.Name = "roundNumUpDown";
            this.roundNumUpDown.Size = new System.Drawing.Size(91, 23);
            this.roundNumUpDown.TabIndex = 6;
            // 
            // roundNumLabel
            // 
            this.roundNumLabel.AutoSize = true;
            this.roundNumLabel.Location = new System.Drawing.Point(108, 118);
            this.roundNumLabel.Name = "roundNumLabel";
            this.roundNumLabel.Size = new System.Drawing.Size(49, 13);
            this.roundNumLabel.TabIndex = 7;
            this.roundNumLabel.Text = "Round #";
            // 
            // GenReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 243);
            this.Controls.Add(this.roundNumLabel);
            this.Controls.Add(this.roundNumUpDown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.autoScoreRB);
            this.Controls.Add(this.crossScoreRB);
            this.Controls.Add(this.totalScoreRB);
            this.Controls.Add(this.reportTypeCB);
            this.Controls.Add(this.label1);
            this.Name = "GenReport";
            this.Text = "Generate Report";
            ((System.ComponentModel.ISupportInitialize)(this.roundNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reportTypeCB;
        private System.Windows.Forms.RadioButton totalScoreRB;
        private System.Windows.Forms.RadioButton crossScoreRB;
        private System.Windows.Forms.RadioButton autoScoreRB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown roundNumUpDown;
        private System.Windows.Forms.Label roundNumLabel;
    }
}