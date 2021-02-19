Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Diagnostics




Partial Class SearchResult
    Inherits System.Web.UI.Page

	Public HeaderImageValue As String
	Public strGUID As String = Guid.NewGuid().ToString()
	Public strError As String
	Public searchRetPage As String
	

Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		
	
		'Sort.Attributes.Add("type", "number")
        
	Dim sortmax As Integer = 0

    If Not Page.IsPostBack Then

			'guidLabel.Text = strGUID
			If Len(Server.HtmlDecode(Request.QueryString("Search"))) > 0 Then

				Dim searchVal As String = Request.QueryString("Search")

				
				
				
				
				
				
				
				
				Try
					Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
					Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
					'Dim sQueryString As String = "SELECT * FROM tblftb ORDER by pageName asc WHERE"
					
					Dim sQueryString As String = "SELECT * FROM tblftb  WHERE pageName LIKE '%" & searchVal & "%' OR content LIKE '%" & searchVal & "%' ORDER by pageName asc"
					Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
					odbcConn.Open()

					Try

						Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
						Dim i As Integer
						While odbcReader.Read()
							
							Dim pgContent As String = Trim(odbcReader("content").ToString)
							
							If pgContent.Length() > 30 Then
								
								pgContent = pgContent.Substring(0,29)
								
							End If
							
							searchRetPage += "<div class='col s3 m4'><div class='card '><div class='card-content '><span class='card-title'>" & Trim(odbcReader("pageName").ToString) & "</span>" &
							"<p>" & pgContent & "</p></div><div class='card-action'><a href='pagesAdd.aspx?ftbNum=" & Convert.ToInt16(odbcReader("ftbNum")) & "'>EDIT PAGE</a></div></div></div>"
							
							'searchRetPage += "{"


							i += 1

							'searchRetPage += """ftbNum"":""" & Convert.ToInt16(odbcReader("ftbNum")) & ""","
							'xmlString += """pageName"":""" & Trim(odbcReader("pageName").ToString) & ""","
							'searchRetPage += """pageName"":""" & Trim(odbcReader("pageName").ToString) & """},"
						End While

						odbcReader.Close()

					Catch ex As Exception
						searchRetPage += ex.ToString
						odbcConn.Close()

					End Try

					odbcConn.Close()

				Catch ex As Exception
						searchRetPage += ex.ToString

				End Try
		
				
				
				
				
				
				
				
			End If

        End If

    End Sub


End Class
