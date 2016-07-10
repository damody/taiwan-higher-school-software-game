Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DataAry() As String = InputBox.Text.Split(Chr(10))
        Dim StrTmp(), StrTmp2() As String
        OutputBox.Text = ""
        For i = 0 To UBound(DataAry)
            StrTmp = DataAry(i).Split(" ")
            StrTmp2 = StrTmp(1).Split("/")
            OutputBox.Text += Format(Val(StrTmp(0)) * Val(StrTmp2(0)) / Val(StrTmp2(1)) / Val(StrTmp(2)), "0") & vbCrLf
        Next
    End Sub
End Class
