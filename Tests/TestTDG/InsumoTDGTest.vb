Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for InsumoTDGTest and is intended
'''to contain all InsumoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class InsumoTDGTest


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
        Dim insumo As New Insumo()
        insumo.codInsumo = 5
        target.borrar(insumo)
    End Sub

#End Region

    Dim target As InsumoTDG = RepositorioFactory.insumoTDG

    '''<summary>
    '''A test for buscarInsumos
    '''</summary>
    <TestMethod()> _
    Public Sub buscarInsumosTest()
        Dim lista As List(Of Insumo) = target.buscarInsumos(Nothing)

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codInsumo)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoInsumo.tipo)
        Assert.AreEqual(Long.Parse(1), lista(0).color.codColor)
        Assert.AreEqual("detalle1", lista(0).detalle)
        Assert.AreEqual("nombre1", lista(0).nombre)
        Assert.AreEqual(Double.Parse(1), lista(0).costo)
        Assert.AreEqual(Double.Parse(1), lista(0).cantidadActual)
    End Sub

    '''<summary>
    '''A test for buscarInsumos
    '''</summary>
    <TestMethod()> _
    Public Sub buscarInsumosConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(InsumoTDG.CANTIDAD_ACTUAL, 1))
        criteria.Add(New Restriccion(InsumoTDG.COD_INSUMO, 1))
        criteria.Add(New Restriccion(InsumoTDG.COLOR, 1))
        criteria.Add(New Restriccion(InsumoTDG.TIPO_INSUMO, 1))
        criteria.Add(New Restriccion(InsumoTDG.DETALLE, "detalle1"))
        criteria.Add(New Restriccion(InsumoTDG.NOMBRE, "nombre1"))
        Dim lista As List(Of Insumo) = target.buscarInsumos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codInsumo)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoInsumo.tipo)
        Assert.AreEqual(Long.Parse(1), lista(0).color.codColor)
        Assert.AreEqual("detalle1", lista(0).detalle)
        Assert.AreEqual("nombre1", lista(0).nombre)
        Assert.AreEqual(Double.Parse(1), lista(0).cantidadActual)
    End Sub

    '''<summary>
    '''A test for buscarInsumos
    '''</summary>
    <TestMethod()> _
    Public Sub grabarInsumoTest()
        Dim insumo As New Insumo(Nothing, "nombre5", "detalle5", 5, New TipoInsumo(1, Nothing), New Color(1), Nothing, 5)

        target.grabar(insumo)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(InsumoTDG.COD_INSUMO, 5))
        Dim lista As List(Of Insumo) = target.buscarInsumos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(5), lista(0).codInsumo)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoInsumo.tipo)
        Assert.AreEqual(Long.Parse(1), lista(0).color.codColor)
        Assert.AreEqual("detalle5", lista(0).detalle)
        Assert.AreEqual("nombre5", lista(0).nombre)
        Assert.AreEqual(Double.Parse(5), lista(0).cantidadActual)
    End Sub

    '''<summary>
    '''A test for buscarInsumos
    '''</summary>
    <TestMethod()> _
    Public Sub modificarInsumoTest()
        Dim insumo As New Insumo(Nothing, "nombre5", "detalle5", 5, New TipoInsumo(1, Nothing), New Color(1), Nothing, 5)

        target.grabar(insumo)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(InsumoTDG.COD_INSUMO, 5))
        Dim insumoBase As Insumo = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(5), insumoBase.codInsumo)
        Assert.AreEqual(Long.Parse(1), insumoBase.tipoInsumo.tipo)
        Assert.AreEqual(Long.Parse(1), insumoBase.color.codColor)
        Assert.AreEqual(Double.Parse(5), insumoBase.costo)
        Assert.AreEqual("detalle5", insumoBase.detalle)
        Assert.AreEqual("nombre5", insumoBase.nombre)
        Assert.AreEqual(Double.Parse(5), insumoBase.cantidadActual)

        insumoBase.color = New Color(4)
        target.actualizar(insumoBase)

        Dim insumoModificado As Insumo = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), insumoModificado.color.codColor)
    End Sub

    <TestMethod()> _
    Public Sub borrarInsumoTest()
        Dim insumo As New Insumo(Nothing, "nombre5", "detalle5", 5, New TipoInsumo(1, Nothing), New Color(1), Nothing, 5)

        target.grabar(insumo)

        Dim lista As List(Of Insumo) = target.buscarInsumos(Nothing)

        Assert.AreEqual(5, lista.Count)

        target.borrar(lista(4))

        lista = target.buscarInsumos(Nothing)

        Assert.AreEqual(4, lista.Count)
    End Sub

End Class

