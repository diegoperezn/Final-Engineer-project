Public Class OrdenCompraRepositorio

    Dim ordenTdg As OrdenDeCompraTDG
    Dim lineaTdg As LineaOrdenDeCompraTDG
    Dim lineaRepo As LineaOrdenCompraRepositorio
    Dim proveedorTdg As ProveedorTDG
    Dim movimientoTDG As MovimientoCuentaProveedorTDG

    Sub New(ByVal ordenTdg As OrdenDeCompraTDG, ByVal lineaTdg As LineaOrdenDeCompraTDG,
            ByVal proveedorTdg As ProveedorTDG, ByVal lineaRepo As LineaOrdenCompraRepositorio,
            ByVal movimientoTDG As MovimientoCuentaProveedorTDG)
        Me.ordenTdg = ordenTdg
        Me.lineaTdg = lineaTdg
        Me.proveedorTdg = proveedorTdg
        Me.lineaRepo = lineaRepo
        Me.movimientoTDG = movimientoTDG
    End Sub

    Public Sub grabarOrdenDeCompra(ByVal orden As OrdenDeCompra)
        Me.ordenTdg.grabar(orden)

        For Each linea As LineaOrdenDeCompra In orden.lineaOrdenDeCompra
            Me.lineaTdg.grabar(linea)
        Next

        Me.movimientoTDG.grabar(orden.movimientoCuenta)
    End Sub


    Public Sub actualizaOrdenDeCompra(ByVal orden As OrdenDeCompra)
        Me.ordenTdg.actualizar(orden)

        For Each linea As LineaOrdenDeCompra In orden.lineaOrdenDeCompra
            If linea.nroLinea = 0 Then
                Me.lineaTdg.grabar(linea)
            Else
                Me.lineaTdg.actualizar(linea)
            End If
        Next

        If orden.movimientoCuenta.nroMovimiento = 0 Then
            Me.movimientoTDG.grabar(orden.movimientoCuenta)
        Else
            Me.movimientoTDG.actualizar(orden.movimientoCuenta)
        End If
    End Sub

    Public Function listarOrdenDeCompras() As List(Of OrdenDeCompra)
        Dim results As List(Of OrdenDeCompra) = Me.ordenTdg.cargarOrdenesDeCompras(Nothing)

        For Each fact As OrdenDeCompra In results
            completarOrdenDeCompra(fact)
        Next

        Return results
    End Function

    Public Function listarOrdenDeComprasPorProveedor(ByVal proveedor As Proveedor) As List(Of OrdenDeCompra)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(OrdenDeCompraTDG.PROVEEDOR, proveedor.codProveedor))

        Dim results As List(Of OrdenDeCompra) = Me.ordenTdg.cargarOrdenesDeCompras(criteria)

        For Each fact As OrdenDeCompra In results
            completarOrdenDeCompra(fact)
        Next

        Return results
    End Function

    Public Function listarOrdenDeComprasPorId(ByVal nroOrdenDeCompra As Long, ByVal nroSucursal As Long, ByVal tipoOrdenDeCompra As String) As OrdenDeCompra
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_ORDEN_DE_COMPRA, nroOrdenDeCompra))
        criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_SUCURSAL, nroSucursal))
        criteria.Add(New Restriccion(OrdenDeCompraTDG.TIPO_ORDEN_DE_COMPRA, tipoOrdenDeCompra))

        Dim result As OrdenDeCompra = Me.ordenTdg.buscarUnico(criteria)

        completarOrdenDeCompra(result)

        Return result
    End Function

    Public Function listarOrdenDeComprasPorMovimiento(ByVal movimiento As MovimientosCuentaCliente) As OrdenDeCompra
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_DOCUMENTO, movimiento.documento.nroDocumento))

        Dim result As OrdenDeCompra = Me.ordenTdg.buscarUnico(criteria)

        completarOrdenDeCompra(result)

        Return result
    End Function

    Public Function listarOrdenDeComprasPorDocumento(ByVal nroDoc As Long) As List(Of OrdenDeCompra)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_DOCUMENTO, nroDoc))

        Dim results As List(Of OrdenDeCompra) = Me.ordenTdg.cargarOrdenesDeCompras(criteria)

        For Each fact As OrdenDeCompra In results
            completarOrdenDeCompra(fact)
        Next

        Return results
    End Function


    Public Function buscarOrdenDeCompras(ByVal nroOrdenDeCompra As Long, ByVal nroSucursal As Long, ByVal tipoOrdenDeCompra As String,
                                  ByVal fechaDsd As String, ByVal fechaHst As String,
                                  ByVal montoDesde As String, ByVal montoHasta As String, ByVal idCliente As String) As List(Of OrdenDeCompra)
        Dim criteria As New List(Of Restriccion)

        If Not nroOrdenDeCompra = 0 Then
            criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_ORDEN_DE_COMPRA, nroOrdenDeCompra))
        End If
        If Not nroSucursal = 0 Then
            criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_SUCURSAL, nroSucursal))
        End If
        If Not String.IsNullOrEmpty(tipoOrdenDeCompra) Then
            criteria.Add(New Restriccion(OrdenDeCompraTDG.TIPO_ORDEN_DE_COMPRA, tipoOrdenDeCompra))
        End If
        If Not String.IsNullOrEmpty(fechaDsd) Then
            criteria.Add(New Restriccion(OrdenDeCompraTDG.FECHA, fechaDsd, Restriccion.CONDICION_MAYOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(fechaHst) Then
            criteria.Add(New Restriccion(OrdenDeCompraTDG.FECHA, fechaHst, Restriccion.CONDICION_MENOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(montoDesde) Then
            criteria.Add(New Restriccion(OrdenDeCompraTDG.MONTO, montoDesde, Restriccion.CONDICION_MAYOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(montoHasta) Then
            criteria.Add(New Restriccion(OrdenDeCompraTDG.MONTO, montoHasta, Restriccion.CONDICION_MENOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(idCliente) Then
            criteria.Add(New Restriccion(OrdenDeCompraTDG.PROVEEDOR, idCliente, Restriccion.CONDICION_IGUAL))
        End If

        Dim ordenes As List(Of OrdenDeCompra) = Me.ordenTdg.cargarOrdenesDeCompras(criteria)

        For Each fac As OrdenDeCompra In ordenes
            Me.completarOrdenDeCompra(fac)
        Next

        Return ordenes
    End Function

    Private Sub completarOrdenDeCompra(ByRef orden As OrdenDeCompra)
        Dim criteria As New List(Of Restriccion)

        orden.lineaOrdenDeCompra = Me.lineaRepo.cargarLineasPorOrdenDeCompra(orden)

        criteria.Clear()
        criteria.Add(New Restriccion(proveedorTdg.COD_PROVEEDOR, orden.proveedor.codProveedor))
        orden.proveedor = Me.proveedorTdg.buscarUnico(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.FACTURA, orden.nroDocumento))
        orden.movimientoCuenta = Me.movimientoTDG.buscarUnico(criteria)
    End Sub

End Class
