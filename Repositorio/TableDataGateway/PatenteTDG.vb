Imports Dominio

Public Class PatenteTDG
    Inherits TableDataGateway

    Private Shared NOMBRE_TABLA As String = "Patente"

    Private Const TABLA_FAMILIA_PATENTE As String = "JoinFamiliaToPatente"
    Private Const TABLA_USUARIO_PATENTE As String = "JoinPatenteToUsuario"

    Public Shared ReadOnly ID_PATENTE As New Columna("patenteId", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly DESCRIPCION As New Columna("descripcion", Columna.TIPO.TEXTO)
    Public Shared ReadOnly PERMISO As New Columna("permiso", Columna.TIPO.TEXTO)
    Public Shared ReadOnly FAMILIA As New Columna("familia", Columna.TIPO.MANY_TO_MANY, New Join(New Columna("idFamilia", "familiaID", Columna.TIPO.NUMERICO, True), TABLA_FAMILIA_PATENTE, False), False)
    Public Shared ReadOnly USUARIO As New Columna("usuario", Columna.TIPO.MANY_TO_MANY, New Join(New Columna("id", "usuarioID", Columna.TIPO.NUMERICO, True), TABLA_USUARIO_PATENTE, False), False)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID_PATENTE)
        _columnas.Add(DESCRIPCION)
        _columnas.Add(PERMISO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New Patente().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarPatentes(ByVal criteria As List(Of Restriccion)) As List(Of Patente)
        Dim listaUsuario As New List(Of Patente)

        For Each elemento As Patente In buscar(criteria)
            listaUsuario.Add(elemento)
        Next

        Return listaUsuario
    End Function

End Class

