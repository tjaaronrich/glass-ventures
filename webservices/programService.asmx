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
Public Sub GetUserByNum(acctNum As String)

	'Dim oList As New List(Of PC_Listing)
	'Dim xmlData As New List(Of String)
	'Dim doc As New XmlDocument()

	Dim xmlString As String = ""
	Try
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblaccount where acctNum = " & acctNum
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()

		Try

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Dim i As Integer
			While odbcReader.Read()
				'Dim oItem As New PC_Listing

				xmlString += "{"

				Dim ImageFile As String

				If odbcReader("ImageFile") Is Nothing Then

					ImageFile = Trim(odbcReader("ImageFile").ToString)

				End If

				i += 1
				'oItem.pId = Convert.ToInt16(odbcReader("pId"))
				xmlString += """acctNum"":""" & Convert.ToInt16(odbcReader("acctNum")) & ""","
				xmlString += """uName"":""" & Trim(odbcReader("uName").ToString) & ""","
				xmlString += """passWord"":""" & Trim(odbcReader("passWord").ToString) & ""","
				xmlString += """PermissionLevel"":""" & Trim(odbcReader("PermissionLevel").ToString) & ""","
				xmlString += """fullName"":""" & Trim(odbcReader("fullName").ToString) & ""","
				xmlString += """addDate"":""" & Trim(odbcReader("addDate").ToString) & ""","
				xmlString += """ImageFile"":""" & Trim(odbcReader("ImageFile").ToString) & """},"
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
	'jsonStr = jsonStr.Replace("," & Chr(34) & "@", "," & Chr(34))
	'jsonStr = jsonStr.Replace("{" & Chr(34) & "@", "{" & Chr(34))
	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/x-javascript"
	HttpContext.Current.Response.Write(xmlString)
	HttpContext.Current.Response.Flush()



End Sub
    
    
    

    
        
<WebMethod()> _
Public Sub GetAllPrograms()


	Dim xmlString As String = ""
	Try
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblprograms ORDER BY pSort ASC "
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()

		Try

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			Dim i As Integer
			While odbcReader.Read()
				'Dim oItem As New PC_Listing

				xmlString += "{"

				Dim ImageFile As String

				If odbcReader("ImageFile") Is Nothing Then

					ImageFile = Trim(odbcReader("ImageFile").ToString)

				End If

				i += 1
				'oItem.pId = Convert.ToInt16(odbcReader("pId"))
				xmlString += """pID"":""" & Convert.ToInt16(odbcReader("pID")) & ""","
				xmlString += """pSort"":""" & Trim(odbcReader("pSort").ToString) & ""","
				xmlString += """ImageText"":""" & Trim(odbcReader("ImageText").ToString) & ""","
				xmlString += """ImageFile"":""" & Trim(odbcReader("ImageFile").ToString) & ""","
				xmlString += """link"":""" & Trim(odbcReader("link").ToString) & ""","
				xmlString += """backgroundImageFile"":""" & Trim(odbcReader("backgroundImageFile").ToString) & """},"
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
Public Sub UpdateProgram(models As String)
    
    Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim pID = x(0)("pID")
	Dim pSort = x(0)("pSort")
	Dim ImageText = x(0)("ImageText")
	Dim link = x(0)("link")
	Dim ImageFile = x(0)("ImageFile")
	Dim backgroundImageFile = x(0)("backgroundImageFile")
	
	
	    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Dim sQueryString As String
        Try

                sQueryString = "UPDATE tblprograms SET " & _
                    "ImageText = '" & Replace(ImageText, "'", "''") & "', " & _
                    "pSort = '" & Replace(pSort, "'", "''") & "', " & _
                    "link = '" & Replace(link, "'", "''") & "', " & _
                    "ImageFile = '" & Replace(ImageFile, "'", "''") & "', " & _
                    "backgroundImageFile = '" & Replace(backgroundImageFile, "'", "''") & "' " & _
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
	HttpContext.Current.Response.Write(models)
	HttpContext.Current.Response.Flush()
End Sub
    
    
    
    
    
    
    
    
<WebMethod> _
Public Sub DeleteProgram(models As String)



	Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim pID = x(0)("pID")


	Dim sQueryString As String
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

	Try

			sQueryString = "DELETE FROM tblprograms WHERE pID = " & pID



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

                sQueryString = "UPDATE tblprograms SET " & _
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
Public Sub AddProgram(models As String)


   

	Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim pID = x(0)("pID")
	Dim pSort = x(0)("pSort")
	Dim ImageText = x(0)("ImageText")
	Dim link = x(0)("link")
	Dim ImageFile = x(0)("ImageFile")
	Dim backgroundImageFile = x(0)("backgroundImageFile")



	Dim TodaysDate As String = DateTime.Now.ToString("yyyy-MM-dd")



	Dim xmlString As String = ""
	xmlString += "{"
	xmlString += """pID"":""" & pID & ""","
	xmlString += """pSort"":""" & pSort & ""","
	xmlString += """ImageText"":""" & ImageText & ""","
	xmlString += """link"":""" & link & ""","
	xmlString += """ImageFile"":""" & ImageFile & ""","
	xmlString += """backgroundImageFile"":""" & backgroundImageFile & """},"

	xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
	'xmlString = "[" & xmlString & "]"
	'xmlString = "callback([" & xmlString & "])"




	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String

	Try



		sQueryString = "INSERT INTO tblprograms " & _
		"(ImageText, " & _
		"pSort, " & _
		"link, " & _
		"ImageFile, " & _
		"backgroundImageFile)" & _
		" VALUES " & _
		"('" & Replace(ImageText, "'", "''") & _
		"', '" & Replace(pSort, "'", "''") & _
		"', '" & Replace(link, "'", "''") & _
		"', '" & Replace(ImageFile, "'", "''") & _
		"', '" & Replace(backgroundImageFile, "'", "''") & "')"

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
	HttpContext.Current.Response.Write("[" & xmlString & "]")
	HttpContext.Current.Response.Flush()

        
        
        
        
        

End Sub
    
    
    

    
    
End Class



















