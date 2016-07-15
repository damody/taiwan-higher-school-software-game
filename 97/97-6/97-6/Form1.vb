Public Class Form1
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        TextBox1.Text &= "0"
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        TextBox1.Text = ""
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TextBox1.Text &= "1"
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TextBox1.Text &= "2"
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        TextBox1.Text &= "3"
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Text &= "4"
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text &= "5"
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox1.Text &= "6"
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text &= "7"
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text &= "8"
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Text &= "9"
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        For i = 1 To TextBox1.Text.Length
            If Mid(TextBox1.Text, i, 1) = "." Then Exit Sub
        Next
        If Not TextBox1.Text = "" Then TextBox1.Text &= "."
    End Sub
    Dim MathWord As String
    Dim Num1 As Double
    Dim Num2 As Double
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Num1 = Val(TextBox1.Text)
        MathWord = "+"
        TextBox1.Text = ""
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Num2 = Val(TextBox1.Text)
        Select Case MathWord
            Case Is = "+"
                TextBox1.Text = num1 + Num2
            Case Is = "-"
                TextBox1.Text = Num1 - Num2
            Case Is = "*"
                TextBox1.Text = Num1 * Num2
            Case Is = "/"
                TextBox1.Text = Num1 / Num2
        End Select
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox1.Text = Math.Log10(Val(TextBox1.Text))
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Mid(TextBox1.Text, 1, 1) <> "-" Then
            TextBox1.Text = "-" & TextBox1.Text
        Else
            TextBox1.Text = Mid(TextBox1.Text, 2, TextBox1.Text.Length - 1)
        End If
    End Sub
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Num1 = Val(TextBox1.Text)
        MathWord = "*"
        TextBox1.Text = ""
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Num1 = Val(TextBox1.Text)
        MathWord = "-"
        TextBox1.Text = ""
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Num1 = Val(TextBox1.Text)
        MathWord = "/"
        TextBox1.Text = ""
    End Sub
End Class
