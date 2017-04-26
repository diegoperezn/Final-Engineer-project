Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for OrdenDeCompraTDGTest and is intended
'''to contain all OrdenDeCompraTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OrdenDeCompraTDGTest


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
        dao.saveOrUpdate("delete " + OrdenDeCompraTDG.NOMBRE_TABLA + " where nro_doc=5")
        dao.saveOrUpdate("delete " + OrdenDeCompraTDG.TABLA_DOCUMENTO + " where nro_doc=5")
    End Sub

#End Region


    Dim target As OrdenDeCompraTDG = RepositorioFactory.ordenDeCompraTDG
    Dim dao As DataAccesObject = RepositorioFactory.dao

    '''<summary>
    '''A test for cargarOrdenesDeCompras
    '''</summary>
    <TestMethod()> _
    Public Sub cargarOrdenesDeComprasTest()
        Dim lista As List(Of OrdenDeCompra) = target.cargarOrdenesDeCompras(Nothing)

        Assert.AreEqual(2, lista.Count)

        Assert.AreEqual(Long.Parse(1), lista(0).nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), lista(0).nroSucursal)
        Assert.AreEqual("A", lista(0).tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(11), lista(0).iva)
        Assert.IsNotNull(lista(0).fecha)
        Assert.AreEqual(Long.Parse(1), lista(0).proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(3), lista(0).nroDocumento)
        Assert.AreEqual(Long.Parse(3), lista(0).movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, lista(0).lineaOrdenDeCompra.Count)
    End Sub

    '''<summary>
    '''A test for cargarFacturas
    '''</summary>
    <TestMethod()> _
    Public Sub cargarOrdenConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(OrdenDeCompraTDG.BORRADO, False))
        criteria.Add(New Restriccion(OrdenDeCompraTDG.PROVEEDOR, 1))
        criteria.Add(New Restriccion(OrdenDeCompraTDG.FECHA, "2011-11-11"))
        criteria.Add(New Restriccion(OrdenDeCompraTDG.IVA, 11))
        criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_DOCUMENTO, 3))
        criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_ORDEN_DE_COMPRA, 1))
        criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_SUCURSAL, 1))
        criteria.Add(New Restriccion(OrdenDeCompraTDG.TIPO_ORDEN_DE_COMPRA, "A"))

        Dim orden As OrdenDeCompra = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), orden.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), orden.nroSucursal)
        Assert.AreEqual("A", orden.tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(11), orden.iva)
        Assert.IsNotNull(orden.fecha)
        Assert.AreEqual(Long.Parse(1), orden.proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(3), orden.nroDocumento)
        Assert.AreEqual(Long.Parse(3), orden.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, orden.lineaOrdenDeCompra.Count)
    End Sub

    '''<summary>
    '''A test for cargarFacturas
    '''</summary>
    <TestMethod()> _
    Public Sub grabarFacturasTest()
        Dim movimiento As New MovimientosCuentaCliente()
        Dim factura As New OrdenDeCompra(Nothing, movimiento, 33.3, 33.3, DateTime.Now, False, Nothing, 1, "A", New Proveedor(2), Nothing)

        target.grabar(factura)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_DOCUMENTO, 5))
        Dim ordenes As List(Of OrdenDeCompra) = target.cargarOrdenesDeCompras(criteria)

        Assert.AreEqual(1, ordenes.Count)

        Assert.AreEqual(Long.Parse(2), ordenes(0).nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), ordenes(0).nroSucursal)
        Assert.AreEqual("A", ordenes(0).tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(33.3), ordenes(0).iva)
        Assert.IsNotNull(ordenes(0).fecha)
        Assert.AreEqual(Long.Parse(2), ordenes(0).proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(5), ordenes(0).nroDocumento)
        Assert.IsNull(ordenes(0).movimientoCuenta)
        Assert.AreEqual(0, ordenes(0).lineaOrdenDeCompra.Count)
        Assert.AreEqual(Double.Parse(33.3), ordenes(0).monto)
    End Sub


    '''<summary>
    '''A test for cargarFacturas
    '''</summary>
    <TestMethod()> _
    Public Sub modificarFacturasTest()
        Dim movimiento As New MovimientosCuentaCliente()
        Dim factura As New OrdenDeCompra(Nothing, movimiento, 33.3, 33.3, DateTime.Now, False, Nothing, 1, "A", New Proveedor(2), Nothing)

        target.grabar(factura)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_DOCUMENTO, 5))
        Dim ordenes As List(Of OrdenDeCompra) = target.cargarOrdenesDeCompras(criteria)

        Assert.AreEqual(1, ordenes.Count)

        Assert.AreEqual(Long.Parse(2), ordenes(0).nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), ordenes(0).nroSucursal)
        Assert.AreEqual("A", ordenes(0).tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(33.3), ordenes(0).iva)
        Assert.AreEqual(Double.Parse(33.3), ordenes(0).monto)
        Assert.IsNotNull(ordenes(0).fecha)
        Assert.AreEqual(Long.Parse(2), ordenes(0).proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(5), ordenes(0).nroDocumento)
        Assert.IsNull(ordenes(0).movimientoCuenta)
        Assert.AreEqual(0, ordenes(0).lineaOrdenDeCompra.Count)

        Dim ordenbase As OrdenDeCompra = ordenes(0)
        ordenbase.iva = 25.5

        target.actualizar(ordenbase)

        ordenes = target.cargarOrdenesDeCompras(criteria)

        Assert.AreEqual(1, ordenes.Count)

        Assert.AreEqual(Long.Parse(2), ordenes(0).nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), ordenes(0).nroSucursal)
        Assert.AreEqual("A", ordenes(0).tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(25.5), ordenes(0).iva)
        Assert.IsNotNull(ordenes(0).fecha)
        Assert.AreEqual(Long.Parse(2), ordenes(0).proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(5), ordenes(0).nroDocumento)
        Assert.IsNull(ordenes(0).movimientoCuenta)
        Assert.AreEqual(0, ordenes(0).lineaOrdenDeCompra.Count)
    End Sub

End Class
