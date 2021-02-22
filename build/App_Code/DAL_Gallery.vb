Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Collections.Generic



Public Class DAL_Gallery

    Public Shared Function FileNameExists(ByVal fn As String) As Integer

        Dim fnCount As Integer = 0

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT count(*) as FileCount FROM tblgallery WHERE ImageFile = '" & fn & "'"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    fnCount = Convert.ToInt16(odbcReader("FileCount"))
                End If

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()
                Return 1

            End Try

            odbcConn.Close()

        Catch ex As Exception
            Return 1
        End Try

        If fnCount < 1 Then
            Return 0    'does not exist
        Else
            Return 1    'exists
        End If

    End Function

    Public Shared Function AddPhoto(ByVal Name As String, ByVal FileName As String, ByVal pgID As Integer, ByVal pgName As String, ByVal Status As String) As Integer

        Dim iResult As Integer = 0

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try

            Dim sQueryString As String = "INSERT INTO tblgallery " & _
            "(Name, " & _
            "ImageFile, " & _
            "pgID, " & _
            "pgName, " & _
            "status)" & _
            " VALUES " & _
            "('" & Name & _
            "', '" & FileName & _
            "', " & pgID & _
            ", '" & pgName & _
            "', '" & Status & "')"

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            iResult = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            iResult = 0

        End Try

        Return iResult

    End Function
    Public Shared Function ModifyPhoto(ByVal photoID As Integer, ByVal photoName As String, ByVal pgID As Integer, ByVal pgName As String, ByVal photoStatus As String) As Integer
        'used by admin only

        Dim iResult As Integer = 0
        Dim sQueryString As String

        If photoStatus <> "Inactive" Then
            photoStatus = "Active"
        End If

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tblgallery SET " & _
                "Name = '" & photoName & "', " & _
                "pgID = " & pgID & ", " & _
                "pgName = '" & pgName & "', " & _
                "Status = '" & photoStatus & "' " & _
                "WHERE photoID = " & photoID

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            iResult = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            iResult = 0

        End Try

        Return iResult

    End Function

    Public Shared Function DeletePhoto(ByVal photoID As Integer) As Integer
        'used by admin only

        Dim iResult As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            'if deleting a pet, physically delete the record
            sQueryString = "DELETE FROM tblgallery WHERE photoID = " & photoID

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            iResult = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            iResult = 0

        End Try

        Return iResult

    End Function

    Public Shared Function GetApprovedImageList() As List(Of PC_Gallery)

        Dim oList As New List(Of PC_Gallery)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblgallery ORDER BY pgName, photoID"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Gallery

                    oItem.photoID = Convert.ToInt16(odbcReader("photoID"))

                    If odbcReader("Name").Equals(DBNull.Value) Then
                        oItem.photoName = ""
                    Else
                        oItem.photoName = Trim(odbcReader("Name").ToString)
                    End If

                    'oItem.ImageFile = "Documents/Gallery/" & Trim(odbcReader("ImageFile").ToString)

                    If odbcReader("pgName").Equals(DBNull.Value) Then
                        oItem.pgName = ""
                    Else
                        oItem.pgName = Trim(odbcReader("pgName").ToString)
                    End If
                    oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    oItem.photoStatus = Trim(odbcReader("Status").ToString)

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

    Public Shared Function GetActiveGalleryLast11() As List(Of PC_Gallery)

        Dim oList As New List(Of PC_Gallery)
        Dim counter As Integer = 0

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblgallery ORDER BY photoID"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    If counter < 11 Then
                        Dim oItem As New PC_Gallery

                        oItem.photoID = Convert.ToInt16(odbcReader("photoID"))

                        If odbcReader("Name").Equals(DBNull.Value) Then
                            oItem.photoName = ""
                        Else
                            oItem.photoName = Trim(odbcReader("Name").ToString)
                        End If
                        If odbcReader("pgName").Equals(DBNull.Value) Then
                            oItem.pgName = ""
                        Else
                            oItem.pgName = Trim(odbcReader("pgName").ToString)
                        End If

                        'oItem.ImageFile = "Documents/Gallery/" & Trim(odbcReader("ImageFile").ToString)
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                        oItem.photoStatus = Trim(odbcReader("Status").ToString)

                        oList.Add(oItem)
                        counter = counter + 1
                    End If
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

    Public Shared Function GetActiveImageList() As List(Of PC_Gallery)

        Dim oList As New List(Of PC_Gallery)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblgallery WHERE Status = 'Active' ORDER BY photoID"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Gallery

                    oItem.photoID = Convert.ToInt16(odbcReader("photoID"))

                    If odbcReader("Name").Equals(DBNull.Value) Then
                        oItem.photoName = ""
                    Else
                        oItem.photoName = Trim(odbcReader("Name").ToString)
                    End If
                    If odbcReader("pgName").Equals(DBNull.Value) Then
                        oItem.pgName = ""
                    Else
                        oItem.pgName = Trim(odbcReader("pgName").ToString)
                    End If

                    'oItem.ImageFile = "Documents/Gallery/" & Trim(odbcReader("ImageFile").ToString)
                    oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    oItem.photoStatus = Trim(odbcReader("Status").ToString)

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
	
	Public Shared Function GetImageGalleryList2() As List(Of PC_Gallery)
 
        Dim oList As New List(Of PC_Gallery)

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblgallery WHERE Status = 'Active' ORDER BY photoID"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_Gallery

                    oItem.photoID = Convert.ToInt16(odbcReader("photoID"))

                    If odbcReader("Name").Equals(DBNull.Value) Then
                        oItem.photoName = ""
                    Else
                        oItem.photoName = Trim(odbcReader("Name").ToString)
                    End If
                    If odbcReader("pgName").Equals(DBNull.Value) Then
                        oItem.pgName = ""
                    Else
                        oItem.pgName = Trim(odbcReader("pgName").ToString)
                    End If

                    'oItem.ImageFile = "Documents/Gallery/" & Trim(odbcReader("ImageFile").ToString)
                    oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    oItem.photoStatus = Trim(odbcReader("Status").ToString)

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
	
	Public Shared Function GetImageGalleryList() As List(Of PC_Gallery)

        Dim oList As New List(Of PC_Gallery)
        Dim counter As Integer = 0

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblgallery WHERE Status = 'Active' ORDER BY photoID"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    If counter < 1 Then
                        Dim oItem As New PC_Gallery

                        oItem.photoID = Convert.ToInt16(odbcReader("photoID"))

                        If odbcReader("Name").Equals(DBNull.Value) Then
                            oItem.photoName = ""
                        Else
                            oItem.photoName = Trim(odbcReader("Name").ToString)
                        End If
                        If odbcReader("pgName").Equals(DBNull.Value) Then
                            oItem.pgName = ""
                        Else
                            oItem.pgName = Trim(odbcReader("pgName").ToString)
                        End If

                        'oItem.ImageFile = "Documents/Gallery/" & Trim(odbcReader("ImageFile").ToString)
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                        oItem.photoStatus = Trim(odbcReader("Status").ToString)

                        oList.Add(oItem)
                        counter = counter + 1
                    End If
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

    Public Shared Function GetImageInfoByID(ByVal photoID As Integer) As PC_Gallery

        Dim oItem As New PC_Gallery

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblgallery WHERE photoID = " & photoID
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.photoID = Convert.ToInt32(odbcReader("photoID"))

                    If odbcReader("Name").Equals(DBNull.Value) Then
                        oItem.photoName = ""
                    Else
                        oItem.photoName = Trim(odbcReader("Name").ToString)
                    End If

                    oItem.pgID = Convert.ToInt32(odbcReader("pgID"))

                    If odbcReader("pgName").Equals(DBNull.Value) Then
                        oItem.pgName = ""
                    Else
                        oItem.pgName = Trim(odbcReader("pgName").ToString)
                    End If

                    If odbcReader("ImageFile").Equals(DBNull.Value) Then
                        oItem.ImageFile = ""
                    Else
                        oItem.ImageFile = Trim(odbcReader("ImageFile").ToString)
                    End If


                    If odbcReader("status").Equals(DBNull.Value) Then
                        oItem.photoStatus = ""
                    Else
                        oItem.photoStatus = Trim(odbcReader("status").ToString)
                    End If
                End If

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oItem

    End Function

#Region "PhotoGallery"

    Public Shared Function GalleryNameExists(ByVal gn As String) As Integer

        Dim gnCount As Integer = 0

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT count(*) as NameCount FROM tblphotogallery WHERE pgName = '" & gn & "'"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    gnCount = Convert.ToInt16(odbcReader("NameCount"))
                End If

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()
                Return 1

            End Try

            odbcConn.Close()

        Catch ex As Exception
            Return 1
        End Try

        If gnCount < 1 Then
            Return 0    'does not exist
        Else
            Return 1    'exists
        End If

    End Function

    Public Shared Function AddPhotoGallery(ByVal Name As String, ByVal IsDefault As String, ByVal Status As String) As Integer

        Dim iResult As Integer = 0

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try

            Dim sQueryString As String = "INSERT INTO tblphotogallery " & _
            "(pgName, " & _
            "pgDefault, " & _
            "pgStatus)" & _
            " VALUES " & _
            "('" & Name & _
            "', '" & IsDefault & _
            "', '" & Status & "')"

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            iResult = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            iResult = 0

        End Try

        Return iResult

    End Function

    Public Shared Function ModifyPhotoGallery(ByVal pgID As Integer, ByVal pgName As String, ByVal pgDefault As String, ByVal pgStatus As String) As Integer
        'used by admin only - can mod gallery name or status only

        Dim iResult As Integer = 0
        Dim Rslt2 As Integer = 0
        Dim sQueryString As String

        If pgStatus <> "Inactive" Then
            pgStatus = "Active"
        End If

        If Len(pgDefault) < 2 Then
            pgDefault = "NO"
        End If

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tblphotogallery SET " & _
                "pgName = '" & pgName & "', " & _
                "pgDefault = '" & pgDefault & "', " & _
                "pgStatus = '" & pgStatus & "' " & _
                "WHERE pgID = " & pgID

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            iResult = 1

            'Rslt2 = ModifyGalleryNameInPhotoTable(pgID, pgName)

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            iResult = 0

        End Try

        Return iResult

    End Function

    Public Shared Function ModifyGalleryNameInPhotoTable(ByVal pgID As Integer, ByVal pgName As String) As Integer
        'used by admin only

        Dim iResult As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            sQueryString = "UPDATE tblgallery SET pgName = '" & pgName & "' WHERE pgID = " & pgID.ToString

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            iResult = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            iResult = 0

        End Try

        Return iResult

    End Function

    Public Shared Function GetActiveGalleryList() As List(Of PC_PhotoGallery)

        Dim oList As New List(Of PC_PhotoGallery)
        Dim counter As Integer = 0

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblphotogallery where pgStatus = 'Active' ORDER BY pgName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                While odbcReader.Read()
                    Dim oItem As New PC_PhotoGallery

                    oItem.pgID = Convert.ToInt16(odbcReader("pgID"))

                    If odbcReader("pgName").Equals(DBNull.Value) Then
                        oItem.pgName = ""
                    Else
                        oItem.pgName = Trim(odbcReader("pgName").ToString)
                    End If

                    oList.Add(oItem)

                    counter = counter + 1
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

    Public Shared Function GetGalleryList() As List(Of PC_PhotoGallery)

        Dim oList As New List(Of PC_PhotoGallery)
        Dim counter As Integer = 0

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblphotogallery ORDER BY pgName ASC"
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try

                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                'add initial item in list - Please Select One
                Dim oItemI As New PC_PhotoGallery

                oItemI.pgID = 0
                oItemI.pgName = "Select One"

                oList.Add(oItemI)

                While odbcReader.Read()
                    Dim oItem As New PC_PhotoGallery

                    oItem.pgID = Convert.ToInt16(odbcReader("pgID"))

                    If odbcReader("pgName").Equals(DBNull.Value) Then
                        oItem.pgName = ""
                    Else
                        oItem.pgName = Trim(odbcReader("pgName").ToString)
                    End If

                    oList.Add(oItem)

                    counter = counter + 1
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

    Public Shared Function GetGalleryByID(ByVal pgID As String) As PC_PhotoGallery

        Dim oItem As New PC_PhotoGallery

        Try
            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)
            Dim sQueryString As String = "SELECT * FROM tblphotogallery WHERE pgID = " & pgID
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            odbcConn.Open()

            Try
                Dim odbcReader As OdbcDataReader = DBCommand.ExecuteReader(CommandBehavior.CloseConnection)

                If odbcReader.HasRows Then
                    odbcReader.Read()

                    oItem.pgID = Convert.ToInt16(odbcReader("pgID"))

                    If odbcReader("pgName").Equals(DBNull.Value) Then
                        oItem.pgName = ""
                    Else
                        oItem.pgName = Trim(odbcReader("pgName").ToString)
                    End If

                    oItem.pgStatus = Trim(odbcReader("pgStatus").ToString)
                End If

                odbcReader.Close()

            Catch ex As Exception

                odbcConn.Close()

            End Try

            odbcConn.Close()

        Catch ex As Exception

        End Try

        Return oItem

    End Function

    Public Shared Function DeletePhotoGallery(ByVal pgID As Integer, ByVal pgName As String) As Integer
        'used by admin only

        'two steps - first delete all photos associations (NOT the photos, as they may be in other galleries) for this gallery, from tblphotogalleryphotos
        'then delete the gallery

        Dim iRslt As Integer = 0

        iRslt = DeletePhotoGalleryAssociations(pgName)

        If iRslt = 1 Then

            Dim iResult As Integer = 0
            Dim sQueryString As String

            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

            Try
                'if deleting a pet, physically delete the record
                sQueryString = "DELETE FROM tblphotogallery WHERE pgID = " & pgID

                odbcConn.Open()
                Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
                DBCommand.ExecuteNonQuery()

                iResult = 1

                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                odbcConn.Dispose()

                iResult = 0

            End Try

            Return iResult

        Else
            Return iRslt
        End If

    End Function

    Public Shared Function DeletePhotoGalleryAssociations(ByVal pgName As String) As Integer
        'used by admin only

        'two steps - first delete all photos associations (NOT the photos, as they may be in other galleries) for this gallery, from tblphotogalleryphotos
        'then delete the gallery

        Dim iResult As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            'if deleting, physically delete the record
            sQueryString = "DELETE FROM tblgallery WHERE pgName = '" & pgName & "'"

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            iResult = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            iResult = 0

        End Try

        Return iResult

    End Function

    Public Shared Function ArchivePhotoGallery(ByVal pgID As String, ByVal pgName As String) As Integer
        'used by admin only

        'two steps - first delete all photos associations (NOT the photos, as they may be in other galleries) for this gallery, from tblphotogalleryphotos
        'then delete the gallery

        Dim iRslt As Integer = 0

        iRslt = ArchivePhotoGalleryAssociations(pgName)

        If iRslt = 1 Then

            Dim iResult As Integer = 0
            Dim sQueryString As String

            Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
            Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

            Try
                'if deleting a pet, physically delete the record
                sQueryString = "UPDATE tblphotogallery SET pgStatus = 'Inactive' WHERE pgID = " & pgID

                odbcConn.Open()
                Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
                DBCommand.ExecuteNonQuery()

                iResult = 1

                odbcConn.Close()

            Catch ex As Exception

                odbcConn.Close()
                odbcConn.Dispose()

                iResult = 0

            End Try

            Return iResult

        Else
            Return iRslt
        End If

    End Function

    Public Shared Function ArchivePhotoGalleryAssociations(ByVal pgName As String) As Integer
        'used by admin only

        'two steps - first delete all photos associations (NOT the photos, as they may be in other galleries) for this gallery, from tblphotogalleryphotos
        'then delete the gallery

        Dim iResult As Integer = 0
        Dim sQueryString As String

        Dim sConnString As String = ConfigurationManager.ConnectionStrings("WebApp").ConnectionString
        Dim odbcConn As OdbcConnection = New OdbcConnection(sConnString)

        Try
            'if deleting, physically delete the record
            sQueryString = "UPDATE tblgallery SET status = 'Inactive' WHERE pgName = '" & pgName & "'"

            odbcConn.Open()
            Dim DBCommand As New OdbcCommand(sQueryString, odbcConn)
            DBCommand.ExecuteNonQuery()

            iResult = 1

            odbcConn.Close()

        Catch ex As Exception

            odbcConn.Close()
            odbcConn.Dispose()

            iResult = 0

        End Try

        Return iResult

    End Function


#End Region


End Class
