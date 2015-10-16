Public Class Settings

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadWeights()
        RefreshFormulas()
    End Sub

    Private Sub LoadWeights()
        AutoTotes1Numeric.Value = GlobalVariables.AutoTote1Weight
        AutoTotes2Numeric.Value = GlobalVariables.AutoTote2Weight
        AutoTotes3Numeric.Value = GlobalVariables.AutoTote3Weight
        AutoBinsNumeric.Value = GlobalVariables.AutoBinWeight
        MobilityNumeric.Value = GlobalVariables.AutoMobilityWeight
        BinNumeric.Value = GlobalVariables.StackedBinMultiplier
        ToteNumeric.Value = GlobalVariables.ToteWeight
        LandfillNumeric.Value = GlobalVariables.LandfillLitterWeight
        RecycledNumeric.Value = GlobalVariables.RecycledLitterWeight
        KnockdownNumeric.Value = GlobalVariables.KnockdownWeight
        FailsNumeric.Value = GlobalVariables.FailWeight

    End Sub

    Private Sub SaveWeights()
        GlobalVariables.AutoTote1Weight = AutoTotes1Numeric.Value
        GlobalVariables.AutoTote2Weight = AutoTotes2Numeric.Value
        GlobalVariables.AutoTote3Weight = AutoTotes3Numeric.Value
        GlobalVariables.AutoBinWeight = AutoBinsNumeric.Value
        GlobalVariables.AutoMobilityWeight = MobilityNumeric.Value
        GlobalVariables.ToteWeight = ToteNumeric.Value
        GlobalVariables.StackedBinMultiplier = BinNumeric.Value
        GlobalVariables.KnockdownWeight = KnockdownNumeric.Value
        GlobalVariables.LandfillLitterWeight = LandfillNumeric.Value
        GlobalVariables.RecycledLitterWeight = RecycledNumeric.Value
        GlobalVariables.FailWeight = FailsNumeric.Value

        ' Refresh the rows on the analysis page
        ScoreOverview.RefreshRows()
    End Sub

    Private Sub RefreshFormulas()
        OffenseFormulaLabel.Text = "(#AutoLow)*" & Convert.ToString(AutoTotes1Numeric.Value) _
                                 & " + (#AutoHigh)*" & Convert.ToString(AutoBinsNumeric.Value) _
                                 & " + (#Mobility)*" & Convert.ToString(MobilityNumeric.Value) & Environment.NewLine _
                                 & " + (#High)*" & Convert.ToString(ToteNumeric.Value) _
                                 & " + (#Low)*" & Convert.ToString(BinNumeric.Value) _
                                 & " + (#Truss)*" & Convert.ToString(LandfillNumeric.Value) _
                                 & " + (#Caught)*" & Convert.ToString(RecycledNumeric.Value) _
                                 & " + (#Knockdowns)*" & Convert.ToString(KnockdownNumeric.Value)

        TotalFormulaLabel.Text = "(Offense Score) + (Defense Score) + (Assists Score) + (#Fails)*" _
                     & Convert.ToString(FailsNumeric.Value)

    End Sub

    Private Sub AutoTotesNumeric_ValueChanged(sender As Object, e As EventArgs) Handles AutoTotes1Numeric.ValueChanged
        RefreshFormulas()
    End Sub

    Private Sub AutoBinsNumeric_ValueChanged(sender As Object, e As EventArgs) Handles AutoBinsNumeric.ValueChanged
        RefreshFormulas()
    End Sub

    Private Sub MobilityNumeric_ValueChanged(sender As Object, e As EventArgs) Handles MobilityNumeric.ValueChanged
        RefreshFormulas()
    End Sub

    Private Sub ToteNumeric_ValueChanged(sender As Object, e As EventArgs) Handles ToteNumeric.ValueChanged
        RefreshFormulas()
    End Sub

    Private Sub BinNumeric_ValueChanged(sender As Object, e As EventArgs) Handles BinNumeric.ValueChanged
        RefreshFormulas()
    End Sub

    Private Sub LandfillNumeric_ValueChanged(sender As Object, e As EventArgs) Handles LandfillNumeric.ValueChanged
        RefreshFormulas()
    End Sub

    Private Sub RecycledNumeric_ValueChanged(sender As Object, e As EventArgs) Handles RecycledNumeric.ValueChanged
        RefreshFormulas()
    End Sub

    Private Sub KnockdownNumeric_ValueChanged(sender As Object, e As EventArgs) Handles KnockdownNumeric.ValueChanged
        RefreshFormulas()
    End Sub

    Private Sub FailsNumeric_ValueChanged(sender As Object, e As EventArgs) Handles FailsNumeric.ValueChanged
        RefreshFormulas()
    End Sub

    Private Sub Settings_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

        SaveWeights()
        Me.Close()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        ' Same as hitting the exit button
        SaveWeights()
        Me.Close()
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        AutoTotes1Numeric.Value = 15.0
        AutoBinsNumeric.Value = 8.0 / 3.0
        MobilityNumeric.Value = 4.0 / 3.0
        BinNumeric.Value = 4.0
        ToteNumeric.Value = 2.0
        LandfillNumeric.Value = 1.0
        RecycledNumeric.Value = 6.0
        KnockdownNumeric.Value = -2.0
        FailsNumeric.Value = 0.0

        RefreshFormulas()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub
End Class