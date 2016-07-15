Public Class Form1
    Dim Min As Integer = 2
    Dim Sec As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Sec = 0 Then
            Sec = 60
            Min -= 1
        End If
        Sec -= 1
        Label1.Text = Min
        Label2.Text = Sec
        If Min = 0 And Sec = 0 Then
            Timer1.Enabled = False
            Label1.Text = "0"
            Label2.Text = "0"
            MsgBox("時間到了!!")
        End If
    End Sub
End Class
