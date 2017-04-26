Imports Dominio

Public Class TipoPedidoTDG
    Inherits TableDataGateway

    Public Const NOMBRE_TABLA As String = "tipoPedido"

    Public Shared ReadOnly TIPO_PEDIDO As New Columna("tipoPedido", "tipo_pedido", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly DESCRIPCION As New Columna("descripcion", "descripcion", Columna.TIPO.TEXTO)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByRef dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(TIPO_PEDIDO)
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
        Return New TipoPedido().GetType()
    End Function

    Public Function buscarTipoPedidos(ByVal criteria As List(Of Restriccion)) As List(Of TipoPedido)
        Dim listTipoPedidos As New List(Of TipoPedido)

        For Each obj As TipoPedido In buscar(criteria)
            listTipoPedidos.Add(obj)
        Next

        Return listTipoPedidos
    End Function

End Class
