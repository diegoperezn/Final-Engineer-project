Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for ProduccionOperadorTDGTest and is intended
'''to contain all ProduccionOperadorTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ProduccionOperadorTDGTest


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


    '1	1	50
    '1	2	50
    '2	2	100
    '3	1	70
    '3	2	30
    '4	1	100
    '5	2	100

    Dim target As ProduccionOperadorTDG = RepositorioFactory.produccionOperadorTDG

    <TestMethod()> _
    Public Sub buscarTodoTest()
        Dim lista As List(Of ProduccionOperador)
        lista = target.buscarLista(Nothing)

        Assert.AreEqual(Long.Parse(1), lista(0).produccion.codProduccion)
        Assert.AreEqual(Long.Parse(1), lista(0).operador.idOperador)
        Assert.AreEqual(Double.Parse(50), lista(0).porcentaje)
        Assert.AreEqual(Long.Parse(1), lista(1).produccion.codProduccion)
        Assert.AreEqual(Long.Parse(2), lista(1).operador.idOperador)
        Assert.AreEqual(Double.Parse(50), lista(1).porcentaje)
        Assert.AreEqual(Long.Parse(2), lista(2).produccion.codProduccion)
        Assert.AreEqual(Long.Parse(2), lista(2).operador.idOperador)
        Assert.AreEqual(Double.Parse(100), lista(2).porcentaje)
        Assert.AreEqual(Long.Parse(3), lista(3).produccion.codProduccion)
        Assert.AreEqual(Long.Parse(1), lista(3).operador.idOperador)
        Assert.AreEqual(Double.Parse(70), lista(3).porcentaje)
        Assert.AreEqual(Long.Parse(4), lista(5).produccion.codProduccion)
        Assert.AreEqual(Long.Parse(1), lista(5).operador.idOperador)
        Assert.AreEqual(Double.Parse(100), lista(5).porcentaje)

        Assert.AreEqual(7, lista.Count)
    End Sub

    <TestMethod()> _
    Public Sub buscarPorIdTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ProduccionOperadorTDG.OPERADOR, 1, Restriccion.CONDICION_IGUAL))
        criteria.Add(New Restriccion(ProduccionOperadorTDG.PRODUCCION, 1, Restriccion.CONDICION_IGUAL))
        Dim prodOperador As ProduccionOperador = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(1), prodOperador.operador.idOperador)
        Assert.AreEqual(Long.Parse(1), prodOperador.produccion.codProduccion)
        Assert.AreEqual(Double.Parse(50), prodOperador.porcentaje)
    End Sub

    <TestMethod()> _
    Public Sub buscarPorDescripcionTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ProduccionOperadorTDG.OPERADOR, 2, Restriccion.CONDICION_IGUAL))
        criteria.Add(New Restriccion(ProduccionOperadorTDG.PRODUCCION, 5, Restriccion.CONDICION_IGUAL))
        criteria.Add(New Restriccion(ProduccionOperadorTDG.PORCENTAJE, 100, Restriccion.CONDICION_IGUAL))
        Dim lista As List(Of ProduccionOperador) = target.buscarLista(criteria)

        Assert.AreEqual(Long.Parse(2), lista(0).operador.idOperador)
        Assert.AreEqual(Long.Parse(5), lista(0).produccion.codProduccion)
        Assert.AreEqual(Double.Parse(100), lista(0).porcentaje)

        Assert.AreEqual(1, lista.Count)
    End Sub

    <TestMethod()> _
    Public Sub actualizarProduccionOperadorTDGTest()
        Dim produccion As New Produccion()
        produccion.codProduccion = 1
        Dim operario As New Operario()
        operario.idOperador = 1
        Dim produccionOperador As ProduccionOperador = New ProduccionOperador(produccion, operario, 1)
        target.actualizar(produccionOperador)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ProduccionOperadorTDG.OPERADOR, produccionOperador.operador.idOperador, Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(ProduccionOperadorTDG.PRODUCCION, produccionOperador.produccion.codProduccion, Restriccion.CONDICION_IGUAL))
        Dim pro As ProduccionOperador = target.buscarUnico(criterio)

        Assert.AreEqual(Long.Parse(1), pro.operador.idOperador)
        Assert.AreEqual(Long.Parse(1), pro.produccion.codProduccion)
        Assert.AreEqual(Double.Parse(1), pro.porcentaje)

        produccionOperador = New ProduccionOperador(produccion, operario, 50)
        target.actualizar(produccionOperador)
    End Sub

    <TestMethod()> _
    Public Sub grabarProduccionOperadorTDGTest()
        Dim produccion As New Produccion()
        produccion.codProduccion = 6
        Dim operario As New Operario()
        operario.idOperador = 2
        Dim produccionOperador As ProduccionOperador = New ProduccionOperador(produccion, operario, 1)
        target.grabar(produccionOperador)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ProduccionOperadorTDG.OPERADOR, produccionOperador.operador.idOperador, Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(ProduccionOperadorTDG.PRODUCCION, produccionOperador.produccion.codProduccion, Restriccion.CONDICION_IGUAL))
        Dim proOp As ProduccionOperador = target.buscarUnico(criterio)

        Assert.AreEqual(Long.Parse(2), proOp.operador.idOperador)
        Assert.AreEqual(Long.Parse(6), proOp.produccion.codProduccion)
        Assert.AreEqual(Double.Parse(1), proOp.porcentaje)

        target.borrar(proOp)
    End Sub

    <TestMethod()> _
    Public Sub borrarProduccionOperadorTest()
        Dim produccion As New Produccion()
        produccion.codProduccion = 6
        Dim operario As New Operario()
        operario.idOperador = 2
        Dim produccionOperador As ProduccionOperador = New ProduccionOperador(produccion, operario, 1)
        target.grabar(produccionOperador)

        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(ProduccionOperadorTDG.OPERADOR, produccionOperador.operador.idOperador, Restriccion.CONDICION_IGUAL))
        criterio.Add(New Restriccion(ProduccionOperadorTDG.PRODUCCION, produccionOperador.produccion.codProduccion, Restriccion.CONDICION_IGUAL))
        Dim proOp As ProduccionOperador = target.buscarUnico(criterio)

        Assert.IsNotNull(proOp)

        produccionOperador = New ProduccionOperador(produccion, operario, Nothing)
        target.borrar(produccionOperador)

        proOp = target.buscarUnico(criterio)

        Assert.IsNull(proOp)
    End Sub

End Class
