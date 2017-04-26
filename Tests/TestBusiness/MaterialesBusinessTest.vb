Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for MaterialesBusinessTest and is intended
'''to contain all MaterialesBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MaterialesBusinessTest


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
        Dim maquina As New Maquina
        maquina.codMaquina = 4
        tdg.borrar(maquina)
        dao.saveOrUpdate("delete from " + MaquinaTDG.TABLA_MAQUINA_TIPO_PRENDA + " where " + MaquinaTDG.COD_MAQUINA.columna + "=" + maquina.codMaquina.ToString)
    End Sub

#End Region

    Dim target As MaterialesBusiness = BusinessFactory.materialesBusiness
    Dim tdg As MaquinaTDG = RepositorioFactory.maquinaTDG
    Dim dao As DataAccesObject = RepositorioFactory.dao

    '''<summary>
    '''A test for modificarMaquina
    '''</summary>
    <TestMethod()> _
    Public Sub modificarMaquinaTest()
        Dim prendas As New List(Of TipoPrenda)
        prendas.Add(New TipoPrenda(1, "test"))
        prendas.Add(New TipoPrenda(2, "test"))

        target.crearNuevaMaquina(prendas, 1000, 12, 200, 100, "nombre nuevo", 12)

        Dim maquinaBase As Maquina = target.cargarMaquinaPorId(4)

        Assert.AreEqual(Long.Parse(4), maquinaBase.codMaquina)
        Assert.AreEqual(100, maquinaBase.altoMargen)
        Assert.AreEqual(200, maquinaBase.anchoMargen)
        Assert.AreEqual(12, maquinaBase.cabezales)
        Assert.AreEqual(12, maquinaBase.cantidadColores)
        Assert.AreEqual("nombre nuevo", maquinaBase.nombre)
        Assert.AreEqual(1000, maquinaBase.velocidadPromedio)
        Assert.AreEqual(2, maquinaBase.tiposPrenda.Count)
        Assert.AreEqual("Campera Armada", maquinaBase.tiposPrenda(0).descripcion)

        maquinaBase.nombre = "nombre editado"
        prendas = New List(Of TipoPrenda)
        prendas.Add(New TipoPrenda(1, "test"))
        maquinaBase.tiposPrenda = prendas

        target.modificarMaquina(maquinaBase, prendas, 1000, 12, 200, 100, "nombre editado", 12)

        maquinaBase = target.cargarMaquinaPorId(4)

        Assert.AreEqual(Long.Parse(4), maquinaBase.codMaquina)
        Assert.AreEqual(100, maquinaBase.altoMargen)
        Assert.AreEqual(200, maquinaBase.anchoMargen)
        Assert.AreEqual(12, maquinaBase.cabezales)
        Assert.AreEqual("nombre editado", maquinaBase.nombre)
        Assert.AreEqual(1000, maquinaBase.velocidadPromedio)
        Assert.AreEqual(1, maquinaBase.tiposPrenda.Count)
        Assert.AreEqual("Campera Armada", maquinaBase.tiposPrenda(0).descripcion)
    End Sub

    '''<summary>
    '''A test for actualizarMaquina
    '''</summary>
    <TestMethod()> _
    Public Sub actualizarMaquinaTest()
        Dim prendas As New List(Of TipoPrenda)
        prendas.Add(New TipoPrenda(1, "test"))
        prendas.Add(New TipoPrenda(2, "test"))

        target.crearNuevaMaquina(prendas, 1000, 12, 200, 100, "nombre nuevo", 12)

        Dim maquinaBase As Maquina = target.cargarMaquinaPorId(4)

        Assert.AreEqual(Long.Parse(4), maquinaBase.codMaquina)
        Assert.AreEqual(100, maquinaBase.altoMargen)
        Assert.AreEqual(200, maquinaBase.anchoMargen)
        Assert.AreEqual(12, maquinaBase.cabezales)
        Assert.AreEqual(12, maquinaBase.cantidadColores)
        Assert.AreEqual("nombre nuevo", maquinaBase.nombre)
        Assert.AreEqual(1000, maquinaBase.velocidadPromedio)
        Assert.AreEqual(2, maquinaBase.tiposPrenda.Count)
        Assert.AreEqual("Campera Armada", maquinaBase.tiposPrenda(0).descripcion)

        maquinaBase.nombre = "nombre editado"
        prendas = New List(Of TipoPrenda)
        prendas.Add(New TipoPrenda(1, "test"))
        maquinaBase.tiposPrenda = prendas

        target.actualizarMaquina(maquinaBase)

        maquinaBase = target.cargarMaquinaPorId(4)

        Assert.AreEqual(Long.Parse(4), maquinaBase.codMaquina)
        Assert.AreEqual(100, maquinaBase.altoMargen)
        Assert.AreEqual(200, maquinaBase.anchoMargen)
        Assert.AreEqual(12, maquinaBase.cabezales)
        Assert.AreEqual("nombre editado", maquinaBase.nombre)
        Assert.AreEqual(1000, maquinaBase.velocidadPromedio)
        Assert.AreEqual(1, maquinaBase.tiposPrenda.Count)
        Assert.AreEqual("Campera Armada", maquinaBase.tiposPrenda(0).descripcion)
    End Sub

    '''<summary>
    '''A test for listarMaquinas
    '''</summary>
    <TestMethod()> _
    Public Sub listarMaquinasTest()
        Dim lista As List(Of Maquina) = target.listarMaquinas()

        Assert.AreEqual(3, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codMaquina)
        Assert.AreEqual(15, lista(0).altoMargen)
        Assert.AreEqual(15, lista(0).anchoMargen)
        Assert.AreEqual(1, lista(0).cabezales)
        Assert.AreEqual("nombre1", lista(0).nombre)
        Assert.AreEqual(111, lista(0).velocidadPromedio)
        Assert.AreEqual(3, lista(0).tiposPrenda.Count)
    End Sub

    '''<summary>
    '''A test for crearNuevaMaquina
    '''</summary>
    <TestMethod()> _
    Public Sub crearNuevaMaquinaTest()
        Dim prendas As New List(Of TipoPrenda)
        prendas.Add(New TipoPrenda(1, "test"))
        prendas.Add(New TipoPrenda(2, "test"))

        target.crearNuevaMaquina(prendas, 1000, 12, 200, 100, "nombre nuevo", 12)

        Dim maquinaBase As Maquina = target.cargarMaquinaPorId(4)

        Assert.AreEqual(Long.Parse(4), maquinaBase.codMaquina)
        Assert.AreEqual(100, maquinaBase.altoMargen)
        Assert.AreEqual(200, maquinaBase.anchoMargen)
        Assert.AreEqual(12, maquinaBase.cabezales)
        Assert.AreEqual(12, maquinaBase.cantidadColores)
        Assert.AreEqual("nombre nuevo", maquinaBase.nombre)
        Assert.AreEqual(1000, maquinaBase.velocidadPromedio)
        Assert.AreEqual(2, maquinaBase.tiposPrenda.Count)
        Assert.AreEqual("Campera Armada", maquinaBase.tiposPrenda(0).descripcion)
    End Sub

    '''<summary>
    '''A test for cargarMaquinaPorId
    '''</summary>
    <TestMethod()> _
    Public Sub cargarMaquinaPorIdTest()
        Dim maquina As Maquina = target.cargarMaquinaPorId(1)

        Assert.AreEqual(Long.Parse(1), maquina.codMaquina)
        Assert.AreEqual(15, maquina.altoMargen)
        Assert.AreEqual(15, maquina.anchoMargen)
        Assert.AreEqual(1, maquina.cabezales)
        Assert.AreEqual("nombre1", maquina.nombre)
        Assert.AreEqual(111, maquina.velocidadPromedio)
        Assert.AreEqual(3, maquina.tiposPrenda.Count)
        Assert.AreEqual("Bolsillo", maquina.tiposPrenda(1).descripcion)
    End Sub
End Class
