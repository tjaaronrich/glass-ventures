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

Public Class Gallery_Photos 
	Inherits System.Web.UI.Page

  'Protected WithEvents Rotator1 As ComponentArt.Web.UI.Rotator
  Protected lblErrorMsg As Label
  Protected lblClickthroughAdd As Label
  Protected lblClickthroughAddTEST As Label
  Protected WithEvents txtClickthroughAdd As TextBox

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim GalleryToDisplay As String = "Default"

    If Not IsPostBack Then
	
            GalleryToDisplay = Server.HtmlDecode(Request.QueryString("pgName"))

            If Len(GalleryToDisplay) < 1 Then
                GalleryToDisplay = "Default"
            End If

            lblGallery.Text = GalleryToDisplay

            CreatePhotoDisplay(GalleryToDisplay)
	
	End If

  End Sub 

  Private Sub CreatePhotoDisplay(ByVal GalleryName As String)

        Dim numitems As Integer = 0
        Dim DisplayCode As String = ""

        If Len(GalleryName) < 1 Then
            GalleryName = "Default"
        End If

        Try

            Dim sConnString1 As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn1 As OdbcConnection = New OdbcConnection(sConnString1)
            Dim sQueryString1 As String = "SELECT count(*) As RowCnt from tblgallery where status = 'Active' and pgName = '" & GalleryName & "'"

            Dim DBCommand1 As New OdbcCommand(sQueryString1, odbcConn1)
            odbcConn1.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand1.ExecuteReader(CommandBehavior.CloseConnection)

                odbcReader.Read()

                numitems = Convert.ToInt16(odbcReader("RowCnt"))

                odbcReader.Close()

            Catch ex As Exception

                odbcConn1.Close()

            End Try

            odbcConn1.Close()
            odbcConn1.Dispose()

        Catch ex As Exception

        End Try

        Dim arrImageFile() As String
        ReDim arrImageFile(numitems) 'will start count at 1 instead of zero

        Dim arrphotoName() As String
        ReDim arrphotoName(numitems) 'will start count at 1 instead of zero

        Dim arrphotoID() As String
        ReDim arrphotoID(numitems) 'will start count at 1 instead of zero

        Dim arrCntr As Integer = 1

        Dim numRows As Integer = 0
        Dim remainder As Integer = 0

        Dim outerLoopCnt As Integer = 0
        Dim innerLoopCnt As Integer = 0
        Dim ii As Integer = 0
        Dim oo As Integer = 0

        numRows = numitems \ 2
        remainder = numitems - (numRows * 2)

        outerLoopCnt = numRows + 1
        innerLoopCnt = remainder

        '-------------------------------------------------------------

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
        'Dim sQueryString As String = "SELECT * from tblgallery where status = 'Active' ORDER BY photoID"
        Dim sQueryString As String = "SELECT * from tblgallery where status = 'Active' and pgName = '" & GalleryName & "' ORDER BY photoID"

        Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
        odbcConn.Open()

        Try
            Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

            While odbcReader.Read()

                arrImageFile(arrCntr) = Trim(odbcReader("ImageFile").ToString)
                arrphotoName(arrCntr) = Trim(odbcReader("Name").ToString)
                arrphotoID(arrCntr) = Trim(odbcReader("photoID").ToString)

                arrCntr = arrCntr + 1

            End While

            odbcReader.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

        End Try
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        If numitems > 0 Then

            arrCntr = 1

            For oo = 1 To outerLoopCnt
                Response.Write("<tr>")

                If oo < outerLoopCnt Then
                    For ii = 1 To 2
                        'Response.Write("   <td style='width: 33%; text-align: left; vertical-align: top'>")
                        'Response.Write("<table width='175' border='0' cellspacing='0' cellpadding='0'><tr><td background='Documents/Gallery/Thumbs/" & arrImageFile(arrCntr) & "' style='background-position:center; background-repeat:no-repeat'><a href='Documents/Gallery/BigGallery/" & arrImageFile(arrCntr) & "' target='_blank' rel='lightbox[Gallery]' title='" & arrphotoName(arrCntr) & "'><img src='Graphics/spacer.gif' alt='" & arrphotoName(arrCntr) & "' width='175' height='115' border='0'></a></td><td width='15' rowspan='2' style='background-image:url(Graphics/Fade_02.jpg); background-repeat:no-repeat; background-position:left bottom'><img src='Graphics/spacer.gif' width='15' height='15'></td></tr><tr><td height='15' style='background-image:url(Graphics/Fade_01.jpg); background-repeat:no-repeat; background-position:right top'><img src='Graphics/spacer.gif' width='15' height='15'></td></tr></table>")
                        'Response.Write("   </td>")

                        DisplayCode = DisplayCode & "   <td style='width: 50%; text-align: left; vertical-align: top'>"
                        DisplayCode = DisplayCode & "<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td background='Documents/Gallery/Thumbs/" & arrImageFile(arrCntr) & "' style='background-position:center; background-repeat:no-repeat'><a href='Documents/Gallery/BigGallery/" & arrImageFile(arrCntr) & "' target='_blank' rel='lightbox[Gallery]' title='" & arrphotoName(arrCntr) & "'><img src='Graphics/spacer.gif' alt='" & arrphotoName(arrCntr) & "' width='100%' height='225' border='0'></a></td><td width='15' rowspan='2' style='background-image:url(Graphics/Fade_02.jpg); background-repeat:no-repeat; background-position:left bottom'><img src='Graphics/spacer.gif' width='15' height='15'></td></tr><tr><td height='15' style='background-image:url(Graphics/Fade_01.jpg); background-repeat:no-repeat; background-position:right top'><img src='Graphics/spacer.gif' width='15' height='15'></td></tr></table>"
                        DisplayCode = DisplayCode & "   </td>"

                        arrCntr = arrCntr + 1
                    Next
                Else
                    For ii = 1 To innerLoopCnt
                        'Response.Write("   <td style='width: 33%; text-align: left; vertical-align: top'>")
                        'Response.Write("<table width='175' border='0' cellspacing='0' cellpadding='0'><tr><td background='Documents/Gallery/Thumbs/" & arrImageFile(arrCntr) & "' style='background-position:center; background-repeat:no-repeat'><a href='Documents/Gallery/BigGallery/" & arrImageFile(arrCntr) & "' target='_blank' rel='lightbox[Gallery]' title='" & arrphotoName(arrCntr) & "'><img src='Graphics/spacer.gif' alt='" & arrphotoName(arrCntr) & "' width='175' height='115' border='0'></a></td><td width='15' rowspan='2' style='background-image:url(Graphics/Fade_02.jpg); background-repeat:no-repeat; background-position:left bottom'><img src='Graphics/spacer.gif' width='15' height='15'></td></tr><tr><td height='15' style='background-image:url(Graphics/Fade_01.jpg); background-repeat:no-repeat; background-position:right top'><img src='Graphics/spacer.gif' width='15' height='15'></td></tr></table>")
                        'Response.Write("   </td>")

                        DisplayCode = DisplayCode & "   <td style='width: 50%; text-align: left; vertical-align: top'>"
                        DisplayCode = DisplayCode & "<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td background='Documents/Gallery/Thumbs/" & arrImageFile(arrCntr) & "' style='background-position:center; background-repeat:no-repeat'><a href='Documents/Gallery/BigGallery/" & arrImageFile(arrCntr) & "' target='_blank' rel='lightbox[Gallery]' title='" & arrphotoName(arrCntr) & "'><img src='Graphics/spacer.gif' alt='" & arrphotoName(arrCntr) & "' width='100%' height='225' border='0'></a></td><td width='15' rowspan='2' style='background-image:url(Graphics/Fade_02.jpg); background-repeat:no-repeat; background-position:left bottom'><img src='Graphics/spacer.gif' width='15' height='15'></td></tr><tr><td height='15' style='background-image:url(Graphics/Fade_01.jpg); background-repeat:no-repeat; background-position:right top'><img src='Graphics/spacer.gif' width='15' height='15'></td></tr></table>"
                        DisplayCode = DisplayCode & "   </td>"

                        If ii < innerLoopCnt Then
                            arrCntr = arrCntr + 1
                        End If
                    Next

                    'If innerLoopCnt = 1 Then
                    '    Response.Write("<td></td><td></td>")
                    'End If
                    If innerLoopCnt = 1 Then
                        Response.Write("<td>&nbsp;</td>")
                    End If
                End If

                'Response.Write("</tr>")
                DisplayCode = DisplayCode & "</tr>"

            Next

        End If

        'output to label
        lblDisplayPhotos.Text = DisplayCode

    End Sub

End Class
