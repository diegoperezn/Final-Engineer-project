'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  Cuenta.vb
''  Implementation of the Class Cuenta
''  Generated by Enterprise Architect
''  Created on:      09-ago-2012 11:34:32 p.m.
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
Public Class Cuenta

    Private _codCuenta As Long
    Private _tipo As String

    Sub New(ByVal cod As Long)
        Me.codCuenta = cod
    End Sub

    Sub New()

    End Sub

    Public Property codCuenta() As Long
        Get
            Return _codCuenta
        End Get
        Set(ByVal value As Long)
            _codCuenta = value
        End Set
    End Property

    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal Value As String)
            _tipo = Value
        End Set
    End Property

End Class ' Cuenta