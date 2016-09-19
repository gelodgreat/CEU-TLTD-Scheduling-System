<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DBPasswordPrompt
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txt_DBPassword = New Telerik.WinControls.UI.RadTextBox()
        Me.btn_DBPassword = New Telerik.WinControls.UI.RadButton()
        CType(Me.txt_DBPassword,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_DBPassword,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'txt_DBPassword
        '
        Me.txt_DBPassword.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_DBPassword.Location = New System.Drawing.Point(78, 12)
        Me.txt_DBPassword.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txt_DBPassword.Name = "txt_DBPassword"
        Me.txt_DBPassword.NullText = "Password"
        Me.txt_DBPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_DBPassword.Size = New System.Drawing.Size(212, 24)
        Me.txt_DBPassword.TabIndex = 0
        Me.txt_DBPassword.ThemeName = "VisualStudio2012Dark"
        '
        'btn_DBPassword
        '
        Me.btn_DBPassword.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_DBPassword.Location = New System.Drawing.Point(315, 13)
        Me.btn_DBPassword.Name = "btn_DBPassword"
        Me.btn_DBPassword.Size = New System.Drawing.Size(110, 24)
        Me.btn_DBPassword.TabIndex = 1
        Me.btn_DBPassword.Text = "OK"
        Me.btn_DBPassword.ThemeName = "VisualStudio2012Dark"
        '
        'DBPasswordPrompt
        '
        Me.AcceptButton = Me.btn_DBPassword
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 59)
        Me.Controls.Add(Me.btn_DBPassword)
        Me.Controls.Add(Me.txt_DBPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "DBPasswordPrompt"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.ShowIcon = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Confirm Database Password"
        Me.ThemeName = "VisualStudio2012Dark"
        Me.TopMost = true
        CType(Me.txt_DBPassword,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_DBPassword,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txt_DBPassword As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btn_DBPassword As Telerik.WinControls.UI.RadButton
End Class

