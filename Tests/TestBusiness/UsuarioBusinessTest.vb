Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio
Imports Repositorio



'''<summary>
'''This is a test class for UsuarioBusinessTest and is intended
'''to contain all UsuarioBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class UsuarioBusinessTest


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
            testContextInstance = value
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
        Dim cliente As Cliente = New Cliente(1, "apellido1", "mail1@test.com", "nombre1", "44", "1111-1111", "1111-1111", True, False)
        cliente.id = 1
        target.actualizarCliente(cliente)
        dao.saveOrUpdate(" UPDATE factura set borrado = 0 ")
        dao.saveOrUpdate(" UPDATE diseño set borrado = 0 ")
        dao.saveOrUpdate(" UPDATE pedido set borrado = 0 ")
        dao.saveOrUpdate(" Insert into JoinPatenteToUsuario values (1,1) ")
    End Sub

#End Region

    Dim target As UsuarioBusiness = BusinessFactory.usuarioBusiness
    Dim dao As DataAccesObject = RepositorioFactory.dao

    '''<summary>
    '''A test for crearUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub crearUsuarioTest()
        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")
        Dim familias As New List(Of Familia)
        familias.Add(familia)
        Dim patentes As New List(Of Patente)
        patentes.Add(patente)

        target.crearUsuario("pas6", familias, patentes, "mail6@test.com", "6666-6666", "6666-6666", "apellido6", "nombre6")

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(UsuarioTDG.ID_USUARIO, 6, Restriccion.CONDICION_IGUAL))
        Dim usr As Usuario = target.buscarUsuario(criteria)

        Assert.AreEqual(1, usr.familias.Count)
        Assert.AreEqual(Long.Parse(5), usr.familias(0).idFamilia)
        Assert.AreEqual(1, usr.patentes.Count)
        Assert.AreEqual(Long.Parse(3), usr.patentes(0).patenteId)
        Assert.AreEqual("nombre6", usr.nombre)

        target.borrarUsuario(usr)

        criteria.Add(New Restriccion(UsuarioTDG.MAIL, "mail6@test.com", Restriccion.CONDICION_IGUAL))
        usr = target.buscarUsuario(criteria)

        Assert.IsNull(usr)
    End Sub

    <TestMethod()> _
    Public Sub cargarUsuarioConRestriccionesTest()
        Dim lista As List(Of Usuario) = target.listarUsuariosConRestricciones("bre3", "ap", "@test", "3-3", "3-3")

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(3), lista(0).id)
        Assert.AreEqual(1, lista(0).familias.Count)
        Assert.AreEqual(Long.Parse(6), lista(0).familias(0).idFamilia)
        Assert.AreEqual("Administracion usuarios", lista(0).familias(0).nombre)
        Assert.AreEqual("Administracion de los usuarios", lista(0).familias(0).descripcion)
        Assert.AreEqual(8, lista(0).familias(0).patentes.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).familias(0).patentes(0).patenteId)
    End Sub

    '''<summary>
    '''A test for modificarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub modificarUsuarioTest()
        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")
        Dim usuario As Usuario = target.buscarUsuarioPorId(5)

        usuario.familias.Add(familia)
        usuario.patentes.Add(patente)
        usuario.nombre = "nombreModificado"

        target.modificarUsuario(usuario)

        Dim usr As Usuario = target.buscarUsuarioPorId(5)

        Assert.AreEqual(1, usr.familias.Count)
        Assert.AreEqual(Long.Parse(5), usr.familias(0).idFamilia)
        Assert.AreEqual(1, usr.patentes.Count)
        Assert.AreEqual(Long.Parse(3), usr.patentes(0).patenteId)
        Assert.AreEqual("nombreModificado", usr.nombre)

        usuario.nombre = "nombre5"
        usr.familias = New List(Of Familia)
        usr.patentes = New List(Of Patente)
        target.modificarUsuario(usr)
    End Sub

    '''<summary>
    '''A test for modificarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub modificarUsuarioTest1()
        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")
        Dim familias As New List(Of Familia)
        Dim patentes As New List(Of Patente)
        familias.Add(familia)
        patentes.Add(patente)

        Dim usuario As Usuario = target.buscarUsuarioPorId(5)

        target.modificarUsuario(usuario.id, "pas6", familias, patentes, "mail6@test.com", "6666-6666", "6666-6666", "apellido6", "nombre6")

        Dim usr As Usuario = target.buscarUsuarioPorId(5)

        Assert.AreEqual(1, usr.familias.Count)
        Assert.AreEqual(Long.Parse(5), usr.familias(0).idFamilia)
        Assert.AreEqual(1, usr.patentes.Count)
        Assert.AreEqual(Long.Parse(3), usr.patentes(0).patenteId)
        Assert.AreEqual("nombre6", usr.nombre)

        target.modificarUsuario(usuario)
    End Sub



    '''<summary>
    '''A test for bloquearUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub bloquearUsuarioTest()
        Dim usuario As Usuario = target.buscarUsuarioPorId(1)

        target.bloquearUsuario(usuario)

        Dim usr As Usuario = target.buscarUsuarioPorId(1)

        Assert.AreEqual(True, usr.bloqueado)

        usuario.bloqueado = False
        target.modificarUsuario(usr)
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


    '''<summary>
    '''A test for actualizarCliente
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarClienteTest()
        Dim actual As Cliente = target.CargarClientePorId(1)

        Dim cliente As Cliente = New Cliente(1, "apellido6", "mail6@test.com", "nombre6", "pas633", "6666-6666", "6666-6666", False, True)
        cliente.idCliente = 1

        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")

        cliente.familias.Add(familia)
        cliente.patentes.Add(patente)

        target.actualizarCliente(cliente)

        Dim base As Cliente = target.CargarClientePorId(1)

        Assert.AreEqual(Long.Parse(1), base.idCliente)
        Assert.AreEqual(Long.Parse(1), base.id)
        Assert.AreEqual(False, base.habitadoTurnos)
        Assert.AreEqual(True, base.newsletter)

        Assert.AreEqual(1, base.familias.Count)
        Assert.AreEqual(Long.Parse(5), base.familias(0).idFamilia)
        Assert.AreEqual(1, base.patentes.Count)
        Assert.AreEqual(Long.Parse(3), base.patentes(0).patenteId)

        Assert.AreEqual("nombre6", base.nombre)
        Assert.AreEqual("mail6@test.com", base.mail)

        Assert.AreEqual(2, base.diseño.Count)
        Assert.AreEqual(2, base.facturas.Count)
        Assert.AreEqual(3, base.pedido.Count)
        Assert.AreEqual(2, base.movimientosCuentaCorriente.Count)
    End Sub

    '''<summary>
    '''A test for borrarCliente
    '''</summary>
    <TestMethod()> _
    Public Sub borrarClienteTest()
        Dim cliente As Cliente = New Cliente(Nothing, "apellido6", "mail6@test.com", "nombre6", "pas633", "6666-6666", "6666-6666", False, True)

        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")

        cliente.familias.Add(familia)
        cliente.patentes.Add(patente)

        target.grabarCliente(cliente)

        Dim base As Cliente = target.CargarClientePorId(3)

        Assert.IsNotNull(base)

        target.borrarCliente(cliente)

        base = target.CargarClientePorId(3)

        Assert.IsNull(base)
    End Sub

    '''<summary>
    '''A test for grabarCliente
    '''</summary>
    <TestMethod()> _
    Public Sub grabarClienteTest()
        Dim cliente As Cliente = New Cliente(Nothing, "apellido6", "mail6@test.com", "nombre6", "pas633", "6666-6666", "6666-6666", False, True)

        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")

        cliente.familias.Add(familia)
        cliente.patentes.Add(patente)

        target.grabarCliente(cliente)

        Dim base As Cliente = target.CargarClientePorId(3)

        Assert.AreEqual(Long.Parse(3), base.idCliente)
        Assert.AreEqual(Long.Parse(6), base.id)
        Assert.AreEqual(False, base.habitadoTurnos)
        Assert.AreEqual(True, base.newsletter)

        Assert.AreEqual(1, base.familias.Count)
        Assert.AreEqual(Long.Parse(5), base.familias(0).idFamilia)
        Assert.AreEqual(1, base.patentes.Count)
        Assert.AreEqual(Long.Parse(3), base.patentes(0).patenteId)

        Assert.AreEqual("nombre6", base.nombre)
        Assert.AreEqual("mail6@test.com", base.mail)

        Assert.AreEqual(0, base.diseño.Count)
        Assert.AreEqual(0, base.facturas.Count)
        Assert.AreEqual(0, base.pedido.Count)
        Assert.AreEqual(0, base.movimientosCuentaCorriente.Count)

        target.borrarCliente(cliente)
    End Sub

    '''<summary>
    '''A test for buscarUsuarioNewsletter
    '''</summary>
    <TestMethod()> _
    Public Sub buscarUsuarioNewsletterTest()
        Dim actual As Cliente = target.CargarClientePorId(1)

        Dim cliente As Cliente = New Cliente(1, "apellido6", "mail6@test.com", "nombre6", "pas633", "6666-6666", "6666-6666", False, True)
        cliente.idCliente = 1

        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")

        cliente.familias.Add(familia)
        cliente.patentes.Add(patente)

        target.actualizarCliente(cliente)

        Dim lista As List(Of Cliente)
        lista = target.buscarUsuarioNewsletter()

        Assert.AreEqual(1, lista.Count)

        Assert.AreEqual(Long.Parse(1), lista(0).idCliente)
        Assert.AreEqual(False, lista(0).habitadoTurnos)
        Assert.AreEqual(True, lista(0).newsletter)
        Assert.AreEqual("mail6@test.com", lista(0).mail)

        target.actualizarCliente(actual)
        dao.saveOrUpdate(" UPDATE factura set borrado = 0 ")
        dao.saveOrUpdate(" UPDATE diseño set borrado = 0 ")
        dao.saveOrUpdate(" UPDATE pedido set borrado = 0 ")
    End Sub

    '''<summary>
    '''A test for CargarClientes
    '''</summary>
    <TestMethod()> _
    Public Sub CargarClientesTest()
        Dim actual As List(Of Cliente)
        actual = target.CargarClientes()

        Assert.AreEqual(2, actual.Count)

        Assert.AreEqual(Long.Parse(1), actual(0).idCliente)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual(True, actual(0).habitadoTurnos)
        Assert.AreEqual(False, actual(0).newsletter)

        Assert.AreEqual(2, actual(0).diseño.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).diseño(0).idDiseño)
        Assert.AreEqual(Long.Parse(2), actual(0).diseño(1).idDiseño)

        Assert.AreEqual(2, actual(0).facturas.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).facturas(0).nroDocumento)
        Assert.AreEqual(Long.Parse(2), actual(0).facturas(1).nroDocumento)

        Assert.AreEqual(2, actual(0).movimientosCuentaCorriente.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).movimientosCuentaCorriente(0).nroMovimiento)
        Assert.AreEqual(Long.Parse(2), actual(0).movimientosCuentaCorriente(1).nroMovimiento)

        Assert.AreEqual(3, actual(0).pedido.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).pedido(0).codPedido)
        Assert.AreEqual(Long.Parse(3), actual(0).pedido(1).codPedido)
        Assert.AreEqual(Long.Parse(4), actual(0).pedido(2).codPedido)

        Assert.AreEqual(1, actual(1).familias.Count)
        Assert.AreEqual(Long.Parse(2), actual(1).familias(0).idFamilia)
        Assert.AreEqual("Operador de maquinas", actual(1).familias(0).nombre)
        Assert.AreEqual("Operador maquinas de produccion", actual(1).familias(0).descripcion)

        Assert.AreEqual(1, actual(1).familias(0).patentes.Count)
        Assert.AreEqual(Long.Parse(1), actual(1).familias(0).patentes(0).patenteId)
        Assert.AreEqual("creacion de usuario", actual(1).familias(0).patentes(0).descripcion)
        Assert.AreEqual("Creacion de usuarios", actual(1).familias(0).patentes(0).permiso)

        Assert.AreEqual(1, actual(0).patentes.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).patentes(0).patenteId)
        Assert.AreEqual("creacion de usuario", actual(0).patentes(0).descripcion)
        Assert.AreEqual("Creacion de usuarios", actual(0).patentes(0).permiso)
    End Sub
End Class
