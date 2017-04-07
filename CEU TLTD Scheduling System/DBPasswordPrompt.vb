Imports MySql.Data.MySqlClient
Imports Telerik.WinControls
Imports MySql.Data.MySqlClient.MySqlBackup


Public Class DBPasswordPrompt
    Dim CorrectDBCredentials As Boolean=False
    Private Sub btn_DBPassword_Click(sender As Object, e As EventArgs) Handles btn_DBPassword.Click
        Try
        MySQLConnCheckDBONLY.ConnectionString="server=" & My.Settings.cons_server & ";port=" & My.Settings.cons_port & ";userid=" & txt_DBUsername.text & ";password=" & txt_DBPassword.Text
        If MySQLConnCheckDBONLY.State = ConnectionState.Open Then
            MySQLConnCheckDBONLY.Close()
        End If
        MySQLConnCheckDBONLY.Open()
        CorrectDBCredentials=True
        MySQLConnCheckDBONLY.Close()
        If CorrectDBCredentials Then
            txt_DBUsername.Text=""
            txt_DBPassword.Text=""
            Dim confirm As DialogResult = RadMessageBox.Show(Me, "Are you sure you want you restore a backup?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Exclamation)
            If confirm=DialogResult.Yes
            Me.Hide
            Dim loaddb_dialog As New OpenFileDialog
            loaddb_dialog.Filter = "CEU TLTD Reservation System Backup|*.ctrsb"
            loaddb_dialog.Title = "Select a File"
                If loaddb_dialog.ShowDialog(Me) = DialogResult.OK Then
                            MySQLConnCheckDBONLY.ConnectionString = CheckDBConnstring
                            Dim mysql_LOAD As New MySqlBackup(comm)
                            mysql_LOAD.Command.Connection = MySQLConnCheckDBONLY
                            MySQLConnCheckDBONLY.Open
                            mysql_LOAD.ImportInfo.EnableEncryption = True
                            mysql_LOAD.ImportInfo.EncryptionPassword="9Wy3Z3xTApDKUtPVN+TegRLTGR2mj8_M3*3ZJwSts83g9+pL?ZLEn?3xnuMR!2g"
                            Dim archive As New Process
                            With archive
                                With .StartInfo
                                    .WindowStyle = ProcessWindowStyle.Hidden
                                    .CreateNoWindow = True
                                    .FileName = "7z.exe"
                                    .Arguments = "e " & loaddb_dialog.FileName & " -aoa -p01mc41334398j37g8u320k3x09i39jiIOUDOIPEOPnx9ud932k0la2is9395k24m096bi230lxe02k9jmc4039me"
                                End With
                                .Start()
                                .WaitForExit()
                            End With
                            mysql_LOAD.ImportFromFile("hashes.hash222")
                            Dim fileContent As New System.IO.FileInfo("hashes.hash222")
                            fileContent.Delete()
                            MySQLConnCheckDBONLY.Close
                            If reservationDBexists =False
                                Login.CheckDBStatus()
                            End If
                            Actions.Wu_RadMessageBox(1,"Database Successfully Imported.")
                  Else
                        Me.Dispose
                  End If
               Else
                Me.Dispose
               End If
            'RadMessageBox.Show(Me, "Wrong Password!!", "TLTD Scheduling System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Me.Dispose
           End If
             Catch ex As MySqlException
             If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") or ex.Message.Contains("Reading from the stream has failed")))
                Actions.Wu_RadMessageBox(4," The database probably went offline.")
                Login.log_lbl_dbstatus.Text = "Offline"
                Login.log_lbl_dbstatus.ForeColor = Color.Red
                Login.lbl_prevmain_status.Text="Unavailable"
                Login.lbl_prevmain_status.ForeColor=Color.Red
                Login.lbl_reservation_status.Text="Unavailable"
                Login.lbl_reservation_status.ForeColor=Color.Red
                Return
            ElseIf ex.Number = 0 And ex.Message.Contains("Access denied for user")
                Actions.Wu_RadMessageBox(4," Unauthorized.") 
            Else
            Actions.Wu_RadMessageBox(4,ex.Message)
            End If
        Catch ex As Exception
            Actions.Wu_RadMessageBox(4,ex.Message)
           Finally
            MySQLConnCheckDBONLY.Dispose
            Me.Dispose
           End Try
    End Sub

    Private Sub DBPasswordPrompt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose
    End Sub
End Class
