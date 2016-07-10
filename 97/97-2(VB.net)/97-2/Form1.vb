Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tmp As String = Strings.Replace(InputBox.Text, "-", "")
        If Len(tmp) <> 9 Then
            ISBN10.Text = "輸入錯誤"
            ISBN13.Text = "輸入錯誤"
            Exit Sub
        End If
        For i As Integer = 1 To 9
            If IsNumeric(Mid(tmp, i, 1)) <> True Then
                ISBN10.Text = "輸入錯誤"
                ISBN13.Text = "輸入錯誤"
                Exit Sub
            End If
        Next
        ISBN10.Text = ToISBN10(tmp)
        ISBN13.Text = ToISBN13(tmp)
    End Sub

    Private Function Check(ByVal _s As String) As Boolean
        Dim strs() = {"157", "204", "421", "442", "7198", "7323", "8573"}
        For i = 0 To strs.Length - 1
            If _s = strs(i) Then Return True
        Next
        Return False
    End Function

    Private Function CheckPublish(ByVal _isbn As String) As String
        If Check(Mid(_isbn, 4, 4)) = True Then
            Return Mid(_isbn, 1, 3) & "-" & Mid(_isbn, 4, 4) & "-" & Mid(_isbn, 8, 2) & "-"
        Else
            Return Mid(_isbn, 1, 3) & "-" & Mid(_isbn, 4, 3) & "-" & Mid(_isbn, 7, 3) & "-"
        End If
    End Function

    Private Function ToISBN10(ByVal _isbn As String) As String
        Dim num(9) As Integer
        Dim answer As String = CheckPublish(_isbn)

        For i As Integer = 1 To 9
            num(i) = Convert.ToInt16(Mid(_isbn, i, 1))
        Next
        Dim sum As Long
        For i As Integer = 1 To 9
            sum += num(i) * (11 - i)
        Next
        sum = sum Mod 11
        sum = 11 - sum
        If sum = 10 Then
            Return answer & "x"
        ElseIf sum = 11 Then
            Return answer & "0"
        Else
            Return answer & Convert.ToString(sum)
        End If
    End Function
    Private Function ToISBN13(ByVal _isbn As String) As String
        Dim num(9) As Integer
        Dim answer As String = CheckPublish(_isbn)

        For i As Integer = 1 To 9
            num(i) = Convert.ToInt32(Mid(_isbn, i, 1))
        Next
        Dim sum As Integer = 38
        For i As Integer = 1 To 9
            If i Mod 2 = 0 Then
                sum += num(i)
            Else
                sum += num(i) * 3
            End If
        Next
        sum = sum Mod 10
        If sum = 0 Then
            Return "978-" & answer & "0"
        Else
            Return "978-" & answer & Convert.ToString(10 - sum)
        End If
    End Function
End Class
