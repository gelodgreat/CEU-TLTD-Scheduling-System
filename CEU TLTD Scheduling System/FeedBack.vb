Imports MySql.Data.MySqlClient
Imports Telerik.WinControls

Public Class FeedBack
    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        Try
            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring
            If MySQLConn.State = ConnectionState.Open Then
                MySQLConn.Close()
            End If
            MySQLConn.Open()
            Dim Query As String = "INSERT INTO ceutltdscheduler.feedback (name,date,details) VALUES(@complainer,DATE_FORMAT(now(), '%Y-%m-%d %H:%i'),@details)"
            comm = New MySqlCommand(Query, MySQLConn)
            comm.Parameters.AddWithValue("@complainer", activeuserlname + ", " + activeuserfname)
            comm.Parameters.AddWithValue("@details", message.Text)
            comm.ExecuteNonQuery()
            MySQLConn.Close()
            RadMessageBox.Show(Me, "Thank you for leaving a feedback. We will get to it as soon as possible. :)", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
            Me.Dispose()
        Catch ex As MySqlException
            If (ex.Number = 0 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed"))) Or (ex.Number = 1042 And (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts") Or ex.Message.Contains("Reading from the stream has failed")))
                RadMessageBox.Show(Me, "The database probably went offline.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                Login.log_lbl_dbstatus.Text = "Offline"
                Login.log_lbl_dbstatus.ForeColor = Color.Red
                Return
            Else
                RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            End If
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MySQLConn.Dispose()
        End Try
    End Sub
End Class
