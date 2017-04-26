Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for CuentaTDGTest and is intended
'''to contain all CuentaTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class CuentaTDGTest


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

    Dim target As CuentaTDG = RepositorioFactory.cuentaTDG

    '''<summary>
    '''A test for buscarTipoPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub buscarTipoCuentasTest()
        Dim lista As List(Of Cuenta) = target.buscarTipoCuentas(Nothing)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codCuenta)
        Assert.AreEqual("doc a cobrar", lista(0).tipo)
    End Sub

    '''<summary>
    '''A test for buscarTipoPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub buscarTipoCuentaPorIdTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(CuentaTDG.COD_CUENTA, 1))
        Dim lista As List(Of Cuenta) = target.buscarTipoCuentas(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codCuenta)
        Assert.AreEqual("doc a cobrar", lista(0).tipo)
    End Sub

    '''<summary>
    '''A test for buscarTipoPedidos
    '''</summary>
    <TestMethod()> _
    Public Sub buscarTipoCuentaPorIdTest2()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(CuentaTDG.COD_CUENTA, 1))
        Dim cuenta As Cuenta = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), cuenta.codCuenta)
        Assert.AreEqual("doc a cobrar", cuenta.tipo)
    End Sub

End Class
