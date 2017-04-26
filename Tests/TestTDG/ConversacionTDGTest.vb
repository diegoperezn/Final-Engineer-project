Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for ConversacionTDGTest and is intended
'''to contain all ConversacionTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ConversacionTDGTest


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
        Dim conversacion As New Conversacion()
        conversacion.id = 3
        target.borrar(conversacion)
        dao.saveOrUpdate("update mensaje set borrado=0")
    End Sub

#End Region

    Dim target As ConversacionTDG = RepositorioFactory.conversacionTDG
    Dim dao As DataAccesObject = RepositorioFactory.dao

    <TestMethod()> _
    Public Sub cargarTest()
        Dim actual As List(Of Conversacion) = target.cargarConversaciones(Nothing)

        Assert.AreEqual(2, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).remitente.id)
        Assert.AreEqual(Long.Parse(2), actual(0).destinatario.id)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual(2, actual(0).mensajes.Count)
        Assert.AreEqual(Long.Parse(2), actual(1).id)
        Assert.AreEqual(2, actual(1).mensajes.Count)
    End Sub

    <TestMethod()> _
    Public Sub cargarMensajePorUsuariosTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ConversacionTDG.REMITENTE, 1))
        criteria.Add(New Restriccion(ConversacionTDG.DESTINATARIO, 2))
        Dim actual As List(Of Conversacion) = target.cargarConversaciones(criteria)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).remitente.id)
        Assert.AreEqual(Long.Parse(2), actual(0).destinatario.id)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual(2, actual(0).mensajes.Count)
    End Sub

    <TestMethod()> _
    Public Sub grabarMensajeTest()
        Dim remitente As New Usuario
        remitente.id = 2
        Dim destinatario As New Usuario
        destinatario.id = 1

        Dim conversacion As New Conversacion(Nothing, remitente, destinatario, Nothing)

        target.grabar(conversacion)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ConversacionTDG.REMITENTE, 2))
        criteria.Add(New Restriccion(ConversacionTDG.DESTINATARIO, 1))
        Dim actual As List(Of Conversacion) = target.cargarConversaciones(criteria)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(2), actual(0).remitente.id)
        Assert.AreEqual(Long.Parse(1), actual(0).destinatario.id)
        Assert.AreEqual(Long.Parse(3), actual(0).id)
        Assert.AreEqual(0, actual(0).mensajes.Count)
    End Sub

    <TestMethod()> _
    Public Sub borrarMensajeTest()
        Dim remitente As New Usuario
        remitente.id = 2
        Dim destinatario As New Usuario
        destinatario.id = 1

        Dim conversacion As New Conversacion(Nothing, remitente, destinatario, Nothing)

        target.grabar(conversacion)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ConversacionTDG.REMITENTE, 2))
        criteria.Add(New Restriccion(ConversacionTDG.DESTINATARIO, 1))
        Dim actual As List(Of Conversacion) = target.cargarConversaciones(criteria)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(2), actual(0).remitente.id)
        Assert.AreEqual(Long.Parse(1), actual(0).destinatario.id)
        Assert.AreEqual(Long.Parse(3), actual(0).id)
        Assert.AreEqual(0, actual(0).mensajes.Count)

        target.borrar(conversacion)

        actual = target.cargarConversaciones(criteria)
        Assert.AreEqual(0, actual.Count)
    End Sub

End Class
