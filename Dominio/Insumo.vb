'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  Insumo.vb
''  Implementation of the Class Insumo
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
Public Class Insumo

    Private _nombre As String
    Private _detalle As String
    Private _cantidadActual As Double
    Private _codInsumo As Long
    Private _tipoInsumo As TipoInsumo
    Private _color As Color
    Private _costo As Double
    Private _movimientosStock As List(Of MovimientosStock)

    Sub New(ByVal cod As Long, ByVal nombre As String, ByVal detalle As String, ByVal cantActual As Double,
             ByVal tipo As TipoInsumo, ByVal color As Color,
            ByVal movimientosStock As List(Of MovimientosStock), ByVal costo As Double)
        Me.nombre = nombre
        Me.detalle = detalle
        Me.cantidadActual = cantActual
        Me.codInsumo = cod
        Me.tipoInsumo = tipo
        Me.color = color
        Me.movimientosStock = movimientosStock
        Me.costo = costo
    End Sub

    Sub New(ByVal id As Long)
        Me.codInsumo = id
    End Sub

    Sub New()

    End Sub

    Public Property cantidadActual() As Double
        Get
            Return _cantidadActual
        End Get
        Set(ByVal Value As Double)
            _cantidadActual = Value
        End Set
    End Property

    Public Property detalle() As String
        Get
            Return _detalle
        End Get
        Set(ByVal Value As String)
            _detalle = Value
        End Set
    End Property

    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal Value As String)
            _nombre = Value
        End Set
    End Property

    Public Property codInsumo() As Long
        Get
            Return _codInsumo
        End Get
        Set(ByVal Value As Long)
            _codInsumo = Value
        End Set
    End Property

    Public Property tipoInsumo() As TipoInsumo
        Get
            Return _tipoInsumo
        End Get
        Set(ByVal Value As TipoInsumo)
            _tipoInsumo = Value
        End Set
    End Property

    Public Property color() As Color
        Get
            Return _color
        End Get
        Set(ByVal Value As Color)
            _color = Value
        End Set
    End Property

    Public Property movimientosStock() As List(Of MovimientosStock)
        Get
            Return _movimientosStock
        End Get
        Set(ByVal value As List(Of MovimientosStock))
            _movimientosStock = value
        End Set
    End Property

    Public Property costo() As Double
        Get
            Return _costo
        End Get
        Set(ByVal value As Double)
            _costo = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.tipoInsumo.descripcion + " - " + Me.color.color
    End Function

    Public ReadOnly Property detalleTipoColor() As String
        Get
            Return Me.tipoInsumo.descripcion + " - " + Me.color.color
        End Get
    End Property

End Class ' Insumo