<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChangeEquipmentReservation
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.che_rgv_eq = New Telerik.WinControls.UI.RadGridView()
        Me.RadGroupBox5 = New Telerik.WinControls.UI.RadGroupBox()
        Me.rec_cb_reserveno = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel72 = New Telerik.WinControls.UI.RadLabel()
        Me.rec_eq_chooseeq = New Telerik.WinControls.UI.RadDropDownList()
        Me.rec_eq_type_choose = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel71 = New Telerik.WinControls.UI.RadLabel()
        Me.rec_btn_check_availability = New Telerik.WinControls.UI.RadButton()
        Me.rec_btn_add_eq = New Telerik.WinControls.UI.RadButton()
        Me.rec_btn_eqclear = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel70 = New Telerik.WinControls.UI.RadLabel()
        Me.rec_eq_choosesn = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel50 = New Telerik.WinControls.UI.RadLabel()
        Me.rec_del_eq = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox17 = New Telerik.WinControls.UI.RadGroupBox()
        Me.eq_rgv_addeq = New Telerik.WinControls.UI.RadGridView()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.che_rgv_eq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.che_rgv_eq.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox5.SuspendLayout()
        CType(Me.rec_cb_reserveno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel72, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rec_eq_chooseeq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rec_eq_type_choose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel71, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rec_btn_check_availability, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rec_btn_add_eq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rec_btn_eqclear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel70, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rec_eq_choosesn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rec_del_eq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox17.SuspendLayout()
        CType(Me.eq_rgv_addeq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eq_rgv_addeq.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.che_rgv_eq)
        Me.RadGroupBox1.HeaderText = "RadGroupBox1"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(901, 223)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "RadGroupBox1"
        Me.RadGroupBox1.ThemeName = "VisualStudio2012Dark"
        '
        'che_rgv_eq
        '
        Me.che_rgv_eq.AutoSizeRows = True
        Me.che_rgv_eq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.che_rgv_eq.Location = New System.Drawing.Point(2, 18)
        '
        '
        '
        Me.che_rgv_eq.MasterTemplate.AllowAddNewRow = False
        Me.che_rgv_eq.MasterTemplate.AllowDeleteRow = False
        Me.che_rgv_eq.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        Me.che_rgv_eq.MasterTemplate.EnableGrouping = False
        Me.che_rgv_eq.MasterTemplate.ShowRowHeaderColumn = False
        Me.che_rgv_eq.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.che_rgv_eq.Name = "che_rgv_eq"
        Me.che_rgv_eq.ReadOnly = True
        Me.che_rgv_eq.Size = New System.Drawing.Size(897, 203)
        Me.che_rgv_eq.TabIndex = 0
        Me.che_rgv_eq.Text = "cer_rgv_eq"
        Me.che_rgv_eq.ThemeName = "VisualStudio2012Dark"
        '
        'RadGroupBox5
        '
        Me.RadGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox5.Controls.Add(Me.rec_cb_reserveno)
        Me.RadGroupBox5.Controls.Add(Me.RadLabel72)
        Me.RadGroupBox5.Controls.Add(Me.rec_eq_chooseeq)
        Me.RadGroupBox5.Controls.Add(Me.rec_eq_type_choose)
        Me.RadGroupBox5.Controls.Add(Me.RadLabel71)
        Me.RadGroupBox5.Controls.Add(Me.rec_btn_check_availability)
        Me.RadGroupBox5.Controls.Add(Me.rec_btn_add_eq)
        Me.RadGroupBox5.Controls.Add(Me.rec_btn_eqclear)
        Me.RadGroupBox5.Controls.Add(Me.RadLabel70)
        Me.RadGroupBox5.Controls.Add(Me.rec_eq_choosesn)
        Me.RadGroupBox5.Controls.Add(Me.RadLabel50)
        Me.RadGroupBox5.Controls.Add(Me.rec_del_eq)
        Me.RadGroupBox5.Controls.Add(Me.RadGroupBox17)
        Me.RadGroupBox5.HeaderText = "Equipments"
        Me.RadGroupBox5.Location = New System.Drawing.Point(14, 241)
        Me.RadGroupBox5.Name = "RadGroupBox5"
        Me.RadGroupBox5.Size = New System.Drawing.Size(897, 288)
        Me.RadGroupBox5.TabIndex = 3
        Me.RadGroupBox5.Text = "Equipments"
        Me.RadGroupBox5.ThemeName = "VisualStudio2012Dark"
        '
        'rec_cb_reserveno
        '
        Me.rec_cb_reserveno.Enabled = False
        Me.rec_cb_reserveno.Location = New System.Drawing.Point(96, 43)
        Me.rec_cb_reserveno.MinimumSize = New System.Drawing.Size(0, 24)
        Me.rec_cb_reserveno.Name = "rec_cb_reserveno"
        '
        '
        '
        Me.rec_cb_reserveno.RootElement.MinSize = New System.Drawing.Size(0, 24)
        Me.rec_cb_reserveno.Size = New System.Drawing.Size(157, 24)
        Me.rec_cb_reserveno.TabIndex = 33
        Me.rec_cb_reserveno.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel72
        '
        Me.RadLabel72.Location = New System.Drawing.Point(13, 49)
        Me.RadLabel72.Name = "RadLabel72"
        Me.RadLabel72.Size = New System.Drawing.Size(77, 18)
        Me.RadLabel72.TabIndex = 34
        Me.RadLabel72.Text = "Reservation #:"
        Me.RadLabel72.ThemeName = "VisualStudio2012Dark"
        '
        'rec_eq_chooseeq
        '
        Me.rec_eq_chooseeq.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.rec_eq_chooseeq.Location = New System.Drawing.Point(13, 248)
        Me.rec_eq_chooseeq.Name = "rec_eq_chooseeq"
        Me.rec_eq_chooseeq.Size = New System.Drawing.Size(217, 24)
        Me.rec_eq_chooseeq.TabIndex = 31
        Me.rec_eq_chooseeq.ThemeName = "VisualStudio2012Dark"
        '
        'rec_eq_type_choose
        '
        Me.rec_eq_type_choose.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.rec_eq_type_choose.Location = New System.Drawing.Point(13, 140)
        Me.rec_eq_type_choose.Name = "rec_eq_type_choose"
        Me.rec_eq_type_choose.Size = New System.Drawing.Size(217, 24)
        Me.rec_eq_type_choose.TabIndex = 25
        Me.rec_eq_type_choose.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel71
        '
        Me.RadLabel71.Location = New System.Drawing.Point(13, 224)
        Me.RadLabel71.Name = "RadLabel71"
        Me.RadLabel71.Size = New System.Drawing.Size(63, 18)
        Me.RadLabel71.TabIndex = 32
        Me.RadLabel71.Text = "Equipment:"
        Me.RadLabel71.ThemeName = "VisualStudio2012Dark"
        '
        'rec_btn_check_availability
        '
        Me.rec_btn_check_availability.Location = New System.Drawing.Point(280, 200)
        Me.rec_btn_check_availability.Name = "rec_btn_check_availability"
        Me.rec_btn_check_availability.Size = New System.Drawing.Size(77, 24)
        Me.rec_btn_check_availability.TabIndex = 30
        Me.rec_btn_check_availability.Text = "Check"
        Me.rec_btn_check_availability.ThemeName = "VisualStudio2012Dark"
        '
        'rec_btn_add_eq
        '
        Me.rec_btn_add_eq.Location = New System.Drawing.Point(280, 170)
        Me.rec_btn_add_eq.Name = "rec_btn_add_eq"
        Me.rec_btn_add_eq.Size = New System.Drawing.Size(77, 24)
        Me.rec_btn_add_eq.TabIndex = 2
        Me.rec_btn_add_eq.Text = ">>"
        Me.rec_btn_add_eq.ThemeName = "VisualStudio2012Dark"
        '
        'rec_btn_eqclear
        '
        Me.rec_btn_eqclear.Location = New System.Drawing.Point(280, 230)
        Me.rec_btn_eqclear.Name = "rec_btn_eqclear"
        Me.rec_btn_eqclear.Size = New System.Drawing.Size(77, 24)
        Me.rec_btn_eqclear.TabIndex = 27
        Me.rec_btn_eqclear.Text = "Clear"
        Me.rec_btn_eqclear.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel70
        '
        Me.RadLabel70.Location = New System.Drawing.Point(13, 170)
        Me.RadLabel70.Name = "RadLabel70"
        Me.RadLabel70.Size = New System.Drawing.Size(93, 18)
        Me.RadLabel70.TabIndex = 29
        Me.RadLabel70.Text = "Equipment Serial:"
        Me.RadLabel70.ThemeName = "VisualStudio2012Dark"
        '
        'rec_eq_choosesn
        '
        Me.rec_eq_choosesn.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.rec_eq_choosesn.Location = New System.Drawing.Point(13, 194)
        Me.rec_eq_choosesn.Name = "rec_eq_choosesn"
        Me.rec_eq_choosesn.Size = New System.Drawing.Size(217, 24)
        Me.rec_eq_choosesn.TabIndex = 28
        Me.rec_eq_choosesn.ThemeName = "VisualStudio2012Dark"
        '
        'RadLabel50
        '
        Me.RadLabel50.Location = New System.Drawing.Point(13, 116)
        Me.RadLabel50.Name = "RadLabel50"
        Me.RadLabel50.Size = New System.Drawing.Size(90, 18)
        Me.RadLabel50.TabIndex = 26
        Me.RadLabel50.Text = "Equipment Type:"
        Me.RadLabel50.ThemeName = "VisualStudio2012Dark"
        '
        'rec_del_eq
        '
        Me.rec_del_eq.Location = New System.Drawing.Point(280, 140)
        Me.rec_del_eq.Name = "rec_del_eq"
        Me.rec_del_eq.Size = New System.Drawing.Size(77, 24)
        Me.rec_del_eq.TabIndex = 3
        Me.rec_del_eq.Text = "<<"
        Me.rec_del_eq.ThemeName = "VisualStudio2012Dark"
        '
        'RadGroupBox17
        '
        Me.RadGroupBox17.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox17.Controls.Add(Me.eq_rgv_addeq)
        Me.RadGroupBox17.HeaderText = "Added Equipments"
        Me.RadGroupBox17.Location = New System.Drawing.Point(387, 43)
        Me.RadGroupBox17.Name = "RadGroupBox17"
        Me.RadGroupBox17.Size = New System.Drawing.Size(492, 224)
        Me.RadGroupBox17.TabIndex = 1
        Me.RadGroupBox17.Text = "Added Equipments"
        Me.RadGroupBox17.ThemeName = "VisualStudio2012Dark"
        '
        'eq_rgv_addeq
        '
        Me.eq_rgv_addeq.AutoSizeRows = True
        Me.eq_rgv_addeq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.eq_rgv_addeq.Location = New System.Drawing.Point(2, 18)
        '
        '
        '
        Me.eq_rgv_addeq.MasterTemplate.AllowAddNewRow = False
        Me.eq_rgv_addeq.MasterTemplate.AllowDeleteRow = False
        Me.eq_rgv_addeq.MasterTemplate.AllowEditRow = False
        Me.eq_rgv_addeq.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewTextBoxColumn1.HeaderText = "#"
        GridViewTextBoxColumn1.Name = "equipment_no"
        GridViewTextBoxColumn1.Width = 68
        GridViewTextBoxColumn2.HeaderText = "Equipments"
        GridViewTextBoxColumn2.Name = "equipment_name"
        GridViewTextBoxColumn2.Width = 212
        GridViewTextBoxColumn3.HeaderText = "Serial Number"
        GridViewTextBoxColumn3.Name = "equipment_sn"
        GridViewTextBoxColumn3.Width = 211
        Me.eq_rgv_addeq.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3})
        Me.eq_rgv_addeq.MasterTemplate.EnableGrouping = False
        Me.eq_rgv_addeq.MasterTemplate.MultiSelect = True
        Me.eq_rgv_addeq.MasterTemplate.ShowRowHeaderColumn = False
        Me.eq_rgv_addeq.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.eq_rgv_addeq.Name = "eq_rgv_addeq"
        Me.eq_rgv_addeq.ReadOnly = True
        Me.eq_rgv_addeq.Size = New System.Drawing.Size(488, 204)
        Me.eq_rgv_addeq.StandardTab = True
        Me.eq_rgv_addeq.TabIndex = 0
        Me.eq_rgv_addeq.Text = "RadGridView1"
        Me.eq_rgv_addeq.ThemeName = "VisualStudio2012Dark"
        '
        'ChangeEquipmentReservation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 544)
        Me.Controls.Add(Me.RadGroupBox5)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Name = "ChangeEquipmentReservation"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "ChangeEquipmentReservation"
        Me.ThemeName = "VisualStudio2012Dark"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        CType(Me.che_rgv_eq.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.che_rgv_eq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox5.ResumeLayout(False)
        Me.RadGroupBox5.PerformLayout()
        CType(Me.rec_cb_reserveno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel72, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rec_eq_chooseeq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rec_eq_type_choose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel71, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rec_btn_check_availability, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rec_btn_add_eq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rec_btn_eqclear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel70, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rec_eq_choosesn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rec_del_eq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox17.ResumeLayout(False)
        CType(Me.eq_rgv_addeq.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eq_rgv_addeq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents che_rgv_eq As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadGroupBox5 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rec_eq_chooseeq As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents rec_eq_type_choose As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel71 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents rec_btn_check_availability As Telerik.WinControls.UI.RadButton
    Friend WithEvents rec_btn_add_eq As Telerik.WinControls.UI.RadButton
    Friend WithEvents rec_btn_eqclear As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel70 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents rec_eq_choosesn As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel50 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents rec_del_eq As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadGroupBox17 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents eq_rgv_addeq As Telerik.WinControls.UI.RadGridView
    Friend WithEvents rec_cb_reserveno As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel72 As Telerik.WinControls.UI.RadLabel
End Class

