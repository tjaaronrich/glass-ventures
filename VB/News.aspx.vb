Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Detail_News
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("nNum"))) > 0 Then

				Dim nNum As Integer = Request.QueryString("nNum")
				Dim currentStatus As String = ""
		
				'lblBlogNum.Text = nNum.ToString
		
				Dim oItem As New PC_NewsFTB
		
				oItem = DAL_NewsFTB.GetNewsByNum(nNum)
		
				With oItem
					lblTitle.Text = .Title
					lblSummary.Text = .Summary
					lblHeadlineDate.Text = .ItemDate
					lblContent.Text = .content
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
