Imports Microsoft.VisualBasic

Public Class PC_FAQs

#Region "Private Member Variables"
    Private _fNum As Integer
    Private _fSort As String
    Private _question As String
    Private _answer As String
    Private _Status As String
    Private _sortmax As Integer
    Private _currentsort As Integer
#End Region

#Region "Constructors"
    Sub New()
        _fNum = 0
        _fSort = String.Empty
        _question = String.Empty
        _answer = String.Empty
        _Status = String.Empty
        _sortmax = 0
        _currentsort = 0
    End Sub
#End Region

#Region "Public Properties"
    Public Property fNum() As Integer
        Get
            Return _fNum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("fNum must be greater than or equal to 0")
            Else
                _fNum = value
            End If
        End Set
    End Property
    Public Property fSort() As String
        Get
            Return _fSort
        End Get
        Set(ByVal value As String)
            _fSort = value
        End Set
    End Property
    Public Property question() As String
        Get
            Return _question
        End Get
        Set(ByVal value As String)
            _question = value
        End Set
    End Property
    Public Property answer() As String
        Get
            Return _answer
        End Get
        Set(ByVal value As String)
            _answer = value
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
