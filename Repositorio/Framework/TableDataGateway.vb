Imports Dominio
Imports System.Globalization
Imports System.Text.RegularExpressions

Public MustInherit Class TableDataGateway

    Protected MustOverride ReadOnly Property tabla() As String
    Protected MustOverride ReadOnly Property columnas() As List(Of Columna)
    Protected MustOverride Function getTipoObjeto() As Type

    Protected dao As DataAccesObject

    Protected Function buscar(ByVal criteria As List(Of Restriccion)) As List(Of Object)
        Dim dateSet As DataSet = dao.ejecutarConsulta(createSelect(criteria))
        Return crearObjetos(dateSet)
    End Function

    Public Function buscarUnico(ByVal condicion As Restriccion) As Object
        Dim criterio As New List(Of Restriccion)
        criterio.Add(condicion)
        Return buscarUnico(criterio)
    End Function

    Public Function buscarUnico(ByVal criteria As List(Of Restriccion)) As Object
        Dim resultado As List(Of Object) = buscar(criteria)
        If resultado.Count > 1 Then
            Throw New Exception("Consulta con mas de un resultado")
        ElseIf resultado.Count = 0 Then
            Return Nothing
        End If
        Return resultado(0)
    End Function

    Public Sub actualizar(ByVal objeto As Object)
        Dim actualizacion As String = "UPDATE " + tabla + " SET "
        Dim where As String = " WHERE "
        Dim dependencia As String = ""

        For Each columna As Columna In columnas
            If columna.tipoColuman = columna.TIPO.MANY_TO_MANY Or columna.tipoColuman = columna.TIPO.ONE_TO_MANY Then
                If columna.esDuenioRelacion Then
                    dependencia += actualizarDependencia(columna, objeto)
                End If
            Else
                Dim valor As String = getValorObjeto(objeto, columna)
                Dim nombreColoumna As String = columna.columna + "="


                If columna.esIdentidad Then
                    where += nombreColoumna + agregarVariableConsulta(columna, valor, True)
                Else
                    If Not columna.tipoColuman = columna.TIPO.ONE_TO_ONE Then
                        actualizacion += nombreColoumna + agregarVariableConsulta(columna, valor)
                    End If
                End If
            End If
        Next

        Dim sentencia As String = actualizacion.Substring(0, actualizacion.Length - 2) + where.Substring(0, where.Length - 4)

        dao.saveOrUpdate(sentencia + "; " + dependencia)
    End Sub

    Public Sub grabar(ByRef objeto As Object)
        'If esObjetoNuevo(objeto) Then
        cargarId(objeto)

        Dim consulta As String = "INSERT INTO " + tabla
        Dim campos As String = " ("
        Dim valores As String = ") VALUES ("
        Dim dependencias As String = ""

        For Each columna As Columna In columnas
            ' Si verifica el tipo de la relacion para ver si es necesario insertar un registro en otra tabla
            If columna.tipoColuman = columna.TIPO.MANY_TO_MANY Or columna.tipoColuman = columna.TIPO.ONE_TO_MANY Then
                If columna.esDuenioRelacion Then
                    dependencias += actualizarDependencia(columna, objeto)
                End If
            Else
                Dim value As String = getValorObjeto(objeto, columna)

                valores = valores + agregarVariableConsulta(columna, value)
                campos = campos + columna.columna + ", "
            End If
        Next

        consulta = consulta + campos.Substring(0, campos.Length - 2) + valores.Substring(0, valores.Length - 2) + "); "
        If Not String.IsNullOrEmpty(dependencias) Then
            consulta += dependencias
        End If

        dao.saveOrUpdate(consulta)
        'Else

        'End If

    End Sub

    Public Overridable Sub borrar(ByVal objeto As Object)
        Dim consulta As String = "DELETE " + tabla + " WHERE "
        Dim dependencias As String = ""

        For Each columna As Columna In columnas
            If columna.esIdentidad Then
                consulta = consulta + columna.columna + "="
                Dim valor As String = getValorObjeto(objeto, columna)
                consulta = consulta + agregarVariableConsulta(columna, valor, True)
            End If
            If columna.tipoColuman = columna.TIPO.MANY_TO_MANY Then
                dependencias += actualizarDependencias(columna, objeto, False)
            End If
        Next

        If Not String.IsNullOrEmpty(dependencias) Then
            consulta = dependencias + ";" + consulta
        End If

        dao.saveOrUpdate(consulta.Substring(0, consulta.Length - 4))
    End Sub

    ' Metodo encargado de realizar la consulta a partir de una lista de restrucciones 
    Protected Function createSelect(ByVal criterios As List(Of Restriccion)) As String
        Dim consulta As New String("select * from " + tabla)
        Dim where As New String(" WHERE ")
        Dim subSelects As New String(" ")
        ' Acumulador del los joins de la consulta
        Dim join As New String(" JOIN ")

        ' Agrego las restricciones default de la tabla. Ej= borrado=false
        agregarRestriccionesGenerales(criterios)

        If criterios IsNot Nothing Then
            Dim tieneJoin As Boolean = False
            Dim tieneCondiciones As Boolean = False

            If criterios.Count > 0 Then
                ' Itero la lista de restricciones 
                For Each restriccion As Restriccion In criterios
                    Dim columna As Columna = restriccion.campo

                    ' Extraigo el bloque de codigo SQL que representa la restriccion dependiendo del tipo
                    ' del objeto EJ: si el dato es fecha se parsea para realizar la cosulta
                    Dim value As String = agregarVariableConsulta(columna, restriccion.valor, True)

                    Dim rest As New String("")
                    If columna.TIPO.MANY_TO_MANY = columna.tipoColuman Or columna.tipoColuman = columna.TIPO.ONE_TO_MANY Then
                        ' Verifico si la tabla no esta ya joinada
                        If Not join.Contains(columna.join.tabla) Then
                            ' Si la columna es del tipo relacion se agrega el join
                            ' si es la primera ves se carga el flag en true para en las posteriores appendear el siguiente join
                            If tieneJoin Then
                                join += " JOIN "
                            Else
                                tieneJoin = True
                            End If

                            ' se agrega el join a la tabla especificada en en el objeto join de la columna
                            ' agregando como alias el nombre de la columna
                            join += columna.join.tabla + " AS " + columna.nombre + " ON "
                            For Each col As Columna In columnaId()
                                join += tabla + "." + col.columna + "=" + columna.nombre + "." + col.columna
                            Next
                        End If

                        ' Se agrega a la seccion del las condiciones la condicion que se debe realizar a las tablas joinadas
                        agregarRestriccionSegunTipo(where, columna, restriccion, value, True)
                    Else
                        ' si la propiedad existe en la misma tabla simplemente se agrega la restriccion
                        tieneCondiciones = True
                        agregarRestriccionSegunTipo(where, columna, restriccion, value, False)
                    End If
                Next

                ' Si tiene join se agrega a la base de la consulta
                If tieneJoin Then
                    consulta += join
                End If

                ' Se le agrega la seccion de las condiciones sacando el ultimo 'AND '
                where = where.Substring(0, where.Length - 4)
                consulta += where

            End If
        End If

        ' Se crean los subselect de la 
        subSelects = creaSubSelect()

        Return consulta + subSelects
    End Function

    Private Sub agregarRestriccionSegunTipo(ByRef where As String, ByVal columna As Columna, ByVal restriccion As Restriccion,
                                            ByVal value As String, ByVal isJoin As Boolean)
        Dim columnaBase As New String("")

        If isJoin Then
            columnaBase = columna.nombre + "." + columna.join.columna.columna
        Else
            columnaBase = " " + tabla + "." + columna.columna
        End If

        If restriccion.CONDICION_BETWEEN = restriccion.condicion Or restriccion.CONDICION_LIKE = restriccion.condicion Then
            Dim MatchObj As Match = Regex.Match(value.Replace("'", "").Trim, "^(.*?)\s((?:AND)|,)\s*$")
            where += columnaBase + restriccion.condicion.Replace("value", MatchObj.Groups(1).Value) + MatchObj.Groups(2).Value + " "
        ElseIf restriccion.CONDICION_NULL = restriccion.condicion Then
            Dim MatchObj As Match = Regex.Match(value.Replace("'", "").Trim, "^(.*?)\s((?:AND)|,)\s*$")
            If restriccion.valor = True Then
                where += columnaBase + " IS " + restriccion.condicion + MatchObj.Groups(2).Value + " "
            Else
                where += columnaBase + " IS NOT " + restriccion.condicion + MatchObj.Groups(2).Value + " "
            End If
        Else
            where += columnaBase + restriccion.condicion.Replace("value", value)
        End If
    End Sub

    Private Function crearObjetos(ByVal dataSet As DataSet) As List(Of Object)
        Dim resultado As New List(Of Object)

        crearRelaciones(dataSet)
        If Not dataSet.Tables.Count = 0 Then
            For Each row As DataRow In dataSet.Tables(tabla).Rows
                Dim objeto As Object = Activator.CreateInstance(getTipoObjeto())
                For Each col As Columna In columnas
                    cargarPropiedad(objeto, col, row, dataSet)
                Next
                resultado.Add(objeto)
            Next
        End If
        Return resultado
    End Function

    Private Function agregarVariableConsulta(ByVal columna As Columna, ByVal value As String)
        Return agregarVariableConsulta(columna, value, False)
    End Function

    ' Metodo que se encarga de crear la sql para la consulta dependiendo del tipo de dato que se guarda en la columna
    Private Function agregarVariableConsulta(ByVal columnaSeleccionada As Columna, ByVal value As String, ByVal isSelect As Boolean) As String
        Dim text As String
        If Columna.TIPO.TEXTO = columnaSeleccionada.tipoColuman Then
            text = "'" + value + "'"
        ElseIf Columna.TIPO.BOOLEANO = columnaSeleccionada.tipoColuman Then
            If value Then
                text = "1 "
            Else
                text = "0 "
            End If
        ElseIf Columna.TIPO.DOUBLE = columnaSeleccionada.tipoColuman Then
            text = value.Replace(",", ".")
        ElseIf Columna.TIPO.FECHA = columnaSeleccionada.tipoColuman Then
            If String.IsNullOrEmpty(value) OrElse value.Equals("NULL") Then
                text = " NULL "
            Else
                Dim fecha As DateTime = Date.Parse(value)
                text = " CAST('" + fecha.ToString("dd/MM/yyyy HH:mm:ss.fff") + "'  AS DateTime)"
            End If
        Else
            If value IsNot Nothing Then
                text = value.ToString + " "
            End If
        End If

        If isSelect Then
            text = text + " AND "
        Else
            text = text + ", "
        End If

        Return text
    End Function

    Protected Overridable Function getValorObjeto(ByVal objeto As Object, ByVal col As Columna) As String
        Dim valor As String = "NULL"
        Dim propiedad As Reflection.PropertyInfo = objeto.GetType.GetProperty(col.nombre)
        If Columna.TIPO.MANY_TO_ONE = col.tipoColuman Then
            Dim dependencia As Object = propiedad.GetValue(objeto, Nothing)
            If dependencia IsNot Nothing Then
                Dim propiedadDependencia As Reflection.PropertyInfo = dependencia.GetType.GetProperty(col.join.columna.nombre)
                valor = propiedadDependencia.GetValue(dependencia, Nothing)
            End If
        ElseIf Columna.TIPO.FECHA = col.tipoColuman Then
            Dim fechaHora As DateTime = CType(propiedad.GetValue(objeto, Nothing), DateTime)
            If Not fechaHora.Year = 1 Then
                valor = fechaHora.ToString("dd/MM/yyyy HH:mm:ss.fff")
            End If
        Else
            valor = propiedad.GetValue(objeto, Nothing)
        End If

        Return valor
    End Function

    Private Function columnaId() As List(Of Columna)
        Dim ids As New List(Of Columna)
        For Each col As Columna In columnas
            If col.esIdentidad Then
                ids.Add(col)
            End If
        Next

        Return ids
    End Function

    Private Sub crearRelaciones(ByRef dataSet As DataSet)
        For Each col As Columna In columnas
            If col.tipoColuman = Columna.TIPO.MANY_TO_MANY Or col.tipoColuman = Columna.TIPO.ONE_TO_MANY Then
                crearRelacion(dataSet, col)
            End If
        Next
    End Sub

    Protected Overridable Sub crearRelacion(ByRef dataset As DataSet, ByVal col As Columna)
        If dataset.Tables(col.join.tabla) IsNot Nothing Then
            Dim parentColumns As New List(Of DataColumn)
            Dim childColumns As New List(Of DataColumn)

            For Each colId As Columna In columnaId()
                parentColumns.Add(dataset.Tables(tabla).Columns(colId.columna))
                childColumns.Add(dataset.Tables(col.join.tabla).Columns(colId.columna))
            Next

            Dim relacion As New DataRelation(col.nombre, parentColumns.ToArray, childColumns.ToArray, False)
            dataset.Relations.Add(relacion)
        End If
    End Sub

    Private Function actualizarDependencia(ByVal columna As Columna, ByVal objeto As Object) As String
        Return actualizarDependencias(columna, objeto, True)
    End Function

    ' Metodo encargado de grabar la dependencia de los objetos que se desea grabar, siempre que en la columna se haya 
    ' marcado como el encargado de grabar la relacion como Columna.esDuenioRelacion=true
    Protected Overridable Function actualizarDependencias(ByVal columna As Columna, ByVal objeto As Object, ByVal actualizacion As Boolean) As String
        Dim sentencia As New String("")

        If columna.tipoColuman = columna.TIPO.MANY_TO_MANY Then
            ' Si la relacion es muchos a muchos se borran todas la relacion en la tabla relacional 
            ' donde esta el id de el objeto padre
            sentencia += "DELETE " + columna.join.tabla + " where "
            For Each col As Columna In columnaId()
                Dim pi As Reflection.PropertyInfo = objeto.GetType.GetProperty(col.nombre)
                sentencia += col.columna + "=" + agregarVariableConsulta(col, pi.GetValue(objeto, Nothing), True)
            Next
            sentencia = sentencia.Substring(0, sentencia.Length - 4) + "; "

            If actualizacion Then
                Dim listaPi As Reflection.PropertyInfo = objeto.GetType.GetProperty(columna.nombre)
                Dim lista As Object = listaPi.GetValue(objeto, Nothing)

                If lista IsNot Nothing Then
                    ' Si bien la relacion many_to_many significa que el objeto principal tiene una lista del
                    ' objeto secundario existen casos donde esto no es asi y el objeto principal contiene una instacia
                    ' del secundario. En este caso valido el tipo de propiedad para saber si tengo que registrar una o
                    ' mas de una relacion en la tabla intermedia
                    If lista.GetType.IsGenericType AndAlso lista.GetType.GetGenericTypeDefinition Is GetType(List(Of )) Then
                        For Each dependencia As Object In lista
                            crearInsertParaTablaRelacional(columna, sentencia, dependencia, objeto)
                        Next
                    Else
                        crearInsertParaTablaRelacional(columna, sentencia, lista, objeto)
                    End If
                End If
            End If
        ElseIf columna.tipoColuman = columna.TIPO.ONE_TO_MANY Then
            If actualizacion Then
                sentencia += "UPDATE " + columna.join.tabla + " SET borrado=1 WHERE "
                For Each col As Columna In columnaId()
                    Dim pi As Reflection.PropertyInfo = objeto.GetType.GetProperty(col.nombre)
                    sentencia += col.columna + "=" + agregarVariableConsulta(col, pi.GetValue(objeto, Nothing), True)
                Next
                sentencia = sentencia.Substring(0, sentencia.Length - 4) + "; "
            End If
        End If

        Return sentencia
    End Function

    ' Crea el subselect para las entidades que que componen el objeto que se esta buscando
    Private Function creaSubSelect() As String
        Dim subSelect As New String("")

        For Each col As Columna In columnas
            ' Recorro todas las columnas y en caso que la relacion sea de uno a muchos o muchos a muchos 
            ' realizo la consulta a la tabla de la relacion para despues unirlos con un data relation en la dataset
            If col.tipoColuman = Columna.TIPO.MANY_TO_MANY Or col.tipoColuman = Columna.TIPO.ONE_TO_MANY Then
                subSelect += "; select * from " + col.join.tabla
                ' Si los objetos que cargo pertenecen solo al objeto que se esta cargando verifico que no se haya borrado
                If col.tipoColuman = Columna.TIPO.ONE_TO_MANY Then
                    subSelect += " WHERE borrado = 0"
                End If
            End If
        Next

        Return subSelect
    End Function

    ' Metodo encargado de cargar el id de la entidad que se desea grabar, siempre que el 
    ' id se encremente al maximo existente en la base, en caso que el id se calcule de otr manera este metodo
    ' debe ser sobreescrito en la clase que lo extienda
    Protected Overridable Sub cargarId(ByVal objeto As Object)
        Dim colId As List(Of Columna) = columnaId()
        If colId.Count = 1 Then
            Dim pi As Reflection.PropertyInfo = objeto.GetType.GetProperty(colId(0).nombre)
            If pi.GetValue(objeto, Nothing) Is Nothing Or pi.GetValue(objeto, Nothing) = 0 Then
                Dim resultado As Long = dao.consultarValor("SELECT  ISNULL(MAX(" + colId(0).columna + " + 1),1) from " + tabla)
                pi.SetValue(objeto, resultado, Nothing)
            End If
        End If

    End Sub

    ' Metodo que debe implementarse en la clase que extiende para agregar restriccion
    ' que se aplicaran a todas las consultas de esta tabla como por ejemplo el borrado 
    ' logico en false 
    Protected Overridable Sub agregarRestriccionesGenerales(ByRef criterios As List(Of Restriccion))

    End Sub

    Protected Sub crearInsertParaTablaRelacional(ByVal columna As Columna, ByRef sentencia As String, ByVal dependencia As Object, ByVal objeto As Object)
        Dim insert As String = " INSERT INTO " + columna.join.tabla + " ( "
        Dim values As String = ") VALUES ( "

        For Each col As Columna In columnaId()
            Dim pic As Reflection.PropertyInfo = objeto.GetType.GetProperty(col.nombre)
            insert += col.columna + ", "
            values += agregarVariableConsulta(col, pic.GetValue(objeto, Nothing))
        Next

        Dim columnadependencia As Columna = columna.join.columna
        Dim pi As Reflection.PropertyInfo = dependencia.GetType.GetProperty(columnadependencia.nombre)
        insert += columnadependencia.columna
        values += agregarVariableConsulta(columnadependencia, pi.GetValue(dependencia, Nothing))

        sentencia += insert + values.Substring(0, values.Length - 2) + "); "
    End Sub

    Protected Overridable Sub cargarPropiedad(ByRef objeto As Object, ByVal col As Columna,
                                              ByVal row As DataRow, ByVal dataset As DataSet)
        Dim pi As Reflection.PropertyInfo = objeto.GetType.GetProperty(col.nombre)
        Dim value As Object = Nothing
        If col.tipoColuman = Columna.TIPO.MANY_TO_ONE Then
            Dim dependencia As Object = Activator.CreateInstance(pi.PropertyType)
            Dim dependenciaPi As Reflection.PropertyInfo = dependencia.GetType.GetProperty(col.join.columna.nombre)
            If Not row(col.columna).GetType.Equals(GetType(System.DBNull)) Then
                dependenciaPi.SetValue(dependencia, row(col.columna), Nothing)
                value = dependencia
            End If
        ElseIf col.tipoColuman = Columna.TIPO.MANY_TO_MANY Or col.tipoColuman = Columna.TIPO.ONE_TO_MANY Then
            If col.join.esPropiedad Then
                Dim lista As Object = Activator.CreateInstance(pi.PropertyType)

                ' Si bien la relaciones many_to_many y one_to_many representan una lista en el objeto
                ' principal del tipo del objeto que lo componen por disposicion de la base puede que en un 
                ' mapeo de este tipo este reflejado por un solo objeto en la dependencia 
                ' Ej: (MovimientoCuentaCliente - Cliente)

                Dim item As Reflection.PropertyInfo = lista.GetType.GetProperty("Item")
                Dim agregar As Reflection.MethodInfo = lista.GetType.GetMethod("Add")

                ' Si la dependencia tiene el metodo item es una lista si no es un objeto de dominio
                If item IsNot Nothing Then
                    Dim tipoElemento As Type = item.PropertyType
                    ' Recorro todos los elementos de la iteracion
                    For Each rowElemento As DataRow In row.GetChildRows(dataset.Relations(col.nombre))
                        ' Creo una instancia por cada uno
                        Dim elemento As Object = Activator.CreateInstance(tipoElemento)

                        ' Obtengo por reflection la propiedad que lo identifica, esta columna/propiedad se setea en la columna
                        ' del join creado en TDG
                        Dim idElemento As Reflection.PropertyInfo = elemento.GetType.GetProperty(col.join.columna.nombre)
                        idElemento.SetValue(elemento, rowElemento(col.join.columna.columna), Nothing)

                        ' Se agrega el objeto a la lista
                        Dim param(0) As Object
                        param(0) = elemento
                        agregar.Invoke(lista, param)
                    Next

                    ' Se carga la lista al objeto valor para cargarse al obejeto principal
                    value = lista
                Else
                    ' En caso que la propidad no sea una lista se obtiene la propiedad que identifica al objeto
                    ' que esta contenido por el objeto principal (propieda nombre de la columna cargada en el join de la columna)
                    Dim idElemento As Reflection.PropertyInfo = lista.GetType.GetProperty(col.join.columna.nombre)
                    ' Se obtine el primer registro de la relacion ya que se supone que en la tabla relacional solo existe
                    ' un objeto con el id del objeto principal
                    If Not row.GetChildRows(dataset.Relations(col.nombre)).Length = 0 Then
                        Dim rowElemento As DataRow = row.GetChildRows(dataset.Relations(col.nombre))(0)
                        idElemento.SetValue(lista, rowElemento(col.join.columna.columna), Nothing)

                        value = lista
                    End If

                End If
            End If
        ElseIf col.tipoColuman = Columna.TIPO.BOOLEANO Then
            If row(col.columna) = 1 Then
                value = True
            Else
                value = False
            End If
        ElseIf col.tipoColuman = Columna.TIPO.FECHA Then
            value = row(col.columna)
            If value.ToString = "" Then
                value = Nothing
            End If
        Else
            value = row(col.columna)
        End If

        If value IsNot Nothing AndAlso GetType(System.DBNull).Equals(value.GetType) Then
            value = Nothing
        End If

        If value IsNot Nothing Then
            pi.SetValue(objeto, value, Nothing)
        End If
    End Sub

    Private Function esObjetoNuevo(ByVal objeto As Object) As Boolean
        Dim colId As List(Of Columna) = columnaId()
        If colId.Count = 1 Then
            Dim pi As Reflection.PropertyInfo = objeto.GetType.GetProperty(colId(0).nombre)
            If pi.GetValue(objeto, Nothing) Is Nothing Or pi.GetValue(objeto, Nothing) = 0 Then
                Return True
            End If
        End If

        Return False
    End Function

End Class
