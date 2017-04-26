Public Class BusquedaArticulo
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.listadoArticulo)
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        Me.diseño.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        Me.tipoPrenda.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
    End Sub

    Protected Sub listaArticulos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaArticulos.SelectedIndexChanged
        Dim id As String = listaArticulos.Rows(listaArticulos.SelectedIndex).Cells(1).Text

        Response.Redirect("~\DetalleArticulo.aspx?id=" + id)
    End Sub

    Protected Sub listaArticulos_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles listaArticulos.RowEditing
        Dim id As String = listaArticulos.Rows(e.NewEditIndex).Cells(1).Text

        Response.Redirect("~\AltaModificacionArticulo.aspx?id=" + id)
    End Sub


End Class