Imports System.Security.Cryptography
Imports System.Security
Imports MySql.Data.MySqlClient
Imports Telerik.WinControls

Public Class Actions
    Shared entropy As Byte() = System.Text.Encoding.Unicode.GetBytes("woprjepi0-32i-w0dowop3k2c90m4cr429j5mv430kr320-rm-32rm32-9ricm329m0329mc39mejfm209jmr09jmrxcij320cj")

    Public Shared Function EncryptString(input As System.Security.SecureString) As String
        Dim encryptedData As Byte() = Cryptography.ProtectedData.Protect(System.Text.Encoding.Unicode.GetBytes(ToInsecureString(input)), entropy, System.Security.Cryptography.DataProtectionScope.CurrentUser)
        Return Convert.ToBase64String(encryptedData)
    End Function

    Public Shared Function DecryptString(encryptedData As String) As SecureString
        Try
            Dim decryptedData As Byte() = ProtectedData.Unprotect(Convert.FromBase64String(encryptedData), entropy, System.Security.Cryptography.DataProtectionScope.CurrentUser)
            Return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData))
        Catch
            Return New SecureString()
        End Try
    End Function

    Public Shared Function ToSecureString(input As String) As SecureString
        Dim secure As New SecureString()
        For Each c As Char In input
            secure.AppendChar(c)
        Next
        secure.MakeReadOnly()
        Return secure
    End Function

    Public Shared Function ToInsecureString(input As SecureString) As String
        Dim returnValue As String = String.Empty
        Dim ptr As IntPtr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input)
        Try
            returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr)
        Finally
            System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr)
        End Try
        Return returnValue
    End Function

    Public Shared Sub SaveDB()
        Dim savedb_dialog As New SaveFileDialog()
        savedb_dialog.Filter = "mySQL Database|*.sql"
        savedb_dialog.Title = "Choose a Location to Save"
        Dim mysql_SAVE As New MySqlBackup(comm)
        mysql_SAVE.ExportInfo.AddCreateDatabase = True
        'mysql_SAVE.ExportInfo.EnableEncryption = True
        'mysql_SAVE.ExportInfo.EncryptionPassword="9Wy3Z3xTApDKUtPVN+TegRLTGR2mj8_M3*3ZJwSts83g9+pL?ZLEn?3xnuMR!2g"
        If savedb_dialog.ShowDialog() = DialogResult.OK Then
            Try
                MySQLConn.ConnectionString = connstring
                Dim mysql_LOAD As New MySqlBackup(comm)
                mysql_LOAD.Command.Connection = MySQLConn
                MySQLConn.Open()
                mysql_SAVE.ExportToFile(savedb_dialog.FileName.ToString)
                MySQLConn.Close()
                RadMessageBox.Show("Database Successfully Exported.", "TLTD Scheduling System", MessageBoxButtons.OK, RadMessageIcon.Info)
            Catch ex As MySqlException
                RadMessageBox.Show("Error in Importing Database:" & Environment.NewLine & ex.Message, "TLTD Scheduling System", MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End If
    End Sub

End Class