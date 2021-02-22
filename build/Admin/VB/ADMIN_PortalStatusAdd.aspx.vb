Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Admin_Status
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        'Dim sortmax As Integer = 0

			If Len(Server.HtmlDecode(Request.QueryString("sNum"))) > 0 Then

				Dim sNum As Integer = Request.QueryString("sNum")
				Dim currentCategory As String = ""
				Dim currentStatus As String = ""
				'Dim ddlList As String = ddlsCategory.SelectedItem.Value()
		
				lblsNum.Text = sNum.ToString
		
				Dim oItem As New PC_Status
		
				oItem = DAL_Status.GetStatusByNum(sNum)
		
				With oItem
					txtTitle.Text = .Title
					currentCategory = .sCategory
					currentStatus = .Status
					txtSummary.Text = .Summary
					'txtStatus.Text = .Status
					'ddlsCategory.SelectedValue = ddlList
					'ddlsCategory.SelectedIndex = ddlsCategory.Items.IndexOf(ddlsCategory.Items.FindByValue(.sCategory))					
					ddlStatus.SelectedValue = currentStatus
					ddlsCategory.SelectedValue = currentCategory
					'txtStatus.Text = .Status
				End With
		
				'set dropdownlist selection
				'If currentStatus = "Active" Then
				'	ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				'Else
				'	ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				'End If
				'pnlStatus.Visible = True
		
				SaveButton.Text = "Update Item"

			'Else 

                'sortmax = DAL_Status.GetMaxSortNumber()
                'lblPriorMaxSortNum.Text = sortmax.ToString
                'for an add, assign next sort number as the default
                'sortmax = sortmax + 1
                'txtfSort.Text = sortmax.ToString
                'lblCurrentSortForEdit.Text = "0"

			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_Status
        Dim Rslt As Integer

        With oItem
            .Title = txtTitle.Text
            '.sCategory = txtquestion.Text
            .Summary = txtSummary.Text
            '.Status = txtStatus.Text
            '.Status = txtStatus.Text
            .Status = ddlStatus.SelectedValue
            .sCategory = ddlsCategory.SelectedValue
            If SaveButton.Text = "Update Item" Then
                .sNum = lblsNum.Text
            End If
        End With

        If SaveButton.Text = "Update Item" Then
            Rslt = DAL_Status.ModStatus(oItem)
            txtTitle.Text = ""
            txtSummary.Text = ""
            'txtStatus.Text = ""
            'ddlsCategory.SelectedIndex = ddlsCategory.SelectedValue
            'ddlsCategory.SelectedIndex = ddlsCategory.Items.IndexOf(ddlsCategory.Items.FindByValue("Business Development"))
            'pnlStatus.Visible = True
            SaveButton.Text = "Update Item"
        Else
            Rslt = DAL_Status.AddStatus(oItem)
            txtTitle.Text = ""
            txtSummary.Text = ""
            'txtStatus.Text = ""
            'ddlsCategory.SelectedIndex = ddlsCategory.SelectedValue
            'ddlsCategory.SelectedIndex = ddlsCategory.Items.IndexOf(ddlsCategory.Items.FindByValue("Business Development"))
            'pnlStatus.Visible = True
            SaveButton.Text = "Add Item"
        End If
			Response.Redirect("ADMIN_PortalStatus.aspx")
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
