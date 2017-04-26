Imports Repositorio
Imports Dominio

Public Class PatenteBusiness

    Private patenteRepo As PatenteRepositorio

    Sub New()
        patenteRepo = RepositorioFactory.patenteRepositorio
    End Sub

    Sub New(ByVal repo As PatenteRepositorio)
        patenteRepo = repo
    End Sub

    Function listaPatentes() As List(Of Patente)
        Return patenteRepo.cargarPatentes()
    End Function

    Function listaPatentesPorFamilia(ByVal Familia As Familia) As List(Of Patente)
        Return patenteRepo.cargarPatentesPorFamilia(Familia)
    End Function

    Function listaPatentesPorUsuario(ByVal usr As Usuario) As List(Of Patente)
        Return patenteRepo.cargarPatentesPorUsuario(usr)
    End Function

End Class
