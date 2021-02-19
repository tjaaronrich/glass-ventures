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
			txtFormName.Text = "Planned Giving"

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
					'txtdateOfBirth.Text = .dateOfBirth
					txtcomments.Text = .comments
					'chkmailingList.Text = .mailingList
					ddlamount.SelectedIndex = ddlamount.Items.IndexOf(ddlamount.Items.FindByValue(.amount))
					'ddlfrequency.SelectedIndex = ddlfrequency.Items.IndexOf(ddlfrequency.Items.FindByValue(.frequency))
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
		txtFormName.Text = "Planned Giving"
		lblFormName.Text = "Planned Giving"

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
			'.dateOfBirth = txtdateOfBirth.Text
			.comments = txtcomments.Text
			'.mailingList = replace(replace(chkmailingList.checked, "True", "Yes"), "False", "No")
			.amount = ddlamount.SelectedValue()
			'.frequency = ddlfrequency.SelectedValue()
			.CurDate = Now()
            'If SaveButton.Text = "Update Item" Then
            '.mNum = lblmNum.Text
            '.mNum = convert.toInt16(lblmNum.Text)
            'End If
        End With

        'If SaveButton.Text = "Update Item" Then
			
			'Rslt = DAL_Contacts.ModContacts(oItem)
								
        'Else
				
					Rslt = DAL_Contacts.AddPlannedGivingContacts(oItem)
					
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
							'.dateOfBirth = txtdateOfBirth.Text
							.comments = txtcomments.Text
							'.mailingList = replace(replace(chkmailingList.checked, "True", "Yes"), "False", "No")
							.amount = ddlamount.SelectedValue()
							'.frequency = ddlfrequency.SelectedValue()
							.CurDate = Now()
						'If SaveButton.Text = "Update Item" Then
						'	.mNum = lblmNum.Text
						'End If
					End With
					Submit.Text = "Submit" 

			Dim mail As New MailMessage()
			
			mail.From = New MailAddress("DONOTREPLY@habitatbay.org")
			'mail.To.Add("" & txtemailAddress.Text & "")
			mail.To.Add("ed@bayhabitat.org")
			'mail.To.Add("info@habitatbaycounty.org")
			'mail.CC.Add("marketing@adoptme.org")
			mail.BCC.Add("aaron@aaronrich.com")
			
			mail.Subject = "Habitat For Humanity of Bay County :: Donate"
			mail.IsBodyHtml = True
			'mail.Body = "Thank you for your donation to the Humane Society of Bay County!  We could not provide an impact in the animal community without the generosity of our donors.  If you need any additional information please feel free to contact us directly. <br><br>" & _
			mail.Body = "<strong>Name: </strong>" & txtfirstName.text & " " & txtlastName.text & "<br>" & _
			"<strong>Company Name: </strong>" & txtcompanyName.text & "<br>" & _
			"<strong>Address: </strong>" & txtaddress1.text & " " & txtaddress2.text & ", " & txtcity1.text & ", " & ddlstate1.text & " " & txtzipCode.text & "<br>" & _
			"<strong>Phone Number: </strong>" & txtphoneNumber.text & "<br>" & _
			"<strong>Email Address: </strong>" & txtemailAddress.Text & "<br>" & _
			"<strong>Donation Amount: </strong>" & ddlamount.text & "<br>" & _
			"<strong>Comments: </strong>" & txtcomments.text
			
			Dim smtp As New SmtpClient("relay-hosting.secureserver.net")
			
			Try
			smtp.Credentials = New NetworkCredential("DONOTREPLY@habitatbay.org", "Password1")
			smtp.Send(mail)
			'Response.Redirect("CU_ThanksMembership.aspx")
			Catch ehttp As System.Web.HttpException
			Response.Redirect("Error.aspx")
			End Try 
			

			If ddlamount.text = "" Then
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=finance%40bayhabitat%2eorg&item_name=Habitat%20for%20Humanity%20Donation&item_number=Donation&amount=&no_shipping=1&return=http%3a%2f%2fwww%2ehabitatbay%2eorg%2fThanks%2easpx&cancel_return=http%3a%2f%2fwww%2ehabitatbay%2eorg%2fDefault%2easpx&no_note=1&tax=0&currency_code=USD&bn=PP%2dDonationsBF&charset=UTF%2d8")
			Else 
			Response.Redirect("https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=finance%40bayhabitat%2eorg&item_name=Habitat%20for%20Humanity%20Donation&item_number=Donation&amount=" & (ddlamount.SelectedValue * 1) & "%2e00&no_shipping=1&return=http%3a%2f%2fwww%2ehabitatbay%2eorg%2fThanks%2easpx&cancel_return=http%3a%2f%2fwww%2ehabitatbay%2eorg%2fDefault%2easpx&no_note=1&tax=0&currency_code=USD&bn=PP%2dDonationsBF&charset=UTF%2d8")

			'ElseIf ddlamount.text Then
			'Response.Redirect("Error.aspx")
			'Else Response.Redirect("Thanks.aspx")
			'End If
			End If

    End Sub

End Class
