Public Class ProduccionRepositorio

    Dim produccionTdg As ProduccionTDG
    Dim realizacionTdg As ProduccionOperadorTDG
    Dim pedidoTdg As PedidoTDG
    Dim maquinaTdg As MaquinaTDG
    Dim articuloTdg As ArticuloTDG
    Dim historicoTdg As HistoricoEstadosProduccionTDG
    Dim estadoTdg As EstadoTrabajoTDG

    Sub New(ByVal produccionTdg As ProduccionTDG, ByVal realizacionTdg As ProduccionOperadorTDG,
            ByVal pedidoTdg As PedidoTDG, ByVal maquinaTdg As MaquinaTDG, ByVal articuloTdg As ArticuloTDG,
            ByVal historicoTdg As HistoricoEstadosProduccionTDG, ByVal estadoTdg As EstadoTrabajoTDG)
        Me.produccionTdg = produccionTdg
        Me.realizacionTdg = realizacionTdg
        Me.pedidoTdg = pedidoTdg
        Me.maquinaTdg = maquinaTdg
        Me.articuloTdg = articuloTdg
        Me.historicoTdg = historicoTdg
        Me.estadoTdg = estadoTdg
    End Sub

    Public Sub grabarProduccion(ByVal produccion As Produccion)
        Me.produccionTdg.grabar(produccion)

        If Not produccion.realizacion Is Nothing Then
            For Each realizacion As ProduccionOperador In produccion.realizacion
                Me.realizacionTdg.grabar(realizacion)
            Next
        End If

        If Not produccion.historicoProduccion Is Nothing Then
            For Each estado As HistoricoProduccion In produccion.historicoProduccion
                Me.historicoTdg.grabar(estado)
            Next
        End If
    End Sub

    Public Sub actualizarProduccion(ByVal produccion As Produccion)
        Me.produccionTdg.actualizar(produccion)

        For Each realizacion As ProduccionOperador In produccion.realizacion
            Me.realizacionTdg.grabar(realizacion)
        Next

        For Each estado As HistoricoProduccion In produccion.historicoProduccion
            If estado.nroEstado = 0 Then
                Me.historicoTdg.grabar(estado)
            Else
                Me.historicoTdg.actualizar(estado)
            End If
        Next
    End Sub

    Public Function buscarProduccionPorMaquinaFechas(ByVal maquina As Maquina,
                                                 ByVal fechaDesdeInicio As DateTime, ByVal fechaHastaInicio As DateTime,
                                                 ByVal fechaDesdeFinal As DateTime, ByVal fechaHastaFinal As DateTime) As Produccion
        Dim criteria As New List(Of Restriccion)

        If Not maquina Is Nothing Then
            criteria.Add(New Restriccion(produccionTdg.MAQUINA, maquina.codMaquina))
        End If

        If Not fechaDesdeInicio.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_INICIO, fechaDesdeInicio, Restriccion.CONDICION_MAYOR_IGUAL))
        End If

        If Not fechaHastaInicio.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_INICIO, fechaHastaInicio, Restriccion.CONDICION_MENOR_IGUAL))
        End If

        If Not fechaDesdeFinal.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_FINAL, fechaDesdeFinal, Restriccion.CONDICION_MAYOR_IGUAL))
        End If

        If Not fechaHastaFinal.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_FINAL, fechaHastaFinal, Restriccion.CONDICION_MENOR_IGUAL))
        End If

        Dim results As List(Of Produccion) = Me.produccionTdg.cargarlistaProduccion(criteria)

        For Each result As Produccion In results
            completarProduccion(result)
        Next

        If results.Count = 0 Then
            Return Nothing
        Else
            Return results(0)
        End If
    End Function

    Public Function listarProduccionConRestricciones(ByVal comentario As String, ByVal pedido As String, ByVal maquina As String,
                                                     ByVal articulo As String, ByVal estado As String,
                                                     ByVal fechaDesdeInicio As DateTime, ByVal fechaHastaInicio As DateTime,
                                                     ByVal fechaDesdeFinal As DateTime, ByVal fechaHastaFinal As DateTime) As List(Of Produccion)
        Dim criteria As New List(Of Restriccion)

        If String.IsNullOrEmpty(comentario) Then
            criteria.Add(New Restriccion(produccionTdg.COMENTARIO, comentario, Restriccion.CONDICION_LIKE))
        End If

        If String.IsNullOrEmpty(pedido) Then
            criteria.Add(New Restriccion(produccionTdg.PEDIDO, pedido))
        End If

        If String.IsNullOrEmpty(maquina) Then
            criteria.Add(New Restriccion(produccionTdg.MAQUINA, maquina))
        End If

        If String.IsNullOrEmpty(articulo) Then
            criteria.Add(New Restriccion(produccionTdg.ARTICULO, articulo))
        End If

        If String.IsNullOrEmpty(estado) Then
            criteria.Add(New Restriccion(produccionTdg.ESTADO_ACTUAL, estado))
        End If

        If Not fechaDesdeInicio.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_INICIO, fechaDesdeInicio, Restriccion.CONDICION_MAYOR_IGUAL))
        End If

        If Not fechaHastaInicio.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_INICIO, fechaHastaInicio, Restriccion.CONDICION_MENOR_IGUAL))
        End If

        If Not fechaDesdeFinal.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_FINAL, fechaDesdeFinal, Restriccion.CONDICION_MAYOR_IGUAL))
        End If

        If Not fechaHastaFinal.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_FINAL, fechaHastaFinal, Restriccion.CONDICION_MENOR_IGUAL))
        End If

        Dim results As List(Of Produccion) = Me.produccionTdg.cargarlistaProduccion(criteria)

        For Each result As Produccion In results
            completarProduccion(result)
        Next

        Return results
    End Function

    Public Function listarProduccionPorArticulo( ByVal articulo As Articulo) As List(Of Produccion)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(produccionTdg.ARTICULO, articulo.codArticulo))

        Dim results As List(Of Produccion) = Me.produccionTdg.cargarlistaProduccion(criteria)

        For Each result As Produccion In results
            completarProduccion(result)
        Next

        Return results
    End Function

    Public Function listarProduccionPorMaquina(ByVal maquina As Maquina) As List(Of Produccion)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(produccionTdg.MAQUINA, maquina.codMaquina))

        Dim results As List(Of Produccion) = Me.produccionTdg.cargarlistaProduccion(criteria)

        For Each result As Produccion In results
            completarProduccion(result)
        Next

        Return results
    End Function

    Public Function listarProduccionPorEstado(ByVal estado As EstadoTrabajos) As List(Of Produccion)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(produccionTdg.ESTADO_ACTUAL, estado.estado))

        Dim results As List(Of Produccion) = Me.produccionTdg.cargarlistaProduccion(criteria)

        For Each result As Produccion In results
            completarProduccion(result)
        Next

        Return results
    End Function

    Public Function listarProduccionPorPedido(ByVal pedido As Pedido) As List(Of Produccion)
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(produccionTdg.PEDIDO, pedido.codPedido))

        Dim results As List(Of Produccion) = Me.produccionTdg.cargarlistaProduccion(criteria)

        For Each result As Produccion In results
            completarProduccion(result)
        Next

        Return results
    End Function

    Public Function listarProduccionPorCodigo(ByVal codigo As Long) As Produccion
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(produccionTdg.COD_PRODUCCION, codigo))

        Dim result As Produccion = Me.produccionTdg.buscarUnico(criteria)

            completarProduccion(result)

        Return result
    End Function

    Public Function listarProduccionPorFechas(ByVal fechaDesdeInicio As DateTime, ByVal fechaHastaInicio As DateTime,
                                                     ByVal fechaDesdeFinal As DateTime, ByVal fechaHastaFinal As DateTime) As List(Of Produccion)
        Dim criteria As New List(Of Restriccion)

        If Not fechaDesdeInicio.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_INICIO, fechaDesdeInicio, Restriccion.CONDICION_MAYOR_IGUAL))
        End If

        If Not fechaHastaInicio.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_INICIO, fechaHastaInicio, Restriccion.CONDICION_MENOR_IGUAL))
        End If

        If Not fechaDesdeFinal.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_FINAL, fechaDesdeFinal, Restriccion.CONDICION_MAYOR_IGUAL))
        End If

        If Not fechaHastaFinal.Year = 1 Then
            criteria.Add(New Restriccion(produccionTdg.FECHA_FINAL, fechaHastaFinal, Restriccion.CONDICION_MENOR_IGUAL))
        End If

        Dim results As List(Of Produccion) = Me.produccionTdg.cargarlistaProduccion(criteria)

        For Each result As Produccion In results
            completarProduccion(result)
        Next

        Return results
    End Function


    Sub borrarProduccion(ByVal elem As Produccion)
        Me.produccionTdg.borrar(elem)
    End Sub

    Private Sub completarProduccion(ByRef result As Produccion)
        Dim criteria As New List(Of Restriccion)

        If result.pedido IsNot Nothing Then
            criteria.Clear()
            criteria.Add(New Restriccion(pedidoTdg.COD_PEDIDO, result.pedido.codPedido))
            result.pedido = Me.pedidoTdg.buscarUnico(criteria)
        End If

        criteria.Clear()
        criteria.Add(New Restriccion(maquinaTdg.COD_MAQUINA, result.maquina.codMaquina))
        result.maquina = Me.maquinaTdg.buscarUnico(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(articuloTdg.COD_ARTICULO, result.articulo.codArticulo))
        result.articulo = Me.articuloTdg.buscarUnico(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(EstadoTrabajoTDG.ESTADO, result.estadoActual.estado))
        result.estadoActual = Me.estadoTdg.buscarUnico(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(HistoricoEstadosProduccionTDG.PRODUCCION, result.codProduccion))
        result.historicoProduccion = Me.historicoTdg.cargarHistoricoEstados(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(ProduccionOperadorTDG.PRODUCCION, result.codProduccion))
        result.realizacion = Me.realizacionTdg.buscarLista(criteria)
    End Sub

End Class
