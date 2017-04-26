Public Class BusquedaUsuario
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.Listado_usuarios)
    End Sub

    Protected Sub listadoUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listadoUsuarios.SelectedIndexChanged
        Dim id As String = listadoUsuarios.Rows(listadoUsuarios.SelectedIndex).Cells(1).Text
        Response.Redirect("~\DetalleUsuario.aspx?id=" + id)
    End Sub

    Protected Sub listadoUsuarios_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles listadoUsuarios.RowEditing
        Dim id As String = listadoUsuarios.Rows(e.NewEditIndex).Cells(1).Text
        Response.Redirect("~\AltaModificacionUsuario.aspx?id=" + id)
    End Sub

End Class