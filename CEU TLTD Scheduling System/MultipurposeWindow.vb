Imports System.Media
Imports Telerik.WinControls.UI

Public Class MultipurposeWindow
    Private Sub MultipurposeWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DeterminePanel()
    End Sub

    Private Sub DeterminePanel()
        If MultipurposeWindowPanel = "A"
            Me.Text="The following equipments has been returned"
            PanelMultipleReturn.Show
            SystemSounds.Asterisk.Play()
            lst_Returned.MasterTemplate.BestFitColumns(BestFitColumnMode.DisplayedDataCells)
        ElseIf MultipurposeWindowPanel = "B"
            Me.Text="Please remove conflicting equipments"
            PanelConflictingReservation.Show
        End If
    End Sub
    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click, Me.Closed
        If PanelMultipleReturn.Visible = True
            lst_Returned.Rows.Clear
        End If
        PanelMultipleReturn.Hide
        PanelConflictingReservation.Hide
        MultipurposeWindowPanel =""
        Me.Text=""
        Me.Close()
    End Sub
End Class
