Public Class AltaModificacionMaquina
    Inherits BasePage

    Dim materialBusiness As MaterialesBusiness = BusinessFactory.materialesBusiness
    Dim tipoPrendaBusiness As TipoPrendaBusiness = BusinessFactory.tipoPrendaBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.InitializeCulture()

        If Not IsPostBack Then
            If Request.Params("id") IsNot Nothing Then
                cargarMaquina(Long.Parse(Request.Params("id")))
                verificarPermisosYRedirecccionar(Permisos.Edicion_maquinas)
            Else
                verificarPermisosYRedirecccionar(Permisos.creacion_maquinas)
                idMaquina.Value = Nothing
                editar.Visible = False
                tituloEdicion.Visible = False
            End If
        End If
    End Sub

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim prendasSeleccionadas As New List(Of TipoPrenda)
        For Each item As ListItem In tiposPrendasSeleccionadas.Items
            prendasSeleccionadas.Add(New TipoPrenda(item.Value))
        Next

        Me.materialBusiness.crearNuevaMaquina(prendasSeleccionadas, CInt(velProm.Text), CInt(colores.Text),
                                              CInt(anchoCampo.Text), CInt(altoCampo.Text), nombre.Text, CInt(cabezales.Text))

        Response.Redirect("~\BusquedaMaquina.aspx")
    End Sub


    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Dim prendasSeleccionadas As New List(Of TipoPrenda)
        For Each item As ListItem In tiposPrendasSeleccionadas.Items
            prendasSeleccionadas.Add(New TipoPrenda(item.Value))
        Next

        Dim maquina As New Maquina(idMaquina.Value)
        Me.materialBusiness.modificarMaquina(maquina, prendasSeleccionadas, CInt(velProm.Text), CInt(colores.Text),
                                              CInt(anchoCampo.Text), CInt(altoCampo.Text), nombre.Text, CInt(cabezales.Text))


        Response.Redirect("~\BusquedaMaquina.aspx")
    End Sub

    Protected Sub agregarTipoPrenda_Click(ByVal sender As Object, ByVal e As EventArgs) Handles agregarTipoPrenda.Click
        Dim result As Integer() = tipoPrendas.GetSelectedIndices()
        Dim vec As New List(Of String)
        For i As Integer = 0 To result.Length - 1
            If Not tiposPrendasSeleccionadas.Items.Contains(tipoPrendas.Items(result(i))) Then
                tiposPrendasSeleccionadas.Items.Add(tipoPrendas.Items(result(i)))
            End If
        Next
    End Sub

    Protected Sub quitarTipoPrenda_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitarTipoPrenda.Click
        Dim result As Integer() = tiposPrendasSeleccionadas.GetSelectedIndices()
        For i As Integer = result.Length - 1 To 0 Step -1
            tiposPrendasSeleccionadas.Items.Remove(tiposPrendasSeleccionadas.Items(result(i)))
        Next
    End Sub

    Private Sub cargarMaquina(ByVal id As Long)
        grabar.Visible = False
        tituloCreacion.Visible = False

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

End Class