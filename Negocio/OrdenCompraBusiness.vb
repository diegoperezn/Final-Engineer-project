Public Class OrdenCompraBusiness

    Dim repo As OrdenCompraRepositorio

    Sub New()
        Me.repo = RepositorioFactory.ordenCompraRepositorio
    End Sub

    Sub New(ByVal repo As OrdenCompraRepositorio)
        Me.repo = repo
    End Sub

    Public Sub grabarOrdenDeCompra(ByVal orden As OrdenDeCompra)
        Me.repo.grabarOrdenDeCompra(orden)
    End Sub

    Public Sub actualizaOrdenDeCompra(ByVal orden As OrdenDeCompra)
        Me.repo.actualizaOrdenDeCompra(orden)
    End Sub

    Public Function listarOrdenDeCompras() As List(Of OrdenDeCompra)
        Return Me.repo.listarOrdenDeCompras()
    End Function

    Public Function listarOrdenDeComprasPorProveedor(ByVal proveedor As Proveedor) As List(Of OrdenDeCompra)
        Return Me.repo.listarOrdenDeComprasPorProveedor(proveedor)
    End Function

    Public Function listarOrdenDeComprasPorId(ByVal nroOrdenDeCompra As Long, ByVal nroSucursal As Long, ByVal tipoOrdenDeCompra As String) As OrdenDeCompra
        Return Me.repo.listarOrdenDeComprasPorId(nroOrdenDeCompra, nroSucursal, tipoOrdenDeCompra)
    End Function

    Public Function listarOrdenDeComprasPorMovimiento(ByVal movimiento As MovimientosCuentaCliente) As OrdenDeCompra
        Return Me.repo.listarOrdenDeComprasPorMovimiento(movimiento)
    End Function

    Public Function listarOrdenDeComprasPorDocumento(ByVal nroDoc As Long) As List(Of OrdenDeCompra)
        Return Me.repo.listarOrdenDeComprasPorDocumento(nroDoc)
    End Function

    Public Function buscarOrdenes(ByVal nroOrden As Long, ByVal nroSucursal As Long, ByVal tipoOrden As String,
                              ByVal fechaDsd As String, ByVal fechaHst As String,
                              ByVal montoDesde As String, ByVal montoHasta As String, ByVal idCliente As String) As List(Of OrdenDeCompra)
        Return Me.repo.buscarOrdenDeCompras(nroOrden, nroSucursal, tipoOrden, fechaDsd, fechaHst, montoDesde, montoHasta, idCliente)
    End Function

End Class
