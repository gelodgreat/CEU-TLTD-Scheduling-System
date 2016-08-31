Imports MySql.Data.MySqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls

Public Class ChangeEquipmentReservation
    Dim query As String


    Private Sub ChangeEquipmentReservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MySQLConn = New MySqlConnection
        MySQLConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MySQLConn.State = ConnectionState.Open Then
            MySQLConn.Close()
        End If

        Try
            MySQLConn.Open()

            query = "SELECT reservationno AS 'Reservation Number',id AS 'ID',equipmentsn AS 'Equipment SN', equipmentno AS 'Equipment No',equipment AS 'Equipment' FROM reservation_equipment"

            comm = New MySqlCommand(query, MySQLConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            che_rgv_eq.DataSource = bsource
            che_rgv_eq.ReadOnly = True
            sda.Update(dbdataset)
            MySQLConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MySQLConn.Dispose()

        End Try
    End Sub
End Class
