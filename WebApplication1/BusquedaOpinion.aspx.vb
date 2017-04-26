Public Class BusquedaOpinion
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.listado_opinion)
    End Sub

    Protected Sub listadoOpiniones_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listadoOpiniones.SelectedIndexChanged
        Dim id As String = listadoOpiniones.Rows(listadoOpiniones.SelectedIndex).Cells(1).Text
        Response.Redirect("~\DetalleOpinion.aspx?id=" + id)
    End Sub

End Class