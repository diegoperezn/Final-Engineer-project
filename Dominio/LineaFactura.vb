'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  LineaFactura.vb
''  Implementation of the Class LineaFactura
''  Generated by Enterprise Architect
''  Created on:      09-ago-2012 11:34:34 p.m.
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
Public Class LineaFactura

    Private _nroLinea As Long
    Private _articulo As Articulo
    Private _cantidad As Integer
    Private _precio As Double
    Private _factura As Factura
    Private _borrado As Boolean

    Sub New(ByVal nroLinea As Long, ByVal art As Articulo, ByVal cant As Integer,
            ByVal precio As Double, ByVal fac As Factura, ByVal borrado As Boolean)
        Me.nroLinea = nroLinea
        Me.articulo = art
        Me.cantidad = cant
        If precio = Double.Parse("0") Then
            Me.precio = art.precioActual
        Else
            Me.precio = precio
        End If
        Me.factura = fac
        Me.borrado = borrado
    End Sub

    Sub New()

    End Sub


    Public Property nroLinea() As Long
        Get
            Return _nroLinea
        End Get
        Set(ByVal Value As Long)
            _nroLinea = Value
        End Set
    End Property

    Public Property articulo() As Articulo
        Get
            Return _articulo
        End Get
        Set(ByVal Value As Articulo)
            _articulo = Value
        End Set
    End Property

    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal Value As Integer)
            _cantidad = Value
        End Set
    End Property

    Public Property factura() As Factura
        Get
            Return _factura
        End Get
        Set(ByVal Value As Factura)
            _factura = Value
        End Set
    End Property

    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal Value As Double)
            _precio = Value
        End Set
    End Property

    Public Property borrado() As Boolean
        Get
            Return _borrado
        End Get
        Set(ByVal value As Boolean)
            _borrado = value
        End Set
    End Property

End Class ' LineaFactura