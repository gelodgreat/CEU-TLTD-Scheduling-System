Imports Telerik.WinControls.UI

Public Class MultipurposeWindow
    Private Sub MultipurposeWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       lst_Returned.MasterTemplate.BestFitColumns(BestFitColumnMode.HeaderCells)
       lst_Returned.Rows.Add("Patrick Jenkin Wu","Air Brush","450.00","1 day(s) 1 hour(s) 59 minute(s).")
    End Sub

    Private Sub DeterminePanel()
    
    End Sub
    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        If PanelMultipleReturn.Visible=True
            lst_Returned.Rows.Clear
        End If
        Me.Close()
    End Sub
End Class
