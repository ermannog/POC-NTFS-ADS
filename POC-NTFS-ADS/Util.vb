Imports System.Security.Cryptography
Imports System.Text

Public NotInheritable Class Util
    Private Sub New()
        MyBase.New()
    End Sub

    Public Shared Function GetApplicationIcon() As System.Drawing.Icon
        Return System.Drawing.Icon.ExtractAssociatedIcon(
            System.Reflection.Assembly.GetEntryAssembly().Location)
    End Function

    Public Shared Function GetMD5HashFromString(input As String) As String
        Using md5 As MD5 = MD5.Create()
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hashBytes As Byte() = md5.ComputeHash(inputBytes)
            Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
        End Using
    End Function

#Region "Method ShowMessage"
    Public Overloads Shared Function ShowMessage(ByVal text As String) As System.Windows.Forms.DialogResult
        Return ShowMessage(text, String.Empty)
    End Function

    Public Overloads Shared Function ShowMessage(ByVal text As String, ByVal title As String) As System.Windows.Forms.DialogResult
        Return ShowMessage(text, title, System.Windows.Forms.MessageBoxIcon.None)
    End Function

    Public Overloads Shared Function ShowMessage(ByVal text As String,
                ByVal icon As System.Windows.Forms.MessageBoxIcon) As System.Windows.Forms.DialogResult
        Return ShowMessage(text, String.Empty, icon)
    End Function

    Public Overloads Shared Function ShowMessage(ByVal text As String,
                                  ByVal title As String,
                                  ByVal icon As System.Windows.Forms.MessageBoxIcon) As System.Windows.Forms.DialogResult
        Return ShowMessage(text, title, System.Windows.Forms.MessageBoxButtons.OK, icon, System.Windows.Forms.MessageBoxDefaultButton.Button1)
    End Function

    Public Overloads Shared Function ShowMessage(ByVal text As String,
                                  ByVal title As String,
                                  ByVal buttons As System.Windows.Forms.MessageBoxButtons,
                                  ByVal icon As System.Windows.Forms.MessageBoxIcon,
                                  ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        ShowMessage = System.Windows.Forms.MessageBox.Show(text,
            My.Application.Info.Title & " " & title,
            buttons, icon, defaultButton)
    End Function
#End Region

#Region "Metodo Question"
    Public Overloads Shared Function ShowQuestion(ByVal text As String) As System.Windows.Forms.DialogResult
        Return ShowQuestion(text, System.Windows.Forms.MessageBoxButtons.YesNo)
    End Function

    Public Overloads Shared Function ShowQuestion(ByVal text As String, ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        Return ShowQuestion(text, System.Windows.Forms.MessageBoxButtons.YesNo, defaultButton)
    End Function

    Public Overloads Shared Function ShowQuestion(ByVal text As String,
                                    ByVal buttons As System.Windows.Forms.MessageBoxButtons) As System.Windows.Forms.DialogResult
        Return ShowQuestion(text, buttons, System.Windows.Forms.MessageBoxDefaultButton.Button2)
    End Function

    Public Overloads Shared Function ShowQuestion(ByVal text As String,
                                              ByVal buttons As System.Windows.Forms.MessageBoxButtons,
                                              ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton) As System.Windows.Forms.DialogResult
        Return ShowMessage(text, String.Empty, buttons, System.Windows.Forms.MessageBoxIcon.Question, defaultButton)
    End Function
#End Region

End Class
