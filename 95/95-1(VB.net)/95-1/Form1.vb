Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim input As Long = Val(InputBox.Text)
        Dim Max As Integer = 0
        For i = 2 To input
            If IsPrime(i) Then
                Max += 1
            End If
        Next
        OutputBox1.Text = "質數個數有 " & Str(Max) & "  個"
        Dim prime(3), Num As Long
        Num = 0
        OutputBox2.Text = ""
        For i = input To 2 Step -1
            If IsPrime(i) Then
                Num += 1
                OutputBox2.Text = Str(i) & OutputBox2.Text
                If Num = 3 Then
                    Exit For
                End If
            End If
        Next
        OutputBox2.Text = "最大的3個質數是 " & OutputBox2.Text

    End Sub
    Private Function IsPrime(ByVal n As Long) As Boolean
        If n = 2 Or n = 3 Then Return True
        Dim sqrtn = Math.Sqrt(n)
        For i = 2 To sqrtn
            If n Mod i = 0 Then Return False
        Next
        Return True
    End Function

End Class
