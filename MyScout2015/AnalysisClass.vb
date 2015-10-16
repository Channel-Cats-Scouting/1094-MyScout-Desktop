
Public Class AnalysisClass

    Public Shared ReadOnly SortByTeam = 1
    Public Shared ReadOnly SortByOverall = 3
    Public Shared ReadOnly SortByOffense = 4
    Public Shared ReadOnly SortByBins = 5
    Public Shared ReadOnly SortByAuto = 6
    Public Shared ReadOnly SortByKnockdowns = 7
    Public Shared ReadOnly SortByReach = 8
    Public Shared ReadOnly SortByFails = 9
    Public Shared ReadOnly SortByRuns = 10

    Dim MyGroupBox As GroupBox
    Dim TeamLabel As Label
    Dim TotalLabel As Label
    Dim OffenseLabel As Label
    Dim BinsLabel As Label
    Dim AutoLabel As Label
    Dim KnockdownsLabel As Label
    Dim ReachLabel As Label
    Dim FailLabel As Label
    Dim RunsLabel As Label

    Public autoToteScore As Int16 = 0
    Public autoContainerCount As Int16 = 0
    Public autoBinCount As Int16 = 0
    Public autoMobilityCount As Int16 = 0
    Public toteScoreCount As Int16 = 0
    Public binScoreCount As Int16 = 0
    Public landfillScoreCount As Int16 = 0
    Public recycledScoreCount As Int16
    Public knockdownCount As Int16 = 0
    Public totesStackedCount As Int16 = 0
    Public binsStackedCount As Int16 = 0
    Public autoCount As Int16 = 0
    Public toteReachHeight As Int16 = 0
    Public binReachHeight As Int16 = 0
    Public failCount As Int16 = 0
    Public runs As Int16 = 1 ' Careful not to divide by 0!

    Public rank As Int16 = 0    ' Ranking compared to other teams; gets set whenever user sorts by Overall
    Public teamName As String = ""
    Public comments As String = ""

    Public Sub New(ByVal GroupBoxX As Integer, GroupBoxY As Integer)
        Dim xOffset = -10
        Dim yOffset = 12

        'create objects'
        MyGroupBox = New GroupBox
        TeamLabel = New Label
        RunsLabel = New Label
        TotalLabel = New Label
        OffenseLabel = New Label
        AutoLabel = New Label
        KnockdownsLabel = New Label
        ReachLabel = New Label
        FailLabel = New Label
        BinsLabel = New Label

        'place Labeles inside group box'
        MyGroupBox.Controls.Add(TeamLabel)
        MyGroupBox.Controls.Add(TotalLabel)
        MyGroupBox.Controls.Add(OffenseLabel)
        MyGroupBox.Controls.Add(BinsLabel)
        MyGroupBox.Controls.Add(AutoLabel)
        MyGroupBox.Controls.Add(KnockdownsLabel)
        MyGroupBox.Controls.Add(ReachLabel)
        MyGroupBox.Controls.Add(FailLabel)
        MyGroupBox.Controls.Add(RunsLabel)

        'Dim lineContainer As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        'Dim line As New Microsoft.VisualBasic.PowerPacks.LineShape(128, 0, 128, 600 + 58)
        ''lineContainer.Dock = DockStyle.Fill
        ''line.BorderColor = Color.Black
        'lineContainer.Shapes.Add(line)
        'line.Parent = lineContainer
        'lineContainer.Parent = ScoreOverview
        'MyGroupBox.Controls.Add(lineContainer)

        'determining location of objects'
        MyGroupBox.Location = New Point(GroupBoxX, GroupBoxY)
        'TeamLabel.Location = New Point(15, 11)
        'TotalLabel.Location = New Point(125, 11)
        'OffenseLabel.Location = New Point(245, 12)
        'BinsLabel.Location = New Point(365, 12)
        'AutoLabel.Location = New Point(480, 12)
        'KnockdownsLabel.Location = New Point(610, 12)
        'ReachLabel.Location = New Point(730, 12)
        'FailLabel.Location = New Point(815, 11)
        'RunsLabel.Location = New Point(900, 14)
        TeamLabel.Location = New Point(xOffset + ScoreOverview.TeamColLabel.Location.X, yOffset)
        TotalLabel.Location = New Point(xOffset + ScoreOverview.OverallColLabel.Location.X, yOffset)
        OffenseLabel.Location = New Point(xOffset + ScoreOverview.OffenseColLabel.Location.X, yOffset)
        BinsLabel.Location = New Point(xOffset + ScoreOverview.BinsColLabel.Location.X, yOffset)
        AutoLabel.Location = New Point(xOffset + ScoreOverview.AutoColLabel.Location.X, yOffset)
        KnockdownsLabel.Location = New Point(xOffset + ScoreOverview.KnockdownsColLabel.Location.X, yOffset)
        ReachLabel.Location = New Point(xOffset + ScoreOverview.ReachColLabel.Location.X, yOffset)
        FailLabel.Location = New Point(xOffset + ScoreOverview.FailsColLabel.Location.X, yOffset)
        RunsLabel.Location = New Point(xOffset + ScoreOverview.RunsColLabel.Location.X, yOffset)

        MyGroupBox.Size = New Point(976, 58)
        TeamLabel.Size = New Point(100, 39)
        TotalLabel.Size = New Point(100, 39)
        OffenseLabel.Size = New Point(99, 37)
        BinsLabel.Size = New Point(48, 37)
        ReachLabel.Size = New Point(93, 37)
        AutoLabel.Size = New Point(99, 37)
        KnockdownsLabel.Size = New Point(100, 37)
        FailLabel.Size = New Point(53, 37)
        RunsLabel.Size = New Point(60, 39)

        MyGroupBox.BackColor = Color.Gray
        TeamLabel.BackColor = Color.White
        TotalLabel.BackColor = Color.White
        OffenseLabel.BackColor = Color.Gainsboro
        BinsLabel.BackColor = Color.Gainsboro
        AutoLabel.BackColor = Color.Gainsboro
        KnockdownsLabel.BackColor = Color.Gainsboro
        ReachLabel.BackColor = Color.Gainsboro
        FailLabel.BackColor = Color.Gainsboro
        RunsLabel.BackColor = Color.White

        TeamLabel.ForeColor = Color.Black
        TotalLabel.ForeColor = Color.Black
        OffenseLabel.ForeColor = Color.Black
        AutoLabel.ForeColor = Color.Black
        KnockdownsLabel.ForeColor = Color.Black
        ReachLabel.ForeColor = Color.Black
        FailLabel.ForeColor = Color.Black
        BinsLabel.ForeColor = Color.Black
        RunsLabel.ForeColor = Color.Black

        TeamLabel.BorderStyle = BorderStyle.FixedSingle
        TeamLabel.TextAlign = ContentAlignment.MiddleRight

        Dim MyFontLarge As Font = New Font("Microsoft Sans Serif", 26.25)
        Dim MyFontMed As Font = New Font("Microsoft Sans Serif", 22)
        Dim MyFontSmall As Font = New Font("Microsoft Sans Serif", 18)

        MyGroupBox.Font = New Font("Microsoft Sans Serif", 0.001)
        TeamLabel.Font = MyFontLarge
        TotalLabel.Font = MyFontMed
        OffenseLabel.Font = MyFontMed
        BinsLabel.Font = MyFontSmall
        AutoLabel.Font = MyFontMed
        KnockdownsLabel.Font = MyFontMed
        ReachLabel.Font = MyFontSmall
        FailLabel.Font = MyFontMed
        RunsLabel.Font = MyFontMed

        MyGroupBox.ContextMenuStrip = ScoreOverview.TotalsContextMenuStrip

        ScoreOverview.SplitContainer2.Panel2.Controls.Add(MyGroupBox)

    End Sub

    Sub SetBoxY(ByVal y As Integer)
        ' Set where the box (row) is placed vertically (for resorting)
        MyGroupBox.Top = y
    End Sub

    Sub SetAll(row As TeamTotalsTable)
        TeamLabel.Text = Convert.ToString(row.Team)
        MyGroupBox.Text = TeamLabel.Text ' for we can get the values when we right-click the groupbox
        runs = Math.Max(row.Runs, 1) ' No dividing by 0!
        RunsLabel.Text = Convert.ToString(runs)

        teamName = row.TeamName
        comments = row.OtherComments

        autoToteScore = row.AutoToteTotal
        autoContainerCount = row.AutoTotalContainers
        autoMobilityCount = row.AutoMobilityTotal
        toteScoreCount = row.ToteScoreCountTotal
        binsStackedCount = row.BinsStackedTotal
        knockdownCount = row.KnockdownTotal
        toteReachHeight = row.ToteReachHeight
        binReachHeight = row.BinReachHeight
        failCount = row.FailTotal

        RefreshTotals()
    End Sub

    Sub RefreshTotals()
        Dim totesTotal As Decimal = (toteScoreCount * GlobalVariables.ToteWeight) / runs
        Dim binsTotal As Decimal = (binsStackedCount * GlobalVariables.StackedBinMultiplier) / runs

        Dim autoTotal As Decimal = (autoToteScore + autoBinCount * GlobalVariables.AutoBinWeight) / runs

        Dim knockdownsTotal As Decimal = knockdownCount * GlobalVariables.KnockdownWeight / runs

        Dim landfillTotal As Decimal = landfillScoreCount * GlobalVariables.LandfillLitterWeight / runs

        Dim recycledTotal As Decimal = recycledScoreCount * GlobalVariables.RecycledLitterWeight / runs

        Dim offenseTotal As Decimal = totesTotal + binsTotal + landfillTotal + recycledTotal

        Dim failTotal As Decimal = failCount * GlobalVariables.FailWeight / runs
        Dim reachTotal As Int16 = 0

        'reachTotal is half toteReachHeight and half binReachHeight'
        reachTotal = (toteReachHeight * GlobalVariables.ToteReachHeightWeight / 2) + (binReachHeight * GlobalVariables.BinReachHeightWeight / 2)


        TotalLabel.Text = Convert.ToString(offenseTotal + autoTotal + knockdownsTotal + failTotal + reachTotal)
        OffenseLabel.Text = Convert.ToString(offenseTotal)
        BinsLabel.Text = Convert.ToString(binsTotal)
        AutoLabel.Text = Convert.ToString(autoTotal)
        KnockdownsLabel.Text = Convert.ToString(knockdownsTotal)
        ReachLabel.Text = Convert.ToString(reachTotal)
        FailLabel.Text = Convert.ToString(failCount)
    End Sub

    Sub SetTeam(ByVal TeamInteger As Integer)

        TeamLabel.Text = Convert.ToString(TeamInteger)

    End Sub

    Function GetValue(analysisClassIndex As Int16)
        ' Return the item that goes with the given sort index
        Select Case analysisClassIndex
            Case SortByTeam
                Return GetTeam()
            Case SortByOverall
                Return GetOverall()
            Case SortByOffense
                Return GetTele()
            Case SortByKnockdowns
                Return GetKnockdowns()
            Case SortByAuto
                Return GetAuto()
            Case SortByFails
                Return GetFail()
            Case SortByRuns
                Return GetRuns()
            Case SortByReach
                Return GetReach()
            Case Else
                Return Nothing

        End Select

    End Function

    Function GetTeam() As Int16

        Return Convert.ToInt16(TeamLabel.Text)

    End Function

    Function GetOverall() As Decimal

        Return Convert.ToDecimal(TotalLabel.Text)

    End Function

    Function GetTele() As Decimal

        Return Convert.ToDecimal(OffenseLabel.Text)

    End Function

    Function GetBins() As Decimal

        Return Convert.ToDecimal(BinsLabel.Text)

    End Function

    Function GetAuto() As Decimal

        Return Convert.ToDecimal(AutoLabel.Text)

    End Function

    Function GetKnockdowns() As Decimal

        Return Convert.ToDecimal(KnockdownsLabel.Text)

    End Function

    Function GetReach() As Decimal

        Return Convert.ToDecimal(ReachLabel.Text)

    End Function

    Function GetFail() As Decimal

        Return Convert.ToDecimal(FailLabel.Text)

    End Function

    Function GetRuns() As Int16

        Return runs

    End Function

    'Function GetLandfilled() As Int16

    '    Return landfillScoreCount

    'End Function

    'Function GetRecycled() As Int16

    '    Return recycledScoreCount

    'End Function


    'Function GetSpeedString() As String

    '   Select Case speedType
    '      Case 1
    '         Return "Slow"
    '      Case 2
    '         Return "Med "
    '      Case 3
    '         Return "Fast"
    '      Case Else
    '         Return "---"
    '   End Select

    'End Function

    Public Sub Kill()
        ScoreOverview.Controls.Remove(MyGroupBox)
        MyGroupBox.Dispose()
    End Sub
End Class
