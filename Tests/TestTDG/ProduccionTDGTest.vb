Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for ProduccionTDGTest and is intended
'''to contain all ProduccionTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ProduccionTDGTest


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
        Dim prod As New Produccion(7, "comentario test", New Pedido(3), New Maquina(3), 10, New Articulo(7),
                                   Nothing, Nothing, New EstadoTrabajos(2), DateTime.Now, DateTime.Now, 1)
        target.borrar(prod)
    End Sub

#End Region

    Dim target As ProduccionTDG = RepositorioFactory.produccionTDG

    '''<summary>
    '''A test for cargarlistaProduccion
    '''</summary>
    <TestMethod()> _
    Public Sub cargarlistaProduccionTest()
        Dim producciones As List(Of Produccion) = target.cargarlistaProduccion(Nothing)

        Assert.AreEqual(6, producciones.Count)
        Assert.AreEqual(Long.Parse(1), producciones(0).codProduccion)
        Assert.AreEqual(Long.Parse(1), producciones(0).pedido.codPedido)
        Assert.AreEqual(Long.Parse(1), producciones(0).articulo.codArticulo)
        Assert.AreEqual(Long.Parse(1), producciones(0).maquina.codMaquina)

        Assert.AreEqual(3, producciones(0).historicoProduccion.Count)
        Assert.AreEqual("comentario 11", producciones(0).comentario)
        Assert.AreEqual(False, producciones(0).borrado)
        Assert.AreEqual(Long.Parse(1), producciones(0).codProduccion)

        Assert.AreEqual(Long.Parse(3), producciones(0).estadoActual.estado)
        Assert.IsNotNull(producciones(0).fechaInicio)
        Assert.IsNotNull(producciones(0).fechaFinal)
    End Sub

    '''<summary>
    '''A test for cargarlistaProduccion
    '''</summary>
    <TestMethod()> _
    Public Sub cargarlistaProduccionConRestriccionesTest()
        Dim criterias As New List(Of Restriccion)
        criterias.Add(New Restriccion(ProduccionTDG.COD_PRODUCCION, 1))
        criterias.Add(New Restriccion(ProduccionTDG.PEDIDO, 1))
        criterias.Add(New Restriccion(ProduccionTDG.ARTICULO, 1))
        criterias.Add(New Restriccion(ProduccionTDG.MAQUINA, 1))
        criterias.Add(New Restriccion(ProduccionTDG.ESTADO_ACTUAL, 3))
        criterias.Add(New Restriccion(ProduccionTDG.COMENTARIO, "rio", Restriccion.CONDICION_LIKE))
        criterias.Add(New Restriccion(ProduccionTDG.BORRADO, False))
        Dim producciones As List(Of Produccion) = target.cargarlistaProduccion(criterias)

        Assert.AreEqual(1, producciones.Count)
        Assert.AreEqual(Long.Parse(1), producciones(0).codProduccion)
        Assert.AreEqual(Long.Parse(1), producciones(0).pedido.codPedido)
        Assert.AreEqual(Long.Parse(1), producciones(0).articulo.codArticulo)
        Assert.AreEqual(Long.Parse(1), producciones(0).maquina.codMaquina)
        Assert.AreEqual(3, producciones(0).historicoProduccion.Count)
        Assert.AreEqual("comentario 11", producciones(0).comentario)
        Assert.AreEqual(False, producciones(0).borrado)
        Assert.AreEqual(Long.Parse(1), producciones(0).codProduccion)

        Assert.AreEqual(Long.Parse(3), producciones(0).estadoActual.estado)
        Assert.IsNotNull(producciones(0).fechaInicio)
        Assert.IsNotNull(producciones(0).fechaFinal)
    End Sub

    '''<summary>
    '''A test for cargarlistaProduccion
    '''</summary>
    <TestMethod()> _
    Public Sub grabarProduccionTest()
        Dim prod As New Produccion(Nothing, "comentario test", New Pedido(3), New Maquina(3), 10, New Articulo(7),
                                         Nothing, Nothing, New EstadoTrabajos(2), DateTime.Now, DateTime.Now, 1)

        target.grabar(prod)

        Dim criterias As New List(Of Restriccion)
        criterias.Add(New Restriccion(ProduccionTDG.COMENTARIO, "comentario test", Restriccion.CONDICION_LIKE))
        Dim producciones As List(Of Produccion) = target.cargarlistaProduccion(criterias)

        Assert.AreEqual(1, producciones.Count)
        Assert.AreEqual(Long.Parse(7), producciones(0).codProduccion)
        Assert.AreEqual(Long.Parse(3), producciones(0).pedido.codPedido)
        Assert.AreEqual(Long.Parse(7), producciones(0).articulo.codArticulo)
        Assert.AreEqual(Long.Parse(3), producciones(0).maquina.codMaquina)
        Assert.AreEqual(0, producciones(0).historicoProduccion.Count)
        Assert.AreEqual("comentario test", producciones(0).comentario)
        Assert.AreEqual(Long.Parse(2), producciones(0).estadoActual.estado)
        Assert.AreEqual(False, producciones(0).borrado)

        Assert.AreEqual(Long.Parse(2), producciones(0).estadoActual.estado)
        Assert.IsNotNull(producciones(0).fechaInicio)
        Assert.IsNotNull(producciones(0).fechaFinal)
    End Sub

    '''<summary>
    '''A test for cargarlistaProduccion
    '''</summary>
    <TestMethod()> _
    Public Sub modificarProduccionTest()
        Dim prod As New Produccion(Nothing, "comentario test", New Pedido(3), New Maquina(3), 10, New Articulo(7),
                                   Nothing, Nothing, New EstadoTrabajos(2), DateTime.Now, DateTime.Now, 1)

        target.grabar(prod)

        Dim criterias As New List(Of Restriccion)
        criterias.Add(New Restriccion(ProduccionTDG.COMENTARIO, "comentario test", Restriccion.CONDICION_LIKE))
        Dim producciones As List(Of Produccion) = target.cargarlistaProduccion(criterias)

        Assert.AreEqual(1, producciones.Count)
        Assert.AreEqual(Long.Parse(7), producciones(0).articulo.codArticulo)

        prod = producciones(0)
        prod.articulo.codArticulo = 5
        prod.estadoActual = New EstadoTrabajos(3)

        target.actualizar(prod)

        producciones = target.cargarlistaProduccion(criterias)

        Assert.AreEqual(1, producciones.Count)
        Assert.AreEqual("comentario test", producciones(0).comentario)
        Assert.AreEqual(Long.Parse(7), producciones(0).codProduccion)
        Assert.AreEqual(Long.Parse(3), producciones(0).pedido.codPedido)
        Assert.AreEqual(Long.Parse(5), producciones(0).articulo.codArticulo)
        Assert.AreEqual(Long.Parse(3), producciones(0).maquina.codMaquina)
        Assert.AreEqual(0, producciones(0).historicoProduccion.Count)
        Assert.AreEqual(10, producciones(0).cantidad)
        Assert.AreEqual(False, producciones(0).borrado)
        Assert.AreEqual(Long.Parse(3), producciones(0).estadoActual.estado)
        Assert.IsNotNull(producciones(0).fechaInicio)
        Assert.IsNotNull(producciones(0).fechaFinal)
    End Sub

    '''<summary>
    '''A test for cargarlistaProduccion
    '''</summary>
    <TestMethod()> _
    Public Sub borrarProduccionTest()
        Dim prod As New Produccion(Nothing, "comentario test", New Pedido(3), New Maquina(3), 10, New Articulo(7),
                                   Nothing, Nothing, New EstadoTrabajos(2), DateTime.Now, DateTime.Now, 1)

        target.grabar(prod)

        Dim criterias As New List(Of Restriccion)
        criterias.Add(New Restriccion(ProduccionTDG.COMENTARIO, "comentario test", Restriccion.CONDICION_LIKE))
        Dim producciones As List(Of Produccion) = target.cargarlistaProduccion(criterias)

        Assert.AreEqual(1, producciones.Count)
        Assert.AreEqual(Long.Parse(7), producciones(0).articulo.codArticulo)

        target.borrar(prod)

        producciones = target.cargarlistaProduccion(criterias)

        Assert.AreEqual(0, producciones.Count)
    End Sub

End Class
