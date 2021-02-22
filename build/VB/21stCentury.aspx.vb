Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.DateTime
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Partial Class Survey

    Inherits System.Web.UI.Page

    Protected Sub submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles submit.Click

	Dim QuestionAnswer01 as String
	
	If QuestionGroup01a.Checked Then
	QuestionAnswer01 = Email
	Else If QuestionGroup01b.Checked Then
	QuestionAnswer01 = Phone
	Else If QuestionGroup01c.Checked Then
	QuestionAnswer01 = Mail
	End If

	Dim mail As New MailMessage()
	
	mail.From = New MailAddress("DONOTREPLY@careersourcegc.com")
	'mail.To.Add("nschlagheck@r4careersourcegc.com")
	mail.To.Add("aaron@aaronrich.com")
	'mail.CC.Add("marketing@adoptme.org")
	'mail.BCC.Add("aaron@aaronrich.com")
	
	mail.Subject = "Employer Survey: CareerSource Gulf Coast"
	mail.IsBodyHtml = True
	Mail.Body = "<strong>Contact name: </strong>" & contactName.text & "<br/ >" & _
	"<strong>Contact name: </strong>" & companyName.text & "<br/ >" & _
	"<strong>Address line 1: </strong>" & addressLine1.text & "<br/ >" & _
	"<strong>Address line 2: </strong>" & addressLine2.text & "<br/ >" &  _
	"<strong>Preferred Method of Contact: </strong>" & QuestionAnswer01 & "<br/ >" &  _
	"<strong>Email Address: </strong>" & emailAddress.text & "<br/ >" &  _
	"<strong>Phone Number: </strong>" & phoneNumber.text & "<br/ >" & _
	"<strong>What Service Did You Use?: </strong>" & message1.Text & "<br/ ><br/ >" &  _
	"<strong>Additional Comments: </strong>" & message2.Text
	
	Dim smtp As New SmtpClient("relay-hosting.secureserver.net")
	
	Try
	smtp.Credentials = New NetworkCredential("DONOTREPLY@careersourcegc.com", "Password1")
	smtp.Send(mail)
	'Response.Redirect("CU_ThanksMembership.aspx")
	Catch ehttp As System.Web.HttpException
	Response.Redirect("Error.aspx")

	End Try

	Response.Redirect("Thanks.aspx")

    End Sub

End Class
