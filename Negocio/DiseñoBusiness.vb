Imports Dominio

Public Class DiseñoBusiness

    Dim diseñoRepo As DiseñoRepositorio

    Sub New()
        diseñoRepo = RepositorioFactory.diseñoRepositorio
    End Sub

    Sub New(ByVal repo As DiseñoRepositorio)
        diseñoRepo = repo
    End Sub

    Public Function BuscarDiseños(ByVal Nombre As String,
                              ByVal puntadasDesde As String, ByVal puntadasHasta As String,
                              ByVal anchoDesde As String, ByVal anchoHasta As String,
                              ByVal altoDesde As String, ByVal altoHasta As String,
                              ByVal cliente As String, ByVal estado As String) As List(Of Diseño)

        Return diseñoRepo.BuscarDiseños(Nombre, puntadasDesde, puntadasHasta, anchoDesde, anchoHasta, altoDesde, altoHasta, cliente, estado)
    End Function

    Public Function listarDiseños() As List(Of Diseño)
        Return diseñoRepo.listarDiseños()
    End Function

    Public Sub actualizarDiseño(ByVal diseño As Diseño)
        Dim diseñoBase As Diseño = Me.buscarDiseñoPorId(diseño.idDiseño)
        diseño.estadoActual = diseñoBase.estadoActual
        Me.diseñoRepo.ActualizarFichaDiseño(diseño)

        If Not String.IsNullOrEmpty(diseño.pathArchivoFinal).Equals(String.IsNullOrEmpty(diseñoBase.pathArchivoFinal)) Then
            diseño = Me.buscarDiseñoPorId(diseño.idDiseño)

            Dim estado As EstadoDiseños = New EstadoDiseños()

            If String.IsNullOrEmpty(diseño.pathArchivoFinal) Then
                estado.estado = 1
            Else
                estado.estado = 2
            End If

            CambiarEstadpPedido(estado, diseño)
        End If
    End Sub

    Public Function GrabarDiseño(ByVal id As Long, ByVal alto As Double, ByVal ancho As Double, ByVal nombre As String, ByVal puntadas As Integer,
            ByVal cliente As Cliente, ByVal imagenPath As String, ByVal imagenDetallePath As String, ByVal archivoEditablePath As String,
            ByVal archivoFinalPath As String, ByVal insumos As List(Of DiseñoInsumo))
        Dim estado As EstadoDiseños = New EstadoDiseños()
        Dim estados As New List(Of HistoricoEstadosDiseño)

        If String.IsNullOrEmpty(archivoFinalPath) Then
            estado.estado = 1
        Else
            estado.estado = 2
        End If

        estados.Add(New HistoricoEstadosDiseño(Nothing, Nothing, "creacion ficha diseño", DateTime.Now, Nothing, estado))

        Dim diseño As New Diseño(id, alto, ancho, nombre, puntadas, cliente, imagenPath, imagenDetallePath,
                                 archivoEditablePath, archivoFinalPath, insumos, estado, estados)
        Me.diseñoRepo.grabarDiseño(diseño)

        Return diseño
    End Function

    Private Sub grabarDiseño(ByRef diseño As Diseño)
        Me.diseñoRepo.grabarDiseño(diseño)
    End Sub

    Sub borrar(ByVal diseño As Diseño)
        Me.diseñoRepo.borrar(diseño)
    End Sub

    Function buscarDiseñoPorId(ByVal id As Long) As Diseño
        Return Me.diseñoRepo.buscarDiseñoPorId(id)
    End Function

    Function buscarDiseñoPorCliente(ByVal cliente As Cliente) As List(Of Diseño)
        Return Me.diseñoRepo.buscarDiseñoPorCliente(cliente)
    End Function

    Function buscarDiseñoPorCliente(ByVal idCliente As String) As List(Of Diseño)
        Dim cliente As New Cliente(Long.Parse(idCliente))
        Return Me.diseñoRepo.buscarDiseñoPorCliente(cliente)
    End Function

    Public Sub CambiarEstadpPedido(ByVal estadoNuevo As EstadoDiseños, ByVal diseño As Diseño)
        diseño.estadoActual = estadoNuevo
        Dim fechaCambio As DateTime = DateTime.Now

        For Each estado As HistoricoEstadosDiseño In diseño.historicoEstados
            If estado.fechaHasta.Year = 1 Then
                estado.fechaHasta = fechaCambio
            End If
        Next

        Dim nuevoEstado As New HistoricoEstadosDiseño(Nothing, diseño, Nothing, fechaCambio, Nothing, estadoNuevo)
        diseño.historicoEstados.Add(nuevoEstado)

        Me.diseñoRepo.ActualizarFichaDiseño(diseño)
    End Sub

End Class ' DiseñoBusiness