Imports Microsoft.VisualBasic

Public Class PC_Testimonials
	
 
#Region "Private Member Variables"
    Private _tNum As Integer
    Private _tDescription As String
    Private _fullName As String
    Private _Title As String
    Private _URL As String
    Private _City As String 
    Private _tSort As String
    Private _Status As String
    Private _sortmax As Integer
    Private _currentsort As Integer
#End Region

#Region "Constructors"
    Sub New()
        _tNum = 0
        _tDescription = String.Empty
        _fullName = String.Empty
        _Title = String.Empty
        _URL = String.Empty
        _City = String.Empty
        _tSort = String.Empty
        _Status = String.Empty
        _sortmax = 0
        _currentsort = 0
    End Sub
#End Region

#Region "Public Properties"
    Public Property tNum() As Integer
        Get
            Return _tNum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("tNum must be greater than or equal to 0")
            Else
                _tNum = value
            End If
        End Set
    End Property
    Public Property tDescription() As String
        Get
            Return _tDescription
        End Get
        Set(ByVal value As String)
            _tDescription = value
        End Set
    End Property
    Public Property fullName() As String
        Get
            Return _fullName
        End Get
        Set(ByVal value As String)
            _fullName = value
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
    Public Property URL() As String
        Get
            Return _URL
        End Get
        Set(ByVal value As String)
            _URL = value
        End Set
    End Property
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            _City = value
        End Set
    End Property
    Public Property tSort() As String
        Get
            Return _tSort
        End Get
        Set(ByVal value As String)
            _tSort = value
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
    Public Property sortmax() As Integer
        Get
            Return _sortmax
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("sortmax must be greater than or equal to 0")
            Else
                _sortmax = value
            End If
        End Set
    End Property
    Public Property currentsort() As Integer
        Get
            Return _currentsort
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("currentsort must be greater than or equal to 0")
            Else
                _currentsort = value
            End If
        End Set
    End Property
#End Region

End Class
