Imports Microsoft.VisualBasic

Imports System.Configuration

Imports System.Data

Imports System.Data.Odbc

Imports System.Data.SqlClient

Imports System.Collections.Generic



Partial Class Detail_FAQs

    Inherits System.Web.UI.Page



	Public FAQS As String

	

	

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not Page.IsPostBack Then



			

			Try

				Dim i As Integer = 0

				Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString

				Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

				Dim sQueryString As String = "SELECT * FROM tblfaqs "

				Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)

				odbcConn.Open()

	

				Try

	

					Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

					

					FAQS += "<ul class='collapsible' data-collapsible='accordion'>"

					

					While odbcReader.Read()



						'lblOut.Text += "<div class='col-md-12'>"

						'Dim myDateString as String = Trim(odbcReader("ItemDate").ToString)

						'Dim myDate as DateTime

						'DateTime.TryParse(myDateString, myDate).ToString()

							

						FAQS += "" & 
						"<li><div class='collapsible-header'><i class='material-icons'>arrow_drop_down_circle</i><h5 style='letter-spacing: 0px; font-weight: bold;font-family: ""Open Sans"";'>" & Trim(odbcReader("question").ToString) & "</h5></div><div class='collapsible-body'><span>" & Trim(odbcReader("answer").ToString) & "</span></div></li>" 

						

					

						

	

						i += 1

					End While

					

					FAQS += "</ul>"

					

					

					odbcReader.Close()

	

				Catch ex As Exception

	

					odbcConn.Close()

	

				End Try

	

				odbcConn.Close()

	

			Catch ex As Exception

	

			End Try

			

			

			



        End If



    End Sub



End Class

