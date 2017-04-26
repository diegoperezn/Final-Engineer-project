Imports Dominio

Public Class TipoMovimientoTDG
    Inherits TableDataGateway


    Public Const NOMBRE_TABLA As String = "tipoMovimiento"

    Public Shared ReadOnly TIPO_MOVIMIENTO As New Columna("tipoMovimiento", "tipoMovimientoID", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly MOVIMIENTO As New Columna("descripcion", "movimiento", Columna.TIPO.TEXTO)

    Private _columnas As New List(Of Columna)

    Sub New(ByRef dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(TIPO_MOVIMIENTO)
        _columnas.Add(MOVIMIENTO)
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

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New TipoMovimiento().GetType()
    End Function

    Public Function buscarLista(ByVal criteria As List(Of Restriccion)) As List(Of TipoMovimiento)
        Dim lista As New List(Of TipoMovimiento)

        For Each obj As TipoMovimiento In buscar(criteria)
            lista.Add(obj)
        Next

        Return lista
    End Function

End Class
