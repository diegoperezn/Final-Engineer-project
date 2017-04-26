Public Class CuentaTDG
    Inherits TableDataGateway

    Public Const NOMBRE_TABLA As String = "Cuenta"

    Public Shared ReadOnly COD_CUENTA As New Columna("codCuenta", "cuentaID", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly TIPO As New Columna("tipo", Columna.TIPO.TEXTO)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByRef dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(COD_CUENTA)
        _columnas.Add(TIPO)
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
        Return GetType(Cuenta)
    End Function

    Public Function buscarTipoCuentas(ByVal criteria As List(Of Restriccion)) As List(Of Cuenta)
        Dim lista As New List(Of Cuenta)

        For Each obj As Cuenta In buscar(criteria)
            lista.Add(obj)
        Next

        Return lista
    End Function

End Class
