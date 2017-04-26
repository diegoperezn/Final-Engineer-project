Public Class MovimientoProveedorBusiness

    Dim movRepo As MovimientoCuentaProveedorRepositorio

    Sub New()
        Me.movRepo = RepositorioFactory.movimientoCuentaProveedorRepositorio
    End Sub

    Sub New(ByVal movBusinesss As MovimientoCuentaProveedorRepositorio)
        Me.movRepo = movBusinesss
    End Sub

    Public Function buscarMovimientos(ByVal com As String, ByVal fechaDsd As String, ByVal fechaHst As String, ByVal cuenta As String,
                                 ByVal tipo As String, ByVal montoDesde As String, ByVal montoHasta As String, ByVal idProveedor As String)
        Return movRepo.buscarMovimientos(com, fechaDsd, fechaHst, cuenta, tipo, montoDesde, montoHasta, idProveedor)
    End Function

    Public Function listarCuentas() As List(Of Cuenta)
        Return Me.movRepo.listarCuentas()
    End Function

    Public Sub grabarMovimiento(ByVal mov As MovimientosCuentaProveedor)
        Me.movRepo.grabarMovimiento(mov)
    End Sub

    Public Sub actualizarMovimiento(ByVal mov As MovimientosCuentaProveedor)
        Me.movRepo.actualizarMovimiento(mov)
    End Sub

    Public Function listarMovimientos() As List(Of MovimientosCuentaProveedor)
        Return Me.movRepo.listarMovimientos
    End Function

    Public Function listarMovimientosPorProveedor(ByVal id As Long) As List(Of MovimientosCuentaProveedor)
        Return Me.movRepo.listarMovimientosPorProveedor(id)
    End Function

    Public Function buscarMovimientoPorNro(ByVal id As Long) As MovimientosCuentaProveedor
        Return Me.movRepo.buscarMovimientoPorNro(id)
    End Function

End Class
