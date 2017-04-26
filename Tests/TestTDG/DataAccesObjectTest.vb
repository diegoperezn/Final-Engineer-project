Imports System.Data

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for DataAccesObjectTest and is intended
'''to contain all DataAccesObjectTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DataAccesObjectTest


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

    Private target As DataAccesObject = RepositorioFactory.dao

    '''<summary>
    '''A test for DataAccesObject Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub DataAccesObjectConstructorTest()
        Dim target As DataAccesObject = New DataAccesObject()
    End Sub

    '''<summary>
    '''A test for ejecutarConsulta
    '''</summary>
    <TestMethod()> _
    Public Sub ejecutarConsultaTest()
        Dim target As DataAccesObject = New DataAccesObject()
        Dim consulta As String = "select * from usuario"
        Dim actual As DataSet
        actual = target.ejecutarConsulta(consulta)
        Assert.AreEqual(1, actual.Tables.Count)
    End Sub

    '''<summary>
    '''A test for save a new row
    '''</summary>
    <TestMethod()> _
    Public Sub saveTest()
        Dim target As DataAccesObject = New DataAccesObject()
        Dim consulta As String = "INSERT INTO Patente (patenteID, descripcion, permiso) VALUES (1, 'test', 'test')"
        target.saveOrUpdate(consulta)
        consulta = "select * from Patente where patenteID = 1"
        Dim actual As DataSet
        actual = target.ejecutarConsulta(consulta)
        Assert.AreEqual(1, actual.Tables.Count)
        consulta = "DELETE FROM Patente"
        target.saveOrUpdate(consulta)
    End Sub

End Class
