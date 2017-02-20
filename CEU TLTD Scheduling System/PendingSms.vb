Imports System.Threading
Imports MySql.Data.MySqlClient

'Lance Bendo


Public Class PendingSms

    Private resId, endTime As String
    Private isDone As Boolean = False

    Private updateQuery As String = ""
    'Conn

    'Conn
    Private Sub Scanfor_isSMS_Sent_Flag()
        MySQLConn_Bendo = New MySqlConnection
        MySQLConn_Bendo.ConnectionString = connstring
        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable

        If MySQLConn.State = ConnectionState.Open Then
            MySQLConn.Close()
        End If
        MySQLConn.Open()
        Dim query As String
        query = "Select reservationno as 'Reservation Number', borrower as 'Borrower', equipmenttype as 'Equipment Type', equipmentno as 'Equipment No.', equipment as 'Equipment', location as 'Location', DATE_FORMAT(date,'%M %d %Y') as 'Date', TIME_FORMAT(endtime, '%H:%i') as 'End Time' from reservation natural join reservation_equipments where res_status = 'Released'  ORDER by date ASC"
        comm = New MySqlCommand(query, MySQLConn)
        sda.SelectCommand = comm
        sda.Fill(dbdataset)
        sda.Update(dbdataset)
        MySQLConn.Close()
    End Sub

    Private dt As New DataTable
    Private WithEvents t As System.Windows.Forms.Timer

    Sub New(ByVal resId As String, ByVal endTime As String, ByVal dt As DataTable, ByVal t As System.Windows.Forms.Timer)
        Me.resId = resId
        'Me.endTime = endTime comment muna for testing
        Me.endTime = DateTime.Now.AddSeconds(5)
        Me.dt = dt
        Me.t = t
    End Sub

    Public Sub endPendingSms()
        Me.isDone = True
    End Sub

    Public Function getReservationId()
        Return Me.resId
    End Function

    Public Function getIsDone()






        Return Me.isDone
    End Function

    Private Sub t_Tick(sender As Object, e As EventArgs) Handles t.Tick

        ' Debug.WriteLine(endTime & " " & DateTime.Now.ToString & isDone.ToString)

        If isDone = True Then               ''pag nabalik na yung hiniram
            disposePendingSms()
        End If


        If endTime = DateTime.Now.ToString And isDone = False Then          ''pag over time na. dito magtetext

            ''INSERT SEND SMS FUNCTION HERE
            'test code lang

            ''create a list for pending sms to be sent to avoid choking of sending


            Debug.WriteLine("MSG SENT!")

            Dim dr As DataRow = dt.Select("[" & dt.Columns(0).ColumnName & "] = '" & Me.getReservationId & "'")(0)
            dt.Rows.Remove(dr)
            Me.isDone = True
            disposePendingSms()
            MsgBox("MSG SENT!")

            RemoveHandler t.Tick, AddressOf t_Tick
            isDone = Nothing
            MyBase.Finalize()

        End If

    End Sub


    Private Sub disposePendingSms()

        'RemoveHandler t.Tick, AddressOf t_Tick
        'isDone = Nothing
        'MyBase.Finalize()
    End Sub


End Class
