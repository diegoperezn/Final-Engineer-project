Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for PatenteTDGTest and is intended
'''to contain all PatenteTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PatenteTDGTest


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

    Dim target As PatenteTDG = RepositorioFactory.patenteTDG

    '''<summary>
    '''A test for cargarFamilias
    '''</summary>
    <TestMethod()> _
    Public Sub cargarFamiliasTest()
        Dim actual As List(Of Patente)
        actual = target.cargarPatentes(Nothing)
        Assert.AreEqual(13, actual.Count)
    End Sub

    <TestMethod()> _
    Public Sub cargarFamiliasPorUsuarioTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(PatenteTDG.USUARIO, 3, Restriccion.CONDICION_IGUAL))
        Dim actual As List(Of Patente)
        actual = target.cargarPatentes(criteria)

        Assert.AreEqual(1, actual.Count)
        Assert.AreEqual(Long.Parse(13), actual(0).patenteId)
        Assert.AreEqual("Listado de diseños", actual(0).descripcion)
        Assert.AreEqual("Listado de diseños", actual(0).permiso)
    End Sub

    <TestMethod()> _
    Public Sub cargarFamiliasPorFamiliaTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(PatenteTDG.FAMILIA, 6, Restriccion.CONDICION_IGUAL))
        Dim actual As List(Of Patente)
        actual = target.cargarPatentes(criteria)

        Assert.AreEqual(8, actual.Count)
    End Sub

End Class
