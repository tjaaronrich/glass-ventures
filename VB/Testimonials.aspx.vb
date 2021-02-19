Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Mail
Imports ComponentArt
Imports ComponentArt.Web
Imports ComponentArt.Web.UI

Public Class ComponentArtRotator 
	Inherits System.Web.UI.Page

  Protected WithEvents Rotator1 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorBannerAd1 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorBannerAd2 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorColumnAd1 As ComponentArt.Web.UI.Rotator
  Protected WithEvents RotatorColumnAd2 As ComponentArt.Web.UI.Rotator
  Protected lblOut As Label
  Protected lblErrorMsg As Label
  Protected lblClickthroughAdd As Label
  Protected lblClickthroughAddTEST As Label
  Protected WithEvents txtClickthroughAdd As TextBox
  Protected pnlRotator1 As Panel
  Protected pnlRotator2 As Panel
  Protected pnlRotatorColumn1 As Panel
  Protected pnlRotatorColumn2 As Panel
  Protected WithEvents InvisibleButton As Button
  Protected WithEvents InvisibleColumnButton As Button

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
		Dim sQueryString As String
	
		Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
		Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
		odbcConn.Open()
         Try
               sQueryString = "UPDATE tblads SET Impressions = Impressions + 1 WHERE Status = 'Active' and AdPage = 'AboutTheChamber'"

            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

        End Try

		Try
                Dim sConnStringFTB As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
                Dim odbcConnFTB As OdbcConnection = New OdbcConnection(sConnStringFTB)

                'pageName value should be coded to match the name of the page where the content is to be loaded
                Dim sQueryStringFTB As String = "SELECT * FROM tblftb WHERE pageName = 'Testimonials'"

                Dim DBCommandFTB As New OdbcCommand(sQueryStringFTB, odbcConnFTB)
                odbcConnFTB.Open()

                Try

                    Dim odbcReaderFTB As OdbcDataReader = DBCommandFTB.ExecuteReader(CommandBehavior.CloseConnection)
                    odbcReaderFTB.Read()

                    lblOut.Text = odbcReaderFTB("content").ToString()
                    'FreeTextBox1.Text = odbcReader("content").ToString()
                   'txtPageName.Text = odbcReader("pageName").ToString()

                    odbcReaderFTB.Close()

                Catch ex As Exception

                    odbcConnFTB.Close()

                End Try

                odbcConnFTB.Close()

            Catch ex As Exception

		End Try

	End If
      FillRotatorBannerAd1() 
      FillRotatorColumnAd1() 
  End Sub 

  Private Sub FillRotatorBannerAd1()

  	Dim cnt as Integer = 0
	cnt = CountAds()
	If cnt > 1 Then
	pnlRotator1.Visible = True
	pnlRotator2.Visible = False
	Else 
	pnlRotator1.Visible = False
	pnlRotator2.Visible = True
	End If

	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String = "SELECT * FROM tblads WHERE Status = 'Active'  and AdSize = '468x60' and AdPage = 'AboutTheChamber' ORDER BY iSort"
	Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
	odbcConn.Open()

    Dim reader As OdbcDataReader
    reader = DBCommand.ExecuteReader()

	If cnt > 1 Then
    RotatorBannerAd1.DataSource = reader
    RotatorBannerAd1.DataBind()
	Else 
    RotatorBannerAd2.DataSource = reader
    RotatorBannerAd2.DataBind()
	End If

  End Sub

  Private Sub FillRotatorColumnAd1()

  	Dim cnt as Integer = 0
	cnt = CountColumnAds()
	If cnt > 1 Then
	pnlRotatorColumn1.Visible = True
	pnlRotatorColumn2.Visible = False
	Else 
	pnlRotatorColumn1.Visible = False
	pnlRotatorColumn2.Visible = True
	End If

	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String = "SELECT * FROM tblads WHERE Status = 'Active'  and AdSize = '200x200' and AdPage = 'AboutTheChamber' ORDER BY iSort"
	Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
	odbcConn.Open()

    Dim reader As OdbcDataReader
    reader = DBCommand.ExecuteReader()

	If cnt > 1 Then
    RotatorColumnAd1.DataSource = reader
    RotatorColumnAd1.DataBind()
	Else 
    RotatorColumnAd2.DataSource = reader
    RotatorColumnAd2.DataBind()
	End If

  End Sub

  Protected Function CountAds() as Integer
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String = "SELECT COUNT(*) as NumAds FROM tblads WHERE Status = 'Active'  and AdSize = '468x60' and AdPage = 'AboutTheChamber' ORDER BY iSort"
	Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
    Dim cnt as Integer = 0
	odbcConn.Open()

    Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    cnt = Convert.ToInt16(odbcReader("NumAds"))
					
				End If

	Return cnt

  End Function

  Protected Function CountColumnAds() as Integer
	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	Dim sQueryString As String = "SELECT COUNT(*) as NumAds FROM tblads WHERE Status = 'Active'  and AdSize = '200x200' and AdPage = 'AboutTheChamber' ORDER BY iSort"
	Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
    Dim cnt as Integer = 0
	odbcConn.Open()

    Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    cnt = Convert.ToInt16(odbcReader("NumAds"))
					
				End If

	Return cnt

  End Function

	Protected Sub txtClickthroughAdd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClickthroughAdd.TextChanged

	End Sub
	
	Protected Sub InvisibleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InvisibleButton.Click
	Dim NumClicks as Integer
	Dim adIDparam as Integer
			
	adIDparam = Convert.ToInt16(txtClickthroughAdd.text)
		
		ClickthroughAdd2(adIDparam)
	
	End Sub

  Protected Sub ClickthroughAdd2(ByVal adID as Integer)

	Dim sQueryString As String

	Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
	Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
	odbcConn.Open() 

         Try
            sQueryString = "UPDATE tblads SET Clickthrough = Clickthrough + 1 WHERE adID = " & adID
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

        End Try

  End Sub

End Class
