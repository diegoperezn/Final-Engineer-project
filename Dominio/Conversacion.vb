<Serializable()>
Public Class Conversacion

    Sub New(ByVal id As Long, ByVal remitente As Usuario, ByVal destinatario As Usuario, ByVal mensajes As List(Of Mensaje))
        Me.id = id
        Me.remitente = remitente
        Me.destinatario = destinatario
        Me.mensajes = mensajes
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

    Private _remitente As Usuario
    Public Property remitente() As Usuario
        Get
            Return _remitente
        End Get
        Set(ByVal value As Usuario)
            _remitente = value
        End Set
    End Property

    Private _destinatario As Usuario
    Public Property destinatario() As Usuario
        Get
            Return _destinatario
        End Get
        Set(ByVal value As Usuario)
            _destinatario = value
        End Set
    End Property

    Private _mensajes As New List(Of Mensaje)
    Public Property mensajes() As List(Of Mensaje)
        Get
            Return _mensajes
        End Get
        Set(ByVal value As List(Of Mensaje))
            _mensajes = value
        End Set
    End Property

    Public ReadOnly Property mensajesDestinatarioSinLeer() As Integer
        Get
            Dim count As Integer = 0
            For Each msj As Mensaje In mensajes
                If Not msj.leido _
                    AndAlso Mensaje.SALIDA.Equals(msj.tipoMensaje) Then
                    count += 1
                End If
            Next

            Return count
        End Get
    End Property

    Public ReadOnly Property mensajesRemitenteSinLeer() As Integer
        Get
            Dim count As Integer = 0
            For Each msj As Mensaje In mensajes
                If Not msj.leido _
                    AndAlso Mensaje.ENTRADA.Equals(msj.tipoMensaje) Then
                    count += 1
                End If
            Next

            Return count
        End Get
    End Property

End Class
