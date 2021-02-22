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

    
    
    <WebMethod()> _
    Public Sub GetOwnerListByUser(pID As String)

        Dim oList As New List(Of PC_Listing)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblowners WHERE pLinkID = " & pID
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    Dim oItem As New PC_Listing
                    
                    xmlString += "{"
                    
                    
                    i += 1
                    oItem.pId = Convert.ToInt16(odbcReader("pId"))
                    xmlString += """CustomerID"":""" & Convert.ToInt16(odbcReader("pId")) & ""","
                    xmlString += """Sort"":""" & Trim(odbcReader("pSort").ToString) & ""","
                    xmlString += """Name"":""" & Trim(odbcReader("pName").ToString) & ""","
                    xmlString += """Address"":""" & Trim(odbcReader("pAddress").ToString) & ""","
                    xmlString += """ImageFile"":""" & Trim(odbcReader("ImageFile1").ToString) & ""","
                    xmlString += """Status"":""" & Trim(odbcReader("Status").ToString) & ""","
                    xmlString += """Type"":""" & Trim(odbcReader("pType").ToString) & """},"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
        xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
        xmlString = "[" & xmlString & "]"
        'xmlString = "callback([" & xmlString & "])"
        'Dim jsonStr As String = JsonConvert.SerializeXmlNode(doc)
        HttpContext.Current.Response.BufferOutput = True
    	HttpContext.Current.Response.ContentType = "application/x-javascript"
    	HttpContext.Current.Response.Write(xmlString)
    	HttpContext.Current.Response.Flush()

    End Sub
    
    
    
	
    
    <WebMethod()> _
    Public Sub GetNavObjectPortal()

        Dim oList As New List(Of PC_Listing)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnavigationportal where navID = '1'"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    Dim oItem As New PC_Listing
                    
                    'xmlString += "{"
                    
                    
                    i += 1
                    
                    xmlString +=  Trim(odbcReader("navObject").ToString) 
                    'xmlString += """pageName"":""" & Trim(odbcReader("pageName").ToString) & ""","
                    'xmlString += """pageName"":""" & Trim(odbcReader("pageName").ToString) & """},"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
        'xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
        'xmlString = "{d :" & xmlString & "}"
        'xmlString = "callback([" & xmlString & "])"
        'Dim jsonStr As String = JsonConvert.SerializeXmlNode(doc)
        HttpContext.Current.Response.BufferOutput = True
		HttpContext.Current.Response.ContentType = "application/json"
    	HttpContext.Current.Response.Write(xmlString)
    	HttpContext.Current.Response.Flush()

    End Sub
	
	
	
        
    
    
    <WebMethod()> _
    Public Sub GetNavObject()

        Dim oList As New List(Of PC_Listing)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnavigation where navID = '1'"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    Dim oItem As New PC_Listing
                    
                    'xmlString += "{"
                    
                    
                    i += 1
                    
                    xmlString +=  Trim(odbcReader("navObject").ToString) 
                    'xmlString += """pageName"":""" & Trim(odbcReader("pageName").ToString) & ""","
                    'xmlString += """pageName"":""" & Trim(odbcReader("pageName").ToString) & """},"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
        'xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
        'xmlString = "{d :" & xmlString & "}"
        'xmlString = "callback([" & xmlString & "])"
        'Dim jsonStr As String = JsonConvert.SerializeXmlNode(doc)
        HttpContext.Current.Response.BufferOutput = True
		HttpContext.Current.Response.ContentType = "application/json"
    	HttpContext.Current.Response.Write(xmlString)
    	HttpContext.Current.Response.Flush()

    End Sub
    
    

   
    
    
<WebMethod> _
Public Sub UpdateNavigation(models As String)
   
   
   
    'Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	'Dim ftbNum = x(0)("ftbNum")
	'Dim pageName = x(0)("pageName")
	'Dim content = x(0)("content")
	Dim str = "Success"
	
	    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Dim sQueryString As String
        
        'models = models.Replace(Chr(34),"'")
        Try

                sQueryString = "UPDATE tblnavigation SET " & _
                    "navObject = '" & Replace(models, "'", "''") & "' " & _
                    "WHERE navID = '1'"

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            'iResult = 1

            odbcConn.Close()

        Catch ex As Exception
			str = ex.ToString()
            odbcConn.Close()
            odbcConn.Dispose()

            'iResult = 0

        End Try
	
	
	
	
	
	
	
	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/json"
	HttpContext.Current.Response.Write(str & models)
	HttpContext.Current.Response.Flush()
End Sub
       
	   
	   
	   
	   
    
<WebMethod> _
Public Sub UpdateNavigationBody()
   Dim nvc As NameValueCollection = System.Web.HttpContext.Current.Request.Form
   
   	Dim models As String = nvc("models")
   
    'Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	'Dim ftbNum = x(0)("ftbNum")
	'Dim pageName = x(0)("pageName")
	'Dim content = x(0)("content")
	Dim str = "Success"
	
	    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Dim sQueryString As String
        
        'models = models.Replace(Chr(34),"'")
        Try

                sQueryString = "UPDATE tblnavigation SET " & _
                    "navObject = '" & Replace(models, "'", "''") & "' " & _
                    "WHERE navID = '1'"

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            'iResult = 1

            odbcConn.Close()

        Catch ex As Exception
			str = ex.ToString()
            odbcConn.Close()
            odbcConn.Dispose()

            'iResult = 0

        End Try
	
	
	
	
	
	
	
	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/json"
	HttpContext.Current.Response.Write(str & models)
	HttpContext.Current.Response.Flush()
End Sub
       
   
   
   
   
    
<WebMethod> _
Public Sub UpdateNavigationPortal(models As String)
   
   
   
    'Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	'Dim ftbNum = x(0)("ftbNum")
	'Dim pageName = x(0)("pageName")
	'Dim content = x(0)("content")
	Dim str = "Success"
	
	    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Dim sQueryString As String
        
        'models = models.Replace(Chr(34),"'")
        Try

                sQueryString = "UPDATE tblnavigationportal SET " & _
                    "navObject = '" & Replace(models, "'", "''") & "' " & _
                    "WHERE navID = '1'"

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            'iResult = 1

            odbcConn.Close()

        Catch ex As Exception
			str = ex.ToString()
            odbcConn.Close()
            odbcConn.Dispose()

            'iResult = 0

        End Try
	
	
	
	
	
	
	
	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/json"
	HttpContext.Current.Response.Write(str & models)
	HttpContext.Current.Response.Flush()
End Sub
       
  
    
    
    
End Class
















