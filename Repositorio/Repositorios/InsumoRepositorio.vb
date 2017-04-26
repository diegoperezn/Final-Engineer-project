Public Class InsumoRepositorio

    Dim insumoTdg As InsumoTDG
    Dim movimientosStockTdg As MovimientoStockTDG
    Dim tipoTdg As TipoInsumoTDG
    Dim colorTdg As ColorTDG

    Sub New(ByVal insumo As InsumoTDG, ByVal movimientosStockTdg As MovimientoStockTDG,
            ByVal tipoTdg As TipoInsumoTDG, ByVal colorTdg As ColorTDG)
        Me.insumoTdg = insumo
        Me.movimientosStockTdg = movimientosStockTdg
        Me.tipoTdg = tipoTdg
        Me.colorTdg = colorTdg
    End Sub

    Public Sub grabarInsumo(ByVal insumo As Insumo)
        Me.insumoTdg.grabar(insumo)

        For Each movimiento As MovimientosStock In insumo.movimientosStock
            Me.movimientosStockTdg.grabar(movimiento)
        Next
    End Sub

    Public Sub actualizarInsumo(ByVal insumo As Insumo)
        Me.insumoTdg.actualizar(insumo)

        For Each movimiento As MovimientosStock In insumo.movimientosStock
            If movimiento.nroMovimiento = 0 Then
                Me.movimientosStockTdg.grabar(movimiento)
            End If
        Next
    End Sub

    Public Function listarInsumos() As List(Of Insumo)
        Dim results As List(Of Insumo) = Me.insumoTdg.buscarInsumos(Nothing)

        For Each insumo As Insumo In results
            completarInsumo(insumo)
        Next

        Return results
    End Function

    Public Function listarInsumosConRestricciones(ByVal nombre As String, ByVal detalle As String,
                                                  ByVal idTipo As String, ByVal idColor As String) As List(Of Insumo)
        Dim criteria As New List(Of Restriccion)

        If Not String.IsNullOrEmpty(nombre) Then
            criteria.Add(New Restriccion(insumoTdg.NOMBRE, nombre, Restriccion.CONDICION_LIKE))
        End If

        If Not String.IsNullOrEmpty(detalle) Then
            criteria.Add(New Restriccion(insumoTdg.DETALLE, detalle, Restriccion.CONDICION_LIKE))
        End If

        If Not String.IsNullOrEmpty(idTipo) Then
            criteria.Add(New Restriccion(insumoTdg.TIPO_INSUMO, idTipo))
        End If

        If Not String.IsNullOrEmpty(idColor) Then
            criteria.Add(New Restriccion(insumoTdg.COLOR, idColor))
        End If

        Dim results As List(Of Insumo) = Me.insumoTdg.buscarInsumos(criteria)

        For Each insumo As Insumo In results
            completarInsumo(insumo)
        Next

        Return results
    End Function

    Public Function listarInsumosPorCodigo(ByVal codigo As Long) As Insumo
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(insumoTdg.COD_INSUMO, codigo))

        Dim insumo As Insumo = Me.insumoTdg.buscarUnico(criteria)

        completarInsumo(insumo)

        Return insumo
    End Function

    Public Function listarInsumosPorTipo(ByVal tipo As TipoInsumo) As List(Of Insumo)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(insumoTdg.TIPO_INSUMO, tipo.tipo))
   
        Dim results As List(Of Insumo) = Me.insumoTdg.buscarInsumos(criteria)

        For Each insumo As Insumo In results
            completarInsumo(insumo)
        Next

        Return results
    End Function

    Public Function listarInsumosPorColor(ByVal color As Color) As List(Of Insumo)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(insumoTdg.COLOR, color.codColor))

        Dim results As List(Of Insumo) = Me.insumoTdg.buscarInsumos(criteria)

        For Each insumo As Insumo In results
            completarInsumo(insumo)
        Next

        Return results
    End Function

    Private Sub completarInsumo(ByVal insumo As Insumo)
        Dim criteria As New List(Of Restriccion)

        criteria.Clear()
        criteria.Add(New Restriccion(TipoInsumoTDG.TIPO_INSUMO, insumo.tipoInsumo.tipo))
        insumo.tipoInsumo = Me.tipoTdg.buscarUnico(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(ColorTDG.COD_COLOR, insumo.color.codColor))
        insumo.color = Me.colorTdg.buscarUnico(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(MovimientoStockTDG.INSUMO, insumo.codInsumo))
        insumo.movimientosStock = Me.movimientosStockTdg.cargarMovimientos(criteria)
    End Sub

End Class
