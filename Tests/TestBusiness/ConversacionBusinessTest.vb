Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for ConversacionBusinessTest and is intended
'''to contain all ConversacionBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ConversacionBusinessTest


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

    Dim target As ConversacionBusiness = BusinessFactory.conversacionBusiness
    Dim mensajeRepositorio As MensajeRepositorio = RepositorioFactory.mensajeRepositorio

    <TestMethod()> _
    Public Sub borrarTest()
        Dim remitente As New Usuario
        remitente.id = 2
        Dim destinatario As New Usuario
        destinatario.id = 3

        Dim conversacion As New Conversacion(Nothing, remitente, destinatario, Nothing)
        Dim msjs As New List(Of Mensaje)
        Dim mensaje2 As New Mensaje(Nothing, Mensaje.ENTRADA, conversacion, DateTime.Now, "test msj grabarMensajeTest")
        msjs.Add(mensaje2)
        Dim mensaje1 As New Mensaje(Nothing, Mensaje.SALIDA, conversacion, DateTime.Now, "test msj grabarMensajeTest")
        msjs.Add(mensaje1)

        conversacion.mensajes = msjs

        target.grabar(conversacion)

        Dim actual As List(Of Conversacion) = target.listarConversacionesPorId(3)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(2), actual(0).remitente.id)
        Assert.AreEqual(Long.Parse(3), actual(0).destinatario.id)
        Assert.AreEqual(Long.Parse(3), actual(0).id)

        Assert.AreEqual(2, actual(0).mensajes.Count)
        Assert.AreEqual(Mensaje.ENTRADA, actual(0).mensajes(0).tipoMensaje)
        Assert.AreEqual("test msj grabarMensajeTest", actual(0).mensajes(0).mensaje)
        Assert.AreEqual(Long.Parse(3), actual(0).mensajes(0).conversacion.id)

        Assert.AreEqual(Mensaje.SALIDA, actual(0).mensajes(1).tipoMensaje)
        Assert.AreEqual("test msj grabarMensajeTest", actual(0).mensajes(1).mensaje)
        Assert.AreEqual(Long.Parse(3), actual(0).mensajes(1).conversacion.id)

        target.borrar(conversacion)
        actual = target.listarConversacionesPorId(3)
        Assert.AreEqual(0, actual.Count)
        Assert.AreEqual(4, MensajeRepositorio.listarMensajes.Count)
    End Sub

    '''<summary>
    '''A test for grabar
    '''</summary>
    <TestMethod()> _
    Public Sub grabarTest()
        Dim remitente As New Usuario
        remitente.id = 2
        Dim destinatario As New Usuario
        destinatario.id = 3

        Dim conversacion As New Conversacion(Nothing, remitente, destinatario, Nothing)
        Dim msjs As New List(Of Mensaje)
        Dim mensaje2 As New Mensaje(Nothing, Mensaje.ENTRADA, conversacion, DateTime.Now, "test msj grabarMensajeTest")
        msjs.Add(mensaje2)
        Dim mensaje1 As New Mensaje(Nothing, Mensaje.SALIDA, conversacion, DateTime.Now, "test msj grabarMensajeTest")
        msjs.Add(mensaje1)

        conversacion.mensajes = msjs

        target.grabar(conversacion)

        Dim actual As List(Of Conversacion) = target.listarConversacionesPorId(3)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(2), actual(0).remitente.id)
        Assert.AreEqual(Long.Parse(3), actual(0).destinatario.id)
        Assert.AreEqual(Long.Parse(3), actual(0).id)

        Assert.AreEqual(2, actual(0).mensajes.Count)
        Assert.AreEqual(Mensaje.ENTRADA, actual(0).mensajes(0).tipoMensaje)
        Assert.AreEqual("test msj grabarMensajeTest", actual(0).mensajes(0).mensaje)
        Assert.AreEqual(Long.Parse(3), actual(0).mensajes(0).conversacion.id)

        Assert.AreEqual(Mensaje.SALIDA, actual(0).mensajes(1).tipoMensaje)
        Assert.AreEqual("test msj grabarMensajeTest", actual(0).mensajes(1).mensaje)
        Assert.AreEqual(Long.Parse(3), actual(0).mensajes(1).conversacion.id)

        target.borrar(conversacion)
    End Sub

    '''<summary>
    '''A test for listarConversacionesPorId
    '''</summary>
    <TestMethod()> _
    Public Sub listarConversacionesPorIdTest()
        Dim actual As List(Of Conversacion) = target.listarConversacionesPorId(1)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).remitente.id)
        Assert.AreEqual(Long.Parse(2), actual(0).destinatario.id)
        Assert.AreEqual(Long.Parse(1), actual(0).id)

        Assert.AreEqual(2, actual(0).mensajes.Count)
        Assert.AreEqual(Mensaje.SALIDA, actual(0).mensajes(0).tipoMensaje)
        Assert.AreEqual("msj de 2 a 1", actual(0).mensajes(0).mensaje)
        Assert.AreEqual(True, actual(0).mensajes(0).leido)
        Assert.AreEqual(Long.Parse(1), actual(0).mensajes(0).conversacion.id)

        Assert.AreEqual(Mensaje.ENTRADA, actual(0).mensajes(1).tipoMensaje)
        Assert.AreEqual("msj de 1 a 2", actual(0).mensajes(1).mensaje)
        Assert.AreEqual(False, actual(0).mensajes(1).leido)
        Assert.AreEqual(Long.Parse(1), actual(0).mensajes(1).conversacion.id)
    End Sub

    '''<summary>
    '''A test for listarConversacionesPorUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub listarConversacionesPorUsuarioTest()
        Dim usuario As New Usuario
        usuario.id = 1
        Dim actual As List(Of Conversacion) = target.listarConversacionesPorUsuario(usuario)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).remitente.id)
        Assert.AreEqual(Long.Parse(2), actual(0).destinatario.id)
        Assert.AreEqual(Long.Parse(1), actual(0).id)

        Assert.AreEqual(2, actual(0).mensajes.Count)
        Assert.AreEqual(Mensaje.SALIDA, actual(0).mensajes(0).tipoMensaje)
        Assert.AreEqual("msj de 2 a 1", actual(0).mensajes(0).mensaje)
        Assert.AreEqual(True, actual(0).mensajes(0).leido)
        Assert.AreEqual(Long.Parse(1), actual(0).mensajes(0).conversacion.id)

        Assert.AreEqual(Mensaje.ENTRADA, actual(0).mensajes(1).tipoMensaje)
        Assert.AreEqual("msj de 1 a 2", actual(0).mensajes(1).mensaje)
        Assert.AreEqual(False, actual(0).mensajes(1).leido)
        Assert.AreEqual(Long.Parse(1), actual(0).mensajes(1).conversacion.id)
    End Sub
    '''<summary>
    '''A test for modificar
    '''</summary>
    <TestMethod()> _
    Public Sub modificarTest()
        Dim actual As List(Of Conversacion) = target.listarConversacionesPorId(4)

        actual(0).mensajes(1).leido = False

        target.modificar(actual(0))

        actual = target.listarConversacionesPorId(4)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(4), actual(0).remitente.id)
        Assert.AreEqual(Long.Parse(5), actual(0).destinatario.id)
        Assert.AreEqual(Long.Parse(2), actual(0).id)

        Assert.AreEqual(2, actual(0).mensajes.Count)
        Assert.AreEqual(Mensaje.ENTRADA, actual(0).mensajes(0).tipoMensaje)
        Assert.AreEqual("msj de 4 a 5", actual(0).mensajes(0).mensaje)
        Assert.AreEqual(True, actual(0).mensajes(0).leido)
        Assert.AreEqual(Long.Parse(2), actual(0).mensajes(0).conversacion.id)

        Assert.AreEqual(Mensaje.SALIDA, actual(0).mensajes(1).tipoMensaje)
        Assert.AreEqual("msj de 5 a 4", actual(0).mensajes(1).mensaje)
        Assert.AreEqual(False, actual(0).mensajes(1).leido)
        Assert.AreEqual(Long.Parse(2), actual(0).mensajes(1).conversacion.id)

        actual(0).mensajes(1).leido = True

        target.modificar(actual(0))
    End Sub
End Class
