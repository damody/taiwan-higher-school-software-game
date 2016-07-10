Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim StrAry() As String = InputBox.Text.Split(" ")
        Dim Data1 As Integer = Val(StrAry(0))
        Dim Data2 As Integer = Val(StrAry(1))
        Dim Answer As Integer = 0
        If WaterLevel(Data1) + ElectricLevel(Data2) = 2 Then
            Answer = (Data1 + Data2) * 5 * 0.6 / 2
        ElseIf WaterLevel(Data1) + ElectricLevel(Data2) = 3 Then
            Answer = (Data1 + Data2) * 5 * 0.8 / 2
        ElseIf WaterLevel(Data1) + ElectricLevel(Data2) = 6 Then
            Answer = (Data1 + Data2) * 5 * 1.4 / 2
        ElseIf WaterLevel(Data1) + ElectricLevel(Data2) = 5 Then
            Answer = (Data1 + Data2) * 5 * 1.2 / 2
        Else
            Answer = (Data1 + Data2) * 5 / 2
        End If
        OutputBox.Text = Str(Answer)
    End Sub
    Private Function WaterLevel(ByVal a As Integer) As Integer
        Select Case a
            Case Is < 50
                Return 1
            Case Is <= 100
                Return 2
            Case Else
                Return 3
        End Select
    End Function
    Private Function ElectricLevel(ByVal a As Integer) As Integer
        Select Case a
            Case Is < 100
                Return 1
            Case Is <= 200
                Return 2
            Case Else
                Return 3
        End Select
    End Function
End Class
