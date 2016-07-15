Public Class Form1
    Dim Mode As String = ""
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label1.Text = ""
        Label2.Text = ""
    End Sub
    Dim a As String = ""
    Dim b As String = ""
    Dim Buttom As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Buttom = Val(TextBox1.Text)
        If Mode = "正向" Then
            a = "數值:" & TextBox1.Text & vbCrLf & "顯示方向:正向" & vbCrLf
            For i = 1 To (Buttom + 1) / 2 Step 1
                a &= Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((Buttom + 1) / 2) - i) & Strings.Left("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", i * 2 - 1) & vbCrLf
            Next
            Label1.Text = a

            b = "數值:" & TextBox1.Text & vbCrLf & "顯示方向:正向" & vbCrLf & "設為中空" & vbCrLf & Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((Buttom + 1) / 2) - 1) & "＊" & vbCrLf
            For i = 2 To ((Buttom + 1) / 2) - 1 Step 1
                b &= Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((Buttom - 1) / 2) - i + 1) & "＊" & Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((i * 2) - 3)) & "＊" & vbCrLf
            Next
            b &= Strings.Left("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", Buttom)
            Label2.Text = b

        Else

            a = "數值:" & TextBox1.Text & vbCrLf & "顯示方向:垂直反轉" & vbCrLf
            For i = (Buttom + 1) / 2 To 1 Step -1
                a &= Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((Buttom + 1) / 2) - i) & Strings.Left("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", i * 2 - 1) & vbCrLf
            Next
            Label1.Text = a

            b = "數值:" & TextBox1.Text & vbCrLf & "顯示方向:垂直反轉" & vbCrLf & "設為中空" & vbCrLf
            b &= Strings.Left("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", Buttom) & vbCrLf
            For i = ((Buttom + 1) / 2) - 1 To 2 Step -1
                b &= Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((Buttom - 1) / 2) - i + 1) & "＊" & Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((i * 2) - 3)) & "＊" & vbCrLf
            Next
            b &= Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((Buttom + 1) / 2) - 1) & "＊" & vbCrLf
            Label2.Text = b
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Mode = "垂直反轉"
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        b = "數值:" & TextBox1.Text & vbCrLf & "顯示方向:垂直反轉" & vbCrLf & "設為中空" & vbCrLf
        b &= Strings.Left("＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊", Buttom) & vbCrLf
        For i = ((Buttom + 1) / 2) - 1 To 2 Step -1
            b &= Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((Buttom - 1) / 2) - i + 1) & "＊" & Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((i * 2) - 3)) & "＊" & vbCrLf
        Next
        b &= Strings.Left("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　", ((Buttom + 1) / 2) - 1) & "＊" & vbCrLf
        Label2.Text = b
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Mode = "正向"
    End Sub
End Class
