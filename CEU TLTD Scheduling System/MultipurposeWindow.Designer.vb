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
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultipurposeWindow))
        Me.PanelMultipleReturn = New Telerik.WinControls.UI.RadPanel()
        Me.lst_Returned = New Telerik.WinControls.UI.RadGridView()
        Me.btn_Close = New Telerik.WinControls.UI.RadButton()
        Me.PanelConflictingReservation = New Telerik.WinControls.UI.RadPanel()
        Me.btn_ResOK = New Telerik.WinControls.UI.RadButton()
        Me.lst_res_conflicts = New Telerik.WinControls.UI.RadGridView()
        CType(Me.PanelMultipleReturn,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelMultipleReturn.SuspendLayout
        CType(Me.lst_Returned,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lst_Returned.MasterTemplate,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.btn_Close,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PanelConflictingReservation,System.ComponentModel.ISupportInitialize).BeginInit
        Me.PanelConflictingReservation.SuspendLayout
        CType(Me.btn_ResOK,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lst_res_conflicts,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.lst_res_conflicts.MasterTemplate,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'PanelMultipleReturn
        '
        Me.PanelMultipleReturn.Controls.Add(Me.lst_Returned)
        Me.PanelMultipleReturn.Controls.Add(Me.btn_Close)
        Me.PanelMultipleReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMultipleReturn.Location = New System.Drawing.Point(0, 0)
        Me.PanelMultipleReturn.Name = "PanelMultipleReturn"
        Me.PanelMultipleReturn.Size = New System.Drawing.Size(630, 385)
        Me.PanelMultipleReturn.TabIndex = 0
        Me.PanelMultipleReturn.ThemeName = "VisualStudio2012Dark"
        Me.PanelMultipleReturn.Visible = false
        '
        'lst_Returned
        '
        Me.lst_Returned.Dock = System.Windows.Forms.DockStyle.Top
        Me.lst_Returned.Location = New System.Drawing.Point(0, 0)
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
        GridViewTextBoxColumn1.Width = 116
        GridViewTextBoxColumn2.HeaderText = "Equipment Type"
        GridViewTextBoxColumn2.Name = "ColEqType"
        GridViewTextBoxColumn2.Width = 323
        GridViewTextBoxColumn3.HeaderText = "Charge"
        GridViewTextBoxColumn3.Name = "ColCharge"
        GridViewTextBoxColumn3.Width = 95
        GridViewTextBoxColumn4.HeaderText = "Duration Exceeded"
        GridViewTextBoxColumn4.Name = "ColExceededTime"
        GridViewTextBoxColumn4.Width = 100
        Me.lst_Returned.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.lst_Returned.MasterTemplate.EnableGrouping = false
        Me.lst_Returned.MasterTemplate.ShowFilteringRow = false
        Me.lst_Returned.MasterTemplate.ShowRowHeaderColumn = false
        Me.lst_Returned.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.lst_Returned.Name = "lst_Returned"
        Me.lst_Returned.ReadOnly = true
        Me.lst_Returned.Size = New System.Drawing.Size(630, 341)
        Me.lst_Returned.TabIndex = 0
        Me.lst_Returned.ThemeName = "VisualStudio2012Dark"
        '
        'btn_Close
        '
        Me.btn_Close.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Close.Location = New System.Drawing.Point(285, 350)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(110, 24)
        Me.btn_Close.TabIndex = 1
        Me.btn_Close.Text = "Ok"
        Me.btn_Close.ThemeName = "VisualStudio2012Dark"
        '
        'PanelConflictingReservation
        '
        Me.PanelConflictingReservation.Controls.Add(Me.btn_ResOK)
        Me.PanelConflictingReservation.Controls.Add(Me.lst_res_conflicts)
        Me.PanelConflictingReservation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelConflictingReservation.Location = New System.Drawing.Point(0, 0)
        Me.PanelConflictingReservation.Name = "PanelConflictingReservation"
        Me.PanelConflictingReservation.Size = New System.Drawing.Size(630, 385)
        Me.PanelConflictingReservation.TabIndex = 1
        Me.PanelConflictingReservation.ThemeName = "VisualStudio2012Dark"
        Me.PanelConflictingReservation.Visible = false
        '
        'btn_ResOK
        '
        Me.btn_ResOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_ResOK.Location = New System.Drawing.Point(265, 350)
        Me.btn_ResOK.Name = "btn_ResOK"
        Me.btn_ResOK.Size = New System.Drawing.Size(110, 24)
        Me.btn_ResOK.TabIndex = 2
        Me.btn_ResOK.Text = "Ok"
        Me.btn_ResOK.ThemeName = "VisualStudio2012Dark"
        '
        'lst_res_conflicts
        '
        Me.lst_res_conflicts.Dock = System.Windows.Forms.DockStyle.Top
        Me.lst_res_conflicts.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.lst_res_conflicts.MasterTemplate.AllowAddNewRow = false
        Me.lst_res_conflicts.MasterTemplate.AllowColumnChooser = false
        Me.lst_res_conflicts.MasterTemplate.AllowColumnHeaderContextMenu = false
        Me.lst_res_conflicts.MasterTemplate.AllowColumnReorder = false
        Me.lst_res_conflicts.MasterTemplate.AllowDeleteRow = false
        Me.lst_res_conflicts.MasterTemplate.AllowDragToGroup = false
        Me.lst_res_conflicts.MasterTemplate.AllowEditRow = false
        Me.lst_res_conflicts.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewTextBoxColumn5.HeaderText = "Equipment Type"
        GridViewTextBoxColumn5.Name = "ColEqType"
        GridViewTextBoxColumn5.Width = 122
        GridViewTextBoxColumn6.HeaderText = "Equipment Serial"
        GridViewTextBoxColumn6.Name = "ColSerialNo"
        GridViewTextBoxColumn6.Width = 94
        GridViewTextBoxColumn7.HeaderText = "Equipment No."
        GridViewTextBoxColumn7.Name = "ColEquipmentNo"
        GridViewTextBoxColumn7.Width = 118
        GridViewTextBoxColumn8.HeaderText = "Equipment Name"
        GridViewTextBoxColumn8.Name = "ColEquipment"
        GridViewTextBoxColumn8.Width = 136
        GridViewTextBoxColumn9.HeaderText = "Date"
        GridViewTextBoxColumn9.Name = "ColDate"
        GridViewTextBoxColumn9.Width = 79
        GridViewTextBoxColumn10.HeaderText = "Start Time"
        GridViewTextBoxColumn10.Name = "ColSTime"
        GridViewTextBoxColumn10.Width = 44
        GridViewTextBoxColumn11.HeaderText = "End Time"
        GridViewTextBoxColumn11.Name = "ColETime"
        GridViewTextBoxColumn11.Width = 44
        Me.lst_res_conflicts.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11})
        Me.lst_res_conflicts.MasterTemplate.EnableGrouping = false
        Me.lst_res_conflicts.MasterTemplate.ShowFilteringRow = false
        Me.lst_res_conflicts.MasterTemplate.ShowRowHeaderColumn = false
        Me.lst_res_conflicts.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.lst_res_conflicts.Name = "lst_res_conflicts"
        Me.lst_res_conflicts.ReadOnly = true
        Me.lst_res_conflicts.Size = New System.Drawing.Size(630, 342)
        Me.lst_res_conflicts.TabIndex = 1
        Me.lst_res_conflicts.ThemeName = "VisualStudio2012Dark"
        '
        'MultipurposeWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 385)
        Me.Controls.Add(Me.PanelConflictingReservation)
        Me.Controls.Add(Me.PanelMultipleReturn)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "MultipurposeWindow"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = true
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MultiPurposeWindow"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.PanelMultipleReturn,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelMultipleReturn.ResumeLayout(false)
        CType(Me.lst_Returned.MasterTemplate,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lst_Returned,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.btn_Close,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PanelConflictingReservation,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelConflictingReservation.ResumeLayout(false)
        CType(Me.btn_ResOK,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lst_res_conflicts.MasterTemplate,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.lst_res_conflicts,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents PanelMultipleReturn As Telerik.WinControls.UI.RadPanel
    Friend WithEvents lst_Returned As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btn_Close As Telerik.WinControls.UI.RadButton
    Friend WithEvents PanelConflictingReservation As Telerik.WinControls.UI.RadPanel
    Friend WithEvents lst_res_conflicts As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btn_ResOK As Telerik.WinControls.UI.RadButton
End Class

