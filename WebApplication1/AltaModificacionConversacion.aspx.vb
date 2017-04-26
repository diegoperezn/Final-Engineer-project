Public Class AltaModificacionConversacion
    Inherits BasePage

    Dim conversacionBusiness As ConversacionBusiness = BusinessFactory.conversacionBusiness
    Dim usuariosBusiness As UsuarioBusiness = BusinessFactory.usuarioBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.mensajes)

        If Request.Params("id") IsNot Nothing Then
            cargarConversacion(Long.Parse(Request.Params("id")))
            usuariosPanel.Visible = False
        End If
    End Sub

    Public Sub cargarVAloresVaciosDropDown() Handles Me.PreRenderComplete
        If Not isClienteLogueado() Then
            Me.usuarios.Items.Insert(0, New ListItem(GetGlobalResourceObject("labels", "Seleccione").ToString, ""))
        End If
    End Sub

    Private Sub cargarConversacion(ByVal id As Long)
        Dim conversacion As Conversacion = Me.conversacionBusiness.listarConversacionesPorIdconversacion(id)
        idConversacion.Value = id

        cargarConversacion(conversacion)
    End Sub

    Private Sub cargarConversacion(ByVal conversacion As Conversacion)
        conversacionesContenedor.Controls.Clear()

        For Each msj As Mensaje In Conversacion.mensajes
            Dim mensajePanel As MensajePanel = LoadControl("MensajePanel.ascx")
            mensajePanel.setFecha(msj.fecha)
            mensajePanel.setMensaje(msj.mensaje)
            If Conversacion.remitente.id = getLoggedUser.id Then
                If msj.tipoMensaje = Mensaje.SALIDA Then
                    mensajePanel.setClaseCss("mensajeSaliente")
                Else
                    mensajePanel.setClaseCss("mensajeEntrante")
                    msj.leido = True
                End If
            Else
                If msj.tipoMensaje = Mensaje.SALIDA Then
                    mensajePanel.setClaseCss("mensajeEntrante")
                    msj.leido = True
                Else
                    mensajePanel.setClaseCss("mensajeSaliente")
                End If
            End If
            conversacionesContenedor.Controls.Add(mensajePanel)
        Next

        Me.conversacionBusiness.modificar(conversacion)
    End Sub

    Protected Sub enviarMensaje_Click(ByVal sender As Object, ByVal e As EventArgs) Handles enviarMensaje.Click
        Dim conversacion As Conversacion
        If idConversacion.Value = "" Then
            conversacion = Me.crearConversacion()
        Else
            conversacion = Me.conversacionBusiness.listarConversacionesPorIdconversacion(idConversacion.Value)
        End If

        Dim tipo As String = Mensaje.SALIDA
        If Not conversacion.remitente.id = getLoggedUser.id Then
            tipo = Mensaje.ENTRADA
        End If
        Dim msj As New Mensaje(Nothing, tipo, conversacion, DateTime.Now, textoMensaje.Text)

        conversacion.mensajes.Add(msj)
        If String.IsNullOrEmpty(idConversacion.Value) Then
            conversacionBusiness.grabar(conversacion)
            idConversacion.Value = conversacion.id
        Else
            conversacionBusiness.modificar(conversacion)
        End If

        cargarConversacion(conversacion)
        textoMensaje.Text = ""
    End Sub

    Private Function crearConversacion() As Conversacion
        Dim usuario As Usuario = Me.usuariosBusiness.buscarUsuarioPorId(usuarios.SelectedValue)
        Return New Conversacion(Nothing, getLoggedUser, usuario, New List(Of Mensaje))
    End Function


End Class