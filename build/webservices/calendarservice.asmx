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
Public Sub GetCalendarByNum(cNum As String)

	'Dim oList As New List(Of PC_Listing)
	'Dim xmlData As New List(Of String)
	'Dim doc As New XmlDocument()

	Dim xmlString As String = ""
	Try
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblcalendardates where cNum = " & cNum
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
				
				xmlString += """cNum"":""" & Convert.ToInt16(odbcReader("cNum")) & ""","
				xmlString += """Title"":""" & Trim(odbcReader("Title").ToString) & ""","
				xmlString += """StartDate"":""" & Trim(odbcReader("StartDate").ToString) & ""","
				xmlString += """EndDate"":""" & Trim(odbcReader("EndDate").ToString) & ""","
				xmlString += """StartTime"":""" & Trim(odbcReader("StartTime").ToString) & ""","
				xmlString += """EndTime"":""" & Trim(odbcReader("EndTime").ToString) & ""","
				xmlString += """AllDay"":""" & Trim(odbcReader("AllDay").ToString) & ""","
				xmlString += """Repeats"":""" & Trim(odbcReader("Repeats").ToString) & ""","
				xmlString += """ContactNumber"":""" & Trim(odbcReader("ContactNumber").ToString) & ""","
				xmlString += """Location"":""" & Trim(odbcReader("Location").ToString) & ""","
				xmlString += """Description"":""" & Trim(odbcReader("Description").ToString) & ""","
				xmlString += """Status"":""" & Trim(odbcReader("Status").ToString) & ""","
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
Public Sub GetAllCalendars()

	'Dim oList As New List(Of PC_Listing)
	'Dim xmlData As New List(Of String)
	'Dim doc As New XmlDocument()

	Dim xmlString As String = ""
	Try
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		Dim sQueryString As String = "SELECT * FROM tblcalendardates  "
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
				
				xmlString += """cNum"":""" & Convert.ToInt16(odbcReader("cNum")) & ""","
				xmlString += """Title"":""" & Trim(odbcReader("Title").ToString) & ""","
				xmlString += """StartDate"":""" & Trim(odbcReader("StartDate").ToString) & ""","
				xmlString += """EndDate"":""" & Trim(odbcReader("EndDate").ToString) & ""","
				xmlString += """StartTime"":""" & Trim(odbcReader("StartTime").ToString) & ""","
				xmlString += """EndTime"":""" & Trim(odbcReader("EndTime").ToString) & ""","
				xmlString += """AllDay"":""" & Trim(odbcReader("AllDay").ToString) & ""","
				xmlString += """Repeats"":""" & Trim(odbcReader("Repeats").ToString) & ""","
				xmlString += """ContactNumber"":""" & Trim(odbcReader("ContactNumber").ToString) & ""","
				xmlString += """Location"":""" & Trim(odbcReader("Location").ToString) & ""","
				xmlString += """Description"":""" & Trim(odbcReader("Description").ToString) & ""","
				xmlString += """Status"":""" & Trim(odbcReader("Status").ToString) & ""","
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
    
    
    
    
<WebMethod> _
Public Sub UpdateCalendar(models As String)
    
    Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim cNum = x(0)("cNum")
	Dim Title = x(0)("Title")
	Dim StartDate = x(0)("StartDate")
	Dim EndDate = x(0)("EndDate")
	Dim ContactNumber = x(0)("ContactNumber")
	Dim Location = x(0)("Location")
	Dim AllDay = x(0)("AllDay")
	'Dim ImageFile = x(0)("ImageFile")
	
	
	    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Dim sQueryString As String
        Try

                sQueryString = "UPDATE tblcalendardates SET " & _
                    "Title = '" & Replace(Title, "'", "''") & "', " & _
                    "StartDate = '" & Replace(StartDate, "'", "''") & "', " & _
                    "EndDate = '" & Replace(EndDate, "'", "''") & "', " & _
                    "ContactNumber = '" & Replace(ContactNumber, "'", "''") & "', " & _
                    "Location = '" & Replace(Location, "'", "''") & "', " & _
                    "AllDay = '" & Replace(AllDay, "'", "''") & "' " & _
                    "WHERE cNum = " & cNum

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
Public Sub DeleteCalendar(models As String)



	Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim cNum = x(0)("cNum")


	Dim sQueryString As String
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

	Try

			sQueryString = "DELETE FROM tblcalendardates WHERE cNum = " & cNum



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
Public Sub AddCalendar(models As String)


   

	Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim acctNum = x(0)("acctNum")
	Dim Name = x(0)("uName")
	Dim Password = x(0)("passWord")
	Dim PermissionLevel = x(0)("PermissionLevel")("CategoryName")
	Dim fullName = x(0)("fullName")
	Dim addDate = x(0)("addDate")
	Dim ImageFile = x(0)("ImageFile")



	Dim TodaysDate As String = DateTime.Now.ToString("yyyy-MM-dd")



	Dim xmlString As String = ""
	xmlString += "{"
	xmlString += """acctNum"":""" & acctNum & ""","
	xmlString += """uName"":""" & Name & ""","
	xmlString += """passWord"":""" & Password & ""","
	xmlString += """PermissionLevel"":""" & PermissionLevel & ""","
	xmlString += """fullName"":""" & fullName & ""","
	xmlString += """addDate"":""" & TodaysDate & ""","
	xmlString += """ImageFile"":""" & ImageFile & """},"

	xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
	'xmlString = "[" & xmlString & "]"
	'xmlString = "callback([" & xmlString & "])"




	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String

	Try



		sQueryString = "INSERT INTO tblaccount " & _
		"(uName, " & _
		"acctNum, " & _
		"passWord, " & _
		"PermissionLevel, " & _
		"fullName, " & _
		"addDate, " & _
		"ImageFile)" & _
		" VALUES " & _
		"('" & Replace(Name, "'", "''") & _
		"', '" & Replace(acctNum, "'", "''") & _
		"', MD5('" & Replace(Password, "'", "''") & _
		"'), '" & Replace(PermissionLevel, "'", "''") & _
		"', '" & Replace(fullName, "'", "''") & _
		"', '" & Replace(TodaysDate, "'", "''") & _
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



















