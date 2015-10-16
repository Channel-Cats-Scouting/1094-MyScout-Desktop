Public Class MatchEditor

    Public myMatch As MatchTable
    Public myMatchNum As Int16 = -1

    Public Sub LoadTeams(matchInteger As Int16)

        myMatch = New MatchTable
        myMatch.Event = GlobalVariables.EventString
        myMatch.Match = matchInteger

        If matchInteger > 0 Then
            ' Load the given match data
            Dim myComm As dbCommunicator = New dbCommunicator
            Dim thisMatch As MatchTable = myComm.GetMatchList(GlobalVariables.EventString, matchInteger).First()

            ' Load local values
            myMatchNum = myMatch.Match
            myMatch.Blue1 = thisMatch.Blue1
            myMatch.Blue2 = thisMatch.Blue2
            myMatch.Blue3 = thisMatch.Blue3
            myMatch.Red1 = thisMatch.Red1
            myMatch.Red2 = thisMatch.Red2
            myMatch.Red3 = thisMatch.Red3

            ' Load text box display
            Blue1TextBox.Text = Convert.ToString(thisMatch.Blue1)
            Blue2TextBox.Text = Convert.ToString(thisMatch.Blue2)
            Blue3TextBox.Text = Convert.ToString(thisMatch.Blue3)
            Red1TextBox.Text = Convert.ToString(thisMatch.Red1)
            Red2TextBox.Text = Convert.ToString(thisMatch.Red2)
            Red3TextBox.Text = Convert.ToString(thisMatch.Red3)

            MatchNumLabel.Text = "Match #" & Convert.ToString(matchInteger)

            myComm.Close()
        Else
            ' Load empty values
            myMatchNum = -1
            myMatch.Blue1 = 0
            myMatch.Blue2 = 0
            myMatch.Blue3 = 0
            myMatch.Red1 = 0
            myMatch.Red2 = 0
            myMatch.Red3 = 0

            ' Load empty display
            Blue1TextBox.Text = "0"
            Blue2TextBox.Text = "0"
            Blue3TextBox.Text = "0"
            Red1TextBox.Text = "0"
            Red2TextBox.Text = "0"
            Red3TextBox.Text = "0"

            MatchNumLabel.Text = "Match #" & Convert.ToString(GlobalVariables.TotalMatchesInteger + 1)
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        ' Validate
        If Not IsNumeric(Blue1TextBox.Text) Then Blue1TextBox.Text = "0"
        If Not IsNumeric(Blue2TextBox.Text) Then Blue2TextBox.Text = "0"
        If Not IsNumeric(Blue3TextBox.Text) Then Blue3TextBox.Text = "0"
        If Not IsNumeric(Red1TextBox.Text) Then Red1TextBox.Text = "0"
        If Not IsNumeric(Red2TextBox.Text) Then Red2TextBox.Text = "0"
        If Not IsNumeric(Red3TextBox.Text) Then Red3TextBox.Text = "0"

        Try

            If (Blue1TextBox.Text <> "0" Or Blue2TextBox.Text <> "0" Or Blue3TextBox.Text <> "0") _
                And (Red1TextBox.Text <> "0" Or Red2TextBox.Text <> "0" Or Red3TextBox.Text <> "0") Then
                ' Save changes if meaningful data

                myMatch.Blue1 = Convert.ToInt16(Blue1TextBox.Text)
                myMatch.Blue2 = Convert.ToInt16(Blue2TextBox.Text)
                myMatch.Blue3 = Convert.ToInt16(Blue3TextBox.Text)
                myMatch.Red1 = Convert.ToInt16(Red1TextBox.Text)
                myMatch.Red2 = Convert.ToInt16(Red2TextBox.Text)
                myMatch.Red3 = Convert.ToInt16(Red3TextBox.Text)


                Dim myComm As dbCommunicator = New dbCommunicator
                Dim thisEvent = myComm.GetEventList(GlobalVariables.EventString).First()

                If myMatchNum = -1 Then
                    GlobalVariables.TotalMatchesInteger += 1
                    myMatch.Match = GlobalVariables.TotalMatchesInteger
                    myMatchNum = myMatch.Match
                    thisEvent.MatchCount = GlobalVariables.TotalMatchesInteger
                End If

                thisEvent.AccessDate = Today.Date

                myComm.SetEvent(thisEvent)
                myComm.SetMatchSchedule(myMatch)

                myComm.Close()

                Blue1TextBox.Focus()

                Me.Close()
            Else
                MessageBox.Show("This match data is incomplete or invalid.")
            End If

        Catch ex As Exception
            MessageBox.Show("Match Edit: " & ex.Message)
        End Try


    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelingButton.Click
        Me.Close()
    End Sub
End Class