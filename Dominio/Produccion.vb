'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  Produccion.vb
''  Implementation of the Class Produccion
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
Public Class Produccion

    Private _codProduccion As Long
    Private _comentario As String
    Private _pedido As Pedido
    Private _maquina As Maquina
    Private _articulo As Articulo
    Private _historicoProduccion As List(Of HistoricoProduccion)
    Private _realizacion As List(Of ProduccionOperador)
    Private _utilizacion As Double

    Private _cantidad As Integer

    Private _estadoActual As EstadoTrabajos

    Private _fechaInicio As Date
    Private _fechaFinal As Date

    Private _borrado As Boolean

    Public Sub New(ByVal cod As Long, ByVal comentario As String, ByVal pedido As Pedido, ByVal maquina As Maquina, ByVal cantidad As Integer,
                   ByVal articulo As Articulo, ByVal estados As List(Of HistoricoProduccion), ByVal realizacion As List(Of ProduccionOperador),
                   ByVal estadoActual As EstadoTrabajos, ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal utilizacion As Double)
        Me.codProduccion = cod
        Me.comentario = comentario
        Me.pedido = pedido
        Me.maquina = maquina
        Me.articulo = articulo
        Me.historicoProduccion = estados
        Me.cantidad = cantidad
        Me.realizacion = realizacion
        Me.estadoActual = estadoActual
        Me.fechaInicio = fechaInicio
        Me.fechaFinal = fechaFinal
        Me.utilizacion = utilizacion
        If Not estados Is Nothing Then
            For Each est As HistoricoProduccion In estados
                est.produccion = Me
            Next
        End If

        If Not realizacion Is Nothing Then
            For Each real As ProduccionOperador In realizacion
                real.produccion = Me
            Next
        End If
    End Sub

    Public Sub New(ByVal articulo As Articulo, ByVal cantidad As Integer)
        Me.articulo = articulo
        Me.cantidad = cantidad
    End Sub

    Sub New(ByVal id As Long)
        Me.codProduccion = id
    End Sub

    Public Sub New()

    End Sub

    Public Property utilizacion() As Double
        Get
            Return _utilizacion
        End Get
        Set(ByVal value As Double)
            _utilizacion = value
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

    Public Property codProduccion() As Long
        Get
            Return _codProduccion
        End Get
        Set(ByVal value As Long)
            _codProduccion = value
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

    Public Property pedido() As Pedido
        Get
            Return _pedido
        End Get
        Set(ByVal Value As Pedido)
            _pedido = Value
        End Set
    End Property

    Public Property maquina() As Maquina
        Get
            Return _maquina
        End Get
        Set(ByVal Value As Maquina)
            _maquina = Value
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
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Property historicoProduccion() As List(Of HistoricoProduccion)
        Get
            Return _historicoProduccion
        End Get
        Set(ByVal Value As List(Of HistoricoProduccion))
            _historicoProduccion = Value
        End Set
    End Property

    Public Property realizacion() As List(Of ProduccionOperador)
        Get
            Return _realizacion
        End Get
        Set(ByVal Value As List(Of ProduccionOperador))
            _realizacion = Value
        End Set
    End Property

    Public Property fechaInicio() As Date
        Get
            Return _fechaInicio
        End Get
        Set(ByVal value As Date)
            _fechaInicio = value
        End Set
    End Property

    Public Property fechaFinal() As Date
        Get
            Return _fechaFinal
        End Get
        Set(ByVal value As Date)
            _fechaFinal = value
        End Set
    End Property

    Public Property estadoActual() As EstadoTrabajos
        Get
            Return _estadoActual
        End Get
        Set(ByVal value As EstadoTrabajos)
            _estadoActual = value
        End Set
    End Property

    Public ReadOnly Property porcentajeRealizacion() As Double
        Get
            If estadoActual.estado.Equals(2) Then
                Dim fechaActual As DateTime = DateTime.Now
                Dim fecha As DateTime
                If fechaActual.Hour > 18 Then
                    fecha = New Date(fechaActual.Year, fechaActual.Month, fechaActual.Day, 18, 0, 0)
                End If
                If fechaActual.Hour < 9 Then
                    fechaActual.AddDays(-1)
                    fecha = New Date(fechaActual.Year, fechaActual.Month, fechaActual.Day, 18, 0, 0)
                End If

                Return calcularDistanciaEntrefechas(Me.fechaInicio, DateTime.Now) _
                        / calcularDistanciaEntrefechas(Me.fechaInicio, Me.fechaFinal)
            ElseIf estadoActual.estado.Equals(3) Then
                Return 100
            Else
                Return 0
            End If
        End Get
    End Property

    Private Function calcularDistanciaEntrefechas(ByVal primero As DateTime, ByVal segundo As DateTime) As Double
        If primero.DayOfYear = segundo.DayOfYear Then
            Return calcularHoras(segundo.Ticks - primero.Ticks)
        Else
            Dim finalDia As New Date(primero.Year, primero.Month, primero.Day, 18, 0, 0)
            Dim inicioDia As New Date(segundo.Year, segundo.Month, segundo.Day, 9, 0, 0)
            Dim fechaInicial As Date = primero
            Dim distancia As New Long
            While Not finalDia.DayOfYear = segundo.DayOfYear
                If Not (finalDia.DayOfWeek = DayOfWeek.Saturday OrElse finalDia.DayOfWeek = DayOfWeek.Sunday) Then
                    distancia += finalDia.Ticks - fechaInicial.Ticks
                End If

                finalDia = finalDia.AddDays(1)
                fechaInicial = New Date(finalDia.Year, finalDia.Month, finalDia.Day, 9, 0, 0)
            End While

            distancia += segundo.Ticks - inicioDia.Ticks

            Return calcularHoras(distancia)
        End If
    End Function


    Private Function calcularHoras(ByVal trick As Double) As Double
        Return (trick / 1000 / 60 / 60) / 10000
    End Function

End Class ' Produccion