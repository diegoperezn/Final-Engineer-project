Imports Dominio

Public Class Permisos

    ' Permisos Usuarios
    Public Const Creacion_usuarios As String = "creacionUsuarios"
    Public Const Edicion_usuarios As String = "edicionUsuarios"
    Public Const Eliminacion_usuarios As String = "eliminacionUsuarios"
    Public Const Listado_usuarios As String = "listadoUsuarios"
    Public Const detalle_usuarios As String = "detalleUsuarios"

    ' ########## Administracion #############

    ' Permisos Opiniones 
    Public Const listado_opinion As String = "listadoOpinion"
    Public Const detalle_opinion As String = "detalleOpinion"

    ' Permisos Estadisticas 
    Public Const detalleEstadisticas As String = "detalleEstadisticas"

    ' Permisos Newsletter 
    Public Const creacion_newletter As String = "creacionNewletter"
    Public Const edicion_newletter As String = "edicionNewletter"
    Public Const eliminacion_newletter As String = "eliminacionNewletter"
    Public Const listado_newletter As String = "listadoNewletter"
    Public Const detalle_newletter As String = "detalleNewletter"

    ' Permisos Proveedor 
    Public Const creacionProveedor As String = "creacionProveedor"
    Public Const edicionProveedor As String = "edicionProveedor"
    Public Const listadoProveedor As String = "listadoProveedor"
    Public Const detalleProveedor As String = "detalleProveedor"

    ' Permisos Insumo 
    Public Const creacionInsumo As String = "creacionInsumo"
    Public Const edicionInsumo As String = "edicionInsumo"
    Public Const listadoInsumo As String = "listadoInsumo"
    Public Const detalleInsumo As String = "detalleInsumo"

    ' ########## Mensajes #############

    ' Permisos Mensajes
    Public Const mensajes As String = "mensajes"

    ' ########## Finanza #############
    ' Permisos Cuenta Corriente Cliente
    Public Const creacionMovimientoCliente As String = "creacionMovimientoCliente"
    Public Const listadoMovimientoCliente As String = "listadoMovimientoCliente"
    Public Const detalleMovimientoCliente As String = "detalleMovimientoCliente"

    ' Permisos Facturacion
    Public Const listadoFactura As String = "listadoFactura"
    Public Const detalleFactura As String = "detalleFactura"

    ' Permisos Cuenta Corriente Proveedor
    Public Const creacionMovimientoProveedor As String = "creacionMovimientoProveedor"
    Public Const listadoMovimientoProveedor As String = "listadoMovimientoProveedor"
    Public Const detalleMovimientoProveedor As String = "detalleMovimientoProveedor"

    ' Permisos Orden Compra
    Public Const listadoOrdenCompra As String = "listadoOrdenCompra"
    Public Const detalleOrdenCompra As String = "detalleOrdenCompra"

    ' ########## Diseños #############
    Public Const creacionDiseños As String = "creacionDiseños"
    Public Const edicionDiseños As String = "edicionDiseños"
    Public Const detalleDiseños As String = "detalleDiseños"
    Public Const eliminacionDiseños As String = "eliminacionDiseños"
    Public Const listadoDiseños As String = "listadoDiseños"

    ' ########## Pedidos #############
    Public Const creacionPedido As String = "creacionPedido"
    Public Const edicionPedido As String = "edicionPedido"
    Public Const detallePedido As String = "detallePedido"
    Public Const eliminacionPedido As String = "eliminacionPedido"
    Public Const listadoPedido As String = "listadoPedido"

    ' ########## Produccions #############
    Public Const creacionProduccion As String = "creacionProduccion"
    Public Const edicionProduccion As String = "edicionProduccion"
    Public Const detalleProduccion As String = "detalleProduccion"
    Public Const eliminacionProduccion As String = "eliminacionProduccion"
    Public Const listadoProduccion As String = "listadoProduccion"

    ' ########## Articulos #############
    Public Const creacionArticulo As String = "creacionArticulo"
    Public Const edicionArticulo As String = "edicionArticulo"
    Public Const detalleArticulo As String = "detalleArticulo"
    Public Const eliminacionArticulo As String = "eliminacionArticulo"
    Public Const listadoArticulo As String = "listadoArticulo"

    ' ########## Otros #############
    Public Const CreacionFamilias As String = "creacionFamilias"
    Public Const EdicionFamilias As String = "edicionFamilias"
    Public Const EliminacionFamilias As String = "eliminacionFamilias"
    Public Const ListadoFamilias As String = "listadoFamilias"
    Public Const detalleFamilias As String = "detalleFamilias"

    Public Const creacion_maquinas As String = "creacionMaquinas"
    Public Const listado_maquinas As String = "listadoMaquinas"
    Public Const detalle_maquinas As String = "detalleMaquinas"
    Public Const Edicion_maquinas As String = "edicionMaquinas"
    Public Const Eliminacion_maquinas As String = "eliminacionMaquinas"

    Public Shared Function permisosAdministracionUsuarios() As List(Of String)
        Dim permisos As New List(Of String)
        permisos.Add(Creacion_usuarios)
        permisos.Add(Edicion_usuarios)
        permisos.Add(Eliminacion_usuarios)
        permisos.Add(Listado_usuarios)

        Return permisos
    End Function

    Shared Function permisosDiseños() As List(Of String)
        Dim permisos As New List(Of String)
        permisos.Add(creacionDiseños)
        permisos.Add(listadoDiseños)

        Return permisos
    End Function

    Shared Function permisosFacturas() As List(Of String)
        Dim permisos As New List(Of String)

        permisos.Add(creacionMovimientoCliente)
        permisos.Add(listadoMovimientoCliente)
        permisos.Add(listadoFactura)
        permisos.Add(creacionMovimientoProveedor)
        permisos.Add(listadoMovimientoProveedor)
        permisos.Add(listadoOrdenCompra)

        Return permisos
    End Function

    Shared Function permisosPedidos() As List(Of String)
        Dim permisos As New List(Of String)
        permisos.Add(creacionPedido)
        permisos.Add(listadoPedido)

        Return permisos
    End Function


    Shared Function permisosUsuario() As List(Of String)
        Dim permisos As New List(Of String)
        permisos.Add(CreacionFamilias)
        permisos.Add(ListadoFamilias)
        permisos.Add(Creacion_usuarios)
        permisos.Add(Listado_usuarios)

        Return permisos
    End Function

    Shared Function permisosMaquina() As List(Of String)
        Dim permisos As New List(Of String)
        permisos.Add(creacion_maquinas)
        permisos.Add(listado_maquinas)

        Return permisos
    End Function

    Shared Function permisosProveedor() As List(Of String)
        Dim permisos As New List(Of String)
        permisos.Add(creacionProveedor)
        permisos.Add(listadoProveedor)

        Return permisos
    End Function

    Shared Function permisosAdministracion() As List(Of String)
        Dim permisos As New List(Of String)
        permisos.Add(detalleEstadisticas)
        permisos.Add(listado_opinion)
        permisos.Add(listado_newletter)

        Return permisos
    End Function

End Class
