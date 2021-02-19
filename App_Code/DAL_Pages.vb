Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class DAL_Pages

	


Public Shared Function AddPage(ByVal oItem As PC_Pages) As Integer

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

			sQueryString = "INSERT INTO tblftb " & _
                "(pageName, " & _
                "HeaderImage, " & _
                "HeaderImageText, " & _
				"meta_title, " & _
                "description, " & _
                "keywords, " & _
                "content, " & _
				"guid)" & _
                " VALUES " & _
                "('" & Replace(.pageName, "'", "''") & _
                "', '" & Replace(.HeaderImage, "'", "''") & _
                "', '" & Replace(.HeaderImageText, "'", "''") & _
				"', '" & Replace(.meta_title, "'", "''") & _
                "', '" & Replace(.description, "'", "''") & _
                "', '" & Replace(.keywords, "'", "''") & _
                "', '" & Replace(.content, "'", "''") & _
				"', '" & Replace(.guid, "'", "''") & "')"
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




Public Shared Function ModifyPage(ByVal oItem As PC_Pages) As String

		Dim histResult As Integer = ModPageHistory(oItem)
        Dim Rslt2 As Integer = 0
        Dim currentsortorder As Integer
        Dim sortmax As Integer


		Dim Result As String
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem

					sQueryString = "UPDATE tblftb SET " & _
					"pageName = '" & Replace(.pageName, "'", "''") & "', " & _
					"HeaderImage = '" & Replace(.HeaderImage, "'", "''") & "', " & _
					"HeaderImageText = '" & Replace(.HeaderImageText, "'", "''") & "', " & _
					"meta_title = '" & Replace(.meta_title, "'", "''") & "', " & _
					"description = '" & Replace(.description, "'", "''") & "', " & _
					"keywords = '" & Replace(.keywords, "'", "''") & "', " & _
					"guid = '" & Replace(.guid, "'", "''") & "', " & _
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

	Public Shared Function GetPageNameByNum(ftbNum As String) As PC_Pages

		Dim oItem As New PC_Pages

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
			Dim sQueryString As String = "SELECT * FROM tblftb WHERE ftbNum = " & ftbNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

					oItem.ftbNum = Convert.ToInt16(odbcReader("ftbNum"))

					If odbcReader("pageName").Equals(DBNull.Value) Then
                        oItem.pageName = ""
                    Else
                        oItem.pageName = Trim(odbcReader("pageName").ToString)
                    End If
					If odbcReader("HeaderImage").Equals(DBNull.Value) Then
                        oItem.HeaderImage = ""
                    Else
                        oItem.HeaderImage = Trim(odbcReader("HeaderImage").ToString)
                    End If
					If odbcReader("HeaderImageText").Equals(DBNull.Value) Then
                        oItem.HeaderImageText = ""
                    Else
                        oItem.HeaderImageText = Trim(odbcReader("HeaderImageText").ToString)
                    End If
					If odbcReader("meta_title").Equals(DBNull.Value) Then
                        oItem.meta_title = ""
                    Else
                        oItem.meta_title = Trim(odbcReader("meta_title").ToString)
                    End If
					If odbcReader("description").Equals(DBNull.Value) Then
                        oItem.description = ""
                    Else
                        oItem.description = Trim(odbcReader("description").ToString)
                    End If
					If odbcReader("keywords").Equals(DBNull.Value) Then
                        oItem.keywords = ""
                    Else
                        oItem.keywords = Trim(odbcReader("keywords").ToString)
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
