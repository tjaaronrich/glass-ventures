Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Admin_Videos2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        'Dim sortmax As Integer = 0

			If Len(Server.HtmlDecode(Request.QueryString("vNum"))) > 0 Then

				Dim vNum As Integer = Request.QueryString("vNum")
				Dim currentStatus As String = ""
		
				lblVideosNum.Text = vNum.ToString
		
				Dim oItem As New PC_Videos2
		
				oItem = DAL_Videos2.GetVideosByNum(vNum)
		
				With oItem
					txtvTitle.Text = .vTitle
					txtvDescription.Text = .vDescription
					clndrVideoDate.SelectedDate = .ItemDate
					txtCredits.Text = .Credits
					txtYouTubeID.Text = .YouTubeID
					currentStatus = .Status
				End With
		
				'set dropdownlist selection
				If currentStatus = "Active" Then
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				Else
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				End If
				pnlStatus.Visible = True
		
				SaveButton.Text = "Update Videos"

			Else 

                'sortmax = DAL_Videos.GetMaxSortNumber()
                'lblPriorMaxSortNum.Text = sortmax.ToString
                'for an add, assign next sort number as the default
                'sortmax = sortmax + 1
                'txtfSort.Text = sortmax.ToString
                'lblCurrentSortForEdit.Text = "0"

			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_Videos2
        Dim Rslt As Integer

        With oItem
            .vTitle = txtvTitle.Text
            .vDescription = txtvDescription.Text
            .Credits = txtCredits.Text
            .YouTubeID = txtYouTubeID.Text
			.ItemDate = clndrVideoDate.SelectedDate
			'lblTEST.Text = .ItemDate
			'lblTEST2.Text = Now()
			If .ItemDate = "12:00:00 AM" Then
				.ItemDate = Now()
				.ItemDate = Trim(Left(.ItemDate, instr(.ItemDate, " ")))
				'lblTEST2.Text = .ItemDate
			End If
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Videos" Then
                .vNum = lblVideosNum.Text
            End If
        End With

        If SaveButton.Text = "Update Videos" Then
            Rslt = DAL_Videos2.ModVideos(oItem)
            txtvTitle.Text = ""
            txtvDescription.Text = ""
            txtCredits.Text = ""
            txtYouTubeID.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            'FreeTextBox1.Text = ""
            'txtStatus.Text = "Active"
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            SaveButton.Text = "Add Videos"
        Else
            Rslt = DAL_Videos2.AddVideos(oItem)
            txtvTitle.Text = ""
            txtvDescription.Text = ""
            txtCredits.Text = ""
            txtYouTubeID.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            'FreeTextBox1.Text = ""
            'txtStatus.Text = "Active"
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            SaveButton.Text = "Add Videos"
        End If
			Response.Redirect("ADMIN_Videos2.aspx")
        'GridView1.DataBind()

    End Sub

End Class
