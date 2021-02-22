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
                    txtSort.Text = .bioSort
					lblImageFile.Text = .ImageFile
                End With
				If currentStatus = "Active" Then
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				Else
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				End If

				thumb.visible = True
				pnlStatus.Visible = True
                lblImageFile.Visible = True
			
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
        Dim cnt As Integer
        Dim Rslt As Integer

        Dim Img As Image
        Dim ThumbSize As Size
        Dim Thumb As Bitmap

        Dim Img2 As Image
        Dim ThumbSize2 As Size
        Dim Thumb2 As Bitmap

        Dim oItem As New PC_Portfolio

        If Len(txtTitle.Text) > 1 Then

            If FileUpload1.HasFile Then

                ImageFile = FileUpload1.FileName

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
                    .bioSort = txtSort.Text
					.Status = ddlStatus.SelectedValue
                    If Button1.Text = "Update Item" Then
                        .bioID = lblPortfolioNum.Text
                    End If
                End With

                cnt = DAL_Portfolio.FileNameExists(ImageFile)

                If cnt = 0 Then
					If Button1.Text = "Update Item" Then
						Rslt = DAL_Portfolio.ModifyPortfolio(oItem)
					End If
	
					If Button1.Text = "Add Item" Then
						Rslt = DAL_Portfolio.AddPortfolio(oItem)
					End If

                    If Rslt = 1 Then

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
                            lblErrorMsg.Text = "ERROR! File upload failed."
                            Exit Sub
                        End Try

                        lblErrorMsg.Text = "Success! Photo was uploaded. Size: " & FileUpload1.PostedFile.ContentLength & " kb"
                        Response.Redirect("ADMIN_Projects.aspx")

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
                    .title = txtTitle.Text
                    '.URL = txtURL.Text
                    .Location = txtLocation.Text
                    '.pFunction = txtpFunction.Text
                    '.Services = txtServices.Text
                    '.Contractor = txtContractor.Text
					.Facility = ddlCategory.SelectedValue()
                    .pDescription = Editor1.Text
                    .ImageFile = lblImageFile.Text
                    .bioSort = txtSort.Text
					.Status = ddlStatus.SelectedValue
                    If Button1.Text = "Update Item" Then
                        .bioID = lblPortfolioNum.Text
                    End If
                End With

                If Button1.Text = "Update Item" Then
                    If Len(lblImageFile.Text) > 0 Then
                        Rslt = DAL_Portfolio.ModifyPortfolio(oItem)
                    Else
                        lblErrorMsg.Text = "ERROR! Image Filename is required! Please select the file to upload."
                        Exit Sub
                    End If
                End If

            End If

        Else
            lblErrorMsg.Text = "ERROR! Title is required! Please enter it."
            Exit Sub
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

End Class
