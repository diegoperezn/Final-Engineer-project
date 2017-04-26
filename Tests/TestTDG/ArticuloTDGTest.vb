Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for ArticuloTDGTest and is intended
'''to contain all ArticuloTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ArticuloTDGTest


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
        Dim articulo As New Articulo
        articulo.codArticulo = 4
        target.borrar(articulo)
    End Sub

#End Region

    Dim target As ArticuloTDG = RepositorioFactory.articuloTDG

    '''<summary>
    '''A test for buscarArticulos
    '''</summary>
    <TestMethod()> _
    Public Sub buscarArticulosTest()
        Dim lista As List(Of Articulo) = target.buscarArticulos(Nothing)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPrenda.tipoPrenda)
        Assert.AreEqual(Long.Parse(1), lista(0).diseño.idDiseño)
        Assert.AreEqual("com1", lista(0).comentario)
        Assert.AreEqual(Double.Parse(2.1), lista(0).precioActual)
        Assert.AreEqual(10, lista(0).produccion)
        Assert.AreEqual(2, lista(0).listaPrecios.Count)
    End Sub

    '''<summary>
    '''A test for buscarArticulos
    '''</summary>
    <TestMethod()> _
    Public Sub buscarArticulosConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ArticuloTDG.COD_ARTICULO, 1))
        criteria.Add(New Restriccion(ArticuloTDG.COMENTARIO, "com1"))
        criteria.Add(New Restriccion(ArticuloTDG.DISEÑO, 1))
        criteria.Add(New Restriccion(ArticuloTDG.PRECIO_ACTUAL, 2.1))
        criteria.Add(New Restriccion(ArticuloTDG.TIPO_PRENDA, 1))
        criteria.Add(New Restriccion(ArticuloTDG.PRODUCCION_POR_HORA, 10))
        Dim lista As List(Of Articulo) = target.buscarArticulos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPrenda.tipoPrenda)
        Assert.AreEqual(Long.Parse(1), lista(0).diseño.idDiseño)
        Assert.AreEqual("com1", lista(0).comentario)
        Assert.AreEqual(10, lista(0).produccion)
        Assert.AreEqual(Double.Parse(2.1), lista(0).precioActual)
        Assert.AreEqual(2, lista(0).listaPrecios.Count)
    End Sub

    '''<summary>
    '''A test for buscarArticulos
    '''</summary>
    <TestMethod()> _
    Public Sub grabarArticulosTest()
        Dim articulo As New Articulo(Nothing, "com4", 1.4, 10, New TipoPrenda(2, Nothing), New Diseño(2), Nothing)

        target.grabar(articulo)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ArticuloTDG.COD_ARTICULO, 4))
        Dim lista As List(Of Articulo) = target.buscarArticulos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(4), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(2), lista(0).tipoPrenda.tipoPrenda)
        Assert.AreEqual(Long.Parse(2), lista(0).diseño.idDiseño)
        Assert.AreEqual(10, lista(0).produccion)
        Assert.AreEqual("com4", lista(0).comentario)
        Assert.AreEqual(Double.Parse(1.4), lista(0).precioActual)
    End Sub

    '''<summary>
    '''A test for buscarArticulos
    '''</summary>
    <TestMethod()> _
    Public Sub modificarArticulosTest()
        Dim articulo As New Articulo(Nothing, "com4", 1.4, 10, New TipoPrenda(2, Nothing), New Diseño(2), Nothing)

        target.grabar(articulo)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ArticuloTDG.COD_ARTICULO, 4))
        Dim lista As List(Of Articulo) = target.buscarArticulos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(4), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(2), lista(0).tipoPrenda.tipoPrenda)
        Assert.AreEqual(Long.Parse(2), lista(0).diseño.idDiseño)
        Assert.AreEqual(10, lista(0).produccion)
        Assert.AreEqual("com4", lista(0).comentario)
        Assert.AreEqual(Double.Parse(1.4), lista(0).precioActual)

        lista(0).comentario = "com modificado"
        lista(0).produccion = 100

        target.actualizar(lista(0))

        lista = target.buscarArticulos(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(4), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(2), lista(0).tipoPrenda.tipoPrenda)
        Assert.AreEqual(Long.Parse(2), lista(0).diseño.idDiseño)
        Assert.AreEqual("com modificado", lista(0).comentario)
        Assert.AreEqual(Double.Parse(1.4), lista(0).precioActual)
    End Sub


    '''<summary>
    '''A test for buscarArticulos
    '''</summary>
    <TestMethod()> _
    Public Sub borrarArticulosTest()
        Dim articulo As New Articulo(Nothing, "com4", 1.4, 10, New TipoPrenda(2, Nothing), New Diseño(2), Nothing)

        Dim lista As List(Of Articulo) = target.buscarArticulos(Nothing)

        Dim cantidad As Integer = lista.Count

        target.grabar(articulo)

        lista = target.buscarArticulos(Nothing)

        Assert.AreEqual(cantidad + 1, lista.Count)

        articulo.codArticulo = 4
        target.borrar(articulo)

        lista = target.buscarArticulos(Nothing)

        Assert.AreEqual(cantidad, lista.Count)
    End Sub


    '''<summary>
    '''A test for obtenerIdsArticulosFrecuentes
    '''</summary>
    <TestMethod()> _
    Public Sub obtenerIdsArticulosFrecuentesTest()
        Dim lista As List(Of Articulo) = target.obtenerIdsArticulosFrecuentes(1)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(2), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(3), lista(1).codArticulo)
        Assert.AreEqual(Long.Parse(1), lista(2).codArticulo)

        lista = target.obtenerIdsArticulosFrecuentes(2)

        Assert.AreEqual(2, lista.Count)
        Assert.AreEqual(Long.Parse(6), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(5), lista(1).codArticulo)
    End Sub

End Class
