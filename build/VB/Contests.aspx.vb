Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic 

Partial Class Detail_FeaturedEvents
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("Title"))) > 0 Then

				Dim Title As String = Request.QueryString("Title")
				Dim currentStatus As String = ""
		
				'lblBlogNum.Text = nNum.ToString
		
				Dim oItem As New PC_FeaturedEventsFTB
		
				oItem = DAL_FeaturedEventsFTB.GetFeaturedEventsByTitle(Title)
		
				With oItem
					lblTitle.Text = .Title
					lblContent.Text = .Content
					lblImageFile.Text = "<a href='Documents/Contests/" & .ImageFile & "' target='_blank'><img alt='click to enlarge' style='border-color:#ffffff; margin-right:0px; margin-left:0px; border-width:0px' width='575' src='Documents/Contests/BigThumbs/" & .ImageFile & "' ></a>"
					'txtStatus.Text = .Status
					'currentStatus = .Status
				End With
		
				'set dropdownlist selection
				'If currentStatus = "Active" Then
					'ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				'Else
					'ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				'End If
				'pnlStatus.Visible = True
		
				'SaveButton.Text = "Update Blog Item"

			End If

        End If

    End Sub

End Class
