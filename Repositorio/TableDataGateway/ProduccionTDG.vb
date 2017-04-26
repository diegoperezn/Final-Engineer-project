Public Class ProduccionTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "produccion"

    Public Shared ReadOnly COD_PRODUCCION As New Columna("codProduccion", "cod_produccion", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly COMENTARIO As New Columna("comentario", Columna.TIPO.TEXTO)
    Public Shared ReadOnly PEDIDO As New Columna("pedido", "cod_pedido", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("codPedido", "cod_pedido", Columna.TIPO.NUMERICO, True)))
    Public Shared ReadOnly MAQUINA As New Columna("maquina", "cod_maquina", Columna.TIPO.MANY_TO_ONE, New Join(MaquinaTDG.COD_MAQUINA))
    Public Shared ReadOnly ARTICULO As New Columna("articulo", "cod_articulo", Columna.TIPO.MANY_TO_ONE, New Join(ArticuloTDG.COD_ARTICULO))
    Public Shared ReadOnly HISTORICO_ESTADOS As New Columna("historicoProduccion", Columna.TIPO.ONE_TO_MANY, New Join(HistoricoEstadosProduccionTDG.NRO_ESTADO, HistoricoEstadosProduccionTDG.NOMBRE_TABLA, True), True)
    Public Shared ReadOnly ESTADO_ACTUAL As New Columna("estadoActual", "estadoActual", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("estado", Columna.TIPO.NUMERICO, True)))

    Public Shared ReadOnly UTILIZACION As New Columna("utilizacion", Columna.TIPO.DOUBLE)
    Public Shared ReadOnly CANTIDAD As New Columna("cantidad", Columna.TIPO.NUMERICO)

    Public Shared ReadOnly FECHA_INICIO As New Columna("fechaInicio", Columna.TIPO.FECHA)
    Public Shared ReadOnly FECHA_FINAL As New Columna("fechaFinal", Columna.TIPO.FECHA)

    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(COD_PRODUCCION)
        _columnas.Add(COMENTARIO)
        _columnas.Add(PEDIDO)
        _columnas.Add(MAQUINA)
        _columnas.Add(ARTICULO)
        _columnas.Add(HISTORICO_ESTADOS)
        _columnas.Add(CANTIDAD)
        _columnas.Add(ESTADO_ACTUAL)
        _columnas.Add(UTILIZACION)

        _columnas.Add(FECHA_INICIO)
        _columnas.Add(FECHA_FINAL)

        _columnas.Add(BORRADO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(Produccion)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarlistaProduccion(ByVal criteria As List(Of Restriccion)) As List(Of Produccion)
        Dim lista As New List(Of Produccion)

        For Each elemento As Produccion In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
