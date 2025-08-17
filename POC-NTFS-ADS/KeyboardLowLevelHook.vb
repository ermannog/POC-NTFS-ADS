Public Class KeyboardLowLevelHook
    Inherits WindowsHook

#Region "Gestione Keyboard Hook"
    Public Enum KeyboardMessage As Integer
        WM_KEYDOWN = &H100
        WM_KEYUP = &H101
        WM_SYSKEYDOWN = &H104
        WM_SYSKEYUP = &H105
    End Enum

    <System.Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)>
    Public Structure KBDLLHOOKSTRUCT
        Public vkCode As System.Windows.Forms.Keys
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer

        Public Enum LowLevelKeyboardFlags As Integer
            LLKHF_EXTENDED = &H1
            LLKHF_INJECTED = &H10
            LLKHF_ALTDOWN = &H20
            LLKHF_UP = &H80
        End Enum

        Public Function TestFlag(ByVal flag As LowLevelKeyboardFlags) As Boolean
            Return (flags And flag) > 0
        End Function
    End Structure

    Private Delegate Function LowLevelKeyboardProcDelegate(ByVal code As Integer,
        ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
#End Region

#Region "Gestione Keyboard Callback"
    Public Delegate Function KeyboardDelegate(ByVal message As KeyboardLowLevelHook.KeyboardMessage,
        ByVal keyboardInputInfo As KeyboardLowLevelHook.KBDLLHOOKSTRUCT) As Boolean

    Private m_KeyboardCallback As KeyboardLowLevelHook.KeyboardDelegate
#End Region

    Public Sub New(ByVal keyboardCallback As KeyboardLowLevelHook.KeyboardDelegate)
        'Impostazione KeyboardCallback
        Me.m_KeyboardCallback = keyboardCallback
    End Sub

    Public Overrides Sub SetHook()
        MyBase.SetWindowsHook(WindowsHook.HookType.WH_KEYBOARD_LL,
            New KeyboardLowLevelHook.LowLevelKeyboardProcDelegate(AddressOf Me.LowLevelKeyboardProc),
            False)
    End Sub

    Public Overrides Function Unhook() As Boolean
        Return MyBase.UnhookWindowsHook()
    End Function

    Private Function LowLevelKeyboardProc(ByVal code As Integer, ByVal wParam As System.IntPtr, ByVal lParam As System.IntPtr) As Integer
        'Verifica necessità processamento messaggio
        If code < 0 Then Return MyBase.CallNextHook(code, wParam, lParam, False)

        'Legge la Struttura KBDLLHOOKSTRUCT
        Dim keyboardInputInfo As New KeyboardLowLevelHook.KBDLLHOOKSTRUCT

        keyboardInputInfo = CType(
            System.Runtime.InteropServices.Marshal.PtrToStructure(
                lParam, keyboardInputInfo.GetType()),
            KeyboardLowLevelHook.KBDLLHOOKSTRUCT)

        'Invoca la KeyboardCallBack
        Dim processed As Boolean
        processed = Me.m_KeyboardCallback.Invoke(
            CType(wParam.ToInt32, KeyboardLowLevelHook.KeyboardMessage),
            keyboardInputInfo)

        'Gestione valore di ritorno
        Return MyBase.CallNextHook(code, wParam, lParam, processed)
    End Function

End Class