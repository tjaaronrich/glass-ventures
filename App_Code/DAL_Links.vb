Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class DAL_Links

#Region "Links"

    Public Shared Function GetAllLinks() As List(Of PC_Links)

		Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices WHERE status <> 'ARCHIVED' ORDER BY status ASC, reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks ORDER BY linkCategory ASC, linkSort ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    'Public Shared Function GetAllAnnouncementsColSort(ByVal sortBy As String, ByVal sortDir As String) As List(Of PC_Announcements)

        'Dim oList As New List(Of PC_Announcements)
        'Dim sQueryString As String

        'If Len(sortBy) < 1 Then
            'sortBy = "status"
        'End If

        'If Len(sortDir) < 1 Then
            'sortDir = "ASC"
        'End If

        'Try
            'Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            'Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices WHERE status <> 'COMPLETED' ORDER BY item ASC, status ASC"

            'If sortBy = "reqDate" Or sortBy = "reqTime" Then
                'special case of sorting by 2 fields when only one selected
                'sQueryString = "SELECT * FROM tblITservices ORDER BY reqDate " & sortDir & ", reqTime " & sortDir & ", status ASC, requestBy ASC"
            'Else
                'sQueryString = "SELECT * FROM tblITservices ORDER BY " & sortBy & " " & sortDir & ", reqDate DESC, reqTime DESC" 
            'End If

            'Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            'odbcConn.Open()

            'Try

                'Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                'While odbcReader.Read()
                    'Dim oItem As New PC_ITSvcRequest


                    'oItem.ilinkNum = Convert.ToInt16(odbcReader("ilinkNum"))
                    'If odbcReader("item").Equals(DBNull.Value) Then
                        'oItem.item = ""
                    'Else
                        'oItem.item = Trim(odbcReader("item").ToString)
                    'End If
                    'If odbcReader("status").Equals(DBNull.Value) Then
                    '    oItem.status = ""
                    'Else
                    '    oItem.status = Trim(odbcReader("status").ToString)
                    'End If
                    'If odbcReader("requestBy").Equals(DBNull.Value) Then
                    '    oItem.requestBy = ""
                    'Else
                    '    oItem.requestBy = Trim(odbcReader("requestBy").ToString)
                    'End If
                    'If odbcReader("reqDate").Equals(DBNull.Value) Then
                    '    oItem.reqDate = ""
                    'Else
                    '    oItem.reqDate = Trim(odbcReader("reqDate").ToString)
                    'End If
                    'If odbcReader("reqTime").Equals(DBNull.Value) Then
                    '    oItem.reqTime = ""
                    'Else
                    '    oItem.reqTime = Trim(odbcReader("reqTime").ToString)
                    'End If
                    'If odbcReader("comments").Equals(DBNull.Value) Then
                    '    oItem.comments = ""
                    'Else
                    '    oItem.comments = Trim(odbcReader("comments").ToString)
                    'End If

                    'oList.Add(oItem)
                'End While

                'odbcReader.Close()

            'Catch ex As Exception

            '    odbcConn.Close()

            'End Try

            'odbcConn.Close()

        'Catch ex As Exception

        'End Try

        'Return oList

    'End Function

    Public Shared Function GetAllLinksADMIN() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks ORDER BY linkCategory ASC, linkSort ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks01() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
			Dim sQueryString As String = "SELECT * FROM tbllinks ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks02() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Young Job Seekers' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks03() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Veterans' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks04() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Workers with Disabilities' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks05() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Employers - Regional Economic Information' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks06() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Employers - State and National Data' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks07() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Job Seekers - Information' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks08() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Job Seekers - Veterans' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks09() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Financing and Accounting' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks10() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Staffing and Workplace Issues' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetAllLinks11() As List(Of PC_Links)

        Dim oList As New List(Of PC_Links)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblITservices ORDER BY reqDate DESC, reqTime DESC"
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkCategory = 'Starting a Business' ORDER BY linkSort ASC, linkCategory ASC, linkName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Links


                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
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

    Public Shared Function GetLinksByNum(ByVal linkNum As Integer) As PC_Links

        Dim oItem As New PC_Links

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tbllinks WHERE linkNum = " & linkNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.linkNum = Convert.ToInt16(odbcReader("linkNum"))
                    If odbcReader("linkName").Equals(DBNull.Value) Then
                        oItem.linkName = ""
                    Else
                        oItem.linkName = Trim(odbcReader("linkName").ToString)
                    End If
                    If odbcReader("linkCategory").Equals(DBNull.Value) Then
                        oItem.linkCategory = ""
                    Else
                        oItem.linkCategory = Trim(odbcReader("linkCategory").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("linkDescription").Equals(DBNull.Value) Then
                        oItem.linkDescription = ""
                    Else
                        oItem.linkDescription = Trim(odbcReader("linkDescription").ToString)
                    End If
                    If odbcReader("linkSort").Equals(DBNull.Value) Then
                        oItem.linkSort = ""
                    Else
                        oItem.linkSort = Trim(odbcReader("linkSort").ToString)
                    End If

                Else
                    oItem.linkNum = 0
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

    'Public Shared Function AddLinks(ByVal linkName As String, ByVal linkCategory As String, ByVal URL As String, ByVal linkDescription As String) As Integer
    Public Shared Function AddLinks(ByVal oItem As PC_Links) As Integer

        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim sQueryString As String
        Dim sortmax As Integer

        sortmax = GetMaxSortNumber()

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        'send notification to admin
        Try
			With oItem
            If oItem.linkSort <= sortmax Then
                Rslt2 = SortInsertInList(oItem.linkSort)
            End If

            'do not allow sort position outside of current min-max range - retain default next position number
            If oItem.linkSort > sortmax + 1 Or oItem.linkSort < 1 Then
                oItem.linkSort = sortmax + 1
            End If
            sQueryString = "INSERT INTO tbllinks " & _
            "(linkName, " & _
            "linkCategory, " & _
            "URL, " & _
            "linkDescription, " & _
            "linkSort)" & _
            " VALUES " & _
            "('" & Replace(.linkName, "'", "''") & _
            "', '" & Replace(.linkCategory, "'", "''") & _
            "', '" & Replace(.URL, "'", "''") & _
            "', '" & Replace(.linkDescription, "'", "''") & _
            "', '" & Replace(.linkSort, "'", "''")  & "')"
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

    'Public Shared Function ModLinks(ByVal linkNum As Integer, ByVal linkName As String, ByVal linkCategory As String, ByVal URL As String, ByVal linkDescription As String) As Integer
    Public Shared Function ModLinks(ByVal oItem As PC_Links) As Integer 

        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim sQueryString As String
        Dim currentsortorder As Integer
        Dim sortmax As Integer

        'sortmax = GetMaxSortNumber()

        'currentsortorder = GetCurrentSortNumber(oItem.linkNum)

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
				with oItem
                'If .linkSort <> currentsortorder Then
                '    Rslt2 = SortMovePositionInList(.linkNum, currentsortorder, .linkSort)
                'End If
                'If .linkSort > sortmax Or .linkSort < 1 Then
                '    .linkSort = currentsortorder
                'End If

                sQueryString = "UPDATE tbllinks " & _
                "SET linkName = '" & Replace(.linkName, "'", "''") & "', " & _
                "linkCategory = '" & Replace(.linkCategory, "'", "''") & "', " & _
                "URL = '" & Replace(.URL, "'", "''") & "', " & _
                "linkDescription = '" & Replace(.linkDescription, "'", "''") & "', " & _
                "linkSort = '" & Replace(.linkSort, "'", "''") & "' " & _
                " WHERE linkNum = " & .linkNum
				End With

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

    Public Shared Function DelLinks(ByVal oItem As PC_Links) As Integer

        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim sQueryString As String
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem
                .linkSort = GetCurrentSortNumber(.linkNum)
                sQueryString = "DELETE FROM tbllinks WHERE linkNum = " & .linkNum
                Rslt2 = SortDeleteFromList(.linkSort)
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

#End Region 'Links

#Region "Sorting"

    Public Shared Function GetMaxSortNumber() As Integer

        Dim sortmax As Integer

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT MAX(linkSort) as sortmax FROM tbllinks HAVING MAX(linkSort) > 0"
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

    Public Shared Function GetCurrentSortNumber(ByVal linkNum As Integer) As Integer

        Dim sort As Integer

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT linkSort FROM tbllinks WHERE linkNum = " & linkNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    sort = Convert.ToInt16(odbcReader("linkSort"))

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

    Public Shared Function SortMovePositionInList(ByVal linkNum As Integer, ByVal oldsortposition As Integer, ByVal newsortposition As Integer) As Integer

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

            Rslt2 = SortUpdateRecordPosition(linkNum, oldsortposition, newsortposition)

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
            sQueryString = "UPDATE tbllinks " & _
                " SET linkSort = linkSort + 1 " & _
                " WHERE linkSort >= " & newsortposition & _
                "  AND  linkSort <  " & oldsortposition

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
            sQueryString = "UPDATE tbllinks " & _
                " SET linkSort = linkSort - 1 " & _
                " WHERE linkSort >  " & oldsortposition & _
                "  AND  linkSort <= " & newsortposition

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

    Public Shared Function SortUpdateRecordPosition(ByVal linkNum As Integer, ByVal oldsortposition As Integer, ByVal newsortposition As Integer) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tbllinks " & _
                " SET linkSort = " & newsortposition & _
                " WHERE linkNum = " & linkNum

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
            sQueryString = "UPDATE tbllinks " & _
                " SET linkSort = linkSort + 1 " & _
                " WHERE linkSort >= " & newsortposition

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
            sQueryString = "UPDATE tbllinks " & _
                " SET linkSort = linkSort - 1 " & _
                " WHERE linkSort >  " & oldsortposition

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
