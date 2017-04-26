Imports Dominio

Public Class UsuarioTDG
    Inherits TableDataGateway

    Private Shared NOMBRE_TABLA As String = "Usuario"

    Private Const TABLA_USUARIO_FAMILIA As String = "JoinUsuarioToFamilia"
    Private Const TABLA_USUARIO_PATENTE As String = "JoinPatenteToUsuario"

    Public Shared ReadOnly ID_USUARIO As New Columna("id", "usuarioID", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly APELLIDO As New Columna("apellido", Columna.TIPO.TEXTO)
    Public Shared ReadOnly NOMBRE As New Columna("nombre", Columna.TIPO.TEXTO)
    Public Shared ReadOnly MAIL As New Columna("mail", Columna.TIPO.TEXTO)
    Public Shared ReadOnly PASSWORD As New Columna("password", Columna.TIPO.TEXTO)
    Public Shared ReadOnly TELEFONO_FIJO As New Columna("telefonoFijo", Columna.TIPO.TEXTO)
    Public Shared ReadOnly TELEFONO_MOVIL As New Columna("telefonoMovil", Columna.TIPO.TEXTO)
    Public Shared ReadOnly BLOQUEADO As New Columna("bloqueado", Columna.TIPO.BOOLEANO)
    Public Shared ReadOnly FAMILIAS As New Columna("familias", Columna.TIPO.MANY_TO_MANY, New Join(FamiliaTDG.ID_FAMILIA, TABLA_USUARIO_FAMILIA, True), True)
    Public Shared ReadOnly PATENTES As New Columna("patentes", Columna.TIPO.MANY_TO_MANY, New Join(PatenteTDG.ID_PATENTE, TABLA_USUARIO_PATENTE, True), True)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByRef dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID_USUARIO)
        _columnas.Add(NOMBRE)
        _columnas.Add(APELLIDO)
        _columnas.Add(MAIL)
        _columnas.Add(PASSWORD)
        _columnas.Add(TELEFONO_FIJO)
        _columnas.Add(TELEFONO_MOVIL)
        _columnas.Add(BLOQUEADO)
        _columnas.Add(FAMILIAS)
        _columnas.Add(PATENTES)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As Type
        Return New Usuario().GetType
    End Function

    Function cargarUsuarios(ByVal criteria As List(Of Restriccion)) As List(Of Usuario)
        Dim listaUsuario As New List(Of Usuario)

        For Each usr As Usuario In buscar(criteria)
            listaUsuario.Add(usr)
        Next

        Return listaUsuario
    End Function

End Class
