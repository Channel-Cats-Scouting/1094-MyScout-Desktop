Public Class ScoreEntryForm

    '1=Blue1 2=Blue2 3=Blue3 4=Red1 5=Red2 6=Red3' 
    Dim CurrentTeamInteger As Integer = 1

    Dim autoBinString() As String = {"0", "0", "0", "0", "0", "0"}
    Dim autoTotesLists() As List(Of Int16) = {New List(Of Int16), New List(Of Int16), New List(Of Int16), New List(Of Int16), New List(Of Int16), New List(Of Int16)}
    Dim autoMobility() As Boolean = {False, False, False, False, False, False}
    Dim totesString() As String = {"0", "0", "0", "0", "0", "0"}
    Dim landfillLitterString() As String = {"0", "0", "0", "0", "0", "0"}
    Dim recycledLitterString() As String = {"0", "0", "0", "0", "0", "0"}
    Dim knockdownsString() As String = {"0", "0", "0", "0", "0", "0"}
    Dim maxBinReachString() As String = {"0", "0", "0", "0", "0", "0"}
    Dim maxToteReachString() As String = {"0", "0", "0", "0", "0", "0"}
    Dim teamNameString() As String = {"", "", "", "", "", ""}
    Dim binsLists() As List(Of Int16) = {New List(Of Int16), New List(Of Int16), New List(Of Int16), New List(Of Int16), New List(Of Int16), New List(Of Int16)}
    Dim autoCommentsString() As String = {"", "", "", "", "", ""}
    Dim otherCommentsString() As String = {"", "", "", "", "", ""}

    Dim didFailBoolean() As Boolean = {False, False, False, False, False, False}


    Dim teamButtons() As Button = {Blue1Button, Blue2Button, Blue3Button, Red1Button, Red2Button, Red3Button}


    Private Sub ScoreEntryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the title bar caption
        Me.Text = GlobalVariables.EventString & " - Score Entry"

        ' Load the array of team buttons
        teamButtons = {Blue1Button, Blue2Button, Blue3Button, Red1Button, Red2Button, Red3Button}

        autoInputMgr.addImage(AutoTotePictureBox1)
        autoInputMgr.addImage(AutoTotePictureBox2)
        autoInputMgr.addImage(AutoTotePictureBox3)

        teleInputMgr.addImage(TotePictureBox1)
        teleInputMgr.addImage(TotePictureBox2)
        teleInputMgr.addImage(TotePictureBox3)
        teleInputMgr.addImage(TotePictureBox4)
        teleInputMgr.addImage(TotePictureBox5)
        teleInputMgr.addImage(TotePictureBox6)

        autoGroup = New TextBoxGroup(AutoToteListGroupBox, 3, 3)
        teleGroup = New TextBoxGroup(ToteListGroupBox, 6, 9)

        'TeamLabel.Text = "Team " & Blue1Button.Text
        'ColorGroupBox.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub ScoreEntry_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '' When the form is shown, Load the team numbers and scores for this match 

        ' Display the current match number
        MatchNumberLabel.Text = Convert.ToString(GlobalVariables.CurrentMatchInteger)

        ' Reset scores
        ResetLocals()

        ' Establish the db connection
        Dim myComm As dbCommunicator = New dbCommunicator

        ' Load the roster for this match
        LoadRoster(myComm)

        ' Load each team's data (match data and static/comments data)
        LoadTeamLocals(myComm)

        ' Start with Blue-1 selected
        Blue1Button_Click(sender, e)    ' meaningless arguments, but it gets the job done

        ' Close the connection
        myComm.Close()

    End Sub

    Private Sub LoadDisplay()
        'load scores to text boxes'

        AutoBinsValueTextBox.Text = autoBinString(CurrentTeamInteger - 1)

        TotesValueTextBox.Text = TotesString(CurrentTeamInteger - 1)
        LandfillLitterValueTextBox.Text = landfillLitterString(CurrentTeamInteger - 1)
        BinLitterValueTextBox.Text = recycledLitterString(CurrentTeamInteger - 1)
        KnockdownValueTextBox.Text = knockdownsString(CurrentTeamInteger - 1)

        MaxBinValueTextBox.Text = maxBinReachString(CurrentTeamInteger - 1)
        MaxToteValueTextBox.Text = maxToteReachString(CurrentTeamInteger - 1)
        TeamNameTextBox.Text = teamNameString(CurrentTeamInteger - 1)

        autoGroup.ClearAll()
        autoGroup.addList(autoTotesLists(CurrentTeamInteger - 1))
        teleGroup.ClearAll()
        teleGroup.addList(binsLists(CurrentTeamInteger - 1))

        RobotSetCheckBox.Checked = autoMobility(CurrentTeamInteger - 1)
        RobotFailureCheckBox.Checked = didFailBoolean(CurrentTeamInteger - 1)

        AutoCommentsTextBox.Text = autoCommentsString(CurrentTeamInteger - 1)
        OtherCommentsTextBox.Text = otherCommentsString(CurrentTeamInteger - 1)


        'refresh the displayed current-team number
        TeamLabel.Text = "Team " & teamButtons(CurrentTeamInteger - 1).Text
    End Sub

    '***************** ROSTER VALIDATION FUNCTIONS *****************'

    ''' <summary>
    ''' Test whether all team slots are filled
    ''' </summary>
    ''' <returns>True if all team slots have a valid team number, false otherwise</returns>
    ''' <remarks></remarks>
    Private Function CheckAllTeamSlots()
        ' Test each button for a valid team number
        For i = 0 To 5
            If Convert.ToInt16(teamButtons(i).Text) < 1 Then
                ' This button is bad, return false
                Return False
            End If
        Next

        ' All buttons are good, return true
        Return True
    End Function

    ''' <summary>
    ''' Test whether all team slots are empty
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>True if all team slots are empty, false otherwise</remarks>
    Private Function CheckAllTeamsZero()
        ' Test each button for a zero team number
        For i = 0 To 5
            If teamButtons(i).Text <> "0000" Then
                ' This button is not zero, return false
                Return False
            End If
        Next

        ' All buttons are zero, return true
        Return True
    End Function

    ''' <summary>
    ''' Test if there are no duplicate nonzero team numbers
    ''' </summary>
    ''' <returns>True if there are no duplicates, false otherwise</returns>
    ''' <remarks></remarks>
    Private Function CheckNoTeamDuplicates()
        ' Check for duplicate team names
        For i = 0 To 4
            For j = i + 1 To 5
                If teamButtons(i).Text = teamButtons(j).Text And teamButtons(i).Text <> "0000" Then
                    ' A nonzero duplicate!
                    Return False
                End If
            Next
        Next

        ' No team duplicates, return true
        Return True
    End Function


    '***************** DB LOADING FUNCTIONS *****************'

    ''' <summary>
    ''' Load the teams for each slot from the roster schedule, if entered
    ''' </summary>
    ''' <param name="myComm">The database communicator</param>
    ''' <remarks></remarks>
    Private Sub LoadRoster(ByRef myComm As dbCommunicator)
        Try
            ' Get the schedule for this match
            Dim matchList As List(Of MatchTable) = myComm.GetMatchList(GlobalVariables.EventString, GlobalVariables.CurrentMatchInteger)

            If matchList.Count > 0 Then
                Dim matchEntry As MatchTable = matchList.First

                ' Set the team names to match the schedule data
                Blue1Button.Text = Convert.ToString(matchEntry.Blue1)
                Blue2Button.Text = Convert.ToString(matchEntry.Blue2)
                Blue3Button.Text = Convert.ToString(matchEntry.Blue3)
                Red1Button.Text = Convert.ToString(matchEntry.Red1)
                Red2Button.Text = Convert.ToString(matchEntry.Red2)
                Red3Button.Text = Convert.ToString(matchEntry.Red3)

                For i = 0 To 5
                    If teamButtons(i).Text = "0" Then teamButtons(i).Text = "0000"
                Next

            End If

        Catch ex As Exception
            ' ERROR
            MessageBox.Show("LoadRoster: " & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Load the match scores and static team data for each team-button's team
    ''' </summary>
    ''' <param name="myComm">The database communicator to use</param>
    ''' <remarks></remarks>
    Private Sub LoadTeamLocals(ByRef myComm As dbCommunicator)
        Dim scoresList As List(Of ScoresTable)
        Dim totalsList As List(Of TeamTotalsTable)

        Try
            ' For each team
            For i As Int16 = 0 To 5
                If teamButtons(i).Text = "0000" Then
                    Continue For
                End If

                ' Get the previous scores for this match and team totals (if they exist)
                scoresList = myComm.GetScoreList(GlobalVariables.EventString, GlobalVariables.CurrentMatchInteger, Convert.ToInt16(teamButtons(i).Text))
                totalsList = myComm.GetTeamTotalsList(GlobalVariables.EventString, Convert.ToInt16(teamButtons(i).Text))

                ' If there's a match-score entry for this team (aka, this match has been entered before)
                If scoresList.Count > 0 Then
                    ' Store the scores to the entry local variables 
                    Dim scoresEntry As ScoresTable = scoresList.First
                    autoBinString(i) = Convert.ToString(scoresEntry.AutoContainersMoved)
                    autoMobility(i) = Convert.ToString(scoresEntry.AutoMobility)
                    totesString(i) = Convert.ToString(scoresEntry.ToteScoreCount)
                    landfillLitterString(i) = Convert.ToString(scoresEntry.LandfillLitterCount)
                    recycledLitterString(i) = Convert.ToString(scoresEntry.RecycledLitterCount)
                    knockdownsString(i) = Convert.ToString(scoresEntry.KnockdownCount)
                    didFailBoolean(i) = scoresEntry.DidFail

                    autoTotesLists(i) = TokenizeIntString(scoresEntry.AutoTotes)
                    binsLists(i) = TokenizeIntString(scoresEntry.BinsStacked)
                End If

                ' If there's a totals entry for this team (aka, this team has run before)
                If totalsList.Count > 0 Then
                    ' We only requested one entry/row (for this team) - get it
                    Dim totalsEntry As TeamTotalsTable = totalsList.First

                    ' Load the team comments
                    autoCommentsString(i) = totalsEntry.AutoComments
                    otherCommentsString(i) = totalsEntry.OtherComments

                    ' Load reach heights
                    maxBinReachString(i) = totalsEntry.BinReachHeight
                    maxToteReachString(i) = totalsEntry.ToteReachHeight

                    ' Load team names
                    teamNameString(i) = totalsEntry.TeamName
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("LoadTeamLocals: " & ex.Message)
        End Try
    End Sub

    '***************** DB SAVING FUNCTIONS *****************'

    ''' <summary>
    ''' Save the current team roster for the current match to the database
    ''' </summary>
    ''' <param name="myComm">The db communicator to use</param>
    ''' <remarks></remarks>
    Private Sub SaveMatchRoster(ByRef myComm As dbCommunicator)
        Try
            Dim myMatchRow As MatchTable = New MatchTable
            ' Key values: event name and match number
            myMatchRow.Event = GlobalVariables.EventString
            myMatchRow.Match = GlobalVariables.CurrentMatchInteger
            ' Roster values:
            myMatchRow.Blue1 = Int16.Parse(Blue1Button.Text)
            myMatchRow.Blue2 = Int16.Parse(Blue2Button.Text)
            myMatchRow.Blue3 = Int16.Parse(Blue3Button.Text)
            myMatchRow.Red1 = Int16.Parse(Red1Button.Text)
            myMatchRow.Red2 = Int16.Parse(Red2Button.Text)
            myMatchRow.Red3 = Int16.Parse(Red3Button.Text)
            ' Save
            myComm.SetMatchSchedule(myMatchRow)

        Catch ex As Exception
            ' ERROR
            MessageBox.Show(GlobalVariables.EventString & " Update Match Roster: " & ex.Message)
            If Not ex.InnerException.Message = Nothing Then
                MessageBox.Show("Inner Exception: " & ex.InnerException.Message)
            End If
        End Try

    End Sub

    ''' <summary>
    ''' Update the team totals for the given index team
    ''' </summary>
    ''' <param name="myComm">The database communicator to use</param>
    ''' <param name="i">The index of the team to save (0-5)</param>
    ''' <remarks>To allow for overwriting old results, the method is "newTotal = oldTotal-oldValue+newValue"</remarks>
    Private Sub SaveTeamTotal(ByRef myComm As dbCommunicator, i As Int16)
        Try
            ' Declare old totals (from existing database record)
            Dim oldAutoToteTotal As Int16 = 0
            Dim oldAutoBinTotal As Int16 = 0
            Dim oldTotesTotal As Int16 = 0
            Dim oldBinsListTotal As List(Of Int16) = New List(Of Int16)
            Dim oldMobilityTotal As Int16 = 0
            Dim oldFailTotal As Int16 = 0
            Dim oldKnockdownsTotal As Int16 = 0
            Dim oldLandfilledTotal As Int16 = 0
            Dim oldRecycledTotal As Int16 = 0
            Dim oldRunsTotal As Int16 = 0

            ' Declare old scores (from database record of possible previous recording of this match)
            Dim oldAutoTotes As List(Of Int16) = New List(Of Int16)
            Dim oldAutoBins As Int16 = 0
            Dim oldTotes As Int16 = 0
            Dim oldBinsList As List(Of Int16) = New List(Of Int16)
            Dim oldMobility As Int16 = 0
            Dim oldFail As Int16 = 0
            Dim oldKnockdowns As Int16 = 0
            Dim oldLandfilled As Int16 = 0
            Dim oldRecycled As Int16 = 0

            Dim newRun As Int16 = 1  ' whether to add this run to the runs total (versus reentering a match)
            Dim newFail As Int16     ' whether it failed this match
            If didFailBoolean(i) = True Then newFail = 1 Else newFail = 0

            ' Get the old totals list
            Dim oldTotalsList As List(Of TeamTotalsTable) = myComm.GetTeamTotalsList(GlobalVariables.EventString, Convert.ToInt16(teamButtons(i).Text))

            ' Get old team totals if they exist
            If oldTotalsList.Count > 0 Then
                Dim oldTotals As TeamTotalsTable = oldTotalsList.First()
                oldAutoToteTotal = oldTotals.AutoToteTotal
                oldAutoBinTotal = Convert.ToString(oldTotals.AutoTotalContainers)
                oldMobilityTotal = Convert.ToString(oldTotals.AutoMobilityTotal)
                oldTotesTotal = Convert.ToString(oldTotals.ToteScoreCountTotal)
                oldBinsListTotal = TokenizeIntString(oldTotals.BinsStackedTotal)
                oldFailTotal = oldTotals.FailTotal
                oldLandfilledTotal = Convert.ToString(oldTotals.LandfillLitterTotal)
                oldKnockdownsTotal = Convert.ToString(oldTotals.KnockdownTotal)
                oldRecycledTotal = Convert.ToString(oldTotals.RecycledLitterTotal)
                oldRunsTotal = oldTotals.Runs
            End If

            ' Get the old scores for this match if they exist
            Dim oldMatchScores As List(Of ScoresTable) = myComm.GetScoreList(GlobalVariables.EventString, GlobalVariables.CurrentMatchInteger, Convert.ToInt16(teamButtons(i).Text))
            If oldMatchScores.Count > 0 Then
                'They exist
                Dim oldMatch = oldMatchScores.First

                oldAutoBins = oldMatch.AutoContainersMoved
                oldAutoTotes = TokenizeIntString(oldMatch.AutoTotes)
                oldMobility = oldMatch.AutoMobility
                oldTotes = oldMatch.ToteScoreCount
                oldBinsList = TokenizeIntString(oldMatch.BinsStacked)
                oldFail = Convert.ToInt16(oldMatch.DidFail)
                oldLandfilled = oldMatch.LandfillLitterCount
                oldKnockdowns = oldMatch.KnockdownCount
                oldRecycled = oldMatch.RecycledLitterCount
                If oldMatch.DidFail = True Then oldFail = 1
                newRun = 0  ' A previous run exists
            End If

            ' Bundle the team totals update
            Dim newTotals As TeamTotalsTable = New TeamTotalsTable
            ' Key values: event name, team number
            newTotals.Event = GlobalVariables.EventString
            newTotals.Team = teamButtons(i).Text
            ' Match Totals:
            newTotals.AutoTotalContainers = oldAutoBinTotal - oldAutoBins + Convert.ToInt16(autoBinString(i))
            newTotals.AutoToteTotal = oldAutoToteTotal - ConvertToAutoPoints(oldAutoTotes) + ConvertToAutoPoints(autoTotesLists(i))
            newTotals.AutoMobilityTotal = oldMobilityTotal - oldMobility + Convert.ToInt16(autoMobility(i))
            newTotals.ToteScoreCountTotal = oldTotesTotal - oldTotes + Convert.ToInt16(totesString(i))
            'TODO: does this work right?
            newTotals.BinsStackedTotal = sumListContents(oldBinsListTotal) - sumListContents(oldBinsList) + sumListContents(binsLists(i))

            newTotals.LandfillLitterTotal = oldLandfilledTotal - oldLandfilled + Convert.ToInt16(landfillLitterString(i))
            newTotals.RecycledLitterTotal = oldRecycledTotal - oldRecycled + Convert.ToInt16(recycledLitterString(i))
            newTotals.KnockdownTotal = oldKnockdownsTotal - oldKnockdowns + Convert.ToInt16(knockdownsString(i))
            newTotals.FailTotal = oldFailTotal - oldFail + newFail
            newTotals.Runs = oldRunsTotal + newRun
            newTotals.AutoComments = autoCommentsString(i)
            newTotals.OtherComments = otherCommentsString(i)
            newTotals.BinReachHeight = maxBinReachString(i)
            newTotals.ToteReachHeight = maxToteReachString(i)
            newTotals.TeamName = teamNameString(i)

            ' Send the update to the TeamTotalsTable
            myComm.SetTeamTotals(newTotals)

        Catch ex As Exception
            ' ERROR
            MessageBox.Show(GlobalVariables.EventString & " Update Team Totals: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Save the team scores for this match for the given index team
    ''' </summary>
    ''' <param name="myComm">The database communicator to use</param>
    ''' <param name="i">The index of the team to save (0-5)</param>
    ''' <remarks></remarks>
    Private Sub SaveTeamScores(ByRef myComm As dbCommunicator, i As Int16)
        Try
            ' Bundle our row data
            Dim myRow As ScoresTable = New ScoresTable

            ' Key Values: event name, match #, team #
            myRow.Event = GlobalVariables.EventString
            myRow.Match = GlobalVariables.CurrentMatchInteger
            myRow.Team = teamButtons(i).Text

            ' Scores:
            myRow.AutoContainersMoved = Convert.ToInt16(autoBinString(i))
            myRow.AutoTotes = BuildIntString(autoTotesLists(i))
            myRow.AutoMobility = Convert.ToInt16(autoMobility(i))
            myRow.ToteScoreCount = Convert.ToInt16(totesString(i))
            myRow.BinsStacked = BuildIntString(binsLists(i))
            myRow.LandfillLitterCount = Convert.ToInt16(landfillLitterString(i))
            myRow.RecycledLitterCount = Convert.ToInt16(recycledLitterString(i))
            myRow.KnockdownCount = Convert.ToInt16(knockdownsString(i))
            myRow.DidFail = didFailBoolean(i)

            ' Add this row to the database
            myComm.SetScores(myRow)

        Catch ex As Exception
            ' ERROR
            MessageBox.Show(GlobalVariables.EventString & "Update Match Scores: " & ex.Message)
        End Try

    End Sub

    Private Sub UpdateEventGlobals(ByRef myComm As dbCommunicator)
        ' Update global team and match counts
        GlobalVariables.TotalTeams = (myComm.GetTeamTotalsList(GlobalVariables.EventString)).Count()
        GlobalVariables.TotalMatchesInteger = (myComm.GetMatchList(GlobalVariables.EventString)).Count()
    End Sub

    ''' <summary>
    ''' Update the global and database info about the active event
    ''' </summary>
    ''' <param name="myComm">The database communicator to use</param>
    ''' <remarks></remarks>
    Private Sub SaveEventStatus(ByRef myComm As dbCommunicator)
        Try
            ' Save
            Dim thisEvent As EventsTable = New EventsTable
            thisEvent.Event = GlobalVariables.EventString
            thisEvent.AccessDate = Today.Date                                   ' this changes
            thisEvent.TeamCount = GlobalVariables.TotalTeams                    ' this might change
            thisEvent.MatchesComplete = GlobalVariables.CurrentMatchInteger - 1 ' this might changes
            thisEvent.isFavorite = GlobalVariables.EventIsFavorite
            thisEvent.MatchCount = GlobalVariables.TotalMatchesInteger          ' this might change

            myComm.SetEvent(thisEvent)

        Catch ex As Exception
            ' ERROR
            MessageBox.Show("SaveEventStatus: " & ex.Message)
        End Try
    End Sub

    '***************** FINISHING UP FUNCTIONS *****************'

    ''' <summary>
    ''' Reset the various score arrays
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetLocals()
        autoBinString = {"0", "0", "0", "0", "0", "0"}
        For Each element As List(Of Int16) In autoTotesLists
            element.Clear()
        Next
        autoMobility = {False, False, False, False, False, False}
        totesString = {"0", "0", "0", "0", "0", "0"}
        landfillLitterString = {"0", "0", "0", "0", "0", "0"}
        recycledLitterString = {"0", "0", "0", "0", "0", "0"}
        knockdownsString = {"0", "0", "0", "0", "0", "0"}
        maxBinReachString = {"0", "0", "0", "0", "0", "0"}
        maxToteReachString = {"0", "0", "0", "0", "0", "0"}
        teamNameString = {"", "", "", "", "", ""}
        For Each element As List(Of Int16) In binsLists
            element.Clear()
        Next
        autoCommentsString = {"", "", "", "", "", ""}
        otherCommentsString = {"", "", "", "", "", ""}

        didFailBoolean = {False, False, False, False, False, False}

        autoGroup.ClearAll()
        teleGroup.ClearAll()

    End Sub

    Private Sub FinishButton_Click(sender As Object, e As EventArgs) Handles FinishButton.Click

        ' Make sure the current tote-control inputs are saved
        saveToteControlInputs()

        ' Check for empty team names
        If Not CheckAllTeamSlots() Then
            ' Confirm if the user wants to finish
            If MsgBox("Not all teams are entered.  Are you sure you want to save the match results?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                ' Quit this action, the user is canceling
                Return
            ElseIf CheckAllTeamsZero() Then
                ' Othewise, if all teams are empty just quit; there's no information to record
                ' TODO: Perhaps reset the input buttons? Or leave so user can come back to it later?
                autoGroup.ClearAll()
                teleGroup.ClearAll()
                Me.Close()
                Return
            End If
        End If

        ' Check for duplicate team names
        If Not CheckNoTeamDuplicates() Then
            ' A duplicate was found - quit this action
            MessageBox.Show("You know, it's not likely that the same team played multiple times in one match." & Environment.NewLine _
                            & Environment.NewLine & "You might want to rethink your entries.")
            Return
        End If


        ' Now we're ready to start saving. Establish the database connection
        Dim myComm As dbCommunicator = New dbCommunicator

        ' ********* STEP 1 - Update the match record in case any team numbers were changed ********** '
        SaveMatchRoster(myComm)

        ' DO FOR ALL 6 TEAMS '
        For i As Int16 = 0 To 5
            If teamButtons(i).Text = "0000" Then
                Continue For
            End If

            ' ********** STEP 2 - Update the team totals ********** '
            SaveTeamTotal(myComm, i)


            ' ********** STEP 3 - Update the individual match score ********** '
            SaveTeamScores(myComm, i)

        Next 'End loop'


        ' ********** STEP 4 - Tidy up before closing ********** '

        ' Reset button team names for next time the form is opened
        For k = 0 To 5
            teamButtons(k).Text = "0000"
        Next

        ' Increment the match number if this wasn't a redo-entry
        If Convert.ToInt32(MatchNumberLabel.Text) >= GlobalVariables.CurrentMatchInteger Then
            GlobalVariables.CurrentMatchInteger = Convert.ToInt32(MatchNumberLabel.Text) + 1
        End If

        ' Update Event data
        UpdateEventGlobals(myComm)

        ' Save Event data
        SaveEventStatus(myComm)

        ' Close the connection
        myComm.Close()

        ' Reset the local data for next time
        ResetLocals()

        'Return to the Overview form
        Me.Close()

    End Sub

    '***************** RIGHT-CLICK TOOLSTRIP ACTIONS *****************'

    ''' <summary>
    ''' Change the team number
    ''' </summary>
    Private Sub ChangeTeamNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeTeamNumberToolStripMenuItem.Click

        ' Get new team number
        Dim enteredString = InputBox("Enter Team Number", "Team Number Entry", TeamContextMenuStrip.SourceControl.Text).Trim()

        ' Check that the number is valid
        If IsNumeric(enteredString) Then
            ' Check that the number is in range
            Dim stringNum As Int16 = Convert.ToInt16(enteredString)
            If stringNum < 1 Then
                enteredString = "0000"
            Else
                enteredString = Convert.ToString(stringNum)
            End If

            TeamContextMenuStrip.SourceControl.Text = enteredString

            ' Select ("click") the team-button just altered
            If Blue1Button.Text = enteredString Then
                Blue1Button_Click(sender, e)
            ElseIf Blue2Button.Text = enteredString Then
                Blue2Button_Click(sender, e)
            ElseIf Blue3Button.Text = enteredString Then
                Blue3Button_Click(sender, e)
            ElseIf Red1Button.Text = enteredString Then
                Red1Button_Click(sender, e)
            ElseIf Red2Button.Text = enteredString Then
                Red2Button_Click(sender, e)
            Else
                Red3Button_Click(sender, e)
            End If

        Else
            MessageBox.Show("That is not a valid team name.")
        End If

    End Sub

    ''' <summary>
    ''' Change the current match number
    ''' </summary>
    Private Sub ChangeMatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeMatchToolStripMenuItem.Click
        Try

            Dim inputString As String = InputBox("Enter Match Number", "Match Number Entry", MatchContextMenuStrip.SourceControl.Text)
            If IsNumeric(inputString) Then
                MatchNumberLabel.Text = Convert.ToString(Math.Max(1, Convert.ToInt16(inputString)))
                GlobalVariables.CurrentMatchInteger = Convert.ToInt16(inputString)

                ' Load team names if available
                Dim myComm = New dbCommunicator
                Dim thisMatch = myComm.GetMatchList(GlobalVariables.EventString, GlobalVariables.CurrentMatchInteger)

                If thisMatch.Count() > 0 Then
                    Dim teamList = thisMatch.First()
                    Blue1Button.Text = Convert.ToString(teamList.Blue1)
                    Blue2Button.Text = Convert.ToString(teamList.Blue2)
                    Blue3Button.Text = Convert.ToString(teamList.Blue3)
                    Red1Button.Text = Convert.ToString(teamList.Red1)
                    Red2Button.Text = Convert.ToString(teamList.Red2)
                    Red3Button.Text = Convert.ToString(teamList.Red3)

                    For i = 0 To 5
                        If teamButtons(i).Text = "0" Then teamButtons(i).Text = "0000"

                        Dim totalsList = myComm.GetTeamTotalsList(GlobalVariables.EventString, Convert.ToInt16(teamButtons(i).Text))
                        If totalsList.Count > 0 Then
                            Dim totalsEntry As TeamTotalsTable = totalsList.First
                            autoCommentsString(i) = totalsEntry.AutoComments

                            otherCommentsString(i) = totalsEntry.OtherComments



                        Else
                            ' Reset to default
                            autoCommentsString(i) = ""
                            otherCommentsString(i) = ""
                        End If
                    Next
                Else
                    For i = 0 To 5
                        ' Reset to default
                        teamButtons(i).Text = "0000"
                        autoCommentsString(i) = ""
                        otherCommentsString(i) = ""


                    Next
                End If

                myComm.Close()

                Blue1Button_Click(sender, e) 'select the first blue team
            Else
                MessageBox.Show("That is not a valid match number!")
            End If

        Catch ex As Exception
            MessageBox.Show("Change Match error: " & ex.Message)
        End Try

    End Sub

    '***************** TEAM SELECTION BUTTONS *****************'

    Private Sub Blue1Button_Click(sender As Object, e As EventArgs) Handles Blue1Button.Click
        saveToteControlInputs()
        CurrentTeamInteger = 1
        LoadDisplay()

        ColorGroupBox.BackColor = Color.CornflowerBlue
        AllianceLabel.Text = "FRC Blue Alliance"

    End Sub

    Private Sub Blue2Button_Click(sender As Object, e As EventArgs) Handles Blue2Button.Click
        saveToteControlInputs()
        CurrentTeamInteger = 2
        LoadDisplay()
        ColorGroupBox.BackColor = Color.CornflowerBlue
        AllianceLabel.Text = "FRC Blue Alliance"
    End Sub

    Private Sub Blue3Button_Click(sender As Object, e As EventArgs) Handles Blue3Button.Click
        saveToteControlInputs()
        CurrentTeamInteger = 3
        LoadDisplay()
        ColorGroupBox.BackColor = Color.CornflowerBlue
        AllianceLabel.Text = "FRC Blue Alliance"
    End Sub

    Private Sub Red1Button_Click(sender As Object, e As EventArgs) Handles Red1Button.Click
        saveToteControlInputs()
        CurrentTeamInteger = 4
        LoadDisplay()
        ColorGroupBox.BackColor = Color.Red
        AllianceLabel.Text = "FRC Red Alliance"
    End Sub

    Private Sub Red2Button_Click(sender As Object, e As EventArgs) Handles Red2Button.Click
        saveToteControlInputs()
        CurrentTeamInteger = 5
        LoadDisplay()
        ColorGroupBox.BackColor = Color.Red
        AllianceLabel.Text = "FRC Red Alliance"
    End Sub

    Private Sub Red3Button_Click(sender As Object, e As EventArgs) Handles Red3Button.Click
        saveToteControlInputs()
        CurrentTeamInteger = 6
        LoadDisplay()
        ColorGroupBox.BackColor = Color.Red
        AllianceLabel.Text = "FRC Red Alliance"
    End Sub

    '***************** UP BUTTONS *****************'

    ''' <summary>
    ''' Increment the given text box's value, as well as the form's stored value corresponding to that box
    ''' </summary>
    ''' <param name="box">The TextBox whose value needs to be incremented</param>
    ''' <param name="sourceString">The array value which also needs to be incremented</param>
    ''' <remarks></remarks>
    Private Sub IncrementTextBoxText(ByRef box As RichTextBox, ByRef sourceString As String)
        'Increase numerical value of box by one'

        Dim valueInteger As Integer
        Dim valueString As String

        'Get the value in the text box'
        valueInteger = Integer.Parse(box.Text)

        'increase value by 1'
        valueInteger += 1

        ' Convert value to string
        valueString = Convert.ToString(valueInteger)

        ' Assign value back to text box'
        box.Text = valueString

        ' Store the new value
        sourceString = valueString
    End Sub


    Private Sub AutoBinUpButton_Click(sender As Object, e As EventArgs) Handles AutoBinsUpButton.Click
        'Increase numerical value of AutoHighValueTextBox by one'
        IncrementTextBoxText(AutoBinsValueTextBox, autoBinString(CurrentTeamInteger - 1))
    End Sub

    Private Sub TotesUpButton_Click(sender As Object, e As EventArgs) Handles TotesUpButton.Click
        'Increase numerical value of TotesValueTextBox by one'
        IncrementTextBoxText(TotesValueTextBox, totesString(CurrentTeamInteger - 1))
    End Sub

    Private Sub LandfillLitterUpButton_Click(sender As Object, e As EventArgs) Handles LandfillLitterUpButton.Click
        'Increase numerical value of LandfillLitterValueTextBox by one'
        IncrementTextBoxText(LandfillLitterValueTextBox, landfillLitterString(CurrentTeamInteger - 1))
    End Sub

    Private Sub BinLitterUpButton_Click(sender As Object, e As EventArgs) Handles BinLitterUpButton.Click
        'Increase numerical value of BinLitterValueTextBox by one'
        IncrementTextBoxText(BinLitterValueTextBox, recycledLitterString(CurrentTeamInteger - 1))
    End Sub

    Private Sub KnockdownUpButton_Click(sender As Object, e As EventArgs) Handles KnockdownUpButton.Click
        'Increase numerical value of KnockdownValueTextBox by one'
        IncrementTextBoxText(KnockdownValueTextBox, knockdownsString(CurrentTeamInteger - 1))
    End Sub

    Private Sub MaxBinUpButton_Click(sender As Object, e As EventArgs) Handles MaxBinUpButton.Click
        'Increase numerical value of MaxBinValueTextBox by one'
        IncrementTextBoxText(MaxBinValueTextBox, maxBinReachString(CurrentTeamInteger - 1))
    End Sub

    Private Sub MaxToteUpButton_Click(sender As Object, e As EventArgs) Handles MaxToteUpButton.Click
        'Increase numerical value of MaxToteValueTextBox by one'
        IncrementTextBoxText(MaxToteValueTextBox, maxToteReachString(CurrentTeamInteger - 1))
    End Sub

    '***************** DOWN BUTTONS *****************'

    ''' <summary>
    ''' Decrement the given text box's value, as well as the form's stored value corresponding to that box
    ''' </summary>
    ''' <param name="box">The TextBox whose value needs to be decremented</param>
    ''' <param name="sourceString">The array value which also needs to be decremented</param>
    ''' <remarks></remarks>
    Private Sub DecrementTextBoxText(ByRef box As RichTextBox, ByRef sourceString As String)
        ' Decrease numerical value of box by one'

        Dim valueInteger As Integer
        Dim valueString As String

        ' Get the value in the text box'
        valueInteger = Integer.Parse(box.Text)

        ' Decrease value by 1'
        valueInteger = Math.Max(0, valueInteger - 1)

        ' Convert value to string
        valueString = Convert.ToString(valueInteger)

        ' Assign value back to text box'
        box.Text = valueString

        ' Store the new value
        sourceString = valueString

    End Sub

    Private Sub AutoBinDownButton_Click(sender As Object, e As EventArgs) Handles AutoBinsDownButton.Click
        'Decrease numerical value of AutoHighValueTextBox by one'
        DecrementTextBoxText(AutoBinsValueTextBox, autoBinString(CurrentTeamInteger - 1))
    End Sub

    Private Sub TotesDownButton_Click(sender As Object, e As EventArgs) Handles TotesDownButton.Click
        'Decrease numerical value of TotesValueTextBox by one'
        DecrementTextBoxText(TotesValueTextBox, totesString(CurrentTeamInteger - 1))
    End Sub

    Private Sub LandfillLitterDownButton_Click(sender As Object, e As EventArgs) Handles LandfillLitterDownButton.Click
        'Decrease numerical value of LandfillLitterValueTextBox by one'
        DecrementTextBoxText(LandfillLitterValueTextBox, landfillLitterString(CurrentTeamInteger - 1))
    End Sub

    Private Sub BinLitterDownButton_Click(sender As Object, e As EventArgs) Handles BinLitterDownButton.Click
        'Decrease numerical value of BinLitterValueTextBox by one'
        DecrementTextBoxText(BinLitterValueTextBox, recycledLitterString(CurrentTeamInteger - 1))
    End Sub

    Private Sub KnockdownDownButton_Click(sender As Object, e As EventArgs) Handles KnockdownDownButton.Click
        'Decrease numerical value of KnockdownValueTextBox by one'
        DecrementTextBoxText(KnockdownValueTextBox, knockdownsString(CurrentTeamInteger - 1))
    End Sub

    Private Sub MaxBinDownButton_Click(sender As Object, e As EventArgs) Handles MaxBinDownButton.Click
        'Decrease numerical value of MaxBinValueTextBox by one'
        DecrementTextBoxText(MaxBinValueTextBox, maxBinReachString(CurrentTeamInteger - 1))
    End Sub

    Private Sub MaxToteDownButton_Click(sender As Object, e As EventArgs) Handles MaxToteDownButton.Click
        'Decrease numerical value of MaxToteValueTextBox by one'
        DecrementTextBoxText(MaxToteValueTextBox, maxToteReachString(CurrentTeamInteger - 1))
    End Sub

    '***************** TEXT CHANGED - ENTRY VALIDATION *****************'

    ''' <summary>
    ''' Return the numeric string limited to the bounds of the given integer and 0
    ''' </summary>
    ''' <param name="str">The string to cap</param>
    ''' <param name="maxVal">The (optional) value limit for the string (default = 50)</param>
    ''' <returns>The given numeric String after being capped, or Nothing if not numeric</returns>
    ''' <remarks></remarks>
    Public Function LimitStringValue(str As String, Optional maxVal As Int16 = 50)
        If IsNumeric(str) Then
            Dim value = Convert.ToDouble(str)
            value = Convert.ToInt16(value)
            ' Keep the value in bounds
            value = Math.Max(0, Math.Min(maxVal, value))

            Return Convert.ToString(value)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Keep the value in a text box valid (within bounds) and sync'ed with internal storage
    ''' </summary>
    ''' <param name="thisTB">The RichTextBox to validate</param>
    ''' <param name="sourceString">The corresponding internal String to sync with</param>
    ''' <remarks></remarks>
    Private Sub ValidateTextChanged(ByRef thisTB As RichTextBox, ByRef sourceString As String)
        ' Validate
        Dim newStr = LimitStringValue(thisTB.Text)
        If newStr = Nothing Then
            thisTB.Text = sourceString
        Else
            thisTB.Text = newStr
            sourceString = newStr
        End If
        thisTB.Select(thisTB.Text.Length(), 0)
    End Sub

    Private Sub AutoBinValueTextBox_TextChanged(sender As Object, e As EventArgs) Handles AutoBinsValueTextBox.TextChanged
        ValidateTextChanged(CType(sender, RichTextBox), autoBinString(CurrentTeamInteger - 1))
    End Sub

    Private Sub TotesValueTextBox_TextChanged(sender As Object, e As EventArgs) Handles TotesValueTextBox.TextChanged
        ValidateTextChanged(CType(sender, RichTextBox), TotesString(CurrentTeamInteger - 1))
    End Sub

    Private Sub LandfillLitterValueTextBox_TextChanged(sender As Object, e As EventArgs) Handles LandfillLitterValueTextBox.TextChanged
        ValidateTextChanged(CType(sender, RichTextBox), landfillLitterString(CurrentTeamInteger - 1))
    End Sub

    Private Sub BinLitterValueTextBox_TextChanged(sender As Object, e As EventArgs) Handles BinLitterValueTextBox.TextChanged
        ValidateTextChanged(CType(sender, RichTextBox), recycledLitterString(CurrentTeamInteger - 1))
    End Sub

    Private Sub KnockdownValueTextBox_TextChanged(sender As Object, e As EventArgs) Handles KnockdownValueTextBox.TextChanged
        ValidateTextChanged(CType(sender, RichTextBox), knockdownsString(CurrentTeamInteger - 1))
    End Sub

    Private Sub MaxBinValueTextBox_TextChanged(sender As Object, e As EventArgs) Handles MaxBinValueTextBox.TextChanged
        ValidateTextChanged(CType(sender, RichTextBox), maxBinReachString(CurrentTeamInteger - 1))
    End Sub

    Private Sub MaxToteValueTextBox_TextChanged(sender As Object, e As EventArgs) Handles MaxToteValueTextBox.TextChanged
        ValidateTextChanged(CType(sender, RichTextBox), maxToteReachString(CurrentTeamInteger - 1))
    End Sub

    '*********SYNC DIRECT INPUT CHANGES*********'

    Private Sub RobotSetCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles RobotSetCheckBox.CheckedChanged
        ' Store robot set status
        autoMobility(CurrentTeamInteger - 1) = RobotSetCheckBox.Checked
    End Sub

    Private Sub RobotFailCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles RobotFailureCheckBox.CheckedChanged
        ' Store failure status
        didFailBoolean(CurrentTeamInteger - 1) = RobotFailureCheckBox.Checked
    End Sub

    Private Sub AutoCommentsTextBox_TextChanged(sender As Object, e As EventArgs) Handles AutoCommentsTextBox.TextChanged
        ' Store the text
        autoCommentsString(CurrentTeamInteger - 1) = AutoCommentsTextBox.Text

    End Sub

    Private Sub OtherCommentsTextBox_TextChanged(sender As Object, e As EventArgs) Handles OtherCommentsTextBox.TextChanged
        ' Store the text
        otherCommentsString(CurrentTeamInteger - 1) = OtherCommentsTextBox.Text
    End Sub

    Private Sub TeamNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles TeamNameTextBox.TextChanged
        ' Store the text
        teamNameString(CurrentTeamInteger - 1) = TeamNameTextBox.Text
    End Sub


    '**** New Code Starts Here ****'
    Public autoGroup As TextBoxGroup
    Public teleGroup As TextBoxGroup
    Public autoInputMgr As ToteImageInputManager = New ToteImageInputManager(Global.MyScout2015.My.Resources.Resources.ToteTotemGold, Global.MyScout2015.My.Resources.Resources.ToteTotemGoldGreyed)
    Public teleInputMgr As ToteImageInputManager = New ToteImageInputManager(Global.MyScout2015.My.Resources.Resources.ToteTotemGrey, Global.MyScout2015.My.Resources.Resources.ToteTotemGreyGreyed)

    Private Function listElementMath(list1 As List(Of Int16), opChar As Char, list2 As List(Of Int16)) As List(Of Int16)
        Dim result As List(Of Int16) = New List(Of Int16)
        Dim smallSize As Int16
        Dim list1Larger As Boolean
        If (list1.Count > list2.Count) Then
            smallSize = list2.Count
            list1Larger = True
        Else
            smallSize = list1.Count
            list1Larger = False
        End If
        For i As Int16 = 0 To smallSize - 1
            If (opChar = "+") Then
                result.Add(list1(i) + list2(i))
            ElseIf (opChar = "-") Then
                result.Add(list1(i) - list2(i))
            ElseIf (opChar = "*") Then
                result.Add(list1(i) * list2(i))
            ElseIf (opChar = "/") Then
                result.Add(list1(i) * list2(i))
            Else
                MessageBox.Show("Operator: '" & opChar & "' Is not valid")
            End If
        Next
        If list1Larger Then
            For i As Int16 = smallSize To list1.Count - 1
                result.Add(list1(i))
            Next
        Else
            For i As Int16 = smallSize To list2.Count - 1
                result.Add(list2(i))
            Next
        End If
        Return result
    End Function
    Public Function ConvertToAutoPoints(list As List(Of Int16)) As Int16
        Dim result As Int16
        For Each element As Int16 In list
            If element = 3 Then
                result = result + GlobalVariables.AutoTote3Weight
            ElseIf element = 2 Then
                result = result + GlobalVariables.AutoTote2Weight
            ElseIf element = 1 Then
                result = result + GlobalVariables.AutoTote1Weight
            ElseIf element <> 0 Then
                MessageBox.Show("Invalid Auto Tote Stack count: '" & element.ToString & "'")
            End If
        Next
        Return result
    End Function
    ''' <summary>
    ''' This builds the auto tote string
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BuildIntString(list As List(Of Int16)) As String
        Dim result As String = ""
        Dim first = True
        For Each num As Int16 In list
            If first Then
                first = False
            Else
                result &= ","
            End If
            result &= Convert.ToString(num)
        Next
        Return result
    End Function
    Public Function TokenizeIntString(input As String) As List(Of Int16)
        Dim result As List(Of Int16) = New List(Of Int16)

        If (input.Trim.Equals("")) Then
            Return result
        End If

        Dim stringArray As String() = input.Split(",")
        Try
            For Each element As String In stringArray
                result.Add(Convert.ToInt16(element))
            Next
        Catch ex As Exception
            MessageBox.Show("TokenizeIntString error: " & input)
        End Try

        Return result
    End Function

    Private Sub AutoToteAddButton_Click(sender As Object, e As EventArgs) Handles AutoToteAddButton.Click
        autoGroup.Add(1)
        autoInputMgr.highlightToteValue(1)
        autoTotesLists(CurrentTeamInteger - 1) = autoGroup.getIntsList()
    End Sub
    Private Sub ToteAddButton_Click(sender As Object, e As EventArgs) Handles ToteAddButton.Click
        teleGroup.Add(1)
        teleInputMgr.highlightToteValue(1)
        binsLists(CurrentTeamInteger - 1) = teleGroup.getIntsList()
    End Sub

    Private Sub AutoToteClearButton_Click(sender As Object, e As EventArgs) Handles AutoToteClearButton.Click
        autoGroup.Clear()
    End Sub
    Private Sub ToteClearButton_Click(sender As Object, e As EventArgs) Handles ToteClearButton.Click
        teleGroup.Clear()
    End Sub
    Public Sub OnClickedTextBox(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        textBox.SelectAll()
        textBox.BackColor = Color.Orange
        If textBox.Parent.Name.StartsWith("Auto") Then
            autoInputMgr.highlightToteValue(Convert.ToInt16(textBox.Text()))
            autoGroup.SetSelectedIndex(textBox)
            autoGroup.Refresh()
        Else
            teleInputMgr.highlightToteValue(Convert.ToInt16(textBox.Text()))
            teleGroup.SetSelectedIndex(textBox)
            teleGroup.Refresh()
        End If
    End Sub

    Private Sub saveToteControlInputs()
        ' Save the current tote control inputs to their corresponding int lists
        autoTotesLists(CurrentTeamInteger - 1) = autoGroup.getIntsList()
        binsLists(CurrentTeamInteger - 1) = teleGroup.getIntsList()
    End Sub

    Public Function sumListContents(list As List(Of Int16)) As Int16
        Dim retVal As Int16 = 0
        For Each item In list
            retVal += item
        Next
        Return retVal
    End Function

End Class
