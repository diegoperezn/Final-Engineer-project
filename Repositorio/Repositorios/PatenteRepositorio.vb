Imports Dominio

Public Class PatenteRepositorio

    Dim patenteTDG As PatenteTDG

    Sub New(ByVal pat As PatenteTDG)
        Me.patenteTDG = pat
    End Sub

    Public Function cargarPatentes() As List(Of Patente)
        Return patenteTDG.cargarPatentes(Nothing)
    End Function

    Public Function cargarPatentesPorFamilia(ByVal familia As Familia) As List(Of Patente)
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(patenteTDG.FAMILIA, familia.idFamilia, Restriccion.CONDICION_IGUAL))
        Return patenteTDG.cargarPatentes(criterio)
    End Function

    Public Function cargarPatentesPorUsuario(ByVal usuario As Usuario) As List(Of Patente)
        Dim criterio As New List(Of Restriccion)
        criterio.Add(New Restriccion(patenteTDG.USUARIO, usuario.id, Restriccion.CONDICION_IGUAL))
        Return patenteTDG.cargarPatentes(criterio)
    End Function

End Class
