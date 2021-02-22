Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class ADMIN_TestimonialsAdd
    Inherits System.Web.UI.Page

	
	Public strGUID As String = Guid.NewGuid().ToString()
	
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then 

        Dim sortmax As Integer = 0

			If Len(Server.HtmlDecode(Request.QueryString("tNum"))) > 0 Then

				Dim tNum As Integer = Request.QueryString("tNum")
				Dim currentStatus As String = ""
		
				lblTestimonialsNum.Text = tNum.ToString
		
				Dim oItem As New PC_Testimonials
		
				oItem = DAL_Testimonials.GetTestimonialsByNum(tNum)
		
				With oItem
					txttDescription.Text = .tDescription
					txtfullName.Text = .fullName
					'txtTitle.Text = .Title
					'txtURL.Text = .URL
					txtCity.Text = .City
					txttSort.Text = .tSort
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

                sortmax = DAL_Testimonials.GetMaxSortNumber()
                sortmax = sortmax + 1
                txttSort.Text = sortmax.ToString
			
			End If

        End If

    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_Testimonials
        Dim Rslt As Integer = 0
        'Dim sRslt As String = ""

        With oItem
            .tDescription = txttDescription.Text
            .fullName = txtfullName.Text
            '.Title = txtTitle.Text
            '.URL = txtURL.Text
            .City = txtCity.Text
            .tSort = txttSort.Text
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Item" Then
                .tNum = lblTestimonialsNum.Text
            End If


        If SaveButton.Text = "Update Item" Then
            Rslt = DAL_Testimonials.ModTestimonials(oItem)
            txttDescription.Text = ""
            txtfullName.Text = ""
           ' txtTitle.Text = ""
            'txtURL.Text = ""
            txtCity.Text = ""
            txttSort.Text = ""
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            pnlStatus2.Visible = False
            SaveButton.Text = "Add Item"
        Else
            Rslt = DAL_Testimonials.AddTestimonials(oItem)
            txttDescription.Text = ""
            txtfullName.Text = ""
            'txtTitle.Text = ""
            'txtURL.Text = ""
            txtCity.Text = ""
            txttSort.Text = ""
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            pnlStatus2.Visible = False
            SaveButton.Text = "Add Item"
        End If
        End With
			'lblError.text = sRslt
Response.Redirect("testimonials.aspx") 

    End Sub

End Class
