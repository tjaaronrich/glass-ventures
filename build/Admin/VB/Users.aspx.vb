Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class ADMIN_Users
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Session("accessLevel") < 1 Then
			Response.Redirect("../AccessDenied.aspx?URL=Default.aspx")
			
		Else If Session("accessLevel") Is Nothing Then
			Response.Redirect("../AccessDenied.aspx?URL=Default.aspx")
		End If
		
		ODS_Account.SelectParameters.Remove(ODS_Account.SelectParameters("pLinkId"))
			ODS_Account.SelectParameters.Add(New Parameter("pLinkId", TypeCode.[String], Session("UserAcctNum").ToString()))
		


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim acctNum As Integer = GridView1.SelectedValue
        Response.Redirect("ADMIN_UserAdd.aspx?mode=edit&acctNum=" & acctNum.ToString)
    End Sub


	
	
	
	
	
	
	
	
Private Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating

        Dim FileUpload0 As FileUpload = CType(Me.GridView1.Rows(e.RowIndex).FindControl("FileUpload0"), FileUpload)
		If FileUpload0.HasFile
			Dim cnt As Integer
			Dim Rslt As Integer
	
			Dim Img As Image
			Dim ThumbSize As Size
			Dim Thumb As Bitmap
	
			Dim Img2 As Image
			Dim ThumbSize2 As Size
			Dim Thumb2 As Bitmap
		  
			' Then
			'    Dim path As String = Server.MapPath("../img/ads/" + fFileAttachment.FileName)
				' grant Write permission to the ASP.NET process account 
				' for the Images subdirectory. 
			'    FileUpload0.SaveAs(path)
			'End If
	
	
	
			FileUpload0.SaveAs(Server.MapPath("..\Documents\Accounts") & "\" & FileUpload0.FileName)
			Img = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Accounts") & "\" & FileUpload0.FileName)
			Img2 = System.Drawing.Image.FromFile(Server.MapPath("..\Documents\Accounts") & "\" & FileUpload0.FileName)
	
	
			ThumbSize = ThumbNailSize(Img.Height, Img.Width, 200, "W")
	
			'new thumbnail code
			Dim NewThumb As New Bitmap(ThumbSize.Width, ThumbSize.Height)
			Dim thumbImg As Graphics
			thumbImg = Graphics.FromImage(NewThumb)
			thumbImg.CompositingQuality = CompositingQuality.HighQuality
			thumbImg.SmoothingMode = SmoothingMode.HighQuality
			thumbImg.InterpolationMode = InterpolationMode.HighQualityBicubic
	
			Dim imgRectangle As New Rectangle(0, 0, ThumbSize.Width, ThumbSize.Height)
			thumbImg.DrawImage(Img, imgRectangle)
	
			NewThumb.Save(Server.MapPath("..\Documents\Accounts\Thumbs") & "\" & FileUpload0.FileName)
	
	
			ThumbSize2 = ThumbNailSize2(Img2.Height, Img2.Width, 500, "W")
	
			'new thumbnail code
			Dim NewThumb2 As New Bitmap(ThumbSize2.Width, ThumbSize2.Height)
			Dim thumbImg2 As Graphics
			thumbImg2 = Graphics.FromImage(NewThumb2)
			thumbImg2.CompositingQuality = CompositingQuality.HighQuality  
			thumbImg2.SmoothingMode = SmoothingMode.HighQuality  
			thumbImg2.InterpolationMode = InterpolationMode.HighQualityBicubic  
	
			Dim imgRectangle2 As New Rectangle(0, 0, ThumbSize2.Width, ThumbSize2.Height)
			thumbImg2.DrawImage(Img2, imgRectangle2)
	
			NewThumb2.Save(Server.MapPath("..\Documents\Accounts\BigThumbs") & "\" & FileUpload0.FileName)
 		End If
End Sub
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
		
    Public Shared Function ThumbNailSize(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

        'NewSizeOrientation: 
        '   H = make height the NewSize, let width scale accordingly
        '   W = make width the NewSize, let height scale accordingly
        '   D = default - make the current largest dimension the NewSize

        Dim ReSize As Size
        Dim TempVal As Double

        ReSize = New Size(OrigW, OrigH)

        If OrigH > NewSize And OrigW > NewSize Then

            If NewSizeOrientation = "D" Then
                If OrigH > OrigW Then
                    TempVal = NewSize / Convert.ToDouble(OrigH)
                Else
                    TempVal = NewSize / Convert.ToDouble(OrigW)
                End If
            End If

            If NewSizeOrientation = "W" Then
                TempVal = NewSize / Convert.ToDouble(OrigW)
            End If

            If NewSizeOrientation = "H" Then
                TempVal = NewSize / Convert.ToDouble(OrigH)
            End If

            ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))

        Else    'one or both dimensions is less than NewSize

            If OrigH > NewSize And NewSizeOrientation = "H" Then
                TempVal = NewSize / Convert.ToDouble(OrigH)
                ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))
            End If

            If OrigW > NewSize And NewSizeOrientation = "W" Then
                TempVal = NewSize / Convert.ToDouble(OrigW)
                ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))
            End If

        End If

        Return ReSize

    End Function

    Public Shared Function ThumbNailSize2(ByVal OrigH As Integer, ByVal OrigW As Integer, ByVal NewSize As Double, ByVal NewSizeOrientation As String)

        'NewSizeOrientation: 
        '   H = make height the NewSize, let width scale accordingly
        '   W = make width the NewSize, let height scale accordingly
        '   D = default - make the current largest dimension the NewSize

        Dim ReSize As Size
        Dim TempVal As Double

        ReSize = New Size(OrigW, OrigH)

        If OrigH > NewSize And OrigW > NewSize Then

            If NewSizeOrientation = "D" Then
                If OrigH > OrigW Then
                    TempVal = NewSize / Convert.ToDouble(OrigH)
                Else
                    TempVal = NewSize / Convert.ToDouble(OrigW)
                End If
            End If

            If NewSizeOrientation = "W" Then
                TempVal = NewSize / Convert.ToDouble(OrigW)
            End If

            If NewSizeOrientation = "H" Then
                TempVal = NewSize / Convert.ToDouble(OrigH)
            End If

            ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))

        Else    'one or both dimensions is less than NewSize

            If OrigH > NewSize And NewSizeOrientation = "H" Then
                TempVal = NewSize / Convert.ToDouble(OrigH)
                ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))
            End If

            If OrigW > NewSize And NewSizeOrientation = "W" Then
                TempVal = NewSize / Convert.ToDouble(OrigW)
                ReSize = New Size(Convert.ToInt32(TempVal * OrigW), Convert.ToInt32(TempVal * OrigH))
            End If

        End If

        Return ReSize

    End Function
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
End Class
