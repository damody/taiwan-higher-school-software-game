Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim StrIn As String = InputBox1.Text
        Dim Key1 As Long = Val(PublicKey1.Text)
        Dim Key2 As Long = Val(PublicKey2.Text)
        Dim StrOut As String = ""
        For i = 1 To StrIn.Length
            If Asc(Mid(StrIn, i, 1)) > 0 Then
                StrOut += FormatStr(CalcBin(Asc(Mid(StrIn, i, 1)), Key1, Key2))
            Else
                StrOut += FormatStr(CalcBin(Asc(Mid(StrIn, i, 1)) + 65536, Key1, Key2))
            End If
        Next
        OutputBox1.Text = StrOut
    End Sub

    Private Function FormatStr(ByVal i As Long) As String
        Dim s As String = Str(i)
        s = s.Replace(" ", "")
        While s.Length < 5
            s = "0" & s
        End While
        Return s
    End Function

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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Key1 As Long = Val(PrivateKey1.Text)
        Dim Key2 As Long = Val(PrivateKey2.Text)
        Dim WordTotal As Integer = InputBox2.Text.Length / 5
        Dim StrOut As String = ""
        For i = 1 To WordTotal
            StrOut += Chr(CalcBin(Val(Mid(InputBox2.Text, 5 * (i - 1) + 1, 5)), Key1, Key2))
        Next
        OutputBox2.Text = StrOut
    End Sub
End Class
