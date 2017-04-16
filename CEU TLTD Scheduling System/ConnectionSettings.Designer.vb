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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConnectionWindow))
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txt_cons_port = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.txt_cons_password = New Telerik.WinControls.UI.RadTextBox()
        Me.txt_cons_username = New Telerik.WinControls.UI.RadTextBox()
        Me.txt_cons_server = New Telerik.WinControls.UI.RadTextBox()
        Me.btn_cons_save = New Telerik.WinControls.UI.RadButton()
        Me.btn_load_database = New Telerik.WinControls.UI.RadButton()
        CType(Me.RadLabel1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadGroupBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.RadGroupBox1.SuspendLayout
        CType(Me.txt_cons_port,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txt_cons_password,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txt_cons_username,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txt_cons_server,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_cons_save,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_load_database,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Location = New System.Drawing.Point(35, 40)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(40, 18)
        Me.RadLabel1.TabIndex = 0
        Me.RadLabel1.Text = "Server:"
        Me.RadLabel1.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel3
        '
        Me.RadLabel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel3.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel3.Location = New System.Drawing.Point(16, 120)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel3.TabIndex = 1
        Me.RadLabel3.Text = "Username:"
        Me.RadLabel3.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel4
        '
        Me.RadLabel4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel4.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel4.Location = New System.Drawing.Point(19, 160)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel4.TabIndex = 2
        Me.RadLabel4.Text = "Password:"
        Me.RadLabel4.ThemeName = "VisualStudio2012Dark"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.txt_cons_port)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel5)
        Me.RadGroupBox1.Controls.Add(Me.txt_cons_password)
        Me.RadGroupBox1.Controls.Add(Me.txt_cons_username)
        Me.RadGroupBox1.Controls.Add(Me.txt_cons_server)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox1.HeaderText = "Datebase Settings"
        Me.RadGroupBox1.Location = New System.Drawing.Point(3, 4)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(268, 233)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.TabStop = false
        Me.RadGroupBox1.Text = "Datebase Settings"
        Me.RadGroupBox1.ThemeName = "VisualStudio2012Dark"
        '
        'txt_cons_port
        '
        Me.txt_cons_port.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cons_port.Location = New System.Drawing.Point(97, 76)
        Me.txt_cons_port.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_port.Name = "txt_cons_port"
        '
        '
        '
        Me.txt_cons_port.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_port.Size = New System.Drawing.Size(150, 24)
        Me.txt_cons_port.TabIndex = 1
        Me.txt_cons_port.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel5
        '
        Me.RadLabel5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel5.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel5.Location = New System.Drawing.Point(46, 78)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(29, 18)
        Me.RadLabel5.TabIndex = 2
        Me.RadLabel5.Text = "Port:"
        Me.RadLabel5.ThemeName = "VisualStudio2012Dark"
        '
        'txt_cons_password
        '
        Me.txt_cons_password.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cons_password.Location = New System.Drawing.Point(97, 157)
        Me.txt_cons_password.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_password.Name = "txt_cons_password"
        Me.txt_cons_password.NullText = "[Type a password to change]"
        Me.txt_cons_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        '
        '
        '
        Me.txt_cons_password.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_password.Size = New System.Drawing.Size(150, 24)
        Me.txt_cons_password.TabIndex = 4
        Me.txt_cons_password.ThemeName = "VisualStudio2012Dark"
        '
        'txt_cons_username
        '
        Me.txt_cons_username.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cons_username.Location = New System.Drawing.Point(97, 117)
        Me.txt_cons_username.MinimumSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_username.Name = "txt_cons_username"
        Me.txt_cons_username.NullText = "[Type a username to change]"
        Me.txt_cons_username.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        '
        '
        '
        Me.txt_cons_username.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.txt_cons_username.Size = New System.Drawing.Size(150, 24)
        Me.txt_cons_username.TabIndex = 3
        Me.txt_cons_username.ThemeName = "VisualStudio2012Dark"
        '
        'txt_cons_server
        '
        Me.txt_cons_server.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_cons_server.Location = New System.Drawing.Point(97, 38)
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
        Me.btn_cons_save.Location = New System.Drawing.Point(86, 252)
        Me.btn_cons_save.Name = "btn_cons_save"
        Me.btn_cons_save.Size = New System.Drawing.Size(110, 24)
        Me.btn_cons_save.TabIndex = 4
        Me.btn_cons_save.Text = "Save"
        Me.btn_cons_save.ThemeName = "VisualStudio2012Dark"
        '
        'btn_load_database
        '
        Me.btn_load_database.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_load_database.Image = CType(resources.GetObject("btn_load_database.Image"),System.Drawing.Image)
        Me.btn_load_database.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_load_database.Location = New System.Drawing.Point(240, 252)
        Me.btn_load_database.Name = "btn_load_database"
        Me.btn_load_database.Size = New System.Drawing.Size(22, 25)
        Me.btn_load_database.TabIndex = 5
        Me.btn_load_database.ThemeName = "VisualStudio2012Dark"
        '
        'ConnectionWindow
        '
        Me.AcceptButton = Me.btn_cons_save
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 291)
        Me.Controls.Add(Me.btn_load_database)
        Me.Controls.Add(Me.btn_cons_save)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "ConnectionWindow"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.ShowIcon = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection"
        Me.ThemeName = "VisualStudio2012Dark"
        Me.TopMost = true
        CType(Me.RadLabel1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadGroupBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.RadGroupBox1.ResumeLayout(false)
        Me.RadGroupBox1.PerformLayout
        CType(Me.txt_cons_port,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txt_cons_password,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txt_cons_username,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txt_cons_server,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_cons_save,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_load_database,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents txt_cons_password As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txt_cons_username As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txt_cons_server As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btn_cons_save As Telerik.WinControls.UI.RadButton
    Friend WithEvents txt_cons_port As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btn_load_database As Telerik.WinControls.UI.RadButton
End Class

