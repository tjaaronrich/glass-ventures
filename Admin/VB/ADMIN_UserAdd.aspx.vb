Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class ADMIN_UserEdit
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oAcct As New PC_Account
        Dim acctStr As String
        Dim acctNum As Integer
        acctStr = Server.HtmlDecode(Request.QueryString("acctNum"))

        If Not Page.IsPostBack Then
            If Session("accessLevel") = "1" Then
                lblMode.Text = Server.HtmlDecode(Request.QueryString("mode"))
                If lblMode.Text = "add" Then
                    btnAction.Text = "Add Account"
                    pnlInstruct.Visible = False
                    lblCurrent.Visible = False
                    lblCurrentLevel.Visible = False
                    lblNewLevel.Visible = False
                End If
                If lblMode.Text = "edit" Then
                    btnAction.Text = "Update Account"
                    lblCurrent.Visible = False
                    lblCurrentLevel.Visible = False
                    lblNewLevel.Visible = False
                    acctStr = Server.HtmlDecode(Request.QueryString("acctNum"))
                    acctNum = Convert.ToInt16(acctStr)
                    'get existing data and populate form
                    If acctNum > 0 Then
                        oAcct = DAL_Account.GetAccountByNum(acctNum)

                        With oAcct
                            lblAccountNum.Text = .acctNum
                            txtUName.Text = .uName
                            lblPW.Text = .passWord
                            If Len(.passWord) = 0 Then
                                lblErrorMsg.Text = "NOTE: There is no existing password, so one must be entered."
                            End If
                            txtPassword.Text = .passWord
                            lblCurrentLevel.Text = .PermissionLevel.ToString
                            'ddlLevel.SelectedIndex = ddlLevel.Items.IndexOf(ddlLevel.Items.FindByValue(.PermissionLevel))
                            txtFullName.Text = .FullName
                        End With
                    Else
                        lblErrorMsg.Text = "ERROR: Account Number is not greater than zero. Invalid record."
                    End If
                End If
            Else
                Response.Redirect("AccessDenied.aspx")
            End If
        End If

    End Sub

    Protected Sub btnAction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAction.Click

        Dim oItem As New PC_Account
        Dim Rslt As Integer

        With oItem
            .uName = txtUName.Text
            .passWord = txtPassword.Text
            If Len(.passWord) = 0 And Len(lblPW.Text) = 0 Then
                lblErrorMsg.Text = "ERROR: A password is required as there is no previous password to use."
                Exit Sub
            End If
            If Len(txtPassword.Text) = 0 Then
                .passWord = lblPW.Text
            End If
            .PermissionLevel = Convert.ToInt16(ddlLevel.SelectedValue)
            .FullName = txtFullName.Text
            If btnAction.Text = "Update Account" Then
                .acctNum = lblAccountNum.Text
            End If
        End With

        If btnAction.Text = "Update Account" Then
            Rslt = DAL_Account.ModAccount(oItem)
            lblAccountNum.Text = ""
            txtUName.Text = ""
            txtPassword.Text = ""
            ddlLevel.SelectedIndex = ddlLevel.Items.IndexOf(ddlLevel.Items.FindByValue("1"))
            txtFullName.Text = ""
            btnAction.Text = "Add Account"
        Else
            Rslt = DAL_Account.AddAccount(oItem)
            lblAccountNum.Text = ""
            txtUName.Text = ""
            txtPassword.Text = ""
            ddlLevel.SelectedIndex = ddlLevel.Items.IndexOf(ddlLevel.Items.FindByValue("1"))
            txtFullName.Text = ""
            btnAction.Text = "Add Account"
        End If

        Response.Redirect("ADMIN_Users.aspx")

    End Sub

End Class
