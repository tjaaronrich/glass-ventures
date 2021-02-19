Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc 
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class YourAttractionListing
    Inherits System.Web.UI.Page

Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If Not Page.IsPostBack Then
		ODS_Property.SelectParameters.Add(New Parameter("pLinkId", TypeCode.[String], Session("UserAcctNum").ToString()))
	End If
End Sub




    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim pID As Integer = GridView1.SelectedValue
		Response.Redirect("Your-Attraction-ListingAdd.aspx?pID=" & pID.toString)

    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging

    End Sub
End Class
