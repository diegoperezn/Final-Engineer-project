Public Class EncuestaBusiness

    Dim encuestaRepositorio As EncuestaRepositorio

    Sub New()
        Me.encuestaRepositorio = RepositorioFactory.encuestaRepositorio
    End Sub

    Sub New(ByVal encuestaRepositorio As EncuestaRepositorio)
        Me.encuestaRepositorio = encuestaRepositorio
    End Sub

    Public Sub grabarEncuesta(ByVal encuesta As Encuesta)
        Me.encuestaRepositorio.grabarEncuesta(encuesta)
    End Sub

End Class
