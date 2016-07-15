Public Class Form1
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim X As Integer = Val(TextBox1.Text)
        Dim P As Integer = Val(TextBox2.Text)
        Dim N As Integer = Val(TextBox3.Text)
        Dim FinalNum As Integer = 0
        If P Mod 2 = 1 Then
            P = P - 1
            FinalNum = X
            Do
                Down(X, P, N)
            Loop Until P = 1
            Label2.Text = "餘數是" & ((FinalNum * X) Mod N).ToString
        Else
            Do
                Down(X, P, N)
            Loop Until P = 1
            Label2.Text = "餘數是" & (X Mod N).ToString
        End If
    End Sub
    Sub Down(ByRef x As Integer, ByRef p As Integer, ByRef n As Integer)
        p = p / 2
        x = x ^ 2 Mod n
    End Sub
End Class