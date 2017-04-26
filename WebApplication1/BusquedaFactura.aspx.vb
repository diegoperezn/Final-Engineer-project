Public Class BusquedaFactura
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.listadoFactura)

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

    Protected Sub listaFacturas_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaFacturas.SelectedIndexChanged
        Dim nroFactura As String = listaFacturas.Rows(listaFacturas.SelectedIndex).Cells(2).Text
        Dim nroSucursal As String = listaFacturas.Rows(listaFacturas.SelectedIndex).Cells(3).Text
        Dim tipoFactura As String = listaFacturas.Rows(listaFacturas.SelectedIndex).Cells(4).Text

        Response.Redirect("~\DetalleFactura.aspx?nroFactura=" + nroFactura + _
                                                "&nroSucursal=" + nroSucursal + _
                                                "&tipoFactura=" + tipoFactura)
    End Sub

End Class