Public Class AltaMovimientoCliente
    Inherits BasePage

    Dim movBusiness As MovimientoClienteBusiness = BusinessFactory.movimientoClienteBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.creacionMovimientoCliente)
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        Me.cliente.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        Me.cuenta.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
    End Sub

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim mov As New MovimientosCuentaCliente(Nothing, comentario.Text, DateTime.Now, monto.Text,
                                                New Cuenta(cuenta.SelectedValue),
                                                New TipoMovimiento(2), New Cliente(cliente.SelectedValue))

        Me.movBusiness.grabarMovimiento(mov)

        Response.Redirect("~\BusquedaMovimientoCliente.aspx")
    End Sub

End Class