Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_GalleryMaintenanceCategories
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

        End If

    End Sub

    Protected Sub ddlGallery_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGallery.SelectedIndexChanged

        Dim oItem As New PC_PhotoGalleryCategories

        'lblErrorMsg.Text = ddlGallery.SelectedItem.Value()
        oItem = DAL_Gallery-Categories.GetGalleryByID(ddlGallery.SelectedItem.Value())

        With oItem
            lblpgID.Text = .pgID
            txtpgName.Text = .pgName
            lblpgName.Text = .pgName
            ddlStatus.SelectedValue = .pgStatus
            'ddlCategory.SelectedValue = .pgYear
            'lblErrorMsg.Text = .pgStatus
        End With

    End Sub

    Protected Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click

        Dim oItem As New PC_PhotoGalleryCategories
        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0

        If Len(txtpgName.Text) > 3 Then
            Rslt = DAL_Gallery-Categories.ModifyPhotoGallery(txtpgName.Text, "NO", ddlCategory.SelectedItem.Value, ddlStatus.SelectedItem.Value, lblpgID.Text)
            Rslt2 = DAL_Gallery-Categories.ModifyGalleryNameInPhotoTable(lblpgID.Text, txtpgName.Text)
        Else
            lblErrorMsg.Text = "ERROR: Gallery Name is too short."
            Exit Sub
        End If

        Response.Redirect("ADMIN_Gallery.aspx")

    End Sub

    Protected Sub btnArchive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnArchive.Click

        Dim Rslt As Integer = 0

        Rslt = DAL_Gallery-Categories.ArchivePhotoGallery(lblpgID.Text, lblpgName.Text)

        Response.Redirect("ADMIN_Gallery.aspx")

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim Rslt As Integer = 0

        Rslt = DAL_Gallery-Categories.DeletePhotoGallery(lblpgID.Text, lblpgName.Text)

        Response.Redirect("ADMIN_Gallery.aspx")

    End Sub

End Class
