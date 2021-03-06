'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  HistoricoEstados.vb
''  Implementation of the Class HistoricoEstados
''  Generated by Enterprise Architect
''  Created on:      09-ago-2012 11:34:33 p.m.
''  Original author: Diego
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



Option Explicit On
Option Strict On

<Serializable()>
Public Class HistoricoEstados

    Private _nroEstado As Long
    Private _pedido As Pedido
    Private _comentario As String
    Private _fechaDesde As DateTime
    Private _fechaHasta As DateTime
    Private _estado As EstadoPedido
    Private _borrado As Boolean
    Private _p1 As Object
    Private _p3 As Object
    Private _p4 As Date
    Private _p5 As Object
    Private _estadoTrabajos As EstadoTrabajos

    Sub New()

    End Sub

    Sub New(ByVal nro As Long, ByVal pedido As Pedido, ByVal comentario As String,
            ByVal desde As DateTime, ByVal hasta As DateTime, ByVal estado As EstadoPedido)
        Me.nroEstado = nro
        Me.pedido = pedido
        Me.comentario = comentario
        Me.fechaDesde = desde
        Me.fechaHasta = hasta
        Me.estado = estado
    End Sub

    Sub New(ByVal p1 As Object, ByVal pedido As Dominio.Pedido, ByVal p3 As Object, ByVal p4 As Date, ByVal p5 As Object, ByVal estadoTrabajos As EstadoTrabajos)
        ' TODO: Complete member initialization 
        _p1 = p1
        _pedido = pedido
        _p3 = p3
        _p4 = p4
        _p5 = p5
        _estadoTrabajos = estadoTrabajos
    End Sub

    Public Property borrado() As Boolean
        Get
            Return _borrado
        End Get
        Set(ByVal value As Boolean)
            _borrado = value
        End Set
    End Property

    Public Property fechaDesde() As DateTime
        Get
            Return _fechaDesde
        End Get
        Set(ByVal Value As DateTime)
            _fechaDesde = Value
        End Set
    End Property

    Public Property comentario() As String
        Get
            Return _comentario
        End Get
        Set(ByVal Value As String)
            _comentario = Value
        End Set
    End Property

    Public Property fechaHasta() As DateTime
        Get
            Return _fechaHasta
        End Get
        Set(ByVal Value As DateTime)
            _fechaHasta = Value
        End Set
    End Property

    Public Property pedido() As Pedido
        Get
            Return _pedido
        End Get
        Set(ByVal Value As Pedido)
            _pedido = Value
        End Set
    End Property

    Public Property estado() As EstadoPedido
        Get
            Return _estado
        End Get
        Set(ByVal Value As EstadoPedido)
            _estado = Value
        End Set
    End Property

    Public Property nroEstado() As Long
        Get
            Return _nroEstado
        End Get
        Set(ByVal Value As Long)
            _nroEstado = Value
        End Set
    End Property

End Class ' HistoricoEstados