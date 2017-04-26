Public Class MovimientoCuentaProveedorRepositorio

    Dim movimientosTDG As MovimientoCuentaProveedorTDG
    Dim proveedorRepo As ProveedorRepositorio
    Dim tipoTdg As TipoMovimientoTDG
    Dim cuentaTdg As CuentaTDG
    Dim ordenTdg As OrdenDeCompraTDG

    Sub New(ByVal mov As MovimientoCuentaProveedorTDG, ByVal proveedorRepo As ProveedorRepositorio, ByVal tipoTdg As TipoMovimientoTDG,
            ByVal cuentaTdg As CuentaTDG, ByVal ordenTdg As OrdenDeCompraTDG)
        Me.movimientosTDG = mov
        Me.proveedorRepo = proveedorRepo
        Me.tipoTdg = tipoTdg
        Me.cuentaTdg = cuentaTdg
        Me.ordenTdg = ordenTdg
    End Sub

    Public Function listarCuentas() As List(Of Cuenta)
        Return Me.cuentaTdg.buscarTipoCuentas(Nothing)
    End Function

    Public Function buscarMovimientos(ByVal com As String, ByVal fechaDsd As String, ByVal fechaHst As String, ByVal cuenta As String,
                                     ByVal tipo As String, ByVal montoDesde As String, ByVal montoHasta As String, ByVal idProveedor As String)
        Dim criteria As New List(Of Restriccion)
        If Not String.IsNullOrEmpty(com) Then
            criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.COMENTARIO, com, Restriccion.CONDICION_LIKE))
        End If
        If Not String.IsNullOrEmpty(fechaDsd) Then
            criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.FECHA, fechaDsd, Restriccion.CONDICION_MAYOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(fechaHst) Then
            criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.FECHA, fechaHst, Restriccion.CONDICION_MENOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(montoDesde) Then
            criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.MONTO, montoDesde, Restriccion.CONDICION_MAYOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(montoHasta) Then
            criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.MONTO, montoHasta, Restriccion.CONDICION_MENOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(cuenta) Then
            criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.CUENTA, cuenta))
        End If
        If Not String.IsNullOrEmpty(tipo) Then
            criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.TIPO_MOVIMIENTO, tipo))
        End If
        If Not String.IsNullOrEmpty(idProveedor) Then
            criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.PROVEEDOR, idProveedor, Restriccion.CONDICION_IGUAL))
        End If

        Dim movimientos As List(Of MovimientosCuentaProveedor) = movimientosTDG.cargarMovimientos(criteria)

        For Each mov In movimientos
            Me.completarMovimiento(mov)
        Next

        Return movimientos
    End Function

    Public Sub grabarMovimiento(ByVal mov As MovimientosCuentaProveedor)
        Me.movimientosTDG.grabar(mov)
    End Sub

    Public Sub actualizarMovimiento(ByVal mov As MovimientosCuentaProveedor)
        Me.movimientosTDG.actualizar(mov)
    End Sub

    Public Function listarMovimientos() As List(Of MovimientosCuentaProveedor)
        Dim results As List(Of MovimientosCuentaProveedor) = Me.movimientosTDG.cargarMovimientos(Nothing)

        For Each mov As MovimientosCuentaProveedor In results
            completarMovimiento(mov)
        Next

        Return results
    End Function

    Public Function listarMovimientosPorProveedor(ByVal id As Long) As List(Of MovimientosCuentaProveedor)
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.PROVEEDOR, id))
        Dim results As List(Of MovimientosCuentaProveedor) = Me.movimientosTDG.cargarMovimientos(Nothing)

        For Each mov As MovimientosCuentaProveedor In results
            completarMovimiento(mov)
        Next

        Return results
    End Function

    Public Function buscarMovimientoPorNro(ByVal id As Long) As MovimientosCuentaProveedor
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(MovimientoCuentaProveedorTDG.NRO_MOVIMIENTO, id))
        Dim result As MovimientosCuentaProveedor = Me.movimientosTDG.buscarUnico(criteria)

        completarMovimiento(result)

        Return result
    End Function

    Private Sub completarMovimiento(ByVal mov As MovimientosCuentaProveedor)
        Dim criteria As New List(Of Restriccion)
        mov.proveedor = Me.proveedorRepo.buscarProveedorPorCodigo(mov.proveedor.codProveedor)

        criteria.Clear()
        If Not mov.documento Is Nothing Then
            criteria.Add(New Restriccion(OrdenDeCompraTDG.NRO_DOCUMENTO, mov.documento.nroDocumento))
            mov.documento = Me.ordenTdg.buscarUnico(criteria)
        End If

        criteria.Clear()
        criteria.Add(New Restriccion(TipoMovimientoTDG.TIPO_MOVIMIENTO, mov.tipoMovimiento.tipoMovimiento))
        mov.tipoMovimiento = Me.tipoTdg.buscarUnico(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(cuentaTdg.COD_CUENTA, mov.cuenta.codCuenta))
        mov.cuenta = Me.cuentaTdg.buscarUnico(criteria)
    End Sub

End Class
