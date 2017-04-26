Public Class BusquedaFamilia
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.ListadoFamilias)
    End Sub

    Protected Sub listaFamilias_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaFamilias.SelectedIndexChanged
        Dim id As String = listaFamilias.Rows(listaFamilias.SelectedIndex).Cells(1).Text

        Response.Redirect("~\DetalleFamilia.aspx?id=" + id)
    End Sub

    Protected Sub listaFamilias_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles listaFamilias.RowEditing
        Dim id As String = listaFamilias.Rows(e.NewEditIndex).Cells(1).Text
        Response.Redirect("~\AltaModificacionFamilia.aspx?id=" + id)
    End Sub

End Class