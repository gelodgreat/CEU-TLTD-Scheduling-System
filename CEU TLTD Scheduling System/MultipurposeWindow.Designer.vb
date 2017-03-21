<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultipurposeWindow
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultipurposeWindow))
        Me.PanelMultipleReturn = New Telerik.WinControls.UI.RadPanel()
        Me.lst_Returned = New Telerik.WinControls.UI.RadGridView()
        Me.btn_Close = New Telerik.WinControls.UI.RadButton()
        CType(Me.PanelMultipleReturn,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelMultipleReturn.SuspendLayout
        CType(Me.lst_Returned,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lst_Returned.MasterTemplate,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_Close,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'PanelMultipleReturn
        '
        Me.PanelMultipleReturn.Controls.Add(Me.btn_Close)
        Me.PanelMultipleReturn.Controls.Add(Me.lst_Returned)
        Me.PanelMultipleReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMultipleReturn.Location = New System.Drawing.Point(0, 0)
        Me.PanelMultipleReturn.Name = "PanelMultipleReturn"
        Me.PanelMultipleReturn.Size = New System.Drawing.Size(628, 387)
        Me.PanelMultipleReturn.TabIndex = 0
        Me.PanelMultipleReturn.ThemeName = "VisualStudio2012Dark"
        Me.PanelMultipleReturn.Visible = false
        '
        'lst_Returned
        '
        Me.lst_Returned.EnableFastScrolling = true
        Me.lst_Returned.Location = New System.Drawing.Point(12, 12)
        '
        '
        '
        Me.lst_Returned.MasterTemplate.AllowAddNewRow = false
        Me.lst_Returned.MasterTemplate.AllowColumnChooser = false
        Me.lst_Returned.MasterTemplate.AllowColumnHeaderContextMenu = false
        Me.lst_Returned.MasterTemplate.AllowColumnReorder = false
        Me.lst_Returned.MasterTemplate.AllowDeleteRow = false
        Me.lst_Returned.MasterTemplate.AllowDragToGroup = false
        Me.lst_Returned.MasterTemplate.AllowEditRow = false
        Me.lst_Returned.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewTextBoxColumn1.HeaderText = "Borrower"
        GridViewTextBoxColumn1.Name = "ColBorrower"
        GridViewTextBoxColumn1.Width = 112
        GridViewTextBoxColumn2.HeaderText = "Equipment Type"
        GridViewTextBoxColumn2.Name = "ColEqType"
        GridViewTextBoxColumn2.Width = 310
        GridViewTextBoxColumn3.HeaderText = "Charge"
        GridViewTextBoxColumn3.Name = "ColCharge"
        GridViewTextBoxColumn3.Width = 91
        GridViewTextBoxColumn4.HeaderText = "Duration Exceeded"
        GridViewTextBoxColumn4.Name = "ColExceededTime"
        GridViewTextBoxColumn4.Width = 95
        Me.lst_Returned.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.lst_Returned.MasterTemplate.EnableGrouping = false
        Me.lst_Returned.MasterTemplate.ShowFilteringRow = false
        Me.lst_Returned.MasterTemplate.ShowRowHeaderColumn = false
        Me.lst_Returned.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.lst_Returned.Name = "lst_Returned"
        Me.lst_Returned.ReadOnly = true
        Me.lst_Returned.Size = New System.Drawing.Size(604, 318)
        Me.lst_Returned.TabIndex = 0
        Me.lst_Returned.ThemeName = "VisualStudio2012Dark"
        '
        'btn_Close
        '
        Me.btn_Close.Location = New System.Drawing.Point(268, 351)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(110, 24)
        Me.btn_Close.TabIndex = 1
        Me.btn_Close.Text = "Ok"
        Me.btn_Close.ThemeName = "VisualStudio2012Dark"
        '
        'MultipurposeWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 387)
        Me.Controls.Add(Me.PanelMultipleReturn)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "MultipurposeWindow"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MultiPurposeWindow"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.PanelMultipleReturn,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelMultipleReturn.ResumeLayout(false)
        CType(Me.lst_Returned.MasterTemplate,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lst_Returned,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_Close,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents PanelMultipleReturn As Telerik.WinControls.UI.RadPanel
    Friend WithEvents lst_Returned As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btn_Close As Telerik.WinControls.UI.RadButton
End Class

