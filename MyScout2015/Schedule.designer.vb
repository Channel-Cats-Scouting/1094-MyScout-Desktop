<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schedule
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Schedule))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.BottomBarGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NextMatchLabel = New System.Windows.Forms.Label()
        Me.NewMatchButton = New System.Windows.Forms.Button()
        Me.ExportButton = New System.Windows.Forms.Button()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.BackButton = New System.Windows.Forms.Button()
        Me.RowContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditMatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.BottomBarGroupBox.SuspendLayout()
        Me.RowContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.Black
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.ExportButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ClearButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ImportButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BackButton)
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 730)
        Me.SplitContainer1.SplitterDistance = 850
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.BottomBarGroupBox)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.BackgroundImage = Global.MyScout2015.My.Resources.Resources.bck_orange01
        Me.SplitContainer2.Panel2.Controls.Add(Me.NextMatchLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.NewMatchButton)
        Me.SplitContainer2.Size = New System.Drawing.Size(850, 730)
        Me.SplitContainer2.SplitterDistance = 53
        Me.SplitContainer2.TabIndex = 8
        '
        'BottomBarGroupBox
        '
        Me.BottomBarGroupBox.BackColor = System.Drawing.Color.Black
        Me.BottomBarGroupBox.Controls.Add(Me.Label19)
        Me.BottomBarGroupBox.Controls.Add(Me.Label20)
        Me.BottomBarGroupBox.Controls.Add(Me.Label22)
        Me.BottomBarGroupBox.Controls.Add(Me.Label6)
        Me.BottomBarGroupBox.Controls.Add(Me.Label16)
        Me.BottomBarGroupBox.Controls.Add(Me.Label18)
        Me.BottomBarGroupBox.Controls.Add(Me.Label4)
        Me.BottomBarGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.BottomBarGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BottomBarGroupBox.Location = New System.Drawing.Point(0, 0)
        Me.BottomBarGroupBox.Name = "BottomBarGroupBox"
        Me.BottomBarGroupBox.Size = New System.Drawing.Size(850, 53)
        Me.BottomBarGroupBox.TabIndex = 7
        Me.BottomBarGroupBox.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(637, 10)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 31)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "R3"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(547, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 31)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "R2"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(461, 10)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 31)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "R1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(337, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 31)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "B3"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(246, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 31)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "B2"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(158, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 31)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "B1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(22, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 31)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Match #"
        '
        'NextMatchLabel
        '
        Me.NextMatchLabel.AutoSize = True
        Me.NextMatchLabel.BackColor = System.Drawing.Color.Gainsboro
        Me.NextMatchLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.NextMatchLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NextMatchLabel.Location = New System.Drawing.Point(725, 24)
        Me.NextMatchLabel.Name = "NextMatchLabel"
        Me.NextMatchLabel.Size = New System.Drawing.Size(91, 22)
        Me.NextMatchLabel.TabIndex = 1
        Me.NextMatchLabel.Text = "Next Match"
        '
        'NewMatchButton
        '
        Me.NewMatchButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.NewMatchButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewMatchButton.Location = New System.Drawing.Point(0, 621)
        Me.NewMatchButton.Name = "NewMatchButton"
        Me.NewMatchButton.Size = New System.Drawing.Size(850, 52)
        Me.NewMatchButton.TabIndex = 0
        Me.NewMatchButton.Text = "New Match"
        Me.NewMatchButton.UseVisualStyleBackColor = True
        '
        'ExportButton
        '
        Me.ExportButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportButton.Location = New System.Drawing.Point(13, 665)
        Me.ExportButton.Name = "ExportButton"
        Me.ExportButton.Size = New System.Drawing.Size(130, 44)
        Me.ExportButton.TabIndex = 3
        Me.ExportButton.Text = "Export"
        Me.ExportButton.UseVisualStyleBackColor = True
        '
        'ClearButton
        '
        Me.ClearButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearButton.Location = New System.Drawing.Point(12, 539)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(130, 44)
        Me.ClearButton.TabIndex = 2
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'ImportButton
        '
        Me.ImportButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportButton.Location = New System.Drawing.Point(13, 615)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(130, 44)
        Me.ImportButton.TabIndex = 1
        Me.ImportButton.Text = "Import"
        Me.ImportButton.UseVisualStyleBackColor = True
        '
        'BackButton
        '
        Me.BackButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackButton.Location = New System.Drawing.Point(13, 7)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(130, 44)
        Me.BackButton.TabIndex = 0
        Me.BackButton.Text = "Back"
        Me.BackButton.UseVisualStyleBackColor = True
        '
        'RowContextMenuStrip
        '
        Me.RowContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditMatchToolStripMenuItem})
        Me.RowContextMenuStrip.Name = "RowContextMenuStrip"
        Me.RowContextMenuStrip.Size = New System.Drawing.Size(132, 26)
        '
        'EditMatchToolStripMenuItem
        '
        Me.EditMatchToolStripMenuItem.Name = "EditMatchToolStripMenuItem"
        Me.EditMatchToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.EditMatchToolStripMenuItem.Text = "Edit Match"
        '
        'Schedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Schedule"
        Me.Text = "Schedule"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.BottomBarGroupBox.ResumeLayout(False)
        Me.BottomBarGroupBox.PerformLayout()
        Me.RowContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents BottomBarGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents BackButton As System.Windows.Forms.Button
    Friend WithEvents ImportButton As System.Windows.Forms.Button
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents RowContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditMatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewMatchButton As System.Windows.Forms.Button
    Friend WithEvents NextMatchLabel As System.Windows.Forms.Label
    Friend WithEvents ExportButton As System.Windows.Forms.Button
End Class
