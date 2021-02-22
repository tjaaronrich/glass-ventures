Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class FTBox2
    Inherits System.Web.UI.Page

	Public Testimonials As String
	Public Calendar As String
	Public Announcements As String
	Public Programs As String
	Public Slider1 As String
	Public Slider2 As String
	Public SliderBtnLink As String
	Public Blog As String
	Public FAQS As String
	Public FirstNewsItem
	Public NewsItems As String
	
	
	
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
			Try
				Dim i As Integer = 1
				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC LIMIT 3"
				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
				odbcConn.Open()
	
				Try
	
					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					
					While odbcReader.Read()

						'lblOut.Text += "<div class='col-md-12'>"
						Dim myDateString as String = Trim(odbcReader("ItemDate").ToString)
						Dim myDate as DateTime
						DateTime.TryParse(myDateString, myDate).ToString()
										Dim BlogLink As String = ""
				If Not Trim(odbcReader("pageName").ToString) = "" Then 
					BlogLink = "<a href='/" & Trim(odbcReader("pageName").ToString) & "'>"
				Else
					BlogLink = "<a href='/news-details?nNum=" & Trim(odbcReader("nNum").ToString) & "'>"
				End If
						Dim blogImage As String = ""
						If Not Trim(odbcReader("ImageFile").ToString) = "" Then
							blogImage = "<img class='img-fluid blog-picture' src='/Documents/News/" & Trim(odbcReader("ImageFile").ToString) & "' />" 
						End If
							
						Blog += "<div class='col-md-4 pad-col-sm blog-pad' >" & 
						BlogLink & "<div class='row blog-row'><div class='col-md-12'><div class='row'><div class='col-md-12'>" & "" &
						"</div></div></div>" & 
						"<div class='col-md-12'>" & 
						"<div class='z-depth-mod blog-card-depth'>" &
						"<div class='card-image'>" &
						blogImage &
						"</div>" &
						"<div class='card-content blog-contents'>" &
						"" &
						"<h4 class='blog-item-header'>" & 
						"" & Trim(odbcReader("Title").ToString) & "" & 
						"</h4>" &
						"<p class='blog-item-paragraph'>" & myDate.ToString("MMMM dd, yyyy") & "</p>" &
						"</div></div>" &
						"</div></div></a></div>" 
						If i = 1 Then
							
							FirstNewsItem = New With {Key _
								.nNum = Trim(odbcReader("nNum").ToString) ,
								.Image = "/Documents/News/" & Trim(odbcReader("ImageFile").ToString) ,
								.Title = Trim(odbcReader("Title").ToString),
								.ItemDate = myDate.ToString("MMMM dd, yyyy")
							}
						Else
							NewsItems+= "<div style=''><a href='/news-detail.aspx?nNum=" & Trim(odbcReader("nNum").ToString) & "' style=''><h2 class='blog-item-h2'>" & Trim(odbcReader("Title").ToString) & "</h2><span class='blog-item-span'>" & myDate.ToString("MMMM dd, yyyy") & "</span><div class='blog-item-div'></div></a></div><hr class='blog-item-hr' />"
						End If
						'Blog += "<div class='col-md-12' style=''>" & "<a href='news.aspx?nNum="& Trim(odbcReader("nNum").ToString) & "' style=''><h5 style='color:#fff;'>" & Trim(odbcReader("Title").ToString) & "</h5>" & 
						'"" &
						'"<p style='text-align:left;color:#eeeeee;'>" & myDate.ToString("MMMM dd, yyyy") & "</p><p>&nbsp</p></a></div>" 
					
						
	
						i += 1
					End While
					'lblOut.Text += "<div class='col s12 m7'><h2 class='header'>Horizontal Card</h2>" &
    					'"<div class='card horizontal'><div class='card-image'><img src='https://lorempixel.com/100/190/nature/6'></div>" &
							'"<div class='card-stacked'>" &
							'"<div class='card-content'>" &
							'"<p>I am a very simple card. I am good at containing small bits of information.</p>" &
							'"</div>" &
							'"<div class='card-action'>" &
							'"<a href='#'>This is a link</a>" &
							'"</div>" &
							'"</div>" &
							'"</div>" & 
					  		'"</div>"
					odbcReader.Close()
	
				Catch ex As Exception
	
					odbcConn.Close()
	
				End Try
	
				odbcConn.Close()
	
			Catch ex As Exception
	
			End Try
			
			
			
			
			
			Try
				Dim i As Integer = 0
				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String = "SELECT * FROM tblcalendardates WHERE Status = 'Active' AND DATE_FORMAT(StartDate, '%Y-%m-%d') >= CURDATE() ORDER BY StartDate ASC LIMIT 12"
				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
				odbcConn.Open()
	
				Try
	
					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					While odbcReader.Read()

						'lblOut.Text += "<div class='col-md-12'>"
						Dim myDateString as String = Trim(odbcReader("StartDate").ToString)
						Dim myDate as DateTime
						DateTime.TryParse(myDateString, myDate).ToString()
						
						Dim AllDay As String = Trim(odbcReader("AllDay").ToString)
						Dim eventTime As String
						
						If AllDay.ToLower() = "true" Then
							eventTime = "All Day"
						Else
							eventTime = Trim(odbcReader("StartTime").ToString).ToLower() & " - " & Trim(odbcReader("EndTime").ToString).ToLower()
						End If
						Calendar += "<div class='col-md-12' style='' >" & 
						"<div class='row calendar-item' style='margin-bottom:0;'>" & 
								"<div class='col-3' style=''>" & 
						"<p class='date blog' style='line-height:1;text-align:center;text-transform:uppercase;'><span class='date-dd'>" & myDate.ToString("dd") & "</span><br />" & myDate.ToString("MMM") & "</p></div>" & 
						"<div class='col-9' style='min-height:70px;'>" & 
						"<h5 class='calendar-h' style='font-family:""Roboto"";text-align: left;margin-bottom: 3%;'>" & 
						"<a href='calendar.aspx' style=''>" & Trim(odbcReader("Title").ToString) & "</a>" & 
												"</h5>" &
						"<p style='font-size:14px;color:#888888;'><i>" & eventTime & "</i></p>" &
						"</div><div class='col-md-12'><hr></div></div></div>" 
						
						i += 1
					End While
					odbcReader.Close()
	
				Catch ex As Exception
	
					odbcConn.Close()
	
				End Try
	
				odbcConn.Close()
	
			Catch ex As Exception
	
			End Try
			
			
			
				Try
				Dim i As Integer = 0
				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String = "SELECT * FROM tblannouncements WHERE Status = 'Active' AND DATE_FORMAT(StartDate, '%Y-%m-%d') >= CURDATE() ORDER BY StartDate ASC LIMIT 3"
				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
				odbcConn.Open()
	
				Try
	
					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					'Dim i As Integer = 0
					While odbcReader.Read()

						'lblOut.Text += "<div class='col-md-12'>"
						Dim myDateString as String = Trim(odbcReader("StartDate").ToString)
						Dim myDate as DateTime
						DateTime.TryParse(myDateString, myDate).ToString()
						
						Dim AllDay As String = Trim(odbcReader("AllDay").ToString)
						Dim eventTime As String
						
						'If AllDay.ToLower() = "true" Then
						'	eventTime = "All Day"
						'Else
							eventTime = myDate.ToString("MMM dd, yyyy") & " | " & Trim(odbcReader("StartTime").ToString).ToLower() 
						'End If
							
						Announcements += "<div class='col-md-4' id='csgc-event-item' >" &	
						"<div class='row'>" &
						"<div class='col-md-12'>" &
					"<a href='events-detail?cNum="& Trim(odbcReader("cNum").ToString) &"'><h3>" & Trim(odbcReader("Title").ToString) & "</h3></a>" &	
						"<p id='event-item-date'>" & myDate.ToString("MMM dd, yyyy") & "</p>" &	
						"<p id='csgc-event-description'>" & Trim(odbcReader("Description").ToString) & "</p>" &
						"<p id='csgc-event-btn-p'><a id='csgc-event-btn' class='btn-large' href='events-detail?cNum="& Trim(odbcReader("cNum").ToString) &"'>VIEW EVENT</a></p>" &
					"</div>" &
						"</div>" &
						"</div>" 
						i += 1
						If i = 3 Then
							i = 0
						End If
						
					End While
					odbcReader.Close()
	
				Catch ex As Exception
	
					odbcConn.Close()
	
				End Try
	
				odbcConn.Close()
	
			Catch ex As Exception
	
			End Try
			
			

			
			
					
			
						
			
			Try
				Dim i As Integer = 0
				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String = "SELECT * FROM tblprograms ORDER BY pSort ASC"
				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
				odbcConn.Open()
	
				Try
	
					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					'Dim i As Integer = 0
					Dim altOrNot As String 
					While odbcReader.Read()

						Dim ImageFile As String
						If Trim(odbcReader("ImageFile").ToString) = ""
							altOrNot = "<span class='altText'>" & Trim(odbcReader("ImageText").ToString) & "</span>"
							ImageFile = ""
						Else
							ImageFile = "<img class='img-fluid' style='margin-left:auto;margin-right:auto;display:block;width:auto;text-transform:none;text-align:center;' src='/Documents/Programs/Thumbs/" & Trim(odbcReader("ImageFile").ToString) & "' />"
						End If
						
						Programs += "" & 
						"<div class='col-md-12 item' style='padding-bottom:20px;'><div class='imgteaser'><a href='" & Trim(odbcReader("link").ToString) & "'><img class='img-responsive product-img' src='/Graphics/fill.png' style='background-position:center;background-size: cover;background-image:url(""/Documents/Programs/Thumbs/" & Trim(odbcReader("backgroundImageFile").ToString) & """);' alt='' style=''><span class='more'><span class='more2'>" & ImageFile & "</span></span><span>" & Trim(odbcReader("ImageText").ToString) & "</span>" & altOrNot & "</a></div></div>" 
						altOrNot = ""
					End While
					odbcReader.Close()
	
				Catch ex As Exception
	
					odbcConn.Close()
	
				End Try
	
				odbcConn.Close()
	
			Catch ex As Exception
	
			End Try
			
			
			
			
			
			Try
				Dim i As Integer = 0
				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String = "SELECT * FROM tblslider ORDER BY pSort ASC"
				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
				odbcConn.Open()
	
				Try
	
					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					'Dim i As Integer = 0
					Dim altOrNot As String 
					While odbcReader.Read()

						
						'If Trim(odbcReader("ImageFile").ToString) = ""
							
						'	altOrNot = "style='bottom:45%;'"
						'End If
						
						Slider1 += "<li><img src='/Documents/Slider/Thumbs/" & Trim(odbcReader("backgroundImageFile").ToString) & "' class='img-fluid main-slides'><div class='caption center-align'><div class='container'><div class='row'><div class='col-md-12'>" & Trim(odbcReader("ImageText").ToString) & "</div></div></div></div></li>" 
						altOrNot = ""
					End While
					odbcReader.Close()
	
				Catch ex As Exception
	
					odbcConn.Close()
	
				End Try
	
				odbcConn.Close()
	
			Catch ex As Exception
	
			End Try
			
			
			
			Try
				Dim i As Integer = 0
				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String = "SELECT * FROM tblannouncements WHERE Category LIKE '%Featured%' limit 5"
				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
				odbcConn.Open()
	
				Try
	
					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					'Dim i As Integer = 0
					Dim altOrNot As String 
					While odbcReader.Read()

						
						'If Trim(odbcReader("ImageFile").ToString) = ""
							
						'	altOrNot = "style='bottom:45%;'"
						'End If
						
						Slider2 += "<li><img src='/Documents/Calendar2Files/" & Trim(odbcReader("fileName").ToString) & "' class='img-fluid' style='background-position:center;'><div class='caption center-align' style='top:70%;'><div class='container'><div class='row'><div class='col-md-12'>" & "<a href='#' class='btn-large' style='margin-left:auto;margin-right:auto;display:table;line-height:2.5;'>More Info</a>" & "</div></div></div></div></li>" 
						SliderBtnLink = "events-detail.aspx?cNum=" & Trim(odbcReader("cNum").ToString)
						altOrNot = ""
					End While
					odbcReader.Close()
	
				Catch ex As Exception
	
					odbcConn.Close()
	
				End Try
	
				odbcConn.Close()
	
			Catch ex As Exception
	
			End Try
			
			
			
			
			
			Try
				Dim i As Integer = 0
				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String = "SELECT * FROM tbltestimonials WHERE Status = 'Active'"
				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
				odbcConn.Open()
	
				Try
	
					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					
					
					While odbcReader.Read()

						'lblOut.Text += "<div class='col-md-12'>"
						'Dim myDateString as String = Trim(odbcReader("ItemDate").ToString)
						'Dim myDate as DateTime
						'DateTime.TryParse(myDateString, myDate).ToString()
						
						Dim ImageFileDir As String  = ""
						
						If Not Trim(odbcReader("ImageFile").ToString) = "" Then
							ImageFileDir = "/Documents/Testimonials/"
						End If
						
						
						
						Testimonials += "" &
						"<div class='card testimonial'>" &
							"<p>&quot;" & Trim(odbcReader("tDescription").ToString) & "&quot;" &
						"<br /><br />" &
						"<img src='/graphics/img-quote.png' style='max-height: 30px; opacity: .4;' /></p>" &
						"</div>"
						
						
						
					
						
	
						i += 1
					End While
					
					
					
					
					odbcReader.Close()
	
				Catch ex As Exception
	
					odbcConn.Close()
	
				End Try
	
				odbcConn.Close()
	
			Catch ex As Exception
	
			End Try
			
			
			
			
			
			
			Try
				Dim i As Integer = 0
				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String = "SELECT * FROM tblfaqs LIMIT 10"
				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
				odbcConn.Open()
	
				Try
	
					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					
					FAQS += "<ul class='collapsible' data-collapsible='accordion'>"
					
					While odbcReader.Read()

						'lblOut.Text += "<div class='col-md-12'>"
						'Dim myDateString as String = Trim(odbcReader("ItemDate").ToString)
						'Dim myDate as DateTime
						'DateTime.TryParse(myDateString, myDate).ToString()
							
						FAQS += "" & 
						"<li><div class='collapsible-header'><i class='material-icons'>arrow_drop_down_circle</i><h5 style='letter-spacing: 0px; font-weight: bold;font-family: ""Open Sans"";'>" & Trim(odbcReader("question").ToString) & "</h5></div><div class='collapsible-body'><span>" & Trim(odbcReader("answer").ToString) & "</span></div></li>" 
						
					
						
	
						i += 1
					End While
					
					FAQS += "</ul>"
					
					
					odbcReader.Close()
	
				Catch ex As Exception
	
					odbcConn.Close()
	
				End Try
	
				odbcConn.Close()
	
			Catch ex As Exception
	
			End Try
			
			
			
			
				

			
			
			
			

        End If

    End Sub


Public Function GetBlog(count As String, format As String, category As String) As String
	Dim retString As String
	Dim categoryQuery As String = ""
	If Not category = "" Then
		categoryQuery = " AND Category = '" & category & "'"
	End If
	Try
		Dim i As Integer = 0
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' " & categoryQuery & " ORDER BY ItemDate DESC, title ASC LIMIT " & count & ""
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()
	
		Try

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While odbcReader.Read()


				Dim myDateString as String = Trim(odbcReader("ItemDate").ToString)

				Dim myDate as DateTime

				DateTime.TryParse(myDateString, myDate).ToString()


				'retString += Trim(odbcReader("ItemDate").ToString)
				retString += "<div class='row z-depth-5' style='background-color: rgba(0,0,0,.3); border-radius: 4px;overflow: hidden;margin-bottom:20px;'>" &
				"<div class='col-md-4 hide-on-med-and-down no-padding-on-large parent-event-image' >" &
							"<div class='events-image' style='height: 100%; background-position: center; background-size: cover;opacity:.85; background-image:url(/Documents/News/" & Trim(odbcReader("ImageFile").ToString) & ")'></div>" &
							"</div>" &
							"<div class='col-md-8' style='padding: 20px 40px 40px'>" & 
							"<a href='/news-details?nNum=" & Trim(odbcReader("nNum").ToString) & "'><h4 style='text-transform: uppercase;color:rgba(255,255,255,.6);'>" & Trim(odbcReader("Title").ToString) & "</h4></a>" &
					"<p style='color:rgba(255,255,255,.6);'>" & myDate.ToString(format) & "</p>" &
				"</div>" &
				"</div>"




				i += 1
			End While
			odbcReader.Close()

		Catch ex As Exception

			odbcConn.Close()
			retString += ex.ToString()
			
		End Try
	
		odbcConn.Close()
	
	Catch ex As Exception
		
		retString += ex.ToString()
		
	End Try
	
	
	Return retString	
	
End Function


End Class
