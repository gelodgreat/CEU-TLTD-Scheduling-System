Imports MySql.Data.MySqlClient
Module GlobalVariableModule
    Public MySQLConn As New MySqlConnection
    Public connstring As String = "server=" & My.Settings.cons_server & ";port=" & My.Settings.cons_port & ";userid=" & Actions.ToInsecureString(Actions.DecryptString(My.Settings.cons_username)) & ";password=" & Actions.ToInsecureString(Actions.DecryptString(My.Settings.cons_password)) & ";database=" & My.Settings.cons_database
    Public comm As MySqlCommand
    Public reader As MySqlDataReader
    Public adapter As New MySqlDataAdapter
    Public activeuserfname As String
    Public activeuserlname As String
    Public username As String
    Public studno As String
    Public lc As Login
    Public db_is_deadCount As Integer=0
    
    'PENALTY Settings
    Public penalty_price As String
    Public penalty_graceperiod As String
    Public penalty_chargeinterval As String
    'PENALTY Settings

    'Delay Settings
    Public refresh_delay As Integer=My.Settings.refreshDelay
    Public search_delay As Integer=My.Settings.searchDelay
    'Delay Settings
    Public Sub applyconstringImmediately()
        connstring = "server=" & My.Settings.cons_server & ";port=" & My.Settings.cons_port & ";userid=" & Actions.ToInsecureString(Actions.DecryptString(My.Settings.cons_username)) & ";password=" & Actions.ToInsecureString(Actions.DecryptString(My.Settings.cons_password)) & ";database=" & My.Settings.cons_database
    End Sub

    Public Sub applydelaysImmediately()
        refresh_delay=My.Settings.refreshDelay
        search_delay=My.Settings.searchDelay
        Main.refresh_released_grid_list.Interval=refresh_delay
        Main.refresh_main_rgv_recordedacademicsonly.Interval=refresh_delay
    End Sub

End Module
