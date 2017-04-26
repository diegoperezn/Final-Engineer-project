Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for FacturaTDGTest and is intended
'''to contain all FacturaTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class FacturaTDGTest


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
        dao.saveOrUpdate("delete " + FacturaTDG.NOMBRE_TABLA + " where nro_doc=5")
        dao.saveOrUpdate("delete " + FacturaTDG.TABLA_DOCUMENTO + " where nro_doc=5")
    End Sub
    '
#End Region

    Dim target As FacturaTDG = RepositorioFactory.facturaTDG
    Dim dao As DataAccesObject = RepositorioFactory.dao

    '''<summary>
    '''A test for cargarFacturas
    '''</summary>
    <TestMethod()> _
    Public Sub cargarFacturasTest()
        Dim facturas As List(Of Factura) = target.cargarFacturas(Nothing)

        Assert.AreEqual(2, facturas.Count)

        Assert.AreEqual(Long.Parse(1), facturas(0).nroFactura)
        Assert.AreEqual(Long.Parse(1), facturas(0).nroSucursal)
        Assert.AreEqual("A", facturas(0).tipoFactura)
        Assert.AreEqual(Double.Parse(11), facturas(0).iva)
        Assert.IsNotNull(facturas(0).fecha)
        Assert.AreEqual(Long.Parse(1), facturas(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), facturas(0).nroDocumento)
        Assert.AreEqual(Long.Parse(1), facturas(0).movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, facturas(0).lineas.Count)
    End Sub

    '''<summary>
    '''A test for cargarFacturas
    '''</summary>
    <TestMethod()> _
    Public Sub cargarFacturasConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FacturaTDG.BORRADO, False))
        criteria.Add(New Restriccion(FacturaTDG.CLIENTE, 1))
        criteria.Add(New Restriccion(FacturaTDG.FECHA, "2011-11-11"))
        criteria.Add(New Restriccion(FacturaTDG.IVA, 11))
        criteria.Add(New Restriccion(FacturaTDG.NRO_DOCUMENTO, 1))
        criteria.Add(New Restriccion(FacturaTDG.NRO_FACTURA, 1))
        criteria.Add(New Restriccion(FacturaTDG.NRO_SUCURSAL, 1))
        criteria.Add(New Restriccion(FacturaTDG.TIPO_FACTURA, "A"))
        criteria.Add(New Restriccion(FacturaTDG.NRO_DOCUMENTO, 1))

        Dim facturas As List(Of Factura) = target.cargarFacturas(criteria)

        Assert.AreEqual(1, facturas.Count)

        Assert.AreEqual(Long.Parse(1), facturas(0).nroFactura)
        Assert.AreEqual(Long.Parse(1), facturas(0).nroSucursal)
        Assert.AreEqual("A", facturas(0).tipoFactura)
        Assert.AreEqual(Double.Parse(11), facturas(0).iva)
        Assert.IsNotNull(facturas(0).fecha)
        Assert.AreEqual(Long.Parse(1), facturas(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), facturas(0).nroDocumento)
        Assert.AreEqual(Long.Parse(1), facturas(0).movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, facturas(0).lineas.Count)
    End Sub

    '''<summary>
    '''A test for cargarFacturas
    '''</summary>
    <TestMethod()> _
    Public Sub grabarFacturasTest()
        Dim movimiento As New MovimientosCuentaCliente()
        Dim factura As New Factura(Nothing, movimiento, 33.3, 33.3, DateTime.Now, False, Nothing, 1, "A", New Cliente(2), Nothing)

        target.grabar(factura)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FacturaTDG.NRO_DOCUMENTO, 5))
        Dim facturas As List(Of Factura) = target.cargarFacturas(criteria)

        Assert.AreEqual(1, facturas.Count)

        Assert.AreEqual(Long.Parse(2), facturas(0).nroFactura)
        Assert.AreEqual(Long.Parse(1), facturas(0).nroSucursal)
        Assert.AreEqual("A", facturas(0).tipoFactura)
        Assert.AreEqual(Double.Parse(33.3), facturas(0).iva)
        Assert.IsNotNull(facturas(0).fecha)
        Assert.AreEqual(Long.Parse(2), facturas(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(5), facturas(0).nroDocumento)
        Assert.IsNull(facturas(0).movimientoCuenta)
        Assert.AreEqual(0, facturas(0).lineas.Count)
        Assert.AreEqual(Double.Parse(33.3), facturas(0).monto)
    End Sub


    '''<summary>
    '''A test for cargarFacturas
    '''</summary>
    <TestMethod()> _
    Public Sub modificarFacturasTest()
        Dim movimiento As New MovimientosCuentaCliente()
        Dim factura As New Factura(Nothing, movimiento, 33.3, 33.3, DateTime.Now, False, Nothing, 1, "A", New Cliente(2), Nothing)

        target.grabar(factura)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FacturaTDG.NRO_DOCUMENTO, 5))
        Dim facturas As List(Of Factura) = target.cargarFacturas(criteria)

        Assert.AreEqual(1, facturas.Count)

        Assert.AreEqual(Long.Parse(2), facturas(0).nroFactura)
        Assert.AreEqual(Long.Parse(1), facturas(0).nroSucursal)
        Assert.AreEqual("A", facturas(0).tipoFactura)
        Assert.AreEqual(Double.Parse(33.3), facturas(0).iva)
        Assert.IsNotNull(facturas(0).fecha)
        Assert.AreEqual(Long.Parse(2), facturas(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(5), facturas(0).nroDocumento)
        Assert.IsNull(facturas(0).movimientoCuenta)
        Assert.AreEqual(0, facturas(0).lineas.Count)
        Assert.AreEqual(Double.Parse(33.3), facturas(0).monto)

        Dim facturabase As Factura = facturas(0)
        facturabase.iva = 25.5

        target.actualizar(facturabase)

        facturas = target.cargarFacturas(criteria)

        Assert.AreEqual(1, facturas.Count)

        Assert.AreEqual(Long.Parse(2), facturas(0).nroFactura)
        Assert.AreEqual(Long.Parse(1), facturas(0).nroSucursal)
        Assert.AreEqual("A", facturas(0).tipoFactura)
        Assert.AreEqual(Double.Parse(25.5), facturas(0).iva)
        Assert.IsNotNull(facturas(0).fecha)
        Assert.AreEqual(Long.Parse(2), facturas(0).cliente.idCliente)
        Assert.AreEqual(Long.Parse(5), facturas(0).nroDocumento)
        Assert.IsNull(facturas(0).movimientoCuenta)
        Assert.AreEqual(0, facturas(0).lineas.Count)
        Assert.AreEqual(Double.Parse(33.3), facturas(0).monto)
    End Sub

End Class
