Imports MySql.Data.MySqlClient
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Data

Public Class Main

    Dim ds As New DataSet
    Dim MysqlConn As MySqlConnection

    Dim dbDataSet As New DataTable
    Dim svYN As DialogResult
    Dim addYN As DialogResult
    Dim editYN As DialogResult
    Dim cancelYN As DialogResult
    Dim updateYN As DialogResult
    Dim deleteYN As DialogResult
    Dim doneYN As DialogResult

    Public equipment As String
    Public rowcounter As Integer = 0
    Dim query As String

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
        load_returned_list()
        rec_load_choices_eqtype()


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
        rel_tb_status.Enabled = False
        rel_tb_id.Enabled = False
        rel_tb_borrower.Enabled = False
        rel_tb_type.Enabled = False
        rel_tb_college.Enabled = False

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

    Private Sub main_rgv_recordeddatamain_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles main_rgv_recordeddatamain.ViewCellFormatting
        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
    End Sub

    Private Sub reservation_rgv_recordeddata_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles reservation_rgv_recordeddata.ViewCellFormatting
        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
    End Sub

    Public Sub load_rec_table()
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

            query = "Select DATE_FORMAT(startdate,'%M %d %Y') as 'Start Date', DATE_FORMAT(enddate,'%M %d, %Y') as 'End Date', TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time', borrower as 'Borrower',location as 'Location', equipment as 'Equipment' from reservation"

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

        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()

            query = "Select DATE_FORMAT(startdate,'%M %d %Y') as 'Start Date', DATE_FORMAT(enddate,'%M %d, %Y') as 'End Date', TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time', borrower as 'Borrower',location as 'Location', equipment as 'Equipment' from reservation"

            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            main_rgv_recordeddatamain.DataSource = bsource
            main_rgv_recordeddatamain.ReadOnly = True
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
            query = "Select prof_id as 'Professor ID' , prof_fname as 'First Name' , prof_mname as 'Middle Name' , prof_surname as 'Surname' , prof_college as 'College/School' , prof_type as 'User Type'  from prof_reg"
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
                Query = "insert into ceutltdscheduler.staff_reg (staff_id,staff_fname,staff_mname,staff_surname,staff_type,staff_username,staff_password) values ('" & acc_sf_id.Text & "' , '" & acc_sf_fname.Text & "', '" & acc_sf_mname.Text & "', '" & acc_sf_lname.Text & "' ,  '" & acc_sf_usertype.Text & "' , '" & acc_sf_username.Text & "' , sha2('" & acc_sf_password.Text & "', 512))"
                comm = New MySqlCommand(Query, MysqlConn)

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
        If (acc_pf_id.Text = "") Or (acc_pf_fname.Text = "") Or (acc_pf_mname.Text = " ") Or (acc_pf_lname.Text = " ") Or (acc_pf_college.Text = " ") Or (acc_pf_usertype.Text = " ") Then
            RadMessageBox.Show(Me, "Please complete the fields to Save!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "insert into ceutltdscheduler.prof_reg (prof_id,prof_fname,prof_mname,prof_surname,prof_college,prof_type) values ('" & acc_pf_id.Text & "' , '" & acc_pf_fname.Text & "' , '" & acc_pf_mname.Text & "' , '" & acc_pf_lname.Text & "' , '" & acc_pf_college.Text & "' , '" & acc_pf_usertype.Text & "')"
                comm = New MySqlCommand(Query, MysqlConn)

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
                acc_pf_usertype.Text = " "

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
                acc_pf_usertype.Text = row.Cells("User Type").Value.ToString

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
            If (acc_pf_id.Text = "") Or (acc_pf_fname.Text = "") Or (acc_pf_mname.Text = " ") Or (acc_pf_lname.Text = " ") Or (acc_pf_college.Text = " ") Or (acc_pf_usertype.Text = " ") Then
                RadMessageBox.Show(Me, "Please complete the fields to update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "UPDATE prof_reg set prof_id = '" & acc_pf_id.Text & "' , prof_fname = '" & acc_pf_fname.Text & "' , prof_mname = '" & acc_pf_mname.Text & "' , prof_surname = '" & acc_pf_lname.Text & "' , prof_college = '" & acc_pf_college.Text & "' , prof_type = '" & acc_pf_usertype.Text & "' where prof_id = '" & acc_pf_id.Text & "' "
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
                Query = "delete from prof_reg where prof_id = '" & acc_pf_id.Text & "'"
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
                acc_pf_usertype.Text = " "

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
            acc_pf_usertype.Text = " "

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
            query = "Select rel_idnum as 'ID Number ' , rel_borrower as ' Borrower ' , rel_type as ' Type ' , rel_startdate as ' Start Date ' , rel_enddate as ' End Date ' , rel_starttime as ' Start Time ' , rel_endtime as ' End Time ' , rel_location as ' Location ' , rel_status as ' Status ' , rel_releasedby as ' Released By'  from released_info"
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
            query = "Select rel_idnum as 'ID Number ' , rel_borrower as ' Borrower ' , rel_type as ' Type ' , rel_startdate as ' Start Date ' , rel_enddate as ' End Date ' , rel_starttime as ' Start Time ' , rel_endtime as ' End Time ' , rel_location as ' Location ' , rel_status as ' Status ' , rel_releasedby as ' Released By'  from released_info"
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

    'Programmed by BRENZ 15th POINT Load form grid RETURNED at returning Management!
    Public Sub load_returned_list()
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
            query = "Select ret_idnum as 'ID Number ' , ret_borrower as ' Borrower ' , ret_type as ' Type ' , ret_startdate as ' Start Date ' , ret_enddate as ' End Date ' , ret_starttime as ' Start Time ' , ret_endtime as ' End Time ' , ret_location as ' Location ' , ret_status as ' Status ' , ret_releasedby as ' Released By' , ret_returnedto as ' Returned to '  from returned_info"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            returned_grid_list.DataSource = bsource
            returned_grid_list.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    'Programmed by BRENZ 16th point RELEASE BTN at Releasing Management!
    Private Sub released_btn_release_Click(sender As Object, e As EventArgs) Handles released_btn_release.Click

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim READER As MySqlDataReader
        If (rel_tb_id.Text = "") Or (rel_tb_borrower.Text = "") Or (rel_tb_type.Text = " ") Or (rel_tb_startdate.Text = " ") Or (rel_tb_enddate.Text = " ") Or (rel_tb_starttime.Text = " ") Or (rel_tb_endtime.Text = " ") Or (rel_tb_college.Text = " ") Or (rel_tb_location.Text = " ") Or (rel_tb_releasedby.Text = " ") Then
            RadMessageBox.Show(Me, "Please complete the fields to Save!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "insert into ceutltdscheduler.released_info (rel_idnum,rel_borrower,rel_type,rel_type,rel_startdate,rel_enddate,rel_starttime,rel_endtime,rel_college,rel_location,rel_status,rel_releasedby) values ('" & rel_tb_id.Text & "' , '" & rel_tb_borrower.Text & "' , '" & rel_tb_type.Text & "' , '" & rel_tb_startdate.Text & "' , '" & rel_tb_enddate.Text & "' , '" & rel_tb_starttime.Text & "' , '" & rel_tb_endtime.Text & "' , '" & rel_tb_college.Text & "' , '" & rel_tb_location.Text & "' , '" & rel_tb_status.Text & "' , '" & rel_tb_releasedby.Text & "')"
                comm = New MySqlCommand(Query, MysqlConn)

                svYN = RadMessageBox.Show(Me, "Are you sure you want to Release this Equipment/s? ", "TLTD Schuling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                If svYN = MsgBoxResult.Yes Then
                    rel_tb_status.Text = "Released"
                    rel_tb_status.BackColor = Color.Red
                    READER = comm.ExecuteReader
                    RadMessageBox.Show("Released!")

                End If
                MysqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
                load_released_list()
                load_released_list2()

            End Try
        End If

    End Sub


    'Programmed by BRENZ 17th Point UPDATE BTN at Releasing Management
    Private Sub released_btn_update_Click(sender As Object, e As EventArgs) Handles released_btn_update.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        updateYN = RadMessageBox.Show(Me, "Do you want to Update the Date/Time/Location of the Reserved Equipment?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (rel_tb_startdate.Text = "") Or (rel_tb_enddate.Text = " ") Or (rel_tb_starttime.Text = " ") Or (rel_tb_endtime.Text = " ") Or (rel_tb_location.Text = " ") Then
                RadMessageBox.Show(Me, "Please complete the fields to update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "UPDATE released_info set rel_startdate = '" & rel_tb_starttime.Text & "' , rel_enddate = '" & rel_tb_enddate.Text & "' , rel_starttime = '" & rel_tb_starttime.Text & "' , rel_endtime = '" & rel_tb_endtime.Text & "' , rel_location = '" & rel_tb_location.Text & "' where rel_startdate = '" & rel_tb_startdate.Text & "' "
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





    Private Sub rec_btn_save_Click(sender As Object, e As EventArgs) Handles rec_btn_save.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim READER As MySqlDataReader


        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        If (rec_dtp_startdate.Text = "") Or (rec_dtp_enddate.Text = "") Or (rec_dtp_starttime.Text = "") Or (rec_dtp_endtime.Text = "") Or (rec_cb_borrower.Text = "") Or (rec_cb_location.Text = "") Or (rec_eq_type_choose.Text = "") Then
            RadMessageBox.Show(Me, "Please complete the form", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            Try
                MysqlConn.Open()


                query = "Select * from reservation where (equipment='" & rec_eq_type_choose.Text & "') and (('" & Format(CDate(rec_dtp_startdate.Value), "yyyy-MM-dd") & " " & Format(CDate(rec_dtp_starttime.Text), "hh:mm") & "' BETWEEN CONCAT(startdate,' ',starttime) AND CONCAT(enddate,' ',endtime)) OR
            ('" & Format(CDate(rec_dtp_enddate.Value), "yyyy-MM-dd") & " " & Format(CDate(rec_dtp_endtime.Text), "hh:mm") & "' BETWEEN CONCAT (enddate,' ',starttime) AND CONCAT(enddate,' ',endtime)))"
                comm = New MySqlCommand(query, MysqlConn)
                READER = comm.ExecuteReader

                Dim count As Integer
                count = 0

                While READER.Read
                    count += 1
                End While

                If count = 1 Then
                    RadMessageBox.Show(Me, "The time " & Format(CDate(rec_dtp_starttime.Text), "HH:mm") & " and " & "the equipment " & rec_eq_type_choose.Text & " is already in used.", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)

                Else
                    MysqlConn.Close()
                    MysqlConn.Open()

                    addYN = RadMessageBox.Show(Me, "Are you sure you want to save this reservation?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                    If addYN = MsgBoxResult.Yes Then
                        query = "INSERT INTO reservation (startdate,enddate,starttime,endtime,borrower,location,equipment,reservedby,status) VALUES ('" & Format(CDate(rec_dtp_startdate.Value), "yyyy-MM-dd") & "','" & Format(CDate(rec_dtp_enddate.Value), "yyyy-MM-dd") & "','" & Format(CDate(rec_dtp_starttime.Text), "HH:mm") & "',
                        '" & Format(CDate(rec_dtp_endtime.Text), "HH:mm") & "', '" & rec_cb_borrower.Text & "','" & rec_cb_location.Text & "','" & rec_eq_type_choose.Text & "','" & rec_cb_reserved.Text & "','" & rec_cb_status.Text & "')  "
                        comm = New MySqlCommand(query, MysqlConn)
                        READER = comm.ExecuteReader

                        RadMessageBox.Show(Me, "Details Saved!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)
                        MysqlConn.Close()

                    End If

                End If

            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()

            End Try

        End If
        load_main_table()
        load_rec_table()

    End Sub


    'Main Window Search Functions Umali C1

    Private Sub btn_searchbydate_Click(sender As Object, e As EventArgs) Handles btn_searchbydate.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            MysqlConn.Open()

            query = "select DATE_FORMAT(startdate,'%M %d %Y') as 'Start Date', DATE_FORMAT(enddate,'%M %d, %Y') as 
            'End Date', TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time', borrower as 
            'Borrower',location as 'Location', equipment as 'Equipment' from reservation
            where (((startdate between '" & Format(CDate(lu_startdate.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(lu_enddate.Value), "yyyy-MM-dd") & "') and 
            (starttime between '" & Format(CDate(lu_starttime.Text), "HH:mm") & "' and '" & Format(CDate(lu_starttime.Text), "HH:mm") & "')) or
            ((enddate between '" & Format(CDate(lu_startdate.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(lu_enddate.Value), "yyyy-MM-dd") & "') and
            (endtime between '" & Format(CDate(lu_endtime.Text), "HH:mm") & "' and '" & Format(CDate(lu_endtime.Text), "HH:mm") & "')))"

            comm = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            main_rgv_recordeddatamain.DataSource = bsource
            SDA.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    'Main Window Search Functions Umali C2

    Private Sub lu_bylocation_TextChanged(sender As Object, e As EventArgs) Handles lu_bylocation.TextChanged
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            MysqlConn.Open()

            query = "SELECT DATE_FORMAT(startdate,'%M %d %Y') AS 'Start Date', DATE_FORMAT(enddate,'%M %d, %Y') AS 
            'End Date', TIME_FORMAT(starttime, '%H:%i') AS 'Start Time', TIME_FORMAT(endtime, '%H:%i') AS 'End Time', borrower AS 
            'Borrower',location AS 'Location', equipment AS 'Equipment' FROM reservation ORDER BY location desc"
            comm = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            main_rgv_recordeddatamain.DataSource = bsource
            SDA.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(dbdataset)
        DV.RowFilter = String.Format("`Location` Like'%{0}%'", lu_bylocation.Text)
        main_rgv_recordeddatamain.DataSource = DV
    End Sub

    'Main Window Search Functions Umali C3
    Private Sub lu_byequipment_TextChanged(sender As Object, e As EventArgs) Handles lu_byequipment.TextChanged
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            MysqlConn.Open()

            query = "SELECT DATE_FORMAT(startdate,'%M %d %Y') AS 'Start Date', DATE_FORMAT(enddate,'%M %d, %Y') AS 
            'End Date', TIME_FORMAT(starttime, '%H:%i') AS 'Start Time', TIME_FORMAT(endtime, '%H:%i') AS 'End Time', borrower AS 
            'Borrower',location AS 'Location', equipment AS 'Equipment' FROM reservation ORDER BY equipment desc"
            comm = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            main_rgv_recordeddatamain.DataSource = bsource
            SDA.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(dbdataset)
        DV.RowFilter = String.Format("`Equipment` Like'%{0}%'", lu_byequipment.Text)
        main_rgv_recordeddatamain.DataSource = DV
    End Sub

    'Equipment Management Codes Umali C1 EQ_LOAD_EQ_TABLE

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

    'Equipment Management Codes Umali C2 EQ_BTN_SAVE

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
                query = "SELECT * from equipments where (equipmentsn='" & eq_sn.Text & "')"

                comm = New MySqlCommand(query, MysqlConn)
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
                        query = "INSERT INTO `equipments` VALUES ('" & eq_equipmentno.Text & "','" & eq_equipment.Text & "','" & eq_sn.Text & "','" & eq_equipmentlocation.Text & "','" & eq_owner.Text & "','" & eq_status.Text & "','" & eq_type.Text & "')"

                        comm = New MySqlCommand(query, MysqlConn)
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


    'Equipment Management Codes Umali C3 EQ_BTN_UPDATE

    Private Sub eq_btn_update_Click(sender As Object, e As EventArgs) Handles eq_btn_update.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        updateYN = RadMessageBox.Show(Me, "Do you want To update the selected equipment?", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (eq_equipmentno.Text = "") Or (eq_sn.Text = "") Or (eq_equipment.Text = "") Or (eq_equipmentlocation.Text = "") Or (eq_owner.Text = "") Or (eq_status.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields To update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "UPDATE equipments Set equipmentno='" & eq_equipmentno.Text & "',equipmentsn='" & eq_sn.Text & "',equipment='" & eq_equipment.Text & "', equipmentlocation='" & eq_equipmentlocation.Text & "',equipmentowner='" & eq_owner.Text & "',equipmentstatus='" & eq_status.Text & "',equipmentype='" & eq_type.Text & "' where (equipmentsn='" & eq_sn.Text & "') and (equipmentno='" & eq_equipmentno.Text & "')"
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
        load_eq_table()
        counter_of_total_eq()
    End Sub

    'Equipment Management Codes Umali C4 EQ_BTN_DELETE

    Private Sub eq_btn_delete_Click(sender As Object, e As EventArgs) Handles eq_btn_delete.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want to delete?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If deleteYN = MsgBoxResult.Yes Then
            Try
                MysqlConn.Open()
                query = "DELETE FROM equipments where equipmentno='" & eq_equipmentno.Text & "' and equipmentsn='" & eq_sn.Text & "' "
                comm = New MySqlCommand(query, MysqlConn)
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

    'Equipment Management Codes Umali C5 EQ_CELLDOUBLECLICK

    Private Sub eq_rgv_showregequipment_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles eq_rgv_showregequipment.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo

            row = Me.eq_rgv_showregequipment.Rows(e.RowIndex)

            eq_equipmentno.Text = row.Cells("Equipment Number").Value.ToString
            eq_equipment.Text = row.Cells("Equipment").Value.ToString
            eq_equipmentlocation.Text = row.Cells("Equipment Location").Value.ToString
            eq_sn.Text = row.Cells("Serial Number").Value.ToString
            eq_status.Text = row.Cells("Status").Value.ToString
            eq_owner.Text = row.Cells("Owner").Value.ToString
            eq_type.Text = row.Cells("Equipment Type").Value.ToString

            eq_btn_update.Show()
            eq_btn_delete.Show()
            eq_btn_save.Hide()
        End If
    End Sub

    'Equipment Management Codes Umali C6 = EQ_BTN_CLEAR

    Private Sub eq_btn_clear_Click(sender As Object, e As EventArgs) Handles eq_btn_clear.Click
        eq_equipmentno.Text = ""
        eq_equipment.Text = ""
        eq_equipmentlocation.Text = ""
        eq_sn.Text = ""
        eq_status.Text = ""
        eq_owner.Text = ""
        eq_type.Text = ""

        eq_btn_update.Hide()
        eq_btn_delete.Hide()
        eq_btn_save.Show()
    End Sub

    'Equipment Management Codes Umali C7 = SEARCH BY EQ_NO
    Private Sub eq_filter_eqno_TextChanged(sender As Object, e As EventArgs) Handles eq_filter_eqno.TextChanged

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

            query = "SELECT equipmentno as 'Equipment Number', equipment as 'Equipment', equipmentsn as 'Serial Number',equipmenttype as 'Equipment Type', equipmentlocation as 'Equipment Location',equipmentowner as 'Owner',equipmentstatus as 'Status' from equipments ORDER BY equipmentno DESC"

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
        DV.RowFilter = String.Format("`Equipment Number`= '{0}'", eq_filter_eqno.Text)
        eq_rgv_showregequipment.DataSource = DV
    End Sub

    'Equipment Management Codes Umali C8 = SEARCH BY EQ_TYPE
    Private Sub eq_filter_eqtype_TextChanged(sender As Object, e As EventArgs) Handles eq_filter_eqtype.TextChanged
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

            query = "SELECT equipmentno as 'Equipment Number', equipment as 'Equipment', equipmentsn as 'Serial Number',equipmenttype as 'Equipment Type', equipmentlocation as 'Equipment Location',equipmentowner as 'Owner',equipmentstatus as 'Status' from equipments ORDER BY equipmentno DESC"

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
        DV.RowFilter = String.Format("`Equipment Type` Like'%{0}%'", eq_filter_eqtype.Text)
        eq_rgv_showregequipment.DataSource = DV
    End Sub

    'Equipment Management Codes Umali C9 = SEARCH BY EQ_STATUS
    Private Sub eq_filter_eqstatus_TextChanged(sender As Object, e As EventArgs) Handles eq_filter_eqstatus.TextChanged
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

                query = "SELECT equipmentno as 'Equipment Number', equipment as 'Equipment', equipmentsn as 'Serial Number',equipmenttype as 'Equipment Type', equipmentlocation as 'Equipment Location',equipmentowner as 'Owner',equipmentstatus as 'Status' from equipments ORDER BY equipmentno DESC"

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
            DV.RowFilter = String.Format("`Status` Like'%{0}%'", eq_filter_eqstatus.Text)
            eq_rgv_showregequipment.DataSource = DV
        End If
    End Sub

    'Equipment Management Codes Umali C10 = COUNTER
    Private Sub eq_counter_type_SelectedIndexChanged_1(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles eq_counter_type.SelectedIndexChanged
        counter_of_total_eq()
    End Sub

    'Equipment Management Codes Umali C11 = COUNTER CODE
    Public Sub counter_of_total_eq()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()

            Dim holder As String

            query = "SELECT count(equipmenttype) as 'total' FROM equipments WHERE equipmenttype='" & eq_counter_type.Text & "'"
            comm = New MySqlCommand(query, MysqlConn)
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


    ' Reservation Management Code Umali C12 = LOADING DATA TO rec_eq_type_choose
    Public Sub rec_load_choices_eqtype()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT DISTINCT(equipmenttype) from equipments ORDER BY equipmenttype ASC"
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            Dim count As Integer
            count = 0
            rec_eq_type_choose.Items.Clear()
            While reader.Read

                rec_eq_type_choose.Items.Add(reader.GetString("equipmenttype"))

            End While
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    'Reservation Management Code Umali C12 = FILTERING OF DATA ACCORDING TO REC_EQTYOE_CHOOSE
    Private Sub rec_eq_type_choose_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles rec_eq_type_choose.SelectedIndexChanged
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT equipment from equipments where equipmenttype='" & rec_eq_type_choose.Text & "'"
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            Dim count As Integer
            count = 0
            rec_eq_choose_eq.Items.Clear()
            While reader.Read

                rec_eq_choose_eq.Items.Add(reader.GetString("equipment"))

            End While
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    'TEST CODES

    Private Sub eq_type_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles eq_type.SelectedIndexChanged
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT * from equipments where equipmenttype='" & eq_type.Text & "'"
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            Dim count As Integer
            count = 0
            eq_equipment.Items.Clear()
            While reader.Read

                eq_equipment.Items.Add(reader.GetString("equipment"))

            End While
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    Private Sub eq_equipment_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles eq_equipment.SelectedIndexChanged
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT * from equipments where equipmenttype='" & eq_type.Text & "' and equipment='" & eq_equipment.Text & "' "
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            Dim count As Integer
            count = 0
            eq_equipmentlocation.Items.Clear()

            While reader.Read
                eq_equipmentlocation.Items.Add(reader.GetString("equipmentlocation"))
            End While

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    Private Sub eq_equipmentlocation_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles eq_equipmentlocation.SelectedIndexChanged
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT * from equipments where equipmenttype='" & eq_type.Text & "' and equipment='" & eq_equipment.Text & "' and equipmentlocation='" & eq_equipmentlocation.Text & "' "
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            Dim count As Integer
            count = 0
            eq_owner.Items.Clear()

            While reader.Read
                eq_owner.Items.Add(reader.GetString("equipmentowner"))
            End While

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    Private Sub eq_owner_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles eq_owner.SelectedIndexChanged
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT * from equipments where equipmenttype='" & eq_type.Text & "' and equipment='" & eq_equipment.Text & "' and equipmentlocation='" & eq_equipmentlocation.Text & "' and equipmentowner='" & eq_owner.Text & "' "
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            Dim count As Integer
            count = 0
            eq_status.Items.Clear()

            While reader.Read
                eq_status.Items.Add(reader.GetString("equipmentstatus"))
            End While

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub



    Private Sub rec_btn_add_eq_Click(sender As Object, e As EventArgs) Handles rec_btn_add_eq.Click

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring

        If rec_eq_choose_eq.Text = "" Then
            RadMessageBox.Show(Me, "Choose Equipment!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        ElseIf rec_eq_type_choose.Text = "" Then
            RadMessageBox.Show(Me, "Choose the Type of Equipment!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Else
            Try
                MysqlConn.Open()
                query = "SELECT equipmentsn as 'Serial Number' from equipments where equipmenttype='" & rec_eq_type_choose.Text & "' and equipment='" & rec_eq_choose_eq.Text & "' "
                comm = New MySqlCommand(query, MysqlConn)
                reader = comm.ExecuteReader

                Dim count As Integer
                count = 0
                Dim temp As String

                While reader.Read
                    temp = reader.GetString("Serial Number")
                End While

                eq_rgv_addeq.Rows.Add(rec_eq_choose_eq.Text, temp)

                rowcounter += 1


            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
            End Try



        End If



        'If MysqlConn.State = ConnectionState.Open Then
        '    MysqlConn.Close()
        'End If
        'Dim count As Integer

        'MysqlConn.ConnectionString = connstring

        'Dim sda As New MySqlDataAdapter
        'Dim dbdataset As New DataTable
        'Dim bsource As New BindingSource
        'count = 0

        'Try
        '    MysqlConn.Open()
        '    query = "SELECT equipment as 'Equipments' from equipments where equipmenttype='" & rec_eq_type_choose.Text & "' and equipment ='" & rec_eq_choose_eq.Text & "'"
        '    comm = New MySqlCommand(query, MysqlConn)
        '    sda.SelectCommand = comm
        '    sda.Fill(dbdataset)
        '    bsource.DataSource = dbdataset
        '    eq_rgv_addeq.DataSource = bsource
        '    eq_rgv_addeq.ReadOnly = True
        '    sda.Update(dbdataset)



        '    'eq_rgv_addeq.Rows.Clear()

        '    With eq_rgv_addeq
        '        Dim rowinfo As New GridViewDataRowInfo(Me.eq_rgv_addeq.MasterView)
        '        rowinfo.Cells(0).Value = rec_eq_choose_eq.Text

        '    End With
        '    MysqlConn.Close()
        'Catch ex As Exception
        '    RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        'Finally
        '    MysqlConn.Dispose()

        'End Try
        'count += 1

    End Sub





End Class
