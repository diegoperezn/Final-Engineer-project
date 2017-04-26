Imports Dominio

Public Class FamiliaRepositorio

    Private familiaTDG As FamiliaTDG
    Private patenteRepositorio As PatenteRepositorio


    Sub New(ByVal fam As FamiliaTDG, ByVal pat As PatenteRepositorio)
        familiaTDG = fam
        patenteRepositorio = pat
    End Sub

    Public Function cargarFamilia(ByVal criterio As List(Of Restriccion)) As Familia
        Dim familia As Familia = familiaTDG.buscarUnico(criterio)

        If familia IsNot Nothing Then
            familia.patentes = patenteRepositorio.cargarPatentesPorFamilia(familia)
        End If

        Return familia
    End Function

    Public Function cargarFamilias(ByVal criterio As List(Of Restriccion)) As List(Of Familia)
        Dim familias As List(Of Familia) = familiaTDG.cargarFamilias(criterio)

        For Each fam As Familia In familias
            fam.patentes = patenteRepositorio.cargarPatentesPorFamilia(fam)
        Next

        Return familias
    End Function

    Public Function cargarFamiliasPorUsuario(ByVal usr As Usuario) As List(Of Familia)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(familiaTDG.USUARIO, usr.id, Restriccion.CONDICION_IGUAL))
        Dim familias As List(Of Familia) = familiaTDG.cargarFamilias(criteria)

        For Each fam As Familia In familias
            fam.patentes = patenteRepositorio.cargarPatentesPorFamilia(fam)
        Next

        Return familias
    End Function

    Public Function cargarFamiliasPorId(ByVal id As Long) As Familia
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(familiaTDG.ID_FAMILIA, id, Restriccion.CONDICION_IGUAL))
        Dim familia As Familia = familiaTDG.buscarUnico(criteria)

        familia.patentes = patenteRepositorio.cargarPatentesPorFamilia(familia)

        Return familia
    End Function

    Public Sub guardarFamilia(ByVal familia As Familia)
        familiaTDG.grabar(familia)
    End Sub

    Public Sub actualizarFamilia(ByVal familia As Familia)
        familiaTDG.actualizar(familia)
    End Sub

    Public Sub borrarFamilia(ByVal familia As Familia)
        familiaTDG.borrar(Familia)
    End Sub

End Class
