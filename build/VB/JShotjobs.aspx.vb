Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class FTBox2
    Inherits System.Web.UI.Page

    'THIS SAMPLE IS FOR USE WITH A MySQL DATABASE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Try

                Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

                'pageName value should be coded to match the name of the page where the content is to be loaded
                Dim sQueryString As String = "SELECT * FROM tblftb WHERE pageName = 'JShotjobs'"

                Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
                odbcConn.Open()

                Try

                    Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)
                    odbcReader.Read()

                    lblOut.Text = odbcReader("content").ToString()
                    'FreeTextBox1.Text = odbcReader("content").ToString()
                   'txtPageName.Text = odbcReader("pageName").ToString()

                    odbcReader.Close()

                Catch ex As Exception

                    odbcConn.Close()

                End Try

                odbcConn.Close()

            Catch ex As Exception

            End Try
			
            Try

                Dim sConnString2 As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConn2 As OdbcConnection = New OdbcConnection(sConnString2)

                'pageName value should be coded to match the name of the page where the content is to be loaded
                Dim sQueryString2 As String = "SELECT * FROM tblftb WHERE pageName = 'JShotjobs2'"

                Dim DBCommand2 As New OdbcCommand(sQueryString2, odbcConn2)
                odbcConn2.Open()

                Try

                    Dim odbcReader2 As OdbcDataReader = DBCommand2.ExecuteReader(CommandBehavior.CloseConnection)
                    odbcReader2.Read()

                    lblOut2.Text = odbcReader2("content").ToString()
                    'FreeTextBox1.Text = odbcReader("content").ToString()
                   'txtPageName.Text = odbcReader("pageName").ToString()

                    odbcReader2.Close()

                Catch ex As Exception

                    odbcConn2.Close()

                End Try

                odbcConn2.Close()

            Catch ex As Exception

            End Try

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

    'Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        'Output.Text = HttpUtility.HtmlEncode(FreeTextBox1.Text)
        'lblOut.Text = FreeTextBox1.Text


        'Dim sConnString As String = ConfigurationManager.ConnectionStrings("DMS").ConnectionString
        'Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        'odbcConn.Open()

        'Dim sqlString = "UPDATE tblwebcontent SET pageName = '" & txtPageName.Text & "', content = '" & FreeTextBox1.Text & "'"

        'Dim DBCommand As New OdbcCommand(sqlString, odbcConn)
        'DBCommand.ExecuteNonQuery()

        'odbcConn.Close()
        'odbcConn.Dispose()
    'End Sub

    'Protected Sub AddButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddButton.Click
        'Output.Text = HttpUtility.HtmlEncode(FreeTextBox1.Text)
        'lblOut.Text = FreeTextBox1.Text

        'Dim sConnString As String = ConfigurationManager.ConnectionStrings("DMS").ConnectionString
        'Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        'odbcConn.Open()

        'Dim sqlString = "INSERT INTO tblwebcontent (pageName, content) VALUES ('" & txtPageName.Text & "', '" & FreeTextBox1.Text & "')"

       ' Dim DBCommand As New OdbcCommand(sqlString, odbcConn)
        'DBCommand.ExecuteNonQuery()

        'odbcConn.Close()
        'odbcConn.Dispose()
    'End Sub

End Class
