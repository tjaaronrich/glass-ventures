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

Public Class NewsDetail 
	Inherits System.Web.UI.Page

  'Protected lblMobile As Label
  Protected lblTitle As Label
  Protected lblPageTitle As Label
  Protected lblMetaTitle As Label
  Protected lblItemDate As Label
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

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("nNum"))) > 0 Then

				Dim nNum As Integer = Request.QueryString("nNum")
				Dim currentStatus As String = ""
		
				Dim oItem As New PC_NewsFTB
		
				oItem = DAL_NewsFTB.GetNewsByNum(nNum)
		
				With oItem
					lblTitle.Text = .Title
					'lblSummary.Text = .Summary 
					'lblAuthor.Text = .Author 
					lblItemDate.Text = .ItemDate
					lblContent.Text = .content 
					lblTwitter.Text = "<a href='https://twitter.com/share' class='twitter-share-button' data-url='http://www.careersourcegc.com/Newsroom-News-Detail.aspx?nNum=" & .nNum & "' data-via='careerslourcegc' data-text='" & .Title & "'>Tweet</a><script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src='//platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document,'script','twitter-wjs');</script>"
					lblFacebook.Text = "<div class='fb-like' data-href='http://www.careersourcegc.com/Newsroom-News-Detail.aspx?nNum=" & .nNum & "' data-send='false' data-layout='button_count' data-width='100' data-show-faces='false' data-font='tahoma'></div>"
					lblMailTo.Text = "<a class='black' href='mailto:?body=Take a look at this blog article I found at CareerSource Gulf Coast, " & .Title & ". You can read it at: http://www.careersourcegc.com/Newsroom-News-Detail.aspx?nNum=" & .nNum & "' class='Black'>Email Story</a>"
					lblImageFile.Text = "<a href='Documents/News/" & .ImageFile & "' target='_blank'><img alt='click to enlarge' style='border-width:0px' width='575' src='Documents/News/Thumbs/" & .ImageFile & "' align='left'></a>"
					
					Page.Title = .Title
					Dim pagetitle As New HtmlMeta()
					pagetitle.Name = "Title"
					pagetitle.Content = .Title 
					Header.Controls.Add(pagetitle)
					Dim pagedesc As New HtmlMeta()
					pagedesc.Name = "Description"
					pagedesc.Content = .Summary 
					Header.Controls.Add(pagedesc)
				End With
		
			End If

	End If

  End Sub 

End Class
