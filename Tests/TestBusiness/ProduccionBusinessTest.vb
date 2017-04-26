Imports System

Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for ProduccionBusinessTest and is intended
'''to contain all ProduccionBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ProduccionBusinessTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    <TestCleanup()> _
    Public Sub MyTestCleanup()
        Dim pedido As New Pedido(3)
        Dim estado1 As New HistoricoProduccion(1, New Produccion(7), "com test", DateTime.Now, Nothing, New EstadoTrabajos(0))
        Dim estado2 As New HistoricoProduccion(2, New Produccion(7), "com test", DateTime.Now, Nothing, New EstadoTrabajos(3))
        Dim prod As New Produccion(7, "com test", pedido, New Maquina(3), 10, New Articulo(3),
                                   Nothing, Nothing, New EstadoTrabajos(0), Nothing, Nothing, 1)
        Dim realizacion As New ProduccionOperador(prod, New Operario(2), 100)

        Me.realizacionTdg.borrar(realizacion)
        Me.historicoTdg.borrar(estado1)
        Me.historicoTdg.borrar(estado2)
        Me.prodTdg.borrar(prod)
    End Sub

#End Region

    Dim target As ProduccionBusiness = BusinessFactory.produccionBusiness
    Dim prodTdg As ProduccionTDG = RepositorioFactory.produccionTDG
    Dim historicoTdg As HistoricoEstadosProduccionTDG = RepositorioFactory.historicoEstadosProduccionTDG
    Dim realizacionTdg As ProduccionOperadorTDG = RepositorioFactory.produccionOperadorTDG
    Dim articuloRepo As ArticuloRepositorio = RepositorioFactory.articuloRepositorio

    '''<summary>
    '''A test for listarProduccionPorFechas
    '''</summary>
    <TestMethod()> _
    Public Sub listarProduccionPorFechasTest()
        Dim fechaDesdeInicio As DateTime = New DateTime(2012, 10, 9, 9, 0, 0, 0)
        Dim fechaHastaInicio As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)
        Dim fechaDesdeFinal As DateTime = New DateTime(2012, 10, 9, 12, 0, 0, 0)
        Dim fechaHastaFinal As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)

        Dim fechaInicio As DateTime = New DateTime(2012, 10, 9, 10, 0, 0, 0)
        Dim fechaFinal As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)

        Dim lista As List(Of Produccion) = target.listarProduccionPorFechas(fechaDesdeInicio, fechaHastaInicio, fechaDesdeFinal, fechaHastaFinal)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codProduccion)
        Assert.AreEqual("com1", lista(0).articulo.comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).articulo.diseño.idDiseño)
        Assert.AreEqual("finalizado", lista(0).estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, lista(0).fechaFinal)
        Assert.AreEqual(fechaInicio, lista(0).fechaInicio)
        Assert.AreEqual(3, lista(0).historicoProduccion.Count)
        Assert.AreEqual("comentario11", lista(0).historicoProduccion(0).comentario)
        Assert.AreEqual("nombre1", lista(0).maquina.nombre)
        Assert.AreEqual("comentario1", lista(0).pedido.comentario)
        Assert.AreEqual(2, lista(0).realizacion.Count)
        Assert.AreEqual(Double.Parse(50), lista(0).realizacion(0).porcentaje)
    End Sub

    '''<summary>
    '''A test for actualizarProduccion
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarProduccionTest()
        Dim fechaInicio As DateTime = New DateTime(2012, 10, 14, 15, 0, 0, 0)
        Dim fechaFinal As DateTime = New DateTime(2012, 10, 14, 18, 0, 0, 0)

        Dim pedido As New Pedido(3)
        Dim estados As New List(Of HistoricoProduccion)
        estados.Add(New HistoricoProduccion(Nothing, Nothing, "com test", DateTime.Now, Nothing, New EstadoTrabajos(1)))
        Dim prod As New Produccion(Nothing, "com test", pedido, New Maquina(3), 10, New Articulo(3),
                                   estados, Nothing, New EstadoTrabajos(1), fechaInicio, fechaFinal, 1)

        Me.target.grabarProduccion(prod)

        Dim produccion As Produccion = target.listarProduccionPorCodigo(7)

        Assert.AreEqual(Long.Parse(7), produccion.codProduccion)
        Assert.AreEqual("com3", produccion.articulo.comentario)
        Assert.AreEqual(Long.Parse(1), produccion.articulo.diseño.idDiseño)
        Assert.AreEqual("en espera", produccion.estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, produccion.fechaFinal)
        Assert.AreEqual(fechaInicio, produccion.fechaInicio)
        Assert.AreEqual(1, produccion.historicoProduccion.Count)
        Assert.AreEqual("com test", produccion.historicoProduccion(0).comentario)
        Assert.AreEqual("nombre3", produccion.maquina.nombre)
        Assert.AreEqual("comentario3", produccion.pedido.comentario)
        Assert.AreEqual(0, produccion.realizacion.Count)

        produccion.realizacion = New List(Of ProduccionOperador)
        produccion.realizacion.Add(New ProduccionOperador(produccion, New Operario(2), 100))
        produccion.historicoProduccion(0).fechaHasta = fechaFinal
        produccion.historicoProduccion.Add(New HistoricoProduccion(Nothing, produccion, "com test", DateTime.Now, Nothing, New EstadoTrabajos(3)))

        Me.target.actualizarProduccion(produccion)

        Dim produccionBase As Produccion = target.listarProduccionPorCodigo(7)

        Assert.AreEqual(Long.Parse(7), produccionBase.codProduccion)
        Assert.AreEqual("com3", produccionBase.articulo.comentario)
        Assert.AreEqual(Long.Parse(1), produccionBase.articulo.diseño.idDiseño)
        Assert.AreEqual("en espera", produccionBase.estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, produccionBase.fechaFinal)
        Assert.AreEqual(fechaInicio, produccionBase.fechaInicio)
        Assert.AreEqual(2, produccionBase.historicoProduccion.Count)
        Assert.AreEqual(fechaFinal, produccionBase.historicoProduccion(0).fechaHasta)
        Assert.AreEqual("com test", produccionBase.historicoProduccion(1).comentario)
        Assert.AreEqual(Long.Parse(3), produccionBase.historicoProduccion(1).estadoTrabajo.estado)
        Assert.AreEqual("nombre3", produccionBase.maquina.nombre)
        Assert.AreEqual("comentario3", produccionBase.pedido.comentario)
        Assert.AreEqual(1, produccionBase.realizacion.Count)
        Assert.AreEqual(Double.Parse(100), produccionBase.realizacion(0).porcentaje)
    End Sub

    '''<summary>
    '''A test for grabarProduccion
    '''</summary>
    <TestMethod()> _
    Public Sub grabarProduccionTest()
        Dim fechaInicio As DateTime = New DateTime(2012, 10, 14, 15, 0, 0, 0)
        Dim fechaFinal As DateTime = New DateTime(2012, 10, 14, 18, 0, 0, 0)

        Dim pedido As New Pedido(3)
        Dim estados As New List(Of HistoricoProduccion)
        estados.Add(New HistoricoProduccion(Nothing, Nothing, "com test", DateTime.Now, Nothing, New EstadoTrabajos(1)))
        Dim prod As New Produccion(Nothing, "com test", pedido, New Maquina(3), 10, New Articulo(3),
                                   estados, Nothing, New EstadoTrabajos(1), fechaInicio, fechaFinal, 1)

        Me.target.grabarProduccion(prod)

        Dim produccion As Produccion = target.listarProduccionPorCodigo(7)

        Assert.AreEqual(Long.Parse(7), produccion.codProduccion)
        Assert.AreEqual("com3", produccion.articulo.comentario)
        Assert.AreEqual(Long.Parse(1), produccion.articulo.diseño.idDiseño)
        Assert.AreEqual("en espera", produccion.estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, produccion.fechaFinal)
        Assert.AreEqual(fechaInicio, produccion.fechaInicio)
        Assert.AreEqual(1, produccion.historicoProduccion.Count)
        Assert.AreEqual("com test", produccion.historicoProduccion(0).comentario)
        Assert.AreEqual("nombre3", produccion.maquina.nombre)
        Assert.AreEqual("comentario3", produccion.pedido.comentario)
        Assert.AreEqual(0, produccion.realizacion.Count)
    End Sub

    '''<summary>
    '''A test for listarProduccionConRestricciones
    '''</summary>
    <TestMethod()> _
    Public Sub listarProduccionConRestriccionesTest()
        Dim comentario As String = "com"
        Dim fechaDesdeInicio As DateTime = New DateTime(2012, 10, 9, 9, 0, 0, 0)
        Dim fechaHastaInicio As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)
        Dim fechaDesdeFinal As DateTime = New DateTime(2012, 10, 9, 12, 0, 0, 0)
        Dim fechaHastaFinal As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)

        Dim fechaInicio As DateTime = New DateTime(2012, 10, 9, 10, 0, 0, 0)
        Dim fechaFinal As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)

        Dim lista As List(Of Produccion) = target.listarProduccionConRestricciones(comentario, 1, 1, 1, 3, fechaDesdeInicio,
                                                                                   fechaHastaInicio, fechaDesdeFinal, fechaHastaFinal)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codProduccion)
        Assert.AreEqual("com1", lista(0).articulo.comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).articulo.diseño.idDiseño)
        Assert.AreEqual("finalizado", lista(0).estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, lista(0).fechaFinal)
        Assert.AreEqual(fechaInicio, lista(0).fechaInicio)
        Assert.AreEqual(3, lista(0).historicoProduccion.Count)
        Assert.AreEqual("comentario11", lista(0).historicoProduccion(0).comentario)
        Assert.AreEqual("nombre1", lista(0).maquina.nombre)
        Assert.AreEqual("comentario1", lista(0).pedido.comentario)
        Assert.AreEqual(2, lista(0).realizacion.Count)
        Assert.AreEqual(Double.Parse(50), lista(0).realizacion(0).porcentaje)
    End Sub

    '''<summary>
    '''A test for listarProduccionPorArticulo
    '''</summary>
    <TestMethod()> _
    Public Sub listarProduccionPorArticuloTest()
        Dim articulo As Articulo = New Articulo(1)

        Dim fechaInicio As DateTime = New DateTime(2012, 10, 9, 10, 0, 0, 0)
        Dim fechaFinal As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)

        Dim lista As List(Of Produccion) = target.listarProduccionPorArticulo(articulo)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codProduccion)
        Assert.AreEqual("com1", lista(0).articulo.comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).articulo.diseño.idDiseño)
        Assert.AreEqual("finalizado", lista(0).estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, lista(0).fechaFinal)
        Assert.AreEqual(fechaInicio, lista(0).fechaInicio)
        Assert.AreEqual(3, lista(0).historicoProduccion.Count)
        Assert.AreEqual("comentario11", lista(0).historicoProduccion(0).comentario)
        Assert.AreEqual("nombre1", lista(0).maquina.nombre)
        Assert.AreEqual("comentario1", lista(0).pedido.comentario)
        Assert.AreEqual(2, lista(0).realizacion.Count)
        Assert.AreEqual(Double.Parse(50), lista(0).realizacion(0).porcentaje)
    End Sub

    '''<summary>
    '''A test for listarProduccionPorEstado
    '''</summary>
    <TestMethod()> _
    Public Sub listarProduccionPorEstadoTest()
        Dim estado As EstadoTrabajos = New EstadoTrabajos(3)

        Dim fechaInicio As DateTime = New DateTime(2012, 10, 9, 10, 0, 0, 0)
        Dim fechaFinal As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)

        Dim lista As List(Of Produccion) = target.listarProduccionPorEstado(estado)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codProduccion)
        Assert.AreEqual("com1", lista(0).articulo.comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).articulo.diseño.idDiseño)
        Assert.AreEqual("finalizado", lista(0).estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, lista(0).fechaFinal)
        Assert.AreEqual(fechaInicio, lista(0).fechaInicio)
        Assert.AreEqual(3, lista(0).historicoProduccion.Count)
        Assert.AreEqual("comentario11", lista(0).historicoProduccion(0).comentario)
        Assert.AreEqual("nombre1", lista(0).maquina.nombre)
        Assert.AreEqual("comentario1", lista(0).pedido.comentario)
        Assert.AreEqual(2, lista(0).realizacion.Count)
        Assert.AreEqual(Double.Parse(50), lista(0).realizacion(0).porcentaje)
    End Sub

    '''<summary>
    '''A test for listarProduccionPorMaquina
    '''</summary>
    <TestMethod()> _
    Public Sub listarProduccionPorMaquinaTest()
        Dim maquina As Maquina = New Maquina(1)

        Dim fechaInicio As DateTime = New DateTime(2012, 10, 9, 10, 0, 0, 0)
        Dim fechaFinal As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)

        Dim lista As List(Of Produccion) = target.listarProduccionPorMaquina(maquina)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codProduccion)
        Assert.AreEqual("com1", lista(0).articulo.comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).articulo.diseño.idDiseño)
        Assert.AreEqual("finalizado", lista(0).estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, lista(0).fechaFinal)
        Assert.AreEqual(fechaInicio, lista(0).fechaInicio)
        Assert.AreEqual(3, lista(0).historicoProduccion.Count)
        Assert.AreEqual("comentario11", lista(0).historicoProduccion(0).comentario)
        Assert.AreEqual("nombre1", lista(0).maquina.nombre)
        Assert.AreEqual("comentario1", lista(0).pedido.comentario)
        Assert.AreEqual(2, lista(0).realizacion.Count)
        Assert.AreEqual(Double.Parse(50), lista(0).realizacion(0).porcentaje)
    End Sub

    '''<summary>
    '''A test for listarProduccionPorPedido
    '''</summary>
    <TestMethod()> _
    Public Sub listarProduccionPorPedidoTest()
        Dim pedido As Pedido = New Pedido(1)

        Dim fechaInicio As DateTime = New DateTime(2012, 10, 9, 10, 0, 0, 0)
        Dim fechaFinal As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)

        Dim lista As List(Of Produccion) = target.listarProduccionPorPedido(pedido)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codProduccion)
        Assert.AreEqual("com1", lista(0).articulo.comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).articulo.diseño.idDiseño)
        Assert.AreEqual("finalizado", lista(0).estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, lista(0).fechaFinal)
        Assert.AreEqual(fechaInicio, lista(0).fechaInicio)
        Assert.AreEqual(3, lista(0).historicoProduccion.Count)
        Assert.AreEqual("comentario11", lista(0).historicoProduccion(0).comentario)
        Assert.AreEqual("nombre1", lista(0).maquina.nombre)
        Assert.AreEqual("comentario1", lista(0).pedido.comentario)
        Assert.AreEqual(2, lista(0).realizacion.Count)
        Assert.AreEqual(Double.Parse(50), lista(0).realizacion(0).porcentaje)
    End Sub

    '''<summary>
    '''A test for listarProduccionPorCodigo
    '''</summary>
    <TestMethod()> _
    Public Sub listarProduccionPorCodigoTest()
        Dim fechaInicio As DateTime = New DateTime(2012, 10, 9, 10, 0, 0, 0)
        Dim fechaFinal As DateTime = New DateTime(2012, 10, 9, 14, 0, 0, 0)

        Dim produccion As Produccion = target.listarProduccionPorCodigo(1)

        Assert.AreEqual(Long.Parse(1), produccion.codProduccion)
        Assert.AreEqual("com1", produccion.articulo.comentario)
        Assert.AreEqual(Long.Parse(1), produccion.articulo.diseño.idDiseño)
        Assert.AreEqual("finalizado", produccion.estadoActual.descripcion)
        Assert.AreEqual(fechaFinal, produccion.fechaFinal)
        Assert.AreEqual(fechaInicio, produccion.fechaInicio)
        Assert.AreEqual(3, produccion.historicoProduccion.Count)
        Assert.AreEqual("comentario11", produccion.historicoProduccion(0).comentario)
        Assert.AreEqual("nombre1", produccion.maquina.nombre)
        Assert.AreEqual("comentario1", produccion.pedido.comentario)
        Assert.AreEqual(2, produccion.realizacion.Count)
        Assert.AreEqual(Double.Parse(50), produccion.realizacion(0).porcentaje)
    End Sub




    '''<summary>
    '''A test for calcularDistanciaEntreTrabajos
    '''</summary>
    <TestMethod()> _
    Public Sub calcularDistanciaEntreTrabajosTest1()
        Dim fechaInicio1 As New DateTime(2012, 10, 10, 14, 0, 0)
        Dim fechafinal1 As New DateTime(2012, 10, 10, 17, 0, 0)
        Dim fechaInicio2 As New DateTime(2012, 10, 11, 10, 0, 0)
        Dim fechafinal2 As New DateTime(2012, 10, 11, 15, 0, 0)

        Dim primero As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio1, fechafinal1, 3)
        Dim segundo As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio2, fechafinal2, 5)
        Dim expected As Double = 2
        Dim actual As Double
        actual = target.calcularDistanciaEntreTrabajos(primero, segundo)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularDistanciaEntreTrabajos
    '''</summary>
    <TestMethod()> _
    Public Sub calcularDistanciaEntreTrabajosTest2()
        Dim fechaInicio1 As New DateTime(2012, 10, 10, 10, 0, 0)
        Dim fechafinal1 As New DateTime(2012, 10, 10, 13, 0, 0)
        Dim fechaInicio2 As New DateTime(2012, 10, 10, 15, 0, 0)
        Dim fechafinal2 As New DateTime(2012, 10, 10, 18, 0, 0)

        Dim primero As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio1, fechafinal1, 3)
        Dim segundo As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio2, fechafinal2, 5)
        Dim expected As Double = 2
        Dim actual As Double
        actual = target.calcularDistanciaEntreTrabajos(primero, segundo)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularDistanciaEntreTrabajos
    '''</summary>
    <TestMethod()> _
    Public Sub calcularDistanciaEntreTrabajosTest3()
        Dim fechaInicio1 As New DateTime(2012, 10, 10, 14, 0, 0)
        Dim fechafinal1 As New DateTime(2012, 10, 10, 17, 0, 0)
        Dim fechaInicio2 As New DateTime(2012, 10, 12, 10, 0, 0)
        Dim fechafinal2 As New DateTime(2012, 10, 12, 15, 0, 0)

        Dim primero As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio1, fechafinal1, 3)
        Dim segundo As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio2, fechafinal2, 5)
        Dim expected As Double = 11
        Dim actual As Double
        actual = target.calcularDistanciaEntreTrabajos(primero, segundo)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularDistanciaEntreTrabajos
    '''</summary>
    <TestMethod()> _
    Public Sub calcularDistanciaEntreTrabajosTest4()
        Dim fechaInicio1 As New DateTime(2012, 10, 11, 14, 0, 0)
        Dim fechafinal1 As New DateTime(2012, 10, 11, 17, 0, 0)
        Dim fechaInicio2 As New DateTime(2012, 10, 15, 10, 0, 0)
        Dim fechafinal2 As New DateTime(2012, 10, 15, 15, 0, 0)

        Dim primero As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio1, fechafinal1, 3)
        Dim segundo As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio2, fechafinal2, 5)
        Dim expected As Double = 11
        Dim actual As Double
        actual = target.calcularDistanciaEntreTrabajos(primero, segundo)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularTimepoTrabajo
    '''</summary>
    <TestMethod()> _
    Public Sub calcularTimepoTrabajoTest()
        Dim fechaInicio1 As New DateTime(2012, 10, 10, 14, 0, 0)
        Dim fechafinal1 As New DateTime(2012, 10, 10, 17, 0, 0)

        Dim trabajo As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio1, fechafinal1, 3)
        Dim expected As Double = 3
        Dim actual As Double = target.calcularTimepoTrabajo(trabajo)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularTimepoTrabajo
    '''</summary>
    <TestMethod()> _
    Public Sub calcularTimepoTrabajoTest2()
        Dim fechaInicio1 As New DateTime(2012, 10, 10, 14, 0, 0)
        Dim fechafinal1 As New DateTime(2012, 10, 11, 11, 0, 0)

        Dim trabajo As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio1, fechafinal1, 3)
        Dim expected As Double = 6
        Dim actual As Double = target.calcularTimepoTrabajo(trabajo)

        Assert.AreEqual(expected, actual)
    End Sub


    '''<summary>
    '''A test for calcularTimepoTrabajo
    '''</summary>
    <TestMethod()> _
    Public Sub calcularTimepoTrabajoTest3()
        Dim fechaInicio1 As New DateTime(2012, 10, 9, 14, 0, 0)
        Dim fechafinal1 As New DateTime(2012, 10, 12, 11, 0, 0)

        Dim trabajo As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio1, fechafinal1, 3)
        Dim expected As Double = 24
        Dim actual As Double = target.calcularTimepoTrabajo(trabajo)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularTimepoTrabajo
    '''</summary>
    <TestMethod()> _
    Public Sub calcularTimepoTrabajoTest4()
        Dim fechaInicio1 As New DateTime(2012, 10, 11, 14, 0, 0)
        Dim fechafinal1 As New DateTime(2012, 10, 16, 11, 0, 0)

        Dim trabajo As New Produccion(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, fechaInicio1, fechafinal1, 3)
        Dim expected As Double = 24
        Dim actual As Double = target.calcularTimepoTrabajo(trabajo)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularFinalizacion
    '''</summary>
    <TestMethod()> _
    Public Sub calcularFinalizacionTest()
        Dim fechaComienzo As New DateTime(2012, 10, 10, 14, 0, 0)
        Dim cantidadCabezalesHora As Integer = 3
        Dim expected As New DateTime(2012, 10, 10, 17, 0, 0)

        Dim actual As DateTime = target.calcularFinalizacion(fechaComienzo, cantidadCabezalesHora)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularFinalizacion
    '''</summary>
    <TestMethod()> _
    Public Sub calcularFinalizacionTest2()
        Dim fechaComienzo As New DateTime(2012, 10, 11, 14, 0, 0)
        Dim cantidadCabezalesHora As Integer = 24
        Dim expected As New DateTime(2012, 10, 16, 11, 0, 0)

        Dim actual As DateTime = target.calcularFinalizacion(fechaComienzo, cantidadCabezalesHora)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularFinalizacion
    '''</summary>
    <TestMethod()> _
    Public Sub calcularFinalizacionTest3()
        Dim fechaComienzo As New DateTime(2012, 10, 9, 14, 0, 0)
        Dim expected As New DateTime(2012, 10, 12, 11, 0, 0)
        Dim cantidadCabezalesHora As Integer = 24

        Dim actual As DateTime = target.calcularFinalizacion(fechaComienzo, cantidadCabezalesHora)

        Assert.AreEqual(expected, actual)
    End Sub

    '''<summary>
    '''A test for calcularFinalizacion
    '''</summary>
    <TestMethod()> _
    Public Sub calcularFinalizacionTest4()
        Dim fechaComienzo As New DateTime(2012, 10, 10, 14, 0, 0)
        Dim expected As New DateTime(2012, 10, 11, 11, 0, 0)

        Dim cantidadCabezalesHora As Double = 6

        Dim actual As DateTime = target.calcularFinalizacion(fechaComienzo, cantidadCabezalesHora)

        Assert.AreEqual(expected, actual)
    End Sub


    '''<summary>
    '''A test for buscarPrimerosHuecosMaquina
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPrimerosHuecosMaquinaTest()
        Dim fechaActual As New DateTime(2012, 10, 9, 11, 0, 0, 0)
        Dim fechaInicio As New DateTime(2012, 10, 9, 14, 0, 0, 0)
        Dim fechaFinal As New DateTime(2012, 10, 9, 16, 0, 0, 0)

        Dim maq As New Maquina(1)
        Dim tiempoNecesarioMaquina As Double = 2
        Dim fechaCalculadaInicio As DateTime = target.buscarPrimerosHuecosMaquina(maq, tiempoNecesarioMaquina, fechaActual)

        Assert.AreEqual(fechaInicio, fechaCalculadaInicio)
    End Sub

    '''<summary>
    '''A test for buscarPrimerosHuecosMaquina
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPrimerosHuecosMaquinaTest2()
        Dim fechaActual As New DateTime(2012, 10, 9, 11, 0, 0, 0)
        Dim fechaInicio As New DateTime(2012, 10, 10, 16, 0, 0, 0)

        Dim maq As New Maquina(1)
        Dim tiempoNecesarioMaquina As Double = 3
        Dim fechaCalculadaInicio As DateTime = target.buscarPrimerosHuecosMaquina(maq, tiempoNecesarioMaquina, fechaActual)

        Assert.AreEqual(fechaInicio, fechaCalculadaInicio)
    End Sub

    '''<summary>
    '''A test for buscarPrimerosHuecosMaquina
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPrimerosHuecosMaquinaTest3()
        Dim fechaActual As New DateTime(2012, 10, 9, 11, 0, 0, 0)
        Dim fechaInicio As New DateTime(2012, 10, 12, 13, 0, 0, 0)

        Dim maq As New Maquina(3)
        Dim tiempoNecesarioMaquina As Double = 9
        Dim fechaCalculadaInicio As DateTime = target.buscarPrimerosHuecosMaquina(maq, tiempoNecesarioMaquina, fechaActual)

        Assert.AreEqual(fechaInicio, fechaCalculadaInicio)
    End Sub


    '''<summary>
    '''A test for buscarPrimerosHuecosMaquina
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPrimerosHuecosMaquinaTest4()
        Dim fechaActual As New DateTime(2012, 10, 9, 11, 0, 0, 0)
        Dim fechaInicio As New DateTime(2012, 10, 16, 9, 0, 0, 0)

        Dim maq As New Maquina(3)
        Dim tiempoNecesarioMaquina As Double = 12
        Dim fechaCalculadaInicio As DateTime = target.buscarPrimerosHuecosMaquina(maq, tiempoNecesarioMaquina, fechaActual)

        Assert.AreEqual(fechaInicio, fechaCalculadaInicio)
    End Sub

    '''<summary>
    '''A test for buscarPrimerosHuecosMaquina
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPrimerosHuecosMaquinaTest5()
        Dim fechaActual As New DateTime(2012, 10, 9, 11, 0, 0, 0)
        Dim fechaInicio As New DateTime(2012, 10, 15, 9, 0, 0, 0)

        Dim maq As New Maquina(2)
        Dim tiempoNecesarioMaquina As Double = 12
        Dim fechaCalculadaInicio As DateTime = target.buscarPrimerosHuecosMaquina(maq, tiempoNecesarioMaquina, fechaActual)

        Assert.AreEqual(fechaInicio, fechaCalculadaInicio)
    End Sub


    '''<summary>
    '''A test for calcularPosiblesFechas
    '''</summary>
    <TestMethod()> _
    Public Sub calcularPosiblesFechasTest()
        Dim articulo As Articulo = Me.articuloRepo.buscarArticulosPorCodigo(1)
        Dim fechaActual As New DateTime(2012, 10, 9, 11, 0, 0, 0)
        Dim produccion As New Produccion(Nothing, "com", New Pedido(1), Nothing, 120, articulo, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        Dim fechaInicialMaquina1 As New DateTime(2012, 10, 10, 16, 0, 0, 0)
        Dim fechaFinalMaquina1 As New DateTime(2012, 10, 12, 10, 0, 0, 0)

        Dim fechaInicialMaquina2 As New DateTime(2012, 10, 15, 9, 0, 0, 0)
        Dim fechaFinalMaquina2 As New DateTime(2012, 10, 15, 11, 0, 0, 0)

        Dim fechaInicialMaquina3 As New DateTime(2012, 10, 12, 13, 0, 0, 0)
        Dim fechaFinalMaquina3 As New DateTime(2012, 10, 12, 14, 0, 0, 0)

        Dim lista As List(Of Produccion) = target.calcularPosiblesFechas(produccion, fechaActual)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Double.Parse(12), lista(0).utilizacion)
        Assert.AreEqual(fechaInicialMaquina1, lista(0).fechaInicio)
        Assert.AreEqual(fechaFinalMaquina1, lista(0).fechaFinal)
        Assert.AreEqual(Double.Parse(2), lista(1).utilizacion)
        Assert.AreEqual(fechaInicialMaquina2, lista(1).fechaInicio)
        Assert.AreEqual(fechaFinalMaquina2, lista(1).fechaFinal)
        Assert.AreEqual(Double.Parse(1), lista(2).utilizacion)
        Assert.AreEqual(fechaInicialMaquina3, lista(2).fechaInicio)
        Assert.AreEqual(fechaFinalMaquina3, lista(2).fechaFinal)
    End Sub


    '''<summary>
    '''A test for calcularPosiblesFechas
    '''</summary>
    <TestMethod()> _
    Public Sub calcularPosiblesFechasTest2()
        Dim articulo As Articulo = Me.articuloRepo.buscarArticulosPorCodigo(1)
        Dim fechaActual As New DateTime(2012, 10, 9, 11, 0, 0, 0)
        Dim produccion As New Produccion(Nothing, "com", New Pedido(1), Nothing, 1200, articulo, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        Dim fechaInicialMaquina1 As New DateTime(2012, 10, 10, 16, 0, 0, 0)
        Dim fechaFinalMaquina1 As New DateTime(2012, 10, 30, 10, 0, 0, 0)

        Dim fechaInicialMaquina2 As New DateTime(2012, 10, 15, 9, 0, 0, 0)
        Dim fechaFinalMaquina2 As New DateTime(2012, 10, 17, 11, 0, 0, 0)

        Dim fechaInicialMaquina3 As New DateTime(2012, 10, 16, 9, 0, 0, 0)
        Dim fechaFinalMaquina3 As New DateTime(2012, 10, 17, 10, 0, 0, 0)

        Dim lista As List(Of Produccion) = target.calcularPosiblesFechas(produccion, fechaActual)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Double.Parse(120), lista(0).utilizacion)
        Assert.AreEqual(fechaInicialMaquina1, lista(0).fechaInicio)
        Assert.AreEqual(fechaFinalMaquina1, lista(0).fechaFinal)
        Assert.AreEqual(Double.Parse(20), lista(1).utilizacion)
        Assert.AreEqual(fechaInicialMaquina2, lista(1).fechaInicio)
        Assert.AreEqual(fechaFinalMaquina2, lista(1).fechaFinal)
        Assert.AreEqual(Double.Parse(10), lista(2).utilizacion)
        Assert.AreEqual(fechaInicialMaquina3, lista(2).fechaInicio)
        Assert.AreEqual(fechaFinalMaquina3, lista(2).fechaFinal)
    End Sub

End Class
