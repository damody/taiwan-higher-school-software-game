' 匯入命名空間
Imports System.IO
Public Class Form1
    Dim MaxValues(100), MinValues(100), OverValues(100), KValues(100), DValues(100) As Single

    Private Sub InputBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InputBox.MouseDoubleClick
        OpenFileDialog.ShowDialog()
        InputBox.Text = OpenFileDialog.FileName
    End Sub

    Private Sub OutputBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OutputBox.MouseDoubleClick
        SaveFileDialog.ShowDialog()
        OutputBox.Text = SaveFileDialog.FileName
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If InputBoxD.Text <> "" And InputBoxK.Text <> "" And InputBox.Text <> "" And OutputBox.Text <> "" Then
            Dim Count As Integer = 0
            Try
                Using myStreamReader As StreamReader = File.OpenText(InputBox.Text)
                    Dim myInputString As String
                    Dim rowCount As Integer = 0
                    While True
                        myInputString = myStreamReader.ReadLine()
                        If myInputString Is Nothing Then
                            Exit While
                        End If
                        Dim strTmp() As String = myInputString.Split(" ")
                        Count += 1
                        MaxValues(Count) = Val(strTmp(1))
                        MinValues(Count) = Val(strTmp(2))
                        OverValues(Count) = Val(strTmp(3))
                    End While
                End Using
            Catch ex As Exception
                MessageBox.Show("檔案讀取錯誤。" + Environment.NewLine + "例外狀況：" + ex.Message)
            End Try
            Using myStreamWriter As StreamWriter = File.CreateText(OutputBox.Text)
                For i = 0 To 7
                    myStreamWriter.WriteLine(Str(i))
                Next
                myStreamWriter.WriteLine(" 8 " & InputBoxK.Text & " " & InputBoxD.Text)
                Dim NowK As Single = Val(InputBoxK.Text)
                Dim NowD As Single = Val(InputBoxD.Text)
                For DayCount = 9 To Count
                    Dim minPrice, maxPrice As Single
                    minPrice = MinValues(DayCount)
                    maxPrice = MaxValues(DayCount)
                    For RSV_Count = DayCount To DayCount - 8 Step -1
                        If minPrice > MinValues(RSV_Count) Then
                            minPrice = MinValues(RSV_Count)
                        End If
                        If maxPrice < MaxValues(RSV_Count) Then
                            maxPrice = MaxValues(RSV_Count)
                        End If
                    Next
                    Dim RSV As Single = (OverValues(DayCount) - minPrice) / (maxPrice - minPrice) * 100
                    NowK = NowK * 2 / 3 + RSV / 3
                    NowD = NowD * 2 / 3 + NowK / 3
                    myStreamWriter.WriteLine(Str(DayCount) & Format(NowK, " 00.00 ") & Format(NowD, "00.00"))
                Next
            End Using
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If InputBoxD.Text <> "" And InputBoxK.Text <> "" And InputBox.Text <> "" And OutputBox.Text <> "" Then
            Dim Count As Integer = 0
            Try
                Using myStreamReader As StreamReader = File.OpenText(InputBox.Text)
                    Dim myInputString As String
                    Dim rowCount As Integer = 0
                    While True
                        myInputString = myStreamReader.ReadLine()
                        If myInputString Is Nothing Then
                            Exit While
                        End If
                        Dim strTmp() As String = myInputString.Split(" ")
                        Count += 1
                        MaxValues(Count) = Val(strTmp(1))
                        MinValues(Count) = Val(strTmp(2))
                        OverValues(Count) = Val(strTmp(3))
                    End While
                End Using
            Catch ex As Exception
                MessageBox.Show("檔案讀取錯誤。" + Environment.NewLine + "例外狀況：" + ex.Message)
            End Try
            '算出KD來
            Dim NowK As Single = Val(InputBoxK.Text)
            Dim NowD As Single = Val(InputBoxD.Text)
            KValues(8) = NowK
            DValues(8) = NowD
            For DayCount = 9 To Count
                Dim minPrice, maxPrice As Single
                minPrice = MinValues(DayCount)
                maxPrice = MaxValues(DayCount)
                For RSV_Count = DayCount To DayCount - 8 Step -1
                    If minPrice > MinValues(RSV_Count) Then
                        minPrice = MinValues(RSV_Count)
                    End If
                    If maxPrice < MaxValues(RSV_Count) Then
                        maxPrice = MaxValues(RSV_Count)
                    End If
                Next
                Dim RSV As Single = (OverValues(DayCount) - minPrice) / (maxPrice - minPrice) * 100
                NowK = NowK * 2 / 3 + RSV / 3
                NowD = NowD * 2 / 3 + NowK / 3
                KValues(DayCount) = Val(Format(NowK, " 00.00 "))
                DValues(DayCount) = Val(Format(NowD, "00.00"))
            Next

            Try
                Using myStreamReader As StreamReader = File.OpenText(OutputBox.Text)
                    Dim myInputString As String
                    For i = 0 To 7
                        myStreamReader.ReadLine()
                    Next
                    Dim rowCount As Integer = 7
                    While True
                        myInputString = myStreamReader.ReadLine()
                        If myInputString Is Nothing Then
                            Exit While
                        End If
                        Dim strTmp() As String = myInputString.Split(" ")
                        rowCount += 1

                        If KValues(rowCount) <> Convert.ToSingle(strTmp(2)) Or _
                            DValues(rowCount) <> Convert.ToSingle(strTmp(3)) Then
                            MessageBox.Show("驗證失敗")
                            Exit Sub
                        End If
                    End While
                End Using
                MessageBox.Show("驗證成功")
            Catch ex As Exception
                MessageBox.Show("驗證失敗")
            End Try
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

    
End Class
