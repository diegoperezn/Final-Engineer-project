Public Class DetallePedido
    Inherits BasePage

    Dim pedidoBusiness As PedidoBusiness = BusinessFactory.pedidoBusiness
    Dim materialesBusiness As MaterialesBusiness = BusinessFactory.materialesBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detallePedido)

        If Request.Params("id") IsNot Nothing Then
            cargarPedido(Long.Parse(Request.Params("id")))
        End If
    End Sub

    Private Sub cargarPedido(ByVal id As Long)
        Dim pedido As Pedido = Me.pedidoBusiness.buscarPedidoPorCodigo(id)

        With pedido
            cliente.Text = .cliente.nombre
            comentario.Text = .comentario
            fechaFinal.Text = .fechaFinal
            fechaInicio.Text = .fechaInicio

            For Each trabajo As Produccion In .trabajos
                trabajo.maquina = Me.materialesBusiness.cargarMaquinaPorId(trabajo.maquina.codMaquina)
            Next

            listaProduccion.DataSource = .trabajos
            listaProduccion.DataBind()
        End With

    End Sub


    Protected Sub listaProduccion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaProduccion.SelectedIndexChanged
        Dim id As String = listaProduccion.Rows(listaProduccion.SelectedIndex).Cells(1).Text

        Response.Redirect("~\DetalleProduccion.aspx?id=" + id)
    End Sub

End Class