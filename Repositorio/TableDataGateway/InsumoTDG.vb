Public Class InsumoTDG
    Inherits TableDataGateway

    Public Const NOMBRE_TABLA As String = "insumo"

    Public Shared ReadOnly COD_INSUMO As New Columna("codInsumo", "cod_insumo", Columna.TIPO.NUMERICO, True)

    Public Shared ReadOnly NOMBRE As New Columna("nombre", Columna.TIPO.TEXTO)
    Public Shared ReadOnly TIPO_INSUMO As New Columna("tipoInsumo", "id_tipo_insumo", Columna.TIPO.MANY_TO_ONE, New Join(TipoInsumoTDG.TIPO_INSUMO))
    Public Shared ReadOnly COLOR As New Columna("color", "color", Columna.TIPO.MANY_TO_ONE, New Join(ColorTDG.COD_COLOR))
    Public Shared ReadOnly DETALLE As New Columna("detalle", Columna.TIPO.TEXTO)
    Public Shared ReadOnly COSTO As New Columna("costo", Columna.TIPO.DOUBLE)
    Public Shared ReadOnly CANTIDAD_ACTUAL As New Columna("cantidadActual", Columna.TIPO.NUMERICO)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByRef dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(COD_INSUMO)
        _columnas.Add(NOMBRE)
        _columnas.Add(TIPO_INSUMO)
        _columnas.Add(COLOR)
        _columnas.Add(DETALLE)
        _columnas.Add(COSTO)
        _columnas.Add(CANTIDAD_ACTUAL)
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
        Return GetType(Insumo)
    End Function

    Public Function buscarInsumos(ByVal criteria As List(Of Restriccion)) As List(Of Insumo)
        Dim lista As New List(Of Insumo)

        For Each elemento As Insumo In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
