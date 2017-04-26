Public Class BusquedaPedido
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.listadoPedido)

        If isClienteLogueado() Then
            Dim clie As Cliente = CType(getLoggedUser(), Cliente)
            clientes.Items.Clear()
            clientes.Items.Add(New ListItem(clie.idCliente, clie.idCliente))
            panelCliente.Visible = False
        End If
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        If Not isClienteLogueado() Then
            Me.clientes.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        End If

        Me.estado.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
    End Sub

    Protected Sub listaPedidos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaPedidos.SelectedIndexChanged
        Dim id As String = listaPedidos.Rows(listaPedidos.SelectedIndex).Cells(1).Text

        Response.Redirect("~\DetallePedido.aspx?id=" + id)
    End Sub

End Class