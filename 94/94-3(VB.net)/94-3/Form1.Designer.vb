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
        Me.OutputBox = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'OutputBox
        '
        Me.OutputBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OutputBox.Location = New System.Drawing.Point(0, 0)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.ReadOnly = True
        Me.OutputBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.OutputBox.Size = New System.Drawing.Size(479, 358)
        Me.OutputBox.TabIndex = 0
        Me.OutputBox.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 356)
        Me.Controls.Add(Me.OutputBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "94年工科技藝競賽第3題"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OutputBox As System.Windows.Forms.RichTextBox

End Class
