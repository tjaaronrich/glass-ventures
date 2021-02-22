<%@ import namespace="System.Data" %> 
<%@ import namespace="System.Data.OleDb" %>
<%@ import Namespace="System.IO" %>
<%@ import namespace="System.Configuration" %>
<%@ import Namespace="System.Data.Odbc" %>
<%@ import Namespace="System.Data.SqlClient" %>
<%@ import Namespace="System.Collections.Generic" %>

<script runat="server">

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
				cmdExcel.CommandText = "SELECT * From [" & SheetNameLoad & "] "
				oda.SelectCommand = cmdExcel
				oda.Fill(dt)
				connExcel.Close()
		
				'Bind Data to GridView 
		
				'GridView1.Caption = Path.GetFileName(FilePathLoad)
				GridViewHotJobs.DataSource = dt
				GridViewHotJobs.DataBind()

            Catch ex As Exception

            End Try

        End If

    End Sub
	
    Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
        Dim FileName As String = GridViewHotJobs.Caption
        Dim Extension As String = Path.GetExtension(FileName)
		Dim FilePath As String = Server.MapPath(FolderPath + "DailyPosting.xls")

        'Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
        GridViewHotJobs.PageIndex = e.NewPageIndex
        GridViewHotJobs.DataBind()

    End Sub
	
</script>

<h2>Hot Jobs</h2>
<asp:ObjectDataSource ID="ODS_HotJobs" runat="server" SelectMethod="GeActiveJobsRand3" TypeName="DAL_JobOpportunities" DataObjectTypeName="PC_JobOpportunities" ></asp:ObjectDataSource>

        <asp:GridView ID="GridViewHotJobs" runat="server" showheader="false" AllowPaging="False" PageSize="3" OnPageIndexChanging="PageIndexChanging" GridLines="None" runat="server" AutoGenerateColumns="False" 
                                width=100%
                                CellPadding="0" 
                                CellSpacing="0"
                                Border="0"
                                ForeColor="#000000"  
                                Font-Names="Arial" 
                                Font-Size="11px">
            <columns>
                    <asp:TemplateField HeaderText="Jobs">
                       <ItemTemplate>
                               
<p style="display: block; margin: 10px; margin-left:0px; padding: 0px; padding-bottom:10px; padding-top:10px; border-bottom: 1px solid #ddd;"><strong><a href="Job-Seekers-Hot-Jobs-Hiring-Events.aspx#HotJobs" class="Black"><%#Eval("Job Title")%></a></strong> (#<%#Eval("Job #")%>)<br /><%#Eval("Wage")%>/<%#Eval("Salary Unit")%> - <%#Eval("Job Type")%></p>

                      </ItemTemplate>
                    </asp:TemplateField>
			  </Columns>

        </asp:GridView>


<a href="job-seekers-hot-jobs-hiring-events.aspx" style="display: block; margin: 10px; margin-left:0px; padding: 0px; padding-bottom:10px; padding-top:10px; ">View all job listings</a>
<p>&nbsp;</p>