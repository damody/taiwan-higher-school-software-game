Public Class Form1
    Dim ErrorTotal As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim InNumber As Integer = Val(InputBox.Text)
        OutputBox.Text = ""
        Label2.Text = ""
        If InputBox.Text = "***" Then
            ErrorTotal = 0
            InputBox.ForeColor = Color.Black
            InputBox.Text = ""
        ElseIf ErrorTotal > 3 Then
            InputBox.ForeColor = Color.Red
            InputBox.Text = " ???"
            Label2.Text = "輸入錯誤超過3次"
        ElseIf InNumber < 1 Or InNumber > 10 Then
            Label2.Text = "輸入錯誤"
            ErrorTotal += 1
            If ErrorTotal > 3 Then
                Button1.PerformClick 
            End If
        Else
            For i = 1 To InNumber
                OutputBox.Text += Strings.StrDup(InNumber - i, " ")
                OutputBox.Text += Str(InNumber - i + 1)
                For j = 2 To i
                    OutputBox.Text += " 1"
                Next
                OutputBox.Text += vbCrLf
            Next
        End If
    End Sub
End Class
