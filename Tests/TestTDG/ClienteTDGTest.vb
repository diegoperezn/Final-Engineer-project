Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for ClienteTDGTest and is intended
'''to contain all ClienteTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ClienteTDGTest


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


    Dim target As ClienteTDG = RepositorioFactory.clienteTDG
    Dim dao As DataAccesObject = RepositorioFactory.dao

    '''<summary>
    '''A test for actualizarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarUsuarioTest()
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ClienteTDG.ID_CLIENTE, 1, Restriccion.CONDICION_IGUAL))
        Dim actual As Cliente
        actual = target.buscarUnico(criterio)

        Dim copia As New Cliente()
        copia.idCliente = 1
        copia.habitadoTurnos = False
        copia.newsletter = True

        target.actualizar(copia)
        Dim base As Cliente = target.buscarUnico(criterio)

        Assert.AreEqual(Long.Parse(1), base.idCliente)
        Assert.AreEqual(Long.Parse(1), base.id)
        Assert.AreEqual(False, base.habitadoTurnos)
        Assert.AreEqual(True, base.newsletter)

        Assert.AreEqual(0, base.diseño.Count)
        Assert.AreEqual(0, base.facturas.Count)
        Assert.AreEqual(0, base.pedido.Count)
        Assert.AreEqual(2, base.movimientosCuentaCorriente.Count)

        copia.habitadoTurnos = False

        target.actualizar(actual)
        dao.saveOrUpdate(" UPDATE factura set borrado = 0 ")
        dao.saveOrUpdate(" UPDATE diseño set borrado = 0 ")
        dao.saveOrUpdate(" UPDATE pedido set borrado = 0 ")
    End Sub

    <TestMethod()> _
    Public Sub cargarClienteTest()
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ClienteTDG.ID_CLIENTE, 1, Restriccion.CONDICION_IGUAL))
        Dim actual As Cliente
        actual = target.buscarUnico(criterio)

        Assert.AreEqual(Long.Parse(1), actual.idCliente)
        Assert.AreEqual(Long.Parse(1), actual.id)
        Assert.AreEqual(True, actual.habitadoTurnos)
        Assert.AreEqual(False, actual.newsletter)

        Assert.AreEqual(2, actual.diseño.Count)
        Assert.AreEqual(Long.Parse(1), actual.diseño(0).idDiseño)
        Assert.AreEqual(Long.Parse(2), actual.diseño(1).idDiseño)

        Assert.AreEqual(2, actual.facturas.Count)
        Assert.AreEqual(Long.Parse(1), actual.facturas(0).nroDocumento)
        Assert.AreEqual(Long.Parse(2), actual.facturas(1).nroDocumento)

        Assert.AreEqual(2, actual.movimientosCuentaCorriente.Count)
        Assert.AreEqual(Long.Parse(1), actual.movimientosCuentaCorriente(0).nroMovimiento)
        Assert.AreEqual(Long.Parse(2), actual.movimientosCuentaCorriente(1).nroMovimiento)
    End Sub

    <TestMethod()> _
    Public Sub cargarClientePorFacturaTest()
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ClienteTDG.FACTURA, 1, Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(ClienteTDG.DISEÑOS, 2, Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(ClienteTDG.MOVIMIETO_CUENTA, 1, Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(ClienteTDG.NEWSLETTER, False, Restriccion.CONDICION_IGUAL))
        Dim actual As Cliente
        actual = target.buscarUnico(criterio)

        Assert.AreEqual(Long.Parse(1), actual.idCliente)
        Assert.AreEqual(Long.Parse(1), actual.id)
        Assert.AreEqual(True, actual.habitadoTurnos)
        Assert.AreEqual(False, actual.newsletter)

        Assert.AreEqual(2, actual.diseño.Count)
        Assert.AreEqual(Long.Parse(1), actual.diseño(0).idDiseño)
        Assert.AreEqual(Long.Parse(2), actual.diseño(1).idDiseño)

        Assert.AreEqual(2, actual.facturas.Count)
        Assert.AreEqual(Long.Parse(1), actual.facturas(0).nroDocumento)
        Assert.AreEqual(Long.Parse(2), actual.facturas(1).nroDocumento)

        Assert.AreEqual(2, actual.movimientosCuentaCorriente.Count)
        Assert.AreEqual(Long.Parse(1), actual.movimientosCuentaCorriente(0).nroMovimiento)
        Assert.AreEqual(Long.Parse(2), actual.movimientosCuentaCorriente(1).nroMovimiento)

        Assert.AreEqual(3, actual.pedido.Count)
        Assert.AreEqual(Long.Parse(1), actual.pedido(0).codPedido)
        Assert.AreEqual(Long.Parse(3), actual.pedido(1).codPedido)
        Assert.AreEqual(Long.Parse(4), actual.pedido(2).codPedido)
    End Sub

    <TestMethod()> _
    Public Sub cargarClientesTest()

        Dim actual As List(Of Cliente)
        actual = target.buscarClientes(Nothing)

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
    End Sub

    <TestMethod()> _
    Public Sub grabarUsuarioTest()
        Dim moviemientosCuenta As New List(Of MovimientosCuentaCliente)
        Dim mov As New MovimientosCuentaCliente()
        mov.nroMovimiento = 3
        moviemientosCuenta.Add(mov)

        Dim cliente As Cliente = New Cliente()
        cliente.idCliente = 3
        cliente.id = 3
        cliente.habitadoTurnos = False
        cliente.newsletter = True
        cliente.movimientosCuentaCorriente = moviemientosCuenta

        target.grabar(cliente)

        Dim lista As List(Of Cliente)
        lista = target.buscarClientes(Nothing)

        Assert.AreEqual(3, lista.Count)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ClienteTDG.ID_CLIENTE, 3, Restriccion.CONDICION_IGUAL))
        Dim actual As Cliente
        actual = target.buscarUnico(criterio)

        Assert.AreEqual(Long.Parse(3), actual.idCliente)
        Assert.AreEqual(Long.Parse(3), actual.id)
        Assert.AreEqual(False, actual.habitadoTurnos)
        Assert.AreEqual(True, actual.newsletter)

        Assert.AreEqual(0, actual.movimientosCuentaCorriente.Count)

        target.borrar(cliente)
    End Sub

    <TestMethod()> _
    Public Sub borrarUsuarioTest()
        Dim cliente As Cliente = New Cliente()
        cliente.idCliente = 3
        cliente.id = 3
        cliente.habitadoTurnos = False

        target.grabar(cliente)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ClienteTDG.ID_CLIENTE, 3, Restriccion.CONDICION_IGUAL))
        Dim actual As Cliente
        actual = target.buscarUnico(criterio)

        Assert.IsNotNull(actual)

        target.borrar(cliente)

        actual = target.buscarUnico(criterio)
        Assert.IsNull(actual)
    End Sub

End Class
