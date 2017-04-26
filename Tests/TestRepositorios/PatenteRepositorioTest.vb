Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for PatenteRepositorioTest and is intended
'''to contain all PatenteRepositorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PatenteRepositorioTest


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

    Dim target As PatenteRepositorio = RepositorioFactory.patenteRepositorio

    '''<summary>
    '''A test for cargarPatentesPorUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub cargarPatentesPorUsuarioTest()
        Dim usuario As Usuario = New Usuario
        usuario.id = 3
        Dim lista As List(Of Patente) = target.cargarPatentesPorUsuario(usuario)

        Assert.AreEqual(1, lista.Count)
        Assert.AreEqual(Long.Parse(13), lista(0).patenteId)
        Assert.AreEqual("Listado de diseños", lista(0).permiso)
        Assert.AreEqual("Listado de diseños", lista(0).descripcion)
    End Sub

    '''<summary>
    '''A test for cargarPatentesPorFamilia
    '''</summary>
    <TestMethod()> _
    Public Sub cargarPatentesPorFamiliaTest()
        Dim familia As Familia = New Familia
        familia.idFamilia = 6
        Dim lista As List(Of Patente) = target.cargarPatentesPorFamilia(familia)

        Assert.AreEqual(8, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).patenteId)
        Assert.AreEqual("Creacion de usuarios", lista(0).permiso)
        Assert.AreEqual("creacion de usuario", lista(0).descripcion)
    End Sub

    '''<summary>
    '''A test for cargarPatentes
    '''</summary>
    <TestMethod()> _
    Public Sub cargarPatentesTest()
        Dim lista As List(Of Patente) = target.cargarPatentes()

        Assert.AreEqual(13, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).patenteId)
        Assert.AreEqual("Creacion de usuarios", lista(0).permiso)
        Assert.AreEqual("creacion de usuario", lista(0).descripcion)
    End Sub
End Class
