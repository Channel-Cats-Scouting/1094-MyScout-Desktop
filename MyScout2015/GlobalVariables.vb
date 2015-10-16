Public Class GlobalVariables
    Public Shared EventString As String = ""            ' The current event
    Public Shared CurrentMatchInteger As Integer = 1    ' The current match
    Public Shared TotalMatchesInteger As Integer = 0    ' The # matches in this event
    Public Shared TotalTeams As Integer = 0             ' The # teams in this event
    Public Shared EventIsFavorite As Boolean = False    ' Whether this is a fav event (not really needed)

    ' How many points to give for each score
    Public Shared AutoBinWeight As Decimal = 8.0 / 3.0
    Public Shared AutoTote1Weight As Decimal = 2.0
    Public Shared AutoTote2Weight As Decimal = 6.0
    Public Shared AutoTote3Weight As Decimal = 20.0
    Public Shared AutoMobilityWeight As Decimal = 4.0 / 3.0
    Public Shared ToteWeight As Decimal = 2.0
    Public Shared KnockdownWeight As Decimal = -2.0
    Public Shared LandfillLitterWeight As Decimal = 1.0
    Public Shared RecycledLitterWeight As Decimal = 6.0
    Public Shared ToteReachHeightWeight As Decimal = 1.0
    Public Shared BinReachHeightWeight As Decimal = 1.0
    Public Shared FailWeight As Decimal = 0.0

    Public Shared StackedBinMultiplier As Decimal = 4.0

End Class
