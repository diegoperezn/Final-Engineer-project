Public Class AltaMovimientoProveedor
    Inherits BasePage

    Dim movBusiness As MovimientoProveedorBusiness = BusinessFactory.movimientoProveedorBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.creacionMovimientoProveedor)

    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        Me.proveedor.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
    End Sub

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim mov As New MovimientosCuentaProveedor(Nothing, comentario.Text, DateTime.Now, monto.Text,
                                                New Cuenta(1), New TipoMovimiento(2), New Proveedor(proveedor.SelectedValue))

        Me.movBusiness.grabarMovimiento(mov)

        Response.Redirect("~\BusquedaMovimientoProveedor.aspx")
    End Sub

End Class