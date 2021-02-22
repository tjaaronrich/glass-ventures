Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_Portfolio
    Inherits System.Web.UI.Page

    Public Shared Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback2() As Boolean
        Return False
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sortmax As Integer = 0

        If Not Page.IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("bioID"))) > 0 Then

				Dim bioID As Integer = Request.QueryString("bioID")
				Dim currentCategory As String = ""
				Dim currentStatus As String = ""
		
				lblPortfolioNum.Text = bioID.ToString

				Dim oItem As New PC_Portfolio
		
				oItem = DAL_Portfolio.GetPortfolioInfoByID(bioID)
		
				With oItem
					currentCategory = .Facility
					currentStatus = .Status
					txtTitle.Text = .title
					'txtURL.Text = .URL
					txtLocation.Text = .Location
					'txtpFunction.Text = .pFunction
					'txtServices.Text = .Services
					'txtContractor.Text = .Contractor
					ddlCategory.SelectedValue = currentCategory
					Editor1.Text = .pDescription
					thumb.ImageUrl = "../Documents/Portfolio/Thumbs/" & .ImageFile
					thumb2.ImageUrl = "../Documents/Portfolio/Thumbs/" & .ImageFile2
					thumb3.ImageUrl = "../Documents/Portfolio/Thumbs/" & .ImageFile3
					thumb4.ImageUrl = "../Documents/Portfolio/Thumbs/" & .ImageFile4
					thumb5.ImageUrl = "../Documents/Portfolio/Thumbs/" & .ImageFile5
					thumb6.ImageUrl = "../Documents/Portfolio/Thumbs/" & .ImageFile6
                    txtSort.Text = .bioSort
					lblImageFile.Text = .ImageFile
					lblImageFile2.Text = .ImageFile2
					lblImageFile3.Text = .ImageFile3
					lblImageFile4.Text = .ImageFile4
					lblImageFile5.Text = .ImageFile5
					lblImageFile6.Text = .ImageFile6
                End With
				If currentStatus = "Active" Then
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				Else
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				End If

				If Len(lblImageFile.Text) > 1 Then 
				thumb.visible = True
                lblImageFile.Visible = True
				Else
				thumb.visible = False
                lblImageFile.Visible = False
				End If
				If Len(lblImageFile2.Text) > 1 Then 
				thumb2.visible = True
                lblImageFile2.Visible = True
				Else
				thumb2.visible = False
                lblImageFile2.Visible = False
				End If
				If Len(lblImageFile3.Text) > 1 Then 
				thumb3.visible = True
                lblImageFile3.Visible = True
				Else
				thumb3.visible = False
                lblImageFile3.Visible = False
				End If
				If Len(lblImageFile4.Text) > 1 Then 
				thumb4.visible = True
                lblImageFile4.Visible = True
				Else
				thumb4.visible = False
                lblImageFile4.Visible = False
				End If
				If Len(lblImageFile5.Text) > 1 Then 
				thumb5.visible = True
                lblImageFile5.Visible = True
				Else
				thumb5.visible = False
                lblImageFile5.Visible = False
				End If
				If Len(lblImageFile6.Text) > 1 Then 
				thumb6.visible = True
                lblImageFile6.Visible = True
				Else
				thumb6.visible = False
                lblImageFile6.Visible = False
				End If
				pnlStatus.Visible = True
			
				Button1.Text = "Update Item"

			Else 

                sortmax = DAL_Portfolio.GetMaxSortNumber()
                sortmax = sortmax + 1
                txtSort.Text = sortmax.ToString

			End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ImageFile As String
        Dim ImageFile2 As String
        Dim ImageFile3 As String
        Dim ImageFile4 As String
        Dim ImageFile5 As String
        Dim ImageFile6 As String
        Dim cnt As Integer
        Dim Rslt As Integer

        Dim Img As Image
        Dim ThumbSize As Size
        Dim Thumb As Bitmap
        Dim Img2 As Image
        Dim ThumbSize2 As Size
        Dim Thumb2 As Bitmap

        Dim Img_2 As Image
        Dim ThumbSize_2 As Size
        Dim Thumb_2 As Bitmap
        Dim Img_2a As Image
        Dim ThumbSize_2a As Size
        Dim Thumb_2a As Bitmap

        Dim Img_3 As Image
        Dim ThumbSize_3 As Size
        Dim Thumb_3 As Bitmap
        Dim Img_3a As Image
        Dim ThumbSize_3a As Size
        Dim Thumb_3a As Bitmap

        Dim Img_4 As Image
        Dim ThumbSize_4 As Size
        Dim Thumb_4 As Bitmap
        Dim Img_4a As Image
        Dim ThumbSize_4a As Size
        Dim Thumb_4a As Bitmap

        Dim Img_5 As Image
        Dim ThumbSize_5 As Size
        Dim Thumb_5 As Bitmap
        Dim Img_5a As Image
        Dim ThumbSize_5a As Size
        Dim Thumb_5a As Bitmap

        Dim Img_6 As Image
        Dim ThumbSize_6 As Size
        Dim Thumb_6 As Bitmap
        Dim Img_6a As Image
        Dim ThumbSize_6a As Size
        Dim Thumb_6a As Bitmap

        Dim oItem As New PC_Portfolio

		If FileUpload1.HasFile Then
		ImageFile = FileUpload1.FileName
		Else
		ImageFile = lblImageFile.Text
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

		If FileUpload6.HasFile Then
		ImageFile6 = FileUpload6.FileName
		Else
		ImageFile6 = lblImageFile6.Text
		End If

                With oItem
                    .title = txtTitle.Text
                    '.URL = txtURL.Text
                    .Location = txtLocation.Text
                    '.pFunction = txtpFunction.Text
                    '.Services = txtServices.Text
                    '.Contractor = txtContractor.Text
					.Facility = ddlCategory.SelectedValue()
                    .pDescription = Editor1.Text
                    .ImageFile = ImageFile
                    .ImageFile2 = ImageFile2
                    .ImageFile3 = ImageFile3
                    .ImageFile4 = ImageFile4
                    .ImageFile5 = ImageFile5
                    .ImageFile6 = ImageFile6
                    .bioSort = txtSort.Text
					.Status = ddlStatus.SelectedValue
                    If Button1.Text = "Update Item" Then
                        .bioID = lblPortfolioNum.Text
                    End If
                End With

					If Button1.Text = "Update Item" Then
						Rslt = DAL_Portfolio.ModifyPortfolio(oItem)
					End If
	
					If Button1.Text = "Add Item" Then
						Rslt = DAL_Portfolio.AddPortfolio(oItem)
					End If

                    If FileUpload1.HasFile Then

                        Try
                        FileUpload1.SaveAs(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload1.FileName)
                        Img = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload1.FileName)
                        Img2 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload1.FileName)

                        ThumbSize = ThumbNailSize(Img.Height, Img.Width, 380, "W")

                        'new thumbnail code
                        Dim NewThumb As New Bitmap(ThumbSize.Width, ThumbSize.Height)
                        Dim thumbImg As Graphics
                        thumbImg = Graphics.FromImage(NewThumb)
                        thumbImg.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle As New Rectangle(0, 0, ThumbSize.Width, ThumbSize.Height)
                        thumbImg.DrawImage(Img, imgRectangle)

                        NewThumb.Save(Server.MapPath("..\Documents\Portfolio\Thumbs") & "\" & FileUpload1.FileName)

                        ThumbSize2 = ThumbNailSize2(Img2.Height, Img2.Width, 780, "W")

                        'new thumbnail code
                        Dim NewThumb2 As New Bitmap(ThumbSize2.Width, ThumbSize2.Height)
                        Dim thumbImg2 As Graphics
                        thumbImg2 = Graphics.FromImage(NewThumb2)
                        thumbImg2.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg2.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg2.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle2 As New Rectangle(0, 0, ThumbSize2.Width, ThumbSize2.Height)
                        thumbImg2.DrawImage(Img2, imgRectangle2)

                        NewThumb2.Save(Server.MapPath("..\Documents\Portfolio\BigThumbs") & "\" & FileUpload1.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File1 upload failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo1 was uploaded. Size: " & FileUpload1.PostedFile.ContentLength & " kb"
                        'Response.Redirect("ADMIN_Projects.aspx")

                    End If

                    If FileUpload2.HasFile Then

                        Try
                        FileUpload2.SaveAs(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload2.FileName)
                        Img_2 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload2.FileName)
                        Img_2a = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload2.FileName)

                        ThumbSize_2 = ThumbNailSize(Img_2.Height, Img_2.Width, 380, "W")

                        'new thumbnail code
                        Dim NewThumb_2 As New Bitmap(ThumbSize_2.Width, ThumbSize_2.Height)
                        Dim thumbImg_2 As Graphics
                        thumbImg_2 = Graphics.FromImage(NewThumb_2)
                        thumbImg_2.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_2.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_2.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_2 As New Rectangle(0, 0, ThumbSize_2.Width, ThumbSize_2.Height)
                        thumbImg_2.DrawImage(Img_2, imgRectangle_2)

                        NewThumb_2.Save(Server.MapPath("..\Documents\Portfolio\Thumbs") & "\" & FileUpload2.FileName)

                        ThumbSize_2a = ThumbNailSize2(Img_2a.Height, Img_2a.Width, 780, "W")

                        'new thumbnail code
                        Dim NewThumb_2a As New Bitmap(ThumbSize_2a.Width, ThumbSize_2a.Height)
                        Dim thumbImg_2a As Graphics
                        thumbImg_2a = Graphics.FromImage(NewThumb_2a)
                        thumbImg_2a.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_2a.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_2a.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_2a As New Rectangle(0, 0, ThumbSize_2a.Width, ThumbSize_2a.Height)
                        thumbImg_2a.DrawImage(Img_2a, imgRectangle_2a)

                        NewThumb_2a.Save(Server.MapPath("..\Documents\Portfolio\BigThumbs") & "\" & FileUpload2.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File2 upload failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo2 was uploaded. Size: " & FileUpload2.PostedFile.ContentLength & " kb"
                        'Response.Redirect("ADMIN_Projects.aspx")

                    End If

                    If FileUpload3.HasFile Then

                        Try
                        FileUpload3.SaveAs(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload3.FileName)
                        Img_3 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload3.FileName)
                        Img_3a = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload3.FileName)

                        ThumbSize_3 = ThumbNailSize(Img_3.Height, Img_3.Width, 380, "W")

                        'new thumbnail code
                        Dim NewThumb_3 As New Bitmap(ThumbSize_3.Width, ThumbSize_3.Height)
                        Dim thumbImg_3 As Graphics
                        thumbImg_3 = Graphics.FromImage(NewThumb_3)
                        thumbImg_3.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_3.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_3.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_3 As New Rectangle(0, 0, ThumbSize_3.Width, ThumbSize_3.Height)
                        thumbImg_3.DrawImage(Img_3, imgRectangle_3)

                        NewThumb_3.Save(Server.MapPath("..\Documents\Portfolio\Thumbs") & "\" & FileUpload3.FileName)

                        ThumbSize_3a = ThumbNailSize2(Img_3a.Height, Img_3a.Width, 780, "W")

                        'new thumbnail code
                        Dim NewThumb_3a As New Bitmap(ThumbSize_3a.Width, ThumbSize_3a.Height)
                        Dim thumbImg_3a As Graphics
                        thumbImg_3a = Graphics.FromImage(NewThumb_3a)
                        thumbImg_3a.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_3a.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_3a.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_3a As New Rectangle(0, 0, ThumbSize_3a.Width, ThumbSize_3a.Height)
                        thumbImg_3a.DrawImage(Img_3a, imgRectangle_3a)

                        NewThumb_3a.Save(Server.MapPath("..\Documents\Portfolio\BigThumbs") & "\" & FileUpload3.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File3 upload failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo3 was uploaded. Size: " & FileUpload3.PostedFile.ContentLength & " kb"
                        'Response.Redirect("ADMIN_Projects.aspx")

                    End If

                    If FileUpload4.HasFile Then

                        Try
                        FileUpload4.SaveAs(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload4.FileName)
                        Img_4 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload4.FileName)
                        Img_4a = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload4.FileName)

                        ThumbSize_4 = ThumbNailSize(Img_4.Height, Img_4.Width, 380, "W")

                        'new thumbnail code
                        Dim NewThumb_4 As New Bitmap(ThumbSize_4.Width, ThumbSize_4.Height)
                        Dim thumbImg_4 As Graphics
                        thumbImg_4 = Graphics.FromImage(NewThumb_4)
                        thumbImg_4.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_4.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_4.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_4 As New Rectangle(0, 0, ThumbSize_4.Width, ThumbSize_4.Height)
                        thumbImg_4.DrawImage(Img_4, imgRectangle_4)

                        NewThumb_4.Save(Server.MapPath("..\Documents\Portfolio\Thumbs") & "\" & FileUpload4.FileName)

                        ThumbSize_4a = ThumbNailSize2(Img_4a.Height, Img_4a.Width, 780, "W")

                        'new thumbnail code
                        Dim NewThumb_4a As New Bitmap(ThumbSize_4a.Width, ThumbSize_4a.Height)
                        Dim thumbImg_4a As Graphics
                        thumbImg_4a = Graphics.FromImage(NewThumb_4a)
                        thumbImg_4a.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_4a.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_4a.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_4a As New Rectangle(0, 0, ThumbSize_4a.Width, ThumbSize_4a.Height)
                        thumbImg_4a.DrawImage(Img_4a, imgRectangle_4a)

                        NewThumb_4a.Save(Server.MapPath("..\Documents\Portfolio\BigThumbs") & "\" & FileUpload4.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File4 upload failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo4 was uploaded. Size: " & FileUpload4.PostedFile.ContentLength & " kb"
                        'Response.Redirect("ADMIN_Projects.aspx")

                    End If

                    If FileUpload5.HasFile Then

                        Try
                        FileUpload5.SaveAs(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload5.FileName)
                        Img_5 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload5.FileName)
                        Img_5a = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload5.FileName)

                        ThumbSize_5 = ThumbNailSize(Img_5.Height, Img_5.Width, 380, "W")

                        'new thumbnail code
                        Dim NewThumb_5 As New Bitmap(ThumbSize_5.Width, ThumbSize_5.Height)
                        Dim thumbImg_5 As Graphics
                        thumbImg_5 = Graphics.FromImage(NewThumb_5)
                        thumbImg_5.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_5.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_5.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_5 As New Rectangle(0, 0, ThumbSize_5.Width, ThumbSize_5.Height)
                        thumbImg_5.DrawImage(Img_5, imgRectangle_5)

                        NewThumb_5.Save(Server.MapPath("..\Documents\Portfolio\Thumbs") & "\" & FileUpload5.FileName)

                        ThumbSize_5a = ThumbNailSize2(Img_5a.Height, Img_5a.Width, 780, "W")

                        'new thumbnail code
                        Dim NewThumb_5a As New Bitmap(ThumbSize_5a.Width, ThumbSize_5a.Height)
                        Dim thumbImg_5a As Graphics
                        thumbImg_5a = Graphics.FromImage(NewThumb_5a)
                        thumbImg_5a.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_5a.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_5a.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_5a As New Rectangle(0, 0, ThumbSize_5a.Width, ThumbSize_5a.Height)
                        thumbImg_5a.DrawImage(Img_5a, imgRectangle_5a)

                        NewThumb_5a.Save(Server.MapPath("..\Documents\Portfolio\BigThumbs") & "\" & FileUpload5.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File5 upload failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo5 was uploaded. Size: " & FileUpload5.PostedFile.ContentLength & " kb"
                        'Response.Redirect("ADMIN_Projects.aspx")

                    End If

                    If FileUpload6.HasFile Then

                        Try
                        FileUpload6.SaveAs(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload6.FileName)
                        Img_6 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload6.FileName)
                        Img_6a = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Portfolio") & "\" & FileUpload6.FileName)

                        ThumbSize_6 = ThumbNailSize(Img_6.Height, Img_6.Width, 380, "W")

                        'new thumbnail code
                        Dim NewThumb_6 As New Bitmap(ThumbSize_6.Width, ThumbSize_6.Height)
                        Dim thumbImg_6 As Graphics
                        thumbImg_6 = Graphics.FromImage(NewThumb_6)
                        thumbImg_6.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_6.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_6.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_6 As New Rectangle(0, 0, ThumbSize_6.Width, ThumbSize_6.Height)
                        thumbImg_6.DrawImage(Img_6, imgRectangle_6)

                        NewThumb_6.Save(Server.MapPath("..\Documents\Portfolio\Thumbs") & "\" & FileUpload6.FileName)

                        ThumbSize_6a = ThumbNailSize2(Img_6a.Height, Img_6a.Width, 780, "W")

                        'new thumbnail code
                        Dim NewThumb_6a As New Bitmap(ThumbSize_6a.Width, ThumbSize_6a.Height)
                        Dim thumbImg_6a As Graphics
                        thumbImg_6a = Graphics.FromImage(NewThumb_6a)
                        thumbImg_6a.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg_6a.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg_6a.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle_6a As New Rectangle(0, 0, ThumbSize_6a.Width, ThumbSize_6a.Height)
                        thumbImg_6a.DrawImage(Img_6a, imgRectangle_6a)

                        NewThumb_6a.Save(Server.MapPath("..\Documents\Portfolio\BigThumbs") & "\" & FileUpload6.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File6 upload failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo6 was uploaded. Size: " & FileUpload6.PostedFile.ContentLength & " kb"
                        'Response.Redirect("ADMIN_Projects.aspx")

                    End If

        Response.Redirect("ADMIN_Projects.aspx")

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

    Public Shared Function ThumbNailSize_2(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

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

    Public Shared Function ThumbNailSize_2a(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

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
