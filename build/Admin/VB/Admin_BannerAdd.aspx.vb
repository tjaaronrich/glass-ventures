Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_BannerAdd
    Inherits System.Web.UI.Page

    Public Shared Function ThumbnailCallback() As Boolean 
        Return False
    End Function

    Public Shared Function ThumbnailCallback2() As Boolean
        Return False
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        Dim sortmax As Integer = 0

			If Len(Server.HtmlDecode(Request.QueryString("bNum"))) > 0 Then

				Dim bNum As Integer = Request.QueryString("bNum")
				Dim currentStatus As String = ""
				'Dim currentFeatured As String = ""
		
				lblBannerNum.Text = bNum.ToString
		
				Dim oItem As New PC_BannerFTB
		
				oItem = DAL_BannerFTB.GetBannerByNum(bNum)
		
				With oItem
					txtTitle.Text = .Title
					txtLocation.Text = .Location
					'txtAuthor.Text = .Author
					txtbSort.Text = .bSort
					'clndrHeadlineDate.SelectedDate = .ItemDate
					'FreeTextBox1.Text = .content
					'currentFeatured = .Featured
					'ddlFeatured.SelectedValue = currentFeatured
					'txtStatus.Text = .Status
					currentStatus = .Status
					thumb.ImageUrl = "../Documents/Banner/Thumbs/" & .ImageFile
					lblImageFile.Text = .ImageFile
				End With
		
				'set dropdownlist selection
				If currentStatus = "Active" Then
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				Else
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				End If
				pnlStatus.Visible = True

				thumb.visible = True

                lblImageFile.Visible = True
		
				SaveButton.Text = "Update Item"

			Else 

                sortmax = DAL_BannerFTB.GetMaxSortNumber()
                'lblPriorMaxSortNum.Text = sortmax.ToString
                'for an add, assign next sort number as the default
                sortmax = sortmax + 1
                txtbSort.Text = sortmax.ToString
                'lblCurrentSortForEdit.Text = "0"

			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim ImageFile As String
        Dim cnt As Integer
        Dim Rslt As Integer

        Dim Img As Image
        Dim ThumbSize As Size
        Dim Thumb As Bitmap
		
        Dim Img2 As Image
        Dim ThumbSize2 As Size
        Dim Thumb2 As Bitmap

        Dim oItem As New PC_BannerFTB

        If Len(txtTitle.Text) > 1 Then

            If FileUpload1.HasFile Then

                ImageFile = FileUpload1.FileName

                With oItem
					.Title = txtTitle.Text
					.Location = txtLocation.Text
					.bSort= txtbSort.Text
					'.Author = txtAuthor.Text
					'.ItemDate = clndrHeadlineDate.SelectedDate
					'.content = FreeTextBox1.Text
					.Featured = "No"
					'.Status = txtStatus.Text
					.Status = ddlStatus.SelectedValue
                    .ImageFile = ImageFile
					'lblTEST.Text = .ItemDate
					'lblTEST2.Text = Now()
					'If .ItemDate = "12:00:00 AM" Then
						'.ItemDate = Now()
						'.ItemDate = Trim(Left(.ItemDate, instr(.ItemDate, " ")))
						'lblTEST2.Text = .ItemDate
					'End If
					If SaveButton.Text = "Update Item" Then
						.bNum = lblBannerNum.Text
                    End If
                End With

                cnt = DAL_BannerFTB.FileNameExists(ImageFile)

                If cnt = 0 Then
					If SaveButton.Text = "Update Item" Then
						Rslt = DAL_BannerFTB.ModBanner(oItem)
					End If
	
					If SaveButton.Text = "Add Item" Then
						Rslt = DAL_BannerFTB.AddBanner(oItem)
					End If

                    If Rslt = 1 Then

                        Try
                        FileUpload1.SaveAs(Server.MapPath("..\Documents\Banner") & "\" & FileUpload1.FileName)
                        Img = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Banner") & "\" & FileUpload1.FileName)
                        'Img2 = System.Drawing.Image.FromFile(Server.MapPath("Documents\Banner") & "\" & FileUpload1.FileName)


                        ThumbSize = ThumbNailSize(Img.Height, Img.Width, 1280, "W")

                        'new thumbnail code
                        Dim NewThumb As New Bitmap(ThumbSize.Width, ThumbSize.Height)
                        Dim thumbImg As Graphics
                        thumbImg = Graphics.FromImage(NewThumb)
                        'thumbImg.CompositingQuality = CompositingQuality.HighSpeed 
                        'thumbImg.SmoothingMode = SmoothingMode.HighSpeed 
                        'thumbImg.InterpolationMode = InterpolationMode.Low  
                        thumbImg.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle As New Rectangle(0, 0, ThumbSize.Width, ThumbSize.Height)
                        thumbImg.DrawImage(Img, imgRectangle)

                        NewThumb.Save(Server.MapPath("..\Documents\Banner\Thumbs") & "\" & FileUpload1.FileName)


                        'ThumbSize2 = ThumbNailSize2(Img2.Height, Img2.Width, 298, "W")

                        'new thumbnail code
                        'Dim NewThumb2 As New Bitmap(ThumbSize2.Width, ThumbSize2.Height)
                        'Dim thumbImg2 As Graphics
                        'thumbImg2 = Graphics.FromImage(NewThumb2)
                        'thumbImg2.CompositingQuality = CompositingQuality.HighQuality  
                        'thumbImg2.SmoothingMode = SmoothingMode.HighQuality  
                        'thumbImg2.InterpolationMode = InterpolationMode.HighQualityBicubic  

                        'Dim imgRectangle2 As New Rectangle(0, 0, ThumbSize2.Width, ThumbSize2.Height)
                        'thumbImg2.DrawImage(Img2, imgRectangle2)

                        'NewThumb2.Save(Server.MapPath("Documents\Banner\BigThumbs") & "\" & FileUpload1.FileName)

                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File upload failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo was uploaded. Size: " & FileUpload1.PostedFile.ContentLength & " kb"
                        Response.Redirect("ADMIN_Banner.aspx")

                    Else
                        lblErrorMsg.Text = "ERROR! Document upload failed!"
                        Exit Sub
                    End If

                Else
                    lblErrorMsg.Text = "ERROR! Filename already in use!"
                    Exit Sub
                End If

            Else

                With oItem
					.Title = txtTitle.Text
					.Location = txtLocation.Text
					.bSort= txtbSort.Text
					'.Author = txtAuthor.Text
					'.ItemDate = clndrHeadlineDate.SelectedDate
					'.content = FreeTextBox1.Text
					.Featured = "No"
					'.Status = txtStatus.Text
					.Status = ddlStatus.SelectedValue
                    .ImageFile = lblImageFile.Text 'use the existing filename, as not replacing it
					If SaveButton.Text = "Update Item" Then
						.bNum = lblBannerNum.Text
                    End If
                End With

                If SaveButton.Text = "Update Item" Then
                    If Len(lblImageFile.Text) > 0 Then
                        Rslt = DAL_BannerFTB.ModBanner(oItem)
                    Else
                        lblErrorMsg.Text = "ERROR! Image Filename is required! Please select the file to upload."
                        Exit Sub
                    End If
                End If

			'lblErrorMsg.Text = "ERROR! Image File is required! Please select the file to upload."
			'Exit Sub

            End If

        Else
            lblErrorMsg.Text = "ERROR! Title is required! Please enter it."
            Exit Sub
        End If

        Response.Redirect("ADMIN_Banner.aspx")

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