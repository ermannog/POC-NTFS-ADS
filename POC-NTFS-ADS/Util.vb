Public NotInheritable Class Util
    Private Sub New()
        MyBase.New()
    End Sub

    Public Shared Function GetApplicationIcon() As System.Drawing.Icon
        Return System.Drawing.Icon.ExtractAssociatedIcon(
            System.Reflection.Assembly.GetEntryAssembly().Location)
    End Function
End Class
