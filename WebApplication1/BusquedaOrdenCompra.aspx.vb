Public Class BusquedaOrdenCompra
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.listadoMovimientoProveedor)
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        Me.proveedor.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
    End Sub

    Protected Sub listaOrdenCompras_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaOrdenCompras.SelectedIndexChanged
        Dim nroOrdenCompra As String = listaOrdenCompras.Rows(listaOrdenCompras.SelectedIndex).Cells(2).Text
        Dim nroSucursal As String = listaOrdenCompras.Rows(listaOrdenCompras.SelectedIndex).Cells(3).Text
        Dim tipoOrdenCompra As String = listaOrdenCompras.Rows(listaOrdenCompras.SelectedIndex).Cells(4).Text

        Response.Redirect("~\DetalleOrdenCompra.aspx?nroOrdenCompra=" + nroOrdenCompra + _
                                                "&nroSucursal=" + nroOrdenCompra + _
                                                "&tipoOrdenCompra=" + tipoOrdenCompra)
    End Sub
End Class