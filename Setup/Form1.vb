Imports MySql.Data.MySqlClient

Public Class Form1

    Public dbconn As New MySqlConnection    ''Used To open connection With dbase''
    Public dbcomm As MySqlCommand           ''Used to execute our query from sql''
    Public dbread As MySqlDataReader        ''Used to store data that fetching from database''

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn = New MySqlConnection
        dbconn.ConnectionString = "server=localhost; userid=root;password=; database= dump"
        Try
            dbconn.Open()
            MessageBox.Show("Connection Successfully")
            dbconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            dbconn.Dispose()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        createnew.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        open.Show()
    End Sub

End Class
