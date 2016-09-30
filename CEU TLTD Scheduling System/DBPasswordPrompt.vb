Imports MySql.Data.MySqlClient
Imports Telerik.WinControls
Imports MySql.Data.MySqlClient.MySqlBackup

Public Class DBPasswordPrompt
    Private Sub btn_DBPassword_Click(sender As Object, e As EventArgs) Handles btn_DBPassword.Click
        If txt_DBPassword.Text = Actions.ToInsecureString(Actions.DecryptString(My.Settings.cons_password))
            txt_DBPassword.Text=""
            Me.Hide
            Dim loaddb_dialog As New OpenFileDialog()
            loaddb_dialog.Filter = "mySQL Database|*.sql"
            loaddb_dialog.Title = "Select a File"

        If loaddb_dialog.ShowDialog() = DialogResult.OK Then
               
                Try
                    MySQLConn.ConnectionString = connstring
                    Dim mysql_LOAD As New MySqlBackup(comm)
                  mysql_LOAD.Command.Connection = MySQLConn
                    MySQLConn.Open
                mysql_LOAD.ImportInfo.EnableEncryption = True
                mysql_LOAD.ImportInfo.EncryptionPassword="9Wy3Z3xTApDKUtPVN+TegRLTGR2mj8_M3*3ZJwSts83g9+pL?ZLEn?3xnuMR!2g"
                mysql_LOAD.ImportFromFile(loaddb_dialog.FileName.ToString)
                MySQLConn.Close
                RadMessageBox.Show(Me, "Database Successfully Imported.", "TLTD Scheduling System", MessageBoxButtons.OK, RadMessageIcon.Info)
            Catch ex As MySqlException
                RadMessageBox.Show(Me, "Error in Importing Database:" & Environment.NewLine & ex.Message, "TLTD Scheduling System", MessageBoxButtons.OK, RadMessageIcon.Error)
           Finally
            Me.Dispose
           End Try
                 
        End If
            Else
            txt_DBPassword.Text=""
            RadMessageBox.Show(Me, "Wrong Password!!", "TLTD Scheduling System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Me.Dispose
            End If
    End Sub

    Private Sub DBPasswordPrompt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose
    End Sub
End Class
