Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.IO

Partial Class ADMIN_Newsletter 
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        Dim sortmax As Integer = 0

			If Len(Server.HtmlDecode(Request.QueryString("nNum"))) > 0 Then

				Dim nNum As Integer = Request.QueryString("nNum")
				Dim currentStatus As String = ""
		
				lblnNum.Text = nNum.ToString
		
				Dim oItem As New PC_Newsletter
		
				oItem = DAL_Newsletter.GetNewsletterByNum(nNum)
		 
				With oItem
					ddlCategory.SelectedValue = .linkCategory
					txtnTitle.Text = .nTitle
					Editor1.Text = .nDescription
					txtnSort.Text = .nSort
				End With
		
				pnlStatusUpload.Visible = False
				pnlStatusUploadText.Visible = False
		
				SaveButton.Text = "Update Item"

			Else 

                sortmax = DAL_Newsletter.GetMaxSortNumber()
                'lblPriorMaxSortNum.Text = sortmax.ToString
                'for an add, assign next sort number as the default
                sortmax = sortmax + 1
                txtnSort.Text = sortmax.ToString
                'lblCurrentSortForEdit.Text = "0"
			
			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_Newsletter
        Dim Rslt As Integer
        Dim cnt As Integer
        Dim fileName As String
		
        With oItem
            .nTitle = txtnTitle.Text
            .nDescription = Editor1.Text
            .nSort = txtnSort.Text
            .linkCategory = ddlCategory.SelectedValue
			If SaveButton.Text = "Add Item" Then
            .fileName = fileUpload1.FileName
			End If
            If SaveButton.Text = "Update Item" Then
                .nNum = lblnNum.Text
            End If
        End With

        If SaveButton.Text = "Update Item" Then
            Rslt = DAL_Newsletter.ModifyNewsletter(oItem)
            txtnTitle.Text = ""
            Editor1.Text = ""
            txtnSort.Text = ""
			pnlStatusUpload.Visible = True
			pnlStatusUploadText.Visible = True
            SaveButton.Text = "Add Item"
        Else
            fileName = FileUpload1.FileName

            If FileUpload1.HasFile Then

                cnt = DAL_Newsletter.FileNameExists(fileName)

                If cnt = 0 Then
				
					Rslt = DAL_Newsletter.AddNewsletter(oItem)
					
					If Rslt = 1 Then
                        'actually upload the file
                        Try
                            FileUpload1.SaveAs(Server.MapPath("..\Documents\Newsletter") & "\" & FileUpload1.FileName)
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

					txtnTitle.Text = ""
					Editor1.Text = ""
					txtnSort.Text = ""
					'fileUpload1.FileName = ""
					'fileUpload1.FileName = fileName
					pnlStatusUpload.Visible = True
					SaveButton.Text = "Add Item" 
					'.fileName = fileUpload1.FileName
				Else
					lblErrorMsg.Text = "ERROR! Filename already in use!"
					Exit Sub
				End If
            Else
				Rslt = DAL_Newsletter.AddNewsletter(oItem)
                lblErrorMsg.Text = "ERROR! Filename is required! Please select the file to upload."
				'Exit Sub
            End If

        End If
			Response.Redirect("ADMIN_Newsletters.aspx")
        'GridView1.DataBind()

    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        'Dim nNum As Integer = GridView1.SelectedValue
        'Dim currentStatus As String = ""

        'lblBlogNum.Text = nNum.ToString

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

        'SaveButton.Text = "Update Blog Item"

    'End Sub

    'Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging

    'End Sub
End Class
