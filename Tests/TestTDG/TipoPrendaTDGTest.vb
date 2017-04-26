Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for TipoPrendaTDGTest and is intended
'''to contain all TipoPrendaTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class TipoPrendaTDGTest


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

    Dim target As TipoPrendaTDG = RepositorioFactory.tipoPrendaTDG

    '''<summary>
    '''A test for buscarPrendas
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPrendasTest()
        Dim criteria As List(Of Restriccion) = Nothing
        Dim actual As List(Of TipoPrenda)
        actual = target.buscarPrendas(criteria)

        Assert.AreEqual(4, actual.Count)
    End Sub

    '''<summary>
    '''A test for buscarPrendas
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPrendasPorIDTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(TipoPrendaTDG.TIPO_PRENDA, 2, Restriccion.CONDICION_IGUAL))

        Dim actual As List(Of TipoPrenda)
        actual = target.buscarPrendas(criteria)

        Assert.AreEqual(1, actual.Count)
    End Sub

    '''<summary>
    '''A test for buscarPrendas
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPrendasPorDescripcionTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(TipoPedidoTDG.DESCRIPCION, "Bolsillo", Restriccion.CONDICION_IGUAL))

        Dim actual As List(Of TipoPrenda)
        actual = target.buscarPrendas(criteria)

        Assert.AreEqual(Long.Parse(2), actual(0).tipoPrenda)
    End Sub

    '''<summary>
    '''A test for actualizarPrenda
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarTipoPrendaTest()
        Dim tipoPrenda As TipoPrenda = New TipoPrenda(1, "Campera modificada")
        target.actualizar(tipoPrenda)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(TipoPrendaTDG.TIPO_PRENDA, 1, Restriccion.CONDICION_IGUAL))
        Dim tPrenda As TipoPrenda = target.buscarUnico(criterio)

        Assert.AreEqual("Campera modificada", tPrenda.descripcion)

        tipoPrenda = New TipoPrenda(1, "Campera Armada")
        target.actualizar(tipoPrenda)
    End Sub

    '''<summary>
    '''A test for grabarTipoPrenda
    '''</summary>
    <TestMethod()> _
    Public Sub grabarTipoPrendaTest()
        Dim tipoPrenda As TipoPrenda = New TipoPrenda(5, "gorro")
        target.grabar(tipoPrenda)

        Dim actual As List(Of TipoPrenda)
        actual = target.buscarPrendas(Nothing)
        Assert.AreEqual(5, actual.Count)

        target.borrar(tipoPrenda)
    End Sub

    '''<summary>
    '''A test for borrarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub borrarPrendaTest()
        Dim tipoPrenda As TipoPrenda = New TipoPrenda(5, "gorro")
        target.grabar(tipoPrenda)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(TipoPrendaTDG.TIPO_PRENDA, 5, Restriccion.CONDICION_IGUAL))

        Dim tPrenda As TipoPrenda = target.buscarUnico(criterio)

        Assert.IsNotNull(tPrenda)

        tipoPrenda = New TipoPrenda()
        tipoPrenda.tipoPrenda = 5
        target.borrar(tipoPrenda)

        tPrenda = target.buscarUnico(criterio)

        Assert.IsNull(tPrenda)
    End Sub


End Class
