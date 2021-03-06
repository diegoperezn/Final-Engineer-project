'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  TipoPrenda.vb
''  Implementation of the Class TipoPrenda
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
Public Class TipoPrenda

    Private _tipoPrenda As Long
    Private _descripcion As String

    Sub New(ByVal tipoPrenda As Long, ByVal descripcion As String)
        Me.tipoPrenda = tipoPrenda
        Me.descripcion = descripcion
    End Sub

    Sub New()
    End Sub

    Sub New(ByVal id As Long)
        Me.tipoPrenda = id
    End Sub

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
        End Set
    End Property

    Public Property tipoPrenda() As Long
        Get
            Return _tipoPrenda
        End Get
        Set(ByVal Value As Long)
            _tipoPrenda = Value
        End Set
    End Property

End Class ' TipoPrenda