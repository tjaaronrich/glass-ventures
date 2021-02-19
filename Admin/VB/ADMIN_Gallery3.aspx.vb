Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_Gallery
    Inherits System.Web.UI.Page

    Public Shared Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback2() As Boolean
        Return False
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ImageFile As String = ""
        Dim cnt As Integer
        Dim Rslt As Integer
        Dim Name As String = ""
        Dim GalleryID As Integer = 0
        Dim Gallery As String = ""
        Dim Status As String = "Active"

        Dim Img As Image
        Dim ThumbSize As Size
        Dim Thumb As Bitmap

        Dim Img2 As Image
        Dim ThumbSize2 As Size
        Dim Thumb2 As Bitmap

        Dim iPhoto As Integer = 0
        Dim FileOK As Integer = 0

        For iPhoto = 1 To 3
            If iPhoto = 1 Then
                Name = txtName1.Text
                GalleryID = Convert.ToInt16(ddlGallery1.SelectedValue)
                Gallery = ddlGallery1.SelectedItem.Text
                'If Len(Name) > 1 Then
                    ImageFile = GalleryID & "-" & FileUpload1.FileName
                'End If
                If FileUpload1.HasFile Then
                    FileOK = 1
                Else
                    FileOK = 0
                End If
            End If
            If iPhoto = 2 Then
                Name = txtName2.Text
                GalleryID = Convert.ToInt16(ddlGallery2.SelectedValue)
                Gallery = ddlGallery2.SelectedItem.Text
                'If Len(Name) > 1 Then
                    ImageFile = GalleryID & "-" & FileUpload2.FileName
                'End If
                If FileUpload2.HasFile Then
                    FileOK = 1
                Else
                    FileOK = 0
					'Exit sub
                End If
            End If
            If iPhoto = 3 Then
                Name = txtName3.Text
                GalleryID = Convert.ToInt16(ddlGallery3.SelectedValue)
                Gallery = ddlGallery3.SelectedItem.Text
                'If Len(Name) > 1 Then
                    ImageFile = GalleryID & "-" & FileUpload3.FileName
                'End If
                If FileUpload3.HasFile Then
                    FileOK = 1
                Else
                    FileOK = 0
					'Exit sub
                End If
            End If

            'If Len(Name) > 1 Then

                'ImageFile = FileUpload1.FileName
 
                'If FileUpload1.HasFile Then
                If FileOK = 1 Then

                    cnt = DAL_GalleryCategories.FileNameExists(ImageFile)

                    If cnt = 0 Then

                        Rslt = DAL_GalleryCategories.AddPhoto(Name, ImageFile, GalleryID, Gallery, Status)

                        If Rslt = 1 Then

                            Try
                                If iPhoto = 1 Then
                                    FileUpload1.SaveAs(Server.MapPath("..\Documents\Gallery") & "\" & GalleryID & "-" & FileUpload1.FileName)
                                    Img = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Gallery") & "\" & GalleryID & "-" & FileUpload1.FileName)
                                    Img2 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Gallery") & "\" & GalleryID & "-" & FileUpload1.FileName)
                                End If
                                If iPhoto = 2 Then
                                    FileUpload2.SaveAs(Server.MapPath("..\Documents\Gallery") & "\" & GalleryID & "-" & FileUpload2.FileName)
                                    Img = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Gallery") & "\" & GalleryID & "-" & FileUpload2.FileName)
                                    Img2 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Gallery") & "\" & GalleryID & "-" & FileUpload2.FileName)
                                End If
                                If iPhoto = 3 Then
                                    FileUpload3.SaveAs(Server.MapPath("..\Documents\Gallery") & "\" & GalleryID & "-" & FileUpload3.FileName)
                                    Img = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Gallery") & "\" & GalleryID & "-" & FileUpload3.FileName)
                                    Img2 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Gallery") & "\" & GalleryID & "-" & FileUpload3.FileName)
                                End If

                                ThumbSize = ThumbNailSize(Img.Height, Img.Width, 200, "W")

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

                                If iPhoto = 1 Then
                                    NewThumb.Save(Server.MapPath("..\Documents\Gallery\Thumbs") & "\" & GalleryID & "-" & FileUpload1.FileName)
                                End If
                                If iPhoto = 2 Then
                                    NewThumb.Save(Server.MapPath("..\Documents\Gallery\Thumbs") & "\" & GalleryID & "-" & FileUpload2.FileName)
                                End If
                                If iPhoto = 3 Then
                                    NewThumb.Save(Server.MapPath("..\Documents\Gallery\Thumbs") & "\" & GalleryID & "-" & FileUpload3.FileName)
                                End If

                                'NewThumb.Save(Server.MapPath("Documents\Gallery\Thumbs") & "\" & FileUpload1.FileName)


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

                                If iPhoto = 1 Then
                                    NewThumb2.Save(Server.MapPath("..\Documents\Gallery\BigGallery") & "\" & GalleryID & "-" & FileUpload1.FileName)
                                End If
                                If iPhoto = 2 Then
                                    NewThumb2.Save(Server.MapPath("..\Documents\Gallery\BigGallery") & "\" & GalleryID & "-" & FileUpload2.FileName)
                                End If
                                If iPhoto = 3 Then
                                    NewThumb2.Save(Server.MapPath("..\Documents\Gallery\BigGallery") & "\" & GalleryID & "-" & FileUpload3.FileName)
                                End If

                            Catch ex As Exception
                                lblErrorMsg.Text = "ERROR! File upload failed."
								exit sub
                            End Try

                            'lblErrorMsg.Text = "Success! Document was uploaded. Size: " & FileUpload1.PostedFile.ContentLength & " kb"
                            lblErrorMsg.Text = "Success! Document was uploaded."
							'exit sub 
                            'Response.Redirect("ADMIN_Gallery.aspx")

                        Else
                            lblErrorMsg.Text = "ERROR! Document upload failed!"
							exit sub
                        End If

                    Else
                        lblErrorMsg.Text = "ERROR! Filename already in use! To upload this image, save it on your computer with antoher name and try again for Item: " & iPhoto.ToString
						exit sub
                    End If

                Else
                    lblErrorMsg.Text = "ERROR! Filename is required! Please select the file to upload for Item: " & iPhoto.ToString
					'exit sub
                End If

            'Else
            '    lblErrorMsg.Text = "ERROR! Image name is required! Please enter it for Item: " & iPhoto.ToString
            'End If

        Next

        Response.Redirect("ADMIN_Gallery.aspx")

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


    Protected Sub btnAddGallery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddGallery.Click

        Dim gExist As Integer = 1
        Dim Rslt As Integer = 0

        'check that gallery name does not already exist
        gExist = DAL_GalleryCategories.GalleryNameExists(txtNewGallery.Text)

        'if gallery does not exist (count = 0), add it
        If gExist = 0 Then
            'Note: IsDefault column not used presently, set to "NO"; Status for now is always "Active"
            Rslt = DAL_GalleryCategories.AddPhotoGallery(txtNewGallery.Text, "NO",  ddlCategory.Text, "Active")
        End If

        'refresh list of galleries in drop down list
        If Rslt = 1 Then
            ddlGallery1.DataBind()
            ddlGallery2.DataBind()
            ddlGallery3.DataBind()
        End If

    End Sub


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim photoID As String = GridView1.SelectedValue
        Response.Redirect("ADMIN_Gallery.aspx?photoID=" & photoID)
    End Sub
End Class
