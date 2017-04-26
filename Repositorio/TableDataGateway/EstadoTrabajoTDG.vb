Public Class EstadoTrabajoTDG
    Inherits TableDataGateway

    Public Const NOMBRE_TABLA As String = "EstadoTrabajos"

    Public Shared ReadOnly ESTADO As New Columna("estado", "cod_estado", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly DESCRIPCION As New Columna("descripcion", "estado", Columna.TIPO.TEXTO)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByRef dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ESTADO)
        _columnas.Add(DESCRIPCION)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(EstadoTrabajos)
    End Function

    Public Function buscarEstados(ByVal criteria As List(Of Restriccion)) As List(Of EstadoTrabajos)
        Dim listTipoPedidos As New List(Of EstadoTrabajos)

        For Each obj As EstadoTrabajos In buscar(criteria)
            listTipoPedidos.Add(obj)
        Next

        Return listTipoPedidos
    End Function

    Public Function buscarEstadosPorId(ByVal id As Long) As EstadoTrabajos
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(EstadoTrabajoTDG.ESTADO, id))

        Return Me.buscarUnico(criteria)
    End Function
End Class
