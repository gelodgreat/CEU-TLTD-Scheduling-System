Imports MySql.Data.MySqlClient
Imports Telerik.WinControls

Public Class Login
    Dim MySQLConn As New MySqlConnection
    Dim Command As MySqlCommand
    Public db_is_deadCount As Integer
    Public db_is_deadCount2 As Integer
    Dim a As Boolean = false
    

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MySQLConn.ConnectionString = connstring
        log_timer.Enabled = True
        ThemeResolutionService.ApplicationThemeName = My.Settings.WindowTheme
        log_username.Select()
        CheckDBStatus()
    End Sub



    'Login Button Codes
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Dim q2 As String
        Try
            If String.IsNullOrEmpty(log_username.Text) Or String.IsNullOrEmpty(log_password.Text) Then
                RadMessageBox.Show(Me, "Please enter username and password.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                If log_username.Text.Contains("@ceu.edu.ph") Then
                    q2 = "SELECT * FROM staff_reg WHERE staff_username=@proc_email_login and staff_password=sha2(@proc_password_login, 512)"
                Else If log_username.Text LIKE "####-#"
                    q2 = "SELECT * FROM staff_reg WHERE staff_id=@proc_email_login and staff_password=sha2(@proc_password_login, 512)"
                Else log_username.Text = log_username.Text + "@ceu.edu.ph"
                    q2 = "SELECT * FROM staff_reg WHERE staff_username=@proc_email_login and staff_password=sha2(@proc_password_login, 512)"
                End If

                If a = False Then
                    DB_DeadCounter()
                ElseIf lbl_reservation_status.Text="Unavailable" or lbl_prevmain_status.Text="Unavailable"
                    RadMessageBox.Show(Me, "Please make sure the databases are available.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                Else
                    CheckDBStatus()
                    If lbl_reservation_status.Text="Unavailable" Or lbl_prevmain_status.Text="Unavailable" Or log_lbl_dbstatus.Text="Offline"
                        Exit Sub
                    Else
                    Dim looper As Integer
                    If MysqlConn.State = ConnectionState.Open Then
                        MysqlConn.Close()
                    End If
                    mysqlconn.Open()
                    comm = New MySqlCommand(q2, mysqlconn)
                    comm.Parameters.AddWithValue("@proc_email_login", log_username.Text)
                    comm.Parameters.AddWithValue("@proc_password_login", log_password.Text)
                    Dim accountstate As Boolean
                    reader = comm.ExecuteReader
                    While reader.Read
                        looper += 1
                        username = reader.GetString("staff_username")
                        activeuserfname = reader.GetString("staff_fname")
                        activeuserlname = reader.GetString("staff_surname")
                        If reader.GetString("staff_isactive").Equals("0") Then
                            accountstate=False
                        ElseIf reader.GetString("staff_isactive").Equals("1") Then
                            accountstate=True
                        End If
                        Main.lbl_nameofstaff_reserved.Text = activeuserlname + ", " + activeuserfname
                        Main.rel_nameofstaff_release.Text = activeuserlname + ", " + activeuserfname
                        Main.ret_nameofstaff_return.Text = activeuserlname + ", " + activeuserfname
                    End While
                    mysqlconn.Close()
                    log_username.Text = String.Empty
                    log_password.Text = String.Empty
                    log_username.Select()

                    If looper = 1 And accountstate Then
                        Me.Hide()
                        My.Settings.gsmIsOn = False
                        Main.Show()
                    ElseIf looper = 1 And Not accountstate Then
                        RadMessageBox.Show(Me, "Your account is not active please inform the staff about the state of your account.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                    Else
                        RadMessageBox.Show(Me, "Incorrect Username or Password.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                 End If
                End If
              End If
            Catch ex As MySqlException
                
                a =False
            If Not(ex.Number=1042 Or ex.Number=0)
                RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
            End If
            End Try    
    End Sub

    'Codes for connection status

    Private Sub DB_DeadCounter()
        If db_is_deadCount>=3 Then
            RadMessageBox.Show(Me, "The server is still Offline." & Environment.NewLine & "Please check the connection settings by clicking the gear icon on the top right and ask the database administrator to input the required details.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            RadMessageBox.Show(Me, "The server is offline.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error,MessageBoxDefaultButton.Button1)
            db_is_deadCount +=1
        End If
    End Sub
    Private Sub log_lbl_dbstatus_MouseHover(sender As Object, e As EventArgs) Handles log_lbl_dbstatus.MouseHover,lbl_prevmain_status.MouseHover,lbl_reservation_status.MouseHover
        If a=False
            Dim aa As DialogResult = RadMessageBox.Show(Me, "The server is offline. Would you like to check again?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If aa=DialogResult.Yes
                CheckDBStatus()
                If a=True
                Else
                    db_is_deadCount+=1
                End If
            End If
        ElseIf lbl_reservation_status.Text="Unavailable" Or lbl_prevmain_status.Text="Unavailable"
            Dim confirm As DialogResult = RadMessageBox.Show(Me, "One or all of the databases are unavailable right now. Would you like to check again?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If confirm=DialogResult.Yes
                CheckDBStatus()
                If db_is_deadCount2>=5
                    RadMessageBox.Show(Me, "Please contact your database administrator to check on the database.", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)
                End If
            End If
        End If
    End Sub

    Public Sub CheckDBStatus()
        If MySQLConn.State = ConnectionState.Open Then
            MySQLConn.Close()
        End If
        Try
            MySQLConn.Open()
            a = True
            db_is_deadCount=0
            log_lbl_dbstatus.Text = "Online"
            log_lbl_dbstatus.ForeColor = Color.Green
            comm = New MySqlCommand("SELECT (SELECT COUNT(*) FROM information_schema.schemata WHERE SCHEMA_NAME='ceutltdscheduler') AS 'ceutltdscheduler_count', (SELECT COUNT(*) FROM information_schema.schemata WHERE SCHEMA_NAME='ceutltdprevmaintenance') AS 'ceuprevmaintenance_count'", MySQLConn)
            reader = comm.ExecuteReader
            While reader.Read
                If reader.GetString("ceutltdscheduler_count") = "1"
                    lbl_reservation_status.Text="Available"
                    lbl_reservation_status.ForeColor=Color.Green
                    db_is_deadCount2=0
                Else
                    lbl_reservation_status.Text="Unavailable"
                    lbl_reservation_status.ForeColor=Color.Red
                    db_is_deadCount2+=1
                End If
                If reader.GetString("ceuprevmaintenance_count") = "1"
                    lbl_prevmain_status.Text="Available"
                    lbl_prevmain_status.ForeColor=Color.Green
                    db_is_deadCount2=0
                Else
                    lbl_prevmain_status.Text="Unavailable"
                    lbl_prevmain_status.ForeColor=Color.Red
                    db_is_deadCount2+=1
                End If
            End While
            MySQLConn.Close()
        Catch ex As MySqlException
            If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Then
                a = False
                log_lbl_dbstatus.Text = "Offline"
                log_lbl_dbstatus.ForeColor = Color.Red
                lbl_reservation_status.Text="Unavailable"
                lbl_reservation_status.ForeColor=Color.Red
                lbl_prevmain_status.Text="Unavailable"
                lbl_prevmain_status.ForeColor=Color.Red
                If db_is_deadCount = 0 And btn_login.IsHandleCreated Then
                    RadMessageBox.Show(Me, "The server is offline.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                    db_is_deadCount +=1
                Else
                    DB_DeadCounter()
                End If
 
                Return
            Else
                RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Finally
            MySQLConn.Dispose()
        End Try
    End Sub

    'System Timer
    Private Sub log_timer_Tick(sender As Object, e As EventArgs) Handles log_timer.Tick
        log_lbl_date.Text = Date.Now.ToString("MMMM dd, yyyy")
        log_lbl_time.Text = Date.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub settingButton_Click(sender As Object, e As EventArgs) Handles settingButton.Click
        ConnectionWindow.ShowDialog()
    End Sub

    Private Sub settingButton_MouseHover(sender As Object, e As EventArgs) Handles settingButton.MouseHover
        settingButton.Image = New Bitmap(My.Resources.settingIcon_Hover)
        Cursor = Cursors.Hand
    End Sub

    Private Sub settingButton_MouseLeave(sender As Object, e As EventArgs) Handles settingButton.MouseLeave
        settingButton.Image = New Bitmap(My.Resources.settingIcon)
        Cursor = Cursors.Arrow
    End Sub


    Private Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If (System.Windows.Forms.Application.MessageLoop) 
        System.Windows.Forms.Application.Exit()
        Else
        System.Environment.Exit(1)
        End If
    End Sub
End Class
