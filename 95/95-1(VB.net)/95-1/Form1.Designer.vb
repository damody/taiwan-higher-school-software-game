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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.InputBox = New System.Windows.Forms.TextBox
        Me.OutputBox1 = New System.Windows.Forms.Label
        Me.OutputBox2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(51, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(422, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "計算及產生質數個數"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "請輸入一正整數"
        '
        'InputBox
        '
        Me.InputBox.Location = New System.Drawing.Point(210, 25)
        Me.InputBox.Name = "InputBox"
        Me.InputBox.Size = New System.Drawing.Size(100, 20)
        Me.InputBox.TabIndex = 2
        Me.InputBox.Text = "10000"
        '
        'OutputBox1
        '
        Me.OutputBox1.AutoSize = True
        Me.OutputBox1.Location = New System.Drawing.Point(72, 106)
        Me.OutputBox1.Name = "OutputBox1"
        Me.OutputBox1.Size = New System.Drawing.Size(67, 13)
        Me.OutputBox1.TabIndex = 3
        Me.OutputBox1.Text = "質數個數有"
        '
        'OutputBox2
        '
        Me.OutputBox2.AutoSize = True
        Me.OutputBox2.Location = New System.Drawing.Point(72, 137)
        Me.OutputBox2.Name = "OutputBox2"
        Me.OutputBox2.Size = New System.Drawing.Size(97, 13)
        Me.OutputBox2.TabIndex = 4
        Me.OutputBox2.Text = "最大的3個質數是"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 188)
        Me.Controls.Add(Me.OutputBox2)
        Me.Controls.Add(Me.OutputBox1)
        Me.Controls.Add(Me.InputBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "95年工科技藝競賽第1題"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents InputBox As System.Windows.Forms.TextBox
    Friend WithEvents OutputBox1 As System.Windows.Forms.Label
    Friend WithEvents OutputBox2 As System.Windows.Forms.Label

End Class
