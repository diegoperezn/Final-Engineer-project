Public Class LineaFacturaTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "LineaFactura"

    Public Shared ReadOnly NRO_FACTURA As New Columna("factura", "nro_factura", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly NRO_SUCURSAL As New Columna("factura", "nro_sucursal", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly TIPO_FACTURA As New Columna("factura", "tipo_factura", Columna.TIPO.TEXTO, True)

    Public Shared ReadOnly NRO_LINEA As New Columna("nroLinea", "nro_linea", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly ARTICULO As New Columna("articulo", "cod_producto", Columna.TIPO.MANY_TO_ONE, New Join(ArticuloTDG.COD_ARTICULO, True))
    Public Shared ReadOnly CANTIDAD As New Columna("cantidad", "cantidad", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly PRECIO As New Columna("precio", "precio", Columna.TIPO.DOUBLE)

    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(NRO_FACTURA)
        _columnas.Add(NRO_SUCURSAL)
        _columnas.Add(TIPO_FACTURA)
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
        Return GetType(LineaFactura)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Protected Overrides Sub cargarId(ByVal objeto As Object)
        Dim linea As LineaFactura = DirectCast(objeto, LineaFactura)
        Dim resultado As Long = dao.consultarValor("SELECT  ISNULL(MAX(" + NRO_LINEA.columna + " + 1),1) from " + NOMBRE_TABLA + _
                                                   " WHERE " + NRO_FACTURA.columna + "=" + linea.factura.nroFactura.ToString + _
                                                        " AND " + NRO_SUCURSAL.columna + "=" + linea.factura.nroSucursal.ToString + _
                                                        " AND " + TIPO_FACTURA.columna + "='" + linea.factura.tipoFactura + "'")
        linea.nroLinea = Long.Parse(resultado)
    End Sub

    Protected Overrides Sub cargarPropiedad(ByRef objeto As Object, ByVal col As Columna, ByVal row As DataRow, ByVal dataset As DataSet)
        Dim linea As LineaFactura = DirectCast(objeto, LineaFactura)

        If col.nombre.Equals(NRO_FACTURA.nombre) Then
            If linea.factura Is Nothing Then
                Dim nroFactura As Long = Long.Parse(row(NRO_FACTURA.columna))
                Dim nroSucursal As Long = Long.Parse(row(NRO_SUCURSAL.columna))
                Dim tipoFactura As String = row(TIPO_FACTURA.columna)

                linea.factura = New Factura(nroFactura, nroSucursal, tipoFactura)
            End If
        Else
            MyBase.cargarPropiedad(objeto, col, row, dataset)
        End If
    End Sub

    Protected Overrides Function getValorObjeto(ByVal objeto As Object, ByVal col As Columna) As String
        Dim valor As String

        If col.nombre.Equals(NRO_FACTURA.nombre) Then
            Dim linea As LineaFactura = DirectCast(objeto, LineaFactura)

            If col.columna.Equals(NRO_FACTURA.columna) Then
                valor = linea.factura.nroFactura.ToString
            ElseIf col.columna.Equals(NRO_SUCURSAL.columna) Then
                valor = linea.factura.nroSucursal.ToString
            ElseIf col.columna.Equals(TIPO_FACTURA.columna) Then
                valor = linea.factura.tipoFactura
            End If

        Else
            valor = MyBase.getValorObjeto(objeto, col)
        End If

        Return valor
    End Function

    Function cargarLineasFactura(ByVal criteria As List(Of Restriccion)) As List(Of LineaFactura)
        Dim lista As New List(Of LineaFactura)

        For Each elemento As LineaFactura In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
