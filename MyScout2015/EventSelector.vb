
Public Class EventSelector

    Dim MyGroupBox As GroupBox
    Dim CompleteLabel As Label
    Dim TotalMatchesLabel As Label
    Dim NumberOfTeamsLabel As Label
    Dim AccessedLabel As Label
    Dim CompleteOutputLabel As Label
    Dim TotalMatchesOutputLabel As Label
    Dim NumberOfTeamsOutputLabel As Label
    Dim AccessedOutputLabel As Label
    Dim SelectButton As Button

    Public Sub New(ByVal GroupBoxX As Integer, GroupBoxY As Integer)
        'create objects'
        MyGroupBox = New GroupBox
        CompleteLabel = New Label
        TotalMatchesLabel = New Label
        NumberOfTeamsLabel = New Label
        AccessedLabel = New Label
        CompleteOutputLabel = New Label
        TotalMatchesOutputLabel = New Label
        NumberOfTeamsOutputLabel = New Label
        AccessedOutputLabel = New Label
        SelectButton = New Button

        ' Add clickability to the contained created button
        AddHandler SelectButton.MouseClick, AddressOf Me.ClickButton

        'place Labeles inside group box'
        MyGroupBox.Controls.Add(CompleteLabel)
        MyGroupBox.Controls.Add(TotalMatchesLabel)
        MyGroupBox.Controls.Add(NumberOfTeamsLabel)
        MyGroupBox.Controls.Add(AccessedLabel)
        MyGroupBox.Controls.Add(CompleteOutputLabel)
        MyGroupBox.Controls.Add(TotalMatchesOutputLabel)
        MyGroupBox.Controls.Add(NumberOfTeamsOutputLabel)
        MyGroupBox.Controls.Add(AccessedOutputLabel)
        MyGroupBox.Controls.Add(SelectButton)

        'determining location of objects'
        MyGroupBox.Location = New Point(GroupBoxX, GroupBoxY)
        CompleteLabel.Location = New Point(23, 30)
        TotalMatchesLabel.Location = New Point(23, 52)
        NumberOfTeamsLabel.Location = New Point(23, 75)
        AccessedLabel.Location = New Point(23, 99)
        CompleteOutputLabel.Location = New Point(130, 30)
        TotalMatchesOutputLabel.Location = New Point(130, 52)
        NumberOfTeamsOutputLabel.Location = New Point(130, 75)
        AccessedOutputLabel.Location = New Point(130, 99)
        SelectButton.Location = New Point(174, 26)

        CompleteLabel.Text = "Matches Complete"
        TotalMatchesLabel.Text = "Matches Total"
        NumberOfTeamsLabel.Text = "# Teams"
        AccessedLabel.Text = "Last Accessed"
        SelectButton.Text = "Select"

        CompleteLabel.BorderStyle = BorderStyle.None
        TotalMatchesLabel.BorderStyle = BorderStyle.None
        NumberOfTeamsLabel.BorderStyle = BorderStyle.None
        AccessedLabel.BorderStyle = BorderStyle.None
        CompleteOutputLabel.BorderStyle = BorderStyle.FixedSingle
        TotalMatchesOutputLabel.BorderStyle = BorderStyle.FixedSingle
        NumberOfTeamsOutputLabel.BorderStyle = BorderStyle.FixedSingle
        AccessedOutputLabel.BorderStyle = BorderStyle.FixedSingle


        MyGroupBox.Size = New Point(254, 128)

        CompleteOutputLabel.Size = New Point(35, 15)
        TotalMatchesOutputLabel.Size = New Point(35, 15)
        NumberOfTeamsOutputLabel.Size = New Point(35, 15)
        AccessedOutputLabel.Size = New Point(70, 15)
        SelectButton.Size = New Point(72, 63)


        CompleteOutputLabel.MinimumSize = New Point(30, 0)
        TotalMatchesOutputLabel.MinimumSize = New Point(30, 0)
        NumberOfTeamsOutputLabel.MinimumSize = New Point(30, 0)
        AccessedOutputLabel.MinimumSize = New Point(60, 0)

        MyGroupBox.BackColor = Color.Silver
        CompleteOutputLabel.BackColor = Color.Gainsboro
        TotalMatchesOutputLabel.BackColor = Color.Gainsboro
        NumberOfTeamsOutputLabel.BackColor = Color.Gainsboro
        AccessedOutputLabel.BackColor = Color.Gainsboro

        Dim MainFont As Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        Dim MyFontLarge As Font = New Font("Microsoft Sans Serif", 8)

        MyGroupBox.Font = MainFont
        CompleteLabel.Font = MyFontLarge
        TotalMatchesLabel.Font = MyFontLarge
        NumberOfTeamsLabel.Font = MyFontLarge
        AccessedLabel.Font = MyFontLarge
        CompleteOutputLabel.Font = MyFontLarge
        TotalMatchesOutputLabel.Font = MyFontLarge
        NumberOfTeamsOutputLabel.Font = MyFontLarge
        AccessedOutputLabel.Font = MyFontLarge

        ' Add the right-clickability
        MyGroupBox.ContextMenuStrip = ChooseEvent.EventContextMenuStrip

        ' Add the groupbox to the screen
        ChooseEvent.SplitContainer1.Panel2.Controls.Add(MyGroupBox)


    End Sub

    Sub ClickButton(sender As Object, e As EventArgs)
        ' Save the Event
        GlobalVariables.EventString = MyGroupBox.Text
        GlobalVariables.TotalTeams = Convert.ToInt16(NumberOfTeamsOutputLabel.Text)
        GlobalVariables.TotalMatchesInteger = Convert.ToInt16(TotalMatchesOutputLabel.Text)
        GlobalVariables.CurrentMatchInteger = Convert.ToInt16(CompleteOutputLabel.Text) + 1
        GlobalVariables.EventIsFavorite = False

        ' Open the Score Overview window
        ChooseEvent.Close()
        ChooseEvent.Dispose()

    End Sub
    Sub SetEvent(ByVal newString As String)

        MyGroupBox.Text = (newString)

    End Sub

    Sub SetComplete(ByVal newInteger As Integer)

        CompleteOutputLabel.Text = Convert.ToString(newInteger)

    End Sub

    Sub SetTotalMatches(ByVal newInteger As Integer)

        TotalMatchesOutputLabel.Text = Convert.ToString(newInteger)

    End Sub

    Sub SetTeamCount(ByVal TeamsInteger As Integer)

        NumberOfTeamsOutputLabel.Text = Convert.ToString(TeamsInteger)

    End Sub

    Sub SetAccessed(ByVal newDate As Date)

        AccessedOutputLabel.Text = Convert.ToString(newDate)

    End Sub
End Class
