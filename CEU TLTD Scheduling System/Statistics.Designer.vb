<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Statistics
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Statistics))
        Me.btn_Close = New Telerik.WinControls.UI.RadButton()
        Me.RadPageView1 = New Telerik.WinControls.UI.RadPageView()
        Me.Equipment = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Summary = New Telerik.WinControls.UI.RadPageViewPage()
        Me.lbl_most_bor_eq = New Telerik.WinControls.UI.RadLabel()
        Me.lbl_res_t_yr = New Telerik.WinControls.UI.RadLabel()
        Me.lbl_res_t_m = New Telerik.WinControls.UI.RadLabel()
        Me.lbl_res_t_wk = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.rgv_StatsByEq = New Telerik.WinControls.UI.RadGridView()
        CType(Me.btn_Close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.Equipment.SuspendLayout()
        Me.Summary.SuspendLayout()
        CType(Me.lbl_most_bor_eq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_res_t_yr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_res_t_m, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbl_res_t_wk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgv_StatsByEq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgv_StatsByEq.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Close
        '
        Me.btn_Close.Location = New System.Drawing.Point(13, 407)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(110, 24)
        Me.btn_Close.TabIndex = 5
        Me.btn_Close.Text = "Close"
        Me.btn_Close.ThemeName = "VisualStudio2012Dark"
        '
        'RadPageView1
        '
        Me.RadPageView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadPageView1.Controls.Add(Me.Equipment)
        Me.RadPageView1.Controls.Add(Me.Summary)
        Me.RadPageView1.Location = New System.Drawing.Point(-4, 12)
        Me.RadPageView1.Name = "RadPageView1"
        Me.RadPageView1.SelectedPage = Me.Equipment
        Me.RadPageView1.Size = New System.Drawing.Size(695, 370)
        Me.RadPageView1.TabIndex = 6
        Me.RadPageView1.Text = "RadPageView1"
        Me.RadPageView1.ThemeName = "VisualStudio2012Dark"
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemPinButton = False
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        CType(Me.RadPageView1.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemCloseButton = False
        '
        'Equipment
        '
        Me.Equipment.Controls.Add(Me.rgv_StatsByEq)
        Me.Equipment.ItemSize = New System.Drawing.SizeF(81.0!, 24.0!)
        Me.Equipment.Location = New System.Drawing.Point(5, 30)
        Me.Equipment.Name = "Equipment"
        Me.Equipment.Size = New System.Drawing.Size(685, 335)
        Me.Equipment.Text = "By Equipment"
        '
        'Summary
        '
        Me.Summary.Controls.Add(Me.lbl_most_bor_eq)
        Me.Summary.Controls.Add(Me.lbl_res_t_yr)
        Me.Summary.Controls.Add(Me.lbl_res_t_m)
        Me.Summary.Controls.Add(Me.lbl_res_t_wk)
        Me.Summary.Controls.Add(Me.RadLabel4)
        Me.Summary.Controls.Add(Me.RadLabel3)
        Me.Summary.Controls.Add(Me.RadLabel2)
        Me.Summary.Controls.Add(Me.RadLabel1)
        Me.Summary.ItemSize = New System.Drawing.SizeF(59.0!, 24.0!)
        Me.Summary.Location = New System.Drawing.Point(205, 4)
        Me.Summary.Name = "Summary"
        Me.Summary.Size = New System.Drawing.Size(475, 362)
        Me.Summary.Text = "Summary"
        '
        'lbl_most_bor_eq
        '
        Me.lbl_most_bor_eq.AutoSize = False
        Me.lbl_most_bor_eq.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_most_bor_eq.Location = New System.Drawing.Point(332, 226)
        Me.lbl_most_bor_eq.Name = "lbl_most_bor_eq"
        Me.lbl_most_bor_eq.Size = New System.Drawing.Size(231, 25)
        Me.lbl_most_bor_eq.TabIndex = 12
        Me.lbl_most_bor_eq.Text = "Microphone"
        Me.lbl_most_bor_eq.ThemeName = "VisualStudio2012Dark"
        '
        'lbl_res_t_yr
        '
        Me.lbl_res_t_yr.AutoSize = False
        Me.lbl_res_t_yr.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_res_t_yr.Location = New System.Drawing.Point(332, 176)
        Me.lbl_res_t_yr.Name = "lbl_res_t_yr"
        Me.lbl_res_t_yr.Size = New System.Drawing.Size(231, 25)
        Me.lbl_res_t_yr.TabIndex = 10
        Me.lbl_res_t_yr.Text = "1000"
        Me.lbl_res_t_yr.ThemeName = "VisualStudio2012Dark"
        '
        'lbl_res_t_m
        '
        Me.lbl_res_t_m.AutoSize = False
        Me.lbl_res_t_m.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_res_t_m.Location = New System.Drawing.Point(331, 123)
        Me.lbl_res_t_m.Name = "lbl_res_t_m"
        Me.lbl_res_t_m.Size = New System.Drawing.Size(231, 25)
        Me.lbl_res_t_m.TabIndex = 8
        Me.lbl_res_t_m.Text = "1000"
        Me.lbl_res_t_m.ThemeName = "VisualStudio2012Dark"
        '
        'lbl_res_t_wk
        '
        Me.lbl_res_t_wk.AutoSize = False
        Me.lbl_res_t_wk.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_res_t_wk.Location = New System.Drawing.Point(331, 70)
        Me.lbl_res_t_wk.Name = "lbl_res_t_wk"
        Me.lbl_res_t_wk.Size = New System.Drawing.Size(231, 25)
        Me.lbl_res_t_wk.TabIndex = 6
        Me.lbl_res_t_wk.Text = "1000"
        Me.lbl_res_t_wk.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel4
        '
        Me.RadLabel4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel4.Location = New System.Drawing.Point(118, 228)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(207, 25)
        Me.RadLabel4.TabIndex = 11
        Me.RadLabel4.Text = "Most Borrowed Equipment:"
        Me.RadLabel4.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel3
        '
        Me.RadLabel3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel3.Location = New System.Drawing.Point(151, 178)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(173, 25)
        Me.RadLabel3.TabIndex = 9
        Me.RadLabel3.Text = "Reservations This Year:"
        Me.RadLabel3.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel2
        '
        Me.RadLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(136, 125)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(190, 25)
        Me.RadLabel2.TabIndex = 7
        Me.RadLabel2.Text = "Reservations This Month:"
        Me.RadLabel2.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel1
        '
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(94, 73)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(231, 25)
        Me.RadLabel1.TabIndex = 5
        Me.RadLabel1.Text = "Reservations Places This Week:"
        Me.RadLabel1.ThemeName = "VisualStudio2012Dark"
        '
        'rgv_StatsByEq
        '
        Me.rgv_StatsByEq.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.rgv_StatsByEq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgv_StatsByEq.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.rgv_StatsByEq.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.rgv_StatsByEq.MasterTemplate.AllowAddNewRow = False
        Me.rgv_StatsByEq.MasterTemplate.AllowColumnReorder = False
        Me.rgv_StatsByEq.MasterTemplate.AllowDragToGroup = False
        Me.rgv_StatsByEq.MasterTemplate.AllowEditRow = False
        Me.rgv_StatsByEq.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        Me.rgv_StatsByEq.MasterTemplate.ShowFilteringRow = False
        Me.rgv_StatsByEq.MasterTemplate.ShowRowHeaderColumn = False
        Me.rgv_StatsByEq.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.rgv_StatsByEq.Name = "rgv_StatsByEq"
        Me.rgv_StatsByEq.ReadOnly = True
        Me.rgv_StatsByEq.ShowGroupPanel = False
        Me.rgv_StatsByEq.ShowGroupPanelScrollbars = False
        Me.rgv_StatsByEq.Size = New System.Drawing.Size(685, 335)
        Me.rgv_StatsByEq.TabIndex = 0
        Me.rgv_StatsByEq.Text = "RadGridView1"
        Me.rgv_StatsByEq.ThemeName = "VisualStudio2012Dark"
        '
        'Statistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 443)
        Me.Controls.Add(Me.RadPageView1)
        Me.Controls.Add(Me.btn_Close)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Statistics"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Statistics"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.btn_Close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.Equipment.ResumeLayout(False)
        Me.Summary.ResumeLayout(False)
        Me.Summary.PerformLayout()
        CType(Me.lbl_most_bor_eq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_res_t_yr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_res_t_m, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbl_res_t_wk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgv_StatsByEq.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgv_StatsByEq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Close As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents Equipment As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Summary As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents lbl_most_bor_eq As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lbl_res_t_yr As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lbl_res_t_m As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lbl_res_t_wk As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents rgv_StatsByEq As Telerik.WinControls.UI.RadGridView
End Class

