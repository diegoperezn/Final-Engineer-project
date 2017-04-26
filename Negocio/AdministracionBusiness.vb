Imports Dominio
Imports Seguridad

Public Class AdministracionBusiness

    Dim usuarioBusiness As UsuarioBusiness
    Dim newsRepo As NewsletterRepositorio
    Dim mailUtils As MailUtils

    Sub New(ByVal usuBusiness As UsuarioBusiness, ByVal newsRepo As NewsletterRepositorio, ByVal mailUtils As MailUtils)
        Me.usuarioBusiness = usuBusiness
        Me.newsRepo = newsRepo
        Me.mailUtils = mailUtils
    End Sub

    Public Sub enviarNewsletter()
        Dim clientes As List(Of Cliente) = usuarioBusiness.buscarUsuarioNewsletter()
        Dim news As Newsletter = newsRepo.buscarNewsletterParaEnviar

        For Each Cliente As Cliente In clientes
            mailUtils.enviarMail("uniprof@email.com", Cliente.mail, news.nombre, news.newsletter)
        Next

    End Sub

    Public Sub enviarNewsletter(ByVal id As Long)
        Dim clientes As List(Of Cliente) = usuarioBusiness.buscarUsuarioNewsletter()
        Dim news As Newsletter = newsRepo.buscarNewsletterPorId(id)

        For Each Cliente As Cliente In clientes
            mailUtils.enviarMail("uniprof@email.com", Cliente.mail, news.nombre, news.newsletter)
        Next

    End Sub

End Class
