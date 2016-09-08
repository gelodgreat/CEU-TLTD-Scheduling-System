Public Class ConnectionWindow
    Private Sub btn_cons_save_Click(sender As Object, e As EventArgs) Handles btn_cons_save.Click
        'My.Settings.cons_server = txt_cons_server.Text
        'My.Settings.cons_database = txt_cons_database.Text
        'My.Settings.cons_username = txt_cons_username.Text
        'My.Settings.cons_password = txt_cons_password.Text
        'My.Settings.Save()
        'Application.Restart()
    End Sub

    Private Sub ConnectionWindow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ConnectionWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
