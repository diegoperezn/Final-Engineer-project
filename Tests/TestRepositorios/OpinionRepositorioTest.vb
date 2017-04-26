Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for OpinionRepositorioTest and is intended
'''to contain all OpinionRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OpinionRepositorioTest


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

    Dim target As OpinionRepositorio = RepositorioFactory.opinionRepositorio

    '''<summary>
    '''A test for listarOpinionesPorId
    '''</summary>
    <TestMethod()> _
    Public Sub listarOpinionesPorIdTest()
        Dim actual As Opinion = target.listarOpinionesPorId(1)

        Assert.AreEqual(Long.Parse(1), actual.id)
        Assert.AreEqual("nombre1", actual.nombre)
        Assert.AreEqual("mail1@test.com", actual.mail)
        Assert.AreEqual("opinion1", actual.opinion)
    End Sub

    '''<summary>
    '''A test for listarOpinionesPorMail
    '''</summary>
    <TestMethod()> _
    Public Sub listarOpinionesPorMailTest()
        Dim actual As List(Of Opinion) = target.listarOpinionesPorMail("mail2@test.com")

        Assert.AreEqual(Long.Parse(2), actual(0).id)
        Assert.AreEqual("nombre2", actual(0).nombre)
        Assert.AreEqual("mail2@test.com", actual(0).mail)
        Assert.AreEqual("opinion2", actual(0).opinion)
    End Sub

    '''<summary>
    '''A test for listarOpiniones
    '''</summary>
    <TestMethod()> _
    Public Sub listarOpinionesTest()
        Dim actual As List(Of Opinion) = target.listarOpiniones

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

    '''<summary>
    '''A test for grabarOpinion
    '''</summary>
    <TestMethod()> _
    Public Sub grabarOpinionTest()
        Dim opinion As New Opinion(Nothing, "nombre4", "mail4@test.com", "opinion4")

        target.grabarOpinion(opinion)

        Dim actual As Opinion = target.listarOpinionesPorId(4)

        Assert.AreEqual(Long.Parse(4), actual.id)
        Assert.AreEqual("nombre4", actual.nombre)
        Assert.AreEqual("mail4@test.com", actual.mail)
        Assert.AreEqual("opinion4", actual.opinion)

        target.borrar(opinion)
    End Sub
End Class
