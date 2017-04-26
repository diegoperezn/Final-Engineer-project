Public Class BusquedaMovimientoProveedor
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.listadoMovimientoProveedor)
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        Me.proveedor.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))

        Me.tipoMovimiento.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
    End Sub

    Protected Sub listaMovimientos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaMovimientos.SelectedIndexChanged
        Dim id As String = listaMovimientos.Rows(listaMovimientos.SelectedIndex).Cells(1).Text
        Response.Redirect("~\DetalleMovimientoProveedor.aspx?id=" + id)
    End Sub

End Class