<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbStartStop = New System.Windows.Forms.ToolStripButton()
        Me.txtKeyLog = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbStartStop})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbStartStop
        '
        Me.tsbStartStop.CheckOnClick = True
        Me.tsbStartStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbStartStop.Image = CType(resources.GetObject("tsbStartStop.Image"), System.Drawing.Image)
        Me.tsbStartStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbStartStop.Name = "tsbStartStop"
        Me.tsbStartStop.Size = New System.Drawing.Size(24, 24)
        Me.tsbStartStop.ToolTipText = "Start/Stop Keylogger"
        '
        'txtKeyLog
        '
        Me.txtKeyLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtKeyLog.Location = New System.Drawing.Point(0, 27)
        Me.txtKeyLog.Multiline = True
        Me.txtKeyLog.Name = "txtKeyLog"
        Me.txtKeyLog.ReadOnly = True
        Me.txtKeyLog.Size = New System.Drawing.Size(800, 423)
        Me.txtKeyLog.TabIndex = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtKeyLog)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "MainForm"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbStartStop As ToolStripButton
    Friend WithEvents txtKeyLog As TextBox
End Class
