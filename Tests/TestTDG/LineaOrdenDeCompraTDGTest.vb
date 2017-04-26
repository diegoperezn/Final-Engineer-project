Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for LineaOrdenDeCompraTDGTest and is intended
'''to contain all LineaOrdenDeCompraTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class LineaOrdenDeCompraTDGTest


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
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region

    Dim target As LineaOrdenDeCompraTDG = RepositorioFactory.lineaOrdenDeCompraTDG

    '''<summary>
    '''A test for cargarLineasFactura
    '''</summary>
    <TestMethod()> _
    Public Sub cargarLineasFacturaTest()
        Dim lista As List(Of LineaOrdenDeCompra) = target.cargarLineasOrdenDeCompra(Nothing)

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).ordenDeCompra.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), lista(0).ordenDeCompra.nroSucursal)
        Assert.AreEqual("A", lista(0).ordenDeCompra.tipoOrdenCompra)
        Assert.AreEqual(Long.Parse(1), lista(0).nroLinea)
        Assert.AreEqual(Long.Parse(1), lista(0).articulo.codInsumo)
        Assert.AreEqual(10, lista(0).cantidad)
        Assert.AreEqual(Double.Parse(10), lista(0).precio)
        Assert.AreEqual(False, lista(0).borrado)
    End Sub

    '''<summary>
    '''A test for cargarLineasFactura
    '''</summary>
    <TestMethod()> _
    Public Sub cargarLineasFacturaConRestriccionTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.ARTICULO, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.BORRADO, False))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.CANTIDAD, 10))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_ORDEN, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_LINEA, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_SUCURSAL, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.PRECIO, 10))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.TIPO_ORDEN, "A"))

        Dim linea As LineaOrdenDeCompra = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroSucursal)
        Assert.AreEqual("A", linea.ordenDeCompra.tipoOrdenCompra)
        Assert.AreEqual(Long.Parse(1), linea.nroLinea)
        Assert.AreEqual(Long.Parse(1), linea.articulo.codInsumo)
        Assert.AreEqual(10, linea.cantidad)
        Assert.AreEqual(Double.Parse(10), linea.precio)
        Assert.AreEqual(False, linea.borrado)
    End Sub

    '''<summary>
    '''A test for cargarLineasFactura
    '''</summary>
    <TestMethod()> _
    Public Sub grabarLineaTest()
        Dim lineaNueva As New LineaOrdenDeCompra(Nothing, New Insumo(3), 33, 33.3, New OrdenDeCompra(1, 1, "A"), False)

        target.grabar(lineaNueva)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_ORDEN, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_LINEA, 3))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_SUCURSAL, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.TIPO_ORDEN, "A"))

        Dim linea As LineaOrdenDeCompra = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroSucursal)
        Assert.AreEqual("A", linea.ordenDeCompra.tipoOrdenCompra)
        Assert.AreEqual(Long.Parse(3), linea.nroLinea)
        Assert.AreEqual(Long.Parse(3), linea.articulo.codInsumo)
        Assert.AreEqual(33, linea.cantidad)
        Assert.AreEqual(33.3, linea.precio)
        Assert.AreEqual(False, linea.borrado)

        target.borrar(linea)
    End Sub

    '''<summary>
    '''A test for cargarLineasFactura
    '''</summary>
    <TestMethod()> _
    Public Sub modificarLineaTest()
        Dim lineaNueva As New LineaOrdenDeCompra(Nothing, New Insumo(3), 33, 33.3, New OrdenDeCompra(1, 1, "A"), False)

        target.grabar(lineaNueva)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_ORDEN, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_LINEA, 3))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_SUCURSAL, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.TIPO_ORDEN, "A"))

        Dim linea As LineaOrdenDeCompra = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroSucursal)
        Assert.AreEqual("A", linea.ordenDeCompra.tipoOrdenCompra)
        Assert.AreEqual(Long.Parse(3), linea.nroLinea)
        Assert.AreEqual(Long.Parse(3), linea.articulo.codInsumo)
        Assert.AreEqual(33, linea.cantidad)
        Assert.AreEqual(33.3, linea.precio)
        Assert.AreEqual(False, linea.borrado)

        linea.precio = 10
        target.actualizar(linea)

        linea = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroSucursal)
        Assert.AreEqual("A", linea.ordenDeCompra.tipoOrdenCompra)
        Assert.AreEqual(Long.Parse(3), linea.nroLinea)
        Assert.AreEqual(Long.Parse(3), linea.articulo.codInsumo)
        Assert.AreEqual(33, linea.cantidad)
        Assert.AreEqual(Double.Parse(10), linea.precio)
        Assert.AreEqual(False, linea.borrado)

        target.borrar(linea)
    End Sub

    '''<summary>
    '''A test for cargarLineasFactura
    '''</summary>
    <TestMethod()> _
    Public Sub borrarLineaTest()
        Dim lineaNueva As New LineaOrdenDeCompra(Nothing, New Insumo(3), 33, 33.3, New OrdenDeCompra(1, 1, "A"), False)

        target.grabar(lineaNueva)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_ORDEN, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_LINEA, 3))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_SUCURSAL, 1))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.TIPO_ORDEN, "A"))

        Dim linea As LineaOrdenDeCompra = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroOrdenCompra)
        Assert.AreEqual(Long.Parse(1), linea.ordenDeCompra.nroSucursal)
        Assert.AreEqual("A", linea.ordenDeCompra.tipoOrdenCompra)
        Assert.AreEqual(Long.Parse(3), linea.nroLinea)
        Assert.AreEqual(Long.Parse(3), linea.articulo.codInsumo)
        Assert.AreEqual(33, linea.cantidad)
        Assert.AreEqual(33.3, linea.precio)
        Assert.AreEqual(False, linea.borrado)

        target.borrar(linea)

        linea = target.buscarUnico(criteria)

        Assert.IsNull(linea)
    End Sub

End Class
