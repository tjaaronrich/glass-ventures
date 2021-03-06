Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data 
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic 
Imports System.Net
Imports System.Net.Mail
Imports ComponentArt
Imports ComponentArt.Web
Imports ComponentArt.Web.UI
 
Public Class Events 
'Partial Class Calendar_ChamberEvents
    Inherits System.Web.UI.Page

  Protected WithEvents Rotator1 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorBannerAd1 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorBannerAd2 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorColumnAd1 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorColumnAd2 As ComponentArt.Web.UI.Rotator 
  Protected WithEvents btnSearch As Button
  Protected WithEvents btnSearch2 As Button
  Protected WithEvents txtFind As TextBox
  Protected lblTitleFind As Label
  Protected lblMo As Label
  Protected lblYr As Label
  Protected lblStartDate As Label
  Protected lblEndDate As Label
  Protected lblErrorMsg As Label
  Protected lblClickthroughAdd As Label
  Protected lblClickthroughAddTEST As Label
  Protected WithEvents txtClickthroughAdd As TextBox
  Protected pnlRotator1 As Panel
  Protected pnlRotator2 As Panel
  Protected pnlRotatorColumn1 As Panel
  Protected pnlRotatorColumn2 As Panel
  Protected WithEvents InvisibleButton As Button
  Protected WithEvents InvisibleColumnButton As Button
  Protected ddlMonth As DropDownList
  Protected ddlYear As DropDownList
  Protected WithEvents GridView1 As System.Web.UI.WebControls.GridView

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    	If Not IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("Title"))) > 0 Then

				Dim Title As String = Request.QueryString("Title")
				Dim currentName As String = ""
		
				lblTitleFind.Text = Title.ToString
				currentName = Title.ToString
								
		End If

    End Sub

    Protected Sub SearchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch2.Click

        'Dim oItem As New PC_Calendar2
        Dim Rslt As Integer
        Dim SearchName As String

        'With oItem
		SearchName = txtFind.text
        'End With

        'Rslt = DAL_Pets.GetActivePetsListByName(SearchName)

        Response.Redirect("Events_SearchResults.aspx?Title=" & SearchName)

    End Sub

    Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim sMo As String = ""
        Dim sYr As String = ""
        lblYr.Text = DateTime.Now.Year.ToString
        lblStartDate.Text = "ALL"
        lblEndDate.Text = "ALL"

        sMo = ddlMonth.SelectedItem.Value()
        lblYr.Text = ddlYear.SelectedItem.Value()
        If sMo = "January" Then
            lblMo.Text = "01"
        End If
        If sMo = "February" Then
            lblMo.Text = "02"
        End If
        If sMo = "March" Then
            lblMo.Text = "03"
        End If
        If sMo = "April" Then
            lblMo.Text = "04"
        End If
        If sMo = "May" Then
            lblMo.Text = "05"
        End If
        If sMo = "June" Then
            lblMo.Text = "06"
        End If
        If sMo = "July" Then
            lblMo.Text = "07"
        End If
        If sMo = "August" Then
            lblMo.Text = "08"
        End If
        If sMo = "September" Then
            lblMo.Text = "09"
        End If
        If sMo = "October" Then
            lblMo.Text = "10"
        End If
        If sMo = "November" Then
            lblMo.Text = "11"
        End If
        If sMo = "December" Then
            lblMo.Text = "12"
        End If
        If sMo = "ALL" Then
            lblMo.Text = "ALL"
        End If

        If lblMo.Text <> "ALL" And lblYr.Text <> "ALL" Then
            If Len(lblMo.Text) < 2 Or lblMo.Text = "Month" Or Len(lblYr.Text) < 3 Or lblYr.Text = "Year" Then
                lblStartDate.Text = "ALL"
                lblEndDate.Text = "ALL"
            Else
                lblStartDate.Text = lblYr.Text & "/" & lblMo.Text & "/" & "01"
                lblEndDate.Text = lblYr.Text & "/" & lblMo.Text & "/" & "31"
            End If
        Else
            lblStartDate.Text = "ALL"
            lblEndDate.Text = "ALL"
        End If

        GridView1.DataBind()

    End Sub

End Class
