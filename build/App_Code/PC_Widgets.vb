Imports Microsoft.VisualBasic

Public Class PC_Widgets

#Region "Private Member Variables"
	Private _ftbNum As Integer
	Private _widgetName As String
    Private _content As String
	Private _guid As String
#End Region

#Region "Constructors"
    Sub New()
		_ftbNum = 0
		_widgetName = String.Empty
        _content = String.Empty
		_guid = String.Empty
    End Sub
#End Region

#Region "Public Properties"

Public Property ftbNum() As Integer
        Get
            Return _ftbNum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New ArgumentException("ftbNum must be greater than or equal to 0")
            Else
                _ftbNum = value
            End If
        End Set
    End Property
	Public Property widgetName() As String
        Get
            Return _widgetName
        End Get
        Set(ByVal value As String)
            _widgetName = value
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
	Public Property guid() As String
        Get
            Return _guid
        End Get
        Set(ByVal value As String)
            _guid = value
        End Set
    End Property
#End Region

End Class
