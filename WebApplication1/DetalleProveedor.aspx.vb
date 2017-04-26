Public Class DetalleProveedor
    Inherits BasePage

    Dim proveedorBusiness As ProveedorBusiness = BusinessFactory.proveedorBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detalleProveedor)

        If Request.Params("id") IsNot Nothing Then
            Me.cargarProveedor(Request.Params("id"))
        End If
    End Sub

    Protected Sub cargarProveedor(ByVal id As Long)
        Dim pro As Proveedor = proveedorBusiness.buscarProveedorPorCodigo(id)

        With pro
            idProveedor.Value = .codProveedor

            direccion.Text = .direccion
            nombre.Text = .nombre
            telefono.Text = .telefono
        End With
    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Response.Redirect("~\AltaModificacionProveedor.aspx?id=" + idProveedor.Value)
    End Sub

End Class