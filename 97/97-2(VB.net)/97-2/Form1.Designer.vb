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
        Me.ISBN13 = New System.Windows.Forms.TextBox
        Me.ISBN10 = New System.Windows.Forms.TextBox
        Me.l2 = New System.Windows.Forms.Label
        Me.l1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.InputBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ISBN13
        '
        Me.ISBN13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ISBN13.Location = New System.Drawing.Point(97, 145)
        Me.ISBN13.MaxLength = 17
        Me.ISBN13.Name = "ISBN13"
        Me.ISBN13.Size = New System.Drawing.Size(164, 26)
        Me.ISBN13.TabIndex = 13
        '
        'ISBN10
        '
        Me.ISBN10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ISBN10.Location = New System.Drawing.Point(97, 119)
        Me.ISBN10.MaxLength = 13
        Me.ISBN10.Name = "ISBN10"
        Me.ISBN10.Size = New System.Drawing.Size(141, 26)
        Me.ISBN10.TabIndex = 12
        '
        'l2
        '
        Me.l2.AutoSize = True
        Me.l2.Location = New System.Drawing.Point(38, 153)
        Me.l2.Name = "l2"
        Me.l2.Size = New System.Drawing.Size(50, 13)
        Me.l2.TabIndex = 11
        Me.l2.Text = "ISBN-13:"
        '
        'l1
        '
        Me.l1.AutoSize = True
        Me.l1.Location = New System.Drawing.Point(38, 127)
        Me.l1.Name = "l1"
        Me.l1.Size = New System.Drawing.Size(50, 13)
        Me.l1.TabIndex = 10
        Me.l1.Text = "ISBN-10:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(64, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(197, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "計算ISBN檢查號"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'InputBox
        '
        Me.InputBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.InputBox.Location = New System.Drawing.Point(124, 17)
        Me.InputBox.MaxLength = 13
        Me.InputBox.Name = "InputBox"
        Me.InputBox.Size = New System.Drawing.Size(137, 26)
        Me.InputBox.TabIndex = 8
        Me.InputBox.Text = "957857358"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "請輸入9位數數字"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 188)
        Me.Controls.Add(Me.ISBN13)
        Me.Controls.Add(Me.ISBN10)
        Me.Controls.Add(Me.l2)
        Me.Controls.Add(Me.l1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.InputBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "97年工科技藝競賽第2題"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ISBN13 As System.Windows.Forms.TextBox
    Friend WithEvents ISBN10 As System.Windows.Forms.TextBox
    Friend WithEvents l2 As System.Windows.Forms.Label
    Friend WithEvents l1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents InputBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
