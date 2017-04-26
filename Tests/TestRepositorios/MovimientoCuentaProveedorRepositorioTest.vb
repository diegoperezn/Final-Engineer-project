Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for MovimientoCuentaProveedorRepositorioTest and is intended
'''to contain all MovimientoCuentaProveedorRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MovimientoCuentaProveedorRepositorioTest


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
        Dim MovimientosCuentaCliente As New MovimientosCuentaCliente(4)
        tdg.borrar(MovimientosCuentaCliente)
    End Sub

#End Region

    Dim tdg As MovimientoCuentaProveedorTDG = RepositorioFactory.movimientoCuentaProveedorTDG
    Dim target As MovimientoCuentaProveedorRepositorio = RepositorioFactory.movimientoCuentaProveedorRepositorio

    '''<summary>
    '''A test for buscarMovimientoPorNro
    '''</summary>
    <TestMethod()> _
    Public Sub buscarMovimientoPorNroTest()
        Dim movimiento As MovimientosCuentaProveedor = target.buscarMovimientoPorNro(3)

        Assert.AreEqual(Long.Parse(3), movimiento.nroMovimiento)
        Assert.AreEqual("com3", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimiento.proveedor.codProveedor)
        Assert.AreEqual("nombre1", movimiento.proveedor.nombre)
    End Sub

    '''<summary>
    '''A test for buscarMovimintos
    '''</summary>
    <TestMethod()> _
    Public Sub buscarMovimintosTest()
        Dim com As String = "m3"
        Dim fecha As DateTime = New Date(2003, 3, 3)
        Dim cuenta As String = "1" ' TODO: Initialize to an appropriate value
        Dim tipo As String = "1" ' TODO: Initialize to an appropriate value
        Dim montoDesde As String = "30" ' TODO: Initialize to an appropriate value
        Dim montoHasta As String = "33" ' TODO: Initialize to an appropriate value

        Dim actual As List(Of MovimientosCuentaProveedor)
        actual = target.buscarMovimientos(com, fecha, Nothing, cuenta, tipo, montoDesde, montoHasta, 1)

        Assert.AreEqual(1, actual.Count)
    End Sub

    '''<summary>
    '''A test for actualizarMovimiento
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarMovimientoTest()
        Dim MovimientosCuenta As New MovimientosCuentaProveedor(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Proveedor(3))

        target.grabarMovimiento(MovimientosCuenta)

        Dim movimiento As MovimientosCuentaProveedor = target.buscarMovimientoPorNro(4)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(3), movimiento.proveedor.codProveedor)
        Assert.AreEqual("nombre3", movimiento.proveedor.nombre)

        movimiento.proveedor.codProveedor = 1
        target.actualizarMovimiento(movimiento)

        movimiento = target.buscarMovimientoPorNro(4)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(1), movimiento.proveedor.codProveedor)
        Assert.AreEqual("nombre1", movimiento.proveedor.nombre)
    End Sub

    '''<summary>
    '''A test for grabarMovimiento
    '''</summary>
    <TestMethod()> _
    Public Sub grabarMovimientoTest()
        Dim MovimientosCuentaCliente As New MovimientosCuentaProveedor(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Proveedor(3))

        target.grabarMovimiento(MovimientosCuentaCliente)

        Dim movimiento As MovimientosCuentaProveedor = target.buscarMovimientoPorNro(4)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(3), movimiento.proveedor.codProveedor)
    End Sub

    '''<summary>
    '''A test for listarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub listarMovimientosTest()
        Dim movimientos As List(Of MovimientosCuentaProveedor) = target.listarMovimientos()

        Assert.AreEqual(1, movimientos.Count)
        Assert.AreEqual(Long.Parse(3), movimientos(0).nroMovimiento)
        Assert.AreEqual("com3", movimientos(0).comentario)
        Assert.IsNotNull(movimientos(0).fecha)
        Assert.AreEqual(Double.Parse(33), movimientos(0).monto)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimientos(0).proveedor.codProveedor)
        Assert.AreEqual("nombre1", movimientos(0).proveedor.nombre)
    End Sub

    '''<summary>
    '''A test for listarMovimientosPorProveedor
    '''</summary>
    <TestMethod()> _
    Public Sub listarMovimientosPorProveedorTest()
        Dim movimientos As List(Of MovimientosCuentaProveedor) = target.listarMovimientosPorProveedor(1)

        Assert.AreEqual(1, movimientos.Count)
        Assert.AreEqual(Long.Parse(3), movimientos(0).nroMovimiento)
        Assert.AreEqual("com3", movimientos(0).comentario)
        Assert.IsNotNull(movimientos(0).fecha)
        Assert.AreEqual(Double.Parse(33), movimientos(0).monto)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimientos(0).proveedor.codProveedor)
    End Sub
End Class
