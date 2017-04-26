Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for PrendaRepositorioTest and is intended
'''to contain all PrendaRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class TipoPrendaRepositorioTest


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

    Dim target As TipoPrendaRepositorio = RepositorioFactory.tipoPrendaRepostirio
    Dim tdg As TipoPrendaTDG = RepositorioFactory.tipoPrendaTDG

    '''<summary>
    '''A test for actualizarTipoPrenda
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarTipoPrendaTest()
        Dim tipoPrenda As TipoPrenda = New TipoPrenda(1, "Campera modificada")
        target.actualizarTipoPrenda(tipoPrenda)

        Dim tPrenda As TipoPrenda = target.buscarPrendaPorId(1)

        Assert.AreEqual("Campera modificada", tPrenda.descripcion)

        tipoPrenda = New TipoPrenda(1, "Campera Armada")
        target.actualizarTipoPrenda(tipoPrenda)
    End Sub

    <TestMethod()> _
    Public Sub buscarPrendasPorIDTest()
        Dim actual As TipoPrenda = target.buscarPrendaPorId(2)

        Assert.AreEqual(Long.Parse(2), actual.tipoPrenda)
    End Sub

    '''<summary>
    '''A test for grabarPrenda
    '''</summary>
    <TestMethod()> _
    Public Sub grabarPrendaTest()
        Dim tipoPrenda As TipoPrenda = New TipoPrenda(5, "gorro")
        target.grabarPrenda(tipoPrenda)

        Dim actual As List(Of TipoPrenda)
        actual = target.ListarPrendas()
        Assert.AreEqual(5, actual.Count)

        tdg.borrar(tipoPrenda)
    End Sub

    '''<summary>
    '''A test for ListarPrendas
    '''</summary>
    <TestMethod()> _
    Public Sub ListarPrendasTest()
        Dim actual As List(Of TipoPrenda) = target.ListarPrendas()

        Assert.AreEqual(4, actual.Count)
    End Sub
End Class
