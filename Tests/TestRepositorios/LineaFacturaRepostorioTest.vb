Imports System.Collections.Generic

Imports Dominio

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for LineaFacturaRepostorioTest and is intended
'''to contain all LineaFacturaRepostorioTest Unit Tests
'''</summary>
<TestClass()> _
Public Class LineaFacturaRepostorioTest


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

    Dim target As LineaFacturaRepostorio = RepositorioFactory.lineaFacturaRepostorio

    '''<summary>
    '''A test for cargarLineasPorFactura
    '''</summary>
    <TestMethod()> _
    Public Sub cargarLineasPorFacturaTest()
        Dim factura As New Factura(1, 1, "A")

        Dim lineas As List(Of LineaFactura) = Me.target.cargarLineasPorFactura(factura)

        Assert.AreEqual(2, lineas.Count)
        Assert.AreEqual(10, lineas(0).cantidad)
        Assert.AreEqual(Double.Parse(10), lineas(0).precio)
        Assert.AreEqual(Long.Parse(1), lineas(0).nroLinea)
        Assert.AreEqual("com1", lineas(0).articulo.comentario)
        Assert.AreEqual(Double.Parse(2.1), lineas(0).articulo.precioActual)
    End Sub
End Class
