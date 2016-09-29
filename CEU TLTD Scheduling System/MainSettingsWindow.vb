Imports MySql.Data.MySqlClient
Imports Telerik.WinControls

Public Class MainSettingsWindow
    Private Sub MainSettingsWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Main.getFromDB_settings_penalty()
        penalty_peso_amount.Text = penalty_price
        Dim DB_GP As TimeSpan = TimeSpan.FromSeconds(penalty_graceperiod)
        Dim DB_CI As TimeSpan = TimeSpan.FromSeconds(penalty_chargeInterval)
        'MsgBox(ct1.ToString & Environment.NewLine & ct1.Days & Environment.NewLine & ct1.Hours & Environment.NewLine & ct1.Minutes & Environment.NewLine & ct1.Seconds)
        penalty_gp_day.Value = DB_GP.Days
        penalty_gp_hhmm.Value = (Date.Parse(String.Format("{0:D2}:{1:D2}:00", DB_GP.Hours,DB_GP.Minutes)))
        penalty_ci_day.Value = DB_CI.Days
        penalty_ci_hhmm.Value = (Date.Parse(String.Format("{0:D2}:{1:D2}:00", DB_CI.Hours,DB_CI.Minutes)))
    End Sub

    Private Sub btn_penalty_setting_save_Click(sender As Object, e As EventArgs) Handles btn_penalty_setting_save.Click
        If penalty_peso_amount.Text.Length = 0 Then
            RadMessageBox.Show(Me, "Please enter peso amount.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            Dim c As Char = penalty_peso_amount.Text(penalty_peso_amount.Text.Length-1)
            If c = "."
                RadMessageBox.Show(Me, "Please fix the formatting of the peso amount.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
            Else
            
            Dim confirmChange As DialogResult = RadMessageBox.Show(Me, "Are you sure save the changes? This will change the charges to everyone who starts returning the equipment after clicking ""Yes"".","CEU TLTD Reservation System",MessageBoxButtons.YesNo, RadMessageIcon.Exclamation,MessageBoxDefaultButton.Button2)
            If confirmChange=DialogResult.Yes
            Dim ts_gp As TimeSpan = TimeSpan.Parse(penalty_gp_day.Value.ToString & "." & penalty_gp_hhmm.Value.ToString("HH:mm"))
            Dim ts_ci As TimeSpan = TimeSpan.Parse(penalty_ci_day.Value.ToString & "." & penalty_ci_hhmm.Value.ToString("HH:mm"))
            Try
                If MySQLConn.State = ConnectionState.Open Then
                    MySQLConn.Close()
                End If
                MysqlConn.ConnectionString = connstring
                MySQLConn.Open()
                Dim q As String = "UPDATE ceutltdscheduler.settings SET value=@a WHERE name='penalty_gracePeriod'; UPDATE ceutltdscheduler.settings SET value=@b WHERE name='penalty_chargeInterval'; UPDATE ceutltdscheduler.settings SET value=@c WHERE name='penalty_price';"
                comm = New MySqlCommand(q, MySQLConn)
                comm.Parameters.AddWithValue("@a", ts_gp.TotalSeconds)
                comm.Parameters.AddWithValue("@b", ts_ci.TotalSeconds)
                comm.Parameters.AddWithValue("@c", penalty_peso_amount.Text)
                comm.ExecuteNonQuery()
                MySQLConn.Close
                RadMessageBox.Show(Me, "Sucessfully updated penalty settings.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1)
            Catch ex As MySqlException
                RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End If
    End If
    End If
    End Sub


    Private Sub penalty_peso_amount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles penalty_peso_amount.KeyPress
        If penalty_peso_amount.Text.Contains(".") Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or (e.KeyChar=vbBack))
        Else
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or (e.KeyChar=vbBack))
        End If
   End Sub

    Private Sub MainSettingsWindow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btn_test_Click(sender As Object, e As EventArgs) 
        MsgBox(penalty_gp_hhmm.Value)
    End Sub
End Class
