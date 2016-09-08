<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectionWindow
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
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txt_cons_password = New Telerik.WinControls.UI.RadTextBox()
        Me.txt_cons_username = New Telerik.WinControls.UI.RadTextBox()
        Me.txt_cons_database = New Telerik.WinControls.UI.RadTextBox()
        Me.txt_cons_server = New Telerik.WinControls.UI.RadTextBox()
        Me.btn_cons_save = New Telerik.WinControls.UI.RadButton()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.txt_cons_password, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_cons_username, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_cons_database, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_cons_server, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_cons_save, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.ForeColor = System.Drawing.Color.White
        Me.RadLabel1.Location = New System.Drawing.Point(36, 40)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(40, 18)
        Me.RadLabel1.TabIndex = 0
        Me.RadLabel1.Text = "Server:"
        '
        'RadLabel2
        '
        Me.RadLabel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.ForeColor = System.Drawing.Color.White
        Me.RadLabel2.Location = New System.Drawing.Point(18, 80)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(55, 18)
        Me.RadLabel2.TabIndex = 1
        Me.RadLabel2.Text = "Database:"
        '
        'RadLabel3
        '
        Me.RadLabel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel3.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel3.ForeColor = System.Drawing.Color.White
        Me.RadLabel3.Location = New System.Drawing.Point(17, 120)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel3.TabIndex = 1
        Me.RadLabel3.Text = "Username:"
        '
        'RadLabel4
        '
        Me.RadLabel4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel4.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel4.ForeColor = System.Drawing.Color.White
        Me.RadLabel4.Location = New System.Drawing.Point(20, 161)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel4.TabIndex = 2
        Me.RadLabel4.Text = "Password:"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadGroupBox1.Controls.Add(Me.txt_cons_password)
        Me.RadGroupBox1.Controls.Add(Me.txt_cons_username)
        Me.RadGroupBox1.Controls.Add(Me.txt_cons_database)
        Me.RadGroupBox1.Controls.Add(Me.txt_cons_server)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox1.HeaderText = "Datebase Settings"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(268, 208)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.TabStop = False
        Me.RadGroupBox1.Text = "Datebase Settings"
        Me.RadGroupBox1.ThemeName = "VisualStudio2012Dark"
        '
        'txt_cons_password
        '
        Me.txt_cons_password.Location = New System.Drawing.Point(98, 158)
        Me.txt_cons_password.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_password.Name = "txt_cons_password"
        Me.txt_cons_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        '
        '
        '
        Me.txt_cons_password.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_password.Size = New System.Drawing.Size(150, 24)
        Me.txt_cons_password.TabIndex = 3
        Me.txt_cons_password.ThemeName = "VisualStudio2012Dark"
        '
        'txt_cons_username
        '
        Me.txt_cons_username.Location = New System.Drawing.Point(98, 117)
        Me.txt_cons_username.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_username.Name = "txt_cons_username"
        Me.txt_cons_username.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        '
        '
        '
        Me.txt_cons_username.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_username.Size = New System.Drawing.Size(150, 24)
        Me.txt_cons_username.TabIndex = 2
        Me.txt_cons_username.ThemeName = "VisualStudio2012Dark"
        '
        'txt_cons_database
        '
        Me.txt_cons_database.Location = New System.Drawing.Point(98, 78)
        Me.txt_cons_database.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_database.Name = "txt_cons_database"
        '
        '
        '
        Me.txt_cons_database.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_database.Size = New System.Drawing.Size(150, 24)
        Me.txt_cons_database.TabIndex = 1
        Me.txt_cons_database.ThemeName = "VisualStudio2012Dark"
        '
        'txt_cons_server
        '
        Me.txt_cons_server.Location = New System.Drawing.Point(98, 38)
        Me.txt_cons_server.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_server.Name = "txt_cons_server"
        '
        '
        '
        Me.txt_cons_server.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_server.Size = New System.Drawing.Size(150, 24)
        Me.txt_cons_server.TabIndex = 0
        Me.txt_cons_server.ThemeName = "VisualStudio2012Dark"
        '
        'btn_cons_save
        '
        Me.btn_cons_save.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_cons_save.Location = New System.Drawing.Point(92, 234)
        Me.btn_cons_save.Name = "btn_cons_save"
        Me.btn_cons_save.Size = New System.Drawing.Size(110, 24)
        Me.btn_cons_save.TabIndex = 4
        Me.btn_cons_save.Text = "Save"
        Me.btn_cons_save.ThemeName = "VisualStudio2012Dark"
        '
        'ConnectionWindow
        '
        Me.AcceptButton = Me.btn_cons_save
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 270)
        Me.Controls.Add(Me.btn_cons_save)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConnectionWindow"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection"
        Me.ThemeName = "VisualStudio2012Dark"
        Me.TopMost = True
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.txt_cons_password, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_cons_username, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_cons_database, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_cons_server, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_cons_save, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txt_cons_password As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txt_cons_username As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txt_cons_database As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txt_cons_server As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btn_cons_save As Telerik.WinControls.UI.RadButton
End Class

