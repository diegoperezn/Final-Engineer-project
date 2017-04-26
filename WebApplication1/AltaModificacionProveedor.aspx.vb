Public Class AltaModificacionProveedor
    Inherits BasePage

    Dim proveedorBusiness As ProveedorBusiness = BusinessFactory.proveedorBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()

        If Not IsPostBack Then
            If Request.Params("id") IsNot Nothing Then
                MyBase.verificarPermisosYRedirecccionar(Permisos.Edicion_usuarios)
                Me.cargarProveedor(Request.Params("id"))
                grabar.Visible = False
                tituloCreacion.Visible = False
            Else
                MyBase.verificarPermisosYRedirecccionar(Permisos.Creacion_usuarios)
                editar.Visible = False
                tituloEdicion.Visible = False
            End If
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

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim proveedor As Proveedor = New Proveedor(Nothing, nombre.Text, telefono.Text, direccion.Text, Nothing)

        Me.proveedorBusiness.grabar(proveedor)

        Response.Redirect("~/BusquedaProveedor.aspx")
    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Dim proveedor As Proveedor = New Proveedor(idProveedor.Value, nombre.Text, telefono.Text, direccion.Text, Nothing)

        Me.proveedorBusiness.actualizar(proveedor)

        Response.Redirect("~/BusquedaProveedor.aspx")
    End Sub

End Class