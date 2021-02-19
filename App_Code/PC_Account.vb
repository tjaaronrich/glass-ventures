Imports Microsoft.VisualBasic

Public Class PC_Account

#Region "Private Member Variables"
    Private _acctNum As Integer
    Private _uName As String
    Private _passWord As String
    Private _PermissionLevel As Integer
    Private _fullName As String         'not part of database
    Private _addDate As String
    Private _ImageFile As String
#End Region

#Region "Constructors"
    Sub New()
        _acctNum = 0
        _uName = String.Empty
        _passWord = String.Empty
        _PermissionLevel = 0
        _fullName = String.Empty
        _addDate = String.Empty
        _ImageFile = String.Empty
    End Sub
#End Region

#Region "Public Properties"

    Public Property acctNum() As Integer
        Get
            Return _acctNum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("mlNum must be greater than or equal to 0")
            Else
                _acctNum = value
            End If
        End Set
    End Property
    Public Property uName() As String
        Get
            Return _uName
        End Get
        Set(ByVal value As String)
            _uName = value
        End Set
    End Property
    Public Property passWord() As String
        Get
            Return _passWord
        End Get
        Set(ByVal value As String)
            _passWord = value
        End Set
    End Property
    Public Property PermissionLevel() As Integer
        Get
            Return _PermissionLevel
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("PermissionLevel must be greater than or equal to 0")
            Else
                _PermissionLevel = value
            End If
        End Set
    End Property
    Public Property FullName() As String
        Get
            Return _fullName
        End Get
        Set(ByVal value As String)
            _fullName = value
        End Set
    End Property
    Public Property addDate() As String
        Get
            Return _addDate
        End Get
        Set(ByVal value As String)
            _addDate = value
        End Set
    End Property
    Public Property ImageFile() As String
        Get
            Return _ImageFile
        End Get
        Set(ByVal value As String)
            _ImageFile = value
        End Set
    End Property
#End Region

End Class
