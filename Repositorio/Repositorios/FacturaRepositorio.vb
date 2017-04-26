Public Class FacturaRepositorio

    Dim facturaTdg As FacturaTDG
    Dim lineaTdg As LineaFacturaTDG
    Dim lineaRepo As LineaFacturaRepostorio
    Dim clienteTdg As ClienteTDG
    Dim movimientoTDG As MovimientoCuentaClienteTDG
    Dim usuarioTdg As UsuarioTDG

    Sub New(ByVal facturaTdg As FacturaTDG, ByVal lineaTdg As LineaFacturaTDG,
            ByVal clienteTdg As ClienteTDG, ByVal lineaRepo As LineaFacturaRepostorio,
            ByVal movimientoTDG As MovimientoCuentaClienteTDG, ByVal usuarioTdg As UsuarioTDG)
        Me.facturaTdg = facturaTdg
        Me.lineaTdg = lineaTdg
        Me.clienteTdg = clienteTdg
        Me.lineaRepo = lineaRepo
        Me.movimientoTDG = movimientoTDG
        Me.usuarioTdg = usuarioTdg
    End Sub

    Public Sub grabarFactura(ByVal factura As Factura)
        Me.facturaTdg.grabar(factura)

        For Each linea As LineaFactura In factura.lineas
            Me.lineaTdg.grabar(linea)
        Next

        Me.movimientoTDG.grabar(factura.movimientoCuenta)
    End Sub


    Public Sub actualizaFactura(ByVal factura As Factura)
        Me.facturaTdg.actualizar(factura)

        For Each linea As LineaFactura In factura.lineas
            If linea.nroLinea = 0 Then
                Me.lineaTdg.grabar(linea)
            Else
                Me.lineaTdg.actualizar(linea)
            End If
        Next

        If factura.movimientoCuenta.nroMovimiento = 0 Then
            Me.movimientoTDG.grabar(factura.movimientoCuenta)
        Else
            Me.movimientoTDG.actualizar(factura.movimientoCuenta)
        End If
    End Sub

    Public Function listarFacturas() As List(Of Factura)
        Dim results As List(Of Factura) = Me.facturaTdg.cargarFacturas(Nothing)

        For Each fact As Factura In results
            completarFactura(fact)
        Next

        Return results
    End Function

    Public Function listarFacturasPorCliente(ByVal cliente As Cliente) As List(Of Factura)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(facturaTdg.CLIENTE, cliente.idCliente))

        Dim results As List(Of Factura) = Me.facturaTdg.cargarFacturas(criteria)

        For Each fact As Factura In results
            completarFactura(fact)
        Next

        Return results
    End Function

    Public Function listarFacturasPorId(ByVal nroFactura As Long, ByVal nroSucursal As Long, ByVal tipoFactura As String) As Factura
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(facturaTdg.NRO_FACTURA, nroFactura))
        criteria.Add(New Restriccion(facturaTdg.NRO_SUCURSAL, nroSucursal))
        criteria.Add(New Restriccion(facturaTdg.TIPO_FACTURA, tipoFactura))

        Dim result As Factura = Me.facturaTdg.buscarUnico(criteria)

        completarFactura(result)

        Return result
    End Function

    Public Function listarFacturasPorMovimiento(ByVal movimiento As MovimientosCuentaCliente) As Factura
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(facturaTdg.NRO_DOCUMENTO, movimiento.documento.nroDocumento))

        Dim result As Factura = Me.facturaTdg.buscarUnico(criteria)

        completarFactura(result)

        Return result
    End Function

    Public Function listarFacturasPorDocumento(ByVal nroDoc As Long) As List(Of Factura)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(facturaTdg.NRO_DOCUMENTO, nroDoc))

        Dim results As List(Of Factura) = Me.facturaTdg.cargarFacturas(criteria)

        For Each fact As Factura In results
            completarFactura(fact)
        Next

        Return results
    End Function

    Public Function buscarFacturas(ByVal nroFactura As Long, ByVal nroSucursal As Long, ByVal tipoFactura As String,
                                      ByVal fechaDsd As String, ByVal fechaHst As String,
                                      ByVal montoDesde As String, ByVal montoHasta As String, ByVal idCliente As String) As List(Of Factura)
        Dim criteria As New List(Of Restriccion)

        If Not nroFactura = 0 Then
            criteria.Add(New Restriccion(facturaTdg.NRO_FACTURA, nroFactura))
        End If
        If Not nroSucursal = 0 Then
            criteria.Add(New Restriccion(facturaTdg.NRO_SUCURSAL, nroSucursal))
        End If
        If Not String.IsNullOrEmpty(tipoFactura) Then
            criteria.Add(New Restriccion(facturaTdg.TIPO_FACTURA, tipoFactura))
        End If
        If Not String.IsNullOrEmpty(fechaDsd) Then
            criteria.Add(New Restriccion(facturaTdg.FECHA, fechaDsd, Restriccion.CONDICION_MAYOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(fechaHst) Then
            criteria.Add(New Restriccion(facturaTdg.FECHA, fechaHst, Restriccion.CONDICION_MENOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(montoDesde) Then
            criteria.Add(New Restriccion(facturaTdg.MONTO, montoDesde, Restriccion.CONDICION_MAYOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(montoHasta) Then
            criteria.Add(New Restriccion(facturaTdg.MONTO, montoHasta, Restriccion.CONDICION_MENOR_IGUAL))
        End If
        If Not String.IsNullOrEmpty(idCliente) Then
            criteria.Add(New Restriccion(facturaTdg.CLIENTE, idCliente, Restriccion.CONDICION_IGUAL))
        End If

        Dim facturas As List(Of Factura) = facturaTdg.cargarFacturas(criteria)

        For Each fac As Factura In facturas
            Me.completarFactura(fac)
        Next

        Return facturas
    End Function

    Private Sub completarFactura(ByRef factura As Factura)
        Dim criteria As New List(Of Restriccion)

        factura.lineas = Me.lineaRepo.cargarLineasPorFactura(factura)

        criteria.Clear()
        criteria.Add(New Restriccion(clienteTdg.ID_CLIENTE, factura.cliente.idCliente))
        factura.cliente = Me.clienteTdg.buscarUnico(criteria)
        factura.cliente.agregarUsuario(UsuarioTDG.buscarUnico(New Restriccion(UsuarioTDG.ID_USUARIO, factura.cliente.id)))

        criteria.Clear()
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.FACTURA, factura.nroDocumento))
        factura.movimientoCuenta = Me.movimientoTDG.buscarUnico(criteria)
    End Sub

    

End Class
