Imports Dominio

Public Class NewsletterTDG
    Inherits TableDataGateway

    Private Shared NOMBRE_TABLA As String = "newsletter"

    Public Shared ReadOnly ID_NEWSLETTER As New Columna("id", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly NEWSLETTER As New Columna("newsletter", Columna.TIPO.TEXTO)
    Public Shared ReadOnly NOMBRE As New Columna("nombre", Columna.TIPO.TEXTO)
    Public Shared ReadOnly ENVIADO As New Columna("enviado", Columna.TIPO.BOOLEANO)


    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(ID_NEWSLETTER)
        _columnas.Add(NEWSLETTER)
        _columnas.Add(NOMBRE)
        _columnas.Add(ENVIADO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return New Newsletter().GetType()
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarNewsletter(ByVal criteria As List(Of Restriccion)) As List(Of Newsletter)
        Dim lista As New List(Of Newsletter)

        For Each elemento As Newsletter In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

End Class
