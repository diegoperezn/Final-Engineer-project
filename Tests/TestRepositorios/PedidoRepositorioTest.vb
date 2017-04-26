Imports System

Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for PedidoRepositorioTest and is intended
'''to contain all PedidoRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PedidoRepositorioTest


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
        Dim pedido As New Pedido(5, "comentario test", New List(Of HistoricoEstados), New TipoPedido(2),
                         New List(Of Produccion), New Cliente(2), New EstadoPedido(2), DateTime.Now, DateTime.Now)
        Dim estado As New HistoricoEstados()
        estado.pedido = pedido
        estado.nroEstado = 1
        tdgEstados.borrar(estado)
        estado.nroEstado = 2
        tdgEstados.borrar(estado)

        Dim prod As New Produccion()
        prod.codProduccion = 7

        tdgproduccion.borrar(prod)

        tdg.borrar(pedido)
    End Sub

#End Region

    Dim target As PedidoRepositorio = RepositorioFactory.pedidoRepositorio
    Dim tdg As PedidoTDG = RepositorioFactory.pedidoTDG
    Dim tdgEstados As HistoricoEstadosPedidoTDG = RepositorioFactory.historicoEstadosPedidoTDG
    Dim tdgproduccion As ProduccionTDG = RepositorioFactory.produccionTDG

    '''<summary>
    '''A test for actualizarPedido
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarPedidoTest()
        Dim estados As New List(Of HistoricoEstados)
        estados.Add(New HistoricoEstados(Nothing, Nothing, "com", DateTime.Now, Nothing, New EstadoPedido(1)))
        Dim produccion As New List(Of Produccion)
        produccion.Add(New Produccion(Nothing, "com1", Nothing, New Maquina(2), 10, New Articulo(1), Nothing, Nothing, New EstadoTrabajos(1), DateTime.Now, Nothing, 1))

        Dim pedidoNuevo As New Pedido(Nothing, "comentario test", estados, New TipoPedido(2),
                                 produccion, New Cliente(2), New EstadoPedido(2), DateTime.Now, DateTime.Now)
        estados(0).pedido = pedidoNuevo
        produccion(0).pedido = pedidoNuevo

        target.grabarPedido(pedidoNuevo)

        Dim pedido As Pedido = target.buscarPedidoPorCodigo(5)

        Assert.AreEqual("comentario test", pedido.comentario)
        Assert.AreEqual(Long.Parse(2), pedido.cliente.idCliente)
        Assert.AreEqual(Long.Parse(2), pedido.tipoPedido.tipoPedido)
        Assert.AreEqual(False, pedido.borrado)
        Assert.AreEqual(1, pedido.historicoEstados.Count)
        Assert.AreEqual(1, pedido.trabajos.Count)
        Assert.AreEqual(Long.Parse(2), pedido.estadoActual.estadoPedido)
        Assert.IsNotNull(pedido.fechaInicio)
        Assert.IsNotNull(pedido.fechaFinal)

        Dim fecha As New Date(2012, 10, 10)

        pedido.comentario = "comentario Modificado"
        pedido.estadoActual = New EstadoPedido(3)
        pedido.historicoEstados(0).fechaHasta = fecha
        pedido.historicoEstados.Add(New HistoricoEstados(Nothing, pedido, "com", DateTime.Now, Nothing, New EstadoPedido(2)))
        pedido.trabajos(0).fechaFinal = fecha
        pedido.fechaFinal = fecha

        target.actualizarPedido(pedido)

        pedido = target.buscarPedidoPorCodigo(5)

        Assert.AreEqual("comentario Modificado", pedido.comentario)
        Assert.AreEqual(Long.Parse(2), pedido.cliente.idCliente)
        Assert.AreEqual(Long.Parse(2), pedido.tipoPedido.tipoPedido)
        Assert.AreEqual(False, pedido.borrado)
        Assert.AreEqual(2, pedido.historicoEstados.Count)
        Assert.AreEqual(1, pedido.trabajos.Count)
        Assert.AreEqual(Long.Parse(3), pedido.estadoActual.estadoPedido)
        Assert.IsNotNull(pedido.fechaInicio)
        Assert.AreEqual(pedido.fechaFinal, fecha)

        Assert.AreEqual(2, pedido.historicoEstados.Count)
        Assert.AreEqual(fecha, pedido.historicoEstados(0).fechaHasta)
        Assert.AreEqual(Long.Parse(2), pedido.historicoEstados(1).estado.estadoPedido)
        Assert.AreEqual(fecha, pedido.trabajos(0).fechaFinal)
        Assert.AreEqual(fecha, pedido.trabajos(0).fechaFinal)

    End Sub

    '''<summary>
    '''A test for grabarPedido
    '''</summary>
    <TestMethod()> _
    Public Sub grabarPedidoTest()
        Dim estados As New List(Of HistoricoEstados)
        estados.Add(New HistoricoEstados(Nothing, Nothing, "com", DateTime.Now, Nothing, New EstadoPedido(1)))
        Dim produccion As New List(Of Produccion)
        produccion.Add(New Produccion(Nothing, "com1", Nothing, New Maquina(2), 10, New Articulo(1), Nothing, Nothing, New EstadoTrabajos(1), DateTime.Now, Nothing, 1))

        Dim pedidoNuevo As New Pedido(Nothing, "comentario test", estados, New TipoPedido(2),
                                 produccion, New Cliente(2), New EstadoPedido(2), DateTime.Now, DateTime.Now)
        estados(0).pedido = pedidoNuevo
        produccion(0).pedido = pedidoNuevo

        target.grabarPedido(pedidoNuevo)

        Dim pedido As Pedido = target.buscarPedidoPorCodigo(5)

        Assert.AreEqual("comentario test", pedido.comentario)
        Assert.AreEqual(Long.Parse(2), pedido.cliente.idCliente)
        Assert.AreEqual(Long.Parse(2), pedido.tipoPedido.tipoPedido)
        Assert.AreEqual(False, pedido.borrado)
        Assert.AreEqual(1, pedido.historicoEstados.Count)
        Assert.AreEqual(1, pedido.trabajos.Count)
        Assert.AreEqual(Long.Parse(2), pedido.estadoActual.estadoPedido)
        Assert.IsNotNull(pedido.fechaInicio)
        Assert.IsNotNull(pedido.fechaFinal)

        Assert.AreEqual(1, pedido.historicoEstados.Count)
        Assert.AreEqual(Long.Parse(1), pedido.historicoEstados(0).estado.estadoPedido)
    End Sub

    '''<summary>
    '''A test for listarPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub listarPedidosTest()
        Dim lista As List(Of Pedido) = target.listarPedidos()

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual("comentario1", lista(0).comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPedido.tipoPedido)
        Assert.AreEqual(False, lista(0).borrado)
        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.AreEqual(3, lista(0).historicoEstados.Count)
        Assert.AreEqual(3, lista(0).trabajos.Count)
        Assert.AreEqual("comentario 11", lista(0).trabajos(0).comentario)
        Assert.AreEqual(Long.Parse(3), lista(0).trabajos(0).estadoActual.estado)

        Assert.AreEqual("comentario 11", lista(0).historicoEstados(0).comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).historicoEstados(0).estado.estadoPedido)

        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.AreEqual("en produccion", lista(0).estadoActual.descripcion)
        Assert.IsNotNull(lista(0).fechaInicio)
        Assert.IsNotNull(lista(0).fechaFinal)
    End Sub

    '''<summary>
    '''A test for listarPedidosConRestriccion
    '''</summary>
    <TestMethod()> _
    Public Sub listarPedidosConRestriccionTest()
        Dim cliente As Cliente = New Cliente(1)
        Dim estadoActual As EstadoPedido = New EstadoPedido(3)
        Dim fechaDesdeInicio As DateTime = New DateTime(2012, 9, 11, 12, 0, 0, 0)
        Dim fechaHastaInicio As DateTime = New DateTime(2012, 9, 11, 14, 0, 0, 0) ' TODO: Initialize to an appropriate value
        Dim fechaDesdeFinal As DateTime = New DateTime(2012, 9, 11, 12, 0, 0, 0) ' TODO: Initialize to an appropriate value
        Dim fechaHastaFinal As DateTime = New DateTime(2012, 9, 11, 14, 0, 0, 0) ' TODO: Initialize to an appropriate value

        Dim lista As List(Of Pedido)
        lista = target.listarPedidosConRestriccion(1, 3, fechaDesdeInicio, fechaHastaInicio, fechaDesdeFinal, fechaHastaFinal)

        Assert.AreEqual("comentario1", lista(0).comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPedido.tipoPedido)
        Assert.AreEqual(False, lista(0).borrado)
        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.AreEqual(3, lista(0).historicoEstados.Count)
        Assert.AreEqual(3, lista(0).trabajos.Count)
        Assert.AreEqual("comentario 11", lista(0).trabajos(0).comentario)
        Assert.AreEqual(Long.Parse(3), lista(0).trabajos(0).estadoActual.estado)

        Assert.AreEqual("comentario 11", lista(0).historicoEstados(0).comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).historicoEstados(0).estado.estadoPedido)

        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.AreEqual("en produccion", lista(0).estadoActual.descripcion)
        Assert.IsNotNull(lista(0).fechaInicio)
        Assert.IsNotNull(lista(0).fechaFinal)

    End Sub

    '''<summary>
    '''A test for listarPedidosPorCliente
    '''</summary>
    <TestMethod()> _
    Public Sub listarPedidosPorClienteTest()
        Dim lista As List(Of Pedido)
        lista = target.listarPedidosPorCliente(1)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual("comentario1", lista(0).comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPedido.tipoPedido)
        Assert.AreEqual(False, lista(0).borrado)
        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.AreEqual(3, lista(0).historicoEstados.Count)
        Assert.AreEqual(3, lista(0).trabajos.Count)
        Assert.AreEqual("comentario 11", lista(0).trabajos(0).comentario)
        Assert.AreEqual(Long.Parse(3), lista(0).trabajos(0).estadoActual.estado)

        Assert.AreEqual("comentario 11", lista(0).historicoEstados(0).comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).historicoEstados(0).estado.estadoPedido)

        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.AreEqual("en produccion", lista(0).estadoActual.descripcion)
        Assert.IsNotNull(lista(0).fechaInicio)
        Assert.IsNotNull(lista(0).fechaFinal)
    End Sub

    '''<summary>
    '''A test for buscarPedidoPorCodigo
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPedidoPorCodigoTest()
        Dim pedido As Pedido = target.buscarPedidoPorCodigo(1)

        Assert.AreEqual("comentario1", pedido.comentario)
        Assert.AreEqual(Long.Parse(1), pedido.cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), pedido.tipoPedido.tipoPedido)
        Assert.AreEqual(False, pedido.borrado)
        Assert.AreEqual(Long.Parse(3), pedido.estadoActual.estadoPedido)
        Assert.AreEqual(3, pedido.historicoEstados.Count)
        Assert.AreEqual(3, pedido.trabajos.Count)
        Assert.AreEqual("comentario 11", pedido.trabajos(0).comentario)
        Assert.AreEqual(Long.Parse(3), pedido.trabajos(0).estadoActual.estado)

        Assert.AreEqual("comentario 11", pedido.historicoEstados(0).comentario)
        Assert.AreEqual(Long.Parse(1), pedido.historicoEstados(0).estado.estadoPedido)

        Assert.AreEqual(Long.Parse(3), pedido.estadoActual.estadoPedido)
        Assert.AreEqual("en produccion", pedido.estadoActual.descripcion)
        Assert.IsNotNull(pedido.fechaInicio)
        Assert.IsNotNull(pedido.fechaFinal)
    End Sub
End Class
