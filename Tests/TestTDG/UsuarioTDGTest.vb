Imports System.Collections.Generic

Imports System.Collections

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for UsuarioTDGTest and is intended
'''to contain all UsuarioTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class UsuarioTDGTest


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
        Dim usuario As Usuario = New Usuario()
        usuario.id = 6
        target.borrar(usuario)

        usuario = New Usuario(5, "apellido5", "mail5@test.com", "nombre5", "pas5", "5555-5555", "5555-5555")
        target.actualizar(usuario)
    End Sub

#End Region

    Dim target As UsuarioTDG = RepositorioFactory.usuarioTDG

    '''<summary>
    '''A test for actualizarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarUsuarioTest()
        Dim usuario As Usuario = New Usuario(5, "apellido1modificado", "mail1modificado@test.com", "nombre1modificado", "pas1mod", "1111-1112", "1111-1112")
        Dim familia As New Familia
        familia.idFamilia = 1
        usuario.familias.Add(familia)
        Dim patente As New Patente
        patente.patenteId = 1
        usuario.patentes.Add(patente)

        target.actualizar(usuario)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(UsuarioTDG.ID_USUARIO, 5, Restriccion.CONDICION_IGUAL))
        Dim usr As Usuario = target.buscarUnico(criterio)

        Assert.AreEqual("nombre1modificado", usr.nombre)
        Assert.AreEqual("apellido1modificado", usr.apellido)
        Assert.AreEqual("mail1modificado@test.com", usr.mail)
        Assert.AreEqual(Long.Parse(5), usr.id)
        Assert.AreEqual("pas1mod", usr.password)
        Assert.AreEqual("1111-1112", usr.telefonoFijo)
        Assert.AreEqual("1111-1112", usr.telefonoMovil)
        Assert.AreEqual(Long.Parse(1), usr.familias(0).idFamilia)
        Assert.AreEqual(Long.Parse(1), usr.patentes(0).patenteId)
    End Sub

    
    <TestMethod()> _
    Public Sub cargarUsuarioTest()
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(UsuarioTDG.ID_USUARIO, 1, Restriccion.CONDICION_IGUAL))
        Dim actual As Usuario
        actual = target.buscarUnico(criterio)
        Assert.AreEqual("nombre1", actual.nombre)
    End Sub

    <TestMethod()> _
    Public Sub cargarUsuarioPorFamiliaTest()
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(UsuarioTDG.FAMILIAS, 6, Restriccion.CONDICION_IGUAL))
        Dim actual As Usuario
        actual = target.buscarUnico(criterio)
        Assert.AreEqual("nombre3", actual.nombre)
    End Sub

    <TestMethod()> _
    Public Sub cargarUsuarioConRestriccionesTest()
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(UsuarioTDG.NOMBRE, "bre1", Restriccion.CONDICION_LIKE))
        criterio.Add(New Restriccion(UsuarioTDG.APELLIDO, "ap", Restriccion.CONDICION_LIKE))
        criterio.Add(New Restriccion(UsuarioTDG.MAIL, "@test", Restriccion.CONDICION_LIKE))
        criterio.Add(New Restriccion(UsuarioTDG.TELEFONO_FIJO, "1-1", Restriccion.CONDICION_LIKE))
        criterio.Add(New Restriccion(UsuarioTDG.TELEFONO_MOVIL, "1-1", Restriccion.CONDICION_LIKE))

        Dim actual As Usuario = target.buscarUnico(criterio)

        Assert.AreEqual("nombre1", actual.nombre)
    End Sub

    <TestMethod()> _
    Public Sub cargarUsuariosTest()
        Dim actual As List(Of Usuario)
        actual = target.cargarUsuarios(Nothing)
        Assert.AreEqual(5, actual.Count)
    End Sub

    '''<summary>
    '''A test for grabarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub grabarUsuarioTest()
        Dim usuario As Usuario = New Usuario(Nothing, "apellido6", "mail6@test.com", "nombre6", "pas6", "6666-6666", "6666-6666")
        Dim familia As New Familia
        familia.idFamilia = 1
        usuario.familias.Add(familia)
        Dim patente As New Patente
        patente.patenteId = 1
        usuario.patentes.Add(patente)

        target.grabar(usuario)
        Dim actual As List(Of Usuario)
        actual = target.cargarUsuarios(Nothing)
        Assert.AreEqual(6, actual.Count)
        Assert.AreEqual(1, actual(5).familias.Count)
        Assert.AreEqual(1, actual(5).patentes.Count)

        target.borrar(usuario)
        actual = target.cargarUsuarios(Nothing)
        Assert.AreEqual(5, actual.Count)
    End Sub

    '''<summary>
    '''A test for borrarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub borrarUsuarioTest()
        Dim usuario As Usuario = New Usuario(6, "apellido6", "mail6@test.com", "nombre6", "pas6", "6666-6666", "6666-6666")
        target.grabar(usuario)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(UsuarioTDG.ID_USUARIO, 6, Restriccion.CONDICION_IGUAL))

        Dim usr As Usuario = target.buscarUnico(criterio)

        Assert.IsNotNull(usr)

        usuario = New Usuario()
        usuario.id = 6
        target.borrar(usuario)

        usr = target.buscarUnico(criterio)

        Assert.IsNull(usr)
    End Sub
End Class
