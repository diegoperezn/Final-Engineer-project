Public Class BusquedaInsumo
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermiso(Permisos.listadoInsumo)
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        Me.tipo.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        Me.color.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
    End Sub

    Protected Sub listaInsumos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaInsumos.SelectedIndexChanged
        Dim id As String = listaInsumos.Rows(listaInsumos.SelectedIndex).Cells(1).Text

        Response.Redirect("~\DetalleInsumo.aspx?id=" + id)
    End Sub

    Protected Sub listaInsumos_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles listaInsumos.RowEditing
        Dim id As String = listaInsumos.Rows(e.NewEditIndex).Cells(1).Text
        Response.Redirect("~\AltaModificacionInsumo.aspx?id=" + id)
    End Sub

End Class