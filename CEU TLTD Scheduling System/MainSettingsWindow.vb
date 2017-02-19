Imports MySql.Data.MySqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class MainSettingsWindow
    Dim question As DialogResult
    Dim query As String
    Public txtven As String
    Public txtschool As String

    Public id_ven As String
    Public id_school As String

    Public random As System.Random = New System.Random


    Private Sub MainSettingsWindow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    'Start Penalty TAB
    Private Sub MainSettingsWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.FormElement.TitleBar.TitlePrimitive.StretchHorizontally = True
        Me.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleCenter
        rpv_settings_SelectedPageChanged(Me, New EventArgs()) 'TRIGGER EVENT SO THAT IT WILL LOAD WHAT IS NEEDED DEPENDING ON THE SELECTED TAB
    End Sub
    Private Sub rpv_settings_SelectedPageChanged(sender As Object, e As EventArgs) Handles rpv_settings.SelectedPageChanged
        If rpv_settings.SelectedPage Is rp_penalty Then
            Main.getFromDB_settings_penalty()
            penalty_peso_amount.Text = penalty_price
            Dim DB_GP As TimeSpan = TimeSpan.FromSeconds(penalty_graceperiod)
            Dim DB_CI As TimeSpan = TimeSpan.FromSeconds(penalty_chargeinterval)
            'MsgBox(ct1.ToString & Environment.NewLine & ct1.Days & Environment.NewLine & ct1.Hours & Environment.NewLine & ct1.Minutes & Environment.NewLine & ct1.Seconds)
            penalty_gp_day.Value = DB_GP.Days
            penalty_gp_hhmm.Value = (Date.Parse(String.Format("{0:D2}:{1:D2}:00", DB_GP.Hours, DB_GP.Minutes)))
            penalty_ci_day.Value = DB_CI.Days
            penalty_ci_hhmm.Value = (Date.Parse(String.Format("{0:D2}:{1:D2}:00", DB_CI.Hours, DB_CI.Minutes)))
            sd_time.Value = My.Settings.searchDelay.ToString
            rr_time.Value = My.Settings.refreshDelay.ToString
        ElseIf rpv_settings.SelectedPage Is rp_sms Then
            setting_gsm_toggleswitch.Value = My.Settings.gsmIsOn
        ElseIf rpv_settings.SelectedPage Is rp_listcolven
            auto_generate_id()
            load_col()
            load_ven()
        End If
    End Sub
    'Penalty TAB
    Private Sub btn_penalty_setting_save_Click(sender As Object, e As EventArgs) Handles btn_penalty_setting_save.Click
        If penalty_peso_amount.Text.Length = 0 Then
            RadMessageBox.Show(Me, "Please enter peso amount.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            Dim c As Char = penalty_peso_amount.Text(penalty_peso_amount.Text.Length - 1)
            If c = "." Then
                RadMessageBox.Show(Me, "Please fix the formatting of the peso amount.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
            Else

                Dim confirmChange As DialogResult = RadMessageBox.Show(Me, "Are you sure save the changes? This will change the charges to everyone who starts returning the equipment after clicking ""Yes"".", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button2)
                If confirmChange = DialogResult.Yes Then
                    Dim ts_gp As TimeSpan = TimeSpan.Parse(penalty_gp_day.Value.ToString & "." & penalty_gp_hhmm.Value.ToString("HH:mm"))
                    Dim ts_ci As TimeSpan = TimeSpan.Parse(penalty_ci_day.Value.ToString & "." & penalty_ci_hhmm.Value.ToString("HH:mm"))
                    Try
                        If MySQLConn.State = ConnectionState.Open Then
                            MySQLConn.Close()
                        End If
                        MySQLConn.ConnectionString = connstring
                        MySQLConn.Open()
                        Dim q As String = "UPDATE ceutltdscheduler.settings SET value=@a WHERE name='penalty_gracePeriod'; UPDATE ceutltdscheduler.settings SET value=@b WHERE name='penalty_chargeInterval'; UPDATE ceutltdscheduler.settings SET value=@c WHERE name='penalty_price';"
                        comm = New MySqlCommand(q, MySQLConn)
                        comm.Parameters.AddWithValue("@a", ts_gp.TotalSeconds)
                        comm.Parameters.AddWithValue("@b", ts_ci.TotalSeconds)
                        comm.Parameters.AddWithValue("@c", penalty_peso_amount.Text)
                        comm.ExecuteNonQuery()
                        MySQLConn.Close()
                        RadMessageBox.Show(Me, "Penalty settings sucessfully updated.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1)
                        Me.Dispose()
                    Catch ex As MySqlException
                        If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Then
                            RadMessageBox.Show(Me, "The database probably went offline.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                            Login.log_lbl_dbstatus.Text = "Offline"
                            Login.log_lbl_dbstatus.ForeColor = Color.Red
                            Return
                        Else
                            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                        End If
                    Catch ex As Exception
                        RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                    Finally
                        MySQLConn.Dispose()
                    End Try
                End If
            End If
        End If
    End Sub
    'Penalty TAB
    Private Sub penalty_peso_amount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles penalty_peso_amount.KeyPress
        If penalty_peso_amount.Text.Contains(".") Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or (e.KeyChar = vbBack))
        Else
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or (e.KeyChar = vbBack))
        End If
    End Sub
    'Penalty TAB
    Private Sub PenaltyChangeGotFocus(sender As Object, e As EventArgs) Handles penalty_gp_day.GotFocus, penalty_gp_hhmm.GotFocus, penalty_ci_day.GotFocus, penalty_ci_hhmm.GotFocus, penalty_peso_amount.GotFocus
        AcceptButton = btn_penalty_setting_save
    End Sub
    'END of Penalty TAB


    'START Delays Tab
    Private Sub DelaysGotFocus(sender As Object, e As EventArgs) Handles sd_time.GotFocus, rr_time.GotFocus
        AcceptButton = btn_delay_save
    End Sub
    Private Sub btn_delay_save_Click(sender As Object, e As EventArgs) Handles btn_delay_save.Click
        Dim delaysave As DialogResult = RadMessageBox.Show(Me, "Are you sure you want to save the changes?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1)
        If delaysave = DialogResult.Yes Then
            My.Settings.searchDelay = Convert.ToInt32(sd_time.Value)
            My.Settings.refreshDelay = Convert.ToInt32(rr_time.Value)
            My.Settings.Save()
            applydelaysImmediately()
            RadMessageBox.Show(Me, "Changes to the delay saved successfully.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1)
            Me.Dispose()
        End If
    End Sub
    'END Delays TAB

    'Start THEME SETTINGS TAB
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
    'End Theme SETTINGS TAB

    'Start SMS Tab
    Private Sub setting_gsm_toggleswitch_ValueChanged(sender As Object, e As EventArgs) Handles setting_gsm_toggleswitch.ValueChanged
        If setting_gsm_toggleswitch.Value = True Then
            lbl_sms_plsSelDev.Show()
            ddl_deviceList.Show()
        Else
            lbl_sms_plsSelDev.Hide()
            ddl_deviceList.Hide()
        End If
    End Sub

    Private Sub btn_SMS_save_Click(sender As Object, e As EventArgs) Handles btn_SMS_save.Click
        Try 'ALL MESSAGE BOXES ARE TO BE REPLACED WITH CODES FOR THE GSM MODULE
            If setting_gsm_toggleswitch.Value = True And ddl_deviceList.Visible = True Then
                If ddl_deviceList.Text = "" Then
                    RadMessageBox.Show(Me, "Please select a device." & vbNewLine & vbNewLine & "If there is no device listed, please double check if the GSM module is plugged in properly.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                Else
                    MsgBox("ADD BENDO CODES HERE - SMS Activation Thread")
                    Save_SMS_Settings()
                End If
            ElseIf setting_gsm_toggleswitch.Value = False Then
                MsgBox("ADD BENDO CODES HERE - SMS Deactivation Thread")
            Else
                MsgBox("Unhandled condition.")
            End If
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub
    'Start SMS Tab

    'Start School/College Tab
    Private Sub btn_setcollege_Click(sender As Object, e As EventArgs) Handles btn_setcollege.Click
        gb_school.Show()
        gb_input_college.Show()

        gb_venue.Hide()
        gb_input_venue.Hide()
    End Sub

    Private Sub btn_setvenue_Click(sender As Object, e As EventArgs) Handles btn_setvenue.Click
        gb_venue.Show()
        gb_input_venue.Show()

        gb_school.Hide()
        gb_input_college.Hide()
    End Sub

    Public Sub auto_generate_id()

        id_ven = Now.ToString("mmddyyy" + "-")
        id_ven = id_ven + random.Next(1, 100000).ToString

        id_school = Now.ToString("mmddyyy" + "-")
        id_school = id_school + random.Next(1, 100000).ToString

        txtschool = id_school
        txtven = id_ven

    End Sub
    'School/College Tab
    Public Sub load_col()
        Try

            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If

            MySQLConn.ConnectionString = connstring

            Dim SDA As New MySqlDataAdapter
            Dim bsource As New BindingSource
            Dim dbdataset As New DataTable

            MySQLConn.Open()
            query = "SELECT list_idschool as 'ID',list_school as 'School' FROM listschool"
            comm = New MySqlCommand(query, MySQLConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            gv_school.DataSource = bsource
            SDA.Update(dbdataset)

            MySQLConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)

        Finally
            MySQLConn.Dispose()
        End Try
    End Sub
    'School/College Tab
    Public Sub load_ven()
        Try

            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If

            MySQLConn.ConnectionString = connstring

            Dim SDA As New MySqlDataAdapter
            Dim bsource As New BindingSource
            Dim dbdataset As New DataTable

            MySQLConn.Open()
            query = "SELECT list_idvenue as 'ID',list_venue as 'Venue' FROM listvenue"
            comm = New MySqlCommand(query, MySQLConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            gv_venue.DataSource = bsource
            SDA.Update(dbdataset)

            MySQLConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)

        Finally
            MySQLConn.Dispose()
        End Try
    End Sub

    Private Sub gv_school_CellClick(sender As Object, e As GridViewCellEventArgs) Handles gv_school.CellClick
        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo

            row = Me.gv_school.Rows(e.RowIndex)
            txtschool = row.Cells("ID").Value.ToString
            col_tb_college.Text = row.Cells("School").Value.ToString
        End If
    End Sub

    Private Sub gv_venue_CellClick(sender As Object, e As GridViewCellEventArgs) Handles gv_venue.CellClick
        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo

            row = Me.gv_venue.Rows(e.RowIndex)
            txtven = row.Cells("ID").Value.ToString
            ven_tb_venue.Text = row.Cells("Venue").Value.ToString
        End If
    End Sub
    'School/College Tab
    Private Sub col_btn_add_Click(sender As Object, e As EventArgs) Handles col_btn_add.Click
        Try
            auto_generate_id()
            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If

            MySQLConn.ConnectionString = connstring

            If (col_tb_college.Text = "") Then
                RadMessageBox.Show(Me, "Please fill fields", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)

            Else

                question = RadMessageBox.Show(Me, "Are you sure you want to add this?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)

                If (question = DialogResult.Yes) Then
                    MySQLConn.Open()
                    query = "SELECT * FROM listschool WHERE list_school=@list_school"
                    comm = New MySqlCommand(query, MySQLConn)
                    comm.Parameters.AddWithValue("list_school", col_tb_college.Text)
                    reader = comm.ExecuteReader

                    Dim count As Integer
                    count = 0

                    While reader.Read
                        count += 1
                    End While

                    If count >= 1 Then
                        RadMessageBox.Show(Me, "College: " & col_tb_college.Text & " is already registered.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                    Else
                        MySQLConn.Close()
                        MySQLConn.Open()

                        query = "INSERT INTO listschool VALUES (@list_idschool,@list_school)"
                        comm = New MySqlCommand(query, MySQLConn)
                        comm.Parameters.AddWithValue("list_idschool", txtschool)
                        comm.Parameters.AddWithValue("list_school", col_tb_college.Text)
                        reader = comm.ExecuteReader
                        MySQLConn.Close()

                        RadMessageBox.Show(Me, "Successfully Saved!", system_Name, MessageBoxButtons.OK, RadMessageIcon.Info)
                        col_tb_college.Focus()
                        col_tb_college.Clear()
                    End If
                End If

            End If

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            load_col()
            auto_generate_id()
            MySQLConn.Dispose()
        End Try
    End Sub
    'School/College Tab
    Private Sub col_btn_update_Click(sender As Object, e As EventArgs) Handles col_btn_update.Click
        Try


            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If
            MySQLConn.ConnectionString = connstring

            If (col_tb_college.Text = "") Then
                RadMessageBox.Show(Me, "Please  select from  the school above.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                question = RadMessageBox.Show(Me, "Are you sure you want to update this?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)

                If (question = DialogResult.Yes) Then
                    MySQLConn.Open()


                    query = "SELECT * FROM listschool WHERE list_school=@list_school"
                    comm = New MySqlCommand(query, MySQLConn)
                    comm.Parameters.AddWithValue("list_school", col_tb_college.Text)
                    reader = comm.ExecuteReader

                    Dim count As Integer
                    count = 0

                    While reader.Read
                        count += 1
                    End While

                    If count >= 1 Then
                        RadMessageBox.Show(Me, "College: " & col_tb_college.Text & " is already registered.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Else
                        MySQLConn.Close()
                        MySQLConn.Open()

                        query = "UPDATE listschool SET list_school=@list_school WHERE list_idschool=@list_idschool"
                        comm = New MySqlCommand(query, MySQLConn)
                        comm.Parameters.AddWithValue("list_school", col_tb_college.Text)
                        comm.Parameters.AddWithValue("list_idschool", txtschool)
                        reader = comm.ExecuteReader
                        MySQLConn.Close()

                        RadMessageBox.Show(Me, "Successfully Updated!", system_Name, MessageBoxButtons.OK, RadMessageIcon.Info)
                        col_tb_college.Focus()
                        col_tb_college.Clear()
                    End If

                End If

            End If
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            load_col()
            auto_generate_id()
            MySQLConn.Dispose()
        End Try


    End Sub
    'School/College Tab
    Private Sub col_btn_delete_Click(sender As Object, e As EventArgs) Handles col_btn_delete.Click
        Try

            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If
            MySQLConn.ConnectionString = connstring


            If (col_tb_college.Text = "") Then
                RadMessageBox.Show(Me, "Please select from  the school above.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                question = RadMessageBox.Show(Me, "Are you sure you want to delete this?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)

                If (question = DialogResult.Yes) Then

                    MySQLConn.Open()

                    query = "DELETE FROm listschool WHERE list_idschool=@list_idschool"
                    comm = New MySqlCommand(query, MySQLConn)
                    comm.Parameters.AddWithValue("list_idschool", txtschool)
                    reader = comm.ExecuteReader
                    MySQLConn.Close()
                    RadMessageBox.Show(Me, "Successfully Deleted!", system_Name, MessageBoxButtons.OK, RadMessageIcon.Info)
                    col_tb_college.Focus()
                    col_tb_college.Clear()
                End If

            End If
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            load_col()
            auto_generate_id()
            MySQLConn.Dispose()
        End Try
    End Sub

    Private Sub col_btn_clear_Click(sender As Object, e As EventArgs) Handles col_btn_clear.Click
        col_tb_college.Clear()
        auto_generate_id()
    End Sub

    Private Sub ven_btn_add_Click(sender As Object, e As EventArgs) Handles ven_btn_add.Click
        Try
            auto_generate_id()
            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If

            MySQLConn.ConnectionString = connstring

            If (ven_tb_venue.Text = "") Then
                RadMessageBox.Show(Me, "Please fill fields", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)

            Else

                question = RadMessageBox.Show(Me, "Are you sure you want to add this?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)

                If (question = DialogResult.Yes) Then
                    MySQLConn.Open()
                    query = "SELECT * FROM listvenue WHERE list_venue=@list_venue"
                    comm = New MySqlCommand(query, MySQLConn)
                    comm.Parameters.AddWithValue("list_venue", ven_tb_venue.Text)
                    reader = comm.ExecuteReader

                    Dim count As Integer
                    count = 0

                    While reader.Read
                        count += 1
                    End While

                    If count >= 1 Then
                        RadMessageBox.Show(Me, "Venue: " & ven_tb_venue.Text & " is already registered.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Exclamation)

                    Else
                        MySQLConn.Close()
                        MySQLConn.Open()

                        query = "INSERT INTO listvenue VALUES (@list_idvenue,@list_venue)"
                        comm = New MySqlCommand(query, MySQLConn)
                        comm.Parameters.AddWithValue("list_idvenue", txtven)
                        comm.Parameters.AddWithValue("list_venue", ven_tb_venue.Text)
                        reader = comm.ExecuteReader
                        MySQLConn.Close()

                        RadMessageBox.Show(Me, "Successfully Saved!", system_Name, MessageBoxButtons.OK, RadMessageIcon.Info)
                        ven_tb_venue.Focus()
                        ven_tb_venue.Clear()
                    End If
                End If

            End If

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            load_ven()
            auto_generate_id()
            MySQLConn.Dispose()
        End Try
    End Sub
    'School/College Tab
    Private Sub ven_btn_update_Click(sender As Object, e As EventArgs) Handles ven_btn_update.Click
        Try
            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If
            MySQLConn.ConnectionString = connstring

            If (ven_tb_venue.Text = "") Then
                RadMessageBox.Show(Me, "Please  select from  the venue above.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                question = RadMessageBox.Show(Me, "Are you sure you want to update this?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)

                If (question = DialogResult.Yes) Then
                    MySQLConn.Open()


                    query = "SELECT * FROM listvenue WHERE list_venue=@list_venue"
                    comm = New MySqlCommand(query, MySQLConn)
                    comm.Parameters.AddWithValue("list_venue", ven_tb_venue.Text)
                    reader = comm.ExecuteReader

                    Dim count As Integer
                    count = 0

                    While reader.Read
                        count += 1
                    End While

                    If count >= 1 Then
                        RadMessageBox.Show(Me, "Venue: " & ven_tb_venue.Text & " is already registered.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Exclamation)
                    Else
                        MySQLConn.Close()
                        MySQLConn.Open()

                        query = "UPDATE listvenue SET list_venue=@list_venue WHERE list_idvenue=@list_idvenue"
                        comm = New MySqlCommand(query, MySQLConn)
                        comm.Parameters.AddWithValue("list_venue", ven_tb_venue.Text)
                        comm.Parameters.AddWithValue("list_idvenue", txtven)
                        reader = comm.ExecuteReader
                        MySQLConn.Close()

                        RadMessageBox.Show(Me, "Successfully Updated!", system_Name, MessageBoxButtons.OK, RadMessageIcon.Info)
                        ven_tb_venue.Focus()
                        ven_tb_venue.Clear()
                    End If

                End If

            End If
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            load_ven()
            auto_generate_id()
            MySQLConn.Dispose()
        End Try
    End Sub

    Private Sub ven_btn_delete_Click(sender As Object, e As EventArgs) Handles ven_btn_delete.Click
        Try

            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If
            MySQLConn.ConnectionString = connstring


            If (ven_tb_venue.Text = "") Then
                RadMessageBox.Show(Me, "Please select from the venue above.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                question = RadMessageBox.Show(Me, "Are you sure you want to delete this?", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Question)

                If (question = DialogResult.Yes) Then

                    MySQLConn.Open()

                    query = "DELETE FROm listvenue WHERE list_idvenue=@list_idvenue"
                    comm = New MySqlCommand(query, MySQLConn)
                    comm.Parameters.AddWithValue("list_idvenue", txtven)
                    reader = comm.ExecuteReader
                    MySQLConn.Close()
                    RadMessageBox.Show(Me, "Successfully Deleted!", system_Name, MessageBoxButtons.OK, RadMessageIcon.Info)
                    ven_tb_venue.Focus()
                    ven_tb_venue.Clear()
                End If

            End If
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            load_ven()
            auto_generate_id()
            MySQLConn.Dispose()
        End Try
    End Sub

    Private Sub ven_btn_clear_Click(sender As Object, e As EventArgs) Handles ven_btn_clear.Click
        ven_tb_venue.Clear()
        auto_generate_id()
    End Sub


End Class



'Private Sub btn_ChP_Click(sender As Object, e As EventArgs) Handles btn_ChP.Click
'    Dim looper As Integer = 0
'    If txt_NewPass.Text <> txt_NewPass_Confirm.Text Then
'        RadMessageBox.Show(Me, "Please double check your new password.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
'        txt_NewPass.Select()
'    ElseIf txt_CurPass.Text = "" Or txt_NewPass.Text = "" Or txt_NewPass_Confirm.Text = "" Then
'        txt_NewPass.SelectedText = True
'        RadMessageBox.Show(Me, "Please complete the fields.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
'    Else
'        If MySQLConn.State = ConnectionState.Open Then
'            MySQLConn.Close()
'        End If
'        Try
'            MySQLConn.ConnectionString = connstring
'            MySQLConn.Open()
'            Dim q2 As String = "SELECT * FROM staff_reg WHERE staff_username=@proc_email_login and staff_password=sha2(@proc_OLDpassword, 512)"
'            comm = New MySqlCommand(q2, MySQLConn)
'            comm.Parameters.AddWithValue("@proc_email_login", username)
'            comm.Parameters.AddWithValue("@proc_OLDpassword", txt_CurPass.Text)
'            reader = comm.ExecuteReader
'            While reader.Read
'                looper += 1
'            End While
'            MySQLConn.Close()
'        Catch ex As MySqlException
'            If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Then
'                RadMessageBox.Show(Me, "The database probably went offline.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
'                Login.log_lbl_dbstatus.Text = "Offline"
'                Login.log_lbl_dbstatus.ForeColor = Color.Red
'                Return
'            Else
'                RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
'            End If
'        Catch ex As Exception
'            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
'        Finally
'            MySQLConn.Dispose()
'        End Try
'        Try
'            If looper = 1 Then

'                If MySQLConn.State = ConnectionState.Open Then
'                    MySQLConn.Close()
'                End If
'                MySQLConn.Open()
'                Dim Query As String = "UPDATE ceutltdscheduler.staff_reg SET staff_password=SHA2(@newpassword,512) WHERE staff_username=@currentusername"
'                comm = New MySqlCommand(Query, MySQLConn)
'                comm.Parameters.AddWithValue("@newpassword", txt_NewPass.Text)
'                comm.Parameters.AddWithValue("@currentusername", username)
'                comm.ExecuteNonQuery()
'                MySQLConn.Close()
'                RadMessageBox.Show(Me, "Password changed successfully.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1)
'                txt_CurPass.Text = String.Empty
'                txt_NewPass.Text = String.Empty
'                txt_NewPass_Confirm.Text = String.Empty
'                txt_CurPass.Select()
'                Me.Dispose()
'            Else
'                txt_CurPass.Text = String.Empty
'                txt_NewPass.Text = String.Empty
'                txt_NewPass_Confirm.Text = String.Empty
'                RadMessageBox.Show(Me, "Wrong Password.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
'                txt_CurPass.Select()
'            End If
'        Catch ex As MySqlException
'            If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Then
'                RadMessageBox.Show(Me, "The database probably went offline.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
'                Login.log_lbl_dbstatus.Text = "Offline"
'                Login.log_lbl_dbstatus.ForeColor = Color.Red
'                Return
'            Else
'                RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
'            End If
'        Catch ex As Exception
'            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
'        Finally
'            MySQLConn.Dispose()
'        End Try
'    End If
'End Sub

'Private Sub PasswordChangeTextBoxes_GotFocus(sender As Object, e As EventArgs) Handles txt_CurPass.GotFocus, txt_NewPass.GotFocus, txt_NewPass_Confirm.GotFocus
'    AcceptButton = btn_ChP
'End Sub