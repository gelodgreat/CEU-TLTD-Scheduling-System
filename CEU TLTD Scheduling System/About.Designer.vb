<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadTextBox1 = New Telerik.WinControls.UI.RadTextBox()
        CType(Me.RadLabel1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadLabel2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RadTextBox1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom),System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(112, 12)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(195, 21)
        Me.RadLabel1.TabIndex = 5
        Me.RadLabel1.Text = "CEU TLTD Reservation System"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadLabel1.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel2
        '
        Me.RadLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom),System.Windows.Forms.AnchorStyles)
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.RadLabel2.Location = New System.Drawing.Point(327, 13)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(46, 20)
        Me.RadLabel2.TabIndex = 6
        Me.RadLabel2.Text = "v. 4.2.2"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadLabel2.ThemeName = "VisualStudio2012Dark"
        '
        'RadTextBox1
        '
        Me.RadTextBox1.AutoSize = false
        Me.RadTextBox1.Location = New System.Drawing.Point(67, 57)
        Me.RadTextBox1.Multiline = true
        Me.RadTextBox1.Name = "RadTextBox1"
        Me.RadTextBox1.ReadOnly = true
        Me.RadTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.RadTextBox1.Size = New System.Drawing.Size(351, 177)
        Me.RadTextBox1.TabIndex = 7
        Me.RadTextBox1.Text = resources.GetString("RadTextBox1.Text")
        Me.RadTextBox1.ThemeName = "VisualStudio2012Dark"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = false
        Me.ClientSize = New System.Drawing.Size(486, 284)
        Me.ControlBox = false
        Me.Controls.Add(Me.RadTextBox1)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.RadLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "About"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.ShowIcon = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.ThemeName = "VisualStudio2012Dark"
        Me.TopMost = true
        CType(Me.RadLabel1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadLabel2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RadTextBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadTextBox1 As Telerik.WinControls.UI.RadTextBox
End Class

