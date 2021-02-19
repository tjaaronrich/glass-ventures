Imports Microsoft.VisualBasic


Public Class PC_PhotoGallery

#Region "Private Member Variables"
    Private _pgID As Integer
    Private _pgName As String
    Private _pgDefault As String
    Private _pgStatus As String
#End Region

#Region "Constructors"
    Sub New()
        _pgID = 0
        _pgName = String.Empty
        _pgDefault = String.Empty
        _pgStatus = String.Empty
    End Sub
#End Region

#Region "Public Properties"

    Public Property pgID() As Integer
        Get
            Return _pgID
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("pgID must be greater than or equal to 0")
            Else
                _pgID = value
            End If
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
    Public Property pgDefault() As String
        Get
            Return _pgDefault
        End Get
        Set(ByVal value As String)
            _pgDefault = value
        End Set
    End Property
    Public Property pgStatus() As String
        Get
            Return _pgStatus
        End Get
        Set(ByVal value As String)
            _pgStatus = value
        End Set
    End Property

#End Region

End Class
