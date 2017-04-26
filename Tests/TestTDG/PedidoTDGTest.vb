Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for PedidoTDGTest and is intended
'''to contain all PedidoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PedidoTDGTest


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
        target.borrar(Pedido)
    End Sub

#End Region

    Dim target As PedidoTDG = RepositorioFactory.pedidoTDG

    '''<summary>
    '''A test for cargarlistaPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub cargarlistaPedidosTest()
        Dim lista As List(Of Pedido) = target.cargarlistaPedidos(Nothing)

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual("comentario1", lista(0).comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPedido.tipoPedido)
        Assert.AreEqual(False, lista(0).borrado)
        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.AreEqual(3, lista(0).historicoEstados.Count)
        Assert.AreEqual(3, lista(0).trabajos.Count)

        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.IsNotNull(lista(0).fechaInicio)
        Assert.IsNotNull(lista(0).fechaFinal)
    End Sub

    '''<summary>
    '''A test for cargarlistaPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub cargarPedidoPorRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(PedidoTDG.COD_PEDIDO, 1))
        criteria.Add(New Restriccion(PedidoTDG.COMENTARIO, "comentario1"))
        criteria.Add(New Restriccion(PedidoTDG.CLIENTE, 1))
        criteria.Add(New Restriccion(PedidoTDG.TIPO_PEDIDO, 1))
        criteria.Add(New Restriccion(PedidoTDG.TRABAJOS, 3))
        criteria.Add(New Restriccion(PedidoTDG.ESTADO_ACTUAL, 3))
        criteria.Add(New Restriccion(PedidoTDG.BORRADO, False))
        Dim lista As List(Of Pedido) = target.cargarlistaPedidos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual("comentario1", lista(0).comentario)
        Assert.AreEqual(Long.Parse(1), lista(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPedido.tipoPedido)
        Assert.AreEqual(False, lista(0).borrado)
        Assert.AreEqual(3, lista(0).historicoEstados.Count)
        Assert.AreEqual(3, lista(0).trabajos.Count)
        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.IsNotNull(lista(0).fechaInicio)
        Assert.IsNotNull(lista(0).fechaFinal)
    End Sub

    '''<summary>
    '''A test for cargarlistaPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub grabarNuevoPedidoTest()
        Dim pedido As New Pedido(Nothing, "comentario test", New List(Of HistoricoEstados), New TipoPedido(2),
                                 New List(Of Produccion), New Cliente(2), New EstadoPedido(2), DateTime.Now, DateTime.Now)

        target.grabar(pedido)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(PedidoTDG.COMENTARIO, "comentario test"))
        Dim lista As List(Of Pedido) = target.cargarlistaPedidos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual("comentario test", lista(0).comentario)
        Assert.AreEqual(Long.Parse(2), lista(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(2), lista(0).tipoPedido.tipoPedido)
        Assert.AreEqual(False, lista(0).borrado)
        Assert.AreEqual(0, lista(0).historicoEstados.Count)
        Assert.AreEqual(0, lista(0).trabajos.Count)
        Assert.AreEqual(Long.Parse(2), lista(0).estadoActual.estadoPedido)
        Assert.IsNotNull(lista(0).fechaInicio)
        Assert.IsNotNull(lista(0).fechaFinal)
    End Sub

    '''<summary>
    '''A test for cargarlistaPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub modificarNuevoPedidoTest()
        Dim pedido As New Pedido(Nothing, "comentario test", New List(Of HistoricoEstados), New TipoPedido(2),
                                 New List(Of Produccion), New Cliente(2), New EstadoPedido(2), DateTime.Now, DateTime.Now)

        target.grabar(pedido)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(PedidoTDG.COMENTARIO, "comentario test"))
        Dim lista As List(Of Pedido) = target.cargarlistaPedidos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual("comentario test", lista(0).comentario)
        Assert.AreEqual(Long.Parse(2), lista(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(2), lista(0).tipoPedido.tipoPedido)
        Assert.AreEqual(False, lista(0).borrado)
        Assert.AreEqual(0, lista(0).historicoEstados.Count)
        Assert.AreEqual(0, lista(0).trabajos.Count)
        Assert.AreEqual(Long.Parse(2), lista(0).estadoActual.estadoPedido)
        Assert.IsNotNull(lista(0).fechaInicio)
        Assert.IsNotNull(lista(0).fechaFinal)

        pedido.comentario = "comentario Modificado"
        pedido.estadoActual = New EstadoPedido(3)
        Dim fecha As New Date(2012, 10, 10)
        pedido.fechaFinal = fecha

        target.actualizar(pedido)

        criteria.Clear()
        criteria.Add(New Restriccion(PedidoTDG.COD_PEDIDO, lista(0).codPedido))
        lista = target.cargarlistaPedidos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual("comentario Modificado", lista(0).comentario)
        Assert.AreEqual(Long.Parse(2), lista(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(2), lista(0).tipoPedido.tipoPedido)
        Assert.AreEqual(False, lista(0).borrado)
        Assert.AreEqual(0, lista(0).historicoEstados.Count)
        Assert.AreEqual(0, lista(0).trabajos.Count)
        Assert.AreEqual(Long.Parse(3), lista(0).estadoActual.estadoPedido)
        Assert.IsNotNull(lista(0).fechaInicio)
        Assert.AreEqual(lista(0).fechaFinal, fecha)
    End Sub


    '''<summary>
    '''A test for cargarlistaPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub borrarPedidoTest()
        Dim pedido As New Pedido(Nothing, "comentario test", New List(Of HistoricoEstados), New TipoPedido(2),
                                 New List(Of Produccion), New Cliente(2), New EstadoPedido(2), DateTime.Now, DateTime.Now)

        target.grabar(pedido)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(PedidoTDG.COMENTARIO, "comentario test"))
        Dim lista As List(Of Pedido) = target.cargarlistaPedidos(criteria)

        Assert.AreEqual(1, lista.Count)

        target.borrar(pedido)

        lista = target.cargarlistaPedidos(criteria)

        Assert.AreEqual(0, lista.Count)

    End Sub


End Class
