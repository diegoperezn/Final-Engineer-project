Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for NewsletterRepositorioTest and is intended
'''to contain all NewsletterRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class NewsletterRepositorioTest


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

    Dim target As NewsletterRepositorio = RepositorioFactory.newsletterRepositorio

    '''<summary>
    '''A test for grabarNewsletter
    '''</summary>
    <TestMethod()> _
    Public Sub grabarNewsletterTest()
        Dim newsletterNuevo As Newsletter = New Newsletter(Nothing, "news3", "html", False)
        target.grabarNewsletter(newsletterNuevo)

        Dim actual As List(Of Newsletter) = target.listarNewsletter
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual("news1", actual(0).nombre)
        Assert.AreEqual(True, actual(0).enviado)

        target.borrarNewsletter(newsletterNuevo)
    End Sub

    '''<summary>
    '''A test for actualizarNewsletter
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarNewsletterTest()
        Dim newsletterOriginal As Newsletter = target.buscarNewsletterPorNombre("news1")

        Dim newsletterModificado As Newsletter = New Newsletter(newsletterOriginal.id, newsletterOriginal.nombre,
                                                      newsletterOriginal.newsletter, True)
        target.actualizarNewsletter(newsletterModificado)

        Dim newsBase As Newsletter = target.buscarNewsletterPorId(1)

        Assert.AreEqual(True, newsBase.enviado)

        target.actualizarNewsletter(newsletterModificado)
    End Sub

    '''<summary>
    '''A test for borrarNewsletter
    '''</summary>
    <TestMethod()> _
    Public Sub borrarNewsletterTest()
        Dim newsletterNuevo As Newsletter = New Newsletter(Nothing, "news3", "html", False)
        target.grabarNewsletter(newsletterNuevo)

        Dim newsBase As Newsletter = target.buscarNewsletterPorId(3)

        Assert.IsNotNull(newsBase)

        target.borrarNewsletter(newsBase)

        newsBase = target.buscarNewsletterPorId(3)

        Assert.IsNull(newsBase)
    End Sub

    '''<summary>
    '''A test for buscarNewsletterPorId
    '''</summary>
    <TestMethod()> _
    Public Sub buscarNewsletterPorIdTest()
        Dim actual As Newsletter = target.buscarNewsletterPorId(2)

        Assert.AreEqual(Long.Parse(2), actual.id)
        Assert.AreEqual("news2", actual.nombre)
        Assert.AreEqual(False, actual.enviado)
    End Sub

    '''<summary>
    '''A test for buscarNewsletterPorNombre
    '''</summary>
    <TestMethod()> _
    Public Sub buscarNewsletterPorNombreTest()
        Dim actual As Newsletter = target.buscarNewsletterPorNombre("news1")

        Assert.AreEqual(Long.Parse(1), actual.id)
        Assert.AreEqual("news1", actual.nombre)
        Assert.AreEqual(True, actual.enviado)
    End Sub

    '''<summary>
    '''A test for listarNewsletter
    '''</summary>
    <TestMethod()> _
    Public Sub listarNewsletterTest()
        Dim actual As List(Of Newsletter) = target.listarNewsletter()
        Assert.AreEqual(2, actual.Count)
    End Sub

    '''<summary>
    '''A test for buscarNewsletterParaEnviar
    '''</summary>
    <TestMethod()> _
    Public Sub buscarNewsletterParaEnviarTest()
        Dim actual As Newsletter = target.buscarNewsletterParaEnviar()

        Assert.AreEqual(Long.Parse(2), actual.id)
        Assert.AreEqual("news2", actual.nombre)
        Assert.AreEqual(False, actual.enviado)
    End Sub
End Class
