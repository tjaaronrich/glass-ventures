Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Mail

Public Class DAL_NewsFTB

#Region "News"

    Public Shared Function FileNameExists(ByVal fn As String) As Integer

        Dim fnCount As Integer = 0
			
        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT count(*) as FileCount FROM tblnewsftb WHERE ImageFile = '" & fn & "'"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    fnCount = Convert.ToInt16(odbcReader("FileCount"))
                End If

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()
                Return 1

            End Try

            odbcConn.Close()

        Catch ex As Exception
            Return 1
        End Try

        If fnCount < 1 Then
            Return 0    'does not exist
        Else
            Return 1    'exists
        End If

    End Function

    Public Shared Function GetAllNews(ByVal NewsStatus As String) As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)

        'possible statuses are CURRENT and ARCHIVED
        If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            NewsStatus = "Active"
        End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb ORDER BY Status ASC, ItemDate DESC, title ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    'oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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
	
	
	
    Public Shared Function GetAllLand(ByVal NewsStatus As String) As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)

        'possible statuses are CURRENT and ARCHIVED
        If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            NewsStatus = "Active"
        End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tbllandftb ORDER BY Status ASC, ItemDate DESC, title ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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
	

    Public Shared Function GetActiveNews() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    'If odbcReader("Summary").Equals(DBNull.Value) Then
                    '    oItem.Summary = ""
                    'Else
                    '    oItem.Summary = Trim(odbcReader("Summary").ToString)
					'	If Len(oItem.Summary) > 85 then 
					'	oItem.Summary = Left(oItem.Summary, 85) & "..."
					'	End If
                    'End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    'oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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
	
	Public Shared Function GetActiveNews1() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)
        Dim counter As Integer = 0

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
					'If odbcReader("Title").Equals(DBNull.Value) Then
                    '    oItem.Title = ""
                    'Else
                    '    oItem.Title = Trim(odbcReader("Title").ToString)
					'	If Len(oItem.Title) > 40 then 
					'	oItem.Title = Left(oItem.Title, 40) & "..."
					'	End If
                    'End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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
	
	
	
	Public Shared Function GetActiveLand1() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)
        Dim counter As Integer = 0

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tbllandftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
					'If odbcReader("Title").Equals(DBNull.Value) Then
                    '    oItem.Title = ""
                    'Else
                    '    oItem.Title = Trim(odbcReader("Title").ToString)
					'	If Len(oItem.Title) > 40 then 
					'	oItem.Title = Left(oItem.Title, 40) & "..."
					'	End If
                    'End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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
	
	
	
	
	
	
	Public Shared Function GetActiveNews2() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)
        Dim counter As Integer = 0

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC LIMIT 1,1"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
					'If odbcReader("Title").Equals(DBNull.Value) Then
                    '    oItem.Title = ""
                    'Else
                    '    oItem.Title = Trim(odbcReader("Title").ToString)
					'	If Len(oItem.Title) > 40 then 
					'	oItem.Title = Left(oItem.Title, 40) & "..."
					'	End If
                    'End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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
	
	Public Shared Function GetActiveNews3() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)
        Dim counter As Integer = 0

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC LIMIT 2,1"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
					'If odbcReader("Title").Equals(DBNull.Value) Then
                    '    oItem.Title = ""
                    'Else
                    '    oItem.Title = Trim(odbcReader("Title").ToString)
					'	If Len(oItem.Title) > 40 then 
					'	oItem.Title = Left(oItem.Title, 40) & "..."
					'	End If
                    'End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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
	
	Public Shared Function GetActiveNews4() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)
        Dim counter As Integer = 0

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC LIMIT 3,1"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
					'If odbcReader("Title").Equals(DBNull.Value) Then
                    '    oItem.Title = ""
                    'Else
                    '    oItem.Title = Trim(odbcReader("Title").ToString)
					'	If Len(oItem.Title) > 40 then 
					'	oItem.Title = Left(oItem.Title, 40) & "..."
					'	End If
                    'End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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
	
	Public Shared Function GetActiveNews5() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)
        Dim counter As Integer = 0

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC LIMIT 4,1"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
					'If odbcReader("Title").Equals(DBNull.Value) Then
                    '    oItem.Title = ""
                    'Else
                    '    oItem.Title = Trim(odbcReader("Title").ToString)
					'	If Len(oItem.Title) > 40 then 
					'	oItem.Title = Left(oItem.Title, 40) & "..."
					'	End If
                    'End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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

    Public Shared Function GetActiveNewsLast1() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)
        Dim counter As Integer = 0

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, title ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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

    Public Shared Function GetActiveNewsLast3() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)
        Dim counter As Integer = 0

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' ORDER BY ItemDate DESC, StartTime ASC"
            'Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Active' and ItemDate >= REPLACE(CURDATE(), '-', '/') ORDER BY ItemDate ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try
 
                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 3 Then

                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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

    Public Shared Function GetInactiveNews() As List(Of PC_NewsFTB)

        Dim oList As New List(Of PC_NewsFTB)

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE Status = 'Inactive' ORDER BY ItemDate DESC, title ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_NewsFTB


                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

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

    Public Shared Function GetNewsByNum(ByVal nNum As Integer) As PC_NewsFTB

        Dim oItem As New PC_NewsFTB

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblnewsftb WHERE nNum = " & nNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
					If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
					If odbcReader("pageName").Equals(DBNull.Value) Then
                        oItem.pageName = ""
                    Else
                        oItem.pageName = Trim(odbcReader("pageName").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    'oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

                Else
                    oItem.nNum = 0
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
	
	
	
    Public Shared Function GetLandByNum(ByVal nNum As Integer) As PC_NewsFTB

        Dim oItem As New PC_NewsFTB

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tbllandftb WHERE nNum = " & nNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.nNum = Convert.ToInt16(odbcReader("nNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("Summary").Equals(DBNull.Value) Then
                        oItem.Summary = ""
                    Else
                        oItem.Summary = Trim(odbcReader("Summary").ToString)
                    End If
                    If odbcReader("Author").Equals(DBNull.Value) Then
                        oItem.Author = ""
                    Else
                        oItem.Author = Trim(odbcReader("Author").ToString)
                    End If
                    If odbcReader("ItemDate").Equals(DBNull.Value) Then
                        oItem.ItemDate = ""
                    Else
                        oItem.ItemDate = Trim(odbcReader("ItemDate").ToString)
                    End If
                    If odbcReader("content").Equals(DBNull.Value) Then
                        oItem.content = ""
                    Else
                        oItem.content = Trim(odbcReader("content").ToString)
                    End If
                    If odbcReader("Featured").Equals(DBNull.Value) Then
                        oItem.Featured = ""
                    Else
                        oItem.Featured = Trim(odbcReader("Featured").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.ItemDate = FormatDateString(oItem.ItemDate)

                    'need function JUST for time?

                Else
                    oItem.nNum = 0
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

    Public Shared Function AddNews(ByVal oItem As PC_NewsFTB) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()
		
        'Dim tempD As String 
        'Dim monD As String = ""
		'Dim dyD As String = ""
		'Dim yrD As String = ""
        'If InStr(oItem.ItemDate, "/") = 2 Then 
        '    oItem.ItemDate = "0" & oItem.ItemDate 
        'End If 
        'monD = Left(oItem.ItemDate, 2)
		
        'tempD = Right(oItem.ItemDate, Len(oItem.ItemDate) - 3) 
        'If InStr(tempD, "/") = 2 Then 
		'	tempD = "0" & tempD
        '    oItem.ItemDate = Left(oItem.ItemDate, 3) & tempD 
        'End If
		'dyD = Left(tempD, 2)
		'yrD = Right(oItem.ItemDate, 4)
		
        'oItem.ItemDate = yrD & "/" & monD & "/" & dyD
		
		Dim myDateString as String = oItem.ItemDate
		Dim myDate as DateTime
		DateTime.TryParse(myDateString, myDate).ToString()
				
        Try
            sQueryString = "INSERT INTO tblnewsftb " & _
            "(Title, " & _
            "Summary, " & _
            "Author, " & _
            "ItemDate, " & _
            "content, " & _
            "Featured, " & _
            "ImageFile, " & _
			"pageName, " & _
			"Category, " & _
			"guid, " & _
            "Status)" & _
            " VALUES " & _
            "('" & Replace(oItem.Title, "'", "''") & _
            "', '" & Replace(oItem.Summary, "'", "''") & _
            "', '" & Replace(oItem.Author, "'", "''") & _
			"', '" & Replace(myDate.ToString("yyyy/MM/dd"), "'", "''") & _
            "', '" & Replace(oItem.content, "'", "''") & _
            "', '" & Replace(oItem.Featured, "'", "''") & _
            "', '" & Replace(oItem.ImageFile, "'", "''") & _
			"', '" & Replace(oItem.pageName, "'", "''") & _
			"', '" & Replace(oItem.Category, "'", "''") & _
			"', '" & Replace(oItem.guid, "'", "''") & _
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
	
	
	
    Public Shared Function AddLand(ByVal oItem As PC_NewsFTB) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()
		
        Dim tempD As String 
        Dim monD As String = ""
		Dim dyD As String = ""
		Dim yrD As String = ""
        If InStr(oItem.ItemDate, "/") = 2 Then 
            oItem.ItemDate = "0" & oItem.ItemDate 
        End If 
        monD = Left(oItem.ItemDate, 2)
		
        tempD = Right(oItem.ItemDate, Len(oItem.ItemDate) - 3) 
        If InStr(tempD, "/") = 2 Then 
			tempD = "0" & tempD
            oItem.ItemDate = Left(oItem.ItemDate, 3) & tempD 
        End If
		dyD = Left(tempD, 2)
		yrD = Right(oItem.ItemDate, 4)
		
        oItem.ItemDate = yrD & "/" & monD & "/" & dyD
				
        Try
            sQueryString = "INSERT INTO tbllandftb " & _
            "(Title, " & _
            "Summary, " & _
            "Author, " & _
            "ItemDate, " & _
            "content, " & _
            "Featured, " & _
            "ImageFile, " & _
            "Status)" & _
            " VALUES " & _
            "('" & Replace(oItem.Title, "'", "''") & _
            "', '" & Replace(oItem.Summary, "'", "''") & _
            "', '" & Replace(oItem.Author, "'", "''") & _
            "', '" & Replace(oItem.ItemDate, "'", "''") & _
            "', '" & Replace(oItem.content, "'", "''") & _
            "', '" & Replace(oItem.Featured, "'", "''") & _
            "', '" & Replace(oItem.ImageFile, "'", "''") & _
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
	
	Public Shared Function ModNewsHistory(ByVal oItem As PC_NewsFTB) As Integer
		Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()
		
		Dim myDateString as String = DateTime.Now.AddHours(+2).ToString()
		Dim myDate as DateTime
		DateTime.TryParse(myDateString, myDate).ToString()
		
				
        Try
			
			
			
			sQueryString = "INSERT INTO tblnewsftb_history SELECT 'insert', '" & myDate.ToString("yyyy/MM/dd HH:mm:ss") & "' , NULL, d.* FROM tblnewsftb AS d WHERE nNum =" & oItem.nNum


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

    Public Shared Function ModNews(ByVal oItem As PC_NewsFTB) As Integer
		
		Dim histResult As Integer = ModNewsHistory(oItem)
        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()
		
		
		
				
        Try
            With oItem
			
			
				Dim myDateString as String = .ItemDate
				Dim myDate as DateTime
				DateTime.TryParse(myDateString, myDate).ToString()
			
                sQueryString = "UPDATE tblnewsftb " & _
                "SET Title = '" & Replace(.Title, "'", "''") & _
                "', Summary = '" & Replace(.Summary, "'", "''") & _
				"', ItemDate = '" & Replace(myDate.ToString("yyyy/MM/dd"), "'", "''") & _
                "', content = '" & Replace(.content, "'", "''") & _
                "', ImageFile = '" & Replace(.ImageFile, "'", "''") & _
				"', Category = '" & Replace(.Category, "'", "''") & _
				"', pageName = '" & Replace(.pageName, "'", "''") & _
				"', guid = '" & Replace(.guid, "'", "''") & _
                "', Status = '" & Replace(.Status, "'", "''") & _
                "' WHERE nNum = " & .nNum
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
	
    Public Shared Function ModLand(ByVal oItem As PC_NewsFTB) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()

        Dim tempD As String 
        Dim monD As String = ""
		Dim dyD As String = ""
		Dim yrD As String = ""
        If InStr(oItem.ItemDate, "/") = 2 Then 
            oItem.ItemDate = "0" & oItem.ItemDate 
        End If 
        monD = Left(oItem.ItemDate, 2)
		
        tempD = Right(oItem.ItemDate, Len(oItem.ItemDate) - 3) 
        If InStr(tempD, "/") = 2 Then 
			tempD = "0" & tempD
            oItem.ItemDate = Left(oItem.ItemDate, 3) & tempD 
        End If
		dyD = Left(tempD, 2)
		yrD = Right(oItem.ItemDate, 4)
		
        oItem.ItemDate = yrD & "/" & monD & "/" & dyD
				
        Try
            With oItem
                sQueryString = "UPDATE tbllandftb " & _
                "SET Title = '" & Replace(.Title, "'", "''") & _
                "', Summary = '" & Replace(.Summary, "'", "''") & _
                "', ItemDate = '" & Replace(.ItemDate, "'", "''") & _
                "', content = '" & Replace(.content, "'", "''") & _
                "', ImageFile = '" & Replace(.ImageFile, "'", "''") & _
                "', Status = '" & Replace(.Status, "'", "''") & _
                "' WHERE nNum = " & .nNum
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

    Public Shared Function DelNews(ByVal oItem As PC_NewsFTB) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem
                sQueryString = "DELETE FROM tblnewsftb WHERE nNum = " & .nNum
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
	
	
	
	
	Public Shared Function DelLand(ByVal oItem As PC_NewsFTB) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem
                sQueryString = "DELETE FROM tbllandftb WHERE nNum = " & .nNum
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

#Region "Utility"

    Public Shared Function FormatDateString(ByVal DateIn As String) As String

        'NOTE: This function formats dates (and time) for output DISPLAY only, using settings from the web.config
        'Date(/time) must be stored in the database in the form yyyy/mm/dd hh:mm:ss, with leading zeros as needed
        'Storage is in a varchar field in the database - NOT a date field; this allows compatibility across db's.

        'Set default to original input string
        FormatDateString = DateIn

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateMonthToString As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateMonthToString"))
        Dim DateMonthStringType As String = System.Configuration.ConfigurationManager.AppSettings("DateMonthStringType")
        Dim DateShowTimeSeconds As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateShowTimeSeconds"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        'Date Format for Output DISPLAY ONLY
        '1 = yyyy-mm-dd
        '2 = mm-dd-yyyy
        '3 = dd-mm-yyyy
        '4 = yy-mm-dd
        '5 = mm-dd-yy
        '6 = dd-mm-yy
        'NOTE: time ONLY available when explicitly stored in database during record creation; this is NOT usually the case unless time is needed
        'Seconds are optional based on web.config setting
        '7 = yyyy-mm-dd hh:mm
        '8 = mm-dd-yyyy hh:mm
        '9 = dd-mm-yyyy hh:mm
        '10 = yy-mm-dd hh:mm
        '11 = mm-dd-yy hh:mm
        '12 = dd-mm-yy hh:mm
        '13 = dd-mm
        '14 = mm-dd
        '15 = yyyy-mm
        '16 = mm-yyyy
        'NOTE: TIME is NOT used in this application!

        If Len(DateIn) > 2 Then

            If InStr(DateIn, ":") Then
                'if the format selected does not include time, strip off time if present in the string
                If DateFormat < 7 Or DateFormat > 12 Then
                    If InStr(DateIn, ":") Then
                        DateIn = Trim(Left(DateIn, InStr(DateIn, " ")))
                    End If
                End If
            End If

            Dim syyyy As String = Left(DateIn, 4)
            Dim syy As String = Right(syyyy, 2)
            Dim sdd As String = Right(DateIn, 2)
            Dim tempD As String = Right(DateIn, 5)
            Dim smm As String = Left(tempD, 2)
            If DateLeadingZero = 0 Then
                If Left(smm, 1) = "0" Then
                    smm = Right(smm, 1)
                End If
                If Left(sdd, 1) = "0" Then
                    sdd = Right(sdd, 1)
                End If
            End If

            'convert month to string?
            If DateMonthToString = 1 Then
                'use Long format or abbreviation?
                If DateMonthStringType = "L" Then
                    If smm = "01" Or smm = "1" Then
                        smm = "January"
                    End If
                    If smm = "02" Or smm = "2" Then
                        smm = "February"
                    End If
                    If smm = "03" Or smm = "3" Then
                        smm = "March"
                    End If
                    If smm = "04" Or smm = "4" Then
                        smm = "April"
                    End If
                    If smm = "05" Or smm = "5" Then
                        smm = "May"
                    End If
                    If smm = "06" Or smm = "6" Then
                        smm = "June"
                    End If
                    If smm = "07" Or smm = "7" Then
                        smm = "July"
                    End If
                    If smm = "08" Or smm = "8" Then
                        smm = "August"

                    End If
                    If smm = "09" Or smm = "9" Then
                        smm = "September"
                    End If
                    If smm = "10" Or smm = "10" Then
                        smm = "October"
                    End If
                    If smm = "11" Or smm = "11" Then
                        smm = "November"
                    End If
                    If smm = "12" Or smm = "12" Then
                        smm = "December"
                    End If
                Else
                    If smm = "01" Or smm = "1" Then
                        smm = "Jan."
                    End If
                    If smm = "02" Or smm = "2" Then
                        smm = "Feb."
                    End If
                    If smm = "03" Or smm = "3" Then
                        smm = "Mar."
                    End If
                    If smm = "04" Or smm = "4" Then
                        smm = "Apr."
                    End If
                    If smm = "05" Or smm = "5" Then
                        smm = "May"
                    End If
                    If smm = "06" Or smm = "6" Then
                        smm = "Jun."
                    End If
                    If smm = "07" Or smm = "7" Then
                        smm = "Jul."
                    End If
                    If smm = "08" Or smm = "8" Then
                        smm = "Aug."
                    End If
                    If smm = "09" Or smm = "9" Then
                        smm = "Sept."
                    End If
                    If smm = "10" Or smm = "10" Then
                        smm = "Oct."
                    End If
                    If smm = "11" Or smm = "11" Then
                        smm = "Nov."
                    End If
                    If smm = "12" Or smm = "12" Then
                        smm = "Dec."
                    End If
                End If

            End If

            If DateFormat = 1 Then
                FormatDateString = syyyy & DateSep & smm & DateSep & sdd
            End If
            If DateFormat = 2 Then
                FormatDateString = smm & DateSep & sdd & DateSep & syyyy
                If DateMonthToString = 1 Then
                    FormatDateString = smm & " " & sdd & ", " & syyyy
                End If
            End If
            If DateFormat = 3 Then
                FormatDateString = sdd & DateSep & smm & DateSep & syyyy
            End If
            If DateFormat = 4 Then
                FormatDateString = syy & DateSep & smm & DateSep & sdd
            End If
            If DateFormat = 5 Then
                FormatDateString = smm & DateSep & sdd & DateSep & syy
                If DateMonthToString = 1 Then
                    FormatDateString = smm & " " & sdd & ", " & syy
                End If
            End If
            If DateFormat = 6 Then
                FormatDateString = sdd & DateSep & smm & DateSep & syy
            End If

            '7 - 12 not yet used - add when time formatting is needed
            If DateShowTimeSeconds = 1 Then

            Else

            End If

            If DateFormat = 13 Then
                FormatDateString = smm & DateSep & sdd
            End If
            If DateFormat = 14 Then
                FormatDateString = sdd & DateSep & smm
            End If
            If DateFormat = 15 Then
                FormatDateString = syyyy & DateSep & smm
            End If
            If DateFormat = 16 Then
                FormatDateString = smm & DateSep & syyyy
            End If

        End If

        Return FormatDateString

    End Function

    Public Shared Function DateMDYtoYMD(ByVal DateMDY As String) As String
        Dim Mo As String
        Dim Dy As String
        Dim Yr As String
        Dim tempD As String
        Dim rtnDate As String

        Mo = Left(DateMDY, InStr(DateMDY, "/") - 1)
        If Len(Mo) = 1 Then
            Mo = "0" & Mo
        End If
        tempD = Right(DateMDY, 7)
        If Left(tempD, 1) = "/" Then
            tempD = Right(tempD, Len(tempD) - 1)
        End If
        Dy = Left(tempD, InStr(tempD, "/") - 1)
        If Len(Dy) = 1 Then
            Dy = "0" & Dy
        End If
        Yr = Right(DateMDY, 4)

        rtnDate = Yr & "/" & Mo & "/" & Dy

        Return rtnDate

    End Function

    Public Shared Function TimeToAmPm(ByVal Time24 As String) As String

        Dim tHr As String
        Dim tMn As String
        Dim iHr As Integer
        Dim iMn As Integer
        Dim rtnTime As String = ""

        If Len(Time24) > 2 Then
            tHr = Left(Time24, 2)
            tMn = Right(Time24, 2)

            iHr = Convert.ToInt16(tHr)
            iMn = Convert.ToInt16(tMn)

            If iHr >= 12 Then 'pm
                If iMn > 0 Then
                    If iHr = 12 Then
                        tHr = "12"
                        If iMn < 10 Then
                            tMn = "0" & iMn.ToString
                        End If
                        rtnTime = tHr & ":" & tMn & " pm"
                    Else
                        iHr = iHr - 12
                        tHr = iHr.ToString
                        tMn = iMn.ToString
                        If iHr < 10 Then
                            tHr = "0" & iHr.ToString
                        End If
                        If iMn < 10 Then
                            tMn = "0" & iMn.ToString
                        End If
                        rtnTime = tHr & ":" & tMn & " pm"
                    End If
                Else
                    If iHr = 12 Then
                        tHr = "12"
                        tMn = "00"
                        rtnTime = tHr & ":" & tMn & " pm"
                    Else
                        iHr = iHr - 12
                        tHr = iHr.ToString
                        tMn = iMn.ToString
                        If iHr < 10 Then
                            tHr = "0" & iHr.ToString
                        End If
                        If iMn < 10 Then
                            tMn = "0" & iMn.ToString
                        End If
                        rtnTime = tHr & ":" & tMn & " pm"
                    End If
                End If
            Else 'am
                tHr = iHr.ToString
                tMn = iMn.ToString
                If iHr < 10 Then
                    tHr = "0" & iHr.ToString
                End If
                If iMn < 10 Then
                    tMn = "0" & iMn.ToString
                End If
                rtnTime = tHr & ":" & tMn & " am"
            End If
        End If

        Return rtnTime

    End Function

#End Region

End Class
