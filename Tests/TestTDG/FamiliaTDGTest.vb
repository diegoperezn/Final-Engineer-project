Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for FamiliaTDGTest and is intended
'''to contain all FamiliaTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class FamiliaTDGTest


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

    Dim target As FamiliaTDG = RepositorioFactory.familiaTDG

    <TestMethod()> _
    Public Sub cargarFamiliasTest()
        Dim actual As List(Of Familia) = target.cargarFamilias(Nothing)
        Assert.AreEqual(6, actual.Count)
        Assert.AreEqual(8, actual(5).patentes.Count)
    End Sub


    <TestMethod()> _
    Public Sub cargarFamiliasPorPatenteTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.PATENTES, 4, Restriccion.CONDICION_IGUAL))
        Dim actual As List(Of Familia) = target.cargarFamilias(criteria)
        Assert.AreEqual(Long.Parse(6), actual(0).idFamilia)
        Assert.AreEqual("Administracion de los usuarios", actual(0).descripcion)
        Assert.AreEqual("Administracion usuarios", actual(0).nombre)
        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(8, actual(0).patentes.Count)
    End Sub

    <TestMethod()> _
    Public Sub cargarFamiliasPorIdTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.ID_FAMILIA, 6, Restriccion.CONDICION_IGUAL))
        Dim actual As List(Of Familia) = target.cargarFamilias(criteria)
        Assert.AreEqual(Long.Parse(6), actual(0).idFamilia)
        Assert.AreEqual("Administracion de los usuarios", actual(0).descripcion)
        Assert.AreEqual("Administracion usuarios", actual(0).nombre)
        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(8, actual(0).patentes.Count)
    End Sub

    <TestMethod()> _
    Public Sub cargarFamiliasPorUsuarioTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.USUARIO, 3, Restriccion.CONDICION_IGUAL))
        Dim actual As List(Of Familia) = target.cargarFamilias(criteria)
        Assert.AreEqual(Long.Parse(6), actual(0).idFamilia)
        Assert.AreEqual("Administracion de los usuarios", actual(0).descripcion)
        Assert.AreEqual("Administracion usuarios", actual(0).nombre)
        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(8, actual(0).patentes.Count)
    End Sub

    <TestMethod()> _
    Public Sub grabarFamiliaTest()
        Dim patente As New Patente(9, "Listado de patentes", "Listado de patentes")
        Dim familia As New Familia(7, "familia test", "test")
        familia.patentes.Add(patente)

        target.grabar(familia)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.ID_FAMILIA, 7, Restriccion.CONDICION_IGUAL))
        Dim actual As Familia = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(7), actual.idFamilia)
        Assert.AreEqual("familia test", actual.descripcion)
        Assert.AreEqual("test", actual.nombre)

        Assert.AreEqual(Long.Parse(9), actual.patentes(0).patenteId)
        Assert.AreEqual(1, actual.patentes.Count)

        target.borrar(familia)
    End Sub

    <TestMethod()> _
    Public Sub agregarPatenteTest()
        Dim patente As New Patente(9, "Listado de patentes", "Listado de patentes")

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.ID_FAMILIA, 5, Restriccion.CONDICION_IGUAL))
        Dim actual As Familia = target.buscarUnico(criteria)

        actual.nombre = "nombretest"
        actual.descripcion = "desTest"
        actual.patentes.Add(patente)

        target.actualizar(actual)

        actual = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(5), actual.idFamilia)
        Assert.AreEqual("desTest", actual.descripcion)
        Assert.AreEqual("nombretest", actual.nombre)

        Assert.AreEqual(Long.Parse(9), actual.patentes(0).patenteId)
        Assert.AreEqual(1, actual.patentes.Count)

        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")
        target.actualizar(familia)
    End Sub

    <TestMethod()> _
    Public Sub borrarFamiliaTest()
        Dim patente As New Patente(9, "Listado de patentes", "Listado de patentes")
        Dim familia As New Familia(7, "familia test", "test")
        familia.patentes.Add(patente)

        target.grabar(familia)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.ID_FAMILIA, 7, Restriccion.CONDICION_IGUAL))
        Dim actual As Familia = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(7), actual.idFamilia)
        Assert.AreEqual("familia test", actual.descripcion)
        Assert.AreEqual("test", actual.nombre)

        Assert.AreEqual(Long.Parse(9), actual.patentes(0).patenteId)
        Assert.AreEqual(1, actual.patentes.Count)

        target.borrar(familia)

        actual = target.buscarUnico(criteria)
        Assert.IsNull(actual)
    End Sub

End Class
