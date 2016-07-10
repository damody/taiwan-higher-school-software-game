Public Class Form1
    Dim MyBitmap(5) As Bitmap

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "tif files|*.tif|png files|*.png|jpg files|*.jpg|bmp files|*.bmp"
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
            MyBitmap(1) = New Bitmap(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "tif files|*.tif|png files|*.png|jpg files|*.jpg|bmp files|*.bmp"
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            PictureBox2.ImageLocation = OpenFileDialog1.FileName
            MyBitmap(2) = New Bitmap(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MyBitmap(3) = New Bitmap(MyBitmap(1).Width, MyBitmap(1).Height)
        Dim flagGraphics As Graphics = Graphics.FromImage(MyBitmap(3))
        Dim pixelColor As Color
        Dim MyPen As Pen = New Pen(pixelColor, 1.0F)
        Dim ColorAvg As Integer
        For i = 1 To MyBitmap(1).Width - 1
            For j = 1 To MyBitmap(1).Height - 1
                pixelColor = MyBitmap(1).GetPixel(i, j)
                ColorAvg = (pixelColor.R / 3 + pixelColor.G / 3 + pixelColor.B / 3)
                pixelColor = Color.FromArgb(ColorAvg, ColorAvg, ColorAvg)
                MyPen.Color = pixelColor
                flagGraphics.DrawLine(MyPen, i - 1, j, i + 1, j)
            Next
        Next
        PictureBox3.Image = MyBitmap(3)
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MyBitmap(4) = New Bitmap(MyBitmap(2).Width, MyBitmap(2).Height)
        Dim flagGraphics As Graphics = Graphics.FromImage(MyBitmap(4))
        Dim pixelColor As Color
        Dim MyPen As Pen = New Pen(pixelColor, 1.0F)
        Dim ColorAvg As Integer
        For i = 1 To MyBitmap(2).Width - 1
            For j = 1 To MyBitmap(2).Height - 1
                pixelColor = MyBitmap(2).GetPixel(i, j)
                ColorAvg = (pixelColor.R / 3 + pixelColor.G / 3 + pixelColor.B / 3)
                pixelColor = Color.FromArgb(ColorAvg, ColorAvg, ColorAvg)
                MyPen.Color = pixelColor
                flagGraphics.DrawLine(MyPen, i - 1, j, i + 1, j)
            Next
        Next
        PictureBox4.Image = MyBitmap(4)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MyBitmap(5) = New Bitmap(MyBitmap(3).Width, MyBitmap(3).Height)
        Dim flagGraphics As Graphics = Graphics.FromImage(MyBitmap(5))
        Dim pixelColor1, pixelColor2 As Color
        Dim MyPen As Pen = New Pen(pixelColor1, 1.0F)
        For i = 1 To MyBitmap(3).Width - 1
            For j = 1 To MyBitmap(3).Height - 1
                pixelColor1 = MyBitmap(3).GetPixel(i, j)
                pixelColor2 = MyBitmap(4).GetPixel(i, j)
                If pixelColor1 <> pixelColor2 Then
                    MyPen.Color = pixelColor1
                    flagGraphics.DrawLine(MyPen, i - 1, j, i + 1, j)
                End If
            Next
        Next
        PictureBox5.Image = MyBitmap(5)
    End Sub
End Class
