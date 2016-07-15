Public Class Form1
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        '產生數字範圍EMAIL
        Dim Start As Integer = Val(TextBox1.Text)
        Dim Final As Integer = Val(TextBox4.Text)
        Dim Times1 As Integer = 0
        If Start < 10000000 Or Final < 10000000 Then
            MsgBox("輸入的值有誤")
            Exit Sub
        End If
        For i = Start To Final
            Times1 += 1
            TextBox2.Text &= i & "@antu.edu.tw;"
            If Times1 Mod 3 = 0 Then TextBox2.Text &= vbCrLf
        Next

        '產生額外EMAIL
        Dim Total As String = TextBox3.Text
        Dim Email As String = ""
        Dim times2 As Integer = 0
        For i = 1 To Total.Length
            If Strings.Mid(Total, i, 1) = "," Or Strings.Mid(Total, i, 1) = " " Then
                Continue For
            End If
            times2 += 1
            Email &= Strings.Mid(Total, i, 1)
            If times2 = 8 Then
                If Email.Length <> 8 Then
                    MsgBox("輸入的值有誤")
                    Exit Sub
                End If
                TextBox2.Text &= Email & "@antu.edu.tw;"
                Email = ""
                times2 = 0
            End If
        Next
        TextBox2.Text = Strings.Mid(TextBox2.Text, 1, TextBox2.TextLength - 1)
    End Sub

    '以下為限制使用者只能輸入數字與空格 逗號 刪除
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        End If
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8) Or e.KeyChar = Chr(32) Or e.KeyChar = "," Then
            e.Handled = False
        End If
    End Sub
End Class
