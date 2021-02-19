Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Mail

Public Class DAL_Testimonials

#Region "Testimonials"
	
	
	
	
	Public Shared Function GlobalTestimonials() As String
   
   
			Dim Testimonials As String
			Try
				Dim i As Integer = 0
				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
				Dim sQueryString As String = "SELECT * FROM tbltestimonials WHERE Status = 'Active'"
				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
				odbcConn.Open()
	
				Try
	
					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
					
					
					While odbcReader.Read()

						'lblOut.Text += "<div class='col-md-12'>"
						'Dim myDateString as String = Trim(odbcReader("ItemDate").ToString)
						'Dim myDate as DateTime
						'DateTime.TryParse(myDateString, myDate).ToString()
						
						Dim ImageFileDir As String  = ""
						
						If Not Trim(odbcReader("ImageFile").ToString) = "" Then
							ImageFileDir = "/Documents/Testimonials/"
						End If
						
						Testimonials += "" & 
						"<li>" & 
						"<img src='" & ImageFileDir & Trim(odbcReader("ImageFile").ToString) & "' class=' img-fluid'>" &
							"<div class='caption center-align'>" &
					"<p class='slide-testimonials module line-clamp'style='font-size:1rem;color:#FFF!important;text-align: center;font-family: ""Montserrat"";'>" & Trim(odbcReader("tDescription").ToString) & "</p>"&
							"<p>&nbsp;</p>" &
					"<p class='' style='font-size:1remlcolor:#FFF;text-align: center;font-family: ""Montserrat"";'>" & Trim(odbcReader("fullName").ToString) & "" & "</p>" &
						"</div>" &
						"</li>" 
						
					
						
	
						i += 1
					End While
					
					
					
					
					odbcReader.Close()
	
				Catch ex As Exception
	
					odbcConn.Close()
	
				End Try
	
				odbcConn.Close()
	
			Catch ex As Exception
	
			End Try
   
   
   			Return Testimonials
	End Function
			

    Public Shared Function GetAllTestimonials(ByVal TestimonialsStatus As String) As List(Of PC_Testimonials)

        Dim oList As New List(Of PC_Testimonials)

        'possible statuses are CURRENT and ARCHIVED
        If Len(TestimonialsStatus) <= 0 Or TestimonialsStatus <> "Inactive" Then
            TestimonialsStatus = "Active"
        End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tbltestimonials ORDER BY Status ASC, tSort ASC, tDescription ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Testimonials


                    oItem.tNum = Convert.ToInt16(odbcReader("tNum"))
                    If odbcReader("tDescription").Equals(DBNull.Value) Then
                        oItem.tDescription = ""
                    Else
                        oItem.tDescription = Trim(odbcReader("tDescription").ToString)
                    End If
                    If odbcReader("fullName").Equals(DBNull.Value) Then
                        oItem.fullName = ""
                    Else
                        oItem.fullName = Trim(odbcReader("fullName").ToString)
                    End If
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("City").Equals(DBNull.Value) Then
                        oItem.City = ""
                    Else
                        oItem.City = Trim(odbcReader("City").ToString)
                    End If
                    If odbcReader("tSort").Equals(DBNull.Value) Then
                        oItem.tSort = ""
                    Else
                        oItem.tSort = Trim(odbcReader("tSort").ToString)
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

    Public Shared Function GetActiveTestimonials() As List(Of PC_Testimonials)

        Dim oList As New List(Of PC_Testimonials)

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tbltestimonials WHERE Status = 'Active' ORDER BY tSort DESC, tDescription ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Testimonials


                    oItem.tNum = Convert.ToInt16(odbcReader("tNum"))
                    If odbcReader("tDescription").Equals(DBNull.Value) Then
                        oItem.tDescription = ""
                    Else
                        oItem.tDescription = Trim(odbcReader("tDescription").ToString)
                    End If
                    If odbcReader("fullName").Equals(DBNull.Value) Then
                        oItem.fullName = ""
                    Else
                        oItem.fullName = Trim(odbcReader("fullName").ToString)
                    End If
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("City").Equals(DBNull.Value) Then
                        oItem.City = ""
                    Else
                        oItem.City = Trim(odbcReader("City").ToString)
                    End If
                    If odbcReader("tSort").Equals(DBNull.Value) Then
                        oItem.tSort = ""
                    Else
                        oItem.tSort = Trim(odbcReader("tSort").ToString)
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

    Public Shared Function GetActiveRandomTestimonial() As List(Of PC_Testimonials)

        Dim oList As New List(Of PC_Testimonials)
        Dim counter As Integer = 0

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tbltestimonials WHERE Status = 'Active' ORDER BY Rand()"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
					If counter < 1 Then

                    Dim oItem As New PC_Testimonials


                    oItem.tNum = Convert.ToInt16(odbcReader("tNum"))
                    'If odbcReader("tDescription").Equals(DBNull.Value) Then
                    '    oItem.tDescription = ""
                    'Else
                    '    oItem.tDescription = Trim(odbcReader("tDescription").ToString)
                    'End If
                    If odbcReader("tDescription").Equals(DBNull.Value) Then
                        oItem.tDescription = ""
                    Else
                        oItem.tDescription = Trim(odbcReader("tDescription").ToString)
						If Len(oItem.tDescription) > 125 then 
						oItem.tDescription = Left(oItem.tDescription, 125) & "..."
						End If
                    End If
                    If odbcReader("fullName").Equals(DBNull.Value) Then
                        oItem.fullName = ""
                    Else
                        oItem.fullName = Trim(odbcReader("fullName").ToString)
                    End If
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("City").Equals(DBNull.Value) Then
                        oItem.City = ""
                    Else
                        oItem.City = Trim(odbcReader("City").ToString)
                    End If
                    If odbcReader("tSort").Equals(DBNull.Value) Then
                        oItem.tSort = ""
                    Else
                        oItem.tSort = Trim(odbcReader("tSort").ToString)
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

    Public Shared Function GetInactiveTestimonials() As List(Of PC_Testimonials)

        Dim oList As New List(Of PC_Testimonials)

        '''''possible statuses are CURRENT and ARCHIVED
        'If Len(NewsStatus) <= 0 Or NewsStatus <> "Inactive" Then
            'NewsStatus = "Active"
        'End If

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tbltestimonials WHERE Status = 'Inactive' ORDER BY tSort DESC, tDescription ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Testimonials


                    oItem.tNum = Convert.ToInt16(odbcReader("tNum"))
                    If odbcReader("tDescription").Equals(DBNull.Value) Then
                        oItem.tDescription = ""
                    Else
                        oItem.tDescription = Trim(odbcReader("tDescription").ToString)
                    End If
                    If odbcReader("fullName").Equals(DBNull.Value) Then
                        oItem.fullName = ""
                    Else
                        oItem.fullName = Trim(odbcReader("fullName").ToString)
                    End If
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("City").Equals(DBNull.Value) Then
                        oItem.City = ""
                    Else
                        oItem.City = Trim(odbcReader("City").ToString)
                    End If
                    If odbcReader("tSort").Equals(DBNull.Value) Then
                        oItem.tSort = ""
                    Else
                        oItem.tSort = Trim(odbcReader("tSort").ToString)
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

    Public Shared Function GetTestimonialsByNum(ByVal TestimonialsNum As Integer) As PC_Testimonials

        Dim oItem As New PC_Testimonials

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tbltestimonials WHERE tNum = " & TestimonialsNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()
 
                    oItem.tNum = Convert.ToInt16(odbcReader("tNum"))
                    If odbcReader("tDescription").Equals(DBNull.Value) Then
                        oItem.tDescription = ""
                    Else
                        oItem.tDescription = Trim(odbcReader("tDescription").ToString)
                    End If
                    If odbcReader("fullName").Equals(DBNull.Value) Then
                        oItem.fullName = ""
                    Else
                        oItem.fullName = Trim(odbcReader("fullName").ToString)
                    End If
                    If odbcReader("Title").Equals(DBNull.Value) Then
                        oItem.Title = ""
                    Else
                        oItem.Title = Trim(odbcReader("Title").ToString)
                    End If
                    If odbcReader("URL").Equals(DBNull.Value) Then
                        oItem.URL = ""
                    Else
                        oItem.URL = Trim(odbcReader("URL").ToString)
                    End If
                    If odbcReader("City").Equals(DBNull.Value) Then
                        oItem.City = ""
                    Else
                        oItem.City = Trim(odbcReader("City").ToString)
                    End If
                    If odbcReader("tSort").Equals(DBNull.Value) Then
                        oItem.tSort = ""
                    Else
                        oItem.tSort = Trim(odbcReader("tSort").ToString)
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
                    oItem.tNum = 0
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

    Public Shared Function AddTestimonials(ByVal oItem As PC_Testimonials) As Integer

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
				
        Try
            If oItem.tSort <= sortmax Then
                Rslt2 = SortInsertInList(oItem.tSort)
            End If

            'do not allow sort position outside of current min-max range - retain default next position number
            If oItem.tSort > sortmax + 1 Or oItem.tSort < 1 Then
                oItem.tSort = sortmax + 1
            End If

            sQueryString = "INSERT INTO tbltestimonials " & _
            "(tDescription, " & _
            "fullName, " & _
            "Title, " & _
            "URL, " & _
            "city, " & _
            "tSort, " & _
            "Status)" & _
            " VALUES " & _
            "('" & Replace(oItem.tDescription, "'", "''") & _
            "', '" & Replace(oItem.fullName, "'", "''") & _
            "', '" & Replace(oItem.Title, "'", "''") & _
            "', '" & Replace(oItem.URL, "'", "''") & _
            "', '" & Replace(oItem.City, "'", "''") & _
            "', " & Replace(oItem.tSort, "'", "''") & _
            ", 'Active'" & ")"
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

    Public Shared Function ModTestimonials(ByVal oItem As PC_Testimonials) As Integer

        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim sQueryString As String
        Dim currentsortorder As Integer
        Dim sortmax As Integer

        sortmax = GetMaxSortNumber()

        currentsortorder = GetCurrentSortNumber(oItem.tNum)

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
				
        Try
            With oItem
                If .tSort <> currentsortorder Then
                    Rslt2 = SortMovePositionInList(.tNum, currentsortorder, .tSort)
                End If

                'do not allow sort position outside of current min-max range - keep current position
                If .tSort > sortmax Or .tSort < 1 Then
                    .tSort = currentsortorder
                End If

                sQueryString = "UPDATE tbltestimonials " & _
                "SET tDescription = '" & Replace(.tDescription, "'", "''") & _
                "', fullName = '" & Replace(.fullName, "'", "''") & _
                "', Title = '" & Replace(.Title, "'", "''") & _
                "', URL = '" & Replace(.URL, "'", "''") & _
                "', City = '" & Replace(.City, "'", "''") & _
                "', tSort = " & Replace(.tSort, "'", "''") & _
                ", Status = '" & Replace(.Status, "'", "''") & _
                "' WHERE tNum = " & .tNum
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

    Public Shared Function DelTestimonials(ByVal oItem As PC_Testimonials) As Integer

        Dim Rslt As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim sQueryString As String
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem
                .tSort = GetCurrentSortNumber(.tNum)

                sQueryString = "DELETE FROM tbltestimonials WHERE tNum = " & .tNum

                'modify sort order ranking of all records that previously sort after this one
                Rslt2 = SortDeleteFromList(.tSort)

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

#Region "Sorting"

    Public Shared Function GetMaxSortNumber() As Integer

        Dim sortmax As Integer

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT MAX(tSort) as sortmax FROM tbltestimonials HAVING MAX(tSort) > 0"
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

    Public Shared Function GetCurrentSortNumber(ByVal tNum As Integer) As Integer

        Dim sort As Integer

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT tSort FROM tbltestimonials WHERE tNum = " & tNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    sort = Convert.ToInt16(odbcReader("tSort"))

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

    Public Shared Function SortMovePositionInList(ByVal tNum As Integer, ByVal oldsortposition As Integer, ByVal newsortposition As Integer) As Integer

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

            Rslt2 = SortUpdateRecordPosition(tNum, oldsortposition, newsortposition)

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
            sQueryString = "UPDATE tbltestimonials " & _
                " SET tSort = tSort + 1 " & _
                " WHERE tSort >= " & newsortposition & _
                "  AND  tSort <  " & oldsortposition

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
            sQueryString = "UPDATE tbltestimonials " & _
                " SET tSort = tSort - 1 " & _
                " WHERE tSort >  " & oldsortposition & _
                "  AND  tSort <= " & newsortposition

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

    Public Shared Function SortUpdateRecordPosition(ByVal tNum As Integer, ByVal oldsortposition As Integer, ByVal newsortposition As Integer) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tbltestimonials " & _
                " SET tSort = " & newsortposition & _
                " WHERE tNum = " & tNum

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
            sQueryString = "UPDATE tbltestimonials " & _
                " SET tSort = tSort + 1 " & _
                " WHERE tSort >= " & newsortposition

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
            sQueryString = "UPDATE tbltestimonials " & _
                " SET tSort = tSort - 1 " & _
                " WHERE tSort >  " & oldsortposition

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
