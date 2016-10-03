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

    'Auto Generating of Reservation No
    Public identifier_reservationno As String
    Public random As System.Random = New System.Random

    Private Sub InstructionalMaterials_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        load_all_movielist()
        load_all_movielist_in_main()
        load_all_subtopics()
        load_all_subtopics_in_main()
        hide_buttons_on_load()
        hide_buttons_subtopics()
        imm_nv_dtp_acquisitiondate.Value = Date.Now
        nst_gb_st.Hide()
        imr_dtp_date.Value = Date.Now
        'IMR CODES
        auto_generate_imr_reservationno()
        load_grid_imr_reservation_grid()
        load_allsubjectto_cb_subject()
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
    Private Sub MenuBar_MouseLeave(sender As Object, e As EventArgs) Handles menuItem_Settings.MouseLeave, menuItem_DBManage.MouseLeave, menuItem_About.MouseLeave
        If ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark" Then
            Dim item As RadMenuItem = TryCast(sender, RadMenuItem)
            item.FillPrimitive.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub MenuBar_MouseEnter(sender As Object, e As EventArgs) Handles menuItem_Settings.MouseEnter, menuItem_DBManage.MouseEnter, menuItem_About.MouseEnter
        If ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark" Then
            Dim item As RadMenuItem = TryCast(sender, RadMenuItem)
            item.FillPrimitive.BackColor = Color.FromArgb(62, 62, 64)
            item.FillPrimitive.GradientStyle = Telerik.WinControls.GradientStyles.Solid
        End If
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
        About.Show()
    End Sub


    'STARTING HERE IS THE DEVELOPMENT OF Instructional Materals Management 

    'Loading all movielist in Main Page

    'MovieList Umali C1 

    Private Sub immain_rgv_movielist_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles immain_rgv_movielist.ViewCellFormatting
        e.CellElement.TextAlignment = ContentAlignment.MiddleCenter
        e.CellElement.TextWrap = True
        Dim cell As GridCellElement = TryCast(e.CellElement, GridCellElement)
        If cell IsNot Nothing Then
	        cell.Font = New Font(New FontFamily("Segoe UI"), 12.25F)
        End If
    End Sub

    Public Sub imm_main_size()
        If immain_rgv_movielist.Columns.Count <= 0
            'Quiet when there is no columns loaded
        Else
        Dim vidid = Me.immain_rgv_movielist.Columns("Video ID")
        vidid.Width = 70

        Dim duration = Me.immain_rgv_movielist.Columns("Duration")
        duration.Width = 70

        Dim subject = Me.immain_rgv_movielist.Columns("Subject")
        subject.Width = 200

        Dim mediatype = Me.immain_rgv_movielist.Columns("Media Type")
        mediatype.Width = 120

        Dim topic = Me.immain_rgv_movielist.Columns("Topic")
        topic.Width = 600

        Dim ac_date = Me.imm_rgv_im_movielists.Columns("Acquisition Date")
        ac_date.Width = 120
        End If
    End Sub

    Public Sub load_all_movielist_in_main()
        If Not immain_rgv_movielist.Columns.Count = 0 Then
            immain_rgv_movielist.Columns.Clear()
        End If
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
            imm_main_size()
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

    End Sub


    Private Sub imm_btn_refresh_Click(sender As Object, e As EventArgs) Handles imm_btn_refresh.Click
        load_all_movielist_in_main()
        imm_lu_topic.Text = ""
        imm_lu_subject.Text = String.Empty
    End Sub

    Private Sub imm_lu_subject_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles imm_lu_subject.SelectedIndexChanged
        imm_lu_subject_filter_delay.Interval = 500
        imm_lu_subject_filter_delay.Stop()
        imm_lu_subject_filter_delay.Start()
    End Sub

    Private Sub imm_lu_subject_filter_delay_Tick(sender As Object, e As EventArgs) Handles imm_lu_subject_filter_delay.Tick
        imm_lu_subject_filter_delay.Stop()
        If Not immain_rgv_movielist.Columns.Count = 0 Then
            immain_rgv_movielist.Columns.Clear()
        End If
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource
        Dim imdbdataset As New DataTable
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
             imm_main_size()
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(imdbdataset)
        DV.RowFilter = String.Format("`Topic` Like'%{0}%' and `Subject` Like'%{1}%'", imm_lu_topic.Text, imm_lu_subject.Text)
        immain_rgv_movielist.DataSource = DV
    End Sub

    Private Sub imm_lu_topic_TextChanged(sender As Object, e As EventArgs) Handles imm_lu_topic.TextChanged
        imm_lu_topic_filter_delay.Interval = 500
        imm_lu_topic_filter_delay.Stop()
        imm_lu_topic_filter_delay.Start
    End Sub

     Private Sub imm_lu_topic_filter_delay_Tick(sender As Object, e As EventArgs) Handles imm_lu_topic_filter_delay.Tick
        imm_lu_topic_filter_delay.Stop()
        If Not immain_rgv_movielist.Columns.Count = 0 Then
            immain_rgv_movielist.Columns.Clear()
        End If

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource
        Dim imdbdataset As New DataTable
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
            imm_main_size()
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try

        Dim DV As New DataView(imdbdataset)
        DV.RowFilter = String.Format("`Topic` Like'%{0}%' and `Subject` Like'%{1}%'", imm_lu_topic.Text, imm_lu_subject.Text)
        immain_rgv_movielist.DataSource = DV
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

        updateYN = RadMessageBox.Show(Me, "Are you sure you want to update this movie?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (imm_nv_tb_vidid.Text = "") Or (imm_nv_cb_subject.Text = "") Or (imm_nv_tb_topic.Text = "") Or (imm_nv_cb_mediatype.Text = "") Or (imm_nv_dtp_duration.Text = "") Or (imm_nv_dtp_acquisitiondate.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields To update!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    MysqlConn.Open()
                    query = "UPDATE movielist SET video_media_type=@mvl_mediatype , duration=@mvl_duration , acquisition=@mvl_acquisition WHERE (vid_id=@mvl_vidid) AND (subject=@mvl_subject) AND (topic=@mvl_topic) "

                    comm = New MySqlCommand(query, MysqlConn)

                    comm.Parameters.AddWithValue("mvl_vidid", imm_nv_tb_vidid.Text)
                    comm.Parameters.AddWithValue("mvl_subject", imm_nv_cb_subject.Text)
                    comm.Parameters.AddWithValue("mvl_topic", imm_nv_tb_topic.Text)
                    comm.Parameters.AddWithValue("mvl_mediatype", imm_nv_cb_mediatype.Text)
                    comm.Parameters.AddWithValue("mvl_duration", Format(CDate(imm_nv_dtp_duration.Value), "HH:mm:ss"))
                    comm.Parameters.AddWithValue("mvl_acquisition", Format(CDate(imm_nv_dtp_acquisitiondate.Value), "yyyy-MM-dd"))
                    reader = comm.ExecuteReader
                    load_all_movielist()
                    load_all_movielist_in_main()
                    RadMessageBox.Show(Me, "Movie updated successfully.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()

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

        'Added functions for NST
        btn_clear_functions()
        nst_gb_st.Hide()

    End Sub

    'Starting here is the development of new sub topics codes
    'Subtopics Umali C1
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
        imm_nst_btn_save.Hide()

        imm_nv_tb_vidid.Enabled = False
        imm_nv_cb_subject.Enabled = False
        imm_nv_tb_topic.Enabled = False

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        addst = RadMessageBox.Show(Me, "Do you want to add Sub Topic for this Movie?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If addst = MsgBoxResult.Yes Then
            imm.SelectedPage = imm_rpv_subtopics
            imm_nst_tb_subtopic.Text = ""
            imm_nst_dtp_duration.Text = "00:00:00"
            imm_nst_tb_vidid.Enabled = False
            imm_nst_cb_subject.Enabled = False
            imm_nst_tb_topic.Enabled = False
            nst_gb_st.Show()
            imm_nst_btn_save.Show()
        Else
            btn_clear_functions()
            nst_gb_st.Hide()
        End If



    End Sub



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
        'imm_nst_tb_vidid.Enabled = False
        'imm_nst_cb_subject.Enabled = False
        'imm_nst_tb_topic.Enabled = False

        imm_nst_btn_save.Hide()
        imm_nst_btn_update.Show()
        imm_nst_btn_delete.Show()
    End Sub


    Public Sub hide_buttons_subtopics()
        imm_nst_btn_update.Hide()
        imm_nst_btn_delete.Hide()
    End Sub


    Private Sub imm_nst_btn_clear_Click(sender As Object, e As EventArgs) Handles imm_nst_btn_clear.Click
        btn_clear_functions()
        imm_nst_btn_save.Show
    End Sub

    Public Sub btn_clear_functions()
        hide_buttons_subtopics()
        imm_nst_btn_delete.Hide()
        'imm_nst_tb_vidid.Text = ""
        'imm_nst_cb_subject.Text = ""
        'imm_nst_tb_topic.Text = ""
        imm_nst_tb_subtopic.Text = ""
        imm_nst_dtp_duration.Text = "00:00:00"
        imm_nst_tb_vidid.Enabled = False
        imm_nst_cb_subject.Enabled = False
        imm_nst_tb_topic.Enabled = False
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
    Private Sub imm_nst_btn_update_Click(sender As Object, e As EventArgs) Handles imm_nst_btn_update.Click
        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()
        End If

        updateYN = RadMessageBox.Show(Me, "Are you sure you want to update this Sub Topic?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (imm_nst_tb_vidid.Text = "") Or (imm_nst_cb_subject.Text = "") Or (imm_nst_tb_topic.Text = "") Or (imm_nst_tb_subtopic.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields To update!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                Try
                    Dim get_prev_Subtopic_beforeUpdate As String = (imm_rgv_im_subtopics.SelectedRows(0).Cells("Sub Topic").Value)
                    MysqlConn.Open()
                    query = "UPDATE `movielist_subtopics` SET subtopic=@nst_subtopic , duration=@nst_duration WHERE (vid_id=@nst_vid_id) AND (subject=@nst_subject) AND (topic=@nst_topic) AND (subtopic=@prev_subtopic)"
                    comm = New MySqlCommand(query, MysqlConn)

                    comm.Parameters.AddWithValue("nst_vid_id", imm_nst_tb_vidid.Text)
                    comm.Parameters.AddWithValue("nst_subject", imm_nst_cb_subject.Text)
                    comm.Parameters.AddWithValue("nst_topic", imm_nst_tb_topic.Text)
                    comm.Parameters.AddWithValue("nst_subtopic", imm_nst_tb_subtopic.Text)
                    comm.Parameters.AddWithValue("nst_duration", Format(CDate(imm_nst_dtp_duration.Value), "HH:mm:ss"))
                    comm.Parameters.AddWithValue("@prev_subtopic",get_prev_Subtopic_beforeUpdate)
                    reader = comm.ExecuteReader


                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()
                    load_all_subtopics()
                    load_all_subtopics_in_main()
                End Try
            End If
        End If

    End Sub

    Private Sub imm_nst_btn_delete_Click(sender As Object, e As EventArgs) Handles imm_nst_btn_delete.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()

        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want to delete this subtopic?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
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
                    load_all_subtopics()
                    load_all_subtopics_in_main()
                    btn_clear_functions()
                    imm_nst_btn_save.Show()
                Catch ex As Exception
                    RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                Finally
                    MysqlConn.Dispose()
                End Try
            End If
        End If

    End Sub

    Private Sub imm_filter_topic_TextChanged(sender As Object, e As EventArgs) Handles imm_filter_topic.TextChanged
        imm_filter_topic_delay.Interval = 700
        imm_filter_topic_delay.Stop()
        imm_filter_topic_delay.Start()
    End Sub

        Private Sub imm_filter_topic_delay_Tick(sender As Object, e As EventArgs) Handles imm_filter_topic_delay.Tick
        imm_filter_topic_delay.Stop()
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

    'END of Instructional Materials Management









    'STARTING HERE IS THE INSTRUCTIONAL MATERIALS RESERVATION

    Public Sub auto_generate_imr_reservationno()
        identifier_reservationno = Now.ToString("mmddyyy" + "-")
        identifier_reservationno = identifier_reservationno + random.Next(1, 100000000).ToString
        imr_reservationno.Text = identifier_reservationno
    End Sub


    'Loading Reservation Grid
    Public Sub load_grid_imr_reservation_grid()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If


        Dim sda As New MySqlDataAdapter
        Dim dbdataset As New DataTable
        Dim bsource As New BindingSource

        Try
            MysqlConn.Open()
            query = "SELECT movie_reservationno AS 'Reservation Number' , res_vid_id AS 'Video ID' , res_subject AS 'Subject' , res_topic AS 'Topic' , TIME_FORMAT(movie_starttime, '%H:%i') AS 'Start Time', TIME_FORMAT(movie_endtime, '%H:%i') AS 'End Time' ,  DATE_FORMAT(movie_date,'%M %d %Y') AS 'Date',res_status as 'Status' FROM movie_reservation WHERE movie_date='" & Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd") & "'"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(dbdataset)
            bsource.DataSource = dbdataset
            imr_rgv_reservationgrid.DataSource = bsource
            imr_rgv_reservationgrid.ReadOnly = True
            sda.Update(dbdataset)
            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    Private Sub imr_rgv_reservationgrid_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles imr_rgv_reservationgrid.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As Telerik.WinControls.UI.GridViewRowInfo

            row = Me.imr_rgv_reservationgrid.Rows(e.RowIndex)

            imr_reservationno.Text = row.Cells("Reservation Number").Value.ToString
            imr_cb_subject.Text = row.Cells("Subject").Value.ToString
            imr_cb_topic.Text = row.Cells("Topic").Value.ToString
            imr_videoid.Text = row.Cells("Video ID").Value.ToString
            imr_cb_status.Text = row.Cells("Status").Value.ToString
            imr_cb_starttime.Text = row.Cells("Start Time").Value.ToString
            imr_cb_endtime.Text = row.Cells("End Time").Value.ToString
            imr_dtp_date.Text = row.Cells("Date").Value.ToString

            imr_reservationno.Enabled = False
            imr_cb_subject.Enabled = False
            imr_cb_topic.Enabled = False
            imr_videoid.Enabled = False
        End If
    End Sub

    Public Sub load_allsubjectto_cb_subject()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring
        Try
            MysqlConn.Open()
            query = "SELECT DISTINCT(subject) FROM movielist ORDER BY subject ASC"
            comm = New MySqlCommand(query, MysqlConn)
            reader = comm.ExecuteReader

            While reader.Read

                imr_cb_subject.Items.Add(reader.GetString("subject"))
                imm_lu_subject.Items.Add(reader.GetString("subject"))
            End While
            MysqlConn.Close()
        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

        End Try
    End Sub

    'Private Sub imlu_subject_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles imlu_subject.SelectedIndexChanged

    '    imlu_topic.Items.Clear()

    '    If MysqlConn.State = ConnectionState.Open Then
    '        MysqlConn.Close()
    '    End If
    '    MysqlConn.ConnectionString = connstring

    '    Try
    '        MysqlConn.Open()
    '        query = "SELECT topic FROM movielist WHERE subject=@res_subject ORDER BY topic ASC"
    '        comm = New MySqlCommand(query, MysqlConn)
    '        comm.Parameters.AddWithValue("res_subject", imlu_subject.Text)
    '        reader = comm.ExecuteReader
    '        imlu_topic.Items.Clear()

    '        While reader.Read
    '            imlu_topic.Items.Add(reader.GetString("topic"))
    '        End While

    '        MysqlConn.Close()

    '    Catch ex As Exception
    '        RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
    '    Finally
    '        MysqlConn.Dispose()


    '    End Try




    'End Sub

    'Private Sub imlu_topic_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles imlu_topic.SelectedIndexChanged
    '    imlu_subtopics.Items.Clear()
    '    If MysqlConn.State = ConnectionState.Open Then
    '        MysqlConn.Close()
    '    End If
    '    MysqlConn.ConnectionString = connstring

    '    Try
    '        MysqlConn.Open()
    '        query = "SELECT subtopic FROM movielist_subtopics WHERE subject=@res_subject AND topic=@res_subtopic ORDER BY subtopic ASC"
    '        comm = New MySqlCommand(query, MysqlConn)
    '        comm.Parameters.AddWithValue("res_subject", imlu_subject.Text)
    '        comm.Parameters.AddWithValue("res_subtopic", imlu_topic.Text)
    '        reader = comm.ExecuteReader
    '        imlu_subtopics.Items.Clear()

    '        While reader.Read
    '            imlu_subtopics.Items.Add(reader.GetString("subtopic"))

    '        End While

    '        If imlu_subtopics.Items.Count = 0 Then
    '            RadMessageBox.Show(Me, "No sub topics found in this topic!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
    '            imlu_topic.SelectedValue = ""
    '        Else
    '            RadMessageBox.Show(Me, "We found some sub topics for this topic!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
    '        End If

    '        MysqlConn.Close()

    '    Catch ex As Exception
    '        RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
    '    End Try

    '    Try
    '        MysqlConn.Open()
    '        query = "SELECT res_topic FROM movie_reservation WHERE (res_topic=@res_topic) AND (res_subject=@res_subject) AND (movie_date=@date) AND (res_status='Reserved') "
    '        comm = New MySqlCommand(query, MysqlConn)
    '        comm.Parameters.AddWithValue("res_subject", imlu_subject.Text)
    '        comm.Parameters.AddWithValue("date", Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd"))
    '        comm.Parameters.AddWithValue("res_topic", imlu_topic.Text)
    '        reader = comm.ExecuteReader

    '        Dim count As Integer
    '        count = 0

    '        While reader.Read
    '            count = count + 1
    '            imlu_topic.Text = reader.GetString("res_topic")

    '        End While

    '        If count > 0 Then
    '            RadMessageBox.Show(Me, "This movie is currently taken.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
    '        Else
    '            RadMessageBox.Show(Me, "This movie is currently available.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
    '        End If

    '    Catch ex As Exception
    '        RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)

    '    Finally
    '        MysqlConn.Dispose()

    '    End Try
    'End Sub



    Private Sub imr_cb_subject_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles imr_cb_subject.SelectedIndexChanged
        imr_cb_topic.Items.Clear()
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring

        Try
            MysqlConn.Open()
            query = "SELECT topic FROM movielist WHERE subject=@res_subject ORDER BY topic ASC"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("res_subject", imr_cb_subject.Text)
            reader = comm.ExecuteReader
            imr_cb_topic.Items.Clear()

            While reader.Read
                imr_cb_topic.Items.Add(reader.GetString("topic"))
            End While

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub


    Private Sub imr_cb_topic_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs) Handles imr_cb_topic.SelectedIndexChanged

        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If
        MysqlConn.ConnectionString = connstring

        Try
            MysqlConn.Open()
            query = "SELECT vid_id FROM movielist WHERE subject=@res_subject AND topic=@res_topic"
            comm = New MySqlCommand(query, MysqlConn)
            comm.Parameters.AddWithValue("res_subject", imr_cb_subject.Text)
            comm.Parameters.AddWithValue("res_topic", imr_cb_topic.Text)

            reader = comm.ExecuteReader


            While reader.Read
                imr_videoid.Text = reader.GetString("vid_id")
            End While

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub


    'Button Functions here

    Private Sub imr_btn_save_Click(sender As Object, e As EventArgs) Handles imr_btn_save.Click

        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()

        End If


        reserveYN = RadMessageBox.Show(Me, "Are you sure you want to reserve?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If reserveYN = MsgBoxResult.Yes Then



            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring
            Dim READER As MySqlDataReader
            Dim errorcount As Boolean = False


            If (imr_cb_topic.Text = "") Or (imr_cb_subject.Text = "") Or (imr_cb_status.Text = "") Or (imr_cb_starttime.Text = "") Or (imr_cb_endtime.Text = "") Or (imr_dtp_date.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
                Dim elapsedTime As TimeSpan = DateTime.Parse(Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd") & " " & imr_cb_endtime.Text).Subtract(DateTime.Parse(DateTime.Parse(Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd") & " " & imr_cb_starttime.Text)))
                'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
                If elapsedTime.CompareTo(TimeSpan.Zero) <= 0 Then
                    RadMessageBox.Show(Me, "The Starting Time can't be the same or later on the Ending Time.", "Reservation", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                Else

                    Try
                        MysqlConn.Close()
                        MysqlConn.Open()

                        'PENDING QUERY

                        'No Params @ Date,Time
                        query = "SELECT * FROM movie_reservation WHERE res_vid_id=@res_vidid AND res_subject=@res_subject AND res_topic=@res_topic AND (('" & Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd") & " " & Format(CDate(imr_cb_starttime.Text), "HH:mm:01") & "' BETWEEN CONCAT(movie_date,' ',movie_starttime) AND CONCAT(movie_date,' ',movie_endtime)) OR ('" & Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd") & " " & Format(CDate(imr_cb_endtime.Text), "HH:mm:01") & "' BETWEEN CONCAT(movie_date,' ',movie_starttime) AND CONCAT (movie_date,' ',movie_endtime))) "

                        'query = "SELECT * FROM movie_reservation WHERE res_vid_id=@res_vidid AND res_subject=@res_subject AND res_topic=@res_topic AND (('@res_movie_date @res_starttime' BETWEEN CONCAT(movie_date,' ',movie_starttime) AND CONCAT(movie_date,' ',movie_endtime)) OR ('@res_movie_date @res_endtime' BETWEEN CONCAT(movie_date,' ',movie_starttime) AND CONCAT (movie_date,' ',movie_endtime))) "
                        comm = New MySqlCommand(query, MysqlConn)
                        comm.Parameters.AddWithValue("res_vidid", imr_videoid.Text)
                        comm.Parameters.AddWithValue("res_subject", imr_cb_subject.Text)
                        comm.Parameters.AddWithValue("res_topic", imr_cb_topic.Text)
                        'comm.Parameters.AddWithValue("res_movie_date", Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd"))
                        'comm.Parameters.AddWithValue("res_starttime", Format(CDate(imr_cb_starttime.Text), "HH:mm:01"))
                        'comm.Parameters.AddWithValue("res_endtime", Format(CDate(imr_cb_endtime.Text), "HH:mm:01"))




                        READER = comm.ExecuteReader
                        Dim count As Integer
                        count = 0
                        While READER.Read
                            count += 1
                        End While

                        If count > 0 Then
                            RadMessageBox.Show(Me, "The movie " & imr_cb_topic.Text & " is already taken.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                            errorcount = True
                        Else
                            MysqlConn.Close()
                            MysqlConn.Open()
                            'PENDING QUERY
                            query = "INSERT INTO `movie_reservation` VALUES (@res_reservationno , @res_vidid , @res_subject , @res_topic , @res_status , @res_starttime , @res_endtime , @res_movie_date)"
                            comm = New MySqlCommand(query, MysqlConn)
                            comm.Parameters.AddWithValue("res_reservationno", imr_reservationno.Text)
                            comm.Parameters.AddWithValue("res_vidid", imr_videoid.Text)
                            comm.Parameters.AddWithValue("res_subject", imr_cb_subject.Text)
                            comm.Parameters.AddWithValue("res_topic", imr_cb_topic.Text)
                            comm.Parameters.AddWithValue("res_status", imr_cb_status.Text)
                            comm.Parameters.AddWithValue("res_starttime", Format(CDate(imr_cb_starttime.Text), "HH:mm"))
                            comm.Parameters.AddWithValue("res_endtime", Format(CDate(imr_cb_endtime.Text), "HH:mm"))
                            comm.Parameters.AddWithValue("res_movie_date", Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd"))

                            READER = comm.ExecuteReader
                            MysqlConn.Close()
                        End If

                    Catch ex As Exception
                        RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                    Finally
                        MysqlConn.Dispose()
                        load_grid_imr_reservation_grid()


                        If errorcount = False Then
                            RadMessageBox.Show(Me, "Movie Film Successfully Reserved!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
                            auto_generate_imr_reservationno()
                        Else
                            RadMessageBox.Show(Me, "Movie Film Failed to Reserved!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)

                        End If
                    End Try


                End If
            End If
        End If

    End Sub



    Private Sub imr_btn_delete_Click(sender As Object, e As EventArgs) Handles imr_btn_delete.Click
        If MysqlConn.State = ConnectionState.Open Then
            MysqlConn.Close()
        End If

        deleteYN = RadMessageBox.Show(Me, "Are you sure you want to delete?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If deleteYN = MsgBoxResult.Yes Then
            Try
                MysqlConn.Open()
                query = "DELETE FROM movie_reservation WHERE (movie_reservationno=@res_reservationno) AND (res_vid_id=@res_vidid)"
                comm = New MySqlCommand(query, MysqlConn)
                comm.Parameters.AddWithValue("res_reservationno", imr_reservationno.Text)
                comm.Parameters.AddWithValue("res_vidid", imr_videoid.Text)


                reader = comm.ExecuteReader


                RadMessageBox.Show(Me, "Successfully Deleted!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)
                MysqlConn.Close()
            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
                load_grid_imr_reservation_grid()
            End Try
        End If

    End Sub

    Private Sub imr_btn_clear_Click(sender As Object, e As EventArgs) Handles imr_btn_clear.Click
        auto_generate_imr_reservationno()
        imr_videoid.Text = ""
        imr_cb_topic.Text = ""
        imr_cb_status.Text = ""
        imr_cb_starttime.Text = ""
        imr_cb_endtime.Text = ""
        imr_cb_subject.Text = ""
        imr_dtp_date.Value = Date.Now
        imr_reservationno.Enabled = True
        imr_cb_subject.Enabled = True
        imr_cb_topic.Enabled = True
        imr_videoid.Enabled = True


    End Sub

    Private Sub imr_btn_update_Click(sender As Object, e As EventArgs) Handles imr_btn_update.Click
        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()
        End If
        Dim errorcount As Boolean = False

        updateYN = RadMessageBox.Show(Me, "Are you sure you want to UPDATE the status of this reservation?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If updateYN = MsgBoxResult.Yes Then
            If (imr_cb_topic.Text = "") Or (imr_cb_subject.Text = "") Or (imr_cb_status.Text = "") Or (imr_cb_starttime.Text = "") Or (imr_cb_endtime.Text = "") Or (imr_dtp_date.Text = "") Then
                RadMessageBox.Show(Me, "Please complete the fields", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
                Dim elapsedTime As TimeSpan = DateTime.Parse(Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd") & " " & imr_cb_endtime.Text).Subtract(DateTime.Parse(DateTime.Parse(Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd") & " " & imr_cb_starttime.Text)))
                'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
                If elapsedTime.CompareTo(TimeSpan.Zero) <= 0 Then
                    RadMessageBox.Show(Me, "The Starting Time can't be the same or later on the Ending Time.", "Reservation", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                Else
                    Try
                        MysqlConn.Close()
                        MysqlConn.Open()
                        query = "SELECT * FROM movie_reservation WHERE res_vid_id=@res_vidid AND movie_reservationno=@res_reservationno AND res_status=@res_status AND (('" & Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd") & " " & Format(CDate(imr_cb_starttime.Text), "HH:mm:01") & "' BETWEEN CONCAT(movie_date,' ',movie_starttime) AND CONCAT(movie_date,' ',movie_endtime)) OR ('" & Format(CDate(imr_dtp_date.Value), "yyyy-MM-dd") & " " & Format(CDate(imr_cb_endtime.Text), "HH:mm:01") & "' BETWEEN CONCAT(movie_date,' ',movie_starttime) AND CONCAT (movie_date,' ',movie_endtime))) "

                        comm = New MySqlCommand(query, MysqlConn)
                        comm.Parameters.AddWithValue("res_vidid", imr_videoid.Text)
                        comm.Parameters.AddWithValue("res_reservationno", imr_reservationno.Text)
                        comm.Parameters.AddWithValue("res_status", imr_cb_status.Text)

                        reader = comm.ExecuteReader
                        Dim count As Integer
                        count = 0

                        While reader.Read
                            count += 1
                        End While

                        If count > 0 Then
                            RadMessageBox.Show(Me, "The movie " & imr_cb_topic.Text & " is already taken.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                            errorcount = True
                        Else
                            MysqlConn.Close()
                            MysqlConn.Open()
                            query = "UPDATE movie_reservation SET res_status=@res_status , movie_starttime=@m_starttime , movie_endtime=@m_endtime WHERE (movie_reservationno=@m_reservationno) AND (res_vid_id=@res_vidid) AND (res_subject=@res_subject)"
                            comm = New MySqlCommand(query, MysqlConn)

                            comm.Parameters.AddWithValue("res_status", imr_cb_status.Text)
                            comm.Parameters.AddWithValue("m_starttime", Format(CDate(imr_cb_starttime.Text), "HH:mm"))
                            comm.Parameters.AddWithValue("m_endtime", Format(CDate(imr_cb_endtime.Text), "HH:mm"))
                            comm.Parameters.AddWithValue("m_reservationno", imr_reservationno.Text)
                            comm.Parameters.AddWithValue("res_vidid", imr_videoid.Text)
                            comm.Parameters.AddWithValue("res_subject", imr_cb_subject.Text)

                            reader = comm.ExecuteReader
                        End If

                    Catch ex As Exception
                        RadMessageBox.Show(Me, ex.Message, "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)
                    Finally
                        MysqlConn.Dispose()
                        load_grid_imr_reservation_grid()

                        If errorcount = False Then
                            RadMessageBox.Show(Me, "Movie Film Successfully Updated!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info)

                        Else
                            RadMessageBox.Show(Me, "Movie Film Failed to Update!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error)

                        End If

                    End Try
                End If

            End If
        End If

    End Sub

    Private Sub imr_btn_resetreservationno_Click(sender As Object, e As EventArgs) Handles imr_btn_resetreservationno.Click
        auto_generate_imr_reservationno()
    End Sub

    Private Sub imr_dtp_date_ValueChanged(sender As Object, e As EventArgs) Handles imr_dtp_date.ValueChanged
        load_grid_imr_reservation_grid()
    End Sub

    Private Sub imm_SelectedPageChanged(sender As Object, e As EventArgs) Handles imm.SelectedPageChanged
        If imm.SelectedPage Is imm_rpv_movielist Then
            nst_gb_st.Hide()
        End If
    End Sub

End Class
