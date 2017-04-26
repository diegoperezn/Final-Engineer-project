Imports Dominio

Public Class TipoInsumoTDG
    Inherits TableDataGateway


    Public Const NOBRE_TABLA As String = "tipoInsumo"

    Public Shared ReadOnly TIPO_INSUMO As New Columna("tipo", "tipo_insumo", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly DESCRIPCION As New Columna("descripcion", "descripcion", Columna.TIPO.TEXTO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(TIPO_INSUMO)
        _columnas.Add(DESCRIPCION)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOBRE_TABLA
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New TipoInsumo().GetType()
    End Function

    Public Function buscarLista(ByVal criteria As List(Of Restriccion)) As List(Of TipoInsumo)
        Dim lista As New List(Of TipoInsumo)

        For Each obj As TipoInsumo In buscar(criteria)
            lista.Add(obj)
        Next

        Return lista
    End Function

End Class
