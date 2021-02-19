Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class AnnouncementsAdd
    Inherits System.Web.UI.Page
	Public strGUID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

		Dim nowDate as string = now()
		lblStartDate.Text = Trim(Left(nowDate, instr(nowDate, " ")))
		lblEndDate.Text = Trim(Left(nowDate, instr(nowDate, " ")))

			If Len(Server.HtmlDecode(Request.QueryString("cNum"))) > 0 Then

				Dim cNum As Integer = Request.QueryString("cNum")
				Dim currentStatus As String = ""
				Dim currentFile As String = ""
				Dim currentCategory As String = ""
				Dim tmpHr As Integer = 0
				Dim HrStr As String = ""
				
				lblCalNum.Text = cNum.ToString
		
				Dim oItem As New PC_Calendar
		
				oItem = DAL_Announcements.GetCalendarEventByNum(cNum)
		
        		With oItem
					lblMultiSelect.Text = .Category
					txtTitle.Text = .Title
					txtEmail.Text = .EmailAddress
					txtWebsite.Text = .Website
					datepicker1.Value = .StartDate
					'ddlCategory.SelectedValue = currentCategory
					'clndrStartDate.SelectedDate = lblStartDate.Text
					lblStartDate.Text = .StartDate
					If Len(.EndDate) > 2 Then
							datepicker2.Value = .EndDate
						lblEndDate.Text = .EndDate
					End If

				timepicker1.Value = .StartTime
				timepicker2.Value = .EndTime



            chkAllDay.Checked = .AllDay
            If chkAllDay.Checked Then
                'hide the time selection list boxes for both start and end times, by hiding the panel they're in
                'pnlStartTime.Visible = False
                'pnlEndTime.Visible = False
				timepicker1.Value = "00:00"
				timepicker2.Value = "00:00"
            Else
					
					.StartTime = timepicker1.Value 
					.EndTime = timepicker2.Value
                'pnlStartTime.Visible = True
                'pnlEndTime.Visible = True
            End If
            txtContactNumber.Text = .ContactNumber
            txtLocation.Text = .Location
            Editor1.Text = .Description
			lblfileName.Text = "<a href='../Documents/Calendar2Files/" & .fileName & "' target=_blank>" & .fileName & "</a>"
			currentFile = .fileName
			lblfileName2.Text = currentFile
            'txtStatus.Text = .Status
            currentStatus = .Status
			ddlStatus.SelectedValue = .Status
        End With
		
        'set dropdownlist selection
        'If currentStatus = "Active" Then
         '   ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(currentStatus))
        'Else
         '   ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Inactive"))
        'End If
        'pnlStatus.Visible = True

        SaveButton.Text = "Update Item"

        End If
		
        End If

    End Sub

    'Protected Sub clndrStartDate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clndrStartDate.SelectionChanged
    '    lblStartDate.Text = clndrStartDate.SelectedDate
    'End Sub

    'Protected Sub clndrEndDate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clndrEndDate.SelectionChanged
    '    lblEndDate.Text = clndrEndDate.SelectedDate
    'End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click

        Dim oItem As New PC_Calendar
        Dim Rslt As Integer
        Dim tmpInt As Integer
        Dim fileName As String

        With oItem
            .Title = txtTitle.Text
			.StartDate = datepicker1.Value
			.EndDate = datepicker2.Value
            .Category = ddlCategory.SelectedValue
			.EmailAddress = txtEmail.Text
			.Website = txtWebsite.Text
			'If InStr(clndrEndDate.SelectedDate, ":") Then
            '    .EndDate = .StartDate
            'Else
            '    .EndDate = clndrEndDate.SelectedDate
            'End If

            .AllDay = chkAllDay.Checked
            .fileName = lblfileName2.Text

            If FileUpload2.HasFile Then
			FileUpload2.SaveAs(Server.MapPath("..\Documents\Calendar2Files") & "\" & FileUpload2.FileName)
            .fileName = fileUpload2.FileName
			Else 
			.fileName = lblfileName2.Text
			End If

            If chkAllDay.Checked = False Then

                .StartTime = timepicker1.Value
                .EndTime = timepicker2.Value


            Else
                .StartTime = "00:00"
                .EndTime = "00:00"
            End If

            .Repeats = 0    'NOTE: not currently a user-settable value, so default to zero
            .Location = txtLocation.Text
            .ContactNumber = txtContactNumber.Text
			.Category = lblMultiSelect.Text
            '.Description = Replace(FreeTextBox1.Text, "'", "''")
            .Description = Editor1.Text
            '.fileName = fileUpload2.FileName
            '.Status = txtStatus.Text
            .Status = ddlStatus.SelectedValue
            If SaveButton.Text = "Update Item" Then
                .cNum = lblCalNum.Text
            End If
        End With

        If SaveButton.Text = "Update Item" Then
			Rslt = DAL_Announcements.ModCalendarEvent(oItem)
            txtTitle.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            chkAllDay.Checked = False
            Editor1.Text = ""
            'txtStatus.Text = "Active"
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            'pnlStatus.Visible = False
            SaveButton.Text = "Add Item"
        Else
			Rslt = DAL_Announcements.AddCalendarEvent(oItem)
            'If chkBothCal.Checked = True
			'	Rslt = DAL_Calendar.AddCalendarEventDupe(oItem)
			'End If
            txtTitle.Text = ""
            'clndrHeadlineDate.SelectedDate = Now()
            chkAllDay.Checked = False
            txtContactNumber.Text = ""
            txtLocation.Text = ""
            Editor1.Text = ""
            'txtStatus.Text = "Active"
            ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
            'pnlStatus.Visible = False
            SaveButton.Text = "Add Item"
        End If
		
		Response.redirect("announcements.aspx")
		
        'GridView1.DataBind()

    End Sub
End Class