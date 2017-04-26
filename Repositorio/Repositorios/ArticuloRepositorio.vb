Public Class ArticuloRepositorio

    Dim articuloTdg As ArticuloTDG
    Dim listaPreciosTdg As ListaPreciosTDG
    Dim tipoPrendaTdg As TipoPrendaTDG
    Dim diseñoTdg As DiseñoTDG

    Sub New(ByVal artTdg As ArticuloTDG, ByVal listaPreciosTdg As ListaPreciosTDG, ByVal tipoPrendaTdg As TipoPrendaTDG,
            ByVal diseñoTdg As DiseñoTDG)
        Me.articuloTdg = artTdg
        Me.listaPreciosTdg = listaPreciosTdg
        Me.tipoPrendaTdg = tipoPrendaTdg
        Me.diseñoTdg = diseñoTdg
    End Sub

    Public Sub guardarArticulo(ByVal articulo As Articulo)
        Me.articuloTdg.grabar(articulo)

        For Each precio As ListaPrecios In articulo.listaPrecios
            If precio.nroLista = 0 Then
                Me.listaPreciosTdg.grabar(precio)
            Else
                Me.listaPreciosTdg.actualizar(precio)
            End If
        Next
    End Sub

    Public Sub actualizaArticulo(ByVal articulo As Articulo)
        Me.articuloTdg.actualizar(articulo)

        For Each precio As ListaPrecios In articulo.listaPrecios
            If precio.nroLista = 0 Then
                Me.listaPreciosTdg.grabar(precio)
            Else
                Me.listaPreciosTdg.actualizar(precio)
            End If
        Next
    End Sub

    Public Sub borrarArticulo(ByVal articulo As Articulo)
        articulo.borrado = True
        Me.articuloTdg.actualizar(articulo)
    End Sub

    Public Function buscarArticulosPorCodigo(ByVal codigo As Long) As Articulo
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(articuloTdg.COD_ARTICULO, codigo))

        Dim result As Articulo = Me.articuloTdg.buscarUnico(criteria)

        completarArticulo(result)

        Return result
    End Function

    Public Function listarArticulosPorDiseño(ByVal diseño As Diseño) As List(Of Articulo)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(articuloTdg.DISEÑO, diseño.idDiseño))
        criteria.Add(New Restriccion(articuloTdg.BORRADO, False))

        Dim results As List(Of Articulo) = Me.articuloTdg.buscarArticulos(criteria)

        For Each result As Articulo In results
            completarArticulo(result)
        Next

        Return results
    End Function

    Public Function listarArticulos() As List(Of Articulo)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(articuloTdg.BORRADO, False))

        Dim results As List(Of Articulo) = Me.articuloTdg.buscarArticulos(criteria)

        For Each result As Articulo In results
            completarArticulo(result)
        Next

        Return results
    End Function

    Public Function listarArticulosPorPrenda(ByVal prenda As TipoPrenda) As List(Of Articulo)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(articuloTdg.TIPO_PRENDA, prenda.tipoPrenda))
        criteria.Add(New Restriccion(articuloTdg.BORRADO, False))

        Dim results As List(Of Articulo) = Me.articuloTdg.buscarArticulos(criteria)

        For Each result As Articulo In results
            completarArticulo(result)
        Next

        Return results
    End Function

    Function listarArticulos(ByVal prenda As String, ByVal diseño As String) As List(Of Articulo)
        Dim criteria As New List(Of Restriccion)
        If Not String.IsNullOrEmpty(prenda) Then
            criteria.Add(New Restriccion(articuloTdg.TIPO_PRENDA, prenda))
        End If
        If Not String.IsNullOrEmpty(diseño) Then
            criteria.Add(New Restriccion(articuloTdg.DISEÑO, diseño))
        End If

        criteria.Add(New Restriccion(articuloTdg.BORRADO, False))

        Dim results As List(Of Articulo) = Me.articuloTdg.buscarArticulos(criteria)

        For Each result As Articulo In results
            completarArticulo(result)
        Next

        Return results
    End Function

    Function obtenerArticulosFrecuentes(ByVal idCliente As Long) As List(Of Articulo)
        Dim articulos As List(Of Articulo) = articuloTdg.obtenerIdsArticulosFrecuentes(idCliente)
        Dim articulosCompletos As New List(Of Articulo)

        For Each art As Articulo In articulos
            articulosCompletos.Add(Me.buscarArticulosPorCodigo(art.codArticulo))
        Next

        Return articulosCompletos
    End Function

    Function listarArticulo(ByVal prenda As String, ByVal diseño As String) As Articulo
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(articuloTdg.DISEÑO, diseño))
        criteria.Add(New Restriccion(articuloTdg.TIPO_PRENDA, prenda))

        Dim result As Articulo = Me.articuloTdg.buscarUnico(criteria)

        completarArticulo(result)

        Return result
    End Function

    Private Sub completarArticulo(ByVal result As Articulo)
        If result IsNot Nothing Then
            Dim criteria As New List(Of Restriccion)

            criteria.Clear()
            criteria.Add(New Restriccion(listaPreciosTdg.COD_ARTICULO, result.codArticulo))
            result.listaPrecios = listaPreciosTdg.cargarListaPrecio(criteria)

            criteria.Clear()
            criteria.Add(New Restriccion(tipoPrendaTdg.TIPO_PRENDA, result.tipoPrenda.tipoPrenda))
            result.tipoPrenda = tipoPrendaTdg.buscarUnico(criteria)

            criteria.Clear()
            criteria.Add(New Restriccion(diseñoTdg.ID_DISEÑO, result.diseño.idDiseño))
            result.diseño = diseñoTdg.buscarUnico(criteria)
        End If
    End Sub





End Class
