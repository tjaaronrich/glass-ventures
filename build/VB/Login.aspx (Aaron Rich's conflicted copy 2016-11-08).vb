
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

			If Len(Server.HtmlDecode(Request.QueryString("URL"))) > 0 Then

				Dim URL As String = Request.QueryString("URL")
				Dim currentURL As String = ""
		
				lblURL.Text = URL.ToString
				currentURL = URL.ToString

			End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim User As New PC_Account
        Dim Rslt As Integer = 0

        Dim iUser As New PC_Account

        With User
            .uName = txtUserName.Text
            .passWord = txtPassword.Text
        End With

        Session("LoggedIn") = 0

        Rslt = DAL_Account.AccountLogin(User)

        If Rslt = 1 Then

            Session("LoggedIn") = 1

            iUser = DAL_Account.GetAccountByuName(User.uName)

            With iUser
                Session("UserName") = .uName
                Session("UserAcctNum") = .acctNum
                'accessLevel is the session variable name used in most of our commercial apps
                Session("accessLevel") = .PermissionLevel
                Session("FullName") = .FullName
            End With


            'redirect 
			If Session("accessLevel") < 1 then
				Response.Redirect("AccessDenied.aspx")
			Else If Session("accessLevel") = 9 then 
				Response.Redirect("Staff-Portal.aspx")
			Else If Session("accessLevel") > 1 then 
				If Len(lblURL.Text) > 3 Then
					Response.Redirect("admin/" & lblURL.Text)
				Else
					Response.Redirect("admin/")
				End If
			Else Response.Redirect("admin/default.aspx")
			End If


        Else
            'lblErrorMsg.Text = "ERROR: Please try again. If problem persists, contact administrator."
            Session("accessLevel") = 0
            Response.Redirect("AccessDenied.aspx")
        End If

    End Sub
End Class
