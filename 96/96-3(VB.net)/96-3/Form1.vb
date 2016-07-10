Public Class Form1
    Dim pi As Double = 4 * Math.Atan(1)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim R, G, B As Double
        R = Val(TextR.Text)
        G = Val(TextG.Text)
        B = Val(TextB.Text)
        Dim RSum, GSum, BSum, Sum As Double
        Sum = R + G + B
        RSum = R / Sum
        GSum = G / Sum
        BSum = B / Sum
        Dim UPcalc As Double = 0.5 * (2 * RSum - GSum - BSum)
        Dim Dncalc As Double = ((RSum - GSum) ^ 2 + (RSum - BSum) * (GSum - BSum)) ^ 0.5
        Dim h As Double = Math.Acos(UPcalc / Dncalc)
        If BSum > GSum Then
            h = 2 * pi - Math.Acos(UPcalc / Dncalc)
        End If
        If Sum = 0 Or Dncalc = 0 Then h = 0
        TextH.Text = Math.Round(h * 180 / pi * 100) / 100
        Dim ss As Double = 0
        If Sum > 0 Then
            ss = 1 - 3 * min(R, G, B) / Sum
        End If
        TextS.Text = Math.Round(ss * 255 * 100) / 100
        Dim ii As Double = (R + G + B) / 3
        TextI.Text = Math.Round(ii * 100) / 100
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim H, S, I, Dh, Ds, Di, xx, yy, zz, R, G, B As Double
        H = Val(TextH.Text)
        S = Val(TextS.Text)
        I = Val(TextI.Text)
        Dh = H * pi / 180
        Ds = S / 255
        Di = I / 255
        If H > 120 And H <= 240 Then
            Dh -= 2 * pi / 3
        ElseIf H > 240 And H <= 360 Then
            Dh -= -4 * pi / 3
        End If
        xx = Di * (1 - Ds)
        Dim UPcalc As Double = Ds * Math.Cos(Dh)
        Dim Dncalc As Double = Math.Cos(pi / 3 - Dh)
        yy = Di * (1 + UPcalc / Dncalc)
        zz = 3 * Di - (xx + yy)
        If H <= 120 Then
            R = yy
            G = zz
            B = xx
        ElseIf H > 120 And H <= 240 Then
            R = xx
            G = yy
            B = zz
        ElseIf H > 240 And H <= 360 Then
            R = zz
            G = xx
            B = yy
        End If
        TextR.Text = Math.Round(R * 25500) / 100
        TextG.Text = Math.Round(G * 25500) / 100
        TextB.Text = Math.Round(B * 25500) / 100
    End Sub

    Function min(ByVal r As Double, ByVal g As Double, ByVal b As Double) As Double
        min = r
        If min > g Then min = g
        If min > b Then min = b
    End Function
End Class
