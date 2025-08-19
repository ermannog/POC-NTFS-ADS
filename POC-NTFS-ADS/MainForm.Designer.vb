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
        Me.components = New System.ComponentModel.Container()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.stsMain = New System.Windows.Forms.StatusStrip()
        Me.tslMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.lsvMain = New System.Windows.Forms.ListView()
        Me.colNTFSADSName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtKeyLog = New System.Windows.Forms.TextBox()
        Me.tsbStartStop = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tsMain.SuspendLayout()
        Me.stsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbStartStop, Me.tsbClear, Me.tsbOpen, Me.tsbDelete})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(600, 27)
        Me.tsMain.TabIndex = 0
        '
        'stsMain
        '
        Me.stsMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.stsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslMain})
        Me.stsMain.Location = New System.Drawing.Point(0, 344)
        Me.stsMain.Name = "stsMain"
        Me.stsMain.ShowItemToolTips = True
        Me.stsMain.Size = New System.Drawing.Size(600, 22)
        Me.stsMain.TabIndex = 2
        '
        'tslMain
        '
        Me.tslMain.Name = "tslMain"
        Me.tslMain.Size = New System.Drawing.Size(39, 17)
        Me.tslMain.Text = "Status"
        Me.tslMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrMain
        '
        Me.tmrMain.Interval = 2000
        '
        'lsvMain
        '
        Me.lsvMain.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNTFSADSName})
        Me.lsvMain.Dock = System.Windows.Forms.DockStyle.Right
        Me.lsvMain.FullRowSelect = True
        Me.lsvMain.HideSelection = False
        Me.lsvMain.Location = New System.Drawing.Point(394, 27)
        Me.lsvMain.Margin = New System.Windows.Forms.Padding(2)
        Me.lsvMain.MultiSelect = False
        Me.lsvMain.Name = "lsvMain"
        Me.lsvMain.ShowItemToolTips = True
        Me.lsvMain.Size = New System.Drawing.Size(206, 317)
        Me.lsvMain.TabIndex = 5
        Me.lsvMain.UseCompatibleStateImageBehavior = False
        Me.lsvMain.View = System.Windows.Forms.View.Details
        '
        'colNTFSADSName
        '
        Me.colNTFSADSName.Text = "NTFS Alternate Data Stream Name"
        Me.colNTFSADSName.Width = 181
        '
        'txtKeyLog
        '
        Me.txtKeyLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtKeyLog.HideSelection = False
        Me.txtKeyLog.Location = New System.Drawing.Point(0, 27)
        Me.txtKeyLog.Margin = New System.Windows.Forms.Padding(2)
        Me.txtKeyLog.Multiline = True
        Me.txtKeyLog.Name = "txtKeyLog"
        Me.txtKeyLog.ReadOnly = True
        Me.txtKeyLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtKeyLog.Size = New System.Drawing.Size(394, 317)
        Me.txtKeyLog.TabIndex = 6
        '
        'tsbStartStop
        '
        Me.tsbStartStop.CheckOnClick = True
        Me.tsbStartStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbStartStop.Image = Global.POC_NTFS_ADS.My.Resources.Resources.StatusRun_16x
        Me.tsbStartStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbStartStop.Name = "tsbStartStop"
        Me.tsbStartStop.Size = New System.Drawing.Size(24, 24)
        Me.tsbStartStop.ToolTipText = "Start/Stop Keylogger"
        '
        'tsbClear
        '
        Me.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbClear.Image = Global.POC_NTFS_ADS.My.Resources.Resources.ClearWindowContent_16x
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(24, 24)
        Me.tsbClear.Text = "Clear output"
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDelete.Enabled = False
        Me.tsbDelete.Image = Global.POC_NTFS_ADS.My.Resources.Resources.RemoveGuide_16x
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(24, 24)
        Me.tsbDelete.Text = "Delete selected NTFS Alternate Data Stream..."
        '
        'tsbOpen
        '
        Me.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOpen.Enabled = False
        Me.tsbOpen.Image = Global.POC_NTFS_ADS.My.Resources.Resources.OpenFile_16x
        Me.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpen.Name = "tsbOpen"
        Me.tsbOpen.Size = New System.Drawing.Size(24, 24)
        Me.tsbOpen.Text = "Open selected NTFS Alternate Data Stream with Notepad"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 366)
        Me.Controls.Add(Me.txtKeyLog)
        Me.Controls.Add(Me.lsvMain)
        Me.Controls.Add(Me.stsMain)
        Me.Controls.Add(Me.tsMain)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainForm"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.stsMain.ResumeLayout(False)
        Me.stsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsMain As ToolStrip
    Friend WithEvents tsbStartStop As ToolStripButton
    Friend WithEvents stsMain As StatusStrip
    Friend WithEvents tmrMain As Timer
    Friend WithEvents tslMain As ToolStripStatusLabel
    Friend WithEvents lsvMain As ListView
    Friend WithEvents txtKeyLog As TextBox
    Friend WithEvents colNTFSADSName As ColumnHeader
    Friend WithEvents tsbDelete As ToolStripButton
    Friend WithEvents tsbOpen As ToolStripButton
    Friend WithEvents tsbClear As ToolStripButton
End Class
