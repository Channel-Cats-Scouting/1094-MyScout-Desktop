

Public Class SubscoresView
    Public Sub SetSubscores(myTeam As Integer)

        ' Get the scores for this team
        Dim myConn = New dbCommunicator
        Dim myTotals = myConn.GetTeamTotalsList(GlobalVariables.EventString, myTeam).First()
        myConn.Close()

        Dim runs = Math.Max(1, myTotals.Runs)
        TeamLabel.Text = "Team " & Convert.ToString(myTotals.Team)
        RunsLabel.Text = Convert.ToString(runs)

        ' Display the average values
        AutoToteLabel.Text = Format(myTotals.AutoToteTotal / runs, "#0.00")
        AutoBinLabel.Text = Format(myTotals.AutoTotalContainers / runs, "#0.00")
        AutoMobilityLabel.Text = Format(myTotals.AutoMobilityTotal / runs, "#0.00")

        ToteLabel.Text = Format(myTotals.ToteScoreCountTotal / runs, "#0.00")
        BinLabel.Text = Format(myTotals.BinsStackedTotal / runs, "#0.00")
        KnocksLabel.Text = Format(myTotals.KnockdownTotal / runs, "#0.00")
        LandfillLabel.Text = Format(myTotals.LandfillLitterTotal / runs, "#0.00")
        RecycledLabel.Text = Format(myTotals.RecycledLitterTotal / runs, "#0.00")
        FailLabel.Text = Convert.ToString(myTotals.FailTotal)
        BinReachLabel.Text = Convert.ToString(myTotals.BinReachHeight)
        ToteReachLabel.Text = Convert.ToString(myTotals.ToteReachHeight)

        AutoCommentsTextBox.Text = myTotals.AutoComments
        OtherCommentsTextBox.Text = myTotals.OtherComments


    End Sub
    Private Sub Label11_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Label20_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub OtherCommentsTextBox_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub SubscoresView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
