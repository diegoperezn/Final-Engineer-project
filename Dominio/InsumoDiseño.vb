<Serializable()>
Public Class DiseñoInsumo

    Sub New()

    End Sub

    Sub New(ByVal insumo As Insumo)
        Me.insumo = insumo
    End Sub

    Sub New(ByVal diseño As Diseño, ByVal insumo As Insumo, ByVal cant As Double)
        Me.diseño = diseño
        Me.insumo = insumo
        Me.cantidad = cant
    End Sub

    Private _diseño As Diseño
    Public Property diseño() As Diseño
        Get
            Return _diseño
        End Get
        Set(ByVal value As Diseño)
            _diseño = value
        End Set
    End Property

    Private _insumo As Insumo
    Public Property insumo() As Insumo
        Get
            Return _insumo
        End Get
        Set(ByVal value As Insumo)
            _insumo = value
        End Set
    End Property

    Private _cantidad As Double
    Public Property cantidad() As Double
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Double)
            _cantidad = value
        End Set
    End Property

End Class
