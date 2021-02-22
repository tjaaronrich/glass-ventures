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

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
 <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class MapService
    Inherits System.Web.Services.WebService
 

    
    
        
    <WebMethod()> _
    Public Sub GetAllGallery()

        'Dim oList As New List(Of PC_Sites)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblgallery WHERE Status = 'Active' ORDER BY photoId ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    'Dim oItem As New PC_Sites
                    
                    xmlString += "<item "
                    
                    
                    i += 1
                   
                   	xmlString += "id='" & Convert.ToInt16(odbcReader("photoID")) & "' "
                    xmlString += "name='" & SecurityElement.Escape(Trim(odbcReader("Name").ToString)) & "' "
                    xmlString += "imageFile='" & SecurityElement.Escape(Trim(odbcReader("ImageFile").ToString)) & "' "
                    xmlString += "pgId='" & SecurityElement.Escape(Trim(odbcReader("pgid").ToString)) & "' "
                    xmlString += "pgName='" & SecurityElement.Escape(Trim(odbcReader("pgName").ToString)) & "' "
                    xmlString += "status='" & Trim(odbcReader("status").ToString) & "' />"
					'xmlString += "</item>"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
        
		doc.LoadXml("<gallery>" & xmlString &  "</gallery>")
        Dim jsonStr As String = JsonConvert.SerializeXmlNode(doc)
        jsonStr = jsonStr.Replace("," & Chr(34) & "@", "," & Chr(34))
        jsonStr = jsonStr.Replace("{" & Chr(34) & "@", "{" & Chr(34))
        HttpContext.Current.Response.BufferOutput = True
    	HttpContext.Current.Response.ContentType = "application/json"
    	HttpContext.Current.Response.Write(jsonStr)
    	HttpContext.Current.Response.Flush()
        'Return jsonStr

    End Sub
    
    
    
    
    
    
        <WebMethod()> _
    Public Sub GetTop3Gallery()

        'Dim oList As New List(Of PC_Sites)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblgallery WHERE Status = 'Active' ORDER BY photoID ASC LIMIT 3"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    'Dim oItem As New PC_Sites
                    
                    xmlString += "<item "
                    
                    
                    i += 1
                    'oItem.pNum = Convert.ToInt16(odbcReader("pNum"))
                   	xmlString += "id='" & Convert.ToInt16(odbcReader("photoID")) & "' "
                    xmlString += "name='" & SecurityElement.Escape(Trim(odbcReader("Name").ToString)) & "' "
                    xmlString += "imageFile='" & SecurityElement.Escape(Trim(odbcReader("ImageFile").ToString)) & "' "
                    xmlString += "pgId='" & SecurityElement.Escape(Trim(odbcReader("pgid").ToString)) & "' "
                    xmlString += "pgName='" & SecurityElement.Escape(Trim(odbcReader("pgName").ToString)) & "' "
                    xmlString += "status='" & Trim(odbcReader("status").ToString) & "' />"
					'xmlString += "</item>"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
        
		doc.LoadXml("<gallery>" & xmlString &  "</gallery>")
        Dim jsonStr As String = JsonConvert.SerializeXmlNode(doc)
        jsonStr = jsonStr.Replace("," & Chr(34) & "@", "," & Chr(34))
        jsonStr = jsonStr.Replace("{" & Chr(34) & "@", "{" & Chr(34))
        HttpContext.Current.Response.BufferOutput = True
    	HttpContext.Current.Response.ContentType = "application/json"
    	HttpContext.Current.Response.Write(jsonStr)
    	HttpContext.Current.Response.Flush()
        'Return jsonStr

    End Sub
    
    
    
    
    
    
    
    
    
        
    <WebMethod()> _
    Public Sub GetBlogId(nNum As String)

        'Dim oList As New List(Of PC_Sites)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' AND nNum = '" & nNum & "'" 
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    'Dim oItem As New PC_Sites
                    
                    xmlString += "<item "
                    
                    
                    i += 1
                    'oItem.pNum = Convert.ToInt16(odbcReader("pNum"))
                   	xmlString += "id='" & Convert.ToInt16(odbcReader("nNum")) & "' "
                    xmlString += "title='" & SecurityElement.Escape(Trim(odbcReader("Title").ToString)) & "' "
                    xmlString += "summary='" & SecurityElement.Escape(Trim(odbcReader("Summary").ToString)) & "' "
                    xmlString += "author='" & SecurityElement.Escape(Trim(odbcReader("Author").ToString)) & "' "
                    xmlString += "date='" & SecurityElement.Escape(Trim(odbcReader("ItemDate").ToString)) & "' "
                    xmlString += "pageName='" & SecurityElement.Escape(Trim(odbcReader("pageName").ToString)) & "' "
                    xmlString += "content='" & SecurityElement.Escape(Trim(odbcReader("content").ToString)) & "' "
                    xmlString += "featured='" & SecurityElement.Escape(Trim(odbcReader("Featured").ToString)) & "' "
                    xmlString += "visibleDate='" & SecurityElement.Escape(Trim(odbcReader("VisibleDate").ToString)) & "' "
                    xmlString += "expiresDate='" & SecurityElement.Escape(Trim(odbcReader("ExpiresDate").ToString)) & "' "
                    xmlString += "keywords='" & SecurityElement.Escape(Trim(odbcReader("Keywords").ToString)) & "' "
                    xmlString += "status='" & Trim(odbcReader("Status").ToString) & "' />"
					'xmlString += "</item>"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
        
		doc.LoadXml("<blog>" & xmlString &  "</blog>")
        Dim jsonStr As String = JsonConvert.SerializeXmlNode(doc)
        jsonStr = jsonStr.Replace("," & Chr(34) & "@", "," & Chr(34))
        jsonStr = jsonStr.Replace("{" & Chr(34) & "@", "{" & Chr(34))
        HttpContext.Current.Response.BufferOutput = True
    	HttpContext.Current.Response.ContentType = "application/json"
    	HttpContext.Current.Response.Write(jsonStr)
    	HttpContext.Current.Response.Flush()
        'Return jsonStr

    End Sub
    
    
    
    
    
  
    
    
    
End Class

Public Class Blog
    Public Property id() As String
    Public Property title() As String
    Public Property summary() As String
    Public Property author() As String
    Public Property pageName() As String
    Public Property featured() As String
    Public Property visibleDate() As String
    Public Property expiresDate() As String
    Public Property status() As String
End Class







