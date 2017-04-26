Imports Negocio
Imports Dominio
Imports System.Threading
Imports System.Globalization

Public Class _Default
    Inherits BasePage

    Dim usuarioBusiness As UsuarioBusiness = BusinessFactory.usuarioBusiness
    Dim articuloBusiness As ArticuloBusiness = BusinessFactory.articuloBusiness
    Dim produccionBusiness As ProduccionBusiness = BusinessFactory.produccionBusiness
    Dim pedidoBusiness As PedidoBusiness = BusinessFactory.pedidoBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        cargarTextos()

        Dim usr As Usuario = Session.Item("usuario")
        If usr IsNot Nothing Then
            If usr.GetType = GetType(Cliente) Then
                Dim cliente As Cliente = CType(usr, Cliente)
                completarArticulosFrecuentes(cliente)
                If cliente.newsletter Then
                    newsletterText.Text = GetGlobalResourceObject("home", "bajaNewsletter").ToString
                Else
                    newsletterText.Text = GetGlobalResourceObject("home", "altaNewsletter").ToString
                End If
                newsletter.Visible = True
            Else
                contenedorArtFrecuentes.Visible = False
                newsletter.Visible = False
            End If
        Else
            contenedorArtFrecuentes.Visible = False
            newsletter.Visible = False
        End If
    End Sub

    Protected Sub newsletterTittle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newsletterTittle.Click
        actualizarSubsNewsletter()
    End Sub

    Protected Sub newsletterText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newsletterText.Click
        actualizarSubsNewsletter()
    End Sub

    Private Sub actualizarSubsNewsletter()
        Dim usr As Usuario = Session.Item("usuario")
        If usr.GetType = GetType(Cliente) Then
            Dim cliente As Cliente = CType(usr, Cliente)
            If cliente.newsletter Then
                Response.Redirect("~/EncuestaUI.aspx")
            Else
                cliente.newsletter = Not cliente.newsletter
                usuarioBusiness.actualizarCliente(usr)

                If cliente.newsletter Then
                    newsletterText.Text = GetGlobalResourceObject("home", "bajaNewsletter").ToString
                Else
                    newsletterText.Text = GetGlobalResourceObject("home", "altaNewsletter").ToString
                End If
            End If


        End If
    End Sub

    Private Sub cargarTextos()
        sobreUniprof.Text = GetGlobalResourceObject("home", "sobreUniprof").ToString

        sobre1.Text = GetGlobalResourceObject("home", "sobre1").ToString
        sobre2.Text = GetGlobalResourceObject("home", "sobre2").ToString
        sobre3.Text = GetGlobalResourceObject("home", "sobre3").ToString
        sobre4.Text = GetGlobalResourceObject("home", "sobre4").ToString
        sobre5.Text = GetGlobalResourceObject("home", "sobre5").ToString

        nosCaracterizamos.Text = GetGlobalResourceObject("home", "nosCaracterizamos").ToString

        caracteristica1.Text = GetGlobalResourceObject("home", "caracteristica1").ToString
        caracteristica2.Text = GetGlobalResourceObject("home", "caracteristica2").ToString
        caracteristica3.Text = GetGlobalResourceObject("home", "caracteristica3").ToString
        caracteristica4.Text = GetGlobalResourceObject("home", "caracteristica4").ToString
        caracteristica5.Text = GetGlobalResourceObject("home", "caracteristica5").ToString
        caracteristica6.Text = GetGlobalResourceObject("home", "caracteristica6").ToString
        caracteristica7.Text = GetGlobalResourceObject("home", "caracteristica7").ToString
        caracteristica8.Text = GetGlobalResourceObject("home", "caracteristica8").ToString
    End Sub

    Private Sub completarArticulosFrecuentes(ByVal cliente As Cliente)
        Dim articulos As List(Of Articulo) = Me.articuloBusiness.obtenerArticulosFrecuentes(cliente.idCliente)

        If articulos.Count = 0 Then
            contenedorArtFrecuentes.Visible = False
        Else
            nombreArt1.Text = articulos(0).ToString

            If articulos.Count > 1 Then
                nombreArt2.Text = articulos(1).ToString
                art2.Visible = True
            End If
            If articulos.Count > 2 Then
                art3.Visible = True
                nombreArt3.Text = articulos(2).ToString
            End If
        End If
    End Sub

    Protected Sub generarPedidoArt1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles generarPedidoArt1.Click
        generarPedidoFrecuente(1, cantidad1.Text)
    End Sub

    Protected Sub generarPedidoArt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles generarPedidoArt2.Click
        generarPedidoFrecuente(2, cantidad2.Text)
    End Sub

    Protected Sub generarPedidoArt3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles generarPedidoArt3.Click
        generarPedidoFrecuente(3, cantidad3.Text)
    End Sub

    Private Sub generarPedidoFrecuente(ByVal art As Integer, ByVal cantidad As Integer)
        Dim usr As Usuario = Session.Item("usuario")
        Dim cliente As Cliente = CType(usr, Cliente)

        Dim articulos As List(Of Articulo) = Me.articuloBusiness.obtenerArticulosFrecuentes(cliente.idCliente)
        Dim articulo As Articulo = articulos(art - 1)

        If articulo IsNot Nothing Then
            Dim produccion As New Produccion(articulo, cantidad)

            Dim posibleProduccion As List(Of Produccion) =
                Me.produccionBusiness.calcularPosiblesFechas(produccion, DateTime.Now)

            Dim tipo As New TipoPedido(2)
            Dim estado As New EstadoPedido(2)

            Dim listaProduccion As New List(Of Produccion)
            posibleProduccion(0).estadoActual = New EstadoTrabajos(1)
            listaProduccion.Add(posibleProduccion(0))

            Dim pedido As New Pedido(Nothing, "Pedido frecuente", New List(Of HistoricoEstados), tipo, listaProduccion, cliente,
                                        estado, Nothing, Nothing)

            Me.pedidoBusiness.GuardarPedido(pedido)

            Response.Redirect("~/BusquedaPedido.aspx")
        End If

    End Sub

End Class