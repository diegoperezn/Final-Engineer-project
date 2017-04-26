Public Class HistoricoEstadosProduccionTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "historico_estados_produccion"

    Public Shared ReadOnly NRO_ESTADO As New Columna("nroEstado", "nro_estado", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly COMETARIO As New Columna("comentario", Columna.TIPO.TEXTO)

    Public Shared ReadOnly PRODUCCION As New Columna("produccion", "cod_produccion", Columna.TIPO.MANY_TO_ONE, True, New Join(New Columna("codProduccion", Columna.TIPO.NUMERICO, True)))

    Public Shared ReadOnly FECHA_DESDE As New Columna("fechaDesde", Columna.TIPO.FECHA)
    Public Shared ReadOnly FECHA_HASTA As New Columna("fechaHasta", Columna.TIPO.FECHA)
    Public Shared ReadOnly ESTADO As New Columna("estadoTrabajo", "estado", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("estado", Columna.TIPO.NUMERICO, True)), True)

    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(NRO_ESTADO)
        _columnas.Add(COMETARIO)
        _columnas.Add(PRODUCCION)
        _columnas.Add(FECHA_DESDE)
        _columnas.Add(FECHA_HASTA)
        _columnas.Add(ESTADO)

        _columnas.Add(BORRADO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(HistoricoProduccion)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarHistoricoEstados(ByVal criteria As List(Of Restriccion)) As List(Of HistoricoProduccion)
        Dim lista As New List(Of HistoricoProduccion)

        For Each elemento As HistoricoProduccion In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

    Protected Overrides Sub cargarId(ByVal objeto As Object)
        Dim historico As HistoricoProduccion = CType(objeto, HistoricoProduccion)
        If historico.nroEstado = 0 Then
            Dim resultado As Long = dao.consultarValor("SELECT  ISNULL(MAX(" + NRO_ESTADO.columna + " + 1),1) from " + tabla + " WHERE " + PRODUCCION.columna + "=" + historico.produccion.codProduccion.ToString)
            historico.nroEstado = resultado
        End If
    End Sub

End Class
