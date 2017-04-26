Imports Dominio

Public Class OpinionTDG
    Inherits TableDataGateway


    Private Const NOMBRE_TABLA As String = "opiniones"

    Public Shared ReadOnly ID As New Columna("id", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly NOMBRE As New Columna("nombre", Columna.TIPO.TEXTO)
    Public Shared ReadOnly MAIL As New Columna("mail", Columna.TIPO.TEXTO)
    Public Shared ReadOnly OPINION As New Columna("opinion", Columna.TIPO.TEXTO)


    Private _columnas As New List(Of Columna)

    Public Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID)
        _columnas.Add(NOMBRE)
        _columnas.Add(MAIL)
        _columnas.Add(OPINION)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New Opinion().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function buscarOpiniones(ByVal criteria As List(Of Restriccion)) As List(Of Opinion)
        Dim lista As New List(Of Opinion)

        For Each elemento As Opinion In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
