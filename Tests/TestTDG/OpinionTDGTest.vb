Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for OpinionTDGTest and is intended
'''to contain all OpinionTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OpinionTDGTest


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

    Dim target As OpinionTDG = RepositorioFactory.opinionTDG

    <TestMethod()> _
    Public Sub buscarOpinionesTest()
        Dim actual As List(Of Opinion) = target.buscarOpiniones(Nothing)

        Assert.AreEqual(3, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual("nombre1", actual(0).nombre)
        Assert.AreEqual("mail1@test.com", actual(0).mail)
        Assert.AreEqual("opinion1", actual(0).opinion)
        Assert.AreEqual(Long.Parse(2), actual(1).id)
        Assert.AreEqual("nombre2", actual(1).nombre)
        Assert.AreEqual("mail2@test.com", actual(1).mail)
        Assert.AreEqual("opinion2", actual(1).opinion)
        Assert.AreEqual(Long.Parse(3), actual(2).id)
        Assert.AreEqual("nombre3", actual(2).nombre)
        Assert.AreEqual("mail3@test.com", actual(2).mail)
        Assert.AreEqual("opinion3", actual(2).opinion)
    End Sub

    <TestMethod()> _
    Public Sub buscarOpinionesPorCriterioTest()
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(OpinionTDG.ID, 1, Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(OpinionTDG.NOMBRE, "nombre1", Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(OpinionTDG.MAIL, "mail1@test.com", Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(OpinionTDG.OPINION, "opinion1", Restriccion.CONDICION_IGUAL))
        Dim actual As List(Of Opinion) = target.buscarOpiniones(criterio)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual("nombre1", actual(0).nombre)
        Assert.AreEqual("mail1@test.com", actual(0).mail)
        Assert.AreEqual("opinion1", actual(0).opinion)
    End Sub

    <TestMethod()> _
    Public Sub buscarOpinionPorCriterioTest()
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(OpinionTDG.ID, 1, Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(OpinionTDG.NOMBRE, "nombre1", Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(OpinionTDG.MAIL, "mail1@test.com", Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(OpinionTDG.OPINION, "opinion1", Restriccion.CONDICION_IGUAL))
        Dim actual As Opinion = target.buscarUnico(criterio)

        Assert.AreEqual(Long.Parse(1), actual.id)
        Assert.AreEqual("nombre1", actual.nombre)
        Assert.AreEqual("mail1@test.com", actual.mail)
        Assert.AreEqual("opinion1", actual.opinion)
    End Sub


    <TestMethod()> _
    Public Sub guardarOpinionTest()
        Dim opinion As New Opinion(Nothing, "nombre4", "mail4@test.com", "opinion4")

        target.grabar(opinion)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(OpinionTDG.ID, 4, Restriccion.CONDICION_IGUAL))
        Dim actual As Opinion = target.buscarUnico(criterio)

        Assert.AreEqual(Long.Parse(4), actual.id)
        Assert.AreEqual("nombre4", actual.nombre)
        Assert.AreEqual("mail4@test.com", actual.mail)
        Assert.AreEqual("opinion4", actual.opinion)

        target.borrar(opinion)
    End Sub
End Class
