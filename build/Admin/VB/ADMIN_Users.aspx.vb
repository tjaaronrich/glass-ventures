
Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class ADMIN_Users
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("accessLevel") <> 1 Then
            Response.Redirect("../AccessDenied.aspx")
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim acctNum As Integer = GridView1.SelectedValue
        Response.Redirect("ADMIN_UserAdd.aspx?mode=edit&acctNum=" & acctNum.ToString)
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("ADMIN_UserAdd.aspx?mode=add&acctNum=0")
    End Sub
End Class
