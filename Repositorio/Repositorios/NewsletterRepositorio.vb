Imports Dominio

Public Class NewsletterRepositorio

    Dim newsTDG As NewsletterTDG

    Sub New(ByVal tdg As NewsletterTDG)
        newsTDG = tdg
    End Sub

    Public Function listarNewsletter() As List(Of Newsletter)
        Return newsTDG.cargarNewsletter(Nothing)
    End Function

    Function buscarNewsletterPorId(ByVal id As Long) As Newsletter
        Return newsTDG.buscarUnico(New Restriccion(NewsletterTDG.ID_NEWSLETTER, id))
    End Function

    Function buscarNewsletterPorNombre(ByVal nombre As String) As Newsletter
        Return newsTDG.buscarUnico(New Restriccion(NewsletterTDG.NOMBRE, nombre))
    End Function

    Sub grabarNewsletter(ByVal news As Newsletter)
        newsTDG.grabar(news)
    End Sub

    Sub actualizarNewsletter(ByVal news As Newsletter)
        newsTDG.actualizar(news)
    End Sub

    Sub borrarNewsletter(ByVal news As Newsletter)
        newsTDG.borrar(news)
    End Sub

    Function buscarNewsletterParaEnviar() As Newsletter
        Dim crit As New List(Of Restriccion)
        crit.Add(New Restriccion(NewsletterTDG.ENVIADO, False))
        Dim newsletters As List(Of Newsletter) = newsTDG.cargarNewsletter(crit)
        If Not newsletters.Count = 0 Then
            Return newsletters(0)
        End If
        Return Nothing
    End Function

End Class
