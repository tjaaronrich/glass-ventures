Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class HotJobs
    Inherits System.Web.UI.Page

    'THIS SAMPLE IS FOR USE WITH A MySQL DATABASE

Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If File.Exists("G:\PleskVhosts\aaronrich.us\httpdocs\HotJobs\DailyPosting.csv") Then
        Dim data As String() = File.ReadAllLines("G:\PleskVhosts\aaronrich.us\httpdocs\HotJobs\DailyPosting.csv")
 
        Dim dt As New DataTable()
 
        Dim col As String() = data(0).Split(",")
 
        For Each s As String In col
            dt.Columns.Add(s, GetType(String))
        Next
 
        For i As Integer = 0 To data.Length - 1
            Dim row As String() = data(i).Split(",")
            dt.Rows.Add(row)
        Next
        GridView1.DataSource = dt
        GridView1.DataBind()
    End If
End Sub

End Class
