Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Admin_Jobs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        Dim sortmax As Integer = 0

			If Len(Server.HtmlDecode(Request.QueryString("jNum"))) > 0 Then

				Dim jNum As Integer = Request.QueryString("jNum")
				Dim currentStatus As String = ""
		
				lblJobsNum.Text = jNum.ToString
		
				Dim oItem As New PC_JobOpportunities
		
				oItem = DAL_JobOpportunities.GetJobsByNum(jNum)
		
				With oItem
					txtTitle.Text = .Title
					txtjDescription.Text = .jDescription
					txtPayRate.Text = .PayRate
					txtLocation.Text = .Location
					txtjSort.Text = .jSort
					clndrHeadlineDate.SelectedDate = .ItemDate
					currentStatus = .Status
				End With
		
				If currentStatus = "Active" Then
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				Else
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				End If
				pnlStatus.Visible = True
				pnlStatus2.Visible = True
		
				SaveButton.Text = "Update Item"

			Else 

                sortmax = DAL_JobOpportunities.GetMaxSortNumber()
                sortmax = sortmax + 1
                txtjSort.Text = sortmax.ToString

			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_JobOpportunities
        Dim Rslt As Integer

        With oItem
            .Title = txtTitle.Text
            .jDescription = txtjDescription.Text
            .PayRate = txtPayRate.Text
            .Location = txtLocation.Text
            .jSort = txtjSort.Text
            .ItemDate = clndrHeadlineDate.SelectedDate
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Item" Then
                .jNum = lblJobsNum.Text
            End If
        End With

        If SaveButton.Text = "Update Item" Then
            Rslt = DAL_JobOpportunities.ModJobs(oItem)
            txtTitle.Text = ""
            txtjDescription.Text = ""
            txtPayRate.Text = ""
            txtLocation.Text = ""
            txtjSort.Text = ""
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            pnlStatus2.Visible = False
            SaveButton.Text = "Add Item"
        Else
            Rslt = DAL_JobOpportunities.AddJobs(oItem)
            txtTitle.Text = ""
            txtjDescription.Text = ""
            txtPayRate.Text = ""
            txtLocation.Text = ""
            txtjSort.Text = ""
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            pnlStatus2.Visible = False
            SaveButton.Text = "Add Item"
        End If
			Response.Redirect("ADMIN_Jobs.aspx")

    End Sub

End Class
