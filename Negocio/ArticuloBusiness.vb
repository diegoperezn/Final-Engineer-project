Public Class ArticuloBusiness

    Dim repo As ArticuloRepositorio

    Sub New()
        Me.repo = RepositorioFactory.articuloRepositorio
    End Sub

    Sub New(ByVal repo As ArticuloRepositorio)
        Me.repo = repo
    End Sub

    Public Sub guardarArticulo(ByVal articulo As Articulo)
        If articulo.listaPrecios Is Nothing Then
            articulo.listaPrecios = New List(Of ListaPrecios)
            articulo.listaPrecios.Add(New ListaPrecios(Nothing, DateTime.Now, Nothing, articulo.precioActual, articulo, False))
        End If

        Me.repo.guardarArticulo(articulo)
    End Sub

    Public Sub actualizaArticulo(ByVal articulo As Articulo)
        Dim articuloViejo As Articulo = Me.buscarArticulosPorCodigo(articulo.codArticulo)

        If Not articulo.precioActual = articuloViejo.precioActual Then
            Dim fecha As DateTime = DateTime.Now

            For Each precio As ListaPrecios In articulo.listaPrecios
                If precio.fechaHasta.Year = 1 Then
                    precio.fechaHasta = fecha
                End If
            Next

            articulo.listaPrecios.Add(New ListaPrecios(Nothing, DateTime.Now, Nothing, articulo.precioActual, articulo, False))
        End If


        Me.repo.actualizaArticulo(articulo)
    End Sub

    Public Sub borrarArticulo(ByVal articulo As Articulo)
        Me.repo.borrarArticulo(articulo)
    End Sub

    Public Function buscarArticulosPorCodigo(ByVal codigo As Long) As Articulo
        Return Me.repo.buscarArticulosPorCodigo(codigo)
    End Function

    Public Function listarArticulosPorDiseño(ByVal diseño As Diseño) As List(Of Articulo)
        Return Me.repo.listarArticulosPorDiseño(diseño)
    End Function

    Public Function listarArticulos() As List(Of Articulo)
        Return Me.repo.listarArticulos
    End Function

    Public Function listarArticulosPorPrenda(ByVal prenda As TipoPrenda) As List(Of Articulo)
        Return Me.repo.listarArticulosPorPrenda(prenda)
    End Function

    Public Function listarArticulos(ByVal prenda As String, diseño As String) As List(Of Articulo)
        Return Me.repo.listarArticulos(prenda, diseño)
    End Function

    Function buscarArticulo(ByVal prenda As String, ByVal diseño As String) As Articulo
        Return Me.repo.listarArticulo(prenda, diseño)
    End Function

    Function obtenerArticulosFrecuentes(ByVal idCliente As Long) As List(Of Articulo)
        Return Me.repo.obtenerArticulosFrecuentes(idCliente)
    End Function

End Class
