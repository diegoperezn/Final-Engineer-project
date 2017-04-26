Option Explicit On

Imports Dominio

Public Class MaquinaRepositorio

    Dim tdg As MaquinaTDG
    Dim prendaTDG As TipoPrendaTDG

    Sub New(ByVal tdg As MaquinaTDG, ByVal prendaTDG As TipoPrendaTDG)
        Me.tdg = tdg
        Me.prendaTDG = prendaTDG 
    End Sub

    Public Sub actualizarMaquina(ByVal maquina As Maquina)
        tdg.actualizar(maquina)
    End Sub

    Public Function cargarMaquinasAptas(ByVal Prenda As TipoPrenda, ByVal diseño As Diseño) As List(Of Maquina)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MaquinaTDG.ALTO, diseño.alto, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.ANCHO, diseño.ancho, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.CABEZALES, 1, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.CANTIDAD_COLORES, diseño.insumos.Count, Restriccion.CONDICION_MAYOR_IGUAL))
        criteria.Add(New Restriccion(MaquinaTDG.TIPO_PRENDA, Prenda.tipoPrenda))

        Dim maquinas As List(Of Maquina) = tdg.cargarMaquinas(criteria)

        For Each maquina As Maquina In maquinas
            completarMaquina(maquina)
        Next

        Return maquinas
    End Function

    Public Sub grabarMaquina(ByVal maquina As Maquina)
        tdg.grabar(maquina)
    End Sub

    Public Function listarMaquinas() As List(Of Maquina)
        Dim maquinas As List(Of Maquina) = tdg.cargarMaquinas(Nothing)

        For Each maquina As Maquina In maquinas
            completarMaquina(maquina)
        Next

        Return maquinas
    End Function

    Public Function cargarMaquinaPorId(ByVal id As Long) As Maquina
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(MaquinaTDG.COD_MAQUINA, id))
        Dim maquina As Maquina = tdg.buscarUnico(criteria)

        completarMaquina(maquina)

        Return maquina
    End Function

    Private Sub completarMaquina(ByRef maquina As Maquina)
        Dim listaPrendas As New List(Of TipoPrenda)
        For Each tPrenda As TipoPrenda In maquina.tiposPrenda
            Dim criterio As New List(Of Restriccion)
            criterio.Add(New Restriccion(TipoPrendaTDG.TIPO_PRENDA, tPrenda.tipoPrenda))
            listaPrendas.Add(prendaTDG.buscarUnico(criterio))
        Next
        maquina.tiposPrenda = listaPrendas


    End Sub

End Class ' MaquinaRepositorio