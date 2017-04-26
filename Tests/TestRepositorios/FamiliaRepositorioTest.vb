Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for FamiliaRepositorioTest and is intended
'''to contain all FamiliaRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class FamiliaRepositorioTest


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


    Dim target As FamiliaRepositorio = RepositorioFactory.familiaRepositorio

    '''<summary>
    '''A test for actualizarFamilia
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarFamiliaTest()
        Dim patente As New Patente(9, "Listado de patentes", "Listado de patentes")

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.ID_FAMILIA, 5, Restriccion.CONDICION_IGUAL))
        Dim familia As Familia = target.cargarFamilia(criteria)

        familia.nombre = "nombretest"
        familia.descripcion = "desTest"
        familia.patentes.Add(patente)

        target.actualizarFamilia(familia)

        familia = target.cargarFamiliasPorId(familia.idFamilia)

        Assert.AreEqual(Long.Parse(5), familia.idFamilia)
        Assert.AreEqual("desTest", familia.descripcion)
        Assert.AreEqual("nombretest", familia.nombre)

        Assert.AreEqual(Long.Parse(9), familia.patentes(0).patenteId)
        Assert.AreEqual(1, familia.patentes.Count)

        Dim familiaOriginal As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")
        target.actualizarFamilia(familia)
    End Sub

    '''<summary>
    '''A test for borrarFamilia
    '''</summary>
    <TestMethod()> _
    Public Sub borrarFamiliaTest()
        Dim patente As New Patente(9, "Listado de patentes", "Listado de patentes")
        Dim familia As New Familia(7, "familia test", "test")
        familia.patentes.Add(patente)

        target.guardarFamilia(familia)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.ID_FAMILIA, 7, Restriccion.CONDICION_IGUAL))
        Dim actual As Familia = target.cargarFamilia(criteria)

        Assert.AreEqual(Long.Parse(7), actual.idFamilia)
        Assert.AreEqual("familia test", actual.descripcion)
        Assert.AreEqual("test", actual.nombre)

        Assert.AreEqual(Long.Parse(9), actual.patentes(0).patenteId)
        Assert.AreEqual(1, actual.patentes.Count)

        target.borrarFamilia(familia)

        actual = target.cargarFamilia(criteria)
        Assert.IsNull(actual)
    End Sub

    '''<summary>
    '''A test for cargarFamiliasPorId
    '''</summary>
    <TestMethod()> _
    Public Sub cargarFamiliasPorIdTest()
        Dim familia As Familia = target.cargarFamiliasPorId(6)
        Assert.AreEqual(Long.Parse(6), familia.idFamilia)
        Assert.AreEqual("Administracion de los usuarios", familia.descripcion)
        Assert.AreEqual("Administracion usuarios", familia.nombre)
        Assert.AreEqual(8, familia.patentes.Count)
    End Sub

    '''<summary>
    '''A test for cargarFamiliasPorUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub cargarFamiliasPorUsuarioTest()
        Dim usuario As New Usuario
        usuario.id = 3
        Dim actual As List(Of Familia) = target.cargarFamiliasPorUsuario(Usuario)
        Assert.AreEqual(Long.Parse(6), actual(0).idFamilia)
        Assert.AreEqual("Administracion de los usuarios", actual(0).descripcion)
        Assert.AreEqual("Administracion usuarios", actual(0).nombre)
        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(8, actual(0).patentes.Count)
    End Sub

    '''<summary>
    '''A test for guardarFamilia
    '''</summary>
    <TestMethod()> _
    Public Sub guardarFamiliaTest()
        Dim patente As New Patente(9, "Listado de patentes", "Listado de patentes")
        Dim familia As New Familia(7, "familia test", "test")
        familia.patentes.Add(patente)

        target.guardarFamilia(familia)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.NOMBRE, "test", Restriccion.CONDICION_IGUAL))
        Dim actual As Familia = target.cargarFamilia(criteria)

        Assert.AreEqual(Long.Parse(7), actual.idFamilia)
        Assert.AreEqual("familia test", actual.descripcion)
        Assert.AreEqual("test", actual.nombre)

        Assert.AreEqual(Long.Parse(9), actual.patentes(0).patenteId)
        Assert.AreEqual(1, actual.patentes.Count)

        target.borrarFamilia(familia)
    End Sub
End Class
