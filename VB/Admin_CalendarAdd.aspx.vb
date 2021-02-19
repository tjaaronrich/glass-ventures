Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class ADMIN_EventCalendar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

		Dim nowDate as string = now()
		lblStartDate.Text = Trim(Left(nowDate, instr(nowDate, " ")))
		lblEndDate.Text = Trim(Left(nowDate, instr(nowDate, " ")))

			If Len(Server.HtmlDecode(Request.QueryString("cNum"))) > 0 Then

				Dim cNum As Integer = Request.QueryString("cNum")
				Dim currentStatus As String = ""
				Dim tmpHr As Integer = 0
				Dim HrStr As String = ""
				
				lblCalNum.Text = cNum.ToString
		
				Dim oItem As New PC_Calendar
		
				oItem = DAL_Calendar.GetCalendarEventByNum(cNum)
		
        With oItem
            txtTitle.Text = .Title
            clndrStartDate.SelectedDate = .StartDate
            'clndrStartDate.SelectedDate = lblStartDate.Text
            lblStartDate.Text = .StartDate
            If Len(.EndDate) > 2 Then
                clndrEndDate.SelectedDate = .EndDate
                lblEndDate.Text = .EndDate
            End If

            If .StartTime = "00:00" Then
                'lbStartHr.SelectedValue = "00"
                lbStartHr.SelectedValue = "12"
                lbStartMin.SelectedValue = "00"
                lbStartampm.SelectedValue = "am"
            Else
                tmpHr = Convert.ToInt16(Left(.StartTime, 2))

                If tmpHr = 12 Then
                    lbStartampm.SelectedValue = "pm"
                Else If tmpHr > 12 Then
                    lbStartampm.SelectedValue = "pm"
                    tmpHr = tmpHr - 12 
                Else
                    lbStartampm.SelectedValue = "am"
                End If

                If tmpHr < 10 and tmpHr > 0 Then
                    HrStr = "0" & tmpHr.ToString
                    lbStartHr.SelectedValue = HrStr
                Else
                    HrStr = tmpHr.ToString
                    lbStartHr.SelectedValue = HrStr
                End If
                If tmpHr = 0 Then
                    HrStr = "12"
                    lbStartHr.SelectedValue = HrStr
				End If
                tmpHr = 0
                HrStr = ""
                lbStartMin.SelectedValue = Right(.StartTime, 2)
            End If

            If .EndTime = "00:00" Then
                'lbEndHr.SelectedValue = "00"
                lbEndHr.SelectedValue = "12"
                lbEndMin.SelectedValue = "00"
                lbEndampm.SelectedValue = "am"
            Else
                tmpHr = Convert.ToInt16(Left(.EndTime, 2))

                If tmpHr = 12 Then
                    lbEndampm.SelectedValue = "pm"
                Else If tmpHr > 12 Then
                    lbEndampm.SelectedValue = "pm"
                    tmpHr = tmpHr - 12
                Else
                    lbEndampm.SelectedValue = "am"
                End If

                If tmpHr < 10 and tmpHr > 0 Then
                    HrStr = "0" & tmpHr.ToString
                    lbEndHr.SelectedValue = HrStr
                Else
                    HrStr = tmpHr.ToString
                    lbEndHr.SelectedValue = HrStr
                End If
                If tmpHr = 0 Then
                    HrStr = "12"
                    lbEndHr.SelectedValue = HrStr
				End If
                tmpHr = 0
                HrStr = ""
                lbEndMin.SelectedValue = Right(.EndTime, 2)
            End If
            chkAllDay.Checked = .AllDay
            If chkAllDay.Checked Then
                'hide the time selection list boxes for both start and end times, by hiding the panel they're in
                pnlStartTime.Visible = False
                pnlEndTime.Visible = False
            Else
                pnlStartTime.Visible = True
                pnlEndTime.Visible = True
            End If
            txtContactNumber.Text = .ContactNumber
            txtLocation.Text = .Location
			txtContent.Text = .Description
			'FreeTextBox1.Text = .Description
			lblfileName.Text = .fileName
            'txtStatus.Text = .Status
            currentStatus = .Status
        End With
		
        'set dropdownlist selection
        If currentStatus = "Active" Then
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
        Else
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
        End If
        pnlStatus.Visible = True
		'pnlStatusUploadText.Visible = True

        SaveButton.Text = "Update Calendar Item"

        End If
		
        End If

    End Sub

    Protected Sub clndrStartDate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clndrStartDate.SelectionChanged
        lblStartDate.Text = clndrStartDate.SelectedDate
    End Sub

    Protected Sub clndrEndDate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clndrEndDate.SelectionChanged
        lblEndDate.Text = clndrEndDate.SelectedDate
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_Calendar
        Dim fileName As String
        Dim Rslt As Integer
        Dim tmpInt As Integer

        With oItem
            .Title = txtTitle.Text
            .StartDate = lblStartDate.Text
            .EndDate = lblEndDate.Text
            
			'If InStr(clndrEndDate.SelectedDate, ":") Then
            '    .EndDate = .StartDate
            'Else
            '    .EndDate = clndrEndDate.SelectedDate
            'End If

            .AllDay = chkAllDay.Checked

            If FileUpload2.HasFile Then
			FileUpload2.SaveAs(Server.MapPath("Documents\CalendarFiles") & "\" & FileUpload2.FileName)
			End If

            If chkAllDay.Checked = False Then

                If lbStartampm.SelectedValue = "pm" Then

                    If Convert.ToInt16(lbStartHr.SelectedValue) < 12 Then
                        tmpInt = Convert.ToInt16(lbStartHr.SelectedValue) + 12
                    Else ' = 12, therefore noon or 12pm which is 12 hrs in 24 hr clock
                        tmpInt = Convert.ToInt16(lbStartHr.SelectedValue)
                    End If

                    .StartTime = tmpInt.ToString & ":" & lbStartMin.SelectedValue.ToString

                End If

                If lbStartampm.SelectedValue = "am" Then

                    If Convert.ToInt16(lbStartHr.SelectedValue) < 12 Then
                        tmpInt = Convert.ToInt16(lbStartHr.SelectedValue)
                    Else ' = 12, therefore midnight or 12am which is 00 hrs in 24 hr clock
                        tmpInt = 0
                    End If

                    If tmpInt < 10 Then 'need to prefix a zero for 2-digit hour
                        .StartTime = "0" & tmpInt.ToString & ":" & lbStartMin.SelectedValue.ToString
                    Else
                        .StartTime = tmpInt.ToString & ":" & lbStartMin.SelectedValue.ToString
                    End If

                End If

                If lbEndampm.SelectedValue = "pm" Then

                    If Convert.ToInt16(lbEndHr.SelectedValue) < 12 Then
                        tmpInt = Convert.ToInt16(lbEndHr.SelectedValue) + 12
                    Else ' = 12, therefore noon or 12pm which is 12 hrs in 24 hr clock
                        tmpInt = Convert.ToInt16(lbEndHr.SelectedValue)
                    End If

                    .EndTime = tmpInt.ToString & ":" & lbEndMin.SelectedValue.ToString

                End If

                If lbEndampm.SelectedValue = "am" Then

                    If Convert.ToInt16(lbEndHr.SelectedValue) < 12 Then
                        tmpInt = Convert.ToInt16(lbEndHr.SelectedValue)
                    Else ' = 12, therefore midnight or 12am which is 00 hrs in 24 hr clock
                        tmpInt = 0
                    End If

                    If tmpInt < 10 Then 'need to prefix a zero for 2-digit hour
                        .EndTime = "0" & tmpInt.ToString & ":" & lbEndMin.SelectedValue.ToString
                    Else
                        .EndTime = tmpInt.ToString & ":" & lbEndMin.SelectedValue.ToString
                    End If

                End If

            Else
                .StartTime = "00:00"
                .EndTime = "00:00"
            End If

            .Repeats = 0    'NOTE: not currently a user-settable value, so default to zero
            .Location = txtLocation.Text
            .ContactNumber = txtContactNumber.Text
            .Description = txtContent.Text
            '.Description = Replace(FreeTextBox1.Text, "'", "''")
            .fileName = fileUpload2.FileName
            '.Status = txtStatus.Text
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Calendar Item" Then
                .cNum = lblCalNum.Text
            End If
        End With

        If SaveButton.Text = "Update Calendar Item" Then
            Rslt = DAL_Calendar.ModCalendarEvent(oItem)
            txtTitle.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            chkAllDay.Checked = False
            txtContent.Text = ""
            'FreeTextBox1.Text = ""
			'lblfileName.Text = ""
            'txtStatus.Text = "Active"
			'.fileName = lblfileName.Text
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            SaveButton.Text = "Add Calendar Item"
        Else
            Rslt = DAL_Calendar.AddCalendarEvent(oItem)
            txtTitle.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            chkAllDay.Checked = False
            txtContactNumber.Text = ""
            txtLocation.Text = ""
            txtContent.Text = ""
            'FreeTextBox1.Text = ""
			'lblfileName.Text = ""
            'txtStatus.Text = "Active"
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            pnlStatus.Visible = False
            SaveButton.Text = "Add Calendar Item"
        End If
		
		Response.redirect("ADMIN_Calendar.aspx")
		
        'GridView1.DataBind()

    End Sub
    Protected Sub chkAllDay_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllDay.CheckedChanged
        If chkAllDay.Checked Then
            'hide the time selection list boxes for both start and end times, by hiding the panel they're in
            pnlStartTime.Visible = False
            pnlEndTime.Visible = False
        Else
            pnlStartTime.Visible = True
            pnlEndTime.Visible = True
        End If
    End Sub
End Class