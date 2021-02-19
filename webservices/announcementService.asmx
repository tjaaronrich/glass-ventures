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
    Public Sub GetAnnouncementByDates(startDate As String, endDate As String)

        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblannouncements WHERE StartDate >= '" & startDate & "' AND StartDate <= '" & endDate & "' AND EndDate <= '" & endDate & "' AND EndDate >= '" & startDate & "' AND Status = 'Active'  ORDER BY StartDate ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    
                    xmlString += "{"
                    
                    
                    i += 1
					Dim myDateString as String = Trim(odbcReader("StartDate").ToString)
					Dim myDate as DateTime
					DateTime.TryParse(myDateString, myDate).ToString()
					Dim myEndDateString as String = Trim(odbcReader("EndDate").ToString)
					Dim myEndDate as DateTime
					DateTime.TryParse(myEndDateString, myEndDate).ToString()
					
					
					
                    
                    xmlString += """cNum"":""" & Convert.ToInt16(odbcReader("cNum")) & ""","
                    xmlString += """Category"":""" & Trim(odbcReader("Category").ToString).Replace(Chr(34), "&#34;") & ""","
                    xmlString += """Title"":""" & Trim(odbcReader("Title").ToString).Replace(Chr(34), "&#34;") & ""","
                    xmlString += """StartDate"":""" & myDate.ToString("MM/dd/yyyy").Replace(Chr(34), "&#34;") & ""","
                    xmlString += """EndDate"":""" & myEndDate.ToString("MM/dd/yyyy").Replace(Chr(34), "&#34;") & ""","
		            xmlString += """StartTime"":""" & Trim(odbcReader("StartTime").ToString).Replace(Chr(34), "&#34;") & ""","
                    xmlString += """EndTime"":""" & Trim(odbcReader("EndTime").ToString).Replace(Chr(34), "&#34;") & ""","
                    xmlString += """ImageFile"":""" & Trim(odbcReader("fileName").ToString).Replace(Chr(34), "&#34;") & ""","
                    xmlString += """Location"":""" & Trim(odbcReader("Location").ToString).Replace(Chr(34), "&#34;") & ""","
					'xmlString += """Location"":""" & "" & ""","
                    xmlString += """Status"":""" & Trim(odbcReader("Status").ToString).Replace(Chr(34), "&#34;") & """},"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
		If xmlString = "" Then
			xmlString = "{},"
			
		End If
		
        xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
        xmlString = "[" & xmlString.Replace(vbCrLf, "") & "]"
        'xmlString = "callback([" & xmlString & "])"
        'Dim jsonStr As String = JsonConvert.SerializeXmlNode(doc)
        HttpContext.Current.Response.BufferOutput = True
    	HttpContext.Current.Response.ContentType = "application/x-javascript"
    	HttpContext.Current.Response.Write(xmlString)
    	HttpContext.Current.Response.Flush()
    	HttpContext.Current.Response.End()

    End Sub
    
	
	
    <WebMethod()> _
    Public Sub GetAnnouncementList()

        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblannouncements   ORDER BY StartDate ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    
                    xmlString += "{"
                    
                    
                    i += 1
                    
                    xmlString += """cNum"":""" & Convert.ToInt16(odbcReader("cNum")) & ""","
                    xmlString += """Category"":""" & Trim(odbcReader("Category").ToString).Replace(Chr(34), "&#34;") & ""","
                    xmlString += """Title"":""" & Trim(odbcReader("Title").ToString).Replace(Chr(34), "&#34;") & ""","
                    xmlString += """StartDate"":""" & Trim(odbcReader("StartDate").ToString).Replace(Chr(34), "&#34;") & ""","
                    xmlString += """EndDate"":""" & Trim(odbcReader("EndDate").ToString).Replace(Chr(34), "&#34;") & ""","
                    'xmlString += """Location"":""" & Trim(odbcReader("Location").ToString).Replace(Chr(34), "&#34;") & ""","
					xmlString += """Location"":""" & "" & ""","
                    xmlString += """Status"":""" & Trim(odbcReader("Status").ToString).Replace(Chr(34), "&#34;") & """},"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
        xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
        xmlString = "[" & xmlString.Replace(vbCrLf, "") & "]"
        'xmlString = "callback([" & xmlString & "])"
        'Dim jsonStr As String = JsonConvert.SerializeXmlNode(doc)
        HttpContext.Current.Response.BufferOutput = True
    	HttpContext.Current.Response.ContentType = "application/x-javascript"
    	HttpContext.Current.Response.Write(xmlString)
    	HttpContext.Current.Response.Flush()

    End Sub
    

    

   
   
    
    
	<WebMethod> _
	Public Sub UpdateAnnouncement(models As String)



		Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
		Dim ftbNum = x(0)("ftbNum")
		Dim pageName = x(0)("pageName")
		Dim content = x(0)("content")


			Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
			Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

			Dim sQueryString As String
			Try

					sQueryString = "UPDATE tblftb SET " & _
						"pageName = '" & Replace(pageName, "'", "''") & "', " & _
						"content = '" & Replace(content, "'", "''") & "' " & _
						"WHERE ftbNum = " & ftbNum

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
	Public Sub AddAnnouncement(models As String)


   
   
		Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
		Dim ftbNum = x(0)("ftbNum")
		Dim pageName = x(0)("pageName")
		Dim content = x(0)("content")
		'Dim Name = x(0)("Name")
		'Dim Address = x(0)("Address")
		'Dim ImageFile = x(0)("ImageFile")
		'Dim Status = x(0)("Status")("CategoryName")
		'Dim Type = x(0)("Type")("CategoryName")
        
        
        
        
		Dim xmlString As String = ""
		xmlString += "{"
		xmlString += """ftbNum"":""" & ftbNum & ""","
		xmlString += """pageName"":""" & pageName & ""","
		'xmlString += """Name"":""" & Name & ""","
		'xmlString += """Address"":""" & Address & ""","
		'xmlString += """ImageFile"":""" & ImageFile & ""","
		'xmlString += """Status"":""" & Status & ""","
		xmlString += """content"":""" & content & """},"
        
		xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
        'xmlString = "[" & xmlString & "]"
        'xmlString = "callback([" & xmlString & "])"
        
        
        

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        Dim sQueryString As String

        Try



			sQueryString = "INSERT INTO tblftb " & _
			"(pageName, " & _
			"content)" & _
			" VALUES " & _
			"('" & Replace(pageName, "'", "''") & _
			"', '" & Replace(content, "'", "''") & "')"

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
        HttpContext.Current.Response.Write("[" & xmlString & "]")
        HttpContext.Current.Response.Flush()

    End Sub
    
    
    
    
    


       
       
       
       
	Public Function DeletePageHistory(ByVal ftbNum As String) As Integer
		Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()
		
		Dim myDateString as String = DateTime.Now.AddHours(+2).ToString()
		Dim myDate as DateTime
		DateTime.TryParse(myDateString, myDate).ToString()
		
				
        Try
			
			
			
			sQueryString = "INSERT INTO tblftb_history SELECT 'delete', '" & myDate.ToString("yyyy/MM/dd HH:mm:ss") & "', NULL, d.* FROM tblftb AS d WHERE ftbNum =" & ftbNum


            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt
		
		
		
	End Function
       
        
    
    <WebMethod> _
    Public Sub DeleteAnnouncement(models As String)

       
          
		Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
		Dim cNum = x(0)("cNum")
       
       	'Dim histResult As Integer = DeletePageHistory(ftbNum)
       
       
        Dim sQueryString As String
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try

                sQueryString = "DELETE FROM tblannouncements WHERE cNum = " & cNum

           

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
    
    
    
    
End Class







Public Class City
    Public cityID as Integer
    Public population as Integer
    Public name as String
End Class




Public Class Product 
        Public Property CustomerID() As String 
        Public Property ContactName() As String 
        Public Property CompanyName() As String 
        Public Property ImageFile() As String 
End Class

Public Class CustomerViewModel


	Public Property CustomerID() As String
		Get
			Return m_CustomerID
		End Get
		Set
			m_CustomerID = Value
		End Set
	End Property
	Private m_CustomerID As String
    
    
    
    
	Public Property ContactName() As String
		Get
			Return m_ContactName
		End Get
		Set
			m_ContactName = Value
		End Set
	End Property
	Private m_ContactName As String
    
    

    Public Property CompanyName() As String
		Get
			Return m_CompanyName
		End Get
		Set
			m_CompanyName = Value
		End Set
	End Property
	Private m_CompanyName As String
    
    Public Property ImageFile() As String
		Get
			Return m_ImageFile
		End Get
		Set
			m_ImageFile = Value
		End Set
	End Property
	Private m_ImageFile As String

    
    
    

End Class











