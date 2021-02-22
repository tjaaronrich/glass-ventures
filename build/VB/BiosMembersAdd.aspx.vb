Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_Members
    Inherits System.Web.UI.Page

    Public Shared Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback2() As Boolean
        Return False
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("bioID"))) > 0 Then

				Dim bioID As Integer = Request.QueryString("bioID")
				Dim currentStatus As String = ""
				Dim currentState As String = ""
				Dim currentSecondState As String = ""
				Dim currentBoardCertified As String = ""
				Dim currentPrimarySpec As String = ""
				Dim currentSecondarySpec As String = ""
				
				lblBioNum.Text = bioID.ToString
		
				Dim oItem As New PC_BiosMembers
		
				oItem = DAL_BiosMembers.GetBioInfoByID(bioID)
		
				With oItem
					'lblImageFile.Text = .ImageFile
					'txtMSN.Text = .msn
					'txtMLN.Text = .mln
					'txtfullName.Text = .fullName
					'txtfName.Text = .fName
					'txtmName.Text = .mName
					'txtlName.Text = .lName
					txtTitle.Text = .title
					'txtMedSchool.Text = .medSchool
					'txtMedYear.Text = .medYear
					txtAddress.Text = .address
					'txtAddress2.Text = .address2
					txtCity.Text = .city
					currentState = .state
					txtzipCode.Text = .zipCode
					'txtSecondAddress.Text = .SecondAddress
					'txtSecondAddress2.Text = .SecondAddress2
					'txtSecondCity.Text = .SecondCity
					'currentSecondState = .SecondState
					'txtSecondZipCode.Text = .SecondZipCode
					txtHyperlink.Text = .hyperlink
					'currentBoardCertified = .boardCertified
					currentPrimarySpec = .PrimarySpec
					currentSecondarySpec = .SecondarySpec
					txtEmailAddress.Text = .emailAddress
					'txtSecondEmailAddress.Text = .SecondEmailAddress
					txtphoneNumber.Text = .phoneNumber
					'txtSecondPhoneNumber.Text = .SecondPhoneNumber
					'txtImageFile.Text = .imageFile
					'txtMobilePhone.Text = .mobilePhone
					currentStatus = .Status
					ddlState.SelectedValue = currentState
					'ddlSecondState.SelectedValue = currentSecondState
					'ddlboardCertified.SelectedValue = currentBoardCertified
					ddlPrimarySpec.SelectedValue = currentPrimarySpec
					ddlSecondarySpec.SelectedValue = currentSecondarySpec
					''If .ImageFile > 0 then
					'thumb.ImageUrl = "Documents/MembersList/Thumbs/" & .ImageFile
					'End If
					'lblImageFile.Text = .ImageFile
					'If Len(lblImageFile.Text) > 1 Then
					'thumb.visible = True
	                'lblImageFile.Visible = True
					'Else
					'thumb.visible = False
	                'lblImageFile.Visible = False
					'End If

				End With
				
				'ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(currentState))
				'ddlboardCertified.SelectedIndex = ddlboardCertified.Items.IndexOf(ddlboardCertified.Items.FindByValue(currentBoardCertified))
				ddlPrimarySpec.SelectedIndex = ddlPrimarySpec.Items.IndexOf(ddlPrimarySpec.Items.FindByValue(currentPrimarySpec))
				ddlSecondarySpec.SelectedIndex = ddlSecondarySpec.Items.IndexOf(ddlSecondarySpec.Items.FindByValue(currentSecondarySpec))
						
				'set dropdownlist selection
				'If currentStatus = "Active" Then
				'	ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				'Else
				'	ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				'End If
				'pnlStatus.Visible = True

				'thumb.visible = True

                'lblImageFile.Visible = True
		
				'SaveButton.Text = "Update Item"

			End If

        End If

    End Sub

    Protected Sub submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles submit.Click

        Dim ImageFile As String
        Dim cnt As Integer
        Dim Rslt As Integer
        Dim sRslt As String

        Dim Img As Image
        Dim ThumbSize As Size
        Dim Thumb As Bitmap

        Dim Img2 As Image
        Dim ThumbSize2 As Size
        Dim Thumb2 As Bitmap

        Dim oItem As New PC_BiosMembers

		Dim mail As New MailMessage()
		
        'If FileUpload1.HasFile Then
		'	ImageFile = FileUpload1.FileName
		'Else 
		'	ImageFile = lblImageFile.Text
		'End If

		With oItem
			'.msn = txtMSN.Text
			'.mln = txtMLN.Text
			'.fullName = txtFullName.Text
			'.fName = txtfName.Text
			'.mName = txtmName.Text
			'.lName = txtlName.Text
			.title = txtTitle.Text
			'.medSchool = txtMedSchool.Text
			'.medYear = txtMedYear.Text
			.address = txtAddress.Text
			'.address2 = txtAddress2.Text
			.city = txtCity.Text
			.State = ddlState.SelectedValue
			.zipCode = txtzipCode.Text
			'.SecondAddress = txtSecondAddress.Text
			'.SecondAddress2 = txtSecondAddress2.Text
			'.SecondCity = txtSecondCity.Text
			'.SecondState = ddlSecondState.SelectedValue
			'.SecondZipCode = txtSecondZipCode.Text
			.hyperlink = txtHyperlink.Text
			'.boardCertified = ddlBoardCertified.SelectedValue
			.PrimarySpec = ddlPrimarySpec.SelectedValue
			.SecondarySpec = ddlSecondarySpec.SelectedValue
			.emailAddress = txtEmailAddress.Text
			'.SecondEmailAddress = txtSecondEmailAddress.Text
			.phoneNumber = txtPhoneNumber.Text
			'.SecondPhoneNumber = txtSecondPhoneNumber.Text
			'.ImageFile = ImageFile
			'.mobilePhone = txtMobilePhone.Text
			'.Status = ddlStatus.SelectedValue
			'If SaveButton.Text = "Update Item" Then
			'	.bioID = lblBioNum.Text
			'End If
		End With

        If Len(txtTitle.Text) > 1 Then

				'If SaveButton.Text = "Update Item" Then
				'	Rslt = DAL_BiosMembers.ModifyBio(oItem)
				'End If

				'If SaveButton.Text = "Add Item" Then
					Rslt = DAL_BiosMembers.AddBioPublic(oItem)
					'sRslt = DAL_BiosMembers.AddBio2(oItem)
					'lblErrorMsg.Text = sRslt
					'Exit Sub
				'End If
					
					'mail.From = New MailAddress("" & emailAddress.Text & "")
					mail.From = New MailAddress("DONOTREPLY@carpediem365.net")
					'mail.To.Add("" & emailAddress.Text & "")
					'mail.To.Add("joaniehw@yahoo.com,islandcaptain58@aol.com ")
					mail.To.Add("mark@carpediem365.net")
					'mail.CC.Add("dpipresident@comcast.net")
					mail.BCC.Add("aarich@arinc.com")
					
					mail.Subject = "Business Submission: CarpeDiem365.net"
					mail.IsBodyHtml = True
					Mail.Body = "<strong>PLEASE REVIEW THE FOLLOWING PENDING BUSINESS LISTING</strong><br><br><strong>Business Name: </strong>" & txtTitle.text & "<br>" & "<strong>Primary Business Type: </strong>" & ddlPrimarySpec.text & "<br>" & "<strong>Secondary Business Type: </strong>" & ddlSecondarySpec.text & "<br>" & "<strong>Address: </strong>" & txtAddress.text & ", "  & txtCity.text & ", " &  ddlState.text & " " &  txtZipCode.text & "<br>" & "<strong>Website: </strong>" & txtHyperlink.text & "<br>" & "<strong>Phone Number: </strong>" & txtPhoneNumber.text & "<br>" &  "<strong>E-mail Address: </strong>" & txtEmailAddress.Text
					
					Dim smtp As New SmtpClient("relay-hosting.secureserver.net")
					
					If Len(txtURL.text) > 1 Then
					Response.Redirect("CU_unExpectedError.aspx")
					End If
					
					Try
					smtp.Credentials = New NetworkCredential("DONOTREPLY@carpediem365.net", "000215")
					smtp.Send(mail)
					Response.Redirect("S_Thanks.aspx")
					Catch ehttp As System.Web.HttpException
					Response.Redirect("CU_unExpectedError.aspx")
					End Try


                If Rslt = 1 Then
                'lblErrorMsg.Text = "Success! Photo was uploaded. Size: " & FileUpload1.PostedFile.ContentLength & " kb"
					Response.Redirect("ADMIN_Members.aspx")
				Else 
					lblErrorMsg.Text = "Update not successful!"
					Exit Sub
				End If

        Else
            lblErrorMsg.Text = "ERROR! Title is required! Please enter it."
            Exit Sub
        End If

        Response.Redirect("ADMIN_Members.aspx")

    End Sub

    Public Shared Function ThumbNailSize(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

        'NewSizeOrientation: 
        '   H = make height the NewSize, let width scale accordingly
        '   W = make width the NewSize, let height scale accordingly
        '   D = default - make the current largest dimension the NewSize

        Dim ReSize As Size
        Dim TempVal As Double

        ReSize = New Size(OrigW, OrigH)

        If OrigH > NewSize And OrigW > NewSize Then

            If NewSizeOrientation = "D" Then
                If OrigH > OrigW Then
                    TempVal = NewSize / Convert.ToDouble(OrigH)
                Else
                    TempVal = NewSize / Convert.ToDouble(OrigW)
                End If
            End If

            If NewSizeOrientation = "W" Then
                TempVal = NewSize / Convert.ToDouble(OrigW)
            End If

            If NewSizeOrientation = "H" Then
                TempVal = NewSize / Convert.ToDouble(OrigH)
            End If

            ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))

        Else    'one or both dimensions is less than NewSize

            If OrigH > NewSize And NewSizeOrientation = "H" Then
                TempVal = NewSize / Convert.ToDouble(OrigH)
                ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))
            End If

            If OrigW > NewSize And NewSizeOrientation = "W" Then
                TempVal = NewSize / Convert.ToDouble(OrigW)
                ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))
            End If

        End If

        Return ReSize

    End Function

    Public Shared Function ThumbNailSize2(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

        'NewSizeOrientation: 
        '   H = make height the NewSize, let width scale accordingly
        '   W = make width the NewSize, let height scale accordingly
        '   D = default - make the current largest dimension the NewSize

        Dim ReSize As Size
        Dim TempVal As Double

        ReSize = New Size(OrigW, OrigH)

        If OrigH > NewSize And OrigW > NewSize Then

            If NewSizeOrientation = "D" Then
                If OrigH > OrigW Then
                    TempVal = NewSize / Convert.ToDouble(OrigH)
                Else
                    TempVal = NewSize / Convert.ToDouble(OrigW)
                End If
            End If

            If NewSizeOrientation = "W" Then
                TempVal = NewSize / Convert.ToDouble(OrigW)
            End If

            If NewSizeOrientation = "H" Then
                TempVal = NewSize / Convert.ToDouble(OrigH)
            End If

            ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))

        Else    'one or both dimensions is less than NewSize

            If OrigH > NewSize And NewSizeOrientation = "H" Then
                TempVal = NewSize / Convert.ToDouble(OrigH)
                ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))
            End If

            If OrigW > NewSize And NewSizeOrientation = "W" Then
                TempVal = NewSize / Convert.ToDouble(OrigW)
                ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))
            End If

        End If

        Return ReSize

    End Function

End Class
