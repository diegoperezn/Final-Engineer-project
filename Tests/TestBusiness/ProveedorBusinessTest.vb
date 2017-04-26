Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for ProveedorBusinessTest and is intended
'''to contain all ProveedorBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ProveedorBusinessTest


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
        Dim proveedor As Proveedor = New Proveedor(4, "nombre4", "4444-4444", "direccion 4", Nothing)
        tdg.borrar(proveedor)
        proveedor = New Proveedor(1, "nombre1", "1111-1111", "direccion 1", New List(Of OrdenDeCompra))
        target.actualizar(proveedor)
    End Sub

#End Region

    Dim target As ProveedorBusiness = BusinessFactory.proveedorBusiness
    Dim tdg As ProveedorTDG = RepositorioFactory.proveedorTDG
    Dim dao As DataAccesObject = RepositorioFactory.dao

    '''<summary>
    '''A test for grabar
    '''</summary>
    <TestMethod()> _
    Public Sub grabarTest()
        Dim ordenes As New List(Of OrdenDeCompra)
        ordenes.Add(New OrdenDeCompra(Nothing, Nothing, 33.3, 33.3, DateTime.Now, False, Nothing, 1, "A", New Proveedor(4), Nothing))
        Dim proveedor As Proveedor = New Proveedor(4, "nombre4", "4444-4444", "direccion 4", ordenes)

        target.grabar(proveedor)

        Dim lista As List(Of Proveedor)
        lista = target.listarProveedores()

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual(Long.Parse(4), lista(3).codProveedor)
        Assert.AreEqual("nombre4", lista(3).nombre)
        Assert.AreEqual("4444-4444", lista(3).telefono)
        Assert.AreEqual("direccion 4", lista(3).direccion)
        Assert.AreEqual(1, lista(3).ordenesDeCompra.Count)
        Assert.AreEqual(Double.Parse(33.3), lista(3).ordenesDeCompra(0).iva)
        Assert.AreEqual(Double.Parse(33.3), lista(3).ordenesDeCompra(0).monto)
    End Sub

    '''<summary>
    '''A test for buscarProveedorPorCodigo
    '''</summary>
    <TestMethod()> _
    Public Sub buscarProveedorPorCodigoTest()
        Dim proveedor As Proveedor = target.buscarProveedorPorCodigo(1)

        Assert.AreEqual(Long.Parse(1), proveedor.codProveedor)
        Assert.AreEqual("nombre1", proveedor.nombre)
        Assert.AreEqual("1111-1111", proveedor.telefono)
        Assert.AreEqual("direccion 1", proveedor.direccion)
        Assert.AreEqual(Double.Parse(11), proveedor.ordenesDeCompra(0).iva)
    End Sub

    '''<summary>
    '''A test for actualizar
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarTest()
        Dim proveedor As Proveedor = New Proveedor(1, "nombre1modificado", "15-1111-1111", "direccion 1 modificado", Nothing)
        target.actualizar(proveedor)

        Dim pro As Proveedor = target.buscarProveedorPorCodigo(1)

        Assert.AreEqual(Long.Parse(1), pro.codProveedor)
        Assert.AreEqual("nombre1modificado", pro.nombre)
        Assert.AreEqual("15-1111-1111", pro.telefono)
        Assert.AreEqual("direccion 1 modificado", pro.direccion)
    End Sub

    '''<summary>
    '''A test for buscarProveedoresPorNombre
    '''</summary>
    <TestMethod()> _
    Public Sub buscarProveedoresPorNombreTest()
        Dim lista As List(Of Proveedor) = target.buscarProveedoresPorNombre("nomb")

        Assert.AreEqual(Long.Parse(2), lista(1).codProveedor)
        Assert.AreEqual("nombre2", lista(1).nombre)
        Assert.AreEqual("2222-2222", lista(1).telefono)
        Assert.AreEqual("direccion 2", lista(1).direccion)

        Assert.AreEqual(3, lista.Count)
    End Sub

    '''<summary>
    '''A test for listarProveedores
    '''</summary>
    <TestMethod()> _
    Public Sub listarProveedoresTest()
        Dim lista As List(Of Proveedor)
        lista = target.listarProveedores()

        Assert.AreEqual(Long.Parse(1), lista(0).codProveedor)
        Assert.AreEqual(Long.Parse(2), lista(1).codProveedor)
        Assert.AreEqual(Long.Parse(3), lista(2).codProveedor)
        Assert.AreEqual("nombre1", lista(0).nombre)
        Assert.AreEqual("nombre2", lista(1).nombre)
        Assert.AreEqual("nombre3", lista(2).nombre)
        Assert.AreEqual("1111-1111", lista(0).telefono)
        Assert.AreEqual("2222-2222", lista(1).telefono)
        Assert.AreEqual("3333-3333", lista(2).telefono)
        Assert.AreEqual("direccion 1", lista(0).direccion)
        Assert.AreEqual("direccion 2", lista(1).direccion)
        Assert.AreEqual("direccion 3", lista(2).direccion)

        Assert.AreEqual(3, lista.Count)
    End Sub
End Class
