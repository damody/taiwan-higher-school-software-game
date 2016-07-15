Module Module1
    Sub Main()
        Dim Choose As String

        Console.WriteLine("請選擇操作項目:")
        Console.WriteLine("       (1)批次輸入:")
        Console.WriteLine("       (2)選手查詢:")
        Console.WriteLine("       (3)刪除:")
        Console.WriteLine("       (4)逐筆輸入:")
        Console.WriteLine("       (5)顯示所有資料:")
        Console.Write("請選擇:")

        Do
            Choose = Console.Read()

            Select Case Chr(Choose)
                Case Is = "1"
                    Console.WriteLine("批次輸入，")
                    Exit Do
                Case Is = "2"
                    Console.WriteLine("選手查詢，")
                    Console.WriteLine("請輸入 班級、學號、姓名:")
                    Exit Do
                Case Is = "3"
                    Console.WriteLine("刪除，")
                    Exit Do
                Case Is = "4"
                    Console.WriteLine("逐筆輸入，")
                    Exit Do
                Case Is = "5"
                    Console.WriteLine("顯示所有資料，")
                Case Else
                    Console.WriteLine("輸入錯誤!!")
            End Select
        Loop
        Console.ReadKey()
        Console.ReadKey()
    End Sub
End Module
