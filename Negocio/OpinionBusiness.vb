Imports Repositorio
Imports Dominio

Public Class OpinionBusiness

    Dim opinionRepo As OpinionRepositorio = RepositorioFactory.opinionRepositorio

    Sub New()
        opinionRepo = RepositorioFactory.opinionRepositorio
    End Sub

    Sub New(ByVal opinioRepo As OpinionRepositorio)
        opinionRepo = opinioRepo
    End Sub

    Public Function listarOpiniones() As List(Of Opinion)
        Return opinionRepo.listarOpiniones
    End Function

    Public Function listarOpinionesPorMail(ByVal mail As String) As List(Of Opinion)
        Return opinionRepo.listarOpinionesPorMail(mail)
    End Function

    Public Function listarOpinionesPorId(ByVal id As Long) As Opinion
        Return opinionRepo.listarOpinionesPorId(id)
    End Function

    Public Sub grabarOpinion(ByVal op As Opinion)
        opinionRepo.grabarOpinion(op)
    End Sub

    Sub borrar(ByVal opinion As Opinion)
        opinionRepo.borrar(opinion)
    End Sub

End Class
