Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_GalleryMaintenance
    Inherits System.Web.UI.Page
	Public test As String
	
	
	
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

        End If

    End Sub

    Protected Sub ddlGallery_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGallery.SelectedIndexChanged

        Dim oItem As New PC_PhotoGallery
		Try 
			
			
			test += "s"
			oItem = DAL_Gallery.GetGalleryByID(ddlGallery.SelectedItem.Value())

			With oItem
				lblpgID.Text = .pgID
				txtpgName.Text = .pgName
				lblpgName.Text = .pgName
				ddlStatus.SelectedValue = .pgStatus
				'lblErrorMsg.Text = .pgStatus
			End With
		Catch ex As Exception
			test += ex.ToString()
		End Try
        'lblErrorMsg.Text = ddlGallery.SelectedItem.Value()
        

    End Sub

    Protected Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click

        Dim oItem As New PC_PhotoGallery
        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0

        If Len(txtpgName.Text) > 3 Then
            Rslt = DAL_Gallery.ModifyPhotoGallery(lblpgID.Text, txtpgName.Text, "NO", ddlStatus.SelectedItem.Value)
            Rslt2 = DAL_Gallery.ModifyGalleryNameInPhotoTable(lblpgID.Text, txtpgName.Text)
        Else
            lblErrorMsg.Text = "ERROR: Gallery Name is too short."
            Exit Sub
        End If

        Response.Redirect("Gallery.aspx")

    End Sub

    Protected Sub btnArchive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnArchive.Click

        Dim Rslt As Integer = 0

        Rslt = DAL_Gallery.ArchivePhotoGallery(lblpgID.Text, lblpgName.Text)

        Response.Redirect("Gallery.aspx")

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim Rslt As Integer = 0

        Rslt = DAL_Gallery.DeletePhotoGallery(lblpgID.Text, lblpgName.Text)

        Response.Redirect("Gallery.aspx")

    End Sub

End Class
