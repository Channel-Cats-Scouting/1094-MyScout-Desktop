Public Class TextBoxGroup

    Dim textBoxList As List(Of TextBox) = New List(Of TextBox)
    Dim selectedIndex As Int16 = -1
    Private groupBox As GroupBox
    Private ReadOnly textBoxWidth = 16
    Private ReadOnly textBoxHeight = 26
    Private ReadOnly buffer = 6
    Private ReadOnly startX = 6
    Private ReadOnly startY = 8
    Private maxTextValue
    Private maxCount
    Private size = 0

    Public Sub New(ByRef myGroupBox As GroupBox, maxValue As Integer, maxCnt As Integer)
        groupBox = myGroupBox
        maxTextValue = maxValue
        maxCount = maxCnt

        For i As Int16 = 0 To maxCount - 1
            ' TODO: add text box with specific onclick function that points back to this group (so it changes which is highlighted)
            Dim tempTextBox As TextBox = New TextBox()
            textBoxList.Add(tempTextBox)
            groupBox.Controls.Add(tempTextBox)
            tempTextBox.Location = New Point(startX + (textBoxList.Count - 1) * (textBoxWidth + buffer), startY)
            tempTextBox.Size = New Point(textBoxWidth, textBoxHeight)

            Dim MyFont As Font = New Font("Microsoft Sans Serif", 12)
            tempTextBox.Font = MyFont
            tempTextBox.BackColor = Color.WhiteSmoke
            tempTextBox.Cursor = Cursors.Hand

            AddHandler tempTextBox.Click, AddressOf ScoreEntryForm.OnClickedTextBox
            AddHandler tempTextBox.LostFocus, AddressOf Me.TempTextBox_LostFocus
            AddHandler tempTextBox.TextChanged, AddressOf Me.TempTextBox_TextChanged

            ' We change textboxes' visibility and text instead of adding/removing them
            tempTextBox.Visible = False
        Next
    End Sub

    Public Sub Add(Optional defaultInt As Int16 = 1)
        If size < maxCount Then
            textBoxList(size).Text = defaultInt.ToString
            textBoxList(size).Visible = True
            size += 1
        End If

    End Sub
    Public Sub UpdateValue(updateIndex As Int16, newInt As Int16)

        textBoxList(updateIndex).Text = newInt.ToString

    End Sub
    Public Sub addList(list As List(Of Int16))
        For Each element As Int16 In list
            Add(element)
        Next
        Refresh()
    End Sub
    Public Sub ClearAll()
        ' Needs to loop from end to front (if actually removing boxes), since indexes shift as items before them are removed
        For i As Integer = size - 1 To 0 Step -1
            Clear(i)
        Next
    End Sub
    Public Sub Clear(clearIndex As Int16)
        If clearIndex >= 0 Then
            'ScoreEntryForm.Controls.Remove(textBoxList(clearIndex))
            'textBoxList(clearIndex).Dispose()
            'textBoxList.RemoveAt(clearIndex)

            ' Shift items above down by one
            For i As Int16 = clearIndex To size - 2
                textBoxList(i).Text = textBoxList(i + 1).Text
            Next
            textBoxList(size - 1).Visible = False
            size -= 1
            selectedIndex = -1
            Refresh()
        End If

    End Sub
    Public Sub Clear()
        If selectedIndex <> -1 Then
            Clear(selectedIndex)
        End If
    End Sub
    Public Sub SetSelectedIndex(ByRef tempBox As TextBox)
        Dim index = textBoxList.IndexOf(tempBox)
        If index <> -1 Then
            selectedIndex = index
        End If
    End Sub

    Public Sub Refresh()
        For i As Int16 = 0 To size - 1
            textBoxList.Item(i).Location = New Point(startX + (i) * (textBoxWidth + buffer), startY)
            If i = selectedIndex Then
                textBoxList.Item(i).BackColor = Color.Orange
            Else
                textBoxList.Item(i).BackColor = Color.WhiteSmoke
            End If

        Next
    End Sub

    Private Sub TempTextBox_LostFocus(sender As Object, e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        Dim limitedValue As Int16
        limitedValue = ScoreEntryForm.LimitStringValue(CType(sender, TextBox).Text, maxTextValue)
        If limitedValue <> Nothing Then
            CType(sender, TextBox).Text = limitedValue
        Else
            CType(sender, TextBox).Text = "1"
        End If
    End Sub
    Private Sub TempTextBox_TextChanged(sender As Object, e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        If (textBox.Text.Length <> 0) Then
            textBox.Text = textBox.Text.Last
        End If
        If Not textBox.Text.Equals("") Then
            If textBox.Parent.Name.StartsWith("Auto") Then
                ScoreEntryForm.autoInputMgr.highlightToteValue(Convert.ToInt16(textBox.Text()))
            Else
                ScoreEntryForm.teleInputMgr.highlightToteValue(Convert.ToInt16(textBox.Text()))
            End If
        End If
        textBox.Select(textBox.Text.Length, 0)
    End Sub

    Function getIntsList() As List(Of Int16)
        Dim returnList = New List(Of Int16)
        For i As Int16 = 0 To size - 1
            returnList.Add(Convert.ToInt16(textBoxList(i).Text))
        Next
        Return returnList
    End Function

End Class
