Imports Microsoft.VisualBasic

Public Class PC_NewsFTB

#Region "Private Member Variables"
    Private _nNum As Integer
    Private _Title As String
    Private _Category As String
    Private _Summary As String
    Private _Author As String
    Private _ItemDate As String
    Private _pageName As String     'needed in this scenario????
    Private _content As String
    Private _Featured As String
    Private _VisibleDate As String
    Private _ExpiresDate As String
    Private _Keywords As String
	Private _guid As String
    Private _Status As String
    Private _ImageFile As String
#End Region

#Region "Constructors"
    Sub New()
        _nNum = 0
        _Title = String.Empty
        _Category = String.Empty
        _Summary = String.Empty
        _Author = String.Empty
        _ItemDate = String.Empty
        _pageName = String.Empty
        _content = String.Empty
        _Featured = String.Empty
        _VisibleDate = String.Empty
        _ExpiresDate = String.Empty
        _Keywords = String.Empty
		_guid = String.Empty
        _Status = String.Empty
        _ImageFile = String.Empty
    End Sub
#End Region

#Region "Public Properties"
    Public Property nNum() As Integer
        Get
            Return _nNum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("nNum must be greater than or equal to 0")
            Else
                _nNum = value
            End If
        End Set
    End Property
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property
    Public Property Category() As String
        Get
            Return _Category
        End Get
        Set(ByVal value As String)
            _Category = value
        End Set
    End Property
    Public Property Summary() As String
        Get
            Return _Summary
        End Get
        Set(ByVal value As String)
            _Summary = value
        End Set
    End Property
    Public Property Author() As String
        Get
            Return _Author
        End Get
        Set(ByVal value As String)
            _Author = value
        End Set
    End Property
    Public Property ItemDate() As String
        Get
            Return _ItemDate
        End Get
        Set(ByVal value As String)
            _ItemDate = value
        End Set
    End Property
    Public Property pageName() As String
        Get
            Return _pageName
        End Get
        Set(ByVal value As String)
            _pageName = value
        End Set
    End Property
    Public Property content() As String
        Get
            Return _content
        End Get
        Set(ByVal value As String)
            _content = value
        End Set
    End Property
    Public Property Featured() As String
        Get
            Return _Featured
        End Get
        Set(ByVal value As String)
            _Featured = value
        End Set
    End Property
    Public Property VisibleDate() As String
        Get
            Return _VisibleDate
        End Get
        Set(ByVal value As String)
            _VisibleDate = value
        End Set
    End Property
    Public Property ExpiresDate() As String
        Get
            Return _ExpiresDate
        End Get
        Set(ByVal value As String)
            _ExpiresDate = value
        End Set
    End Property
    Public Property Keywords() As String
        Get
            Return _Keywords
        End Get
        Set(ByVal value As String)
            _Keywords = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
	Public Property guid() As String
        Get
            Return _guid
        End Get
        Set(ByVal value As String)
            _guid = value
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
