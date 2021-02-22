Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Mail


Public Class DAL_CalendarDates

#Region "EventCalendar"

    Public Shared Function GetActiveCalendarEventsLast01() As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)
        Dim counter As Integer = 0

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and StartDate >= REPLACE(CURDATE(), '-', '/') ORDER BY StartDate ASC, StartTime ASC"
            'Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and StartDate >= DATE_TO_STRING(CURDATE(), '%y/%m/%d') ORDER BY StartDate ASC, StartTime ASC"
            'Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' ORDER BY StartDate ASC, StartTime ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                        oItem.StartDate = Right(oItem.StartDate, 5) & "/" & Left(oItem.StartDate, 4)
                    End If
                    If odbcReader("EndDate") = odbcReader("StartDate") Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                        oItem.EndDate = " to " & Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    End If
                    'If odbcReader("EndDate").Equals(DBNull.Value) Then
                    'oItem.EndDate = ""
                    'Else
                    'oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    'oItem.EndDate = Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    'End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    ElseIf odbcReader("EndTime") = "00:00" Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                        'oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " to " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    ElseIf odbcReader("StartTime") = "00:00" Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                        'oItem.StartTime = TimeToAmPm(oItem.StartTime)
                        If Len(oItem.EndTime) > 0 Then
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " - " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                        Else
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & "</em></p>"
                        End If
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    ElseIf odbcReader("ContactNumber") = "" Then
                        oItem.ContactNumber = ""
                    Else
                        'oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                        oItem.ContactNumber = "Contact Number: " & Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    Else
                        oItem.fileName = Trim(odbcReader("fileName").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetAllCalendarItems() As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateMonthToString As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateMonthToString"))
        Dim DateMonthStringType As String = System.Configuration.ConfigurationManager.AppSettings("DateMonthStringType")
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblcalendar ORDER BY Status ASC, StartDate ASC, StartTime ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                    End If
                    If odbcReader("EndDate").Equals(DBNull.Value) Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                    End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    Else
                        oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    Else
                        oItem.fileName = Trim(odbcReader("fileName").ToString)
                    End If
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'Date Format for Output DISPLAY ONLY
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetActiveCalendarEvents() As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' ORDER BY StartDate ASC, StartTime ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                    End If
                    If odbcReader("EndDate").Equals(DBNull.Value) Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                    End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    Else
                        oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    Else
                        oItem.fileName = Trim(odbcReader("fileName").ToString)
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
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetActiveCalendarEventsList() As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and EndDate >= REPLACE(CURDATE(), '-', '/') ORDER BY StartDate ASC, StartTime ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                        oItem.StartDate = Right(oItem.StartDate, 5) & "/" & Left(oItem.StartDate, 4)
                    End If
                    If odbcReader("EndDate") = odbcReader("StartDate") Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                        oItem.EndDate = " to " & Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    End If
                    'If odbcReader("EndDate").Equals(DBNull.Value) Then
                    'oItem.EndDate = ""
                    'Else
                    'oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    'oItem.EndDate = Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    'End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    ElseIf odbcReader("EndTime") = "00:00" Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                        'oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " to " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    ElseIf odbcReader("StartTime") = "00:00" Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                        'oItem.StartTime = TimeToAmPm(oItem.StartTime)
                        If Len(oItem.EndTime) > 0 Then
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " - " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                        Else
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & "</em></p>"
                        End If
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    ElseIf odbcReader("ContactNumber") = "" Then
                        oItem.ContactNumber = ""
                    Else
                        'oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                        oItem.ContactNumber = "Contact Number: " & Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    Else
                        oItem.fileName = Trim(odbcReader("fileName").ToString)
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
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetActiveCalendarEventsListByName(ByVal currentName As String) As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))
        'Dim oItemI As New PC_Calendar

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and Title like '%" & Replace(currentName, "'", "''") & "%'"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                'oItemI.cNum = 0
                'oItemI.Title = sQueryString
                'oItemI.MiscString = oItemI.pTitle

                'oList.Add(oItemI)

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                        oItem.StartDate = Right(oItem.StartDate, 5) & "/" & Left(oItem.StartDate, 4)
                    End If
                    If odbcReader("EndDate") = odbcReader("StartDate") Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                        oItem.EndDate = " to " & Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    End If
                    'If odbcReader("EndDate").Equals(DBNull.Value) Then
                    'oItem.EndDate = ""
                    'Else
                    'oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    'oItem.EndDate = Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    'End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    ElseIf odbcReader("EndTime") = "00:00" Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                        'oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " to " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    ElseIf odbcReader("StartTime") = "00:00" Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                        'oItem.StartTime = TimeToAmPm(oItem.StartTime)
                        If Len(oItem.EndTime) > 0 Then
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " - " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                        Else
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & "</em></p>"
                        End If
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    ElseIf odbcReader("ContactNumber") = "" Then
                        oItem.ContactNumber = ""
                    Else
                        'oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                        oItem.ContactNumber = "Contact Number: " & Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    Else
                        oItem.fileName = Trim(odbcReader("fileName").ToString)
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
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetActiveCalendarEventsList2(ByVal fStartDate As String, ByVal fEndDate As String) As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)
        Dim sQueryString As String = ""

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and EndDate >= REPLACE(CURDATE(), '-', '/') ORDER BY StartDate ASC, StartTime ASC"
            If fStartDate = "ALL" Or fEndDate = "ALL" Then
                sQueryString = "SELECT * FROM tblcalendar WHERE Status = 'Active' and Category = 'Event' and EndDate >= REPLACE(CURDATE(), '-', '/') ORDER BY StartDate ASC, StartTime ASC"
            Else
                sQueryString = "SELECT * FROM tblcalendar WHERE Status = 'Active' and Category = 'Event' and ((StartDate >= '" & fStartDate & "' and StartDate <= '" & fEndDate & "') or (EndDate >= '" & fStartDate & "' and EndDate <= '" & fEndDate & "')) ORDER BY StartDate ASC, StartTime ASC"
            End If
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                        oItem.StartDate = Right(oItem.StartDate, 5) & "/" & Left(oItem.StartDate, 4)
                    End If
                    If odbcReader("EndDate") = odbcReader("StartDate") Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                        oItem.EndDate = " to " & Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    End If
                    'If odbcReader("EndDate").Equals(DBNull.Value) Then
                    'oItem.EndDate = ""
                    'Else
                    'oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    'oItem.EndDate = Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    'End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    ElseIf odbcReader("EndTime") = "00:00" Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                        'oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " to " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    ElseIf odbcReader("StartTime") = "00:00" Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                        'oItem.StartTime = TimeToAmPm(oItem.StartTime)
                        If Len(oItem.EndTime) > 0 Then
                            oItem.StartTime = "<p style=color:#fff; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " - " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                        Else
                            oItem.StartTime = "<p style=color:#fff; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & "</em></p>"
                        End If
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    ElseIf odbcReader("ContactNumber") = "" Then
                        oItem.ContactNumber = ""
                    Else
                        'oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                        oItem.ContactNumber = "Contact Number: " & Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    ElseIf odbcReader("fileName") = "" Then
                        oItem.fileName = ""
                    Else
                        'oItem.fileName = Trim(odbcReader("fileName").ToString)
                        oItem.fileName = "<p>&nbsp;</p><a href='Documents/Calendar2Files/" & Trim(odbcReader("fileName").ToString) & "' target=_blank><img src='Graphics/Button-06.png' border='0'></a>"
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
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetActiveCalendarEventsListTourney2(ByVal fStartDate As String, ByVal fEndDate As String) As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)
        Dim sQueryString As String = ""

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and EndDate >= REPLACE(CURDATE(), '-', '/') ORDER BY StartDate ASC, StartTime ASC"
            If fStartDate = "ALL" Or fEndDate = "ALL" Then
                sQueryString = "SELECT * FROM tblcalendar WHERE Status = 'Active' and Category = 'Tournament' and EndDate >= REPLACE(CURDATE(), '-', '/') ORDER BY StartDate ASC, StartTime ASC"
            Else
                sQueryString = "SELECT * FROM tblcalendar WHERE Status = 'Active' and Category = 'Tournament' and ((StartDate >= '" & fStartDate & "' and StartDate <= '" & fEndDate & "') or (EndDate >= '" & fStartDate & "' and EndDate <= '" & fEndDate & "')) ORDER BY StartDate ASC, StartTime ASC"
            End If
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                        oItem.StartDate = Right(oItem.StartDate, 5) & "/" & Left(oItem.StartDate, 4)
                    End If
                    If odbcReader("EndDate") = odbcReader("StartDate") Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                        oItem.EndDate = " to " & Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    End If
                    'If odbcReader("EndDate").Equals(DBNull.Value) Then
                    'oItem.EndDate = ""
                    'Else
                    'oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    'oItem.EndDate = Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    'End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    ElseIf odbcReader("EndTime") = "00:00" Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                        'oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " to " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    ElseIf odbcReader("StartTime") = "00:00" Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                        'oItem.StartTime = TimeToAmPm(oItem.StartTime)
                        If Len(oItem.EndTime) > 0 Then
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " - " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                        Else
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & "</em></p>"
                        End If
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    ElseIf odbcReader("ContactNumber") = "" Then
                        oItem.ContactNumber = ""
                    Else
                        'oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                        oItem.ContactNumber = "Contact Number: " & Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    ElseIf odbcReader("fileName") = "" Then
                        oItem.fileName = ""
                    Else
                        'oItem.fileName = Trim(odbcReader("fileName").ToString)
                        oItem.fileName = "<p>&nbsp;</p><a href='Documents/Calendar2Files/" & Trim(odbcReader("fileName").ToString) & "' target=_blank><img src='Graphics/Button-06.png' border='0'></a>"
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
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetActiveCalendarEventsListTourney24(ByVal fStartDate As String, ByVal fEndDate As String) As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)
        Dim sQueryString As String = ""
        Dim counter As Integer = 0

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            'Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and EndDate >= REPLACE(CURDATE(), '-', '/') ORDER BY StartDate ASC, StartTime ASC"
            If fStartDate = "ALL" Or fEndDate = "ALL" Then
                sQueryString = "SELECT * FROM tblcalendar WHERE Status = 'Active' and Category = 'Tournament' and EndDate >= REPLACE(CURDATE(), '-', '/') ORDER BY StartDate ASC, StartTime ASC"
            Else
                sQueryString = "SELECT * FROM tblcalendar WHERE Status = 'Active' and Category = 'Tournament' and ((StartDate >= '" & fStartDate & "' and StartDate <= '" & fEndDate & "') or (EndDate >= '" & fStartDate & "' and EndDate <= '" & fEndDate & "')) ORDER BY StartDate ASC, StartTime ASC"
            End If
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then
                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                        oItem.StartDate = Right(oItem.StartDate, 5) & "/" & Left(oItem.StartDate, 4)
                    End If
                    If odbcReader("EndDate") = odbcReader("StartDate") Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                        oItem.EndDate = " to " & Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    End If
                    'If odbcReader("EndDate").Equals(DBNull.Value) Then
                    'oItem.EndDate = ""
                    'Else
                    'oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    'oItem.EndDate = Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    'End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    ElseIf odbcReader("EndTime") = "00:00" Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                        'oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " to " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    ElseIf odbcReader("StartTime") = "00:00" Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                        'oItem.StartTime = TimeToAmPm(oItem.StartTime)
                        If Len(oItem.EndTime) > 0 Then
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " - " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                        Else
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & "</em></p>"
                        End If
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    ElseIf odbcReader("ContactNumber") = "" Then
                        oItem.ContactNumber = ""
                    Else
                        'oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                        oItem.ContactNumber = "Contact Number: " & Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    ElseIf odbcReader("fileName") = "" Then
                        oItem.fileName = ""
                    Else
                        'oItem.fileName = Trim(odbcReader("fileName").ToString)
                        oItem.fileName = "<p>&nbsp;</p><a href='Documents/Calendar2Files/" & Trim(odbcReader("fileName").ToString) & "' target=_blank><img src='Graphics/Button-06.png' border='0'></a>"
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
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetInactiveCalendarEvents() As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Inactive' ORDER BY StartDate ASC, StartTime ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                    End If
                    If odbcReader("EndDate").Equals(DBNull.Value) Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                    End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    Else
                        oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    Else
                        oItem.fileName = Trim(odbcReader("fileName").ToString)
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
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetActiveCalendarEventsLast1() As List(Of PC_Calendar)

        Dim oList As New List(Of PC_Calendar)
        Dim counter As Integer = 0

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and StartDate >= REPLACE(CURDATE(), '-', '/') ORDER BY StartDate ASC, StartTime ASC"
            'Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and StartDate >= DATE_TO_STRING(CURDATE(), '%y/%m/%d') ORDER BY StartDate ASC, StartTime ASC"
            'Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' ORDER BY StartDate ASC, StartTime ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_Calendar

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                    End If
                    If odbcReader("EndDate").Equals(DBNull.Value) Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                    End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    Else
                        oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
						If Len(oItem.Description) > 500 then 
						oItem.Description = Left(oItem.Description, 500) & "..."
						End If
                    End If
                    'If odbcReader("Description").Equals(DBNull.Value) Then
                    '    oItem.Description = ""
                    'Else
                    '    oItem.Description = Trim(odbcReader("Description").ToString)
                    'End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    Else
                        oItem.fileName = Trim(odbcReader("fileName").ToString)
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
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

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

    Public Shared Function GetCalendarEventByNum(ByVal calNum As Integer) As PC_Calendar

        Dim oItem As New PC_Calendar

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
			Dim sQueryString As String = "SELECT * FROM tblcalendardates WHERE cNum = " & calNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                    End If
                    If odbcReader("EndDate").Equals(DBNull.Value) Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                    End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    Else
                        oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    Else
                        oItem.fileName = Trim(odbcReader("fileName").ToString)
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
                    'oItem.StartDate = FormatDateString(oItem.StartDate)
                    'oItem.EndDate = FormatDateString(oItem.EndDate)

                    'need function JUST for time?
                Else
                    oItem.cNum = 0
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

    Public Shared Function GetCalendarEventByNum2(ByVal calNum As Integer) As PC_Calendar

        Dim oItem As New PC_Calendar

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE cNum = " & calNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.cNum = Convert.ToInt16(odbcReader("cNum"))
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("StartDate").Equals(DBNull.Value) Then
                        oItem.StartDate = ""
                    Else
                        oItem.StartDate = Trim(odbcReader("StartDate").ToString)
                        oItem.StartDate = Right(oItem.StartDate, 5) & "/" & Left(oItem.StartDate, 4)
                    End If
                    If odbcReader("EndDate") = odbcReader("StartDate") Then
                        oItem.EndDate = ""
                    Else
                        oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                        oItem.EndDate = " to " & Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    End If
                    'If odbcReader("EndDate").Equals(DBNull.Value) Then
                    'oItem.EndDate = ""
                    'Else
                    'oItem.EndDate = Trim(odbcReader("EndDate").ToString)
                    'oItem.EndDate = Right(oItem.EndDate, 5) & "/" & Left(oItem.EndDate, 4)
                    'End If
                    If odbcReader("EndTime").Equals(DBNull.Value) Then
                        oItem.EndTime = ""
                    ElseIf odbcReader("EndTime") = "00:00" Then
                        oItem.EndTime = ""
                    Else
                        oItem.EndTime = Trim(odbcReader("EndTime").ToString)
                        oItem.EndTime = Left(oItem.EndTime, 5)
                        'oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " to " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                    End If
                    If odbcReader("StartTime").Equals(DBNull.Value) Then
                        oItem.StartTime = ""
                    ElseIf odbcReader("StartTime") = "00:00" Then
                        oItem.StartTime = ""
                    Else
                        oItem.StartTime = Trim(odbcReader("StartTime").ToString)
                        oItem.StartTime = Left(oItem.StartTime, 5)
                        'oItem.StartTime = TimeToAmPm(oItem.StartTime)
                        If Len(oItem.EndTime) > 0 Then
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & " - " & TimeToAmPm(oItem.EndTime) & "</em></p>"
                        Else
                            oItem.StartTime = "<p style=color:#666666; margin-left:0px><em>" & TimeToAmPm(oItem.StartTime) & "</em></p>"
                        End If
                    End If
                    If odbcReader("AllDay").Equals(DBNull.Value) Then
                        oItem.AllDay = ""
                    Else
                        oItem.AllDay = Trim(odbcReader("AllDay").ToString)
                    End If
                    oItem.Repeats = Convert.ToInt16(odbcReader("Repeats"))
                    'If odbcReader("Repeats").Equals(DBNull.Value) Then
                    '    oItem.Repeats = ""
                    'Else
                    '    oItem.Repeats = Trim(odbcReader("Repeats").ToString)
                    'End If
                    If odbcReader("ContactNumber").Equals(DBNull.Value) Then
                        oItem.ContactNumber = ""
                    ElseIf odbcReader("ContactNumber") = "" Then
                        oItem.ContactNumber = ""
                    Else
                        'oItem.ContactNumber = Trim(odbcReader("ContactNumber").ToString)
                        oItem.ContactNumber = "Contact Number: " & Trim(odbcReader("ContactNumber").ToString)
                    End If
                    If odbcReader("Location").Equals(DBNull.Value) Then
                        oItem.Location = ""
                    Else
                        oItem.Location = Trim(odbcReader("Location").ToString)
                    End If
                    If odbcReader("Description").Equals(DBNull.Value) Then
                        oItem.Description = ""
                    Else
                        oItem.Description = Trim(odbcReader("Description").ToString)
                    End If
                    If odbcReader("Category").Equals(DBNull.Value) Then
                        oItem.Category = ""
                    Else
                        oItem.Category = Trim(odbcReader("Category").ToString)
                    End If
                    If odbcReader("fileName").Equals(DBNull.Value) Then
                        oItem.fileName = ""
                    ElseIf odbcReader("fileName") = "" Then
                        oItem.fileName = ""
                    Else
                        'oItem.fileName = Trim(odbcReader("fileName").ToString)
                        oItem.fileName = "<p>&nbsp;</p><a href='Documents/Calendar2Files/" & Trim(odbcReader("fileName").ToString) & "' target=_blank><img src='Graphics/Button-06.png' border='0'></a>"
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
                    oItem.StartDateDisplay = FormatDateString(oItem.StartDate)
                    oItem.EndDateDisplay = FormatDateString(oItem.EndDate)

                    'need function JUST for time?
                Else
                    oItem.cNum = 0
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

    Public Shared Function AddCalendarEvent(ByVal oItem As PC_Calendar) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()

        Dim tempD As String
        Dim monD As String = ""
        Dim dyD As String = ""
        Dim yrD As String = ""

        Try
			sQueryString = "INSERT INTO tblcalendardates " & _
            "(Title, " & _
            "StartDate, " & _
            "EndDate, " & _
            "StartTime, " & _
            "EndTime, " & _
            "AllDay, " & _
            "ContactNumber, " & _
            "Location, " & _
            "Description, " & _
            "Category, " & _
            "fileName, " & _
            "ImageFile, " & _
            "Status)" & _
            " VALUES " & _
            "('" & Replace(oItem.Title, "'", "''") & _
            "', '" & Replace(oItem.StartDate, "'", "''") & _
            "', '" & Replace(oItem.EndDate, "'", "''") & _
            "', '" & Replace(oItem.StartTime, "'", "''") & _
            "', '" & Replace(oItem.EndTime, "'", "''") & _
            "', '" & Replace(oItem.AllDay, "'", "''") & _
            "', '" & Replace(oItem.ContactNumber, "'", "''") & _
            "', '" & Replace(oItem.Location, "'", "''") & _
            "', '" & Replace(oItem.Description, "'", "''") & _
            "', '" & Replace(oItem.Category, "'", "''") & _
            "', '" & Replace(oItem.fileName, "'", "''") & _
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

    Public Shared Function AddCalendarEventDupe(ByVal oItem As PC_Calendar) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()

        Try
            sQueryString = "INSERT INTO tblcalendar " & _
            "(Title, " & _
            "StartDate, " & _
            "EndDate, " & _
            "StartTime, " & _
            "EndTime, " & _
            "AllDay, " & _
            "Repeats, " & _
            "ContactNumber, " & _
            "Location, " & _
            "Description, " & _
            "Category, " & _
            "fileName, " & _
            "ImageFile, " & _
            "Status)" & _
            " VALUES " & _
            "('" & Replace(oItem.Title, "'", "''") & _
            "', '" & Replace(oItem.StartDate, "'", "''") & _
            "', '" & Replace(oItem.EndDate, "'", "''") & _
            "', '" & Replace(oItem.StartTime, "'", "''") & _
            "', '" & Replace(oItem.EndTime, "'", "''") & _
            "', '" & Replace(oItem.AllDay, "'", "''") & _
            "', " & oItem.Repeats & _
            ", '" & Replace(oItem.ContactNumber, "'", "''") & _
            "', '" & Replace(oItem.Location, "'", "''") & _
            "', '" & Replace(oItem.Description, "'", "''") & _
            "', '" & Replace(oItem.Category, "'", "''") & _
            "', '" & Replace(oItem.fileName, "'", "''") & _
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

    Public Shared Function ModCalendarEvent(ByVal oItem As PC_Calendar) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        odbcConn.Open()

        Dim tempD As String
        Dim monD As String = ""
        Dim dyD As String = ""
        Dim yrD As String = ""

        Try
            With oItem
			sQueryString = "UPDATE tblcalendardates " & _
                "SET Title = '" & Replace(.Title, "'", "''") & _
                "', StartDate = '" & Replace(.StartDate, "'", "''") & _
                "', EndDate = '" & Replace(.EndDate, "'", "''") & _
                "', StartTime = '" & Replace(.StartTime, "'", "''") & _
                "', EndTime = '" & Replace(.EndTime, "'", "''") & _
                "', AllDay = '" & Replace(.AllDay, "'", "''") & _
                "', ContactNumber = '" & Replace(.ContactNumber, "'", "''") & _
                "', Location = '" & Replace(.Location, "'", "''") & _
                "', Description = '" & Replace(.Description, "'", "''") & _
                "', Category = '" & Replace(.Category, "'", "''") & _
                "', fileName = '" & Replace(.fileName, "'", "''") & _
                "', ImageFile = '" & Replace(.ImageFile, "'", "''") & _
                "', Status = '" & Replace(.Status, "'", "''") & _
                "' WHERE cNum = " & .cNum
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

    Public Shared Function DelCalendarEvent(ByVal oItem As PC_Calendar) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem
                sQueryString = "DELETE FROM tblcalendar WHERE cNum = " & .cNum
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

        'Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        'Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        'Dim DateMonthToString As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateMonthToString"))
        'Dim DateMonthStringType As String = System.Configuration.ConfigurationManager.AppSettings("DateMonthStringType")
        'Dim DateShowTimeSeconds As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateShowTimeSeconds"))
        'Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Dim DateSep As String = "/"
        Dim DateLeadingZero As Integer = 0
        Dim DateMonthToString As Integer = 0
        Dim DateMonthStringType As String = "L"
        Dim DateShowTimeSeconds As Integer = 0
        Dim DateFormat As Integer = 2

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
            End If
            If DateFormat = 3 Then
                FormatDateString = sdd & DateSep & smm & DateSep & syyyy
            End If
            If DateFormat = 4 Then
                FormatDateString = syy & DateSep & smm & DateSep & sdd
            End If
            If DateFormat = 5 Then
                FormatDateString = smm & DateSep & sdd & DateSep & syy
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
