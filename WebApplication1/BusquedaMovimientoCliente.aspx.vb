Public Class BusquedaCuentaCorriente
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.listadoMovimientoCliente)

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

        Me.cuenta.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        Me.tipoMovimiento.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
    End Sub

    Protected Sub listaMovimientos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaMovimientos.SelectedIndexChanged
        Dim id As String = listaMovimientos.Rows(listaMovimientos.SelectedIndex).Cells(1).Text
        Response.Redirect("~\DetalleMovimientoCliente.aspx?id=" + id)
    End Sub


End Class