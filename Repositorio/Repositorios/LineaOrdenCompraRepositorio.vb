Public Class LineaOrdenCompraRepositorio

    Dim lineaTdg As LineaOrdenDeCompraTDG
    Dim insumoTDG As InsumoTDG

    Sub New(ByVal lineaTdg As LineaOrdenDeCompraTDG, ByVal insumoTDG As InsumoTDG)
        Me.lineaTdg = lineaTdg
        Me.insumoTDG = insumoTDG
    End Sub

    Public Function cargarLineasPorOrdenDeCompra(ByVal orden As OrdenDeCompra) As List(Of LineaOrdenDeCompra)
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_ORDEN, orden.nroOrdenCompra))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.TIPO_ORDEN, orden.tipoOrdenCompra))
        criteria.Add(New Restriccion(LineaOrdenDeCompraTDG.NRO_SUCURSAL, orden.nroSucursal))

        Dim lineas As List(Of LineaOrdenDeCompra) = Me.lineaTdg.cargarLineasOrdenDeCompra(criteria)

        For Each linea As LineaOrdenDeCompra In lineas
            completarLinea(linea)
        Next

        Return lineas
    End Function

    Private Sub completarLinea(ByRef linea As LineaOrdenDeCompra)
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(insumoTDG.COD_INSUMO, linea.articulo.codInsumo))
        linea.articulo = Me.insumoTDG.buscarUnico(criteria)
    End Sub

End Class
