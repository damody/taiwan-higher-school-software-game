Public Class Form1
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        End
    End Sub

    Private Sub BtnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConvert.Click
        Dim Num As Double = Val(InputBox.Text)
        If Math.Abs(Num) >= 65536 Then
            OutputBox.Text = "overflow"
            Exit Sub
        End If
        Dim sOut As String = "0"
        If Num < 0 Then sOut = "1"
        Num = Math.Abs(Num)
        sOut += ToBin(Fix(Num)) & "." & DotToBin(Num - Fix(Num))
        OutputBox.Text = sOut
    End Sub
    Function ToBin(ByVal _Num As Long) As String
        Dim sTmp As String = ""
        While _Num > 0
            sTmp = Convert.ToString(_Num Mod 2) & sTmp
            _Num \= 2
        End While
        While Len(sTmp) < 15
            sTmp = "0" & sTmp
        End While
        If Len(sTmp) > 15 Then
            sTmp = sTmp.Substring(1, 15)
        End If
        Return sTmp
    End Function
    Function DotToBin(ByVal _Num As Double) As String
        Dim sTmp As String = ""
        Dim i As Double = 0.5
        While _Num > 0
            If _Num >= i Then
                _Num -= i
                sTmp += "1"
            Else
                sTmp += "0"
            End If
            i /= 2
        End While
        While Len(sTmp) < 8
            sTmp += "0"
        End While
        If Len(sTmp) > 8 Then
            sTmp = sTmp.Substring(1, 8)
        End If
        Return sTmp
    End Function
End Class
