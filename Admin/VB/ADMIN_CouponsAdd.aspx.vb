Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class Admin_Coupons
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("cNum"))) > 0 Then

				Dim cNum As Integer = Request.QueryString("cNum")
				Dim currentStatus As String = ""
		
				lblCouponsNum.Text = cNum.ToString
		
				Dim oItem As New PC_Coupons
		
				oItem = DAL_Coupons.GetCouponsByNum(cNum)
		
				With oItem
					txtcSort.Text = .cSort
					txtcTitle.Text = .cTitle
					txtcDescription.Text = .cDescription
					'txtStatus.Text = .Status
					currentStatus = .Status
				End With
		
				'set dropdownlist selection
				If currentStatus = "Active" Then
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
				Else
					ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
				End If
				pnlStatus.Visible = True
		
				SaveButton.Text = "Update Coupon Item"

			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_Coupons
        Dim Rslt As Integer

        With oItem
            .cSort = txtcSort.Text
            .cTitle = txtcTitle.Text
            .cDescription = txtcDescription.Text
            '.Status = txtStatus.Text
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Coupon Item" Then
                .cNum = lblCouponsNum.Text
            End If
        End With

        If SaveButton.Text = "Update Coupon Item" Then
            Rslt = DAL_Coupons.ModCoupons(oItem)
            txtcSort.Text = ""
            txtcTitle.Text = ""
            txtcDescription.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            'FreeTextBox1.Text = ""
            'txtStatus.Text = "Active"
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            SaveButton.Text = "Add Coupon Item"
        Else
            Rslt = DAL_Coupons.AddCoupons(oItem)
            txtcSort.Text = ""
            txtcTitle.Text = ""
            txtcDescription.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            'FreeTextBox1.Text = ""
            'txtStatus.Text = "Active"
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            SaveButton.Text = "Add Coupons Item"
        End If
			Response.Redirect("/ADMIN/ADMIN_Coupons.aspx")
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
