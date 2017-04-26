<Serializable()>
Public Class Mensaje

    Public Shared ENTRADA As Integer = 0
    Public Shared SALIDA As Integer = 1

    Sub New(ByVal id As Long, ByVal tipoMsj As Integer, ByVal conversacion As Conversacion,
            ByVal fecha As DateTime, ByVal msj As String)
        Me.id = id
        Me.tipoMensaje = tipoMsj
        Me.conversacion = conversacion
        Me.mensaje = msj
        Me.leido = False
        Me.fecha = fecha
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Private _id As Long
    Public Property id() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property

    Private _tipoMensaje As Integer
    Public Property tipoMensaje() As Integer
        Get
            Return _tipoMensaje
        End Get
        Set(ByVal value As Integer)
            _tipoMensaje = value
        End Set
    End Property

    Private _conversacion As Conversacion
    Public Property conversacion() As Conversacion
        Get
            Return _conversacion
        End Get
        Set(ByVal value As Conversacion)
            _conversacion = value
        End Set
    End Property

    Private _mensaje As String
    Public Property mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property

    Private _leido As Boolean
    Public Property leido() As Boolean
        Get
            Return _leido
        End Get
        Set(ByVal value As Boolean)
            _leido = value
        End Set
    End Property

    Private _fecha As DateTime
    Public Property fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Private _borrado As Boolean
    Public Property borrado() As Boolean
        Get
            Return _borrado
        End Get
        Set(ByVal value As Boolean)
            _borrado = value
        End Set
    End Property

End Class
