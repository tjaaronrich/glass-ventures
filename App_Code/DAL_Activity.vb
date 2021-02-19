Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Mail

Public Class DAL_Activity
	
	
	
	

	Public Shared Function GetStatusHome() As String
		Dim recentActivity As String
		Try

			Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
			Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

			Dim sQueryString As String = "SELECT * FROM tblsettings WHERE name = 'recent-activity'"

			Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
			odbcConn.Open()

			Try

				Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				While odbcReader.Read()

					If Trim(odbcReader("value").ToString) = "true"
						recentActivity = ""
					Else
						recentActivity = "hide"
					End If
					


				End While


				odbcReader.Close()

			Catch ex As Exception

				odbcConn.Close()

			End Try

			odbcConn.Close()

		Catch ex As Exception

		End Try

        Return recentActivity
		
	End Function
	
	
	
	

	Public Shared Function GetStatus() As String
		Dim recentActivity As String
		Try

			Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
			Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

			Dim sQueryString As String = "SELECT * FROM tblsettings WHERE name = 'recent-activity'"

			Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
			odbcConn.Open()

			Try

				Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				While odbcReader.Read()

					If Trim(odbcReader("value").ToString) = "true"
						recentActivity = "checked='true'"
					Else
						recentActivity = ""
					End If
					


				End While


				odbcReader.Close()

			Catch ex As Exception

				odbcConn.Close()

			End Try

			odbcConn.Close()

		Catch ex As Exception

		End Try

        Return recentActivity
		
	End Function
	
	
	
	
	
	

	Public Shared Function GetCMSEvents() As String
		Dim recentActivity As String
		Try

			Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
			Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

			Dim sQueryString As String = "SELECT * FROM tblactivity ORDER by nNum DESC LIMIT 12"

			Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
			odbcConn.Open()

			Try

				Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				'recentActivity +=  "<thead><tr><th>Title</th><th>Action</th><th>User</th></tr></thead><tbody>"
				While odbcReader.Read()

					Dim icon As String
					Dim color As String
					

					Select Case Trim(odbcReader("Title").ToString)
						Case "News/Blog"
							icon =  "book"
							color = "amber"
						Case "Pages"
							icon =  "pages"
							color = "green"
						Case "CMS Login"
							icon =  "account_circle"
						color = "deep-orange"
						Case "CMS Logout"
							icon =  "keyboard_tab"
							color = "brown"
						Case Else
							icon = "apps"
						color = "deep-purple"
					End Select

					recentActivity += "<div class='recent-activity-list chat-out-list row mb-0'>" &
						"<div class='col s3 mt-2 center-align recent-activity-list-icon'>" &
					"<i class='material-icons white-text icon-bg-color " & color & " lighten-2'>" & icon & "</i>" &
						"</div>" & 
					"<div class='col s9 recent-activity-list-text'>" &
					"<a href='#' class='" & color & "-text medium-small'>" & Trim(odbcReader("Title").ToString) & "</a>" &
						"<p class='mt-0 mb-2 fixed-line-height font-weight-300 medium-small'>" & Trim(odbcReader("action").ToString) & "</p>" &
					"</div>" &
                    "</div>"








				End While

				'recentActivity += "</tbody>"
				'lblOut.Text = odbcReader("content").ToString()

				odbcReader.Close()

			Catch ex As Exception

				odbcConn.Close()

			End Try

			odbcConn.Close()

		Catch ex As Exception

		End Try

        Return recentActivity

    End Function






End Class
