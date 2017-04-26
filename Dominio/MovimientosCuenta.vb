'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  MovimientosCuenta.vb
''  Implementation of the Class MovimientosCuenta
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
Public Class MovimientosCuenta

    Private _nroMovimiento As Long
    Private _comentario As String
    Private _fecha As DateTime
    Private _monto As Double
    Private _cuenta As Cuenta
    Private _tipoMovimiento As TipoMovimiento
    Private _documento As Documento

    Sub New(ByVal nroMovimiento As Long, ByVal com As String, ByVal fecha As DateTime,
            ByVal monto As Double, ByVal cuenta As Cuenta, ByVal tipo As TipoMovimiento)
        Me.nroMovimiento = nroMovimiento
        Me.comentario = com
        Me.fecha = fecha
        Me.monto = monto
        Me.cuenta = cuenta
        Me.tipoMovimiento = tipo
    End Sub

    Sub New()

    End Sub


    Public Property documento() As Documento
        Get
            Return _documento
        End Get
        Set(ByVal value As Documento)
            _documento = value
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

    Public Property fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal Value As DateTime)
            _fecha = Value
        End Set
    End Property

    Public Property monto() As Double
        Get
            Return _monto
        End Get
        Set(ByVal Value As Double)
            _monto = Value
        End Set
    End Property

    Public Property nroMovimiento() As Long
        Get
            Return _nroMovimiento
        End Get
        Set(ByVal Value As Long)
            _nroMovimiento = Value
        End Set
    End Property

    Public Property cuenta() As Cuenta
        Get
            Return _cuenta
        End Get
        Set(ByVal Value As Cuenta)
            _cuenta = Value
        End Set
    End Property

    Public Property tipoMovimiento() As TipoMovimiento
        Get
            Return _tipoMovimiento
        End Get
        Set(ByVal Value As TipoMovimiento)
            _tipoMovimiento = Value
        End Set
    End Property

End Class ' MovimientosCuenta