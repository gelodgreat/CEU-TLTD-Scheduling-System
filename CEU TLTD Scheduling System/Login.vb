Imports MySql.Data.MySqlClient
Imports Telerik.WinControls

Public Class Login
    Dim mysqlconn As MySqlConnection
    Dim Command As MySqlCommand
    Dim a As Boolean

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timerandstatus()
    End Sub


    'Login Button Codes


    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Main.Show()
        Me.Hide()
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
        log_lbl_timer.Text = Date.Now.ToString("MMMM dd yyyy hh:mm:ss tt")
    End Sub

    'Theme Changer
    Private Sub btn_vslight_Click(sender As Object, e As EventArgs) Handles btn_vslight.Click
        ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Light"
    End Sub

    Private Sub btn_vsdark_Click(sender As Object, e As EventArgs) Handles btn_vsdark.Click
        ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark"
    End Sub

    Private Sub btn_metrotheme_Click(sender As Object, e As EventArgs) Handles btn_metrotheme.Click
        ThemeResolutionService.ApplicationThemeName = "TelerikMetro"
    End Sub

    Private Sub btn_officelight_Click(sender As Object, e As EventArgs) Handles btn_metroblue.Click
        ThemeResolutionService.ApplicationThemeName = "TelerikMetroBlue"
    End Sub

    Private Sub btn_aqua_Click(sender As Object, e As EventArgs) Handles btn_w8.Click
        ThemeResolutionService.ApplicationThemeName = "Windows8"
    End Sub


End Class
