Public Class LineaOrdenDeCompraTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "LineaOrdenDeCompra"

    Public Shared ReadOnly NRO_ORDEN As New Columna("orden", "nro_orden_compra", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly NRO_SUCURSAL As New Columna("orden", "nro_sucursal", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly TIPO_ORDEN As New Columna("orden", "tipo_orden_compra", Columna.TIPO.TEXTO, True)

    Public Shared ReadOnly NRO_LINEA As New Columna("nroLinea", "nro_linea", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly ARTICULO As New Columna("articulo", "cod_producto", Columna.TIPO.MANY_TO_ONE, New Join(InsumoTDG.COD_INSUMO, True))
    Public Shared ReadOnly CANTIDAD As New Columna("cantidad", "cantidad", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly PRECIO As New Columna("precio", "precio", Columna.TIPO.DOUBLE)

    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(NRO_ORDEN)
        _columnas.Add(NRO_SUCURSAL)
        _columnas.Add(TIPO_ORDEN)
        _columnas.Add(NRO_LINEA)

        _columnas.Add(ARTICULO)
        _columnas.Add(CANTIDAD)
        _columnas.Add(PRECIO)

        _columnas.Add(BORRADO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(LineaOrdenDeCompra)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Protected Overrides Sub cargarId(ByVal objeto As Object)
        Dim linea As LineaOrdenDeCompra = DirectCast(objeto, LineaOrdenDeCompra)
        Dim resultado As Long = dao.consultarValor("SELECT  ISNULL(MAX(" + NRO_LINEA.columna + " + 1),1) from " + NOMBRE_TABLA + _
                                                   " WHERE " + NRO_ORDEN.columna + "=" + linea.ordenDeCompra.nroOrdenCompra.ToString + _
                                                        " AND " + NRO_SUCURSAL.columna + "=" + linea.ordenDeCompra.nroSucursal.ToString + _
                                                        " AND " + TIPO_ORDEN.columna + "='" + linea.ordenDeCompra.tipoOrdenCompra + "'")
        linea.nroLinea = Long.Parse(resultado)
    End Sub

    Protected Overrides Sub cargarPropiedad(ByRef objeto As Object, ByVal col As Columna, ByVal row As DataRow, ByVal dataset As DataSet)
        Dim linea As LineaOrdenDeCompra = DirectCast(objeto, LineaOrdenDeCompra)

        If col.nombre.Equals(NRO_ORDEN.nombre) Then
            If linea.ordenDeCompra Is Nothing Then
                Dim nroOrden As Long = Long.Parse(row(NRO_ORDEN.columna))
                Dim nroSucursal As Long = Long.Parse(row(NRO_SUCURSAL.columna))
                Dim tipoOrden As String = row(TIPO_ORDEN.columna)

                linea.ordenDeCompra = New OrdenDeCompra(nroOrden, nroSucursal, tipoOrden)
            End If
        Else
            MyBase.cargarPropiedad(objeto, col, row, dataset)
        End If
    End Sub

    Protected Overrides Function getValorObjeto(ByVal objeto As Object, ByVal col As Columna) As String
        Dim valor As String

        If col.nombre.Equals(NRO_ORDEN.nombre) Then
            Dim linea As LineaOrdenDeCompra = DirectCast(objeto, LineaOrdenDeCompra)

            If col.columna.Equals(NRO_ORDEN.columna) Then
                valor = linea.ordenDeCompra.nroOrdenCompra.ToString
            ElseIf col.columna.Equals(NRO_SUCURSAL.columna) Then
                valor = linea.ordenDeCompra.nroSucursal.ToString
            ElseIf col.columna.Equals(TIPO_ORDEN.columna) Then
                valor = linea.ordenDeCompra.tipoOrdenCompra
            End If

        Else
            valor = MyBase.getValorObjeto(objeto, col)
        End If

        Return valor
    End Function

    Function cargarLineasOrdenDeCompra(ByVal criteria As List(Of Restriccion)) As List(Of LineaOrdenDeCompra)
        Dim lista As New List(Of LineaOrdenDeCompra)

        For Each elemento As LineaOrdenDeCompra In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function
End Class
