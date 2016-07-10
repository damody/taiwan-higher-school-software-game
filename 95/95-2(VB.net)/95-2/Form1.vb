Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim N As Integer = InputBox.Text.Length
        Dim K As Integer = 1
        While True
            If 2 ^ K >= N + K + 1 Then
                Exit While
            End If
            K += 1
        End While
        Dim XorNum As Integer = 0
        Dim OnFirst As Boolean = True
        Dim Outputs As String = InputBox.Text
        For i = 1 To K
            If i <= 2 Then
                Outputs += "A"
            Else
                Insert(Outputs, 2 ^ (i - 1) - 1, "A")
            End If
        Next
        N = Outputs.Length
        For i = 1 To N
            If Mid(Outputs, i, 1) = "1" Then
                If OnFirst = True Then
                    OnFirst = False
                    XorNum = N - i + 1
                Else
                    XorNum = XorNum Xor (N - i + 1)
                End If
            End If
        Next
        Dim Humming As String = ToBinary(XorNum, K)
        Outputs = InputBox.Text
        For i = 1 To K
            Insert(Outputs, 2 ^ (i - 1) - 1, Mid(Humming, Humming.Length - i + 1, 1))
        Next
        OutputBox.Text = Outputs
    End Sub

    Private Sub Insert(ByRef s As String, ByVal a As Integer, ByVal ins As String)
        If a = 0 Then
            s += ins
            Exit Sub
        End If
        Dim s1 As String = Mid(s, 1, s.Length - a)
        Dim s2 As String = Mid(s, s.Length - a + 1)
        s = s1 & ins & s2
    End Sub

    Private Function ToBinary(ByVal a As Integer, ByVal lens As Integer)
        ToBinary = ""
        While a > 0
            If a Mod 2 = 0 Then
                ToBinary = "0" & ToBinary
            Else
                ToBinary = "1" & ToBinary
            End If
            a \= 2
        End While
        While Len(ToBinary) < lens
            ToBinary = "0" & ToBinary
        End While
    End Function
End Class
