Imports Microsoft.VisualBasic



Public Class PC_Calendar

#Region "Private Member Variables"
    Private _cNum As Integer
    Private _Title As String
    Private _StartDate As String
    Private _EndDate As String
    Private _StartTime As String
    Private _EndTime As String
    Private _AllDay As String
    Private _Repeats As Integer
    Private _ContactNumber As String
    Private _Location As String
    Private _Description As String
    Private _Category As String
    Private _fileName As String
	Private _ImageFile As String
    Private _Status As String
    Private _StartDateDisplay As String
    Private _EndDateDisplay As String
	Private _Website As String
	Private _EmailAddress As String
	Private _Address As String
#End Region

#Region "Constructors"
    Sub New()
        _cNum = 0
        _Title = String.Empty
        _StartDate = String.Empty
        _EndDate = String.Empty
        _StartTime = String.Empty
        _EndTime = String.Empty
        _AllDay = String.Empty
        _Repeats = 0
        _ContactNumber = String.Empty
        _Location = String.Empty
        _Description = String.Empty
        _Category = String.Empty
        _fileName = String.Empty
		_ImageFile = String.Empty
        _Status = String.Empty
        _StartDateDisplay = String.Empty
        _EndDateDisplay = String.Empty
		_Website = String.Empty
		_EmailAddress = String.Empty
		_Address = String.Empty
    End Sub
#End Region

#Region "Public Properties"
    Public Property cNum() As Integer
        Get
            Return _cNum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("cNum must be greater than or equal to 0")
            Else
                _cNum = value
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
    Public Property StartDate() As String
        Get
            Return _StartDate
        End Get
        Set(ByVal value As String)
            _StartDate = value
        End Set
    End Property
    Public Property EndDate() As String
        Get
            Return _EndDate
        End Get
        Set(ByVal value As String)
            _EndDate = value
        End Set
    End Property
    Public Property StartTime() As String
        Get
            Return _StartTime
        End Get
        Set(ByVal value As String)
            _StartTime = value
        End Set
    End Property
    Public Property EndTime() As String
        Get
            Return _EndTime
        End Get
        Set(ByVal value As String)
            _EndTime = value
        End Set
    End Property
    Public Property AllDay() As String
        Get
            Return _AllDay
        End Get
        Set(ByVal value As String)
            _AllDay = value
        End Set
    End Property
    Public Property Repeats() As Integer
        Get
            Return _Repeats
        End Get
        Set(ByVal value As Integer)
            _Repeats = value
        End Set
    End Property
    Public Property ContactNumber() As String
        Get
            Return _ContactNumber
        End Get
        Set(ByVal value As String)
            _ContactNumber = value
        End Set
    End Property
    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
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
    Public Property fileName() As String
        Get
            Return _fileName
        End Get
        Set(ByVal value As String)
            _fileName = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property StartDateDisplay() As String
        Get
            Return _StartDateDisplay
        End Get
        Set(ByVal value As String)
            _StartDateDisplay = value
        End Set
    End Property
    Public Property EndDateDisplay() As String
        Get
            Return _EndDateDisplay
        End Get
        Set(ByVal value As String)
            _EndDateDisplay = value
        End Set
    End Property
	Public Property Website() As String
        Get
			Return _Website
        End Get
        Set(ByVal value As String)
			_Website = value
        End Set
    End Property
	Public Property EmailAddress() As String
        Get
			Return _EmailAddress
        End Get
        Set(ByVal value As String)
			_EmailAddress = value
        End Set
    End Property
	Public Property Address() As String
        Get
			Return _Address
        End Get
        Set(ByVal value As String)
			_Address = value
        End Set
    End Property


#End Region

End Class
