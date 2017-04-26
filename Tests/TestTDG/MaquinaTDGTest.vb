Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for MaquinaTDGTest and is intended
'''to contain all MaquinaTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MaquinaTDGTest


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
        Dim maquina As New Maquina(4)
        target.borrar(Maquina)
    End Sub

#End Region

    Dim target As MaquinaTDG = RepositorioFactory.maquinaTDG

    '''<summary>
    '''A test for cargarMaquinas
    '''</summary>
    <TestMethod()> _
    Public Sub cargarMaquinasTest()
        Dim lista As List(Of Maquina) = target.cargarMaquinas(Nothing)

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codMaquina)
        Assert.AreEqual(15, lista(0).altoMargen)
        Assert.AreEqual(15, lista(0).anchoMargen)
        Assert.AreEqual(1, lista(0).cabezales)
        Assert.AreEqual("nombre1", lista(0).nombre)
        Assert.AreEqual(111, lista(0).velocidadPromedio)
        Assert.AreEqual(3, lista(0).tiposPrenda.Count)
        Assert.AreEqual(3, lista(0).cantidadColores)
    End Sub


    '''<summary>
    '''A test for cargarMaquinas
    '''</summary>
    <TestMethod()> _
    Public Sub cargarMaquinasConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MaquinaTDG.COD_MAQUINA, 1))
        criteria.Add(New Restriccion(MaquinaTDG.ALTO, 20, Restriccion.CONDICION_MENOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.ANCHO, 10, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.CABEZALES, 1))
        criteria.Add(New Restriccion(MaquinaTDG.NOMBRE, "e1", Restriccion.CONDICION_LIKE))
        criteria.Add(New Restriccion(MaquinaTDG.VELOCIDAD, 111, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.CANTIDAD_COLORES, 2, Restriccion.CONDICION_MAYOR_IGUAL))

        Dim lista As List(Of Maquina) = target.cargarMaquinas(criteria)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codMaquina)
        Assert.AreEqual(15, lista(0).altoMargen)
        Assert.AreEqual(15, lista(0).anchoMargen)
        Assert.AreEqual(1, lista(0).cabezales)
        Assert.AreEqual("nombre1", lista(0).nombre)
        Assert.AreEqual(111, lista(0).velocidadPromedio)
        Assert.AreEqual(3, lista(0).tiposPrenda.Count)
        Assert.AreEqual(3, lista(0).cantidadColores)
    End Sub

    '''<summary>
    '''A test for cargarMaquinas
    '''</summary>
    <TestMethod()> _
    Public Sub grabarMaquinasTest()
        Dim maquina As New Maquina(Nothing, 100, 200, 12, "nombre nuevo", 1000, New List(Of TipoPrenda), 15)

        target.grabar(maquina)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MaquinaTDG.COD_MAQUINA, 4))
        criteria.Add(New Restriccion(MaquinaTDG.ALTO, 500, Restriccion.CONDICION_MENOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.ANCHO, 100, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.CABEZALES, 12))
        criteria.Add(New Restriccion(MaquinaTDG.NOMBRE, "e n", Restriccion.CONDICION_LIKE))
        criteria.Add(New Restriccion(MaquinaTDG.VELOCIDAD, 500, Restriccion.CONDICION_MAYOR_IGUAL))

        Dim maquinaBase As Maquina = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), maquinaBase.codMaquina)
        Assert.AreEqual(100, maquinaBase.altoMargen)
        Assert.AreEqual(200, maquinaBase.anchoMargen)
        Assert.AreEqual(12, maquinaBase.cabezales)
        Assert.AreEqual("nombre nuevo", maquinaBase.nombre)
        Assert.AreEqual(1000, maquinaBase.velocidadPromedio)
        Assert.AreEqual(0, maquinaBase.tiposPrenda.Count)
        Assert.AreEqual(15, maquinaBase.cantidadColores)
    End Sub

    '''<summary>
    '''A test for cargarMaquinas
    '''</summary>
    <TestMethod()> _
    Public Sub modificarMaquinasTest()
        Dim maquina As New Maquina(Nothing, 100, 200, 12, "nombre nuevo", 1000, New List(Of TipoPrenda), 12)

        target.grabar(maquina)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MaquinaTDG.COD_MAQUINA, 4))
        criteria.Add(New Restriccion(MaquinaTDG.ALTO, 500, Restriccion.CONDICION_MENOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.ANCHO, 100, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.CABEZALES, 12))
        criteria.Add(New Restriccion(MaquinaTDG.NOMBRE, "e n", Restriccion.CONDICION_LIKE))
        criteria.Add(New Restriccion(MaquinaTDG.VELOCIDAD, 500, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.CANTIDAD_COLORES, 12))

        Dim maquinaBase As Maquina = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), maquinaBase.codMaquina)
        Assert.AreEqual(100, maquinaBase.altoMargen)
        Assert.AreEqual(200, maquinaBase.anchoMargen)
        Assert.AreEqual(12, maquinaBase.cabezales)
        Assert.AreEqual("nombre nuevo", maquinaBase.nombre)
        Assert.AreEqual(1000, maquinaBase.velocidadPromedio)
        Assert.AreEqual(0, maquinaBase.tiposPrenda.Count)
        Assert.AreEqual(12, maquinaBase.cantidadColores)

        maquinaBase.nombre = "nombre editado"
        maquinaBase.cantidadColores = 2

        target.actualizar(maquinaBase)

        criteria.Clear()
        criteria.Add(New Restriccion(MaquinaTDG.COD_MAQUINA, maquinaBase.codMaquina))
        maquinaBase = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(4), maquinaBase.codMaquina)
        Assert.AreEqual(100, maquinaBase.altoMargen)
        Assert.AreEqual(200, maquinaBase.anchoMargen)
        Assert.AreEqual(12, maquinaBase.cabezales)
        Assert.AreEqual("nombre editado", maquinaBase.nombre)
        Assert.AreEqual(1000, maquinaBase.velocidadPromedio)
        Assert.AreEqual(0, maquinaBase.tiposPrenda.Count)
        Assert.AreEqual(2, maquinaBase.cantidadColores)
    End Sub

    '''<summary>
    '''A test for cargarMaquinas
    '''</summary>
    <TestMethod()> _
    Public Sub borrarMaquinasTest()
        Dim maquina As New Maquina(Nothing, 100, 200, 12, "nombre nuevo", 1000, New List(Of TipoPrenda), 12)

        target.grabar(maquina)

        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MaquinaTDG.COD_MAQUINA, 4))

        Dim maquinaBase As Maquina = target.buscarUnico(criteria)

        Assert.IsNotNull(maquinaBase)

        target.borrar(maquinaBase)

        maquinaBase = target.buscarUnico(criteria)

        Assert.IsNull(maquinaBase)
    End Sub


End Class
