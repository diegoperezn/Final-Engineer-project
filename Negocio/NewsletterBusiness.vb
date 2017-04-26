Public Class NewsletterBusiness

    Dim newsRepo As NewsletterRepositorio

    Sub New()
        newsRepo = RepositorioFactory.newsletterRepositorio
    End Sub

    Sub New(ByVal tdg As NewsletterRepositorio)
        newsRepo = tdg
    End Sub

    Public Function listarNewsletter() As List(Of Newsletter)
        Return newsRepo.listarNewsletter
    End Function

    Function buscarNewsletterPorId(ByVal id As Long) As Newsletter
        Return newsRepo.buscarNewsletterPorId(id)
    End Function

    Function buscarNewsletterPorNombre(ByVal nombre As String) As Newsletter
        Return newsRepo.buscarNewsletterPorNombre(nombre)
    End Function

    Sub grabarNewsletter(ByVal news As Newsletter)
        newsRepo.grabarNewsletter(news)
    End Sub

    Sub actualizarNewsletter(ByVal news As Newsletter)
        newsRepo.actualizarNewsletter(news)
    End Sub

    Sub borrarNewsletter(ByVal news As Newsletter)
        newsRepo.borrarNewsletter(news)
    End Sub

    Function buscarNewsletterParaEnviar() As Newsletter
        Return newsRepo.buscarNewsletterParaEnviar
    End Function

End Class
