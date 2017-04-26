Public Class DiseñoInsumoTDG
    Inherits TableDataGateway

    Public Const NOMBRE_TABLA As String = "Diseño_insumos"

    Public Shared ReadOnly DISEÑO As Columna = New Columna("diseño", "cod_diseño", Columna.TIPO.MANY_TO_ONE, True,
                                                           New Join(New Columna("idDiseño", "cod_diseño", Columna.TIPO.NUMERICO, True)))
    Public Shared ReadOnly INSUMO As Columna = New Columna("insumo", "cod_insumo", Columna.TIPO.MANY_TO_ONE, True,
                                                               New Join(New Columna("codInsumo", "cod_insumo", Columna.TIPO.NUMERICO, True)))
    Public Shared ReadOnly CANTIDAD As Columna = New Columna("cantidad", Columna.TIPO.DOUBLE)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(DISEÑO)
        _columnas.Add(INSUMO)
        _columnas.Add(CANTIDAD)
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
        Return GetType(DiseñoInsumo)
    End Function

    Public Function buscarDiseñoInsumoConRestriccion(ByVal restriccion As Restriccion) As List(Of DiseñoInsumo)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(restriccion)
        Return buscarDiseñoInsumo(criteria)
    End Function

    Public Function buscarDiseñoInsumo(ByVal criteria As List(Of Restriccion)) As List(Of DiseñoInsumo)
        Dim lista As New List(Of DiseñoInsumo)

        For Each obj As DiseñoInsumo In buscar(criteria)
            lista.Add(obj)
        Next

        Return lista
    End Function
End Class
