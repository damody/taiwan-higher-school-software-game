Public Class Form1
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Rand()
    End Sub
    Dim a As Integer
    Sub Rand()
        Randomize()
        a = Int(Rnd() * 2 + 1)
        TextBox1.Text = a & Int(Rnd() * 9 + 1)
        TextBox2.Text = a & Int(Rnd() * 9 + 1)
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Val(TextBox3.Text) = Val(TextBox1.Text) * Val(TextBox2.Text) Then
            Label5.Text = ""
            Label6.Text = "Very Good!"
        Else
            Label5.Text = "is wrong"
            Label6.Text = "(1) " & TextBox1.Text & "+" & Strings.Right(TextBox2.Text, 1) & "=" & (Val(TextBox1.Text) + Val(Strings.Right(TextBox2.Text, 1))) & vbCrLf
            Label6.Text &= "(2) " & (Val(TextBox1.Text) + Val(Strings.Right(TextBox2.Text, 1))) & "X" & a & "0=" & (Val(TextBox1.Text) + Val(Strings.Right(TextBox2.Text, 1))) * 10 * a & vbCrLf
            Label6.Text &= "(3) " & Val(Strings.Right(TextBox1.Text, 1)) & "X" & Val(Strings.Right(TextBox2.Text, 1)) & "=" & Val(Strings.Right(TextBox1.Text, 1)) * Val(Strings.Right(TextBox2.Text, 1)) & vbCrLf
            Label6.Text &= "(4) " & (Val(TextBox1.Text) + Val(Strings.Right(TextBox2.Text, 1))) * 10 * a & "+" & Val(Strings.Right(TextBox1.Text, 1)) * Val(Strings.Right(TextBox2.Text, 1)) & "=" & ((Val(TextBox1.Text) + Val(Strings.Right(TextBox2.Text, 1))) * 10 + Val(Strings.Right(TextBox1.Text, 1)) * Val(Strings.Right(TextBox2.Text, 1)))
        End If
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Label5.Text = ""
        Label6.Text = ""
        Rand()
    End Sub
End Class
