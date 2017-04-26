Public Class ConversacionRepositorio

    Dim mensajeRepo As MensajeRepositorio
    Dim conversacionTDG As ConversacionTDG
    Dim usuarioTDG As UsuarioTDG

    Sub New(ByVal msjTdg As MensajeRepositorio, ByVal convTDG As ConversacionTDG, ByVal usuarioTDG As UsuarioTDG)
        mensajeRepo = msjTdg
        conversacionTDG = convTDG
        Me.usuarioTDG = usuarioTDG
    End Sub

    Sub grabar(ByRef conv As Conversacion)
        conversacionTDG.grabar(conv)
        For Each msj As Mensaje In conv.mensajes
            If msj.id = 0 Then
                mensajeRepo.grabar(msj)
            Else
                mensajeRepo.modificar(msj)
            End If
        Next
    End Sub

    Sub modificar(ByVal conv As Conversacion)
        conversacionTDG.actualizar(conv)
        For Each msj As Mensaje In conv.mensajes
            If msj.id = 0 Then
                mensajeRepo.grabar(msj)
            Else
                mensajeRepo.modificar(msj)
            End If
        Next
    End Sub

    Sub borrar(ByVal conv As Conversacion)
        For Each msj As Mensaje In conv.mensajes
            mensajeRepo.borrar(msj)
        Next
        conversacionTDG.borrar(conv)
    End Sub

    Function listarConversacionesPorUsuario(ByVal usuario As Usuario) As List(Of Conversacion)
        Return listarConversacionesPorId(usuario.id)
    End Function

    Function listarConversacionesPorId(ByVal id As Long) As List(Of Conversacion)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(conversacionTDG.REMITENTE, id))
        Dim conversaciones As List(Of Conversacion) = conversacionTDG.cargarConversaciones(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(conversacionTDG.DESTINATARIO, id))
        conversaciones.AddRange(conversacionTDG.cargarConversaciones(criteria))

        For Each Conversacion As Conversacion In conversaciones
            Conversacion.remitente = usuarioTDG.buscarUnico(New Restriccion(usuarioTDG.ID_USUARIO, Conversacion.remitente.id))
            Conversacion.destinatario = usuarioTDG.buscarUnico(New Restriccion(usuarioTDG.ID_USUARIO, Conversacion.destinatario.id))
            mensajeRepo.cargarMensajePorConversacion(Conversacion)
        Next

        Return conversaciones
    End Function

    Function listarConversacionesPorIdConversacion(ByVal p1 As Long) As Conversacion
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(conversacionTDG.ID_CONVERSACION, p1))
        Dim Conversacion As Conversacion = conversacionTDG.buscarUnico(criteria)

        If Conversacion IsNot Nothing Then
            Conversacion.remitente = usuarioTDG.buscarUnico(New Restriccion(usuarioTDG.ID_USUARIO, Conversacion.remitente.id))
            Conversacion.destinatario = usuarioTDG.buscarUnico(New Restriccion(usuarioTDG.ID_USUARIO, Conversacion.destinatario.id))
            mensajeRepo.cargarMensajePorConversacion(Conversacion)
        End If

        Return Conversacion
    End Function

End Class
