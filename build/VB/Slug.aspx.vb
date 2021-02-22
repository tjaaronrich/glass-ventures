Imports System
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI.ControlCollection
Imports System.Linq
Imports System.Net
Imports System.Net.Mail
Imports System.IO

Partial Class SlugPage
    Inherits System.Web.UI.Page
	
	
	Public Content As String
	Public Title As String
	Public HeaderImage As String
	Public HeaderImageText As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Not Me.IsPostBack Then
            Me.PopulatePage()
			
		Else
			Dim Item, fieldName, fieldValue
			Dim emailContent As String = ""
			For Each Item In Request.Form
				fieldName = Item
				fieldValue = Request.Form(Item)
				If fieldName.Contains("SendMail") Then
					'Response.Write(fieldName & " " & fieldValue)
					emailContent += "<strong>" & Request.Form("Placeholder-" & fieldName.Replace("SendMail-","")) & ": </strong>" & fieldValue & "<br/ >" 
				End If
			Next
		
			If Not emailContent = "" Then
				Dim mail As New MailMessage()
				mail.From = New MailAddress(Request.Form("FromMail")) 
				mail.To.Add(Request.Form("ToMail"))
				'mail.To.Add("linden@aaronrich.com")
				mail.CC.Add(Request.Form("CCMail"))
				mail.BCC.Add(Request.Form("BCCMail"))

				mail.Subject = Request.Form("SubjectMail")
				mail.IsBodyHtml = True
				Mail.Body = emailContent


				Dim smtp As New SmtpClient("relay-hosting.secureserver.net")


				Try
					smtp.Credentials = New NetworkCredential(Request.Form("FromMail"), "000215")
					smtp.Send(mail)
					Response.Redirect("thanks")
				Catch ehttp As System.Web.HttpException
					Response.Redirect("error")
				End Try
			End If
        End If
		
		
        'If Not Page.IsPostBack Then

            'Try

            '    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            '    Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

            '    Dim sQueryString As String = "SELECT * FROM tblftb WHERE pageName = 'Default'"

            '    Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            '    odbcConn.Open()

            '    Try

            '        Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
            '        odbcReader.Read()

            '        lblOut.Text = odbcReader("content").ToString()

            '        odbcReader.Close()

            '    Catch ex As Exception

            '        odbcConn.Close()

            '    End Try

            '    odbcConn.Close()

            'Catch ex As Exception

            'End Try

        'End If

    End Sub
	
	
	
	
	Private Sub PopulatePage()
		Dim pageName As String
		Dim hasData = True
		Try
			pageName = Me.Page.RouteData.Values("slug").ToString()
		Catch ex As Exception
			Response.Redirect("/default.aspx")
		End Try
		
		If pageName.Contains(".aspx") Then
			Dim checkForAspx As String = pageName.Substring(pageName.Length - 5, 5)
			If checkForAspx.ToLower() = ".aspx" Then
				pageName = pageName.Substring(0, pageName.Length - 5)
			End If
		End If
		If pageName.Contains("owner-") Then
			
			If Not Session("accessLevel") = 1 Then
				Response.Redirect("/accessdenied")
			End If
			
		End If
		
		Dim query As String = "SELECT * FROM tblftb WHERE pageName = '" & pageName & "'"
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		
		
        Dim DBCommand As New OdbcCommand(query, odbcConn)
		
        	
        Try
			odbcConn.Open()
            Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			If odbcReader.Read() Then
				'lblContent.Text = odbcReader("content").ToString()
				Content = CheckForShortCodes(odbcReader("content").ToString())
				Page.Title = Trim(odbcReader("meta_title").ToString())
				HeaderImage = Trim(odbcReader("HeaderImage").ToString())
				HeaderImageText = Trim(odbcReader("HeaderImageText").ToString())







				If Not HeaderImage = "" Then
					HeaderImage = "" &
					"<div class='subpage parallax-container'>" &
						"<div class='parallax'>" &
							"<div class='container'>" &
								"<div class='row align-items-center' style='top: 35%;position: absolute;padding-left: 15px;z-index:1;'>" &
									"<div class='col-md-12'>" &
										"<h2 style='color:#ffffff;margin:0;font-size:50px;'>" & Trim(odbcReader("HeaderImageText").ToString()) & "</h2>" &
									"</div>" &
								"</div>" &
							"</div>" &
							"<img src='/Documents/Banner/" & Trim(odbcReader("HeaderImage").ToString()) & "' style='width:100%;'>" &
						"</div>" &
					"</div>"
				End If



				Dim pHtml As HtmlHead = Page.Header

				For Each metaTag As HtmlMeta In pHtml.Controls.OfType(Of HtmlMeta)()
					If metaTag.Name.Equals("TITLE", StringComparison.CurrentCultureIgnoreCase) Then
					metaTag.Content = Trim(odbcReader("meta_title").ToString())
							'You could keep looping to find other controls with the same name, but I'm exiting the loop
						'Exit For
					End If
					If metaTag.Name.Equals("DESCRIPTION", StringComparison.CurrentCultureIgnoreCase) Then
					metaTag.Content = Trim(odbcReader("description").ToString())
							'You could keep looping to find other controls with the same name, but I'm exiting the loop
						'Exit For
					End If
					If metaTag.Name.Equals("KEYWORDS", StringComparison.CurrentCultureIgnoreCase) Then
					'metaTag.Content = Trim(odbcReader("keywords").ToString())
							'You could keep looping to find other controls with the same name, but I'm exiting the loop
						'Exit For
					End If
				Next










				odbcReader.Close()
			Else
				hasData = False
			End If
        Catch ex As Exception
			'If pageName = "" Then
			Dim errMsg As String = "/404"
			'Response.Redirect(HttpUtility.UrlEncode(errMsg))
	
	Response.Redirect("/thanks?PostIf=" & query)	
	'End If
        	odbcConn.Close()
		End Try







	If hasData = False Then


		Dim queryBlog As String = "SELECT * FROM tblnewsftb WHERE pageName = '" & pageName & "'"
		Dim sConnStringBlog As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConnBlog As OdbcConnection = New OdbcConnection(sConnStringBlog)


		Dim DBCommandBlog As New OdbcCommand(queryBlog, odbcConnBlog)


		Try 
			odbcConnBlog.Open()
			Dim odbcReader As OdbcDataReader = DBCommandBlog.ExecuteReader(CommandBehavior.CloseConnection)


			If odbcReader.Read() Then

				Content = CheckForShortCodes(odbcReader("content").ToString())
				Page.Title = Trim(odbcReader("Title").ToString())
				HeaderImage = Trim(odbcReader("ImageFile").ToString())
				HeaderImageText = Trim(odbcReader("Title").ToString())
				
				Dim FeaturedImage As String = ""
				If Not HeaderImage = ""
				FeaturedImage = "<img src='/Documents/News/" & Trim(odbcReader("ImageFile").ToString()) & "' class='img-fluid' style='margin-left: auto;margin-right: auto;display: block;'/>"
				End If
			
				Content = "" &
					"<div class='col-md-12'><h1 >" & Trim(odbcReader("Title").ToString()) & "</h1><br />" &	
					"<div style='float:left;' class='sharethis-inline-share-buttons'></div>" &		
					"<p>&nbsp;</p>" &
					FeaturedImage &
					"<p>&nbsp;</p>" &
					"<strong style='font-weight:bold;'>Event Start Date: <em>" & Trim(odbcReader("ItemDate").ToString()) & "</em></strong>" &
					"<p style='margin-top:0px;'>" & Trim(odbcReader("ItemDate").ToString()) & "</p>" &
					"<p style='margin-top:5px;''><span style='margin-top:5px; margin-bottom:10px'>" & Content & "</span></p>" &
					"<div style='float:left;' class='sharethis-inline-share-buttons'></div></div>"


				If Not HeaderImage = "" Then
					HeaderImage = "" &
					"<div class='subpage parallax-container'>" &
						"<div class='parallax'>" &
							"<div class='container'>" &
								"<div class='row align-items-center' style='top: 73%;position: absolute;padding-left: 15px;z-index:1;'>" &
									"<div class='col-md-12'>" &
										"<h2 style='color:#ffffff;margin:0;font-size:50px;'>" & "News Details" & "</h2>" &
									"</div>" &
								"</div>" &
							"</div>" &
							"<img src='/Documents/News/" & Trim(odbcReader("ImageFile").ToString()) & "' style='width:100%;'>" &
						"</div>" &
					"</div>"
				End If



				Dim pHtml As HtmlHead = Page.Header

				For Each metaTag As HtmlMeta In pHtml.Controls.OfType(Of HtmlMeta)()
					If metaTag.Name.Equals("TITLE", StringComparison.CurrentCultureIgnoreCase) Then
					metaTag.Content = Trim(odbcReader("Title").ToString())
							'You could keep looping to find other controls with the same name, but I'm exiting the loop
						'Exit For
					End If
					If metaTag.Name.Equals("DESCRIPTION", StringComparison.CurrentCultureIgnoreCase) Then
					metaTag.Content = Trim(odbcReader("Summary").ToString())
							'You could keep looping to find other controls with the same name, but I'm exiting the loop
						'Exit For
					End If
					If metaTag.Name.Equals("KEYWORDS", StringComparison.CurrentCultureIgnoreCase) Then
					'metaTag.Content = Trim(odbcReader("keywords").ToString())
							'You could keep looping to find other controls with the same name, but I'm exiting the loop
						'Exit For
					End If
				Next

				odbcReader.Close()
		
			Else
				Response.Redirect("/404?blogIf=" & queryBlog)
		
			End If






		Catch ex As Exception
			odbcConnBlog.Close()
			'If pageName = "" Then
			
			Response.Redirect("/404?blogTry=")
			'End If
		End Try





	End If





    End Sub
	
Public Function CheckForShortCodes(content As String) As String
	
	
	
	Try
		
		
		
		If content.Contains("[UPLOADS") And content.Contains("[/UPLOADS]") Then
			Dim pFrom As Integer = content.IndexOf("[UPLOADS")
			Dim pTo As Integer = content.LastIndexOf("[/UPLOADS]") + "[/UPLOADS]".Length

			Dim result As String = content.Substring(pFrom, pTo - pFrom)
			'content = content.Replace(result, GetUploads("Policies"))
			
			
			Dim Category As String
			Dim position As Integer = 0
			While position <> -1
				position = content.IndexOf("[UPLOADS")
				If position <> -1 Then
					Dim endPosition As Integer = content.IndexOf("[/UPLOADS]") + "[/UPLOADS]".Length
					
					Category = GetAttribute(content.Substring(position, endPosition - position), "category")
					content = content.Remove(position, endPosition - position)
					content = content.Insert(position, GetUploads(Category))
					position = endPosition
				End If
			End While
			
			'content = Category
			
			
			
			
		End If
		
		
		
		
		
		If content.Contains("[WIDGET") And content.Contains("[/WIDGET]") Then
			Dim pFrom As Integer = content.IndexOf("[WIDGET")
			Dim pTo As Integer = content.LastIndexOf("[/WIDGET]") + "[/WIDGET]".Length

			Dim result As String = content.Substring(pFrom, pTo - pFrom)
			'content = content.Replace(result, GetUploads("Policies"))
			
			
			Dim attribute As String
			Dim position As Integer = 0
			While position <> -1
				position = content.IndexOf("[WIDGET")
				If position <> -1 Then
					Dim endPosition As Integer = content.IndexOf("[/WIDGET]") + "[/WIDGET]".Length
					
					attribute = GetAttributeDQ(content.Substring(position, endPosition - position), "id")
					content = content.Remove(position, endPosition - position)
					content = content.Insert(position, GetWidget(attribute))
					position = endPosition
				End If
			End While
			
			'content = Category
			
			
			
			
		End If
		
		
		If content.Contains("[BLOG") And content.Contains("[/BLOG]") Then
			Dim pFrom As Integer = content.IndexOf("[BLOG")
			Dim pTo As Integer = content.LastIndexOf("[/BLOG]") + "[/BLOG]".Length

			Dim result As String = content.Substring(pFrom, pTo - pFrom)
			'content = content.Replace(result, GetUploads("Policies"))
			
			Dim format As String = ""
			Dim attribute As String
			Dim position As Integer = 0
			While position <> -1
				position = content.IndexOf("[BLOG")
				If position <> -1 Then
					Dim endPosition As Integer = content.IndexOf("[/BLOG]") + "[/BLOG]".Length
					
					If content.IndexOf("formatDate") > 0 Then
						format = GetAttributeDQ(content.Substring(position, endPosition - position), "formatDate")
					End If
					attribute = GetAttributeDQ(content.Substring(position, endPosition - position), "count")
					content = content.Remove(position, endPosition - position)
					content = content.Insert(position, GetBlog(attribute, format))
					position = endPosition
				End If
			End While
			
			'content = Category
			
			
			
			
		End If
		
		
		If content.Contains("[FAQS") And content.Contains("[/FAQS]") Then
			Dim pFrom As Integer = content.IndexOf("[FAQS")
			Dim pTo As Integer = content.LastIndexOf("[/FAQS]") + "[/FAQS]".Length

			Dim result As String = content.Substring(pFrom, pTo - pFrom)
			'content = content.Replace(result, GetUploads("Policies"))
			
			Dim format As String = ""
			Dim attribute As String
			Dim position As Integer = 0
			While position <> -1
				position = content.IndexOf("[FAQS")
				If position <> -1 Then
					Dim endPosition As Integer = content.IndexOf("[/FAQS]") + "[/FAQS]".Length
					
					
					attribute = GetAttributeDQ(content.Substring(position, endPosition - position), "count")
					content = content.Remove(position, endPosition - position)
					content = content.Insert(position, GetFaqs(attribute))
					position = endPosition
				End If
			End While
			
			'content = Category
			
			
			
			
		End If
		
		If content.Contains("[LINKS") And content.Contains("[/LINKS]") Then
			Dim pFrom As Integer = content.IndexOf("[LINKS")
			Dim pTo As Integer = content.LastIndexOf("[/LINKS]") + "[/LINKS]".Length

			Dim result As String = content.Substring(pFrom, pTo - pFrom)
			'content = content.Replace(result, GetUploads("Policies"))
			
			Dim format As String = ""
			Dim attribute As String
			Dim position As Integer = 0
			While position <> -1
				position = content.IndexOf("[LINKS")
				If position <> -1 Then
					Dim endPosition As Integer = content.IndexOf("[/LINKS]") + "[/LINKS]".Length
					
					
					attribute = GetAttributeDQ(content.Substring(position, endPosition - position), "count")
					content = content.Remove(position, endPosition - position)
					content = content.Insert(position, GetLinks(attribute))
					position = endPosition
				End If
			End While
			
			'content = Category
			
			
			
			
		End If
		
		
		
		
		If content.Contains("[CONTACT") And content.Contains("[/CONTACT]") Then
			Dim pFrom As Integer = content.IndexOf("[CONTACT")
			Dim pTo As Integer = content.LastIndexOf("[/CONTACT]") + "[/CONTACT]".Length

			Dim result As String = content.Substring(pFrom, pTo - pFrom)
			Dim fullShortCode As String = content.Substring(pFrom, pTo - pFrom)
			'content = content.Replace(result, GetUploads("Policies"))
			
			Dim format As String = ""
			Dim attribute As String
			Dim position As Integer = 0
			Dim rIndex As Integer = fullShortCode.IndexOf("]")
			Dim rLastIndex As Integer = fullShortCode.IndexOf("[/CONTACT]")
			
			Dim rShortCodeBegin As String = result.Substring(0, rIndex + 1)
			
			Dim innerShortCodeContent As String = fullShortCode.Substring(rIndex + 1, rLastIndex - rIndex -1)
			
			Dim repString As String = ""
			
			
			
			Dim inputContent As String = GetInputValues(innerShortCodeContent)
			Dim cfrom As String = ""
			Dim cto As String = ""
			Dim csubject As String = ""
			Dim ccc As String = ""
			Dim bcc As String = ""
			If rShortCodeBegin.contains("from=") Then
				cfrom = GetAttributeDQ(rShortCodeBegin, "from")
				inputContent += "<input style='display:none;' name='FromMail' value='" & cfrom & "' />"
			End If
			If rShortCodeBegin.contains("to=") Then
				cto = GetAttributeDQ(rShortCodeBegin, "to")
				inputContent += "<input style='display:none;' name='ToMail' value='" & cto & "' />"
			End If
			If rShortCodeBegin.contains("subject=") Then
				csubject = GetAttributeDQ(rShortCodeBegin, "subject")
				inputContent += "<input style='display:none;' name='SubjectMail' value='" & csubject & "' />"
			End If
			If rShortCodeBegin.contains(" cc=") Then
				ccc = GetAttributeDQ(rShortCodeBegin, " cc")
				inputContent += "<input style='display:none;' name='CCMail' value='" & ccc & "' />"
			End If
			If rShortCodeBegin.contains("bcc=") Then
				bcc = GetAttributeDQ(rShortCodeBegin, "bcc")
				inputContent += "<input style='display:none;' name='BCCMail' value='" & bcc & "' />"
			End If
			
			
			result = content.Replace(rShortCodeBegin, "")
			result = result.Replace(innerShortCodeContent, inputContent)
			result = result.Replace("[/CONTACT]", "")
			
			
			'content = innerShortCodeContent
			'content = result & " " & innerShortCodeContent & " " &  rIndex & " " & rLastIndex & " " & inputContent
			
		content = result
			
			
			
			
			
			
			
			
			
		End If
		
		
		
		
		
		
		
		

		
	
	
	
	Catch ex As Exception
		content += ex.ToString()

	End Try
	
	
	Return content
	
	
End Function

Public Function GetInputValues(content As String) As String
	Dim nContent As String = ""
	'Dim array As String() = Regex.Split(content,"[/INPUT]")

    'Dim input As String = "one)(two)(three)(four)(five"
	Dim result As String() = content.Split(New String() {"[/INPUT]"}, StringSplitOptions.None)
	For Each s As String In result
		If s.Contains("id=") Then
			Dim id As String = GetAttributeDQ(s, "id")
			Dim placeholder As String = GetAttributeDQ(s, "placeholder")
			Dim type As String = GetAttributeDQ(s, "type")
			Dim required As String = ""
			If s.Contains("required=") Then
				
				Dim requiredVal As String = GetAttributeDQ(s, "required")
		
				If requiredVal.ToLower() = "true"
					required = "required='true'"
				End If
		
			End If
			If type = "text" Then
				nContent += "<div class='input-field col-md-12'>" &
								"<input id='" & id & "' name='SendMail-" & id & "' type='text' class='validate' style='border-bottom: 1px solid #9e9e9e;box-shadow: none;' " & required & ">" &
								"<label for='" & id & "' style='margin-left: 15px; color:#9e9e9e;'>" & placeholder & "</label>" &
								"<input name='Placeholder-" & id & "' value='" & placeholder & "'  style='display:none;'/>" &
							"</div>"
			Else If type = "textarea" Then
				nContent += "<div class='input-field col-md-12'>" &
								"<textarea id='" & id & "' name='SendMail-" & id & "' class='materialize-textarea' style='border-bottom: 1px solid #9e9e9e;box-shadow: none;'' " & required & "></textarea>" &
								"<label for='" & id & "' style='margin-left: 15px;color:#9e9e9e;'>" & placeholder & "</label>" &
								"<input name='Placeholder-" & id & "' value='" & placeholder & "'  style='display:none;'/>" &
							"</div>"
			Else If type = "submit"
				nContent += "<div class='input-field col-md-12'>" &
					"<input type='submit' name='" & id & "-submit' value='" & placeholder & "' id='" & id & "' class='btn-large z-depth-5'>" &
							"</div>"
			End If
		
			'nContent += s &  "     " & id & "         <br />"
		End If
	Next

	Return nContent
	
End Function



Public Function GetAttributeInput(content As String, attribute As String) As String
	content = content.Replace(Chr(34),"&quot;")
	Dim subContent As String
	attribute = attribute & "=&quot;"
	Dim position As Integer = 0
	Dim endPosition As Integer = 0
	position = content.IndexOf(attribute) + 2
	If position <> -1 Then
		subContent = content.Substring(position, content.Length - position)
		endPosition = subContent.IndexOf("&quot;") + "&quot;".Length
		content = subContent.Substring(0, endPosition)
		content = content.Replace("'","")
		content = content.Replace("&quot;","")
	End If
	
	Return content 
	
End Function


Public Function GetAttributeDQ(content As String, attribute As String) As String
	content = content.Replace(Chr(34),"&quot;")
	Dim subContent As String
	attribute = attribute & "=&quot;"
	Dim position As Integer = 0
	Dim endPosition As Integer = 0
	position = content.IndexOf(attribute) + attribute.Length
	If position <> -1 Then
		subContent = content.Substring(position, content.Length - position)
		endPosition = subContent.IndexOf("&quot;") + "&quot;".Length
		content = subContent.Substring(0, endPosition)
		content = content.Replace("'","")
		content = content.Replace("&quot;","")
	End If
	
	Return content 
	
End Function



Public Function GetAttribute(content As String, attribute As String) As String
	
	Dim subContent As String
	attribute = attribute & "=&#39;"
	Dim position As Integer = 0
	Dim endPosition As Integer = 0
	position = content.IndexOf(attribute) + attribute.Length
	If position <> -1 Then
		subContent = content.Substring(position, content.Length - position)
		endPosition = subContent.IndexOf("&#39;") + "&#39;".Length
		content = subContent.Substring(0, endPosition)
		content = content.Replace("'","")
		content = content.Replace("&#39;","")
	End If
	
	Return content 
	
End Function

Public Function GetUploads(category As String) As String
	Dim retString As String
	
	
	Try
		Dim i As Integer = 0
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tbluploads WHERE linkCategory = '" & category & "' ORDER BY dateStamp DESC"
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()
	
		Try

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			retString += "<style>td, th {border: 1px solid #dddddd;text-align: left;padding: 8px;}</style><div class='col-md-12'><h1>" & category & "</h1><table style='table-layout:fixed;width:100%;'><tr><th>Name</th><th>Description</th><th>Date</th><th>File</th><tr/>"
			While odbcReader.Read()



				Dim myDateString as String = Trim(odbcReader("dateStamp").ToString)
				Dim myDate as DateTime
				DateTime.TryParse(myDateString, myDate).ToString()

				retString += "<tr><td>" & Trim(odbcReader("linkName").ToString) & "</td><td>" & Trim(odbcReader("linkDescription").ToString) & "</td><td>" & myDate.ToString("MMMM dd, yyyy") & "</td>" & "</td><td><a target='_blank' href='/Documents/Files/" & Trim(odbcReader("URL").ToString) & "'>View File</a></td>" & "</tr>"




				i += 1
			End While
			retString += "</table></div>"
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




Public Function GetWidget(id As String) As String
	Dim retString As String
	
	
	Try
		Dim i As Integer = 0
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblwidgets WHERE ftbNum = '" & id & "'"
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()
	
		Try

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While odbcReader.Read()





				retString += Trim(odbcReader("content").ToString)




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



Public Function GetLinks(count As String) As String
	Dim retString As String


	Try

		Dim i As Integer = 0
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tbllinks ORDER BY linkCategory ASC, linkSort ASC, linkName ASC LIMIT " & count
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()

	

		Try

	

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			'retString += "<ul class='collapsible' data-collapsible='accordion'>"
			While odbcReader.Read()
						retString += "" & 
						"<p><i style='color: #bbb;' class='fa fa-arrow-circle-right' aria-hidden='true'></i> &nbsp; <strong><a href=''" & Trim(odbcReader("URL").ToString) & "' target=_blank >" & Trim(odbcReader("linkName").ToString) & "</a></strong> - " & Trim(odbcReader("linkDescription").ToString) & "</p>"


					
						i += 1

			End While
			'retString += "</ul>"
			odbcReader.Close()
		Catch ex As Exception



			odbcConn.Close()



		End Try

	

		odbcConn.Close()

	

	Catch ex As Exception

		retString += ex.ToString()

	End Try
	
	Return retString
	
End Function




Public Function GetFaqs(count As String) As String
	Dim retString As String


	Try

		Dim i As Integer = 0
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblfaqs LIMIT " & count
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()

	

		Try

	

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			retString += "<ul class='collapsible' data-collapsible='accordion'>"
			While odbcReader.Read()
						retString += "" & 
						"<li><div class='collapsible-header'><i class='material-icons'>arrow_drop_down_circle</i><h5 style='letter-spacing: 0px; font-weight: bold;font-family: ""Open Sans"";'>" & Trim(odbcReader("question").ToString) & "</h5></div><div class='collapsible-body'><span>" & Trim(odbcReader("answer").ToString) & "</span></div></li>" 

					
						i += 1

			End While
			retString += "</ul>"
			odbcReader.Close()
		Catch ex As Exception



			odbcConn.Close()



		End Try

	

		odbcConn.Close()

	

	Catch ex As Exception

		retString += ex.ToString()

	End Try
	
	Return retString
	
End Function






Public Function GetBlog(count As String, format As String) As String
	Dim retString As String
	
	
	Try
		Dim i As Integer = 0
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC LIMIT " & count & ""
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()
	
		Try

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While odbcReader.Read()


				Dim myDateString as String = Trim(odbcReader("ItemDate").ToString)

				Dim myDate as DateTime

				DateTime.TryParse(myDateString, myDate).ToString()

				Dim BlogLink As String = ""
				If Not Trim(odbcReader("pageName").ToString) = "" Then 
					BlogLink = "<a href='/" & Trim(odbcReader("pageName").ToString) & "'>"
				Else
					BlogLink = "<a href='/news-details?nNum=" & Trim(odbcReader("nNum").ToString) & "'>"
				End If
		
				'retString += Trim(odbcReader("ItemDate").ToString)
				retString += "<div class='row z-depth-5' style='background-color: #f8f8f8; border-radius: 4px;overflow: hidden;margin-bottom:20px;'>" &
				"<div class='col-md-4 hide-on-med-and-down no-padding-on-large parent-event-image' >" &
							"<div class='events-image' style='height: 100%; background-position: center; background-size: cover; background-image:url(/Documents/News/" & Trim(odbcReader("ImageFile").ToString) & ")'></div>" &
							"</div>" &
							"<div class='col-md-8' style='padding: 20px 40px 40px'>" & 
							BlogLink & "<h4 style='text-transform: uppercase;'>" & Trim(odbcReader("Title").ToString) & "</h4></a>" &
							"<p>" & myDate.ToString(format) & "</p>" &
							"<p>" & Trim(odbcReader("Summary").ToString) & "</p>" &
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





Public Function BuildContact(content As String) As String
	Dim retString As String
	
	
	Try
		
		retString = content
	
	Catch ex As Exception
		
		retString += ex.ToString()
		
	End Try
	
	
	Return retString	
	
End Function


	
	

End Class
