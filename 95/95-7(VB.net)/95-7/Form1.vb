Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim R, C, f, Z, Phase, RealNumber, imaginary, Xc As Double
        R = Val(InputR.Text)
        C = Val(InputC.Text)
        f = Val(Inputf.Text)
        Dim pi As Double = 4 * Math.Atan(1)
        Xc = 1 / (2 * pi * f * C)
        RealNumber = 1 / (1 - (2 * pi * f * R * C) ^ 2)
        imaginary = (-2 * pi * f * R * C) / (1 - (2 * pi * f * R * C) ^ 2)
        'Phase = Math.Atan(-R / Xc) * 180 / pi
        'Z = Math.Abs(Xc / (Xc ^ 2 + R ^ 2) ^ 0.5)
        Phase = Math.Atan(imaginary / RealNumber) * 180 / pi
        Z = Math.Abs(RealNumber / (imaginary ^ 2 + RealNumber ^ 2) ^ 0.5)
        Z = 20 * Math.Log10(Z)
        OutputZ.Text = Format(Z, "0.000") & "dB"
        OutputPhase.Text = Format(Phase, "0.000")
    End Sub
End Class
