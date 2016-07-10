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
        Me.InputBox = New System.Windows.Forms.RichTextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.OutputBox = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'InputBox
        '
        Me.InputBox.Location = New System.Drawing.Point(12, 12)
        Me.InputBox.Name = "InputBox"
        Me.InputBox.Size = New System.Drawing.Size(195, 122)
        Me.InputBox.TabIndex = 0
        Me.InputBox.Text = "100 1/5 0.8" & Global.Microsoft.VisualBasic.ChrW(10) & "100 1/5 0.9" & Global.Microsoft.VisualBasic.ChrW(10) & "80 1/5 0.8" & Global.Microsoft.VisualBasic.ChrW(10) & "80 1/5 0.9"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 140)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "計算"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OutputBox
        '
        Me.OutputBox.Location = New System.Drawing.Point(12, 169)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.Size = New System.Drawing.Size(195, 122)
        Me.OutputBox.TabIndex = 2
        Me.OutputBox.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(220, 303)
        Me.Controls.Add(Me.OutputBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.InputBox)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "94年工科技藝競賽第4題"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InputBox As System.Windows.Forms.RichTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OutputBox As System.Windows.Forms.RichTextBox

End Class
