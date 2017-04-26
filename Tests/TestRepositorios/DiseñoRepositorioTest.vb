Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for DiseñoRepositorioTest and is intended
'''to contain all DiseñoRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DiseñoRepositorioTest


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

    Dim target As DiseñoRepositorio = RepositorioFactory.diseñoRepositorio
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
        Assert.AreEqual("nombre1", actual(0).cliente.nombre)
        Assert.AreEqual(Long.Parse(2), actual(0).estadoActual.estado)
        Assert.AreEqual(2, actual(0).historicoEstados.Count)
    End Sub

    '''<summary>
    '''A test for GrabarDiseño
    '''</summary>
    <TestMethod()> _
    Public Sub GrabarDiseñoTest()
        Dim diseño As New Diseño()
        diseño.alto = 33
        diseño.ancho = 33
        diseño.nombre = "diseño3"
        diseño.puntadas = 3333
        Dim cliente As New Cliente()
        cliente.idCliente = 1
        diseño.cliente = cliente
        diseño.pathImagen = "/cliente1/imagen/diseño1.jpg"
        diseño.pathDetalle = "/cliente1/detalle/diseño1.jpg"
        diseño.pathArchivoEditable = "/cliente1/diseñoEditable/diseño1.jpg"
        diseño.pathArchivoFinal = "/cliente1/diseño/diseño1.jpg"
        diseño.estadoActual = New EstadoDiseños(2)

        diseño.insumos = New List(Of DiseñoInsumo)
        Dim insumo As New Insumo(1)
        diseño.insumos.Add(New DiseñoInsumo(diseño, insumo, 3))

        target.grabarDiseño(diseño)

        Dim diseñoBase As Diseño = target.buscarDiseñoPorId(3)

        Assert.AreEqual(Long.Parse(1), diseñoBase.cliente.idCliente)
        Assert.AreEqual("nombre1", diseñoBase.cliente.nombre)
        Assert.AreEqual("/cliente1/imagen/diseño1.jpg", diseñoBase.pathImagen)
        Assert.AreEqual("/cliente1/detalle/diseño1.jpg", diseñoBase.pathDetalle)
        Assert.AreEqual("/cliente1/diseñoEditable/diseño1.jpg", diseñoBase.pathArchivoEditable)
        Assert.AreEqual("/cliente1/diseño/diseño1.jpg", diseñoBase.pathArchivoFinal)
        Assert.AreEqual(1, diseñoBase.insumos.Count)
        Assert.AreEqual(Long.Parse(2), diseñoBase.estadoActual.estado)
        Assert.AreEqual(Double.Parse(3), diseñoBase.insumos(0).cantidad)
    End Sub

    <TestMethod()> _
    Public Sub actualizarDiseñoTest()
        Dim diseño As New Diseño()
        diseño.alto = 33
        diseño.ancho = 33
        diseño.nombre = "diseño3"
        diseño.puntadas = 3333
        Dim cliente As New Cliente()
        cliente.idCliente = 1
        diseño.cliente = cliente
        diseño.pathImagen = "/cliente1/imagen/diseño1.jpg"
        diseño.pathDetalle = "/cliente1/detalle/diseño1.jpg"
        diseño.pathArchivoEditable = "/cliente1/diseñoEditable/diseño1.jpg"
        diseño.estadoActual = New EstadoDiseños(1)

        diseño.historicoEstados = New List(Of HistoricoEstadosDiseño)
        diseño.historicoEstados.Add(New HistoricoEstadosDiseño(Nothing, diseño, "test", DateTime.Now, Nothing, diseño.estadoActual))

        target.grabarDiseño(diseño)

        Dim diseñoBase As Diseño = target.buscarDiseñoPorId(3)

        Assert.AreEqual(Long.Parse(1), diseñoBase.cliente.idCliente)
        Assert.AreEqual(Long.Parse(1), diseñoBase.estadoActual.estado)
        Assert.AreEqual(1, diseñoBase.historicoEstados.Count)
        Assert.AreEqual(Long.Parse(1), diseñoBase.historicoEstados(0).estado.estado)
        Assert.AreEqual(1, diseñoBase.historicoEstados(0).fechaHasta.Year)
        Assert.AreEqual("nombre1", diseñoBase.cliente.nombre)
        Assert.AreEqual("/cliente1/imagen/diseño1.jpg", diseñoBase.pathImagen)
        Assert.AreEqual("/cliente1/detalle/diseño1.jpg", diseñoBase.pathDetalle)
        Assert.AreEqual("/cliente1/diseñoEditable/diseño1.jpg", diseñoBase.pathArchivoEditable)
        Assert.AreEqual("", diseñoBase.pathArchivoFinal)

        diseñoBase.insumos = New List(Of DiseñoInsumo)
        Dim insumo As New Insumo(1)
        diseñoBase.insumos.Add(New DiseñoInsumo(diseño, insumo, 3))
        diseñoBase.pathArchivoFinal = "/cliente1/diseño/diseño1.jpg"

        diseñoBase.estadoActual = New EstadoDiseños(2)
        diseñoBase.historicoEstados(0).fechaHasta = DateTime.Now
        diseñoBase.historicoEstados.Add(New HistoricoEstadosDiseño(Nothing, diseño, "test", DateTime.Now, Nothing, New EstadoDiseños(2)))

        target.ActualizarFichaDiseño(diseñoBase)

        diseño = target.buscarDiseñoPorId(3)

        Assert.AreEqual(Long.Parse(1), diseñoBase.cliente.idCliente)
        Assert.AreEqual(Long.Parse(2), diseñoBase.estadoActual.estado)
        Assert.AreEqual(2, diseñoBase.historicoEstados.Count)
        Assert.AreEqual(Long.Parse(2), diseñoBase.historicoEstados(1).estado.estado)
        Assert.AreEqual(2012, diseñoBase.historicoEstados(0).fechaHasta.Year)
        Assert.AreEqual(1, diseñoBase.historicoEstados(1).fechaHasta.Year)
        Assert.AreEqual("nombre1", diseñoBase.cliente.nombre)
        Assert.AreEqual("/cliente1/imagen/diseño1.jpg", diseñoBase.pathImagen)
        Assert.AreEqual("/cliente1/detalle/diseño1.jpg", diseñoBase.pathDetalle)
        Assert.AreEqual("/cliente1/diseñoEditable/diseño1.jpg", diseñoBase.pathArchivoEditable)
        Assert.AreEqual("/cliente1/diseño/diseño1.jpg", diseñoBase.pathArchivoFinal)
        Assert.AreEqual(1, diseñoBase.insumos.Count)
        Assert.AreEqual(Double.Parse(3), diseñoBase.insumos(0).cantidad)
    End Sub


    <TestMethod()> _
    Public Sub borrarDiseñoTest()
        Dim diseño As New Diseño()
        diseño.alto = 33
        diseño.ancho = 33
        diseño.nombre = "diseño3"
        diseño.puntadas = 3333
        Dim cliente As New Cliente()
        cliente.idCliente = 1
        diseño.cliente = cliente
        diseño.estadoActual = New EstadoDiseños(1)

        target.grabarDiseño(diseño)

        Dim lista As List(Of Diseño) = target.listarDiseños

        Assert.AreEqual(3, lista.Count)

        target.borrar(lista(2))

        lista = target.listarDiseños

        Assert.AreEqual(2, lista.Count)
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
    End Sub

End Class
