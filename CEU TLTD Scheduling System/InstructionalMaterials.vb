Imports MySql.Data.MySqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Public Class InstructionalMaterials

    Dim ds As New DataSet
    Dim MysqlConn As MySqlConnection
    Dim query As String
    Dim reader As MySqlDataReader


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
    Dim returnEquipYN As DialogResult
    Dim penaltiesDeleteYN As DialogResult
    Dim addst As DialogResult

    Private Sub InstructionalMaterials_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        load_all_movielist()
        load_all_movielist_in_main()
        load_all_subtopics()
        load_all_subtopics_in_main()
        hide_buttons_on_load()
        hide_buttons_subtopics()
        imm_nv_dtp_acquisitiondate.Value = Date.Now
        nst_gb_st.Hide()
    End Sub

    Public Sub hide_buttons_on_load()
        imm_nv_btn_update.Hide()
        imm_nv_btn_delete.Hide()
    End Sub

    Private Sub InstructionalMaterials_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        Main.Show()
    End Sub

    'MENU BAR
    Private Sub MenuBar_MouseLeave(sender As Object, e As EventArgs) Handles menuItem_DBManage.MouseLeave, menuItem_About.MouseLeave, menuItem_Settings.MouseLeave
         If ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark" Then
             Dim item As RadMenuItem = TryCast(sender, RadMenuItem)
	         item.FillPrimitive.BackColor = Color.Transparent
         End IF
    End Sub

    Private Sub MenuBar_MouseEnter(sender As Object, e As EventArgs) Handles menuItem_DBManage.MouseEnter, menuItem_About.MouseEnter, menuItem_Settings.MouseEnter
        If ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark" Then
	        Dim item As RadMenuItem = TryCast(sender, RadMenuItem)
	        item.FillPrimitive.BackColor = Color.FromArgb(62, 62, 64)
	    item.FillPrimitive.GradientStyle = Telerik.WinControls.GradientStyles.Solid
        End IF
    End Sub
    Private Sub menuItem_LoadDB_Click(sender As Object, e As EventArgs) Handles menuItem_LoadDB.Click
        DBPasswordPrompt.Show()
    End Sub

    Private Sub menuItem_SaveDB_Click(sender As Object, e As EventArgs) Handles menuItem_SaveDB.Click
        Actions.SaveDB()
    End Sub

    Private Sub menuItem_Settings_Click(sender As Object, e As EventArgs) Handles menuItem_Settings.Click
        MainSettingsWindow.ShowDialog()
    End Sub

    Private Sub menuItem_About_Click(sender As Object, e As EventArgs) Handles menuItem_About.Click
        MsgBox("ABOUT WINDOW HERE")
    End Sub


    'STARTING HERE IS THE DEVELOPMENT OF Instructional Materals Management 

    'Loading all movielist in Main Page

    'MovieList Umali C1 

    Public Sub load_all_movielist_in_main()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource
        Dim imdbdataset As New DataTable

        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()
        End If

        Try
            MysqlConn.Open()
            query = "SELECT vid_id as 'Video ID', subject as 'Subject' , topic as 'Topic' , video_media_type as 'Media Type', duration as 'Duration',DATE_FORMAT(acquisition,'%M %d %Y') as 'Acquisition Date' FROM movielist ORDER BY subject ASC,vid_id ASC"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(imdbdataset)
            bsource.DataSource = imdbdataset
            immain_rgv_movielist.DataSource = bsource
            immain_rgv_movielist.ReadOnly = True
            sda.Update(imdbdataset)

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

            Dim vidid = Me.immain_rgv_movielist.Columns("Video ID")
            vidid.TextAlignment = ContentAlignment.MiddleCenter
            vidid.Width = 50

            Dim duration = Me.immain_rgv_movielist.Columns("Duration")
            duration.TextAlignment = ContentAlignment.MiddleCenter
            duration.Width = 70

            Dim subject = Me.immain_rgv_movielist.Columns("Subject")
            subject.TextAlignment = ContentAlignment.MiddleCenter
            subject.Width = 100

            Dim mediatype = Me.immain_rgv_movielist.Columns("Media Type")
            mediatype.TextAlignment = ContentAlignment.MiddleCenter
            mediatype.Width = 50

            Dim topic = Me.immain_rgv_movielist.Columns("Topic")
            topic.WrapText = True
            topic.TextAlignment = ContentAlignment.MiddleCenter
            topic.Width = 300

            Dim ac_date = Me.imm_rgv_im_movielists.Columns("Acquisition Date")
            ac_date.TextAlignment = ContentAlignment.MiddleCenter
            ac_date.Width = 60
        End Try

    End Sub

    'Loading all movielist in Instructional Materials Page
    'MovieList Umali C2
    Public Sub load_all_movielist()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource
        Dim imdbdataset As New DataTable

        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()
        End If


        Try
            MysqlConn.Open()
            query = "SELECT vid_id as 'Video ID', subject as 'Subject' , topic as 'Topic' , video_media_type as 'Media Type', duration as 'Duration',DATE_FORMAT(acquisition,'%M %d %Y') as 'Acquisition Date' FROM movielist ORDER BY subject ASC,vid_id ASC"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(imdbdataset)
            bsource.DataSource = imdbdataset
            imm_rgv_im_movielists.DataSource = bsource
            imm_rgv_im_movielists.ReadOnly = True
            sda.Update(imdbdataset)

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

            Dim vidid = Me.imm_rgv_im_movielists.Columns("Video ID")
            vidid.TextAlignment = ContentAlignment.MiddleCenter
            vidid.Width = 50

            Dim duration = Me.imm_rgv_im_movielists.Columns("Duration")
            duration.TextAlignment = ContentAlignment.MiddleCenter
            duration.Width = 70

            Dim subject = Me.imm_rgv_im_movielists.Columns("Subject")
            subject.TextAlignment = ContentAlignment.MiddleCenter
            subject.Width = 100

            Dim mediatype = Me.imm_rgv_im_movielists.Columns("Media Type")
            mediatype.TextAlignment = ContentAlignment.MiddleCenter
            mediatype.Width = 50

            Dim ac_date = Me.imm_rgv_im_movielists.Columns("Acquisition Date")
            ac_date.TextAlignment = ContentAlignment.MiddleCenter
            ac_date.Width = 60

            Dim topic = Me.imm_rgv_im_movielists.Columns("Topic")
            topic.WrapText = True
            topic.TextAlignment = ContentAlignment.MiddleCenter
            topic.Width = 300
        End Try

    End Sub

    'Loading all subtopics
    'MovieList Umali C3
    Public Sub load_all_subtopics()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource
        Dim imdbdataset As New DataTable

        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()
        End If
        Try
            MysqlConn.Open()
            query = "SELECT vid_id as 'Video ID', subject as 'Subject' , topic as 'Topic' , subtopic as 'Sub Topic', duration as 'Duration' FROM movielist_subtopics ORDER BY subject ASC, vid_id ASC"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(imdbdataset)
            bsource.DataSource = imdbdataset
            imm_rgv_im_subtopics.DataSource = bsource
            imm_rgv_im_subtopics.ReadOnly = True
            sda.Update(imdbdataset)

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

            Dim vidid = Me.imm_rgv_im_subtopics.Columns("Video ID")
            vidid.TextAlignment = ContentAlignment.MiddleCenter
            vidid.Width = 50

            Dim duration = Me.imm_rgv_im_subtopics.Columns("Duration")
            duration.TextAlignment = ContentAlignment.MiddleCenter
            duration.Width = 75

            Dim subject = Me.imm_rgv_im_subtopics.Columns("Subject")
            subject.TextAlignment = ContentAlignment.MiddleCenter
            subject.Width = 150

            Dim topic = Me.imm_rgv_im_subtopics.Columns("Topic")
            topic.WrapText = True
            topic.TextAlignment = ContentAlignment.MiddleCenter
            topic.Width = 300

            Dim subtopic = Me.imm_rgv_im_subtopics.Columns("Sub Topic")
            subtopic.WrapText = True
            subtopic.TextAlignment = ContentAlignment.MiddleCenter
            subtopic.Width = 300
        End Try
    End Sub

    'MovieList Umali C4
    Public Sub load_all_subtopics_in_main()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource
        Dim imdbdataset As New DataTable

        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()
        End If
        Try
            MysqlConn.Open()
            query = "SELECT vid_id as 'Video ID', subject as 'Subject' , topic as 'Topic' , subtopic as 'Sub Topic', duration as 'Duration' FROM movielist_subtopics ORDER BY subject ASC, vid_id ASC"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(imdbdataset)
            bsource.DataSource = imdbdataset
            immain_rgv_subtopic.DataSource = bsource
            immain_rgv_subtopic.ReadOnly = True
            sda.Update(imdbdataset)

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

            Dim vidid = Me.imm_rgv_im_subtopics.Columns("Video ID")
            vidid.TextAlignment = ContentAlignment.MiddleCenter
            vidid.Width = 50

            Dim duration = Me.imm_rgv_im_subtopics.Columns("Duration")
            duration.TextAlignment = ContentAlignment.MiddleCenter
            duration.Width = 75

            Dim subject = Me.imm_rgv_im_subtopics.Columns("Subject")
            subject.TextAlignment = ContentAlignment.MiddleCenter
            subject.Width = 150

            Dim topic = Me.imm_rgv_im_subtopics.Columns("Topic")
            topic.WrapText = True
            topic.TextAlignment = ContentAlignment.MiddleCenter
            topic.Width = 300

            Dim subtopic = Me.imm_rgv_im_subtopics.Columns("Sub Topic")
            subtopic.WrapText = True
            subtopic.TextAlignment = ContentAlignment.MiddleCenter
            subtopic.Width = 300
        End Try
    End Sub

    'MovieList Umali C5
    Private Sub imm_nv_btn_save_Click(sender As Object, e As EventArgs) Handles imm_nv_btn_save.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()
        End If

        If (imm_nv_cb_subject.Text = "") Or (imm_nv_cb_mediatype.Text = "") Or (imm_nv_dtp_acquisitiondate.Text = "") Or (imm_nv_dtp_duration.Text = "") Or (imm_nv_tb_topic.Text = "") Or (imm_nv_tb_vidid.Text = "") Then
            RadMessageBox.Show(Me, "Please complete the fields to save the movie!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)

        Else
            Try
                MysqlConn.Open()

                query = "SELECT * FROM movielist where (vid_id=@mvl_vidid) and (subject=@mvl_subject) or (topic=@mvl_topic)"
                comm = New MySqlCommand(query, MysqlConn)
                comm.Parameters.AddWithValue("mvl_vidid", imm_nv_tb_vidid.Text)
                comm.Parameters.AddWithValue("mvl_subject", imm_nv_cb_subject.Text)
                comm.Parameters.AddWithValue("mvl_topic", imm_nv_tb_topic.Text)

                reader = comm.ExecuteReader

                Dim count As Integer

                While reader.Read
                    count += 1
                End While

                If count = 1 Then
                    RadMessageBox.Show(Me, "The Movie Number " & imm_nv_tb_vidid.Text & " with the subject of " & imm_nv_cb_subject.Text & " and topic of " & imm_nv_tb_topic.Text & " is already taken.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)

                Else

                    MysqlConn.Close()
                    MysqlConn.Open()

                    addYN = RadMessageBox.Show(Me, "Are you sure you want to add this movie?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                    If addYN = MsgBoxResult.Yes Then
                        query = "INSERT INTO `movielist` VALUES  (@mvl_vidid , @mvl_subject , @mvl_topic , @mvl_mediatype , @mvl_duration , @mvl_acquisition)"
                        comm = New MySqlCommand(query, MysqlConn)

                        comm.Parameters.AddWithValue("mvl_vidid", imm_nv_tb_vidid.Text)
                        comm.Parameters.AddWithValue("mvl_subject", imm_nv_cb_subject.Text)
                        comm.Parameters.AddWithValue("mvl_topic", imm_nv_tb_topic.Text)
                        comm.Parameters.AddWithValue("mvl_mediatype", imm_nv_cb_mediatype.Text)
                        comm.Parameters.AddWithValue("mvl_duration", Format(CDate(imm_nv_dtp_duration.Value), "HH:mm:ss"))
                        comm.Parameters.AddWithValue("mvl_acquisition", Format(CDate(imm_nv_dtp_acquisitiondate.Value), "yyyy-MM-dd"))

                        reader = comm.ExecuteReader
                        RadMessageBox.Show(Me, "Movie Registered Successfully!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
                        MysqlConn.Close()
                    End If
                End If


            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
                load_all_movielist()
                load_all_movielist_in_main()
            End Try


        End If


    End Sub

    'MovieList Umali C6
    Private Sub imm_nv_btn_update_Click(sender As Object, e As EventArgs) Handles imm_nv_btn_update.Click
        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()
        End If

        updateYN = RadMessageBox.Show(Me, "Are you sure you want to update this movie?", "CEU TLTD Reservation System" < MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (imm_nv_tb_vidid.Text = "") Or (imm_nv_cb_subject.Text = "") Or (imm_nv_tb_topic.Text = "") Or (imm_nv_cb_mediatype.Text = "") Or (imm_nv_dtp_duration.Text = "") Or (imm_nv_dtp_acquisitiondate.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields To update!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "UPDATE movielist SET video_movie_type=@mvl_mediatype , duration=@mvl_duration , acquisition=@mvl_acquisition WHERE (vid_id=@mvl_vidid) AND (mvl_subject=@mvl_subject) AND (topic=@mvl_topic) "

                    comm = New MySqlCommand(query, MysqlConn)

                    comm.Parameters.AddWithValue("mvl_vidid", imm_nv_tb_vidid.Text)
                    comm.Parameters.AddWithValue("mvl_subject", imm_nv_cb_subject.Text)
                    comm.Parameters.AddWithValue("mvl_topic", imm_nv_tb_topic.Text)
                    comm.Parameters.AddWithValue("mvl_mediatype", imm_nv_cb_mediatype.Text)
                    comm.Parameters.AddWithValue("mvl_duration", Format(CDate(imm_nv_dtp_duration.Value), "HH:mm:ss"))
                    comm.Parameters.AddWithValue("mvl_acquisition", Format(CDate(imm_nv_dtp_acquisitiondate.Value), "yyyy-MM-dd"))
                    reader = comm.ExecuteReader


                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()
                    load_all_movielist()
                    load_all_movielist_in_main()
                End Try
            End If
        End If
    End Sub

    'MovieList Umali C7
    Private Sub imm_nv_btn_delete_Click(sender As Object, e As EventArgs) Handles imm_nv_btn_delete.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()

        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want to delete?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If deleteYN = MsgBoxResult.Yes Then
            If (imm_nv_tb_vidid.Text = "") Or (imm_nv_cb_subject.Text = "") Or (imm_nv_tb_topic.Text = "") Or (imm_nv_cb_mediatype.Text = "") Or (imm_nv_dtp_duration.Text = "") Or (imm_nv_dtp_acquisitiondate.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields To delete!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else

                Try
                    MysqlConn.Open()
                    query = "DELETE FROM movielist WHERE (vid_id=@mvl_vidid) AND (subject=@mvl_subject) AND (topic=@mvl_topic)"
                    comm = New MySqlCommand(query, MysqlConn)
                    comm.Parameters.AddWithValue("mvl_vidid", imm_nv_tb_vidid.Text)
                    comm.Parameters.AddWithValue("mvl_subject", imm_nv_cb_subject.Text)
                    comm.Parameters.AddWithValue("mvl_topic", imm_nv_tb_topic.Text)
                    reader = comm.ExecuteReader


                    RadMessageBox.Show(Me, "Successfully Deleted!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
                    MysqlConn.Close()
                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()

                    load_all_movielist()
                    load_all_movielist_in_main()
                End Try
            End If
        End If

        imm_nv_btn_update.Show()
        imm_nv_btn_delete.Show()

        imm_nv_tb_vidid.Enabled = False
        imm_nv_cb_subject.Enabled = False
        imm_nv_tb_topic.Enabled = False


    End Sub

    'MovieList Umali C8
    Private Sub imm_nv_btn_clear_Click(sender As Object, e As EventArgs) Handles imm_nv_btn_clear.Click
        imm_nv_tb_vidid.Text = ""
        imm_nv_cb_subject.Text = ""
        imm_nv_tb_topic.Text = ""
        imm_nv_cb_mediatype.Text = ""
        imm_nv_dtp_duration.Text = "00:00:00"
        imm_nv_dtp_acquisitiondate.Value = Date.Now
        imm_nv_tb_vidid.Enabled = True
        imm_nv_cb_subject.Enabled = True
        imm_nv_tb_topic.Enabled = True

        imm_nv_dtp_acquisitiondate.Value = Date.Now
        imm_nv_btn_update.Hide()
        imm_nv_btn_delete.Hide()

        nst_gb_st.Hide()

    End Sub

    'MovieList Umali C9
    Private Sub imm_rgv_im_movielists_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles imm_rgv_im_movielists.CellDoubleClick

        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo
            row = Me.imm_rgv_im_movielists.Rows(e.RowIndex)

            imm_nv_tb_vidid.Text = row.Cells("Video ID").Value.ToString
            imm_nv_cb_subject.Text = row.Cells("Subject").Value.ToString
            imm_nv_tb_topic.Text = row.Cells("Topic").Value.ToString
            imm_nv_cb_mediatype.Text = row.Cells("Media Type").Value.ToString
            imm_nv_dtp_duration.Text = row.Cells("Duration").Value.ToString
            imm_nv_dtp_acquisitiondate.Value = row.Cells("Acquisition Date").Value.ToString

            imm_nst_tb_subtopic.Text = ""
            imm_nst_tb_vidid.Text = row.Cells("Video ID").Value.ToString
            imm_nst_cb_subject.Text = row.Cells("Subject").Value.ToString
            imm_nst_tb_topic.Text = row.Cells("Topic").Value.ToString

        End If


        imm_nv_btn_update.Show()
        imm_nv_btn_delete.Show()

        imm_nst_btn_delete.Hide()
        imm_nst_btn_update.Hide()
        imm_nst_btn_save.Show()

        imm_nv_tb_vidid.Enabled = False
        imm_nv_cb_subject.Enabled = False
        imm_nv_tb_topic.Enabled = False

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        addst = RadMessageBox.Show(Me, "Do you want to add Sub Topic for this Movie?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If addst = MsgBoxResult.Yes Then

            nst_gb_st.Show()

        End If



    End Sub


    'Starting here is the development of new sub topics codes
    'Subtopics Umali C1
    Private Sub imm_rgv_im_subtopics_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles imm_rgv_im_subtopics.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo
            row = Me.imm_rgv_im_subtopics.Rows(e.RowIndex)

            imm_nst_tb_vidid.Text = row.Cells("Video ID").Value.ToString
            imm_nst_cb_subject.Text = row.Cells("Subject").Value.ToString
            imm_nst_tb_topic.Text = row.Cells("Topic").Value.ToString
            imm_nst_tb_subtopic.Text = row.Cells("Sub Topic").Value.ToString
            imm_nst_dtp_duration.Text = row.Cells("Duration").Value.ToString

        End If
        imm_nst_tb_vidid.Enabled = False
        imm_nst_cb_subject.Enabled = False
        imm_nst_tb_topic.Enabled = False

        imm_nst_btn_save.Show()
        imm_nst_btn_update.Show()
        imm_nst_btn_delete.Show()
    End Sub




    'Subtopics Umali C4
    Public Sub hide_buttons_subtopics()

        imm_nst_btn_update.Hide()
        imm_nst_btn_delete.Hide()
    End Sub

    'Subtopics Umali C5
    Private Sub imm_nst_btn_clear_Click(sender As Object, e As EventArgs) Handles imm_nst_btn_clear.Click
        btn_clear_functions()
    End Sub

    Public Sub btn_clear_functions()
        hide_buttons_subtopics()
        imm_nst_tb_vidid.Text = ""
        imm_nst_cb_subject.Text = ""
        imm_nst_tb_topic.Text = ""
        imm_nst_tb_subtopic.Text = ""
        imm_nst_dtp_duration.Text = ""
        imm_nst_tb_vidid.Enabled = True
        imm_nst_cb_subject.Enabled = True
        imm_nst_tb_topic.Enabled = True
    End Sub

    'Subtopics Umali C6
    Private Sub imm_nst_btn_save_Click(sender As Object, e As EventArgs) Handles imm_nst_btn_save.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        If (imm_nst_tb_vidid.Text = "") Or (imm_nst_cb_subject.Text = "") Or (imm_nst_tb_topic.Text = "") Or (imm_nst_tb_subtopic.Text = "") Then
            RadMessageBox.Show(Me, "Please complete the fields to save the Sub Topics!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)

        Else
            Try
                MysqlConn.Open()

                query = "SELECT * FROM movielist_subtopics WHERE (vid_id=@nst_vid_id) AND (subject=@nst_subject) AND (subtopic=@nst_subtopic) AND (topic=@nst_topic)"
                comm = New MySqlCommand(query, MysqlConn)
                comm.Parameters.AddWithValue("nst_vid_id", imm_nst_tb_vidid.Text)
                comm.Parameters.AddWithValue("nst_subject", imm_nst_cb_subject.Text)
                comm.Parameters.AddWithValue("nst_topic", imm_nst_tb_topic.Text)
                comm.Parameters.AddWithValue("nst_subtopic", imm_nst_tb_subtopic.Text)

                reader = comm.ExecuteReader
                Dim count As Integer

                While reader.Read
                    count += 1
                End While

                If count = 1 Then
                    RadMessageBox.Show(Me, "The Sub Topic " & imm_nst_tb_subtopic.Text & " is already taken.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)

                Else
                    MysqlConn.Close()
                    MysqlConn.Open()

                    addYN = RadMessageBox.Show(Me, "Are you sure you want to add this movie?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                    If addYN = MsgBoxResult.Yes Then
                        query = "INSERT INTO `movielist_subtopics` VALUES (@nst_vid_id , @nst_subject ,@nst_topic , @nst_subtopic ,  @nst_duration)"
                        comm = New MySqlCommand(query, MysqlConn)

                        comm.Parameters.AddWithValue("nst_vid_id", imm_nst_tb_vidid.Text)
                        comm.Parameters.AddWithValue("nst_subject", imm_nst_cb_subject.Text)
                        comm.Parameters.AddWithValue("nst_topic", imm_nst_tb_topic.Text)
                        comm.Parameters.AddWithValue("nst_subtopic", imm_nst_tb_subtopic.Text)
                        comm.Parameters.AddWithValue("nst_duration", Format(CDate(imm_nst_dtp_duration.Value), "HH:mm:ss"))

                        reader = comm.ExecuteReader
                        RadMessageBox.Show(Me, "Sub Topic Successfully!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
                        MysqlConn.Close()
                    End If
                End If
            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
                load_all_subtopics()
                load_all_subtopics_in_main()
            End Try
        End If
    End Sub

    'PENDING UPDATE
    'Private Sub imm_nst_btn_update_Click(sender As Object, e As EventArgs) Handles imm_nst_btn_update.Click
    '    If (MysqlConn.State = ConnectionState.Open) Then
    '        MysqlConn.Close()
    '    End If

    '    updateYN = RadMessageBox.Show(Me, "Are you sure you want to update this Sub Topic?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
    '    If updateYN = MsgBoxResult.Yes Then
    '        If (imm_nst_tb_vidid.Text = "") Or (imm_nst_cb_subject.Text = "") Or (imm_nst_tb_topic.Text = "") Or (imm_nst_tb_subtopic.Text = "") Then
    '            RadMessageBox.Show(Me, "Please complete the fields To update!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
    '        Else
    '            Try
    '                MysqlConn.Open()
    '                query = "UPDATE `movielist_subtopics` SET subtopic=@nst_subtopic , duration=@nst_duration WHERE (vid_id=@nst_vid_id) AND (subject=@nst_subject) AND (topic=@nst_topic)"
    '                comm = New MySqlCommand(query, MysqlConn)

    '                comm.Parameters.AddWithValue("nst_vid_id", imm_nst_tb_vidid.Text)
    '                comm.Parameters.AddWithValue("nst_subject", imm_nst_cb_subject.Text)
    '                comm.Parameters.AddWithValue("nst_topic", imm_nst_tb_topic.Text)
    '                comm.Parameters.AddWithValue("nst_subtopic", imm_nst_tb_subtopic.Text)
    '                comm.Parameters.AddWithValue("nst_duration", Format(CDate(imm_nst_dtp_duration.Value), "HH:mm:ss"))
    '                reader = comm.ExecuteReader


    '            Catch ex As Exception
    '                RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
    '            Finally
    '                MysqlConn.Dispose()
    '                load_all_subtopics()
    '                load_all_subtopics_in_main()
    '            End Try
    '        End If
    '    End If

    'End Sub

    Private Sub imm_nst_btn_delete_Click(sender As Object, e As EventArgs) Handles imm_nst_btn_delete.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()

        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want to delete?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If deleteYN = MsgBoxResult.Yes Then
            If (imm_nst_tb_vidid.Text = "") Or (imm_nst_cb_subject.Text = "") Or (imm_nst_tb_topic.Text = "") Or (imm_nst_tb_subtopic.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields To delete!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "DELETE FROM `movielist_subtopics` WHERE (vid_id=@nst_vid_id) AND (subject=@nst_subject) AND (topic=@nst_topic) AND (subtopic=@nst_subtopic)"
                    comm = New MySqlCommand(query, MysqlConn)
                    comm.Parameters.AddWithValue("nst_vid_id", imm_nst_tb_vidid.Text)
                    comm.Parameters.AddWithValue("nst_subject", imm_nst_cb_subject.Text)
                    comm.Parameters.AddWithValue("nst_topic", imm_nst_tb_topic.Text)
                    comm.Parameters.AddWithValue("nst_subtopic", imm_nst_tb_subtopic.Text)

                    reader = comm.ExecuteReader
                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()
                    load_all_subtopics()
                    load_all_subtopics_in_main()
                    btn_clear_functions()
                End Try
            End If
        End If

    End Sub

    Private Sub imm_filter_topic_TextChanged(sender As Object, e As EventArgs) Handles imm_filter_topic.TextChanged
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim SDA As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource
        Try
            MysqlConn.Open()

            query = "SELECT vid_id as 'Video ID', subject as 'Subject' , topic as 'Topic' , video_media_type as 'Media Type', duration as 'Duration',DATE_FORMAT(acquisition,'%M %d %Y') as 'Acquisition Date' FROM movielist ORDER BY subject ASC,vid_id ASC"

            comm = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = comm
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            imm_rgv_im_movielists.DataSource = bsource
            SDA.Update(dbdataset)

            MysqlConn.Close()

        Catch ex As MySqlException
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(dbdataset)
        DV.RowFilter = String.Format("`Topic` Like'%{0}%' ", imm_filter_topic.Text)
        imm_rgv_im_movielists.DataSource = DV
    End Sub


    'ayaw lumabas nung subtopics pag lumipat ng page
    Private Sub imm_rpv_subtopics_Click(sender As Object, e As EventArgs) Handles imm_rpv_subtopics.Click

        nst_gb_st.Show()

    End Sub









































    'STARTING HERE IS THE INSTRUCTIONAL MATERIALS RESERVATION
    'Private Sub im_btn_save_Click(sender As Object, e As EventArgs)

    '    If (MysqlConn.State = ConnectionState.Open) Then
    '        MysqlConn.Close()

    '    End If


    '    reserveYN = RadMessageBox.Show(Me, "Are you sure you want to reserve?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
    '    If reserveYN = MsgBoxResult.Yes Then



    '        MysqlConn = New MySqlConnection
    '        MysqlConn.ConnectionString = connstring
    '        Dim READER As MySqlDataReader
    '        Dim errorcount As Boolean = False


    '        If (im_cb_title.Text = "") Or (im_cb_subject.Text = "") Or (im_cb_status.Text = "") Or (im_cb_starttime.Text = "") Or (im_cb_endtime.Text) Then
    '            RadMessageBox.Show(Me, "Please complete the fields", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
    '        Else
    '            'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
    '            Dim elapsedTime As TimeSpan = DateTime.Parse(Format(CDate(im_dtp_date.Value), "yyyy-MM-dd") & " " & im_cb_endtime.Text).Subtract(DateTime.Parse(DateTime.Parse(Format(CDate(im_dtp_date.Value), "yyyy-MM-dd") & " " & im_cb_starttime.Text)))
    '            'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
    '            If elapsedTime.CompareTo(TimeSpan.Zero) <= 0 Then
    '                RadMessageBox.Show(Me, "The Starting Time can't be the same or later on the Ending Time.", "Reservation", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
    '            Else

    '                Try
    '                    MysqlConn.Close()
    '                    MysqlConn.Open()

    '                    'PENDING QUERY
    '                    'query=""
    '                    comm = New MySqlCommand(query, MysqlConn)
    '                    READER = comm.ExecuteReader
    '                    Dim count As Integer
    '                    count = 0
    '                    While READER.Read
    '                        count = count + 1
    '                        'PENDING CODE
    '                    End While

    '                    If count > 0 Then
    '                        'PENDING ERROR MESSAGE
    '                        errorcount = True
    '                    Else
    '                        MysqlConn.Close()
    '                        MysqlConn.Open()
    '                        'PENDING QUERY
    '                        'query="INSERT INTO "
    '                        comm = New MySqlCommand(query, MysqlConn)
    '                        READER = comm.ExecuteReader

    '                        MysqlConn.Close()

    '                    End If

    '                Catch ex As Exception
    '                    RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
    '                Finally
    '                    MysqlConn.Dispose()

    '                End Try

    '                If errorcount = False Then
    '                    RadMessageBox.Show(Me, "Movie Film Successfully Reserved!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)

    '                Else
    '                    RadMessageBox.Show(Me, "Movie Film Failed to Reserved!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)

    '                End If
    '            End If
    '        End If
    '    End If



    'End Sub


End Class
