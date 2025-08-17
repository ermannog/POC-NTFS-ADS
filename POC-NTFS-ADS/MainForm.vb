Public Class MainForm

    Private KeyboardHook As New KeyboardLowLevelHook(AddressOf Me.KeyboardCallback)


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Inizializzazioni
        Me.Icon = Util.GetApplicationIcon()

        Me.SetFormText()
    End Sub

    Private Sub SetFormText()
        Me.Text = My.Application.Info.AssemblyName & " " &
            String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build) & " - " &
            My.Application.Info.Description
    End Sub

    Private Function KeyboardCallback(ByVal message As KeyboardLowLevelHook.KeyboardMessage, ByVal keyboardInputInfo As KeyboardLowLevelHook.KBDLLHOOKSTRUCT) As Boolean
        If message = KeyboardLowLevelHook.KeyboardMessage.WM_KEYDOWN OrElse
            message = KeyboardLowLevelHook.KeyboardMessage.WM_SYSKEYDOWN Then

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
        End If

        Return False
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsbStartStop.Click
        If Me.tsbStartStop.Checked Then
            Me.KeyboardHook.SetHook()
        Else
            Me.KeyboardHook.Unhook()
        End If
    End Sub
End Class
