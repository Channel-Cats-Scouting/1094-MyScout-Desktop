Imports System.IO

' TODO: Allow user to change NextMatch
' TODO: Add "Loading Please Wait" indicator when importing - takes a while

Public Class Schedule
    Dim matchList As List(Of MatchRow) = New List(Of MatchRow)

    Private Sub Schedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Schedule_Reload()

    End Sub

    Public Sub Schedule_Reload()
        ' Load the match data

        Me.Text = GlobalVariables.EventString & " - Schedule"

        Dim myComm As dbCommunicator = New dbCommunicator

        ' Get the match list
        Dim myMatch As List(Of MatchTable)
        myMatch = myComm.GetMatchList(GlobalVariables.EventString)

        ' Dispose of the dbCommunicator, we don't need it anymore
        myComm.Close()

        ' Set the number of matches in the list (we overwrite old ones instead of deleting and recreating them - is faster)
        Try
            ' Delete rows if too many
            While matchList.Count > myMatch.Count
                matchList.Item(matchList.Count - 1).Kill() 'Removes the contained GroupBox from the Class, so dereferencing class will free it
                matchList.RemoveAt(matchList.Count - 1)
            End While

            ' Add rows if not enough
            For j As Int16 = matchList.Count To myMatch.Count - 1 Step 1
                Dim newRow = New MatchRow(6 + 64 * j)
                newRow.SetName(Convert.ToString(j))
                matchList.Add(newRow)
            Next

            ' Load the teams into the list
            Dim i As Integer = 0
            For Each MatchRow In myMatch
                matchList.Item(i).SetAll(MatchRow)

                i += 1
            Next

            ' Reset scrollbar to top of panel (optional)
            'SplitContainer2.Panel2.VerticalScroll.Value = 0

            ' Set the CurrentMatch marker
            If matchList.Count() > 0 And GlobalVariables.CurrentMatchInteger <= GlobalVariables.TotalMatchesInteger Then
                NextMatchLabel.Visible = True
                NextMatchLabel.Top = 20 + 64 * (GlobalVariables.CurrentMatchInteger - 1) - SplitContainer2.Panel2.VerticalScroll.Value
            Else
                NextMatchLabel.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub Schedule_Close(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Clear the schedule list (commented out, unnecessary)
        'For Each row In matchList
        '    row.Kill()
        'Next
        'matchList.Clear()
    End Sub

    Private Function GetHeaderIndices(ByVal readString As String, ByRef matchInd As Int16, ByRef redInd As Int16, ByRef blueInd As Int16, ByRef commaCount As Int16) As Int16
        Dim retVal = 0  ' return 0 if all okay
        Dim temp As Int16

        ' Check if there is a header by scanning the first line for the word "red"
        If Not readString.Contains("red") Then
            ' If there is no proper header, count the number of columns to see if there is a match# column

            temp = 0
            If readString.Contains(","c) Then
                ' Get the count of occurences of the word "red"
                temp = readString.Split(","c).Count()
            Else
                ' If there are no commas, it's a bad file
                Return -2
            End If

            ' If there are 7 columns, assume the first to be match-number, with 3 red followed by 3 blue
            If (temp = 7) Then
                matchInd = 0
                redInd = 1
                blueInd = 4
            ElseIf (temp = 6) Then
                ' If there are 6 columns, assume no match-number, with 3 red followed by 3 blue
                matchInd = -1
                redInd = 0
                blueInd = 3
            Else
                ' Return an error code if an improper number of columns
                Return -2
            End If

            ' Return that there was no header
            Return 0

        Else
            ' *** If there is a header, find the order of the columns by scanning for key words in the header
            ' First scan for match-number
            temp = readString.IndexOf("match")
            If temp <> -1 Then
                ' If there is a match-column, find the column number by counting commas
                commaCount = 0
                For i As Int16 = 0 To temp - 1
                    If readString.ElementAt(i) = ","c Then
                        commaCount += 1
                    End If
                Next
                ' Set the match-column to the number of column-breaks (commas) found before it
                matchInd = commaCount
            End If

            ' Now scan for the red-column
            temp = readString.IndexOf("red")
            ' Return error code if there is no red-column
            If temp = -1 Then
                Return -2
            Else
                ' Find the column number by counting commas
                commaCount = 0
                For i As Int16 = 0 To temp - 1
                    If readString.ElementAt(i) = ","c Then
                        commaCount += 1
                    End If
                Next
                ' Set the red-column to the number of column-breaks (commas) found before it
                redInd = commaCount
            End If

            ' Now scan for the blue-column
            temp = readString.IndexOf("blu")
            ' Return error code if there is no blue-column
            If temp = -1 Then
                Return -2
            Else
                ' Find the column number by counting commas
                commaCount = 0
                For i As Int16 = 0 To temp - 1
                    If readString.ElementAt(i) = ","c Then
                        commaCount += 1
                    End If
                Next
                ' Set the blue-column to the number of column-breaks (commas) found before it
                blueInd = commaCount
            End If

            ' All is good, return so
            Return 1

        End If ' End of checking the header
    End Function

    Private Function GetRosterFromString(readString As String, matchInd As Int16, redInd As Int16, blueInd As Int16, commaCount As Int16) As Int16()
        Dim temp As Int16
        Dim i As Int16 = 0 ' used for various included loops

        Dim matchValues() As Int16 = {1, 0, 0, 0, 0, 0, 0}  ' The match row values read from a line
        '                   {match, blu1, blu2, blu3, red1, red2, red3}

        ' Read the match number from the file if available
        If (matchInd <> -1) Then
            ' Scan through the line until the correct column is reached
            commaCount = 0
            i = 0
            While i < readString.Count AndAlso commaCount < matchInd
                If readString.ElementAt(i) = ","c Then
                    commaCount += 1
                End If
                i += 1
            End While
            ' Set the match-value to the column-value
            matchValues(0) = Convert.ToInt16(GetCsvCell(readString, i))
        End If

        ' ***Now read the red teams
        ' Scan through the line until the correct column is reached
        commaCount = 0
        i = 0
        While i < readString.Count AndAlso commaCount < redInd
            If readString.ElementAt(i) = ","c Then
                commaCount += 1
            End If
            i += 1
        End While
        temp = i   ' the string position to start reading from

        ' Read the next three cells and add them to the match schedule
        For i = 4 To 6
            ' Store the cell value
            'obj_sched.m[matchNum-1,i] = real(scr_getCsvCell(readString,temp))
            matchValues(i) = Convert.ToInt16(GetCsvCell(readString, temp))

            ' Scan to the next cell, skipping any commas or spaces
            temp += 1
            While temp < readString.Count AndAlso readString.ElementAt(temp) <> ","c
                temp += 1
            End While
        Next

        ' ***Now read the blue teams
        ' Scan through the line until the correct column is reached
        commaCount = 0
        i = 0
        While i < readString.Count AndAlso commaCount < blueInd
            If readString.ElementAt(i) = ","c Then
                commaCount += 1
            End If
            i += 1
        End While
        temp = i   ' the string position to start reading from

        ' Read the next three cells and add them to the match schedule
        For i = 1 To 3
            ' Store the cell value
            'obj_sched.m[matchNum-1,i] = real(scr_getCsvCell(readString,temp))
            matchValues(i) = Convert.ToInt16(GetCsvCell(readString, temp))

            ' Scan to the next cell
            temp += 1
            While temp < readString.Count AndAlso readString.ElementAt(temp) <> ","c
                temp += 1
            End While
        Next

        Return matchValues

    End Function

    Public Function ImportSchedule(sender As Object, e As EventArgs) As Int16 Handles ImportButton.Click
        ' * LOADS A SCHEDULE FROM A CSV FILE INTO THE DATABASE * '

        ' Create an instance of the open file dialog box.
        Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog

        ' Set filter options and filter index.
        openFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.Multiselect = False

        ' Call the ShowDialog method to show the dialogbox
        Dim UserClickedOK As System.Windows.Forms.DialogResult = openFileDialog1.ShowDialog()

        ' Process input if the user clicked OK.
        If (UserClickedOK = Windows.Forms.DialogResult.OK) Then
            'Open the selected file to read.
            Dim fileStream As System.IO.Stream = openFileDialog1.OpenFile   ' the file input-stream
            Dim loadedList As List(Of MatchTable) = New List(Of MatchTable) ' the list of rows we load

            Try
                Using reader As New System.IO.StreamReader(fileStream)      ' reads the stream of input data; "using" means will discard reader when done

                    ' ***** NOW THE FILE IS READY FOR READING ***** '

                    ' Get the first line (in lower case)
                    Dim readString As String = reader.ReadLine().ToLower()
                    ' TODO: Move file-marker to next line?

                    Dim temp As Int16 = 0       ' reused as various count holders
                    Dim matchInd As Int16 = -1   ' the char index of the Match column
                    Dim redInd As Int16 = 0     ' the char index of the first Red column (red1)
                    Dim blueInd As Int16 = 0    ' the char index of the first Red column (red1)
                    Dim commaCount As Int16 = 0 ' used for counting various commas in various lines

                    ' Find the column indices for match, red, and blue
                    Dim headerStatus = GetHeaderIndices(readString, matchInd, redInd, blueInd, commaCount)

                    If headerStatus < 0 Then
                        ' The file is not formatted properly - quit
                        reader.Close()
                        fileStream.Close()
                        Return -2
                    ElseIf headerStatus = 0 Then
                        ' The file had no header, restart from the top of the file
                        reader.DiscardBufferedData()
                        reader.BaseStream.Seek(0, SeekOrigin.Begin)
                    End If

                    ' *** Now that we have the column indexes, scan the rest of the file and process the data

                    While Not reader.EndOfStream

                        ' Get the next line
                        readString = reader.ReadLine()
                        ' Move file-marker to next line?

                        ' Turn this comma-separated string into a properly ordered array
                        Dim matchValues As Int16() = GetRosterFromString(readString, matchInd, redInd, blueInd, commaCount)

                        ' Now save this value to the list of rows to update in the db
                        Dim thisMatch = New MatchTable
                        thisMatch.Event = GlobalVariables.EventString
                        thisMatch.Match = matchValues(0)
                        thisMatch.Blue1 = matchValues(1)
                        thisMatch.Blue2 = matchValues(2)
                        thisMatch.Blue3 = matchValues(3)
                        thisMatch.Red1 = matchValues(4)
                        thisMatch.Red2 = matchValues(5)
                        thisMatch.Red3 = matchValues(6)
                        loadedList.Add(thisMatch)

                        ' Increment the match number, in case there is no such column
                        matchValues(0) += 1

                    End While


                    ' ***** DONE READING THE FILE ***** '
                End Using
            Catch ex As Exception
                MessageBox.Show("Schedule Import error: " & ex.Message & Environment.NewLine & "The selected file may be improperly formatted.")
            End Try

            ' Close the file
            fileStream.Close()

            ' Now update the db with the matches loaded
            ' (note: this will only overwrite existing matches, leaving matches that are not overwritten)
            Try
                Dim myComm = New dbCommunicator
                For Each row As MatchTable In loadedList
                    myComm.SetMatchSchedule(row)
                Next

                ' Update the Event's total matches
                GlobalVariables.TotalMatchesInteger = (myComm.GetMatchList(GlobalVariables.EventString)).Count()
                Dim thisEvent As EventsTable = New EventsTable
                thisEvent.Event = GlobalVariables.EventString
                thisEvent.AccessDate = Today.Date
                thisEvent.TeamCount = GlobalVariables.TotalTeams
                thisEvent.MatchesComplete = GlobalVariables.CurrentMatchInteger - 1
                thisEvent.isFavorite = GlobalVariables.EventIsFavorite
                thisEvent.MatchCount = GlobalVariables.TotalMatchesInteger   ' this is the only one changing
                myComm.SetEvent(thisEvent)

                myComm.Close()
            Catch ex As Exception
                MessageBox.Show("Schedule Update error: " & ex.Message)
                Return -1
            End Try

            ' Now refresh the displayed schedule
            Schedule_Reload()

        End If

        Return 0    ' success
    End Function

    Private Function GetCsvCell(rowString As String, startPosition As Int16) As String
        ' * RETURNS THE SUBSTRING OF THE GIVEN STRING STARTING AT THE GIVEN INDEX AND ENDING AT THE NEXT COMMA
        '  if arguments are ("1,1111,2222,3333,4444,5555,6666" , 7 ) it would return "2222"
        startPosition = Math.Max(startPosition, 0)
        Dim endPosition = startPosition + 1
        Dim strLength = rowString.Length

        ' Scan through the string starting at the given location (not a ',') until a comma is reached, return the string found
        While endPosition < rowString.Length AndAlso rowString.ElementAt(endPosition) <> ","c
            ' Increment the end of our cell
            endPosition += 1
        End While

        ' Return the string segment found
        Return rowString.Substring(startPosition, endPosition - startPosition).Replace(",", "")

    End Function

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ' ** CLEARS THE WHOLE DB SCHEDULE ** '

        If MsgBox("Are you sure you want to delete the entire schedule?" & Environment.NewLine & "This cannot be undone!", _
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "DELETE") = MsgBoxResult.Yes Then
            If MsgBox("Are you really really sure?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "REALLY DELETE") = MsgBoxResult.Yes Then
                ' Delete the event's schedule
                Dim myComm = New dbCommunicator
                myComm.DeleteMatchSchedule(GlobalVariables.EventString)

                ' Update Event data
                Dim thisEvent = myComm.GetEventList(GlobalVariables.EventString).First()
                thisEvent.MatchCount = 0
                thisEvent.MatchesComplete = 0
                thisEvent.AccessDate = Today.Date
                myComm.SetEvent(thisEvent)
                GlobalVariables.TotalMatchesInteger = 0
                GlobalVariables.CurrentMatchInteger = 1

                ' Close the connection
                myComm.Close()

                ' Refresh
                Schedule_Reload()
            End If

        End If
    End Sub


    Private Sub EditMatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditMatchToolStripMenuItem.Click
        ' Edit the selected row's roster
        Dim rowIndex As Int16 = Convert.ToInt16(RowContextMenuStrip.SourceControl.Name) ' the name is the index
        MatchEditor.LoadTeams(Convert.ToInt16(RowContextMenuStrip.SourceControl.Text))
        MatchEditor.ShowDialog()

        matchList(rowIndex).SetAll(MatchEditor.myMatch)

    End Sub

    Private Sub NewMatchButton_Click(sender As Object, e As EventArgs) Handles NewMatchButton.Click
        ' Make a new match
        MatchEditor.LoadTeams(-1)
        MatchEditor.ShowDialog()

        If Not MatchEditor.myMatchNum = -1 Then
            Dim j = matchList.Count()
            Dim newRow = New MatchRow(6 + 64 * j)
            newRow.SetName(Convert.ToString(j))
            newRow.SetAll(MatchEditor.myMatch)
            matchList.Add(newRow)

        End If
    End Sub

    Private Sub ExportButton_Click(sender As Object, e As EventArgs) Handles ExportButton.Click
        ' Export the schedule to a csv file

        Try
            ' Create an instance of the open file dialog box.
            Dim saveFileDialog1 As SaveFileDialog = New SaveFileDialog

            ' Set filter options and filter index.
            saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            saveFileDialog1.FilterIndex = 1

            ' Call the ShowDialog method to show the dialogbox
            Dim UserClickedOK As System.Windows.Forms.DialogResult = saveFileDialog1.ShowDialog()
            If UserClickedOK = Windows.Forms.DialogResult.OK Then
                ' Open the file stream for writing
                Dim fileStream As FileStream = saveFileDialog1.OpenFile()
                Dim writer As New StreamWriter(fileStream)

                ' Output the file header
                writer.Write("match, blue 1, blue 2, blue 3, red 1, red 2, red 3")
                writer.WriteLine()

                ' Now output the schedule data
                For Each row In matchList
                    writer.Write(row.GetMatchText() & "," & row.GetBlueText(1) & "," & row.GetBlueText(2) & "," & row.GetBlueText(3) & "," _
                                 & row.GetRedText(1) & "," & row.GetRedText(2) & "," & row.GetRedText(3))
                    writer.WriteLine()
                Next
                ' Close the file
                writer.Flush()
                writer.Close()
                fileStream.Close()

                ' Show message if successful
                MessageBox.Show("Schedule exported to " & saveFileDialog1.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Export Schedule error: " & ex.Message)
        End Try
    End Sub

End Class