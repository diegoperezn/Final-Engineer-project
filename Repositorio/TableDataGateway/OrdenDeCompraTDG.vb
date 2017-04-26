Public Class OrdenDeCompraTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "OrdenDeCompra"

    Public Shared TABLA_DOCUMENTO_MOVIMIENTO As String = "documento_movimiento"
    Public Shared TABLA_DOCUMENTO As String = "documento"

    Public Shared ReadOnly NRO_DOCUMENTO As New Columna("nroDocumento", "nro_Doc", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly IVA As New Columna("iva", Columna.TIPO.DOUBLE)
    Public Shared ReadOnly MONTO As New Columna("monto", Columna.TIPO.DOUBLE)
    Public Shared ReadOnly FECHA As New Columna("fecha", Columna.TIPO.FECHA)
    Public Shared ReadOnly MOVIMIENTO_CUENTA As New Columna("movimientoCuenta", "nro_doc", Columna.TIPO.MANY_TO_MANY,
                                              New Join(MovimientoCuentaClienteTDG.NRO_MOVIMIENTO, TABLA_DOCUMENTO_MOVIMIENTO, True), False)
    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Public Shared ReadOnly NRO_ORDEN_DE_COMPRA As New Columna("nroOrdenCompra", "nro_orden_compra", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly NRO_SUCURSAL As New Columna("nroSucursal", "nro_sucursal", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly TIPO_ORDEN_DE_COMPRA As New Columna("tipoOrdenCompra", "tipo_orden_compra", Columna.TIPO.TEXTO, True)
    Public Shared ReadOnly PROVEEDOR As New Columna("proveedor", "id_proveedor", Columna.TIPO.MANY_TO_ONE, New Join(ProveedorTDG.COD_PROVEEDOR))
    Public Shared ReadOnly LINEAS As New Columna("lineaOrdenDeCompra", Columna.TIPO.ONE_TO_MANY, New Join(LineaOrdenDeCompraTDG.NRO_LINEA, LineaOrdenDeCompraTDG.NOMBRE_TABLA, True), True)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(NRO_DOCUMENTO)
        _columnas.Add(IVA)
        _columnas.Add(FECHA)
        _columnas.Add(MOVIMIENTO_CUENTA)
        _columnas.Add(BORRADO)
        _columnas.Add(NRO_ORDEN_DE_COMPRA)
        _columnas.Add(NRO_SUCURSAL)
        _columnas.Add(TIPO_ORDEN_DE_COMPRA)
        _columnas.Add(PROVEEDOR)
        _columnas.Add(LINEAS)
        _columnas.Add(MONTO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(OrdenDeCompra)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Protected Overrides Sub cargarId(ByVal objeto As Object)
        Dim orden As OrdenDeCompra = DirectCast(objeto, OrdenDeCompra)
        Dim resultado As Long = dao.consultarValor("SELECT  ISNULL(MAX(" + NRO_DOCUMENTO.columna + " + 1),1) from " + TABLA_DOCUMENTO)
        orden.nroDocumento = Long.Parse(resultado)
        dao.saveOrUpdate("INSERT INTO " + TABLA_DOCUMENTO + " VALUES (" + resultado.ToString + ")")

        resultado = dao.consultarValor("SELECT  ISNULL(MAX(" + NRO_ORDEN_DE_COMPRA.columna + " + 1),1) from " + NOMBRE_TABLA _
                                       + " WHERE " + NRO_SUCURSAL.columna + "=" + orden.nroSucursal.ToString +
                                           " AND " + TIPO_ORDEN_DE_COMPRA.columna + "='" + orden.tipoOrdenCompra.ToString + "'")
        orden.nroOrdenCompra = Long.Parse(resultado)
    End Sub

    Protected Overrides Sub crearRelacion(ByRef dataset As DataSet, ByVal col As Columna)
        If col.Equals(MOVIMIENTO_CUENTA) Then
            If dataset.Tables(col.join.tabla) IsNot Nothing Then
                Dim relacion As New DataRelation(col.nombre, dataset.Tables(tabla).Columns(NRO_DOCUMENTO.columna), dataset.Tables(col.join.tabla).Columns(NRO_DOCUMENTO.columna), False)
                dataset.Relations.Add(relacion)
            End If
        Else
            MyBase.crearRelacion(dataset, col)
        End If

    End Sub

    Function cargarOrdenesDeCompras(ByVal criteria As List(Of Restriccion)) As List(Of OrdenDeCompra)
        Dim lista As New List(Of OrdenDeCompra)

        For Each elemento As OrdenDeCompra In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

    Public Overrides Sub borrar(ByVal Objecto As Object)
        Throw New Exception("No se puede borrar una factura")
    End Sub


End Class
