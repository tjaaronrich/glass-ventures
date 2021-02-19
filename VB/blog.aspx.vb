Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Blog
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
			If Len(Server.HtmlDecode(Request.QueryString("nNum"))) > 0 Then

				Try
					Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
					Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
					Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' AND nNum = '" & Server.HtmlDecode(Request.QueryString("nNum")) & "'" 
					Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
					odbcConn.Open()
					
					Try
		
						Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
						Dim i As Integer
						While odbcReader.Read()
							'Dim oItem As New PC_Sites
							blogTitle.innerHtml = Trim(odbcReader("Title").ToString)
							'xmlString += "<item "
							lblOut.Text = Trim(odbcReader("content").ToString)
							
							i += 1
							'oItem.pNum = Convert.ToInt16(odbcReader("pNum"))
							'xmlString += "id='" & Convert.ToInt16(odbcReader("nNum")) & "' "
							'xmlString += "title='" & SecurityElement.Escape(Trim(odbcReader("Title").ToString)) & "' "
							'xmlString += "summary='" & SecurityElement.Escape(Trim(odbcReader("Summary").ToString)) & "' "
							'xmlString += "author='" & SecurityElement.Escape(Trim(odbcReader("Author").ToString)) & "' "
							'xmlString += "date='" & SecurityElement.Escape(Trim(odbcReader("ItemDate").ToString)) & "' "
							'xmlString += "pageName='" & SecurityElement.Escape(Trim(odbcReader("pageName").ToString)) & "' "
							'xmlString += "content='" & SecurityElement.Escape(Trim(odbcReader("content").ToString)) & "' "
							'xmlString += "featured='" & SecurityElement.Escape(Trim(odbcReader("Featured").ToString)) & "' "
							'xmlString += "visibleDate='" & SecurityElement.Escape(Trim(odbcReader("VisibleDate").ToString)) & "' "
							'xmlString += "expiresDate='" & SecurityElement.Escape(Trim(odbcReader("ExpiresDate").ToString)) & "' "
							'xmlString += "keywords='" & SecurityElement.Escape(Trim(odbcReader("Keywords").ToString)) & "' "
							'xmlString += "status='" & Trim(odbcReader("Status").ToString) & "' />"
							'xmlString += "</item>"
						End While
		
						odbcReader.Close()
		
					Catch ex As Exception
		
						odbcConn.Close()
		
					End Try
		
					odbcConn.Close()
		
				Catch ex As Exception
		
				End Try

			
			Else
				blogTitle.innerHtml = "Latest Blogs and Posts"
				Try
					Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
					Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
					Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC"
					Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
					odbcConn.Open()
		
					Try
		
						Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
						lblOut.Text = "<div class='container main-container'><div class='row masonry-container'>"
						While odbcReader.Read()
							
							lblOut.Text += "<div class='col-md-4 col-sm-6 item' ><div class='thumbnail' style='box-shadow:0 10px 16px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19) !important;'><div class='caption'>" & 
								"<h3>" & Trim(odbcReader("Title").ToString) & "</h3>" &
								"<p>" & Trim(odbcReader("Summary").ToString) & " " &
									"<a href='blog.aspx?nNum="& Trim(odbcReader("nNum").ToString) & "'>Read more</a>" & 
								"</p>" &
							"</div></div></div>" 
		
							'oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
							'If odbcReader("Title").Equals(DBNull.Value) Then
							'	oItem.Title = ""
							'Else
							'	oItem.Title = Trim(odbcReader("Title").ToString)
							'End If
							'If odbcReader("Summary").Equals(DBNull.Value) Then
							'	oItem.Summary = ""
							'Else
							'	oItem.Summary = Trim(odbcReader("Summary").ToString)
							'End If
							'If odbcReader("Summary").Equals(DBNull.Value) Then
							'    oItem.Summary = ""
							'Else
							'    oItem.Summary = Trim(odbcReader("Summary").ToString)
							'	If Len(oItem.Summary) > 85 then 
							'	oItem.Summary = Left(oItem.Summary, 85) & "..."
							'	End If
							'End If
							'If odbcReader("Author").Equals(DBNull.Value) Then
							'	oItem.Author = ""
							'Else
							'	oItem.Author = Trim(odbcReader("Author").ToString)
							'End If
							'If odbcReader("ItemDate").Equals(DBNull.Value) Then
							'	oItem.ItemDate = ""
							'Else
							'	oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
							'End If
							'If odbcReader("content").Equals(DBNull.Value) Then
							'	oItem.content = ""
							'Else
							'	oItem.content = Trim(odbcReader("content").ToString)
							'End If
							'If odbcReader("Featured").Equals(DBNull.Value) Then
							'	oItem.Featured = ""
							'Else
							'	oItem.Featured = Trim(odbcReader("Featured").ToString)
							'End If
							'If odbcReader("ImageFile").Equals(DBNull.Value) Then
							'	oItem.ImageFile = ""
							'Else
							'	oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
							'End If
							'If odbcReader("Status").Equals(DBNull.Value) Then
							'	oItem.Status = ""
							'Else
							'	oItem.Status = Trim(odbcReader("Status").ToString)
							'End If
		
							'Date Format for Output DISPLAY ONLY
							'oItem.ItemDate = FormatDateString(oItem.ItemDate)
		
							'need function JUST for time?
		
							'oList.Add(oItem)
						End While
						lblOut.Text += "</div></div>"
						odbcReader.Close()
		
					Catch ex As Exception
		
						odbcConn.Close()
		
					End Try
		
					odbcConn.Close()
		
				Catch ex As Exception
		
				End Try
			
			
			End If

        End If

    End Sub

End Class
