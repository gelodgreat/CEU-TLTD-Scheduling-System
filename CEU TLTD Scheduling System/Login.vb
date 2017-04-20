Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Imports Telerik.WinControls

Public Class Login
    Dim MySQLConn As New MySqlConnection
    Dim Command As MySqlCommand
    Public db_is_deadCount As Integer
    Public db_is_deadCount2 As Integer
    Dim a As Boolean = False

    Shared Sub New()
        Telerik.WinControls.RadTypeResolver.Instance.ResolveTypesInCurrentAssembly = True
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        log_timer.Enabled = True
        ThemeResolutionService.ApplicationThemeName = My.Settings.WindowTheme
        log_username.Select()
        CheckDBStatus()



        If My.Application.CommandLineArgs.Count > 0 Then
            If IsDebugMode = False Then
                For Each Argument As String In My.Application.CommandLineArgs
                    If Argument = "-debugshamwow" Then
                        Win32.AllocConsole()
                        IsDebugMode = True
                        'Logger("Welcome to CEU TLTD Reservation System")
                        Logger("Welcome to CEU TLTD Reservation System")
                        'Logger("The System has been launched with an debugshamwow Argument.")
                        Logger("The System has been launched with an debugshamwow Argument.")
                        'Logger("This is the Console Window. Closing this window wil also terminate the system.")
                        Logger("This is the Console Window. Closing this window wil also terminate the system.")
                        Logger("")
                    ElseIf Argument = "-debugshamwowsilent" Then
                        SilentDebug = True
                        'Logger("Welcome to CEU TLTD Reservation System")
                        Logger("Welcome to CEU TLTD Reservation System")
                        'Logger("The System has been launched with an debugshamwow Argument.")
                        Logger("The System has been launched with an debugshamwow Argument.")
                        'Logger("This is the Console Window. Closing this window wil also terminate the system.")
                        Logger("This is the Console Window. Closing this window wil also terminate the system.")
                        Logger("")
                    End If
                Next
            End If
            Logger("Login Window")
        End If
    End Sub



    'Login Button Codes
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Dim q2 As String
        Logger("Action: Login Button Clicked")
        Logger("Username =" & log_username.Text & "")
        Logger("Password =" & log_password.Text & "")
        Try
            MySQLConn.ConnectionString = connstring
            If String.IsNullOrEmpty(log_username.Text) Or String.IsNullOrEmpty(log_password.Text) Then
                RadMessageBox.Show(Me, "Please enter username And password.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                Logger("The Username or password Field is lacking information.")
            Else
                If log_username.Text.Contains("@ceu.edu.ph") Then
                    q2 = "Select * FROM staff_reg WHERE staff_username=@proc_email_login And staff_password=sha2(@proc_password_login, 512)"
                    Logger("The username entered contains '@ceu.edu.ph'.")
                ElseIf log_username.Text Like "####-#" Then
                    Logger("The username used is the Staff ID.")
                    q2 = "Select * FROM staff_reg WHERE staff_id=@proc_email_login And staff_password=sha2(@proc_password_login, 512)"
                Else log_username.Text = log_username.Text + "@ceu.edu.ph"
                    Logger("Username without domain. Automatically added '@ceu.edu.ph' at the end")
                    q2 = "SELECT * FROM staff_reg WHERE staff_username=@proc_email_login And staff_password=sha2(@proc_password_login, 512)"
                End If

                If a = False Then
                    DB_DeadCounter()
                ElseIf lbl_reservation_status.Text = "Unavailable" Or lbl_prevmain_status.Text = "Unavailable" Then
                    RadMessageBox.Show(Me, "Please make sure the databases are available.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                ElseIf lbl_prevmain_status.Text = "Unauthorized" Or lbl_reservation_status.Text = "Unauthorized" Then
                    RadMessageBox.Show(Me, "Unauthorized access to server.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                Else
                    CheckDBStatus()
                    If lbl_reservation_status.Text = "Unavailable" Or lbl_prevmain_status.Text = "Unavailable" Or log_lbl_dbstatus.Text = "Offline" Then
                        Exit Sub
                    Else
                        Dim looper As Integer
                        If MySQLConn.State = ConnectionState.Open Then
                            MySQLConn.Close()
                        End If
                        MySQLConn.Open()
                        comm = New MySqlCommand(q2, MySQLConn)
                        comm.Parameters.AddWithValue("@proc_email_login", log_username.Text)
                        comm.Parameters.AddWithValue("@proc_password_login", log_password.Text)
                        Logger("Run SQL query to verify username and password entered.")
                        Dim accountstate As Boolean
                        reader = comm.ExecuteReader
                        While reader.Read
                            looper += 1
                            username = reader.GetString("staff_username")
                            activeuserfname = reader.GetString("staff_fname")
                            activeuserlname = reader.GetString("staff_surname")
                            If reader.GetString("staff_isactive").Equals("0") Then
                                accountstate = False
                            ElseIf reader.GetString("staff_isactive").Equals("1") Then
                                accountstate = True
                            End If
                            Main.lbl_nameofstaff_reserved.Text = activeuserlname + ", " + activeuserfname
                            Main.rel_nameofstaff_release.Text = activeuserlname + ", " + activeuserfname
                            Main.ret_nameofstaff_return.Text = activeuserlname + ", " + activeuserfname
                        End While
                        MySQLConn.Close()
                        log_username.Text = String.Empty
                        log_password.Text = String.Empty
                        log_username.Select()

                        If looper = 1 And accountstate Then
                            Me.Hide()
                            My.Settings.gsmIsOn = False
                            Main.Show()
                        ElseIf looper = 1 And Not accountstate Then
                            RadMessageBox.Show(Me, "Your account Is Not active please inform the staff about the state of your account.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                            Logger("The Account credentials is correct but the account is not active.")
                        Else
                            RadMessageBox.Show(Me, "Incorrect Username Or Password.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                            Logger("Account credentials incorrect.")
                        End If
                    End If
                End If
            End If
        Catch ex As MySqlException
            a = False
            If Not (ex.Number = 1042 Or ex.Number = 0) Then
                RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                Logger("Exception catched on Login Sub." & ex.Message & "")
            End If
        End Try
    End Sub

    'Codes for connection status

    Private Sub DB_DeadCounter()

        If db_is_deadCount >= 3 Then
            RadMessageBox.Show(Me, "Still Unable to connect to the server.." & Environment.NewLine & "Please check the connection settings by clicking the gear icon on the top right And ask the database administrator to input the required details.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            RadMessageBox.Show(Me, "Unable to connect to the server.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
            db_is_deadCount += 1
        End If
    End Sub
    Private Sub log_lbl_dbstatus_MouseHover(sender As Object, e As EventArgs) Handles log_lbl_dbstatus.MouseHover, lbl_prevmain_status.MouseHover, lbl_reservation_status.MouseHover
        Logger("Mouse hovered on DBStatus Label.")
        If a = False And Not (lbl_prevmain_status.Text = "Unauthorized" Or lbl_reservation_status.Text = "Unauthorized") Then
            Dim aa As DialogResult = RadMessageBox.Show(Me, "Unable to connect to the server. Would you Like to check again?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If aa = DialogResult.Yes Then
                CheckDBStatus()
                If a = True Then
                Else
                    db_is_deadCount += 1
                End If
            End If
        ElseIf lbl_reservation_status.Text = "Unavailable" Or lbl_prevmain_status.Text = "Unavailable" Then
            Dim confirm As DialogResult = RadMessageBox.Show(Me, "One Or all of the databases are unavailable right now. Would you Like to check again?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If confirm = DialogResult.Yes Then
                CheckDBStatus()
                If db_is_deadCount2 >= 5 Then
                    RadMessageBox.Show(Me, "Please contact your database administrator to check on the database.", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)
                End If
            End If
        ElseIf lbl_prevmain_status.Text = "Unauthorized" Or lbl_reservation_status.Text = "Unauthorized" Then
        End If
    End Sub

    Public Sub CheckDBStatus()
        Logger("Check Database if exists.")
        If MySQLConnCheckDBONLY.State = ConnectionState.Open Then
            MySQLConnCheckDBONLY.Close()
        End If
        Try
            MySQLConnCheckDBONLY.ConnectionString = CheckDBConnstring
            MySQLConnCheckDBONLY.Open()
            a = True
            db_is_deadCount = 0
            log_lbl_dbstatus.Text = "Online"
            log_lbl_dbstatus.ForeColor = Color.Green
            comm = New MySqlCommand("SELECT (SELECT COUNT(*) FROM information_schema.schemata WHERE SCHEMA_NAME='ceutltdscheduler') AS 'ceutltdscheduler_count', (SELECT COUNT(*) FROM information_schema.schemata WHERE SCHEMA_NAME='ceutltdprevmaintenance') AS 'ceuprevmaintenance_count'", MySQLConnCheckDBONLY)
            reader = comm.ExecuteReader
            While reader.Read
                If reader.GetString("ceutltdscheduler_count") = "1" Then
                    Logger("TLTD Reservation System database exists.")
                    lbl_reservation_status.Text = "Available"
                    lbl_reservation_status.ForeColor = Color.Green
                    db_is_deadCount2 = 0
                    reservationDBexists = True
                Else
                    Logger("TLTD Reservation System database does not exist.")
                    lbl_reservation_status.Text = "Unavailable"
                    lbl_reservation_status.ForeColor = Color.Red
                    reservationDBexists = False
                    db_is_deadCount2 += 1
                End If
                If reader.GetString("ceuprevmaintenance_count") = "1" Then
                    Logger("TLTD Preventive Maintenance System database exists.")
                    lbl_prevmain_status.Text = "Available"
                    lbl_prevmain_status.ForeColor = Color.Green
                    db_is_deadCount2 = 0
                Else
                    Logger("TLTD Preventive Maintenance System database does not exist exist.")
                    lbl_prevmain_status.Text = "Unavailable"
                    lbl_prevmain_status.ForeColor = Color.Red
                    db_is_deadCount2 += 1
                End If
            End While
            MySQLConnCheckDBONLY.Close()
        Catch ex As MySqlException
            If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Then
                a = False
                log_lbl_dbstatus.Text = "Offline"
                log_lbl_dbstatus.ForeColor = Color.Red
                lbl_reservation_status.Text = "Unavailable"
                lbl_reservation_status.ForeColor = Color.Red
                lbl_prevmain_status.Text = "Unavailable"
                lbl_prevmain_status.ForeColor = Color.Red
                If db_is_deadCount = 0 And btn_login.IsHandleCreated Then
                    RadMessageBox.Show(Me, "Unable to connect to the server.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                    db_is_deadCount += 1
                Else
                    DB_DeadCounter()
                End If

                Return
            ElseIf ex.Number = 0 And ex.Message.Contains("Access denied for user") Then
                log_lbl_dbstatus.Text = "Online"
                log_lbl_dbstatus.ForeColor = Color.Green
                lbl_reservation_status.Text = "Unauthorized"
                lbl_reservation_status.ForeColor = Color.Red
                lbl_prevmain_status.Text = "Unauthorized"
                lbl_prevmain_status.ForeColor = Color.Red

                If My.Settings.cons_server = "" And My.Settings.cons_port = "" And Actions.ToInsecureString(Actions.DecryptString(My.Settings.cons_password)) = "" And Actions.ToInsecureString(Actions.DecryptString(My.Settings.cons_username)) = "" Then
                    RadMessageBox.Show(Me, "Please check the connection settings to the database.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Else
                    RadMessageBox.Show(Me, "Unauthorized access to server.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                End If
            Else
                RadMessageBox.Show(Me, ex.Message & "  " & ex.Number, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Finally
            MySQLConnCheckDBONLY.Dispose()
        End Try
    End Sub

    'System Timer
    Private Sub log_timer_Tick(sender As Object, e As EventArgs) Handles log_timer.Tick
        log_lbl_date.Text = Date.Now.ToString("MMMM dd, yyyy")
        log_lbl_time.Text = Date.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub settingButton_Click(sender As Object, e As EventArgs) Handles settingButton.Click
        Logger("Database Connection Cinfiguration button Clicked")
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
        If (System.Windows.Forms.Application.MessageLoop) Then
            System.Windows.Forms.Application.Exit()
            Logger("The System has been terminated")
        Else
            System.Environment.Exit(1)
            Logger("The System has been terminated with exit code 1")
        End If
    End Sub

    Private Sub Login_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Logger("F1 Pressed")
            If IO.File.Exists("help.chm") Then
                Actions.showHelp(Me, "5")
                Logger("Check if help.chm exists.")
            Else
                Logger("The help.chm file does not exist.")
                RadMessageBox.Show(Me, "Required file for help not found. Re-installing might solve the problem.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                Exit Sub
            End If
        End If
    End Sub
    'Console for Debugging
    Public Class Win32
        <DllImport("kernel32.dll")> Public Shared Function AllocConsole() As Boolean
        End Function
        <DllImport("kernel32.dll")> Public Shared Function FreeConsole() As Boolean
        End Function
    End Class
End Class
