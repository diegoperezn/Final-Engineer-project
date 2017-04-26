Public Class AltaModificacionPedido
    Inherits BasePage

    Dim produccionBusiness As ProduccionBusiness = BusinessFactory.produccionBusiness
    Dim articuloBusiness As ArticuloBusiness = BusinessFactory.articuloBusiness
    Dim pedidoBusiness As PedidoBusiness = BusinessFactory.pedidoBusiness
    Dim diseñoBusiness As DiseñoBusiness = BusinessFactory.diseñoBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.creacionPedido)
        Me.UpdatePanel2.UpdateMode = UpdatePanelUpdateMode.Conditional

        If isClienteLogueado() Then
            Dim clie As Cliente = CType(getLoggedUser(), Cliente)
            clientes.Items.Clear()
            clientes.Items.Add(New ListItem(clie.idCliente, clie.idCliente))
            clientePanel.Visible = False
            cargarArticulos()
        End If

        If Not IsPostBack Then
            Session.Add("listaFechas", New List(Of Produccion))
            Session.Add("listaProduccion", New List(Of Produccion))
        End If
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        If Not isClienteLogueado() Then
            Me.clientes.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        End If

        Me.articulos.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
    End Sub


    Protected Sub buscarFechas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cargarInsumo.Click
        Dim articulo As Articulo = Me.articuloBusiness.buscarArticulosPorCodigo(articulos.SelectedValue)

        If articulo IsNot Nothing Then
            Dim produccion As New Produccion(articulo, cantidad.Text)

            Dim fecha As DateTime

            If Calendar1.SelectedDate.Year = 1 Then
                fecha = DateTime.Now
            Else
                fecha = Calendar1.SelectedDate
            End If

            Dim posibleProduccion As List(Of Produccion) = Me.produccionBusiness.calcularPosiblesFechas(produccion, fecha)

            Session.Add("listaFechas", posibleProduccion)

            Dim listaFechas As List(Of Produccion) = Session("listaFechas")
            listaPosiblesFechas.DataSource = posibleProduccion
        End If

        listaPosiblesFechas.DataBind()
    End Sub

    Protected Sub listaPosiblesFechas_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaPosiblesFechas.SelectedIndexChanged
        Dim listaFechas As List(Of Produccion) = Session("listaFechas")
        Dim fechaSelecionada As Produccion = listaFechas(listaPosiblesFechas.SelectedIndex)

        Dim lista As List(Of Produccion) = Session("listaProduccion")

        lista.Add(fechaSelecionada)

        fechaSelecionada.estadoActual = New EstadoTrabajos(4)
        Me.produccionBusiness.grabarProduccion(fechaSelecionada)

        fechaSelecionada.estadoActual = New EstadoTrabajos(1)
        Session.Add("listaFechas", New List(Of Produccion))
        Session.Add("listaProduccion", lista)

        listaPosiblesFechas.DataSource = Nothing
        listaPosiblesFechas.DataBind()

        listaProduccion.DataSource = lista
        listaProduccion.DataBind()

        cantidad.Text = ""
    End Sub

    Protected Sub borrarProduccion(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles listaProduccion.RowDeleting
        Dim lista As List(Of Produccion) = Session("listaProduccion")

        lista.Remove(lista(e.RowIndex))

        Session.Add("listaProduccion", lista)

        listaProduccion.DataSource = lista
        listaProduccion.DataBind()
    End Sub

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim lista As List(Of Produccion) = Session("listaProduccion")

        For Each elem As Produccion In lista
            Me.produccionBusiness.borrarProduccion(elem)
        Next

        Dim tipo As New TipoPedido(2)
        Dim estado As New EstadoPedido(2)
        If Not Calendar1.SelectedDate.Year = 1 Then
            tipo.tipoPedido = 1
            estado.estadoPedido = 1
        End If

        Dim pedido As New Pedido(Nothing, comentario.Text, New List(Of HistoricoEstados), tipo, Session("listaProduccion"), New Cliente(clientes.SelectedValue),
                                    estado, Nothing, Nothing)

        Me.pedidoBusiness.GuardarPedido(pedido)

        Response.Redirect("~/BusquedaPedido.aspx")
    End Sub

    Protected Sub cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelar.Click
        Dim lista As List(Of Produccion) = Session("listaProduccion")

        For Each elem As Produccion In lista
            Me.produccionBusiness.borrarProduccion(elem)
        Next
    End Sub

    Protected Sub clientes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clientes.SelectedIndexChanged
        cargarArticulos()
    End Sub

    Private Sub cargarArticulos()
        Dim articulos As New List(Of Articulo)

        If Not clientes.SelectedValue = "" Then
            Dim diseños As List(Of Diseño) = Me.diseñoBusiness.buscarDiseñoPorCliente(New Cliente(clientes.SelectedValue))

            For Each diseño As Diseño In diseños
                articulos.AddRange(Me.articuloBusiness.listarArticulosPorDiseño(diseño))
            Next

            For Each art As Articulo In articulos
                Dim value As String = art.codArticulo
                Dim texto As String = art.diseño.nombre + " - " + art.tipoPrenda.descripcion

                Me.articulos.Items.Add(New ListItem(texto, value))
            Next

            Me.UpdatePanel2.Update()

        End If
    End Sub


End Class