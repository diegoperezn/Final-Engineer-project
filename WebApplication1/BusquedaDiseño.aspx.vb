Public Class BusquedaDiseñosUI
    Inherits BasePage

    Dim diseñoBusiness As DiseñoBusiness = BusinessFactory.diseñoBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        verificarPermisosYRedirecccionar(Permisos.listadoDiseños)

        If isClienteLogueado() Then
            Dim clie As Cliente = CType(getLoggedUser(), Cliente)
            cliente.Items.Clear()
            cliente.Items.Add(New ListItem(clie.idCliente, clie.idCliente))
            clientePanel.Visible = False
        End If
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        If Not isClienteLogueado() Then
            Me.cliente.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        End If
    End Sub

    Protected Sub listaDiseños_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaDiseños.SelectedIndexChanged
        Dim id As String = listaDiseños.Rows(listaDiseños.SelectedIndex).Cells(1).Text

        Response.Redirect("~\DetalleDiseño.aspx?id=" + id)
    End Sub

    Protected Sub listaDiseños_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles listaDiseños.RowEditing
        Dim id As String = listaDiseños.Rows(e.NewEditIndex).Cells(1).Text

        Response.Redirect("~\AltaModificacionDiseño.aspx?id=" + id)
    End Sub

End Class