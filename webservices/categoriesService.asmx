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
Public Sub GetCategories()


	Dim xmlString As String = ""
	Try
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblCategories ORDER BY name ASC "
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()

		Try

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Dim i As Integer
			While odbcReader.Read()
				'Dim oItem As New PC_Listing

				xmlString += "{"

				

				i += 1
				'oItem.pId = Convert.ToInt16(odbcReader("pId"))
				xmlString += """ProductID"":" & Convert.ToInt16(odbcReader("pid")) & ","
				xmlString += """ProductName"":""" & Trim(odbcReader("name").ToString) & """},"
				'xmlString += """type"":""" & Trim(odbcReader("type").ToString) & """},"
			End While

			odbcReader.Close()

		Catch ex As Exception

			odbcConn.Close()

		End Try

		odbcConn.Close()

	Catch ex As Exception

	End Try
	If Not xmlString = "" Then
		xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
	End If
	xmlString = "[" & xmlString & "]"
	
	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/x-javascript"
	HttpContext.Current.Response.Write(xmlString)
	HttpContext.Current.Response.Flush()



End Sub
    
    
    
    
<WebMethod> _
Public Sub UpdateCategory(models As String)
    Dim retString As String = ""
    Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim pID = x(0)("ProductID")
	Dim name = x(0)("ProductName")
	
	
	    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Dim sQueryString As String
        Try

                sQueryString = "UPDATE tblCategories SET " & _
                    "name = '" & Replace(name, "'", "''") & "'  " & _
                    "WHERE pid = " & pID

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            'iResult = 1

            odbcConn.Close()

        Catch ex As Exception
			retString += ex.ToString()
            odbcConn.Close()
            odbcConn.Dispose()

            'iResult = 0

        End Try
	
	
	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/json"
	HttpContext.Current.Response.Write(models)
	HttpContext.Current.Response.Flush()
End Sub
    
    
    
    
    
    
    
    
<WebMethod> _
Public Sub DeleteCategory(models As String)



	Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim pID = x(0)("ProductID")


	Dim sQueryString As String
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

	Try

			sQueryString = "DELETE FROM tblCategories WHERE pID = " & pID



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
	HttpContext.Current.Response.Write(models)
	HttpContext.Current.Response.Flush()

End Sub

   
   
   
   <WebMethod> _
Public Sub ClearImages(pID As String)

    
    'Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	'Dim pID = x(0)("pID")
	'Dim ImageText = x(0)("ImageText")
	'Dim link = x(0)("link")
	'Dim ImageFile = x(0)("ImageFile")
	'Dim backgroundImageFile = x(0)("backgroundImageFile")
	
	
	    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Dim sQueryString As String
        Try

                sQueryString = "UPDATE tblslider SET " & _
                    "ImageFile = '', " & _
                    "backgroundImageFile = '' " & _
                    "WHERE pID = " & pID

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            'iResult = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            'iResult = 0

        End Try
	
	
	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/json"
	HttpContext.Current.Response.Write("")
	HttpContext.Current.Response.Flush()

End Sub
   
   
    
	
	
    
    
    
<WebMethod> _
Public Sub AddCategory(models As String)


   

	Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim pID = x(0)("ProductID")
	Dim name = x(0)("ProductName")
	'Dim ntype = x(0)("type")("CategoryName")






	Dim xmlString As String = ""
	xmlString += "{"
	'xmlString += """ProductID"":" & pid & ","
	xmlString += """ProductName"":""" & name & """},"
	'xmlString += """type"":""" & ntype & """},"

	xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
	'xmlString = "[" & xmlString & "]"
	'xmlString = "callback([" & xmlString & "])"




	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String

	Try



		sQueryString = "INSERT INTO tblCategories " & _
		"(name)" & _
		" VALUES " & _
		"('" & Replace(name, "'", "''") & "')"

		odbcConn.Open()
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		DBCommand.ExecuteNonQuery()

		odbcConn.Close()

	Catch ex As Exception

		odbcConn.Close()
		odbcConn.Dispose()
		xmlString += ex.ToString()
	End Try

	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/json"
	HttpContext.Current.Response.Write( xmlString )
	HttpContext.Current.Response.Flush()

        
        
        
        
        

End Sub
    
    
    

    
    
End Class



















