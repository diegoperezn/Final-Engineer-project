Public Class AltaModificacionArticulo
    Inherits BasePage

    Dim business As ArticuloBusiness = BusinessFactory.articuloBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.creacionArticulo)

        If Not IsPostBack Then
            If Request.Params("id") IsNot Nothing Then
                cargarArticulo(Long.Parse(Request.Params("id")))
                verificarPermisosYRedirecccionar(Permisos.edicionDiseños)
                grabar.Visible = False
                labelTituloCreacion.Visible = False
            Else
                verificarPermisosYRedirecccionar(Permisos.creacionDiseños)
                idArticulo.Value = Nothing
                editar.Visible = False
                labelTituloEdicion.Visible = False
                Session.Add("listaPrecio", New List(Of ListaPrecios))
            End If
        End If
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        If idArticulo.Value Is Nothing Then
            Me.diseño.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
            Me.tipoPrenda.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        End If
    End Sub

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim articulo As New Articulo(Nothing, comentario.Text, precio.Text,
                                     produccion.Text, New TipoPrenda(tipoPrenda.SelectedValue),
                                     New Diseño(diseño.SelectedValue), Nothing)

        Me.business.guardarArticulo(articulo)

        Response.Redirect("~/BusquedaArticulo.aspx")
    End Sub

    Private Sub cargarArticulo(ByVal id As Long)
        Dim articulo As Articulo = Me.business.buscarArticulosPorCodigo(id)

        idArticulo.Value = id

        With articulo
            diseño.SelectedValue = .diseño.idDiseño
            tipoPrenda.SelectedValue = .tipoPrenda.tipoPrenda
            produccion.Text = .produccion
            comentario.Text = .comentario
            precio.Text = .precioActual

            Session.Add("listaPrecio", .listaPrecios)
        End With

    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Dim articulo As New Articulo(idArticulo.Value, comentario.Text, precio.Text,
                                     produccion.Text, New TipoPrenda(tipoPrenda.SelectedValue),
                                     New Diseño(diseño.SelectedValue), Session.Item("listaPrecio"))

        Me.business.actualizaArticulo(articulo)

        Response.Redirect("~/BusquedaArticulo.aspx")
    End Sub
End Class