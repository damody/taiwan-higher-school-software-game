Public Class Form1
    '優先權2的運算
    Private Sub Eval2(ByRef input As String, ByRef ouput As String)
        If Mid(input, 1, 1) = "(" Then
            input = Strings.Right(input, input.Length - 1)
            Eval0(input, ouput)
            If Mid(input, 1, 1) = ")" Then
                input = Strings.Right(input, input.Length - 1)
            End If
        Else
            ouput += Str(Val(input)) & " "
            input = Strings.Right(input, input.Length - Str(Val(input)).Length + 1)
        End If
    End Sub
    '優先權1的運算
    Private Sub Eval1(ByRef input As String, ByRef ouput As String)
        Eval2(input, ouput)
        While Mid(input, 1, 1) = "*" Or Mid(input, 1, 1) = "/"
            If Mid(input, 1, 1) = "*" Then
                input = Strings.Right(input, input.Length - 1)
                Eval2(input, ouput)
                ouput += "* "
            ElseIf Mid(input, 1, 1) = "/" Then
                input = Strings.Right(input, input.Length - 1)
                Eval2(input, ouput)
                ouput += "/ "
            End If
        End While
    End Sub
    '優先權0的運算
    Private Sub Eval0(ByRef input As String, ByRef ouput As String)
        Eval1(input, ouput)
        While Mid(input, 1, 1) = "+" Or Mid(input, 1, 1) = "-"
            If Mid(input, 1, 1) = "+" Then
                input = Strings.Right(input, input.Length - 1)
                Eval1(input, ouput)
                ouput += "+ "
            ElseIf Mid(input, 1, 1) = "-" Then
                input = Strings.Right(input, input.Length - 1)
                Eval1(input, ouput)
                ouput += "- "
            End If
        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strTmp As String = InputBox.Text.Replace(" ", "")
        If strTmp.Length < 3 Then
            OutputBox.Text = "輸入錯誤"
            Exit Sub
        End If
        OutputBox.Text = ""
        Eval0(strTmp, OutputBox.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class
