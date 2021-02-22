Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class FTBox2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Try

                Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

                Dim sQueryString As String = "SELECT * FROM tblftb WHERE pageName = 'JSreemployment'"

                Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
                odbcConn.Open()

                Try

                    Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
                    odbcReader.Read()

					Editor1.Text = odbcReader("content").ToString()

                    odbcReader.Close()

                Catch ex As Exception

                    odbcConn.Close()

                End Try

                odbcConn.Close()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()

        Dim sqlString = "UPDATE tblftb SET content = '" & Replace(Editor1.Text, "'", "''") & "' WHERE pageName = 'JSreemployment'"

        Dim DBCommand As New OdbcCommand(sqlString, odbcConn)
        DBCommand.ExecuteNonQuery()

        odbcConn.Close()
        odbcConn.Dispose()
    End Sub

End Class
