<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.btn_login = New Telerik.WinControls.UI.RadButton()
        Me.VisualStudio2012DarkTheme1 = New Telerik.WinControls.Themes.VisualStudio2012DarkTheme()
        Me.RadLabel17 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel14 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.log_lbl_dbstatus = New Telerik.WinControls.UI.RadLabel()
        Me.log_username = New Telerik.WinControls.UI.RadTextBox()
        Me.log_password = New Telerik.WinControls.UI.RadTextBox()
        Me.log_timer = New System.Windows.Forms.Timer(Me.components)
        Me.log_lbl_date = New Telerik.WinControls.UI.RadLabel()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.btn_w8 = New Telerik.WinControls.UI.RadButton()
        Me.btn_metroblue = New Telerik.WinControls.UI.RadButton()
        Me.btn_metrotheme = New Telerik.WinControls.UI.RadButton()
        Me.btn_vsdark = New Telerik.WinControls.UI.RadButton()
        Me.btn_vslight = New Telerik.WinControls.UI.RadButton()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.TelerikMetroTheme1 = New Telerik.WinControls.Themes.TelerikMetroTheme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.log_lbl_time = New Telerik.WinControls.UI.RadLabel()
        Me.settingButton = New System.Windows.Forms.PictureBox()
        CType(Me.btn_login,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel17,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel14,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.log_lbl_dbstatus,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.log_username,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.log_password,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.log_lbl_date,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadGroupBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.RadGroupBox1.SuspendLayout
        CType(Me.RadGroupBox2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.RadGroupBox2.SuspendLayout
        CType(Me.btn_w8,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_metroblue,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_metrotheme,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_vsdark,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_vslight,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.log_lbl_time,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.settingButton,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btn_login
        '
        Me.btn_login.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btn_login.Location = New System.Drawing.Point(132, 174)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(110, 24)
        Me.btn_login.TabIndex = 3
        Me.btn_login.Text = "Login"
        Me.btn_login.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel17
        '
        Me.RadLabel17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom),System.Windows.Forms.AnchorStyles)
        Me.RadLabel17.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel17.Location = New System.Drawing.Point(59, 109)
        Me.RadLabel17.Name = "RadLabel17"
        Me.RadLabel17.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel17.TabIndex = 24
        Me.RadLabel17.Text = "Password:"
        Me.RadLabel17.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel14
        '
        Me.RadLabel14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom),System.Windows.Forms.AnchorStyles)
        Me.RadLabel14.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel14.Location = New System.Drawing.Point(78, 79)
        Me.RadLabel14.Name = "RadLabel14"
        Me.RadLabel14.Size = New System.Drawing.Size(35, 18)
        Me.RadLabel14.TabIndex = 23
        Me.RadLabel14.Text = "Email:"
        Me.RadLabel14.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(12, 12)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(46, 21)
        Me.RadLabel1.TabIndex = 25
        Me.RadLabel1.Text = "Status:"
        Me.RadLabel1.ThemeName = "VisualStudio2012Dark"
        '
        'log_lbl_dbstatus
        '
        Me.log_lbl_dbstatus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.log_lbl_dbstatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.log_lbl_dbstatus.Location = New System.Drawing.Point(57, 12)
        Me.log_lbl_dbstatus.Name = "log_lbl_dbstatus"
        Me.log_lbl_dbstatus.Size = New System.Drawing.Size(97, 21)
        Me.log_lbl_dbstatus.TabIndex = 26
        Me.log_lbl_dbstatus.Text = "Online/Offline"
        Me.log_lbl_dbstatus.ThemeName = "VisualStudio2012Dark"
        '
        'log_username
        '
        Me.log_username.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom),System.Windows.Forms.AnchorStyles)
        Me.log_username.Location = New System.Drawing.Point(121, 78)
        Me.log_username.MinimumSize = New System.Drawing.Size(0, 24)
        Me.log_username.Name = "log_username"
        '
        '
        '
        Me.log_username.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.log_username.Size = New System.Drawing.Size(192, 24)
        Me.log_username.TabIndex = 0
        Me.log_username.ThemeName = "VisualStudio2012Dark"
        '
        'log_password
        '
        Me.log_password.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom),System.Windows.Forms.AnchorStyles)
        Me.log_password.Location = New System.Drawing.Point(121, 108)
        Me.log_password.MinimumSize = New System.Drawing.Size(0, 24)
        Me.log_password.Name = "log_password"
        Me.log_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        '
        '
        '
        Me.log_password.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.log_password.Size = New System.Drawing.Size(192, 24)
        Me.log_password.TabIndex = 1
        Me.log_password.ThemeName = "VisualStudio2012Dark"
        '
        'log_timer
        '
        '
        'log_lbl_date
        '
        Me.log_lbl_date.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.log_lbl_date.AutoSize = false
        Me.log_lbl_date.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.log_lbl_date.Location = New System.Drawing.Point(180, -1)
        Me.log_lbl_date.Name = "log_lbl_date"
        Me.log_lbl_date.Size = New System.Drawing.Size(245, 21)
        Me.log_lbl_date.TabIndex = 29
        Me.log_lbl_date.Text = "Date"
        Me.log_lbl_date.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.log_lbl_date.ThemeName = "VisualStudio2012Dark"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.btn_login)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel14)
        Me.RadGroupBox1.Controls.Add(Me.log_password)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel17)
        Me.RadGroupBox1.Controls.Add(Me.log_username)
        Me.RadGroupBox1.HeaderText = "Login"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 51)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(386, 236)
        Me.RadGroupBox1.TabIndex = 30
        Me.RadGroupBox1.Text = "Login"
        Me.RadGroupBox1.ThemeName = "VisualStudio2012Dark"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox2.Controls.Add(Me.btn_w8)
        Me.RadGroupBox2.Controls.Add(Me.btn_metroblue)
        Me.RadGroupBox2.Controls.Add(Me.btn_metrotheme)
        Me.RadGroupBox2.Controls.Add(Me.btn_vsdark)
        Me.RadGroupBox2.Controls.Add(Me.btn_vslight)
        Me.RadGroupBox2.HeaderText = "Themes"
        Me.RadGroupBox2.Location = New System.Drawing.Point(404, 51)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(190, 236)
        Me.RadGroupBox2.TabIndex = 31
        Me.RadGroupBox2.Text = "Themes"
        Me.RadGroupBox2.ThemeName = "VisualStudio2012Dark"
        '
        'btn_w8
        '
        Me.btn_w8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_w8.Location = New System.Drawing.Point(41, 174)
        Me.btn_w8.Name = "btn_w8"
        Me.btn_w8.Size = New System.Drawing.Size(110, 24)
        Me.btn_w8.TabIndex = 8
        Me.btn_w8.Text = "Windows 8"
        Me.btn_w8.ThemeName = "VisualStudio2012Dark"
        '
        'btn_metroblue
        '
        Me.btn_metroblue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_metroblue.Location = New System.Drawing.Point(41, 144)
        Me.btn_metroblue.Name = "btn_metroblue"
        Me.btn_metroblue.Size = New System.Drawing.Size(110, 24)
        Me.btn_metroblue.TabIndex = 7
        Me.btn_metroblue.Text = "Blue Metro"
        Me.btn_metroblue.ThemeName = "VisualStudio2012Dark"
        '
        'btn_metrotheme
        '
        Me.btn_metrotheme.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_metrotheme.Location = New System.Drawing.Point(41, 114)
        Me.btn_metrotheme.Name = "btn_metrotheme"
        Me.btn_metrotheme.Size = New System.Drawing.Size(110, 24)
        Me.btn_metrotheme.TabIndex = 6
        Me.btn_metrotheme.Text = "Metro Theme"
        Me.btn_metrotheme.ThemeName = "VisualStudio2012Dark"
        '
        'btn_vsdark
        '
        Me.btn_vsdark.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_vsdark.Location = New System.Drawing.Point(41, 82)
        Me.btn_vsdark.Name = "btn_vsdark"
        Me.btn_vsdark.Size = New System.Drawing.Size(110, 24)
        Me.btn_vsdark.TabIndex = 5
        Me.btn_vsdark.Text = "VS2012 Dark"
        Me.btn_vsdark.ThemeName = "VisualStudio2012Dark"
        '
        'btn_vslight
        '
        Me.btn_vslight.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_vslight.Location = New System.Drawing.Point(41, 52)
        Me.btn_vslight.Name = "btn_vslight"
        Me.btn_vslight.Size = New System.Drawing.Size(110, 24)
        Me.btn_vslight.TabIndex = 4
        Me.btn_vslight.Text = "VS2012 Light"
        Me.btn_vslight.ThemeName = "VisualStudio2012Dark"
        '
        'log_lbl_time
        '
        Me.log_lbl_time.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.log_lbl_time.AutoSize = false
        Me.log_lbl_time.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.log_lbl_time.Location = New System.Drawing.Point(180, 24)
        Me.log_lbl_time.Name = "log_lbl_time"
        Me.log_lbl_time.Size = New System.Drawing.Size(245, 21)
        Me.log_lbl_time.TabIndex = 32
        Me.log_lbl_time.Text = "Time"
        Me.log_lbl_time.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.log_lbl_time.ThemeName = "VisualStudio2012Dark"
        '
        'settingButton
        '
        Me.settingButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.settingButton.Image = Global.CEU_TLTD_Scheduling_System.My.Resources.Resources.settingIcon
        Me.settingButton.InitialImage = Nothing
        Me.settingButton.Location = New System.Drawing.Point(556, 12)
        Me.settingButton.Name = "settingButton"
        Me.settingButton.Size = New System.Drawing.Size(37, 33)
        Me.settingButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.settingButton.TabIndex = 33
        Me.settingButton.TabStop = false
        '
        'Login
        '
        Me.AcceptButton = Me.btn_login
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 312)
        Me.Controls.Add(Me.settingButton)
        Me.Controls.Add(Me.log_lbl_time)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.log_lbl_date)
        Me.Controls.Add(Me.log_lbl_dbstatus)
        Me.Controls.Add(Me.RadLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "Login"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ThemeName = "VisualStudio2012Dark"
        Me.TopMost = true
        CType(Me.btn_login,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel17,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel14,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.log_lbl_dbstatus,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.log_username,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.log_password,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.log_lbl_date,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadGroupBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.RadGroupBox1.ResumeLayout(false)
        Me.RadGroupBox1.PerformLayout
        CType(Me.RadGroupBox2,System.ComponentModel.ISupportInitialize).EndInit
        Me.RadGroupBox2.ResumeLayout(false)
        CType(Me.btn_w8,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_metroblue,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_metrotheme,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_vsdark,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_vslight,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.log_lbl_time,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.settingButton,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents btn_login As Telerik.WinControls.UI.RadButton
    Friend WithEvents VisualStudio2012DarkTheme1 As Telerik.WinControls.Themes.VisualStudio2012DarkTheme
    Friend WithEvents RadLabel17 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel14 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents log_lbl_dbstatus As Telerik.WinControls.UI.RadLabel
    Friend WithEvents log_username As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents log_password As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents log_timer As Timer
    Friend WithEvents log_lbl_date As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents btn_w8 As Telerik.WinControls.UI.RadButton
    Friend WithEvents btn_metroblue As Telerik.WinControls.UI.RadButton
    Friend WithEvents btn_metrotheme As Telerik.WinControls.UI.RadButton
    Friend WithEvents btn_vsdark As Telerik.WinControls.UI.RadButton
    Friend WithEvents btn_vslight As Telerik.WinControls.UI.RadButton
    Friend WithEvents VisualStudio2012LightTheme1 As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Friend WithEvents TelerikMetroTheme1 As Telerik.WinControls.Themes.TelerikMetroTheme
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents log_lbl_time As Telerik.WinControls.UI.RadLabel
    Friend WithEvents settingButton As PictureBox
End Class

