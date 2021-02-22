Imports Microsoft.VisualBasic

Imports System.Configuration

Imports System.Data

Imports System.Data.Odbc

Imports System.Data.SqlClient

Imports System.Collections.Generic

Imports System.Drawing

Imports System.Drawing.Drawing2D

Imports System.Drawing.Imaging

Imports System.Diagnostics









Partial Class PagesAdd

    Inherits System.Web.UI.Page



	Public HeaderImageValue As String

	Public strGUID As String = Guid.NewGuid().ToString()

	Public strError As String

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

		

	

		'Sort.Attributes.Add("type", "number")

        

	Dim sortmax As Integer = 0



    If Not Page.IsPostBack Then



			guidLabel.Text = strGUID

			If Len(Server.HtmlDecode(Request.QueryString("ftbNum"))) > 0 Then



				Dim ftbNum As Integer = Request.QueryString("ftbNum")



				'Dim currentCategory As String = ""



					lblftbNum.Text = ftbNum.ToString



					Dim oItem As New PC_Pages

				Dim cStatus As String

				oItem = DAL_Pages.GetPageNameByNum(ftbNum)



				With oItem

					txtpageName.Text = .pageName

					txtpageTitle.Text = .title 

					txtpageMetaTitle.Text = .meta_title 

					txtpageDescription.Text = .description 

					txtpageKeywords.Text = .keywords

					txtpageHeaderImageText.Text = .HeaderImageText

					HeaderImageValue = .HeaderImage

					 

					'Editor1RTE.Text = .content

					editor.innerHtml = Server.HtmlEncode(.content.Replace("&quot;", Chr(34)))
					keditor.innerHtml = Server.HtmlEncode(.content.Replace("&quot;", Chr(34)))

					lblImageFile0.Text = .HeaderImage

				End With

		

				

				SaveButton.Text = "Update Item"

		

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















        Dim cnt As Integer

        Dim Rslt As Integer







		Dim oItem As New PC_Pages

		

		If Len(txtpageName.Text) > 1 Then



            'If FileUpload1.HasFile or FileUpload2.HasFile Then



                If FileUpload0.HasFile Then

				ImageFile0 = FileUpload0.FileName

				Else

				ImageFile0 = lblImageFile0.Text

				End If

				

	

	

				If FileUpload0.HasFile Then

					Try

						FileUpload0.SaveAs(Server.MapPath("..\Documents\Banner") & "\" & FileUpload0.FileName)

					Catch ex As Exception

						lblErrorMsg.Text = "ERROR! File upload 0 failed.    " & ex.ToString()

						Exit Sub

					End Try



					lblErrorMsg.Text = "Success! Photo 0 was uploaded. Size: " & FileUpload0.PostedFile.ContentLength & " kb"

				End If

		

		

	

				Dim cStatus As String

                With oItem

					.pageName = txtpageName.Text
					Dim checkForLeadingSlash As String = ""
					If Not .pageName = "" Then
						checkForLeadingSlash = .pageName.Substring(0,1)
						If checkForLeadingSlash = "/" Then
							.pageName = .pageName.SubString(1, .pageName.Length-1)
						End If
					End	If
		
					If Not aceeditor.value = "" Then
						.content = aceeditor.value
					Else
						.content = keditorp.value
					End If
			
					

					.title = txtpageTitle.Text

					.meta_title = txtpageMetaTitle.Text

					.description = txtpageDescription.Text

					.keywords = txtpageKeywords.Text

					.HeaderImageText = txtpageHeaderImageText.Text 

					.HeaderImage = ImageFile0

					.guid = guidLabel.Text

				

                    If SaveButton.Text = "Update Item" Then

						.ftbNum = lblftbNum.Text 

                    End If

                End With



                'cnt = DAL_Staff.FileNameExists(ImageFile)



                'If cnt = 0 Then

					Dim nResult As String

					If SaveButton.Text = "Update Item" Then

						nResult = DAL_Pages.ModifyPage(oItem)

					End If

	

					If SaveButton.Text = "Add Item" Then

						Rslt = DAL_Pages.AddPage(oItem)

						nResult = "Here"

					End If

					strError = "nResult"

                    'If Rslt = 1 Then



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

			lblErrorMsg.Text = "ERROR! Permalink is required."

            Exit Sub

        End If



'	Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
	Response.Redirect("/admin/Pages.aspx", True)



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

