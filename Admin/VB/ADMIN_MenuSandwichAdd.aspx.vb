Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class ADMIN_MenuAdd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        Dim sortmax As Integer = 0

			If Len(Server.HtmlDecode(Request.QueryString("mNum"))) > 0 Then

				Dim mNum As Integer = Request.QueryString("mNum")
				Dim currentStatus As String = ""
				Dim currentFeatured As String = ""
				Dim currentCategory As String = ""
		
				lblMenuNum.Text = mNum.ToString
		
				Dim oItem As New PC_Menu
		
				oItem = DAL_MenuSandwich.GetMenuByNum(mNum)
		
				With oItem
					txtmDescription.Text = .mDescription
					txtCategory.Text = .Category
					txtTitle.Text = .Title
					txtFeatured.Text = .Featured
					txtPrice.Text = .Price
					txtmSort.Text = .mSort
					currentStatus = .Status
					currentFeatured = .Featured
					currentCategory = .Category
					ddlStatus.SelectedValue = currentStatus
					ddlFeatured.SelectedValue = currentFeatured
					ddlCategory.SelectedValue = currentCategory

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

                sortmax = DAL_MenuSandwich.GetMaxSortNumber()
                sortmax = sortmax + 1
                txtmSort.Text = sortmax.ToString
			
			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_Menu
        Dim Rslt As Integer = 0
        'Dim sRslt As String = ""

        With oItem
            .mDescription = txtmDescription.Text
            '.Category = txtCategory.Text
			.Category = ddlCategory.SelectedValue
            .Title = txtTitle.Text
			.Featured = ddlFeatured.SelectedValue
            '.Featured = txtFeatured.Text
            .Price = txtPrice.Text
            .mSort = txtmSort.Text
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Item" Then
                .mNum = lblMenuNum.Text
            End If


        If SaveButton.Text = "Update Item" Then
            Rslt = DAL_MenuSandwich.ModMenu(oItem)
            txtmDescription.Text = ""
            txtCategory.Text = ""
            txtTitle.Text = ""
            txtFeatured.Text = ""
            txtPrice.Text = ""
            txtmSort.Text = ""
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            pnlStatus2.Visible = False
            SaveButton.Text = "Add Item"
        Else
            Rslt = DAL_MenuSandwich.AddMenu(oItem)
            txtmDescription.Text = ""
            txtCategory.Text = ""
            txtTitle.Text = ""
            txtFeatured.Text = ""
            txtPrice.Text = ""
            txtmSort.Text = ""
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            pnlStatus2.Visible = False
            SaveButton.Text = "Add Item"
        End If
        End With
			'lblError.text = sRslt
			Response.Redirect("ADMIN_Menu.aspx") 

    End Sub

End Class
