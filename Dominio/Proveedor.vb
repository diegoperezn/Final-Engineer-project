'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  Proveedor.vb
''  Implementation of the Class Proveedor
''  Generated by Enterprise Architect
''  Created on:      09-ago-2012 11:34:36 p.m.
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
Public Class Proveedor

    Private _codProveedor As Long
    Private _nombre As String
    Private _telefono As String
    Private _direccion As String
    Private _ordenesDeCompra As New List(Of OrdenDeCompra)

    Sub New()

    End Sub

    Sub New(ByVal codProv As Long, ByVal nombre As String, ByVal tel As String, ByVal dir As String, ByVal ordenes As List(Of OrdenDeCompra))
        Me.codProveedor = codProv
        Me.nombre = nombre
        Me.telefono = tel
        Me.direccion = dir
        If Not ordenes Is Nothing Then
            Me.ordenesDeCompra = ordenes
        End If
    End Sub

    Sub New(ByVal cod As Long)
        codProveedor = cod
    End Sub

    Public Property codProveedor() As Long
        Get
            Return _codProveedor
        End Get
        Set(ByVal Value As Long)
            _codProveedor = Value
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

    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal Value As String)
            _telefono = Value
        End Set
    End Property

    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal Value As String)
            _direccion = Value
        End Set
    End Property

    Public Property ordenesDeCompra() As List(Of OrdenDeCompra)
        Get
            Return _ordenesDeCompra
        End Get
        Set(ByVal Value As List(Of OrdenDeCompra))
            _ordenesDeCompra = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.nombre
    End Function

End Class ' Proveedor