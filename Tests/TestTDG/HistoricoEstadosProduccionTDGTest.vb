Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for HistoricoEstadosProduccionTDGTest and is intended
'''to contain all HistoricoEstadosProduccionTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class HistoricoEstadosProduccionTDGTest


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

    Dim target As HistoricoEstadosProduccionTDG = RepositorioFactory.historicoEstadosProduccionTDG

    '''<summary>
    '''A test for cargarHistoricoEstados
    '''</summary>
    <TestMethod()> _
    Public Sub cargarHistoricoEstadosTest()
        Dim estados As List(Of HistoricoProduccion)

        estados = target.cargarHistoricoEstados(Nothing)

        Assert.AreEqual(5, estados.Count)
        Assert.AreEqual(Long.Parse(1), estados(0).nroEstado)
        Assert.AreEqual(Long.Parse(1), estados(0).produccion.codProduccion)
        Assert.AreEqual(Long.Parse(1), estados(0).estadoTrabajo.estado)
        Assert.AreEqual("comentario11", estados(0).comentario)
        Assert.AreEqual(False, estados(0).borrado)
    End Sub

    '''<summary>
    '''A test for cargarHistoricoEstados
    '''</summary>
    <TestMethod()> _
    Public Sub modificarHistoricoEstadosTest()
        Dim estado As HistoricoProduccion

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(HistoricoEstadosProduccionTDG.NRO_ESTADO, 1))
        criteria.Add(New Restriccion(HistoricoEstadosProduccionTDG.PRODUCCION, 1))
        estado = target.buscarUnico(criteria)

        Assert.AreEqual("comentario11", estado.comentario)

        estado.comentario = "comentarioModificado"

        target.actualizar(estado)

        Dim estadoBase As HistoricoProduccion = target.buscarUnico(criteria)

        Assert.AreEqual("comentarioModificado", estado.comentario)

        estado.comentario = "comentario11"
        target.actualizar(estado)
    End Sub

    '''<summary>
    '''A test for cargarHistoricoEstados
    '''</summary>
    <TestMethod()> _
    Public Sub grabarHistoricoEstadosTest()
        Dim estado As New HistoricoProduccion

        estado.borrado = False
        estado.comentario = "comentario32"
        Dim estadoproduccion As New EstadoTrabajos()
        estadoproduccion.estado = 3
        estado.estadoTrabajo = estadoproduccion
        estado.fechaDesde = DateTime.Now
        estado.fechaHasta = DateTime.Now
        estado.produccion = New Produccion()
        estado.produccion.codProduccion = 2

        target.grabar(estado)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(HistoricoEstadosProduccionTDG.NRO_ESTADO, 3))
        criteria.Add(New Restriccion(HistoricoEstadosProduccionTDG.PRODUCCION, 2))
        estado = target.buscarUnico(criteria)

        Assert.AreEqual(False, estado.borrado)
        Assert.AreEqual("comentario32", estado.comentario)
        Assert.AreEqual(Long.Parse(3), estado.estadoTrabajo.estado)
        Assert.IsNotNull(estado.fechaDesde)
        Assert.IsNotNull(estado.fechaHasta)

        target.borrar(estado)
    End Sub

    '''<summary>
    '''A test for cargarHistoricoEstados
    '''</summary>
    <TestMethod()> _
    Public Sub borrarHistoricoEstadosTest()
        Dim estado As New HistoricoProduccion

        estado.borrado = False
        estado.comentario = "comentario32"
        Dim estadoproduccion As New EstadoTrabajos()
        estadoproduccion.estado = 3
        estado.estadoTrabajo = estadoproduccion
        estado.fechaDesde = DateTime.Now
        estado.fechaHasta = DateTime.Now
        estado.produccion = New Produccion()
        estado.produccion.codProduccion = 2

        target.grabar(estado)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(HistoricoEstadosProduccionTDG.NRO_ESTADO, 3))
        criteria.Add(New Restriccion(HistoricoEstadosProduccionTDG.PRODUCCION, 2))
        estado = target.buscarUnico(criteria)

        Assert.AreEqual(False, estado.borrado)

        target.borrar(estado)

        estado = target.buscarUnico(criteria)
        Assert.IsNull(estado)
    End Sub

End Class
