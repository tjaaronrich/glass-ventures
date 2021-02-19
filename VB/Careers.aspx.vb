Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Gallery
    Inherits System.Web.UI.Page
	
	Public Gallery As String
	

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
			If Not Len(Server.HtmlDecode(Request.QueryString("nNum"))) > 0 Then

			
				'blogTitle.innerHtml = "Previous Client Job Gallery"
				Try
					Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
					Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
					Dim sQueryString As String = "SELECT * FROM tblgallery WHERE Status = 'Active' AND pgName = 'Career-Slider' ORDER BY photoID DESC"
					Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
					odbcConn.Open()
		
					Try
		
						Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
						
						While odbcReader.Read()
							
							'lblOut.Text += "<div class='col-md-4 col-sm-6 item' ><div class='thumbnail' style='box-shadow:0 10px 16px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19) !important;'><div class='caption'>" & 
								'"<h3 style='font-size:20px;'>" & Trim(odbcReader("Name").ToString) & "</h3>" &
								'"<a href='/Documents/Gallery/BigGallery/" & Trim(odbcReader("ImageFile").ToString) & "' 'target='_blank' rel='lightbox[Gallery]' title='" & Trim(odbcReader("Name").ToString) & "'><img class='img-responsive' src='/Documents/Gallery/BigGallery/" & Trim(odbcReader("ImageFile").ToString) & "' /></a>" &
							'"</div></div></div>" 
							
							
							
							
							
							Gallery += "" & 
							"<div>" &
								"<a href='#' class='portfolio-box'>" & 
									"<img src='/Graphics/fill.png' style='background-position:center;background-image: url(""/Documents/Gallery/BigGallery/" & Trim(odbcReader("ImageFile").ToString) & """);background-size: cover;' class='img-fluid img-gallery' alt=''>" &
								"</a>" &
    						"</div>"
							
							
							
							
							
							
							
						End While
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
