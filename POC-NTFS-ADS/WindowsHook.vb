Public MustInherit Class WindowsHook

#Region "Win32Api"
    Protected Enum HookType
        WH_JOURNALRECORD = 0
        WH_JOURNALPLAYBACK = 1
        WH_KEYBOARD = 2
        WH_GETMESSAGE = 3
        WH_CALLWNDPROC = 4
        WH_CBT = 5
        WH_SYSMSGFILTER = 6
        WH_MOUSE = 7
        WH_HARDWARE = 8
        WH_DEBUG = 9
        WH_SHELL = 10
        WH_FOREGROUNDIDLE = 11
        WH_CALLWNDPROCRET = 12
        WH_KEYBOARD_LL = 13
        WH_MOUSE_LL = 14
    End Enum

    <System.Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function SetWindowsHookEx(
        ByVal idHook As HookType,
        ByVal lpfn As System.Delegate,
        ByVal hMod As IntPtr,
        ByVal dwThreadId As Integer) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function UnhookWindowsHookEx(ByVal hHook As System.IntPtr) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function CallNextHookEx _
             (ByVal hhk As IntPtr, ByVal nCode As Integer,
              ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function
#End Region

    <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)>
    Private m_HookCallback As System.Delegate

    Private m_HookCallbackHandle As System.IntPtr = System.IntPtr.Zero

    Protected Overridable Function SetWindowsHook(ByVal hookType As WindowsHook.HookType, ByVal hookCallback As System.Delegate, ByVal onlyCurrentThread As Boolean) As System.IntPtr
        If Not Me.m_HookCallback Is Nothing Then Me.UnhookWindowsHook()

        'Impostazione Hook Callback
        Me.m_HookCallback = hookCallback

        'Modulo a cui appartiene la HookCallBack
        Dim moduleHandle As System.IntPtr
        moduleHandle = System.Runtime.InteropServices.Marshal.GetHINSTANCE(
            Me.m_HookCallback.GetType.Module)

        'Aggiunta Hook
        If onlyCurrentThread Then
            Me.m_HookCallbackHandle = WindowsHook.SetWindowsHookEx(hookType,
                Me.m_HookCallback, System.IntPtr.Zero, System.Threading.Thread.CurrentThread.ManagedThreadId)
        Else
            Me.m_HookCallbackHandle = WindowsHook.SetWindowsHookEx(hookType,
                Me.m_HookCallback, moduleHandle, 0)
        End If
    End Function

    Protected Overridable Function UnhookWindowsHook() As Boolean
        Dim returnValue As Boolean
        returnValue = WindowsHook.UnhookWindowsHookEx(Me.m_HookCallbackHandle)

        Me.m_HookCallback = Nothing
        Me.m_HookCallbackHandle = System.IntPtr.Zero

        Return returnValue
    End Function

    Protected Overridable Function CallNextHook(ByVal code As Integer,
              ByVal wParam As IntPtr, ByVal lParam As IntPtr,
              ByVal processed As Boolean) As Integer

        If processed Then
            Return 1
        Else
            Return WindowsHook.CallNextHookEx(Me.m_HookCallbackHandle, code, wParam, lParam)
        End If
    End Function

    Public MustOverride Sub SetHook()

    Public MustOverride Function Unhook() As Boolean
End Class
