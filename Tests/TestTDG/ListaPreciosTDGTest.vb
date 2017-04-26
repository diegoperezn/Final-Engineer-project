Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for ListaPreciosTDGTest and is intended
'''to contain all ListaPreciosTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ListaPreciosTDGTest


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
        Dim precio As New ListaPrecios
        precio.nroLista = 3
        precio.articulo = New Articulo(1)

        target.borrar(precio)
    End Sub
    '
#End Region

    Dim target As ListaPreciosTDG = RepositorioFactory.listaPreciosTDG

    '''<summary>
    '''A test for cargarListaPrecio
    '''</summary>
    <TestMethod()> _
    Public Sub cargarListaPrecioTest()
        Dim lista As List(Of ListaPrecios) = target.cargarListaPrecio(Nothing)

        Dim fechaDesde As New Date(2011, 11, 11, 10, 55, 33, 110)
        Dim fechaHasta As New Date(2011, 11, 11, 11, 55, 33, 223)

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).articulo.codArticulo)
        Assert.AreEqual(Long.Parse(1), lista(0).nroLista)
        Assert.AreEqual(fechaDesde, lista(0).fechaDesde)
        Assert.AreEqual(fechaHasta, lista(0).fechaHasta)
        Assert.AreEqual(Double.Parse(1.1), lista(0).precio)
        Assert.AreEqual(False, lista(0).borrado)
    End Sub

    '''<summary>
    '''A test for cargarListaPrecio
    '''</summary>
    <TestMethod()> _
    Public Sub cargarListaPrecioConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ListaPreciosTDG.BORRADO, False))
        criteria.Add(New Restriccion(ListaPreciosTDG.COD_ARTICULO, 1))
        Dim lista As List(Of ListaPrecios) = target.cargarListaPrecio(criteria)

        Dim fechaDesde As New Date(2011, 11, 11, 10, 55, 33, 110)
        Dim fechaHasta As New Date(2011, 11, 11, 11, 55, 33, 223)

        Assert.AreEqual(2, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).articulo.codArticulo)
        Assert.AreEqual(Long.Parse(1), lista(0).nroLista)
        Assert.AreEqual(fechaDesde, lista(0).fechaDesde)
        Assert.AreEqual(fechaHasta, lista(0).fechaHasta)
        Assert.AreEqual(Double.Parse(1.1), lista(0).precio)
        Assert.AreEqual(False, lista(0).borrado)
    End Sub

    '''<summary>
    '''A test for cargarListaPrecio
    '''</summary>
    <TestMethod()> _
    Public Sub grabarListaPrecioTest()
        Dim fechaDesde As New Date(2011, 11, 11, 13, 55, 33, 110)
        Dim fechaHasta As New Date(2011, 11, 11, 14, 55, 33, 223)
        Dim precio As New ListaPrecios(Nothing, fechaDesde, fechaHasta, 3.1, New Articulo(1), False)

        target.grabar(precio)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ListaPreciosTDG.BORRADO, False))
        criteria.Add(New Restriccion(ListaPreciosTDG.COD_ARTICULO, 1))
        Dim lista As List(Of ListaPrecios) = target.cargarListaPrecio(criteria)


        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(2).articulo.codArticulo)
        Assert.AreEqual(Long.Parse(3), lista(2).nroLista)
        Assert.AreEqual(fechaDesde, lista(2).fechaDesde)
        Assert.AreEqual(fechaHasta, lista(2).fechaHasta)
        Assert.AreEqual(Double.Parse(3.1), lista(2).precio)
        Assert.AreEqual(False, lista(2).borrado)
    End Sub


    '''<summary>
    '''A test for cargarListaPrecio
    '''</summary>
    <TestMethod()> _
    Public Sub modificarListaPrecioTest()
        Dim fechaDesde As New Date(2011, 11, 11, 13, 55, 33, 110)
        Dim fechaHasta As New Date(2011, 11, 11, 14, 55, 33, 223)
        Dim precio As New ListaPrecios(Nothing, fechaDesde, fechaHasta, 3.1, New Articulo(1), False)

        target.grabar(precio)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ListaPreciosTDG.BORRADO, False))
        criteria.Add(New Restriccion(ListaPreciosTDG.COD_ARTICULO, 1))
        Dim lista As List(Of ListaPrecios) = target.cargarListaPrecio(criteria)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(2).articulo.codArticulo)
        Assert.AreEqual(Long.Parse(3), lista(2).nroLista)
        Assert.AreEqual(fechaDesde, lista(2).fechaDesde)
        Assert.AreEqual(fechaHasta, lista(2).fechaHasta)
        Assert.AreEqual(Double.Parse(3.1), lista(2).precio)
        Assert.AreEqual(False, lista(2).borrado)

        lista(2).precio = 4.4

        target.actualizar(lista(2))

        lista = target.cargarListaPrecio(criteria)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(2).articulo.codArticulo)
        Assert.AreEqual(Long.Parse(3), lista(2).nroLista)
        Assert.AreEqual(fechaDesde, lista(2).fechaDesde)
        Assert.AreEqual(fechaHasta, lista(2).fechaHasta)
        Assert.AreEqual(Double.Parse(4.4), lista(2).precio)
        Assert.AreEqual(False, lista(2).borrado)
    End Sub

    '''<summary>
    '''A test for cargarListaPrecio
    '''</summary>
    <TestMethod()> _
    Public Sub borrarListaPrecioTest()
        Dim fechaDesde As New Date(2011, 11, 11, 13, 55, 33, 110)
        Dim fechaHasta As New Date(2011, 11, 11, 14, 55, 33, 223)
        Dim precio As New ListaPrecios(Nothing, fechaDesde, fechaHasta, 3.1, New Articulo(1), False)

        target.grabar(precio)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ListaPreciosTDG.BORRADO, False))
        criteria.Add(New Restriccion(ListaPreciosTDG.COD_ARTICULO, 1))
        Dim lista As List(Of ListaPrecios) = target.cargarListaPrecio(criteria)

        Assert.AreEqual(3, lista.Count)

        target.borrar(lista(2))

        lista = target.cargarListaPrecio(criteria)

        Assert.AreEqual(2, lista.Count)
    End Sub

End Class
