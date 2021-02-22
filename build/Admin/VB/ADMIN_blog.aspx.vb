Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class ADMIN_blog
    Inherits System.Web.UI.Page

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim nNum As Integer = GridView1.SelectedValue
		Response.Redirect("ADMIN_blogadd.aspx?nNum=" & nNum.toString)
        'Dim currentStatus As String = ""

        'lblBlogNum.Text = nNum.ToString

        'Dim oItem As New PC_NewsFTB

        'oItem = DAL_NewsFTB.GetNewsByNum(nNum)

        'With oItem
            'txtTitle.Text = .Title
            'txtSummary.Text = .Summary
            'clndrHeadlineDate.SelectedDate = .ItemDate
            'FreeTextBox1.Text = .content
            ''''''txtStatus.Text = .Status
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

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging

    End Sub
End Class
