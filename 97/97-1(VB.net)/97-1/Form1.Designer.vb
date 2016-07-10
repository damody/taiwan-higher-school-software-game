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
        Me.replot = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.tbMax = New System.Windows.Forms.TextBox
        Me.tbMin = New System.Windows.Forms.TextBox
        Me.graphs = New System.Windows.Forms.PictureBox
        CType(Me.graphs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'replot
        '
        Me.replot.Location = New System.Drawing.Point(64, 286)
        Me.replot.Name = "replot"
        Me.replot.Size = New System.Drawing.Size(75, 23)
        Me.replot.TabIndex = 17
        Me.replot.Text = "Replot"
        Me.replot.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(348, 291)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(34, 13)
        Me.label2.TabIndex = 16
        Me.label2.Text = "MaxX"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(225, 291)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(31, 13)
        Me.label1.TabIndex = 15
        Me.label1.Text = "MinX"
        '
        'tbMax
        '
        Me.tbMax.Location = New System.Drawing.Point(385, 289)
        Me.tbMax.Name = "tbMax"
        Me.tbMax.Size = New System.Drawing.Size(67, 20)
        Me.tbMax.TabIndex = 14
        Me.tbMax.Text = "20"
        '
        'tbMin
        '
        Me.tbMin.Location = New System.Drawing.Point(262, 289)
        Me.tbMin.Name = "tbMin"
        Me.tbMin.Size = New System.Drawing.Size(65, 20)
        Me.tbMin.TabIndex = 13
        Me.tbMin.Text = "-20"
        '
        'graphs
        '
        Me.graphs.Location = New System.Drawing.Point(64, 12)
        Me.graphs.Name = "graphs"
        Me.graphs.Size = New System.Drawing.Size(400, 250)
        Me.graphs.TabIndex = 12
        Me.graphs.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 343)
        Me.Controls.Add(Me.replot)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.tbMax)
        Me.Controls.Add(Me.tbMin)
        Me.Controls.Add(Me.graphs)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "97年工科技藝競賽第1題"
        CType(Me.graphs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents replot As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tbMax As System.Windows.Forms.TextBox
    Private WithEvents tbMin As System.Windows.Forms.TextBox
    Private WithEvents graphs As System.Windows.Forms.PictureBox

End Class
