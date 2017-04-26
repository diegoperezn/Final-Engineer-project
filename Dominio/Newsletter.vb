<Serializable()>
Public Class Newsletter

    Sub New(ByVal id As String, ByVal nombre As String, ByVal newsletter As String, ByVal enviado As Boolean)
        Me.id = id
        Me.nombre = nombre
        Me.newsletter = newsletter
        Me.enviado = enviado
    End Sub

    Private _id As Long

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Public Property id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property


    Private _newsletter As String
    Public Property newsletter() As String
        Get
            Return _newsletter
        End Get
        Set(ByVal value As String)
            _newsletter = value
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


    Private _enviado As Boolean
    Public Property enviado() As Boolean
        Get
            Return _enviado
        End Get
        Set(ByVal value As Boolean)
            _enviado = value
        End Set
    End Property


End Class
