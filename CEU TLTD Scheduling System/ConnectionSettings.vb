Public Class ConnectionWindow
    Private Sub btn_cons_save_Click(sender As Object, e As EventArgs) Handles btn_cons_save.Click
        My.Settings.cons_server = txt_cons_server.Text
        My.Settings.cons_port = txt_cons_port.Text
        My.Settings.cons_database = txt_cons_database.Text
        If String.IsNullOrEmpty(txt_cons_username.Text) And String.IsNullOrEmpty(txt_cons_password.Text) Then
            'NO ACTION
        Else
            My.Settings.cons_username = Actions.EncryptString(Actions.ToSecureString(txt_cons_username.Text))
            My.Settings.cons_password = Actions.EncryptString(Actions.ToSecureString(txt_cons_password.Text))
        End If
        My.Settings.Save()
        Me.Dispose()
        Login.timerandstatus()
        Application.Restart()
    End Sub

    Private Sub ConnectionWindow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ConnectionWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_cons_server.Text = My.Settings.cons_server
        txt_cons_port.Text = My.Settings.cons_port
        txt_cons_database.Text = My.Settings.cons_database
    End Sub
End Class
