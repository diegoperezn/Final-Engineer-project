Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for InsumoBusinessTest and is intended
'''to contain all InsumoBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class InsumoBusinessTest


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
        Dim insumo As New Insumo(5)
        Dim mov1 As New MovimientosStock(1, insumo, 100, DateTime.Now, New TipoMovimiento(1))
        Dim mov2 As New MovimientosStock(2, insumo, 150, DateTime.Now, New TipoMovimiento(1))

        Dim insumo1 As Insumo = Me.target.listarInsumosPorCodigo(1)
        Dim insumo2 As Insumo = Me.target.listarInsumosPorCodigo(2)

        insumo1.cantidadActual = 1
        insumo2.cantidadActual = 2

        Me.target.actualizarInsumo(insumo1)
        Me.target.actualizarInsumo(insumo2)

        Me.dao.ejecutarConsulta("delete from MovimientosStock where cod_insumo > 2 or (cod_insumo = 1 AND nro_movimiento > 2) or (cod_insumo = 2 AND nro_movimiento > 1)")

        Me.movimietosTdg.borrar(mov1)
        Me.movimietosTdg.borrar(mov2)
        Me.insumoTdg.borrar(insumo)
    End Sub

#End Region

    Dim dao As DataAccesObject = RepositorioFactory.dao
    Dim target As InsumoBusiness = BusinessFactory.InsumoBusiness
    Dim insumoTdg As InsumoTDG = RepositorioFactory.insumoTDG
    Dim movimietosTdg As MovimientoStockTDG = RepositorioFactory.movimientoStockTDG

    '''<summary>
    '''A test for listarInsumosPorTipo
    '''</summary>
    <TestMethod()> _
    Public Sub listarInsumosPorTipoTest()
        Dim tipo As TipoInsumo = New TipoInsumo(1)
        Dim lista As List(Of Insumo) = target.listarInsumosPorTipo(tipo)

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codInsumo)
        Assert.AreEqual("Rojo", lista(0).color.color)
        Assert.AreEqual("hilo", lista(0).tipoInsumo.descripcion)
        Assert.AreEqual(2, lista(0).movimientosStock.Count)
        Assert.AreEqual(Double.Parse(10), lista(0).movimientosStock(0).cantidad)
    End Sub

    '''<summary>
    '''A test for listarInsumosPorColor
    '''</summary>
    <TestMethod()> _
    Public Sub listarInsumosPorColorTest()
        Dim color As Color = New Color(1)
        Dim lista As List(Of Insumo) = target.listarInsumosPorColor(color)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codInsumo)
        Assert.AreEqual("Rojo", lista(0).color.color)
        Assert.AreEqual("hilo", lista(0).tipoInsumo.descripcion)
        Assert.AreEqual(2, lista(0).movimientosStock.Count)
        Assert.AreEqual(Double.Parse(10), lista(0).movimientosStock(0).cantidad)
    End Sub

    '''<summary>
    '''A test for listarInsumosPorCodigo
    '''</summary>
    <TestMethod()> _
    Public Sub listarInsumosPorCodigoTest()
        Dim insumo As Insumo = target.listarInsumosPorCodigo(1)

        Assert.AreEqual(Long.Parse(1), insumo.codInsumo)
        Assert.AreEqual("Rojo", insumo.color.color)
        Assert.AreEqual("hilo", insumo.tipoInsumo.descripcion)
        Assert.AreEqual(2, insumo.movimientosStock.Count)
        Assert.AreEqual(Double.Parse(10), insumo.movimientosStock(0).cantidad)
    End Sub

    '''<summary>
    '''A test for listarInsumosConRestricciones
    '''</summary>
    <TestMethod()> _
    Public Sub listarInsumosConRestriccionesTest()
        Dim nombre As String = "bre"
        Dim detalle As String = "lle1"
        Dim lista As List(Of Insumo) = target.listarInsumosConRestricciones(nombre, detalle, 1, 1)


        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codInsumo)
        Assert.AreEqual("Rojo", lista(0).color.color)
        Assert.AreEqual("hilo", lista(0).tipoInsumo.descripcion)
        Assert.AreEqual(2, lista(0).movimientosStock.Count)
        Assert.AreEqual(Double.Parse(10), lista(0).movimientosStock(0).cantidad)

    End Sub

    '''<summary>
    '''A test for listarInsumos
    '''</summary>
    <TestMethod()> _
    Public Sub listarInsumosTest()
        Dim lista As List(Of Insumo) = target.listarInsumos

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codInsumo)
        Assert.AreEqual("Rojo", lista(0).color.color)
        Assert.AreEqual("hilo", lista(0).tipoInsumo.descripcion)
        Assert.AreEqual(2, lista(0).movimientosStock.Count)
        Assert.AreEqual(Double.Parse(10), lista(0).movimientosStock(0).cantidad)
    End Sub

    '''<summary>
    '''A test for grabarInsumo
    '''</summary>
    <TestMethod()> _
    Public Sub grabarInsumoTest()
        Dim insumo As New Insumo(Nothing, "test creacion", "insumo repo test", 100, New TipoInsumo(1),
                                 New Color(1), New List(Of MovimientosStock), 5)

        Me.target.grabarInsumo(insumo)

        Dim insumoBase As Insumo = target.listarInsumosPorCodigo(5)

        Assert.AreEqual(Long.Parse(5), insumoBase.codInsumo)
        Assert.AreEqual("test creacion", insumoBase.nombre)
        Assert.AreEqual("insumo repo test", insumoBase.detalle)
        Assert.AreEqual("Rojo", insumoBase.color.color)
        Assert.AreEqual("hilo", insumoBase.tipoInsumo.descripcion)
        Assert.AreEqual(Double.Parse(5), insumoBase.costo)
        Assert.AreEqual(1, insumoBase.movimientosStock.Count)
        Assert.AreEqual(Long.Parse(1), insumoBase.movimientosStock(0).nroMovimiento)
        Assert.AreEqual(Double.Parse(100), insumoBase.movimientosStock(0).cantidad)
    End Sub

    '''<summary>
    '''A test for actualizarInsumo
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarInsumoTest()
        Dim insumo As New Insumo(Nothing, "test creacion", "insumo repo test", 100, New TipoInsumo(1), New Color(1), New List(Of MovimientosStock), 5)

        Me.target.grabarInsumo(insumo)

        Dim insumoBase As Insumo = target.listarInsumosPorCodigo(5)

        Assert.AreEqual(Long.Parse(5), insumoBase.codInsumo)
        Assert.AreEqual("test creacion", insumoBase.nombre)
        Assert.AreEqual("insumo repo test", insumoBase.detalle)
        Assert.AreEqual("Rojo", insumoBase.color.color)
        Assert.AreEqual("hilo", insumoBase.tipoInsumo.descripcion)
        Assert.AreEqual(1, insumoBase.movimientosStock.Count)
        Assert.AreEqual(Double.Parse(5), insumoBase.costo)
        Assert.AreEqual(Long.Parse(1), insumoBase.movimientosStock(0).nroMovimiento)
        Assert.AreEqual(Double.Parse(100), insumoBase.movimientosStock(0).cantidad)

        insumoBase.movimientosStock.Add(New MovimientosStock(Nothing, insumo, 150, DateTime.Now, New TipoMovimiento(1)))
        insumoBase.cantidadActual = 250

        target.actualizarInsumo(insumoBase)

        insumoBase = target.listarInsumosPorCodigo(5)

        Assert.AreEqual(Long.Parse(5), insumoBase.codInsumo)
        Assert.AreEqual("test creacion", insumoBase.nombre)
        Assert.AreEqual("insumo repo test", insumoBase.detalle)
        Assert.AreEqual("Rojo", insumoBase.color.color)
        Assert.AreEqual("hilo", insumoBase.tipoInsumo.descripcion)
        Assert.AreEqual(2, insumoBase.movimientosStock.Count)
        Assert.AreEqual(Long.Parse(1), insumoBase.movimientosStock(0).nroMovimiento)
        Assert.AreEqual(Double.Parse(100), insumoBase.movimientosStock(0).cantidad)
        Assert.AreEqual(Long.Parse(2), insumoBase.movimientosStock(1).nroMovimiento)
        Assert.AreEqual(Double.Parse(150), insumoBase.movimientosStock(1).cantidad)
        Assert.AreEqual(Double.Parse(250), insumoBase.cantidadActual)
    End Sub


    '''<summary>
    '''A test for disminuirStock
    '''</summary>
    <TestMethod()> _
    Public Sub disminuirStockTest()
        Dim idArticulo As Long = 1
        target.disminuirStock(idArticulo, 1)

        Dim insumo1 As Insumo = target.listarInsumosPorCodigo(1)
        Dim insumo2 As Insumo = target.listarInsumosPorCodigo(2)

        Assert.AreEqual(Double.Parse(0), insumo1.cantidadActual)
        Assert.AreEqual(Double.Parse(1), insumo2.cantidadActual)

    End Sub
End Class
