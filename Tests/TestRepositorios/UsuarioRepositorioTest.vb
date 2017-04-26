Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for UsuarioRepositorioTest and is intended
'''to contain all UsuarioRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class UsuarioRepositorioTest


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

    Dim target As UsuarioRepositorio = RepositorioFactory.usuarioRepostorio

    '''<summary>
    '''A test for actualizarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarUsuarioTest()
        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")
        Dim usuario As Usuario = target.cargarUsuarioPorId(5)

        usuario.familias.Add(familia)
        usuario.patentes.Add(patente)
        usuario.nombre = "nombreModificado"

        target.actualizarUsuario(usuario)

        Dim usr As Usuario = target.cargarUsuarioPorId(5)

        Assert.AreEqual(1, usr.familias.Count)
        Assert.AreEqual(Long.Parse(5), usr.familias(0).idFamilia)
        Assert.AreEqual(1, usr.patentes.Count)
        Assert.AreEqual(Long.Parse(3), usr.patentes(0).patenteId)
        Assert.AreEqual("nombreModificado", usr.nombre)

        usuario.nombre = "nombre5"
        usr.familias = New List(Of Familia)
        usr.patentes = New List(Of Patente)
        target.actualizarUsuario(usr)
    End Sub

    <TestMethod()> _
    Public Sub cargarUsuarioConRestriccionesTest()
        Dim actual As List(Of Usuario) = target.listarUsuariosConRestricciones("bre1", "ap", "@test", "1-1", "1-1")

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual("nombre1", actual(0).nombre)
    End Sub

    '''<summary>
    '''A test for grabarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub grabarUsuarioTest()
        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")
        Dim usuario As Usuario = New Usuario(6, "apellido6", "mail6@test.com", "nombre6", "pas633", "6666-6666", "6666-6666")

        usuario.familias.Add(familia)
        usuario.patentes.Add(patente)

        target.grabarUsuario(usuario)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(UsuarioTDG.ID_USUARIO, 6, Restriccion.CONDICION_IGUAL))
        Dim usr As Usuario = target.cargarUsuario(criteria)

        Assert.AreEqual(1, usr.familias.Count)
        Assert.AreEqual(Long.Parse(5), usr.familias(0).idFamilia)
        Assert.AreEqual(1, usr.patentes.Count)
        Assert.AreEqual(Long.Parse(3), usr.patentes(0).patenteId)
        Assert.AreEqual("nombre6", usr.nombre)

        target.borrarUsuario(usr)
        usr = target.cargarUsuario(criteria)
        Assert.IsNull(usr)
    End Sub

    '''<summary>
    '''A test for listarUsuarios
    '''</summary>
    <TestMethod()> _
    Public Sub listarUsuariosTest()
        Dim lista As List(Of Usuario) = target.listarUsuarios(Nothing)

        Assert.AreEqual(5, lista.Count)
        Assert.AreEqual(Long.Parse(3), lista(2).id)
        Assert.AreEqual(1, lista(2).familias.Count)
        Assert.AreEqual(Long.Parse(6), lista(2).familias(0).idFamilia)
        Assert.AreEqual("Administracion usuarios", lista(2).familias(0).nombre)
        Assert.AreEqual("Administracion de los usuarios", lista(2).familias(0).descripcion)
        Assert.AreEqual(8, lista(2).familias(0).patentes.Count)
        Assert.AreEqual(Long.Parse(1), lista(2).familias(0).patentes(0).patenteId)
    End Sub

    <TestMethod()> _
    Public Sub cargarUsuarioPorIdTest()
        Dim usr As Usuario = target.cargarUsuarioPorId(3)

        Assert.AreEqual(Long.Parse(3), usr.id)
        Assert.AreEqual(1, usr.familias.Count)
        Assert.AreEqual(Long.Parse(6), usr.familias(0).idFamilia)
        Assert.AreEqual("Administracion usuarios", usr.familias(0).nombre)
        Assert.AreEqual("Administracion de los usuarios", usr.familias(0).descripcion)
        Assert.AreEqual(8, usr.familias(0).patentes.Count)
        Assert.AreEqual(Long.Parse(1), usr.familias(0).patentes(0).patenteId)
    End Sub

End Class
