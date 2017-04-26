Public Class MovimientoStockTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "MovimientosStock"

    Public Shared ReadOnly NRO_MOVIMIENTO As New Columna("nroMovimiento", "nro_movimiento", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly INSUMO As New Columna("insumo", "cod_insumo", Columna.TIPO.MANY_TO_ONE, True, New Join(New Columna("codInsumo", "cod_insumo", Columna.TIPO.NUMERICO, True)))
    Public Shared ReadOnly TIPO_MOVIMIENTO As New Columna("tipoMovimiento", "tipo", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("tipoMovimiento", "tipoMovimientoID", Columna.TIPO.NUMERICO)), True)
    Public Shared ReadOnly FECHA As New Columna("fecha", Columna.TIPO.FECHA)
    Public Shared ReadOnly CANTIDAD As New Columna("cantidad", Columna.TIPO.DOUBLE)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(NRO_MOVIMIENTO)
        _columnas.Add(INSUMO)
        _columnas.Add(TIPO_MOVIMIENTO)
        _columnas.Add(FECHA)
        _columnas.Add(CANTIDAD)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(MovimientosStock)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarMovimientos(ByVal criteria As List(Of Restriccion)) As List(Of MovimientosStock)
        Dim lista As New List(Of MovimientosStock)

        For Each elemento As MovimientosStock In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

    Protected Overrides Sub cargarId(ByVal objeto As Object)
        Dim movimiento As MovimientosStock = CType(objeto, MovimientosStock)
        If movimiento.nroMovimiento = 0 Then
            Dim resultado As Long = dao.consultarValor("SELECT  ISNULL(MAX(" + NRO_MOVIMIENTO.columna + " + 1),1) from " + tabla + " WHERE " + INSUMO.columna + "=" + movimiento.insumo.codInsumo.ToString)
            movimiento.nroMovimiento = resultado
        End If
    End Sub
End Class
