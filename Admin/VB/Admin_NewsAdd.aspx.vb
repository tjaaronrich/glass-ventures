Imports Microsoft.VisualBasic

Imports System.Configuration

Imports System.Data

Imports System.Data.Odbc

Imports System.Data.SqlClient

Imports System.Collections.Generic

Imports System.Drawing

Imports System.Drawing.Drawing2D

Imports System.Drawing.Imaging



Partial Class ADMIN_newsadd

    Inherits System.Web.UI.Page



	

	

	

	

	Public HeaderImageValue As String

    Public Shared Function ThumbnailCallback() As Boolean

        Return False

    End Function



    Public Shared Function ThumbnailCallback2() As Boolean

        Return False

    End Function

	

	

	Public newDate As String

	Public strGUID As String = Guid.NewGuid().ToString()

	
	Public catValue As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not Page.IsPostBack Then



			guidLabel.Text = strGUID

			If Len(Server.HtmlDecode(Request.QueryString("nNum"))) > 0 Then



				Dim nNum As Integer = Request.QueryString("nNum")

				Dim currentStatus As String = ""

				Dim currentFeatured As String = ""

				lblnewsNum.Text = nNum.ToString

		

				Dim oItem As New PC_NewsFTB

		

				oItem = DAL_NewsFTB.GetNewsByNum(nNum)

		

				With oItem
					catValue = .Category
					lblMultiSelect.Text = .Category

					'txtnNum.Text = .nNum
					txtPageName.Text = .pageName

					txtTitle.Text = .Title

					txtSummary.Text = .Summary

					'txtAuthor.Text = .Author

					datePicker.Value = .ItemDate

					Editor1.Text = .content

					currentFeatured = .Featured

					'ddlFeatured.SelectedValue = currentFeatured

					'txtStatus.Text = .Status

					currentStatus = .Status

				

					HeaderImageValue = .ImageFile

					lblImageFile0.Text = .ImageFile
				
					'ddlCategory.SelectedValue = .Category

					'thumb.ImageUrl = "../Documents/News/Thumbs/" & .ImageFile

					'lblImageFile.Text = .ImageFile

				End With

				

				'set dropdownlist selection

				'pnlStatus.Visible = True



				'thumb.visible = True



                'lblImageFile.Visible = True

		

				SaveButton.Text = "Update News Item"



		

			Else

		

				Dim myDateString as String = Date.Today.ToString()

				Dim myDate as DateTime

				DateTime.TryParse(myDateString, myDate).ToString()

				datePicker.Value() = myDate.ToString("yyyy/MM/dd")

		

			End If



        End If



    End Sub



    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click



        Dim ImageFile0 As String

        Dim cnt As Integer

        Dim Rslt As Integer



        Dim Img As Image

        Dim ThumbSize As Size

        Dim Thumb As Bitmap

		

        Dim Img2 As Image

        Dim ThumbSize2 As Size

        Dim Thumb2 As Bitmap



        Dim oItem As New PC_NewsFTB







		Dim strDate As String = datePicker.Value()







		Dim myDateString as String = Trim(strDate)

		Dim myDate as DateTime

		DateTime.TryParse(myDateString, myDate).ToString()



        If Len(txtTitle.Text) > 1 Then



	

	

	

				If FileUpload0.HasFile Then

				ImageFile0 = FileUpload0.FileName

				Else

				ImageFile0 = lblImageFile0.Text

				End If

				

	

	

				If FileUpload0.HasFile Then

					Try

					FileUpload0.SaveAs(Server.MapPath("..\Documents\News") & "\" & FileUpload0.FileName)

					Catch ex As Exception

						lblErrorMsg.Text = "ERROR! File upload 0 failed.    " & ex.ToString()

						Exit Sub

					End Try



					lblErrorMsg.Text = "Success! Photo 0 was uploaded. Size: " & FileUpload0.PostedFile.ContentLength & " kb"

				End If

	

	

	



                With oItem
		
					
					.pageName = txtPageName.Text
					Dim checkForLeadingSlash As String = ""
					If Not .pageName = "" Then
						checkForLeadingSlash = .pageName.Substring(0,1)
						If checkForLeadingSlash = "/" Then
							.pageName = .pageName.SubString(1, .pageName.Length-1)
						End If
					End	If
		
					''.Category = ddlCategory.SelectedValue

					'.nNum = txtnNum.Text

					.Title = txtTitle.Text

					.Summary = txtSummary.Text

	'.Author = txtAuthor.Text

					'.ItemDate = clndrHeadlineDate.SelectedDate

					.ItemDate = strDate

					.content = Editor1.Text

					.Featured = "No"

					'.Status = txtStatus.Text

					.Status = ddlStatus.SelectedValue

					.guid = guidLabel.Text

		

					.ImageFile = ImageFile0
		
			.Category = lblMultiSelect.Text

					'.ImageFile = ImageFile

					'lblTEST.Text = .ItemDate

					'lblTEST2.Text = Now()

					If .ItemDate = "12:00:00 AM" Then

						.ItemDate = Now()

						.ItemDate = Trim(Left(.ItemDate, instr(.ItemDate, " ")))

						'lblTEST2.Text = .ItemDate

					End If

					If SaveButton.Text = "Update News Item" Then

						.nNum = lblNewsNum.Text

                    End If

                End With



					If SaveButton.Text = "Update News Item" Then

						Rslt = DAL_NewsFTB.ModNews(oItem)

					End If

	

					If SaveButton.Text = "Add News Item" Then

						Rslt = DAL_NewsFTB.AddNews(oItem)

					End If



        Else

            lblErrorMsg.Text = "ERROR! Title is required! Please enter it."

            Exit Sub

        End If



        Response.Redirect("news.aspx")



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