Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Admin_FAQs
    Inherits System.Web.UI.Page
	
	
	
	
	
	Public newDate As String
	Public strGUID As String = Guid.NewGuid().ToString()
	
	

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        Dim sortmax As Integer = 0

			If Len(Server.HtmlDecode(Request.QueryString("fNum"))) > 0 Then

				Dim fNum As Integer = Request.QueryString("fNum")
				Dim currentStatus As String = ""
		
				lblFAQsNum.Text = fNum.ToString
		
				Dim oItem As New PC_FAQs
		
				oItem = DAL_FAQs.GetFAQsByNum(fNum)
		
				With oItem
					txtfSort.Text = .fSort
					txtquestion.Text = .question
					txtanswer.Text = .answer
					'txtStatus.Text = .Status
					currentStatus = .Status
				End With
		
				'set dropdownlist selection
				If currentStatus = "Active" Then
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				Else
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				End If
				'pnlStatus.Visible = True
		
				SaveButton.Text = "Update Item"

			Else 

                sortmax = DAL_FAQs.GetMaxSortNumber()
                'lblPriorMaxSortNum.Text = sortmax.ToString
                'for an add, assign next sort number as the default
                sortmax = sortmax + 1
                txtfSort.Text = sortmax.ToString
                'lblCurrentSortForEdit.Text = "0"

			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_FAQs
        Dim Rslt As Integer

        With oItem
            .fSort = txtfSort.Text
            .question = txtquestion.Text
            .answer = txtanswer.Text
            '.Status = txtStatus.Text
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Item" Then
                .fNum = lblFAQsNum.Text
            End If
        End With

        If SaveButton.Text = "Update Item" Then
            Rslt = DAL_FAQs.ModFAQs(oItem)
            txtfSort.Text = ""
            txtquestion.Text = ""
            txtanswer.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            'FreeTextBox1.Text = ""
            'txtStatus.Text = "Active"
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            'pnlStatus.Visible = False
            SaveButton.Text = "Add Item"
        Else
            Rslt = DAL_FAQs.AddFAQs(oItem)
            txtfSort.Text = ""
            txtquestion.Text = ""
            txtanswer.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            'FreeTextBox1.Text = ""
            'txtStatus.Text = "Active"
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            'pnlStatus.Visible = False
            SaveButton.Text = "Add Item"
        End If
		Response.Redirect("faqs.aspx")
        'GridView1.DataBind()

    End Sub

End Class
