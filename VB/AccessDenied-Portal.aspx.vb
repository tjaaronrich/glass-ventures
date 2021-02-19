
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("URL"))) > 0 Then

				Dim URL As String = Request.QueryString("URL")
				Dim currentURL As String = ""
		
				lblURL.Text = URL.ToString
				currentURL = URL.ToString
				lblLoginLink.Text = "<a href='Login-Portal.aspx?URL=" & URL.ToString & "'>login</a>"
				

			Else 

				lblLoginLink.Text = "<a href='Login-Portal.aspx'>login</a>"
			
			End If

        End If

    End Sub

End Class
