Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Diagnostics


Public Class SiteMaster
    Inherits MasterPage
    Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Private _antiXsrfTokenValue As String
	Public beforeBody As String
	Public afterBody As String

    Protected Sub Page_Init(sender As Object, e As EventArgs)
        ' The code below helps to protect against XSRF attacks
        Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With { _
                 .HttpOnly = True, _
                 .Value = _antiXsrfTokenValue _
            }
            If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
                responseCookie.Secure = True
            End If
            Response.Cookies.[Set](responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Protected Sub master_Page_PreLoad(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            ' Set Anti-XSRF token
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, [String].Empty)
        Else
            ' Validate the Anti-XSRF token
            If DirectCast(ViewState(AntiXsrfTokenKey), String) <> _antiXsrfTokenValue OrElse DirectCast(ViewState(AntiXsrfUserNameKey), String) <> (If(Context.User.Identity.Name, [String].Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		
				
		beforeBody = GetOptionByNum("1")
		afterBody = GetOptionByNum("2")
				
				
    End Sub
			
			
	Public Shared Function GetOptionByNum(ftbNum As String) As String

		Dim oItem As String

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
			Dim sQueryString As String = "SELECT * FROM tbloptions WHERE option_id = " & ftbNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

					oItem = odbcReader("option_value").ToString() 

                End If

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oItem

    End Function
			
			
			
			

    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        'Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
    End Sub

End Class