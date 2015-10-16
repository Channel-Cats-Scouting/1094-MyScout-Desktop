<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScoreOverview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScoreOverview))
        Me.TopBarGroupBox = New System.Windows.Forms.GroupBox()
        Me.ReachColLabel = New System.Windows.Forms.Label()
        Me.BinsColLabel = New System.Windows.Forms.Label()
        Me.KnockdownsColLabel = New System.Windows.Forms.Label()
        Me.RunsColLabel = New System.Windows.Forms.Label()
        Me.FailsColLabel = New System.Windows.Forms.Label()
        Me.OffenseColLabel = New System.Windows.Forms.Label()
        Me.AutoColLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OverallColLabel = New System.Windows.Forms.Label()
        Me.TeamColLabel = New System.Windows.Forms.Label()
        Me.ScoreEntryButton = New System.Windows.Forms.Button()
        Me.BottomBarGroupBox = New System.Windows.Forms.GroupBox()
        Me.ExportButton = New System.Windows.Forms.Button()
        Me.ScheduleButton = New System.Windows.Forms.Button()
        Me.PrintButton = New System.Windows.Forms.Button()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.FinishButton = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.OverviewPrintDocument = New System.Drawing.Printing.PrintDocument()
        Me.OverviewPrintDialog = New System.Windows.Forms.PrintDialog()
        Me.OverviewPrintPreviewDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.TotalsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowSubscoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TopBarGroupBox.SuspendLayout()
        Me.BottomBarGroupBox.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TotalsContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TopBarGroupBox
        '
        Me.TopBarGroupBox.BackColor = System.Drawing.Color.Black
        Me.TopBarGroupBox.Controls.Add(Me.ReachColLabel)
        Me.TopBarGroupBox.Controls.Add(Me.BinsColLabel)
        Me.TopBarGroupBox.Controls.Add(Me.KnockdownsColLabel)
        Me.TopBarGroupBox.Controls.Add(Me.RunsColLabel)
        Me.TopBarGroupBox.Controls.Add(Me.FailsColLabel)
        Me.TopBarGroupBox.Controls.Add(Me.OffenseColLabel)
        Me.TopBarGroupBox.Controls.Add(Me.AutoColLabel)
        Me.TopBarGroupBox.Controls.Add(Me.Label2)
        Me.TopBarGroupBox.Controls.Add(Me.OverallColLabel)
        Me.TopBarGroupBox.Controls.Add(Me.TeamColLabel)
        Me.TopBarGroupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopBarGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopBarGroupBox.Location = New System.Drawing.Point(0, 0)
        Me.TopBarGroupBox.Name = "TopBarGroupBox"
        Me.TopBarGroupBox.Size = New System.Drawing.Size(1008, 53)
        Me.TopBarGroupBox.TabIndex = 0
        Me.TopBarGroupBox.TabStop = False
        '
        'ReachColLabel
        '
        Me.ReachColLabel.AutoSize = True
        Me.ReachColLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ReachColLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReachColLabel.ForeColor = System.Drawing.Color.White
        Me.ReachColLabel.Location = New System.Drawing.Point(661, 6)
        Me.ReachColLabel.MinimumSize = New System.Drawing.Size(0, 41)
        Me.ReachColLabel.Name = "ReachColLabel"
        Me.ReachColLabel.Size = New System.Drawing.Size(101, 41)
        Me.ReachColLabel.TabIndex = 6
        Me.ReachColLabel.Text = "Reach"
        Me.ReachColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BinsColLabel
        '
        Me.BinsColLabel.AutoSize = True
        Me.BinsColLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BinsColLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BinsColLabel.ForeColor = System.Drawing.Color.White
        Me.BinsColLabel.Location = New System.Drawing.Point(356, 6)
        Me.BinsColLabel.MinimumSize = New System.Drawing.Size(0, 41)
        Me.BinsColLabel.Name = "BinsColLabel"
        Me.BinsColLabel.Size = New System.Drawing.Size(59, 41)
        Me.BinsColLabel.TabIndex = 3
        Me.BinsColLabel.Text = "RC"
        Me.BinsColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KnockdownsColLabel
        '
        Me.KnockdownsColLabel.AutoSize = True
        Me.KnockdownsColLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.KnockdownsColLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KnockdownsColLabel.ForeColor = System.Drawing.Color.White
        Me.KnockdownsColLabel.Location = New System.Drawing.Point(529, 6)
        Me.KnockdownsColLabel.MinimumSize = New System.Drawing.Size(0, 41)
        Me.KnockdownsColLabel.Name = "KnockdownsColLabel"
        Me.KnockdownsColLabel.Size = New System.Drawing.Size(95, 41)
        Me.KnockdownsColLabel.TabIndex = 5
        Me.KnockdownsColLabel.Text = "Drops"
        Me.KnockdownsColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RunsColLabel
        '
        Me.RunsColLabel.AutoSize = True
        Me.RunsColLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RunsColLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunsColLabel.ForeColor = System.Drawing.Color.White
        Me.RunsColLabel.Location = New System.Drawing.Point(886, 6)
        Me.RunsColLabel.MinimumSize = New System.Drawing.Size(0, 41)
        Me.RunsColLabel.Name = "RunsColLabel"
        Me.RunsColLabel.Size = New System.Drawing.Size(85, 41)
        Me.RunsColLabel.TabIndex = 8
        Me.RunsColLabel.Text = "Runs"
        Me.RunsColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FailsColLabel
        '
        Me.FailsColLabel.AutoSize = True
        Me.FailsColLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FailsColLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FailsColLabel.ForeColor = System.Drawing.Color.White
        Me.FailsColLabel.Location = New System.Drawing.Point(784, 6)
        Me.FailsColLabel.MinimumSize = New System.Drawing.Size(0, 41)
        Me.FailsColLabel.Name = "FailsColLabel"
        Me.FailsColLabel.Size = New System.Drawing.Size(96, 41)
        Me.FailsColLabel.TabIndex = 7
        Me.FailsColLabel.Text = "#Fails"
        Me.FailsColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OffenseColLabel
        '
        Me.OffenseColLabel.AutoSize = True
        Me.OffenseColLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.OffenseColLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OffenseColLabel.ForeColor = System.Drawing.Color.White
        Me.OffenseColLabel.Location = New System.Drawing.Point(233, 6)
        Me.OffenseColLabel.MinimumSize = New System.Drawing.Size(0, 41)
        Me.OffenseColLabel.Name = "OffenseColLabel"
        Me.OffenseColLabel.Size = New System.Drawing.Size(119, 41)
        Me.OffenseColLabel.TabIndex = 2
        Me.OffenseColLabel.Text = "Offense"
        Me.OffenseColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AutoColLabel
        '
        Me.AutoColLabel.AutoSize = True
        Me.AutoColLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AutoColLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoColLabel.ForeColor = System.Drawing.Color.White
        Me.AutoColLabel.Location = New System.Drawing.Point(420, 6)
        Me.AutoColLabel.MinimumSize = New System.Drawing.Size(0, 41)
        Me.AutoColLabel.Name = "AutoColLabel"
        Me.AutoColLabel.Size = New System.Drawing.Size(76, 41)
        Me.AutoColLabel.TabIndex = 4
        Me.AutoColLabel.Text = "Auto"
        Me.AutoColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(274, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 37)
        Me.Label2.TabIndex = 2
        '
        'OverallColLabel
        '
        Me.OverallColLabel.AutoSize = True
        Me.OverallColLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.OverallColLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OverallColLabel.ForeColor = System.Drawing.Color.White
        Me.OverallColLabel.Location = New System.Drawing.Point(124, 6)
        Me.OverallColLabel.MinimumSize = New System.Drawing.Size(0, 41)
        Me.OverallColLabel.Name = "OverallColLabel"
        Me.OverallColLabel.Size = New System.Drawing.Size(82, 41)
        Me.OverallColLabel.TabIndex = 1
        Me.OverallColLabel.Text = "Total"
        Me.OverallColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TeamColLabel
        '
        Me.TeamColLabel.AutoSize = True
        Me.TeamColLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TeamColLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TeamColLabel.ForeColor = System.Drawing.Color.White
        Me.TeamColLabel.Location = New System.Drawing.Point(15, 6)
        Me.TeamColLabel.MinimumSize = New System.Drawing.Size(0, 41)
        Me.TeamColLabel.Name = "TeamColLabel"
        Me.TeamColLabel.Size = New System.Drawing.Size(92, 41)
        Me.TeamColLabel.TabIndex = 0
        Me.TeamColLabel.Text = "Team"
        Me.TeamColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ScoreEntryButton
        '
        Me.ScoreEntryButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScoreEntryButton.ForeColor = System.Drawing.Color.Black
        Me.ScoreEntryButton.Location = New System.Drawing.Point(544, 12)
        Me.ScoreEntryButton.Name = "ScoreEntryButton"
        Me.ScoreEntryButton.Size = New System.Drawing.Size(110, 33)
        Me.ScoreEntryButton.TabIndex = 12
        Me.ScoreEntryButton.Text = "SCORE"
        Me.ScoreEntryButton.UseVisualStyleBackColor = True
        '
        'BottomBarGroupBox
        '
        Me.BottomBarGroupBox.BackColor = System.Drawing.Color.Black
        Me.BottomBarGroupBox.Controls.Add(Me.ScoreEntryButton)
        Me.BottomBarGroupBox.Controls.Add(Me.ExportButton)
        Me.BottomBarGroupBox.Controls.Add(Me.ScheduleButton)
        Me.BottomBarGroupBox.Controls.Add(Me.PrintButton)
        Me.BottomBarGroupBox.Controls.Add(Me.SettingsButton)
        Me.BottomBarGroupBox.Controls.Add(Me.FinishButton)
        Me.BottomBarGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomBarGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BottomBarGroupBox.Location = New System.Drawing.Point(0, -10)
        Me.BottomBarGroupBox.Name = "BottomBarGroupBox"
        Me.BottomBarGroupBox.Size = New System.Drawing.Size(1008, 53)
        Me.BottomBarGroupBox.TabIndex = 2
        Me.BottomBarGroupBox.TabStop = False
        '
        'ExportButton
        '
        Me.ExportButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportButton.ForeColor = System.Drawing.Color.Black
        Me.ExportButton.Location = New System.Drawing.Point(191, 11)
        Me.ExportButton.Name = "ExportButton"
        Me.ExportButton.Size = New System.Drawing.Size(106, 37)
        Me.ExportButton.TabIndex = 10
        Me.ExportButton.Text = "Export"
        Me.ExportButton.UseVisualStyleBackColor = True
        '
        'ScheduleButton
        '
        Me.ScheduleButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScheduleButton.ForeColor = System.Drawing.Color.Black
        Me.ScheduleButton.Location = New System.Drawing.Point(10, 11)
        Me.ScheduleButton.Name = "ScheduleButton"
        Me.ScheduleButton.Size = New System.Drawing.Size(124, 37)
        Me.ScheduleButton.TabIndex = 9
        Me.ScheduleButton.Text = "Schedule"
        Me.ScheduleButton.UseVisualStyleBackColor = True
        '
        'PrintButton
        '
        Me.PrintButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintButton.ForeColor = System.Drawing.Color.Black
        Me.PrintButton.Location = New System.Drawing.Point(303, 11)
        Me.PrintButton.Name = "PrintButton"
        Me.PrintButton.Size = New System.Drawing.Size(92, 37)
        Me.PrintButton.TabIndex = 11
        Me.PrintButton.Text = "Print"
        Me.PrintButton.UseVisualStyleBackColor = True
        '
        'SettingsButton
        '
        Me.SettingsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingsButton.ForeColor = System.Drawing.Color.Black
        Me.SettingsButton.Location = New System.Drawing.Point(786, 10)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(114, 37)
        Me.SettingsButton.TabIndex = 13
        Me.SettingsButton.Text = "Settings"
        Me.SettingsButton.UseVisualStyleBackColor = True
        '
        'FinishButton
        '
        Me.FinishButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinishButton.ForeColor = System.Drawing.Color.Black
        Me.FinishButton.Location = New System.Drawing.Point(906, 10)
        Me.FinishButton.Name = "FinishButton"
        Me.FinishButton.Size = New System.Drawing.Size(92, 37)
        Me.FinishButton.TabIndex = 14
        Me.FinishButton.Text = "Done"
        Me.FinishButton.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackgroundImage = Global.MyScout2015.My.Resources.Resources.bck_orange01
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.BottomBarGroupBox)
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 730)
        Me.SplitContainer1.SplitterDistance = 686
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 3
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackgroundImage = Global.MyScout2015.My.Resources.Resources.bck_orange01
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.AutoScroll = True
        Me.SplitContainer2.Panel1.Controls.Add(Me.TopBarGroupBox)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.BackgroundImage = Global.MyScout2015.My.Resources.Resources.bck_orange01
        Me.SplitContainer2.Size = New System.Drawing.Size(1008, 686)
        Me.SplitContainer2.SplitterDistance = 53
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 0
        '
        'OverviewPrintDocument
        '
        Me.OverviewPrintDocument.DocumentName = "MyScoutResults"
        '
        'OverviewPrintDialog
        '
        Me.OverviewPrintDialog.UseEXDialog = True
        '
        'OverviewPrintPreviewDialog
        '
        Me.OverviewPrintPreviewDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.OverviewPrintPreviewDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.OverviewPrintPreviewDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.OverviewPrintPreviewDialog.Enabled = True
        Me.OverviewPrintPreviewDialog.Icon = CType(resources.GetObject("OverviewPrintPreviewDialog.Icon"), System.Drawing.Icon)
        Me.OverviewPrintPreviewDialog.Name = "OverviewPrintPreviewDialog"
        Me.OverviewPrintPreviewDialog.Visible = False
        '
        'TotalsContextMenuStrip
        '
        Me.TotalsContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowSubscoresToolStripMenuItem})
        Me.TotalsContextMenuStrip.Name = "TotalsContextMenuStrip"
        Me.TotalsContextMenuStrip.Size = New System.Drawing.Size(160, 26)
        '
        'ShowSubscoresToolStripMenuItem
        '
        Me.ShowSubscoresToolStripMenuItem.Name = "ShowSubscoresToolStripMenuItem"
        Me.ShowSubscoresToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ShowSubscoresToolStripMenuItem.Text = "Show Subscores"
        '
        'ScoreOverview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BackgroundImage = Global.MyScout2015.My.Resources.Resources.bck_orange01
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.SplitContainer1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(0, 50)
        Me.Name = "ScoreOverview"
        Me.Text = "ScoreOverview"
        Me.TopBarGroupBox.ResumeLayout(False)
        Me.TopBarGroupBox.PerformLayout()
        Me.BottomBarGroupBox.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TotalsContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TopBarGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents TeamColLabel As System.Windows.Forms.Label
    Friend WithEvents AutoColLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OverallColLabel As System.Windows.Forms.Label
    Friend WithEvents OffenseColLabel As System.Windows.Forms.Label
    Friend WithEvents FailsColLabel As System.Windows.Forms.Label
    Friend WithEvents ReachColLabel As System.Windows.Forms.Label
    Friend WithEvents BottomBarGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents FinishButton As System.Windows.Forms.Button
    Friend WithEvents ScoreEntryButton As System.Windows.Forms.Button
    Friend WithEvents SettingsButton As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents RunsColLabel As System.Windows.Forms.Label
    Friend WithEvents PrintButton As System.Windows.Forms.Button
    Friend WithEvents OverviewPrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents OverviewPrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents OverviewPrintPreviewDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents ScheduleButton As System.Windows.Forms.Button
    Friend WithEvents ExportButton As System.Windows.Forms.Button
    Friend WithEvents TotalsContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowSubscoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KnockdownsColLabel As System.Windows.Forms.Label
    Friend WithEvents BinsColLabel As System.Windows.Forms.Label
End Class
