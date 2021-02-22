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




Partial Class PagesAdd
    Inherits System.Web.UI.Page

	Public HeaderImageValue As String
	Public strGUID As String = Guid.NewGuid().ToString()
	Public strError As String
    Public Shared Function ThumbnailCallback0() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback1() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback2() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback3() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback4() As Boolean
        Return False
    End Function

    Public Shared Function ThumbnailCallback5() As Boolean
        Return False
    End Function
	
	
	
	

	
	

Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		
	
	'Sort.Attributes.Add("type", "number")
        
	Dim sortmax As Integer = 0

    If Not Page.IsPostBack Then

			Editor1RTE.Value = GetOptionByNum("1")
			Editor2RTE.Value = GetOptionByNum("2")
			'strError += GetOptionByNum("1")
			guidLabel.Text = strGUID
			If Len(Server.HtmlDecode(Request.QueryString("ftbNum"))) > 0 Then
				
		
			End If

	End If

End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click


		Dim result1 As String = ModifyOption(Editor1RTE.Value, "1")
		Dim result2 As String = ModifyOption(Editor2RTE.Value, "2")
		
		
		


   
		
			
		If result1 = "Success" AND result2 = "Success" Then
			Response.Redirect("default.aspx")
		End If

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


	Public Shared Function ModifyOption(ByVal value As String, ByVal Id As String) As String

		

		Dim Result As String
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try

			sQueryString = "UPDATE tbloptions SET option_value = '" & Replace(value, "'", "''") & "' WHERE option_id = " & Id
            

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

			Result = "Success"

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

			Result = ex.ToString()

        End Try

        Return Result

    End Function
	
	
	
End Class
