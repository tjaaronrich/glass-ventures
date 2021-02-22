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
		
				Dim oItem As New PC_NewsFTB
		
				oItem = DAL_NewsFTB.GetNewsByNum(nNum)
		
				With oItem
					lblTitle.Text = .Title
					'lblAuthor.Text = .Author
					lblSummary.Text = .Summary
					lblHeadlineDate.Text = .ItemDate
					lblContent.Text = .content
				End With
		
			End If

        End If

    End Sub

End Class
