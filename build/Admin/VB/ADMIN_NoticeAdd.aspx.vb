Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_NoticeAdd
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

			If Len(Server.HtmlDecode(Request.QueryString("bioID"))) > 0 Then

				Dim bioID As Integer = Request.QueryString("bioID")
				Dim currentStatus As String = ""
		
				lblBioNum.Text = bioID.ToString
		
				Dim oItem As New PC_Notice
		
				oItem = DAL_Notice.GetNoticeInfoByID(bioID)
		
				With oItem
					'txtFullName.Text = .fullName
					'txtTitle.Text = .title
					txtDescription.text = .nDescription
					txtLink.Text = .link
                    'load the existing image
					'thumb.ImageUrl = "../Documents/Notice/Thumbs/" & .ImageFile

                    txtSort.Text = .nSort
					'lblImageFile.Text = .ImageFile
                End With

                'make the existing image visible
				'thumb.visible = True

                'lblImageFile.Visible = True
			
				Button1.Text = "Update Item"

			Else 

                sortmax = DAL_Notice.GetMaxSortNumber()
                sortmax = sortmax + 1
                txtSort.Text = sortmax.ToString

			End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim oItem As New PC_Notice
        Dim ImageFile As String
        Dim cnt As Integer
        Dim Rslt As Integer

        Dim Img As Image
        Dim ThumbSize As Size
        Dim Thumb As Bitmap

        'If Len(txtDescription.Text) > 1 Then

                With oItem
                    '.fullName = txtFullName.Text
                    '.title = txtTitle.Text
                    .nDescription = txtDescription.Text
                    .link = txtLink.Text
                    '.ImageFile = ImageFile
                    .nSort = txtSort.Text
                    If Button1.Text = "Update Item" Then
                        .bioID = lblBioNum.Text
                    End If
					
                End With

                    'Rslt = DAL_BiosACHService.AddBio(fullName, title, nDescription, emailAddress, nSort, ImageFile)
					If Button1.Text = "Update Item" Then
						Rslt = DAL_Notice.ModifyNotice(oItem)
					End If
	
					If Button1.Text = "Add Item" Then
						Rslt = DAL_Notice.AddNotice(oItem)
					End If


        'Else
            'lblErrorMsg.Text = "ERROR! Description is required! Please enter it."
            'Exit Sub
        'End If

        Response.Redirect("ADMIN_Notice.aspx")

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
