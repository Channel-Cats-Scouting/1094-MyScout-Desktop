Imports System.IO

Public Class ScoreOverview

    Dim teamAnalysisList As List(Of AnalysisClass) = New List(Of AnalysisClass)() ' a list of all the group boxes we'll add
    Dim currSort As Int16 = -AnalysisClass.SortByTeam
    Dim printRowStartIndex As Int16 = 0     ' Which index being printed: a sloppy way of "remembering" where to pick up when printing a second or more pages

    Private Sub ScoreOverview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Bring up the Event Load page
            Me.Hide()
            ChooseEvent.ShowDialog()

            If GlobalVariables.EventString = "" Then
                ' Close the whole application if the exit button was hit in the event-chooser form
                Me.Close()
            Else
                ' Load the event data
                Me.Show()
                ScoreOverview_Reload()
            End If

        Catch ex As Exception
            MessageBox.Show("Event Data load error: " & ex.Message)
        End Try
    End Sub

    Public Sub ScoreOverview_Reload()
        ' Load the overview data into the AnalysisClass boxes
        Try
            ' Update the form caption
            Me.Text = GlobalVariables.EventString & " - Score Overview"

            Dim myComm As dbCommunicator = New dbCommunicator

            ' Get the event's list of team totals data
            Dim myTeamTotals As List(Of TeamTotalsTable)
            myTeamTotals = myComm.GetTeamTotalsList(GlobalVariables.EventString)

            ' Dispose of the dbCommunicator, we don't need it anymore
            myComm.Close()

            ' Set the number of teams in the list (we overwrite old ones instead of deleting and recreating them - is faster)
            ' Delete rows if we have too many
            While teamAnalysisList.Count > myTeamTotals.Count
                ' Remove the item at the end of the list
                teamAnalysisList.Item(teamAnalysisList.Count - 1).Kill() ' Removes the contained GroupBox from the Class, so dereferencing the class will free it
                teamAnalysisList.RemoveAt(teamAnalysisList.Count - 1)    ' Dereference the class
            End While

            ' Add rows if we don't have enough
            For j As Int16 = teamAnalysisList.Count To myTeamTotals.Count - 1 Step 1
                teamAnalysisList.Add(New AnalysisClass(12, 6 + 70 * j))
            Next

            ' Load the teams into the list
            Dim i As Integer = 0
            For Each thisrow In myTeamTotals
                teamAnalysisList.Item(i).SetAll(thisrow)

                i += 1
            Next

            ' Load the rankings
            RefreshRanks()

        Catch ex As Exception
            MessageBox.Show("Overview Load error: " & ex.Message)
        End Try


    End Sub

    ''' <summary>
    ''' Sort the list by the given two indices
    ''' </summary>
    ''' <param name="sortFirst">The first index to sort by</param>
    ''' <param name="sortSecond">The second index to sort by</param>
    ''' <remarks></remarks>
    Private Sub SortByIndex(ByVal sortFirst As Int16, ByVal sortSecond As Int16)
        ' currSort denotes the index being sorted by
        ' if it is a negative number, then sorting is backwards for that index

        Dim absSortFirst = Math.Abs(sortFirst)
        Dim secondDir = 1   ' *positive for descending
        Dim firstDir = 1

        If (sortSecond < 0) Then
            secondDir = -1  ' *negative for ascending
        End If
        If (sortFirst < 0) Then
            firstDir = -1  ' *negative for ascending
        End If

        sortSecond = Math.Abs(sortSecond) ' The GetValue function needs an abs value

        ' If already on that sort index, sort the other direction
        If currSort = -sortFirst Then
            ' Sort ascending
            teamAnalysisList.Sort(Function(x, y) CompareTwo(firstDir * x.GetValue(absSortFirst), firstDir * y.GetValue(absSortFirst), secondDir * y.GetValue(sortSecond), secondDir * x.GetValue(sortSecond)))
            currSort = sortFirst
        Else
            ' Sort descending
            teamAnalysisList.Sort(Function(x, y) CompareTwo(firstDir * y.GetValue(absSortFirst), firstDir * x.GetValue(absSortFirst), secondDir * y.GetValue(sortSecond), secondDir * x.GetValue(sortSecond)))
            currSort = -sortFirst
        End If
    End Sub

    Public Sub SortData(ByVal sortInd As Int16)
        ' Define which direction each column gets sorted by
        Select Case sortInd
            Case AnalysisClass.SortByTeam
                SortByIndex(-sortInd, AnalysisClass.SortByOverall)
            Case AnalysisClass.SortByOverall
                SortByIndex(sortInd, -AnalysisClass.SortByTeam)
            Case AnalysisClass.SortByRuns
                SortByIndex(sortInd, AnalysisClass.SortByOverall)
            Case AnalysisClass.SortByOffense
                SortByIndex(sortInd, AnalysisClass.SortByOverall)
            Case AnalysisClass.SortByAuto
                SortByIndex(sortInd, AnalysisClass.SortByOverall)
            Case AnalysisClass.SortByFails
                SortByIndex(-sortInd, AnalysisClass.SortByOverall)
            Case AnalysisClass.SortByKnockdowns
                SortByIndex(sortInd, AnalysisClass.SortByOverall)
            Case AnalysisClass.SortByReach
                SortByIndex(sortInd, AnalysisClass.SortByOverall)
            Case Else
                ' Stop, invalid input
                Return

        End Select

    End Sub

    Public Sub RefreshRows(Optional toSort As Int16 = -1)
        ' Resort data without inverting order
        Dim oldCurrSort = currSort
        currSort = toSort + 1

        If toSort = -1 Then
            SortData(Math.Abs(oldCurrSort))
        Else
            SortData(toSort)
        End If

        ' Reposition the AnalysisClass rows to match the sort
        PositionRows()

    End Sub

    Private Sub PositionRows()
        ' Reposition the groupboxes based on their location in teamAnalysisList after the sort
        Dim offsetY = SplitContainer2.Panel2.VerticalScroll.Value
        Dim i As Integer = 0
        For Each obj In teamAnalysisList
            obj.SetBoxY(6 + 70 * i - offsetY)
            i += 1
        Next
    End Sub

    Public Sub RefreshRanks()
        ' Sort by overall, if not so already
        If currSort <> AnalysisClass.SortByOverall Then
            teamAnalysisList.Sort(Function(x, y) y.GetOverall().CompareTo(x.GetOverall()))
        End If

        ' Set the ranks
        If teamAnalysisList.Count() > 0 Then
            teamAnalysisList.ElementAt(0).rank = 1
        End If
        Dim thisRank = 1    ' the value to print in case of a tie

        For i As Int16 = 1 To teamAnalysisList.Count() - 1
            If teamAnalysisList.ElementAt(i).GetOverall() <> teamAnalysisList.ElementAt(i - 1).GetOverall() Then
                thisRank = i + 1
            End If
            teamAnalysisList.ElementAt(i).rank = thisRank
        Next

        ' Return to the previous sort
        If currSort <> AnalysisClass.SortByOverall Then
            SortData(Math.Abs(currSort))
            PositionRows()
        End If
    End Sub

    'Sub ScrollUpdate() Handles Me.Scroll
    '' Was for old method of keeping buttons on edge, but now they live in a panel
    '    BottomBarGroupBox.Location = New Point(0, Me.AutoScrollOffset.Y + Me.Bottom - 91)
    '    TopBarGroupBox.Location = New Point(0, Me.AutoScrollOffset.Y)

    'End Sub

    Private Sub ScoreEntryButton_Click(sender As Object, e As EventArgs) Handles ScoreEntryButton.Click
        Me.Hide()
        ScoreEntryForm.ShowDialog()
        Me.Show()
        ScoreOverview_Reload()
    End Sub

    Private Sub Form_Exit(sender As Object, e As EventArgs) Handles FinishButton.Click

        ' Bring up the Event Load page
        GlobalVariables.EventString = ""

        ' Hide the main page
        Me.Hide()

        ' Reset form variables
        For Each row In teamAnalysisList
            row.Kill() ' removes the row's groupbox from the form
        Next
        teamAnalysisList.Clear()
        currSort = AnalysisClass.SortByTeam

        ' Bring up the event-chooser, returning to this form when it is done
        ChooseEvent.ShowDialog()

        If GlobalVariables.EventString = "" Then
            ' Close the whole application if the exit button was hit in the event-chooser form
            Me.Close()
        Else
            ' Load the event data
            Me.Show()
            ScoreOverview_Reload()
        End If

    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        Settings.ShowDialog()
        ScoreOverview_Reload()
    End Sub

    ' ********** SORT BUTTONS ********** '

    Private Sub SortTeamButton_Click(sender As Object, e As EventArgs) Handles TeamColLabel.Click
        SortData(AnalysisClass.SortByTeam)
        PositionRows()
    End Sub

    Private Sub SortOverallButton_Click(sender As Object, e As EventArgs) Handles OverallColLabel.Click
        SortData(AnalysisClass.SortByOverall)
        PositionRows()
    End Sub

    Private Sub SortOffenseButton_Click(sender As Object, e As EventArgs) Handles OffenseColLabel.Click
        SortData(AnalysisClass.SortByOffense)
        PositionRows()
    End Sub

    Private Sub BinsColLabel_Click(sender As Object, e As EventArgs) Handles BinsColLabel.Click
        SortData(AnalysisClass.SortByReach)
        PositionRows()
    End Sub

    Private Sub SortAutoButton_Click(sender As Object, e As EventArgs) Handles AutoColLabel.Click
        SortData(AnalysisClass.SortByAuto)
        PositionRows()
    End Sub

    Private Sub KnockdownsColLabel_Click(sender As Object, e As EventArgs) Handles KnockdownsColLabel.Click
        SortData(AnalysisClass.SortByKnockdowns)
        PositionRows()
    End Sub

    Private Sub FailsColLabel_Click(sender As Object, e As EventArgs) Handles FailsColLabel.Click
        SortData(AnalysisClass.SortByFails)
        PositionRows()
    End Sub

    Private Sub RunsColLabel_Click(sender As Object, e As EventArgs) Handles RunsColLabel.Click
        SortData(AnalysisClass.SortByRuns)
        PositionRows()
    End Sub


    ' ********** HIGHLIGHT COLUMN BUTTONS ********** ' 

    Private Sub ColLabel_MouseEnter(sender As Object, e As EventArgs) Handles TeamColLabel.MouseEnter, OverallColLabel.MouseEnter, RunsColLabel.MouseEnter, OffenseColLabel.MouseEnter, AutoColLabel.MouseEnter, ReachColLabel.MouseEnter, FailsColLabel.MouseEnter, KnockdownsColLabel.MouseEnter, BinsColLabel.MouseEnter
        Dim lbl As Label = CType(sender, Label)
        lbl.BackColor = Color.DimGray
    End Sub

    Private Sub ColLabel_MouseLeave(sender As Object, e As EventArgs) Handles TeamColLabel.MouseLeave, OverallColLabel.MouseLeave, RunsColLabel.MouseLeave, OffenseColLabel.MouseLeave, AutoColLabel.MouseLeave, ReachColLabel.MouseLeave, FailsColLabel.MouseLeave, KnockdownsColLabel.MouseLeave, BinsColLabel.MouseLeave
        Dim lbl As Label = CType(sender, Label)
        lbl.BackColor = Color.Black
    End Sub


    ' ********** OTHER BUTTONS ********** '

    Private Sub PrintButton_Click(sender As Object, e As EventArgs) Handles PrintButton.Click
        Try
            OverviewPrintPreviewDialog.Document = OverviewPrintDocument
            If OverviewPrintPreviewDialog.ShowDialog() = DialogResult.OK Then
                OverviewPrintDocument.Print()
            End If
            printRowStartIndex = 0  ' Reset so further print actions start from the start
        Catch ex As Exception
            MessageBox.Show("Print Data error: " & ex.Message)
        End Try
    End Sub

    Private Sub OverviewPrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles OverviewPrintDocument.PrintPage
        ' specify fonts for printing
        Dim myHeaderFont = New Font("Microsoft Sans Serif", 10)
        Dim myDataFont = New Font("Microsoft Sans Serif", 12)
        Dim mySmallFont = New Font("Microsoft Sans Serif", 8)
        Dim myBoldFont = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)

        'e.Graphics.PageUnit = GraphicsUnit.Inch    ' Changes the units used for drawing on the page

        Const introMargin As Int16 = 48 ' How far below the margin to print the first row of data
        Dim maxRows As Int16 = Math.Min(Math.Max(30, GlobalVariables.TotalTeams), 45)  ' The max number of rows to print, for example, bounded from 30 to 45
        ' Increasing the max will make the rows more squished, if there're enough to fill the page
        ' The min value determines the default relaxed row height, when there aren't enough rows to fill the page

        Dim leftMargin As Int16 = 60                                        ' The space on either side of the table
        Dim topMargin As Int16 = 60                                         ' The space before the top of the table
        Dim bottomMargin As Int16 = 30                                      ' The space after the end of the table
        Dim printWidth As Int16 = e.PageBounds.Width - leftMargin * 2       ' The width of the table

        Dim ySpacing As Int16 = (e.PageBounds.Height - topMargin - introMargin - bottomMargin) / maxRows ' (e.MarginBounds.Height - introMargin) / maxRows 
        Dim rowHeight As Int16 = Math.Min(ySpacing, 28)   ' the thickness of a row of data, to fit maxRows into the space between the margins
        Const headerHeight As Int16 = 24                  ' how far below the upper margin to print the header

        Dim widthWeights() As Int16 = {3, 3, 6, 5, 5, 4, 4, 3, 3, 3, 5}    ' relative proportion of column widths
        Dim widthUnit As Single = 0
        For Each element In widthWeights
            widthUnit += element
        Next
        widthUnit = e.MarginBounds.Width / widthUnit

        ' Calculate the widths of each column
        Dim columnWidths(widthWeights.Count() - 1) As Int16
        For i As Int16 = 0 To widthWeights.Count() - 1
            columnWidths(i) = widthUnit * widthWeights(i)
        Next


        ' Calculate the starting x of each column
        Dim columnStarts(widthWeights.Count()) As Int16
        columnStarts(0) = leftMargin
        columnStarts(widthWeights.Count()) = printWidth  ' e.MarginBounds.Width() ' Set an extra value for the far right side of the table
        Dim currentX = columnWidths(0)
        For i As Int16 = 1 To widthWeights.Count() - 1
            columnStarts(i) = leftMargin + currentX
            currentX += columnWidths(i)
        Next


        Dim sortedInd As Int16 = Math.Abs(currSort)     ' the index of the column sorted by

        ' Draw sort indicator
        Dim triangleX As Integer = (columnStarts(sortedInd) + columnStarts(sortedInd + 1)) / 2
        e.Graphics.DrawPolygon(Pens.Black, {New Point(triangleX - 16, topMargin), New Point(triangleX + 16, topMargin), New Point(triangleX, topMargin + 8)})

        ' Draw column headers
        Dim headerTexts() As String = {"Rank", "Team", "Name", "Total", "Tele", "RC", "Auto", "Knocks", "Reach", "#Fails", "Comments"}
        Dim columnDataFonts(headerTexts.Count) As Font      ' The font to use for the data cells for each column

        columnDataFonts(0) = myBoldFont
        columnDataFonts(1) = myDataFont
        columnDataFonts(2) = mySmallFont
        columnDataFonts(3) = myDataFont
        columnDataFonts(4) = myDataFont
        columnDataFonts(5) = myHeaderFont
        columnDataFonts(6) = myDataFont
        columnDataFonts(7) = myDataFont
        columnDataFonts(8) = myDataFont
        columnDataFonts(9) = myDataFont
        columnDataFonts(10) = mySmallFont

        For i As Int16 = 0 To headerTexts.Count - 1
            e.Graphics.DrawString(headerTexts(i), myHeaderFont, Brushes.Black, 4 + columnStarts(i), topMargin + headerHeight)
        Next
        'e.Graphics.DrawString("Rank", myHeaderFont, Brushes.Black, 2, headerHeight)
        'e.Graphics.DrawString("Team", myHeaderFont, Brushes.Black, 8 + columnStarts(1), headerHeight)
        'e.Graphics.DrawString("Total", myHeaderFont, Brushes.Black, 8 + columnStarts(2), headerHeight)
        'e.Graphics.DrawString("Avg" & Environment.NewLine & "Offense", myHeaderFont, Brushes.Black, 8 + columnStarts(3), headerHeight - myHeaderFont.Height)
        'e.Graphics.DrawString("Avg" & Environment.NewLine & "Assists", myHeaderFont, Brushes.Black, 8 + columnStarts(4), headerHeight - myHeaderFont.Height)
        'e.Graphics.DrawString("Avg" & Environment.NewLine & "Auto", myHeaderFont, Brushes.Black, 8 + columnStarts(5), headerHeight - myHeaderFont.Height)
        'e.Graphics.DrawString("Pickup" & Environment.NewLine & "Speed", myHeaderFont, Brushes.Black, 8 + columnStarts(6), headerHeight - myHeaderFont.Height)
        'e.Graphics.DrawString("#Fails", myHeaderFont, Brushes.Black, columnStarts(7), headerHeight)
        'e.Graphics.DrawString("Can" & Environment.NewLine & "Push", myHeaderFont, Brushes.Black, 2 + columnStarts(8), headerHeight - myHeaderFont.Height)
        'e.Graphics.DrawString("Runs", myHeaderFont, Brushes.Black, 2 + columnStarts(9), headerHeight)

        Dim rowIterator As Int16
        For rowIterator = printRowStartIndex To Math.Min(printRowStartIndex + maxRows - 1, teamAnalysisList.Count - 1)
            Dim row = teamAnalysisList.Item(rowIterator)                      ' The row of this iteration
            Dim thisRowTop = topMargin + introMargin + (rowIterator - printRowStartIndex) * rowHeight ' The top of this row as drawn on the page
            Dim dataStrings(headerTexts.Count) As String            ' An array of the strings to print for this row's data

            ' Draw row-frame
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(leftMargin, thisRowTop, printWidth, rowHeight))

            ' Get and format the data into the strings to be printed
            dataStrings(0) = Convert.ToString(row.rank)                                             ' the first column's data as a string

            dataStrings(1) = Convert.ToString(row.GetTeam())
            dataStrings(2) = LimitString(Convert.ToString(row.teamName), e, columnDataFonts(2), columnStarts(3) - columnStarts(2) - 2) ' Truncate name if too long
            dataStrings(3) = Format(row.GetOverall(), "#0.00")      ' Round to 2 decimal places
            dataStrings(4) = Format(row.GetTele(), "#0.00")
            dataStrings(5) = Format(row.GetBins(), "#0.00")
            dataStrings(6) = Format(row.GetAuto(), "#0.00")
            dataStrings(7) = Convert.ToString(row.GetKnockdowns())
            dataStrings(8) = Convert.ToString(row.GetReach())
            dataStrings(9) = Format(row.GetFail(), "#0")            ' Round to no decimal places
            dataStrings(10) = LimitString(row.comments, e, columnDataFonts(10), columnStarts(11) - columnStarts(10) - 2)

            ' Make each string flush-right
            For j As Int16 = 0 To headerTexts.Count - 1
                If j = 2 Then
                    Continue For        ' j=2 is Team Name, which doesn't need to be right-justified, so skip it
                End If
                dataStrings(j) = dataStrings(j).PadLeft(columnWidths(j) \ 6 - dataStrings(j).Length)    ' make the string flush-right
            Next

            ' Draw the data strings
            For j As Int16 = 0 To headerTexts.Count - 1
                e.Graphics.DrawString(dataStrings(j), columnDataFonts(j), Brushes.Black, columnStarts(j) + 4, thisRowTop + rowHeight / 2 - columnDataFonts(j).GetHeight / 2)
            Next

            ' Draw the column separator lines
            For j As Int16 = 1 To columnStarts.Count - 2
                e.Graphics.DrawLine(Pens.Black, columnStarts(j), thisRowTop, columnStarts(j), thisRowTop + rowHeight)
            Next

        Next

        ' Check for printing additional pages. If told there are more pages, vb will call this sub again, so update the start row for the next page
        printRowStartIndex = rowIterator    ' printRowStartIndex is a class variable, so it will persist between runs of this sub
        e.HasMorePages = printRowStartIndex < teamAnalysisList.Count - 1    ' If we haven't reached the end of the list, we can haz more pages

    End Sub

    Private Sub ScheduleButton_Click(sender As Object, e As EventArgs) Handles ScheduleButton.Click
        'Dim NewForm As Schedule = New Schedule
        Me.Hide()
        Schedule.ShowDialog()
        Me.Show()
    End Sub

    Private Sub ExportButton_Click(sender As Object, e As EventArgs) Handles ExportButton.Click
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
                writer.Write("Team, Total, Teleop, Auto, Knockdowns, #Fails, Reach, Runs,,SubScores:," & _
                             "AutoBins, AutoTotes, AutoMobility, Bins, Totes, Knockdowns, Landfill Litter, Recycled Litter, Fail, Reach")
                writer.WriteLine()

                ' Now output the schedule data
                For Each row In teamAnalysisList
                    Dim runs As Decimal = Math.Max(1, row.GetRuns())
                    writer.Write(Convert.ToString(row.GetTeam()) & "," & Format(row.GetOverall(), "#0.00") & "," & _
                                 Format(row.GetTele(), "#0.00") & "," & _
                                 Format(row.GetAuto(), "#0.00") & "," & row.GetKnockdowns() & "," & Format(row.GetFail(), "#0.00") & "," & _
                                  Convert.ToString(row.GetReach()) & "," & Convert.ToString(row.GetRuns()) & _
                                 ",,," & _
                                 Format((row.autoBinCount * GlobalVariables.AutoBinWeight / runs), "#0.00") & "," & _
                                 Format((row.autoToteScore / runs), "#0.00") & "," & _
                                 Format((row.autoMobilityCount * GlobalVariables.AutoMobilityWeight / runs), "#0.00") & "," & _
                                 Format((row.binScoreCount * GlobalVariables.StackedBinMultiplier / runs), "#0.00") & "," & _
                                 Format((row.toteScoreCount * GlobalVariables.ToteWeight / runs), "#0.00") & "," & _
                                 Format((row.knockdownCount * GlobalVariables.KnockdownWeight / runs), "#0.00") & "," & _
                                 Format((row.landfillScoreCount * GlobalVariables.LandfillLitterWeight / runs), "#0.00") & "," & _
                                 Format((row.recycledScoreCount * GlobalVariables.RecycledLitterWeight / runs), "#0.00") & "," & _
                                 Convert.ToString(row.failCount * GlobalVariables.FailWeight / runs) & "," & _
                                 Convert.ToString(row.toteReachHeight * GlobalVariables.ToteReachHeightWeight))
                    writer.WriteLine()
                Next
                ' Close the file
                writer.Flush()
                writer.Close()
                fileStream.Close()

                ' Show message if successful
                MessageBox.Show("Summary exported to " & saveFileDialog1.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Export Schedule error: " & ex.Message)
            Return
        End Try

    End Sub

    Private Sub ShowSubscoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowSubscoresToolStripMenuItem.Click
        ' Open a window with the subscores
        Dim newSubscoresView = New SubscoresView()
        newSubscoresView.SetSubscores(TotalsContextMenuStrip.SourceControl.Text)
        newSubscoresView.Show()
    End Sub

    Private Function CompareTwo(x1 As Object, y1 As Object, x2 As Object, y2 As Object) As Integer
        '' A custom comparator so we can make in-line double-sort commands
        Dim comp1 As Integer = x1.CompareTo(y1)
        If comp1 <> 0 Then
            Return comp1
        Else
            Return x2.CompareTo(y2)
        End If
    End Function

    Private Function LimitString(str As String, ByRef e As Printing.PrintPageEventArgs, myDataFont As Drawing.Font, width As Decimal) As String
        Dim fullW = e.Graphics.MeasureString(str, myDataFont).Width
        Dim retStr = str
        If fullW > width Then
            ' Add elipses to the end of the returned string
            ' Approximate the truncation point (integer division via '\', as opposed to '/')
            Dim charW = (str.Count * width \ fullW)
            retStr = Microsoft.VisualBasic.Left(retStr, charW - 3)

            ' Replace the last 3 chars with ...
            retStr &= "..."
        End If

        Return retStr
    End Function

End Class