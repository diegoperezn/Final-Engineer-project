Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for MovimientoStockTDGTest and is intended
'''to contain all MovimientoStockTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MovimientoStockTDGTest


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
        Dim movimiento As New MovimientosStock(3, New Insumo(1), 15, Nothing, New TipoMovimiento(1))

        Me.target.borrar(movimiento)
    End Sub

#End Region

    Dim target As MovimientoStockTDG = RepositorioFactory.movimientoStockTDG

    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub cargarMovimientosTest()
        Dim fecha As New DateTime(2012, 10, 10)
        Dim lista As List(Of MovimientosStock) = Me.target.cargarMovimientos(Nothing)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).nroMovimiento)
        Assert.AreEqual(fecha, lista(0).fecha)
        Assert.AreEqual(Double.Parse(10), lista(0).cantidad)
        Assert.AreEqual(Long.Parse(1), lista(0).insumo.codInsumo)
    End Sub


    <TestMethod()> _
    Public Sub cargarMovimientosConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        Dim fecha As New DateTime(2012, 10, 10)

        criteria.Add(New Restriccion(MovimientoStockTDG.FECHA, fecha))
        criteria.Add(New Restriccion(MovimientoStockTDG.INSUMO, 1))
        criteria.Add(New Restriccion(MovimientoStockTDG.CANTIDAD, 10))
        criteria.Add(New Restriccion(MovimientoStockTDG.NRO_MOVIMIENTO, 1))
        Dim lista As List(Of MovimientosStock) = Me.target.cargarMovimientos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).nroMovimiento)
        Assert.AreEqual(fecha, lista(0).fecha)
        Assert.AreEqual(Double.Parse(10), lista(0).cantidad)
        Assert.AreEqual(Long.Parse(1), lista(0).insumo.codInsumo)
    End Sub


    <TestMethod()> _
    Public Sub grabarMovimientosTest()
        Dim insumo As New Insumo(1)
        Dim fecha As New DateTime(2012, 11, 11)
        Dim movimiento As New MovimientosStock(Nothing, insumo, 15, fecha, New TipoMovimiento(1))

        Me.target.grabar(movimiento)

        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(MovimientoStockTDG.INSUMO, 1))
        criteria.Add(New Restriccion(MovimientoStockTDG.NRO_MOVIMIENTO, 3))
        Dim mov As MovimientosStock = Me.target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(3), mov.nroMovimiento)
        Assert.AreEqual(fecha, mov.fecha)
        Assert.AreEqual(Double.Parse(15), mov.cantidad)
        Assert.AreEqual(Long.Parse(1), mov.insumo.codInsumo)
    End Sub

    <TestMethod()> _
    Public Sub actualizarMovimientosTest()
        Dim insumo As New Insumo(1)
        Dim fecha As New DateTime(2012, 11, 11)
        Dim movimiento As New MovimientosStock(Nothing, insumo, 15, fecha, New TipoMovimiento(1))

        Me.target.grabar(movimiento)

        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(MovimientoStockTDG.INSUMO, 1))
        criteria.Add(New Restriccion(MovimientoStockTDG.NRO_MOVIMIENTO, 3))
        Dim mov As MovimientosStock = Me.target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(3), mov.nroMovimiento)
        Assert.AreEqual(fecha, mov.fecha)
        Assert.AreEqual(Double.Parse(15), mov.cantidad)
        Assert.AreEqual(Long.Parse(1), mov.insumo.codInsumo)

        mov.cantidad = 18.3

        target.actualizar(mov)

        mov = Me.target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(3), mov.nroMovimiento)
        Assert.AreEqual(fecha, mov.fecha)
        Assert.AreEqual(Double.Parse(18.3), mov.cantidad)
        Assert.AreEqual(Long.Parse(1), mov.insumo.codInsumo)
    End Sub

    <TestMethod()> _
    Public Sub borrarMovimientosTest()
        Dim insumo As New Insumo(1)
        Dim fecha As New DateTime(2012, 11, 11)
        Dim movimiento As New MovimientosStock(Nothing, insumo, 15, fecha, New TipoMovimiento(1))

        Me.target.grabar(movimiento)

        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(MovimientoStockTDG.INSUMO, 1))
        criteria.Add(New Restriccion(MovimientoStockTDG.NRO_MOVIMIENTO, 3))
        Dim mov As MovimientosStock = Me.target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(3), mov.nroMovimiento)
        Assert.AreEqual(fecha, mov.fecha)
        Assert.AreEqual(Double.Parse(15), mov.cantidad)
        Assert.AreEqual(Long.Parse(1), mov.insumo.codInsumo)

        target.borrar(mov)

        mov = Me.target.buscarUnico(criteria)

        Assert.IsNull(mov)
    End Sub

End Class
