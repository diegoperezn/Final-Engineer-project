Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for DiseñoBusinessTest and is intended
'''to contain all DiseñoBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DiseñoBusinessTest


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
        dao.saveOrUpdate("DELETE FROM " + DiseñoInsumoTDG.NOMBRE_TABLA + " where " + DiseñoInsumoTDG.DISEÑO.columna + "=3")
        dao.saveOrUpdate("DELETE FROM " + HistoricoEstadosDiseñoTDG.NOMBRE_TABLA + " where " + HistoricoEstadosDiseñoTDG.COD_DISEÑO.columna + "=3")
        Dim diseño As New Diseño(3)
        target.borrar(diseño)
    End Sub

#End Region

    Dim target As DiseñoBusiness = BusinessFactory.diseñoBusiness
    Dim dao As DataAccesObject = RepositorioFactory.dao

    '''<summary>
    '''A test for BuscarDiseños
    '''</summary>
    <TestMethod()> _
    Public Sub BuscarDiseñosTest()
        Dim Nombre As String = "ño1"
        Dim puntadasDesde As Integer = 500
        Dim puntadasHasta As Integer = 1500
        Dim anchoDesde As Integer = 5
        Dim anchoHasta As Integer = 15
        Dim altoDesde As Integer = 5
        Dim altoHasta As Integer = 15

        Dim actual As List(Of Diseño)
        actual = target.BuscarDiseños(Nombre, puntadasDesde, puntadasHasta, anchoDesde, anchoHasta, altoDesde, altoHasta, 1, 2)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).idDiseño)
        Assert.AreEqual(Long.Parse(2), actual(0).estadoActual.estado)
        Assert.AreEqual(2, actual(0).historicoEstados.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).historicoEstados(0).estado.estado)
        Assert.AreEqual(Long.Parse(2), actual(0).historicoEstados(1).estado.estado)
        Assert.AreEqual(2012, actual(0).historicoEstados(0).fechaHasta.Year)
    End Sub

    '''<summary>
    '''A test for actualizarDiseño
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarDiseñoTest()
        Dim cliente As New Cliente()
        cliente.idCliente = 1

        target.GrabarDiseño(Nothing, 33, 33, "diseño3", 3333, cliente, Nothing, Nothing, Nothing, Nothing, New List(Of DiseñoInsumo))

        Dim diseñoBase As Diseño = target.buscarDiseñoPorId(3)

        Assert.AreEqual(Long.Parse(1), diseñoBase.cliente.idCliente)
        Assert.AreEqual("nombre1", diseñoBase.cliente.nombre)
        Assert.AreEqual(Long.Parse(1), diseñoBase.estadoActual.estado)
        Assert.AreEqual(1, diseñoBase.historicoEstados.Count)
        Assert.AreEqual(Long.Parse(1), diseñoBase.historicoEstados(0).estado.estado)
        Assert.AreEqual(1, diseñoBase.historicoEstados(0).fechaHasta.Year)

        diseñoBase.insumos = New List(Of DiseñoInsumo)
        Dim insumo As New Insumo(1)
        diseñoBase.insumos.Add(New DiseñoInsumo(diseñoBase, insumo, 3))
        diseñoBase.pathArchivoFinal = "/cliente1/diseño/diseño1.jpg"

        target.actualizarDiseño(diseñoBase)

        diseñoBase = target.buscarDiseñoPorId(3)

        Assert.AreEqual(Long.Parse(1), diseñoBase.cliente.idCliente)
        Assert.AreEqual("nombre1", diseñoBase.cliente.nombre)
        Assert.AreEqual(Long.Parse(2), diseñoBase.estadoActual.estado)
        Assert.AreEqual(2, diseñoBase.historicoEstados.Count)
        Assert.AreEqual(Long.Parse(2), diseñoBase.historicoEstados(1).estado.estado)
        Assert.AreEqual(2012, diseñoBase.historicoEstados(0).fechaHasta.Year)
        Assert.AreEqual(1, diseñoBase.historicoEstados(1).fechaHasta.Year)

        Assert.AreEqual(1, diseñoBase.insumos.Count)
        Assert.AreEqual(Double.Parse(3), diseñoBase.insumos(0).cantidad)
    End Sub

    '''<summary>
    '''A test for buscarDiseñoPorId
    '''</summary>
    <TestMethod()> _
    Public Sub buscarDiseñoPorIdTest()
        Dim diseñoBase As Diseño = target.buscarDiseñoPorId(1)

        Assert.AreEqual(Long.Parse(1), diseñoBase.cliente.idCliente)
        Assert.AreEqual("nombre1", diseñoBase.cliente.nombre)
        'Assert.AreEqual("/cliente1/imagen/diseño1.jpg", diseñoBase.pathImagen)
        'Assert.AreEqual("/cliente1/detalle/diseño1.jpg", diseñoBase.pathDetalle)
        'Assert.AreEqual("/cliente1/diseñoEditable/diseño1.jpg", diseñoBase.pathArchivoEditable)
        'Assert.AreEqual("/cliente1/diseño/diseño1.jpg", diseñoBase.pathArchivoFinal)
        Assert.AreEqual(2, diseñoBase.insumos.Count)
        Assert.AreEqual(Double.Parse(1), diseñoBase.insumos(0).cantidad)
        Assert.AreEqual(Long.Parse(1), diseñoBase.insumos(0).insumo.codInsumo)
    End Sub

    '''<summary>
    '''A test for GrabarDiseño
    '''</summary>
    <TestMethod()> _
    Public Sub GrabarDiseñoTest()
        Dim cliente As New Cliente()
        cliente.idCliente = 1
        'Dim imagen As String = "/cliente1/imagen/diseño1.jpg"
        'Dim imagenDetalle As String = "/cliente1/detalle/diseño1.jpg"
        'Dim archivoEditable As String = "/cliente1/diseñoEditable/diseño1.jpg"
        'Dim archivoFinal As String = "/cliente1/diseño/diseño1.jpg"

        Dim insumos As New List(Of DiseñoInsumo)
        Dim insumo As New Insumo(1)
        insumos.Add(New DiseñoInsumo(Nothing, insumo, 3))

        target.GrabarDiseño(Nothing, 33, 33, "diseño3", 3333, cliente, Nothing, Nothing, Nothing, Nothing, insumos)

        Dim diseñoBase As Diseño = target.buscarDiseñoPorId(3)

        Assert.AreEqual(Long.Parse(1), diseñoBase.cliente.idCliente)
        Assert.AreEqual("nombre1", diseñoBase.cliente.nombre)
        'Assert.AreEqual("/cliente1/imagen/diseño1.jpg", diseñoBase.pathImagen)
        'Assert.AreEqual("/cliente1/detalle/diseño1.jpg", diseñoBase.pathDetalle)
        'Assert.AreEqual("/cliente1/diseñoEditable/diseño1.jpg", diseñoBase.pathArchivoEditable)
        'Assert.AreEqual("/cliente1/diseño/diseño1.jpg", diseñoBase.pathArchivoFinal)
        Assert.AreEqual(1, diseñoBase.insumos.Count)
        Assert.AreEqual(Double.Parse(3), diseñoBase.insumos(0).cantidad)
    End Sub

    '''<summary>
    '''A test for GrabarDiseño
    '''</summary>
    <TestMethod()> _
    Public Sub GrabarDiseñoTest1()
        Dim cliente As New Cliente()
        cliente.idCliente = 1
        'diseño.pathImagen = "/cliente1/imagen/diseño1.jpg"
        'diseño.pathDetalle = "/cliente1/detalle/diseño1.jpg"
        'diseño.pathArchivoEditable = "/cliente1/diseñoEditable/diseño1.jpg"
        'diseño.pathArchivoFinal = "/cliente1/diseño/diseño1.jpg"

        Dim insumos As New List(Of DiseñoInsumo)
        Dim insumo As New Insumo(1)
        insumos.Add(New DiseñoInsumo(Nothing, insumo, 3))

        target.GrabarDiseño(Nothing, 33, 33, "diseño3", 3333, cliente, Nothing, Nothing, Nothing, Nothing, insumos)

        Dim diseñoBase As Diseño = target.buscarDiseñoPorId(3)

        Assert.AreEqual(Long.Parse(1), diseñoBase.cliente.idCliente)
        Assert.AreEqual("nombre1", diseñoBase.cliente.nombre)
        'Assert.AreEqual("/cliente1/imagen/diseño1.jpg", diseñoBase.pathImagen)
        'Assert.AreEqual("/cliente1/detalle/diseño1.jpg", diseñoBase.pathDetalle)
        'Assert.AreEqual("/cliente1/diseñoEditable/diseño1.jpg", diseñoBase.pathArchivoEditable)
        'Assert.AreEqual("/cliente1/diseño/diseño1.jpg", diseñoBase.pathArchivoFinal)
        Assert.AreEqual(1, diseñoBase.insumos.Count)
        Assert.AreEqual(Double.Parse(3), diseñoBase.insumos(0).cantidad)
    End Sub

    '''<summary>
    '''A test for buscarDiseñoPorCliente
    '''</summary>
    <TestMethod()> _
    Public Sub buscarDiseñoPorClienteTest()
        Dim cliente As New Cliente(1)
        Dim actual As List(Of Diseño) = target.buscarDiseñoPorCliente(cliente)

        Assert.AreEqual(2, actual.Count)
        Assert.AreEqual(Long.Parse(1), actual(0).idDiseño)
        Assert.AreEqual("nombre1", actual(0).cliente.nombre)
        Assert.AreEqual(2, actual(0).insumos.Count)
        'Assert.AreEqual("/cliente1/detalle/diseño1.jpg", actual(0).pathDetalle)
        'Assert.AreEqual("/cliente1/detalle/diseño2.jpg", actual(1).pathDetalle)
    End Sub

End Class
