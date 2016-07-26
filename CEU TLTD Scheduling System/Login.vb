Imports MySql.Data.MySqlClient
Imports Telerik.WinControls

Public Class Login
    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Main.Show()
        Me.Hide()

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark"
    End Sub
End Class
