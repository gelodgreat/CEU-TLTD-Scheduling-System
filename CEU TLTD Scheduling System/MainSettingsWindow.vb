Imports MySql.Data.MySqlClient
Imports Telerik.WinControls

Public Class MainSettingsWindow
    Private Sub btn_penalty_setting_save_Click(sender As Object, e As EventArgs) Handles btn_penalty_setting_save.Click
        Dim ts_gp As TimeSpan = TimeSpan.Parse(penalty_gp_day.Value.ToString & "." & penalty_gp_hhmm.Value.ToString("HH:mm"))
        Dim ts_ci As TimeSpan = TimeSpan.Parse(penalty_ci_day.Value.ToString & "." & penalty_ci_hhmm.Value.ToString("HH:mm"))
        Try
            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If
            MySQLConn.Open
            Dim q As String = "UPDATE ceutltdscheduler.settings SET value=@a WHERE name='penalty_gracePeriod'; UPDATE ceutltdscheduler.settings SET value=@b WHERE name='penalty_chargeInterval'; UPDATE ceutltdscheduler.settings SET value=@c WHERE name='penalty_price';"
            comm = New MySqlCommand(q, MySQLConn)
            comm.Parameters.AddWithValue("@a", ts_gp.ToString)
            comm.Parameters.AddWithValue("@b", ts_ci.ToString)
            comm.Parameters.AddWithValue("@c", penalty_peso_amount.Text)
            comm.ExecuteNonQuery()
            MySQLConn.Close
        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub penalty_peso_amount_TextChanged(sender As Object, e As EventArgs) Handles penalty_peso_amount.TextChanged
        penalty_peso_amount.Text=String.Format("{0:0,0.00}", penalty_peso_amount.Text)
    End Sub

    Private Sub MainSettingsWindow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
