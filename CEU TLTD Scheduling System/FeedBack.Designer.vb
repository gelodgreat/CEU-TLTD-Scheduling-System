<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FeedBack
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FeedBack))
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.message = New Telerik.WinControls.UI.RadTextBoxControl()
        Me.btn_submit = New Telerik.WinControls.UI.RadButton()
        CType(Me.RadGroupBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.RadGroupBox1.SuspendLayout
        CType(Me.message,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_submit,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.message)
        Me.RadGroupBox1.HeaderText = "Message"
        Me.RadGroupBox1.Location = New System.Drawing.Point(36, 9)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(447, 298)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "Message"
        Me.RadGroupBox1.ThemeName = "VisualStudio2012Dark"
        '
        'message
        '
        Me.message.Dock = System.Windows.Forms.DockStyle.Fill
        Me.message.Location = New System.Drawing.Point(2, 18)
        Me.message.Name = "message"
        Me.message.Size = New System.Drawing.Size(443, 278)
        Me.message.TabIndex = 0
        Me.message.ThemeName = "VisualStudio2012Dark"
        '
        'btn_submit
        '
        Me.btn_submit.Location = New System.Drawing.Point(214, 313)
        Me.btn_submit.Name = "btn_submit"
        Me.btn_submit.Size = New System.Drawing.Size(110, 24)
        Me.btn_submit.TabIndex = 1
        Me.btn_submit.Text = "Submit Feedback"
        Me.btn_submit.ThemeName = "VisualStudio2012Dark"
        '
        'FeedBack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 345)
        Me.Controls.Add(Me.btn_submit)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MaximumSize = New System.Drawing.Size(526, 378)
        Me.MinimizeBox = false
        Me.MinimumSize = New System.Drawing.Size(526, 378)
        Me.Name = "FeedBack"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.RootElement.MaxSize = New System.Drawing.Size(526, 378)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Leave Feedback"
        Me.ThemeName = "VisualStudio2012Dark"
        Me.TopMost = true
        CType(Me.RadGroupBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.RadGroupBox1.ResumeLayout(false)
        CType(Me.message,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_submit,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents message As Telerik.WinControls.UI.RadTextBoxControl
    Friend WithEvents btn_submit As Telerik.WinControls.UI.RadButton
End Class

