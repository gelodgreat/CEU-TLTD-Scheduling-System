Imports MySql.Data.MySqlClient
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Public Class InstructionalMaterials

    Dim ds As New DataSet
    Dim MysqlConn As MySqlConnection
    Dim query As String

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

    Public dbdataset As New DataTable

    Private Sub InstructionalMaterials_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        Main.Show()
    End Sub

    Private Sub InstructionalMaterials_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'STARTING HERE IS THE INSTRUCTIONAL MATERIALS CODE
    Private Sub im_btn_save_Click(sender As Object, e As EventArgs)

        If (MysqlConn.State = ConnectionState.Open) Then
            MysqlConn.Close()

        End If


        reserveYN = RadMessageBox.Show(Me, "Are you sure you want to reserve?", "TLTD Scheduling Management", MessageBoxButtons.YesNo, RadMessageIcon.Question)
        If reserveYN = MsgBoxResult.Yes Then



            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = connstring
            Dim READER As MySqlDataReader
            Dim errorcount As Boolean = False


            If (im_cb_title.Text = "") Or (im_cb_subject.Text = "") Or (im_cb_status.Text = "") Or (im_cb_starttime.Text = "") Or (im_cb_endtime.Text) Then
                RadMessageBox.Show(Me, "Please complete the fields", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
            Else
                'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
                Dim elapsedTime As TimeSpan = DateTime.Parse(Format(CDate(im_dtp_date.Value), "yyyy-MM-dd") & " " & im_cb_endtime.Text).Subtract(DateTime.Parse(DateTime.Parse(Format(CDate(im_dtp_date.Value), "yyyy-MM-dd") & " " & im_cb_starttime.Text)))
                'ADD THE CHECKBOX TO PICK IF IT IS FROM ANOTHER DAY, ANOTHER DATE PICKER, BUT BY DEFAULT IT IS NOT CHECKED
                If elapsedTime.CompareTo(TimeSpan.Zero) <= 0 Then
                    RadMessageBox.Show(Me, "The Starting Time can't be the same or later on the Ending Time.", "Reservation", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1)
                Else

                    Try
                        MysqlConn.Close()
                        MysqlConn.Open()

                        'PENDING QUERY
                        'query=""
                        comm = New MySqlCommand(query, MysqlConn)
                        READER = comm.ExecuteReader
                        Dim count As Integer
                        count = 0
                        While READER.Read
                            count = count + 1
                            'PENDING CODE
                        End While

                        If count > 0 Then
                            'PENDING ERROR MESSAGE
                            errorcount = True
                        Else
                            MysqlConn.Close()
                            MysqlConn.Open()
                            'PENDING QUERY
                            'query="INSERT INTO "
                            comm = New MySqlCommand(query, MysqlConn)
                            READER = comm.ExecuteReader

                            MysqlConn.Close()

                        End If

                    Catch ex As Exception
                        RadMessageBox.Show(Me, ex.Message, "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)
                    Finally
                        MysqlConn.Dispose()

                    End Try

                    If errorcount = False Then
                        RadMessageBox.Show(Me, "Movie Film Successfully Reserved!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Info)

                    Else
                        RadMessageBox.Show(Me, "Movie Film Failed to Reserved!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error)

                    End If
                End If
            End If
        End If



    End Sub
End Class
