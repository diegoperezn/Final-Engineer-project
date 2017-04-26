Public Class MaquinaTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "Maquina"

    Public Const TABLA_MAQUINA_TIPO_PRENDA As String = "JoinMaquinaToTipoPrenda"

    Public Shared ReadOnly COD_MAQUINA As New Columna("codMaquina", "cod_maquina", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly ALTO As New Columna("altoMargen", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly ANCHO As New Columna("anchoMargen", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly CABEZALES As New Columna("cabezales", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly NOMBRE As New Columna("nombre", Columna.TIPO.TEXTO)
    Public Shared ReadOnly VELOCIDAD As New Columna("velocidadPromedio", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly CANTIDAD_COLORES As New Columna("cantidadColores", Columna.TIPO.NUMERICO)

    Public Shared ReadOnly TIPO_PRENDA As New Columna("tiposPrenda", Columna.TIPO.MANY_TO_MANY, New Join(TipoPrendaTDG.TIPO_PRENDA, TABLA_MAQUINA_TIPO_PRENDA, True), True)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(COD_MAQUINA)
        _columnas.Add(ALTO)
        _columnas.Add(ANCHO)
        _columnas.Add(CABEZALES)
        _columnas.Add(NOMBRE)
        _columnas.Add(VELOCIDAD)
        _columnas.Add(CANTIDAD_COLORES)
        _columnas.Add(TIPO_PRENDA)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New Maquina().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarMaquinas(ByVal criteria As List(Of Restriccion)) As List(Of Maquina)
        Dim lista As New List(Of Maquina)

        For Each elemento As Maquina In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
