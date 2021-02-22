Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Diagnostics




Partial Class ImportData
    Inherits System.Web.UI.Page

	

Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		
	

    

End Sub

Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click


	Dim ImageFile0 As String






	If FileUpload0.HasFile Then
	ImageFile0 = FileUpload0.FileName
	Else
	ImageFile0 = lblErrorMsg.Text
	End If
	
		
	Dim csvPath As String = Server.MapPath("..\Documents\Imports") & "\" & FileUpload0.FileName
	Dim wpDataPath As String = Server.MapPath("..\Documents\Imports") & "\" & "wp_users.csv"
	Dim outPath As String = Server.MapPath("..\Documents\Imports") & "\" & "output.txt"
	
	
	If FileUpload0.HasFile Then
		Try
			FileUpload0.SaveAs(csvPath)
		Catch ex As Exception
			lblErrorMsg.Text = "ERROR! File upload 0 failed.    " & ex.ToString()
			'Exit Sub
		End Try

		lblErrorMsg.Text = "Success! Photo 0 was uploaded. Size: " & FileUpload0.PostedFile.ContentLength & " kb"
	End If
		
	Dim csvData As String = File.ReadAllText(csvPath)
		Dim wpUserData As String = File.ReadAllText(wpDataPath)
		
    'Execute a loop over the rows.
	Dim retString As String
    For Each row As String In csvData.Split(ControlChars.Lf)
        If Not String.IsNullOrEmpty(row) Then
            'dt.Rows.Add()
			'row = row.Replace(",,", ",0,")
            Dim i As Integer = 0
			Dim cells As String() = row.Split(","c)
			Dim Fullname As String = cells(1) & " " & cells(0)
			Dim Login As String = cells(2)
			Dim Email As String = cells(3)
			Dim time As DateTime = DateTime.Now
			Dim format As String = "yyyy-MM-dd HH:mm:ss"
			
			
			
			Dim id As String = GetContent(wpUserData, Login)
			Dim metaKey As String = "property_address"
			Dim metaValue As String = cells(0)
			If cells(0).ToLower().Contains("box") Then
				
				metaKey = "mailing_address"
				
			End If
			If Not id = "" Then
				'retString += id & vbCrLf
				retString += "INSERT INTO `wp_usermeta`" &
				"(" &
					"`user_id`," &
					"`meta_key`," &
					"`meta_value`" &
				")" &
				"VALUES" &
				"(" &
				"" & id & "," &
				"'full_name'," &
				"'" & Fullname &
				"');" & vbCrLf

				retString += "INSERT INTO `wp_usermeta`" &
				"(" &
					"`user_id`," &
					"`meta_key`," &
					"`meta_value`" &
				")" &
				"VALUES" &
				"(" &
				"" & id & "," &
				"'last_name'," &
				"'" & cells(0) &
				"');" & vbCrLf

				retString += "INSERT INTO `wp_usermeta`" &
				"(" &
					"`user_id`," &
					"`meta_key`," &
					"`meta_value`" &
				")" &
				"VALUES" &
				"(" &
				"" & id & "," &
				"'first_name'," &
				"'" & cells(1) &
				"');" & vbCrLf



				retString += "INSERT INTO `wp_usermeta`" &
				"(" &
					"`user_id`," &
					"`meta_key`," &
					"`meta_value`" &
				")" &
				"VALUES" &
				"(" &
				"" & id & "," &
				"'nickname'," &
				"'" & Login &
				"');" & vbCrLf



				retString += "INSERT INTO `wp_usermeta`" &
				"(" &
				"`user_id`," &
				"`meta_key`," &
				"`meta_value`" &
				")" &
				"VALUES" &
				"(" &
				"" & id & "," &
				"'account_status'," &
				"'approved');" & vbCrLf


				retString += "INSERT INTO `wp_usermeta`" &
				"(" &
				"`user_id`," &
				"`meta_key`," &
				"`meta_value`" &
				")" &
				"VALUES" &
				"(" &
				"" & id & "," &
				"'role'," &
				"'member');" & vbCrLf
			
			
			End If
            'Execute a loop over the columns.
            'For Each cell As String In row.Split(","c)
            '    'dt.Rows(dt.Rows.Count - 1)(i) = cell
				'retString += cell
            '    i += 1
            'Next
			retString += vbCrLf & vbCrLf
        End If
    Next
	lblErrorMsg.Text = retString	
			
	File.WriteAllText(outPath, retString)


End Sub



Public Function GetContent(content As String, userName As String) As String

	
	Dim retString As String
	
	For Each row As String In content.Split(ControlChars.Lf)
        If Not String.IsNullOrEmpty(row) Then
            'dt.Rows.Add()
			'row = row.Replace(",,", ",0,")
            Dim i As Integer = 0
			Dim cells As String() = row.Split(","c)

		
			If cells(1).Replace(Chr(34),"") = userName Then
			
				retString = cells(0).Replace(Chr(34),"")
			
			Else
			
				'retString = cells(1) 
			
			End If
		
			
			
            'Execute a loop over the columns.
            'For Each cell As String In row.Split(","c)
            '    'dt.Rows(dt.Rows.Count - 1)(i) = cell
				'retString += cell
            '    i += 1
            'Next
			'retString += vbCrLf & vbCrLf
        End If
    Next
	
	Return retString
	
			

End Function


End Class
