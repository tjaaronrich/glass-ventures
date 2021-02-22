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
		
				GridView1.Caption = Path.GetFileName(FilePathLoad)
				GridView1.DataSource = dt
				GridView1.DataBind()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If FileUpload1.HasFile Then
            Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")

            Dim FilePath As String = Server.MapPath(FolderPath + "DailyPosting.xls")
            'Dim FilePath As String = Server.MapPath(FolderPath + FileName)
            FileUpload1.SaveAs(FilePath)
            Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
        End If
    End Sub
	
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
        Dim conStr As String = ""
        Select Case Extension
            Case ".xls"
                'Excel 97-03 
                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                Exit Select
            Case ".xlsx"
                'Excel 07 
                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
                Exit Select
        End Select
        conStr = String.Format(conStr, FilePath, isHDR)

        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        Dim dt As New DataTable()

        cmdExcel.Connection = connExcel

        'Get the name of First Sheet 
        connExcel.Open()
        Dim dtExcelSchema As DataTable
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
        connExcel.Close()

        'Read Data from First Sheet 
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()

        'Bind Data to GridView 

        GridView1.Caption = Path.GetFileName(FilePath)
        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub
	
	

    Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
        Dim FileName As String = GridView1.Caption
        Dim Extension As String = Path.GetExtension(FileName)
        Dim FilePath As String = Server.MapPath(FolderPath + FileName)

        Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

End Class
