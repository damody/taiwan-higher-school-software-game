Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim A, B, C As Long
        A = Val(TextA.Text)
        B = Val(TextB.Text)
        C = Val(TextC.Text)
        OutputBox.Text = CalcBin(A, B, C)  '依提示解
        'OutputBox.Text = CalcMod(A, B, C) '遞迴解
    End Sub

    Private Function CalcBin(ByVal a As Long, ByVal b As Long, ByVal c As Long) As Long
        Dim StrB As String = ToBinary(b)
        Dim S As Long = 1
        For i = 1 To StrB.Length
            S = (S * S) Mod c
            If Mid(StrB, i, 1) = "1" Then
                S = (a * S) Mod c
            End If
        Next
        Return S
    End Function

    Private Function ToBinary(ByVal a As Long) As String
        ToBinary = ""
        While a > 0
            If a Mod 2 = 1 Then
                ToBinary = "1" & ToBinary
            Else
                ToBinary = "0" & ToBinary
            End If
            a \= 2
        End While
    End Function

    Private Function CalcMod(ByVal a As Long, ByVal b As Long, ByVal c As Long) As Long
        If b = 1 Then
            Return a Mod c
        Else
            If b Mod 2 = 0 Then
                Return (CalcMod(a, b \ 2, c) * CalcMod(a, b \ 2, c)) Mod c
            Else
                Return (CalcMod(a, b \ 2, c) * CalcMod(a, b \ 2, c) * a) Mod c
            End If
        End If
    End Function
End Class
