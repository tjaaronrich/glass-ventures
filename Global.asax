<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Odbc" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Http" %>
<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="System.Net.Http" %>
<%@ Import Namespace="JavaScriptEngineSwitcher.Core" %>
	
<script RunAt="server">
    Private Sub Application_Start(sender As Object, e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
	    GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear()
		
	
		
	JsEngineSwitcherConfig.Configure(JsEngineSwitcher.Instance)



        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
	
	
	Private Sub Application_BeginRequest(sender As Object, e As EventArgs)
		
	
	If HttpContext.Current.Request.Url.ToString().ToLower().Contains("/about.aspx") Then
        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.Status = "301 Moved Permanently"
        HttpContext.Current.Response.AddHeader("Location", Request.Url.ToString().ToLower().Replace("/about.aspx", "/about"))
    End If
	
	
	
		Dim fullOrigionalpath As [String] = Request.Url.ToString()
		Dim sElements As [String]() = fullOrigionalpath.Split("/"c)
		Dim sFilePath As [String]() = sElements(sElements.Length - 1).Split("."c)
		Dim queryString As [String]() = sElements(sElements.Length - 1).Split("?"c)
		
	
	
		Dim query As String = "SELECT * FROM tblftb WHERE pageName = '" & queryString(0) & "'"
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sqlRet As String
		
        'Dim DBCommand As New OdbcCommand(query, odbcConn)
        'odbcConn.Open()
        'Try
        ''    Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
        ''    odbcReader.Read()
        ''    sqlRet = odbcReader("content").ToString()
        ''    odbcReader.Close()
        'Catch ex As Exception
		''	sqlRet = ""
        ''	odbcConn.Close()
		'End Try
	
	
		'odbcConn.Close()
	
	
	
	
		'If sqlRet = "" Then
			If Not fullOrigionalpath.Contains(".asmx") AND Not fullOrigionalpath.Contains("fbclid") AND Not fullOrigionalpath.Contains("?”)

	
				If Not fullOrigionalpath.Contains("UseUploadModule")
					If Not fullOrigionalpath.Contains(".aspx") AndAlso sFilePath.Length = 1 Then
						If Not String.IsNullOrEmpty(sFilePath(0).Trim()) Then
							If queryString.Length = 1 Then
								Context.RewritePath(sFilePath(0) + ".aspx")
							Else
								Context.RewritePath(queryString(0) + ".aspx?" + queryString(1))
							End If

						End If
					End If
				End If
			End If
		'End If
	
	
	
	End Sub
 
    Private Shared Sub RegisterRoutes(routes As RouteCollection)
		routes.MapRoute(
			name:="DefaultMvc",
			url:="mvc/{controller}/{action}/{id}",
			defaults:=New With {Key _
			.action = "Index", Key _
			.id = UrlParameter.[Optional]
		})
		routes.MapHttpRoute(
			name:="DefaultApi",
			routeTemplate:="api/{controller}/{id}",
			defaults:=New With {.id = System.Web.Http.RouteParameter.[Optional]
        })
        routes.MapPageRoute("Default", "Default", "~/Default.aspx")
	
	
        routes.MapPageRoute("DefaultSlash", "", "~/Default.aspx")
		routes.MapPageRoute("DynamicPage", "{PageName}", "~/DynamicPage.aspx")
		routes.MapPageRoute("SeoSlugPageLookup", "{*slug}", "~/DynamicPage.aspx")
		
	
		
	
    End Sub
</script>
