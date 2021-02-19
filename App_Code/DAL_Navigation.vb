Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq

Public Class DAL_Navigation
	
	
	
	Public Shared Function BuildNavMobile()
		
		
			Dim header As String

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



						i += 1

						header +=  Trim(odbcReader("navObject").ToString) 
					End While

					odbcReader.Close()

				Catch ex As Exception

					odbcConn.Close()

				End Try

				odbcConn.Close()

			Catch ex As Exception

			End Try
		
			'Dim test As String
		    'Dim jsonString = "{""items"":{""1"":[{""text"":""Man"",""itemID"":""1"",""checked"":1,""sequence"":1,""matchingtext"":"""",""weight"":0},{""text"":""goat"",""itemID"":""2"",""checked"":0,""sequence"":2,""matchingtext"":"""",""weight"":0},{""text"":""dog"",""itemID"":""3"",""checked"":0,""sequence"":3,""matchingtext"":"""",""weight"":0}],""2"":[{""text"":""pizza"",""itemID"":""1"",""checked"":1,""sequence"":1,""matchingtext"":"""",""weight"":0},{""text"":""horse"",""itemID"":""2"",""checked"":0,""sequence"":2,""matchingtext"":"""",""weight"":0},{""text"":""paper"",""itemID"":""3"",""checked"":0,""sequence"":3,""matchingtext"":"""",""weight"":0}]},""wbmode"":""dd"",""wbanswertype"":""sc""}"
			
			
			
		
			Dim navRet As String
			header = header.Substring(1, header.Length()-2)
			header = "{""items"":[" & header & "]}"
			Dim dynamicObj = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Object)(header)
			Dim index As Integer = 0
			'Dim j As JObject = JObject.Parse(header)

			'Dim o As JObject = JObject.Parse(dynamicObj)
			
			For Each msg As JObject In dynamicObj("items")
				Dim navLabel As String
				Dim navHref As String
				Dim temp2 As String
				
				For Each p In msg
					If Not  p.Key.ToString = "children"
						If p.Key.ToString = "text" 
							navLabel = p.Value.ToString
						Else If p.Key.ToString = "href" 
							navHref = p.Value.ToString
						End If

					Else 
						Dim header2 = "{""items"":" & p.Value.ToString & "}"
						Dim dynamicObj2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Object)(header2)
						temp2 += vb_TraverseMobile(dynamicObj2)
					End If
				Next
				If temp2 = ""
			navRet += "<li class='bold'>" + "<a class='' href='" + navHref + "'><span>" + navLabel + "</span></a>" + "</li>"
				Else
			navRet += "<li class='bold'>" + "<a class='collapsible-header dropdown waves-effect waves-cyan'>" + navLabel + "</a><div class='collapsible-body'><ul>" + temp2 + "</ul></div></li>"
				End If
				temp2 = ""
				index += 1
			Next
		
			Return navRet
			
		End Function
Public Shared Function vb_TraverseMobile(msg As JObject) As String
			Dim navRet As String
			For Each obj As JObject In msg("items")
				Dim navLabel As String
				Dim navHref As String
				Dim temp2 As String
				For Each p in obj
					If Not p.Key.ToString = "children"
						If p.Key.ToString = "text" 
							navLabel = p.Value.ToString
						Else If p.Key.ToString = "href" 
							navHref = p.Value.ToString
						End If
					Else
						Dim header2 = "{""items"":" & p.Value.ToString & "}"
						Dim dynamicObj2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Object)(header2)
						temp2 += vb_TraverseMobile(dynamicObj2)
					End If
				Next

				
				If temp2 = ""
					navRet +=  "<li><a class='page-scroll' href='" + navHref + "'>" + navLabel + "</a></li>"
				Else
					'navRet += "<li  class='dropdown dropdown-submenu'>" + "<a class='dropdown-toggle' data-toggle='dropdown' class='page-scroll' href='#'>" + navLabel + "<span class='caret'></span></a>" + "<ul class='dropdown-menu'>" + temp2 + "</ul>" + "</li>"
				End If
				
				temp2 = ""
				
			Next
				
			
			Return navRet
			
		End Function
		
	
	
	Public Shared Function BuildNav()
		
		
			Dim header As String

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



						i += 1

						header +=  Trim(odbcReader("navObject").ToString) 
					End While

					odbcReader.Close()

				Catch ex As Exception

					odbcConn.Close()

				End Try

				odbcConn.Close()

			Catch ex As Exception

			End Try
		
			'Dim test As String
		    'Dim jsonString = "{""items"":{""1"":[{""text"":""Man"",""itemID"":""1"",""checked"":1,""sequence"":1,""matchingtext"":"""",""weight"":0},{""text"":""goat"",""itemID"":""2"",""checked"":0,""sequence"":2,""matchingtext"":"""",""weight"":0},{""text"":""dog"",""itemID"":""3"",""checked"":0,""sequence"":3,""matchingtext"":"""",""weight"":0}],""2"":[{""text"":""pizza"",""itemID"":""1"",""checked"":1,""sequence"":1,""matchingtext"":"""",""weight"":0},{""text"":""horse"",""itemID"":""2"",""checked"":0,""sequence"":2,""matchingtext"":"""",""weight"":0},{""text"":""paper"",""itemID"":""3"",""checked"":0,""sequence"":3,""matchingtext"":"""",""weight"":0}]},""wbmode"":""dd"",""wbanswertype"":""sc""}"
			
			
			
		
			Dim navRet As String
			header = header.Substring(1, header.Length()-2)
			header = "{""items"":[" & header & "]}"
			Dim dynamicObj = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Object)(header)
			Dim index As Integer = 0
			'Dim j As JObject = JObject.Parse(header)

			'Dim o As JObject = JObject.Parse(dynamicObj)
			
			For Each msg As JObject In dynamicObj("items")
				Dim navLabel As String
				Dim navHref As String
				Dim temp2 As String
				
				For Each p In msg
					If Not  p.Key.ToString = "children"
						If p.Key.ToString = "text" 
							navLabel = p.Value.ToString
						Else If p.Key.ToString = "href" 
							navHref = p.Value.ToString
						End If

					Else 
						Dim header2 = "{""items"":" & p.Value.ToString & "}"
						Dim dynamicObj2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Object)(header2)
						temp2 += vb_Traverse(dynamicObj2)
					End If
				Next
				If temp2 = ""
					navRet += "<li style='list-style-type: none !important;'>" + "<a class='page-scroll' href='" + navHref + "' index='" & index & "'>" + navLabel + "</a></li>"
				Else
					navRet += "<li style='list-style-type: none !important;'  class='dropdown menu-index'>" + "<a index='" & index & "' href='#'>" + navLabel + "<span class='caret'></span></a><ul class='dropdown-menu multi-level'>" & temp2 & "</ul></li>"
				End If
				temp2 = ""
				index += 1
			Next
		
			Return navRet
			
		End Function





		Public Shared Function BuildNavPortal()
		
		
			Dim header As String

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



						i += 1

						header +=  Trim(odbcReader("navObject").ToString) 
					End While

					odbcReader.Close()

				Catch ex As Exception

					odbcConn.Close()

				End Try

				odbcConn.Close()

			Catch ex As Exception

			End Try
		
			'Dim test As String
		    'Dim jsonString = "{""items"":{""1"":[{""text"":""Man"",""itemID"":""1"",""checked"":1,""sequence"":1,""matchingtext"":"""",""weight"":0},{""text"":""goat"",""itemID"":""2"",""checked"":0,""sequence"":2,""matchingtext"":"""",""weight"":0},{""text"":""dog"",""itemID"":""3"",""checked"":0,""sequence"":3,""matchingtext"":"""",""weight"":0}],""2"":[{""text"":""pizza"",""itemID"":""1"",""checked"":1,""sequence"":1,""matchingtext"":"""",""weight"":0},{""text"":""horse"",""itemID"":""2"",""checked"":0,""sequence"":2,""matchingtext"":"""",""weight"":0},{""text"":""paper"",""itemID"":""3"",""checked"":0,""sequence"":3,""matchingtext"":"""",""weight"":0}]},""wbmode"":""dd"",""wbanswertype"":""sc""}"
			
			
			
		
			Dim navRet As String
			header = header.Substring(1, header.Length()-2)
			header = "{""items"":[" & header & "]}"
			Dim dynamicObj = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Object)(header)
			Dim index As Integer = 0
			'Dim j As JObject = JObject.Parse(header)

			'Dim o As JObject = JObject.Parse(dynamicObj)
			
			For Each msg As JObject In dynamicObj("items")
				Dim navLabel As String
				Dim navHref As String
				Dim temp2 As String
				
				For Each p In msg
					If Not  p.Key.ToString = "children"
						If p.Key.ToString = "text" 
							navLabel = p.Value.ToString
						Else If p.Key.ToString = "href" 
							navHref = p.Value.ToString
						End If

					Else 
						Dim header2 = "{""items"":" & p.Value.ToString & "}"
						Dim dynamicObj2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Object)(header2)
						temp2 += vb_Traverse(dynamicObj2)
					End If
				Next
				If temp2 = ""
					navRet += "<li>" + "<a class='page-scroll' href='" + navHref + "' onMouseOver='mopen(""m" & index & " "")'>" + navLabel + "</a><div id='m" & index & "' onmouseover='mcancelclosetime()' onmouseout='mclosetime()' style='margin-left:-5000px; margin-top:0px;'></div>" + "</li>"
				Else
			navRet += "<li  class='dropdown'>" + "<a onMouseOver='mopen(""m" & index & """)'  href='#'>" + navLabel + "<span class='caret'></span></a><div id='m" & index & "' onmouseover='mcancelclosetime()' onmouseout='mclosetime()' style='margin-left:-15px; margin-top:0px;' >" & temp2 & "</div>" + "</li>"
				End If
				temp2 = ""
				index += 1
			Next
		
			Return navRet
			
		End Function





		
Public Shared Function vb_Traverse(msg As JObject) As String
			Dim navRet As String
			For Each obj As JObject In msg("items")
				Dim navLabel As String
				Dim navHref As String
				Dim temp2 As String
				For Each p in obj
					If Not p.Key.ToString = "children"
						If p.Key.ToString = "text" 
							navLabel = p.Value.ToString
						Else If p.Key.ToString = "href" 
							navHref = p.Value.ToString
						End If
					Else
						Dim header2 = "{""items"":" & p.Value.ToString & "}"
						Dim dynamicObj2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Object)(header2)
						temp2 += vb_Traverse(dynamicObj2)
					End If
				Next

				
				If temp2 = ""
					navRet +=  "<li style='list-style-type: none !important;'><a class='page-scroll' href='" + navHref + "'>" + navLabel + "</a></li>"
				Else
					'navRet += "<li  class='dropdown dropdown-submenu'>" + "<a class='dropdown-toggle' data-toggle='dropdown' class='page-scroll' href='#'>" + navLabel + "<span class='caret'></span></a>" + "<ul class='dropdown-menu'>" + temp2 + "</ul>" + "</li>"
				End If
				
				temp2 = ""
				
			Next
				
			
			Return navRet
			
		End Function
		
		
		
Public Shared Function GetNavObject() As String

			Dim header As String

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



						i += 1

						header +=  Trim(odbcReader("navHeader").ToString) 
					End While

					odbcReader.Close()

				Catch ex As Exception

					odbcConn.Close()

				End Try

				odbcConn.Close()

			Catch ex As Exception

			End Try
			
			
			Dim navHeader As String = BuildNav()
			
			header = header.Replace("[HEADER][/HEADER]", navHeader)
			
			
			
			
			
			
			
			Return header
		End Function
		




	Public Shared Function AddPage(ByVal oItem As PC_Widgets) As Integer

        Dim Rslt2 As Integer = 0
        Dim sortmax As Integer

        'sortmax = GetMaxSortNumber()

        Dim iResult As Integer = 0

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        Dim sQueryString As String

        Try

            With oItem
            'If oItem.pSort <= sortmax Then
            '    Rslt2 = SortInsertInList(oItem.pSort)
            'End If

            'If oItem.pSort > sortmax + 1 Or oItem.pSort < 1 Then
            '    oItem.pSort = sortmax + 1
            'End If

			sQueryString = "INSERT INTO tblwidgets " & _
				"(widgetName, " & _
				"content)" & _
                " VALUES " & _
                "('" & Replace(.widgetName, "'", "''") & _
				"', '" & Replace(.content, "'", "''") & "')"
            End With

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            iResult = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            iResult = 0

        End Try

        Return iResult

    End Function



Public Shared Function ModPageHistory(ByVal oItem As PC_Pages) As Integer

		Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()
		
		Dim myDateString as String = DateTime.Now.AddHours(+2).ToString()
		Dim myDate as DateTime
		DateTime.TryParse(myDateString, myDate).ToString()
		
				
        Try
			
			
			
			sQueryString = "INSERT INTO tblftb_history SELECT 'insert', '" & myDate.ToString("yyyy/MM/dd HH:mm:ss") & "', NULL, d.* FROM tblftb AS d WHERE ftbNum =" & oItem.ftbNum


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




Public Shared Function ModifyPage(ByVal oItem As PC_Widgets) As String

		'Dim histResult As Integer = ModPageHistory(oItem)
        Dim Rslt2 As Integer = 0
        Dim currentsortorder As Integer
        Dim sortmax As Integer


		Dim Result As String
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem

				sQueryString = "UPDATE tblwidgets SET " & _
					"widgetName = '" & Replace(.widgetName, "'", "''") & "', " & _
                    "content = '" & Replace(.content, "'", "''") & "' " & _
					"WHERE ftbNum = " & .ftbNum
            End With

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

			Result = "Success"

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

			Result = ex.ToString()

        End Try

        Return Result

    End Function

Public Shared Function GetPageNameByNum(ftbNum As String) As PC_Widgets

		Dim oItem As New PC_Widgets

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
			Dim sQueryString As String = "SELECT * FROM tblwidgets WHERE ftbNum = " & ftbNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

					oItem.ftbNum = Convert.ToInt16(odbcReader("ftbNum"))

					If odbcReader("widgetName").Equals(DBNull.Value) Then
                        oItem.widgetName = ""
                    Else
                        oItem.widgetName = Trim(odbcReader("widgetName").ToString)
                    End If
					If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If

                End If

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oItem

    End Function


End Class
