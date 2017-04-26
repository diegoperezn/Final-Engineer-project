Imports Dominio

Public Class ProveedorTDG
    Inherits TableDataGateway

    Private Const NOMBRE_TABLA As String = "Proveedor"

    Public Shared ReadOnly COD_PROVEEDOR As New Columna("codProveedor", "id_proveedor", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly NOMBRE As New Columna("nombre", "nombre", Columna.TIPO.TEXTO)
    Public Shared ReadOnly TELEFONO As New Columna("telefono", "telefono", Columna.TIPO.TEXTO)
    Public Shared ReadOnly DIRECCION As New Columna("direccion", "direccion", Columna.TIPO.TEXTO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(COD_PROVEEDOR)
        _columnas.Add(NOMBRE)
        _columnas.Add(TELEFONO)
        _columnas.Add(DIRECCION)
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
        Return New Proveedor().GetType()
    End Function

    Public Function buscarLista(ByVal criteria As List(Of Restriccion)) As List(Of Proveedor)
        Dim lista As New List(Of Proveedor)

        For Each obj As Proveedor In buscar(criteria)
            lista.Add(obj)
        Next

        Return lista
    End Function

End Class
