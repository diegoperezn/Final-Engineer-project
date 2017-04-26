Public Class BusquedaNewsLetter
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.listado_newletter)
    End Sub

    Protected Sub listaNewsletter_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaNewsletter.SelectedIndexChanged
        Dim id As String = listaNewsletter.Rows(listaNewsletter.SelectedIndex).Cells(1).Text
        Response.Redirect("~\DetalleNewsletter.aspx?id=" + id)
    End Sub

    Protected Sub listaNewsletter_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles listaNewsletter.RowEditing
        Dim id As String = listaNewsletter.Rows(e.NewEditIndex).Cells(1).Text

        Response.Redirect("~\AltaModificacionNewsletter.aspx?id=" + id)
    End Sub

End Class