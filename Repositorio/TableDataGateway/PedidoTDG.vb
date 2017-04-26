Public Class PedidoTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "Pedido"

    Public Shared ReadOnly COD_PEDIDO As New Columna("codPedido", "cod_pedido", Columna.TIPO.NUMERICO, True)

    Public Shared ReadOnly COMENTARIO As New Columna("comentario", Columna.TIPO.TEXTO)
    Public Shared ReadOnly CLIENTE As New Columna("cliente", "id_cliente", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("idCliente", "id_cliente", Columna.TIPO.NUMERICO, True)))
    Public Shared ReadOnly TIPO_PEDIDO As New Columna("tipoPedido", "tipo_pedido", Columna.TIPO.MANY_TO_ONE, New Join(TipoPedidoTDG.TIPO_PEDIDO))
    Public Shared ReadOnly HISTORICO_ESTADOS As New Columna("historicoEstados", Columna.TIPO.ONE_TO_MANY, New Join(HistoricoEstadosPedidoTDG.NRO_ESTADO, HistoricoEstadosPedidoTDG.NOMBRE_TABLA, True), True)
    Public Shared ReadOnly TRABAJOS As New Columna("trabajos", Columna.TIPO.ONE_TO_MANY, New Join(ProduccionTDG.COD_PRODUCCION, ProduccionTDG.NOMBRE_TABLA, True), True)
    Public Shared ReadOnly ESTADO_ACTUAL As New Columna("estadoActual", "estadoActual", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("estadoPedido", Columna.TIPO.NUMERICO, True)))

    Public Shared ReadOnly FECHA_INICIO As New Columna("fechaInicio", Columna.TIPO.FECHA)
    Public Shared ReadOnly FECHA_FINAL As New Columna("fechaFinal", Columna.TIPO.FECHA)

    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(COD_PEDIDO)
        _columnas.Add(COMENTARIO)
        _columnas.Add(CLIENTE)
        _columnas.Add(TIPO_PEDIDO)
        _columnas.Add(TRABAJOS)
        _columnas.Add(HISTORICO_ESTADOS)
        _columnas.Add(ESTADO_ACTUAL)

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
        Return New Pedido().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarlistaPedidos(ByVal criteria As List(Of Restriccion)) As List(Of Pedido)
        Dim lista As New List(Of Pedido)

        For Each elemento As Pedido In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function


End Class
