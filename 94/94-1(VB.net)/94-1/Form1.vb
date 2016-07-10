Public Class Form1
    Dim StrAry() As String = {"a", "b", "c", "d", "f", "g", "h", "i", "j"}
    Dim DataAry(,) As Integer = New Integer(,) {{1, 9, 12, 33, 47, 53, 67, 78, 92, 0, 0, 0, 0, 0}, _
                                                {1, 48, 81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
                                                {1, 13, 41, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
                                                {1, 1, 3, 45, 79, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
                                                {1, 14, 16, 24, 44, 46, 55, 57, 64, 74, 82, 87, 98, 0}, _
                                                {1, 10, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
                                                {1, 6, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
                                                {1, 23, 39, 50, 56, 65, 68, 0, 0, 0, 0, 0, 0, 0}, _
                                                {1, 32, 70, 73, 83, 88, 93, 0, 0, 0, 0, 0, 0, 0}, _
                                                {1, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}}

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For i = 0 To 9
            DataAry(i, 0) = 1
        Next
        Dim OutString As String = ""
        For i = 1 To InputBox.Text.Length
            OutString += Encoding(Mid(InputBox.Text, i, 1)) & " "
        Next
        OutputBox.Text = OutString
    End Sub
    Private Function Encoding(ByVal data As String) As String
        Dim n As Integer = Asc(data) - 97
        Dim index As Integer = DataAry(n, 0)
        If DataAry(n, index) <> 0 Then
            DataAry(n, 0) += 1
            Encoding = Str(DataAry(n, index))
        Else
            DataAry(n, 0) = 2
            Encoding = Str(DataAry(n, 1))
        End If
        Encoding = Trim(Encoding)
        While Len(Encoding) < 2
            Encoding = "0" & Encoding
        End While
    End Function
End Class
