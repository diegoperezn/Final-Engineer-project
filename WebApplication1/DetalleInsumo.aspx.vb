Public Class DetalleInsumo
    Inherits BasePage

    Dim insumoBusiness As InsumoBusiness = BusinessFactory.insumoBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detalleInsumo)

        If Request.Params("id") IsNot Nothing Then
            cargarInsumo(Long.Parse(Request.Params("id")))
        End If
    End Sub

    Private Sub cargarInsumo(ByVal id As Long)
        Dim insumo As Insumo = Me.insumoBusiness.listarInsumosPorCodigo(id)

        With insumo
            nombre.Text = .nombre
            tipo.Text = .tipoInsumo.descripcion
            cantidad.Text = .cantidadActual
            costo.Text = .costo

            listaMovimientos.DataSource = .movimientosStock
            listaMovimientos.DataBind()
        End With

    End Sub



End Class