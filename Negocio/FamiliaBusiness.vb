Imports Repositorio
Imports Dominio

Public Class FamiliaBusiness

    Private familiaRepo As FamiliaRepositorio

    Sub New()
        familiaRepo = RepositorioFactory.familiaRepositorio
    End Sub

    Sub New(ByVal repo As FamiliaRepositorio)
        familiaRepo = repo
    End Sub

    Public Function listarFamlias() As List(Of Familia)
        Return familiaRepo.cargarFamilias(Nothing)
    End Function

    Public Function cargarFamilia(ByVal criterio As List(Of Restriccion)) As Familia
        Return familiaRepo.cargarFamilia(criterio)
    End Function

    Public Function cargarFamiliaPorId(ByVal id As Long) As Familia
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(FamiliaTDG.ID_FAMILIA, id, Restriccion.CONDICION_IGUAL))

        Return familiaRepo.cargarFamilia(criterio)
    End Function

    Public Sub actualizarFamilia(ByVal familia As Familia)
        familiaRepo.actualizarFamilia(familia)
    End Sub

    Public Sub actualizarFamilia(ByVal id As Long, ByVal nombre As String, ByVal desc As String, ByVal patentes As List(Of Patente))
        Dim familia As New Familia(id, desc, nombre, patentes)
        familiaRepo.actualizarFamilia(Familia)
    End Sub

    Public Sub borrarFamilia(ByVal familia As Familia)
        familiaRepo.borrarFamilia(familia)
    End Sub

    Public Sub guardarFamilia(ByVal familia As Familia)
        familiaRepo.guardarFamilia(familia)
    End Sub

End Class
