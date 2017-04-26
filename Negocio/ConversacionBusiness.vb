Public Class ConversacionBusiness

    Private conversacionRepo As ConversacionRepositorio

    Sub New()
        Me.conversacionRepo = RepositorioFactory.conversacionRepositorio
    End Sub

    Sub New(ByVal coversacionRepo As ConversacionRepositorio)
        Me.conversacionRepo = coversacionRepo
    End Sub

    Sub grabar(ByRef conv As Conversacion)
        conversacionRepo.grabar(conv)
    End Sub

    Sub modificar(ByVal conv As Conversacion)
        conversacionRepo.modificar(conv)
    End Sub

    Sub borrar(ByVal conv As Conversacion)
        conversacionRepo.borrar(conv)
    End Sub

    Function listarConversacionesPorUsuario(ByVal usuario As Usuario) As List(Of Conversacion)
        Return listarConversacionesPorId(usuario.id)
    End Function

    Function listarConversacionesPorId(ByVal id As Long) As List(Of Conversacion)
        Return conversacionRepo.listarConversacionesPorId(id)
    End Function

    Function listarConversacionesPorIdconversacion(ByVal p1 As Long) As Conversacion
        Return conversacionRepo.listarConversacionesPorIdConversacion(p1)
    End Function


    Function contarMsjSinLeer(ByVal usr As Usuario) As Integer
        If usr Is Nothing Then
            Return 0
        End If

        Dim conversaciones As List(Of Conversacion) = Me.listarConversacionesPorUsuario(usr)
        Dim msjCount As Integer = 0

        For Each conversacion As Conversacion In conversaciones
            If usr.id = conversacion.remitente.id Then
                msjCount += conversacion.mensajesRemitenteSinLeer
            Else
                msjCount += conversacion.mensajesDestinatarioSinLeer
            End If
        Next

        Return msjCount
    End Function

End Class
