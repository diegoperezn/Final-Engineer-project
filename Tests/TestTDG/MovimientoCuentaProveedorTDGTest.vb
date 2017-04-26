Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for MovimientoCuentaProveedorTDGTest and is intended
'''to contain all MovimientoCuentaProveedorTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MovimientoCuentaProveedorTDGTest


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
        Dim movimiento As New MovimientosCuentaProveedor(4, "com4", DateTime.Now, 33.3,
                                                              New Cuenta(1), New TipoMovimiento(2), New Proveedor(2))
        target.borrar(movimiento)
    End Sub

#End Region


    Dim target As MovimientoCuentaProveedorTDG = RepositorioFactory.MovimientoCuentaProveedorTDG

    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub cargarMovimientosTest()
        Dim movimientos As List(Of MovimientosCuentaProveedor) = target.cargarMovimientos(Nothing)

        Assert.AreEqual(1, movimientos.Count)
        Assert.AreEqual(Long.Parse(3), movimientos(0).nroMovimiento)
        Assert.AreEqual("com3", movimientos(0).comentario)
        Assert.IsNotNull(movimientos(0).fecha)
        Assert.AreEqual(Double.Parse(33), movimientos(0).monto)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimientos(0).proveedor.codProveedor)
    End Sub


    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub cargarMovimientosConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.NRO_MOVIMIENTO, 3))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.COMENTARIO, "m3", Restriccion.CONDICION_LIKE))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.FECHA, "2003-03-03"))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.MONTO, 5, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.MONTO, 50, Restriccion.CONDICION_MENOR_IGUAL))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.CUENTA, 1))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.TIPO_MOVIMIENTO, 1))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.PROVEEDOR, 1, Restriccion.CONDICION_IGUAL))

        Dim movimientos As List(Of MovimientosCuentaProveedor) = target.cargarMovimientos(criteria)

        Assert.AreEqual(1, movimientos.Count)
        Assert.AreEqual(Long.Parse(3), movimientos(0).nroMovimiento)
        Assert.AreEqual("com3", movimientos(0).comentario)
        Assert.IsNotNull(movimientos(0).fecha)
        Assert.AreEqual(Double.Parse(33), movimientos(0).monto)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimientos(0).proveedor.codProveedor)
    End Sub

    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub grabarMovimientosClienteTest()
        Dim MovimientoCuentaProveedor As New MovimientosCuentaProveedor(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Proveedor(2))

        target.grabar(MovimientoCuentaProveedor)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.NRO_MOVIMIENTO, 4))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.MONTO, 33.3))
        Dim movimiento As MovimientosCuentaProveedor = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(2), movimiento.proveedor.codProveedor)
    End Sub

    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub modificarMovimientosClienteTest()
        Dim MovimientoCuentaProveedor As New MovimientosCuentaProveedor(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Proveedor(2))

        target.grabar(MovimientoCuentaProveedor)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.NRO_MOVIMIENTO, 4))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.MONTO, 33.3))
        Dim movimiento As MovimientosCuentaProveedor = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(2), movimiento.proveedor.codProveedor)

        movimiento.proveedor.codProveedor = 3
        target.actualizar(movimiento)

        movimiento = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(3), movimiento.proveedor.codProveedor)
    End Sub

    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub borrarMovimientosClienteTest()
        Dim MovimientoCuentaProveedor As New MovimientosCuentaProveedor(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Proveedor(2))

        target.grabar(MovimientoCuentaProveedor)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.NRO_MOVIMIENTO, 4))
        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.MONTO, 33.3))
        Dim movimiento As MovimientosCuentaProveedor = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(2), movimiento.proveedor.codProveedor)

        target.borrar(movimiento)

        movimiento = target.buscarUnico(criteria)

        Assert.IsNull(movimiento)
    End Sub

End Class
