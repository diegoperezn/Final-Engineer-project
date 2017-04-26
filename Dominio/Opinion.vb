<Serializable()>
Public Class Opinion

    Sub New(ByVal id As Long, ByVal nombre As String, ByVal mail As String, ByVal opinion As String)
        Me.id = id
        Me.nombre = nombre
        Me.mail = mail
        Me.opinion = opinion
    End Sub

    Private _opinion As String

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Public Property opinion() As String
        Get
            Return _opinion
        End Get
        Set(ByVal value As String)
            _opinion = value
        End Set
    End Property


    Private _mail As String
    Public Property mail() As String
        Get
            Return _mail
        End Get
        Set(ByVal value As String)
            _mail = value
        End Set
    End Property


    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property


    Private _id As Long
    Public Property id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property


End Class
