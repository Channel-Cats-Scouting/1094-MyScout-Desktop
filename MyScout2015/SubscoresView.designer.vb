<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubscoresView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SubscoresView))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AutoGroupBox = New System.Windows.Forms.GroupBox()
        Me.AutoMobilityLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.AutoBinLabel = New System.Windows.Forms.Label()
        Me.AutoToteLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TeleopGroupBox = New System.Windows.Forms.GroupBox()
        Me.BinReachLabel = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ToteReachLabel = New System.Windows.Forms.Label()
        Me.KnocksLabel = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.FailLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RecycledLabel = New System.Windows.Forms.Label()
        Me.LandfillLabel = New System.Windows.Forms.Label()
        Me.BinLabel = New System.Windows.Forms.Label()
        Me.ToteLabel = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CommentsGroupBox = New System.Windows.Forms.GroupBox()
        Me.OtherCommentsTextBox = New System.Windows.Forms.TextBox()
        Me.AutoCommentsTextBox = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TeamLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RunsLabel = New System.Windows.Forms.Label()
        Me.AutoGroupBox.SuspendLayout()
        Me.TeleopGroupBox.SuspendLayout()
        Me.CommentsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(15, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Totes"
        '
        'AutoGroupBox
        '
        Me.AutoGroupBox.Controls.Add(Me.AutoMobilityLabel)
        Me.AutoGroupBox.Controls.Add(Me.Label6)
        Me.AutoGroupBox.Controls.Add(Me.AutoBinLabel)
        Me.AutoGroupBox.Controls.Add(Me.AutoToteLabel)
        Me.AutoGroupBox.Controls.Add(Me.Label2)
        Me.AutoGroupBox.Controls.Add(Me.Label1)
        Me.AutoGroupBox.Location = New System.Drawing.Point(12, 41)
        Me.AutoGroupBox.Name = "AutoGroupBox"
        Me.AutoGroupBox.Size = New System.Drawing.Size(209, 75)
        Me.AutoGroupBox.TabIndex = 1
        Me.AutoGroupBox.TabStop = False
        Me.AutoGroupBox.Text = "Auto Mode (average actions per match)"
        '
        'AutoMobilityLabel
        '
        Me.AutoMobilityLabel.AutoSize = True
        Me.AutoMobilityLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AutoMobilityLabel.Location = New System.Drawing.Point(154, 24)
        Me.AutoMobilityLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.AutoMobilityLabel.Name = "AutoMobilityLabel"
        Me.AutoMobilityLabel.Size = New System.Drawing.Size(40, 15)
        Me.AutoMobilityLabel.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(105, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Mobility"
        '
        'AutoBinLabel
        '
        Me.AutoBinLabel.AutoSize = True
        Me.AutoBinLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AutoBinLabel.Location = New System.Drawing.Point(53, 49)
        Me.AutoBinLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.AutoBinLabel.Name = "AutoBinLabel"
        Me.AutoBinLabel.Size = New System.Drawing.Size(40, 15)
        Me.AutoBinLabel.TabIndex = 5
        '
        'AutoToteLabel
        '
        Me.AutoToteLabel.AutoSize = True
        Me.AutoToteLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AutoToteLabel.Location = New System.Drawing.Point(53, 26)
        Me.AutoToteLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.AutoToteLabel.Name = "AutoToteLabel"
        Me.AutoToteLabel.Size = New System.Drawing.Size(40, 15)
        Me.AutoToteLabel.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(20, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Bins"
        '
        'TeleopGroupBox
        '
        Me.TeleopGroupBox.Controls.Add(Me.BinReachLabel)
        Me.TeleopGroupBox.Controls.Add(Me.Label18)
        Me.TeleopGroupBox.Controls.Add(Me.ToteReachLabel)
        Me.TeleopGroupBox.Controls.Add(Me.KnocksLabel)
        Me.TeleopGroupBox.Controls.Add(Me.Label11)
        Me.TeleopGroupBox.Controls.Add(Me.Label16)
        Me.TeleopGroupBox.Controls.Add(Me.FailLabel)
        Me.TeleopGroupBox.Controls.Add(Me.Label7)
        Me.TeleopGroupBox.Controls.Add(Me.RecycledLabel)
        Me.TeleopGroupBox.Controls.Add(Me.LandfillLabel)
        Me.TeleopGroupBox.Controls.Add(Me.BinLabel)
        Me.TeleopGroupBox.Controls.Add(Me.ToteLabel)
        Me.TeleopGroupBox.Controls.Add(Me.Label12)
        Me.TeleopGroupBox.Controls.Add(Me.Label13)
        Me.TeleopGroupBox.Controls.Add(Me.Label14)
        Me.TeleopGroupBox.Controls.Add(Me.Label15)
        Me.TeleopGroupBox.Location = New System.Drawing.Point(12, 158)
        Me.TeleopGroupBox.Name = "TeleopGroupBox"
        Me.TeleopGroupBox.Size = New System.Drawing.Size(209, 141)
        Me.TeleopGroupBox.TabIndex = 10
        Me.TeleopGroupBox.TabStop = False
        Me.TeleopGroupBox.Text = "Teleop (average actions per match)"
        '
        'BinReachLabel
        '
        Me.BinReachLabel.AutoSize = True
        Me.BinReachLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BinReachLabel.Location = New System.Drawing.Point(154, 101)
        Me.BinReachLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.BinReachLabel.Name = "BinReachLabel"
        Me.BinReachLabel.Size = New System.Drawing.Size(40, 15)
        Me.BinReachLabel.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(96, 101)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "BinReach"
        '
        'ToteReachLabel
        '
        Me.ToteReachLabel.AutoSize = True
        Me.ToteReachLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ToteReachLabel.Location = New System.Drawing.Point(154, 76)
        Me.ToteReachLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.ToteReachLabel.Name = "ToteReachLabel"
        Me.ToteReachLabel.Size = New System.Drawing.Size(40, 15)
        Me.ToteReachLabel.TabIndex = 13
        '
        'KnocksLabel
        '
        Me.KnocksLabel.AutoSize = True
        Me.KnocksLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.KnocksLabel.Location = New System.Drawing.Point(53, 76)
        Me.KnocksLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.KnocksLabel.Name = "KnocksLabel"
        Me.KnocksLabel.Size = New System.Drawing.Size(40, 15)
        Me.KnocksLabel.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(112, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Reach"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(6, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Knocks"
        '
        'FailLabel
        '
        Me.FailLabel.AutoSize = True
        Me.FailLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.FailLabel.Location = New System.Drawing.Point(53, 101)
        Me.FailLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.FailLabel.Name = "FailLabel"
        Me.FailLabel.Size = New System.Drawing.Size(40, 15)
        Me.FailLabel.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(6, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Failures"
        '
        'RecycledLabel
        '
        Me.RecycledLabel.AutoSize = True
        Me.RecycledLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RecycledLabel.Location = New System.Drawing.Point(154, 51)
        Me.RecycledLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.RecycledLabel.Name = "RecycledLabel"
        Me.RecycledLabel.Size = New System.Drawing.Size(40, 15)
        Me.RecycledLabel.TabIndex = 7
        '
        'LandfillLabel
        '
        Me.LandfillLabel.AutoSize = True
        Me.LandfillLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LandfillLabel.Location = New System.Drawing.Point(154, 26)
        Me.LandfillLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.LandfillLabel.Name = "LandfillLabel"
        Me.LandfillLabel.Size = New System.Drawing.Size(40, 15)
        Me.LandfillLabel.TabIndex = 6
        '
        'BinLabel
        '
        Me.BinLabel.AutoSize = True
        Me.BinLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BinLabel.Location = New System.Drawing.Point(53, 51)
        Me.BinLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.BinLabel.Name = "BinLabel"
        Me.BinLabel.Size = New System.Drawing.Size(40, 15)
        Me.BinLabel.TabIndex = 5
        '
        'ToteLabel
        '
        Me.ToteLabel.AutoSize = True
        Me.ToteLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ToteLabel.Location = New System.Drawing.Point(53, 26)
        Me.ToteLabel.MinimumSize = New System.Drawing.Size(40, 0)
        Me.ToteLabel.Name = "ToteLabel"
        Me.ToteLabel.Size = New System.Drawing.Size(40, 15)
        Me.ToteLabel.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(98, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Recycled"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(98, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Landfilled"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(22, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Bins"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(15, 28)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Totes"
        '
        'CommentsGroupBox
        '
        Me.CommentsGroupBox.Controls.Add(Me.OtherCommentsTextBox)
        Me.CommentsGroupBox.Controls.Add(Me.AutoCommentsTextBox)
        Me.CommentsGroupBox.Controls.Add(Me.Label20)
        Me.CommentsGroupBox.Controls.Add(Me.Label23)
        Me.CommentsGroupBox.Location = New System.Drawing.Point(235, 41)
        Me.CommentsGroupBox.Name = "CommentsGroupBox"
        Me.CommentsGroupBox.Size = New System.Drawing.Size(214, 258)
        Me.CommentsGroupBox.TabIndex = 10
        Me.CommentsGroupBox.TabStop = False
        Me.CommentsGroupBox.Text = "Comments"
        '
        'OtherCommentsTextBox
        '
        Me.OtherCommentsTextBox.BackColor = System.Drawing.Color.White
        Me.OtherCommentsTextBox.Enabled = False
        Me.OtherCommentsTextBox.Location = New System.Drawing.Point(24, 109)
        Me.OtherCommentsTextBox.Multiline = True
        Me.OtherCommentsTextBox.Name = "OtherCommentsTextBox"
        Me.OtherCommentsTextBox.ReadOnly = True
        Me.OtherCommentsTextBox.Size = New System.Drawing.Size(166, 47)
        Me.OtherCommentsTextBox.TabIndex = 11
        '
        'AutoCommentsTextBox
        '
        Me.AutoCommentsTextBox.BackColor = System.Drawing.Color.White
        Me.AutoCommentsTextBox.Enabled = False
        Me.AutoCommentsTextBox.Location = New System.Drawing.Point(24, 43)
        Me.AutoCommentsTextBox.Multiline = True
        Me.AutoCommentsTextBox.Name = "AutoCommentsTextBox"
        Me.AutoCommentsTextBox.ReadOnly = True
        Me.AutoCommentsTextBox.Size = New System.Drawing.Size(166, 45)
        Me.AutoCommentsTextBox.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(21, 93)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(33, 13)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Other"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Location = New System.Drawing.Point(21, 26)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(107, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Automode Comments"
        '
        'TeamLabel
        '
        Me.TeamLabel.AutoSize = True
        Me.TeamLabel.BackColor = System.Drawing.Color.Transparent
        Me.TeamLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TeamLabel.Location = New System.Drawing.Point(99, 9)
        Me.TeamLabel.Name = "TeamLabel"
        Me.TeamLabel.Size = New System.Drawing.Size(58, 20)
        Me.TeamLabel.TabIndex = 11
        Me.TeamLabel.Text = "Team "
        Me.TeamLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(292, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Runs:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'RunsLabel
        '
        Me.RunsLabel.AutoSize = True
        Me.RunsLabel.BackColor = System.Drawing.Color.Transparent
        Me.RunsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunsLabel.Location = New System.Drawing.Point(343, 9)
        Me.RunsLabel.Name = "RunsLabel"
        Me.RunsLabel.Size = New System.Drawing.Size(19, 20)
        Me.RunsLabel.TabIndex = 13
        Me.RunsLabel.Text = "0"
        '
        'SubscoresView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkOrange
        Me.BackgroundImage = Global.MyScout2015.My.Resources.Resources.bck_orange01
        Me.ClientSize = New System.Drawing.Size(461, 309)
        Me.Controls.Add(Me.RunsLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TeamLabel)
        Me.Controls.Add(Me.CommentsGroupBox)
        Me.Controls.Add(Me.TeleopGroupBox)
        Me.Controls.Add(Me.AutoGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SubscoresView"
        Me.Text = "Team Subscores"
        Me.AutoGroupBox.ResumeLayout(False)
        Me.AutoGroupBox.PerformLayout()
        Me.TeleopGroupBox.ResumeLayout(False)
        Me.TeleopGroupBox.PerformLayout()
        Me.CommentsGroupBox.ResumeLayout(False)
        Me.CommentsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AutoGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents AutoMobilityLabel As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents AutoBinLabel As System.Windows.Forms.Label
    Friend WithEvents AutoToteLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TeleopGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ToteReachLabel As System.Windows.Forms.Label
    Friend WithEvents KnocksLabel As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents FailLabel As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RecycledLabel As System.Windows.Forms.Label
    Friend WithEvents LandfillLabel As System.Windows.Forms.Label
    Friend WithEvents BinLabel As System.Windows.Forms.Label
    Friend WithEvents ToteLabel As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents BinReachLabel As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CommentsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents OtherCommentsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AutoCommentsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TeamLabel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RunsLabel As System.Windows.Forms.Label
End Class
