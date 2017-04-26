Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for ClienteRepositorioTest and is intended
'''to contain all ClienteRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ClienteRepositorioTest


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


    Dim target As ClienteRepositorio = RepositorioFactory.clienteRepositorio
    Dim dao As DataAccesObject = RepositorioFactory.dao

    <TestMethod()> _
    Public Sub CargarClienteTest()
        Dim usuario As New Usuario()
        usuario.id = 1
        Dim actual As Cliente = target.CargarCliente(usuario)

        Assert.AreEqual(Long.Parse(1), actual.idCliente)
        Assert.AreEqual(Long.Parse(1), actual.id)
        Assert.AreEqual(True, actual.habitadoTurnos)
        Assert.AreEqual(False, actual.newsletter)

        Assert.AreEqual(2, actual.diseño.Count)
        Assert.AreEqual(Long.Parse(1), actual.diseño(0).idDiseño)
        Assert.AreEqual("diseño1", actual.diseño(0).nombre)
        Assert.AreEqual(Long.Parse(2), actual.diseño(1).idDiseño)
        Assert.AreEqual(2222, actual.diseño(1).puntadas)

        Assert.AreEqual(2, actual.facturas.Count)
        Assert.AreEqual(Long.Parse(1), actual.facturas(0).nroDocumento)
        Assert.AreEqual(Double.Parse(11), actual.facturas(0).iva)
        Assert.AreEqual(Long.Parse(2), actual.facturas(1).nroDocumento)
        Assert.AreEqual(Double.Parse(22), actual.facturas(1).iva)

        Assert.AreEqual(3, actual.pedido.Count)
        Assert.AreEqual(Long.Parse(1), actual.pedido(0).codPedido)
        Assert.AreEqual(Long.Parse(1), actual.pedido(0).tipoPedido.tipoPedido)
        Assert.AreEqual(Long.Parse(3), actual.pedido(1).codPedido)
        Assert.AreEqual("comentario3", actual.pedido(1).comentario)

        Assert.AreEqual(2, actual.movimientosCuentaCorriente.Count)
        Assert.AreEqual(Long.Parse(1), actual.movimientosCuentaCorriente(0).nroMovimiento)
        Assert.AreEqual("com1", actual.movimientosCuentaCorriente(0).comentario)
        Assert.AreEqual(Long.Parse(2), actual.movimientosCuentaCorriente(1).nroMovimiento)
        Assert.AreEqual("com2", actual.movimientosCuentaCorriente(1).comentario)
    End Sub

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
        Assert.AreEqual("diseño1", actual(0).diseño(0).nombre)
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

        Assert.AreEqual(Long.Parse(1), actual(0).pedido(0).codPedido)
        Assert.AreEqual(Long.Parse(1), actual(0).pedido(0).tipoPedido.tipoPedido)

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

        target.actualizarCliente(actual)
        dao.saveOrUpdate(" UPDATE factura set borrado = 0 ")
        dao.saveOrUpdate(" UPDATE diseño set borrado = 0 ")
        dao.saveOrUpdate(" UPDATE pedido set borrado = 0 ")
    End Sub

    <TestMethod()> _
    Public Sub guardarClienteTest()
        Dim cliente As Cliente = New Cliente(Nothing, "apellido6", "mail6@test.com", "nombre6", "pas633", "6666-6666", "6666-6666", False, True)

        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")

        cliente.familias.Add(familia)
        cliente.patentes.Add(patente)

        target.guardarCliente(cliente)

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

    <TestMethod()> _
    Public Sub borrarClienteTest()
        Dim cliente As Cliente = New Cliente(Nothing, "apellido6", "mail6@test.com", "nombre6", "pas633", "6666-6666", "6666-6666", False, True)

        Dim patente As New Patente(3, "Eliminacion de usuarios", "Eliminacion de usuarios")
        Dim familia As New Familia(5, "Administracion de finanzas", "Administracion de finanzas")

        cliente.familias.Add(familia)
        cliente.patentes.Add(patente)

        target.guardarCliente(cliente)

        Dim base As Cliente = target.CargarClientePorId(3)

        Assert.IsNotNull(base)

        target.borrarCliente(cliente)

        base = target.CargarClientePorId(3)

        Assert.IsNull(base)
    End Sub
End Class
