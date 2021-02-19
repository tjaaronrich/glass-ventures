Imports Microsoft.VisualBasic

Public Class PC_Links
#Region "Private Member Variables"
    Private _linkNum As Integer
    Private _linkName As String
    Private _linkCategory As String
    Private _URL As String
    Private _linkDescription As String
    Private _linkSort As String
#End Region 

#Region "Constructors"
    Sub New()
        _linkNum = 0
        _linkName = String.Empty
        _linkCategory = String.Empty
        _URL = String.Empty
        _linkDescription = String.Empty
        _linkSort = String.Empty
    End Sub
#End Region

#Region "Public Properties"
    Public Property linkNum() As Integer
        Get
            Return _linkNum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("linkNum must be greater than or equal to 0")
            Else
                _linkNum = value
            End If
        End Set
    End Property
    Public Property linkName() As String
        Get
            Return _linkName
        End Get
        Set(ByVal value As String)
            _linkName = value
        End Set
    End Property
    Public Property linkCategory() As String
        Get
            Return _linkCategory
        End Get
        Set(ByVal value As String)
            _linkCategory = value
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
    Public Property linkDescription() As String
        Get
            Return _linkDescription
        End Get
        Set(ByVal value As String)
            _linkDescription = value
        End Set
    End Property
    Public Property linkSort() As String
        Get
            Return _linkSort
        End Get
        Set(ByVal value As String)
            _linkSort = value
        End Set
    End Property
#End Region
End Class
