Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Detail_FAQs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("fNum"))) > 0 Then

				Dim fNum As Integer = Request.QueryString("fNum")
				Dim currentStatus As String = ""
		
				'lblBlogNum.Text = nNum.ToString
		
				Dim oItem As New PC_FAQs
		
				oItem = DAL_PSFAQs.GetFAQsByNum(fNum)
		
				With oItem
					'lblfSort.Text = .fSort
					lblquestion.Text = .question
					lblanswer.Text = .answer
					'lblContent.Text = .content
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
