Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim s As String = InputBox.Text
        Dim StrAry(100) As String
        Dim TotalAry(100) As Integer
        Dim MaxChar As Integer = 0
        Dim isHave As Boolean
        For i = 1 To InputBox.Text.Length
            isHave = False
            For j = 1 To MaxChar
                If StrAry(j) = Mid(InputBox.Text, i, 1) Then
                    isHave = True
                    TotalAry(j) += 1
                    Exit For
                End If
            Next
            If isHave = False Then
                MaxChar += 1
                StrAry(MaxChar) = Mid(InputBox.Text, i, 1)
                TotalAry(MaxChar) = 1
            End If
        Next
        For i = 1 To MaxChar
            For j = 1 To MaxChar - i
                If TotalAry(j) < TotalAry(j + 1) Then
                    Dim tmp As Integer = TotalAry(j)
                    TotalAry(j) = TotalAry(j + 1)
                    TotalAry(j + 1) = tmp
                    Dim tmpp As String = StrAry(j)
                    StrAry(j) = StrAry(j + 1)
                    StrAry(j + 1) = tmpp
                End If
            Next
        Next
        OutputBox.Text = ""
        For i = 1 To MaxChar
            OutputBox.Text += """" & StrAry(i) & """" & "=" & Str(TotalAry(i)) & "; "
        Next

    End Sub
End Class
