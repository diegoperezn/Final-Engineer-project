Public Class EstadoDiseñoTDG
    Inherits TableDataGateway

    Public Const NOMBRE_TABLA As String = "EstadoDiseños"

    Public Shared ReadOnly ESTADO As New Columna("estado", "estado", Columna.TIPO.NUMERICO, True)
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
        Return GetType(EstadoDiseños)
    End Function

    Public Function buscarEstados(ByVal criteria As List(Of Restriccion)) As List(Of EstadoDiseños)
        Dim lista As New List(Of EstadoDiseños)

        For Each obj As EstadoDiseños In buscar(criteria)
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function buscarEstadosPorId(ByVal id As Long) As EstadoDiseños
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(EstadoDiseñoTDG.ESTADO, id))

        Return Me.buscarUnico(criteria)
    End Function

End Class
