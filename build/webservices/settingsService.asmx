<%@ WebService Language="VB" Class="MapService" %>


Imports System
Imports System.IO
Imports System.Security
Imports System.Configuration
Imports System.Xml
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Xml.Serialization
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System.Net.Http

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
 <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class MapService
    Inherits System.Web.Services.WebService
 

    
    
<WebMethod> _
Public Sub UpdateSetting(name As String, value As String)
    

	
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

	Dim sQueryString As String
        Try
               
			sQueryString = "UPDATE tblsettings SET value = '" & value & "' WHERE name = '" & name & "'"

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()


        End Try
	
	
	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/json"
	HttpContext.Current.Response.Write(name & " " & value)
	HttpContext.Current.Response.Flush()
End Sub
    

    

    
    
    
    

    
    

    
    
    
    
    
End Class



















