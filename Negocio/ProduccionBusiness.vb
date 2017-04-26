Public Class ProduccionBusiness

    Dim repo As ProduccionRepositorio
    Dim maquinaRepo As MaquinaRepositorio
    Dim pedidoBusiness As PedidoBusiness
    Dim facturaBusiness As FacturaBusiness
    Dim insumosBusiness As InsumoBusiness

    Sub New()
        Me.repo = RepositorioFactory.produccionRepositorio
        Me.maquinaRepo = RepositorioFactory.maquinaRepositorio
        Me.pedidoBusiness = BusinessFactory.pedidoBusiness
        Me.facturaBusiness = BusinessFactory.facturaBusiness
        Me.insumosBusiness = BusinessFactory.insumoBusiness
    End Sub

    Sub New(ByVal produccionRepo As ProduccionRepositorio, ByVal maquinaRepo As MaquinaRepositorio,
            ByVal pedidoBusiness As PedidoBusiness, ByVal facturaBusiness As FacturaBusiness,
            ByVal insumosBusiness As InsumoBusiness)
        Me.repo = produccionRepo
        Me.maquinaRepo = maquinaRepo
        Me.pedidoBusiness = pedidoBusiness
        Me.facturaBusiness = facturaBusiness
        Me.insumosBusiness = insumosBusiness
    End Sub

    Public Sub recalcularAgenda()
        Dim producciones As List(Of Produccion) = Me.repo.listarProduccionPorFechas(DateTime.Now, Nothing, Nothing, Nothing)

        For Each prod As Produccion In producciones
            prod.fechaFinal = Nothing
            prod.fechaInicio = Nothing

            Me.repo.actualizarProduccion(prod)
        Next

        For Each prod As Produccion In producciones
            Dim primeraProd As Produccion = Nothing
            For Each p As Produccion In calcularPosiblesFechas(prod, DateTime.Now)
                If primeraProd Is Nothing OrElse primeraProd.fechaInicio > p.fechaInicio Then
                    primeraProd = p
                End If
            Next

            Me.repo.actualizarProduccion(primeraProd)
        Next

        producciones = Me.repo.listarProduccionPorFechas(DateTime.Now, Nothing, Nothing, Nothing)

        For Each prod As Produccion In producciones
            Dim pedido As Pedido = Me.pedidoBusiness.buscarPedidoPorCodigo(prod.pedido.codPedido)

            Dim inicio As DateTime
            Dim final As DateTime

            For Each p As Produccion In pedido.trabajos
                If inicio.Year = 1 OrElse p.fechaInicio < inicio Then
                    inicio = p.fechaInicio
                End If
                If final.Year = 1 OrElse p.fechaFinal > final Then
                    final = p.fechaFinal
                End If
            Next

            pedido.fechaInicio = inicio
            pedido.fechaFinal = final

            Me.pedidoBusiness.actualizarPedido(pedido)
        Next
    End Sub

    Public Function calcularPosiblesFechas(ByVal produccion As Produccion, ByVal fecha As Date) As List(Of Produccion)
        Dim opciones As New List(Of Produccion)
        Dim produccionPorCabezal As Integer = produccion.articulo.produccion ' 10
        Dim cantidad As Integer = produccion.cantidad ' 120

        Dim cantidadCabezalesHora As Integer = cantidad / produccionPorCabezal ' 12 cabezalHora

        Dim maquinasAptas As List(Of Maquina) = maquinaRepo.cargarMaquinasAptas(produccion.articulo.tipoPrenda, produccion.articulo.diseño)

        For Each maq As Maquina In maquinasAptas
            Dim tiempoNecesarioMaquina As Double = cantidadCabezalesHora / maq.cabezales ' 12 / 6 = 2 horas de esta maquina
            Dim fechaComienzo As Date = Me.buscarPrimerosHuecosMaquina(maq, tiempoNecesarioMaquina, fecha)

            Dim fechaFinalizacion = calcularFinalizacion(fechaComienzo, tiempoNecesarioMaquina)

            Dim opcion As New Produccion(produccion.codProduccion, produccion.comentario, produccion.pedido, maq,
                                         produccion.cantidad, produccion.articulo, produccion.historicoProduccion,
                                         produccion.realizacion, produccion.estadoActual, fechaComienzo, fechaFinalizacion,
                                         tiempoNecesarioMaquina)

            opciones.Add(opcion)
        Next

        Return opciones
    End Function

    Public Function calcularFinalizacion(ByVal fechaComienzo As Date, ByVal cantidadCabezalesHora As Integer) As Date
        Dim finalDia As New Date(fechaComienzo.Year, fechaComienzo.Month, fechaComienzo.Day, 18, 0, 0)
        Dim fecha As Date = fechaComienzo

        If calcularHoras(finalDia.Ticks - fechaComienzo.Ticks) > cantidadCabezalesHora Then
            fecha = fechaComienzo.AddHours(cantidadCabezalesHora)
        Else
            cantidadCabezalesHora -= calcularHoras(finalDia.Ticks - fechaComienzo.Ticks)

            While cantidadCabezalesHora > 9
                fecha = fecha.AddDays(1)

                If Not (fecha.DayOfWeek = DayOfWeek.Saturday OrElse fecha.DayOfWeek = DayOfWeek.Sunday) Then
                    cantidadCabezalesHora -= 9
                End If
            End While

            fecha = New Date(fecha.Year, fecha.Month, fecha.Day, 9, 0, 0)
            fecha = fecha.AddDays(1)
            fecha = fecha.AddHours(cantidadCabezalesHora)
        End If

        Return fecha
    End Function

    Public Function buscarPrimerosHuecosMaquina(ByVal maq As Maquina, ByVal tiempoNecesarioMaquina As Double, ByVal fecha As Date) As Date
        Dim fechaLimite As DateTime = fecha.AddDays(30)
        Dim fechaLibre As DateTime

        Dim primero As Produccion = Me.buscarProduccionPorMaquinaFechas(maq, Nothing, Nothing, fecha, Nothing)

        If primero Is Nothing Then
            primero = New Produccion
            primero.fechaFinal = fecha
            primero.fechaInicio = fecha
        End If

        While Not fecha = fechaLimite AndAlso fechaLibre.Year = 1
            Dim segundo As Produccion = Me.buscarProduccionPorMaquinaFechas(maq, primero.fechaFinal, Nothing, Nothing, Nothing)

            If segundo Is Nothing Then
                If primero.fechaFinal.Hour < 9 Then
                    fechaLibre = New DateTime(primero.fechaFinal.Year, primero.fechaFinal.Month, primero.fechaFinal.Day, 9, 0, 0)
                ElseIf primero.fechaFinal.Hour > 18 Then
                    fechaLibre = New DateTime(primero.fechaFinal.Year, primero.fechaFinal.Month, primero.fechaFinal.Day, 9, 0, 0)
                    fechaLibre = fechaLibre.AddDays(1)

                    While (fechaLibre.DayOfWeek = DayOfWeek.Saturday OrElse fechaLibre.DayOfWeek = DayOfWeek.Sunday)
                        fechaLibre = fechaLibre.AddDays(1)
                    End While
                Else
                    fechaLibre = primero.fechaFinal
                End If


            Else
                Dim tiempoEntreTrabajos As Double = calcularDistanciaEntreTrabajos(primero, segundo)

                If tiempoEntreTrabajos >= tiempoNecesarioMaquina Then
                    fechaLibre = primero.fechaFinal
                End If
            End If

            primero = segundo
        End While

        If fechaLibre.Hour = 18 Then
            fechaLibre = fechaLibre.AddDays(1)

            While fechaLibre.DayOfWeek = DayOfWeek.Saturday OrElse fechaLibre.DayOfWeek = DayOfWeek.Sunday
                fechaLibre = fechaLibre.AddDays(1)
            End While

            fechaLibre = New Date(fechaLibre.Year, fechaLibre.Month, fechaLibre.Day, 9, 0, 0)
        End If

        Return fechaLibre
    End Function

    Public Function calcularDistanciaEntreTrabajos(ByVal primero As Produccion, ByVal segundo As Produccion) As Double
        If primero.fechaFinal.DayOfYear = segundo.fechaInicio.DayOfYear Then
            Return calcularHoras(segundo.fechaInicio.Ticks - primero.fechaFinal.Ticks)
        Else
            Dim finalDia As New Date(primero.fechaFinal.Year, primero.fechaFinal.Month, primero.fechaFinal.Day, 18, 0, 0)
            Dim inicioDia As New Date(segundo.fechaInicio.Year, segundo.fechaInicio.Month, segundo.fechaInicio.Day, 9, 0, 0)
            Dim fechaInicial As Date = primero.fechaFinal
            Dim distancia As New Long
            While Not finalDia.DayOfYear = segundo.fechaInicio.DayOfYear
                If Not (finalDia.DayOfWeek = DayOfWeek.Saturday OrElse finalDia.DayOfWeek = DayOfWeek.Sunday) Then
                    distancia += finalDia.Ticks - fechaInicial.Ticks
                End If

                finalDia = finalDia.AddDays(1)
                fechaInicial = New Date(finalDia.Year, finalDia.Month, finalDia.Day, 9, 0, 0)
            End While

            distancia += segundo.fechaInicio.Ticks - inicioDia.Ticks

            Return calcularHoras(distancia)
        End If
    End Function

    Public Function calcularTimepoTrabajo(ByVal trabajo As Produccion) As Double
        If trabajo.fechaFinal.DayOfYear = trabajo.fechaInicio.DayOfYear Then
            Return calcularHoras(trabajo.fechaFinal.Ticks - trabajo.fechaInicio.Ticks)
        Else
            Dim finalDia As New Date(trabajo.fechaInicio.Year, trabajo.fechaInicio.Month, trabajo.fechaInicio.Day, 18, 0, 0)
            Dim inicioDia As New Date(trabajo.fechaFinal.Year, trabajo.fechaFinal.Month, trabajo.fechaFinal.Day, 9, 0, 0)
            Dim fechaInicial As Date = trabajo.fechaInicio
            Dim distancia As New Long
            While Not finalDia.DayOfYear = trabajo.fechaFinal.DayOfYear
                If Not (finalDia.DayOfWeek = DayOfWeek.Saturday OrElse finalDia.DayOfWeek = DayOfWeek.Sunday) Then
                    distancia += finalDia.Ticks - fechaInicial.Ticks
                End If

                finalDia = finalDia.AddDays(1)
                fechaInicial = New Date(finalDia.Year, finalDia.Month, finalDia.Day, 9, 0, 0)
            End While

            distancia += trabajo.fechaFinal.Ticks - inicioDia.Ticks

            Return calcularHoras(distancia)
        End If
    End Function

    Public Sub grabarProduccion(ByVal produccion As Produccion)
        Me.repo.grabarProduccion(produccion)
    End Sub

    Public Sub actualizarProduccion(ByVal produccion As Produccion)
        Me.repo.actualizarProduccion(produccion)
    End Sub

    Public Function buscarProduccionPorMaquinaFechas(ByVal maquina As Maquina,
                                                 ByVal fechaDesdeInicio As DateTime, ByVal fechaHastaInicio As DateTime,
                                                 ByVal fechaDesdeFinal As DateTime, ByVal fechaHastaFinal As DateTime) As Produccion
        Return Me.repo.buscarProduccionPorMaquinaFechas(maquina, fechaDesdeInicio, fechaHastaInicio, fechaDesdeFinal, fechaHastaFinal)
    End Function

    Public Function listarProduccionConRestricciones(ByVal comentario As String, ByVal pedido As String, ByVal maquina As String,
                                                     ByVal articulo As String, ByVal estado As String,
                                                     ByVal fechaDesdeInicio As DateTime, ByVal fechaHastaInicio As DateTime,
                                                     ByVal fechaDesdeFinal As DateTime, ByVal fechaHastaFinal As DateTime) As List(Of Produccion)
        Return Me.repo.listarProduccionConRestricciones(comentario, pedido, maquina, articulo, estado, fechaDesdeInicio, fechaHastaInicio, fechaDesdeFinal, fechaHastaFinal)
    End Function

    Public Function listarProduccionPorArticulo(ByVal articulo As Articulo) As List(Of Produccion)
        Return Me.repo.listarProduccionPorArticulo(articulo)
    End Function

    Public Function listarProduccionPorMaquina(ByVal maquina As Maquina) As List(Of Produccion)
        Return Me.repo.listarProduccionPorMaquina(maquina)
    End Function

    Public Function listarProduccionPorEstado(ByVal estado As EstadoTrabajos) As List(Of Produccion)
        Return Me.repo.listarProduccionPorEstado(estado)
    End Function

    Public Function listarProduccionPorPedido(ByVal pedido As Pedido) As List(Of Produccion)
        Return Me.repo.listarProduccionPorPedido(pedido)
    End Function

    Public Function listarProduccionPorCodigo(ByVal codigo As Long) As Produccion
        Return Me.repo.listarProduccionPorCodigo(codigo)
    End Function

    Public Function listarProduccionPorFechas(ByVal fechaDesdeInicio As DateTime, ByVal fechaHastaInicio As DateTime,
                                                     ByVal fechaDesdeFinal As DateTime, ByVal fechaHastaFinal As DateTime) As List(Of Produccion)
        Return Me.repo.listarProduccionPorFechas(fechaDesdeInicio, fechaHastaInicio, fechaDesdeFinal, fechaHastaFinal)
    End Function

    Private Function calcularHoras(ByVal trick As Double) As Double
        Return (trick / 1000 / 60 / 60) / 10000
    End Function

    Sub borrarProduccion(ByVal elem As Produccion)
        Me.repo.borrarProduccion(elem)
    End Sub

    Public Sub CambiarEstadoPedidos(ByVal estadoTrabajo As EstadoTrabajos, ByVal trabajo As Produccion)
        trabajo.estadoActual = estadoTrabajo
        Dim fechaCambio As DateTime = DateTime.Now

        For Each estado As HistoricoProduccion In trabajo.historicoProduccion
            If estado.fechaHasta.Year = 1 Then
                estado.fechaHasta = fechaCambio
            End If
        Next

        Dim nuevoEstado As New HistoricoProduccion(Nothing, trabajo, Nothing, fechaCambio, Nothing, estadoTrabajo)
        trabajo.historicoProduccion.Add(nuevoEstado)
    End Sub

    Sub registrarComienzoTrabajo(ByVal prod As Produccion)
        Me.CambiarEstadoPedidos(New EstadoTrabajos(2), prod)
        Me.actualizarProduccion(prod)

        Dim pedido As Pedido = Me.pedidoBusiness.buscarPedidoPorCodigo(prod.pedido.codPedido)
        If Not pedido.estadoActual.estadoPedido = 2 Then
            Me.pedidoBusiness.CambiarEstadpPedido(New EstadoPedido(3), pedido)
        End If

    End Sub

    Sub registrarFinalizacionTrabajo(ByVal produccion As Produccion)
        Me.CambiarEstadoPedidos(New EstadoTrabajos(3), produccion)

        Me.actualizarProduccion(produccion)
        Me.insumosBusiness.disminuirStock(produccion.articulo.codArticulo, produccion.cantidad)

        Dim pedido As Pedido = Me.pedidoBusiness.buscarPedidoPorCodigo(produccion.pedido.codPedido)

        Dim pedidoTerminado As Boolean = True
        For Each prod As Produccion In pedido.trabajos
            If Not prod.estadoActual.estado = 3 Then
                pedidoTerminado = False
            End If
        Next

        If pedidoTerminado Then
            Me.pedidoBusiness.CambiarEstadpPedido(New EstadoPedido(4), pedido)
            Me.facturaBusiness.generarFactura(pedido)
        End If

    End Sub

End Class
