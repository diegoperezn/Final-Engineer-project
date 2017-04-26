Imports System.Threading
Imports Dominio
Imports Negocio
Imports System.Globalization

Public Class Site
    Inherits System.Web.UI.MasterPage

    Dim verificarPermisos As Boolean = True

    Private usuarioBusiness As UsuarioBusiness = BusinessFactory.usuarioBusiness
    Private opinionBusiness As OpinionBusiness = BusinessFactory.opinionBusiness
    Private permisosBusiness As New PermisosBusiness
    Private conversacionBusiness As ConversacionBusiness = BusinessFactory.conversacionBusiness


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usr As Dominio.Usuario = getLoggedUser()
        InitializeCulture()

        Dim botonHome As New MenuItem("home", "home", Nothing, "~/Default.aspx")
        Dim botonUsuario As New MenuItem(GetGlobalResourceObject("botones", "botonUsuario").ToString, "Usuario")
        Dim botonDiseños As New MenuItem(GetGlobalResourceObject("botones", "botonDiseños").ToString, "Diseños")
        Dim botonFacturas As New MenuItem(GetGlobalResourceObject("botones", "botonFinanzas").ToString, "Finanzas")
        Dim botonPedidos As New MenuItem(GetGlobalResourceObject("botones", "botonPedidos").ToString, "Pedidos")
        Dim botonMaquina As New MenuItem(GetGlobalResourceObject("botones", "botonMaquinas").ToString, "Maquinas")
        Dim botonProveedor As New MenuItem(GetGlobalResourceObject("botones", "botonProveedores").ToString, "Proveedores")
        Dim botonAdministracion As New MenuItem(GetGlobalResourceObject("botones", "botonAdministracion").ToString, "Administracion")

        Dim msjSinLeer As Integer = conversacionBusiness.contarMsjSinLeer(getLoggedUser)
        Dim botonMensajes As New MenuItem(GetGlobalResourceObject("botones", "botonMensajes").ToString + "(" + msjSinLeer.ToString + ")", "Mensajes")

        If usr IsNot Nothing Then
            Login.Visible = False
            LogOut.Visible = True
            mainMenu.Items.Clear()
            mainMenu.Items.Add(botonHome)

            If usr.GetType = GetType(Cliente) Then
                If verificarListaPermisos(Permisos.permisosDiseños) Then
                    mainMenu.Items.Add(botonDiseños)
                End If
                If verificarListaPermisos(Permisos.permisosFacturas) Then
                    mainMenu.Items.Add(botonFacturas)
                End If
                If verificarListaPermisos(Permisos.permisosPedidos) Then
                    mainMenu.Items.Add(botonPedidos)
                End If
                If verificarPermiso(Permisos.mensajes) Then
                    mainMenu.Items.Add(botonMensajes)
                End If
            Else
                If verificarListaPermisos(Permisos.permisosUsuario) Then
                    mainMenu.Items.Add(botonUsuario)
                End If
                If verificarListaPermisos(Permisos.permisosDiseños) Then
                    mainMenu.Items.Add(botonDiseños)
                End If
                If verificarListaPermisos(Permisos.permisosFacturas) Then
                    mainMenu.Items.Add(botonFacturas)
                End If
                If verificarListaPermisos(Permisos.permisosPedidos) Then
                    mainMenu.Items.Add(botonPedidos)
                End If
                If verificarListaPermisos(Permisos.permisosMaquina) Then
                    mainMenu.Items.Add(botonMaquina)
                End If
                If verificarListaPermisos(Permisos.permisosProveedor) Then
                    mainMenu.Items.Add(botonProveedor)
                End If
                If verificarListaPermisos(Permisos.permisosAdministracion) Then
                    mainMenu.Items.Add(botonAdministracion)
                End If
                If verificarPermiso(Permisos.mensajes) Then
                    mainMenu.Items.Add(botonMensajes)
                End If
            End If
        Else
            Login.Visible = True
            LogOut.Visible = False

            Login.UserNameLabelText = GetGlobalResourceObject("labels", "usuario").ToString
            Login.PasswordLabelText = GetGlobalResourceObject("labels", "contraseña").ToString
            Login.CreateUserText = GetGlobalResourceObject("labels", "registracion").ToString
            Login.LoginButtonText = GetGlobalResourceObject("labels", "ingresar").ToString
            Login.TitleText = GetGlobalResourceObject("labels", "loguerse").ToString

            mainMenu.Items.Clear()
            mainMenu.Items.Add(botonHome)
        End If

                cargarSubMenu()
    End Sub

    Protected Sub InitializeCulture()

        If Not Session("cultura") Is Nothing Then
            Dim cultura As String = Session("cultura").ToString

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultura)
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(cultura)
        End If

    End Sub

    Protected Sub Login_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login.Authenticate
        Dim usuario As Dominio.Usuario = usuarioBusiness.login(Login.UserName, Login.Password)
        If usuario IsNot Nothing Then
            Session.Add("usuario", usuario)
            'Session.Add("idUsuarioLogueado", usuario)
            Session.Add("isLoggedCliente", GetType(Cliente).Equals(usuario.GetType()))

            e.Authenticated = True

            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub LogOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LogOut.Click
        Session.Add("usuario", Nothing)
        Response.Redirect("~/Default.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabarOpinion.Click
        Dim op As New Opinion(Nothing, nombre.Text, mail.Text, opinion.Text)
        opinionBusiness.grabarOpinion(op)

        nombre.Text = ""
        mail.Text = ""
        opinion.Text = ""
    End Sub

    Protected Sub idiomaEspañol_Click(ByVal sender As Object, ByVal e As EventArgs) Handles idiomaEspañol.Click
        Session.Add("cultura", "es-AR")
        Server.Transfer(Request.Path)
    End Sub

    Protected Sub idiomaIngles_Click(ByVal sender As Object, ByVal e As EventArgs) Handles idiomaIngles.Click
        Session.Add("cultura", "en-US")
        Server.Transfer(Request.Path)
    End Sub

    Protected Function getLoggedUser() As Usuario
        Return Session.Item("usuario")
    End Function

    Protected Function isClienteLogueado()
        Return getLoggedUser() IsNot Nothing AndAlso GetType(Cliente).Equals(getLoggedUser.GetType())
    End Function

    Protected Function verificarPermiso(ByVal permiso As String) As Boolean
        Return permisosBusiness.verificarPermiso(permiso, getLoggedUser()) OrElse Not verificarPermisos
    End Function

    Protected Function verificarListaPermisos(ByVal permisos As List(Of String)) As Boolean
        Return permisosBusiness.verificarPermiso(permisos, getLoggedUser()) OrElse Not verificarPermisos
    End Function

    Protected Sub ClickMainMenu(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles mainMenu.MenuItemClick
        Session.Add("menuSeleccionado", e.Item.Value)
        e.Item.Selected = True
        cargarSubMenu()
    End Sub

    Private Sub cargarSubMenu()
        SubMenu.Items.Clear()

        If Session.Item("menuSeleccionado") IsNot Nothing Then
            Dim menu As String = Session.Item("menuSeleccionado")
            If menu = "Maquinas" Then
                cargarSubBotonesMaquina()
            ElseIf menu = "Usuario" Then
                cargarSubBotonesUsuario()
            ElseIf menu = "Administracion" Then
                cargarSubBotonesAdministracion()
            ElseIf menu = "Diseños" Then
                cargarSubBotonesDiseño()
            ElseIf menu = "Mensajes" Then
                cargarSubBotonesMensaje()
            ElseIf menu = "Finanzas" Then
                cargarSubBotonesFinanzas()
            ElseIf menu = "Proveedores" Then
                cargarSubBotonesProveedores()
            ElseIf menu = "Pedidos" Then
                cargarSubBotonesPedidos()
            End If
        End If
    End Sub


    Private Sub cargarSubBotonesAdministracion()
        If verificarPermiso(Permisos.listado_opinion) Then
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaOpinion").ToString, "BusquedaOpinion",
                                             Nothing, "~/BusquedaOpinion.aspx")
            SubMenu.Items.Add(botonBusqueda)
        End If
        If verificarPermiso(Permisos.detalleEstadisticas) Then
            Dim botonEstadisticasProd As New MenuItem(GetGlobalResourceObject("botones", "detalleEstadisticas").ToString, "BusquedaOpinion",
                                             Nothing, "~/DetalleEstadistica.aspx")
            SubMenu.Items.Add(botonEstadisticasProd)
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "DetalleEncuestas").ToString, "BusquedaOpinion",
                                 Nothing, "~/DetalleEncuestas.aspx")
            SubMenu.Items.Add(botonBusqueda)
        End If
        If verificarPermiso(Permisos.listado_newletter) Then
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaNewsletter").ToString, "busquedaNewsletter",
                                             Nothing, "~/BusquedaNewsletter.aspx")
            SubMenu.Items.Add(botonBusqueda)
        End If
    End Sub

    Private Sub cargarSubBotonesUsuario()
        If verificarPermiso(Permisos.Creacion_usuarios) Then
            Dim botonAltaMaquina As New MenuItem(GetGlobalResourceObject("botones", "creacionUsuario").ToString, "creacionMaquina",
                                             Nothing, "~/AltaModificacionUsuario.aspx")
            SubMenu.Items.Add(botonAltaMaquina)
        End If
        If verificarPermiso(Permisos.Listado_usuarios) Then
            Dim botonBusquedaMaquina As New MenuItem(GetGlobalResourceObject("botones", "busquedaUsuario").ToString, "busquedaMaquina",
                                             Nothing, "~/BusquedaUsuario.aspx")
            SubMenu.Items.Add(botonBusquedaMaquina)
        End If
        If verificarPermiso(Permisos.CreacionFamilias) Then
            Dim botonAltaFamilia As New MenuItem(GetGlobalResourceObject("botones", "creacionFamilia").ToString, "creacionFamilia",
                                             Nothing, "~/AltaModificacionFamilia.aspx")
            SubMenu.Items.Add(botonAltaFamilia)
        End If
        If verificarPermiso(Permisos.ListadoFamilias) Then
            Dim botonBusquedaFamilia As New MenuItem(GetGlobalResourceObject("botones", "busquedaFamilia").ToString, "busquedaFamilia",
                                             Nothing, "~/BusquedaFamilia.aspx")
            SubMenu.Items.Add(botonBusquedaFamilia)
        End If
    End Sub

    Private Sub cargarSubBotonesMaquina()
        If verificarPermiso(Permisos.creacion_maquinas) Then
            Dim botonAlta As New MenuItem(GetGlobalResourceObject("botones", "creacionMaquina").ToString, "creacionMaquina",
                                             Nothing, "~/AltaModificacionMaquina.aspx")
            SubMenu.Items.Add(botonAlta)
        End If
        If verificarPermiso(Permisos.listado_maquinas) Then
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaMaquina").ToString, "busquedaMaquina",
                                             Nothing, "~/BusquedaMaquina.aspx")
            SubMenu.Items.Add(botonBusqueda)
        End If
        If verificarPermiso(Permisos.listadoInsumo) Then
            Dim botonAlta As New MenuItem(GetGlobalResourceObject("botones", "buscarInsumo").ToString, "buscarInsumo",
                                             Nothing, "~/BusquedaInsumo.aspx")
            SubMenu.Items.Add(botonAlta)
        End If
        If verificarPermiso(Permisos.creacionInsumo) Then
            Dim botonAlta As New MenuItem(GetGlobalResourceObject("botones", "creacionInsumo").ToString, "creacionInsumo",
                                             Nothing, "~/AltaModificacionInsumo.aspx")
            SubMenu.Items.Add(botonAlta)
        End If
    End Sub

    Private Sub cargarSubBotonesDiseño()
        If verificarPermiso(Permisos.listadoDiseños) Then
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaDiseño").ToString, "busquedaDiseño",
                                             Nothing, "~/BusquedaDiseño.aspx")
            SubMenu.Items.Add(botonBusqueda)
        End If
        If verificarPermiso(Permisos.creacionDiseños) Then
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "creacionDiseño").ToString, "busquedaDiseño",
                                             Nothing, "~/AltaModificacionDiseño.aspx")
            SubMenu.Items.Add(botonBusqueda)
        End If
        If Not isClienteLogueado() Then
            If verificarPermiso(Permisos.listadoArticulo) Then
                Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "creacionArticulo").ToString, "busquedaArticulo",
                                                 Nothing, "~/AltaModificacionArticulo.aspx")
                SubMenu.Items.Add(botonBusqueda)
            End If
            If verificarPermiso(Permisos.creacionArticulo) Then
                Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaArticulo").ToString, "busquedaArticulo",
                                                 Nothing, "~/BusquedaArticulo.aspx")
                SubMenu.Items.Add(botonBusqueda)
            End If
        End If
    End Sub

    Private Sub cargarSubBotonesMensaje()
        If verificarPermiso(Permisos.mensajes) Then
            Dim botonAlta As New MenuItem(GetGlobalResourceObject("botones", "creacionConversacion").ToString, "creacionConversacion",
                                             Nothing, "~/AltaModificacionConversacion.aspx")
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaConversacion").ToString, "busquedaConversacion",
                                 Nothing, "~/BusquedaConversacion.aspx")
            SubMenu.Items.Add(botonAlta)
            SubMenu.Items.Add(botonBusqueda)
        End If
    End Sub

    Private Sub cargarSubBotonesFinanzas()
        If verificarPermiso(Permisos.creacionMovimientoCliente) Then
            Dim botonAlta As New MenuItem(GetGlobalResourceObject("botones", "creacionMovimientoCliente").ToString, "creacionMovimiento",
                                             Nothing, "~/AltaMovimientoCliente.aspx")
            SubMenu.Items.Add(botonAlta)
        End If
        If verificarPermiso(Permisos.listadoMovimientoCliente) Then
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaMovimientoCliente").ToString, "busquedaMovimiento",
                                             Nothing, "~/BusquedaMovimientoCliente.aspx")
            SubMenu.Items.Add(botonBusqueda)
        End If
        If verificarPermiso(Permisos.listadoFactura) Then
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaFactura").ToString, "busquedaFactura",
                                             Nothing, "~/BusquedaFactura.aspx")
            SubMenu.Items.Add(botonBusqueda)
        End If
        If Not isClienteLogueado() Then
            If verificarPermiso(Permisos.creacionMovimientoProveedor) Then
                Dim botonAlta As New MenuItem(GetGlobalResourceObject("botones", "creacionMovimientoProveedor").ToString, "creacionMovimiento",
                                                 Nothing, "~/AltaMovimientoProveedor.aspx")
                SubMenu.Items.Add(botonAlta)
            End If
            If verificarPermiso(Permisos.listadoMovimientoProveedor) Then
                Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaMovimientoProveedor").ToString, "busquedaMovimiento",
                                                 Nothing, "~/BusquedaMovimientoProveedor.aspx")
                SubMenu.Items.Add(botonBusqueda)
            End If
            If verificarPermiso(Permisos.listadoOrdenCompra) Then
                Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaOrdenCompra").ToString, "busquedaOrdenCompra",
                                                 Nothing, "~/BusquedaOrdenCompra.aspx")
                SubMenu.Items.Add(botonBusqueda)
            End If
        End If
    End Sub

    Private Sub cargarSubBotonesProveedores()
        If verificarPermiso(Permisos.creacion_maquinas) Then
            Dim botonAlta As New MenuItem(GetGlobalResourceObject("botones", "creacionProveedor").ToString, "creacionProveedor",
                                             Nothing, "~/AltaModificacionProveedor.aspx")
            SubMenu.Items.Add(botonAlta)
        End If
        If verificarPermiso(Permisos.listado_maquinas) Then
            Dim botonBusqueda As New MenuItem(GetGlobalResourceObject("botones", "busquedaProveedor").ToString, "busquedaProveedor",
                                             Nothing, "~/BusquedaProveedor.aspx")
            SubMenu.Items.Add(botonBusqueda)
        End If
    End Sub

    Private Sub cargarSubBotonesPedidos()
        If verificarPermiso(Permisos.creacionPedido) Then
            Dim botonAltaPedido As New MenuItem(GetGlobalResourceObject("botones", "creacionPedido").ToString, "creacionPedido",
                                             Nothing, "~/AltaModificacionPedido.aspx")
            SubMenu.Items.Add(botonAltaPedido)
        End If
        If verificarPermiso(Permisos.listadoPedido) Then
            Dim botonBusquedaPedido As New MenuItem(GetGlobalResourceObject("botones", "busquedaPedido").ToString, "busquedaPedido",
                                             Nothing, "~/BusquedaPedido.aspx")
            SubMenu.Items.Add(botonBusquedaPedido)
        End If
    End Sub



End Class