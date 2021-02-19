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

Partial Class ADMIN_Contacts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

			txtCurDate.Text = Now()
			txtFormName.Text = "Membership"

			If Len(Server.HtmlDecode(Request.QueryString("mNum"))) > 0 Then

				Dim mNum As Integer = Request.QueryString("mNum")
				'Dim currentStatus As String = ""
				'Dim fileName As String

				lblmNum.Text = mNum.ToString
		
				Dim oItem As New PC_Contacts
		
				oItem = DAL_Contacts.GetContactsByNum(mNum)
		
				With oItem
					txtFormName.Text = .FormName
					txtfirstName.Text = .firstName
					txtlastName.Text = .lastName
					txtcompanyName.Text = .companyName
					txtaddress1.Text = .address1
					txtaddress2.Text = .address2
					txtcity1.Text = .city1
					ddlstate1.SelectedIndex = ddlstate1.Items.IndexOf(ddlstate1.Items.FindByValue(.state1))
					txtzipCode.Text = .zipCode
					txtphoneNumber.Text = .phoneNumber
					txtemailAddress.Text = .emailAddress
					txtdateOfBirth.Text = .dateOfBirth
					txtcomments.Text = .comments
					chkmailingList.Text = .mailingList
					ddlsponsorshipType.SelectedIndex = ddlsponsorshipType.Items.IndexOf(ddlsponsorshipType.Items.FindByValue(.sponsorshipType))
					txtCurDate.Text = Now()
				End With

				Submit.Text = "Update"

			End If

        End If

    End Sub

    Protected Sub submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles submit.Click

        Dim oItem As New PC_Contacts
        Dim Rslt As Integer
        Dim cnt As Integer
        'Dim fileName As String
		txtFormName.Text = "Membership"
		lblFormName.Text = "Membership"

		If Len(txtURL.text) > 1 Then
		Response.Redirect("Error.aspx")
		End If

        With oItem
			.FormName = txtFormName.Text
			.firstName = txtfirstName.Text
			.lastName = txtlastName.Text
			.companyName = txtcompanyName.Text
			.address1 = txtaddress1.Text
			.address2 = txtaddress2.Text
			.city1 = txtcity1.Text
			.state1 = ddlstate1.SelectedValue()
			.zipCode = txtzipCode.Text
			.phoneNumber = txtphoneNumber.Text
			.emailAddress = txtemailAddress.Text
			.dateOfBirth = txtdateOfBirth.Text
			.comments = txtcomments.Text
			.mailingList = replace(replace(chkmailingList.checked, "True", "Yes"), "False", "No")
			.sponsorshipType = ddlsponsorshipType.SelectedValue()
			.CurDate = Now()
            'If SaveButton.Text = "Update Item" Then
            '.mNum = lblmNum.Text
            '.mNum = convert.toInt16(lblmNum.Text)
            'End If
        End With

        'If SaveButton.Text = "Update Item" Then
			
			'Rslt = DAL_Contacts.ModContacts(oItem)
								
        'Else
				
					Rslt = DAL_Contacts.AddMembershipContacts(oItem)
					
					With oItem
							.FormName = txtFormName.Text
							.firstName = txtfirstName.Text
							.lastName = txtlastName.Text
							.companyName = txtcompanyName.Text
							.address1 = txtaddress1.Text
							.address2 = txtaddress2.Text
							.city1 = txtcity1.Text
							.state1 = ddlstate1.SelectedValue()
							.zipCode = txtzipCode.Text
							.phoneNumber = txtphoneNumber.Text
							.emailAddress = txtemailAddress.Text
							.dateOfBirth = txtdateOfBirth.Text
							.comments = txtcomments.Text
							.mailingList = replace(replace(chkmailingList.checked, "True", "Yes"), "False", "No")
							.sponsorshipType = ddlsponsorshipType.SelectedValue()
							.CurDate = Now()
						'If SaveButton.Text = "Update Item" Then
						'	.mNum = lblmNum.Text
						'End If
					End With
					Submit.Text = "Submit" 

			Dim mail As New MailMessage()
			
			mail.From = New MailAddress("DONOTREPLY@bgcbay.com")
			'mail.To.Add("" & txtemailAddress.Text & "")
			'mail.To.Add("info@bgcbay.com")
			'mail.To.Add("sarah@aaronrich.com")
			mail.To.Add("info@bgcbay.com")
			'mail.CC.Add("marketing@adoptme.org")
			mail.BCC.Add("aaron@aaronrich.com")
			
			mail.Subject = "Boys & Girls Club of Bay County :: Membership"
			mail.IsBodyHtml = True
			'mail.Body = "Thank you for becoming a member of the Humane Society of Bay County!  We could not provide an impact in the animal community without the generosity of our members.  If you need any additional information please feel free to contact us directly. <br><br>" & _
			mail.Body = "<strong>Name: </strong>" & txtfirstName.text & " " & txtlastName.text & "<br>" & _
			"<strong>Company Name: </strong>" & txtcompanyName.text & "<br>" & _
			"<strong>Address: </strong>" & txtaddress1.text & " " & txtaddress2.text & ", " & txtcity1.text & ", " & ddlstate1.text & " " & txtzipCode.text & "<br>" & _
			"<strong>Phone Number: </strong>" & txtphoneNumber.text & "<br>" & _
			"<strong>Email Address: </strong>" & txtemailAddress.text & "<br>" & _
			"<strong>Date of Birth: </strong>" & txtdateOfBirth.text & "<br>" & _
			"<strong>Mailing List: </strong>" & replace(replace(chkmailingList.checked, "True", "Yes"), "False", "No") & "<br>" & _
			"<strong>Sponsorship Type: </strong>" & ddlsponsorshipType.text & "<br>" & _
			"<strong>Comments: </strong>" & txtcomments.text
			
			Dim smtp As New SmtpClient("relay-hosting.secureserver.net")
			
			Try
			smtp.Credentials = New NetworkCredential("DONOTREPLY@bgcbay.com", "Password1")
			smtp.Send(mail)
			'Response.Redirect("CU_ThanksMembership.aspx")
			Catch ehttp As System.Web.HttpException
			Response.Redirect("Error.aspx")
			End Try

			If ddlsponsorshipType.SelectedValue = "Member25" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=TZFDD4WFYEGDQ")
			ElseIf ddlsponsorshipType.SelectedValue = "Member50" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=LGZFK44UMXETW")
			ElseIf ddlsponsorshipType.SelectedValue = "Member100" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=GXHZVQ46BDSGY")
			ElseIf ddlsponsorshipType.SelectedValue = "Member150" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8RTLTBNC3U9YC")
			ElseIf ddlsponsorshipType.SelectedValue = "Member200" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XFA7Q2H6NUR6C")
			ElseIf ddlsponsorshipType.SelectedValue = "Member300" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=P5PJ9M6NBENDQ")
			
			ElseIf ddlsponsorshipType.SelectedValue = "Member25recurring" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=MRN5S9P9SJUMU")
			ElseIf ddlsponsorshipType.SelectedValue = "Member50recurring" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=J7QZNVX6P6FTL")
			ElseIf ddlsponsorshipType.SelectedValue = "Member100recurring" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=QEUCUBG3KCDXY")
			ElseIf ddlsponsorshipType.SelectedValue = "Member150recurring" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=X46HKFYZG75BU")
			ElseIf ddlsponsorshipType.SelectedValue = "Member200recurring" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=7UR7P8DYL5NY4")
			ElseIf ddlsponsorshipType.SelectedValue = "Member300recurring" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XWXWSYKJ49ZDC")
			
			ElseIf ddlsponsorshipType.SelectedValue = "MemberOther" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8CJJ4YHABN6JW")

			ElseIf ddlsponsorshipType.SelectedValue = "" Then
			Response.Redirect("Error.aspx")
			Else Response.Redirect("Thanks.aspx")
			End If
			'End If

    End Sub

End Class
