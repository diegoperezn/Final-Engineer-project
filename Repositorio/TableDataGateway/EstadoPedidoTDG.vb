Public Class EstadoPedidoTDG
    Inherits TableDataGateway

    Public Const NOMBRE_TABLA As String = "EstadoPedido"

    Public Shared ReadOnly ESTADO As New Columna("estadoPedido", "estado_pedido", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly DESCRIPCION As New Columna("descripcion", "descripcion", Columna.TIPO.TEXTO)

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
        Return GetType(EstadoPedido)
    End Function

    Public Function buscarEstados(ByVal criteria As List(Of Restriccion)) As List(Of EstadoPedido)
        Dim listTipoPedidos As New List(Of EstadoPedido)

        For Each obj As EstadoPedido In buscar(criteria)
            listTipoPedidos.Add(obj)
        Next

        Return listTipoPedidos
    End Function

    Public Function buscarEstadosPorId(ByVal id As Long) As EstadoPedido
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(EstadoPedidoTDG.ESTADO, id))

        Return Me.buscarUnico(criteria)
    End Function


End Class
