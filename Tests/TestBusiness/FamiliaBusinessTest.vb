Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for FamiliaBusinessTest and is intended
'''to contain all FamiliaBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class FamiliaBusinessTest


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

    Dim target As FamiliaBusiness = BusinessFactory.familiaBusiness

    '''<summary>
    '''A test for actualizarFamilia
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarFamiliaTest()
        Dim patentes As New List(Of Patente)
        patentes.Add(New Patente(9, "Listado de patentes", "Listado de patentes"))
        Dim familia As Familia = target.cargarFamiliaPorId(2)

        target.actualizarFamilia(familia.idFamilia, "nombretest", "desTest", patentes)

        Dim nuevaFamilia As Familia = target.cargarFamiliaPorId(2)

        Assert.AreEqual(Long.Parse(2), nuevaFamilia.idFamilia)
        Assert.AreEqual("desTest", nuevaFamilia.descripcion)
        Assert.AreEqual("nombretest", nuevaFamilia.nombre)

        Assert.AreEqual(Long.Parse(9), nuevaFamilia.patentes(0).patenteId)
        Assert.AreEqual(1, nuevaFamilia.patentes.Count)

        target.actualizarFamilia(familia)
    End Sub

    '''<summary>
    '''A test for actualizarFamilia
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarFamiliaPorObjetoTest()
        Dim patente As New Patente(9, "Listado de patentes", "Listado de patentes")

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.ID_FAMILIA, 5, Restriccion.CONDICION_IGUAL))
        Dim actual As Familia = target.cargarFamilia(criteria)

        actual.nombre = "nombretest"
        actual.descripcion = "desTest"
        actual.patentes.Add(patente)

        target.actualizarFamilia(actual)

        actual = target.cargarFamilia(criteria)

        Assert.AreEqual(Long.Parse(5), actual.idFamilia)
        Assert.AreEqual("desTest", actual.descripcion)
        Assert.AreEqual("nombretest", actual.nombre)

        Assert.AreEqual(Long.Parse(9), actual.patentes(0).patenteId)
        Assert.AreEqual(1, actual.patentes.Count)

        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")
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

        actual = target.cargarFamiliaPorId(7)
        Assert.IsNull(actual)
    End Sub

    '''<summary>
    '''A test for cargarFamilia
    '''</summary>
    <TestMethod()> _
    Public Sub cargarFamiliaTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(FamiliaTDG.NOMBRE, "Administracion usuarios", Restriccion.CONDICION_IGUAL))
        Dim actual As Familia = target.cargarFamilia(criteria)

        Assert.AreEqual(Long.Parse(6), actual.idFamilia)
        Assert.AreEqual("Administracion de los usuarios", actual.descripcion)
        Assert.AreEqual("Administracion usuarios", actual.nombre)
        Assert.AreEqual(8, actual.patentes.Count)
    End Sub

    '''<summary>
    '''A test for cargarFamiliaPorId
    '''</summary>
    <TestMethod()> _
    Public Sub cargarFamiliaPorIdTest()
        Dim actual As Familia = target.cargarFamiliaPorId(6)
        Assert.AreEqual(Long.Parse(6), actual.idFamilia)
        Assert.AreEqual("Administracion de los usuarios", actual.descripcion)
        Assert.AreEqual("Administracion usuarios", actual.nombre)
        Assert.AreEqual(8, actual.patentes.Count)
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
        criteria.Add(New Restriccion(FamiliaTDG.ID_FAMILIA, 7, Restriccion.CONDICION_IGUAL))
        Dim actual As Familia = target.cargarFamilia(criteria)

        Assert.AreEqual(Long.Parse(7), actual.idFamilia)
        Assert.AreEqual("familia test", actual.descripcion)
        Assert.AreEqual("test", actual.nombre)

        Assert.AreEqual(Long.Parse(9), actual.patentes(0).patenteId)
        Assert.AreEqual(1, actual.patentes.Count)

        target.borrarFamilia(familia)
    End Sub

    '''<summary>
    '''A test for listarFamlias
    '''</summary>
    <TestMethod()> _
    Public Sub listarFamliasTest()
        Dim actual As List(Of Familia) = target.listarFamlias()
        Assert.AreEqual(6, actual.Count)
        Assert.AreEqual(8, actual(5).patentes.Count)
    End Sub
End Class
