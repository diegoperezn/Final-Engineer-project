Public Class MovimientoCuentaClienteTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "MovimientosCuenta"

    Public Const TABLA_CLIENTE_MOVIMIENTO As String = "cliente_movimientos"
    Public Shared TABLA_DOCUMENTO_MOVIMIENTO As String = "documento_movimiento"

    Public Shared ReadOnly NRO_MOVIMIENTO As New Columna("nroMovimiento", "nro_movimiento", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly COMENTARIO As New Columna("comentario", Columna.TIPO.TEXTO)
    Public Shared ReadOnly FECHA As New Columna("fecha", Columna.TIPO.FECHA)
    Public Shared ReadOnly MONTO As New Columna("monto", Columna.TIPO.DOUBLE)
    Public Shared ReadOnly CUENTA As New Columna("cuenta", "cuentaID", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("codCuenta", Columna.TIPO.NUMERICO)), True)
    Public Shared ReadOnly TIPO_MOVIMIENTO As New Columna("tipoMovimiento", "tipoMovimientoID", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("tipoMovimiento", "tipoMovimientoID", Columna.TIPO.NUMERICO)), True)
    Public Shared ReadOnly CLIENTE As New Columna("cliente", "id_cliente", Columna.TIPO.MANY_TO_MANY,
                                                  New Join(New Columna("idCliente", "id_cliente", Columna.TIPO.NUMERICO, True), TABLA_CLIENTE_MOVIMIENTO, True), True)
    Public Shared ReadOnly FACTURA As New Columna("documento", "nro_doc", Columna.TIPO.MANY_TO_MANY,
                                          New Join(New Columna("nroDocumento", "nro_Doc", Columna.TIPO.NUMERICO), TABLA_DOCUMENTO_MOVIMIENTO, True), True)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(NRO_MOVIMIENTO)
        _columnas.Add(COMENTARIO)
        _columnas.Add(FECHA)
        _columnas.Add(MONTO)
        _columnas.Add(CUENTA)
        _columnas.Add(TIPO_MOVIMIENTO)
        _columnas.Add(CLIENTE)
        _columnas.Add(FACTURA)

    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New MovimientosCuentaCliente().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Protected Overrides Sub agregarRestriccionesGenerales(ByRef criterios As List(Of Restriccion))
        If criterios Is Nothing Then
            criterios = New List(Of Restriccion)
        End If

        criterios.Add(New Restriccion(CLIENTE, False, Restriccion.CONDICION_NULL))
    End Sub

    Function cargarMovimientos(ByVal criteria As List(Of Restriccion)) As List(Of MovimientosCuentaCliente)
        Dim lista As New List(Of MovimientosCuentaCliente)

        For Each elemento As MovimientosCuentaCliente In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
