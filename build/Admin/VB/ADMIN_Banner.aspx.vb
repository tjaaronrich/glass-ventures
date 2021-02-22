Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_Banner
    Inherits System.Web.UI.Page

    Public Shared Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback2() As Boolean
        Return False
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim sortmax As Integer = 0

        Dim ImageFile As String
        Dim Title As String
        Dim Location As String
        Dim URL As String
        Dim iSort As String
        Dim cnt As Integer
        Dim Rslt As Integer
        Dim Clickthrough As Integer = "0"
        Dim Impressions As Integer = "0"
        Dim Caption As String
        Dim AdSize As String
        Dim AdPage As String
        Dim Status As String
       ' Dim Status As String = "Active"

        Dim Img As Image
        Dim ThumbSize As Size
        Dim Thumb As Bitmap

        Dim Img2 As Image
        Dim ThumbSize2 As Size
        Dim Thumb2 As Bitmap

        Status = ddlStatus.SelectedValue
        'AdSize = ddlAdSize.SelectedItem.Value
        'AdPage = ddlAdPage.SelectedItem.Value
        Title = txtTitle.Text
        Location = txtSummary.Text
        iSort = txtSort.Text
        URL = txtURL.Text
		'lblClickthrough = 0
        'Clickthrough = txtClickthrough.Text
		'lblErrorMsg.text = AdSize
		
        If Not Page.IsPostBack Then

		'sortmax = DAL_Ads.GetMaxSortNumber()
		'sortmax = sortmax + 1
		'txtSort.Text = sortmax.ToString

		End If

        If FileUpload1.HasFile Then

            ImageFile = FileUpload1.FileName

            If FileUpload1.HasFile Then

                cnt = DAL_Banner.FileNameExists(ImageFile)

                If cnt = 0 Then

                    Rslt = DAL_Banner.AddPhoto(ImageFile, Title, Location, URL, iSort, Status)

                    If Rslt = 1 Then

                        Try
						
                        'If AdSize = "200x200" Then
												
						FileUpload1.SaveAs(Server.MapPath("..\Documents\Banner") & "\" & FileUpload1.FileName)
                        Img = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Banner") & "\" & FileUpload1.FileName)
                        Img2 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Banner") & "\" & FileUpload1.FileName)

                        ThumbSize = ThumbNailSize(Img.Height, Img.Width, 2000, "W")

                        'new thumbnail code
                        Dim NewThumb As New Bitmap(ThumbSize.Width, ThumbSize.Height)
                        Dim thumbImg As Graphics
                        thumbImg = Graphics.FromImage(NewThumb)
                        thumbImg.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle As New Rectangle(0, 0, ThumbSize.Width, ThumbSize.Height)
                        thumbImg.DrawImage(Img, imgRectangle)

                        NewThumb.Save(Server.MapPath("..\Documents\Banner\BigThumbs") & "\" & FileUpload1.FileName)


                        ThumbSize2 = ThumbNailSize2(Img2.Height, Img2.Width, 300, "W")

                        'new thumbnail code
                        Dim NewThumb2 As New Bitmap(ThumbSize2.Width, ThumbSize2.Height)
                        Dim thumbImg2 As Graphics
                        thumbImg2 = Graphics.FromImage(NewThumb2)
                        thumbImg2.CompositingQuality = CompositingQuality.HighQuality
                        thumbImg2.SmoothingMode = SmoothingMode.HighQuality
                        thumbImg2.InterpolationMode = InterpolationMode.HighQualityBicubic

                        Dim imgRectangle2 As New Rectangle(0, 0, ThumbSize2.Width, ThumbSize2.Height)
                        thumbImg2.DrawImage(Img2, imgRectangle2)

                        NewThumb2.Save(Server.MapPath("..\Documents\Banner\Thumbs") & "\" & FileUpload1.FileName)
						
						'End If 
						
                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File upload failed."
                        End Try

                        lblErrorMsg.Text = "Success! Document was uploaded. Size: " & FileUpload1.PostedFile.ContentLength & " kb"
                        Response.Redirect("ADMIN_Banner.aspx")

                    Else
                        lblErrorMsg.Text = "ERROR! Document upload failed!"
                    End If

                Else
                    lblErrorMsg.Text = "ERROR! Filename already in use!"
                End If

            Else
                lblErrorMsg.Text = "ERROR! Filename is required! Please select the file to upload."
            End If

        Else
            lblErrorMsg.Text = "ERROR! Image name is required! Please enter it."

        End If

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