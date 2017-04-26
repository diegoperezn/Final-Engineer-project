Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for OrdenCompraBusinessTest and is intended
'''to contain all OrdenCompraBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OrdenCompraBusinessTest


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
        Dim mov As New MovimientosCuentaProveedor(4, "com test", Nothing, 100, New Cuenta(1), New TipoMovimiento(1), Nothing)
        Dim orden As New OrdenDeCompra(Nothing, mov, 1.1, 100, Nothing, False, 2, 1, "A", Nothing, Nothing)
        Dim linea As New LineaOrdenDeCompra(1, New Insumo(2), 10, 2, orden, False)
        Dim linea2 As New LineaOrdenDeCompra(2, New Insumo(2), 10, 2, orden, False)

        lineaOrdenTdg.borrar(linea)
        lineaOrdenTdg.borrar(linea2)
        Me.movimientoTdg.borrar(mov)
        Me.dao.saveOrUpdate("DELETE FROM " + OrdenDeCompraTDG.NOMBRE_TABLA + " WHERE " + FacturaTDG.NRO_DOCUMENTO.columna + " =5")
        Me.dao.saveOrUpdate("delete " + OrdenDeCompraTDG.TABLA_DOCUMENTO + " where nro_doc=5")
    End Sub

#End Region

    Dim target As OrdenCompraBusiness = BusinessFactory.ordenCompraBusiness
    Dim dao As DataAccesObject = RepositorioFactory.dao
    Dim lineaOrdenTdg As LineaOrdenDeCompraTDG = RepositorioFactory.lineaOrdenDeCompraTDG
    Dim movimientoTdg As MovimientoCuentaProveedorTDG = RepositorioFactory.movimientoCuentaProveedorTDG

    '''<summary>
    '''A test for listarOrdenDeComprasPorMovimiento
    '''</summary>
    <TestMethod()> _
    Public Sub listarOrdenDeComprasPorMovimientoTest()
        Dim mov As New MovimientosCuentaCliente()
        mov.documento = New Documento(3)
        Dim orden As OrdenDeCompra = target.listarOrdenDeComprasPorMovimiento(mov)

        Assert.AreEqual(Long.Parse(1), orden.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), orden.nroSucursal)
        Assert.AreEqual("A", orden.tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(11), orden.iva)
        Assert.IsNotNull(orden.fecha)
        Assert.AreEqual(Long.Parse(1), orden.proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(3), orden.nroDocumento)
        Assert.AreEqual(Long.Parse(3), orden.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, orden.lineaOrdenDeCompra.Count)
        Assert.AreEqual(10, orden.lineaOrdenDeCompra(0).cantidad)
        Assert.AreEqual(Double.Parse(33), orden.movimientoCuenta.monto)
        Assert.AreEqual("nombre1", orden.proveedor.nombre)
    End Sub

    '''<summary>
    '''A test for listarOrdenDeComprasPorId
    '''</summary>
    <TestMethod()> _
    Public Sub listarOrdenDeComprasPorIdTest()
        Dim orden As OrdenDeCompra = target.listarOrdenDeComprasPorId(1, 1, "A")

        Assert.AreEqual(Long.Parse(1), orden.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), orden.nroSucursal)
        Assert.AreEqual("A", orden.tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(11), orden.iva)
        Assert.IsNotNull(orden.fecha)
        Assert.AreEqual(Long.Parse(1), orden.proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(3), orden.nroDocumento)
        Assert.AreEqual(Long.Parse(3), orden.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, orden.lineaOrdenDeCompra.Count)
        Assert.AreEqual(10, orden.lineaOrdenDeCompra(0).cantidad)
        Assert.AreEqual(Double.Parse(33), orden.movimientoCuenta.monto)
        Assert.AreEqual("nombre1", orden.proveedor.nombre)
    End Sub

    '''<summary>
    '''A test for listarOrdenDeComprasPorCliente
    '''</summary>
    <TestMethod()> _
    Public Sub listarOrdenDeComprasPorProveedorTest()
        Dim prov As New Proveedor(1)
        Dim ordenes As List(Of OrdenDeCompra) = target.listarOrdenDeComprasPorProveedor(prov)

        Assert.AreEqual(2, ordenes.Count)
        Assert.AreEqual(Long.Parse(1), ordenes(0).nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), ordenes(0).nroSucursal)
        Assert.AreEqual("A", ordenes(0).tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(11), ordenes(0).iva)
        Assert.IsNotNull(ordenes(0).fecha)
        Assert.AreEqual(Long.Parse(1), ordenes(0).proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(3), ordenes(0).nroDocumento)
        Assert.AreEqual(Long.Parse(3), ordenes(0).movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, ordenes(0).lineaOrdenDeCompra.Count)
        Assert.AreEqual(10, ordenes(0).lineaOrdenDeCompra(0).cantidad)
        Assert.AreEqual(Double.Parse(33), ordenes(0).movimientoCuenta.monto)
        Assert.AreEqual("nombre1", ordenes(0).proveedor.nombre)
    End Sub

    '''<summary>
    '''A test for listarOrdenDeCompras
    '''</summary>
    <TestMethod()> _
    Public Sub listarOrdenDeComprasTest()
        Dim ordenes As List(Of OrdenDeCompra) = target.listarOrdenDeCompras

        Assert.AreEqual(2, ordenes.Count)
        Assert.AreEqual(Long.Parse(1), ordenes(0).nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), ordenes(0).nroSucursal)
        Assert.AreEqual("A", ordenes(0).tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(11), ordenes(0).iva)
        Assert.IsNotNull(ordenes(0).fecha)
        Assert.AreEqual(Long.Parse(1), ordenes(0).proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(3), ordenes(0).nroDocumento)
        Assert.AreEqual(Long.Parse(3), ordenes(0).movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, ordenes(0).lineaOrdenDeCompra.Count)
        Assert.AreEqual(10, ordenes(0).lineaOrdenDeCompra(0).cantidad)
        Assert.AreEqual(Double.Parse(33), ordenes(0).movimientoCuenta.monto)
        Assert.AreEqual("nombre1", ordenes(0).proveedor.nombre)
    End Sub

    '''<summary>
    '''A test for grabarOrdenDeCompra
    '''</summary>
    <TestMethod()> _
    Public Sub grabarOrdenDeCompraTest()
        Dim prov As New Proveedor(2)
        Dim fecha As New DateTime(2012, 10, 13, 21, 44, 12)
        Dim mov As New MovimientosCuentaProveedor(Nothing, "com test", fecha, 100, New Cuenta(1), New TipoMovimiento(1), prov)
        Dim lineas As New List(Of LineaOrdenDeCompra)
        lineas.Add(New LineaOrdenDeCompra(Nothing, New Insumo(2), 10, 50, Nothing, False))
        Dim orden As New OrdenDeCompra(Nothing, mov, 1.1, 100, fecha, False, Nothing, 1, "A", prov, lineas)

        target.grabarOrdenDeCompra(orden)

        Dim ordenBase As OrdenDeCompra = target.listarOrdenDeComprasPorId(2, 1, "A")

        Assert.AreEqual(Long.Parse(2), ordenBase.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), ordenBase.nroSucursal)
        Assert.AreEqual("A", ordenBase.tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(1.1), ordenBase.iva)
        Assert.IsNotNull(ordenBase.fecha)
        Assert.AreEqual(Long.Parse(2), ordenBase.proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(5), ordenBase.nroDocumento)
        Assert.AreEqual(Long.Parse(4), ordenBase.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(1, ordenBase.lineaOrdenDeCompra.Count)
        Assert.AreEqual(10, ordenBase.lineaOrdenDeCompra(0).cantidad)
        Assert.AreEqual(Double.Parse(100), ordenBase.movimientoCuenta.monto)
        Assert.AreEqual("nombre2", ordenBase.proveedor.nombre)
        Assert.AreEqual("com test", ordenBase.movimientoCuenta.comentario)
        Assert.AreEqual(Long.Parse(1), ordenBase.movimientoCuenta.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), ordenBase.movimientoCuenta.tipoMovimiento.tipoMovimiento)
    End Sub

    '''<summary>
    '''A test for actualizaOrdenDeCompra
    '''</summary>
    <TestMethod()> _
    Public Sub actualizaOrdenDeCompraTest()
        Dim prov As New Proveedor(2)
        Dim fecha As New DateTime(2012, 10, 13, 21, 44, 12)
        Dim mov As New MovimientosCuentaProveedor(Nothing, "com test", fecha, 100, New Cuenta(1), New TipoMovimiento(1), prov)
        Dim lineas As New List(Of LineaOrdenDeCompra)
        lineas.Add(New LineaOrdenDeCompra(Nothing, New Insumo(2), 10, 50, Nothing, False))
        Dim orden As New OrdenDeCompra(Nothing, mov, 1.1, 100, fecha, False, Nothing, 1, "A", prov, lineas)

        target.grabarOrdenDeCompra(orden)

        Dim ordenBase As OrdenDeCompra = target.listarOrdenDeComprasPorId(2, 1, "A")

        Assert.AreEqual(Long.Parse(2), ordenBase.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), ordenBase.nroSucursal)
        Assert.AreEqual("A", ordenBase.tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(1.1), ordenBase.iva)
        Assert.IsNotNull(ordenBase.fecha)
        Assert.AreEqual(Long.Parse(2), ordenBase.proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(5), ordenBase.nroDocumento)
        Assert.AreEqual(Long.Parse(4), ordenBase.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(1, ordenBase.lineaOrdenDeCompra.Count)
        Assert.AreEqual(10, ordenBase.lineaOrdenDeCompra(0).cantidad)
        Assert.AreEqual(Double.Parse(100), ordenBase.movimientoCuenta.monto)
        Assert.AreEqual("nombre2", ordenBase.proveedor.nombre)
        Assert.AreEqual("com test", ordenBase.movimientoCuenta.comentario)
        Assert.AreEqual(Long.Parse(1), ordenBase.movimientoCuenta.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), ordenBase.movimientoCuenta.tipoMovimiento.tipoMovimiento)

        ordenBase.lineaOrdenDeCompra(0).cantidad = 15
        ordenBase.lineaOrdenDeCompra.Add(New LineaOrdenDeCompra(Nothing, New Insumo(1), 10, Nothing, ordenBase, False))
        ordenBase.monto = 111
        ordenBase.movimientoCuenta.monto = 111

        target.actualizaOrdenDeCompra(ordenBase)

        ordenBase = target.listarOrdenDeComprasPorId(2, 1, "A")

        Assert.AreEqual(Long.Parse(2), ordenBase.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), ordenBase.nroSucursal)
        Assert.AreEqual("A", ordenBase.tipoOrdenCompra)
        Assert.AreEqual(Double.Parse(1.1), ordenBase.iva)
        Assert.IsNotNull(ordenBase.fecha)
        Assert.AreEqual(Long.Parse(2), ordenBase.proveedor.codProveedor)
        Assert.AreEqual(Long.Parse(5), ordenBase.nroDocumento)
        Assert.AreEqual(Long.Parse(4), ordenBase.movimientoCuenta.nroMovimiento)
        Assert.AreEqual(2, ordenBase.lineaOrdenDeCompra.Count)
        Assert.AreEqual(15, ordenBase.lineaOrdenDeCompra(0).cantidad)
        Assert.AreEqual(10, ordenBase.lineaOrdenDeCompra(1).cantidad)
        Assert.AreEqual(Double.Parse(111), ordenBase.movimientoCuenta.monto)
        Assert.AreEqual(Double.Parse(111), ordenBase.monto)
        Assert.AreEqual("nombre2", ordenBase.proveedor.nombre)
        Assert.AreEqual("com test", ordenBase.movimientoCuenta.comentario)
        Assert.AreEqual(Long.Parse(1), ordenBase.movimientoCuenta.cuenta.codCuenta)
        Assert.AreEqual(Long.Parse(1), ordenBase.movimientoCuenta.tipoMovimiento.tipoMovimiento)
    End Sub

End Class
