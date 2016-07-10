Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim A, B, C As Double
        A = Val(TxtA.Text)
        B = Val(TxtB.Text)
        C = Val(TxtC.Text)
        If A = 0 And B = 0 And C <> 0 Then
            UpBox.Text = "無解"
        ElseIf A = 0 And B = 0 And C = 0 Then
            UpBox.Text = "無限多解"
        ElseIf A = 0 And B <> 0 Then
            UpBox.Text = -C / B
            DownBox.Text = "只有一解"
        Else
            Dim D As Double = B ^ 2 - 4 * A * C
            If D = 0 Then
                UpBox.Text = -B / (2 * A)
                DownBox.Text = "同根"
            ElseIf D > 0 Then
                D = Math.Sqrt(D)
                UpBox.Text = (-B + D) / (2 * A)
                DownBox.Text = (-B - D) / (2 * A)
            ElseIf D < 0 Then
                D = Math.Sqrt(4 * A * C - B ^ 2)
                UpBox.Text = Format(-B / (2 * A), "0.00") & "+" & Format(D / (2 * A), "0.00") & "i"
                DownBox.Text = Format(-B / (2 * A), "0.00") & Format(-D / (2 * A), "0.00") & "i"
            End If
        End If
    End Sub
End Class
