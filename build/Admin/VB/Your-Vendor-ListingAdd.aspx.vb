Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class YourVendorListingAdd
    Inherits System.Web.UI.Page

    Public Shared Function ThumbnailCallback0() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback1() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback2() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback3() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback4() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback5() As Boolean
        Return False
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sortmax As Integer = 0

        If Not Page.IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("pID"))) > 0 Then

				Dim pID As Integer = Request.QueryString("pID")
		 
				'Dim currentCategory As String = ""

				lblpID.Text = pID.ToString
		
				Dim oItem As New PC_Listing
		
				oItem = DAL_Listing.GetVendorInfoByID(pID)
		
				With oItem
					txtpName.Text = .pName
					ddlpType.SelectedValue = .pType
					'ddlpSleeps.SelectedValue = .pSleeps
					'ddlpBedrooms.SelectedValue = .pBedrooms
					'ddlpBathrooms.SelectedValue = .pBathrooms
                    txtpAddress.Text = .pAddress
                    'txtpLat.Text = .pLat
                    'txtpLong.Text = .pLong
                    txtpVRBO.Text = .pVRBO
                    'txtpHomeaway.Text = .pHomeaway
                    Editor1.Text = .pDescription
                    Editor2.Text = .pFeatures
                    txtpSort.Text = .pSort
					'ddlStatus.SelectedValue = .Status

					thumb0.ImageUrl = "../Documents/Vendors/Thumbs/" & .ImageFile1
					thumb1.ImageUrl = "../Documents/Vendors/Thumbs/" & .ImageFile2
					thumb2.ImageUrl = "../Documents/Vendors/Thumbs/" & .ImageFile3
					thumb3.ImageUrl = "../Documents/Vendors/Thumbs/" & .ImageFile4
					thumb4.ImageUrl = "../Documents/Vendors/Thumbs/" & .ImageFile5
					thumb5.ImageUrl = "../Documents/Vendors/Thumbs/" & .ImageFile6
					lblImageFile0.Text = .ImageFile1
					lblImageFile1.Text = .ImageFile2
					lblImageFile2.Text = .ImageFile3
					lblImageFile3.Text = .ImageFile4
					lblImageFile4.Text = .ImageFile5
					lblImageFile5.Text = .ImageFile6
                End With

				thumb0.visible = True
				thumb1.visible = True
				thumb2.visible = True
				thumb3.visible = True
				thumb4.visible = True
				thumb5.visible = True

                lblImageFile0.Visible = True
                lblImageFile1.Visible = True
                lblImageFile2.Visible = True
                lblImageFile3.Visible = True
                lblImageFile4.Visible = True
                lblImageFile5.Visible = True
			
				SaveButton.Text = "Update Item"

			Else 

                sortmax = DAL_Attractions.GetMaxSortNumber()
                sortmax = sortmax + 1
                txtpSort.Text = sortmax.ToString
 
			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim ImageFile0 As String
        Dim ImageFile1 As String
		Dim ImageFile2 As String
		Dim ImageFile3 As String
		Dim ImageFile4 As String
		Dim ImageFile5 As String
        Dim cnt As Integer
        Dim Rslt As Integer

        Dim Img0 As Image
        Dim ThumbSize0 As Size
        Dim Thumb0 As Bitmap

        Dim Img1 As Image
        Dim ThumbSize1 As Size
        Dim Thumb1 As Bitmap

        Dim Img2 As Image
        Dim ThumbSize2 As Size
        Dim Thumb2 As Bitmap

        Dim Img3 As Image
        Dim ThumbSize3 As Size
        Dim Thumb3 As Bitmap

        Dim Img4 As Image
        Dim ThumbSize4 As Size
        Dim Thumb4 As Bitmap

        Dim Img5 As Image
        Dim ThumbSize5 As Size
        Dim Thumb5 As Bitmap

        Dim oItem As New PC_Listing

        If Len(txtpName.Text) > 1 Then

            'If FileUpload1.HasFile or FileUpload2.HasFile Then

                If FileUpload0.HasFile Then
				ImageFile0 = FileUpload0.FileName
				Else
				ImageFile0 = lblImageFile0.Text
				End If
                If FileUpload1.HasFile Then
				ImageFile1 = FileUpload1.FileName
				Else
				ImageFile1 = lblImageFile1.Text
				End If
                If FileUpload2.HasFile Then
				ImageFile2 = FileUpload2.FileName
				Else
				ImageFile2 = lblImageFile2.Text
				End If
                If FileUpload3.HasFile Then
				ImageFile3 = FileUpload3.FileName
				Else
				ImageFile3 = lblImageFile3.Text
				End If
                If FileUpload4.HasFile Then
				ImageFile4 = FileUpload4.FileName
				Else
				ImageFile4 = lblImageFile4.Text
				End If
                If FileUpload5.HasFile Then
				ImageFile5 = FileUpload5.FileName
				Else
				ImageFile5 = lblImageFile5.Text
				End If

                With oItem
                    .pName = txtpName.Text
                    .pType = ddlpType.SelectedValue
                    .pSleeps = ddlpSleeps.SelectedValue
                    .pBedrooms = ddlpBedrooms.SelectedValue
                    .pBathrooms = ddlpBathrooms.SelectedValue
                    .pAddress = txtpAddress.Text
                    '.pLat = txtpLat.Text
                    '.pLong = txtpLong.Text
                    .pVRBO = txtpVRBO.Text
                    '.pHomeaway = txtpHomeaway.Text
                    .pDescription = Editor1.Text
                    .pFeatures = Editor2.Text
                    .pSort = txtpSort.Text
                    .Status = ddlStatus.SelectedValue
                    .ImageFile1 = ImageFile0
                    .ImageFile2 = ImageFile1
                    .ImageFile3 = ImageFile2
                    .ImageFile4 = ImageFile3
                    .ImageFile5 = ImageFile4
                    .ImageFile6 = ImageFile5
                    If SaveButton.Text = "Update Item" Then
                        .pID = lblpID.Text 
                    End If
                End With

                'cnt = DAL_Staff.FileNameExists(ImageFile)

                'If cnt = 0 Then
					If SaveButton.Text = "Update Item" Then
						Rslt = DAL_Listing.ModifyVendor(oItem)
					End If
	
					If SaveButton.Text = "Add Item" Then
						Rslt = DAL_Listing.AddVendorListing(oItem, Session("UserAcctNum").ToString())
					End If

                    'If Rslt = 1 Then

						If FileUpload0.HasFile Then
                        Try
                        FileUpload0.SaveAs(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload0.FileName)
                        Img0 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload0.FileName)
                        ThumbSize0 = ThumbNailSize0(Img0.Height, Img0.Width, 800, "W")

                        'new thumbnail code
                        Dim NewThumb0 As New Bitmap(ThumbSize0.Width, ThumbSize0.Height)
                        Dim thumbImg0 As Graphics
                        thumbImg0 = Graphics.FromImage(NewThumb0)
                        thumbImg0.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg0.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg0.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle0 As New Rectangle(0, 0, ThumbSize0.Width, ThumbSize0.Height)
                        thumbImg0.DrawImage(Img0, imgRectangle0)

                        NewThumb0.Save(Server.MapPath("..\Documents\Vendors\Thumbs") & "\" & FileUpload0.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File upload 0 failed.    " & ex.ToString()
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo 0 was uploaded. Size: " & FileUpload0.PostedFile.ContentLength & " kb"
						End If
						
						'-----------------------------------------------

						If FileUpload1.HasFile Then
                        Try
                        FileUpload1.SaveAs(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload1.FileName)
                        Img1 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload1.FileName)
                        ThumbSize1 = ThumbNailSize1(Img1.Height, Img1.Width, 800, "W")

                        'new thumbnail code
                        Dim NewThumb1 As New Bitmap(ThumbSize1.Width, ThumbSize1.Height)
                        Dim thumbImg1 As Graphics
                        thumbImg1 = Graphics.FromImage(NewThumb1)
                        thumbImg1.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg1.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg1.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle1 As New Rectangle(0, 0, ThumbSize1.Width, ThumbSize1.Height)
                        thumbImg1.DrawImage(Img1, imgRectangle1)

                        NewThumb1.Save(Server.MapPath("..\Documents\Vendors\Thumbs") & "\" & FileUpload1.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File upload 1 failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo 1 was uploaded. Size: " & FileUpload1.PostedFile.ContentLength & " kb"
						End If
						
						'-----------------------------------------------

						If FileUpload2.HasFile Then
                        Try
                        FileUpload2.SaveAs(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload2.FileName)
                        Img2 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload2.FileName)
                        ThumbSize2 = ThumbNailSize2(Img2.Height, Img2.Width, 800, "W")

                        'new thumbnail code
                        Dim NewThumb2 As New Bitmap(ThumbSize2.Width, ThumbSize2.Height)
                        Dim thumbImg2 As Graphics
                        thumbImg2 = Graphics.FromImage(NewThumb2)
                        thumbImg2.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg2.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg2.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle2 As New Rectangle(0, 0, ThumbSize2.Width, ThumbSize2.Height)
                        thumbImg2.DrawImage(Img2, imgRectangle2)

                        NewThumb2.Save(Server.MapPath("..\Documents\Vendors\Thumbs") & "\" & FileUpload2.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File upload 2 failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo 2 was uploaded. Size: " & FileUpload2.PostedFile.ContentLength & " kb"
						End If
						
						'-----------------------------------------------

						If FileUpload3.HasFile Then
                        Try
                        FileUpload3.SaveAs(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload3.FileName)
                        Img3 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload3.FileName)
                        ThumbSize3 = ThumbNailSize3(Img3.Height, Img3.Width, 800, "W")

                        'new thumbnail code
                        Dim NewThumb3 As New Bitmap(ThumbSize3.Width, ThumbSize3.Height)
                        Dim thumbImg3 As Graphics
                        thumbImg3 = Graphics.FromImage(NewThumb3)
                        thumbImg3.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg3.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg3.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle3 As New Rectangle(0, 0, ThumbSize3.Width, ThumbSize3.Height)
                        thumbImg3.DrawImage(Img3, imgRectangle3)

                        NewThumb3.Save(Server.MapPath("..\Documents\Vendors\Thumbs") & "\" & FileUpload3.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File upload 3 failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo 3 was uploaded. Size: " & FileUpload3.PostedFile.ContentLength & " kb"
						End If
						
						'-----------------------------------------------

						If FileUpload4.HasFile Then
                        Try
                        FileUpload4.SaveAs(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload4.FileName)
                        Img4 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload4.FileName)
                        ThumbSize4 = ThumbNailSize4(Img4.Height, Img4.Width, 800, "W")

                        'new thumbnail code
                        Dim NewThumb4 As New Bitmap(ThumbSize4.Width, ThumbSize4.Height)
                        Dim thumbImg4 As Graphics
                        thumbImg4 = Graphics.FromImage(NewThumb4)
                        thumbImg4.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg4.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg4.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle4 As New Rectangle(0, 0, ThumbSize4.Width, ThumbSize4.Height)
                        thumbImg4.DrawImage(Img4, imgRectangle4)

                        NewThumb4.Save(Server.MapPath("..\Documents\Vendors\Thumbs") & "\" & FileUpload4.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File upload 4 failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo 4 was uploaded. Size: " & FileUpload4.PostedFile.ContentLength & " kb"
						End If
						
						'-----------------------------------------------

						If FileUpload5.HasFile Then
                        Try
                        FileUpload5.SaveAs(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload5.FileName)
                        Img5 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Vendors") & "\" & FileUpload5.FileName)
                        ThumbSize5 = ThumbNailSize5(Img5.Height, Img5.Width, 800, "W")

                        'new thumbnail code
                        Dim NewThumb5 As New Bitmap(ThumbSize5.Width, ThumbSize5.Height)
                        Dim thumbImg5 As Graphics
                        thumbImg5 = Graphics.FromImage(NewThumb5)
                        thumbImg5.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg5.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg5.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle5 As New Rectangle(0, 0, ThumbSize5.Width, ThumbSize5.Height)
                        thumbImg5.DrawImage(Img5, imgRectangle5)

                        NewThumb5.Save(Server.MapPath("..\Documents\Vendors\Thumbs") & "\" & FileUpload5.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File upload 5 failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo 5 was uploaded. Size: " & FileUpload5.PostedFile.ContentLength & " kb"
						End If
						
                        'Response.Redirect("ADMIN_Before_After.aspx")
  
                    'Else
                        'lblErrorMsg.Text = "ERROR! Document upload failed!"
                        'Exit Sub
                    'End If

                'Else
                    'lblErrorMsg.Text = "ERROR! Filename already in use!"
                    'Exit Sub
                'End If

            'Else

                'With oItem
                    '.fullName = txtFullName.Text
                    '.Category = ddlCategory.SelectedValue
                    '.ImageFile = lblImageFile.Text  'use the existing filename, as not replacing it
                    '.ImageFile2 = lblImageFile2.Text  'use the existing filename, as not replacing it
                    '.nSort = txtSort.Text
                    'If Button1.Text = "Update Item" Then
                    '    .bioID = lblBioNum.Text
                    'End If
                'End With

                'If Button1.Text = "Update Item" Then
                    'If Len(lblImageFile.Text) > 0 Then
                    '    Rslt = DAL_Staff.ModifyStaff(oItem)
                    'Else
                    '    lblErrorMsg.Text = "ERROR! Image Filename is required! Please select the file to upload."
                    '    Exit Sub
                    'End If
                    'If Len(lblImageFile2.Text) > 0 Then
                    '    Rslt = DAL_Staff.ModifyStaff(oItem)
                    'Else
                    '    lblErrorMsg.Text = "ERROR! Image Filename2 is required! Please select the file to upload."
                    '    Exit Sub
                    'End If
                'End If

            'End If
			
        Else
            lblErrorMsg.Text = "ERROR! Property name is required! Please enter it."
            Exit Sub
        End If

        Response.Redirect("Your-Vendor-Listing.aspx")

    End Sub

    Public Shared Function ThumbNailSize0(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

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

    Public Shared Function ThumbNailSize1(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

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

    Public Shared Function ThumbNailSize3(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

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

    Public Shared Function ThumbNailSize4(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

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

    Public Shared Function ThumbNailSize5(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

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
