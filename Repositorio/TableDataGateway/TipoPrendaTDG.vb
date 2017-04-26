Imports Dominio

Public Class TipoPrendaTDG
    Inherits TableDataGateway

    Private Const NOMBRE_TABLA As String = "TipoPrenda"

    Public Shared ReadOnly TIPO_PRENDA As New Columna("tipoPrenda", "tipo_prenda", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly DESCRIPCION As New Columna("descripcion", "descripcion", Columna.TIPO.TEXTO)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByRef dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(TIPO_PRENDA)
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
        Return New TipoPrenda().GetType
    End Function

    Public Function buscarPrendas(ByVal criteria As List(Of Restriccion)) As List(Of TipoPrenda)
        Dim listTipoPrendas As New List(Of TipoPrenda)

        For Each usr As TipoPrenda In buscar(criteria)
            listTipoPrendas.Add(usr)
        Next

        Return listTipoPrendas
    End Function

End Class
