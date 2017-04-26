Public Class DetalleMovimientoCliente
    Inherits BasePage

    Dim movBusiness As MovimientoClienteBusiness = BusinessFactory.movimientoClienteBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detalleMovimientoCliente)

        If Request.Params("id") IsNot Nothing Then
            cargarMovimiento(Long.Parse(Request.Params("id")))
        End If
    End Sub

    Private Sub cargarMovimiento(ByVal id As Long)
        Dim mov As MovimientosCuentaCliente = Me.movBusiness.buscarMovimientoPorNro(id)

        With mov
            cliente.Text = .cliente.nombre
            monto.Text = .monto.ToString("c")
            fecha.Text = .fecha.ToString("g")
            tipoCuenta.Text = .cuenta.tipo
            tipoMovimieto.text = .tipoMovimiento.descripcion
            comentario.Text = .comentario
        End With

    End Sub

End Class