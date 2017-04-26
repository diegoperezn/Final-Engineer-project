Public Class TipoPrendaBusiness

    Dim repo As TipoPrendaRepositorio

    Sub New()
        Me.repo = RepositorioFactory.tipoPrendaRepostirio
    End Sub

    Sub New(ByVal repo As TipoPrendaRepositorio)
        Me.repo = repo
    End Sub

    Public Sub actualizarTipoPrenda(ByVal tPrenda As TipoPrenda)
        repo.actualizarTipoPrenda(tPrenda)
    End Sub

    Public Sub grabarPrenda(ByVal tPrenda As TipoPrenda)
        repo.grabarPrenda(tPrenda)
    End Sub

    Public Function ListarPrendas() As List(Of TipoPrenda)
        Return repo.ListarPrendas()
    End Function

    Function buscarPrendaPorId(ByVal id As Long) As TipoPrenda
        Return repo.buscarPrendaPorId(id)
    End Function


End Class
