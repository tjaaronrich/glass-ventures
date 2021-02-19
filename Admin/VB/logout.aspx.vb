Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web

Partial Class FTBox2
    Inherits System.Web.UI.Page
	
	Protected Sub btnSubmit_ServerClick(sender As Object, e As EventArgs) 
        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "none", "<script>alert('test');</script>", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
			'userName.innerHtml = "Test"
			
			
			'Dim label1 As Label = TryCast(Me.Parent.FindControl("userNameTopNav"), Label)
			'Label label1 = Parent.FindControl("userNameTopNav") As Label
			'lblOut.Text = DirectCast(Session("accessLevel"), Integer)
			
			
				Dim strGUID As String = Guid.NewGuid().ToString()
			
			
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
					"('" & Replace("CMS Logout", "'", "''") & _
					"', '" & Replace(myDate.ToString("yyyy/MM/dd HH:mm:ss"), "'", "''") & _
					"', '" & Replace(Session("FullName"), "'", "''") & _
					"', '" & Replace(Session("UserAcctNum"), "'", "''") & _
					"', '" & Replace(strGUID, "'", "''") & _
					"', '" & Replace("Logout", "'", "''") & "')"

					odbcConn.Open()
					Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
					DBCommand.ExecuteNonQuery()

					odbcConn.Close()

				Catch ex As Exception

					odbcConn.Close()
					odbcConn.Dispose()

				End Try
			
			
			
			
			
			
			
			
			
			Session.Remove("accessLevel")
			Response.Redirect("/login.aspx", True)

        End If

    End Sub

End Class
