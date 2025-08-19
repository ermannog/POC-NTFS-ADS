Public NotInheritable Class UtilNTFSADS
    Private Sub New()
        MyBase.New()
    End Sub


    <System.Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential, CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Private Structure WIN32_FIND_STREAM_DATA
        Public StreamSize As Long
        <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=296)>
        Public cStreamName As String
    End Structure

    <System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Unicode)>
    Private Shared Function FindFirstStreamW(
        lpFileName As String,
        InfoLevel As Integer,
        ByRef lpFindStreamData As WIN32_FIND_STREAM_DATA,
        dwFlags As Integer) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Unicode)>
    Private Shared Function FindNextStreamW(
        hFindStream As IntPtr,
        ByRef lpFindStreamData As WIN32_FIND_STREAM_DATA) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function FindClose(hFindFile As IntPtr) As Boolean
    End Function

    Public Shared Function GetAlternateDataStreams(filePath As String) As List(Of String)
        Dim streams As New List(Of String)()
        Dim findStreamData As New WIN32_FIND_STREAM_DATA()
        Const FindStreamInfoStandard As Integer = 0

        Dim hFind As IntPtr = UtilNTFSADS.FindFirstStreamW(filePath, FindStreamInfoStandard, findStreamData, 0)
        If hFind = IntPtr.Zero OrElse hFind.ToInt64() = -1 Then
            Return streams ' Nessun ADS o errore
        End If

        Try
            Do
                Dim name As String = findStreamData.cStreamName.Trim()
                ' Escludi il flusso principale "::$DATA"
                If Not name.Equals("::$DATA", StringComparison.OrdinalIgnoreCase) Then
                    streams.Add(name)
                End If
            Loop While UtilNTFSADS.FindNextStreamW(hFind, findStreamData)
        Finally
            UtilNTFSADS.FindClose(hFind)
        End Try

        Return streams
    End Function

    Public Shared Function GetExecutableNTFSADSPath(streamName As String) As String
        Return "\\?\" & Application.ExecutablePath() & streamName
    End Function
End Class
