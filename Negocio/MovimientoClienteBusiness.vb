Public Class MovimientoClienteBusiness

    Dim movRepo As MovimientoCuentaClienteRepositorio

    Sub New()
        Me.movRepo = RepositorioFactory.movimientoCuentaClienteRepositorio
    End Sub

    Sub New(ByVal movBusinesss As MovimientoCuentaClienteRepositorio)
        Me.movRepo = movBusinesss
    End Sub

    Public Function buscarMovimientos(ByVal com As String, ByVal fechaDsd As String, ByVal fechaHst As String, ByVal cuenta As String,
                                 ByVal tipo As String, ByVal montoDesde As String, ByVal montoHasta As String, ByVal idCliente As String) As List(Of MovimientosCuentaCliente)
        Return movRepo.buscarMovimientos(com, fechaDsd, fechaHst, cuenta, tipo, montoDesde, montoHasta, idCliente)
    End Function

    Public Function listarCuentas() As List(Of Cuenta)
        Return Me.movRepo.listarCuentas()
    End Function

    Public Sub grabarMovimiento(ByVal mov As MovimientosCuentaCliente)
        Me.movRepo.grabarMovimiento(mov)
    End Sub

    Public Sub actualizarMovimiento(ByVal mov As MovimientosCuentaCliente)
        Me.movRepo.actualizarMovimiento(mov)
    End Sub

    Public Function listarMovimientos() As List(Of MovimientosCuentaCliente)
        Return Me.movRepo.listarMovimientos
    End Function

    Public Function listarMovimientosPorCliente(ByVal id As Long) As List(Of MovimientosCuentaCliente)
        Return Me.movRepo.listarMovimientosPorCliente(id)
    End Function


    Public Function buscarMovimientoPorNro(ByVal id As Long) As MovimientosCuentaCliente
        Return Me.movRepo.buscarMovimientoPorNro(id)
    End Function

End Class
