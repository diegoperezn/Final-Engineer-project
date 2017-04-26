Imports Dominio

Public Class FamiliaTDG
    Inherits TableDataGateway

    Private Shared NOMBRE_TABLA As String = "Familia"

    Private Const TABLA_FAMILIA_PATENTE As String = "JoinFamiliaToPatente"
    Private Const TABLA_USUARIO_FAMILIA As String = "JoinUsuarioToFamilia"

    Public Shared ReadOnly ID_FAMILIA As New Columna("idFamilia", "familiaID", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly DESCRIPCION As New Columna("descripcion", Columna.TIPO.TEXTO)
    Public Shared ReadOnly NOMBRE As New Columna("nombre", Columna.TIPO.TEXTO)
    Public Shared ReadOnly PATENTES As New Columna("patentes", Columna.TIPO.MANY_TO_MANY, New Join(PatenteTDG.ID_PATENTE, TABLA_FAMILIA_PATENTE, True), True)
    Public Shared ReadOnly USUARIO As New Columna("usuarios", Columna.TIPO.MANY_TO_MANY, New Join(New Columna("id", "usuarioID", Columna.TIPO.NUMERICO, True), TABLA_USUARIO_FAMILIA, False), False)


    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID_FAMILIA)
        _columnas.Add(DESCRIPCION)
        _columnas.Add(NOMBRE)
        _columnas.Add(PATENTES)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New Familia().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarFamilias(ByVal criteria As List(Of Restriccion)) As List(Of Familia)
        Dim lista As New List(Of Familia)

        For Each elemento As Familia In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
