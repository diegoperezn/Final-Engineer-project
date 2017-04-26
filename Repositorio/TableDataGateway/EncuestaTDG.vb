Public Class EncuestaTDG
    Inherits TableDataGateway

    Private Const NOMBRE_TABLA As String = "encuesta"

    Public Shared ReadOnly ID As New Columna("id", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly ATENCION As New Columna("atencion", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly CALIDAD As New Columna("calidad", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly EFICIENCIA As New Columna("eficiencia", Columna.TIPO.NUMERICO)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID)
        _columnas.Add(ATENCION)
        _columnas.Add(CALIDAD)
        _columnas.Add(EFICIENCIA)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(Encuesta)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function buscarEncuesta(ByVal criteria As List(Of Restriccion)) As List(Of Encuesta)
        Dim lista As New List(Of Encuesta)

        For Each elemento As Encuesta In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
