Imports Microsoft.VisualBasic


Public Class PC_Gallery

#Region "Private Member Variables"
    Private _photoID As Integer
    Private _photoName As String
    Private _pgName As String
    Private _pgID As Integer
    Private _ImageFile As String
    Private _photoStatus As String
#End Region

#Region "Constructors"
    Sub New()
        _photoID = 0
        _photoName = String.Empty
        _pgID = 0
        _pgName = String.Empty
        _ImageFile = String.Empty
        '_photoStatus = String.Empty
    End Sub
#End Region

#Region "Public Properties"

    Public Property photoID() As Integer
        Get
            Return _photoID
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("photoID must be greater than or equal to 0")
            Else
                _photoID = value
            End If
        End Set
    End Property
    Public Property photoName() As String
        Get
            Return _photoName
        End Get
        Set(ByVal value As String)
            _photoName = value
        End Set
    End Property
    Public Property pgID() As Integer
        Get
            Return _pgID
        End Get
        Set(ByVal value As Integer)
            _pgID = value
        End Set
    End Property
    Public Property pgName() As String
        Get
            Return _pgName
        End Get
        Set(ByVal value As String)
            _pgName = value
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
    Public Property photoStatus() As String
        Get
            Return _photoStatus
        End Get
        Set(ByVal value As String)
            _photoStatus = value
        End Set
    End Property
#End Region

End Class
