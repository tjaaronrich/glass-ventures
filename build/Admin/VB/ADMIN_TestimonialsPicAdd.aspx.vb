Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Net
Imports System.Net.Mail

Partial Class ADMIN_TestimonialsAdd
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

			If Len(Server.HtmlDecode(Request.QueryString("tNum"))) > 0 Then

				Dim tNum As Integer = Request.QueryString("tNum")
				Dim currentStatus As String = ""
		
				lblTestimonialsNum.Text = tNum.ToString
		
				Dim oItem As New PC_TestimonialsPic
		
				oItem = DAL_TestimonialsPic.GetTestimonialsByNum(tNum)
		
				With oItem
					txttDescription.Text = .tDescription
					txtfullName.Text = .fullName
					txtTitle.Text = .Title
					txtURL.Text = .URL
					txtCity.Text = .City
					txttSort.Text = .tSort
					thumb.ImageUrl = "../Documents/Testimonials/Thumbs/" & .ImageFile
					lblImageFile.Text = .ImageFile
					currentStatus = .Status
				End With
		
				If currentStatus = "Active" Then
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				Else
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				End If
				pnlStatus.Visible = True
				pnlStatus2.Visible = True
				
				thumb.visible = True

                lblImageFile.Visible = True
		
				SaveButton.Text = "Update Item"

			Else 

                sortmax = DAL_TestimonialsPic.GetMaxSortNumber()
                sortmax = sortmax + 1
                txttSort.Text = sortmax.ToString
			
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

        Dim oItem As New PC_TestimonialsPic
        'Dim Rslt As Integer = 0
        'Dim sRslt As String = ""
		
		If Len(txtFullName.Text) > 1 Then

            If FileUpload1.HasFile Then

                ImageFile = FileUpload1.FileName

			With oItem

            .tDescription = txttDescription.Text
            .fullName = txtfullName.Text
            .Title = txtTitle.Text
            .URL = txtURL.Text
            .City = txtCity.Text
			'If Len(FileUpload1.FileName) > 1 Then 
			.ImageFile = ImageFile
			'Else
			'.ImageFile = lblImageFile.text
			'End If
            .tSort = txttSort.Text
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Item" Then
                .tNum = lblTestimonialsNum.Text
				End If
			End With
			
			cnt = DAL_TestimonialsPic.FileNameExists(ImageFile)

                If cnt = 0 Then
					If SaveButton.Text = "Update Item" Then
						Rslt = DAL_TestimonialsPic.ModTestimonials(oItem)
					End If
	
					If SaveButton.Text = "Add Item" Then
						Rslt = DAL_TestimonialsPic.AddTestimonials(oItem)
					End If

                    If Rslt = 1 Then

                        Try
                        FileUpload1.SaveAs(Server.MapPath("..\Documents\Testimonials") & "\" & FileUpload1.FileName)
                        Img = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Testimonials") & "\" & FileUpload1.FileName)
                        Img2 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Testimonials") & "\" & FileUpload1.FileName)


                        ThumbSize = ThumbNailSize(Img.Height, Img.Width, 175, "W")

                        'new thumbnail code
                        Dim NewThumb As New Bitmap(ThumbSize.Width, ThumbSize.Height)
                        Dim thumbImg As Graphics
                        thumbImg = Graphics.FromImage(NewThumb)
                        thumbImg.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle As New Rectangle(0, 0, ThumbSize.Width, ThumbSize.Height)
                        thumbImg.DrawImage(Img, imgRectangle)

                        NewThumb.Save(Server.MapPath("..\Documents\Testimonials\Thumbs") & "\" & FileUpload1.FileName)


                        ThumbSize2 = ThumbNailSize2(Img2.Height, Img2.Width, 600, "W")

                        'new thumbnail code
                        Dim NewThumb2 As New Bitmap(ThumbSize2.Width, ThumbSize2.Height)
                        Dim thumbImg2 As Graphics
                        thumbImg2 = Graphics.FromImage(NewThumb2)
                        thumbImg2.CompositingQuality = CompositingQuality.HighQuality  
                        thumbImg2.SmoothingMode = SmoothingMode.HighQuality  
                        thumbImg2.InterpolationMode = InterpolationMode.HighQualityBicubic  

                        Dim imgRectangle2 As New Rectangle(0, 0, ThumbSize2.Width, ThumbSize2.Height)
                        thumbImg2.DrawImage(Img2, imgRectangle2)

                        NewThumb2.Save(Server.MapPath("..\Documents\Testimonials\BigThumbs") & "\" & FileUpload1.FileName)

                        Catch ex As Exception
                            lblError.Text = "ERROR! File upload failed."
                            Exit Sub
                        End Try

                        lblError.Text = "Success! Photo was uploaded. Size: " & FileUpload1.PostedFile.ContentLength & " kb"
                        Response.Redirect("ADMIN_TestimonialsPic.aspx")

                    Else
                        lblError.Text = "ERROR! Document upload failed!"
                        Exit Sub
                    End If

                Else
                    lblError.Text = "ERROR! Filename already in use!"
                    Exit Sub
                End If

            Else
			
			With oItem
            .tDescription = txttDescription.Text
            .fullName = txtfullName.Text
            .Title = txtTitle.Text
            .URL = txtURL.Text
            .City = txtCity.Text
			.ImageFile = lblImageFile.text
            .tSort = txttSort.Text
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Item" Then
                .tNum = lblTestimonialsNum.Text
            End If
                End With

                If SaveButton.Text = "Update Item" Then
                    If Len(lblImageFile.Text) > 0 Then
                        Rslt = DAL_TestimonialsPic.ModTestimonials(oItem)
                    Else
                        lblError.Text = "ERROR! Image Filename is required! Please select the file to upload."
                        Exit Sub
                    End If
                End If

            End If

        Else
            lblError.Text = "ERROR! Full name is required! Please enter it."
            Exit Sub
        End If

        Response.Redirect("ADMIN_TestimonialsPic.aspx")

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
