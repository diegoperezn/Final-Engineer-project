Imports Dominio

Public Class OpinionRepositorio

    Dim opinionTDG As OpinionTDG = RepositorioFactory.opinionTDG

    Sub New(ByVal opinioTDG As OpinionTDG)
        opinionTDG = opinioTDG
    End Sub

    Public Function listarOpiniones() As List(Of Opinion)
        Return opinionTDG.buscarOpiniones(Nothing)
    End Function

    Public Function listarOpinionesPorMail(ByVal mail As String) As List(Of Opinion)
        Dim criteria As New List(Of Restriccion)

        If mail IsNot Nothing Then
            criteria.Add(New Restriccion(opinionTDG.MAIL, mail, Restriccion.CONDICION_LIKE))
        End If

        Return opinionTDG.buscarOpiniones(criteria)
    End Function

    Public Function listarOpinionesPorId(ByVal id As Long) As Opinion
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(opinionTDG.ID, id, Restriccion.CONDICION_IGUAL))
        Return opinionTDG.buscarUnico(criteria)
    End Function

    Public Sub grabarOpinion(ByVal op As Opinion)
        opinionTDG.grabar(op)
    End Sub

    Sub borrar(ByVal opinion As Opinion)
        opinionTDG.borrar(opinion)
    End Sub

End Class
