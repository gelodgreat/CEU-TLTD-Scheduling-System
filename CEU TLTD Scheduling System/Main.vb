Imports MySql.Data.MySqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Data

Public Class Main

    Dim ds As New DataSet
    Dim MysqlConn As MySqlConnection


    Dim svYN As DialogResult
    Dim addYN As DialogResult
    Dim editYN As DialogResult
    Dim cancelYN As DialogResult
    Dim updateYN As DialogResult
    Dim deleteYN As DialogResult
    Dim doneYN As DialogResult
    Dim closingYN As DialogResult
    Dim returnYN As DialogResult
    Dim reserveYN As DialogResult

    Public dbdataset As New DataTable

    Public identifier_reservationno As String
    Public random As System.Random = New System.Random

    Public equipment As String
    Public rowcounter As Integer = 0
    Dim query As String
    Dim eq_keepSelectedRowIndexAfterUpdate As Integer 'WU_TRY1



    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        reservation_rgv_recordeddata.Show()
        reservations_rgv_showavailableitems.Hide()
        load_main_table()
        load_rec_table()
        load_eq_table()
        load_main_acc()
        load_main_prof()
        startup_disabled_buttons()
        load_released_list()
        load_released_list2()
        rec_load_choices_eqtype()
        auto_generate_reservationno()
        reserved_load_table()
        startup_disabled_textbox()
        show_hide_txt_lbl()
        color_coding()
        rec_rrtc_actname.Enabled = False
        rec_lbl_actname.Enabled = False
        lu_date.Value = Date.Now
        rec_dtp_date.Value = Date.Now
        Main_Timer.Enabled = True
        load_cb_eq_type()
    End Sub


    Public Sub startup_disabled_buttons()
        eq_btn_update.Hide()
        eq_btn_delete.Hide()
        acc_staff_btn_update.Hide()
        acc_staff_btn_delete.Hide()
        acc_prof_btn_delete.Hide()
        acc_prof_btn_update.Hide()
    End Sub
    Public Sub startup_disabled_textbox()
        'rel_tb_status.Enabled = False
        'rel_tb_id.Enabled = False
        rel_tb_borrower.Enabled = False
        rel_tb_reservationnum.Enabled = False
        ret_tb_reservationnum.Enabled = False
        rel_tb_startdate.Enabled = False
        rel_tb_starttime.Enabled = False
        rel_tb_endtime.Enabled = False
        rel_tb_equipmentnum.Enabled = False
        rel_tb_equipment.Enabled = False
        ret_tb_reservationnum.Enabled = False
        ret_tb_borrower.Enabled = False
        ret_tb_sdate.Enabled = False
        ret_tb_stime.Enabled = False
        ret_tb_etime.Enabled = False
        ret_tb_equipmentnum.Enabled = False
        ret_tb_equipment.Enabled = False
    End Sub
    Public Sub color_coding()
        If (rel_tb_status.Text = "Reserved") Then
            rel_tb_status.BackColor = Color.Blue
        ElseIf (rel_tb_status.Text = "Released") Then
            rel_tb_status.BackColor = Color.Red
        ElseIf (rel_tb_status.Text = "Returned") Then
            rel_tb_status.BackColor = Color.Green
        ElseIf (rel_tb_status.Text = "") Then
            rel_tb_status.BackColor = Color.Gray
        End If

    End Sub
    Public Sub show_hide_txt_lbl()
        lbl_equipment.Hide()
        lbl_equipmentnum.Hide()
        lbl_ret_equipment.Hide()
        lbl_ret_equipmentnum.Hide()
        lbl_ret_release.Hide()
        rel_tb_equipmentnum.Hide()
        rel_tb_equipment.Hide()
        ret_tb_equipment.Hide()
        ret_tb_equipmentnum.Hide()
        ret_nameofstaff_release2.Hide()
    End Sub

    Private Sub btn_showavailequip_Click(sender As Object, e As EventArgs)
        reservation_rgv_recordeddata.Hide()
        reservations_rgv_showavailableitems.Show()
    End Sub

    Private Sub btn_showalldata_Click(sender As Object, e As EventArgs)
        reservation_rgv_recordeddata.Show()
        reservations_rgv_showavailableitems.Hide()
    End Sub

    'Formatting of GridViews
    Private Sub eq_rgv_showregequipment_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles eq_rgv_showregequipment.ViewCellFormatting
        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
    End Sub

    Private Sub main_rgv_recordeddatamain_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles main_rgv_recordedacademicsmain.ViewCellFormatting
        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
    End Sub

    Private Sub reservation_rgv_recordeddata_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles reservation_rgv_recordeddata.ViewCellFormatting
        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
    End Sub

    Public Sub load_rec_table()

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource

        dbdataset.Clear()

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()

            query = "Select reservationno as 'Reservation Number' ,borrower as 'Borrower',id as 'ID', equipmentno as 'Equipment No', equipment as 'Equipment', DATE_FORMAT(date,'%M %d %Y') as 'Date',TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time',activitytype as 'Activiity Type',actname as 'Activity' from reservation where date ='" & Format(CDate(rec_dtp_date.Value), "yyyy-MM-dd") & "' ORDER by date ASC"

            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            reservation_rgv_recordeddata.DataSource = bsource
            reservation_rgv_recordeddata.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    Public Sub load_main_table()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        dbdataset.Clear()

        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()
            query = "Select reservationno as 'Reservation Number' ,borrower as 'Borrower',id as 'ID', equipmentno as 'Equipment No', equipment as 'Equipment', DATE_FORMAT(date,'%M %d %Y') as 'Date',TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time',activitytype as 'Activiity Type',actname as 'Activity' from reservation where date ='" & Format(CDate(lu_date.Value), "yyyy-MM-dd") & "' ORDER by date ASC"
            ' PROBLEM: ID and Reservation is missing. THE NEXT COMMENT shows the old query
            'query = "SELECT TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time',borrower as 'Borrower', equipment as 'Equipment', equipmentno as 'Equipment No' ,DATE_FORMAT(date,'%M %d %Y') as 'Date', activitytype as 'Activiity Type',actname as 'Activity' from reservation where date='" & Format(CDate(lu_date.Value), "yyyy-MM-dd") & "'ORDER BY starttime ASC"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            main_rgv_recordedacademicsmain.DataSource = bsource
            main_rgv_recordedacademicsmain.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    'Programmed by BRENZ STARTING POINT

    Public Sub load_main_acc()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()
            Dim query As String
            query = "Select staff_id as 'Staff ID' , staff_fname as 'First Name' , staff_mname as 'Middle Name' , staff_surname as 'Surname' , staff_username as 'Username' , staff_type as 'User Type' from staff_reg"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            acc_staff_list.DataSource = bsource
            acc_staff_list.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    'Programmed by BRENZ SECOND POINT
    Public Sub load_main_prof()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()
            Dim query As String
            query = "Select bor_id as 'Professor ID' , bor_fname as 'First Name' , bor_mname as 'Middle Name' , bor_surname as 'Surname' , bor_college as 'College/School'  from borrowers_reg"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            acc_prof_list.DataSource = bsource
            acc_prof_list.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try

    End Sub

    Public Sub load_eq_table_retain_filters_after_update()  'WU_TRY1
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            MysqlConn.Open()

            query = "SELECT equipmentno AS 'Equipment Number', equipment AS 'Equipment', equipmentsn AS 'Serial Number',equipmenttype AS 'Equipment Type', equipmentlocation AS 'Equipment Location',equipmentowner AS 'Owner',equipmentstatus AS 'Status' FROM equipments ORDER BY equipmentno DESC"

            comm = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            eq_rgv_showregequipment.DataSource = bsource
            SDA.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(dbdataset)
        DV.RowFilter = String.Format("`Equipment Number` Like'%{0}%' and `Equipment Type` Like'%{1}%' and `Status` Like'%{2}%' ", eq_filter_eqno.Text, eq_filter_eqtype.Text, eq_filter_eqstatus.Text)
        eq_rgv_showregequipment.DataSource = DV
        eq_rgv_showregequipment.Rows(eq_keepSelectedRowIndexAfterUpdate).IsCurrent = True  'WUTRY_1
        eq_sn.Enabled = False 'WUTRY1
    End Sub


    'Programmed by BRENZ THIRD POINT SAVE BUTTON

    Private Sub acc_staff_btn_save_Click(sender As Object, e As EventArgs) Handles acc_staff_btn_save.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim READER As MySqlDataReader
        If (acc_sf_id.Text = "") Or (acc_sf_fname.Text = "") Or (acc_sf_mname.Text = " ") Or (acc_sf_lname.Text = " ") Or (acc_sf_usertype.Text = " ") Or (acc_sf_username.Text = " ") Then
            RadMessageBox.Show(Me, "Please complete the fields to Save!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "insert into ceutltdscheduler.staff_reg (staff_id,staff_fname,staff_mname,staff_surname,staff_type,staff_username,staff_password) values (@staffid, @staffFname, @staffMname, @staffLname, @staffUsertype, @staffUsername, sha2(@staffPassword, 512))"
                comm = New MySqlCommand(Query, MysqlConn)
                comm.Parameters.AddWithValue("staffid", acc_sf_id.Text)
                comm.Parameters.AddWithValue("staffFname", acc_sf_fname.Text)
                comm.Parameters.AddWithValue("staffMname", acc_sf_mname.Text)
                comm.Parameters.AddWithValue("staffLname", acc_sf_lname.Text)
                comm.Parameters.AddWithValue("staffUsertype", acc_sf_usertype.Text)
                comm.Parameters.AddWithValue("staffUsername", acc_sf_username.Text)
                comm.Parameters.AddWithValue("staffPassword", acc_sf_password.Text)


                svYN = RadMessageBox.Show(Me, "Are you sure you want To save this information? ", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                If svYN = MsgBoxResult.Yes Then
                    If (acc_sf_password.Text = acc_sf_retypepassword.Text) Then
                        READER = comm.ExecuteReader
                        RadMessageBox.Show("Register Complete!")
                        acc_sf_id.Text = " "
                        acc_sf_fname.Text = " "
                        acc_sf_mname.Text = " "
                        acc_sf_lname.Text = " "
                        acc_sf_usertype.Text = " "
                        acc_sf_username.Text = " "
                        acc_sf_password.Text = ""
                        acc_sf_retypepassword.Text = ""

                    Else
                        RadMessageBox.Show("Password did Not match!")


                    End If
                End If
                MysqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
                load_main_acc()
            End Try
        End If
    End Sub


    'Programmed by BRENZ 4th point Cell Double Click

    Private Sub acc_staff_list_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles acc_staff_list.CellDoubleClick
        updateYN = RadMessageBox.Show(Me, "Do you want to select this information?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then

            If e.RowIndex >= 0 Then
                Dim row As Telerik.WinControls.UI.GridViewRowInfo

                row = Me.acc_staff_list.Rows(e.RowIndex)

                acc_sf_id.Text = row.Cells("Staff ID").Value.ToString
                acc_sf_fname.Text = row.Cells("First Name").Value.ToString
                acc_sf_mname.Text = row.Cells("Middle Name").Value.ToString
                acc_sf_lname.Text = row.Cells("Surname").Value.ToString
                acc_sf_usertype.Text = row.Cells("User Type").Value.ToString
                acc_sf_username.Text = row.Cells("Username").Value.ToString

                acc_sf_id.Enabled = False
                acc_sf_password.Enabled = False
                acc_sf_retypepassword.Enabled = False
                acc_staff_btn_update.Show()
                acc_staff_btn_delete.Show()
                acc_staff_btn_save.Hide()
                load_main_acc()

            End If

        End If
    End Sub

    'Programmed by BRENZ 5th Point Update Button!
    Private Sub acc_staff_btn_update_Click(sender As Object, e As EventArgs) Handles acc_staff_btn_update.Click

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        updateYN = RadMessageBox.Show(Me, "Do you want to update the selected Information?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (acc_sf_id.Text = "") Or (acc_sf_fname.Text = "") Or (acc_sf_mname.Text = " ") Or (acc_sf_lname.Text = " ") Or (acc_sf_usertype.Text = " ") Or (acc_sf_username.Text = " ") Then
                RadMessageBox.Show(Me, "Please complete the fields to update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "UPDATE staff_reg set staff_id = '" & acc_sf_id.Text & "' , staff_fname = '" & acc_sf_fname.Text & "' , staff_mname = '" & acc_sf_mname.Text & "' , staff_surname = '" & acc_sf_lname.Text & "' , staff_type = '" & acc_sf_usertype.Text & "' , staff_username = '" & acc_sf_username.Text & "' where staff_id = '" & acc_sf_id.Text & "' "
                    comm = New MySqlCommand(query, MysqlConn)
                    reader = comm.ExecuteReader

                    RadMessageBox.Show(Me, "Update Success!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
                    MysqlConn.Close()


                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()
                End Try
            End If
        End If
        load_main_acc()

    End Sub

    'Programmed by BRENZ 6th Point Delete Button!
    Private Sub acc_staff_btn_delete_Click(sender As Object, e As EventArgs) Handles acc_staff_btn_delete.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want To Delete this information? ", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If deleteYN = MsgBoxResult.Yes Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "delete from staff_reg where staff_id = '" & acc_sf_id.Text & "'"
                comm = New MySqlCommand(Query, MysqlConn)
                reader = comm.ExecuteReader

                RadMessageBox.Show(Me, "Delete Complete!", "Delete")
                MysqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
                load_main_acc()
                acc_sf_id.Text = " "
                acc_sf_fname.Text = " "
                acc_sf_mname.Text = " "
                acc_sf_lname.Text = " "
                acc_sf_usertype.Text = " "
                acc_sf_username.Text = " "

            End Try
        End If

    End Sub

    'Programmed by Brenz 7th point Clear Button!
    Private Sub acc_staff_btn_clear_Click(sender As Object, e As EventArgs) Handles acc_staff_btn_clear.Click
        doneYN = RadMessageBox.Show(Me, "Are you sure you want to clear the fields?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If doneYN = MsgBoxResult.Yes Then
            acc_sf_id.Text = " "
            acc_sf_fname.Text = " "
            acc_sf_mname.Text = " "
            acc_sf_lname.Text = " "
            acc_sf_usertype.Text = " "
            acc_sf_username.Text = " "
            acc_sf_password.Text = ""
            acc_sf_retypepassword.Text = ""
            acc_sf_password.Enabled = True
            acc_sf_retypepassword.Enabled = True
            acc_staff_btn_save.Show()
            acc_staff_btn_update.Hide()
            acc_staff_btn_delete.Hide()
        End If

    End Sub

    'Programmed by Brenz 8th point prof Save Button!
    Private Sub acc_prof_btn_save_Click(sender As Object, e As EventArgs) Handles acc_prof_btn_save.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim READER As MySqlDataReader
        If (acc_pf_id.Text = "") Or (acc_pf_fname.Text = "") Or (acc_pf_mname.Text = " ") Or (acc_pf_lname.Text = " ") Or (acc_pf_college.Text = " ") Then
            RadMessageBox.Show(Me, "Please complete the fields to Save!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "insert into `borrowers_reg`  values (@BorID, @BorFname, @BorMname, @BorLname, @BorCollege)"
                comm = New MySqlCommand(Query, MysqlConn)
                comm.Parameters.AddWithValue("BorID", acc_pf_id.Text)
                comm.Parameters.AddWithValue("BorFname", acc_pf_fname.Text)
                comm.Parameters.AddWithValue("BorMname", acc_pf_mname.Text)
                comm.Parameters.AddWithValue("BorLname", acc_pf_lname.Text)
                comm.Parameters.AddWithValue("BorCollege", acc_pf_college.Text)


                svYN = RadMessageBox.Show(Me, "Are you sure you want To save this information? ", "TLTD Schuling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                If svYN = MsgBoxResult.Yes Then

                    READER = comm.ExecuteReader
                    RadMessageBox.Show("Register Complete!")

                End If
                MysqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
                load_main_prof()
                acc_pf_id.Text = " "
                acc_pf_fname.Text = " "
                acc_pf_mname.Text = " "
                acc_pf_lname.Text = " "
                acc_pf_college.Text = " "

            End Try
        End If
    End Sub



    'Programmed by Brenz 9th point Cell Double Click Prof List!
    Private Sub acc_prof_list_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles acc_prof_list.CellDoubleClick
        updateYN = RadMessageBox.Show(Me, "Do you want to select this information?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then

            If e.RowIndex >= 0 Then
                Dim row As Telerik.WinControls.UI.GridViewRowInfo

                row = Me.acc_prof_list.Rows(e.RowIndex)

                acc_pf_id.Text = row.Cells("Professor ID").Value.ToString
                acc_pf_fname.Text = row.Cells("First Name").Value.ToString
                acc_pf_mname.Text = row.Cells("Middle Name").Value.ToString
                acc_pf_lname.Text = row.Cells("Surname").Value.ToString
                acc_pf_college.Text = row.Cells("College/School").Value.ToString

                acc_pf_id.Enabled = False
                acc_prof_btn_update.Show()
                acc_prof_btn_delete.Show()
                acc_prof_btn_save.Hide()
                load_main_prof()

            End If

        End If

    End Sub

    'Programmed by Brenz 10th Point Prof Update Button
    Private Sub acc_prof_btn_update_Click(sender As Object, e As EventArgs) Handles acc_prof_btn_update.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        updateYN = RadMessageBox.Show(Me, "Do you want to update the selected Information?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (acc_pf_id.Text = "") Or (acc_pf_fname.Text = "") Or (acc_pf_mname.Text = " ") Or (acc_pf_lname.Text = " ") Or (acc_pf_college.Text = " ") Then
                RadMessageBox.Show(Me, "Please complete the fields to update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "UPDATE borrowers_reg set bor_id = '" & acc_pf_id.Text & "' , bor_fname = '" & acc_pf_fname.Text & "' , bor_mname = '" & acc_pf_mname.Text & "' , bor_surname = '" & acc_pf_lname.Text & "' , bor_college = '" & acc_pf_college.Text & "' where bor_id = '" & acc_pf_id.Text & "' "
                    comm = New MySqlCommand(query, MysqlConn)
                    reader = comm.ExecuteReader

                    RadMessageBox.Show(Me, "Update Success!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
                    MysqlConn.Close()


                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()
                End Try
            End If
        End If
        load_main_prof()
    End Sub

    'Programmed by Brenz 11th point prof Delete Button!
    Private Sub acc_prof_btn_delete_Click(sender As Object, e As EventArgs) Handles acc_prof_btn_delete.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want To Delete this information? ", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If deleteYN = MsgBoxResult.Yes Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "delete from borrowers_reg where bor_id = '" & acc_pf_id.Text & "'"
                comm = New MySqlCommand(Query, MysqlConn)
                reader = comm.ExecuteReader

                RadMessageBox.Show(Me, "Delete Complete!", "Delete")
                MysqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
                load_main_prof()
                acc_pf_id.Text = " "
                acc_pf_fname.Text = " "
                acc_pf_mname.Text = " "
                acc_pf_lname.Text = " "
                acc_pf_college.Text = " "

            End Try
        End If



    End Sub

    'Programmed by Brenz 12th Point Clear Button
    Private Sub acc_prof_btn_clear_Click(sender As Object, e As EventArgs) Handles acc_prof_btn_clear.Click
        doneYN = RadMessageBox.Show(Me, "Are you sure you want to clear the fields?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If doneYN = MsgBoxResult.Yes Then
            acc_pf_id.Text = " "
            acc_pf_fname.Text = " "
            acc_pf_mname.Text = " "
            acc_pf_lname.Text = " "
            acc_pf_college.Text = " "

            acc_prof_btn_delete.Hide()
            acc_prof_btn_update.Hide()
            acc_prof_btn_save.Show()
        End If
    End Sub

    'Programmed by BRENZ 13th POINT Load form grid RELEASED at Releasing Management!
    Public Sub load_released_list()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()
            Dim query As String
            query = "Select rel_reservation_no as 'Reservation Number', rel_id_passnum as 'Pass Number ' , rel_borrower as ' Borrower ' , rel_equipment_no as 'Equipment Number', rel_equipment as 'Equipment',DATE_FORMAT(rel_assign_date,'%M %d %Y') as 'Date',TIME_FORMAT(rel_starttime, '%H:%i') as 'Start Time', TIME_FORMAT(rel_endtime, '%H:%i') as 'End Time'  , rel_status as ' Status ' , rel_releasedby as ' Released By'  from released_info"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            released_grid_list.DataSource = bsource
            released_grid_list.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    'Programmed by BRENZ 14th POINT Load form grid RELEASED at returning Management!
    Public Sub load_released_list2()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()
            Dim query As String
            query = "Select rel_reservation_no as 'Reservation Number' , rel_id_passnum as 'Pass Number' , rel_borrower as 'Borrower' , rel_equipment_no as 'Equipment No' , rel_equipment as 'Equipment' , DATE_FORMAT(rel_assign_date,'%M %d %Y') as 'Date',TIME_FORMAT(rel_starttime, '%H:%i') as 'Start Time', TIME_FORMAT(rel_endtime, '%H:%i') as 'End Time' , rel_status as 'Status' , rel_releasedby as 'Released By'  from released_info"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            released_grid_list2.DataSource = bsource
            released_grid_list2.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    'Programmed by BRENZ 15th point RELEASE BTN at Releasing Management!
    Private Sub released_btn_release_Click(sender As Object, e As EventArgs) Handles released_btn_release.Click

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim READER As MySqlDataReader
        If (rel_tb_reservationnum.Text = "") Or (rel_tb_borrower.Text = "") Or (rel_tb_equipmentnum.Text = "") Or (rel_tb_equipment.Text = "") Or (rel_tb_startdate.Text = " ") Or (rel_tb_starttime.Text = " ") Or (rel_tb_endtime.Text = " ") Then
            RadMessageBox.Show(Me, "Please complete the fields to Save!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            Try
                MysqlConn.Open()
                Dim Query As String
                ' Dim Query2 As String
                Query = "insert into `released_info`  values ('" & rel_tb_id.Text & "' ,'" & rel_tb_reservationnum.Text & " ',  '" & rel_tb_borrower.Text & "' , '" & rel_tb_reservationnum.Text & "', '" & rel_tb_equipment.Text & "', '" & Format(CDate(rel_tb_startdate.Value), "yyyy-MM-dd") & "','" & Format(CDate(rel_tb_starttime.Text), "HH:mm") & "', '" & Format(CDate(rel_tb_endtime.Text), "HH:mm") & "', '" & rel_tb_status.Text & "' , '" & rel_nameofstaff_release.Text & "'); update reservation set  res_status = '" & rel_tb_status.Text & "' where reservationno = '" & rel_tb_reservationnum.Text & "'"
                'Query = "delete from reservation where  reservationno = '" & rel_tb_reservationnum.Text & "'"
                comm = New MySqlCommand(Query, MysqlConn)
                'comm.Parameters.AddWithValue("ID", rel_tb_id.Text)
                'comm.Parameters.AddWithValue("ID", rel_tb_id.Text)
                'comm.Parameters.AddWithValue("ID", rel_tb_id.Text)


                svYN = RadMessageBox.Show(Me, "Are you sure you want to Release this Equipment/s? ", "TLTD Schuling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                If svYN = MsgBoxResult.Yes Then
                    READER = comm.ExecuteReader
                    RadMessageBox.Show("Released!")

                End If
                MysqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
                rel_tb_reservationnum.Text = ""
                rel_tb_id.Text = ""
                rel_tb_borrower.Text = ""
                rel_tb_startdate.Text = "01/01/99"
                rel_tb_starttime.Text = ""
                rel_tb_endtime.Text = ""
                rel_tb_status.Text = ""
                rel_tb_equipment.Text = ""
                rel_tb_equipmentnum.Text = ""
                show_hide_txt_lbl()
                load_released_list()
                load_released_list2()
                reserved_load_table()
                load_rec_table()
                color_coding()
            End Try
        End If

    End Sub


    'Programmed by BRENZ 16th Point UPDATE BTN at Releasing Management
    Private Sub released_btn_update_Click(sender As Object, e As EventArgs)
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        updateYN = RadMessageBox.Show(Me, "Do you want to Update the Date/Time/Location of the Reserved Equipment?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (rel_tb_startdate.Text = "") Or (rel_tb_starttime.Text = " ") Or (rel_tb_endtime.Text = " ") Then
                RadMessageBox.Show(Me, "Please complete the fields to update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "UPDATE released_info set rel_assign_date = '" & rel_tb_starttime.Text & "'  , rel_starttime = '" & rel_tb_starttime.Text & "' , rel_endtime = '" & rel_tb_endtime.Text & "'  where rel_assign_date = '" & rel_tb_startdate.Text & "' "
                    comm = New MySqlCommand(query, MysqlConn)
                    reader = comm.ExecuteReader

                    RadMessageBox.Show(Me, "Update Success!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
                    MysqlConn.Close()


                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()
                    load_released_list()
                    load_released_list2()
                End Try
            End If
        End If



    End Sub

    'Programmed by BRENZ 17th Point Cancel BTN at Returning Management
    Private Sub return_btn_cancel_Click(sender As Object, e As EventArgs) Handles return_btn_cancel.Click
        cancelYN = RadMessageBox.Show(Me, "Do you want to cancel returning? ", "TLTD Scheduling management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If cancelYN = MsgBoxResult.Yes Then
            ret_tb_reservationnum.Text = ""
            ret_tb_id.Text = ""
            ret_tb_borrower.Text = ""
            ret_tb_sdate.Text = "01/01/99"
            ret_tb_stime.Text = ""
            ret_tb_etime.Text = ""
            ret_tb_status.Text = ""
            'ret_tb_equipment.Text = ""
            ret_tb_equipmentnum.Text = ""
            show_hide_txt_lbl()
        End If
    End Sub


    'Programmed by BRENZ 18th Point Cancel BTN at Releasing Management
    Private Sub released_btn_cancel_Click(sender As Object, e As EventArgs) Handles released_btn_cancel.Click
        cancelYN = RadMessageBox.Show(Me, "Do you want to cancel returning? ", "TLTD Scheduling management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If cancelYN = MsgBoxResult.Yes Then
            rel_tb_id.Text = ""
            rel_tb_borrower.Text = ""
            rel_tb_startdate.Text = "01/01/99"
            rel_tb_starttime.Text = ""
            rel_tb_status.Text = ""
            rel_tb_equipment.Text = ""
            rel_tb_equipmentnum.Text = ""
            lbl_equipment.Hide()
            lbl_equipmentnum.Hide()
            rel_tb_equipment.Hide()
            rel_tb_equipmentnum.Hide()
            color_coding()



        End If




    End Sub

    'Programmed by BRENZ 19th Point reserved records at releasing management

    Public Sub reserved_load_table()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()
            Dim query As String
            query = "Select reservationno as 'Reservation Number' , borrower as 'Borrower', equipmentno as 'Equipment No', equipment as 'Equipment', DATE_FORMAT(date,'%M %d %Y') as 'Date',TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time' , res_status as 'Status' from reservation  ORDER by date ASC"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            reserved_grid_list.DataSource = bsource
            reserved_grid_list.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

    End Sub

    'Programmed by BRENZ 20th Point reserved_grid_list cell double click at releasing management
    Private Sub reserved_grid_list_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles reserved_grid_list.CellDoubleClick
        Dim released As String

        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo

            row = Me.reserved_grid_list.Rows(e.RowIndex)
            released = row.Cells("Status").Value.ToString

            If released = "Released" Then
                RadMessageBox.Show(Me, "The equipment is already released", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Exclamation)

            Else

                updateYN = RadMessageBox.Show(Me, "Do you want to select this information?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                If updateYN = MsgBoxResult.Yes Then

                    If e.RowIndex >= 0 Then
                        Dim row2 As Telerik.WinControls.UI.GridViewRowInfo

                        row2 = Me.reserved_grid_list.Rows(e.RowIndex)

                        rel_tb_reservationnum.Text = row2.Cells("Reservation Number").Value.ToString
                        rel_tb_borrower.Text = row2.Cells("Borrower").Value.ToString
                        rel_tb_startdate.Text = row2.Cells("Date").Value.ToString
                        rel_tb_starttime.Text = row2.Cells("Start Time").Value.ToString
                        rel_tb_endtime.Text = row2.Cells("End Time").Value.ToString
                        rel_tb_status.Text = row2.Cells("Status").Value.ToString
                        rel_tb_equipmentnum.Text = row2.Cells("Equipment No").Value.ToString
                        rel_tb_equipment.Text = row2.Cells("Equipment").Value.ToString




                        lbl_equipment.Show()
                        lbl_equipmentnum.Show()
                        rel_tb_equipment.Show()
                        rel_tb_equipmentnum.Show()
                        reserved_load_table()
                        color_coding()
                    End If

                End If
            End If
        End If
    End Sub


    'Programmed by BRENZ/wu 21st Point Closing button
    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        closingYN = RadMessageBox.Show(Me, "Are you sure you want to Log-Out?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation)
        If closingYN = MsgBoxResult.Yes Then
            Me.Dispose()
            Login.Show()
        ElseIf closingYN = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub


    'Programmed by BRENZ 22nd cell double click release2 @ return management


    Private Sub released_grid_list2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles released_grid_list2.CellDoubleClick
        returnYN = RadMessageBox.Show(Me, "Do you want to select this information?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If returnYN = MsgBoxResult.Yes Then

            If e.RowIndex >= 0 Then
                Dim row As Telerik.WinControls.UI.GridViewRowInfo

                row = Me.released_grid_list2.Rows(e.RowIndex)

                ret_tb_reservationnum.Text = row.Cells("Reservation Number").Value.ToString
                ret_tb_id.Text = row.Cells("Pass Number").Value.ToString
                ret_tb_borrower.Text = row.Cells("Borrower").Value.ToString
                ret_tb_sdate.Text = row.Cells("Date").Value.ToString
                ret_tb_stime.Text = row.Cells("Start Time").Value.ToString
                ret_tb_etime.Text = row.Cells("End Time").Value.ToString
                ret_tb_status.Text = row.Cells("Status").Value.ToString
                ret_tb_equipmentnum.Text = row.Cells("Equipment No").Value.ToString
                ret_tb_equipment.Text = row.Cells("Equipment").Value.ToString
                ret_nameofstaff_release2.Text = row.Cells("Released By").Value.ToString

                lbl_ret_equipmentnum.Show()
                lbl_ret_equipment.Show()
                ret_tb_equipmentnum.Show()
                ret_tb_equipment.Show()
                lbl_ret_release.Show()
                ret_nameofstaff_release2.Show()
                load_released_list2()
                'show_hide_txt_lbl()
                color_coding()
            End If

        End If
    End Sub







    'Main Window Search Functions Umali C1
    Private Sub lu_byequipment_TextChanged(sender As Object, e As EventArgs) Handles lu_byequipment.TextChanged
        lu_byequipment_filter_delay.Interval = 700
        lu_byequipment_filter_delay.Stop()
        lu_byequipment_filter_delay.Start()
    End Sub

    Private Sub lu_byequipment_filter_delay_Tick(sender As Object, e As EventArgs) Handles lu_byequipment_filter_delay.Tick
        lu_byequipment_filter_delay.Stop()
        ''''''''Pending Changes because of client request

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            MysqlConn.Open()


            query = "Select reservationno as 'Reservation Number' ,borrower as 'Borrower',id as 'ID', equipmentno as 'Equipment No', equipment as 'Equipment',
            DATE_FORMAT(date,'%M %d %Y') as 'Date',TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time',
            activitytype as 'Activiity Type',actname as 'Activity' from reservation where date ='" & Format(CDate(rec_dtp_date.Value), "yyyy-MM-dd") & "'  ORDER BY equipment desc"

            comm = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            main_rgv_recordedacademicsmain.DataSource = bsource
            SDA.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(dbdataset)
        DV.RowFilter = String.Format("`Equipment` Like'%{0}%' and `Borrower` Like'%{1}%'", lu_byequipment.Text, lu_byname.Text)
        main_rgv_recordedacademicsmain.DataSource = DV
    End Sub

    'Search by Name in Main Tab
    Private Sub lu_byname_TextChanged(sender As Object, e As EventArgs) Handles lu_byname.TextChanged
        lu_byname_filter_delay.Interval = 700
        lu_byname_filter_delay.Stop()
        lu_byname_filter_delay.Start()
    End Sub

    Private Sub lu_byname_filter_delay_Tick(sender As Object, e As EventArgs) Handles lu_byname_filter_delay.Tick
        lu_byname_filter_delay.Stop()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            MysqlConn.Open()

            query = "Select reservationno as 'Reservation Number' ,borrower as 'Borrower',id as 'ID', equipmentno as 'Equipment No', equipment as 'Equipment',
            DATE_FORMAT(date,'%M %d %Y') as 'Date',TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time',
            activitytype as 'Activiity Type',actname as 'Activity' from reservation where date ='" & Format(CDate(rec_dtp_date.Value), "yyyy-MM-dd") & "'"

            comm = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            main_rgv_recordedacademicsmain.DataSource = bsource
            SDA.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(dbdataset)
        DV.RowFilter = String.Format("`Borrower` Like'%{0}%' and `Equipment` Like'%{1}%'", lu_byname.Text, lu_byequipment.Text)
        main_rgv_recordedacademicsmain.DataSource = DV
    End Sub

    'Equipment Management Codes Umali E1 EQ_LOAD_EQ_TABLE

    Public Sub load_eq_table()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()

            query = "SELECT equipmentno as 'Equipment Number', equipment as 'Equipment', equipmentsn as 'Serial Number',equipmenttype as 'Equipment Type', equipmentlocation as 'Equipment Location',equipmentowner as 'Owner',equipmentstatus as 'Status' from equipments ORDER BY equipment ASC"

            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            eq_rgv_showregequipment.DataSource = bsource
            eq_rgv_showregequipment.ReadOnly = True




            sda.Update(dbdataset)
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try

    End Sub

    'Equipment Management Codes Umali E2 EQ_BTN_SAVE

    Private Sub eq_btn_save_Click(sender As Object, e As EventArgs) Handles eq_btn_save.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim reader As MySqlDataReader


        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        If (eq_equipmentno.Text = "") Or (eq_sn.Text = "") Or (eq_equipment.Text = "") Or (eq_equipmentlocation.Text = "") Or (eq_owner.Text = "") Or (eq_status.Text = "") Then
            RadMessageBox.Show(Me, "Please complete the fields to update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)

        Else
            Try
                MysqlConn.Open()
                query = "SELECT * from equipments where (equipmentsn=@eq_sn)"
                comm = New MySqlCommand(query, MysqlConn)
                comm.Parameters.AddWithValue("eq_sn", eq_sn.Text)
                reader = comm.ExecuteReader

                Dim count As Integer

                While reader.Read
                    count += 1
                End While

                If count = 1 Then
                    RadMessageBox.Show(Me, "Equipment #" & eq_equipmentno.Text & " And the equipment " & eq_equipment.Text & " Is already registered")
                Else
                    MysqlConn.Close()
                    MysqlConn.Open()

                    addYN = RadMessageBox.Show(Me, "Are you sure you want To save this equipment?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                    If addYN = MsgBoxResult.Yes Then
                        query = "INSERT INTO `equipments` VALUES (@eq_eqno, @eq_eqeq, @eq_eqsn, @eq_eqlocation, @eq_eqowner, @eq_eqstatus, @eq_eqtype)"
                        comm = New MySqlCommand(query, MysqlConn)

                        comm.Parameters.AddWithValue("eq_eqno", eq_equipmentno.Text)
                        comm.Parameters.AddWithValue("eq_eqeq", eq_equipment.Text)
                        comm.Parameters.AddWithValue("eq_eqsn", eq_sn.Text)
                        comm.Parameters.AddWithValue("eq_eqlocation", eq_equipmentlocation.Text)
                        comm.Parameters.AddWithValue("eq_eqowner", eq_owner.Text)
                        comm.Parameters.AddWithValue("eq_eqstatus", eq_status.Text)
                        comm.Parameters.AddWithValue("eq_eqtype", eq_type.Text)


                        reader = comm.ExecuteReader
                        RadMessageBox.Show(Me, "Equipment Registered!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
                        MysqlConn.Close()
                    End If
                End If
            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()

            End Try
        End If
        load_eq_table()
        counter_of_total_eq()
    End Sub


    'Equipment Management Codes Umali E3 EQ_BTN_UPDATE

    Private Sub eq_btn_update_Click(sender As Object, e As EventArgs) Handles eq_btn_update.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        updateYN = RadMessageBox.Show(Me, "Do you want To update the selected equipment?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (eq_equipmentno.Text = "") Or (eq_sn.Text = "") Or (eq_equipment.Text = "") Or (eq_equipmentlocation.Text = "") Or (eq_owner.Text = "") Or (eq_status.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields To update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "UPDATE equipments SET equipmentno=@eq_eqno, equipmentsn=@eq_eqsn, equipment=@eq_eqeq, equipmentlocation=@eq_eqlocation, equipmentowner=@eq_eqowner, equipmentstatus=@eq_eqstatus, equipmenttype=@eq_eqtype WHERE (equipmentsn=@eq_eqsn) AND (equipmentno=@eq_eqno)"
                    comm = New MySqlCommand(query, MysqlConn)

                    comm.Parameters.AddWithValue("eq_eqno", eq_equipmentno.Text)
                    comm.Parameters.AddWithValue("eq_eqeq", eq_equipment.Text)
                    comm.Parameters.AddWithValue("eq_eqsn", eq_sn.Text)
                    comm.Parameters.AddWithValue("eq_eqlocation", eq_equipmentlocation.Text)
                    comm.Parameters.AddWithValue("eq_eqowner", eq_owner.Text)
                    comm.Parameters.AddWithValue("eq_eqstatus", eq_status.Text)
                    comm.Parameters.AddWithValue("eq_eqtype", eq_type.Text)


                    reader = comm.ExecuteReader

                    RadMessageBox.Show(Me, "Update Success!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
                    MysqlConn.Close()


                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()
                End Try
            End If
        End If

        load_eq_table_retain_filters_after_update()


        counter_of_total_eq()
    End Sub

    'Equipment Management Codes Umali E4 EQ_BTN_DELETE

    Private Sub eq_btn_delete_Click(sender As Object, e As EventArgs) Handles eq_btn_delete.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want to delete?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If deleteYN = MsgBoxResult.Yes Then
            Try
                MysqlConn.Open()
                query = "DELETE FROM equipments WHERE equipmentno=@eq_eqno AND equipmentsn=@eq_eqsn "
                comm = New MySqlCommand(query, MysqlConn)
                comm.Parameters.AddWithValue("eq_eqno", eq_equipmentno.Text)
                comm.Parameters.AddWithValue("eq_eqsn", eq_sn.Text)

                reader = comm.ExecuteReader

                eq_equipment.Text = ""
                eq_equipmentno.Text = ""
                eq_equipmentlocation.Text = ""
                eq_sn.Text = ""
                eq_status.Text = ""
                eq_owner.Text = ""

                RadMessageBox.Show(Me, "Successfully Deleted!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
                MysqlConn.Close()
            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
            End Try
        End If
        load_eq_table()
        counter_of_total_eq()
    End Sub

    Private Sub eq_clear_filter_Click(sender As Object, e As EventArgs) Handles eq_clear_filter.Click
        eq_filter_eqno.Text = ""
        eq_filter_eqtype.Text = ""
        eq_filter_eqstatus.Text = ""
    End Sub

    'Equipment Management Codes Umali E5 EQ_CELLDOUBLECLICK

    Private Sub eq_rgv_showregequipment_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles eq_rgv_showregequipment.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo
            eq_keepSelectedRowIndexAfterUpdate = e.RowIndex 'WUTRY_1
            row = Me.eq_rgv_showregequipment.Rows(e.RowIndex)

            eq_equipmentno.Text = row.Cells("Equipment Number").Value.ToString
            eq_equipment.Text = row.Cells("Equipment").Value.ToString
            eq_equipmentlocation.Text = row.Cells("Equipment Location").Value.ToString
            eq_sn.Text = row.Cells("Serial Number").Value.ToString
            eq_status.Text = row.Cells("Status").Value.ToString
            eq_owner.Text = row.Cells("Owner").Value.ToString
            eq_type.Text = row.Cells("Equipment Type").Value.ToString

            eq_sn.Enabled = False
            eq_btn_update.Show()
            eq_btn_delete.Show()
            eq_btn_save.Hide()
        End If
    End Sub

    'Equipment Management Codes Umali E6 = EQ_BTN_CLEAR

    Private Sub eq_btn_clear_Click(sender As Object, e As EventArgs) Handles eq_btn_clear.Click
        eq_equipmentno.Text = ""
        eq_equipment.Text = ""
        eq_equipmentlocation.Text = ""
        eq_sn.Text = ""
        eq_status.Text = ""
        eq_owner.Text = ""
        eq_type.Text = ""
        eq_sn.Enabled = True
        eq_btn_update.Hide()
        eq_btn_delete.Hide()
        eq_btn_save.Show()
    End Sub

    'Equipment Management Codes Umali E7 = SEARCH BY EQ_NO

    Private Sub eqno_filter_delay_Tick(sender As Object, e As EventArgs) Handles eqno_filter_delay.Tick
        eqno_filter_delay.Stop()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()

            query = "SELECT equipmentno AS 'Equipment Number', equipment AS 'Equipment', equipmentsn AS 'Serial Number',equipmenttype AS 'Equipment Type', equipmentlocation AS 'Equipment Location',equipmentowner AS 'Owner',equipmentstatus AS 'Status' FROM equipments ORDER BY equipmentno DESC"

            comm = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            eq_rgv_showregequipment.DataSource = bsource
            SDA.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(dbdataset)
        DV.RowFilter = String.Format("`Equipment Number` Like'%{0}%' and `Equipment Type` Like'%{1}%' and `Status` Like'%{2}%' ", eq_filter_eqno.Text, eq_filter_eqtype.Text, eq_filter_eqstatus.Text)
        eq_rgv_showregequipment.DataSource = DV
    End Sub


    Private Sub eq_filter_eqno_TextChanged(sender As Object, e As EventArgs) Handles eq_filter_eqno.TextChanged
        eqno_filter_delay.Interval = 700
        eqno_filter_delay.Stop()
        eqno_filter_delay.Start()
    End Sub

    'Equipment Management Codes Umali E8 = SEARCH BY EQ_TYPE
    Private Sub eq_filter_eqtype_TextChanged(sender As Object, e As EventArgs) Handles eq_filter_eqtype.TextChanged
        eqtype_filter_delay.Interval = 700
        eqtype_filter_delay.Stop()
        eqtype_filter_delay.Start()
    End Sub
    'THIS IS TO DELAY THE FILTER WHEN the user types so that it won't be laggy
    Private Sub eqtype_filter_delay_Tick(sender As Object, e As EventArgs) Handles eqtype_filter_delay.Tick
        eqtype_filter_delay.Stop()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            MysqlConn.Open()

            query = "SELECT equipmentno AS 'Equipment Number', equipment AS 'Equipment', equipmentsn AS 'Serial Number',equipmenttype AS 'Equipment Type', equipmentlocation AS 'Equipment Location',equipmentowner AS 'Owner',equipmentstatus AS 'Status' FROM equipments ORDER BY equipmentno DESC"

            comm = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            eq_rgv_showregequipment.DataSource = bsource
            SDA.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(dbdataset)
        DV.RowFilter = String.Format("`Equipment Number` Like'%{0}%' and `Equipment Type` Like'%{1}%' and `Status` Like'%{2}%' ", eq_filter_eqno.Text, eq_filter_eqtype.Text, eq_filter_eqstatus.Text)
        eq_rgv_showregequipment.DataSource = DV
    End Sub

    'Equipment Management Codes Umali E9 = SEARCH BY EQ_STATUS
    Private Sub eq_filter_eqstatus_TextChanged(sender As Object, e As EventArgs) Handles eq_filter_eqstatus.TextChanged
        eqstatus_filter_delay.Interval = 700
        eqstatus_filter_delay.Stop()
        eqstatus_filter_delay.Start()
    End Sub

    Private Sub eqstatus_filter_delay_Tick(sender As Object, e As EventArgs) Handles eqstatus_filter_delay.Tick
        eqstatus_filter_delay.Stop()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If eq_filter_eqstatus.Text = "-" Then
            load_eq_table()
        Else
            Try
                MysqlConn.Open()

                query = "SELECT equipmentno AS 'Equipment Number', equipment AS 'Equipment', equipmentsn AS 'Serial Number',equipmenttype AS 'Equipment Type', equipmentlocation AS 'Equipment Location',equipmentowner AS 'Owner',equipmentstatus AS 'Status' FROM equipments ORDER BY equipmentno DESC"

                comm = New MySqlCommand(query, MysqlConn)
                SDA.SelectCommand = comm
                SDA.Fill(dbdataset)
                bsource.DataSource = dbdataset
                eq_rgv_showregequipment.DataSource = bsource
                SDA.Update(dbdataset)

                MysqlConn.Close()

            Catch ex As MySqlException
                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
            End Try

            Dim DV As New DataView(dbdataset)
            DV.RowFilter = String.Format("`Equipment Number` Like'%{0}%' and `Equipment Type` Like'%{1}%' and `Status` Like'%{2}%' ", eq_filter_eqno.Text, eq_filter_eqtype.Text, eq_filter_eqstatus.Text)
            eq_rgv_showregequipment.DataSource = DV
        End If
    End Sub

    'Equipment Management Codes Umali E10 = COUNTER
    Private Sub eq_counter_type_SelectedIndexChanged_1(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles eq_counter_type.SelectedIndexChanged
        counter_of_total_eq()
    End Sub

    'Equipment Management Codes Umali E11 = COUNTER CODE
    Public Sub counter_of_total_eq()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()

            Dim holder As String

            query = "SELECT COUNT(equipmenttype) AS 'total' FROM equipments WHERE equipmenttype=@eq_countertype"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("eq_countertype", eq_counter_type.Text)

            reader = comm.ExecuteReader
            While reader.Read
                holder = reader.GetString("total")
            End While
            eq_total_units.Text = holder

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub


    ' Reservation Management Code Umali R1 = LOADING DATA TO rec_eq_type_choose
    Public Sub rec_load_choices_eqtype()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT DISTINCT(equipmenttype) FROM equipments ORDER BY equipmenttype ASC"
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader


            rec_eq_type_choose.Items.Clear()
            eq_counter_type.Items.Clear()

            While reader.Read

                rec_eq_type_choose.Items.Add(reader.GetString("equipmenttype"))
                eq_counter_type.Items.Add(reader.GetString("equipmenttype"))
            End While
            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    ' Reservation Management Code Umali R2 = LOADING DATA TO rec_eq_choosesn 
    Private Sub rec_eq_type_choose_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles rec_eq_type_choose.SelectedIndexChanged
        rec_eq_chooseno.Items.Clear()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring

        Try
            MysqlConn.Open()

            query = "SELECT equipmentno FROM equipments WHERE equipmenttype=@rec_eq_type_choose"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("rec_eq_type_choose", rec_eq_type_choose.Text)
            reader = comm.ExecuteReader

            rec_eq_chooseno.Items.Clear()
            While reader.Read
                rec_eq_chooseno.Items.Add(reader.GetString("equipmentno"))
            End While

            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

    End Sub

    ' Reservation Management Code Umali R2.5 = LOADING DATA TO rec_eq_chooseeq 
    Private Sub rec_eq_chooseno_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles rec_eq_chooseno.SelectedIndexChanged
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT equipment from equipments where equipmenttype=@rec_eq_type_choose and equipmentno=@rec_eq_chooseno"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("rec_eq_type_choose", rec_eq_type_choose.Text)
            comm.Parameters.AddWithValue("rec_eq_chooseno", rec_eq_chooseno.Text)


            reader = comm.ExecuteReader

            rec_eq_chooseeq.Items.Clear()
            While reader.Read
                rec_eq_chooseeq.Items.Add(reader.GetString("equipment"))
            End While

            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub



    'Reservation Management Code Umali R3 = Adding Data from combobox to eq_rgv_addeq RadDataGrid
    Private Sub rec_btn_add_eq_Click(sender As Object, e As EventArgs) Handles rec_btn_add_eq.Click

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring

        If rec_eq_chooseno.Text = "" Then
            RadMessageBox.Show(Me, "Choose Serial Number!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        ElseIf rec_eq_type_choose.Text = "" Then
            RadMessageBox.Show(Me, "Choose the Type of Equipment!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        ElseIf rec_eq_chooseeq.Text = "" Then
            RadMessageBox.Show(Me, "Choose the Equipment!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            Try
                MysqlConn.Open()
                query = "SELECT equipmentsn as 'Serial Number', equipmentno as '#' from equipments where equipmenttype=@rec_eq_type_choose and equipment=@rec_chooseeq and equipmentno=@rec_eq_chooseno"
                comm = New MySqlCommand(query, MysqlConn)
                comm.Parameters.AddWithValue("rec_eq_type_choose", rec_eq_type_choose.Text)
                comm.Parameters.AddWithValue("rec_eq_chooseno", rec_eq_chooseno.Text)
                comm.Parameters.AddWithValue("rec_chooseeq", rec_eq_chooseeq.Text)

                reader = comm.ExecuteReader

                Dim count As Integer
                count = 0
                Dim tempsn As String
                Dim tempno As String
                While reader.Read
                    tempsn = reader.GetString("Serial Number")
                    tempno = reader.GetString("#")
                End While

                eq_rgv_addeq.Rows.Add(tempno, rec_eq_chooseeq.Text, tempsn)

                rowcounter += 1

                MysqlConn.Close()
            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
            End Try

        End If

    End Sub

    'Reservation Management Code Umali R4 = Removing data from eq_rgv_addeq RadDataGrid
    Private Sub rec_del_eq_Click(sender As Object, e As EventArgs) Handles rec_del_eq.Click

        If (eq_rgv_addeq.Rows.Count = 0) Then
            RadMessageBox.Show(Me, "The Table is already empty.", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            eq_rgv_addeq.Rows.RemoveAt(eq_rgv_addeq.CurrentRow.Index)
        End If

    End Sub

    'Reservation Management Code Umali R5 = Checking the availabity of the equipment
    Private Sub rec_btn_check_availability_Click(sender As Object, e As EventArgs) Handles rec_btn_check_availability.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        rowcounter = 0

        Try
            MysqlConn.Open()
            query = "SELECT equipmentno,equipment,equipmentsn from reservation where equipmentno=@rows_eqno and equipment=@rows_eq and equipmentsn=@rows_eqsn"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("rows_eqno", eq_rgv_addeq.Rows(eq_rgv_addeq.SelectedRows(0).Index).Cells(0).Value.ToString())
            comm.Parameters.AddWithValue("rows_eq", eq_rgv_addeq.Rows(eq_rgv_addeq.SelectedRows(0).Index).Cells(1).Value.ToString())
            comm.Parameters.AddWithValue("rows_eqsn", eq_rgv_addeq.Rows(eq_rgv_addeq.SelectedRows(0).Index).Cells(2).Value.ToString())


            reader = comm.ExecuteReader

            Dim count As Integer
            count = 0


            While reader.Read
                count += 1
            End While

            If count = 1 Then
                RadMessageBox.Show(Me, "Item Not Available", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                RadMessageBox.Show(Me, "Item Available", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
            End If
            MysqlConn.Close()
        Catch ex As IndexOutOfRangeException
            RadMessageBox.Show(Me, "No equipments to check.", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub




    'Reservation Management Code Umali R6 = Inserting Data to database
    'Under observation because of bugs that can be found in the future ' as of 09.06.16 4:55pm'

    Private Sub rec_btn_save_Click(sender As Object, e As EventArgs) Handles rec_btn_save.Click
        reserveYN = RadMessageBox.Show(Me, "Are you sure you want to reserve?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If reserveYN = MsgBoxResult.Yes Then



            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring
            Dim READER As MySqlDataReader

            Dim conflictequipmentno As String = ""
            Dim conflictequipment As String = ""
            Dim conflictequipmentsn As String = ""

            If (rec_cb_reserveno.Text = "") Or (rec_cb_idnum.Text = "") Or (rec_cb_borrower.Text = "") Or (rec_dtp_date.Text = "") Or (rec_dtp_starttime.Text = "") Or (rec_dtp_endtime.Text = "") Or (rec_cb_college_school.Text = "") Or (rec_cb_location.Text = "") Or (rec_cb_status.Text = "") Or (rec_eq_chooseno.Text = "") Or (rec_eq_type_choose.Text = "") Or (eq_rgv_addeq.Rows.Count < 0) Or (rec_cb_acttype.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
                Dim elapsedTime As TimeSpan = DateTime.Parse(Format(CDate(rec_dtp_date.Value), "yyyy-MM-dd") & " " & rec_dtp_endtime.Text).Subtract(DateTime.Parse(DateTime.Parse(Format(CDate(rec_dtp_date.Value), "yyyy-MM-dd") & " " & rec_dtp_starttime.Text)))
                'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
                If elapsedTime.CompareTo(TimeSpan.Zero) <= 0 Then
                    RadMessageBox.Show(Me, "The Starting Time can't be the same or later on the Ending Time.", "Reservation", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                Else
                    Dim counter As Integer
                    Dim rownumber As Integer = eq_rgv_addeq.Rows.Count
                    counter = 0
                    Dim errorcount As Boolean = False
                    If rownumber > 0 Then
                        While counter <> rownumber

                            Dim equipmentnorgv As String = eq_rgv_addeq.Rows(counter).Cells(0).Value
                            Dim equipmentrgv As String = eq_rgv_addeq.Rows(counter).Cells(1).Value
                            Dim equipmentsnrgv As String = eq_rgv_addeq.Rows(counter).Cells(2).Value

                            Try

                                MysqlConn.Close()
                                MysqlConn.Open()

                                query = "SELECT * from reservation where reservationno=@RE_reservationno and equipment=@RE_equipment and equipmentsn=@RE_equipmentsn and equipmentno=@RE_equipmentno and date=@RE_date and starttime=@RE_starttime and endtime=@RE_endtime"
                                comm = New MySqlCommand(query, MysqlConn)
                                comm.Parameters.AddWithValue("RE_reservationno", rec_cb_reserveno.Text)
                                comm.Parameters.AddWithValue("RE_equipment", equipmentrgv)
                                comm.Parameters.AddWithValue("RE_equipmentsn", equipmentsnrgv)
                                comm.Parameters.AddWithValue("RE_equipmentno", equipmentnorgv)
                                comm.Parameters.AddWithValue("RE_date", Format(CDate(rec_dtp_date.Value), "yyyy-MM-dd"))
                                comm.Parameters.AddWithValue("RE_starttime", Format(CDate(rec_dtp_starttime.Text), "HH:mm"))
                                comm.Parameters.AddWithValue("RE_endtime", Format(CDate(rec_dtp_endtime.Text), "HH:mm"))

                                READER = comm.ExecuteReader
                                Dim count As Integer
                                count = 0
                                While READER.Read

                                    count = count + 1
                                    equipmentnorgv = READER.GetString("equipmentno")
                                    equipmentrgv = READER.GetString("equipment")
                                    equipmentsnrgv = READER.GetString("equipmentsn")

                                End While

                                If count > 0 Then
                                    RadMessageBox.Show(Me, "The equipment " & equipmentrgv & " with serial number of " & equipmentsnrgv & " is already taken", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
                                    errorcount = True
                                    Exit While
                                Else

                                    MysqlConn.Close()
                                    MysqlConn.Open()
                                    query = "INSERT INTO `reservation` VALUES ('" & rec_cb_reserveno.Text & "','" & equipmentnorgv & "', '" & equipmentrgv & "', '" & equipmentsnrgv & "', '" & rec_cb_idnum.Text & "', '" & Format(CDate(rec_dtp_date.Value), "yyyy-MM-dd") & "','" & Format(CDate(rec_dtp_starttime.Text), "HH:mm") & "', '" & Format(CDate(rec_dtp_endtime.Text), "HH:mm") & "', '" & rec_cb_borrower.Text & "', '" & rec_cb_location.Text & "' , '" & lbl_nameofstaff_reserved.Text & "' ,'" & rec_cb_status.Text & "','" & rec_cb_acttype.Text & "','" & rec_rrtc_actname.Text & "')
                            ;INSERT INTO `reservation_equipments` VALUES ('" & rec_cb_reserveno.Text & "','" & equipmentnorgv & "', '" & equipmentrgv & "', '" & equipmentsnrgv & "')"

                                    comm = New MySqlCommand(query, MysqlConn)
                                    READER = comm.ExecuteReader
                                    MysqlConn.Close()

                                End If

                            Catch ex As Exception
                                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
                            Finally
                                MysqlConn.Dispose()
                            End Try
                            counter = counter + 1


                        End While
                        eq_rgv_addeq.Rows.Clear()
                        rowcounter = 0
                    End If

                    If errorcount = False Then
                        RadMessageBox.Show(Me, "Succesfully Equipment Reserved!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)

                    Else
                        RadMessageBox.Show(Me, "Not Successfully Reserved!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)

                    End If
                End If
            End If
            load_main_table()
            load_rec_table()
            reserved_load_table()
        End If
    End Sub

    'Showing All Data to Reservation Grid View
    Private Sub rec_btn_showalldata_Click(sender As Object, e As EventArgs) Handles rec_btn_showalldata.Click
        load_rec_table()
    End Sub

    'SHowing all available equipments to Reservation Grid View
    'Currently Pending because of importance
    Private Sub rec_btn_showavailequip_Click(sender As Object, e As EventArgs) Handles rec_btn_showavailequip.Click
        'MysqlConn = New MySqlConnection
        'MysqlConn.ConnectionString = connstring

        'Dim sda As New MySqlDataAdapter
        'Dim dbdataset As New DataTable
        'Dim bsource As New BindingSource

        'If MysqlConn.State = ConnectionState.Open Then
        '    MysqlConn.Close()
        'End If

        'Try
        '    MysqlConn.Open()
        '    'Relacing on how to show the taken equipments
        '    query = "SELECT equipmenttype AS 'Equipment Type',equipmentno AS 'Equipment No.',equipment AS 'Equipment', equipmentsn AS 'Equipment Serial' FROM equipments  ORDER BY equipmenttype ASC"

        '    comm = New MySqlCommand(query, MysqlConn)
        '    sda.SelectCommand = comm
        '    sda.Fill(dbdataset)
        '    bsource.DataSource = dbdataset
        '    reservation_rgv_recordeddata.DataSource = bsource
        '    reservation_rgv_recordeddata.ReadOnly = True
        '    sda.Update(dbdataset)
        '    MysqlConn.Close()

        'Catch ex As Exception
        '    RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        'Finally
        '    MysqlConn.Dispose()

        'End Try
    End Sub

    'Showing all Taken equipments to Reservation Grid View
    Private Sub rec_btn_showalltakeneq_Click(sender As Object, e As EventArgs) Handles rec_btn_showalltakeneq.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()
            'Pending Changes to show all taken equipments
            query = "SELECT reservationno as 'Reservation Number',equipmentno AS 'Equipment No.',equipment AS 'Equipment', equipmentsn AS 'Equipment Serial' FROM reservation_equipments"

            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            reservation_rgv_recordeddata.DataSource = bsource
            reservation_rgv_recordeddata.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    'Clearing of the Equipment Choice
    Private Sub rec_btn_eqclear_Click(sender As Object, e As EventArgs) Handles rec_btn_eqclear.Click
        rec_eq_type_choose.Text = ""
        rec_eq_chooseno.Text = ""
        rec_eq_chooseeq.Text = ""

    End Sub

    'WUTRY2 Checkbox for different end date, if not checked, "Date" as Start Date and End Date
    Private Sub rec_ckb_dted_CheckStateChanged(sender As Object, e As EventArgs) Handles rec_ckb_dted.CheckStateChanged
        If rec_ckb_dted.Checked Then
            RadLabel9.Visible = True
            rec_dtp_enddate.Visible = True

            RadLabel1.Location = New Point(rec_cb_reserveno.Location) + New Point(411, 4)
            RadLabel1.Text = "Start Date:"


            RadLabel9.Location = New Point(rec_cb_reserveno.Location) + New Point(416, 34)
            rec_dtp_enddate.Location = New Point(rec_cb_reserveno.Location) + New Point(475, 31)
            rec_dtp_enddate.Value = Date.Now.AddDays(1)

            RadLabel3.Location = New Point(rec_cb_reserveno.Location) + New Point(410, 63)
            rec_dtp_starttime.Location = New Point(rec_cb_reserveno.Location) + New Point(475, 61)

            RadLabel4.Location = New Point(rec_cb_reserveno.Location) + New Point(414, 93)
            rec_dtp_endtime.Location = New Point(rec_cb_reserveno.Location) + New Point(475, 91)
        Else
            RadLabel9.Visible = False
            rec_dtp_enddate.Visible = False

            RadLabel1.Location = New Point(rec_cb_reserveno.Location) + New Point(438, 4)
            RadLabel1.Text = "Date:"

            RadLabel3.Location = New Point(rec_cb_reserveno.Location) + New Point(410, 34)
            rec_dtp_starttime.Location = New Point(rec_cb_reserveno.Location) + New Point(475, 31)

            RadLabel4.Location = New Point(rec_cb_reserveno.Location) + New Point(414, 63)
            rec_dtp_endtime.Location = New Point(rec_cb_reserveno.Location) + New Point(475, 61)
        End If
    End Sub

    'AutoGenerating of Reservation#
    Public Sub auto_generate_reservationno()
        identifier_reservationno = Now.ToString("mmddyyy" + "-")
        identifier_reservationno = identifier_reservationno + random.Next(1, 100000000).ToString
        rec_cb_reserveno.Text = identifier_reservationno
    End Sub

    'Deletion of data in Reservation Page
    Private Sub rec_btn_delete_Click(sender As Object, e As EventArgs) Handles rec_btn_delete.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want to delete?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If deleteYN = MsgBoxResult.Yes Then
            Try
                MysqlConn.Open()
                query = "DELETE FROM reservation WHERE (reservationno=@R_rec_cb_reserveno) AND (id=@R_rec_cb_idnum)"
                comm = New MySqlCommand(query, MysqlConn)
                comm.Parameters.AddWithValue("R_rec_cb_reserveno", rec_cb_reserveno.Text)
                comm.Parameters.AddWithValue("R_rec_cb_idnum", rec_cb_idnum.Text)

                reader = comm.ExecuteReader


                RadMessageBox.Show(Me, "Successfully Deleted!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
                MysqlConn.Close()
            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
            End Try
        End If
        load_rec_table()
        load_main_table()
    End Sub

    'Combining (Fname,Lname) in Borrower Field in Reservation
    Private Sub rec_cb_idnum_TextChanged(sender As Object, e As EventArgs) Handles rec_cb_idnum.TextChanged
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT CONCAT (bor_surname,', ',bor_fname) as 'Name' FROM borrowers_reg WHERE bor_id=@bor_idno"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("bor_idno", rec_cb_idnum.Text)
            reader = comm.ExecuteReader

            rec_cb_borrower.Items.Clear()
            While reader.Read
                rec_cb_borrower.Items.Add(reader.GetString("name"))
            End While

            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub


    'Clearing of Fields in Reservation Page
    Private Sub rec_btn_clear_Click(sender As Object, e As EventArgs) Handles rec_btn_clear.Click
        auto_generate_reservationno()
        rec_cb_borrower.Text = ""
        rec_cb_idnum.Text = ""
        rec_cb_acttype.Text = ""
        rec_dtp_date.Value = Date.Now
        rec_cb_status.Text = ""
        rec_dtp_starttime.Text = ""
        rec_dtp_endtime.Text = ""
        rec_cb_college_school.Text = ""
        rec_cb_location.Text = ""
        rec_cb_status.Text = ""
        rec_eq_chooseeq.Text = ""
        rec_eq_chooseno.Text = ""
        rec_eq_type_choose.Text = ""
        eq_rgv_addeq.Rows.Clear()
        rec_rrtc_actname.Text = ""
    End Sub

    'Loading of data in Reservation Page Grid
    Private Sub rec_dtp_date_ValueChanged(sender As Object, e As EventArgs) Handles rec_dtp_date.ValueChanged
        load_rec_table()
    End Sub

    'Loading of data in Main Page Grid
    Private Sub lu_date_filter_delay_Tick(sender As Object, e As EventArgs) Handles lu_date_filter_delay.Tick
        lu_date_filter_delay.Stop()
        load_main_table()
    End Sub

    Private Sub lu_date_ValueChanged(sender As Object, e As EventArgs) Handles lu_date.ValueChanged
        lu_date_filter_delay.Interval = 500
        lu_date_filter_delay.Stop()
        lu_date_filter_delay.Start()
    End Sub

    'Double Click function in Reservation Tab Page
    Private Sub reservation_rgv_recordeddata_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles reservation_rgv_recordeddata.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo

            row = Me.reservation_rgv_recordeddata.Rows(e.RowIndex)

            rec_cb_reserveno.Text = row.Cells("Reservation Number").Value.ToString
            rec_cb_idnum.Text = row.Cells("ID").Value.ToString.ToString
        End If

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want to delete?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If deleteYN = MsgBoxResult.Yes Then
            Try
                MysqlConn.Open()
                query = "DELETE FROM reservation WHERE (reservationno=@R_rec_cb_reserveno) AND (id=@R_rec_cb_idnum)"
                comm = New MySqlCommand(query, MysqlConn)
                comm.Parameters.AddWithValue("R_rec_cb_reserveno", rec_cb_reserveno.Text)
                comm.Parameters.AddWithValue("R_rec_cb_idnum", rec_cb_idnum.Text)

                reader = comm.ExecuteReader


                RadMessageBox.Show(Me, "Successfully Deleted!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
                MysqlConn.Close()
            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
            End Try
        End If
        load_rec_table()
        load_main_table()
    End Sub


    'Auto Generating of Reservation Number
    Private Sub btn_resetreservationno_Click(sender As Object, e As EventArgs) Handles btn_resetreservationno.Click
        auto_generate_reservationno()
    End Sub

    Private Sub Main_Timer_Tick(sender As Object, e As EventArgs) Handles Main_Timer.Tick
        Dim title As String = "TLTD Scheduling System"
        Me.Text = title + Date.Now.ToString("            MMMM dd, yyyy  hh:mm:ss tt")
    End Sub

    Private Sub rpv1_Click(sender As Object, e As EventArgs) Handles rpv1.Click
        'load_main_table()
        'load_rec_table()
    End Sub


    Private Sub rec_cb_acttype_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles rec_cb_acttype.SelectedIndexChanged
        If rec_cb_acttype.Text = "School Activity" Then
            rec_rrtc_actname.Enabled = True
            rec_lbl_actname.Enabled = True
        Else
            rec_rrtc_actname.Enabled = False
            rec_lbl_actname.Enabled = False
            rec_rrtc_actname.Text = ""
        End If

    End Sub

    Private Sub eq_btn_other_Click(sender As Object, e As EventArgs) Handles eq_btn_other.Click
        eq_type.DropDownStyle = RadDropDownStyle.DropDown
    End Sub

    Public Sub load_cb_eq_type()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT DISTINCT(equipmenttype) from equipments"
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            eq_type.Items.Clear()
            While reader.Read
                eq_type.Items.Add(reader.GetString("equipmenttype"))
            End While

            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub





































    'PENDING CHANGES
    'WILL I CHANGE BORROWER TO BORROWER ID#?





    '[FUTURE REFERENCE] 'Reservation Management Code Umali R5.5 = Checking the availabity of the equipment using CellClick

    'Private Sub eq_rgv_addeq_CellClick(sender As Object, e As GridViewCellEventArgs) Handles eq_rgv_addeq.CellClick
    '    If MysqlConn.State = ConnectionState.Open Then
    '        MysqlConn.Close()
    '    End If
    '    MysqlConn.ConnectionString = connstring


    '    Try
    '        MysqlConn.Open()
    '        query = "Select equipment,equipmentsn from reservation_equipment where equipment='" & eq_rgv_addeq.Rows(e.RowIndex).Cells(0).Value & "' and equipmentsn='" & eq_rgv_addeq.Rows(e.RowIndex).Cells(1).Value & "' "
    '        comm = New MySqlCommand(query, MysqlConn)
    '        reader = comm.ExecuteReader

    '        Dim count As Integer
    '        count = 0


    '        While reader.Read
    '            count += 1
    '        End While

    '        If count = 1 Then
    '            RadMessageBox.Show(Me, "Item Not Available", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
    '        Else
    '            RadMessageBox.Show(Me, "Item Available", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
    '        End If

    '    Catch ex As Exception
    '        RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
    '    Finally
    '        MysqlConn.Dispose()

    '    End Try
    'End Sub




    ''TEST CODES

    'Private Sub eq_type_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
    '    If MysqlConn.State = ConnectionState.Open Then
    '        MysqlConn.Close()
    '    End If
    '    MysqlConn.ConnectionString = connstring
    '    Try
    '        MysqlConn.Open()
    '        query = "SELECT * from equipments where equipmenttype='" & eq_type.Text & "'"
    '        comm = New MySqlCommand(query, MysqlConn)
    '        reader = comm.ExecuteReader

    '        Dim count As Integer
    '        count = 0
    '        eq_equipment.Items.Clear()
    '        While reader.Read

    '            eq_equipment.Items.Add(reader.GetString("equipment"))

    '        End While
    '    Catch ex As Exception
    '        RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
    '    Finally
    '        MysqlConn.Dispose()

    '    End Try
    'End Sub

    'Private Sub eq_equipment_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
    '    If MysqlConn.State = ConnectionState.Open Then
    '        MysqlConn.Close()
    '    End If
    '    MysqlConn.ConnectionString = connstring
    '    Try
    '        MysqlConn.Open()
    '        query = "SELECT * from equipments where equipmenttype='" & eq_type.Text & "' and equipment='" & eq_equipment.Text & "' "
    '        comm = New MySqlCommand(query, MysqlConn)
    '        reader = comm.ExecuteReader

    '        Dim count As Integer
    '        count = 0
    '        eq_equipmentloction.Items.Clear()

    '        While reader.Read
    '            eq_equipmentloction.Items.Add(reader.GetString("equipmentlocation"))
    '        End While

    '    Catch ex As Exception
    '        RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
    '    Finally
    '        MysqlConn.Dispose()

    '    End Try
    'End Sub

    'Private Sub eq_equipmentlocation_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
    '    If MysqlConn.State = ConnectionState.Open Then
    '        MysqlConn.Close()
    '    End If
    '    MysqlConn.ConnectionString = connstring
    '    Try
    '        MysqlConn.Open()
    '        query = "SELECT * from equipments where equipmenttype='" & eq_type.Text & "' and equipment='" & eq_equipment.Text & "' and equipmentlocation='" & eq_equipmentloction.Text & "' "
    '        comm = New MySqlCommand(query, MysqlConn)
    '        reader = comm.ExecuteReader

    '        Dim count As Integer
    '        count = 0
    '        eq_owner.Items.Clear()

    '        While reader.Read
    '            eq_owner.Items.Add(reader.GetString("equipmentowner"))
    '        End While

    '    Catch ex As Exception
    '        RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
    '    Finally
    '        MysqlConn.Dispose()

    '    End Try
    'End Sub

    'Private Sub eq_owner_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
    '    If MysqlConn.State = ConnectionState.Open Then
    '        MysqlConn.Close()
    '    End If
    '    MysqlConn.ConnectionString = connstring
    '    Try
    '        MysqlConn.Open()
    '        query = "SELECT * from equipments where equipmenttype='" & eq_type.Text & "' and equipment='" & eq_equipment.Text & "' and equipmentlocation='" & eq_equipmentloction.Text & "' and equipmentowner='" & eq_owner.Text & "' "
    '        comm = New MySqlCommand(query, MysqlConn)
    '        reader = comm.ExecuteReader

    '        Dim count As Integer
    '        count = 0
    '        eq_status.Items.Clear()

    '        While reader.Read
    '            eq_status.Items.Add(reader.GetString("equipmentstatus"))
    '        End While

    '    Catch ex As Exception
    '        RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
    '    Finally
    '        MysqlConn.Dispose()

    '    End Try
    'End Sub


End Class
