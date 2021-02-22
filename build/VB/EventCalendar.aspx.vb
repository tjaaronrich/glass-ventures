Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class EventCalendar
    Inherits System.Web.UI.Page

    'set to correspond to columns in database that are in use
    Public Structure MyDates
        Dim cNum As Integer
        Dim Title As String
        Dim StartDate As String
        Dim EndDate As String
        Dim StartTime As String
        Dim EndTime As String
        Dim AllDay As String
        Dim Repeats As Integer
        Dim Location As String
        Dim Description As String
        Dim Status As String
    End Structure

    Public MyCollection As Collection
    Public tempDate As DateTime
    Public tempMo As String
    Public tempYr As String
    Public old15cNum As Integer = 0
    Public old14cNum As Integer = 0
    Public old13cNum As Integer = 0
    Public old12cNum As Integer = 0
    Public old11cNum As Integer = 0
    Public old10cNum As Integer = 0
    Public old9cNum As Integer = 0
    Public old8cNum As Integer = 0
    Public old7cNum As Integer = 0
    Public old6cNum As Integer = 0
    Public old5cNum As Integer = 0
    Public old4cNum As Integer = 0
    Public old3cNum As Integer = 0
    Public old2cNum As Integer = 0
    Public old1cNum As Integer = 0
    Public newcNum As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MDYdate As String
        Dim currMo As String
        Dim currYr As String

        If Not (Page.IsPostBack) Then
            tempDate = Calendar1.TodaysDate
            MDYdate = tempDate.ToString
            MDYdate = Left(MDYdate, InStr(MDYdate, " ") - 1)
            currMo = Left(MDYdate, InStr(MDYdate, "/") - 1)
            If Len(currMo) = 1 Then
                currMo = "0" & currMo
            End If
            currYr = Right(MDYdate, 4)

            tempMo = currMo
            tempYr = currYr

            Get_CalendarItems()
        End If
    End Sub
    Public Sub Get_CalendarItems()

        Dim oItem As MyDates

        MyCollection = New Collection()
        Dim recYr As String
        Dim recMo As String
        Dim recDy As String
        Dim tmpStr As String
        Dim tmpDt As String 'use to find events within current month when building SQL statement
        tmpDt = tempYr & "/" & tempMo & "%"

        Dim DateSep As String = System.Configuration.ConfigurationManager.AppSettings("DateSeparator")
        Dim DateLeadingZero As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateLeadingZero"))
        Dim DateFormat As Integer = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings("DateFormat"))

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebAppGCCAC").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

            Dim sQueryString As String = "SELECT * FROM tblcalendar WHERE Status = 'Active' and StartDate LIKE '" & tmpDt & "' ORDER BY StartDate ASC, StartTime ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    oItem = New MyDates()

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
                    If odbcReader("Status").Equals(DBNull.Value) Then
                        oItem.Status = ""
                    Else
                        oItem.Status = Trim(odbcReader("Status").ToString)
                    End If

                    'check date to see if matches the current month and year
                    'tempMo, tempYr
                    recYr = Left(oItem.StartDate, 4)
                    tmpStr = Right(oItem.StartDate, Len(oItem.StartDate) - 5)
                    recMo = Left(tmpStr, 2)
                    recDy = Right(tmpStr, 2)

                    MyCollection.Add(oItem)
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        'Return oList

    End Sub

    Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
        Dim Item As MyDates  '//Temporary storage for looping through the collection
        Dim tempMDY As String
        Dim tempYMD As String
        Dim oktorender As Integer = 0
        Dim testStr As String

        Dim DayHold As String = "1900/01/01" '//Temporary date to check for multiple items per day

        For Each Item In MyCollection

            '//If found a date matching the current date... create the appropriate text
            tempMDY = e.Day.Date.ToString
            tempMDY = Left(tempMDY, InStr(tempMDY, " ") - 1)
            tempYMD = DAL_Calendar.DateMDYtoYMD(tempMDY)
            'If e.Day.Date = Item.StartDate.ToString("d") Then
            If tempYMD = Item.StartDate Then

                newcNum = Item.cNum

                If newcNum <> old1cNum And newcNum <> old2cNum And newcNum <> old3cNum And newcNum <> old4cNum And newcNum <> old5cNum And newcNum <> old6cNum And newcNum <> old7cNum And newcNum <> old8cNum And newcNum <> old9cNum And newcNum <> old10cNum And newcNum <> old11cNum And newcNum <> old12cNum And newcNum <> old13cNum And newcNum <> old14cNum And newcNum <> old15cNum Then
                    oktorender = 1
                Else
                    oktorender = 0
                End If

                If oktorender = 1 Then

                    Dim lblEvent As New HyperLink
                    If Item.StartTime = "00:00" Then
                        lblEvent.Text = "<br/>" & Item.Title.ToString()
                    Else
                        lblEvent.Text = "<br/>" & DAL_Calendar.TimeToAmPm(Item.StartTime) & " " & Item.Title.ToString()
                    End If

                    'the following version renders the link correctly - none of the other variants found on the web have worked
                    lblEvent.NavigateUrl = "EventsDetail.aspx?ID=" & Item.cNum.ToString
                    'and the following line does not work or is not needed
                    'lblEvent.Attributes.Add("onclick", "openNewWindow('EventCalendarDetail.aspx?ID=" & Item.cNum.ToString & "')")
                    e.Cell.Controls.Add(lblEvent)

                End If

                old15cNum = old14cNum
                old14cNum = old13cNum
                old13cNum = old12cNum
                old12cNum = old11cNum
                old11cNum = old10cNum
                old10cNum = old9cNum
                old9cNum = old8cNum
                old8cNum = old7cNum
                old7cNum = old6cNum
                old6cNum = old5cNum
                old5cNum = old4cNum
                old4cNum = old3cNum
                old3cNum = old2cNum
                old2cNum = old1cNum
                old1cNum = Item.cNum
            End If
        Next

    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged

    End Sub

    Protected Sub MonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendar1.VisibleMonthChanged
        '//Set the tempDatevariable to the value in the MonthChangedEventArgs NewDate property
        Dim MDYdate As String
        Dim currMo As String
        Dim currYr As String
        tempDate = e.NewDate
        MDYdate = tempDate.ToString
        MDYdate = Left(MDYdate, InStr(MDYdate, " ") - 1)
        currMo = Left(MDYdate, InStr(MDYdate, "/") - 1)
        If Len(currMo) = 1 Then
            currMo = "0" & currMo
        End If
        currYr = Right(MDYdate, 4)

        tempMo = currMo
        tempYr = currYr

        '//Reload the collection
        Get_CalendarItems()
    End Sub

    'Protected Function DateMDYtoYMD(ByVal DateMDY As String) As String
    '    Dim Mo As String
    '    Dim Dy As String
    '    Dim Yr As String
    '    Dim tempD As String
    '    Dim rtnDate As String

    '    Mo = Left(DateMDY, InStr(DateMDY, "/") - 1)
    '    If Len(Mo) = 1 Then
    '        Mo = "0" & Mo
    '    End If
    '    tempD = Right(DateMDY, 7)
    '    If Left(tempD, 1) = "/" Then
    '        tempD = Right(tempD, Len(tempD) - 1)
    '    End If
    '    Dy = Left(tempD, InStr(tempD, "/") - 1)
    '    If Len(Dy) = 1 Then
    '        Dy = "0" & Dy
    '    End If
    '    Yr = Right(DateMDY, 4)

    '    rtnDate = Yr & "/" & Mo & "/" & Dy

    '    Return rtnDate

    'End Function

    'Protected Function TimeToAmPm(ByVal Time24 As String) As String

    '    Dim tHr As String
    '    Dim tMn As String
    '    Dim iHr As Integer
    '    Dim iMn As Integer
    '    Dim rtnTime As String = ""

    '    If Len(Time24) > 2 Then
    '        tHr = Left(Time24, 2)
    '        tMn = Right(Time24, 2)

    '        iHr = Convert.ToInt16(tHr)
    '        iMn = Convert.ToInt16(tMn)

    '        If iHr >= 12 Then 'pm
    '            If iMn > 0 Then
    '                If iHr = 12 Then
    '                    tHr = "12"
    '                    If iMn < 10 Then
    '                        tMn = "0" & iMn.ToString
    '                    End If
    '                    rtnTime = tHr & ":" & tMn & " pm"
    '                Else
    '                    iHr = iHr - 12
    '                    tHr = iHr.ToString
    '                    tMn = iMn.ToString
    '                    If iHr < 10 Then
    '                        tHr = "0" & iHr.ToString
    '                    End If
    '                    If iMn < 10 Then
    '                        tMn = "0" & iMn.ToString
    '                    End If
    '                    rtnTime = tHr & ":" & tMn & " pm"
    '                End If
    '            Else
    '                If iHr = 12 Then
    '                    tHr = "12"
    '                    tMn = "00"
    '                    rtnTime = tHr & ":" & tMn & " pm"
    '                Else
    '                    iHr = iHr - 12
    '                    tHr = iHr.ToString
    '                    tMn = iMn.ToString
    '                    If iHr < 10 Then
    '                        tHr = "0" & iHr.ToString
    '                    End If
    '                    If iMn < 10 Then
    '                        tMn = "0" & iMn.ToString
    '                    End If
    '                    rtnTime = tHr & ":" & tMn & " pm"
    '                End If
    '            End If
    '        Else 'am
    '            tHr = iHr.ToString
    '            tMn = iMn.ToString
    '            If iHr < 10 Then
    '                tHr = "0" & iHr.ToString
    '            End If
    '            If iMn < 10 Then
    '                tMn = "0" & iMn.ToString
    '            End If
    '            rtnTime = tHr & ":" & tMn & " am"
    '        End If
    '    End If

    '    Return rtnTime

    'End Function

End Class
