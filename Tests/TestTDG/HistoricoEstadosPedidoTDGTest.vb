Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for HistoricoEstadosPedidoTDGTest and is intended
'''to contain all HistoricoEstadosPedidoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class HistoricoEstadosPedidoTDGTest


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
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region

    Dim target As HistoricoEstadosPedidoTDG = RepositorioFactory.historicoEstadosPedidoTDG

    '''<summary>
    '''A test for cargarHistoricoEstados
    '''</summary>
    <TestMethod()> _
    Public Sub cargarHistoricoEstadosTest()
        Dim estados As List(Of HistoricoEstados)

        estados = target.cargarHistoricoEstados(Nothing)

        Assert.AreEqual(6, estados.Count)
        Assert.AreEqual(Long.Parse(1), estados(0).nroEstado)
        Assert.AreEqual(Long.Parse(1), estados(0).pedido.codPedido)
        Assert.IsNotNull(estados(0).fechaDesde)
        Assert.IsNotNull(estados(0).fechaHasta)
        Assert.AreEqual("comentario 11", estados(0).comentario)
        Assert.AreEqual(Long.Parse(1), estados(0).estado.estadoPedido)
        Assert.AreEqual(False, estados(0).borrado)
    End Sub

    '''<summary>
    '''A test for cargarHistoricoEstados
    '''</summary>
    <TestMethod()> _
    Public Sub modificarHistoricoEstadosTest()
        Dim estado As HistoricoEstados

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(HistoricoEstadosPedidoTDG.NRO_ESTADO, 1))
        criteria.Add(New Restriccion(HistoricoEstadosPedidoTDG.PEDIDO, 1))
        estado = target.buscarUnico(criteria)

        Assert.AreEqual("comentario 11", estado.comentario)

        estado.comentario = "comentarioModificado"

        target.actualizar(estado)

        Dim estadoBase As HistoricoEstados = target.buscarUnico(criteria)

        Assert.AreEqual("comentarioModificado", estado.comentario)

        estado.comentario = "comentario 11"
        target.actualizar(estado)
    End Sub

    '''<summary>
    '''A test for cargarHistoricoEstados
    '''</summary>
    <TestMethod()> _
    Public Sub grabarHistoricoEstadosTest()
        Dim estado As New HistoricoEstados

        estado.borrado = False
        estado.comentario = "comentario32"
        Dim pedido As New Pedido()
        pedido.codPedido = 2
        estado.pedido = pedido
        estado.fechaDesde = DateTime.Now
        estado.estado = New EstadoPedido()
        estado.estado.estadoPedido = 4

        target.grabar(estado)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(HistoricoEstadosPedidoTDG.NRO_ESTADO, 4))
        criteria.Add(New Restriccion(HistoricoEstadosPedidoTDG.PEDIDO, 2))
        estado = target.buscarUnico(criteria)

        Assert.AreEqual(False, estado.borrado)
        Assert.AreEqual("comentario32", estado.comentario)
        Assert.AreEqual(Long.Parse(4), estado.estado.estadoPedido)
        Assert.AreEqual(Long.Parse(2), estado.pedido.codPedido)
        Assert.IsNotNull(estado.fechaDesde)
        Assert.AreEqual(estado.fechaHasta, New DateTime)

        target.borrar(estado)
    End Sub

    '''<summary>
    '''A test for cargarHistoricoEstados
    '''</summary>
    <TestMethod()> _
    Public Sub borrarHistoricoEstadosTest()
        Dim estado As New HistoricoEstados

        estado.borrado = False
        estado.comentario = "comentario32"
        Dim pedido As New Pedido()
        pedido.codPedido = 2
        estado.pedido = pedido
        estado.fechaDesde = DateTime.Now
        estado.estado = New EstadoPedido()
        estado.estado.estadoPedido = 4

        target.grabar(estado)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(HistoricoEstadosPedidoTDG.NRO_ESTADO, 4))
        criteria.Add(New Restriccion(HistoricoEstadosPedidoTDG.PEDIDO, 2))
        estado = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), estado.nroEstado)

        target.borrar(estado)

        estado = target.buscarUnico(criteria)
        Assert.IsNull(estado)
    End Sub
End Class
