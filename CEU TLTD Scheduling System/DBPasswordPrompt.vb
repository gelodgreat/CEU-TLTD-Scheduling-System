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
                    Actions.Wu_RadMessageBox(1,"Database Successfully Imported.")
             Catch ex As MySqlException
             If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") or ex.Message.Contains("Reading from the stream has failed")))
                Actions.Wu_RadMessageBox(4," The database probably went offline.")
                Login.log_lbl_dbstatus.Text = "Offline"
                Login.log_lbl_dbstatus.ForeColor = Color.Red
                Return
            Else
            Actions.Wu_RadMessageBox(4,ex.Message)
            End If
        Catch ex As Exception
            Actions.Wu_RadMessageBox(4,ex.Message)
           Finally
            Me.Dispose
           End Try
                 
        End If
            Else
            txt_DBPassword.Text=""
            Actions.Wu_RadMessageBox(4,"Wrong Password!!")
            'RadMessageBox.Show(Me, "Wrong Password!!", "TLTD Scheduling System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Me.Dispose
            End If
    End Sub

    Private Sub DBPasswordPrompt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose
    End Sub
End Class
