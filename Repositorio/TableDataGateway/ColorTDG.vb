Public Class ColorTDG
    Inherits TableDataGateway

    Private Const NOMBRE_TABLA As String = "color"

    Public Shared ReadOnly COD_COLOR As New Columna("codColor", "codigo_color", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly COLOR As New Columna("color", Columna.TIPO.TEXTO)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByRef dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(COD_COLOR)
        _columnas.Add(COLOR)
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
        Return GetType(Color)
    End Function

    Public Function buscarColor(ByVal criteria As List(Of Restriccion)) As List(Of Color)
        Dim lista As New List(Of Color)

        For Each elemento As Color In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function
End Class
