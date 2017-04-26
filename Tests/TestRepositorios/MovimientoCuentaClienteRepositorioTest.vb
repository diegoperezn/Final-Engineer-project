Imports System.Collections.Generic

Imports Dominio

Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for MovimientoCuentaClienteRepositorioTest and is intended
'''to contain all MovimientoCuentaClienteRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MovimientoCuentaClienteRepositorioTest


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

    Dim tdg As MovimientoCuentaClienteTDG = RepositorioFactory.movimientoCuentaClienteTDG
    Dim target As MovimientoCuentaClienteRepositorio = RepositorioFactory.movimientoCuentaClienteRepositorio
    
    <TestMethod()> _
    Public Sub buscarMovimintosTest()
        Dim com As String = "m1"
        Dim fecha As DateTime = New Date(2011, 11, 11)
        Dim cuenta As String = "1" ' TODO: Initialize to an appropriate value
        Dim tipo As String = "1" ' TODO: Initialize to an appropriate value
        Dim montoDesde As String = "5" ' TODO: Initialize to an appropriate value
        Dim montoHasta As String = "15" ' TODO: Initialize to an appropriate value

        Dim actual As List(Of MovimientosCuentaCliente)
        actual = target.buscarMovimientos(com, fecha, Nothing, cuenta, tipo, montoDesde, montoHasta, "1")

        Assert.AreEqual(1, actual.Count)
    End Sub

    '''<summary>
    '''A test for listarMovimientos
    '''</summary>
    <TestMethod()> _
    Public Sub listarMovimientosTest()
        Dim movimientos As List(Of MovimientosCuentaCliente) = target.listarMovimientos()

        Assert.AreEqual(2, movimientos.Count)
        Assert.AreEqual(Long.Parse(1), movimientos(0).nroMovimiento)
        Assert.AreEqual("com1", movimientos(0).comentario)
        Assert.IsNotNull(movimientos(0).fecha)
        Assert.AreEqual(Double.Parse(11), movimientos(0).monto)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cliente.idCliente)
        Assert.AreEqual("doc a cobrar", movimientos(0).cuenta.tipo)
        Assert.AreEqual(Double.Parse(11), movimientos(0).documento.monto)
    End Sub

    '''<summary>
    '''A test for grabarMovimiento
    '''</summary>
    <TestMethod()> _
    Public Sub grabarMovimientoTest()
        Dim MovimientosCuentaCliente As New MovimientosCuentaCliente(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Cliente(2))

        target.grabarMovimiento(MovimientosCuentaCliente)

        Dim movimiento As MovimientosCuentaCliente = target.buscarMovimientoPorNro(4)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(2), movimiento.cliente.idCliente)
    End Sub

    '''<summary>
    '''A test for actualizarMovimiento
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarMovimientoTest()
        Dim MovimientosCuentaCliente As New MovimientosCuentaCliente(Nothing, "com4", DateTime.Now, 33.3,
                                                                     New Cuenta(1), New TipoMovimiento(2), New Cliente(2))

        target.grabarMovimiento(MovimientosCuentaCliente)

        Dim movimiento As MovimientosCuentaCliente = target.buscarMovimientoPorNro(4)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(2), movimiento.cliente.idCliente)

        movimiento.cliente.idCliente = 1
        target.actualizarMovimiento(movimiento)

        movimiento = target.buscarMovimientoPorNro(4)

        Assert.AreEqual(Long.Parse(4), movimiento.nroMovimiento)
        Assert.AreEqual("com4", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(33.3), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(2), movimiento.tipoMovimiento.tipoMovimiento)
        Assert.AreEqual(Long.Parse(1), movimiento.cliente.idCliente)
    End Sub

    '''<summary>
    '''A test for listarMovimientosPorCliente
    '''</summary>
    <TestMethod()> _
    Public Sub listarMovimientosPorClienteTest()
        Dim movimientos As List(Of MovimientosCuentaCliente) = target.listarMovimientosPorCliente(1)

        Assert.AreEqual(2, movimientos.Count)
        Assert.AreEqual(Long.Parse(1), movimientos(0).nroMovimiento)
        Assert.AreEqual("com1", movimientos(0).comentario)
        Assert.IsNotNull(movimientos(0).fecha)
        Assert.AreEqual(Double.Parse(11), movimientos(0).monto)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimientos(0).cliente.idCliente)
    End Sub


    '''<summary>
    '''A test for listarMovimientosPorNro
    '''</summary>
    <TestMethod()> _
    Public Sub listarMovimientosPorNroTest()
        Dim movimiento As MovimientosCuentaCliente = target.buscarMovimientoPorNro(1)

        Assert.AreEqual(Long.Parse(1), movimiento.nroMovimiento)
        Assert.AreEqual("com1", movimiento.comentario)
        Assert.IsNotNull(movimiento.fecha)
        Assert.AreEqual(Double.Parse(11), movimiento.monto)
        Assert.AreEqual(Long.Parse(1), movimiento.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), movimiento.cliente.idCliente)
    End Sub
End Class
