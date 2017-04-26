Public Class FacturaBusiness

    Dim repo As FacturaRepositorio
    Dim produccionBusiness As ProduccionRepositorio

    Sub New()
        Me.produccionBusiness = RepositorioFactory.produccionRepositorio
        Me.repo = RepositorioFactory.facturaRepositorio
    End Sub

    Sub New(ByVal repo As FacturaRepositorio, ByVal prod As ProduccionRepositorio)
        Me.repo = repo
        Me.produccionBusiness = prod
    End Sub

    Public Sub grabarFactura(ByVal factura As Factura)
        Me.repo.grabarFactura(factura)
    End Sub

    Public Sub actualizaFactura(ByVal factura As Factura)
        Me.repo.actualizaFactura(factura)
    End Sub

    Public Function listarFacturas() As List(Of Factura)
        Return Me.repo.listarFacturas()
    End Function

    Public Function listarFacturasPorCliente(ByVal cliente As Cliente) As List(Of Factura)
        Return Me.repo.listarFacturasPorCliente(cliente)
    End Function

    Public Function buscarFacturas(ByVal nroFactura As Long, ByVal nroSucursal As Long, ByVal tipoFactura As String,
                                  ByVal fechaDsd As String, ByVal fechaHst As String,
                                  ByVal montoDesde As String, ByVal montoHasta As String, ByVal idCliente As String) As List(Of Factura)
        Return Me.repo.buscarFacturas(nroFactura, nroSucursal, tipoFactura, fechaDsd, fechaHst, montoDesde, montoHasta, idCliente)
    End Function

    Public Function listarFacturasPorId(ByVal nroFactura As Long, ByVal nroSucursal As Long, ByVal tipoFactura As String) As Factura
        Return Me.repo.listarFacturasPorId(nroFactura, nroSucursal, tipoFactura)
    End Function

    Public Function listarFacturasPorMovimiento(ByVal movimiento As MovimientosCuentaCliente) As Factura
        Return Me.repo.listarFacturasPorMovimiento(movimiento)
    End Function

    Public Function listarFacturasPorDocumento(ByVal nroDoc As Long) As List(Of Factura)
        Return Me.repo.listarFacturasPorDocumento(nroDoc)
    End Function

    Sub generarFactura(ByVal pedido As Pedido)
        Dim lineas As New List(Of LineaFactura)
        Dim total As Double
        Dim fecha As DateTime = DateTime.Now

        For Each prod As Produccion In pedido.trabajos
            Dim prodBase As Produccion = Me.produccionBusiness.listarProduccionPorCodigo(prod.codProduccion)
            Dim lineaFActura As LineaFactura = New LineaFactura(Nothing, prodBase.articulo, prodBase.cantidad,
                                                                prodBase.articulo.precioActual, Nothing, False)
            total += prodBase.cantidad * prodBase.articulo.precioActual
            lineas.Add(lineaFActura)
        Next

        Dim movimiento As New MovimientosCuentaCliente(Nothing, Nothing, fecha, total, New Cuenta(1), New TipoMovimiento(1), pedido.cliente)
        Dim factura As New Factura(Nothing, movimiento, total * 0.20999999999999999, total, fecha, False, Nothing, 1, "A", pedido.cliente, lineas)

        Me.grabarFactura(factura)
    End Sub

End Class
