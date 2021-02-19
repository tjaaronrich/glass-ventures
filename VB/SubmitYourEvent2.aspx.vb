Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data 
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net 
Imports System.Net.Mail
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports ComponentArt
Imports ComponentArt.Web
Imports ComponentArt.Web.UI


Public Class SubmitYourEvent 
'Partial Class Calendar_ChamberEvents
    Inherits System.Web.UI.Page

  Protected WithEvents Rotator1 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorBannerAd1 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorBannerAd2 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorColumnAd1 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorColumnAd2 As ComponentArt.Web.UI.Rotator
  Protected WithEvents btnSearch As Button
  Protected WithEvents SaveButton As Button
  Protected WithEvents txtTitle As TextBox
  Protected WithEvents txtLocation As TextBox
  Protected WithEvents txtContactNumber As TextBox
  Protected WithEvents txtDescription As TextBox
  Protected WithEvents txtURL As TextBox
  Protected WithEvents chkAllDay As checkbox
  Protected WithEvents FileUpload2 As System.Web.UI.WebControls.FileUpload
  Protected lblMo As Label
  Protected lblYr As Label
  Protected lblStartDate As Label
  Protected lblEndDate As Label
  Protected lblErrorMsg As Label
  Protected lblClickthroughAdd As Label
  Protected lblClickthroughAddTEST As Label
  Protected lbStartampm As System.Web.UI.WebControls.ListBox
  Protected lbEndampm As System.Web.UI.WebControls.ListBox
  Protected lbStartHr As System.Web.UI.WebControls.ListBox
  Protected lbEndHr As System.Web.UI.WebControls.ListBox
  Protected lbStartMin As System.Web.UI.WebControls.ListBox
  Protected lbEndMin As System.Web.UI.WebControls.ListBox
  Protected WithEvents txtClickthroughAdd As TextBox
  Protected pnlStatus As Panel
  Protected pnlStartTime As Panel
  Protected pnlEndTime As Panel
  Protected pnlRotator1 As Panel
  Protected pnlRotator2 As Panel
  Protected pnlRotatorColumn1 As Panel
  Protected pnlRotatorColumn2 As Panel
  Protected WithEvents InvisibleButton As Button
  Protected WithEvents InvisibleColumnButton As Button
  Protected ddlMonth As DropDownList
  Protected ddlYear As DropDownList
  Protected ddlStatus As DropDownList
  Protected WithEvents GridView1 As System.Web.UI.WebControls.GridView
  Protected WithEvents clndrStartDate As System.Web.UI.WebControls.Calendar
  Protected WithEvents clndrEndDate As System.Web.UI.WebControls.Calendar

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If Not IsPostBack Then

		Dim nowDate as string = now()
		lblStartDate.Text = Trim(Left(nowDate, instr(nowDate, " ")))
		lblEndDate.Text = Trim(Left(nowDate, instr(nowDate, " ")))
	
	End If

    End Sub

    Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim sMo As String = ""
        Dim sYr As String = ""
        lblYr.Text = DateTime.Now.Year.ToString
        lblStartDate.Text = "ALL"
        lblEndDate.Text = "ALL"

        sMo = ddlMonth.SelectedItem.Value()
        lblYr.Text = ddlYear.SelectedItem.Value()
        If sMo = "January" Then
            lblMo.Text = "01"
        End If
        If sMo = "February" Then
            lblMo.Text = "02"
        End If
        If sMo = "March" Then
            lblMo.Text = "03"
        End If
        If sMo = "April" Then
            lblMo.Text = "04"
        End If
        If sMo = "May" Then
            lblMo.Text = "05"
        End If
        If sMo = "June" Then
            lblMo.Text = "06"
        End If
        If sMo = "July" Then
            lblMo.Text = "07"
        End If
        If sMo = "August" Then
            lblMo.Text = "08"
        End If
        If sMo = "September" Then
            lblMo.Text = "09"
        End If
        If sMo = "October" Then
            lblMo.Text = "10"
        End If
        If sMo = "November" Then
            lblMo.Text = "11"
        End If
        If sMo = "December" Then
            lblMo.Text = "12"
        End If
        If sMo = "ALL" Then
            lblMo.Text = "ALL"
        End If

        If lblMo.Text <> "ALL" And lblYr.Text <> "ALL" Then
            If Len(lblMo.Text) < 2 Or lblMo.Text = "Month" Or Len(lblYr.Text) < 3 Or lblYr.Text = "Year" Then
                lblStartDate.Text = "ALL"
                lblEndDate.Text = "ALL"
            Else
                lblStartDate.Text = lblYr.Text & "/" & lblMo.Text & "/" & "01"
                lblEndDate.Text = lblYr.Text & "/" & lblMo.Text & "/" & "31"
            End If
        Else
            lblStartDate.Text = "ALL"
            lblEndDate.Text = "ALL"
        End If

        GridView1.DataBind()

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
            .ContactNumber = txtContactNumber.Text
            .Location = txtLocation.Text
            .Description = txtDescription.Text           
            .AllDay = chkAllDay.Checked
			.fileName = FileUpload2.FileName

            If FileUpload2.HasFile Then
			FileUpload2.SaveAs(Server.MapPath("Documents\CalendarFiles") & "\" & FileUpload2.FileName)
			End If

            If chkAllDay.Checked = False Then

                If lbStartampm.text = "pm" Then

                    If Convert.ToInt16(lbStartHr.text) < 12 Then
                        tmpInt = Convert.ToInt16(lbStartHr.text) + 12
                    Else ' = 12, therefore noon or 12pm which is 12 hrs in 24 hr clock
                        tmpInt = Convert.ToInt16(lbStartHr.text)
                    End If

                    .StartTime = tmpInt.ToString & ":" & lbStartMin.text.ToString

                End If

                If lbStartampm.text = "am" Then

                    If Convert.ToInt16(lbStartHr.text) < 12 Then
                        tmpInt = Convert.ToInt16(lbStartHr.text)
                    Else ' = 12, therefore midnight or 12am which is 00 hrs in 24 hr clock
                        tmpInt = 0
                    End If

                    If tmpInt < 10 Then 'need to prefix a zero for 2-digit hour
                        .StartTime = "0" & tmpInt.ToString & ":" & lbStartMin.text.ToString
                    Else
                        .StartTime = tmpInt.ToString & ":" & lbStartMin.text.ToString
                    End If

                End If

                If lbEndampm.text = "pm" Then

                    If Convert.ToInt16(lbEndHr.text) < 12 Then
                        tmpInt = Convert.ToInt16(lbEndHr.text) + 12
                    Else ' = 12, therefore noon or 12pm which is 12 hrs in 24 hr clock
                        tmpInt = Convert.ToInt16(lbEndHr.text)
                    End If

                    .EndTime = tmpInt.ToString & ":" & lbEndMin.text.ToString

                End If

                If lbEndampm.text = "am" Then

                    If Convert.ToInt16(lbEndHr.text) < 12 Then
                        tmpInt = Convert.ToInt16(lbEndHr.text)
                    Else ' = 12, therefore midnight or 12am which is 00 hrs in 24 hr clock
                        tmpInt = 0
                    End If

                    If tmpInt < 10 Then 'need to prefix a zero for 2-digit hour
                        .EndTime = "0" & tmpInt.ToString & ":" & lbEndMin.text.ToString
                    Else
                        .EndTime = tmpInt.ToString & ":" & lbEndMin.text.ToString
                    End If

                End If

            Else
                .StartTime = "00:00"
                .EndTime = "00:00"
            End If

            '.Repeats = 0    'NOTE: not currently a user-settable value, so default to zero
            '.Location = txtLocation.Text
            '.ContactNumber = txtContactNumber.Text
            '.Description = txtDescription.Text
            '.fileName = fileUpload2.FileName
            '.Status = txtStatus.Text
            '.Status = ddlStatus.SelectedValue
        End With

			If Len(txtURL.text) > 1 Then
				Response.Redirect("CU_unExpectedError.aspx")
			End If

            If Len(txtTitle.text) > 1 Then
				Rslt = DAL_Calendar.AddCalendarEventPublic(oItem)
				txtTitle.Text = ""
				'clndrHeadlineDate.SelectedDate = Now()
				chkAllDay.Checked = False
				txtContactNumber.Text = ""
				txtLocation.Text = ""
				txtDescription.Text = ""
				'lblfileName.Text = ""
				'txtStatus.Text = "Active"
				ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("Active"))
				pnlStatus.Visible = False
				SaveButton.Text = "Add Calendar Item"
			Else 
				exit sub
			End If
			
        'End If

			Dim mail As New MailMessage()
			
			mail.From = New MailAddress("DONOTREPLY@carpediem365.net")
			'mail.To.Add("" & emailAddress.Text & "")
			'mail.To.Add("info@aafpanamacity.com")
			mail.To.Add("mark@carpediem365.net") 
			'mail.CC.Add("information@baychamberfl.com")
			mail.BCC.Add("aaron@aaronrich.com")
			
			mail.Subject = "Carpe Diem 365: New Event Posting"
			mail.IsBodyHtml = True
			mail.Body = "You have received a request for a event posting for the Carpe Diem 365 website.  Please login at <strong><a href=http://www.carpediem365.net/Login.aspx>http://www.carpediem365.net/Login.aspx</a></strong> to review the request.  "
			
			Dim smtp As New SmtpClient("relay-hosting.secureserver.net")
			
			Try
			smtp.Credentials = New NetworkCredential("DONOTREPLY@carpediem365.net", "000215")
			smtp.Send(mail)
			Response.Redirect("S_Thanks.aspx")
			Catch ehttp As System.Web.HttpException
			Response.Redirect("CU_unExpectedError.aspx")
			End Try
		
		'Response.redirect("Calendar_Thanks.aspx")
		
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
