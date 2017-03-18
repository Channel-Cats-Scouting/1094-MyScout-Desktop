namespace MyScout
{
    partial class PrescoutFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.canLowGoalCB = new System.Windows.Forms.CheckBox();
            this.canHighGoalCB = new System.Windows.Forms.CheckBox();
            this.maxCarriedUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxCarriedUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(33, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 62);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Team";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(35, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(116, 219);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // canLowGoalCB
            // 
            this.canLowGoalCB.AutoSize = true;
            this.canLowGoalCB.BackColor = System.Drawing.Color.Transparent;
            this.canLowGoalCB.Location = new System.Drawing.Point(32, 118);
            this.canLowGoalCB.Name = "canLowGoalCB";
            this.canLowGoalCB.Size = new System.Drawing.Size(93, 17);
            this.canLowGoalCB.TabIndex = 12;
            this.canLowGoalCB.Text = "Can Low Goal";
            this.canLowGoalCB.UseVisualStyleBackColor = false;
            this.canLowGoalCB.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // canHighGoalCB
            // 
            this.canHighGoalCB.AutoSize = true;
            this.canHighGoalCB.BackColor = System.Drawing.Color.Transparent;
            this.canHighGoalCB.Location = new System.Drawing.Point(32, 95);
            this.canHighGoalCB.Name = "canHighGoalCB";
            this.canHighGoalCB.Size = new System.Drawing.Size(95, 17);
            this.canHighGoalCB.TabIndex = 13;
            this.canHighGoalCB.Text = "Can High Goal";
            this.canHighGoalCB.UseVisualStyleBackColor = false;
            this.canHighGoalCB.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // maxCarriedUpDown
            // 
            this.maxCarriedUpDown.Location = new System.Drawing.Point(32, 142);
            this.maxCarriedUpDown.Name = "maxCarriedUpDown";
            this.maxCarriedUpDown.Size = new System.Drawing.Size(43, 20);
            this.maxCarriedUpDown.TabIndex = 14;
            this.maxCarriedUpDown.ValueChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(77, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Max Carried";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(32, 168);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Can Climb Rope";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Location = new System.Drawing.Point(32, 191);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(91, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Can Get Gear";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // PrescoutFrm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::MyScout.Properties.Resources.bg;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(203, 254);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxCarriedUpDown);
            this.Controls.Add(this.canHighGoalCB);
            this.Controls.Add(this.canLowGoalCB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrescoutFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pre-Scout Event";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maxCarriedUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox canLowGoalCB;
        private System.Windows.Forms.CheckBox canHighGoalCB;
        private System.Windows.Forms.NumericUpDown maxCarriedUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}