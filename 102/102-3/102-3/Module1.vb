Module Module1
    Dim AllWay As String
    ''' <permission>
    ''' 今張君不以謫為患
    ''' 竊會計之餘功
    ''' 而自放山水之間
    ''' 此其中宜有以過人者
    ''' 將蓬戶甕牖
    ''' 無所不快
    ''' 而況乎濯長江之清流
    ''' 挹西山之白雲
    ''' 窮耳目之勝以自適也哉
    ''' </permission>
    ''' <remarks></remarks>
    Sub Main()

        For i = 0 To 8
            AllWay &= Console.ReadLine() & vbCrLf
        Next

        Dim AllWayArray() = Split(AllWay, vbCrLf)
        Dim PerNum As String = ""
        Dim WayLong(9) As String

        For i = 0 To 8
            WayLong(i) = Strings.Mid(AllWayArray(i), 5, AllWayArray(i).Length - 4)
        Next

        Dim Way1 = Val(WayLong(0)) + Val(WayLong(1)) + Val(WayLong(4)) + Val(WayLong(8))
        Dim Way2 = Val(WayLong(0)) + Val(WayLong(1)) + Val(WayLong(3)) + Val(WayLong(7))
        Dim Way3 = Val(WayLong(0)) + Val(WayLong(2)) + Val(WayLong(5)) + Val(WayLong(7))
        Dim Way4 = Val(WayLong(0)) + Val(WayLong(2)) + Val(WayLong(6))


        Dim Sort As String = ""
        Dim min As Integer = 0
        min = Way1 : Sort = "1 2 3 6 7" : PerNum = Val(WayLong(0)) & " " & Val(WayLong(1)) & " " & Val(WayLong(4)) & " " & Val(WayLong(8))
        If Way2 < min Then min = Way2 : Sort = "1 2 3 5 7" : PerNum = Val(WayLong(0)) & " " & Val(WayLong(1)) & " " & Val(WayLong(3)) & " " & Val(WayLong(7))
        If Way3 < min Then min = Way3 : Sort = "1 2 4 5 7" : PerNum = Val(WayLong(0)) & " " & Val(WayLong(2)) & " " & Val(WayLong(5)) & " " & Val(WayLong(7))
        If Way4 < min Then min = Way4 : Sort = "1 2 4 7" : PerNum = Val(WayLong(0)) & " " & Val(WayLong(2)) & " " & Val(WayLong(6))

        Console.WriteLine("最低成本值總和:" & min & vbCrLf & "路徑次序:" & Sort & vbCrLf & "連線數值:0 " & PerNum)
        Console.Read()
        Main()
    End Sub
End Module
