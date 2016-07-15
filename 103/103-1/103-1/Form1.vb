Public Class Form1
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Val(TextBox1.Text) > 1 Or Val(TextBox1.Text) > 1 Or Val(TextBox1.Text) > 1 Then
            TextBox7.Text = "無解"
        Else
            TextBox7.Text = "在台北市的上班族遲到的機率為:" & (Val(TextBox1.Text) * Val(TextBox4.Text)) + (Val(TextBox2.Text) * Val(TextBox5.Text)) + (Val(TextBox3.Text) * Val(TextBox6.Text))
        End If
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If Val(TextBox1.Text) > 1 Or Val(TextBox1.Text) > 1 Or Val(TextBox1.Text) > 1 Then
            TextBox7.Text = "無解"
        Else
            TextBox7.Text = "如果已知有一個人上班遲到，那他是自己開車的機率為何:" & Val(TextBox6.Text) / ((Val(TextBox1.Text) * Val(TextBox4.Text)) + (Val(TextBox2.Text) * Val(TextBox5.Text)) + (Val(TextBox3.Text) * Val(TextBox6.Text))) / 10
        End If
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        End
    End Sub
End Class
