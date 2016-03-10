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
            this.portcullisCheckBox = new System.Windows.Forms.CheckBox();
            this.tippyRampCheckBox = new System.Windows.Forms.CheckBox();
            this.moatCheckBox = new System.Windows.Forms.CheckBox();
            this.rampartCheckBox = new System.Windows.Forms.CheckBox();
            this.drawbridgeCheckBox = new System.Windows.Forms.CheckBox();
            this.sallyPortCheckBox = new System.Windows.Forms.CheckBox();
            this.rockWallCheckBox = new System.Windows.Forms.CheckBox();
            this.roughTerrainCheckBox = new System.Windows.Forms.CheckBox();
            this.lowBarCheckBox = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.canHighGoalCB = new System.Windows.Forms.CheckBox();
            this.canLowGoalCB = new System.Windows.Forms.CheckBox();
            this.loadEmbrasureCB = new System.Windows.Forms.CheckBox();
            this.loadBattriceCB = new System.Windows.Forms.CheckBox();
            this.loadFloorCB = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(50, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 95);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 85);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Team";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // portcullisCheckBox
            // 
            this.portcullisCheckBox.AutoSize = true;
            this.portcullisCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.portcullisCheckBox.Location = new System.Drawing.Point(18, 126);
            this.portcullisCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portcullisCheckBox.Name = "portcullisCheckBox";
            this.portcullisCheckBox.Size = new System.Drawing.Size(97, 25);
            this.portcullisCheckBox.TabIndex = 1;
            this.portcullisCheckBox.Text = "Portcullis";
            this.portcullisCheckBox.UseVisualStyleBackColor = true;
            this.portcullisCheckBox.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // tippyRampCheckBox
            // 
            this.tippyRampCheckBox.AutoSize = true;
            this.tippyRampCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tippyRampCheckBox.Location = new System.Drawing.Point(18, 162);
            this.tippyRampCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tippyRampCheckBox.Name = "tippyRampCheckBox";
            this.tippyRampCheckBox.Size = new System.Drawing.Size(143, 25);
            this.tippyRampCheckBox.TabIndex = 2;
            this.tippyRampCheckBox.Text = "Cheval de Frise";
            this.tippyRampCheckBox.UseVisualStyleBackColor = true;
            this.tippyRampCheckBox.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // moatCheckBox
            // 
            this.moatCheckBox.AutoSize = true;
            this.moatCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.moatCheckBox.Location = new System.Drawing.Point(18, 197);
            this.moatCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.moatCheckBox.Name = "moatCheckBox";
            this.moatCheckBox.Size = new System.Drawing.Size(70, 25);
            this.moatCheckBox.TabIndex = 3;
            this.moatCheckBox.Text = "Moat";
            this.moatCheckBox.UseVisualStyleBackColor = true;
            this.moatCheckBox.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // rampartCheckBox
            // 
            this.rampartCheckBox.AutoSize = true;
            this.rampartCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rampartCheckBox.Location = new System.Drawing.Point(18, 232);
            this.rampartCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rampartCheckBox.Name = "rampartCheckBox";
            this.rampartCheckBox.Size = new System.Drawing.Size(104, 25);
            this.rampartCheckBox.TabIndex = 4;
            this.rampartCheckBox.Text = "Ramparts";
            this.rampartCheckBox.UseVisualStyleBackColor = true;
            this.rampartCheckBox.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // drawbridgeCheckBox
            // 
            this.drawbridgeCheckBox.AutoSize = true;
            this.drawbridgeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.drawbridgeCheckBox.Location = new System.Drawing.Point(18, 268);
            this.drawbridgeCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.drawbridgeCheckBox.Name = "drawbridgeCheckBox";
            this.drawbridgeCheckBox.Size = new System.Drawing.Size(115, 25);
            this.drawbridgeCheckBox.TabIndex = 5;
            this.drawbridgeCheckBox.Text = "Drawbridge";
            this.drawbridgeCheckBox.UseVisualStyleBackColor = true;
            this.drawbridgeCheckBox.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // sallyPortCheckBox
            // 
            this.sallyPortCheckBox.AutoSize = true;
            this.sallyPortCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sallyPortCheckBox.Location = new System.Drawing.Point(18, 303);
            this.sallyPortCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sallyPortCheckBox.Name = "sallyPortCheckBox";
            this.sallyPortCheckBox.Size = new System.Drawing.Size(100, 25);
            this.sallyPortCheckBox.TabIndex = 6;
            this.sallyPortCheckBox.Text = "Sally Port";
            this.sallyPortCheckBox.UseVisualStyleBackColor = true;
            this.sallyPortCheckBox.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // rockWallCheckBox
            // 
            this.rockWallCheckBox.AutoSize = true;
            this.rockWallCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rockWallCheckBox.Location = new System.Drawing.Point(18, 338);
            this.rockWallCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rockWallCheckBox.Name = "rockWallCheckBox";
            this.rockWallCheckBox.Size = new System.Drawing.Size(105, 25);
            this.rockWallCheckBox.TabIndex = 7;
            this.rockWallCheckBox.Text = "Rock Wall";
            this.rockWallCheckBox.UseVisualStyleBackColor = true;
            this.rockWallCheckBox.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // roughTerrainCheckBox
            // 
            this.roughTerrainCheckBox.AutoSize = true;
            this.roughTerrainCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.roughTerrainCheckBox.Location = new System.Drawing.Point(18, 374);
            this.roughTerrainCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.roughTerrainCheckBox.Name = "roughTerrainCheckBox";
            this.roughTerrainCheckBox.Size = new System.Drawing.Size(135, 25);
            this.roughTerrainCheckBox.TabIndex = 8;
            this.roughTerrainCheckBox.Text = "Rough Terrain";
            this.roughTerrainCheckBox.UseVisualStyleBackColor = true;
            this.roughTerrainCheckBox.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // lowBarCheckBox
            // 
            this.lowBarCheckBox.AutoSize = true;
            this.lowBarCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lowBarCheckBox.Location = new System.Drawing.Point(18, 409);
            this.lowBarCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lowBarCheckBox.Name = "lowBarCheckBox";
            this.lowBarCheckBox.Size = new System.Drawing.Size(92, 25);
            this.lowBarCheckBox.TabIndex = 9;
            this.lowBarCheckBox.Text = "Low Bar";
            this.lowBarCheckBox.UseVisualStyleBackColor = true;
            this.lowBarCheckBox.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(56, 445);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 35);
            this.button2.TabIndex = 10;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(177, 445);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 35);
            this.button3.TabIndex = 11;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // canHighGoalCB
            // 
            this.canHighGoalCB.AutoSize = true;
            this.canHighGoalCB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.canHighGoalCB.Location = new System.Drawing.Point(170, 162);
            this.canHighGoalCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.canHighGoalCB.Name = "canHighGoalCB";
            this.canHighGoalCB.Size = new System.Drawing.Size(122, 25);
            this.canHighGoalCB.TabIndex = 12;
            this.canHighGoalCB.Text = "High Goals?";
            this.canHighGoalCB.UseVisualStyleBackColor = true;
            this.canHighGoalCB.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // canLowGoalCB
            // 
            this.canLowGoalCB.AutoSize = true;
            this.canLowGoalCB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.canLowGoalCB.Location = new System.Drawing.Point(170, 197);
            this.canLowGoalCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.canLowGoalCB.Name = "canLowGoalCB";
            this.canLowGoalCB.Size = new System.Drawing.Size(118, 25);
            this.canLowGoalCB.TabIndex = 13;
            this.canLowGoalCB.Text = "Low Goals?";
            this.canLowGoalCB.UseVisualStyleBackColor = true;
            this.canLowGoalCB.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // loadEmbrasureCB
            // 
            this.loadEmbrasureCB.AutoSize = true;
            this.loadEmbrasureCB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadEmbrasureCB.Location = new System.Drawing.Point(170, 298);
            this.loadEmbrasureCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadEmbrasureCB.Name = "loadEmbrasureCB";
            this.loadEmbrasureCB.Size = new System.Drawing.Size(121, 25);
            this.loadEmbrasureCB.TabIndex = 14;
            this.loadEmbrasureCB.Text = "Embrasure?";
            this.loadEmbrasureCB.UseVisualStyleBackColor = true;
            this.loadEmbrasureCB.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // loadBattriceCB
            // 
            this.loadBattriceCB.AutoSize = true;
            this.loadBattriceCB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadBattriceCB.Location = new System.Drawing.Point(170, 334);
            this.loadBattriceCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadBattriceCB.Name = "loadBattriceCB";
            this.loadBattriceCB.Size = new System.Drawing.Size(98, 25);
            this.loadBattriceCB.TabIndex = 15;
            this.loadBattriceCB.Text = "Battrice?";
            this.loadBattriceCB.UseVisualStyleBackColor = true;
            this.loadBattriceCB.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // loadFloorCB
            // 
            this.loadFloorCB.AutoSize = true;
            this.loadFloorCB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadFloorCB.Location = new System.Drawing.Point(170, 369);
            this.loadFloorCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loadFloorCB.Name = "loadFloorCB";
            this.loadFloorCB.Size = new System.Drawing.Size(79, 25);
            this.loadFloorCB.TabIndex = 16;
            this.loadFloorCB.Text = "Floor?";
            this.loadFloorCB.UseVisualStyleBackColor = true;
            this.loadFloorCB.CheckedChanged += new System.EventHandler(this.chkbx_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Can Make:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 269);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Loads from:";
            // 
            // PrescoutFrm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(304, 492);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadFloorCB);
            this.Controls.Add(this.loadBattriceCB);
            this.Controls.Add(this.loadEmbrasureCB);
            this.Controls.Add(this.canLowGoalCB);
            this.Controls.Add(this.canHighGoalCB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lowBarCheckBox);
            this.Controls.Add(this.roughTerrainCheckBox);
            this.Controls.Add(this.rockWallCheckBox);
            this.Controls.Add(this.sallyPortCheckBox);
            this.Controls.Add(this.drawbridgeCheckBox);
            this.Controls.Add(this.rampartCheckBox);
            this.Controls.Add(this.moatCheckBox);
            this.Controls.Add(this.tippyRampCheckBox);
            this.Controls.Add(this.portcullisCheckBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrescoutFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pre-Scout Event";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox portcullisCheckBox;
        private System.Windows.Forms.CheckBox tippyRampCheckBox;
        private System.Windows.Forms.CheckBox moatCheckBox;
        private System.Windows.Forms.CheckBox rampartCheckBox;
        private System.Windows.Forms.CheckBox drawbridgeCheckBox;
        private System.Windows.Forms.CheckBox sallyPortCheckBox;
        private System.Windows.Forms.CheckBox rockWallCheckBox;
        private System.Windows.Forms.CheckBox roughTerrainCheckBox;
        private System.Windows.Forms.CheckBox lowBarCheckBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox canHighGoalCB;
        private System.Windows.Forms.CheckBox canLowGoalCB;
        private System.Windows.Forms.CheckBox loadEmbrasureCB;
        private System.Windows.Forms.CheckBox loadBattriceCB;
        private System.Windows.Forms.CheckBox loadFloorCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}