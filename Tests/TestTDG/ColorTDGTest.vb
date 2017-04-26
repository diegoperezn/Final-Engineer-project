Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for ColorTDGTest and is intended
'''to contain all ColorTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ColorTDGTest


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

    Dim target As ColorTDG = RepositorioFactory.colorTDG

    '''<summary>
    '''A test for buscarColor
    '''</summary>
    <TestMethod()> _
    Public Sub buscarColorTest()
        Dim lista As List(Of Color) = target.buscarColor(Nothing)

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual(Long.Parse(1), lista(0).codColor)
        Assert.AreEqual("Rojo", lista(0).color)
    End Sub

    '''<summary>
    '''A test for buscarColor
    '''</summary>
    <TestMethod()> _
    Public Sub buscarColorConRestriccionesTest()
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ColorTDG.COD_COLOR, 3))
        Dim color As Color = target.buscarUnico(criteria)

        Assert.AreEqual(Long.Parse(3), color.codColor)
        Assert.AreEqual("Azul", color.color)
    End Sub


End Class
