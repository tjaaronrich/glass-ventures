Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_EditPhoto
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Dim PermissionLevel As Integer = 0
If Not Page.IsPostBack Then

        lblErrorMsg.Text = ""


        If Session("UserID") <> "0" Then


            'AEmode = Server.HtmlDecode(Request.QueryString("mode"))
            lblMode.Text = "edit"
            lblphotoID.Text = Server.HtmlDecode(Request.QueryString("photoID"))


            If lblphotoID.Text <> "0" Then
                Dim oItem As New PC_Gallery

                oItem = DAL_Gallery.GetImageInfoByID(lblphotoID.Text)

                With oItem
                    txtName.Text = .photoName
                    lblFileName.Text = .ImageFile
                    ddlGallery.SelectedValue = .pgID
                    ddlStatus.SelectedValue = .photoStatus
                    'lblErrorMsg.Text = .photoName & ", " & .ImageFile & ", " & .pgID & ", " & .pgName & ", " & .photoStatus
                End With

            End If


        End If
	
End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click

        Dim Rslt As Integer = 0
        Dim PicName As String
        Dim GalNum As String
        Dim oItem As New PC_Gallery

        With oItem
            PicName = txtName.Text
            GalNum = ddlGallery.SelectedValue
        End With

        Try
		
        Rslt = DAL_Gallery.ModifyPhoto(lblphotoID.Text, PicName, GalNum, ddlGallery.SelectedItem.Text, ddlStatus.SelectedValue)
        'Rslt = DAL_Gallery.ModifyPhoto(lblphotoID.Text, txtName.Text, ddlGallery.SelectedValue, ddlGallery.SelectedItem.Text, ddlStatus.SelectedValue)
                        
		Catch ex As Exception
		
		lblErrorMsg.Text = "ERROR! Update failed."
		Exit Sub
        End Try

        'lblErrorMsg.Text = lblphotoID.Text & txtName.Text & ddlGallery.SelectedValue & ddlGallery.SelectedItem.Text & ddlStatus.SelectedValue
		If Rslt = 1 Then
			Response.Redirect("Gallery.aspx")
		End If
        

    End Sub
End Class
