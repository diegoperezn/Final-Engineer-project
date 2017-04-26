Public Class BusquedaProveedor
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.listadoProveedor)
    End Sub

    Protected Sub listaProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaProveedores.SelectedIndexChanged
        Dim id As String = listaProveedores.Rows(listaProveedores.SelectedIndex).Cells(1).Text

        Response.Redirect("~\DetalleProveedor.aspx?id=" + id)
    End Sub

    Protected Sub listaProveedores_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles listaProveedores.RowEditing
        Dim id As String = listaProveedores.Rows(e.NewEditIndex).Cells(1).Text

        Response.Redirect("~\AltaModificacionProveedor.aspx?id=" + id)
    End Sub

End Class