Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for NewsletterBusinessTest and is intended
'''to contain all NewsletterBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class NewsletterBusinessTest


    Private testContextInstance As TestContext

    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

    Dim target As NewsletterBusiness = BusinessFactory.newsletterBusiness

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

    <TestMethod()> _
    Public Sub buscarNewsletterPorIdTest()
        Dim actual As Newsletter = target.buscarNewsletterPorId(2)

        Assert.AreEqual(Long.Parse(2), actual.id)
        Assert.AreEqual("news2", actual.nombre)
        Assert.AreEqual(False, actual.enviado)
    End Sub

    <TestMethod()> _
    Public Sub buscarNewsletterPorNombreTest()
        Dim actual As Newsletter = target.buscarNewsletterPorNombre("news1")

        Assert.AreEqual(Long.Parse(1), actual.id)
        Assert.AreEqual("news1", actual.nombre)
        Assert.AreEqual(True, actual.enviado)
    End Sub

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

    <TestMethod()> _
    Public Sub listarNewsletterTest()
        Dim actual As List(Of Newsletter) = target.listarNewsletter()
        Assert.AreEqual(2, actual.Count)
    End Sub

    <TestMethod()> _
    Public Sub buscarNewsletterParaEnviarTest()
        Dim actual As Newsletter = target.buscarNewsletterParaEnviar()

        Assert.AreEqual(Long.Parse(2), actual.id)
        Assert.AreEqual("news2", actual.nombre)
        Assert.AreEqual(False, actual.enviado)
    End Sub

End Class
