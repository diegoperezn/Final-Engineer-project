'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  MovimientosStock.vb
''  Implementation of the Class MovimientosStock
''  Generated by Enterprise Architect
''  Created on:      09-ago-2012 11:34:35 p.m.
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
Public Class MovimientosStock

    Private _nroMovimiento As Long
    Private _insumo As Insumo
    Private _cantidad As Double
    Private _fecha As DateTime
    Private _tipoMovimiento As TipoMovimiento

    Sub New()

    End Sub

    Sub New(ByVal nroMovimiento As Long, ByVal insumo As Insumo, ByVal cantidad As Double,
            ByVal fecha As Date, ByVal tipoMovimiento As TipoMovimiento)
        Me.nroMovimiento = nroMovimiento
        Me.insumo = insumo
        Me.cantidad = cantidad
        Me.fecha = fecha
        Me.tipoMovimiento = tipoMovimiento
    End Sub

    Public Property nroMovimiento() As Long
        Get
            Return _nroMovimiento
        End Get
        Set(ByVal value As Long)
            _nroMovimiento = value
        End Set
    End Property


    Public Property fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal Value As DateTime)
            _fecha = Value
        End Set
    End Property

    Public Property cantidad() As Double
        Get
            Return _cantidad
        End Get
        Set(ByVal Value As Double)
            _cantidad = Value
        End Set
    End Property

    Public Property insumo() As Insumo
        Get
            Return _insumo
        End Get
        Set(ByVal value As Insumo)
            _insumo = value
        End Set
    End Property

    Public Property tipoMovimiento() As TipoMovimiento
        Get
            Return _tipoMovimiento
        End Get
        Set(ByVal value As TipoMovimiento)
            _tipoMovimiento = value
        End Set
    End Property


End Class ' MovimientosStock