Module Module1
    Sub Main()
        Dim Input As Integer = Val(Console.ReadLine)
        For i = 1 To Input + 1
            Dim Output As String = "1"
            If i = 1 Then
                Console.WriteLine("1")
            Else
                Dim a As Integer = i
                Do
                    F(i, Output)
                    If i = 1 Then Exit Do
                Loop
                Console.WriteLine(Output)
                i = a
            End If
        Next
        Main()
    End Sub
    Sub F(ByRef Input As Integer, ByRef Output As String)
        Dim a As String = Mid(Output, 1, 1)
        Dim count As Integer = 0
        Dim NewOutput As String = ""
        For i = 1 To Output.Length
            If Mid(Output, i, 1) = a Then
                count += 1
            Else
                NewOutput &= count & a
                a = Mid(Output, i, 1)
            End If
            If i = Output.Length Then NewOutput &= count & a
        Next
        Output = NewOutput
        Input -= 1
    End Sub
End Module