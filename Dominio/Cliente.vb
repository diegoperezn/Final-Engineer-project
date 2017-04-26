'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  Cliente.vb
''  Implementation of the Class Cliente
''  Generated by Enterprise Architect
''  Created on:      09-ago-2012 11:34:31 p.m.
''  Original author: dperez
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

<Serializable()>
Public Class Cliente
    Inherits Usuario

    Private _idCliente As Long
    Private _habitadoTurnos As Boolean
    Private _dise�o As List(Of Dise�o)
    Private _movimientosCuentaCliente As List(Of MovimientosCuentaCliente)
    Private _pedido As List(Of Pedido)
    Private _factura As List(Of Factura)
    Private _newsletter As Boolean

    Sub New(ByVal id As Long)
        Me.idCliente = id
    End Sub

    Sub New(ByVal id As Long, ByVal ap As String, ByVal mail As String, ByVal nombre As String, ByVal pass As String, ByVal telFijo As String,
            ByVal telMovil As String, ByVal habTurnos As Boolean, ByVal newsletter As Boolean)
        MyBase.New(id, ap, mail, nombre, pass, telFijo, telMovil)
        Me.idCliente = id
        Me.habitadoTurnos = habTurnos
        Me.newsletter = newsletter
    End Sub

    Sub New(ByVal id As Long, ByVal habTurnos As Boolean, ByVal newsletter As Boolean, ByVal dise�o As List(Of Dise�o),
        ByVal movCuenta As List(Of MovimientosCuentaCliente), ByVal pedido As List(Of Pedido), ByVal factura As List(Of Factura))
        Me.idCliente = id
        Me.habitadoTurnos = habTurnos
        Me.dise�o = dise�o
        Me.movimientosCuentaCorriente = movCuenta
        Me.pedido = pedido
        Me.facturas = factura
        Me.newsletter = newsletter
    End Sub

    Sub New()
    End Sub

    Public Property newsletter() As Boolean
        Get
            Return _newsletter
        End Get
        Set(ByVal value As Boolean)
            _newsletter = value
        End Set
    End Property

    Public Property idCliente() As Long
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Long)
            _idCliente = value
        End Set
    End Property

    Public Property facturas() As List(Of Factura)
        Get
            Return _factura
        End Get
        Set(ByVal value As List(Of Factura))
            _factura = value
        End Set
    End Property

    Public Property pedido() As List(Of Pedido)
        Get
            Return _pedido
        End Get
        Set(ByVal value As List(Of Pedido))
            _pedido = value
        End Set
    End Property

    Public Property movimientosCuentaCorriente() As List(Of MovimientosCuentaCliente)
        Get
            Return _movimientosCuentaCliente
        End Get
        Set(ByVal value As List(Of MovimientosCuentaCliente))
            _movimientosCuentaCliente = value
        End Set
    End Property

    Public Property dise�o() As List(Of Dise�o)
        Get
            Return _dise�o
        End Get
        Set(ByVal value As List(Of Dise�o))
            _dise�o = value
        End Set
    End Property

    Public Property habitadoTurnos() As Boolean
        Get
            Return _habitadoTurnos
        End Get
        Set(ByVal Value As Boolean)
            _habitadoTurnos = Value
        End Set
    End Property

    Sub agregarUsuario(ByVal usr As Usuario)
        Me.id = usr.id
        Me.apellido = usr.apellido
        Me.mail = usr.mail
        Me.nombre = usr.nombre
        Me.password = usr.password
        Me.telefonoFijo = usr.telefonoFijo
        Me.telefonoMovil = usr.telefonoMovil
        Me.patentes = usr.patentes
        Me.familias = usr.familias
        Me.bloqueado = usr.bloqueado
    End Sub

End Class ' Cliente
