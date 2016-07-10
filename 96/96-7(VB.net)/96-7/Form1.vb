Public Class Form1
    Dim Menu1() As String = {"香酥脆皮雞排", "特選沙朗牛排", "特選菲力牛排", "什錦海鮮", "法式藍帶豬排", "海陸大餐"}
    Dim Menu1Price() As Integer = {250, 380, 430, 450, 300, 570}
    Dim Menu2() As String = {"生菜沙拉", "凱薩醬", "和風醬", "優格水果沙拉", "千島醬", "義大利醬"}
    Dim Menu2Price() As Integer = {60, 60, 60, 60, 60, 60}
    Dim Menu3() As String = {"洋蔥鱈魚肝", "泰式嫩菲力", "煙燻鮭魚", "香蒜烤田螺", "黑菌鵝肝醬"}
    Dim Menu3Price() As Integer = {80, 80, 80, 80, 80}
    Dim Menu4() As String = {"雞蓉巧達湯", "海鮮燉魚湯", "烤洋蔥湯", "南瓜湯", "脆皮濃湯"}
    Dim Menu4Price() As Integer = {100, 100, 100, 100, 100}
    Dim Menu5() As String = {"雞蛋布丁", "焦糖蛋糕", "義式布丁", "提拉米蘇", "柳橙水果凍"}
    Dim Menu5Price() As Integer = {30, 50, 40, 50, 50}
    Dim Menu6() As String = {"奶泡熱奶茶", "熱咖啡", "蜂蜜柚子茶", "拿鐵熱咖啡", "熱金桔檸檬梅子汁"}
    Dim Menu6Price() As Integer = {70, 70, 90, 70, 100}
    Dim Menu7() As String = {"可口可樂", "冰咖啡", "冰金桔檸檬", "芒果汁", "冰拿鐵"}
    Dim Menu7Price() As Integer = {50, 70, 100, 90, 70}
    Dim Text1(6), Text2(6), Text3(5), Text4(5), Text5(5), Text6(5), Text7(5) As Label
    Dim Price1(6), Price2(6), Price3(5), Price4(5), Price5(5), Price6(5), Price7(5) As TextBox
    Dim Num1(6), Num2(6), Num3(5), Num4(5), Num5(5), Num6(5), Num7(5) As TextBox
    Dim VSB1(6), VSB2(6), VSB3(5), VSB4(5), VSB5(5), VSB6(5), VSB7(5) As VScrollBar


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 1 To 6
            Text1(i) = New Label
            With Text1(i)
                .Text = Menu1(i - 1)
                .Left = 20
                .Top = 10 + i * 20
                .Height = 20
                .Visible = True
                .AutoSize = True
                GroupBox1.Controls.Add(Text1(i))
            End With
            Price1(i) = New TextBox
            With Price1(i)
                .Text = Menu1Price(i - 1)
                .Left = 170
                .Top = 10 + i * 20
                .Width = 30
                .Height = 20
                .Visible = True
                GroupBox1.Controls.Add(Price1(i))
            End With
            Num1(i) = New TextBox
            With Num1(i)
                .Text = "0"
                .Left = 270
                .Top = 10 + i * 20
                .Height = 20
                .Width = 30
                .Visible = True
                GroupBox1.Controls.Add(Num1(i))
            End With
            VSB1(i) = New VScrollBar
            With VSB1(i)
                .Left = 300
                .Top = 10 + i * 20
                .Height = 20
                .Width = 15
                .Visible = True
                GroupBox1.Controls.Add(VSB1(i))
            End With
            AddHandler VSB1(i).Scroll, AddressOf VSB1_Click
        Next

        For i As Integer = 1 To 6
            Text2(i) = New Label
            With Text2(i)
                .Text = Menu2(i - 1)
                .Left = 40
                .Top = 10 + i * 20
                .Height = 20
                .Visible = True
                .AutoSize = True
                GroupBox2.Controls.Add(Text2(i))
            End With
            Price2(i) = New TextBox
            With Price2(i)
                .Text = Menu2Price(i - 1)
                .Left = 170
                .Top = 10 + i * 20
                .Width = 30
                .Height = 20
                .Visible = True
                GroupBox2.Controls.Add(Price2(i))
            End With
            Num2(i) = New TextBox
            With Num2(i)
                .Text = "0"
                .Left = 270
                .Top = 10 + i * 20
                .Height = 20
                .Width = 30
                .Visible = True
                GroupBox2.Controls.Add(Num2(i))
            End With
            VSB2(i) = New VScrollBar
            With VSB2(i)
                .Left = 300
                .Top = 10 + i * 20
                .Height = 20
                .Width = 15
                .Visible = True
                GroupBox2.Controls.Add(VSB2(i))
            End With
            AddHandler VSB2(i).Scroll, AddressOf VSB2_Click
        Next

        For i As Integer = 1 To 5
            Text3(i) = New Label
            With Text3(i)
                .Text = Menu3(i - 1)
                .Left = 20
                .Top = 10 + i * 20
                .Height = 20
                .Visible = True
                .AutoSize = True
                GroupBox3.Controls.Add(Text3(i))
            End With
            Price3(i) = New TextBox
            With Price3(i)
                .Text = Menu3Price(i - 1)
                .Left = 110
                .Top = 10 + i * 20
                .Width = 30
                .Height = 20
                .Visible = True
                GroupBox3.Controls.Add(Price3(i))
            End With
            Num3(i) = New TextBox
            With Num3(i)
                .Text = "0"
                .Left = 180
                .Top = 10 + i * 20
                .Height = 20
                .Width = 30
                .Visible = True
                GroupBox3.Controls.Add(Num3(i))
            End With
            VSB3(i) = New VScrollBar
            With VSB3(i)
                .Left = 210
                .Top = 10 + i * 20
                .Height = 20
                .Width = 15
                .Visible = True
                GroupBox3.Controls.Add(VSB3(i))
            End With
            AddHandler VSB3(i).Scroll, AddressOf VSB3_Click
        Next

        For i As Integer = 1 To 5
            Text4(i) = New Label
            With Text4(i)
                .Text = Menu4(i - 1)
                .Left = 20
                .Top = 10 + i * 20
                .Height = 20
                .Visible = True
                .AutoSize = True
                GroupBox4.Controls.Add(Text4(i))
            End With
            Price4(i) = New TextBox
            With Price4(i)
                .Text = Menu4Price(i - 1)
                .Left = 110
                .Top = 10 + i * 20
                .Width = 30
                .Height = 20
                .Visible = True
                GroupBox4.Controls.Add(Price4(i))
            End With
            Num4(i) = New TextBox
            With Num4(i)
                .Text = "0"
                .Left = 180
                .Top = 10 + i * 20
                .Height = 20
                .Width = 30
                .Visible = True
                GroupBox4.Controls.Add(Num4(i))
            End With
            VSB4(i) = New VScrollBar
            With VSB4(i)
                .Left = 210
                .Top = 10 + i * 20
                .Height = 20
                .Width = 15
                .Visible = True
                GroupBox4.Controls.Add(VSB4(i))
            End With
            AddHandler VSB4(i).Scroll, AddressOf VSB4_Click
        Next

        For i As Integer = 1 To 5
            Text5(i) = New Label
            With Text5(i)
                .Text = Menu5(i - 1)
                .Left = 20
                .Top = 10 + i * 20
                .Height = 20
                .Visible = True
                .AutoSize = True
                GroupBox5.Controls.Add(Text5(i))
            End With
            Price5(i) = New TextBox
            With Price5(i)
                .Text = Menu5Price(i - 1)
                .Left = 110
                .Top = 10 + i * 20
                .Width = 30
                .Height = 20
                .Visible = True
                GroupBox5.Controls.Add(Price5(i))
            End With
            Num5(i) = New TextBox
            With Num5(i)
                .Text = "0"
                .Left = 180
                .Top = 10 + i * 20
                .Height = 20
                .Width = 30
                .Visible = True
                GroupBox5.Controls.Add(Num5(i))
            End With
            VSB5(i) = New VScrollBar
            With VSB5(i)
                .Left = 210
                .Top = 10 + i * 20
                .Height = 20
                .Width = 15
                .Visible = True
                GroupBox5.Controls.Add(VSB5(i))
            End With
            AddHandler VSB5(i).Scroll, AddressOf VSB5_Click
        Next

        For i As Integer = 1 To 5
            Text6(i) = New Label
            With Text6(i)
                .Text = Menu6(i - 1)
                .Left = 40
                .Top = 10 + i * 20
                .Height = 20
                .Visible = True
                .AutoSize = True
                GroupBox6.Controls.Add(Text6(i))
            End With
            Price6(i) = New TextBox
            With Price6(i)
                .Text = Menu6Price(i - 1)
                .Left = 170
                .Top = 10 + i * 20
                .Width = 30
                .Height = 20
                .Visible = True
                GroupBox6.Controls.Add(Price6(i))
            End With
            Num6(i) = New TextBox
            With Num6(i)
                .Text = "0"
                .Left = 270
                .Top = 10 + i * 20
                .Height = 20
                .Width = 30
                .Visible = True
                GroupBox6.Controls.Add(Num6(i))
            End With
            VSB6(i) = New VScrollBar
            With VSB6(i)
                .Left = 300
                .Top = 10 + i * 20
                .Height = 20
                .Width = 15
                .Visible = True
                GroupBox6.Controls.Add(VSB6(i))
            End With
            AddHandler VSB6(i).Scroll, AddressOf VSB6_Click
        Next

        For i As Integer = 1 To 5
            Text7(i) = New Label
            With Text7(i)
                .Text = Menu7(i - 1)
                .Left = 40
                .Top = 10 + i * 20
                .Height = 20
                .Visible = True
                .AutoSize = True
                GroupBox7.Controls.Add(Text7(i))
            End With
            Price7(i) = New TextBox
            With Price7(i)
                .Text = Menu7Price(i - 1)
                .Left = 170
                .Top = 10 + i * 20
                .Width = 30
                .Height = 20
                .Visible = True
                GroupBox7.Controls.Add(Price7(i))
            End With
            Num7(i) = New TextBox
            With Num7(i)
                .Text = "0"
                .Left = 270
                .Top = 10 + i * 20
                .Height = 20
                .Width = 30
                .Visible = True
                GroupBox7.Controls.Add(Num7(i))
            End With
            VSB7(i) = New VScrollBar
            With VSB7(i)
                .Left = 300
                .Top = 10 + i * 20
                .Height = 20
                .Width = 15
                .Visible = True
                GroupBox7.Controls.Add(VSB7(i))
            End With
            AddHandler VSB7(i).Scroll, AddressOf VSB7_Click
        Next


    End Sub

    Private Sub VSB1_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        For i = 1 To 6
            If DirectCast(sender, VScrollBar).Equals(VSB1(i)) Then
                Num1(i).Text = VSB1(i).Value
            End If
        Next
    End Sub
    Private Sub VSB2_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        For i = 1 To 6
            If DirectCast(sender, VScrollBar).Equals(VSB2(i)) Then
                Num2(i).Text = VSB2(i).Value
            End If
        Next
    End Sub
    Private Sub VSB3_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        For i = 1 To 5
            If DirectCast(sender, VScrollBar).Equals(VSB3(i)) Then
                Num3(i).Text = VSB3(i).Value
            End If
        Next
    End Sub
    Private Sub VSB4_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        For i = 1 To 5
            If DirectCast(sender, VScrollBar).Equals(VSB4(i)) Then
                Num4(i).Text = VSB4(i).Value
            End If
        Next
    End Sub
    Private Sub VSB5_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        For i = 1 To 5
            If DirectCast(sender, VScrollBar).Equals(VSB5(i)) Then
                Num5(i).Text = VSB5(i).Value
            End If
        Next
    End Sub
    Private Sub VSB6_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        For i = 1 To 5
            If DirectCast(sender, VScrollBar).Equals(VSB6(i)) Then
                Num6(i).Text = VSB6(i).Value
            End If
        Next
    End Sub
    Private Sub VSB7_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        For i = 1 To 5
            If DirectCast(sender, VScrollBar).Equals(VSB7(i)) Then
                Num7(i).Text = VSB7(i).Value
            End If
        Next
    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Label.Text = "等客人點餐"
        For i = 1 To 6
            VSB1(i).Value = 0
            VSB2(i).Value = 0
            Num1(i).Text = 0
            Num2(i).Text = 0
        Next
        For i = 1 To 5
            VSB3(i).Value = 0
            VSB4(i).Value = 0
            VSB5(i).Value = 0
            VSB6(i).Value = 0
            VSB7(i).Value = 0
            Num3(i).Text = 0
            Num4(i).Text = 0
            Num5(i).Text = 0
            Num6(i).Text = 0
            Num7(i).Text = 0
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sum As Double = 0
        For i = 1 To 6
            sum += VSB1(i).Value * Val(Price1(i).Text)
            sum += VSB2(i).Value * Val(Price2(i).Text)
        Next
        For i = 1 To 5
            sum += VSB3(i).Value * Val(Price3(i).Text)
            sum += VSB4(i).Value * Val(Price4(i).Text)
            sum += VSB5(i).Value * Val(Price5(i).Text)
            sum += VSB6(i).Value * Val(Price6(i).Text)
            sum += VSB7(i).Value * Val(Price7(i).Text)
        Next
        sum *= 1.05
        sum = Math.Round(sum + 0.01)
        Label.Text = "加稅後總金額：" & Val(sum)
    End Sub
End Class
