Public Class Form1
    Dim InputData As String = ""
    Dim IsStrat As Boolean = False
    Dim DataAry(8, 8) As Integer
    Const HORSE As Integer = 38
    Const NOWAY As Integer = 78
    Dim HorseX, HorseY As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OutputBox.Text = "馬目前位置與一些障礙物："
        OutputBox.SelectionStart = OutputBox.TextLength
    End Sub
    Private Sub RichTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OutputBox.GotFocus
        Me.Focus()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.D0 To Keys.D7
                InputData += Chr(e.KeyCode)
                OutputBox.Text += Chr(e.KeyCode)
                If IsStrat = True Then
                    OutputBox.Text += HandleData(Chr(e.KeyCode))
                    InputData = ""
                    OutputBox.Text += vbCrLf & "輸入移動數字鍵："
                End If
            Case Keys.Space
                InputData += " "
                OutputBox.Text += " "
            Case Keys.Enter
                Try
                    If IsStrat = False Then
                        IsStrat = True
                        Dim stmp() As String = InputData.Split(" ")
                        HorseY = Val(stmp(0))
                        HorseX = Val(stmp(1))
                        For i = 2 To UBound(stmp) Step 2
                            DataAry(Val(stmp(i)), Val(stmp(i + 1))) = NOWAY
                        Next
                        OutputBox.Text += vbCrLf & "輸入移動數字鍵："
                    End If
                Catch ex As Exception
                    IsStrat = False
                    OutputBox.Text = "馬目前位置與一些障礙物："
                End Try
                InputData = ""
            Case Keys.Back
                If InputData.Length > 0 Then
                    OutputBox.Text = Strings.Left(OutputBox.Text, OutputBox.TextLength - 1)
                    InputData = Strings.Left(InputData, InputData.Length - 1)
                End If
            Case Keys.D9
                End
        End Select
        OutputBox.SelectionStart = OutputBox.TextLength
    End Sub

    Private Function HandleData(ByVal Data As String) As String
        HandleData = vbCrLf & "馬移動到新位置："
        Select Case Data
            Case "0"
                HandleData += IsOK(2, 1, 1, 0)
            Case "1"
                HandleData += IsOK(2, -1, 1, 0)
            Case "2"
                HandleData += IsOK(1, -2, 0, -1)
            Case "3"
                HandleData += IsOK(-1, -2, 0, -1)
            Case "4"
                HandleData += IsOK(-2, -1, -1, 0)
            Case "5"
                HandleData += IsOK(-2, 1, -1, 0)
            Case "6"
                HandleData += IsOK(-1, 2, 0, 1)
            Case "7"
                HandleData += IsOK(1, 2, 0, 1)
        End Select
    End Function

    Private Function IsOK(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer) As String
        If IsIn(x, y) Then
            If DataAry(HorseY + h, HorseX + w) <> NOWAY Then '注意這題的x跟y的位置跟平常是相反的
                HorseX += x
                HorseY += y
                DataAry(HorseY, HorseX) = 0
                IsOK = Str(HorseY) & Str(HorseX)
            Else
                IsOK = Str(HorseY) & Str(HorseX) & "(因馬腳梱住而保持原座標)"
            End If
        Else
            IsOK = Str(HorseY) & Str(HorseX) & "(因超出棋盤外而保持原座標)"
        End If
    End Function

    Private Function IsIn(ByVal x As Integer, ByVal y As Integer) As Boolean
        If HorseX + x > 8 Or HorseY + y > 8 Or HorseX + x < 1 Or HorseY + y < 1 Then
            Return False
        End If
        Return True
    End Function
End Class
