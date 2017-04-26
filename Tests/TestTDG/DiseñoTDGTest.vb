Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for DiseñoTDGTest and is intended
'''to contain all DiseñoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DiseñoTDGTest


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

    Dim target As DiseñoTDG = RepositorioFactory.diseñoTDG

    '''<summary>
    '''A test for cargarFamilias
    '''</summary>
    <TestMethod()> _
    Public Sub cargarDiseñosTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(DiseñoTDG.ALTO, 5, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(DiseñoTDG.ALTO, 15, Restriccion.CONDICION_MENOR_IGUAL))
        criteria.Add(New Restriccion(DiseñoTDG.ANCHO, 5, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(DiseñoTDG.ANCHO, 15, Restriccion.CONDICION_MENOR_IGUAL))
        criteria.Add(New Restriccion(DiseñoTDG.NOMBRE, "ño1", Restriccion.CONDICION_LIKE))
        criteria.Add(New Restriccion(DiseñoTDG.PUNTADA, 500, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(DiseñoTDG.PUNTADA, 1500, Restriccion.CONDICION_MENOR_IGUAL))
        criteria.Add(New Restriccion(DiseñoTDG.CLIENTE, 1, Restriccion.CONDICION_IGUAL))

        Dim diseños As List(Of Diseño) = target.cargarDiseños(criteria)

        Assert.AreEqual(1, diseños.Count)
        Assert.AreEqual("/cliente1/imagen/diseño1.jpg", diseños(0).pathImagen)
        Assert.AreEqual("/cliente1/detalle/diseño1.jpg", diseños(0).pathDetalle)
        Assert.AreEqual("/cliente1/diseñoEditable/diseño1.jpg", diseños(0).pathArchivoEditable)
        Assert.AreEqual("/cliente1/diseño/diseño1.jpg", diseños(0).pathArchivoFinal)
    End Sub

    <TestMethod()> _
    Public Sub grabarDiseñosTest()
        Dim diseño As New Diseño()
        diseño.alto = 33
        diseño.ancho = 33
        diseño.nombre = "diseño3"
        diseño.puntadas = 3333
        diseño.estadoActual = New EstadoDiseños(1)
        Dim cliente As New Cliente()
        cliente.idCliente = 1
        diseño.cliente = cliente
        diseño.pathImagen = "/cliente1/imagen/diseño1.jpg"
        diseño.pathDetalle = "/cliente1/detalle/diseño1.jpg"
        diseño.pathArchivoEditable = "/cliente1/diseñoEditable/diseño1.jpg"
        diseño.pathArchivoFinal = "/cliente1/diseño/diseño1.jpg"


        target.grabar(diseño)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(DiseñoTDG.ID_DISEÑO, 3))
        Dim diseñoBase As Diseño = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), diseñoBase.cliente.idCliente)
        Assert.AreEqual("/cliente1/imagen/diseño1.jpg", diseñoBase.pathImagen)
        Assert.AreEqual("/cliente1/detalle/diseño1.jpg", diseñoBase.pathDetalle)
        Assert.AreEqual("/cliente1/diseñoEditable/diseño1.jpg", diseñoBase.pathArchivoEditable)
        Assert.AreEqual("/cliente1/diseño/diseño1.jpg", diseñoBase.pathArchivoFinal)

        target.borrar(diseño)
    End Sub

    <TestMethod()> _
    Public Sub actualizarDiseñosTest()
        Dim diseño As New Diseño()
        diseño.alto = 33
        diseño.ancho = 33
        diseño.nombre = "diseño3"
        diseño.puntadas = 3333
        Dim cliente As New Cliente()
        cliente.idCliente = 1
        diseño.cliente = cliente
        diseño.estadoActual = New EstadoDiseños(1)
        diseño.pathImagen = "/cliente1/imagen/diseño1.jpg"
        diseño.pathDetalle = "/cliente1/detalle/diseño1.jpg"
        diseño.pathArchivoEditable = "/cliente1/diseñoEditable/diseño1.jpg"
        diseño.pathArchivoFinal = "/cliente1/diseño/diseño1.jpg"

        target.grabar(diseño)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(DiseñoTDG.ID_DISEÑO, 3))
        Dim diseñoBase As Diseño = target.buscarUnico(criteria)

        diseñoBase.alto = 333
        diseñoBase.ancho = 333
        diseñoBase.nombre = "diseño33"
        diseñoBase.puntadas = 33333
        Dim cliente2 As New Cliente()
        cliente2.idCliente = 2
        diseñoBase.cliente = cliente2
        diseñoBase.pathImagen = "/cliente1/imagen/diseño3.jpg"
        diseñoBase.pathDetalle = "/cliente1/detalle/diseño3.jpg"
        diseñoBase.pathArchivoEditable = "/cliente1/diseñoEditable/diseño3.jpg"
        diseñoBase.pathArchivoFinal = "/cliente1/diseño/diseño3.jpg"

        target.actualizar(diseñoBase)

        Dim diseñoBasem As Diseño = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(2), diseñoBasem.cliente.idCliente)
        Assert.AreEqual(Double.Parse(333), diseñoBasem.alto)
        Assert.AreEqual(Double.Parse(333), diseñoBasem.ancho)
        Assert.AreEqual("diseño33", diseñoBasem.nombre)
        Assert.AreEqual(33333, diseñoBasem.puntadas)
        Assert.AreEqual(Long.Parse(2), diseñoBasem.cliente.idCliente)

        'Assert.AreEqual("/cliente1/imagen/diseño3.jpg", diseñoBasem.pathImagen)
        'Assert.AreEqual("/cliente1/detalle/diseño3.jpg", diseñoBasem.pathDetalle)
        'Assert.AreEqual("/cliente1/diseñoEditable/diseño3.jpg", diseñoBasem.pathArchivoEditable)
        'Assert.AreEqual("/cliente1/diseño/diseño3.jpg", diseñoBasem.pathArchivoFinal)

        target.borrar(diseño)
    End Sub

    <TestMethod()> _
    Public Sub borrarDiseñosTest()
        Dim diseño As New Diseño()
        diseño.alto = 33
        diseño.ancho = 33
        diseño.nombre = "diseño3"
        diseño.puntadas = 3333
        Dim cliente As New Cliente()
        cliente.idCliente = 1
        diseño.cliente = cliente
        diseño.estadoActual = New EstadoDiseños(1)
        diseño.pathImagen = "/cliente1/imagen/diseño1.jpg"
        diseño.pathDetalle = "/cliente1/detalle/diseño1.jpg"
        diseño.pathArchivoEditable = "/cliente1/diseñoEditable/diseño1.jpg"
        diseño.pathArchivoFinal = "/cliente1/diseño/diseño1.jpg"

        target.grabar(diseño)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(DiseñoTDG.CLIENTE, 1))
        Dim diseños As List(Of Diseño) = target.cargarDiseños(criteria)

        Assert.AreEqual(3, diseños.Count)

        target.borrar(diseño)

        diseños = target.cargarDiseños(criteria)

        Assert.AreEqual(2, diseños.Count)
    End Sub



End Class
