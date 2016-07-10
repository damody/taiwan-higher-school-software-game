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
        Me.PublicKey1 = New System.Windows.Forms.TextBox
        Me.PublicKey2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.InputBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.OutputBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.InputBox2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.OutputBox2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PrivateKey2 = New System.Windows.Forms.TextBox
        Me.PrivateKey1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "公開金錀"
        '
        'PublicKey1
        '
        Me.PublicKey1.Location = New System.Drawing.Point(74, 6)
        Me.PublicKey1.Name = "PublicKey1"
        Me.PublicKey1.Size = New System.Drawing.Size(100, 20)
        Me.PublicKey1.TabIndex = 1
        Me.PublicKey1.Text = "8315"
        '
        'PublicKey2
        '
        Me.PublicKey2.Location = New System.Drawing.Point(180, 6)
        Me.PublicKey2.Name = "PublicKey2"
        Me.PublicKey2.Size = New System.Drawing.Size(100, 20)
        Me.PublicKey2.TabIndex = 2
        Me.PublicKey2.Text = "68269"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "明文"
        '
        'InputBox1
        '
        Me.InputBox1.Location = New System.Drawing.Point(74, 51)
        Me.InputBox1.Name = "InputBox1"
        Me.InputBox1.Size = New System.Drawing.Size(206, 20)
        Me.InputBox1.TabIndex = 4
        Me.InputBox1.Text = "電腦軟體設計"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "密文"
        '
        'OutputBox1
        '
        Me.OutputBox1.Location = New System.Drawing.Point(74, 92)
        Me.OutputBox1.Name = "OutputBox1"
        Me.OutputBox1.Size = New System.Drawing.Size(635, 20)
        Me.OutputBox1.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(311, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "加密"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(311, 211)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "解密"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'InputBox2
        '
        Me.InputBox2.Location = New System.Drawing.Point(74, 173)
        Me.InputBox2.Name = "InputBox2"
        Me.InputBox2.Size = New System.Drawing.Size(635, 20)
        Me.InputBox2.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "密文"
        '
        'OutputBox2
        '
        Me.OutputBox2.Location = New System.Drawing.Point(74, 214)
        Me.OutputBox2.Name = "OutputBox2"
        Me.OutputBox2.Size = New System.Drawing.Size(206, 20)
        Me.OutputBox2.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "明文"
        '
        'PrivateKey2
        '
        Me.PrivateKey2.Location = New System.Drawing.Point(180, 134)
        Me.PrivateKey2.Name = "PrivateKey2"
        Me.PrivateKey2.Size = New System.Drawing.Size(100, 20)
        Me.PrivateKey2.TabIndex = 10
        Me.PrivateKey2.Text = "68269"
        '
        'PrivateKey1
        '
        Me.PrivateKey1.Location = New System.Drawing.Point(74, 134)
        Me.PrivateKey1.Name = "PrivateKey1"
        Me.PrivateKey1.Size = New System.Drawing.Size(100, 20)
        Me.PrivateKey1.TabIndex = 9
        Me.PrivateKey1.Text = "9907"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "私密金錀"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 269)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.InputBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.OutputBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PrivateKey2)
        Me.Controls.Add(Me.PrivateKey1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.OutputBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.InputBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PublicKey2)
        Me.Controls.Add(Me.PublicKey1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "96年工科技藝競賽第6題"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PublicKey1 As System.Windows.Forms.TextBox
    Friend WithEvents PublicKey2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents InputBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OutputBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents InputBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OutputBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PrivateKey2 As System.Windows.Forms.TextBox
    Friend WithEvents PrivateKey1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
