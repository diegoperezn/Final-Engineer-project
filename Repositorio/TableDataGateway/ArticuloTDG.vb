Public Class ArticuloTDG
    Inherits TableDataGateway

    Public Shared NOMBRE_TABLA As String = "Articulos"

    Private Const TABLA_LISTA_PRECIOS As String = "lista_precios"

    Public Shared ReadOnly COD_ARTICULO As New Columna("codArticulo", "cod_articulo", Columna.TIPO.NUMERICO, True)

    Public Shared ReadOnly TIPO_PRENDA As New Columna("tipoPrenda", "tipoPrendaID", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("tipoPrenda", "tipo_prenda", Columna.TIPO.NUMERICO, True)))
    Public Shared ReadOnly DISEÑO As New Columna("diseño", "diseñoID", Columna.TIPO.MANY_TO_ONE, New Join(New Columna("idDiseño", "cod_diseño", Columna.TIPO.NUMERICO, True)))
    Public Shared ReadOnly COMENTARIO As New Columna("comentario", Columna.TIPO.TEXTO)
    Public Shared ReadOnly PRECIO_ACTUAL As New Columna("precioActual", Columna.TIPO.DOUBLE)

    Public Shared ReadOnly PRODUCCION_POR_HORA As New Columna("produccion", Columna.TIPO.NUMERICO)

    Public Shared ReadOnly BORRADO As New Columna("borrado", Columna.TIPO.BOOLEANO)

    Public Shared ReadOnly HISTORICO_PRECIOS As New Columna("listaPrecios", Columna.TIPO.ONE_TO_MANY, New Join(ListaPreciosTDG.NRO_PRECIO, ListaPreciosTDG.NOMBRE_TABLA, True), True)

    Private _columnas As New List(Of Columna)

    Public Sub New(ByVal dao As DataAccesObject)
        Me.dao = dao
        _columnas.Add(COD_ARTICULO)
        _columnas.Add(TIPO_PRENDA)
        _columnas.Add(DISEÑO)
        _columnas.Add(COMENTARIO)
        _columnas.Add(PRODUCCION_POR_HORA)
        _columnas.Add(PRECIO_ACTUAL)
        _columnas.Add(HISTORICO_PRECIOS)
        _columnas.Add(BORRADO)
    End Sub

    Protected Overrides ReadOnly Property columnas As System.Collections.Generic.List(Of Columna)
        Get
            Return _columnas
        End Get
    End Property

    Protected Overrides Function getTipoObjeto() As System.Type
        Return GetType(Articulo)
    End Function

    Protected Overrides ReadOnly Property tabla As String
        Get
            Return NOMBRE_TABLA
        End Get
    End Property

    Function buscarArticulos(ByVal criteria As List(Of Restriccion)) As List(Of Articulo)
        Dim lista As New List(Of Articulo)

        For Each elemento As Articulo In buscar(criteria)
            lista.Add(elemento)
        Next

        Return lista
    End Function

    Function obtenerIdsArticulosFrecuentes(ByVal idCliente As Long) As List(Of Articulo)
        Dim consulta As New String("select top 3 pr.cod_articulo as idArticulo, SUM(pr.cantidad) as cantidad " _
                                + " from produccion pr, Pedido pe " _
                                  + " where(pe.cod_pedido = pr.cod_pedido) " _
                                    + " AND pe.id_cliente = " + idCliente.ToString _
                                + " group by pr.cod_articulo " _
                                + " order by cantidad desc")

        Dim lista As New List(Of Articulo)

        For Each row As DataRow In dao.ejecutarConsulta(consulta).Tables(0).Rows
            lista.Add(New Articulo(row(0)))
        Next

        Return lista
    End Function

End Class
