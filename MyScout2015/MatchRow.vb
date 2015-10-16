
Public Class MatchRow

    Dim BlueGroupBox As GroupBox
    Dim RedGroupBox As GroupBox

    Dim MatchNumberLabel As Label
    Dim Blue1Label As Label
    Dim Blue2Label As Label
    Dim Blue3Label As Label
    Dim Red1Label As Label
    Dim Red2Label As Label
    Dim Red3Label As Label

    Dim autoLowCount As Int16 = 0
    Dim autoHighCount As Int16 = 0
    Dim autoLowHCount As Int16 = 0
    Dim autoHighHCount As Int16 = 0
    Dim autoMobilityCount As Int16 = 0
    Dim lowCount As Int16 = 0

    Public Sub New(ByVal GroupBoxY As Integer)
        'create objects'
        BlueGroupBox = New GroupBox
        RedGroupBox = New GroupBox
        Blue1Label = New Label
        Blue2Label = New Label
        Blue3Label = New Label
        Red1Label = New Label
        Red2Label = New Label
        Red3Label = New Label
        MatchNumberLabel = New Label


        ' place Labels inside group boxes'
        Schedule.SplitContainer2.Panel2.Controls.Add(MatchNumberLabel)
        BlueGroupBox.Controls.Add(Blue1Label)
        BlueGroupBox.Controls.Add(Blue2Label)
        BlueGroupBox.Controls.Add(Blue3Label)
        RedGroupBox.Controls.Add(Red1Label)
        RedGroupBox.Controls.Add(Red2Label)
        RedGroupBox.Controls.Add(Red3Label)

        BlueGroupBox.ContextMenuStrip = Schedule.RowContextMenuStrip
        RedGroupBox.ContextMenuStrip = Schedule.RowContextMenuStrip


        ' set location of objects'
        BlueGroupBox.Location = New Point(120, GroupBoxY)
        RedGroupBox.Location = New Point(420, GroupBoxY)
        Blue1Label.Location = New Point(27, 12)
        Blue2Label.Location = New Point(115, 12)
        Blue3Label.Location = New Point(203, 12)
        Red1Label.Location = New Point(27, 12)
        Red2Label.Location = New Point(115, 12)
        Red3Label.Location = New Point(203, 12)
        MatchNumberLabel.Location = New Point(44, GroupBoxY + 8)

        BlueGroupBox.Size = New Point(295, 53)
        RedGroupBox.Size = New Point(295, 53)
        Blue1Label.Size = New Point(88, 33)
        Blue2Label.Size = New Point(88, 33)
        Blue3Label.Size = New Point(88, 33)
        Red1Label.Size = New Point(88, 33)
        Red2Label.Size = New Point(88, 33)
        Red3Label.Size = New Point(88, 33)
        MatchNumberLabel.Size = New Point(64, 33)

        BlueGroupBox.BackColor = Color.Gainsboro
        RedGroupBox.BackColor = Color.Gainsboro
        MatchNumberLabel.BackColor = Color.Transparent

        Blue1Label.ForeColor = Color.DodgerBlue
        Blue2Label.ForeColor = Color.DodgerBlue
        Blue3Label.ForeColor = Color.DodgerBlue
        Red1Label.ForeColor = Color.Red
        Red2Label.ForeColor = Color.Red
        Red3Label.ForeColor = Color.Red
        MatchNumberLabel.ForeColor = Color.Black


        'MatchNumberLabel.BorderStyle = BorderStyle.FixedSingle
        MatchNumberLabel.TextAlign = ContentAlignment.MiddleRight


        Dim MyFontTiny As Font = New Font("Microsoft Sans Serif", 0.001)
        Dim MyFontMain As Font = New Font("GOST Common", 20)

        BlueGroupBox.Font = MyFontTiny
        RedGroupBox.Font = MyFontTiny
        Blue1Label.Font = MyFontMain
        Blue2Label.Font = MyFontMain
        Blue3Label.Font = MyFontMain
        Red1Label.Font = MyFontMain
        Red2Label.Font = MyFontMain
        Red3Label.Font = MyFontMain
        MatchNumberLabel.Font = MyFontMain


        Schedule.SplitContainer2.Panel2.Controls.Add(BlueGroupBox)
        Schedule.SplitContainer2.Panel2.Controls.Add(RedGroupBox)

    End Sub

    Sub SetBoxY(ByVal y As Integer)
        ' Set where the box (row) is placed vertically (for resorting)
        BlueGroupBox.Top = y
        RedGroupBox.Top = y
        MatchNumberLabel.Top = y
    End Sub

    Public Sub SetName(nameString As String)
        ' Sets the names of the contained controls
        BlueGroupBox.Name = nameString
        RedGroupBox.Name = nameString
        MatchNumberLabel.Name = nameString
    End Sub

    Sub SetAll(ByRef thisMatch As MatchTable)
        MatchNumberLabel.Text = Convert.ToString(thisMatch.Match)
        BlueGroupBox.Text = MatchNumberLabel.Text
        RedGroupBox.Text = MatchNumberLabel.Text
        Blue1Label.Text = Convert.ToString(thisMatch.Blue1)
        Blue2Label.Text = Convert.ToString(thisMatch.Blue2)
        Blue3Label.Text = Convert.ToString(thisMatch.Blue3)
        Red1Label.Text = Convert.ToString(thisMatch.Red1)
        Red2Label.Text = Convert.ToString(thisMatch.Red2)
        Red3Label.Text = Convert.ToString(thisMatch.Red3)

    End Sub

    Function GetMatchText() As String
        Return MatchNumberLabel.Text
    End Function

    Function GetBlueText(ByVal TeamIndex As Integer) As String
        Select Case TeamIndex
            Case 1
                Return Blue1Label.Text
            Case 2
                Return Blue2Label.Text
            Case 3
                Return Blue3Label.Text
            Case Else
                Return ""
        End Select

    End Function

    Function GetRedText(ByVal TeamIndex As Integer) As String
        Select Case TeamIndex
            Case 1
                Return Red1Label.Text
            Case 2
                Return Red2Label.Text
            Case 3
                Return Red3Label.Text
            Case Else
                Return ""
        End Select

    End Function

    Public Sub Kill()
        ScoreOverview.Controls.Remove(BlueGroupBox)
        ScoreOverview.Controls.Remove(RedGroupBox)
        ScoreOverview.Controls.Remove(MatchNumberLabel)
        BlueGroupBox.Dispose()
        RedGroupBox.Dispose()
        MatchNumberLabel.Dispose()
    End Sub
End Class
