Imports System.Threading

'Lance Bendo


Public Class PendingSms

    Private resId, endTime As String
    Private isDone As Boolean = False

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
