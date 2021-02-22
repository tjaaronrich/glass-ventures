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
    Public Function GetAllActiveSites() As String
		Session.Remove("accessLevel")
		Server.Transfer("/login.aspx", true)
        Return ""

    End Function
    
    
    
    
    
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
Public Sub GetAllStaff()

	'Dim oList As New List(Of PC_Listing)
	'Dim xmlData As New List(Of String)
	'Dim doc As New XmlDocument()

	Dim xmlString As String = ""
	Try
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblstaff  "
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
				xmlString += """bioID"":""" & Convert.ToInt16(odbcReader("bioID")) & ""","
				xmlString += """fullName"":""" & Trim(odbcReader("fullName").ToString) & ""","
				xmlString += """title"":""" & Trim(odbcReader("title").ToString) & ""","
				xmlString += """phoneNumber"":""" & Trim(odbcReader("phoneNumber").ToString) & ""","
				xmlString += """nDescription"":""" & Trim(odbcReader("nDescription").ToString) & ""","
				xmlString += """Category"":""" & Trim(odbcReader("Category").ToString) & ""","
				xmlString += """nSort"":""" & Trim(odbcReader("nSort").ToString) & ""","
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
    

Public Function GetHash(acctNum As String) As String
  	
   	Dim password As String = ""
	Try
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblaccount WHERE acctNum = " & acctNum
		Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
		odbcConn.Open()

		Try

			Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
			While odbcReader.Read()
	


				password = Trim(odbcReader("passWord").ToString)
				
				
			End While

			odbcReader.Close()

		Catch ex As Exception

			odbcConn.Close()

		End Try

		odbcConn.Close()

	Catch ex As Exception

	End Try
	
	Return password
End Function
    
    
<WebMethod> _
Public Sub UpdateStaff(models As String)
   
   
   
    
    Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim bioID = x(0)("bioID")
	Dim fullName = x(0)("fullName")
	Dim title = x(0)("title")
	Dim Category = x(0)("Category")
	Dim ImageFile = x(0)("ImageFile")
	
	
	
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

	Dim sQueryString As String
        Try
			
              
			sQueryString = "UPDATE tblstaff SET " & _
				"fullName = '" & Replace(fullName, "'", "''") & "', " & _
				"title = '" & Replace(title, "'", "''") & "', " & _
				"Category = '" & Replace(Category, "'", "''") & "', " & _
				"ImageFile = '" & Replace(ImageFile, "'", "''") & "' " & _
				"WHERE bioID = " & bioID
               

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
Public Sub DeleteStaff(models As String)



	Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim bioID = x(0)("bioID")


	Dim sQueryString As String
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

	Try

		sQueryString = "DELETE FROM tblstaff WHERE bioID = " & bioID



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
Public Sub AddStaff(models As String)


   

	Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim bioID = x(0)("bioID")
	Dim fullName = x(0)("fullName")
	Dim title = x(0)("title")
	Dim Category = x(0)("Category")("CategoryName")
	Dim ImageFile = x(0)("ImageFile")



	Dim TodaysDate As String = DateTime.Now.ToString("yyyy-MM-dd")



	Dim xmlString As String = ""
	xmlString += "{"
	xmlString += """bioID"":""" & bioID & ""","
	xmlString += """fullName"":""" & fullName & ""","
	xmlString += """title"":""" & title & ""","
	xmlString += """Category"":""" & Category & ""","
	xmlString += """ImageFile"":""" & ImageFile & """},"

	xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
	'xmlString = "[" & xmlString & "]"
	'xmlString = "callback([" & xmlString & "])"




	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String

	Try



		sQueryString = "INSERT INTO tblstaff " & _
		"(fullName, " & _
		"title, " & _
		"Category, " & _
		"ImageFile)" & _
		" VALUES " & _
		"('" & Replace(fullName, "'", "''") & _
		"', '" & Replace(title, "'", "''") & _
		"', '" & Replace(Category, "'", "''") & _
		"', '" & Replace(ImageFile, "'", "''") & "')"

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



















