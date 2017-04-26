Imports System.Collections.Generic

Imports Dominio

Imports Repositorio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Negocio



'''<summary>
'''This is a test class for PatenteBusinessTest and is intended
'''to contain all PatenteBusinessTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PatenteBusinessTest


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

    Dim target As PatenteBusiness = BusinessFactory.patenteBusiness

    '''<summary>
    '''A test for listaPatentesPorUsuario
    '''</summary>
    <TestMethod()> _
    Public Sub listaPatentesPorUsuarioTest()
        Dim usr As New Usuario
        usr.id = 3
        Dim actual As List(Of Patente)
        actual = target.listaPatentesPorUsuario(usr)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(13), actual(0).patenteId)
        Assert.AreEqual("Listado de diseños", actual(0).descripcion)
        Assert.AreEqual("Listado de diseños", actual(0).permiso)
    End Sub

    '''<summary>
    '''A test for listaPatentesPorFamilia
    '''</summary>
    <TestMethod()> _
    Public Sub listaPatentesPorFamiliaTest()
        Dim familia As New Familia(6, Nothing, Nothing)
        Dim actual As List(Of Patente)
        actual = target.listaPatentesPorFamilia(familia)

        Assert.AreEqual(8, actual.Count)
    End Sub

    '''<summary>
    '''A test for listaPatentes
    '''</summary>
    <TestMethod()> _
    Public Sub listaPatentesTest()
        Dim actual As List(Of Patente)
        actual = target.listaPatentes()
        Assert.AreEqual(13, actual.Count)
    End Sub
End Class
