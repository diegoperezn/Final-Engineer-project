Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for MensajeTDGTest and is intended
'''to contain all MensajeTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MensajeTDGTest


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

    Dim target As MensajeTDG = RepositorioFactory.mensajeTDG


    <TestMethod()> _
    Public Sub cargarTest()
        Dim actual As List(Of Mensaje) = target.cargarMensajes(Nothing)

        Assert.AreEqual(4, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual(Long.Parse(1), actual(0).conversacion.id)
        Assert.AreEqual(True, actual(0).leido)
        Assert.AreEqual(1, actual(0).tipoMensaje)
        Assert.AreEqual("msj de 2 a 1", actual(0).mensaje)
    End Sub

    <TestMethod()> _
    Public Sub cargarMensajePorConversacionTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MensajeTDG.CONVERSACION, 1))
        Dim actual As List(Of Mensaje) = target.cargarMensajes(criteria)

        Assert.AreEqual(2, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual(Long.Parse(1), actual(0).conversacion.id)
        Assert.AreEqual(True, actual(0).leido)
        Assert.AreEqual(1, actual(0).tipoMensaje)
        Assert.AreEqual("msj de 2 a 1", actual(0).mensaje)
    End Sub

    <TestMethod()> _
    Public Sub grabarMensajeTest()
        Dim conversacion As New Conversacion()
        conversacion.id = 1

        Dim mensaje As New Mensaje(Nothing, mensaje.ENTRADA, conversacion, DateTime.Now, "test msj grabarMensajeTest")

        target.grabar(mensaje)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MensajeTDG.CONVERSACION, 1))
        Dim actual As List(Of Mensaje) = target.cargarMensajes(criteria)

        Assert.AreEqual(3, actual.Count)
        Assert.AreEqual(Long.Parse(5), actual(2).id)
        Assert.AreEqual(Long.Parse(1), actual(2).conversacion.id)
        Assert.AreEqual(False, actual(2).leido)
        Assert.AreEqual(0, actual(2).tipoMensaje)
        Assert.AreEqual("test msj grabarMensajeTest", actual(2).mensaje)

        target.borrar(mensaje)
    End Sub

    <TestMethod()> _
    Public Sub modificarMensajeTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MensajeTDG.ID_MENSAJE, 2))
        Dim viejo As Mensaje = target.buscarUnico(criteria)

        viejo.leido = True
        target.actualizar(viejo)
        viejo = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(2), viejo.id)
        Assert.AreEqual(Long.Parse(1), viejo.conversacion.id)
        Assert.AreEqual(True, viejo.leido)
        Assert.AreEqual(0, viejo.tipoMensaje)
        Assert.AreEqual("msj de 1 a 2", viejo.mensaje)

        viejo.leido = False
        target.actualizar(viejo)
    End Sub

    Public Sub borrarMensajeTest()
        Dim conversacion As New Conversacion()
        conversacion.id = 1

        Dim mensaje As New Mensaje(Nothing, mensaje.ENTRADA, conversacion, DateTime.Now, "test msj grabarMensajeTest")

        target.grabar(mensaje)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MensajeTDG.CONVERSACION, 1))
        Dim actual As List(Of Mensaje) = target.cargarMensajes(criteria)

        Assert.AreEqual(3, actual.Count)
        Assert.AreEqual(Long.Parse(5), actual(2).id)
        Assert.AreEqual(Long.Parse(1), actual(2).conversacion.id)
        Assert.AreEqual(False, actual(2).leido)
        Assert.AreEqual(0, actual(2).tipoMensaje)
        Assert.AreEqual("test msj grabarMensajeTest", actual(2).mensaje)

        target.borrar(mensaje)

        criteria.Clear()
        criteria.Add(New Restriccion(MensajeTDG.CONVERSACION, 1))
        actual = target.cargarMensajes(criteria)
        Assert.AreEqual(2, actual.Count)
    End Sub
   
End Class
