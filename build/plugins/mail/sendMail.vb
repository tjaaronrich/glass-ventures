
Sub submit_click(sender As Object, e As EventArgs)
	Dim rValidate As Boolean = IsGoogleCaptchaValid()
	
	If rValidate = True Then
		Dim mail As New MailMessage()
		mail.From = New MailAddress("DONOTREPLY@Anderson-Construction.com") 
		mail.To.Add("tj@aaronrich.com")
	'mail.To.Add("linden@aaronrich.com")
	'mail.CC.Add("")
	mail.BCC.Add("webadmin@aaronrich.com")

		mail.Subject = "NEW MESSAGE via Anderson-Construction.com"
	mail.IsBodyHtml = True
	Mail.Body = "" & 
	"<strong>Name: </strong>" & fullname.value & "<br/ >" & _
	"<strong>Email Address: </strong>" & email.value & "<br/ >" &  _
	"<strong>Phone: </strong>" & phone.value & "<br/ >" & _
	"<strong>Request Type: </strong>" & requestType.value & "<br/ >" & _
	"<strong>Location Type: </strong>" & locationType.value
	
		
		Dim smtp As New SmtpClient("relay-hosting.secureserver.net")


		Try
			smtp.Credentials = New NetworkCredential("DONOTREPLY@Anderson-Construction.com", "000215")
			smtp.Send(mail)
			Response.Redirect("thanks")
		Catch ehttp As System.Web.HttpException
			Response.Redirect("error")
		End Try
	Else
		rAlert.Attributes.Add("style", "display: block;color:red;")
	End If
	

End Sub 

Private Function IsGoogleCaptchaValid() As Boolean
	Dim recaptchaResponse As String = Request.Form("g-recaptcha-response")
    Try
        If Not String.IsNullOrEmpty(recaptchaResponse) Then
            Dim request As Net.WebRequest = Net.WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=6LdCLBkaAAAAAO-17o8JaAoflCx8HvLOZbiSYLz5&response=" + recaptchaResponse)
            request.Method = "POST"
            request.ContentType = "application/json; charset=utf-8"
            Dim postData As String = ""

            'get a reference to the request-stream, and write the postData to it
            Using s As IO.Stream = request.GetRequestStream()
                Using sw As New IO.StreamWriter(s)
                    sw.Write(postData)
                End Using
            End Using
            ''get response-stream, and use a streamReader to read the content
            Using s As IO.Stream = request.GetResponse().GetResponseStream()
                Using sr As New IO.StreamReader(s)
                    'decode jsonData with javascript serializer
                    Dim jsonData = sr.ReadToEnd()
					'message.value += jsonData
					If jsonData.Contains("""success"": true") = True Then
                        Return True
                    End If
                End Using
            End Using
        End If
    Catch ex As Exception
		requestType.value = ex.ToString()
    End Try

		'message.value = recaptchaResponse
    Return False
End Function