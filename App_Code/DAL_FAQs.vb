Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Mail

Public Class DAL_FAQs

#Region "FAQs"

    Public Shared Function GetAllFAQs(ByVal FAQsStatus As String) As List(Of PC_FAQs)

        Dim oList As New List(Of PC_FAQs)

        'possible statuses are CURRENT and ARCHIVED
        If Len(FAQsStatus) <= 0 Or FAQsStatus <> "Inactive" Then
            FAQsStatus = "Active"
        End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblfaqs ORDER BY Status ASC, fSort ASC, question ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_FAQs


                    oItem.fNum = Convert.ToInt16(odbcReader("fNum"))
                    If odbcReader("fSort").Equals(DBNull.Value) Then
                        oItem.fSort = ""
                    Else
                        oItem.fSort = Trim(odbcReader("fSort").ToString)
                    End If
                    If odbcReader("question").Equals(DBNull.Value) Then
                        oItem.question = ""
                    Else
                        oItem.question = Trim(odbcReader("question").ToString)
                    End If
                    If odbcReader("answer").Equals(DBNull.Value) Then
                        oItem.answer = ""
                    Else
                        oItem.answer = Trim(odbcReader("answer").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    oList.Add(oItem)
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oList

    End Function

    Public Shared Function GetFAQsLast5() As List(Of PC_FAQs)

        Dim oList As New List(Of PC_FAQs)
        Dim counter As Integer = 0

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblfaqs WHERE Status = 'Active' ORDER BY fSort ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 5 Then

                    Dim oItem As New PC_FAQs


                    oItem.fNum = Convert.ToInt16(odbcReader("fNum"))
                    If odbcReader("fSort").Equals(DBNull.Value) Then
                        oItem.fSort = ""
                    Else
                        oItem.fSort = Trim(odbcReader("fSort").ToString)
                    End If
                    If odbcReader("question").Equals(DBNull.Value) Then
                        oItem.question = ""
                    Else
                        oItem.question = Trim(odbcReader("question").ToString)
                    End If
                    If odbcReader("answer").Equals(DBNull.Value) Then
                        oItem.answer = ""
                    Else
                        oItem.answer = Trim(odbcReader("answer").ToString)
						If Len(oItem.answer) > 125 then 
						oItem.answer = Left(oItem.answer, 125) & "..."
						End If
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    oList.Add(oItem)
					counter = counter + 1
					End If
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oList

    End Function

    Public Shared Function GetActiveFAQs() As List(Of PC_FAQs)

        Dim oList As New List(Of PC_FAQs)

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblfaqs WHERE Status = 'Active' ORDER BY fSort ASC, question ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_FAQs


                    oItem.fNum = Convert.ToInt16(odbcReader("fNum"))
                    If odbcReader("fSort").Equals(DBNull.Value) Then
                        oItem.fSort = ""
                    Else
                        oItem.fSort = Trim(odbcReader("fSort").ToString)
                    End If
                    If odbcReader("question").Equals(DBNull.Value) Then
                        oItem.question = ""
                    Else
                        oItem.question = Trim(odbcReader("question").ToString)
                    End If
                    If odbcReader("answer").Equals(DBNull.Value) Then
                        oItem.answer = ""
                    Else
                        oItem.answer = Trim(odbcReader("answer").ToString)
						If Len(oItem.answer) > 125 then 
						oItem.answer = Left(oItem.answer, 125) & "..."
						End If
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    oList.Add(oItem)
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oList

    End Function

    Public Shared Function GetInactiveFAQs() As List(Of PC_FAQs)

        Dim oList As New List(Of PC_FAQs)

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblfaqs WHERE Status = 'Inactive' ORDER BY fSort ASC, question ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_FAQs


                    oItem.fNum = Convert.ToInt16(odbcReader("fNum"))
                    If odbcReader("fSort").Equals(DBNull.Value) Then
                        oItem.fSort = ""
                    Else
                        oItem.fSort = Trim(odbcReader("fSort").ToString)
                    End If
                    If odbcReader("question").Equals(DBNull.Value) Then
                        oItem.question = ""
                    Else
                        oItem.question = Trim(odbcReader("question").ToString)
                    End If
                    If odbcReader("answer").Equals(DBNull.Value) Then
                        oItem.answer = ""
                    Else
                        oItem.answer = Trim(odbcReader("answer").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    oList.Add(oItem)
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oList

    End Function

    Public Shared Function GetFAQsByNum(ByVal fNum As Integer) As PC_FAQs

        Dim oItem As New PC_FAQs

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblfaqs WHERE fNum = " & fNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.fNum = Convert.ToInt16(odbcReader("fNum"))
                    If odbcReader("fSort").Equals(DBNull.Value) Then
                        oItem.fSort = ""
                    Else
                        oItem.fSort = Trim(odbcReader("fSort").ToString)
                    End If
                    If odbcReader("question").Equals(DBNull.Value) Then
                        oItem.question = ""
                    Else
                        oItem.question = Trim(odbcReader("question").ToString)
                    End If
                    If odbcReader("answer").Equals(DBNull.Value) Then
                        oItem.answer = ""
                    Else
                        oItem.answer = Trim(odbcReader("answer").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If
                Else
                    oItem.fNum = 0
                End If

                odbcReader.Close()
                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                odbcConn.Dispose()

            End Try

        Catch ex As Exception

        End Try

        Return oItem

    End Function

    Public Shared Function AddFAQs(ByVal oItem As PC_FAQs) As Integer

        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim sQueryString As String
        Dim sortmax As Integer

        sortmax = GetMaxSortNumber()

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()
		
        'Dim tempD As String 
        'Dim monD As String = ""
		'Dim dyD As String = ""
		'Dim yrD As String = ""
        'If InStr(oItem.ItemDate, "/") = 2 Then 
            'oItem.ItemDate = "0" & oItem.ItemDate 
        'End If 
        'monD = Left(oItem.ItemDate, 2)
		
        'tempD = Right(oItem.ItemDate, Len(oItem.ItemDate) - 3) 
        'If InStr(tempD, "/") = 2 Then 
			'tempD = "0" & tempD
            'oItem.ItemDate = Left(oItem.ItemDate, 3) & tempD 
        'End If
		'dyD = Left(tempD, 2)
		'yrD = Right(oItem.ItemDate, 4)
		
        'oItem.ItemDate = yrD & "/" & monD & "/" & dyD
				
        Try
            If oItem.fSort <= sortmax Then
                Rslt2 = SortInsertInList(oItem.fSort)
            End If

            'do not allow sort position outside of current min-max range - retain default next position number
            If oItem.fSort > sortmax + 1 Or oItem.fSort < 1 Then
                oItem.fSort = sortmax + 1
            End If

            sQueryString = "INSERT INTO tblfaqs " & _
            "(fSort, " & _
            "question, " & _
            "answer, " & _
            "Status)" & _
            " VALUES " & _
            "('" & Replace(oItem.fSort, "'", "''") & _
            "', '" & Replace(oItem.question, "'", "''") & _
            "', '" & Replace(oItem.answer, "'", "''") & _
            "', 'Active'" & ")"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

    Public Shared Function ModFAQs(ByVal oItem As PC_FAQs) As Integer

        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim sQueryString As String
        Dim currentsortorder As Integer
        Dim sortmax As Integer

        sortmax = GetMaxSortNumber()

        currentsortorder = GetCurrentSortNumber(oItem.fNum)

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()

        'Dim tempD As String 
        'Dim monD As String = ""
		'Dim dyD As String = ""
		'Dim yrD As String = ""
        'If InStr(oItem.ItemDate, "/") = 2 Then 
            'oItem.ItemDate = "0" & oItem.ItemDate 
        'End If 
        'monD = Left(oItem.ItemDate, 2)
		
        'tempD = Right(oItem.ItemDate, Len(oItem.ItemDate) - 3) 
        'If InStr(tempD, "/") = 2 Then 
			'tempD = "0" & tempD
            'oItem.ItemDate = Left(oItem.ItemDate, 3) & tempD 
        'End If
		'dyD = Left(tempD, 2)
		'yrD = Right(oItem.ItemDate, 4)
		
        'oItem.ItemDate = yrD & "/" & monD & "/" & dyD
				
        Try
            With oItem
                If .fSort <> currentsortorder Then
                    Rslt2 = SortMovePositionInList(.fNum, currentsortorder, .fSort)
                End If

                'do not allow sort position outside of current min-max range - keep current position
                If .fSort > sortmax Or .fSort < 1 Then
                    .fSort = currentsortorder
                End If

                sQueryString = "UPDATE tblfaqs " & _
                "SET fSort = '" & Replace(.fSort, "'", "''") & _
                "', question = '" & Replace(.question, "'", "''") & _
                "', answer = '" & Replace(.answer, "'", "''") & _
                "', Status = '" & Replace(.Status, "'", "''") & _
                "' WHERE fNum = " & .fNum
            End With

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

    Public Shared Function DelFAQs(ByVal oItem As PC_FAQs) As Integer

        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim sQueryString As String
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem
                .fSort = GetCurrentSortNumber(.fNum)
                sQueryString = "DELETE FROM tblfaqs WHERE fNum = " & .fNum
                Rslt2 = SortDeleteFromList(.fSort)
            End With

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

#End Region

#Region "Sorting"

    Public Shared Function GetMaxSortNumber() As Integer

        Dim sortmax As Integer

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT MAX(fSort) as sortmax FROM tblfaqs HAVING MAX(fSort) > 0"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    sortmax = Convert.ToInt16(odbcReader("sortmax"))

                Else
                    sortmax = 0
                End If

                odbcReader.Close()
                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                sortmax = 0

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return sortmax

    End Function

    Public Shared Function GetCurrentSortNumber(ByVal fNum As Integer) As Integer

        Dim sort As Integer

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT fSort FROM tblfaqs WHERE fNum = " & fNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    sort = Convert.ToInt16(odbcReader("fSort"))

                Else
                    sort = 0
                End If

                odbcReader.Close()
                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                sort = 0

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return sort

    End Function

    Public Shared Function SortMovePositionInList(ByVal fNum As Integer, ByVal oldsortposition As Integer, ByVal newsortposition As Integer) As Integer

        Dim Rslt1 As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim maxsort As Integer = 0

        maxsort = GetMaxSortNumber()

        If maxsort > 0 And oldsortposition > 0 And newsortposition > 0 And oldsortposition <= maxsort And newsortposition <= maxsort Then

            If oldsortposition > newsortposition Then
                Rslt1 = SortMoveUpInList(oldsortposition, newsortposition)
            End If

            If oldsortposition < newsortposition Then
                Rslt1 = SortMoveDownInList(oldsortposition, newsortposition)
            End If

            Rslt2 = SortUpdateRecordPosition(fNum, oldsortposition, newsortposition)

            If Rslt1 > 0 And Rslt2 > 0 Then
                Return 1
            Else
                Return 0
            End If

        Else
            Return 0
        End If

    End Function

    Public Shared Function SortMoveUpInList(ByVal oldsortposition As Integer, ByVal newsortposition As Integer) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tblfaqs " & _
                " SET fSort = fSort + 1 " & _
                " WHERE fSort >= " & newsortposition & _
                "  AND  fSort <  " & oldsortposition

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

    Public Shared Function SortMoveDownInList(ByVal oldsortposition As Integer, ByVal newsortposition As Integer) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tblfaqs " & _
                " SET fSort = fSort - 1 " & _
                " WHERE fSort >  " & oldsortposition & _
                "  AND  fSort <= " & newsortposition

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

    Public Shared Function SortUpdateRecordPosition(ByVal fNum As Integer, ByVal oldsortposition As Integer, ByVal newsortposition As Integer) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tblfaqs " & _
                " SET fSort = " & newsortposition & _
                " WHERE fNum = " & fNum

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

    Public Shared Function SortInsertInList(ByVal newsortposition As Integer) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tblfaqs " & _
                " SET fSort = fSort + 1 " & _
                " WHERE fSort >= " & newsortposition

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

    Public Shared Function SortDeleteFromList(ByVal oldsortposition As Integer) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tblfaqs " & _
                " SET fSort = fSort - 1 " & _
                " WHERE fSort >  " & oldsortposition

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

#End Region

End Class
