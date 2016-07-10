Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim g As Graphics = OutputBox.CreateGraphics()
        Dim pi As Single = 3.14
        Dim W As Single = OutputBox.Width
        Dim H As Single = OutputBox.Height
        Dim x, y, lx, ly As Single
        g.DrawLine(Pens.Black, 0, H / 2, W, H / 2)
        If RadioSin.Checked = True Then
            lx = 0
            ly = H / 2.1 + 5
            For i = 0.01 To pi * 2 Step 0.01
                x = i * W / (pi * 2)
                y = (-Math.Sin(i) + 1) * H / 2.1 + 5
                g.DrawLine(Pens.Black, lx, ly, x, y)
                lx = x
                ly = y
            Next
        Else
            lx = 0
            ly = 5
            For i = 0.01 To pi * 2 Step 0.01
                x = i * W / (pi * 2)
                y = (-Math.Cos(i) + 1) * H / 2.1 + 5
                g.DrawLine(Pens.Black, lx, ly, x, y)
                lx = x
                ly = y
            Next
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OutputBox.CreateGraphics().Clear(Color.White)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub
End Class
