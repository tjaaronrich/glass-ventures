Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Partial Class Login
    Inherits System.Web.UI.Page

	
	Public Test As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	
	
	
		'If you want to hide the .aspx extension you must invoke the default button on Page Load
		Dim myButton As Button = DirectCast(FindControl("Button1"), Button)
		'Page.Form.DefaultButton = myButton.UniqueID
		'---------------------------------------------------------------------------------------
		
		
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
		
		Dim strGUID As String = Guid.NewGuid().ToString()
        Dim User As New PC_Account
        Dim Rslt As Integer = 0

        Dim iUser As New PC_Account

        With User
			.uName = txtUserName.Value
            .passWord = txtPassword.Value
        End With

        Session("LoggedIn") = 0

Rslt = DAL_Account.MD5AccountLogin(User)

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
			If Session("accessLevel") = 1 Then


        
				Dim myDateString as String = DateTime.Now.AddHours(+2).ToString()
				Dim myDate as DateTime
				DateTime.TryParse(myDateString, myDate).ToString()
        

				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String
        
				
       
				Try


					sQueryString = "INSERT INTO tblactivity " & _
					"(Title, " & _
					"ItemDate, " & _
					"user, " & _
					"userID, " & _
					"guid, " & _
					"action)" & _
					" VALUES " & _
					"('" & Replace("CMS Login", "'", "''") & _
					"', '" & Replace(myDate.ToString("yyyy/MM/dd HH:mm:ss"), "'", "''") & _
					"', '" & Replace(Session("FullName"), "'", "''") & _
					"', '" & Replace(Session("UserAcctNum"), "'", "''") & _
					"', '" & Replace(strGUID, "'", "''") & _
					"', '" & Replace("Login", "'", "''") & "')"

					odbcConn.Open()
					Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
					DBCommand.ExecuteNonQuery()

					odbcConn.Close()

				Catch ex As Exception

					odbcConn.Close()
					odbcConn.Dispose()

				End Try


			End If



			If Session("accessLevel") < 1 then
				Response.Redirect("/AccessDenied")
			Else If Session("accessLevel") = 9 then 
				Response.Redirect("Staff-Portal-Documents.aspx")
			Else If Session("accessLevel") > 1 then 
				If Len(lblURL.Text) > 3 Then
			Response.Redirect("/accessdenied" & lblURL.Text)
				Else
			Response.Redirect("/accessdenied")
				End If
			Else
				Response.Redirect("/owner-default")
			End If


        Else
            'lblErrorMsg.Text = "ERROR: Please try again. If problem persists, contact administrator."
            Session("accessLevel") = 0
	'Test = Rslt
            'Response.Redirect("AccessDenied.aspx")
			
        End If

    End Sub
End Class
