Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class FTBox2
    Inherits System.Web.UI.Page

    'THIS SAMPLE IS FOR USE WITH A MySQL DATABASE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Try

                Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

                'pageName value should be coded to match the name of the page where the content is to be loaded
                Dim sQueryString As String = "SELECT * FROM tblftb WHERE pageName = 'Crime-Mapping'"

                Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
                odbcConn.Open()

                Try

                    Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
                    odbcReader.Read()

                    lblOut.Text = odbcReader("content").ToString()
                    'FreeTextBox1.Text = odbcReader("content").ToString()
                   'txtPageName.Text = odbcReader("pageName").ToString()

                    odbcReader.Close()

                Catch ex As Exception

                    odbcConn.Close()

                End Try

                odbcConn.Close()

            Catch ex As Exception

            End Try

        End If

    End Sub

    'Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        'Output.Text = HttpUtility.HtmlEncode(FreeTextBox1.Text)
        'lblOut.Text = FreeTextBox1.Text


        'Dim sConnString As String = ConfigurationManager.ConnectionStrings("DMS").ConnectionString
        'Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        'odbcConn.Open()

        'Dim sqlString = "UPDATE tblwebcontent SET pageName = '" & txtPageName.Text & "', content = '" & FreeTextBox1.Text & "'"

        'Dim DBCommand As New OdbcCommand(sqlString, odbcConn)
        'DBCommand.ExecuteNonQuery()

        'odbcConn.Close()
        'odbcConn.Dispose()
    'End Sub

    'Protected Sub AddButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddButton.Click
        'Output.Text = HttpUtility.HtmlEncode(FreeTextBox1.Text)
        'lblOut.Text = FreeTextBox1.Text

        'Dim sConnString As String = ConfigurationManager.ConnectionStrings("DMS").ConnectionString
        'Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        'odbcConn.Open()

        'Dim sqlString = "INSERT INTO tblwebcontent (pageName, content) VALUES ('" & txtPageName.Text & "', '" & FreeTextBox1.Text & "')"

       ' Dim DBCommand As New OdbcCommand(sqlString, odbcConn)
        'DBCommand.ExecuteNonQuery()

        'odbcConn.Close()
        'odbcConn.Dispose()
    'End Sub

End Class
