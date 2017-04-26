Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for TipoPedidoTDGTest and is intended
'''to contain all TipoPedidoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class TipoPedidoTDGTest


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

    Dim target As TipoPedidoTDG = RepositorioFactory.tipoPedidoTDG

    '''<summary>
    '''A test for buscarTipoPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub buscarTipoPedidosTest()
        Dim listaTipos As List(Of TipoPedido)
        listaTipos = target.buscarTipoPedidos(Nothing)
        Assert.AreEqual(Long.Parse(1), listaTipos(0).tipoPedido)
        Assert.AreEqual(Long.Parse(2), listaTipos(1).tipoPedido)
        Assert.AreEqual("con turno", listaTipos(0).descripcion)
        Assert.AreEqual("sin turno", listaTipos(1).descripcion)
        Assert.AreEqual(2, listaTipos.Count)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(TipoPedidoTDG.TIPO_PEDIDO, 1, Restriccion.CONDICION_IGUAL))
        Dim tipoP As TipoPedido = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), listaTipos(0).tipoPedido)
        Assert.AreEqual("con turno", tipoP.descripcion)

        criteria = New List(Of Restriccion)
        criteria.Add(New Restriccion(TipoPedidoTDG.DESCRIPCION, "sin turno", Restriccion.CONDICION_IGUAL))
        listaTipos = target.buscarTipoPedidos(criteria)

        Assert.AreEqual(Long.Parse(2), listaTipos(0).tipoPedido)
        Assert.AreEqual("sin turno", listaTipos(0).descripcion)
    End Sub

    '''<summary>
    '''A test for buscarTipoPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub grabarTipoPedidosTest()
        Dim tipoPedido As New TipoPedido(3, "tipo test")
        target.grabar(tipoPedido)

        Dim listaTipos As List(Of TipoPedido)
        listaTipos = target.buscarTipoPedidos(Nothing)
        Assert.AreEqual(Long.Parse(1), listaTipos(0).tipoPedido)
        Assert.AreEqual(Long.Parse(2), listaTipos(1).tipoPedido)
        Assert.AreEqual(Long.Parse(3), listaTipos(2).tipoPedido)
        Assert.AreEqual("con turno", listaTipos(0).descripcion)
        Assert.AreEqual("sin turno", listaTipos(1).descripcion)
        Assert.AreEqual("tipo test", listaTipos(2).descripcion)
        Assert.AreEqual(3, listaTipos.Count)

        target.borrar(tipoPedido)
    End Sub

    '''<summary>
    '''A test for buscarTipoPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarTipoPedidosTest()
        Dim tipoPedido As New TipoPedido(1, "tipo modificado")
        target.actualizar(tipoPedido)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(TipoPedidoTDG.TIPO_PEDIDO, 1, Restriccion.CONDICION_IGUAL))
        Dim tipoP As TipoPedido = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), tipoP.tipoPedido)
        Assert.AreEqual("tipo modificado", tipoP.descripcion)

        tipoPedido.descripcion = "con turno"
        target.actualizar(tipoPedido)
    End Sub

    '''<summary>
    '''A test for buscarTipoPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub borrarTipoPedidosTest()
        Dim listaTipos As List(Of TipoPedido)
        listaTipos = target.buscarTipoPedidos(Nothing)
        Assert.AreEqual(2, listaTipos.Count)

        Dim tipoPedido As New TipoPedido(3, "tipo test")
        target.grabar(tipoPedido)

        listaTipos = target.buscarTipoPedidos(Nothing)
        Assert.AreEqual(Long.Parse(1), listaTipos(0).tipoPedido)
        Assert.AreEqual(Long.Parse(2), listaTipos(1).tipoPedido)
        Assert.AreEqual(Long.Parse(3), listaTipos(2).tipoPedido)
        Assert.AreEqual("con turno", listaTipos(0).descripcion)
        Assert.AreEqual("sin turno", listaTipos(1).descripcion)
        Assert.AreEqual("tipo test", listaTipos(2).descripcion)
        Assert.AreEqual(3, listaTipos.Count)

        target.borrar(tipoPedido)
        listaTipos = target.buscarTipoPedidos(Nothing)
        Assert.AreEqual(Long.Parse(1), listaTipos(0).tipoPedido)
        Assert.AreEqual(Long.Parse(2), listaTipos(1).tipoPedido)
        Assert.AreEqual("con turno", listaTipos(0).descripcion)
        Assert.AreEqual("sin turno", listaTipos(1).descripcion)
        Assert.AreEqual(2, listaTipos.Count)
    End Sub

End Class
