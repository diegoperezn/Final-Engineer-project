Public Class ListaPreciosTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "lista_precios"

    Public Shared ReadOnly NRO_PRECIO As New Columna("nroLista", "nro_lista", Columna.TIPO.NUMERICO, True)
    Public Shared ReadOnly COD_ARTICULO As New Columna("articulo", "cod_articulo", Columna.TIPO.MANY_TO_ONE, True, New Join(New Columna("codArticulo", "cod_articulo", Columna.TIPO.NUMERICO, True), True))
    Public Shared ReadOnly FECHA_DESDE As New Columna("fechaDesde", Columna.TIPO.FECHA)
    Public Shared ReadOnly FECHA_HASTA As New Columna("fechaHasta", Columna.TIPO.FECHA)
    Public Shared ReadOnly PRECIO As New Columna("precio", Columna.TIPO.DOUBLE)

    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Private _columnas As New List(Of Columna)

    Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(NRO_PRECIO)
        _columnas.Add(COD_ARTICULO)
        _columnas.Add(PRECIO)
        _columnas.Add(FECHA_DESDE)
        _columnas.Add(FECHA_HASTA)

        _columnas.Add(BORRADO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(ListaPrecios)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function cargarListaPrecio(ByVal criteria As List(Of Restriccion)) As List(Of ListaPrecios)
        Dim lista As New List(Of ListaPrecios)

        For Each elemento As ListaPrecios In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

    Protected Overrides Sub cargarId(ByVal objeto As Object)
        Dim precio As ListaPrecios = CType(objeto, ListaPrecios)
        If precio.nroLista = 0 Then
            Dim resultado As Long = dao.consultarValor("SELECT  ISNULL( MAX(" + NRO_PRECIO.columna + " + 1), 1) from " + tabla + _
                                                       " WHERE " + COD_ARTICULO.columna + "=" + precio.articulo.codArticulo.ToString)
            precio.nroLista = resultado
        End If
    End Sub

End Class
