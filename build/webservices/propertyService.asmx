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
    Public Function GetAllActiveSites2() As XmlDocument

        Dim oList As New List(Of PC_Listing)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblowners WHERE Status = 'Active' "
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    Dim oItem As New PC_Listing
                    
                    xmlString += "<marker "
                    
                    
                    i += 1
                    oItem.pId = Convert.ToInt16(odbcReader("pId"))
                    xmlString += "id='" & Convert.ToInt16(odbcReader("pId")) & "' "
                    xmlString += "ContactName='" & SecurityElement.Escape(Trim(odbcReader("pName").ToString)) & "' "
                    'xmlString += "address='" & SecurityElement.Escape(Trim(odbcReader("address").ToString)) & "' "
                    'xmlString += "website='" & SecurityElement.Escape(Trim(odbcReader("website").ToString)) & "' "
                    'xmlString += "image='" & SecurityElement.Escape(Trim(odbcReader("Image1").ToString)) & "' "
                    'xmlString += "lat='" & Trim(odbcReader("lat").ToString) & "' "
                    'xmlString += "lng='" & Trim(odbcReader("lng").ToString) & "' "
                    xmlString += "type='" & Trim(odbcReader("pType").ToString) & "' />"
					'xmlString += "</marker>"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
        
		doc.LoadXml("<markers>" & xmlString &  "</markers>")
        Return doc

    End Function


    
    <WebMethod()> _
    Public Sub GetAllActiveSites3()

        Dim oList As New List(Of PC_Listing)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblowners WHERE Status = 'Active' "
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()
            
            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
				Dim i As Integer
                While odbcReader.Read()
                    Dim oItem As New PC_Listing
                    
                    xmlString += "<marker "
                    
                    
                    i += 1
                    oItem.pId = Convert.ToInt16(odbcReader("pId"))
                    xmlString += "id='" & Convert.ToInt16(odbcReader("pId")) & "' "
                    xmlString += "ContactName='" & SecurityElement.Escape(Trim(odbcReader("pName").ToString)) & "' "
                    'xmlString += "address='" & SecurityElement.Escape(Trim(odbcReader("address").ToString)) & "' "
                    'xmlString += "website='" & SecurityElement.Escape(Trim(odbcReader("website").ToString)) & "' "
                    'xmlString += "image='" & SecurityElement.Escape(Trim(odbcReader("Image1").ToString)) & "' "
                    'xmlString += "lat='" & Trim(odbcReader("lat").ToString) & "' "
                    'xmlString += "lng='" & Trim(odbcReader("lng").ToString) & "' "
                    xmlString += "type='" & Trim(odbcReader("pType").ToString) & "' />"
					'xmlString += "</marker>"
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try
        
		doc.LoadXml("<markers>" & xmlString &  "</markers>")
        
                Dim jsonStr As String = JsonConvert.SerializeXmlNode(doc)
        jsonStr = jsonStr.Replace("," & Chr(34) & "@", "," & Chr(34))
        jsonStr = jsonStr.Replace("{" & Chr(34) & "@", "{" & Chr(34))
        HttpContext.Current.Response.BufferOutput = True
    	HttpContext.Current.Response.ContentType = "application/json"
    	HttpContext.Current.Response.Write(jsonStr)
    	HttpContext.Current.Response.Flush()
        
        

    End Sub
    
    
    
        
    <WebMethod()> _
    Public Sub GetAllOwners()

        Dim oList As New List(Of PC_Listing)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblowners WHERE Status = 'Active' "
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
                    xmlString += """Name"":""" & Trim(odbcReader("pName").ToString) & ""","
                    xmlString += """Address"":""" & Trim(odbcReader("pAddress").ToString) & ""","
                    xmlString += """ImageFile"":""" & Trim(odbcReader("ImageFile1").ToString) & ""","
                    xmlString += """Sleeps"":""" & Trim(odbcReader("pSleeps").ToString) & ""","
                    xmlString += """Bedrooms"":""" & Trim(odbcReader("pBedrooms").ToString) & ""","
                    xmlString += """Bathrooms"":""" & Trim(odbcReader("pBathrooms").ToString) & ""","
                    xmlString += """description"":""" & HttpUtility.HtmlDecode(Trim(odbcReader("pDescription").ToString())).Replace(Chr(34), "'") & ""","
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
        'jsonStr = jsonStr.Replace("," & Chr(34) & "@", "," & Chr(34))
        'jsonStr = jsonStr.Replace("{" & Chr(34) & "@", "{" & Chr(34))
        HttpContext.Current.Response.BufferOutput = True
    	HttpContext.Current.Response.ContentType = "application/x-javascript"
    	HttpContext.Current.Response.Write(xmlString)
    	HttpContext.Current.Response.Flush()
        
        

    End Sub
    
    
    
    
    
    
    
    
    
    
    
    
    
    
        <WebMethod()> _
    Public Sub GetOwnersByStr(propertyStr As String, addressStr As String)

        Dim oList As New List(Of PC_Listing)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblowners WHERE Status = 'Active' AND " & "pName = '" & propertyStr & "' AND " & "pAddress = '" & addressStr & "'"
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
                    xmlString += """Name"":""" & Trim(odbcReader("pName").ToString) & ""","
                    xmlString += """Address"":""" & Trim(odbcReader("pAddress").ToString) & ""","
                    xmlString += """ImageFile"":""" & Trim(odbcReader("ImageFile1").ToString) & ""","
                    xmlString += """Sleeps"":""" & Trim(odbcReader("pSleeps").ToString) & ""","
                    xmlString += """Bedrooms"":""" & Trim(odbcReader("pBedrooms").ToString) & ""","
                    xmlString += """Bathrooms"":""" & Trim(odbcReader("pBathrooms").ToString) & ""","
                    xmlString += """description"":""" & HttpUtility.HtmlDecode(Trim(odbcReader("pDescription").ToString())).Replace(Chr(34), "'") & ""","
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
        'jsonStr = jsonStr.Replace("," & Chr(34) & "@", "," & Chr(34))
        'jsonStr = jsonStr.Replace("{" & Chr(34) & "@", "{" & Chr(34))
        HttpContext.Current.Response.BufferOutput = True
    	HttpContext.Current.Response.ContentType = "application/x-javascript"
    	HttpContext.Current.Response.Write(xmlString)
    	HttpContext.Current.Response.Flush()
        
        

    End Sub
    
    
    
    
    
    
    
    
        
        
    <WebMethod()> _
    Public Sub GetAllOwnersAutoComplete()

        Dim oList As New List(Of PC_Listing)
        Dim xmlData As New List(Of String)
		Dim doc As New XmlDocument()
        
		Dim xmlString As String = ""
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblowners WHERE Status = 'Active' "
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
                    xmlString += """Name"":""" & Trim(odbcReader("pName").ToString) & ", " & Trim(odbcReader("pAddress").ToString) & ""","
                    xmlString += """ImageFile"":""" & Trim(odbcReader("ImageFile1").ToString) & ""","
                    xmlString += """CompanyName"":""" & Trim(odbcReader("pType").ToString) & """},"
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
    
    
    
    
    
    
    <WebMethod> _
Public Sub save2() 

		Dim ret As String = ""
		Dim request As HttpRequest = Me.Context.Request
		Dim file As HttpPostedFile = request.Files("filename")
		Dim FileName As String = file.FileName
		Dim cropName As String = request("filename")

		Dim ext As String = Path.GetExtension(FileName).ToLower()

		If Not (ext = ".png" OrElse ext = ".jpg" OrElse ext = ".jpeg") Then
			' for only images file
			ret = String.Format("File extension {0} not allowed.", ext)

		End If

		If FileName <> "" Then
			'Dim path__1 As String = HttpRuntime.BinDirectory

			'Dim UUID As String = System.Guid.NewGuid().ToString()
			'Dim filepath As String = (Convert.ToString(path__1 & Convert.ToString("upload/")) & UUID) + ".jpg"
			
			'file.SaveAs(filepath)
		End If
End Sub
    
    
    
    <WebMethod> _
Public Sub save4(filestream As Stream) 

	
	
	
	
	
	HttpContext.Current.Response.BufferOutput = True
	HttpContext.Current.Response.ContentType = "application/json"
	HttpContext.Current.Response.Write("")
	HttpContext.Current.Response.Flush()
End Sub
    
 
    
    
    
<WebMethod> _
Public Sub save()

		
	Dim loop1 As Integer
	Dim arr1() As String
	Dim Files As HttpFileCollection
	Dim memFile As HttpPostedFile
	Dim bytReq(0) As Byte


	Dim intLen As Integer


	Dim strParam As String


	Files = HttpContext.Current.Request.Files 


	arr1 = Files.AllKeys 


	Dim strResult As String


	Dim strFname As String


	Dim strParams() As String


	For loop1 = 0 To arr1.GetUpperBound(0)


	strResult &= "File control: " & Server.HtmlEncode(arr1(loop1)) & vbCrLf


	memFile = HttpContext.Current.Request.Files(arr1(loop1))


	strFname = memFile.FileName


	strResult &= "File Name: " & strFname & vbCrLf


	memFile.SaveAs(Server.MapPath("..\Documents\Owners\Thumbs") & "\" &
	System.IO.Path.GetFileName(strFname))


	strParams = Split(strFname, vbTab)


	Next loop1


	For Each strParam In strParams
	strResult &= vbCrLf & strParam
	Next

		
		
End Sub
    
    
    
    
<WebMethod> _
Public Sub updateGrid(models As String)
   
   
   
    Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
	Dim Type = x(0)("Type")
	Dim Name = x(0)("Name")
	Dim CustomerID = x(0)("CustomerID")
	Dim Address = x(0)("Address")
	Dim Sort = x(0)("Sort")
	Dim Status = x(0)("Status")
	Dim ImageFile = x(0)("ImageFile")
	
	
	    Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Dim sQueryString As String
        Try

                sQueryString = "UPDATE tblowners SET " & _
                    "pName = '" & Replace(Name, "'", "''") & "', " & _
                    "pSort = '" & Replace(Sort, "'", "''") & "', " & _
                    "pType = '" & Replace(Type, "'", "''") & "', " & _
                    "ImageFile1 = '" & Replace(ImageFile, "'", "''") & "', " & _
                    "Status = '" & Replace(Status, "'", "''") & "', " & _
                    "pAddress = '" & Replace(Address, "'", "''") & "' " & _
                    "WHERE pID = " & CustomerID

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
        Public Sub AddOwnerListing(pLinkId As String, models As String)


   
   
		Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
		Dim CustomerID = x(0)("CustomerID")
		Dim Sort = x(0)("Sort")
		Dim Name = x(0)("Name")
		Dim Address = x(0)("Address")
		Dim ImageFile = x(0)("ImageFile")
		Dim Status = x(0)("Status")("CategoryName")
		Dim Type = x(0)("Type")("CategoryName")
        
        
        
        
		Dim xmlString As String = ""
		xmlString += "{"
		xmlString += """CustomerID"":""" & CustomerID & ""","
		xmlString += """Sort"":""" & Sort & ""","
		xmlString += """Name"":""" & Name & ""","
		xmlString += """Address"":""" & Address & ""","
		xmlString += """ImageFile"":""" & ImageFile & ""","
		xmlString += """Status"":""" & Status & ""","
		xmlString += """Type"":""" & Type & """},"
        
		xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)
        'xmlString = "[" & xmlString & "]"
        'xmlString = "callback([" & xmlString & "])"
        
        
        

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        Dim sQueryString As String

        Try



			sQueryString = "INSERT INTO tblowners " & _
			"(pName, " & _
			"pLinkId, " & _
			"pSort, " & _
			"pAddress, " & _
			"ImageFile1, " & _
			"pType, " & _
			"Status)" & _
			" VALUES " & _
			"('" & Replace(Name, "'", "''") & _
			"', '" & Replace(pLinkId, "'", "''") & _
			"', '" & Replace(Sort, "'", "''") & _
			"', '" & Replace(Address, "'", "''") & _
			"', '" & Replace(ImageFile, "'", "''") & _
			"', '" & Replace(Type, "'", "''") & _
			"', '" & Replace(Status, "'", "''") & "')"

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
    
    
    
    
    
    
    <WebMethod> _
    Public Sub DeleteOwnerListing(models As String)

       
          
		Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)
		Dim CompanyName = x(0)("CompanyName")
		Dim ContactName = x(0)("ContactName")
		Dim CustomerID = x(0)("CustomerID")
       
       
        Dim sQueryString As String
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try

                sQueryString = "DELETE FROM tblowners WHERE pID = " & CustomerID

           

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











