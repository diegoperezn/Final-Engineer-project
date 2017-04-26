Public Class BusquedaConversacion
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.mensajes)

    End Sub

    Protected Sub listaConversaciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaConversaciones.SelectedIndexChanged
        Dim id As String = listaConversaciones.Rows(listaConversaciones.SelectedIndex).Cells(1).Text

        Response.Redirect("~\AltaModificacionConversacion.aspx?id=" + id)
    End Sub

End Class