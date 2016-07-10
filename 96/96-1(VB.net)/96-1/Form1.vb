Public Class Form1
    Dim points(3) As Point
    Dim maxY, minY, midY, maxX, minX, midX, Sum, Xsum As Single
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Do
            RandomPoints()
            Sum = maxX - minX
            Sum += maxY - minY
            Button2.PerformClick()
        Loop While Sum = Xsum '當不能省線長時找別的點看看
        Output1.Text = Str(Sum)
        Output2.Text = ""
        Output3.Text = ""
        Dim g As Graphics = OutputBox.CreateGraphics()
        g.Clear(Color.White)
        DrawPoints()
        g.DrawLine(Pens.Black, maxX, midY, minX, midY)
        g.DrawLine(Pens.Black, points(1).X, minY, points(1).X, midY)
        g.DrawLine(Pens.Black, points(3).X, maxY, points(3).X, midY)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim H1 As Integer = midY - minY '第一段高
        Dim H2 As Integer = maxY - midY '第二段高
        Dim W1 As Integer = Math.Abs(points(1).X - points(2).X) '第一段長
        Dim W2 As Integer = Math.Abs(points(2).X - points(3).X) '第二段長
        Dim X1st, X2nd As Integer 'X1st儲放第一個折點的X值，X2nd儲放第二個折點的X值
        Dim Su1, Su2, Su3 As Integer '各段計算後的總合
        Su1 = 9999
        Su2 = 9999
        Su3 = 9999
        '第一段可繞線的長度計算
        If W1 > H1 Then
            If (points(1).X > points(2).X) Then
                X1st = points(1).X - H1
            Else
                X1st = points(1).X + H1
            End If
            Su1 = ((points(1).X - X1st) ^ 2 + (points(1).Y - midY) ^ 2) ^ 0.5
            Su1 += maxY - midY
            Su1 += Math.Abs(X1st - points(2).X) + Math.Abs(points(3).X - points(2).X)
            If X1st >= points(2).X And points(3).X >= points(2).X Or X1st <= points(2).X And points(3).X <= points(2).X Then
                Su1 -= Math.Min(Math.Abs(X1st - points(2).X), Math.Abs(points(3).X - points(2).X))
            End If
        End If
        '第二段可繞線的長度計算
        If W2 > H2 Then
            If (points(3).X > points(2).X) Then
                X2nd = points(3).X - H2
            Else
                X2nd = points(3).X + H2
            End If
            Su2 = ((points(3).X - X2nd) ^ 2 + (points(3).Y - midY) ^ 2) ^ 0.5
            Su2 += midY - minY
            Su2 += Math.Abs(points(1).X - points(2).X) + Math.Abs(X2nd - points(2).X)
            If X2nd >= points(2).X And points(1).X >= points(2).X Or points(1).X <= points(2).X And X2nd <= points(2).X Then
                Su2 -= Math.Min(Math.Abs(X2nd - points(2).X), Math.Abs(points(1).X - points(2).X))
            End If
        End If
        '一二段都可繞線的長度計算
        If W1 > H1 And W2 > H2 Then
            Su3 = ((points(1).X - X1st) ^ 2 + (points(1).Y - midY) ^ 2) ^ 0.5
            Su3 += ((points(3).X - X2nd) ^ 2 + (points(3).Y - midY) ^ 2) ^ 0.5
            Su3 += Math.Abs(X1st - points(2).X) + Math.Abs(X2nd - points(2).X)
            If X1st >= points(2).X And X2nd >= points(2).X Or X1st <= points(2).X And X2nd <= points(2).X Then
                Su3 -= Math.Min(Math.Abs(X1st - points(2).X), Math.Abs(X2nd - points(2).X))
            End If
        End If
        '計算出結果
        Xsum = Math.Min(Sum, fMin(Su1, Su2, Su3))
        Output2.Text = Str(Xsum)
        Output3.Text = Format((Sum - Xsum) / Sum * 100, "0.00") + "%"
        '畫出最短的線
        Dim g As Graphics = OutputBox.CreateGraphics()
        g.Clear(Color.White)
        DrawPoints()
        Select Case Xsum
            Case Su1
                g.DrawLine(Pens.Black, points(1).X, points(1).Y, X1st, midY)
                g.DrawLine(Pens.Black, points(3).X, maxY, points(3).X, midY)
                g.DrawLine(Pens.Black, X1st, midY, points(2).X, midY)
                g.DrawLine(Pens.Black, points(3).X, midY, points(2).X, midY)
            Case Su2
                g.DrawLine(Pens.Black, points(3).X, points(3).Y, X2nd, midY)
                g.DrawLine(Pens.Black, points(1).X, minY, points(1).X, midY)
                g.DrawLine(Pens.Black, points(1).X, midY, points(2).X, midY)
                g.DrawLine(Pens.Black, X2nd, midY, points(2).X, midY)
            Case Su3
                g.DrawLine(Pens.Black, points(1).X, points(1).Y, X1st, midY)
                g.DrawLine(Pens.Black, points(3).X, points(3).Y, X2nd, midY)
                g.DrawLine(Pens.Black, X1st, midY, points(2).X, midY)
                g.DrawLine(Pens.Black, X2nd, midY, points(2).X, midY)
            Case Sum
                g.DrawLine(Pens.Black, maxX, midY, minX, midY)
                g.DrawLine(Pens.Black, points(1).X, minY, points(1).X, midY)
                g.DrawLine(Pens.Black, points(3).X, maxY, points(3).X, midY)
        End Select
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

    Private Function fMax(ByVal a As Single, ByVal b As Single, ByVal c As Single) As Single
        Return Math.Max(a, Math.Max(b, c))
    End Function
    Private Function fMin(ByVal a As Single, ByVal b As Single, ByVal c As Single) As Single
        Return Math.Min(a, Math.Min(b, c))
    End Function

    Private Sub RandomPoints()
        Randomize(Now.Millisecond)
        Do
            For i = 1 To 3
                points(i).X = Rnd() * (OutputBox.Width - 20) + 10
                points(i).Y = Rnd() * (OutputBox.Height - 20) + 10
            Next
            If points(1).Y > points(2).Y Then
                swap(points(1), points(2))
            End If
            If points(2).Y > points(3).Y Then
                swap(points(2), points(3))
            End If
            If points(1).Y > points(2).Y Then
                swap(points(1), points(2))
            End If
        Loop While (Math.Abs(points(1).Y - points(2).Y) < 10) Or (Math.Abs(points(2).Y - points(3).Y)) < 10 _
                Or (Math.Abs(points(1).X - points(2).X) < 10) Or (Math.Abs(points(2).X - points(3).X)) < 10
        maxY = fMax(points(1).Y, points(2).Y, points(3).Y)
        minY = fMin(points(1).Y, points(2).Y, points(3).Y)
        For i = 1 To 3
            If points(i).Y <> maxY And points(i).Y <> minY Then
                midY = points(i).Y
            End If
        Next
        maxX = fMax(points(1).X, points(2).X, points(3).X)
        minX = fMin(points(1).X, points(2).X, points(3).X)
        For i = 1 To 3
            If points(i).X <> maxX And points(i).X <> minX Then
                midX = points(i).X
            End If
        Next
    End Sub
    Private Sub swap(Of T)(ByRef a As T, ByRef b As T)
        Dim tmp As T = a
        a = b
        b = tmp
    End Sub
    Private Sub DrawPoints()
        Dim g As Graphics = OutputBox.CreateGraphics()
        For i = 1 To 3
            g.FillEllipse(Brushes.Black, points(i).X - 4, points(i).Y - 4, 8, 8)
        Next
    End Sub
End Class
