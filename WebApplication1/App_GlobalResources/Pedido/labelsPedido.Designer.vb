'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.269
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option or rebuild the Visual Studio project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "10.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class labelsPedido
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Resources.labelsPedido", Global.System.Reflection.[Assembly].Load("App_GlobalResources"))
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Articulo.
        '''</summary>
        Friend Shared ReadOnly Property articulo() As String
            Get
                Return ResourceManager.GetString("articulo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Al buscar la fechas posibles el sistema presente una lista de fechas posibles, y hora, en la que es posible realizar el trabajo, ofreciendo la libertad de seleccionar la mas conveniente.
        '''</summary>
        Friend Shared ReadOnly Property ayudaBuscarFechas() As String
            Get
                Return ResourceManager.GetString("ayudaBuscarFechas", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to La cantidad del articulo que se desea bordar.
        '''</summary>
        Friend Shared ReadOnly Property ayudaCantidad() As String
            Get
                Return ResourceManager.GetString("ayudaCantidad", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to El cliente es el dueño del pedido que se desea cargar, a este se le facturara una ves terminado el trabajo.
        '''</summary>
        Friend Shared ReadOnly Property ayudaCliente() As String
            Get
                Return ResourceManager.GetString("ayudaCliente", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to El comentario es simplemente un campo para agregar cualquier informacion adicional a los campos presentados.
        '''</summary>
        Friend Shared ReadOnly Property ayudaComentario() As String
            Get
                Return ResourceManager.GetString("ayudaComentario", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to El diseño, junto con el tipo de prenda, representa el articulo que se desea bordar, de aqui se desprendes los tiempos de realizacion y precio.
        '''</summary>
        Friend Shared ReadOnly Property ayudaDiseño() As String
            Get
                Return ResourceManager.GetString("ayudaDiseño", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to La fecha indica el dia en el que se deberan tener el material y desde la cual se dara el turno para realzar el trabajo.
        '''</summary>
        Friend Shared ReadOnly Property ayudaFecha() As String
            Get
                Return ResourceManager.GetString("ayudaFecha", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Una ves cargados todos los trabajos que componen el pedido se grabar el pedido y sus respectivos trabajos.
        '''</summary>
        Friend Shared ReadOnly Property ayudaGrabar() As String
            Get
                Return ResourceManager.GetString("ayudaGrabar", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to La lista de produccion preseta todos los trabajos que componen un pedido, una ves que todos estos trabajos se realicen se pasara al pedido a estado &quot;finalizado&quot; y se generara la factura.
        '''</summary>
        Friend Shared ReadOnly Property ayudaListaProduccion() As String
            Get
                Return ResourceManager.GetString("ayudaListaProduccion", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to El registro seleccionado se cargara en forma definitiva el pedido.
        '''</summary>
        Friend Shared ReadOnly Property ayudaSeleccionarFecha() As String
            Get
                Return ResourceManager.GetString("ayudaSeleccionarFecha", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to El precio, en conjunto con el diseño, componen el articulo que se desea bordad.
        '''</summary>
        Friend Shared ReadOnly Property ayudaTipoPrenda() As String
            Get
                Return ResourceManager.GetString("ayudaTipoPrenda", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Buscar Fechas.
        '''</summary>
        Friend Shared ReadOnly Property buscarFechas() As String
            Get
                Return ResourceManager.GetString("buscarFechas", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Cantidad.
        '''</summary>
        Friend Shared ReadOnly Property cantidad() As String
            Get
                Return ResourceManager.GetString("cantidad", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Cliente.
        '''</summary>
        Friend Shared ReadOnly Property cliente() As String
            Get
                Return ResourceManager.GetString("cliente", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Clientes.
        '''</summary>
        Friend Shared ReadOnly Property clientes() As String
            Get
                Return ResourceManager.GetString("clientes", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Cod..
        '''</summary>
        Friend Shared ReadOnly Property codPedido() As String
            Get
                Return ResourceManager.GetString("codPedido", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Cod..
        '''</summary>
        Friend Shared ReadOnly Property codProduccion() As String
            Get
                Return ResourceManager.GetString("codProduccion", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Comentario.
        '''</summary>
        Friend Shared ReadOnly Property comentario() As String
            Get
                Return ResourceManager.GetString("comentario", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to creacion Trabajos.
        '''</summary>
        Friend Shared ReadOnly Property crearTrabajo() As String
            Get
                Return ResourceManager.GetString("crearTrabajo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Datos Pedido.
        '''</summary>
        Friend Shared ReadOnly Property datosPedido() As String
            Get
                Return ResourceManager.GetString("datosPedido", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Estados.
        '''</summary>
        Friend Shared ReadOnly Property estado() As String
            Get
                Return ResourceManager.GetString("estado", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Estado.
        '''</summary>
        Friend Shared ReadOnly Property estadoActual() As String
            Get
                Return ResourceManager.GetString("estadoActual", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Fecha turno.
        '''</summary>
        Friend Shared ReadOnly Property fecha() As String
            Get
                Return ResourceManager.GetString("fecha", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Fecha dsd. Final.
        '''</summary>
        Friend Shared ReadOnly Property fechaDsdFinal() As String
            Get
                Return ResourceManager.GetString("fechaDsdFinal", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Fecha dsd. Inicio.
        '''</summary>
        Friend Shared ReadOnly Property fechaDsdInicio() As String
            Get
                Return ResourceManager.GetString("fechaDsdInicio", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Fecha Final.
        '''</summary>
        Friend Shared ReadOnly Property fechaFinal() As String
            Get
                Return ResourceManager.GetString("fechaFinal", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Fecha hsta. Final.
        '''</summary>
        Friend Shared ReadOnly Property fechaHstFinal() As String
            Get
                Return ResourceManager.GetString("fechaHstFinal", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Fecha hsta. Inicio.
        '''</summary>
        Friend Shared ReadOnly Property fechaHstInicio() As String
            Get
                Return ResourceManager.GetString("fechaHstInicio", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Fecha Inicio.
        '''</summary>
        Friend Shared ReadOnly Property fechaInicio() As String
            Get
                Return ResourceManager.GetString("fechaInicio", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Crear Pedido.
        '''</summary>
        Friend Shared ReadOnly Property labelTituloCreacion() As String
            Get
                Return ResourceManager.GetString("labelTituloCreacion", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Detalle Pedido.
        '''</summary>
        Friend Shared ReadOnly Property labelTituloDetalle() As String
            Get
                Return ResourceManager.GetString("labelTituloDetalle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Busqueda Pedidos.
        '''</summary>
        Friend Shared ReadOnly Property labelTituloLista() As String
            Get
                Return ResourceManager.GetString("labelTituloLista", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Lista trabajos.
        '''</summary>
        Friend Shared ReadOnly Property listaProduccion() As String
            Get
                Return ResourceManager.GetString("listaProduccion", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Maquina.
        '''</summary>
        Friend Shared ReadOnly Property maquina() As String
            Get
                Return ResourceManager.GetString("maquina", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Realizacion.
        '''</summary>
        Friend Shared ReadOnly Property porcentajeRealizacion() As String
            Get
                Return ResourceManager.GetString("porcentajeRealizacion", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Posibles Fechas.
        '''</summary>
        Friend Shared ReadOnly Property posiblesFechas() As String
            Get
                Return ResourceManager.GetString("posiblesFechas", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to No existe articulo para la combinacion diseño prenda.
        '''</summary>
        Friend Shared ReadOnly Property sinArticulo() As String
            Get
                Return ResourceManager.GetString("sinArticulo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Trabajos.
        '''</summary>
        Friend Shared ReadOnly Property trabajos() As String
            Get
                Return ResourceManager.GetString("trabajos", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Utilizacion.
        '''</summary>
        Friend Shared ReadOnly Property utilizacion() As String
            Get
                Return ResourceManager.GetString("utilizacion", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
