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

Public Class Gallery 
	Inherits System.Web.UI.Page

  'Protected WithEvents Rotator1 As ComponentArt.Web.UI.Rotator
  Protected lblErrorMsg As Label
  Protected lblClickthroughAdd As Label
  Protected lblClickthroughAddTEST As Label
  Protected WithEvents txtClickthroughAdd As TextBox

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
	
            lblDisplayPhotos.Text = ""

            Try
                Dim sConnString2 As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConn2 As OdbcConnection = New OdbcConnection(sConnString2)
                Dim sQueryString2 As String = "SELECT * FROM tblcategoryphotogallery where pgStatus = 'Active' AND pgYear = 'Residential' ORDER BY pgName ASC"
                Dim DBCommand2 As New OdbcCommand(sQueryString2, odbcConn2)
                odbcConn2.Open()

                Try

                    Dim odbcReader2 As OdbcDataReader = DBCommand2.ExecuteReader(CommandBehavior.CloseConnection)

                    While odbcReader2.Read()
                        Dim oItem As New PC_PhotoGallery

                        oItem.pgID = Convert.ToInt16(odbcReader2("pgID"))

                        If odbcReader2("pgName").Equals(DBNull.Value) Then
                            oItem.pgName = ""
                        Else
                            oItem.pgName = Trim(odbcReader2("pgName").ToString)
                        End If

                        lblDisplayPhotos.Text = lblDisplayPhotos.Text & "<p><strong><img src='Graphics/Bullet_02a.png' width='14' height='9'><a href='media-gallery-category-pictures.aspx?pgName=" & oItem.pgName & "'>" & oItem.pgName & "</a></strong></p><br />"

                    End While

                    odbcReader2.Close()

                Catch ex As Exception

                    odbcConn2.Close()

                End Try

                odbcConn2.Close()

            Catch ex As Exception

            End Try
		
	End If

  End Sub 

End Class
