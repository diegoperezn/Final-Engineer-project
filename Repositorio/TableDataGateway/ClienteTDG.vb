Imports Dominio

Public Class ClienteTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "Cliente"

    Private Const TABLA_CLIENTE_MOVIMIENTO As String = "cliente_movimientos"

    Public Shared ReadOnly ID_CLIENTE As New Columna("idCliente", "id_cliente", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly HABILITADO_TURNO As New Columna("habitadoTurnos", Columna.TIPO.BOOLEANO)
    Public Shared ReadOnly NEWSLETTER As New Columna("newsletter", Columna.TIPO.BOOLEANO)
    Public Shared ReadOnly USUARIO As New Columna("id", "usuarioID", Columna.TIPO.ONE_TO_ONE)
    Public Shared ReadOnly MOVIMIETO_CUENTA As New Columna("movimientosCuentaCorriente", Columna.TIPO.MANY_TO_MANY, New Join(MovimientoCuentaClienteTDG.NRO_MOVIMIENTO, TABLA_CLIENTE_MOVIMIENTO, True), False)
    Public Shared ReadOnly PEDIDOS As New Columna("pedido", Columna.TIPO.ONE_TO_MANY, New Join(PedidoTDG.COD_PEDIDO, PedidoTDG.NOMBRE_TABLA, True), True)
    Public Shared ReadOnly FACTURA As New Columna("facturas", Columna.TIPO.ONE_TO_MANY, New Join(FacturaTDG.NRO_DOCUMENTO, FacturaTDG.NOMBRE_TABLA, True), True)
    Public Shared ReadOnly DISEÑOS As New Columna("diseño", Columna.TIPO.ONE_TO_MANY, New Join(DiseñoTDG.ID_DISEÑO, DiseñoTDG.NOMBRE_TABLA, True), True)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID_CLIENTE)
        _columnas.Add(HABILITADO_TURNO)
        _columnas.Add(USUARIO)
        _columnas.Add(NEWSLETTER)
        _columnas.Add(MOVIMIETO_CUENTA)
        _columnas.Add(PEDIDOS)
        _columnas.Add(FACTURA)
        _columnas.Add(DISEÑOS)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New Cliente().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function buscarClientes(ByVal criteria As List(Of Restriccion)) As List(Of Cliente)
        Dim lista As New List(Of Cliente)

        For Each elemento As Cliente In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
