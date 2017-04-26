'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  ListaPrecios.vb
''  Implementation of the Class ListaPrecios
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
Public Class ListaPrecios

    Private _nroLista As Long
    Private _fechaDesde As DateTime
    Private _fechaHasta As DateTime
    Private _precio As Double
    Private _articulo As Articulo
    Private _borrado As Boolean

    Sub New(ByVal nro As Long, ByVal fdesde As Date, ByVal fHasta As Date,
            ByVal precio As Double, ByVal art As Articulo, ByVal borrado As Boolean)
        Me.nroLista = nro
        Me.fechaDesde = fdesde
        Me.fechaHasta = fHasta
        Me.precio = precio
        Me.articulo = art
        Me.borrado = borrado
    End Sub

    Sub New()

    End Sub

    Public Property fechaDesde() As DateTime
        Get
            Return _fechaDesde
        End Get
        Set(ByVal Value As DateTime)
            _fechaDesde = Value
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

    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal Value As Double)
            _precio = Value
        End Set
    End Property

    Public Property nroLista() As Long
        Get
            Return _nroLista
        End Get
        Set(ByVal Value As Long)
            _nroLista = Value
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

    Public Property borrado() As Boolean
        Get
            Return _borrado
        End Get
        Set(ByVal value As Boolean)
            _borrado = value
        End Set
    End Property

End Class ' ListaPrecios