Public Class EncuestaRepositorio

    Dim encuestaTDG As EncuestaTDG

    Sub New(ByVal encuestaTDG As EncuestaTDG)
        Me.encuestaTDG = encuestaTDG
    End Sub

    Public Sub grabarEncuesta(ByVal encuesta As Encuesta)
        Me.encuestaTDG.grabar(encuesta)
    End Sub

End Class
