﻿Imports MySql.Data.MySqlClient
Imports Telerik.WinControls

Public Class Login
    Dim mysqlconn As MySqlConnection
    Dim Command As MySqlCommand
    Dim a As Boolean

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timerandstatus()
        ThemeResolutionService.ApplicationThemeName = My.Settings.WindowTheme
        log_username.Select()
    End Sub


    'Login Button Codes
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If String.IsNullOrEmpty(log_username.Text) Or String.IsNullOrEmpty(log_password.Text) Then
            RadMessageBox.Show(Me, "Please enter username and password.", "Login", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)

        Else
            Try
                Dim looper As Integer
                If ConnectionState.Open = True Then
                    mysqlconn.Close()
                End If

                mysqlconn.Open()
                Dim q2 As String = "SELECT * FROM staff_reg WHERE BINARY staff_username=@proc_email_login and staff_password=sha2(@proc_password_login, 512)"
                comm = New MySqlCommand(q2, mysqlconn)
                comm.Parameters.AddWithValue("@proc_email_login", log_username.Text)
                comm.Parameters.AddWithValue("@proc_password_login", log_password.Text)
                reader = comm.ExecuteReader
                While reader.Read
                    looper += 1
                    username = reader.GetString("staff_username")
                    activeuserfname = reader.GetString("staff_fname")
                    activeuserlname = reader.GetString("staff_surname")
                    Main.lbl_nameofstaff_reserved.Text = activeuserlname + " " + activeuserfname
                    Main.rel_nameofstaff_release.Text = activeuserlname + " " + activeuserfname
                    Main.ret_nameofstaff_return.Text = activeuserlname + " " + activeuserfname
                End While
                mysqlconn.Close()
                log_username.Text = String.Empty
                log_password.Text = String.Empty
                log_username.Select()

                If looper = 1 Then
                    Me.Hide()
                    Main.Show()
                Else
                    RadMessageBox.Show(Me, "Incorrect Username or Password.", "Login", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As MySqlException
                RadMessageBox.Show(Me, ex.Message, "Login", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End If
    End Sub

    'Codes for timer and connection status
    Public Sub timerandstatus()

        'Timer
        log_timer.Enabled = True

        'Online/Offline Status
        a = New Boolean
        a = False
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = connstring

        Try
            mysqlconn.Open()
            a = True
            mysqlconn.Close()
        Catch ex As Exception

        Finally
            mysqlconn.Dispose()
            If a = True Then
                log_lbl_dbstatus.Text = "Online"
                log_lbl_dbstatus.ForeColor = Color.Green
            Else
                log_lbl_dbstatus.Text = "Offline"
                log_lbl_dbstatus.ForeColor = Color.Red
            End If

        End Try
    End Sub

    'System Timer
    Private Sub log_timer_Tick(sender As Object, e As EventArgs) Handles log_timer.Tick
        log_lbl_date.Text = Date.Now.ToString("MMMM dd, yyyy")
        log_lbl_time.Text = Date.Now.ToString("hh:mm:ss tt")
    End Sub

    'Theme Changer
    Private Sub btn_vslight_Click(sender As Object, e As EventArgs) Handles btn_vslight.Click
        ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Light"
        SaveTheme()
    End Sub

    Private Sub btn_vsdark_Click(sender As Object, e As EventArgs) Handles btn_vsdark.Click
        ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark"
        SaveTheme()
    End Sub

    Private Sub btn_metrotheme_Click(sender As Object, e As EventArgs) Handles btn_metrotheme.Click
        ThemeResolutionService.ApplicationThemeName = "TelerikMetro"
        SaveTheme()
    End Sub

    Private Sub btn_officelight_Click(sender As Object, e As EventArgs) Handles btn_metroblue.Click
        ThemeResolutionService.ApplicationThemeName = "TelerikMetroBlue"
        SaveTheme()
    End Sub

    Private Sub btn_aqua_Click(sender As Object, e As EventArgs) Handles btn_w8.Click
        ThemeResolutionService.ApplicationThemeName = "Windows8"
        SaveTheme()
    End Sub

    Private Sub SaveTheme()
        My.Settings.WindowTheme = ThemeResolutionService.ApplicationThemeName
        My.Settings.Save()
    End Sub

    Private Sub btn_bypass_log_Click(sender As Object, e As EventArgs) Handles btn_bypass_log.Click
        Main.Show()
        Me.Hide()
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


End Class
