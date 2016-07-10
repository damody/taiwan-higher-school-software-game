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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.InputR = New System.Windows.Forms.TextBox
        Me.InputC = New System.Windows.Forms.TextBox
        Me.Inputf = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.OutputZ = New System.Windows.Forms.TextBox
        Me.OutputPhase = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "電阻值R，單位歐姆="
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "電容值C，單位法拉="
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "頻率值f，單位赫芝="
        '
        'InputR
        '
        Me.InputR.Location = New System.Drawing.Point(135, 6)
        Me.InputR.Name = "InputR"
        Me.InputR.Size = New System.Drawing.Size(100, 20)
        Me.InputR.TabIndex = 3
        Me.InputR.Text = "1600"
        '
        'InputC
        '
        Me.InputC.Location = New System.Drawing.Point(135, 32)
        Me.InputC.Name = "InputC"
        Me.InputC.Size = New System.Drawing.Size(100, 20)
        Me.InputC.TabIndex = 4
        Me.InputC.Text = "0.000001"
        '
        'Inputf
        '
        Me.Inputf.Location = New System.Drawing.Point(135, 58)
        Me.Inputf.Name = "Inputf"
        Me.Inputf.Size = New System.Drawing.Size(100, 20)
        Me.Inputf.TabIndex = 5
        Me.Inputf.Text = "1000"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(107, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "計算"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "濾波器大小Z="
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "濾波器的相角="
        '
        'OutputZ
        '
        Me.OutputZ.Location = New System.Drawing.Point(98, 146)
        Me.OutputZ.Name = "OutputZ"
        Me.OutputZ.Size = New System.Drawing.Size(100, 20)
        Me.OutputZ.TabIndex = 9
        '
        'OutputPhase
        '
        Me.OutputPhase.Location = New System.Drawing.Point(98, 169)
        Me.OutputPhase.Name = "OutputPhase"
        Me.OutputPhase.Size = New System.Drawing.Size(100, 20)
        Me.OutputPhase.TabIndex = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(248, 209)
        Me.Controls.Add(Me.OutputPhase)
        Me.Controls.Add(Me.OutputZ)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Inputf)
        Me.Controls.Add(Me.InputC)
        Me.Controls.Add(Me.InputR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "95年工科技藝競賽第7題"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents InputR As System.Windows.Forms.TextBox
    Friend WithEvents InputC As System.Windows.Forms.TextBox
    Friend WithEvents Inputf As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OutputZ As System.Windows.Forms.TextBox
    Friend WithEvents OutputPhase As System.Windows.Forms.TextBox

End Class
