Public Class AltaDiseñoUI
    Inherits BasePage

    Dim business As DiseñoBusiness = BusinessFactory.diseñoBusiness
    Dim insumosBusiness As InsumoBusiness = BusinessFactory.insumoBusiness
    Dim usuarioBusiness As UsuarioBusiness = BusinessFactory.usuarioBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.creacionDiseños)

        If isClienteLogueado() Then
            Dim clie As Cliente = CType(getLoggedUser(), Cliente)
            clientes.Items.Clear()
            clientes.Items.Add(New ListItem(clie.idCliente, clie.idCliente))
            clientePanel.Visible = False
        End If

        If Not IsPostBack Then
            If Request.Params("id") IsNot Nothing Then
                cargarDiseño(Long.Parse(Request.Params("id")))
                verificarPermisosYRedirecccionar(Permisos.edicionDiseños)
                grabar.Visible = False
                labelTituloCreacion.Visible = False
            Else
                verificarPermisosYRedirecccionar(Permisos.creacionDiseños)
                idDiseño.Value = Nothing
                editar.Visible = False
                labelTituloEdicion.Visible = False
                Session.Add("insumos", New List(Of DiseñoInsumo))
            End If
        End If
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        If Not isClienteLogueado() Then
            Me.clientes.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        End If
    End Sub

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim cliente As Cliente
        If isClienteLogueado() Then
            cliente = getLoggedUser()
        Else
            cliente = Me.usuarioBusiness.CargarClientePorId(Me.clientes.SelectedValue)
        End If

        Dim diseño As Diseño = Me.business.GrabarDiseño(Nothing, altura.Text, ancho.Text, nombre.Text, puntadas.Text, cliente,
                                 Nothing, Nothing, Nothing, Nothing, Session.Item("insumos"))

        diseño.pathImagen = grabarArchivo(imagen, getLoggedUser.nombre, diseño.idDiseño, "imagen")
        diseño.pathArchivoFinal = grabarArchivo(matrizFinal, getLoggedUser.nombre, diseño.idDiseño, "matriz final")
        diseño.pathArchivoEditable = grabarArchivo(matrizEditable, getLoggedUser.nombre, diseño.idDiseño, "matriz editable")
        diseño.pathDetalle = grabarArchivo(ficha, getLoggedUser.nombre, diseño.idDiseño, "ficha")

        Me.business.actualizarDiseño(diseño)

        Response.Redirect("~/busquedaDiseño.aspx")
    End Sub


    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Dim diseñoBase As Diseño = Me.business.buscarDiseñoPorId(idDiseño.Value)

        Dim diseño As New Diseño(idDiseño.Value, altura.Text, ancho.Text, nombre.Text, puntadas.Text, diseñoBase.cliente,
                                 Nothing, Nothing, Nothing, Nothing, Session.Item("insumos"))

        Dim pathImagen As String = grabarArchivo(imagen, getLoggedUser.nombre, diseño.idDiseño, "imagen")
        Dim pathArchivo As String = grabarArchivo(matrizFinal, getLoggedUser.nombre, diseño.idDiseño, "matriz final")
        Dim PathEditable As String = grabarArchivo(matrizEditable, getLoggedUser.nombre, diseño.idDiseño, "matriz editable")
        Dim PathFicha As String = grabarArchivo(ficha, getLoggedUser.nombre, diseño.idDiseño, "ficha")

        If pathImagen IsNot Nothing Then
            diseño.pathImagen = pathImagen
        Else
            diseño.pathImagen = diseñoBase.pathImagen
        End If
        If pathArchivo IsNot Nothing Then
            diseño.pathArchivoFinal = pathArchivo
        Else
            diseño.pathArchivoFinal = diseñoBase.pathArchivoFinal
        End If
        If PathEditable IsNot Nothing Then
            diseño.pathArchivoEditable = PathEditable
        Else
            diseño.pathArchivoEditable = diseñoBase.pathArchivoEditable
        End If
        If PathFicha IsNot Nothing Then
            diseño.pathDetalle = PathFicha
        Else
            diseño.pathDetalle = diseñoBase.pathDetalle
        End If


        Me.business.actualizarDiseño(diseño)

        Response.Redirect("~/busquedaDiseño.aspx")
    End Sub

    Protected Sub cargarInsumo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cargarInsumo.Click
        Dim listaInsumosdiseños As List(Of DiseñoInsumo) = Session.Item("insumos")
        Dim insumo As Insumo = Me.insumosBusiness.listarInsumosPorCodigo(insumos.SelectedValue)

        Dim DiseñoInsumo As New DiseñoInsumo(Nothing, insumo, cantidadInsumo.Text)
        listaInsumosdiseños.Add(DiseñoInsumo)

        Session.Add("insumos", listaInsumosdiseños)

        listaInsumo.DataSource = listaInsumosdiseños
        listaInsumo.DataBind()
    End Sub

    Protected Sub borrarInsumo(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles listaInsumo.RowDeleting
        Dim listaInsumosdiseños As List(Of DiseñoInsumo) = Session.Item("insumos")

        listaInsumosdiseños.Remove(listaInsumosdiseños(e.RowIndex))

        Session.Add("insumos", listaInsumosdiseños)

        listaInsumo.DataSource = listaInsumosdiseños
        listaInsumo.DataBind()
    End Sub

    Private Function grabarArchivo(ByVal fileUpload As FileUpload, ByVal cliente As String,
                                   ByVal diseño As String, ByVal tipo As String) As String
        If Not fileUpload.HasFile Then
            Return Nothing
        End If

        Dim basePath As String = Server.MapPath("~/images/clientes/")
        Dim nombre As String = cliente + " - " + diseño + " - " + tipo
        Dim extension As String = "." + fileUpload.FileName.Split(".")(1)

        Dim path As String = nombre + extension

        fileUpload.SaveAs(basePath + path)

        Return path
    End Function

    Private Sub cargarDiseño(ByVal id As Long)
        Dim diseño As Diseño = Me.business.buscarDiseñoPorId(id)

        idDiseño.Value = id

        With diseño
            nombre.Text = .nombre
            altura.Text = .alto
            ancho.Text = .ancho
            puntadas.Text = .puntadas

            imagenCargada.Visible = Not String.IsNullOrEmpty(.pathImagen)
            matrizCargada.Visible = Not String.IsNullOrEmpty(.pathArchivoFinal)
            editableCargada.Visible = Not String.IsNullOrEmpty(.pathArchivoEditable)
            fichaCargada.Visible = Not String.IsNullOrEmpty(.pathDetalle)

            For Each Insumo As DiseñoInsumo In .insumos
                Insumo.insumo = Me.insumosBusiness.listarInsumosPorCodigo(Insumo.insumo.codInsumo)
            Next

            listaInsumo.DataSource = .insumos
            listaInsumo.DataBind()

            Session.Add("insumos", .insumos)


            clientes.Items.Clear()
            clientes.Items.Add(New ListItem(.cliente.idCliente, .cliente.idCliente))
            clientePanel.Visible = False
        End With

    End Sub

End Class