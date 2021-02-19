Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI.HtmlControls
Imports System.Net
Imports System.Net.Mail
Imports ComponentArt
Imports ComponentArt.Web
Imports ComponentArt.Web.UI

Public Class AttractionsDetail 
	Inherits System.Web.UI.Page

	Protected lblpName As Label
	Protected lblPageTitle As Label
	Protected lblMetaTitle As Label
	Protected lblpType As Label
	Protected lblpSleeps As Label
	Protected lblpBedrooms As Label
	Protected lblpBathrooms As Label
	Protected lblpAddress As Label
	Protected lblpLat As Label
	Protected lblpDescription As Label
	Protected lblpFeatures As Label
	Protected lblpVRBO As Label
	Protected lblpHomeaway As Label
	Protected lblContent As Label
	Protected lblMetaDescription As Label
	Protected lblMailTo As Label
	Protected lblImageFile0 As Label
	Protected lblImageFile0Thumb As Label
	Protected lblImageFile1 As Label
	Protected lblImageFile1Thumb As Label
	Protected lblImageFile2 As Label
	Protected lblImageFile3 As Label
	Protected lblImageFile4 As Label
	Protected lblImageFile5 As Label
	Protected lblErrorMsg As Label

	Public Status As String
	Public Address As String
	Public propName As String
	Public propType As String
	Public Beds As String
	Public Baths As String
	Public Sleeps As String
	Public propId As String
	Public mls_Id As String
	Public irrigated As String
	Public residence As String
	Public Price As String
	Public Acres As String
	Public Features As String
	Public listType As String
	Public googleAddress As String
	Public Lat As String
	Public Lon As String


  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("pID"))) > 0 Then

				Dim pID As Integer = Request.QueryString("pID")
				Dim pName As String = Request.QueryString("pName")
				Dim currentStatus As String = ""
				
				Dim oItem As New PC_Listing
		
				oItem = DAL_Listing.GetVendorInfoByID(pID)
		
				With oItem
					
					'listType = .listType
					'If listType = "0" Or listType = "" Then
					'	listType = ""
					'Else
					'	listType = 
					'		"<tr>" & 
					'			"<td>" & 
					'				"<p><strong>List Type: </strong></p></td>" &
                    '            "<td>" &
                    '                "<p>" & listType & "</p>" &
                    '            "</td>" &
                    '        "</tr>"
					'End If
				
					'mls_Id = .mls_Id
					'If mls_Id = "0" Or mls_Id = "" Then
					'	mls_Id = ""
					'Else
					'	mls_Id = 
					'		"<tr>" & 
					'			"<td>" & 
					'				"<p><strong>MLS ID: </strong></p></td>" &
                    '            "<td>" &
                    '                "<p>" & mls_Id & "</p>" &
                    '            "</td>" &
                    '        "</tr>"
					'End If
					propId = .pID
					'irrigated = .irrigated
					'residence = .residence
					lblpName.Text = .pName
					propName = .pName
					'lblpType.Text = .pType Not being Used
					propType = .pType
					'lblpSleeps.Text = .pSleeps
					Sleeps = .pSleeps
					If Not Sleeps = "0" Then
						Sleeps = "<i class='fa fa-male' aria-hidden='true'></i>" & Sleeps & " Sleeps &nbsp;&nbsp;&nbsp;"
					Else
						Sleeps = ""
					End If
					'lblpBedrooms.Text = .pBedrooms
					Beds = .pBedrooms
					If Not Beds = "0" Then
						Beds = "<i class='fa fa-bed' aria-hidden='true'></i>" & Beds & " Bedrooms &nbsp;&nbsp;&nbsp;"
					Else
						Beds = ""
					End If
					'lblpBathrooms.Text = .pBathrooms
					Baths = .pBathrooms
					If Not Baths = "0" Then
						Baths = "<i class='fa fa-bath' aria-hidden='true'></i>" & Baths & " Bathrooms &nbsp;&nbsp;&nbsp;"
					Else
						Baths = ""
					End If
					'Price = .price
					'If Not Price = "0" Or Price = "" Then
					'	Price = "<i class='fa fa-usd' aria-hidden='true'></i> " & Price & " &nbsp;&nbsp;&nbsp;"
					'Else
					'	Price = ""
					'End If
					'Acres = .acres
					'If Not Acres = "0" Or Acres = "" Then
					'	Acres = "" & Acres & " acres&nbsp;&nbsp;&nbsp;"
					'Else
					'	Acres = ""
					'End If
					lblpAddress.Text = .pAddress
					Address = .pAddress
					Lon = .pLong
					Lat = .pLat
					'AIzaSyD19yNmafdb-dlOMiFEhUfEiV_cXqPgV80
					'lblpLat.Text = "<iframe width='100%' height='225' frameborder='0' style='border:0' src='https://www.google.com/maps/embed/v1/view?key=AIzaSyD19yNmafdb-dlOMiFEhUfEiV_cXqPgV80&center=" & Lat & "," & Lon & "&zoom=15&maptype=satellite&markers=color:red%7Clabel:S%7C" & Lat & "," & Lon & "' allowfullscreen></iframe>"
					'Works but no title
					lblpLat.Text = "<iframe width='100%' height='225' frameborder='0' scrolling='no' marginheight='0' marginwidth='0' src='https://maps.google.com/maps?q=" & .pLat & "," & .pLong & "&hl=en;z=14&amp;output=embed'></iframe>"
					'lblpLat.Text = "<iframe width='100%' height='225' frameborder='0' scrolling='no' marginheight='0' marginwidth='0' src='https://maps.google.com/maps?ie=UTF8&amp;q=" & .pName & "&amp;gl=US&amp;hl=en&amp;ll=" & .pLat & "," & .pLong & "&amp;spn=0.006295,0.006295&amp;t=m&amp;iwloc=A&amp;output=embed'></iframe>"
					'lblpLat.Text = "<iframe src='https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3448.753475382679!2d" & Lon & "84903381!3d" & Lat & "38174147!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x889388cc50c4743b%3A0x714ee18e59e4951d!2s" & .pName & "!5e0!3m2!1sen!2sus!4v1456701747120' width='100%' height='225' frameborder='0' style='border:0' allowfullscreen></iframe>"
					lblpDescription.Text = .pDescription
					Features = .pFeatures
					If Not Features = "" Then
						Features = "<h5 style='font-size:26px'>Features / Amenities</h5><p>" & Features & "</p>"
					Else
						Features = ""
					End If
					lblMailTo.Text = "<a style='color:#333;' href='mailto:?body=Take a look at this property I found on Southern Land Connection, " & .pName & ". You can read more at: http://www.vacationhomemanager.com/properties-detail.aspx?pName=" & .pName & "' class='Grayu'>Email Story</a>"
					lblpVRBO.Text = "<a href='" & .pVRBO & "' target='_blank' class='btn btn-success btn-lg'>Buy This Property</a>"
					'lblpVRBO.Text = "<a href='" & .pVRBO & "' target='_blank'><img src='Graphics/Btn-Book-Vacation-Property-On-VRBO.png' alt='Book Vacation Property on VRBO' width='100%' height='auto' border='0' align='right' style='margin-bottom:10px;'></a>"
					'lblpHomeaway.Text = "<a href='" & .pHomeaway & "' target='_blank'><img src='Graphics/Btn-Book-Vacation-Property-On-Homeaway.png' alt='Book Vacation Property on Homeaway' width='100%' height='auto' border='0' align='right' style='margin-bottom:0px;'></a>"
					lblImageFile0.Text = "<a href='/Documents/Vendors/" & .ImageFile1 & " 'target='_blank' rel='lightbox[Gallery]' title='" & .pName & "'><img src='/Documents/Vendors/" & .ImageFile1 & "' width='100%' height='auto' style='margin-bottom:5px;' /></a>"
					lblImageFile1.Text = "<a href='/Documents/Vendors/" & .ImageFile2 & "' 'target='_blank' rel='lightbox[Gallery]' title='" & .pName & "'><img src='/Documents/Vendors/" & .ImageFile2 & "' width='100%' height='auto' style='margin-right:5px;' /></a>" 
					lblImageFile2.Text = "<a href='/Documents/Vendors/" & .ImageFile3 & "' 'target='_blank' rel='lightbox[Gallery]' title='" & .pName & "'><img src='/Documents/Vendors/" & .ImageFile3 & "' width='100%' height='auto' style='margin-right:5px;' /></a>"
					lblImageFile3.Text = "<a href='/Documents/Vendors/" & .ImageFile4 & "' 'target='_blank' rel='lightbox[Gallery]' title='" & .pName & "'><img src='/Documents/Vendors/" & .ImageFile4 & "' width='100%' height='auto' style='margin-right:5px;' /></a>"
					lblImageFile4.Text = "<a href='/Documents/Vendors/" & .ImageFile5 & "' 'target='_blank' rel='lightbox[Gallery]' title='" & .pName & "'><img src='/Documents/Vendors/" & .ImageFile5 & "' width='100%' height='auto' style='margin-right:5px;' /></a>"
					lblImageFile5.Text = "<a href='/Documents/Vendors/" & .ImageFile6 & "' 'target='_blank' rel='lightbox[Gallery]' title='" & .pName & "'><img src='/Documents/Vendors/" & .ImageFile6 & "' width='100%' height='auto' /></a>"
											
					Page.Title = .pName
					Dim pagetitle As New HtmlMeta() 
					pagetitle.Name = "Title" 
					pagetitle.Content = .pName 
					Header.Controls.Add(pagetitle)
					Dim pagedesc As New HtmlMeta() 
					pagedesc.Name = "Description"
					pagedesc.Content = .pDescription 
					Header.Controls.Add(pagedesc)
					Status = .Status
				End With
		
			End If

	End If

  End Sub 

End Class
