Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for ProveedorTDGTest and is intended
'''to contain all ProveedorTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ProveedorTDGTest


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

    '1	nombre1	1111-1111	direccion 1
    '2	nombre2	2222-2222	direccion 2
    '3	nombre3	3333-3333	direccion 3

    Dim target As ProveedorTDG = RepositorioFactory.proveedorTDG()

    <TestMethod()> _
    Public Sub buscarTodoTest()
        Dim lista As List(Of Proveedor)
        lista = target.buscarLista(Nothing)

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

    <TestMethod()> _
    Public Sub buscarPorIdTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ProveedorTDG.COD_PROVEEDOR, 1, Restriccion.CONDICION_IGUAL))
        Dim proveedor As Proveedor = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), proveedor.codProveedor)
        Assert.AreEqual("nombre1", proveedor.nombre)
        Assert.AreEqual("1111-1111", proveedor.telefono)
        Assert.AreEqual("direccion 1", proveedor.direccion)
    End Sub

    <TestMethod()> _
    Public Sub buscarPorDescripcionTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ProveedorTDG.NOMBRE, "nombre2", Restriccion.CONDICION_IGUAL))
        criteria.Add(New Restriccion(ProveedorTDG.TELEFONO, "2222-2222", Restriccion.CONDICION_IGUAL))
        criteria.Add(New Restriccion(ProveedorTDG.DIRECCION, "direccion 2", Restriccion.CONDICION_IGUAL))
        Dim lista As List(Of Proveedor) = target.buscarLista(criteria)

        Assert.AreEqual(Long.Parse(2), lista(0).codProveedor)
        Assert.AreEqual("nombre2", lista(0).nombre)
        Assert.AreEqual("2222-2222", lista(0).telefono)
        Assert.AreEqual("direccion 2", lista(0).direccion)

        Assert.AreEqual(1, lista.Count)
    End Sub

    <TestMethod()> _
    Public Sub actualizarProveedorTest()
        Dim proveedor As Proveedor = New Proveedor(1, "nombre1modificado", "15-1111-1111", "direccion 1 modificado", Nothing)
        target.actualizar(Proveedor)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ProveedorTDG.COD_PROVEEDOR, 1, Restriccion.CONDICION_IGUAL))
        Dim pro As Proveedor = target.buscarUnico(criterio)

        Assert.AreEqual(Long.Parse(1), pro.codProveedor)
        Assert.AreEqual("nombre1modificado", pro.nombre)
        Assert.AreEqual("15-1111-1111", pro.telefono)
        Assert.AreEqual("direccion 1 modificado", pro.direccion)

        proveedor = New Proveedor(1, "nombre1", "1111-1111", "direccion 1", Nothing)
        target.actualizar(Proveedor)
    End Sub

    <TestMethod()> _
    Public Sub grabarProveedorTest()
        Dim proveedor As Proveedor = New Proveedor(4, "nombre4", "4444-4444", "direccion 4", Nothing)
        target.grabar(Proveedor)

        Dim lista As List(Of Proveedor)
        lista = target.buscarLista(Nothing)

        Assert.AreEqual(Long.Parse(1), lista(0).codProveedor)
        Assert.AreEqual(Long.Parse(2), lista(1).codProveedor)
        Assert.AreEqual(Long.Parse(3), lista(2).codProveedor)
        Assert.AreEqual(Long.Parse(4), lista(3).codProveedor)
        Assert.AreEqual("nombre1", lista(0).nombre)
        Assert.AreEqual("nombre2", lista(1).nombre)
        Assert.AreEqual("nombre3", lista(2).nombre)
        Assert.AreEqual("nombre4", lista(3).nombre)
        Assert.AreEqual("1111-1111", lista(0).telefono)
        Assert.AreEqual("2222-2222", lista(1).telefono)
        Assert.AreEqual("3333-3333", lista(2).telefono)
        Assert.AreEqual("4444-4444", lista(3).telefono)
        Assert.AreEqual("direccion 1", lista(0).direccion)
        Assert.AreEqual("direccion 2", lista(1).direccion)
        Assert.AreEqual("direccion 3", lista(2).direccion)
        Assert.AreEqual("direccion 4", lista(3).direccion)
        Assert.AreEqual(4, lista.Count)

        target.borrar(Proveedor)
    End Sub

    <TestMethod()> _
    Public Sub borrarProveedorTest()
        Dim proveedor As Proveedor = New Proveedor(4, "nombre4", "4444-4444", "direccion 4", Nothing)
        target.grabar(proveedor)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ProveedorTDG.COD_PROVEEDOR, 4, Restriccion.CONDICION_IGUAL))

        Dim prov As Proveedor = target.buscarUnico(criterio)

        Assert.IsNotNull(prov)

        proveedor = New Proveedor()
        proveedor.codProveedor = 4
        target.borrar(proveedor)

        prov = target.buscarUnico(criterio)

        Assert.IsNull(prov)
    End Sub

End Class
