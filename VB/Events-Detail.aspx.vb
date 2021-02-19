Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI.HtmlControls
Imports System.Net
Imports System.Net.Mail
Imports ComponentArt
Imports ComponentArt.Web
Imports ComponentArt.Web.UI



Public Class EventsDetail 
Inherits System.Web.UI.Page

Protected lblTitle As Label
Protected lblPageTitle As Label
Protected lblMetaTitle As Label
Protected lblItemDate As Label
Protected lblEndDate As Label
Protected lblContent As Label
Protected lblMetaDescription As Label
Protected lblSummary As Label
Protected lblMailTo As Label
Protected lblAuthor As Label
Protected lblFacebook As Label
Protected lblTwitter As Label
Protected lblImageFile As Label
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
Public FeaturedImage As String
Public PageTitleStr As String
Public PageDescriptionStr As String
Public StartEndTime As String
Public StartTime As String
Public EndTime As String
Public Location As String
Public ContactNumber As String
Public Website As String
Public ImageCheck As String


  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then

If Len(Server.HtmlDecode(Request.QueryString("cNum"))) > 0 Then

Dim cNum As Integer = Request.QueryString("cNum")
Dim currentStatus As String = ""

Dim oItem As New PC_Calendar

oItem = DAL_Calendar2.GetCalendarEventByNum(cNum)

With oItem
ImageCheck = .fileName
FeaturedImage = "/Documents/Calendar2Files/" & .fileName

				PageTitleStr = .Title & " | The Summerhouse"
PageDescriptionStr = .Description
lblTitle.Text = .Title
'lblSummary.Text = .Summary 
'lblAuthor.Text = .Author 
lblItemDate.Text = .StartDate
'lblEndDate.Text = .EndDate
lblContent.Text = .Description 
Location = .Location
ContactNumber = .ContactNumber
StartTime = .StartTime
EndTime = .EndTime
'Website = .Website
StartEndTime = .StartTime & "/" & .EndTime

lblImageFile.Text = "<a href='Documents/Calendar2Files/" & .fileName & "' target='_blank'><img alt='click to enlarge' style='border-width:0px' width='575' src='Documents/Calendar2Files/" & .fileName & "' align='left'></a>"

'Page.Title = .Title
'Dim pagetitle As New HtmlMeta()
'pagetitle.Name = "Title"
'pagetitle.Content = .Title 
'Header.Controls.Add(pagetitle)
'Dim pagedesc As New HtmlMeta()
'pagedesc.Name = "Description"
'pagedesc.Content = .Description 
'Header.Controls.Add(pagedesc)
End With


Else

Response.Redirect("/events")

End If

End If

  End Sub 




Public Function GetPageTitle() As String

Return PageTitleStr

End Function

Public Function GetPageTitleMeta As String

Return WebUtility.HtmlDecode("<META NAME=""TITLE"" content=""" & PageTitleStr & """>")

End Function



Public Function GetPageDescriptionMeta As String

Return WebUtility.HtmlDecode("<META NAME=""DESCRIPTION"" content=""" & PageDescriptionStr & """>")

End Function



End Class
