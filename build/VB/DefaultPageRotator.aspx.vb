Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Mail
Imports ComponentArt
Imports ComponentArt.Web
Imports ComponentArt.Web.UI

Public Class DefaultPageRotator 
	Inherits System.Web.UI.Page

  Protected WithEvents Rotator1 As ComponentArt.Web.UI.Rotator
  Protected lblErrorMsg As Label
  Protected lblOut As Label
  Protected lblOut2 As Label
  Protected lblOut3 As Label
  Protected WithEvents txtClickthroughAdd As TextBox
  Protected pnlRotator1 As Panel
  Protected pnlRotator2 As Panel
  Protected pnlRotator3 As Panel
  Protected pnlRotator4 As Panel
  Protected pnlRotator5 As Panel
  Protected pnlRotator6 As Panel
  Protected WithEvents InvisibleButton As Button
  Protected WithEvents InvisibleColumnButton As Button

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
            Try

                Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

                Dim sQueryString As String = "SELECT * FROM tblftb WHERE pageName = 'HomeJobSeekers'"

                Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
                odbcConn.Open()

                Try

                    Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
                    odbcReader.Read()

                    lblOut.Text = odbcReader("content").ToString()

                    odbcReader.Close()
					
                Catch ex As Exception

                    odbcConn.Close()

                End Try

                odbcConn.Close()

            Catch ex As Exception

         End Try

         Try

                Dim sConnString2 As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConn2 As OdbcConnection = New OdbcConnection(sConnString2)

                Dim sQueryString2 As String = "SELECT * FROM tblftb WHERE pageName = 'HomeEmployers'"

                Dim DBCommand2 As New OdbcCommand(sQueryString2, odbcConn2)
                odbcConn2.Open()

                Try

                    Dim odbcReader2 As OdbcDataReader = DBCommand2.ExecuteReader(CommandBehavior.CloseConnection)
                    odbcReader2.Read()

                    lblOut2.Text = odbcReader2("content").ToString()

                    odbcReader2.Close()
					
                Catch ex As Exception

                    'odbcConn2.Close()

                End Try

                odbcConn2.Close()

            Catch ex As Exception

         End Try

         Try

                Dim sConnString3 As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConn3 As OdbcConnection = New OdbcConnection(sConnString3)

                Dim sQueryString3 As String = "SELECT * FROM tblftb WHERE pageName = 'HomeWelcome'"

                Dim DBCommand3 As New OdbcCommand(sQueryString3, odbcConn3)
                odbcConn3.Open()

                Try

                    Dim odbcReader3 As OdbcDataReader = DBCommand3.ExecuteReader(CommandBehavior.CloseConnection)
                    odbcReader3.Read()

                    lblOut3.Text = odbcReader3("content").ToString()

                    odbcReader3.Close()
					
                Catch ex As Exception

                    'odbcConn3.Close()

                End Try

                odbcConn3.Close()

            Catch ex As Exception

         End Try

	End If
      FillRotator() 
  End Sub 

  Private Sub FillRotator()
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String = "SELECT * FROM tblads2 where Status = 'Active' ORDER BY iSort ASC"
	Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
	odbcConn.Open()

    Dim reader As OdbcDataReader
    reader = DBCommand.ExecuteReader()
    
    Rotator1.DataSource = reader
    Rotator1.DataBind()

	odbcConn.Close()
    odbcConn.Dispose()

  End Sub

End Class
