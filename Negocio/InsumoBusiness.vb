Public Class InsumoBusiness

    Dim insumoRepo As InsumoRepositorio
    Dim articuloRepo As ArticuloRepositorio
    Dim diseñoRepo As DiseñoRepositorio

    Sub New()
        Me.articuloRepo = RepositorioFactory.articuloRepositorio
        Me.insumoRepo = RepositorioFactory.insumoRepositorio
        Me.diseñoRepo = RepositorioFactory.diseñoRepositorio
    End Sub

    Sub New(ByVal insumoRepo As InsumoRepositorio, ByVal articuloRepo As ArticuloRepositorio,
            ByVal diseñoRepo As DiseñoRepositorio)
        Me.insumoRepo = insumoRepo
        Me.articuloRepo = articuloRepo
        Me.diseñoRepo = diseñoRepo
    End Sub

    Public Sub grabarInsumo(ByVal insumo As Insumo)
        Dim mov As New MovimientosStock(Nothing, insumo, insumo.cantidadActual, DateTime.Now, New TipoMovimiento(2))
        insumo.movimientosStock.Add(mov)

        Me.insumoRepo.grabarInsumo(insumo)
    End Sub

    Public Sub actualizarInsumo(ByVal insumo As Insumo)
        Dim insumoBase As Insumo = Me.insumoRepo.listarInsumosPorCodigo(insumo.codInsumo)
        If Not insumoBase.cantidadActual = insumo.cantidadActual Then
            Dim tipoMovimiento As TipoMovimiento = New TipoMovimiento(2)
            If insumoBase.cantidadActual > insumo.cantidadActual Then
                tipoMovimiento.tipoMovimiento = 1
            End If
            Dim mov As New MovimientosStock(Nothing, insumo, insumo.cantidadActual - insumoBase.cantidadActual, DateTime.Now, tipoMovimiento)
            insumoBase.movimientosStock.Add(mov)
        End If

        insumoBase.color = insumo.color
        insumoBase.detalle = insumo.detalle
        insumoBase.nombre = insumo.nombre
        insumoBase.cantidadActual = insumo.cantidadActual
        insumoBase.tipoInsumo = insumo.tipoInsumo
        insumoBase.costo = insumo.costo

        Me.insumoRepo.actualizarInsumo(insumoBase)
    End Sub

    Public Function listarInsumos() As List(Of Insumo)
        Return Me.insumoRepo.listarInsumos()
    End Function

    Public Function listarInsumosConRestricciones(ByVal nombre As String, ByVal detalle As String,
                                                  ByVal idTipo As String, ByVal idColor As String) As List(Of Insumo)
        Return Me.insumoRepo.listarInsumosConRestricciones(nombre, detalle, idTipo, idColor)
    End Function

    Public Function listarInsumosPorCodigo(ByVal codigo As Long) As Insumo
        Return Me.insumoRepo.listarInsumosPorCodigo(codigo)
    End Function

    Public Function listarInsumosPorTipo(ByVal tipo As TipoInsumo) As List(Of Insumo)
        Return Me.insumoRepo.listarInsumosPorTipo(tipo)
    End Function

    Public Function listarInsumosPorColor(ByVal color As Color) As List(Of Insumo)
        Return Me.insumoRepo.listarInsumosPorColor(color)
    End Function

    Sub disminuirStock(ByVal idArticulo As Long, ByVal cantidad As Integer)
        Dim articulo As Articulo = Me.articuloRepo.buscarArticulosPorCodigo(idArticulo)
        Dim diseño As Diseño = Me.diseñoRepo.buscarDiseñoPorId(articulo.diseño.idDiseño)

        For Each diseñoInsumo As DiseñoInsumo In diseño.insumos

            Dim insumo As Insumo = Me.listarInsumosPorCodigo(diseñoInsumo.insumo.codInsumo)
            insumo.cantidadActual = insumo.cantidadActual - diseñoInsumo.cantidad * cantidad

            actualizarInsumo(insumo)
        Next

    End Sub

End Class
