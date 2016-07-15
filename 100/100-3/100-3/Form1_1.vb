Public Class Form1

    Dim min As Integer = 1
    Dim sec As Integer = 0
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Start()
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        min = 1
        sec = 0
        Timer1.Start()
    End Sub
    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox3.Text = vbNullString Or TextBox4.Text = vbNullString Or IsNumeric(TextBox3.Text) = False Or IsNumeric(TextBox4.Text) = False Or Val(TextBox3.Text) < 0 Or Val(TextBox4.Text) < 0 Or Val(TextBox4.Text) > 60 Then
            MsgBox("input error")
        End If
        min = Val(TextBox3.Text)
        sec = Val(TextBox4.Text)
    End Sub
    Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Timer1.Stop()
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Interval = 1000
        Timer1.Stop()
        TextBox1.ForeColor = Color.Red
        TextBox2.ForeColor = Color.Red
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If sec <= 0 Then
            min -= 1
            sec += 60
        Else
            sec -= 1
        End If
        TextBox1.Text = min.ToString
        TextBox2.Text = sec.ToString
        If min = 0 And sec = 0 Then
            Timer1.Stop()
            MsgBox("時間到!!")
        End If
    End Sub
End Class
