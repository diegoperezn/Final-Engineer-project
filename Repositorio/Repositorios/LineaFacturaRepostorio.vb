Public Class LineaFacturaRepostorio

    Dim lineaTdg As LineaFacturaTDG
    Dim articuloTdg As ArticuloTDG

    Sub New(ByVal lineaTdg As LineaFacturaTDG, ByVal articuloTdg As ArticuloTDG)
        Me.lineaTdg = lineaTdg
        Me.articuloTdg = articuloTdg
    End Sub

    Public Function cargarLineasPorFactura(ByVal factura As Factura) As List(Of LineaFactura)
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(LineaFacturaTDG.NRO_FACTURA, factura.nroFactura))
        criteria.Add(New Restriccion(LineaFacturaTDG.TIPO_FACTURA, factura.tipoFactura))
        criteria.Add(New Restriccion(LineaFacturaTDG.NRO_SUCURSAL, factura.nroSucursal))
        Dim lineas As List(Of LineaFactura) = Me.lineaTdg.cargarLineasFactura(criteria)

        For Each linea As LineaFactura In lineas
            completarLinea(linea)
        Next

        Return Lineas
    End Function

    Private Sub completarLinea(ByRef linea As LineaFactura)
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(articuloTdg.COD_ARTICULO, linea.articulo.codArticulo))
        linea.articulo = Me.articuloTdg.buscarUnico(criteria)
    End Sub

End Class
