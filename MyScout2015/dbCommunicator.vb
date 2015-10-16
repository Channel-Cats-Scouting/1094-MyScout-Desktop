Public Class dbCommunicator

    ' Create the Entity Context for our db communications
    Dim dbContext As MyScout2015DBEntities


    Public Sub New()
        dbContext = New MyScout2015DBEntities
    End Sub

    Protected Overrides Sub Finalize()
        ' * Called when this instance is killed

        MyBase.Finalize()
        ' Dispose the context when this class is closed!
        dbContext.Dispose()
    End Sub

    Public Sub Close()
        Me.Finalize()
    End Sub

    Public Function GetEventList(Optional ByVal eventString As String = Nothing) As List(Of EventsTable)
        ' * Returns a list of EventsTable rows

        Try
            Dim eventQuery As IQueryable(Of EventsTable)
            ' Query for the list of events
            If Not eventString = Nothing Then
                eventQuery = From e In dbContext.EventsTables Where e.Event = eventString Select e
            Else
                eventQuery = From e In dbContext.EventsTables Select e
            End If
            ' Convert the result of this query to a list
            Dim eventList As List(Of EventsTable) = eventQuery.ToList()
            ' Return this list
            Return eventList
        Catch ex As Exception
            MessageBox.Show("Get Event: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Sub SetEvent(ByVal eventTable As EventsTable)
        ' * Adds/replaces a row to EventsTable

        Dim eventString = eventTable.Event
        Try
            If dbContext.EventsTables.Any(Function(o) o.Event = eventString) Then
                ' If the given team's totals already exist, update them
                Dim currEntry As EventsTable = GetEventList(eventString).First
                currEntry.AccessDate = eventTable.AccessDate
                currEntry.TeamCount = eventTable.TeamCount
                currEntry.MatchCount = eventTable.MatchCount
                currEntry.MatchesComplete = eventTable.MatchesComplete
                currEntry.isFavorite = eventTable.isFavorite
            Else
                ' If no record already exists, add this record
                dbContext.AddToEventsTables(eventTable)
            End If

            dbContext.SaveChanges()
        Catch ex As Exception
            MessageBox.Show("Set Event: " & ex.Message)
        End Try

    End Sub

    Public Sub DeleteEvent(eventString As String)
        Try
            ' First delete the data in dependent tables
            Dim myMatches = GetMatchList(eventString)
            For Each row In myMatches
                dbContext.DeleteObject(row)
            Next

            Dim scoresQuery As IQueryable(Of ScoresTable) = (From e In dbContext.ScoresTables Where e.Event = eventString Select e)
            Dim myScores As List(Of ScoresTable) = scoresQuery.ToList()
            For Each row In myScores
                dbContext.DeleteObject(row)
            Next

            Dim myTotals = GetTeamTotalsList(eventString)
            For Each row In myTotals
                dbContext.DeleteObject(row)
            Next

            ' Now delete the event
            Dim myEvent = GetEventList(eventString).First()
            dbContext.DeleteObject(myEvent)

            dbContext.SaveChanges()

        Catch ex As Exception
            MessageBox.Show("Event Delete error: " & ex.Message)
        End Try
    End Sub

    Public Function GetTeamTotalsList(ByVal eventString As String, Optional ByVal teamInteger As Int16 = Nothing) As List(Of TeamTotalsTable)
        ' * Returns a list of TeamTotalsTables rows

        Try
            Dim totalsQuery As IQueryable(Of TeamTotalsTable)

            If Not teamInteger = Nothing Then
                ' If a team number was supplied, query for that team's totals
                totalsQuery = From e In dbContext.TeamTotalsTables _
                              Where e.Event = eventString And e.Team = teamInteger _
                              Select e
            Else
                ' If no team number was supplied, query for the whole list of team totals in the given event
                totalsQuery = From e In dbContext.TeamTotalsTables
                              Where e.Event = eventString _
                              Select e
            End If

            ' Convert the result of this query to a list
            Dim totalsList As List(Of TeamTotalsTable) = totalsQuery.ToList()

            ' Return this list
            Return totalsList

        Catch ex As Exception
            MessageBox.Show("Get TeamTotals: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Sub SetTeamTotals(ByVal totalsTable As TeamTotalsTable)
        ' * Adds/replaces a row to TeamTotalsTable

        Try
            Dim eventString = totalsTable.Event
            Dim teamInteger = totalsTable.Team

            If dbContext.TeamTotalsTables.Any(Function(o) o.Event = eventString AndAlso o.Team = teamInteger) Then
                Dim currEntry As TeamTotalsTable = GetTeamTotalsList(eventString, teamInteger).First
                ' Copy the given values to the existing table entry
                currEntry.AutoToteTotal = totalsTable.AutoToteTotal
                currEntry.AutoTotalContainers = totalsTable.AutoTotalContainers
                currEntry.AutoMobilityTotal = totalsTable.AutoMobilityTotal
                currEntry.ToteScoreCountTotal = totalsTable.ToteScoreCountTotal
                currEntry.BinsStackedTotal = totalsTable.BinsStackedTotal
                currEntry.FailTotal = totalsTable.FailTotal
                currEntry.KnockdownTotal = totalsTable.KnockdownTotal
                currEntry.LandfillLitterTotal = totalsTable.LandfillLitterTotal
                currEntry.RecycledLitterTotal = totalsTable.RecycledLitterTotal

                currEntry.AutoComments = totalsTable.AutoComments
                currEntry.OtherComments = totalsTable.OtherComments
                currEntry.ToteReachHeight = totalsTable.ToteReachHeight
                currEntry.BinReachHeight = totalsTable.BinReachHeight
                currEntry.TeamName = totalsTable.TeamName
                currEntry.Runs = totalsTable.Runs

                ' If the given team's totals already exist, update them
                'dbContext.TeamTotalsTables.Attach(totalsTable)
                'dbContext.ObjectStateManager.ChangeObjectState(totalsTable, EntityState.Modified)
                'BUGGY'
            Else
                ' If no record already exists, add this record
                dbContext.AddToTeamTotalsTables(totalsTable)
            End If

            dbContext.SaveChanges()
        Catch ex As Exception
            MessageBox.Show("Set TeamTotals: " & ex.Message)
            MessageBox.Show("Inner Exception: " & ex.InnerException.Message)
        End Try

    End Sub

    Public Function GetMatchList(ByVal eventString As String, Optional ByVal matchInteger As Int16 = Nothing) As List(Of MatchTable)
        ' * Returns a list of MatchTables rows

        Try
            Dim matchQuery As IQueryable(Of MatchTable)

            If Not matchInteger = Nothing Then
                ' If a match number was supplied, query for that match
                matchQuery = From e In dbContext.MatchTables _
                              Where e.Event = eventString And e.Match = matchInteger _
                              Select e
            Else
                ' If no match number was supplied, query for the whole schedule of matches in the given event
                matchQuery = From e In dbContext.MatchTables _
                              Where e.Event = eventString _
                              Select e
            End If

            ' Convert the result of this query to a list
            Dim matchList As List(Of MatchTable) = matchQuery.ToList()

            ' Return this list
            Return matchList

        Catch ex As Exception
            MessageBox.Show("Get Matches: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Sub SetMatchSchedule(ByVal matchTable As MatchTable)
        ' * Adds/replaces a row to MatchTable

        Try
            Dim eventString = matchTable.Event
            Dim matchInteger = matchTable.Match

            If dbContext.MatchTables.Any(Function(o) o.Event = eventString AndAlso o.Match = matchInteger) Then
                Dim currEntry As MatchTable = GetMatchList(eventString, matchInteger).First
                ' Copy the given values to the existing table entry
                currEntry.Blue1 = matchTable.Blue1
                currEntry.Blue2 = matchTable.Blue2
                currEntry.Blue3 = matchTable.Blue3
                currEntry.Red1 = matchTable.Red1
                currEntry.Red2 = matchTable.Red2
                currEntry.Red3 = matchTable.Red3
                ' If the given match schedule already exists, update it
                'dbContext.MatchTables.Attach(matchTable)
                'dbContext.ObjectStateManager.ChangeObjectState(matchTable, EntityState.Modified)
            Else
                ' If no record already exists, add this record
                dbContext.AddToMatchTables(matchTable)
            End If

            dbContext.SaveChanges()

        Catch ex As Exception
            MessageBox.Show("Set Matches error: " & ex.Message)
            MessageBox.Show("Inner Exception: " & ex.InnerException.Message)
        End Try

    End Sub

    Public Sub DeleteMatchSchedule(eventString As String, Optional matchInteger As Integer = -1)
        Try
            Dim matchList As List(Of MatchTable)

            If matchInteger = -1 Then
                ' Delete all matches for this event
                matchList = GetMatchList(eventString)
            Else
                ' Delete only the specified match
                matchList = GetMatchList(eventString, matchInteger)
            End If

            For Each row In matchList
                ' Delete each row selected
                dbContext.DeleteObject(row)
            Next

            ' Update event data
            'Dim thisEvent As EventsTable = New EventsTable
            'thisEvent.Event = eventString
            'thisEvent.AccessDate = Today.Date
            'thisEvent.isFavorite = GlobalVariables.EventIsFavorite
            'thisEvent.MatchCount = 0
            'thisEvent.MatchesComplete = GlobalVariables.CurrentMatchInteger - 1
            'thisEvent.TeamCount = GlobalVariables.TotalTeams
            'SetEvent(thisEvent)

            ' Finalize the deletion
            dbContext.SaveChanges()

        Catch ex As Exception
            MessageBox.Show("Delete Match error: " & ex.Message)
            MessageBox.Show("Inner Exception: " & ex.InnerException.Message)
        End Try
    End Sub

    Public Function GetScoreList(ByVal eventString As String, ByVal matchInteger As Int16, Optional ByVal teamInteger As Int16 = Nothing) As List(Of ScoresTable)
        ' * Returns a list of ScoresTables rows

        Try
            Dim scoreQuery As IQueryable(Of ScoresTable)

            If Not teamInteger = Nothing Then
                ' If a match number was supplied, query for that match
                scoreQuery = From e In dbContext.ScoresTables _
                              Where e.Event = eventString And e.Match = matchInteger And e.Team = teamInteger _
                              Select e
            Else
                ' If no match number was supplied, query for the whole schedule of matches in the given event
                scoreQuery = From e In dbContext.ScoresTables _
                              Where e.Event = eventString And e.Match = matchInteger _
                              Select e
            End If

            ' Convert the result of this query to a list
            Dim scoreList As List(Of ScoresTable) = scoreQuery.ToList()

            ' Return this list
            Return scoreList

        Catch ex As Exception
            MessageBox.Show("Get Match Scores: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Sub SetScores(ByVal scoreTable As ScoresTable)
        ' * Adds/replaces a row to ScoresTable

        Try
            Dim eventString = scoreTable.Event
            Dim matchInteger = scoreTable.Match
            Dim teamInteger = scoreTable.Team

            If dbContext.ScoresTables.Any(Function(o) o.Event = eventString AndAlso o.Match = matchInteger AndAlso o.Team = teamInteger) Then
                ' If the given match schedule already exists, update it
                Dim currEntry As ScoresTable = GetScoreList(eventString, matchInteger, teamInteger).First
                ' Copy the given values to the existing table entry
                currEntry.AutoTotes = scoreTable.AutoTotes
                currEntry.AutoContainersMoved = scoreTable.AutoContainersMoved
                currEntry.AutoMobility = scoreTable.AutoMobility
                currEntry.ToteScoreCount = scoreTable.ToteScoreCount
                currEntry.AutoMobility = scoreTable.AutoMobility
                currEntry.BinsStacked = scoreTable.BinsStacked
                currEntry.DidFail = scoreTable.DidFail
                currEntry.KnockdownCount = scoreTable.KnockdownCount
                currEntry.LandfillLitterCount = scoreTable.LandfillLitterCount
                currEntry.RecycledLitterCount = scoreTable.RecycledLitterCount
            Else
                ' If no record already exists, add this record
                dbContext.AddToScoresTables(scoreTable)
            End If

            dbContext.SaveChanges()

        Catch ex As Exception
            MessageBox.Show("Set Match Scores: " & ex.Message)
        End Try

    End Sub

End Class
