Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.DateTime
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Partial Class SiteForm

    Inherits System.Web.UI.Page

	Protected Sub ddlType_SelectedIndexChanged(sender As Object, e As EventArgs)
		Dim selectedType = ddlType.SelectedItem.Text
	
		If ddlType.SelectedItem.Text = "General Success Story Recommendation" Then
			pnlA.Visible = True
			pnlB.Visible = False
			pnlC.Visible = False
			pnlSubmit.Visible = True
		Else If ddlType.SelectedItem.Text = "I Found a Job" Then
			pnlA.Visible = False
			pnlB.Visible = True
			pnlC.Visible = False
			pnlSubmit.Visible = True
		Else If ddlType.SelectedItem.Text = "The WorkForce Board Helped My Company" Then
			pnlA.Visible = False
			pnlB.Visible = False
			pnlC.Visible = True
			pnlSubmit.Visible = True
		Else
			pnlA.Visible = False
			pnlB.Visible = False
			pnlC.Visible = False
			pnlSubmit.Visible = False
			lblType.text = "You must select an option."
			Exit Sub
		End If
	End Sub

End Class
