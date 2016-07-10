Public Class Form1
    Dim LabelQueue() As Label
    Dim Rear, Front, Ran, QueueData(1024) As Integer
    Dim QueueMAX As Integer
    Const SQURE_WIDTH As Integer = 30
    Const INITIALIZE_NUM As Integer = 6
    Const NULL As Integer = 0

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ReDim LabelQueue(384)
        For i As Integer = 1 To INITIALIZE_NUM
            LabelQueue(i) = New Label
            With LabelQueue(i)
                .Left = SQURE_WIDTH * i
                .Top = 60
                .Width = SQURE_WIDTH
                .Height = SQURE_WIDTH
                .BackColor = Color.White
                .BorderStyle = BorderStyle.FixedSingle
                .Visible = True
                Me.Controls.Add(LabelQueue(i))
            End With
        Next
        QueueMAX = INITIALIZE_NUM
        QueueData(5) = 35
        QueueData(6) = 128
        Front = 5
        Rear = 6
        ShowNow()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If CanAdd(QueueData, QueueMAX) = True Then
            If Rear = Front And QueueData(Rear) = 0 Then
                Ran = 1 + Int(Rnd() * 999)
                MessageLabel.Text = "Add " & Str(Ran)
                QueueData(Rear) = Ran
            Else
                Rear += 1
                If Rear > QueueMAX Then Rear = 1
                Ran = 1 + Int(Rnd() * 999)
                MessageLabel.Text = "Add " & Str(Ran)
                QueueData(Rear) = Ran
            End If
        Else
            If QueueMAX >= 384 Then
                MessageLabel.Text = "Fulled."
                Exit Sub
            End If
            '增加新的label
            For i = QueueMAX + 1 To QueueMAX * 2
                LabelQueue(i) = New Label
                With LabelQueue(i)
                    .Left = SQURE_WIDTH * ((i - 1) Mod 24 + 1)
                    .Top = 60 + ((i - 1) \ 24) * SQURE_WIDTH
                    .Width = SQURE_WIDTH
                    .Height = SQURE_WIDTH
                    .BackColor = Color.White
                    .BorderStyle = BorderStyle.FixedSingle
                    .Visible = True
                    Me.Controls.Add(LabelQueue(i))
                End With
            Next
            Dim AddNumber As Integer = QueueMAX
            QueueMAX *= 2
            If Rear = AddNumber - 1 Or Front = 2 Then

            ElseIf Rear >= Front Then
                For i = AddNumber To Rear Step -1
                    QueueData(i + AddNumber) = QueueData(i)
                    QueueData(i) = 0
                Next
                Rear = Rear + AddNumber
            ElseIf Rear < Front Then
                For i = QueueMAX - AddNumber To Front Step -1
                    QueueData(i + AddNumber) = QueueData(i)
                    QueueData(i) = NULL
                Next
                Front = Front + AddNumber
            End If
            Rear += 1
            If Rear > QueueMAX Then Rear = 1
            Ran = 1 + Int(Rnd() * 999)
            MessageLabel.Text = "Add " & Str(Ran)
            QueueData(Rear) = Ran
        End If
        ShowNow()
    End Sub

    Private Sub BtnRomove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRomove.Click
        If CanRomove(QueueData, QueueMAX) = True Then
            MessageLabel.Text = "Romove " & Str(QueueData(Front))
            QueueData(Front) = 0
            If Front <> Rear Then
                Front += 1
                If Front > QueueMAX Then Front = 1
            End If
        Else
            MessageLabel.Text = "Empty."
        End If
        ShowNow()
    End Sub

    Sub ShowNow()
        Dim x As Integer
        For i As Int16 = 1 To QueueMAX
            LabelQueue(i).TextAlign = ContentAlignment.MiddleCenter
            If QueueData(i) <> 0 Then
                LabelQueue(i).Text = QueueData(i)
                x = x + 1
            Else
                LabelQueue(i).Text = ""
            End If
        Next
    End Sub

    Function CanAdd(ByVal LabelQueue() As Integer, ByVal big As Integer) As Boolean
        Dim x As Integer
        CanAdd = True
        For i As Integer = 1 To big
            If LabelQueue(i) = 0 Then x = x + 1
        Next
        If x < 2 Then CanAdd = False
    End Function

    Function CanRomove(ByVal LabelQueue() As Integer, ByVal big As Integer) As Boolean
        CanRomove = False
        For i As Integer = 1 To big
            If LabelQueue(i) <> 0 Then CanRomove = True
        Next
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub
End Class
