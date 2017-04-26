Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for TipoInsumoTDGTest and is intended
'''to contain all TipoInsumoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class TipoInsumoTDGTest


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

    '1	hilo
    '2	friselina fina
    '3	friselina gruesa
    '4	tela aplique
    '5	reparacion

    Dim target As TipoInsumoTDG = RepositorioFactory.tipoInsumoTDG()

    <TestMethod()> _
    Public Sub buscarTodoTest()
        Dim lista As List(Of TipoInsumo)
        lista = target.buscarLista(Nothing)

        Assert.AreEqual(Long.Parse(1), lista(0).tipo)
        Assert.AreEqual(Long.Parse(2), lista(1).tipo)
        Assert.AreEqual(Long.Parse(3), lista(2).tipo)
        Assert.AreEqual(Long.Parse(4), lista(3).tipo)
        Assert.AreEqual(Long.Parse(5), lista(4).tipo)
        Assert.AreEqual("hilo", lista(0).descripcion)
        Assert.AreEqual("friselina fina", lista(1).descripcion)
        Assert.AreEqual("friselina gruesa", lista(2).descripcion)
        Assert.AreEqual("tela aplique", lista(3).descripcion)
        Assert.AreEqual("reparacion", lista(4).descripcion)
        Assert.AreEqual(5, lista.Count)
    End Sub

    <TestMethod()> _
    Public Sub buscarPorIdTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(TipoInsumoTDG.TIPO_INSUMO, 1, Restriccion.CONDICION_IGUAL))
        Dim tipoP As TipoInsumo = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), tipoP.tipo)
        Assert.AreEqual("hilo", tipoP.descripcion)
    End Sub

    <TestMethod()> _
    Public Sub buscarPorDescripcionTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(TipoInsumoTDG.DESCRIPCION, "friselina gruesa", Restriccion.CONDICION_IGUAL))
        Dim lista As List(Of TipoInsumo) = target.buscarLista(criteria)

        Assert.AreEqual(Long.Parse(3), lista(0).tipo)
        Assert.AreEqual("friselina gruesa", lista(0).descripcion)
        Assert.AreEqual(1, lista.Count)
    End Sub
End Class
