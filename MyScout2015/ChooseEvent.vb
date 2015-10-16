Public Class ChooseEvent

    Dim eventNameList As List(Of String) = New List(Of String)

    Private Sub ChooseEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            ' Start the db communications
            Dim myConn As dbCommunicator = New dbCommunicator

            eventNameList.Clear()

            ' Get the event list
            Dim myEventList As List(Of EventsTable)
            myEventList = myConn.GetEventList()

            ' Close the connection
            myConn.Close()


            Dim i As Int16 = 0
            For Each newRow In myEventList
                Dim newEventObj = New EventSelector(63 + (254 + 64) * (i Mod 3), 16 + 157 * (i \ 3))
                eventNameList.Add(newRow.Event.ToString)
                newEventObj.SetEvent(newRow.Event.ToString)
                newEventObj.SetComplete(newRow.MatchesComplete.ToString)
                newEventObj.SetTotalMatches(newRow.MatchCount.ToString)
                newEventObj.SetTeamCount(newRow.TeamCount.ToString)
                newEventObj.SetAccessed(newRow.AccessDate.ToString)
                i = i + 1
            Next
        Catch ex As Exception
            MessageBox.Show("Load Event list error: " & ex.Message)
        End Try


        'MessageBox.Show(firstEvent.Event.ToString)
    End Sub

    Private Sub NewButton_Click(sender As Object, e As EventArgs) Handles NewButton.Click
        Dim eventNameString As String = InputBox("Enter New Event Name", "New Event", "")

        ' End if no event name entered
        If eventNameString.Trim(" ").Length < 1 Then
            MessageBox.Show("That is not a valid event name!")
            Return
        End If

        ' End if a duplicate event name is entered
        For Each takenName In eventNameList
            If eventNameString = takenName Then
                MessageBox.Show("That name is already taken!")
                Return
            End If
        Next

        Dim newEvent As EventsTable = New EventsTable
        newEvent.Event = eventNameString
        newEvent.MatchesComplete = 0
        newEvent.MatchCount = 0
        newEvent.TeamCount = 0
        newEvent.AccessDate = Date.Today
        newEvent.isFavorite = False

        ' Save to the database
        Dim myConn As dbCommunicator = New dbCommunicator
        myConn.SetEvent(newEvent)
        myConn.Close()

        GlobalVariables.EventString = eventNameString

        ScoreOverview.Show()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Close the whole application upon the exit button
        If GlobalVariables.EventString = "" Then
            ScoreOverview.Close()
        End If

    End Sub
    
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

        If MsgBox("Are you sure you want to delete the entire event and all associated records?" & Environment.NewLine & "This cannot be undone!", _
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "DELETE") = MsgBoxResult.Yes Then
            If MsgBox("Are you really really really really really sure?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "REALLY DELETE") = MsgBoxResult.Yes Then
                ' Delete the event
                Dim myComm = New dbCommunicator
                myComm.DeleteEvent(EventContextMenuStrip.SourceControl.Text)
                myComm.Close()

                EventContextMenuStrip.SourceControl.Visible = False
                eventNameList.Remove(EventContextMenuStrip.SourceControl.Text)
            End If
        End If

    End Sub
End Class