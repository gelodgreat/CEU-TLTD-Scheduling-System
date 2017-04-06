Imports System.ComponentModel
Imports System.Media
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI

Public Class MultipurposeWindow
    Private Sub MultipurposeWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DeterminePanel()
    End Sub

    Private Sub DeterminePanel()
        If MultipurposeWindowPanel = "A"
            Me.Size = New Size(638, 418)
            Me.Text = "The following equipments has been returned"
            PanelMultipleReturn.Show
            SystemSounds.Asterisk.Play()
            lst_Returned.MasterTemplate.BestFitColumns(BestFitColumnMode.DisplayedDataCells)
        ElseIf MultipurposeWindowPanel = "B"
            Me.Size = New Size(800, Me.Size.Height)
            Me.Text = "One or more of the selected equipments has a conflict with"
            PanelConflictingReservation.Show
            SystemSounds.Exclamation.Play()
            lst_res_conflicts.MasterTemplate.BestFitColumns(BestFitColumnMode.DisplayedCells)
            Dim descriptorDate As New SortDescriptor()
            descriptorDate.PropertyName = "ColDate"
            descriptorDate.Direction = ListSortDirection.Ascending
            Dim descriptorStartTime As New SortDescriptor()
            descriptorStartTime.PropertyName = "ColSTime"
            descriptorStartTime.Direction = ListSortDirection.Ascending
            Dim descriptorEndTime As New SortDescriptor()
            descriptorEndTime.PropertyName = "ColETime"
            descriptorEndTime.Direction = ListSortDirection.Ascending
            lst_res_conflicts.SortDescriptors.Add(descriptorDate)
            lst_res_conflicts.SortDescriptors.Add(descriptorStartTime)
            lst_res_conflicts.SortDescriptors.Add(descriptorEndTime)
        End If
    End Sub
    Private Sub CloseWhatisNeededToClose()
        PanelMultipleReturn.Hide
        PanelConflictingReservation.Hide
        MultipurposeWindowPanel = ""
        Me.Text = ""
        Me.Dispose()
    End Sub

    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        If PanelMultipleReturn.Visible = True
            lst_Returned.Rows.Clear
        End If
        CloseWhatisNeededToClose()
    End Sub

    Private Sub btn_ResOK_Click(sender As Object, e As EventArgs) Handles btn_ResOK.Click
        If PanelConflictingReservation.Visible = True
            lst_res_conflicts.Rows.Clear
        End If
        CloseWhatisNeededToClose()
    End Sub

    Private Sub Form_Closed(sender As Object, e As EventArgs) Handles Me.FormClosed
        If PanelMultipleReturn.Visible = True
            lst_Returned.Rows.Clear
        ElseIf PanelConflictingReservation.Visible = True
            lst_res_conflicts.Rows.Clear
        End If
        CloseWhatisNeededToClose()
    End Sub
End Class
