Imports MySql.Data.MySqlClient
Public Class createnew

    Public dbconn As New MySqlConnection    ''Used To open connection With dbase''
    Public dbcomm As MySqlCommand           ''Used to execute our query from sql''
    Public dbread As MySqlDataReader        ''Used to store data that fetching from database''


    Private Sub createnew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        company_create.Enabled = False
        Dim create As Date = Now()
        company_create.Text = Format(create, "dd MMMM yyyy")
        DateTimePicker1.Visible = False


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        Dim redirect As Integer
        Dim company As String
        Dim periode As String
        dbconn = New MySqlConnection
        dbconn.ConnectionString = "server=localhost; userid=root;database=siak_db"
        Try
            dbconn.Open()

            periode = DateTimePicker1.Value.ToString("yyyy-mm-dd")
            sql = "INSERT INTO data_perusahaan(ID,PASSWORD,NAMA_PERUSAHAAN,ALAMAT_PERUSAHAAN,KODE_POS,NO_KONTAK,EMAIL,WEBSITE,PERIODE_AKUNTANSI) VALUES 
            (NULL, '" & company_password.Text & "','" & company_name.Text & "','" & company_address.Text & "','" & company_pos.Text & "','" & company_phone.Text & "','" & company_email.Text & "','" & company_website.Text & "','" & DateTimePicker1.Text & "')"
            dbcomm = New MySqlCommand(sql, dbconn)
            dbread = dbcomm.ExecuteReader
            redirect = MsgBox("Sucessfully save", MsgBoxStyle.Information, "Success")
            company = company_name.Text
            main.Label1.Text = "Selamat datang " + company

            If redirect = 1 Then
                Me.Hide()
                main.Show()
            End If
            dbconn.Close()
            Try
                dbconn.Open()
                sql = "SELECT * FROM data_perusahaan WHERE NAMA_PERUSAHAAN= '" & company & "'"
                dbcomm = New MySqlCommand(sql, dbconn)
                dbread = dbcomm.ExecuteReader
                While dbread.Read
                    main.Label2.Text = (dbread("id"))
                End While

                dbread.Close()
            Catch ex As Exception
                MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
                dbread.Close()
                Exit Sub
            End Try
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            dbconn.Dispose()
        End Try

        company_name.Text = ""
        company_phone.Text = ""
        company_address.Text = ""
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker1.Value = DateTimePicker2.Value
    End Sub
End Class