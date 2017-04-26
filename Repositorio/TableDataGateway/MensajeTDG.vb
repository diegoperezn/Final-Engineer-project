Public Class MensajeTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "Mensaje"

    Public Shared ReadOnly ID_MENSAJE As New Columna("id", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly TIPO_MENSAJE As New Columna("tipoMensaje", Columna.TIPO.NUMERICO)
    Public Shared ReadOnly MENSAJE As New Columna("mensaje", Columna.TIPO.TEXTO)
    Public Shared ReadOnly FECHA As New Columna("fecha", Columna.TIPO.FECHA)
    Public Shared ReadOnly LEIDO As New Columna("leido", Columna.TIPO.BOOLEANO)
    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)
    Public Shared ReadOnly CONVERSACION As New Columna("conversacion", "id_conversacion", Columna.TIPO.MANY_TO_ONE, New Join(ConversacionTDG.ID_CONVERSACION, True))

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID_MENSAJE)
        _columnas.Add(TIPO_MENSAJE)
        _columnas.Add(FECHA)
        _columnas.Add(MENSAJE)
        _columnas.Add(LEIDO)
        _columnas.Add(BORRADO)
        _columnas.Add(CONVERSACION)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New Mensaje().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarMensajes(ByVal criteria As List(Of Restriccion)) As List(Of Mensaje)
        Dim lista As New List(Of Mensaje)

        For Each elemento As Mensaje In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
