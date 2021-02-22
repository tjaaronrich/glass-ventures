Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Mail

Public Class DefaultRotator 
	Inherits System.Web.UI.Page

  Protected WithEvents Rotator1 As ComponentArt.Web.UI.Rotator

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      FillRotator() 
    End If
  End Sub 

  Private Sub FillRotator()
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String = "SELECT * FROM tblhighlightpwyw WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC"
	Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
	odbcConn.Open()

    Dim reader As OdbcDataReader
    reader = DBCommand.ExecuteReader()
    
    Rotator1.DataSource = reader
    DataBind()
  End Sub

End Class
