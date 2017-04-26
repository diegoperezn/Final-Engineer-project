Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for EncuestaTDGTest and is intended
'''to contain all EncuestaTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class EncuestaTDGTest


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

    Dim target As EncuestaTDG = RepositorioFactory.encuestaTDG

    '''<summary>
    '''A test for buscarEncuesta
    '''</summary>
    <TestMethod()> _
    Public Sub buscarEncuestaTest()
        Dim encuesta As New Encuesta(Nothing, 1, 2, 3)

        target.grabar(encuesta)

        Dim lista As List(Of Encuesta) = Me.target.buscarEncuesta(Nothing)

        Assert.AreEqual(4, lista.Count)
        Assert.AreEqual(Long.Parse(4), lista(3).id)
        Assert.AreEqual(1, lista(3).atencion)
        Assert.AreEqual(2, lista(3).calidad)
        Assert.AreEqual(3, lista(3).eficiencia)

        target.borrar(encuesta)

        lista = Me.target.buscarEncuesta(Nothing)

        Assert.AreEqual(3, lista.Count)
    End Sub
End Class
