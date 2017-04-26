Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for TipoMovimientoTDGTest and is intended
'''to contain all TipoMovimientoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class TipoMovimientoTDGTest


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

    Dim target As TipoMovimientoTDG = RepositorioFactory.tipoMovimientoTDG

    '''<summary>
    '''A test for buscarLista
    '''</summary>
    <TestMethod()> _
    Public Sub buscarTodoTest()
        Dim lista As List(Of TipoMovimiento)
        lista = target.buscarLista(Nothing)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoMovimiento)
        Assert.AreEqual(Long.Parse(2), lista(1).tipoMovimiento)
        Assert.AreEqual("debito", lista(0).descripcion)
        Assert.AreEqual("credito", lista(1).descripcion)
        Assert.AreEqual(2, lista.Count)
    End Sub

    '''<summary>
    '''A test for buscarLista
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPorIdTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(TipoMovimientoTDG.TIPO_MOVIMIENTO, 1, Restriccion.CONDICION_IGUAL))
        Dim tipoP As TipoMovimiento = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), tipoP.tipoMovimiento)
        Assert.AreEqual("debito", tipoP.descripcion)
    End Sub

    '''<summary>
    '''A test for buscarLista
    '''</summary>
    <TestMethod()> _
    Public Sub buscarPorDescripcionTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(TipoMovimientoTDG.MOVIMIENTO, "credito", Restriccion.CONDICION_IGUAL))
        Dim lista As List(Of TipoMovimiento) = target.buscarLista(criteria)

        Assert.AreEqual(Long.Parse(2), lista(0).tipoMovimiento)
        Assert.AreEqual("credito", lista(0).descripcion)
    End Sub

End Class
