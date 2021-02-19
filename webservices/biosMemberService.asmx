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
    Public Sub GetBiosMemberList()



        Dim xmlData As New List(Of String)

		Dim doc As New XmlDocument()

        

		Dim xmlString As String = ""

        Try

            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString

            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

            Dim sQueryString As String = "SELECT * FROM tblbiosmembers "

            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)

            odbcConn.Open()

            

            Try



                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

				Dim i As Integer

                While odbcReader.Read()

                    

                    xmlString += "{"

                    

                    

                    i += 1

                    

                    xmlString += """bioId"":""" & Convert.ToInt16(odbcReader("bioId")) & ""","

                    'xmlString += """nTitle"":""" & Trim(odbcReader("nTitle").ToString) & ""","

                    xmlString += """fName"":""" & Trim(odbcReader("fName").ToString) & ""","
                    xmlString += """lName"":""" & Trim(odbcReader("lName").ToString) & ""","

                    xmlString += """title"":""" & Trim(odbcReader("title").ToString) & ""","
                    xmlString += """emailAddress"":""" & Trim(odbcReader("emailAddress").ToString) & ""","
                    xmlString += """hyperLink"":""" & Trim(odbcReader("hyperLink").ToString) & ""","
                    'xmlString += """fileName"":""" & Trim(odbcReader("Category").ToString) & ""","

                    xmlString += """Status"":""" & Trim(odbcReader("Status").ToString) & """},"

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
Public Sub UpdateBios(models As String)

    

    Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)

	Dim bioId = x(0)("bioId")

	Dim title = x(0)("title")

	Dim fName = x(0)("fName")

	Dim lName = x(0)("lName")
	
	Dim emailAddress = x(0)("emailAddress")

	Dim hyperLink = x(0)("hyperLink")

	

	
	

	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString

	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)



	Dim sQueryString As String

        Try

		  

                sQueryString = "UPDATE tblbiosmembers SET " & _
                    "fName = '" & Replace(fName, "'", "''") & "', " & _
                    "lName = '" & Replace(lName, "'", "''") & "', " & _
                    "title = '" & Replace(title, "'", "''") & "', " & _
                    "emailAddress = '" & Replace(emailAddress, "'", "''") & "', " & _
                    "hyperLink = '" & Replace(hyperLink, "'", "''") & "' " & _
                    "WHERE bioId = " & bioID

               

		  



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
        Public Sub AddBiosMember(models As String)





   

   

		Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)

		Dim boiId = x(0)("bioId")

		Dim fName = x(0)("fName")

		Dim lName = x(0)("lName")

		Dim title = x(0)("title")

		Dim emailAddress = x(0)("emailAddress")

		Dim hyperLink = x(0)("hyperLink")

		'Dim Status = x(0)("Status")("CategoryName")

		'Dim Type = x(0)("Type")("CategoryName")

        

        

        

        

		Dim xmlString As String = ""

		xmlString += "{"
		xmlString += """fName"":""" & fName & ""","
		xmlString += """lName"":""" & lName & ""","
		xmlString += """title"":""" & title & ""","
		xmlString += """emailAddress"":""" & emailAddress & ""","
		xmlString += """hyperLink"":""" & hyperLink & """},"

        

		'xmlString = xmlString.Trim().Substring(0, xmlString.Length - 1)

        'xmlString = "[" & xmlString & "]"

        'xmlString = "callback([" & xmlString & "])"

        

        

        



        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString

        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Dim sQueryString As String



        Try







			sQueryString = "INSERT INTO tblbiosmembers " & _
			"(fName, " & _
			"lName," & _
			"title," & _
			"emailAddress," & _
			"hyperLink)" & _
			" VALUES " & _
			"('" & Replace(fName, "'", "''") & _
			"', '" & Replace(lName, "'", "''") & _
			"', '" & Replace(title, "'", "''") & _
			"', '" & Replace(emailAddress, "'", "''") & _
			"', '" & Replace(hyperLink, "'", "''") & "')"



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
    Public Sub DeleteBiosMember(models As String)



       

          

		Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)

		Dim CompanyName = x(0)("CompanyName")

		Dim ContactName = x(0)("ContactName")

		Dim bioId = x(0)("bioId")

       

       

        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString

        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)



        Try



                sQueryString = "DELETE FROM tblbiosmembers WHERE bioId = " & bioId



           



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



        

        

        

        

	Public Function DeleteNewsHistory(ByVal nNum As String) As Integer

		Dim Rslt As Integer = 0

        Dim sQueryString As String



        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString

        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        odbcConn.Open()

		

		Dim myDateString as String = DateTime.Now.AddHours(+2).ToString()

		Dim myDate as DateTime

		DateTime.TryParse(myDateString, myDate).ToString()

		

				

        Try

			

			

			

			sQueryString = "INSERT INTO tblnewsftb_history SELECT 'delete', '" & myDate.ToString("yyyy/MM/dd HH:mm:ss") & "', NULL, d.* FROM tblnewsftb AS d WHERE nNum =" & nNum





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
    Public Sub DeleteNews(models As String)



       

        

		Dim x As Object = JsonConvert.DeserializeObject(of Object)(models)

		Dim nNum = x(0)("nNum")

		'Dim pageName = x(0)("pageName")

		'Dim content = x(0)("content")

       

       	Dim histResult As Integer = DeleteNewsHistory(nNum)

       

        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString

        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)



        Try



                sQueryString = "DELETE FROM tblnewsftb WHERE nNum = " & nNum



           



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

	HttpContext.Current.Response.Write(histResult)

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























