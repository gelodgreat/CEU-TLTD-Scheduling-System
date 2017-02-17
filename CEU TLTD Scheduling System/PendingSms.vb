Imports System.Threading

'Lance Bendo


Public Class PendingSms

    Private resId, endTime As String
    Private isDone As Boolean = False

    Private dt As New DataTable
    Private WithEvents t As New System.Windows.Forms.Timer

    Sub New(ByVal resId As String, ByVal endTime As String, ByVal dt As DataTable)
        Me.resId = resId
        Me.endTime = endTime
        Me.dt = dt
    End Sub

    Public Sub endPendingSms()
        Me.isDone = True
    End Sub

    Public Function getReservationId()
        Return Me.resId
    End Function

    Private Sub t_Tick(sender As Object, e As EventArgs) Handles t.Tick

        If isDone = True Then               ''pag nabalik na yung hiniram
            disposePendingSms()
        End If


        If endTime = DateTime.Now.ToString And isDone = False Then          ''pag over time na. dito magtetext

            ''INSERT SEND SMS FUNCTION HERE

            isDone = True
            disposePendingSms()
        End If

    End Sub


    Private Sub disposePendingSms()
        endTime = Nothing
        resId = Nothing
        RemoveHandler t.Tick, AddressOf t_Tick
        t.Dispose()
        t = Nothing
        isDone = Nothing
        MyBase.Finalize()
    End Sub


End Class
