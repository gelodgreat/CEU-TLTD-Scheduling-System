Imports System.Runtime.InteropServices
Imports Telerik.WinControls

Public Class About
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HTCAPTION As Integer = &H2

    <DllImport("User32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("User32.dll")> _
    Public Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    Private Sub About_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
		    ReleaseCapture()
		    SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
	    End If
    End Sub
    Private Sub About_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Protected Overrides Sub OnDeactivate(e As EventArgs)
	    MyBase.OnDeactivate(e)
        Me.Close
    End Sub
End Class