Imports Telerik.WinControls

Public Class ConnectionWindow
    Private Sub btn_cons_save_Click(sender As Object, e As EventArgs) Handles btn_cons_save.Click
        Dim DBSettingchange As DialogResult = RadMessageBox.Show(Me, "Are you sure you want to apply the new settings?" & Environment.NewLine & Environment.NewLine & "If you are not the network administrator it is advisable to choose ""NO.""", system_Name, MessageBoxButtons.YesNo, RadMessageIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If DBSettingchange=DialogResult.Yes
            My.Settings.cons_server = txt_cons_server.Text
            My.Settings.cons_port = txt_cons_port.Text
            If String.IsNullOrEmpty(txt_cons_username.Text) And String.IsNullOrEmpty(txt_cons_password.Text) Then
                'NO ACTION
            Else
                My.Settings.cons_username = Actions.EncryptString(Actions.ToSecureString(txt_cons_username.Text))
                My.Settings.cons_password = Actions.EncryptString(Actions.ToSecureString(txt_cons_password.Text))
            End If
            My.Settings.Save()
            applyconstringImmediately()
            Login.CheckDBStatus()
            Me.Dispose()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub ConnectionWindow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ConnectionWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_cons_server.Text = My.Settings.cons_server
        txt_cons_port.Text = My.Settings.cons_port
    End Sub

    Private Sub btn_load_database_Click(sender As Object, e As EventArgs) Handles btn_load_database.Click
        DBPasswordPrompt.ShowDialog()
    End Sub

    Private Sub ConnectionWindow_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode=Keys.F1
            If IO.File.Exists("help.chm") Then
                Actions.showHelp(Me, "6")
            Else
                RadMessageBox.Show(Me, "Required file for help not found. Re-installing might solve the problem.", system_Name, MessageBoxButtons.OK, RadMessageIcon.Error)
                Exit Sub
            End If
        End If
    End Sub
End Class
