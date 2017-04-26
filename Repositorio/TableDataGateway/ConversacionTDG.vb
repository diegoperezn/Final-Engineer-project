Public Class ConversacionTDG
    Inherits TableDataGateway

    Private Shared NOMBRE_TABLA As String = "Conversacion"

    Public Shared ReadOnly ID_CONVERSACION As New Columna("id", "id_conversacion", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly REMITENTE As New Columna("remitente", Columna.TIPO.MANY_TO_ONE, New Join(UsuarioTDG.ID_USUARIO), True)
    Public Shared ReadOnly DESTINATARIO As New Columna("destinatario", Columna.TIPO.MANY_TO_ONE, New Join(UsuarioTDG.ID_USUARIO), True)
    Public Shared ReadOnly MENSAJES As New Columna("mensajes", Columna.TIPO.ONE_TO_MANY, New Join(New Columna("id", Columna.TIPO.NUMERICO, True), "mensaje", True), True)


    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID_CONVERSACION)
        _columnas.Add(REMITENTE)
        _columnas.Add(DESTINATARIO)
        _columnas.Add(MENSAJES)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New Conversacion().GetType
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarConversaciones(ByVal criteria As List(Of Restriccion)) As List(Of Conversacion)
        Dim lista As New List(Of Conversacion)

        For Each elemento As Conversacion In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
