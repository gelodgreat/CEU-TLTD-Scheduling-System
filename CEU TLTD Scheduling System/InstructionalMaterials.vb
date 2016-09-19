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


    Private Sub InstructionalMaterials_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        Main.Show()
    End Sub

    Private Sub InstructionalMaterials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_all_movielist()
        load_all_subtopics()
        load_all_movielist_in_main()
    End Sub

    'MENU BAR
     Private Sub MenuBar_MouseLeave(sender As Object, e As EventArgs) Handles menuItem_DBManage.MouseLeave, menuItem_About.MouseLeave
        If ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark" Then
        Dim item As RadMenuItem = TryCast(sender, RadMenuItem)
	   item.FillPrimitive.BackColor = Color.Transparent
      End IF
    End Sub

    Private Sub MenuBar_MouseEnter(sender As Object, e As EventArgs) Handles menuItem_DBManage.MouseEnter, menuItem_About.MouseEnter
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
        Dim savedb_dialog As New SaveFileDialog()
        savedb_dialog.Filter = "mySQL Database|*.sql"
        savedb_dialog.Title = "Choose a Location to Save"
        Dim mysql_SAVE As New MySqlBackup(comm)
        mysql_SAVE.ExportInfo.AddCreateDatabase = True
        'mysql_SAVE.ExportInfo.EnableEncryption = True
        'mysql_SAVE.ExportInfo.EncryptionPassword="9Wy3Z3xTApDKUtPVN+TegRLTGR2mj8_M3*3ZJwSts83g9+pL?ZLEn?3xnuMR!2g"
        If savedb_dialog.ShowDialog() = DialogResult.OK Then
            Try
                MySQLConn.Open()
                mysql_SAVE.ExportToFile(savedb_dialog.FileName.ToString)
                MySQLConn.Close()
                RadMessageBox.Show("Database Successfully Exported.", "TLTD Scheduling System", MessageBoxButtons.OK, RadMessageIcon.Info)
            Catch ex As MySqlException
                RadMessageBox.Show("Error in Importing Database:" & Environment.NewLine & ex.Message, "TLTD Scheduling System", MessageBoxButtons.OK, RadMessageIcon.Error)
            End Try
        End If
    End Sub

        Private Sub menuItem_About_Click(sender As Object, e As EventArgs) Handles menuItem_About.Click
        MsgBox("ABOUT WINDOW HERE")
    End Sub


    'STARTING HERE IS THE DEVELOPMENT OF Instructional Materals Management

    'Loading all movielist in Main Page
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
            query = "SELECT vid_id as 'Video ID', subject as 'Subject' , topic as 'Topic' , video_media_type as 'Media Type', duration as 'Duration' FROM movielist ORDER BY subject ASC,vid_id ASC"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(imdbdataset)
            bsource.DataSource = imdbdataset
            immain_rgv_movielist.DataSource = bsource
            immain_rgv_movielist.ReadOnly = True
            sda.Update(imdbdataset)

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

            Dim vidid = Me.immain_rgv_movielist.Columns("Video ID")
            vidid.TextAlignment = ContentAlignment.MiddleCenter
            vidid.Width = 50

            Dim duration = Me.immain_rgv_movielist.Columns("Duration")
            duration.TextAlignment = ContentAlignment.MiddleCenter
            duration.Width = 75

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
        End Try

    End Sub

    'Loading all movielist in Instructional Materials Page
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
            query = "SELECT vid_id as 'Video ID', subject as 'Subject' , topic as 'Topic' , video_media_type as 'Media Type', duration as 'Duration' FROM movielist ORDER BY subject ASC,vid_id ASC"
            comm = New MySqlCommand(query, MysqlConn)
            sda.SelectCommand = comm
            sda.Fill(imdbdataset)
            bsource.DataSource = imdbdataset
            imm_rgv_im_movielists.DataSource = bsource
            imm_rgv_im_movielists.ReadOnly = True
            sda.Update(imdbdataset)

            MysqlConn.Close()

        Catch ex As Exception
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
        Finally
            MysqlConn.Dispose()

            Dim vidid = Me.imm_rgv_im_movielists.Columns("Video ID")
            vidid.TextAlignment = ContentAlignment.MiddleCenter
            vidid.Width = 50

            Dim duration = Me.imm_rgv_im_movielists.Columns("Duration")
            duration.TextAlignment = ContentAlignment.MiddleCenter
            duration.Width = 75

            Dim subject = Me.imm_rgv_im_movielists.Columns("Subject")
            subject.TextAlignment = ContentAlignment.MiddleCenter
            subject.Width = 100

            Dim mediatype = Me.imm_rgv_im_movielists.Columns("Media Type")
            mediatype.TextAlignment = ContentAlignment.MiddleCenter
            mediatype.Width = 50

            Dim topic = Me.imm_rgv_im_movielists.Columns("Topic")
            topic.WrapText = True
            topic.TextAlignment = ContentAlignment.MiddleCenter
            topic.Width = 300
        End Try

    End Sub

    'Loading all subtopics
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
            RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
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


    Private Sub imm_nv_btn_save_Click(sender As Object, e As EventArgs) Handles imm_nv_btn_save.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = connstring

        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()
        End If

        If (imm_nv_cb_subject.Text = "") Or (imm_nv_cb_mediatype.Text = "") Or (imm_nv_dtp_acquisitiondate.Text = "") Or (imm_nv_dtp_duration.Text = "") Or (imm_nv_tb_topic.Text = "") Or (imm_nv_tb_vidid.Text = "") Then
            RadMessageBox.Show(Me, "Please complete the fields to update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)

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
                    RadMessageBox.Show(Me, "The Movie Number " & imm_nv_tb_vidid.Text & " with the subject of " & imm_nv_cb_subject.Text & " and topic of " & imm_nv_tb_topic.Text & " is already taken.", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)

                Else

                    MysqlConn.Close()
                    MysqlConn.Open()

                    addYN = RadMessageBox.Show(Me, "Are you sure you want to add this movie?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
                    If addYN = MsgBoxResult.Yes Then
                        query = "INSERT INTO `movielist` VALUES  (vid_id=@mvl_vidid , subject=@mvl_subject , topic=@mvl_topic , video_media_type=@mvl_mediatype , duration=@mvl_duration)"
                        comm = New MySqlCommand(query, MysqlConn)

                        comm.Parameters.AddWithValue("mvl_id", imm_nv_tb_vidid.Text)
                        comm.Parameters.AddWithValue("mvl_subject", imm_nv_cb_subject.Text)
                        comm.Parameters.AddWithValue("mvl_topic", imm_nv_tb_topic.Text)
                        comm.Parameters.AddWithValue("mvl_mediatype", imm_nv_cb_mediatype.Text)
                        comm.Parameters.AddWithValue("mvl_duration", imm_nv_dtp_duration.Text)

                        reader = comm.ExecuteReader
                        RadMessageBox.Show(Me, "Movie Registered Successfully!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
                        MysqlConn.Close()
                    End If
                End If


            Catch ex As Exception
                RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Finally
                MysqlConn.Dispose()
            End Try


        End If


    End Sub



















    'STARTING HERE IS THE INSTRUCTIONAL MATERIALS RESERVATION
    'Private Sub im_btn_save_Click(sender As Object, e As EventArgs)

    '    If (MysqlConn.State = ConnectionState.Open) Then
    '        MysqlConn.Close()

    '    End If


    '    reserveYN = RadMessageBox.Show(Me, "Are you sure you want to reserve?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
    '    If reserveYN = MsgBoxResult.Yes Then



    '        MysqlConn = New MySqlConnection
    '        MysqlConn.ConnectionString = connstring
    '        Dim READER As MySqlDataReader
    '        Dim errorcount As Boolean = False


    '        If (im_cb_title.Text = "") Or (im_cb_subject.Text = "") Or (im_cb_status.Text = "") Or (im_cb_starttime.Text = "") Or (im_cb_endtime.Text) Then
    '            RadMessageBox.Show(Me, "Please complete the fields", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
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
    '                    RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
    '                Finally
    '                    MysqlConn.Dispose()

    '                End Try

    '                If errorcount = False Then
    '                    RadMessageBox.Show(Me, "Movie Film Successfully Reserved!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)

    '                Else
    '                    RadMessageBox.Show(Me, "Movie Film Failed to Reserved!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)

    '                End If
    '            End If
    '        End If
    '    End If



    'End Sub


End Class
