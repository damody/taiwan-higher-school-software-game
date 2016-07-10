<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextI = New System.Windows.Forms.TextBox
        Me.TextB = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextS = New System.Windows.Forms.TextBox
        Me.TextG = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextH = New System.Windows.Forms.TextBox
        Me.TextR = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(194, 113)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 29)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "RGB<HSI"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(43, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 29)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "RGB>HSI"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 21)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "B"
        '
        'TextI
        '
        Me.TextI.Location = New System.Drawing.Point(194, 78)
        Me.TextI.Name = "TextI"
        Me.TextI.Size = New System.Drawing.Size(129, 20)
        Me.TextI.TabIndex = 15
        '
        'TextB
        '
        Me.TextB.Location = New System.Drawing.Point(36, 78)
        Me.TextB.Name = "TextB"
        Me.TextB.Size = New System.Drawing.Size(119, 20)
        Me.TextB.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 21)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "G"
        '
        'TextS
        '
        Me.TextS.Location = New System.Drawing.Point(194, 48)
        Me.TextS.Name = "TextS"
        Me.TextS.Size = New System.Drawing.Size(129, 20)
        Me.TextS.TabIndex = 11
        '
        'TextG
        '
        Me.TextG.Location = New System.Drawing.Point(36, 48)
        Me.TextG.Name = "TextG"
        Me.TextG.Size = New System.Drawing.Size(119, 20)
        Me.TextG.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 21)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "R"
        '
        'TextH
        '
        Me.TextH.Location = New System.Drawing.Point(194, 18)
        Me.TextH.Name = "TextH"
        Me.TextH.Size = New System.Drawing.Size(129, 20)
        Me.TextH.TabIndex = 8
        '
        'TextR
        '
        Me.TextR.Location = New System.Drawing.Point(36, 18)
        Me.TextR.Name = "TextR"
        Me.TextR.Size = New System.Drawing.Size(119, 20)
        Me.TextR.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(329, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 21)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = " I"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(329, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 21)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "S"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(329, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 21)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "H"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 160)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextI)
        Me.Controls.Add(Me.TextB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextS)
        Me.Controls.Add(Me.TextG)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextH)
        Me.Controls.Add(Me.TextR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "96年工科技藝競賽第3題"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextI As System.Windows.Forms.TextBox
    Friend WithEvents TextB As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextS As System.Windows.Forms.TextBox
    Friend WithEvents TextG As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextH As System.Windows.Forms.TextBox
    Friend WithEvents TextR As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
