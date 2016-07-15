Public Class Form1
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        End
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Randomize()
        TextBox1.Text = Rnd() * 10000
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim ReturnNumber As String = ""
        Dim Former As Integer = 0
        Dim Latter As Double = 0
        For i = 1 To TextBox1.Text.Length
            If Strings.Mid(TextBox1.Text, i, 1) = "." Then

                Former = Val(Strings.Mid(TextBox1.Text, 1, i - 1))
                Do
                    ReturnNumber &= Former Mod 2
                    Former = (Former - (Former Mod 2)) / 2
                Loop Until Former = 0
                ReturnNumber = StrReverse(ReturnNumber)

                ReturnNumber &= "."

                Latter = Val("0." & Strings.Mid(TextBox1.Text, i + 1, TextBox1.Text.Length - i))
                For j = 1 To 10
                    ReturnNumber &= Int(Latter * 2)
                    If Latter * 2 > 1 Then
                        Latter = Latter * 2 - 1
                    Else
                        Latter = Latter * 2
                    End If
                Next
            End If
        Next

        TextBox2.Text = ReturnNumber

        Dim a As Integer = ReturnNumber.Length
        For i = 1 To a
            If Strings.Mid(ReturnNumber, i, 1) = "0" Then
                ReturnNumber = Strings.Mid(ReturnNumber, i + 1, a - i)
            Else
                Exit For
            End If
        Next

        For i = 1 To a
            If Strings.Mid(ReturnNumber, a - i + 1, 1) = "0" Then
                ReturnNumber = Strings.Mid(ReturnNumber, 1, a - i)
            Else
                Exit For
            End If
        Next
        TextBox3.Text = ReturnNumber
    End Sub
End Class
