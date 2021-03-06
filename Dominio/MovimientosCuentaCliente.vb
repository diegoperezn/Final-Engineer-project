'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  MovimientosCuentaCliente.vb
''  Implementation of the Class MovimientosCuentaCliente
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
Public Class MovimientosCuentaCliente
    Inherits MovimientosCuenta

    Private _cliente As Cliente

    Sub New(ByVal cod As Long)
        Me.nroMovimiento = cod

    End Sub

    Sub New(ByVal nroMovimiento As Long, ByVal com As String, ByVal fecha As DateTime, ByVal monto As Double,
            ByVal cuenta As Cuenta, ByVal tipo As TipoMovimiento, ByVal cliente As Cliente)
        MyBase.New(nroMovimiento, com, fecha, monto, cuenta, tipo)
        Me.cliente = cliente
    End Sub

    Sub New()

    End Sub

    Public Property cliente() As Cliente
        Get
            Return _cliente
        End Get
        Set(ByVal Value As Cliente)
            _cliente = Value
        End Set
    End Property

End Class ' MovimientosCuentaCliente