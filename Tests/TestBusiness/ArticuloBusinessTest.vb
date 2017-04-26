Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for ArticuloBusinessTest and is intended
'''to contain all ArticuloBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ArticuloBusinessTest


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
        Dim precios As New List(Of ListaPrecios)
        precios.Add(New ListaPrecios(1, DateTime.Now, Nothing, 1, Nothing, False))
        Dim articulo As New Articulo(4, "com test", 1, 10, New TipoPrenda(3), New Diseño(2), precios)
        articulo.listaPrecios(0).articulo = articulo
        articulo.listaPrecios.Add(New ListaPrecios(2, DateTime.Now, Nothing, 1, articulo, False))

        Me.preciosTdg.borrar(articulo.listaPrecios(0))
        Me.preciosTdg.borrar(articulo.listaPrecios(1))
        Me.artTdg.borrar(articulo)
    End Sub

    Dim target As ArticuloBusiness = BusinessFactory.articuloBusiness
    Dim artTdg As ArticuloTDG = RepositorioFactory.articuloTDG
    Dim preciosTdg As ListaPreciosTDG = RepositorioFactory.listaPreciosTDG

#End Region

    '''<summary>
    '''A test for guardarArticulo
    '''</summary>
    <TestMethod()> _
    Public Sub guardarArticuloTest()
        Dim articulo As New Articulo(Nothing, "com test", 1, 10, New TipoPrenda(3), New Diseño(2), Nothing)

        target.guardarArticulo(articulo)

        Dim articuloBase As Articulo = target.buscarArticulosPorCodigo(4)

        Assert.AreEqual(Long.Parse(4), articuloBase.codArticulo)
        Assert.AreEqual(Long.Parse(3), articuloBase.tipoPrenda.tipoPrenda)
        Assert.AreEqual("manga", articuloBase.tipoPrenda.descripcion)
        Assert.AreEqual(False, articuloBase.borrado)
        Assert.AreEqual(Long.Parse(2), articuloBase.diseño.idDiseño)
        Assert.AreEqual("diseño2", articuloBase.diseño.nombre)
        Assert.AreEqual("com test", articuloBase.comentario)
        Assert.AreEqual(Double.Parse(1), articuloBase.precioActual)
        Assert.AreEqual(1, articuloBase.listaPrecios.Count)
        Assert.AreEqual(10, articuloBase.produccion)
        Assert.AreEqual(Double.Parse(1), articuloBase.listaPrecios(0).precio)
    End Sub

    '''<summary>
    '''A test for listarArticulosPorDiseño
    '''</summary>
    <TestMethod()> _
    Public Sub listarArticulosPorDiseñoTest()
        Dim lista As List(Of Articulo) = target.listarArticulosPorDiseño(New Diseño(1))

        Assert.AreEqual(2, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPrenda.tipoPrenda)
        Assert.AreEqual("Campera Armada", lista(0).tipoPrenda.descripcion)
        Assert.AreEqual(Long.Parse(1), lista(0).diseño.idDiseño)
        Assert.AreEqual("diseño1", lista(0).diseño.nombre)
        Assert.AreEqual("com1", lista(0).comentario)
        Assert.AreEqual(Double.Parse(2.1), lista(0).precioActual)
        Assert.AreEqual(2, lista(0).listaPrecios.Count)
        Assert.AreEqual(10, lista(0).produccion)
        Assert.AreEqual(Double.Parse(1.1), lista(0).listaPrecios(0).precio)
    End Sub

    '''<summary>
    '''A test for listarArticulosPorPrenda
    '''</summary>
    <TestMethod()> _
    Public Sub listarArticulosPorPrendaTest()
        Dim prenda As New TipoPrenda(1)
        Dim lista As List(Of Articulo) = target.listarArticulosPorPrenda(prenda)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPrenda.tipoPrenda)
        Assert.AreEqual("Campera Armada", lista(0).tipoPrenda.descripcion)
        Assert.AreEqual(Long.Parse(1), lista(0).diseño.idDiseño)
        Assert.AreEqual("diseño1", lista(0).diseño.nombre)
        Assert.AreEqual("com1", lista(0).comentario)
        Assert.AreEqual(Double.Parse(2.1), lista(0).precioActual)
        Assert.AreEqual(2, lista(0).listaPrecios.Count)
        Assert.AreEqual(10, lista(0).produccion)
        Assert.AreEqual(Double.Parse(1.1), lista(0).listaPrecios(0).precio)
    End Sub

    '''<summary>
    '''A test for buscarArticulosPorCodigo
    '''</summary>
    <TestMethod()> _
    Public Sub buscarArticulosPorCodigoTest()
        Dim articulo As Articulo = target.buscarArticulosPorCodigo(1)

        Assert.AreEqual(Long.Parse(1), articulo.codArticulo)
        Assert.AreEqual(Long.Parse(1), articulo.tipoPrenda.tipoPrenda)
        Assert.AreEqual("Campera Armada", articulo.tipoPrenda.descripcion)
        Assert.AreEqual(Long.Parse(1), articulo.diseño.idDiseño)
        Assert.AreEqual("diseño1", articulo.diseño.nombre)
        Assert.AreEqual("com1", articulo.comentario)
        Assert.AreEqual(Double.Parse(2.1), articulo.precioActual)
        Assert.AreEqual(2, articulo.listaPrecios.Count)
        Assert.AreEqual(10, articulo.produccion)
        Assert.AreEqual(Double.Parse(1.1), articulo.listaPrecios(0).precio)
    End Sub

    '''<summary>
    '''A test for borrarArticulo
    '''</summary>
    <TestMethod()> _
    Public Sub borrarArticuloTest()
        Dim articulo As New Articulo(Nothing, "com test", 1, 10, New TipoPrenda(3), New Diseño(2), Nothing)

        target.guardarArticulo(articulo)

        Dim articuloBase As Articulo = target.buscarArticulosPorCodigo(4)

        Assert.AreEqual(Long.Parse(4), articuloBase.codArticulo)
        Assert.AreEqual(Long.Parse(3), articuloBase.tipoPrenda.tipoPrenda)
        Assert.AreEqual("manga", articuloBase.tipoPrenda.descripcion)
        Assert.AreEqual(False, articuloBase.borrado)
        Assert.AreEqual(Long.Parse(2), articuloBase.diseño.idDiseño)
        Assert.AreEqual("diseño2", articuloBase.diseño.nombre)
        Assert.AreEqual("com test", articuloBase.comentario)
        Assert.AreEqual(Double.Parse(1), articuloBase.precioActual)
        Assert.AreEqual(1, articuloBase.listaPrecios.Count)
        Assert.AreEqual(10, articuloBase.produccion)
        Assert.AreEqual(Double.Parse(1), articuloBase.listaPrecios(0).precio)

        target.borrarArticulo(articuloBase)

        Dim articuloBaseBorrado As Articulo = target.buscarArticulosPorCodigo(4)

        Assert.AreEqual(Long.Parse(4), articuloBaseBorrado.codArticulo)
        Assert.AreEqual(Long.Parse(3), articuloBaseBorrado.tipoPrenda.tipoPrenda)
        Assert.AreEqual("manga", articuloBaseBorrado.tipoPrenda.descripcion)
        Assert.AreEqual(True, articuloBaseBorrado.borrado)
        Assert.AreEqual(Long.Parse(2), articuloBaseBorrado.diseño.idDiseño)
        Assert.AreEqual("diseño2", articuloBaseBorrado.diseño.nombre)
        Assert.AreEqual("com test", articuloBaseBorrado.comentario)
        Assert.AreEqual(Double.Parse(1), articuloBaseBorrado.precioActual)
        Assert.AreEqual(1, articuloBaseBorrado.listaPrecios.Count)
        Assert.AreEqual(Double.Parse(1), articuloBase.listaPrecios(0).precio)
    End Sub

    '''<summary>
    '''A test for actualizaArticulo
    '''</summary>
    <TestMethod()> _
    Public Sub actualizaArticuloTest()
        Dim articulo As New Articulo(Nothing, "com test", 1, 10, New TipoPrenda(3), New Diseño(2), Nothing)

        target.guardarArticulo(articulo)

        Dim articuloBase As Articulo = target.buscarArticulosPorCodigo(4)

        Assert.AreEqual(Long.Parse(4), articuloBase.codArticulo)
        Assert.AreEqual(Long.Parse(3), articuloBase.tipoPrenda.tipoPrenda)
        Assert.AreEqual("manga", articuloBase.tipoPrenda.descripcion)
        Assert.AreEqual(False, articuloBase.borrado)
        Assert.AreEqual(Long.Parse(2), articuloBase.diseño.idDiseño)
        Assert.AreEqual("diseño2", articuloBase.diseño.nombre)
        Assert.AreEqual("com test", articuloBase.comentario)
        Assert.AreEqual(Double.Parse(1), articuloBase.precioActual)
        Assert.AreEqual(1, articuloBase.listaPrecios.Count)
        Assert.AreEqual(Double.Parse(1), articuloBase.listaPrecios(0).precio)

        Dim fecha As DateTime = New DateTime(2012, 11, 11)

        articuloBase.precioActual = 2
        articuloBase.produccion = 8

        target.actualizaArticulo(articuloBase)

        Dim articuloBaseEditado As Articulo = target.buscarArticulosPorCodigo(4)

        Assert.AreEqual(Long.Parse(4), articuloBaseEditado.codArticulo)
        Assert.AreEqual(Long.Parse(3), articuloBaseEditado.tipoPrenda.tipoPrenda)
        Assert.AreEqual("manga", articuloBaseEditado.tipoPrenda.descripcion)
        Assert.AreEqual(False, articuloBaseEditado.borrado)
        Assert.AreEqual(Long.Parse(2), articuloBaseEditado.diseño.idDiseño)
        Assert.AreEqual("diseño2", articuloBaseEditado.diseño.nombre)
        Assert.AreEqual("com test", articuloBaseEditado.comentario)
        Assert.AreEqual(Double.Parse(2), articuloBaseEditado.precioActual)
        Assert.AreEqual(2, articuloBaseEditado.listaPrecios.Count)
        Assert.AreEqual(8, articuloBaseEditado.produccion)
        Assert.AreEqual(Double.Parse(2), articuloBaseEditado.listaPrecios(1).precio)
    End Sub

    '''<summary>
    '''A test for listarArticulos
    '''</summary>
    <TestMethod()> _
    Public Sub listarArticulosTest()
        Dim lista As List(Of Articulo) = target.listarArticulos

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codArticulo)
        Assert.AreEqual(Long.Parse(1), lista(0).tipoPrenda.tipoPrenda)
        Assert.AreEqual("Campera Armada", lista(0).tipoPrenda.descripcion)
        Assert.AreEqual(Long.Parse(1), lista(0).diseño.idDiseño)
        Assert.AreEqual("diseño1", lista(0).diseño.nombre)
        Assert.AreEqual("com1", lista(0).comentario)
        Assert.AreEqual(Double.Parse(2.1), lista(0).precioActual)
        Assert.AreEqual(2, lista(0).listaPrecios.Count)
        Assert.AreEqual(Double.Parse(1.1), lista(0).listaPrecios(0).precio)
    End Sub
   
End Class
