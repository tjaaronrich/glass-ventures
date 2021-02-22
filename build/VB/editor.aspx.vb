Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI.ControlCollection
Imports System.Linq

Partial Class editorPage
    Inherits System.Web.UI.Page
	
	
	Public Content As String
	Public Title As String
	Public HeaderImage As String
	Public HeaderImageText As String
	
	Public pageName As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If Not Me.IsPostBack Then
			If Len(Server.HtmlDecode(Request.QueryString("pageName"))) > 0 Then

				pageName = Request.QueryString("pageName").ToString()

			End If
			
			
            Me.PopulatePage()
        End If
		
		
        'If Not Page.IsPostBack Then

            'Try

            '    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            '    Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

            '    Dim sQueryString As String = "SELECT * FROM tblftb WHERE pageName = 'Default'"

            '    Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            '    odbcConn.Open()

            '    Try

            '        Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
            '        odbcReader.Read()

            '        lblOut.Text = odbcReader("content").ToString()

            '        odbcReader.Close()

            '    Catch ex As Exception

            '        odbcConn.Close()

            '    End Try

            '    odbcConn.Close()

            'Catch ex As Exception

            'End Try

        'End If

    End Sub
	
	
	
	
	Private Sub PopulatePage()
        'Dim pageName As String = Me.Page.RouteData.Values("PageName").ToString()
		'pageName = pageName.Replace(".aspx", "")
		Dim query As String = "SELECT * FROM tblftb WHERE pageName = '" & pageName & "'"
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		
		
        Dim DBCommand As New OdbcCommand(query, odbcConn)
        odbcConn.Open()
        Try
            Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
            odbcReader.Read()
			Content = odbcReader("content").ToString()
			'Content = HttpUtility.HtmlDecode(odbcReader("content").ToString())
			'Page.Title = Trim(odbcReader("meta_title").ToString())
			'HeaderImage = Trim(odbcReader("HeaderImage").ToString())
			'HeaderImageText = Trim(odbcReader("HeaderImageText").ToString())
			
			
			
			
			
			

			

			
			
			
			
			
			
			
			
			
            odbcReader.Close()
        Catch ex As Exception
			'Response.Redirect("/404")
			Content = ex.ToString()
        	odbcConn.Close()
		End Try
    End Sub
	
	
	
	

End Class
