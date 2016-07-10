Public Class Form1
    Dim Tsum As Decimal = 0
    Dim Sum As Decimal = 0
    Dim isDot As Boolean = False
    Dim dotNum As Decimal = 0
    Dim Flag As String = ""
    Dim isReset As Boolean = False
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OutputBox.Text = "0"
    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        HandleNum(1)
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        HandleNum(2)
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        HandleNum(3)
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        HandleNum(4)
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        HandleNum(5)
    End Sub

    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        HandleNum(6)
    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        HandleNum(7)
    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        HandleNum(8)
    End Sub

    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        HandleNum(9)
    End Sub
    Private Sub Btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn0.Click
        If isReset Then
            BtnAC.PerformClick()
            isReset = False
        End If
        If isDot Then
            dotNum += 1
            OutputBox.Text += "0"
        Else
            Sum = Sum * 10
            OutputBox.Text = Str(Sum)
        End If
    End Sub
    Private Sub HandleNum(ByVal _num As Decimal)
        If isReset Then
            BtnAC.PerformClick()
            isReset = False
        End If
        If isDot Then
            dotNum += 1
            Sum += (10 ^ (-dotNum)) * _num
        Else
            Sum = Sum * 10 + _num
        End If
        OutputBox.Text = Str(Sum)
        If Sum < 1 And Sum > 0 Then
            OutputBox.Text = "0" & OutputBox.Text
        End If
    End Sub

    Private Sub BtnDot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDot.Click
        isDot = True
        If Sum = Math.Floor(Sum) Then
            OutputBox.Text = Str(Sum) + "."
        End If
    End Sub

    Private Sub BtnAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAC.Click
        Sum = 0
        Tsum = 0
        dotNum = 0
        isDot = False
        Flag = ""
        OutputBox.Text = "0"
    End Sub

    Private Sub BtnEqu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEqu.Click
        Select Case Flag
            Case "+"
                Sum += Tsum
            Case "-"
                Sum = Tsum - Sum
            Case "x"
                Sum *= Tsum
            Case "/"
                Sum = Tsum / Sum
        End Select
        OutputBox.Text = Str(Sum)
        isReset = True
        If Sum < 1 And Sum > 0 Then
            OutputBox.Text = "0" & OutputBox.Text
        End If
    End Sub
    Private Sub HandleFlag(ByVal _f As String)
        Flag = _f
        Tsum = Sum
        Sum = 0
        dotNum = 0
        isDot = False
        OutputBox.Text = "0"
    End Sub
    Private Sub BtnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPlus.Click
        HandleFlag("+")
    End Sub

    Private Sub BtnNat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNat.Click
        HandleFlag("-")
    End Sub

    Private Sub BtnTimes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimes.Click
        HandleFlag("x")
    End Sub

    Private Sub BtnDiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDiv.Click
        HandleFlag("/")
    End Sub
    
    Private Sub BtnLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLog.Click
        If Sum = 0 Then Exit Sub
        isReset = True
        Sum = Math.Log10(Sum)
        OutputBox.Text = Str(Sum)
        If Sum < 1 And Sum > 0 Then
            OutputBox.Text = "0" & OutputBox.Text
        End If
    End Sub
End Class
