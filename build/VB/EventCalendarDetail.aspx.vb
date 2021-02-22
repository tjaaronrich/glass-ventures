Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class EventCalendarDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Len(Request.QueryString("ID")) > 0 Then
            lblCalNum.Text = Server.HtmlDecode(Request.QueryString("ID"))
        End If

        Dim cNum As Integer = Convert.ToInt16(Server.HtmlDecode(Request.QueryString("ID")))

        Dim tmpHr As Integer = 0
        Dim HrStr As String = ""
        Dim tmpAmPm As String = ""

        Dim oItem As New PC_Calendar

        oItem = DAL_Calendar.GetCalendarEventByNum(cNum)

        With oItem

            lblCalNum.Text = cNum.ToString

            lblTitle.Text = .Title
            lblStartDate.Text = .StartDate
            If Len(.EndDate) > 2 Then
                lblEndDate.Text = .EndDate
            End If

            lblStartTime.Text = DAL_Calendar.TimeToAmPm(.StartTime)
            lblEndTime.Text = DAL_Calendar.TimeToAmPm(.EndTime)

            lblAllDay.Text = .AllDay
            If .AllDay = True Then
                'hide the time selection list boxes for both start and end times, by hiding the panel they're in
                pnlStartTime.Visible = False
                pnlEndTime.Visible = False
            Else
                pnlStartTime.Visible = True
                pnlEndTime.Visible = True
            End If
            lblLocation.Text = .Location
            lblEventDescription.Text = .Description
        End With

    End Sub

End Class
