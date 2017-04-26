Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for FacturaBusinessTest and is intended
'''to contain all FacturaBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class FacturaBusinessTest


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
        Dim mov As New MovimientosCuentaCliente(4, "com test", Nothing, 100, New Cuenta(1), New TipoMovimiento(1), Nothing)
        Dim factura As New Factura(Nothing, mov, 1.1, 100, Nothing, False, 2, 1, "A", Nothing, Nothing)
        Dim linea As New LineaFactura(1, New Articulo(2), 10, 2, factura, False)
        Dim linea2 As New LineaFactura(2, New Articulo(2), 10, 2, factura, False)

        LineaFacturaTDG.borrar(linea)
        LineaFacturaTDG.borrar(linea2)
        Me.movimientoTdg.borrar(mov)
        Me.dao.saveOrUpdate("DELETE FROM " + FacturaTDG.NOMBRE_TABLA + " WHERE " + FacturaTDG.NRO_DOCUMENTO.columna + " =5")
        Me.dao.saveOrUpdate("delete " + FacturaTDG.TABLA_DOCUMENTO + " where nro_doc=5")
    End Sub

#End Region

    Dim target As FacturaBusiness = BusinessFactory.facturaBusiness
    Dim dao As DataAccesObject = RepositorioFactory.dao
    Dim lineaFacturaTdg As LineaFacturaTDG = RepositorioFactory.lineaFacturaTDG
    Dim movimientoTdg As MovimientoCuentaClienteTDG = RepositorioFactory.movimientoCuentaClienteTDG

    '''<summary>
    '''A test for listarFacturasPorMovimiento
    '''</summary>
    <TestMethod()> _
    Public Sub listarFacturaPorMovimientoTest()
        Dim mov As New MovimientosCuentaCliente()
        mov.documento = New Documento(1)
        Dim factura As Factura = target.listarFacturasPorMovimiento(mov)

        Assert.AreEqual(Long.Parse(1), factura.nroFactura)
        Assert.AreEqual(Long.Parse(1), factura.nroSucursal)
        Assert.AreEqual("A", factura.tipoFactura)
        Assert.AreEqual(Double.Parse(11), factura.iva)
        Assert.IsNotNull(factura.fecha)
        Assert.AreEqual(Long.Parse(1), factura.cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), factura.nroDocumento)
        Assert.AreEqual(Long.Parse(1), factura.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, factura.lineas.Count)
        Assert.AreEqual("com1", factura.lineas(0).articulo.comentario)
        Assert.AreEqual("nombre1", factura.cliente.nombre)
        Assert.AreEqual(Double.Parse(11), factura.movimientoCuenta.monto)
    End Sub


    '''<summary>
    '''A test for listarFacturasPorCliente
    '''</summary>
    <TestMethod()> _
    Public Sub listarFacturasPorClienteTest()
        Dim cliente As New Cliente()
        cliente.idCliente = 1
        Dim facturas As List(Of Factura) = target.listarFacturasPorCliente(cliente)

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
        Assert.AreEqual("com1", facturas(0).lineas(0).articulo.comentario)
        Assert.AreEqual("nombre1", facturas(0).cliente.nombre)
        Assert.AreEqual(Double.Parse(11), facturas(0).movimientoCuenta.monto)
    End Sub

    '''<summary>
    '''A test for listarFacturas
    '''</summary>
    <TestMethod()> _
    Public Sub listarFacturasTest()
        Dim facturas As List(Of Factura) = target.listarFacturas

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
        Assert.AreEqual("com1", facturas(0).lineas(0).articulo.comentario)
        Assert.AreEqual("nombre1", facturas(0).cliente.nombre)
        Assert.AreEqual(Double.Parse(11), facturas(0).movimientoCuenta.monto)
    End Sub

    '''<summary>
    '''A test for listarFacturasPorId
    '''</summary>
    <TestMethod()> _
    Public Sub listarFacturasPorIdTest()
        Dim factura As Factura = target.listarFacturasPorId(1, 1, "A")

        Assert.AreEqual(Long.Parse(1), factura.nroFactura)
        Assert.AreEqual(Long.Parse(1), factura.nroSucursal)
        Assert.AreEqual("A", factura.tipoFactura)
        Assert.AreEqual(Double.Parse(11), factura.iva)
        Assert.IsNotNull(factura.fecha)
        Assert.AreEqual(Long.Parse(1), factura.cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), factura.nroDocumento)
        Assert.AreEqual(Long.Parse(1), factura.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, factura.lineas.Count)
        Assert.AreEqual("com1", factura.lineas(0).articulo.comentario)
        Assert.AreEqual("nombre1", factura.cliente.nombre)
        Assert.AreEqual(Double.Parse(11), factura.movimientoCuenta.monto)
    End Sub


    '''<summary>
    '''A test for grabarFactura
    '''</summary>
    <TestMethod()> _
    Public Sub grabarFacturaTest()
        Dim cliente As New Cliente(2)
        Dim fecha As New DateTime(2012, 10, 13, 21, 44, 12)
        Dim mov As New MovimientosCuentaCliente(Nothing, "com test", fecha, 100, New Cuenta(1), New TipoMovimiento(1), cliente)
        Dim lineas As New List(Of LineaFactura)
        lineas.Add(New LineaFactura(Nothing, New Articulo(2), 10, 50, Nothing, False))
        Dim factura As New Factura(Nothing, mov, 1.1, 100, fecha, False, Nothing, 1, "A", Cliente, lineas)

        target.grabarFactura(factura)

        Dim facturaBase As Factura = target.listarFacturasPorId(2, 1, "A")

        Assert.AreEqual(Long.Parse(2), facturaBase.nroFactura)
        Assert.AreEqual(Long.Parse(1), facturaBase.nroSucursal)
        Assert.AreEqual("A", facturaBase.tipoFactura)
        Assert.AreEqual(Double.Parse(1.1), facturaBase.iva)
        Assert.AreEqual(fecha, facturaBase.fecha)
        Assert.AreEqual(Long.Parse(2), facturaBase.cliente.idCliente)
        Assert.AreEqual(Long.Parse(5), facturaBase.nroDocumento)
        Assert.AreEqual(Long.Parse(4), facturaBase.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(1, facturaBase.lineas.Count)
        Assert.AreEqual("com2", facturaBase.lineas(0).articulo.comentario)
        Assert.AreEqual(Double.Parse(50), facturaBase.lineas(0).precio)
        Assert.AreEqual("nombre2", facturaBase.cliente.nombre)
        Assert.AreEqual(Double.Parse(100), facturaBase.movimientoCuenta.monto)
        Assert.AreEqual("com test", facturaBase.movimientoCuenta.comentario)
        Assert.AreEqual(Long.Parse(1), facturaBase.movimientoCuenta.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), facturaBase.movimientoCuenta.tipoMovimiento.tipoMovimiento)
    End Sub

    '''<summary>
    '''A test for actualizaFactura
    '''</summary>
    <TestMethod()> _
    Public Sub actualizaFacturaTest()
        Dim cliente As New Cliente(2)
        Dim fecha As New DateTime(2012, 10, 13, 21, 44, 12)
        Dim mov As New MovimientosCuentaCliente(Nothing, "com test", fecha, 100, New Cuenta(1), New TipoMovimiento(1), cliente)
        Dim lineas As New List(Of LineaFactura)
        lineas.Add(New LineaFactura(Nothing, New Articulo(2), 10, Nothing, Nothing, False))
        Dim factura As New Factura(Nothing, mov, 1.1, 100, fecha, False, Nothing, 1, "A", cliente, lineas)

        target.grabarFactura(factura)

        Dim facturaBase As Factura = target.listarFacturasPorId(2, 1, "A")

        Assert.AreEqual(Long.Parse(2), facturaBase.nroFactura)
        Assert.AreEqual(Long.Parse(1), facturaBase.nroSucursal)
        Assert.AreEqual("A", facturaBase.tipoFactura)
        Assert.AreEqual(Double.Parse(1.1), facturaBase.iva)
        Assert.AreEqual(fecha, facturaBase.fecha)
        Assert.AreEqual(Long.Parse(2), facturaBase.cliente.idCliente)
        Assert.AreEqual(Long.Parse(5), facturaBase.nroDocumento)
        Assert.AreEqual(Long.Parse(4), facturaBase.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(1, facturaBase.lineas.Count)
        Assert.AreEqual("com2", facturaBase.lineas(0).articulo.comentario)
        Assert.AreEqual(10, facturaBase.lineas(0).cantidad)
        Assert.AreEqual("nombre2", facturaBase.cliente.nombre)
        Assert.AreEqual(Double.Parse(100), facturaBase.movimientoCuenta.monto)
        Assert.AreEqual("com test", facturaBase.movimientoCuenta.comentario)
        Assert.AreEqual(Long.Parse(1), facturaBase.movimientoCuenta.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), facturaBase.movimientoCuenta.tipoMovimiento.tipoMovimiento)

        facturaBase.lineas(0).cantidad = 15
        Dim articulo As New Articulo(1)
        articulo.precioActual = 2.1
        facturaBase.lineas.Add(New LineaFactura(Nothing, articulo, 10, Nothing, facturaBase, False))
        facturaBase.monto = 111
        facturaBase.movimientoCuenta.monto = 111

        target.actualizaFactura(facturaBase)

        facturaBase = target.listarFacturasPorId(2, 1, "A")

        Assert.AreEqual(Long.Parse(2), facturaBase.nroFactura)
        Assert.AreEqual(Long.Parse(1), facturaBase.nroSucursal)
        Assert.AreEqual("A", facturaBase.tipoFactura)
        Assert.AreEqual(Double.Parse(1.1), facturaBase.iva)
        Assert.AreEqual(fecha, facturaBase.fecha)
        Assert.AreEqual(Long.Parse(2), facturaBase.cliente.idCliente)
        Assert.AreEqual(Long.Parse(5), facturaBase.nroDocumento)
        Assert.AreEqual(Long.Parse(4), facturaBase.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, facturaBase.lineas.Count)
        Assert.AreEqual("com2", facturaBase.lineas(0).articulo.comentario)
        Assert.AreEqual(Double.Parse(2.1), facturaBase.lineas(1).precio)
        Assert.AreEqual("nombre2", facturaBase.cliente.nombre)
        Assert.AreEqual(15, facturaBase.lineas(0).cantidad)
        Assert.AreEqual(Double.Parse(111), facturaBase.monto)
        Assert.AreEqual(Double.Parse(111), facturaBase.movimientoCuenta.monto)
        Assert.AreEqual("com test", facturaBase.movimientoCuenta.comentario)
        Assert.AreEqual(Long.Parse(1), facturaBase.movimientoCuenta.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), facturaBase.movimientoCuenta.tipoMovimiento.tipoMovimiento)
    End Sub
End Class
