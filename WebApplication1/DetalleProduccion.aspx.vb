Public Class DetalleProduccion
    Inherits BasePage

    Dim produccionBusiness As ProduccionBusiness = BusinessFactory.produccionBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detalleProduccion)

        If Request.Params("id") IsNot Nothing Then
            cargarProduccion(Long.Parse(Request.Params("id")))
        End If
    End Sub

    Private Sub cargarProduccion(ByVal id As Long)
        Dim prod As Produccion = Me.produccionBusiness.listarProduccionPorCodigo(id)

        idProduccion.Value = id

        With prod
            codPedido.Text = .codProduccion
            diseño.Text = .articulo.diseño.nombre
            prenda.Text = .articulo.tipoPrenda.descripcion
            cantidad.Text = .cantidad
            comentario.Text = .comentario
            estado.Text = .estadoActual.descripcion
            fechaFinal.Text = .fechaFinal.ToString("g")
            fechaInicio.Text = .fechaInicio.ToString("g")
            utilizacion.Text = .utilizacion

            If .estadoActual.estado = 1 Then
                cambiarEstado.Text = GetGlobalResourceObject("labelsProduccion", "RegistrarComienzoTrabajo").ToString
            ElseIf .estadoActual.estado = 2 Then
                cambiarEstado.Text = GetGlobalResourceObject("labelsProduccion", "RegistrarFinalizacionTrabajo").ToString
            End If
        End With



    End Sub

    Protected Sub cambiarEstado_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cambiarEstado.Click
        Dim prod As Produccion = Me.produccionBusiness.listarProduccionPorCodigo(idProduccion.Value)

        If prod.estadoActual.estado = 1 Then
            Me.produccionBusiness.registrarComienzoTrabajo(prod)
        ElseIf prod.estadoActual.estado = 2 Then
            Me.produccionBusiness.registrarFinalizacionTrabajo(prod)
        End If

        cargarProduccion(idProduccion.Value)
    End Sub
End Class