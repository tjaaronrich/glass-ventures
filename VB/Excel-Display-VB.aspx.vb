Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration
Partial Class VB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Try
			
				'Dim FileNameLoad As String = Path.GetFileName(DailyPosting.xls)
				'Dim ExtensionLoad As String = Path.GetExtension(DailyPosting.xls)
				Dim FolderPathLoad As String = ConfigurationManager.AppSettings("FolderPath")
				Dim FilePathLoad As String = Server.MapPath(FolderPathLoad + "DailyPosting.xls")
				Dim conStr As String = ""
				Dim isHDR As String = "Yes"
				''Select Case Extension
					''Case ".xls"
						'Excel 97-03 
						conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
						''Exit Select
					''Case ".xlsx"
						'Excel 07 
						''conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
						''Exit Select
				''End Select
				conStr = String.Format(conStr, FilePathLoad, isHDR)
		
				Dim connExcel As New OleDbConnection(conStr)
				Dim cmdExcel As New OleDbCommand()
				Dim oda As New OleDbDataAdapter()
				Dim dt As New DataTable()
		
				cmdExcel.Connection = connExcel
		
				'Get the name of First Sheet 
				connExcel.Open()
				Dim dtExcelSchema As DataTable
				dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
				Dim SheetNameLoad As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
				connExcel.Close()
		
				'Read Data from First Sheet 
				connExcel.Open()
				cmdExcel.CommandText = "SELECT * From [" & SheetNameLoad & "]"
				oda.SelectCommand = cmdExcel
				oda.Fill(dt)
				connExcel.Close()
		
				'Bind Data to GridView 
		
				'GridView1.Caption = Path.GetFileName(FilePathLoad)
				GridView1.DataSource = dt
				GridView1.DataBind()

            Catch ex As Exception

            End Try

        End If

    End Sub

End Class
