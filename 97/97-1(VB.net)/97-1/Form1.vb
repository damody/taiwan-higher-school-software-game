Public Class Form1

    Private Sub replot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles replot.Click
        '建立新的點陣圖
        Dim Pict1 As New Bitmap(graphs.Width, graphs.Height)
        Dim g As Graphics = Graphics.FromImage(Pict1)
        '開始做畫
        Dim min, max As Single
        Dim sMax As String = tbMax.Text
        Dim sMin As String = tbMin.Text
        max = Val(sMax)
        min = Val(sMin)
        If min >= max Or min < -30 Or max > 30 Then
            inputError()
            Exit Sub
        End If
        tbMax.Text = max
        tbMin.Text = min

        Dim myPen As Pen = New Pen(Color.Black)
        g.Clear(Color.White) '清成白色

        '由pictureBox的長寬定義出放大變數
        Dim rateW As Single = graphs.Width / Math.Abs(min - max)
        Dim rateH As Single = graphs.Height / 2.2F
        Dim sw2 As Single = graphs.Width * Math.Abs(min) / Math.Abs(min - max)
        Dim sh2 As Single = graphs.Height / 2.0F
        If min > 0 And max > 0 Then sw2 *= -1

        g.DrawLine(myPen, 0.0F, sh2, graphs.Width, sh2)
        g.DrawLine(myPen, sw2, 0.0F, sw2, sh2 * 2)
        myPen = New Pen(Color.Red)
        Dim xx As Single = min
        For x As Single = min To max Step 0.1F

            Dim yy As Single = Math.Sin(xx) / xx
            Dim y As Single = Math.Sin(x) / x
            If x = 0 Or xx = 0 Then
                yy = 1
                y = 1
            End If
            g.DrawLine(myPen, xx * rateW + sw2, -yy * rateH + sh2, x * rateW + sw2, -y * rateH + sh2)
            xx = x
        Next
        '把畫好的點陣圖傳給 graphs(PictureBox)
        graphs.Image = Pict1
    End Sub
    Sub inputError()
        tbMin.Text = "輸入錯誤"
        tbMax.Text = "輸入錯誤"
    End Sub

End Class
