Public Class MovimientoCuentaProveedorTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "MovimientosCuenta"

    Public Const TABLA_PROVEEDOR_MOVIMIENTO As String = "proveedor_movimientos"
    Public Shared TABLA_DOCUMENTO_MOVIMIENTO As String = "documento_movimiento"

    Public Shared ReadOnly NRO_MOVIMIENTO As New Columna("nroMovimiento", "nro_movimiento", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly COMENTARIO As New Columna("comentario", Columna.TIPO.TEXTO)
    Public Shared ReadOnly FECHA As New Columna("fecha", Columna.TIPO.FECHA)
    Public Shared ReadOnly MONTO As New Columna("monto", Columna.TIPO.DOUBLE)
    Public Shared ReadOnly CUENTA As New Columna("cuenta", "cuentaID", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("codCuenta", Columna.TIPO.NUMERICO)), True)
    Public Shared ReadOnly TIPO_MOVIMIENTO As New Columna("tipoMovimiento", "tipoMovimientoID", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("tipoMovimiento", "tipoMovimientoID", Columna.TIPO.NUMERICO)), True)
    Public Shared ReadOnly PROVEEDOR As New Columna("proveedor", "id_proveedor", Columna.TIPO.MANY_TO_MANY,
                                                  New Join(ProveedorTDG.COD_PROVEEDOR, TABLA_PROVEEDOR_MOVIMIENTO, True), True)

    Public Shared ReadOnly ORDEN_COMPRA As New Columna("documento", "nro_doc", Columna.TIPO.MANY_TO_MANY,
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
        _columnas.Add(PROVEEDOR)
        _columnas.Add(ORDEN_COMPRA)

    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(MovimientosCuentaProveedor)
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

        criterios.Add(New Restriccion(PROVEEDOR, False, Restriccion.CONDICION_NULL))
    End Sub

    Function cargarMovimientos(ByVal criteria As List(Of Restriccion)) As List(Of MovimientosCuentaProveedor)
        Dim lista As New List(Of MovimientosCuentaProveedor)

        For Each elemento As MovimientosCuentaProveedor In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
