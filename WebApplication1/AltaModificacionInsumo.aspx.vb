Public Class AltaModificacionInsumo
    Inherits BasePage

    Dim insumoBusiness As InsumoBusiness = BusinessFactory.insumoBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()

        If Not IsPostBack Then
            If Request.Params("id") IsNot Nothing Then
                cargarInsumo(Long.Parse(Request.Params("id")))
                verificarPermisosYRedirecccionar(Permisos.edicionInsumo)
                grabar.Visible = False
                tituloCreacion.Visible = False
            Else
                verificarPermisosYRedirecccionar(Permisos.creacionInsumo)
                idInsumo.Value = Nothing
                editar.Visible = False
                tituloEdicion.Visible = False
            End If
        End If
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        If idInsumo.Value Is Nothing Then
            Me.color.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
            Me.tipo.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        End If
    End Sub

    Private Sub cargarInsumo(ByVal id As Long)
        Dim insumo As Insumo = Me.insumoBusiness.listarInsumosPorCodigo(id)

        idInsumo.Value = id

        With insumo
            nombre.Text = .nombre
            descripcion.Text = .detalle
            tipo.SelectedValue = .tipoInsumo.tipo
            color.SelectedValue = .color.codColor
            cantidad.Text = .cantidadActual
            costo.Text = .costo
        End With
    End Sub

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim insumo As New Insumo(Nothing, nombre.Text, descripcion.Text, cantidad.Text,
                                  New TipoInsumo(tipo.SelectedValue), New Color(color.SelectedValue), New List(Of MovimientosStock), costo.Text)

        Me.insumoBusiness.grabarInsumo(insumo)

        Response.Redirect("~/BusquedaInsumo.aspx")
    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Dim insumo As New Insumo(idInsumo.Value, nombre.Text, descripcion.Text, cantidad.Text,
                          New TipoInsumo(tipo.SelectedValue), New Color(color.SelectedValue), New List(Of MovimientosStock), costo.Text)

        Me.insumoBusiness.actualizarInsumo(insumo)

        Response.Redirect("~/BusquedaInsumo.aspx")
    End Sub
End Class