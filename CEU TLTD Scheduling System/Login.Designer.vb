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
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.VisualStudio2012LightTheme1 = New Telerik.WinControls.Themes.VisualStudio2012LightTheme()
        Me.TelerikMetroTheme1 = New Telerik.WinControls.Themes.TelerikMetroTheme()
        Me.Windows8Theme1 = New Telerik.WinControls.Themes.Windows8Theme()
        Me.TelerikMetroBlueTheme1 = New Telerik.WinControls.Themes.TelerikMetroBlueTheme()
        Me.log_lbl_time = New Telerik.WinControls.UI.RadLabel()
        Me.lbl_reservation_status = New Telerik.WinControls.UI.RadLabel()
        Me.lbl_prevmain_status = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
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
        CType(Me.RadLabel2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.log_lbl_time,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lbl_reservation_status,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lbl_prevmain_status,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.settingButton,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btn_login
        '
        Me.btn_login.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_login.Location = New System.Drawing.Point(198, 184)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(120, 24)
        Me.btn_login.TabIndex = 3
        Me.btn_login.Text = "Login"
        Me.btn_login.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel17
        '
        Me.RadLabel17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom),System.Windows.Forms.AnchorStyles)
        Me.RadLabel17.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel17.Location = New System.Drawing.Point(109, 109)
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
        Me.RadLabel14.Location = New System.Drawing.Point(128, 79)
        Me.RadLabel14.Name = "RadLabel14"
        Me.RadLabel14.Size = New System.Drawing.Size(35, 18)
        Me.RadLabel14.TabIndex = 23
        Me.RadLabel14.Text = "Email:"
        Me.RadLabel14.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(3, -1)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(40, 18)
        Me.RadLabel1.TabIndex = 25
        Me.RadLabel1.Text = "Server:"
        Me.RadLabel1.ThemeName = "VisualStudio2012Dark"
        '
        'log_lbl_dbstatus
        '
        Me.log_lbl_dbstatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.log_lbl_dbstatus.BackColor = System.Drawing.Color.Transparent
        Me.log_lbl_dbstatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.log_lbl_dbstatus.Location = New System.Drawing.Point(49, -1)
        Me.log_lbl_dbstatus.Name = "log_lbl_dbstatus"
        Me.log_lbl_dbstatus.Size = New System.Drawing.Size(83, 18)
        Me.log_lbl_dbstatus.TabIndex = 26
        Me.log_lbl_dbstatus.Text = "Online/Offline"
        Me.log_lbl_dbstatus.ThemeName = "VisualStudio2012Dark"
        '
        'log_username
        '
        Me.log_username.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom),System.Windows.Forms.AnchorStyles)
        Me.log_username.Location = New System.Drawing.Point(171, 78)
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
        Me.log_password.Location = New System.Drawing.Point(171, 108)
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
        Me.log_lbl_date.Location = New System.Drawing.Point(253, 0)
        Me.log_lbl_date.Name = "log_lbl_date"
        Me.log_lbl_date.Size = New System.Drawing.Size(178, 21)
        Me.log_lbl_date.TabIndex = 29
        Me.log_lbl_date.Text = "Date"
        Me.log_lbl_date.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.log_lbl_date.ThemeName = "VisualStudio2012Dark"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox1.Controls.Add(Me.btn_login)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel14)
        Me.RadGroupBox1.Controls.Add(Me.log_password)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel17)
        Me.RadGroupBox1.Controls.Add(Me.log_username)
        Me.RadGroupBox1.HeaderText = ""
        Me.RadGroupBox1.Location = New System.Drawing.Point(2, 52)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(487, 256)
        Me.RadGroupBox1.TabIndex = 30
        Me.RadGroupBox1.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel2
        '
        Me.RadLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(3, 32)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(116, 18)
        Me.RadLabel2.TabIndex = 26
        Me.RadLabel2.Text = "Reservation Database:"
        Me.RadLabel2.ThemeName = "VisualStudio2012Dark"
        '
        'log_lbl_time
        '
        Me.log_lbl_time.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.log_lbl_time.AutoSize = false
        Me.log_lbl_time.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.log_lbl_time.Location = New System.Drawing.Point(253, 25)
        Me.log_lbl_time.Name = "log_lbl_time"
        Me.log_lbl_time.Size = New System.Drawing.Size(178, 21)
        Me.log_lbl_time.TabIndex = 32
        Me.log_lbl_time.Text = "Time"
        Me.log_lbl_time.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.log_lbl_time.ThemeName = "VisualStudio2012Dark"
        '
        'lbl_reservation_status
        '
        Me.lbl_reservation_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lbl_reservation_status.BackColor = System.Drawing.Color.Transparent
        Me.lbl_reservation_status.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lbl_reservation_status.Location = New System.Drawing.Point(185, 33)
        Me.lbl_reservation_status.Name = "lbl_reservation_status"
        Me.lbl_reservation_status.Size = New System.Drawing.Size(68, 18)
        Me.lbl_reservation_status.TabIndex = 27
        Me.lbl_reservation_status.Text = "Unavailable"
        Me.lbl_reservation_status.ThemeName = "VisualStudio2012Dark"
        '
        'lbl_prevmain_status
        '
        Me.lbl_prevmain_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lbl_prevmain_status.BackColor = System.Drawing.Color.Transparent
        Me.lbl_prevmain_status.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lbl_prevmain_status.Location = New System.Drawing.Point(184, 15)
        Me.lbl_prevmain_status.Name = "lbl_prevmain_status"
        Me.lbl_prevmain_status.Size = New System.Drawing.Size(68, 18)
        Me.lbl_prevmain_status.TabIndex = 29
        Me.lbl_prevmain_status.Text = "Unavailable"
        Me.lbl_prevmain_status.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel5
        '
        Me.RadLabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RadLabel5.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RadLabel5.Location = New System.Drawing.Point(2, 15)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(178, 18)
        Me.RadLabel5.TabIndex = 28
        Me.RadLabel5.Text = "Preventive Maintenance Database:"
        Me.RadLabel5.ThemeName = "VisualStudio2012Dark"
        '
        'settingButton
        '
        Me.settingButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.settingButton.Image = Global.CEU_TLTD_Reservation_System.My.Resources.Resources.settingIcon
        Me.settingButton.InitialImage = Nothing
        Me.settingButton.Location = New System.Drawing.Point(437, 6)
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
        Me.ClientSize = New System.Drawing.Size(491, 312)
        Me.Controls.Add(Me.lbl_prevmain_status)
        Me.Controls.Add(Me.settingButton)
        Me.Controls.Add(Me.lbl_reservation_status)
        Me.Controls.Add(Me.RadLabel5)
        Me.Controls.Add(Me.log_lbl_time)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.log_lbl_date)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.log_lbl_dbstatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
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
        CType(Me.RadLabel2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.log_lbl_time,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lbl_reservation_status,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lbl_prevmain_status,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel5,System.ComponentModel.ISupportInitialize).EndInit
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
    Friend WithEvents VisualStudio2012LightTheme1 As Telerik.WinControls.Themes.VisualStudio2012LightTheme
    Friend WithEvents TelerikMetroTheme1 As Telerik.WinControls.Themes.TelerikMetroTheme
    Friend WithEvents Windows8Theme1 As Telerik.WinControls.Themes.Windows8Theme
    Friend WithEvents TelerikMetroBlueTheme1 As Telerik.WinControls.Themes.TelerikMetroBlueTheme
    Friend WithEvents log_lbl_time As Telerik.WinControls.UI.RadLabel
    Friend WithEvents settingButton As PictureBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lbl_reservation_status As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lbl_prevmain_status As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
End Class

