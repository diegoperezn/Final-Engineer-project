Public Class MovimientoCuentaClienteRepositorio

    Dim movimientoTdg As MovimientoCuentaClienteTDG
    Dim clienteRepo As ClienteRepositorio
    Dim tipoTdg As TipoMovimientoTDG
    Dim cuentaTdg As CuentaTDG
    Dim facturaTdg As FacturaTDG
    Private _listarMovimientosPorClienteYNro As List(Of MovimientosCuentaCliente)

    Sub New(ByVal movimientoTdg As MovimientoCuentaClienteTDG, ByVal clienteRepo As ClienteRepositorio,
         ByVal tipoTdg As TipoMovimientoTDG, ByVal cuentaTdg As CuentaTDG, ByVal facturaTdg As FacturaTDG)
        Me.movimientoTdg = movimientoTdg
        Me.clienteRepo = clienteRepo
        Me.tipoTdg = tipoTdg
        Me.cuentaTdg = cuentaTdg
        Me.facturaTdg = facturaTdg
    End Sub

    Public Function listarCuentas() As List(Of Cuenta)
        Return Me.cuentaTdg.buscarTipoCuentas(Nothing)
    End Function

    Public Function buscarMovimientos(ByVal com As String, ByVal fechaDsd As String, ByVal fechaHst As String, ByVal cuenta As String,
                                     ByVal tipo As String, ByVal montoDesde As String, ByVal montoHasta As String, ByVal idCliente As String)
        Dim criteria As New List(Of Restriccion)
        If Not String.IsNullOrEmpty(com) Then
            criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.COMENTARIO, com, Restriccion.CONDICION_LIKE))
        End If
        If Not String.IsNullOrEmpty(fechaDsd) Then
            criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.FECHA, fechaDsd, Restriccion.CONDICION_MAYOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(fechaHst) Then
            criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.FECHA, fechaHst, Restriccion.CONDICION_MENOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(montoDesde) Then
            criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.MONTO, montoDesde, Restriccion.CONDICION_MAYOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(montoHasta) Then
            criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.MONTO, montoHasta, Restriccion.CONDICION_MENOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(cuenta) Then
            criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.CUENTA, cuenta))
        End If
        If Not String.IsNullOrEmpty(tipo) Then
            criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.TIPO_MOVIMIENTO, tipo))
        End If
        If Not String.IsNullOrEmpty(idCliente) Then
            criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.CLIENTE, idCliente, Restriccion.CONDICION_IGUAL))
        End If

        Dim movimientos As List(Of MovimientosCuentaCliente) = movimientoTdg.cargarMovimientos(criteria)

        For Each mov In movimientos
            Me.completarMovimiento(mov)
        Next

        Return movimientos
    End Function

    Public Sub grabarMovimiento(ByVal mov As MovimientosCuentaCliente)
        Me.movimientoTdg.grabar(mov)
    End Sub

    Public Sub actualizarMovimiento(ByVal mov As MovimientosCuentaCliente)
        Me.movimientoTdg.actualizar(mov)
    End Sub

    Public Function listarMovimientos() As List(Of MovimientosCuentaCliente)
        Dim results As List(Of MovimientosCuentaCliente) = Me.movimientoTdg.cargarMovimientos(Nothing)

        For Each mov As MovimientosCuentaCliente In results
            completarMovimiento(mov)
        Next

        Return results
    End Function

    Public Function listarMovimientosPorCliente(ByVal id As Long) As List(Of MovimientosCuentaCliente)
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.CLIENTE, id))
        Dim results As List(Of MovimientosCuentaCliente) = Me.movimientoTdg.cargarMovimientos(Nothing)

        For Each mov As MovimientosCuentaCliente In results
            completarMovimiento(mov)
        Next

        Return results
    End Function

    Public Function buscarMovimientoPorNro(ByVal id As Long) As MovimientosCuentaCliente
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.NRO_MOVIMIENTO, id))
        Dim result As MovimientosCuentaCliente = Me.movimientoTdg.buscarUnico(criteria)

        completarMovimiento(result)

        Return result
    End Function

    Private Sub completarMovimiento(ByVal mov As MovimientosCuentaCliente)
        Dim criteria As New List(Of Restriccion)

        mov.cliente = Me.clienteRepo.CargarClientePorId(mov.cliente.idCliente)

        criteria.Clear()
        If Not mov.documento Is Nothing Then
            criteria.Add(New Restriccion(facturaTdg.NRO_DOCUMENTO, mov.documento.nroDocumento))
            mov.documento = Me.facturaTdg.buscarUnico(criteria)
        End If

        criteria.Clear()
        criteria.Add(New Restriccion(TipoMovimientoTDG.TIPO_MOVIMIENTO, mov.tipoMovimiento.tipoMovimiento))
        mov.tipoMovimiento = Me.tipoTdg.buscarUnico(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(cuentaTdg.COD_CUENTA, mov.cuenta.codCuenta))
        mov.cuenta = Me.cuentaTdg.buscarUnico(criteria)
    End Sub


End Class
