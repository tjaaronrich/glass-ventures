Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.DateTime
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Partial Class ADMIN_Portal 
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        Dim sortmax As Integer = 0

			If Len(Server.HtmlDecode(Request.QueryString("nNum"))) > 0 Then

				Dim nNum As Integer = Request.QueryString("nNum")
				Dim currentStatus As String = ""
				Dim currentCategory As String = ""
		
				lblnNum.Text = nNum.ToString
		
				Dim oItem As New PC_PortalNewsletter
		
				oItem = DAL_PortalNewsletter.GetNewsletterByNum(nNum)
		
				With oItem
					currentCategory = .linkCategory
					txtnTitle.Text = .nTitle
					'txtnDescription.Text = .nDescription
					txtnSort.Text = .nSort
					ddllinkCategory.SelectedValue = currentCategory
				End With
		
				pnlStatusUpload.Visible = False
				pnlStatusUploadText.Visible = False
		
				SaveButton.Text = "Update Item"

			Else 

                sortmax = DAL_PortalNewsletter.GetMaxSortNumber()
                'lblPriorMaxSortNum.Text = sortmax.ToString
                'for an add, assign next sort number as the default
                sortmax = sortmax + 1
                txtnSort.Text = sortmax.ToString
                'lblCurrentSortForEdit.Text = "0"
			
			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_PortalNewsletter
        Dim Rslt As Integer
        Dim cnt As Integer
        Dim fileName As String
		
        With oItem
            .nTitle = txtnTitle.Text
            '.nDescription = txtnDescription.Text
            .nSort = txtnSort.Text
            .linkCategory = ddllinkCategory.SelectedValue
			If SaveButton.Text = "Add Item" Then
            .fileName = fileUpload1.FileName
			End If
            If SaveButton.Text = "Update Item" Then
                .nNum = lblnNum.Text
            End If
        End With

        If SaveButton.Text = "Update Item" Then
            Rslt = DAL_PortalNewsletter.ModifyNewsletter(oItem)
            With oItem
                .nTitle = txtnTitle.Text
                '.nDescription = txtnDescription.Text
                .nSort = txtnSort.Text
                .linkCategory = ddllinkCategory.SelectedValue
            'txtnTitle.Text = ""
            'txtnDescription.Text = ""
            txtnSort.Text = ""
            '.Author = ddllinkCategory.SelectedValue
			'ddllinkCategory.SelectedIndex = ddllinkCategory.Items.IndexOf(ddllinkCategory.Items.FindByValue("BCBS"))
			pnlStatusUpload.Visible = True
			pnlStatusUploadText.Visible = True
            SaveButton.Text = "Add Item"
            End With
        Else
            fileName = FileUpload1.FileName

            If FileUpload1.HasFile Then

                cnt = DAL_PortalNewsletter.FileNameExists(fileName)

                If cnt = 0 Then
				
					Rslt = DAL_PortalNewsletter.AddNewsletter(oItem)
					
					If Rslt = 1 Then
                        'actually upload the file
                        Try
                            FileUpload1.SaveAs(Server.MapPath("..\Documents\PortalForms") & "\" & FileUpload1.FileName)
                            'Img = System.Drawing.Image.FromFile(Server.MapPath("/AAF/Documents\Bios") & "\" & FileUpload1.FileName)

                            'new thumbnail code
                            'Response.ContentType = "image/gif"
                            'Dim dummyCallBack As System.Drawing.Image.GetThumbnailImageAbort
                            'dummyCallBack = New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
                            'Dim ThumbImg As System.Drawing.Image
                            'ThumbSize = ThumbNailSize(Img.Height, Img.Width, 150)
                            'ThumbImg = Img.GetThumbnailImage(ThumbSize.Width, ThumbSize.Height, dummyCallBack, IntPtr.Zero)
                            'ThumbImg.Save(Server.MapPath("/AAF/Documents\Bios\Thumbs") & "\" & FileUpload1.FileName)


                        Catch ex As Exception
                            lblErrorMsg.Text = "ERROR! File upload failed."
							Exit Sub
                        End Try
					End If

            With oItem
                .nTitle = txtnTitle.Text
                '.nDescription = txtnDescription.Text
                .nSort = txtnSort.Text
                .linkCategory = ddllinkCategory.SelectedValue
                '.Status = ddlStatus.SelectedValue
					pnlStatusUpload.Visible = True
					SaveButton.Text = "Add Item" 
					'.fileName = fileUpload1.FileName
            End With
				Else
					lblErrorMsg.Text = "ERROR! Filename already in use!"
					'Exit Sub
				End If
            Else
                lblErrorMsg.Text = "ERROR! Filename is required! Please select the file to upload."
				Exit Sub
            End If

        End If
			Response.Redirect("ADMIN_PortalDocuments.aspx")
        'GridView1.DataBind()

    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        'Dim nNum As Integer = GridView1.SelectedValue
        'Dim currentStatus As String = ""

        'lblNewsNum.Text = nNum.ToString

        'Dim oItem As New PC_NewsFTB

        'oItem = DAL_NewsFTB.GetNewsByNum(nNum)

        'With oItem
            'txtTitle.Text = .Title
            'txtSummary.Text = .Summary
            'clndrHeadlineDate.SelectedDate = .ItemDate
            'FreeTextBox1.Text = .content
            '''''txtStatus.Text = .Status
            'currentStatus = .Status
        'End With

        ''''''set dropdownlist selection
        'If currentStatus = "Active" Then
            'ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
        'Else
            'ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
        'End If
        'pnlStatus.Visible = True

        'SaveButton.Text = "Update News Item"

    'End Sub

    'Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging

    'End Sub
End Class
