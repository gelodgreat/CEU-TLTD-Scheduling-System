<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainSettingsWindow
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
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.btn_penalty_setting_save = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.penalty_ci_day = New Telerik.WinControls.UI.RadSpinEditor()
        Me.penalty_ci_hhmm = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.penalty_gp_day = New Telerik.WinControls.UI.RadSpinEditor()
        Me.penalty_gp_hhmm = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.penalty_peso_amount = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        CType(Me.RadGroupBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.RadGroupBox1.SuspendLayout
        CType(Me.btn_penalty_setting_save,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel6,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel7,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.penalty_ci_day,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.penalty_ci_hhmm,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.penalty_gp_day,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.penalty_gp_hhmm,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.penalty_peso_amount,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.btn_penalty_setting_save)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel6)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel5)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel7)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox1.Controls.Add(Me.penalty_ci_day)
        Me.RadGroupBox1.Controls.Add(Me.penalty_ci_hhmm)
        Me.RadGroupBox1.Controls.Add(Me.penalty_gp_day)
        Me.RadGroupBox1.Controls.Add(Me.penalty_gp_hhmm)
        Me.RadGroupBox1.Controls.Add(Me.penalty_peso_amount)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel2)
        Me.RadGroupBox1.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox1.HeaderText = "Penalty Handling"
        Me.RadGroupBox1.Location = New System.Drawing.Point(23, 24)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(493, 187)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "Penalty Handling"
        Me.RadGroupBox1.ThemeName = "VisualStudio2012Dark"
        '
        'btn_penalty_setting_save
        '
        Me.btn_penalty_setting_save.Location = New System.Drawing.Point(193, 151)
        Me.btn_penalty_setting_save.Name = "btn_penalty_setting_save"
        Me.btn_penalty_setting_save.Size = New System.Drawing.Size(110, 24)
        Me.btn_penalty_setting_save.TabIndex = 5
        Me.btn_penalty_setting_save.Text = "Save Settings"
        Me.btn_penalty_setting_save.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel6
        '
        Me.RadLabel6.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel6.Location = New System.Drawing.Point(331, 73)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(113, 18)
        Me.RadLabel6.TabIndex = 24
        Me.RadLabel6.Text = "hour(s) and minute(s)"
        Me.RadLabel6.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel5
        '
        Me.RadLabel5.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel5.Location = New System.Drawing.Point(331, 36)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(113, 18)
        Me.RadLabel5.TabIndex = 20
        Me.RadLabel5.Text = "hour(s) and minute(s)"
        Me.RadLabel5.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel7
        '
        Me.RadLabel7.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel7.Location = New System.Drawing.Point(211, 73)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(36, 18)
        Me.RadLabel7.TabIndex = 23
        Me.RadLabel7.Text = "day(s)"
        Me.RadLabel7.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel4
        '
        Me.RadLabel4.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel4.Location = New System.Drawing.Point(211, 36)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(36, 18)
        Me.RadLabel4.TabIndex = 19
        Me.RadLabel4.Text = "day(s)"
        Me.RadLabel4.ThemeName = "VisualStudio2012Dark"
        '
        'penalty_ci_day
        '
        Me.penalty_ci_day.Location = New System.Drawing.Point(160, 69)
        Me.penalty_ci_day.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.penalty_ci_day.MinimumSize = New System.Drawing.Size(0, 24)
        Me.penalty_ci_day.Name = "penalty_ci_day"
        '
        '
        '
        Me.penalty_ci_day.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.penalty_ci_day.Size = New System.Drawing.Size(46, 24)
        Me.penalty_ci_day.TabIndex = 2
        Me.penalty_ci_day.TabStop = false
        Me.penalty_ci_day.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.penalty_ci_day.ThemeName = "VisualStudio2012Dark"
        '
        'penalty_ci_hhmm
        '
        Me.penalty_ci_hhmm.CustomFormat = "HH:mm"
        Me.penalty_ci_hhmm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.penalty_ci_hhmm.Location = New System.Drawing.Point(258, 69)
        Me.penalty_ci_hhmm.MinimumSize = New System.Drawing.Size(0, 24)
        Me.penalty_ci_hhmm.Name = "penalty_ci_hhmm"
        '
        '
        '
        Me.penalty_ci_hhmm.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.penalty_ci_hhmm.ShowUpDown = true
        Me.penalty_ci_hhmm.Size = New System.Drawing.Size(68, 24)
        Me.penalty_ci_hhmm.TabIndex = 3
        Me.penalty_ci_hhmm.TabStop = false
        Me.penalty_ci_hhmm.Text = "00:00"
        Me.penalty_ci_hhmm.ThemeName = "VisualStudio2012Dark"
        Me.penalty_ci_hhmm.Value = New Date(CType(0,Long))
        '
        'penalty_gp_day
        '
        Me.penalty_gp_day.Location = New System.Drawing.Point(160, 32)
        Me.penalty_gp_day.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.penalty_gp_day.MinimumSize = New System.Drawing.Size(0, 24)
        Me.penalty_gp_day.Name = "penalty_gp_day"
        '
        '
        '
        Me.penalty_gp_day.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.penalty_gp_day.Size = New System.Drawing.Size(46, 24)
        Me.penalty_gp_day.TabIndex = 0
        Me.penalty_gp_day.TabStop = false
        Me.penalty_gp_day.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.penalty_gp_day.ThemeName = "VisualStudio2012Dark"
        '
        'penalty_gp_hhmm
        '
        Me.penalty_gp_hhmm.CustomFormat = "HH:mm"
        Me.penalty_gp_hhmm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.penalty_gp_hhmm.Location = New System.Drawing.Point(258, 32)
        Me.penalty_gp_hhmm.MinimumSize = New System.Drawing.Size(0, 24)
        Me.penalty_gp_hhmm.Name = "penalty_gp_hhmm"
        '
        '
        '
        Me.penalty_gp_hhmm.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.penalty_gp_hhmm.ShowUpDown = true
        Me.penalty_gp_hhmm.Size = New System.Drawing.Size(68, 24)
        Me.penalty_gp_hhmm.TabIndex = 1
        Me.penalty_gp_hhmm.TabStop = false
        Me.penalty_gp_hhmm.Text = "00:00"
        Me.penalty_gp_hhmm.ThemeName = "VisualStudio2012Dark"
        Me.penalty_gp_hhmm.Value = New Date(CType(0,Long))
        '
        'penalty_peso_amount
        '
        Me.penalty_peso_amount.Location = New System.Drawing.Point(160, 106)
        Me.penalty_peso_amount.MinimumSize = New System.Drawing.Size(0, 24)
        Me.penalty_peso_amount.Name = "penalty_peso_amount"
        Me.penalty_peso_amount.NullText = "Peso Amout"
        '
        '
        '
        Me.penalty_peso_amount.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.penalty_peso_amount.Size = New System.Drawing.Size(87, 24)
        Me.penalty_peso_amount.TabIndex = 4
        Me.penalty_peso_amount.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel3
        '
        Me.RadLabel3.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel3.Location = New System.Drawing.Point(110, 108)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(31, 18)
        Me.RadLabel3.TabIndex = 2
        Me.RadLabel3.Text = "Rate:"
        Me.RadLabel3.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel2
        '
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.Location = New System.Drawing.Point(59, 72)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(85, 18)
        Me.RadLabel2.TabIndex = 1
        Me.RadLabel2.Text = "Charge Interval:"
        Me.RadLabel2.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel1
        '
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Location = New System.Drawing.Point(71, 35)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(73, 18)
        Me.RadLabel1.TabIndex = 0
        Me.RadLabel1.Text = "Grace Period:"
        Me.RadLabel1.ThemeName = "VisualStudio2012Dark"
        '
        'MainSettingsWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 243)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "MainSettingsWindow"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.ThemeName = "VisualStudio2012Dark"
        Me.TopMost = true
        CType(Me.RadGroupBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.RadGroupBox1.ResumeLayout(false)
        Me.RadGroupBox1.PerformLayout
        CType(Me.btn_penalty_setting_save,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel6,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel7,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.penalty_ci_day,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.penalty_ci_hhmm,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.penalty_gp_day,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.penalty_gp_hhmm,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.penalty_peso_amount,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents penalty_gp_hhmm As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents penalty_peso_amount As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents penalty_ci_day As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents penalty_ci_hhmm As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents penalty_gp_day As Telerik.WinControls.UI.RadSpinEditor
    Friend WithEvents btn_penalty_setting_save As Telerik.WinControls.UI.RadButton
End Class

