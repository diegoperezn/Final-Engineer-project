Public Class DetalleMaquina
    Inherits BasePage

    Dim materialBusiness As MaterialesBusiness = BusinessFactory.materialesBusiness
    Dim tipoPrendaBusiness As TipoPrendaBusiness = BusinessFactory.tipoPrendaBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.detalle_maquinas)

        If Request.Params("id") IsNot Nothing Then
            cargarMaquina(Long.Parse(Request.Params("id")))
        End If
    End Sub

    Private Sub cargarMaquina(ByVal id As Long)
        Dim maquina As Maquina = Me.materialBusiness.cargarMaquinaPorId(id)

        idMaquina.Value = id

        With maquina
            nombre.Text = .nombre
            velProm.Text = .velocidadPromedio
            colores.Text = .cantidadColores
            cabezales.Text = .cabezales
            altoCampo.Text = .altoMargen
            anchoCampo.Text = .anchoMargen

            For Each prenda As TipoPrenda In .tiposPrenda
                tiposPrendasSeleccionadas.Items.Add(New ListItem(prenda.descripcion, prenda.tipoPrenda))
            Next
        End With
    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Response.Redirect("~\AltaModificacionMaquina.aspx?id=" + idMaquina.Value)
    End Sub
End Class