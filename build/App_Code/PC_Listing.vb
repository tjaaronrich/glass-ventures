Imports Microsoft.VisualBasic

Public Class PC_Listing

#Region "Private Member Variables"
    Private _pID As Integer
    Private _pName As String
    Private _pType As String
    Private _pSleeps As String
    Private _pBedrooms As String
    Private _pBathrooms As String
    Private _pAddress As String
    Private _pLat As String
    Private _pLong As String
    Private _pVRBO As String
    Private _pHomeaway As String
    Private _pDetails As String
    Private _pDescription As String
    Private _pFeatures As String
    Private _pSort As Integer
    Private _ImageFile1 As String
    Private _ImageFile2 As String
    Private _ImageFile3 As String
    Private _ImageFile4 As String
    Private _ImageFile5 As String
    Private _ImageFile6 As String
    Private _Status As String
#End Region

#Region "Constructors"
    Sub New()
        _pID = 0
        _pName = String.Empty
        _pType = String.Empty
        _pSleeps = String.Empty
        _pBedrooms = String.Empty
        _pBathrooms = String.Empty
        _pAddress = String.Empty
        _pLat = String.Empty
        _pLong = String.Empty
        _pVRBO = String.Empty
        _pHomeaway = String.Empty
        _pDetails = String.Empty
        _pDescription = String.Empty
        _pFeatures = String.Empty
        _pSort = 0
        _ImageFile1 = String.Empty
        _ImageFile2 = String.Empty
        _ImageFile3 = String.Empty
        _ImageFile4 = String.Empty
        _ImageFile5 = String.Empty
        _ImageFile6 = String.Empty
        _Status = String.Empty
    End Sub
#End Region

#Region "Public Properties"

    Public Property pID() As Integer
        Get
            Return _pID
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("pID must be greater than or equal to 0")
            Else
                _pID = value
            End If
        End Set
    End Property
    Public Property pName() As String
        Get
            Return _pName
        End Get
        Set(ByVal value As String)
            _pName = value
        End Set
    End Property
    Public Property pType() As String
        Get
            Return _pType
        End Get
        Set(ByVal value As String)
            _pType = value
        End Set
    End Property
    Public Property pSleeps() As String
        Get
            Return _pSleeps
        End Get
        Set(ByVal value As String)
            _pSleeps = value
        End Set
    End Property
    Public Property pBedrooms() As String
        Get
            Return _pBedrooms
        End Get
        Set(ByVal value As String)
            _pBedrooms = value
        End Set
    End Property
    Public Property pBathrooms() As String
        Get
            Return _pBathrooms
        End Get
        Set(ByVal value As String)
            _pBathrooms = value
        End Set
    End Property
    Public Property pAddress() As String
        Get
            Return _pAddress
        End Get
        Set(ByVal value As String)
            _pAddress = value
        End Set
    End Property
    Public Property pLat() As String
        Get
            Return _pLat
        End Get
        Set(ByVal value As String)
            _pLat = value
        End Set
    End Property
    Public Property pLong() As String
        Get
            Return _pLong
        End Get
        Set(ByVal value As String)
            _pLong = value
        End Set
    End Property
    Public Property pVRBO() As String
        Get
            Return _pVRBO
        End Get
        Set(ByVal value As String)
            _pVRBO = value
        End Set
    End Property
    Public Property pHomeaway() As String
        Get
            Return _pHomeaway
        End Get
        Set(ByVal value As String)
            _pHomeaway = value
        End Set
    End Property
    Public Property pDetails() As String
        Get
            Return _pDetails
        End Get
        Set(ByVal value As String)
            _pDetails = value
        End Set
    End Property
    Public Property pDescription() As String
        Get
            Return _pDescription
        End Get
        Set(ByVal value As String)
            _pDescription = value
        End Set
    End Property
    Public Property pFeatures() As String
        Get
            Return _pFeatures
        End Get
        Set(ByVal value As String)
            _pFeatures = value
        End Set
    End Property
    Public Property pSort() As Integer
        Get
            Return _pSort
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("pSort must be greater than or equal to 0")
            Else
                _pSort = value
            End If
        End Set
    End Property
    Public Property ImageFile1() As String
        Get
            Return _ImageFile1
        End Get
        Set(ByVal value As String)
            _ImageFile1 = value
        End Set
    End Property
    Public Property ImageFile2() As String
        Get
            Return _ImageFile2
        End Get
        Set(ByVal value As String)
            _ImageFile2 = value
        End Set
    End Property
    Public Property ImageFile3() As String
        Get
            Return _ImageFile3
        End Get
        Set(ByVal value As String)
            _ImageFile3 = value
        End Set
    End Property
    Public Property ImageFile4() As String
        Get
            Return _ImageFile4
        End Get
        Set(ByVal value As String)
            _ImageFile4 = value
        End Set
    End Property
    Public Property ImageFile5() As String
        Get
            Return _ImageFile5
        End Get
        Set(ByVal value As String)
            _ImageFile5 = value
        End Set
    End Property
    Public Property ImageFile6() As String
        Get
            Return _ImageFile6
        End Get
        Set(ByVal value As String)
            _ImageFile6 = value
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
#End Region

End Class
