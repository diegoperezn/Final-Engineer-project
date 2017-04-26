Public Class BusquedaProduccion
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.listadoProduccion)
    End Sub


    Protected Sub listaProduccion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaProduccion.SelectedIndexChanged
        Dim id As String = listaProduccion.Rows(listaProduccion.SelectedIndex).Cells(1).Text

        Response.Redirect("~\DetalleProduccion.aspx?id=" + id)
    End Sub

End Class