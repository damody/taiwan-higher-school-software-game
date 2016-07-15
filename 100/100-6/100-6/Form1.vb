Public Class Form1
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Randomize()
        TextBox1.Text = Int(Rnd() * 37 + 16)
        TextBox2.Text = Int(Rnd() * 8 + 1) & "B"
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim a = Val(TextBox1.Text)
        Dim Output As String = ""
        Select Case Int(a / 10)
            Case Is = 1
                a = a - 10
                a = 2 ^ a * Val(Strings.Left(TextBox2.Text, 1))
                Output = a & "KB"
            Case Is = 2
                a = a - 20
                a = 2 ^ a * Val(Strings.Left(TextBox2.Text, 1))
                Output = a & "MB"
            Case Is = 3
                a = a - 30
                a = 2 ^ a * Val(Strings.Left(TextBox2.Text, 1))
                Output = a & "GB"
            Case Is = 4
                a = a - 40
                a = 2 ^ a * Val(Strings.Left(TextBox2.Text, 1))
                Output = a & "TB"
            Case Is = 5
                a = a - 50
                a = 2 ^ a * Val(Strings.Left(TextBox2.Text, 1))
                Output = a & "TB"
        End Select
        TextBox3.Text = Output
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim A() As String = {"K", "M", "G", "T"}
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = Int(Rnd() * 8 + 1) & "B"
        TextBox6.Text = Int(Rnd() * 32256 + 512) & A(Int(Rnd() * 4)) & "B"
        If Val(TextBox6.Text) > 1023 Then
            Select Case Strings.Right(TextBox6.Text, 2)
                Case "KB"
                    TextBox6.Text = Int(Val(TextBox6.Text) / 1024 + Val(TextBox6.Text) Mod 1024) & "MB"
                Case "MB"
                    TextBox6.Text = Int(Val(TextBox6.Text) / 1024 + Val(TextBox6.Text) Mod 1024) & "GB"
                Case "GB"
                    TextBox6.Text = Int(Val(TextBox6.Text) / 1024 + Val(TextBox6.Text) Mod 1024) & "TB"
            End Select
        End If
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim AdB As Integer = 0
        Select Case Strings.Right(TextBox6.Text, 2)
            Case Is = "KB"
                AdB = 10
                AdB += xxx(Val(TextBox6.Text) / Val(TextBox5.Text))
            Case Is = "MB"
                AdB = 20
                AdB += xxx(Val(TextBox6.Text) / Val(TextBox5.Text))
            Case Is = "GB"
                AdB = 30
                AdB += xxx(Val(TextBox6.Text) / Val(TextBox5.Text))
            Case Is = "TB"
                AdB = 40
                AdB += xxx(Val(TextBox6.Text) / Val(TextBox5.Text))
        End Select
        TextBox4.Text = AdB
    End Sub
    Function xxx(ByVal x As Integer)
        For i = 1 To 100
            If 2 ^ i > x Then Return i
        Next
    End Function
End Class
