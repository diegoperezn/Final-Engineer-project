'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  Familia.vb
''  Implementation of the Class Familia
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
Public Class Familia

    Private _idFamilia As Long
    Private _descripcion As String
    Private _nombre As String
    Private _patentes As New List(Of Patente)

    Sub New()

    End Sub

    Sub New(ByVal id As Long, ByVal des As String, ByVal nombre As String, ByVal patentes As List(Of Patente))
        Me.idFamilia = id
        Me.descripcion = des
        Me.nombre = nombre
        Me.patentes = patentes
    End Sub

    Sub New(ByVal id As Long, ByVal des As String, ByVal nombre As String)
        Me.idFamilia = id
        Me.descripcion = des
        Me.nombre = nombre
    End Sub

    Public Property idFamilia() As Long
        Get
            Return _idFamilia
        End Get
        Set(ByVal value As Long)
            _idFamilia = value
        End Set
    End Property


    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal Value As String)
            _descripcion = Value
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

    Public Property patentes() As List(Of Patente)
        Get
            Return _patentes
        End Get
        Set(ByVal Value As List(Of Patente))
            _patentes = Value
        End Set
    End Property


End Class ' Familia