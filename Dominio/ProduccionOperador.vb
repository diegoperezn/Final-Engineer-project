'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  ProduccionOperador.vb
''  Implementation of the Class ProduccionOperador
''  Generated by Enterprise Architect
''  Created on:      09-ago-2012 11:34:36 p.m.
''  Original author: martin.perez
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



Option Explicit On
Option Strict On

<Serializable()>
Public Class ProduccionOperador

    Private _operador As Operario
    Private _produccion As Produccion
    Private _porcentaje As Double

    Sub New(ByVal prod As Produccion, ByVal op As Operario, ByVal porcentaje As Double)
        Me.operador = op
        Me.produccion = prod
        Me.porcentaje = porcentaje
    End Sub

    Sub New()

    End Sub

    Public Property operador() As Operario
        Get
            Return _operador
        End Get
        Set(ByVal Value As Operario)
            _operador = Value
        End Set
    End Property

    Public Property produccion() As Produccion
        Get
            Return _produccion
        End Get
        Set(ByVal Value As Produccion)
            _produccion = Value
        End Set
    End Property

    Public Property porcentaje() As Double
        Get
            Return _porcentaje
        End Get
        Set(ByVal Value As Double)
            _porcentaje = Value
        End Set
    End Property


End Class ' ProduccionOperador