Module Module1
    Dim AllPlayers As String = "六年一班 48763 小明 男 100公尺" & vbCrLf & "五年二班 12345 小華 女 400公尺接力"
    Sub Main()
        Console.WriteLine("")
        Console.WriteLine("請選擇操作項目:")
        Console.WriteLine("       (1)批次輸入:")
        Console.WriteLine("       (2)選手查詢:")
        Console.WriteLine("       (3)刪除:")
        Console.WriteLine("       (4)逐筆輸入:")
        Console.WriteLine("       (5)顯示所有資料:")
        Console.Write("請選擇:")

        Dim Choose As String = ""

        Choose = Console.ReadLine()
        Do
            Select Case Choose
                Case Is = "1"
                    Console.WriteLine("批次輸入，")
                    For i = 1 To 1000
                        Dim r As String = Console.ReadLine
                        If r = "" Then Exit For
                        AllPlayers &= vbCrLf & r
                    Next

                    Console.Write("繼續:請按1,結束:請按0")
                    If Console.ReadLine = "1" Then
                        Choose = "1"
                        Continue Do
                    Else
                        Main()
                    End If
                    Exit Do
                    '''''''''''''''''''''''''''''''''''''''''''''''' ''''''''''''''''''''''''''''''''''''''''''''''''
                Case Is = "2"
                    Console.WriteLine("選手查詢，")
                    Console.Write("請輸入 班級、學號、姓名:")
                    Dim PlayerName As String = Console.ReadLine()
                    Dim Search() As String = Split(AllPlayers, vbCrLf)
                    For i = 0 To Search.Length - 1
                        If InStr(Search(i), PlayerName) > 0 Then
                            Console.WriteLine(Search(i))
                        End If
                    Next
                    Console.Write("繼續:請按1,結束:請按0")
                    If Console.ReadLine = "1" Then
                        Choose = "2"
                        Continue Do
                    Else
                        Main()
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''' ''''''''''''''''''''''''''''''''''''''''''''''''
                Case Is = "3"
                    Console.WriteLine("刪除資料，")
                    Console.Write("請輸入 班級、學號、姓名及報名項目:")
                    Dim PlayerName As String = Console.ReadLine()
                    Dim Search() As String = Split(AllPlayers, vbCrLf)
                    Console.WriteLine("被刪除的選手資料:" & PlayerName)
                    For i = 0 To Search.Length - 1
                        Dim q() As String = Split(PlayerName, " ")
                        If InStr(Search(i), q(3)) > 0 And InStr(Search(i), q(2)) > 0 Then
                            AllPlayers = ""
                            For x = 0 To Search.Length - 1
                                If x = i Then Continue For
                                AllPlayers &= Search(x) & vbCrLf
                            Next
                        End If
                    Next
                    Console.Write("繼續:請按1,結束:請按0")
                    If Console.ReadLine = "1" Then
                        Choose = "3"
                        Continue Do
                    Else
                        Main()
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''' ''''''''''''''''''''''''''''''''''''''''''''''''
                Case Is = "4"
                    Console.WriteLine("逐筆輸入，")
                    Console.Write("請輸入 班級、學號、姓名及性別:")
                    Dim player As String = Console.ReadLine()
                    Console.WriteLine("報名項目:")
                    Console.WriteLine(" a:大隊接力")
                    Console.WriteLine(" b:一顆球的距離")
                    Console.WriteLine(" c:天旋地轉")
                    Console.WriteLine(" d:滾大球袋鼠跳")
                    Console.WriteLine(" e:牽手同心")
                    Console.WriteLine(" f:100公尺")
                    Console.WriteLine(" g:400公尺接力")
                    Console.WriteLine(" h:800公尺")
                    Console.WriteLine(" i:跳高")
                    Console.Write("請選擇")
                    Dim x As Integer = 0, y As Integer = 0
                    Dim a As String = Console.ReadLine()
                    Dim b As String = ""
                    Select Case a
                        Case Is = "a"
                            b = "大隊接力"
                        Case Is = "b"
                            b = "一顆球的距離"
                            x += 1
                        Case Is = "c"
                            b = "天旋地轉"
                            x += 1
                        Case Is = "d"
                            b = "滾大球袋鼠跳"
                            x += 1
                        Case Is = "e"
                            b = "牽手同心"
                            x += 1
                        Case Is = "f"
                            b = "100公尺"
                            y += 1
                        Case Is = "g"
                            b = "400公尺接力"
                            y += 1
                        Case Is = "h"
                            b = "800公尺"
                            y += 1
                        Case Is = "i"
                            b = "跳高"
                            y += 1
                    End Select
                    Dim sp() As String = Split(player, " ")
                    Console.WriteLine("輸入班級:" & sp(0) & "、學號:" & sp(1) & "、姓名:" & sp(2) & "、性別:" & sp(3) & "、報名項目:" & b)
                    Dim sp2() As String = Split(AllPlayers, vbCrLf)
                    For i = 0 To sp2.Length - 1
                        If InStr(sp2(i), sp(2)) > 0 Then
                            Console.WriteLine(sp2(i))
                            If sp2(i) Like "*一顆球的距離*" Then x += 1
                            If sp2(i) Like "*天旋地轉*" Then x += 1
                            If sp2(i) Like "*滾大球袋鼠跳*" Then x += 1
                            If sp2(i) Like "*牽手同心*" Then x += 1
                            If sp2(i) Like "*100公尺*" Then y += 1
                            If sp2(i) Like "*400公尺接力*" Then y += 1
                            If sp2(i) Like "*800公尺*" Then y += 1
                            If sp2(i) Like "*跳高*" Then y += 1
                        End If
                    Next
                    If x * y <> 0 Or x + y > 2 Then
                        If x > 2 Then
                            Console.WriteLine("已報個人賽，不能在報名超過2項!")
                        Else
                            Console.WriteLine("已報團體賽，不能在報名超過2項!")
                        End If
                    Else
                        AllPlayers &= vbCrLf & player & " " & b
                    End If

                    Exit Do
                    '''''''''''''''''''''''''''''''''''''''''''''''' ''''''''''''''''''''''''''''''''''''''''''''''''
                Case Is = "5"
                    Console.WriteLine("顯示所有資料，")
                    Console.WriteLine(AllPlayers)

                    Exit Do
                    '''''''''''''''''''''''''''''''''''''''''''''''' '''''''''''''''''''''''''''''''''''''''''''''''' 
                Case Else
                    Console.WriteLine("輸入錯誤!!")

            End Select
        Loop

        Main()

    End Sub
End Module