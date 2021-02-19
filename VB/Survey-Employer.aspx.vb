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
	QuestionAnswer01 = "Email"
	Else If QuestionGroup01b.Checked Then
	QuestionAnswer01 = "Phone"
	Else If QuestionGroup01c.Checked Then
	QuestionAnswer01 = "Mail"
	End If
	
	'------------------
	
	Dim QuestionAnswer02 as String
	
	If QuestionGroup02a.Checked Then
	QuestionAnswer02 = "10"
	Else If QuestionGroup02b.Checked Then
	QuestionAnswer02 = "9"
	Else If QuestionGroup02c.Checked Then
	QuestionAnswer02 = "8"
	Else If QuestionGroup02d.Checked Then
	QuestionAnswer02 = "7"
	Else If QuestionGroup02e.Checked Then
	QuestionAnswer02 = "6"
	Else If QuestionGroup02f.Checked Then
	QuestionAnswer02 = "5"
	Else If QuestionGroup02g.Checked Then
	QuestionAnswer02 = "4"
	Else If QuestionGroup02h.Checked Then
	QuestionAnswer02 = "3"
	Else If QuestionGroup02i.Checked Then
	QuestionAnswer02 = "2"
	Else If QuestionGroup02j.Checked Then
	QuestionAnswer02 = "1"
	End If

	'------------------

	Dim QuestionAnswer03 as String
	
	If QuestionGroup03a.Checked Then
	QuestionAnswer03 = "10"
	Else If QuestionGroup03b.Checked Then
	QuestionAnswer03 = "9"
	Else If QuestionGroup03c.Checked Then
	QuestionAnswer03 = "8"
	Else If QuestionGroup03d.Checked Then
	QuestionAnswer03 = "7"
	Else If QuestionGroup03e.Checked Then
	QuestionAnswer03 = "6"
	Else If QuestionGroup03f.Checked Then
	QuestionAnswer03 = "5"
	Else If QuestionGroup03g.Checked Then
	QuestionAnswer03 = "4"
	Else If QuestionGroup03h.Checked Then
	QuestionAnswer03 = "3"
	Else If QuestionGroup03i.Checked Then
	QuestionAnswer03 = "2"
	Else If QuestionGroup03j.Checked Then
	QuestionAnswer03 = "1"
	End If

	'------------------

	Dim QuestionAnswer04 as String
	
	If QuestionGroup04a.Checked Then
	QuestionAnswer04 = "10"
	Else If QuestionGroup04b.Checked Then
	QuestionAnswer04 = "9"
	Else If QuestionGroup04c.Checked Then
	QuestionAnswer04 = "8"
	Else If QuestionGroup04d.Checked Then
	QuestionAnswer04 = "7"
	Else If QuestionGroup04e.Checked Then
	QuestionAnswer04 = "6"
	Else If QuestionGroup04f.Checked Then
	QuestionAnswer04 = "5"
	Else If QuestionGroup04g.Checked Then
	QuestionAnswer04 = "4"
	Else If QuestionGroup04h.Checked Then
	QuestionAnswer04 = "3"
	Else If QuestionGroup04i.Checked Then
	QuestionAnswer04 = "2"
	Else If QuestionGroup04j.Checked Then
	QuestionAnswer04 = "1"
	End If

	'------------------

	Dim QuestionAnswer05 as String
	
	If QuestionGroup05a.Checked Then
	QuestionAnswer05 = "10"
	Else If QuestionGroup05b.Checked Then
	QuestionAnswer05 = "9"
	Else If QuestionGroup05c.Checked Then
	QuestionAnswer05 = "8"
	Else If QuestionGroup05d.Checked Then
	QuestionAnswer05 = "7"
	Else If QuestionGroup05e.Checked Then
	QuestionAnswer05 = "6"
	Else If QuestionGroup05f.Checked Then
	QuestionAnswer05 = "5"
	Else If QuestionGroup05g.Checked Then
	QuestionAnswer05 = "4"
	Else If QuestionGroup05h.Checked Then
	QuestionAnswer05 = "3"
	Else If QuestionGroup05i.Checked Then
	QuestionAnswer05 = "2"
	Else If QuestionGroup05j.Checked Then
	QuestionAnswer05 = "1"
	End If

	'------------------

	Dim QuestionAnswer06 as String
	
	If QuestionGroup06a.Checked Then
	QuestionAnswer06 = "10"
	Else If QuestionGroup06b.Checked Then
	QuestionAnswer06 = "9"
	Else If QuestionGroup06c.Checked Then
	QuestionAnswer06 = "8"
	Else If QuestionGroup06d.Checked Then
	QuestionAnswer06 = "7"
	Else If QuestionGroup06e.Checked Then
	QuestionAnswer06 = "6"
	Else If QuestionGroup06f.Checked Then
	QuestionAnswer06 = "5"
	Else If QuestionGroup06g.Checked Then
	QuestionAnswer06 = "4"
	Else If QuestionGroup06h.Checked Then
	QuestionAnswer06 = "3"
	Else If QuestionGroup06i.Checked Then
	QuestionAnswer06 = "2"
	Else If QuestionGroup06j.Checked Then
	QuestionAnswer06 = "1"
	End If

	'------------------

	Dim QuestionAnswer07 as String
	
	If QuestionGroup07a.Checked Then
	QuestionAnswer07 = "10"
	Else If QuestionGroup07b.Checked Then
	QuestionAnswer07 = "9"
	Else If QuestionGroup07c.Checked Then
	QuestionAnswer07 = "8"
	Else If QuestionGroup07d.Checked Then
	QuestionAnswer07 = "7"
	Else If QuestionGroup07e.Checked Then
	QuestionAnswer07 = "6"
	Else If QuestionGroup07f.Checked Then
	QuestionAnswer07 = "5"
	Else If QuestionGroup07g.Checked Then
	QuestionAnswer07 = "4"
	Else If QuestionGroup07h.Checked Then
	QuestionAnswer07 = "3"
	Else If QuestionGroup07i.Checked Then
	QuestionAnswer07 = "2"
	Else If QuestionGroup07j.Checked Then
	QuestionAnswer07 = "1"
	End If

	'------------------

	Dim QuestionAnswer08 as String
	
	If QuestionGroup08a.Checked Then
	QuestionAnswer08 = "10"
	Else If QuestionGroup08b.Checked Then
	QuestionAnswer08 = "9"
	Else If QuestionGroup08c.Checked Then
	QuestionAnswer08 = "8"
	Else If QuestionGroup08d.Checked Then
	QuestionAnswer08 = "7"
	Else If QuestionGroup08e.Checked Then
	QuestionAnswer08 = "6"
	Else If QuestionGroup08f.Checked Then
	QuestionAnswer08 = "5"
	Else If QuestionGroup08g.Checked Then
	QuestionAnswer08 = "4"
	Else If QuestionGroup08h.Checked Then
	QuestionAnswer08 = "3"
	Else If QuestionGroup08i.Checked Then
	QuestionAnswer08 = "2"
	Else If QuestionGroup08j.Checked Then
	QuestionAnswer08 = "1"
	End If

	'------------------

	Dim mail As New MailMessage()
	
	mail.From = New MailAddress("DONOTREPLY@careersourcegc.com")
	'mail.To.Add("nschlagheck@r4careersourcegc.com")
	mail.To.Add("customerservice@careersourcegc.com")
	'mail.CC.Add("marketing@adoptme.org")
	mail.BCC.Add("aaron@aaronrich.com")
	
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
	"<strong>Overall, how would you rate your satisfaction with the services from CareerSource Gulf Coast? </strong>" & QuestionAnswer02 & "<br/ >" &  _
	"<strong>Overall, rate how well the services you received met your expectations. </strong>" & QuestionAnswer03 & "<br/ >" &  _
	"<strong>Overall, rate how timely the services you received from CareerSource were. </strong>" & QuestionAnswer04 & "<br/ >" &  _
	"<strong>Overall, how would you rate CareerSource in responding to your needs? </strong>" & QuestionAnswer05 & "<br/ >" &  _
	"<strong>Overall, how would you rate CareerSource in providing the services that helped you hire employees? </strong>" & QuestionAnswer06 & "<br/ >" &  _
	"<strong>How likely are you to recommend CareerSource to a colleague? </strong>" & QuestionAnswer07 & "<br/ >" &  _
	"<strong>How useful did you find this web site? </strong>" & QuestionAnswer08 & "<br/ >" &  _
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
