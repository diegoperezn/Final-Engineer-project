Public Class HistoricoEstadosPedidoTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "historico_estados_pedido"

    Public Shared ReadOnly NRO_ESTADO As New Columna("nroEstado", "nro_estado", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly COMETARIO As New Columna("comentario", Columna.TIPO.TEXTO)

    Public Shared ReadOnly PEDIDO As New Columna("pedido", "cod_pedido", Columna.TIPO.MANY_TO_ONE, True, New Join(New Columna("codPedido", "cod_pedido", Columna.TIPO.NUMERICO, True)))

    Public Shared ReadOnly FECHA_DESDE As New Columna("fechaDesde", Columna.TIPO.FECHA)
    Public Shared ReadOnly FECHA_HASTA As New Columna("fechaHasta", Columna.TIPO.FECHA)
    Public Shared ReadOnly ESTADO As New Columna("estado", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("estadoPedido", Columna.TIPO.NUMERICO, True)), True)

    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(NRO_ESTADO)
        _columnas.Add(COMETARIO)
        _columnas.Add(PEDIDO)
        _columnas.Add(FECHA_DESDE)
        _columnas.Add(FECHA_HASTA)
        _columnas.Add(ESTADO)

        _columnas.Add(BORRADO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New HistoricoEstados().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarHistoricoEstados(ByVal criteria As List(Of Restriccion)) As List(Of HistoricoEstados)
        Dim lista As New List(Of HistoricoEstados)

        For Each elemento As HistoricoEstados In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

    Protected Overrides Sub cargarId(ByVal objeto As Object)
        Dim historico As HistoricoEstados = CType(objeto, HistoricoEstados)
        If historico.nroEstado = 0 Then
            Dim result As Object = dao.consultarValor("SELECT  ISNULL(MAX(" + NRO_ESTADO.columna + " + 1),1) from " + tabla + " WHERE " + PEDIDO.columna + "=" + historico.pedido.codPedido.ToString)

            Dim resultado As Long
            If result.GetType.Equals(GetType(System.DBNull)) Then
                resultado = 1
            Else
                resultado = Long.Parse(result)
            End If

            historico.nroEstado = resultado
        End If
    End Sub

End Class
