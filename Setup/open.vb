Imports MySql.Data.MySqlClient
Public Class open
    Public dbconn As New MySqlConnection    ''Used To open connection With dbase''
    Public dbcomm As MySqlCommand           ''Used to execute our query from sql''
    Public dbread As MySqlDataReader        ''Used to store data that fetching from database''


    Public getserver As String
    Public getusername As String
    Public getpassword As String
    Public getdatabase As String
    Private Sub open_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        dbconn = New MySqlConnection
        dbconn.ConnectionString = "server=localhost; userid=root;database=siak_db"

        Label1.Text = getserver

        Try
            dbconn.Open()
            sql = "SELECT * FROM data_perusahaan"
            dbcomm = New MySqlCommand(sql, dbconn)
            dbread = dbcomm.ExecuteReader
            MsgBox("Data loaded", MsgBoxStyle.Information)
            While dbread.Read
                ComboBox1.Items.Add(dbread("NAMA_PERUSAHAAN"))
            End While

            dbread.Close()
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
            dbread.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        Dim getcombo As String
        dbconn = New MySqlConnection
        dbconn.ConnectionString = "server=localhost; userid=root;database=siak_db"

        getcombo = ComboBox1.SelectedItem
        main.Label1.Text = "Selamat datang " + getcombo

        Try
            dbconn.Open()
            sql = "SELECT * FROM data_perusahaan WHERE NAMA_PERUSAHAAN= '" & getcombo & "'"
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


        Me.Hide()
        main.Show()
    End Sub
End Class