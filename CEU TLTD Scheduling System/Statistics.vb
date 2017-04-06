Imports Telerik.WinControls

Public Class Statistics
    Private Sub Statistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MySQLConn.ConnectionString = connstring
            MySQLConn.Open()
            Dim q As String = "SELECT  (
    SELECT COUNT(*) FROM ceutltdscheduler.reservation WHERE YEARWEEK(date)=YEARWEEK(CURDATE())) AS 'reservations_placed_for_this_week',
    (SELECT COUNT(*) FROM  ceutltdscheduler.reservation WHERE MONTH(date)=MONTH(CURDATE())) AS 'reservations_placed_this_month',
    (SELECT COUNT(*) FROM  ceutltdscheduler.reservation WHERE YEAR(date)=YEAR(CURDATE())) AS 'reservations_placed_this_year',
    (SELECT equipmenttype FROM ceutltdscheduler.reservation GROUP BY equipmenttype ORDER BY COUNT(equipmenttype) DESC LIMIT 1) As 'most_borrowed_equipment_all_time'"
            comm = New MySql.Data.MySqlClient.MySqlCommand(q, MySQLConn)
            reader = comm.ExecuteReader
            While reader.Read
                lbl_res_t_wk.Text = reader.GetString("reservations_placed_for_this_week")
                lbl_res_t_m.Text = reader.GetString("reservations_placed_this_month")
                lbl_res_t_yr.Text = reader.GetString("reservations_placed_this_year")
                If reader.IsDBNull(3) Then
                    lbl_most_bor_eq.Text = "No data yet."
                Else
                    lbl_most_bor_eq.Text = reader.GetString("most_borrowed_equipment_all_time")
                End If
            End While
            MySQLConn.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Then
                Main.refresh_main_rgv_recordedacademicsonly.Stop()
                Main.refresh_released_grid_list.Stop()
                RadMessageBox.Show(Me, "The server probably went offline.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                Login.log_lbl_dbstatus.Text = "Offline"
                Login.log_lbl_dbstatus.ForeColor = Color.Red
                Login.lbl_prevmain_status.Text="Unavailable"
                Login.lbl_prevmain_status.ForeColor=Color.Red
                Login.lbl_reservation_status.Text="Unavailable"
                Login.lbl_reservation_status.ForeColor=Color.Red
                Return
            Else
                RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MySQLConn.Dispose()
        End Try
        Load_equipmentstats()
    End Sub
    Public Sub Load_equipmentstats()
        If MySQLConn.State = ConnectionState.Open Then
            MySQLConn.Close()
        End If
        MySQLConn.ConnectionString = connstring
        Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dbdataset As New DataTable

        Try
            MySQLConn.Open()
            comm = New MySql.Data.MySqlClient.MySqlCommand("SELECT ret_eqtype AS 'Equipment Type', ret_equipment AS 'Equipment Name', ret_equipment_no AS 'Equipment Number', ret_eqsn AS 'Equipment Serial Number', COUNT(ret_eqsn) AS 'Number of borrows' FROM returned_info GROUP BY ret_eqsn ORDER BY COUNT(ret_eqsn)", MySQLConn)
            adapter.SelectCommand = comm
            adapter.Fill(dbdataset)
            rgv_StatsByEq.DataSource = dbdataset
            MySQLConn.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Then
                Main.refresh_main_rgv_recordedacademicsonly.Stop()
                Main.refresh_released_grid_list.Stop()
                RadMessageBox.Show(Me, "The server probably went offline.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                Login.log_lbl_dbstatus.Text = "Offline"
                Login.log_lbl_dbstatus.ForeColor = Color.Red
                Login.lbl_prevmain_status.Text="Unavailable"
                Login.lbl_prevmain_status.ForeColor=Color.Red
                Login.lbl_reservation_status.Text="Unavailable"
                Login.lbl_reservation_status.ForeColor=Color.Red
                Return
            Else
                RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MySQLConn.Dispose()
        End Try
    End Sub
    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Me.Dispose()
    End Sub

    Private Sub rgv_StatsByEq_ViewCellFormatting(sender As Object, e As UI.CellFormattingEventArgs) Handles rgv_StatsByEq.ViewCellFormatting
        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
    End Sub
End Class
