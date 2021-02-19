Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web

Partial Class Index
    Inherits System.Web.UI.Page
	Public recentActivity As String
	Public CmsEvents As String
	Protected Sub btnSubmit_ServerClick(sender As Object, e As EventArgs) 
        ScriptManager.RegisterClientScriptBlock(Me, [GetType](), "none", "<script>alert('test');</script>", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
			'userName.innerHtml = "Test"
			
			
			'Dim label1 As Label = TryCast(Me.Parent.FindControl("userNameTopNav"), Label)
			'Label label1 = Parent.FindControl("userNameTopNav") As Label
			'lblOut.Text = DirectCast(Session("accessLevel"), Integer)
			Try

                Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

				Dim sQueryString As String = "SELECT * FROM tblactivity ORDER by nNum DESC LIMIT 5"

                Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
                odbcConn.Open()

                Try

                    Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
                    recentActivity +=  "<thead><tr><th>Title</th><th>Action</th><th>User</th></tr></thead><tbody>"
					While odbcReader.Read()

						
						
						
						

						recentActivity += "<tr><td>" & Trim(odbcReader("Title").ToString) & "</td><td>" & Trim(odbcReader("action").ToString) & "</td><td>" & Trim(odbcReader("user").ToString) & "</td></tr>"



						
						
		

					End While
					
					recentActivity += "</tbody>"
                    'lblOut.Text = odbcReader("content").ToString()

                    odbcReader.Close()

                Catch ex As Exception

                    odbcConn.Close()

                End Try

                odbcConn.Close()

            Catch ex As Exception

            End Try
			
			
			
			
			
			
			Try

                Dim sConnString As String = ConfigurationManager.ConnectionStrings("CMSWebApp").ConnectionString
                Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

				Dim sQueryString As String = "SELECT * FROM tblevents ORDER by pID ASC LIMIT 5"

                Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
                odbcConn.Open()

                Try

                    Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					While odbcReader.Read()

						
						
						
						

						CmsEvents += "<div class='card-action border-non '>" & Trim(odbcReader("event").ToString)  & "</div>"



						
						
		

					End While
                    'lblOut.Text = odbcReader("content").ToString()

                    odbcReader.Close()

                Catch ex As Exception

                    odbcConn.Close()

                End Try

                odbcConn.Close()

            Catch ex As Exception

            End Try

			


        End If

    End Sub

End Class
