Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.DateTime
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Partial Class EmploymentApp

    Inherits System.Web.UI.Page

    Protected Sub submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles submit.Click

        Dim oItem As New PC_EmploymentApp
        Dim Rslt As Integer
        'Dim cnt As Integer
        Dim counterA As Integer
        Dim counterI As Integer
        Dim counterD As Integer
        Dim counterE As Integer
        Dim counterS As Integer
        Dim counterR As Integer

		If q001aYes.checked and q001cYes.checked Then
		lblError.text = "You may only select one box at a time"
		Exit Sub
		End If

		If preferredMethodA.Checked Then
		preferredMethod = Email
		End If
		 
		If preferredMethodB.Checked Then
		preferredMethod = Phone
		End If
		
		If preferredMethodC.Checked Then
		preferredMethod = Mail
		End If

		

		lblCounterA.text = counterA
		lblCounterI.text = counterI
		lblCounterD.text = counterD
		lblCounterE.text = counterE
		lblCounterS.text = counterS
		lblCounterR.text = counterR

        With oItem
			.appNum = txtAppNum.Text
			.aNum = counterA
			.iNum = counterI
			.dNum = counterD
			.eNum1 = counterE
			.sNum = counterS
			.rNum = counterR
			.addDate = Now()
        End With
				
		Rslt = DAL_EmploymentApp.AddEmploymentApp(oItem)
		
		'With oItem
		'	.appNum = txtAppNum.Text
		'	.aNum = counterA
		'	.iNum = counterI
		'	.dNum = counterD
		'	.eNum1 = counterE
		'	.sNum = counterS
		'	.rNum = counterR
		'	.addDate = Now()
		'End With
	
	Response.Redirect("thanks.aspx")

    End Sub

End Class
