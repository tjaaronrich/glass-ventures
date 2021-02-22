Imports Microsoft.VisualBasic

Public Class PC_Pages

#Region "Private Member Variables"
	Private _ftbNum As Integer
	Private _pageName As String
	Private _HeaderImage As String
	Private _HeaderImageText As String
	Private _title As String
	Private _meta_title As String
	Private _description As String
	Private _keywords As String
    Private _content As String
	Private _guid As String
#End Region

#Region "Constructors"
    Sub New()
		_ftbNum = 0
		_pageName = String.Empty
		_HeaderImage = String.Empty
		_HeaderImageText = String.Empty
		_title = String.Empty
		_meta_title = String.Empty
		_description = String.Empty
		_keywords = String.Empty
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
	Public Property pageName() As String
        Get
            Return _pageName
        End Get
        Set(ByVal value As String)
            _pageName = value
        End Set
    End Property
	Public Property HeaderImage() As String
        Get
            Return _HeaderImage
        End Get
        Set(ByVal value As String)
            _HeaderImage = value
        End Set
    End Property
	Public Property HeaderImageText() As String
        Get
            Return _HeaderImageText
        End Get
        Set(ByVal value As String)
            _HeaderImageText = value
        End Set
    End Property
	Public Property title() As String
        Get
			Return _title
        End Get
        Set(ByVal value As String)
			_title = value
        End Set
    End Property
Public Property meta_title() As String
        Get
			Return _meta_title
        End Get
        Set(ByVal value As String)
			_meta_title = value
        End Set
    End Property
	Public Property description() As String
        Get
			Return _description
        End Get
        Set(ByVal value As String)
			_description = value
        End Set
    End Property
	Public Property keywords() As String
        Get
			Return _keywords
        End Get
        Set(ByVal value As String)
			_keywords = value
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
