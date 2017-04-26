Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for DiseñoInsumoTDGTest and is intended
'''to contain all DiseñoInsumoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DiseñoInsumoTDGTest


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
        Dim diseñoIns As New DiseñoInsumo(New Diseño(2), New Insumo(1), 5.5)
        target.borrar(diseñoIns)
    End Sub

#End Region

    Dim target As DiseñoInsumoTDG = RepositorioFactory.diseñoInsumoTDG

    '''<summary>
    '''A test for buscarDiseñoInsumo
    '''</summary>
    <TestMethod()> _
    Public Sub buscarDiseñoInsumoTest()
        Dim lista As List(Of DiseñoInsumo) = target.buscarDiseñoInsumo(Nothing)

        Assert.AreEqual(2, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).diseño.idDiseño)
        Assert.AreEqual(Long.Parse(1), lista(0).insumo.codInsumo)
        Assert.AreEqual(Double.Parse(1), lista(0).cantidad)
    End Sub


    '''<summary>
    '''A test for buscarDiseñoInsumo
    '''</summary>
    <TestMethod()> _
    Public Sub buscarDiseñoInsumoConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(DiseñoInsumoTDG.CANTIDAD, 1))
        criteria.Add(New Restriccion(DiseñoInsumoTDG.DISEÑO, 1))
        criteria.Add(New Restriccion(DiseñoInsumoTDG.INSUMO, 1))
        Dim lista As List(Of DiseñoInsumo) = target.buscarDiseñoInsumo(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).diseño.idDiseño)
        Assert.AreEqual(Long.Parse(1), lista(0).insumo.codInsumo)
        Assert.AreEqual(Double.Parse(1), lista(0).cantidad)
    End Sub

    '''<summary>
    '''A test for buscarDiseñoInsumo
    '''</summary>
    <TestMethod()> _
    Public Sub grabarDiseñoInsumoTest()
        Dim diseñoIns As New DiseñoInsumo(New Diseño(2), New Insumo(1), 5.5)

        target.grabar(diseñoIns)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(DiseñoInsumoTDG.DISEÑO, 2))
        criteria.Add(New Restriccion(DiseñoInsumoTDG.INSUMO, 1))
        Dim lista As List(Of DiseñoInsumo) = target.buscarDiseñoInsumo(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(2), lista(0).diseño.idDiseño)
        Assert.AreEqual(Long.Parse(1), lista(0).insumo.codInsumo)
        Assert.AreEqual(Double.Parse(5.5), lista(0).cantidad)
    End Sub

    '''<summary>
    '''A test for buscarDiseñoInsumo
    '''</summary>
    <TestMethod()> _
    Public Sub modificarDiseñoInsumoTest()
        Dim diseñoIns As New DiseñoInsumo(New Diseño(2), New Insumo(1), 5.5)

        target.grabar(diseñoIns)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(DiseñoInsumoTDG.DISEÑO, 2))
        criteria.Add(New Restriccion(DiseñoInsumoTDG.INSUMO, 1))
        Dim lista As List(Of DiseñoInsumo) = target.buscarDiseñoInsumo(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(2), lista(0).diseño.idDiseño)
        Assert.AreEqual(Long.Parse(1), lista(0).insumo.codInsumo)
        Assert.AreEqual(Double.Parse(5.5), lista(0).cantidad)

        diseñoIns.cantidad = 15.5

        target.actualizar(diseñoIns)

        lista = target.buscarDiseñoInsumo(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(2), lista(0).diseño.idDiseño)
        Assert.AreEqual(Long.Parse(1), lista(0).insumo.codInsumo)
        Assert.AreEqual(Double.Parse(15.5), lista(0).cantidad)
    End Sub

    '''<summary>
    '''A test for buscarDiseñoInsumo
    '''</summary>
    <TestMethod()> _
    Public Sub borrarDiseñoInsumoTest()
        Dim diseñoIns As New DiseñoInsumo(New Diseño(2), New Insumo(1), 5.5)

        target.grabar(diseñoIns)

        Dim criteria As New List(Of Restriccion)
        Dim lista As List(Of DiseñoInsumo) = target.buscarDiseñoInsumo(criteria)

        Assert.AreEqual(3, lista.Count)

        diseñoIns.cantidad = 15.5

        target.borrar(lista(2))

        lista = target.buscarDiseñoInsumo(criteria)

        Assert.AreEqual(2, lista.Count)
    End Sub

End Class
