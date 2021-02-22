Imports Microsoft.VisualBasic

Imports System.Configuration

Imports System.Data

Imports System.Data.Odbc

Imports System.Data.SqlClient

Imports System.Collections.Generic



Partial Class Admin_Links

    Inherits System.Web.UI.Page



	

	

	

	Public newDate As String

	Public strGUID As String = Guid.NewGuid().ToString()

	

	

	

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not Page.IsPostBack Then



        Dim sortmax As Integer = 0



			If Len(Server.HtmlDecode(Request.QueryString("linkNum"))) > 0 Then



				Dim linkNum As Integer = Request.QueryString("linkNum")

				Dim currentCategory As String = ""

				'Dim ddlList As String = ddllinkCategory.SelectedItem.Value()

		

				lbllinkNum.Text = linkNum.ToString

		

				Dim oItem As New PC_Links

		

				oItem = DAL_Links.GetLinksByNum(linkNum)

		

				With oItem

					txtlinkName.Text = .linkName

					currentCategory = .linkCategory

					txtURL.Text = .URL

					txtlinkDescription.Text = .linkDescription

					'ddllinkCategory.SelectedValue = ddlList

					'ddllinkCategory.SelectedIndex = ddllinkCategory.Items.IndexOf(ddllinkCategory.Items.FindByValue(.linkCategory))					

					ddlCategory.SelectedValue = currentCategory

					txtlinkSort.Text = .linkSort

					'txtStatus.Text = .Status

				End With

		

				'set dropdownlist selection

				'If currentStatus = "Active" Then

				'	ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))

				'Else

				'	ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))

				'End If

				'pnlStatus.Visible = True

		

				SaveButton.Text = "Update Link Item"



			Else 



                sortmax = DAL_Links.GetMaxSortNumber()

                'lblPriorMaxSortNum.Text = sortmax.ToString

                'for an add, assign next sort number as the default

                sortmax = sortmax + 1

                txtlinkSort.Text = sortmax.ToString

                'lblCurrentSortForEdit.Text = "0"



			End If



        End If



    End Sub



    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click



        Dim oItem As New PC_Links

        Dim Rslt As Integer



        With oItem

            .linkName = txtlinkName.Text

            '.linkCategory = txtquestion.Text

            .URL = txtURL.Text

            .linkDescription = txtlinkDescription.Text

            .linkSort = txtlinkSort.Text

           '.Status = txtStatus.Text

            .linkCategory = ddlCategory.SelectedValue

            If SaveButton.Text = "Update Link Item" Then

                .linkNum = lbllinkNum.Text

            End If

        End With



        If SaveButton.Text = "Update Link Item" Then

            Rslt = DAL_Links.ModLinks(oItem)

            txtlinkName.Text = ""

            txtURL.Text = ""

            txtlinkDescription.Text = ""

            txtlinkSort.Text = ""

            'ddllinkCategory.SelectedIndex = ddllinkCategory.SelectedValue

            ddllinkCategory.SelectedIndex = ddllinkCategory.Items.IndexOf(ddllinkCategory.Items.FindByValue("Business Development"))

            'pnlStatus.Visible = True

            SaveButton.Text = "Update Link Item"

        Else

            Rslt = DAL_Links.AddLinks(oItem)

            txtlinkName.Text = ""

            txtURL.Text = ""

            txtlinkDescription.Text = ""

            txtlinkSort.Text = ""

            ddllinkCategory.SelectedIndex = ddllinkCategory.Items.IndexOf(ddllinkCategory.Items.FindByValue("Business Development"))

            'pnlStatus.Visible = True

            SaveButton.Text = "Add Link Item"

        End If

			Response.Redirect("links.aspx")

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

