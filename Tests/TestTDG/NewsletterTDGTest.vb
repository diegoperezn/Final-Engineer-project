Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for NewsletterTDGTest and is intended
'''to contain all NewsletterTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class NewsletterTDGTest


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

    Dim target As NewsletterTDG = RepositorioFactory.newsletterTDG

    <TestMethod()> _
    Public Sub cargarNewsletterTest()
        Dim actual As List(Of Newsletter) = target.cargarNewsletter(Nothing)
        Assert.AreEqual(2, actual.Count)
    End Sub

    <TestMethod()> _
    Public Sub buscarNewsletterPorIDTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(NewsletterTDG.ID_NEWSLETTER, 2, Restriccion.CONDICION_IGUAL))

        Dim actual As List(Of Newsletter) = target.cargarNewsletter(criteria)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(2), actual(0).id)
        Assert.AreEqual("news2", actual(0).nombre)
        Assert.AreEqual(False, actual(0).enviado)
    End Sub

    '''<summary>
    '''A test for buscarPrendas
    '''</summary>
    <TestMethod()> _
    Public Sub buscarNewsletterPorNombreTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(NewsletterTDG.NOMBRE, "news1", Restriccion.CONDICION_IGUAL))

        Dim actual As List(Of Newsletter) = target.cargarNewsletter(criteria)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual("news1", actual(0).nombre)
        Assert.AreEqual(True, actual(0).enviado)
    End Sub

    '''<summary>
    '''A test for actualizarPrenda
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarNewsletterTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(NewsletterTDG.NOMBRE, "news1", Restriccion.CONDICION_IGUAL))
        Dim newsletterOriginal As Newsletter = target.buscarUnico(criteria)

        Dim newsletterModificado As Newsletter = New Newsletter(newsletterOriginal.id, newsletterOriginal.nombre,
                                                      newsletterOriginal.newsletter, True)
        target.actualizar(newsletterModificado)

        criteria.Clear()
        criteria.Add(New Restriccion(NewsletterTDG.ID_NEWSLETTER, 1, Restriccion.CONDICION_IGUAL))
        Dim newsBase As Newsletter = target.buscarUnico(criteria)

        Assert.AreEqual(True, newsBase.enviado)

        target.actualizar(newsletterModificado)
    End Sub

    '''<summary>
    '''A test for grabarTipoPrenda
    '''</summary>
    <TestMethod()> _
    Public Sub grabarNewsletterTest()
        Dim newsletterNuevo As Newsletter = New Newsletter(Nothing, "news3", "html", False)
        target.grabar(newsletterNuevo)

        Dim actual As List(Of Newsletter) = target.cargarNewsletter(Nothing)
        Assert.AreEqual(3, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).id)
        Assert.AreEqual("news1", actual(0).nombre)
        Assert.AreEqual(True, actual(0).enviado)

        target.borrar(newsletterNuevo)
    End Sub

    '''<summary>
    '''A test for borrarUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub borrarNewsletterTest()
        Dim newsletterNuevo As Newsletter = New Newsletter(Nothing, "news3", "html", False)
        target.grabar(newsletterNuevo)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(NewsletterTDG.ID_NEWSLETTER, 3, Restriccion.CONDICION_IGUAL))

        Dim newsBase As Newsletter = target.buscarUnico(criterio)

        Assert.IsNotNull(newsBase)

        target.borrar(newsBase)

        newsBase = target.buscarUnico(criterio)

        Assert.IsNull(newsBase)
    End Sub
End Class
