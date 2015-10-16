Public Class ToteImageInputManager
    Private highlightImage As Image
    Private greyedImage As Image
    Public Sub New(ByRef image As Image, ByRef greyimage As Image)
        highlightImage = image
        greyedImage = greyimage
    End Sub
    Private textBoxImageList As List(Of PictureBox) = New List(Of PictureBox)
    Public Sub addImage(ByRef Pbox As PictureBox)
        textBoxImageList.Add(Pbox)
    End Sub

    Public Sub highlightToteValue(par1int As Int16)
        For i As Int16 = 0 To textBoxImageList.Count - 1
            If i < par1int Then
                textBoxImageList(i).Image() = highlightImage
            Else
                textBoxImageList(i).Image() = greyedImage
            End If
        Next
    End Sub
End Class