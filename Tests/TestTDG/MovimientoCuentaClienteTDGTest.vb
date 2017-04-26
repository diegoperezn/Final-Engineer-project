Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for MovimientoCuentaClienteTDGTest and is intended
'''to contain all MovimientoCuentaClienteTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MovimientoCuentaClienteTDGTest


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
        target.borrar(MovimientosCuentaCliente)
    End Sub

#End Region

    Dim target As MovimientoCuentaClienteTDG = RepositorioFactory.movimientoCuentaClienteTDG

    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub cargarMovimientosTest()
        Dim movimientos As List(Of MovimientosCuentaCliente) = target.cargarMovimientos(Nothing)

        Assert.AreEqual(2, movimientos.Count)
        Assert.AreEqual(Long.Parse(1), movimientos(0).nroMovimiento)
        Assert.AreEqual("com1", movimientos(0).comentario)
        Assert.IsNotNull(movimientos(0).fecha)
        Assert.AreEqual(Double.Parse(11), movimientos(0).monto)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cliente.idCliente)
    End Sub


    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub cargarMovimientosConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.NRO_MOVIMIENTO, 1))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.COMENTARIO, "m1", Restriccion.CONDICION_LIKE))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.FECHA, "2011-11-11"))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.MONTO, 5, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.MONTO, 15, Restriccion.CONDICION_MENOR_IGUAL))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.CUENTA, 1))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.TIPO_MOVIMIENTO, 1))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.CLIENTE, 1, Restriccion.CONDICION_IGUAL))

        Dim movimientos As List(Of MovimientosCuentaCliente) = target.cargarMovimientos(criteria)

        Assert.AreEqual(1, movimientos.Count)
        Assert.AreEqual(Long.Parse(1), movimientos(0).nroMovimiento)
        Assert.AreEqual("com1", movimientos(0).comentario)
        Assert.IsNotNull(movimientos(0).fecha)
        Assert.AreEqual(Double.Parse(11), movimientos(0).monto)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cliente.idCliente)
    End Sub

    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub grabarMovimientosClienteTest()
        Dim MovimientosCuentaCliente As New MovimientosCuentaCliente(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Cliente(2))

        target.grabar(MovimientosCuentaCliente)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.NRO_MOVIMIENTO, 4))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.MONTO, 33.3))
        Dim movimiento As MovimientosCuentaCliente = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(2), movimiento.cliente.idCliente)
    End Sub

    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub modificarMovimientosClienteTest()
        Dim MovimientosCuentaCliente As New MovimientosCuentaCliente(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Cliente(2))

        target.grabar(MovimientosCuentaCliente)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.NRO_MOVIMIENTO, 4))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.MONTO, 33.3))
        Dim movimiento As MovimientosCuentaCliente = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(2), movimiento.cliente.idCliente)

        movimiento.cliente.idCliente = 1
        target.actualizar(movimiento)

        movimiento = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(1), movimiento.cliente.idCliente)
    End Sub

    '''<summary>
    '''A test for cargarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub borrarMovimientosClienteTest()
        Dim MovimientosCuentaCliente As New MovimientosCuentaCliente(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Cliente(2))

        target.grabar(MovimientosCuentaCliente)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.NRO_MOVIMIENTO, 4))
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.MONTO, 33.3))
        Dim movimiento As MovimientosCuentaCliente = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(2), movimiento.cliente.idCliente)

        target.borrar(movimiento)

        movimiento = target.buscarUnico(criteria)

        Assert.IsNull(movimiento)
    End Sub

End Class
