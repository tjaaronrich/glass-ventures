Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Net
Imports System.Net.Mail


Public Class DAL_Account


    Public Shared Function GetImageByNum(ByVal acctNum As Integer) As String

        Dim oItem As New PC_Account

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblaccount WHERE acctNum = " & acctNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.acctNum = Convert.ToInt16(odbcReader("acctNum"))
                    If odbcReader("uName").Equals(DBNull.Value) Then
                        oItem.uName = ""
                    Else
                        oItem.uName = Trim(odbcReader("uName").ToString)
                    End If
                    If odbcReader("passWord").Equals(DBNull.Value) Then
                        oItem.passWord = ""
                    Else
                        oItem.passWord = Trim(odbcReader("passWord").ToString)
                    End If
                    oItem.PermissionLevel = Convert.ToInt16(odbcReader("PermissionLevel"))
                    If odbcReader("FullName").Equals(DBNull.Value) Then
                        oItem.FullName = ""
                    Else
                        oItem.FullName = Trim(odbcReader("FullName").ToString)
                    End If
                    If odbcReader("addDate").Equals(DBNull.Value) Then
                        oItem.addDate = ""
                    Else
                        oItem.addDate = Trim(odbcReader("addDate").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If
                Else
                    oItem.acctNum = 0
                End If

                odbcReader.Close()
                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                odbcConn.Dispose()

            End Try

        Catch ex As Exception

        End Try

        Return oItem.ImageFile

    End Function






	Public Shared Function MD5AccountLogin(ByVal oUser As PC_Account) As Integer

        Dim oItem As New PC_Account
        Dim Rslt As Integer = 0
        Dim ePW As String
        Dim eUN As String

        ePW = oUser.passWord
		eUN = oUser.uName

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
			Dim sQueryString As String = "select count(*) from tblaccount where uName = '" & eUN & "' and passWord = MD5('" & ePW & "')"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try
				Rslt = Convert.ToInt32(DBCommand.ExecuteScalar())

                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                odbcConn.Dispose()
                Rslt = 2

            End Try

        Catch ex As Exception
            Rslt = 3
        End Try

        Return Rslt
			
	End Function
		



#Region "Staff"

    Public Shared Function AccountLogin(ByVal oUser As PC_Account) As Integer
        'checks encrypted password (from user) against encrypted password from database; login succeeds if they match
        'checks number of failed login attempts within past 2 hours, and calls account locking function if 5 or more

        Dim oItem As New PC_Account
        Dim Rslt As Integer = 0
        Dim ePW As String

        'ePW = FormsAuthentication.HashPasswordForStoringInConfigFile(oUser.passWord, "SHA1")
        ePW = oUser.passWord

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT passWord FROM tblaccount WHERE uName = '" & oUser.uName & "'"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try
                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.passWord = Trim(odbcReader("passWord").ToString)
                    If ePW = oItem.passWord Then
                        'user is valid, password is correct
                        Rslt = 1
                    End If
                Else
                    Rslt = 0
                End If

                odbcReader.Close()
                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                odbcConn.Dispose()
                Rslt = 0

            End Try

        Catch ex As Exception
            Rslt = 0
        End Try

        Return Rslt

    End Function

    Public Shared Function GetAllAccounts() As List(Of PC_Account)

        Dim oList As New List(Of PC_Account)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblaccount ORDER BY uName"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Account

                    oItem.acctNum = Convert.ToInt16(odbcReader("acctNum"))
                    If odbcReader("uName").Equals(DBNull.Value) Then
                        oItem.uName = ""
                    Else
                        oItem.uName = Trim(odbcReader("uName").ToString)
                    End If
                    If odbcReader("passWord").Equals(DBNull.Value) Then
                        oItem.passWord = ""
                    Else
                        oItem.passWord = Trim(odbcReader("passWord").ToString)
                    End If
                    oItem.PermissionLevel = Convert.ToInt16(odbcReader("PermissionLevel"))
                    If odbcReader("FullName").Equals(DBNull.Value) Then
                        oItem.FullName = ""
                    Else
                        oItem.FullName = Trim(odbcReader("FullName").ToString)
                    End If
                    If odbcReader("addDate").Equals(DBNull.Value) Then
                        oItem.addDate = ""
                    Else
                        oItem.addDate = Trim(odbcReader("addDate").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If

                    oList.Add(oItem)
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oList

    End Function
	
	    Public Shared Function GetAccountByUser(pLinkId As String) As List(Of PC_Account)

        Dim oList As New List(Of PC_Account)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblaccount where acctNum = '" & pLinkId & "' ORDER BY uName"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Account

                    oItem.acctNum = Convert.ToInt16(odbcReader("acctNum"))
                    If odbcReader("uName").Equals(DBNull.Value) Then
                        oItem.uName = ""
                    Else
                        oItem.uName = Trim(odbcReader("uName").ToString)
                    End If
                    If odbcReader("passWord").Equals(DBNull.Value) Then
                        oItem.passWord = ""
                    Else
                        oItem.passWord = Trim(odbcReader("passWord").ToString)
                    End If
                    oItem.PermissionLevel = Convert.ToInt16(odbcReader("PermissionLevel"))
                    If odbcReader("FullName").Equals(DBNull.Value) Then
                        oItem.FullName = ""
                    Else
                        oItem.FullName = Trim(odbcReader("FullName").ToString)
                    End If
                    If odbcReader("addDate").Equals(DBNull.Value) Then
                        oItem.addDate = ""
                    Else
                        oItem.addDate = Trim(odbcReader("addDate").ToString)
                    End If
                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If

                    oList.Add(oItem)
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oList

    End Function
	
	
	
    Public Shared Function GetAccountByNum(ByVal acctNum As Integer) As PC_Account

        Dim oItem As New PC_Account

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblaccount WHERE acctNum = " & acctNum
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.acctNum = Convert.ToInt16(odbcReader("acctNum"))
                    If odbcReader("uName").Equals(DBNull.Value) Then
                        oItem.uName = ""
                    Else
                        oItem.uName = Trim(odbcReader("uName").ToString)
                    End If
                    If odbcReader("passWord").Equals(DBNull.Value) Then
                        oItem.passWord = ""
                    Else
                        oItem.passWord = Trim(odbcReader("passWord").ToString)
                    End If
                    oItem.PermissionLevel = Convert.ToInt16(odbcReader("PermissionLevel"))
                    If odbcReader("FullName").Equals(DBNull.Value) Then
                        oItem.FullName = ""
                    Else
                        oItem.FullName = Trim(odbcReader("FullName").ToString)
                    End If
                    If odbcReader("addDate").Equals(DBNull.Value) Then
                        oItem.addDate = ""
                    Else
                        oItem.addDate = Trim(odbcReader("addDate").ToString)
                    End If
                Else
                    oItem.acctNum = 0
                End If

                odbcReader.Close()
                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                odbcConn.Dispose()

            End Try

        Catch ex As Exception

        End Try

        Return oItem

    End Function
    Public Shared Function GetAccountByuName(ByVal uName As String) As PC_Account

        Dim oItem As New PC_Account
        Dim sQueryString As String

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            sQueryString = "SELECT * FROM tblaccount WHERE uName = '" & uName & "'"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.acctNum = Convert.ToInt16(odbcReader("acctNum"))
                    If odbcReader("uName").Equals(DBNull.Value) Then
                        oItem.uName = ""
                    Else
                        oItem.uName = Trim(odbcReader("uName").ToString)
                    End If
                    If odbcReader("passWord").Equals(DBNull.Value) Then
                        oItem.passWord = ""
                    Else
                        oItem.passWord = Trim(odbcReader("passWord").ToString)
                    End If
                    oItem.PermissionLevel = Convert.ToInt16(odbcReader("PermissionLevel"))
                    If odbcReader("FullName").Equals(DBNull.Value) Then
                        oItem.FullName = ""
                    Else
                        oItem.FullName = Trim(odbcReader("FullName").ToString)
                    End If
                    If odbcReader("addDate").Equals(DBNull.Value) Then
                        oItem.addDate = ""
                    Else
                        oItem.addDate = Trim(odbcReader("addDate").ToString)
                    End If
                Else
                    oItem.acctNum = 0
                End If

                odbcReader.Close()
                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                odbcConn.Dispose()

            End Try

        Catch ex As Exception

        End Try

        Return oItem

    End Function

    Public Shared Function AddAccount(ByVal oItem As PC_Account) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "INSERT INTO tblaccount " & _
            "(uName, " & _
            "passWord, " & _
            "PermissionLevel, " & _
            "FullName, " & _
            "ImageFile, " & _
            "addDate)" & _
            " VALUES " & _
            "('" & oItem.uName & _
            "', '" & oItem.passWord & _
            "', " & oItem.PermissionLevel & _
            ", '" & oItem.FullName & _
            "', '" & oItem.ImageFile & _
            "', CURDATE() )"

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

    Public Shared Function ModAccount(ByVal oItem As PC_Account) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem
                sQueryString = "UPDATE tblaccount " & _
                "SET uName = '" & .uName & _
                "', passWord = '" & .passWord & _
                "', PermissionLevel = " & .PermissionLevel & _
                ", FullName = '" & .FullName & _
                "', ImageFile = '" & .ImageFile & _
                "' WHERE acctNum = " & .acctNum
            End With

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function

    Public Shared Function DelAccount(ByVal oItem As PC_Account) As Integer

        Dim Rslt As Integer = 0
        Dim sQueryString As String
        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            With oItem
                sQueryString = "DELETE FROM tblaccount WHERE acctNum = " & .acctNum
            End With

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            Rslt = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            Rslt = 0

        End Try

        Return Rslt

    End Function
    Public Shared Function FindAccountByName(ByVal NamePart As String) As List(Of PC_Account)

        Dim oList As New List(Of PC_Account)
        Dim sQueryString As String = ""

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            sQueryString = "SELECT * FROM tblaccount WHERE FullName like '%" & NamePart & "%' ORDER BY FullName"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Account

                    oItem.acctNum = Convert.ToInt16(odbcReader("acctNum"))
                    If odbcReader("uName").Equals(DBNull.Value) Then
                        oItem.uName = ""
                    Else
                        oItem.uName = Trim(odbcReader("uName").ToString)
                    End If
                    If odbcReader("passWord").Equals(DBNull.Value) Then
                        oItem.passWord = ""
                    Else
                        oItem.passWord = Trim(odbcReader("passWord").ToString)
                    End If
                    oItem.PermissionLevel = Convert.ToInt16(odbcReader("PermissionLevel"))
                    If odbcReader("FullName").Equals(DBNull.Value) Then
                        oItem.FullName = ""
                    Else
                        oItem.FullName = Trim(odbcReader("FullName").ToString)
                    End If
                    If odbcReader("addDate").Equals(DBNull.Value) Then
                        oItem.addDate = ""
                    Else
                        oItem.addDate = Trim(odbcReader("addDate").ToString)
                    End If

                    oList.Add(oItem)
                End While

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oList

    End Function

#End Region


End Class
