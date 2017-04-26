Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for OperadorTDGTest and is intended
'''to contain all OperadorTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OperadorTDGTest


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
        Dim operador As New Operario
        operador.idOperador = 3
        target.borrar(operador)
    End Sub

#End Region

    Dim target As OperadorTDG = RepositorioFactory.operadorTDG

    '''<summary>
    '''A test for buscarOperadores
    '''</summary>
    <TestMethod()> _
    Public Sub buscarOperadoresTest()
        Dim lista As List(Of Operario) = target.buscarOperadores(Nothing)

        Assert.AreEqual(2, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).idOperador)
        Assert.AreEqual(Long.Parse(4), lista(0).id)
    End Sub


    <TestMethod()> _
    Public Sub buscarOperadoresConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(OperadorTDG.ID_OPERADOR, 1))
        criteria.Add(New Restriccion(OperadorTDG.USUARIO, 4))
        Dim lista As List(Of Operario) = target.buscarOperadores(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).idOperador)
        Assert.AreEqual(Long.Parse(4), lista(0).id)
    End Sub


    <TestMethod()> _
    Public Sub grabarOperadorTest()
        Dim operador As New Operario()
        operador.id = 3

        target.grabar(operador)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(OperadorTDG.USUARIO, 3))
        Dim lista As List(Of Operario) = target.buscarOperadores(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(3), lista(0).idOperador)
        Assert.AreEqual(Long.Parse(3), lista(0).id)
    End Sub

    <TestMethod()> _
    Public Sub borrarOperadorTest()
        Dim operador As New Operario()
        operador.id = 3

        target.grabar(operador)

        Dim lista As List(Of Operario) = target.buscarOperadores(Nothing)

        Assert.AreEqual(3, lista.Count)

        target.borrar(lista(2))

        lista = target.buscarOperadores(Nothing)

        Assert.AreEqual(2, lista.Count)
    End Sub

End Class
