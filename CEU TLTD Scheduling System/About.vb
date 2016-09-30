Imports Telerik.WinControls

Public Class About
    Private Sub About_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim closingYN As DialogResult = RadMessageBox.Show(Me, "Are you sure you want to close this window?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation)
        If closingYN = MsgBoxResult.Yes Then
            Me.Dispose()
        ElseIf closingYN = MsgBoxResult.No Then
            e.Cancel = True
        End If
        
    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MaximumSize=New Size(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height)
        Me.MinimumSize=New Size(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height)
        TopMost=True
    End Sub

    Private Sub About_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Location = new Point(0,0)
        TopMost=True
        ShowInTaskbar=True
    End Sub

End Class