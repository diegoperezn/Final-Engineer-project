Public Class MensajeRepositorio

    Dim mensajeTDG As MensajeTDG

    Sub New(ByVal msjTdg As MensajeTDG)
        mensajeTDG = msjTdg
    End Sub

    Sub grabar(ByVal mensaje As Mensaje)
        mensajeTDG.grabar(mensaje)
    End Sub

    Sub modificar(ByVal mensaje As Mensaje)
        mensajeTDG.actualizar(mensaje)
    End Sub

    Sub borrar(ByVal mensaje As Mensaje)
        mensajeTDG.borrar(mensaje)
    End Sub


    Function listarMensajes() As List(Of Mensaje)
        Return mensajeTDG.cargarMensajes(Nothing)
    End Function


    Sub cargarMensajePorConversacion(ByRef conversacion As Conversacion)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(mensajeTDG.CONVERSACION, conversacion.id))
        conversacion.mensajes = mensajeTDG.cargarMensajes(criteria)
    End Sub

    Function cargarMensajePorId(ByVal id As Long) As Mensaje
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(mensajeTDG.ID_MENSAJE, id))
        Return mensajeTDG.buscarUnico(criteria)
    End Function

End Class
