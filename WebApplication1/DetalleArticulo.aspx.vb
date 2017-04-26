Public Class DetalleArticulo
    Inherits BasePage

    Dim business As ArticuloBusiness = BusinessFactory.articuloBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detalleArticulo)

        If Request.Params("id") IsNot Nothing Then
            cargarArticulo(Long.Parse(Request.Params("id")))
        End If
    End Sub

    Private Sub cargarArticulo(ByVal id As Long)
        Dim articulo As Articulo = Me.business.buscarArticulosPorCodigo(id)

        idArticulo.Value = id

        With articulo
            diseño.Text = .diseño.nombre
            tipoPrenda.Text = .tipoPrenda.descripcion
            produccion.Text = .produccion
            comentario.Text = .comentario
            precio.Text = .precioActual

            listaPrecios.DataSource = .listaPrecios
            listaPrecios.DataBind()
        End With

    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Response.Redirect("~\AltaModificacionArticulo.aspx?id=" + idArticulo.Value)
    End Sub
End Class