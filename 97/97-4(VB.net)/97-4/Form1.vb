Public Class Form1
    Dim str1 As String = "請輸入每一點資料的x,y [ x, y ]:"
    Dim str2 As String = "請輸入資料的總數:"
    Dim points(100) As PointF
    Dim Count, NowCount As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Label1.Text = str2 Then
                Count = Convert.ToInt32(InputBox.Text)
                Label1.Text = str1
                NowCount = 0
                RichTextBox.Text += vbCrLf + str2 + Str(Count)
                ReSet()
            Else
                Dim StrTmp As String = InputBox.Text.Replace("[", "")
                StrTmp = StrTmp.Replace("]", "")
                Dim StrTmp2() As String = StrTmp.Split(" ")
                points(NowCount).X = Val(StrTmp2(0))
                points(NowCount).Y = Val(StrTmp2(1))
                NowCount += 1
                RichTextBox.Text += vbCrLf + str1 + "[" + StrTmp2(0) + " " + StrTmp2(1) + "]"
                ReSet()
                Output()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        If NowCount = Count And Count > 0 Then
            Dim xy, xx, x, y, px, py, m, b As Double
            For i = 0 To Count
                xy += points(i).X * points(i).Y
                xx += points(i).X * points(i).X
                x += points(i).X
                y += points(i).Y
            Next
            px = x / Count
            py = y / Count
            m = (xy - x * py) / (xx - x * px)
            b = py - m * px
            RichTextBox.Text += vbCrLf + "最小平方直線的回歸係數:"
            RichTextBox.Text += vbCrLf + "斜率 (m)  = " + Str(m)
            RichTextBox.Text += vbCrLf + "截距 (b)  = " + Str(b)
            RichTextBox.Text += vbCrLf + "總資料點數= " + Str(Count)
            ReSet()
            Output()
            Label1.Text = str2
        End If
        InputBox.Text = ""
        InputBox.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ReSet()
        Label1.Text = str2
        RichTextBox.Text = ""
    End Sub
    Const XYstep As Integer = 40
    Private Sub ReSet()
        '初始化畫畫工具
        Dim g As Graphics = OutputBox.CreateGraphics()
        Dim MyPen As Pen = New Pen(Brushes.Black, 1.0F)
        Dim MyBrush As Brush = Brushes.White
        '畫出方形區
        g.FillRectangle(MyBrush, 50, 50, 320, 320)
        g.DrawRectangle(MyPen, 50, 50, 320, 320)
        MyPen.DashStyle = Drawing2D.DashStyle.Dash
        '畫虛線
        For i As Integer = 50 To 50 + XYstep * 7 Step XYstep
            g.DrawLine(MyPen, 50, i, 370, i)
            g.DrawLine(MyPen, i, 50, i, 370)
        Next
        '畫數字1~8
        Dim Myfont As Font = New Font("新細明體", 12)
        For i = 50 To 50 + XYstep * 8 Step XYstep
            g.DrawString(Str(8 - (i - 50) / 40), Myfont, Brushes.Black, 30, i)
        Next
        For i = 70 To 70 + XYstep * 7 Step XYstep
            g.DrawString(Str(1 + (i - 70) / 40), Myfont, Brushes.Black, i, 370)
        Next
    End Sub

    Private Sub Output()
        '依座標畫線出來
        If NowCount > 0 Then
            DrawLineToOutputBox(points(0).X, points(0).Y, points(0).X, points(0).Y)
        End If
        For i = 0 To NowCount - 2
            DrawLineToOutputBox(points(i).X, points(i).Y, points(i + 1).X, points(i + 1).Y)
        Next
    End Sub
    Private Sub DrawLineToOutputBox(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single)
        Dim g As Graphics = OutputBox.CreateGraphics()
        Dim MyPen As Pen = New Pen(Brushes.Red, 1.5F)
        Dim MyPenB As Pen = New Pen(Brushes.Blue, 1.0F)
        '把座標經過轉換後畫出來
        g.DrawArc(MyPenB, x2 * XYstep + 45, (8 - y2) * XYstep + 45, 10.0F, 10.0F, 0.0F, 360.0F)
        g.DrawLine(MyPen, x1 * XYstep + 50, (8 - y1) * XYstep + 50, x2 * XYstep + 50, (8 - y2) * XYstep + 50)
    End Sub

    Private Sub InputBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles InputBox.KeyDown
        '按ENTER等於按確定
        If e.KeyData = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub
End Class
