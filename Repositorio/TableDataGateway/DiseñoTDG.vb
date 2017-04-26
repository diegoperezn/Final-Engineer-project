Public Class DiseñoTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "Diseño"

    Public Shared ReadOnly ID_DISEÑO As New Columna("idDiseño", "cod_diseño", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly NOMBRE As New Columna("nombre", Columna.TIPO.TEXTO)
    Public Shared ReadOnly PUNTADA As New Columna("puntadas", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly ALTO As New Columna("alto", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly ANCHO As New Columna("ancho", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly CLIENTE As New Columna("cliente", "id_cliente", Columna.TIPO.MANY_TO_ONE,
                New Join(New Columna("idCliente", "id_cliente", Columna.TIPO.NUMERICO, True), ClienteTDG.NOMBRE_TABLA, True))
    Public Shared ReadOnly FECHA_REALIZACION As New Columna("fechaRealizacion", Columna.TIPO.FECHA)

    Public Shared ReadOnly HISTORICO_ESTADOS As New Columna("historicoEstados", Columna.TIPO.ONE_TO_MANY,
                                                            New Join(HistoricoEstadosDiseñoTDG.NRO_ESTADO, HistoricoEstadosDiseñoTDG.NOMBRE_TABLA, True), True)
    Public Shared ReadOnly ESTADO_ACTUAL As New Columna("estadoActual", "estadoActual", Columna.TIPO.MANY_TO_ONE,
                                                        New Join(New Columna("estado", Columna.TIPO.NUMERICO, True)))

    Public Shared ReadOnly PATH_IMAGEN As New Columna("pathImagen", Columna.TIPO.TEXTO)
    Public Shared ReadOnly PATH_DETALLE As New Columna("pathDetalle", Columna.TIPO.TEXTO)
    Public Shared ReadOnly PATH_ARCHIVO_EDITABLE As New Columna("pathArchivoEditable", Columna.TIPO.TEXTO)
    Public Shared ReadOnly PATH_ARCHIVO_FINAL As New Columna("pathArchivoFinal", Columna.TIPO.TEXTO)

    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID_DISEÑO)
        _columnas.Add(NOMBRE)
        _columnas.Add(PUNTADA)
        _columnas.Add(ALTO)
        _columnas.Add(ANCHO)
        _columnas.Add(CLIENTE)

        _columnas.Add(HISTORICO_ESTADOS)
        _columnas.Add(ESTADO_ACTUAL)

        _columnas.Add(PATH_IMAGEN)
        _columnas.Add(PATH_DETALLE)
        _columnas.Add(PATH_ARCHIVO_EDITABLE)
        _columnas.Add(PATH_ARCHIVO_FINAL)

        _columnas.Add(BORRADO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New Diseño().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarDiseños(ByVal criteria As List(Of Restriccion)) As List(Of Diseño)
        Dim lista As New List(Of Diseño)

        For Each elemento As Diseño In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
