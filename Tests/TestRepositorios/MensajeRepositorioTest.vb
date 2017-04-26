Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for MensajeRepositorioTest and is intended
'''to contain all MensajeRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MensajeRepositorioTest


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

    Dim target As MensajeRepositorio = RepositorioFactory.mensajeRepositorio

    <TestMethod()> _
    Public Sub cargarMensajePorConversacionTest()
        Dim conversacion As New Conversacion()
        conversacion.id = 1
        target.cargarMensajePorConversacion(conversacion)

        Assert.AreEqual(2, conversacion.mensajes.Count)
        Assert.AreEqual(Long.Parse(1), conversacion.mensajes(0).id)
        Assert.AreEqual(Long.Parse(1), conversacion.mensajes(0).conversacion.id)
        Assert.AreEqual(True, conversacion.mensajes(0).leido)
        Assert.AreEqual(1, conversacion.mensajes(0).tipoMensaje)
        Assert.AreEqual("msj de 2 a 1", conversacion.mensajes(0).mensaje)
    End Sub

    '''<summary>
    '''A test for grabar
    '''</summary>
    <TestMethod()> _
    Public Sub grabarTest()
        Dim conversacion As New Conversacion()
        conversacion.id = 1

        Dim mensaje As New Mensaje(Nothing, mensaje.ENTRADA, conversacion, DateTime.Now, "test msj grabarMensajeTest")

        target.grabar(mensaje)

        target.cargarMensajePorConversacion(conversacion)

        Assert.AreEqual(3, conversacion.mensajes.Count)
        Assert.AreEqual(Long.Parse(5), conversacion.mensajes(2).id)
        Assert.AreEqual(Long.Parse(1), conversacion.mensajes(2).conversacion.id)
        Assert.AreEqual(False, conversacion.mensajes(2).leido)
        Assert.AreEqual(0, conversacion.mensajes(2).tipoMensaje)
        Assert.AreEqual("test msj grabarMensajeTest", conversacion.mensajes(2).mensaje)

        target.borrar(mensaje)
    End Sub

    '''<summary>
    '''A test for modificar
    '''</summary>
    <TestMethod()> _
    Public Sub modificarTest()
        Dim viejo As Mensaje = target.cargarMensajePorId(2)

        viejo.leido = True
        target.modificar(viejo)
        viejo = target.cargarMensajePorId(2)

        Assert.AreEqual(Long.Parse(2), viejo.id)
        Assert.AreEqual(Long.Parse(1), viejo.conversacion.id)
        Assert.AreEqual(True, viejo.leido)
        Assert.AreEqual(0, viejo.tipoMensaje)
        Assert.AreEqual("msj de 1 a 2", viejo.mensaje)

        viejo.leido = False
        target.modificar(viejo)
    End Sub

    '''<summary>
    '''A test for borrar
    '''</summary>
    <TestMethod()> _
    Public Sub borrarTest()
        Dim conversacion As New Conversacion()
        conversacion.id = 1


        Dim mensaje As New Mensaje(Nothing, mensaje.ENTRADA, conversacion, DateTime.Now, "test msj grabarMensajeTest")

        target.grabar(mensaje)

        target.cargarMensajePorConversacion(conversacion)

        Assert.AreEqual(3, conversacion.mensajes.Count)
        Assert.AreEqual(Long.Parse(5), conversacion.mensajes(2).id)
        Assert.AreEqual(Long.Parse(1), conversacion.mensajes(2).conversacion.id)
        Assert.AreEqual(False, conversacion.mensajes(2).leido)
        Assert.AreEqual(0, conversacion.mensajes(2).tipoMensaje)
        Assert.AreEqual("test msj grabarMensajeTest", conversacion.mensajes(2).mensaje)

        target.borrar(mensaje)

        target.cargarMensajePorConversacion(conversacion)
        Assert.AreEqual(2, conversacion.mensajes.Count)
    End Sub

    '''<summary>
    '''A test for listarMensajes
    '''</summary>
    <TestMethod()> _
    Public Sub listarMensajesTest()
        Dim actual As List(Of Mensaje) = target.listarMensajes()

        Assert.AreEqual(4, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual(Long.Parse(1), actual(0).conversacion.id)
        Assert.AreEqual(True, actual(0).leido)
        Assert.AreEqual(1, actual(0).tipoMensaje)
        Assert.AreEqual("msj de 2 a 1", actual(0).mensaje)
    End Sub
End Class
