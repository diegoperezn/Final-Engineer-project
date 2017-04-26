﻿Imports Dominio

Imports System.Collections.Generic

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Repositorio



'''<summary>
'''This is a test class for EstadoTrabajoTDGTest and is intended
'''to contain all EstadoTrabajoTDGTest Unit Tests
'''</summary>
<TestClass()> _
Public Class EstadoTrabajoTDGTest


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

    Dim target As EstadoTrabajoTDG = RepositorioFactory.estadoTrabajoTDG

    '''<summary>
    '''A test for buscarEstados
    '''</summary>
    <TestMethod()> _
    Public Sub buscarEstadosTest()
        Dim estados As List(Of EstadoTrabajos) = target.buscarEstados(Nothing)

        Assert.AreEqual(3, estados.Count)
        Assert.AreEqual("en espera", estados(0).descripcion)
    End Sub

    '''<summary>
    '''A test for buscarEstadosPorId
    '''</summary>
    <TestMethod()> _
    Public Sub buscarEstadosPorIdTest()
        Dim estado As EstadoTrabajos = target.buscarEstadosPorId(2)

        Assert.AreEqual(Long.Parse(2), estado.estado)
        Assert.AreEqual("en proceso", estado.descripcion)
    End Sub
End Class