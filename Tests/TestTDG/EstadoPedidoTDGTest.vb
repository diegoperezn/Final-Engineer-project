Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for EstadoPedidoTDGTest and is intended
'''to contain all EstadoPedidoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class EstadoPedidoTDGTest


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

    Dim target As EstadoPedidoTDG = RepositorioFactory.estadoPedidoTDG

    '''<summary>
    '''A test for buscarEstados
    '''</summary>
    <TestMethod()> _
    Public Sub buscarEstadosTest()
        Dim estados As List(Of EstadoPedido) = target.buscarEstados(Nothing)

        Assert.AreEqual(4, estados.Count)
        Assert.AreEqual("pendiente recepcion", estados(0).descripcion)
    End Sub

    '''<summary>
    '''A test for buscarEstadosPorId
    '''</summary>
    <TestMethod()> _
    Public Sub buscarEstadosPorIdTest()
        Dim estado As EstadoPedido = target.buscarEstadosPorId(1)

        Assert.AreEqual(Long.Parse(1), estado.estadoPedido)
        Assert.AreEqual("pendiente recepcion", estado.descripcion)
    End Sub

End Class
