Imports Dominio

Public Class ProduccionOperadorTDG
    Inherits TableDataGateway

    Private Const NOMBRE_TABLA As String = "produccion_operador"

    Public Shared ReadOnly OPERADOR As Columna = New Columna("operador", "id_operador", Columna.TIPO.MANY_TO_ONE, True, New Join(New Columna("idOperador", "id_operador", Columna.TIPO.NUMERICO)))
    Public Shared ReadOnly PRODUCCION As Columna = New Columna("produccion", "cod_prodcuccion", Columna.TIPO.MANY_TO_ONE, True, New Join(New Columna("codProduccion", "cod_produccion", Columna.TIPO.NUMERICO)))
    Public Shared ReadOnly PORCENTAJE As Columna = New Columna("porcentaje", "porcentaje", Columna.TIPO.NUMERICO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(OPERADOR)
        _columnas.Add(PRODUCCION)
        _columnas.Add(PORCENTAJE)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides ReadOnly Property Tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New ProduccionOperador().GetType()
    End Function

    Public Function buscarLista(ByVal criteria As List(Of Restriccion)) As List(Of ProduccionOperador)
        Dim lista As New List(Of ProduccionOperador)

        For Each obj As ProduccionOperador In buscar(criteria)
            lista.Add(obj)
        Next

        Return lista
    End Function

End Class
