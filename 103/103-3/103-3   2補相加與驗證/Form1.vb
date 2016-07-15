Public Class Form1
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        Randomize()
        For i = 1 To 8
            TextBox1.Text &= Int(2 * Rnd())
            TextBox2.Text &= Int(2 * Rnd())
        Next
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox8.Text = ""
        Dim t3 As String
        t3 = ""
        Dim Over As Boolean = False
        For i = 1 To 8
            If Over = True Then
                If Val(Strings.Mid(TextBox1.Text, 9 - i, 1)) + Val(Strings.Mid(TextBox2.Text, 9 - i, 1)) + 1 = 3 Then
                    t3 &= "1"
                    Over = True
                    Continue For
                End If
                If Val(Strings.Mid(TextBox1.Text, 9 - i, 1)) + Val(Strings.Mid(TextBox2.Text, 9 - i, 1)) + 1 = 2 Then
                    t3 &= "0"
                    Over = True
                    Continue For
                End If
                If Val(Strings.Mid(TextBox1.Text, 9 - i, 1)) + Val(Strings.Mid(TextBox2.Text, 9 - i, 1)) + 1 = 1 Then
                    t3 &= "1"
                    Over = False
                    Continue For
                End If
            End If
            If Val(Strings.Mid(TextBox1.Text, 9 - i, 1)) + Val(Strings.Mid(TextBox2.Text, 9 - i, 1)) = 2 Then
                t3 &= "0"
                Over = True
                Continue For
            End If
            If Val(Strings.Mid(TextBox1.Text, 9 - i, 1)) + Val(Strings.Mid(TextBox2.Text, 9 - i, 1)) = 1 Then
                t3 &= "1"
                Over = False
                Continue For
            End If
            If Val(Strings.Mid(TextBox1.Text, 9 - i, 1)) + Val(Strings.Mid(TextBox2.Text, 9 - i, 1)) = 0 Then
                t3 &= "0"
                Over = False
                Continue For
            End If
        Next
        TextBox3.Text = StrReverse(t3)
        If Strings.Mid(TextBox1.Text, 1, 1) = "0" And Strings.Mid(TextBox2.Text, 1, 1) = "0" And Strings.Mid(TextBox3.Text, 1, 1) = "1" Then
            TextBox4.Text = "underflow"
        End If
        If Strings.Mid(TextBox1.Text, 1, 1) = "1" And Strings.Mid(TextBox2.Text, 1, 1) = "1" And Strings.Mid(TextBox3.Text, 1, 1) = "0" Then
            TextBox4.Text = "underflow"
        End If
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Dim t5 As Integer = 0, t6 As Integer = 0, t7 As Integer = 0

        '定義一個放置二補後的文字
        Dim II As String = ""
        '分析第一個字到第八個字
        For i = 1 To 8
            '若第一字為0
            If Strings.Mid(TextBox1.Text, 1, 1) = "0" Then
                '當目前分析第一字時
                If i = 1 Then
                    '令輸出為正
                    TextBox5.Text &= "+"
                    '離開分析第二字
                    Continue For
                End If
                '從第二字開始計算加到第八字
                t5 += Strings.Mid(TextBox1.Text, i, 1) * (2 ^ (8 - i))
                Continue For
            Else
                '若第一字為0
                '當目前分析第一字時
                If i = 1 Then
                    '令T5為負一
                    t5 = -1
                    '將原始字串相反後放在II
                    For x = 1 To 8
                        If Strings.Mid(TextBox1.Text, x, 1) = "0" Then
                            II &= "1"
                        Else
                            II &= "0"
                        End If
                    Next
                    t5 -= Strings.Mid(II, i, 1) * (2 ^ (8 - i))
                    Continue For
                End If
                '從第二字開始計算加到第八字
                t5 -= Strings.Mid(II, i, 1) * (2 ^ (8 - i))
                Continue For
            End If
        Next

        Dim kk As String = ""
        For i = 1 To 8
            If Strings.Mid(TextBox2.Text, 1, 1) = "0" Then
                If i = 1 Then
                    TextBox6.Text &= "+"                    
                    Continue For
                End If
                t6 += Strings.Mid(TextBox2.Text, i, 1) * (2 ^ (8 - i))
                Continue For
            Else
                If i = 1 Then
                    t6 = -1
                    For x = 1 To 8
                        If Strings.Mid(TextBox2.Text, x, 1) = "0" Then
                            kk &= "1"
                        Else
                            kk &= "0"
                        End If
                    Next
                    t6 -= Strings.Mid(kk, i, 1) * (2 ^ (8 - i))
                    Continue For
                End If
                t6 -= Strings.Mid(kk, i, 1) * (2 ^ (8 - i))
                Continue For
            End If
        Next
        Dim pp As String = ""
        For i = 1 To 8
            If Strings.Mid(TextBox3.Text, 1, 1) = "0" Then
                If i = 1 Then
                    TextBox7.Text &= "+"
                    Continue For
                End If
                t7 += Strings.Mid(TextBox3.Text, i, 1) * (2 ^ (8 - i))
                Continue For
            Else
                If i = 1 Then
                    t7 = -1
                    For x = 1 To 8
                        If Strings.Mid(TextBox3.Text, x, 1) = "0" Then
                            pp &= "1"
                        Else
                            pp &= "0"
                        End If
                    Next
                    t7 -= Strings.Mid(pp, i, 1) * (2 ^ (8 - i))
                    Continue For
                End If
                t7 -= Strings.Mid(pp, i, 1) * (2 ^ (8 - i))
                Continue For
            End If
        Next
        TextBox5.Text &= t5
        TextBox6.Text &= t6
        TextBox7.Text &= t7
        If Val(TextBox5.Text) + Val(TextBox6.Text) <> Val(TextBox7.Text) Then
            TextBox8.Text = "不足位"
        End If
    End Sub
End Class