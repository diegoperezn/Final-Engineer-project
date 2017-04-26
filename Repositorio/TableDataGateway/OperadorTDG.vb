Public Class OperadorTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "operador"

    Private Const TABLA_CLIENTE_MOVIMIENTO As String = "cliente_movimientos"

    Public Shared ReadOnly ID_OPERADOR As New Columna("idOperador", "id_Operador", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly USUARIO As New Columna("id", "id_usuario", Columna.TIPO.ONE_TO_ONE)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID_OPERADOR)
        _columnas.Add(USUARIO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(Operario)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function buscarOperadores(ByVal criteria As List(Of Restriccion)) As List(Of Operario)
        Dim lista As New List(Of Operario)

        For Each elemento As Operario In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
