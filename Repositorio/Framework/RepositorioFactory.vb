Public Class RepositorioFactory

    Private Shared _dao As New DataAccesObject()

    Private Shared _tipoPrendaTDG As New TipoPrendaTDG(dao)
    Private Shared _usuarioTDG As New UsuarioTDG(dao)
    Private Shared _tipoPedidoTDG As New TipoPedidoTDG(dao)
    Private Shared _tipoMovimientoTDG As New TipoMovimientoTDG(dao)
    Private Shared _tipoInsumoTDG As New TipoInsumoTDG(dao)
    Private Shared _proveedorTDG As New ProveedorTDG(dao)
    Private Shared _produccionOperadorTDG As New ProduccionOperadorTDG(dao)
    Private Shared _familiaTDG As New FamiliaTDG(dao)
    Private Shared _patenteTDG As New PatenteTDG(dao)
    Private Shared _opinioTDG As New OpinionTDG(dao)
    Private Shared _clienteTDG As New ClienteTDG(dao)
    Private Shared _newsletterTDG As New NewsletterTDG(dao)
    Private Shared _mensajeTDG As New MensajeTDG(dao)
    Private Shared _conversacionTDG As New ConversacionTDG(dao)
    Private Shared _diseñoTDG As New DiseñoTDG(dao)
    Private Shared _movimientoCuentaClienteTDG As New MovimientoCuentaClienteTDG(dao)
    Private Shared _movimientoCuentaProveedorTDG As New MovimientoCuentaProveedorTDG(dao)
    Private Shared _historicoEstadosDiseñoTDG As New HistoricoEstadosDiseñoTDG(dao)
    Private Shared _historicoEstadosProduccionTDG As New HistoricoEstadosProduccionTDG(dao)
    Private Shared _produccionTDG As New ProduccionTDG(dao)
    Private Shared _historicoEstadosPedidoTDG As New HistoricoEstadosPedidoTDG(dao)
    Private Shared _pedidoTDG As New PedidoTDG(dao)
    Private Shared _maquinaTDG As New MaquinaTDG(dao)
    Private Shared _facturaTDG As New FacturaTDG(dao)
    Private Shared _lineaFacturaTDG As New LineaFacturaTDG(dao)
    Private Shared _ordenDeCompraTDG As New OrdenDeCompraTDG(dao)
    Private Shared _lineaOrdenDeCompraTDG As New LineaOrdenDeCompraTDG(dao)
    Private Shared _articuloTDG As New ArticuloTDG(dao)
    Private Shared _colorTDG As New ColorTDG(dao)
    Private Shared _insumoTDG As New InsumoTDG(dao)
    Private Shared _listaPreciosTDG As New ListaPreciosTDG(dao)
    Private Shared _diseñoInsumoTDG As New DiseñoInsumoTDG(dao)
    Private Shared _operadorTDG As New OperadorTDG(dao)
    Private Shared _estadoPedidoTDG As New EstadoPedidoTDG(dao)
    Private Shared _estadoTrabajoTDG As New EstadoTrabajoTDG(dao)
    Private Shared _cuentaTDG As New CuentaTDG(dao)
    Private Shared _movimientoStockTDG As New MovimientoStockTDG(dao)
    Private Shared _encuestaTDG As New EncuestaTDG(dao)
    Private Shared _estadoDiseñoTDG As New EstadoDiseñoTDG(dao)

    Private Shared _patenteRepositorio As New PatenteRepositorio(_patenteTDG)
    Private Shared _tipoPrendaRepostirio As New TipoPrendaRepositorio(_tipoPrendaTDG)
    Private Shared _materialesRepositorio As New MaterialesRepositorio(_colorTDG, _tipoInsumoTDG)
    Private Shared _maquinaRepositorio As New MaquinaRepositorio(_maquinaTDG, _tipoPrendaTDG)
    Private Shared _familiaRepositorio As New FamiliaRepositorio(_familiaTDG, _patenteRepositorio)
    Private Shared _usuarioRepositorio As New UsuarioRepositorio(_usuarioTDG, _familiaRepositorio, _patenteRepositorio, _clienteTDG)
    Private Shared _clienteRepositorio As New ClienteRepositorio(_clienteTDG, _diseñoTDG, _usuarioRepositorio, _facturaTDG, _pedidoTDG, _movimientoCuentaClienteTDG)
    Private Shared _opinionRepositorio As New OpinionRepositorio(_opinioTDG)
    Private Shared _newsletterRepositorio As New NewsletterRepositorio(_newsletterTDG)
    Private Shared _mensajeRepositorio As New MensajeRepositorio(_mensajeTDG)
    Private Shared _conversacionRepositorio As New ConversacionRepositorio(_mensajeRepositorio, _conversacionTDG, _usuarioTDG)
    Private Shared _diseñoRepositorio As New DiseñoRepositorio(_diseñoTDG, _clienteTDG, _usuarioTDG, _diseñoInsumoTDG, _historicoEstadosDiseñoTDG, _estadoDiseñoTDG)
    Private Shared _MovimientoCuentaClienteRepositorio As New MovimientoCuentaClienteRepositorio(_movimientoCuentaClienteTDG, _clienteRepositorio, _tipoMovimientoTDG, _cuentaTDG, _facturaTDG)
    Private Shared _proveedorRepositorio As New ProveedorRepositorio(_proveedorTDG, _ordenDeCompraTDG)
    Private Shared _movimientoCuentaProveedorRepositorio As New MovimientoCuentaProveedorRepositorio(_movimientoCuentaProveedorTDG, _proveedorRepositorio, _tipoMovimientoTDG, _cuentaTDG, _ordenDeCompraTDG)
    Private Shared _pedidoRepositorio As New PedidoRepositorio(_pedidoTDG, _historicoEstadosPedidoTDG, _tipoPedidoTDG, _produccionTDG, _clienteTDG, _estadoPedidoTDG)
    Private Shared _articuloRepositorio As New ArticuloRepositorio(_articuloTDG, _listaPreciosTDG, _tipoPrendaTDG, _diseñoTDG)
    Private Shared _lineaFacturaRepostorio As New LineaFacturaRepostorio(_lineaFacturaTDG, _articuloTDG)
    Private Shared _lineaOrdenCompraRepositorio As New LineaOrdenCompraRepositorio(_lineaOrdenDeCompraTDG, _insumoTDG)
    Private Shared _facturaRepositorio As New FacturaRepositorio(_facturaTDG, _lineaFacturaTDG, _clienteTDG, _lineaFacturaRepostorio, _movimientoCuentaClienteTDG, _usuarioTDG)
    Private Shared _ordenCompraRepositorio As New OrdenCompraRepositorio(_ordenDeCompraTDG, _lineaOrdenDeCompraTDG, _proveedorTDG, _lineaOrdenCompraRepositorio, _movimientoCuentaProveedorTDG)
    Private Shared _produccionRepositorio As New ProduccionRepositorio(_produccionTDG, _produccionOperadorTDG, _pedidoTDG, _maquinaTDG, _articuloTDG, _historicoEstadosProduccionTDG, _estadoTrabajoTDG)
    Private Shared _insumoRepositorio As New InsumoRepositorio(_insumoTDG, _movimientoStockTDG, _tipoInsumoTDG, _colorTDG)
    Private Shared _encuestaRepositorio As New EncuestaRepositorio(_encuestaTDG)

    Public Shared ReadOnly Property dao() As DataAccesObject
        Get
            Return _dao
        End Get
    End Property

    Public Shared ReadOnly Property usuarioTDG() As UsuarioTDG
        Get
            Return _usuarioTDG
        End Get
    End Property

    Public Shared ReadOnly Property tipoPrendaTDG() As TipoPrendaTDG
        Get
            Return _tipoPrendaTDG
        End Get
    End Property

    Public Shared ReadOnly Property tipoPedidoTDG() As TipoPedidoTDG
        Get
            Return _tipoPedidoTDG
        End Get
    End Property

    Public Shared ReadOnly Property tipoMovimientoTDG() As TipoMovimientoTDG
        Get
            Return _tipoMovimientoTDG
        End Get
    End Property

    Public Shared ReadOnly Property tipoInsumoTDG() As TipoInsumoTDG
        Get
            Return _tipoInsumoTDG
        End Get
    End Property

    Public Shared ReadOnly Property proveedorTDG() As ProveedorTDG
        Get
            Return _proveedorTDG
        End Get
    End Property

    Public Shared ReadOnly Property produccionOperadorTDG() As ProduccionOperadorTDG
        Get
            Return _produccionOperadorTDG
        End Get
    End Property

    Public Shared ReadOnly Property familiaTDG() As FamiliaTDG
        Get
            Return _familiaTDG
        End Get
    End Property

    Public Shared ReadOnly Property patenteTDG() As PatenteTDG
        Get
            Return _patenteTDG
        End Get
    End Property

    Public Shared ReadOnly Property opinionTDG() As OpinionTDG
        Get
            Return _opinioTDG
        End Get
    End Property

    Public Shared ReadOnly Property clienteTDG() As ClienteTDG
        Get
            Return _clienteTDG
        End Get
    End Property

    Public Shared ReadOnly Property newsletterTDG() As NewsletterTDG
        Get
            Return _newsletterTDG
        End Get
    End Property

    Public Shared ReadOnly Property mensajeTDG() As MensajeTDG
        Get
            Return _mensajeTDG
        End Get
    End Property

    Public Shared ReadOnly Property conversacionTDG() As ConversacionTDG
        Get
            Return _conversacionTDG
        End Get
    End Property

    Public Shared ReadOnly Property DiseñoTDG() As DiseñoTDG
        Get
            Return _diseñoTDG
        End Get
    End Property

    Public Shared ReadOnly Property movimientoCuentaClienteTDG() As MovimientoCuentaClienteTDG
        Get
            Return _movimientoCuentaClienteTDG
        End Get
    End Property

    Public Shared ReadOnly Property historicoEstadosDiseñoTDG() As HistoricoEstadosDiseñoTDG
        Get
            Return _historicoEstadosDiseñoTDG
        End Get
    End Property

    Public Shared ReadOnly Property historicoEstadosProduccionTDG() As HistoricoEstadosProduccionTDG
        Get
            Return _historicoEstadosProduccionTDG
        End Get
    End Property

    Public Shared ReadOnly Property produccionTDG() As ProduccionTDG
        Get
            Return _produccionTDG
        End Get
    End Property

    Public Shared ReadOnly Property historicoEstadosPedidoTDG() As HistoricoEstadosPedidoTDG
        Get
            Return _historicoEstadosPedidoTDG
        End Get
    End Property

    Public Shared ReadOnly Property pedidoTDG() As PedidoTDG
        Get
            Return _pedidoTDG
        End Get
    End Property

    Public Shared ReadOnly Property maquinaTDG() As MaquinaTDG
        Get
            Return _maquinaTDG
        End Get
    End Property

    Public Shared ReadOnly Property movimientoCuentaProveedorTDG() As MovimientoCuentaProveedorTDG
        Get
            Return _movimientoCuentaProveedorTDG
        End Get
    End Property

    Public Shared ReadOnly Property facturaTDG() As FacturaTDG
        Get
            Return _facturaTDG
        End Get
    End Property

    Public Shared ReadOnly Property lineaFacturaTDG() As LineaFacturaTDG
        Get
            Return _lineaFacturaTDG
        End Get
    End Property

    Public Shared ReadOnly Property ordenDeCompraTDG() As OrdenDeCompraTDG
        Get
            Return _ordenDeCompraTDG
        End Get
    End Property

    Public Shared ReadOnly Property lineaOrdenDeCompraTDG() As LineaOrdenDeCompraTDG
        Get
            Return _lineaOrdenDeCompraTDG
        End Get
    End Property

    Public Shared ReadOnly Property articuloTDG() As ArticuloTDG
        Get
            Return _articuloTDG
        End Get
    End Property

    Public Shared ReadOnly Property colorTDG() As ColorTDG
        Get
            Return _colorTDG
        End Get
    End Property

    Public Shared ReadOnly Property insumoTDG() As InsumoTDG
        Get
            Return _insumoTDG
        End Get
    End Property

    Public Shared ReadOnly Property listaPreciosTDG() As ListaPreciosTDG
        Get
            Return _listaPreciosTDG
        End Get
    End Property

    Public Shared ReadOnly Property diseñoInsumoTDG() As DiseñoInsumoTDG
        Get
            Return _diseñoInsumoTDG
        End Get
    End Property

    Public Shared ReadOnly Property operadorTDG() As OperadorTDG
        Get
            Return _operadorTDG
        End Get
    End Property

    Public Shared ReadOnly Property estadoPedidoTDG() As EstadoPedidoTDG
        Get
            Return _estadoPedidoTDG
        End Get
    End Property

    Public Shared ReadOnly Property estadoTrabajoTDG() As EstadoTrabajoTDG
        Get
            Return _estadoTrabajoTDG
        End Get
    End Property

    Public Shared ReadOnly Property cuentaTDG() As CuentaTDG
        Get
            Return _cuentaTDG
        End Get
    End Property

    Public Shared ReadOnly Property movimientoStockTDG() As MovimientoStockTDG
        Get
            Return _movimientoStockTDG
        End Get
    End Property

    Public Shared ReadOnly Property encuestaTDG() As EncuestaTDG
        Get
            Return _encuestaTDG
        End Get
    End Property

    Public Shared ReadOnly Property estadoDiseñoTdg() As EstadoDiseñoTDG
        Get
            Return _estadoDiseñoTDG
        End Get
    End Property













    Public Shared ReadOnly Property usuarioRepostorio() As UsuarioRepositorio
        Get
            Return _usuarioRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property familiaRepositorio() As FamiliaRepositorio
        Get
            Return _familiaRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property patenteRepositorio() As PatenteRepositorio
        Get
            Return _patenteRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property opinionRepositorio() As OpinionRepositorio
        Get
            Return _opinionRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property clienteRepositorio() As ClienteRepositorio
        Get
            Return _clienteRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property newsletterRepositorio() As NewsletterRepositorio
        Get
            Return _newsletterRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property mensajeRepositorio() As MensajeRepositorio
        Get
            Return _mensajeRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property conversacionRepositorio() As ConversacionRepositorio
        Get
            Return _conversacionRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property diseñoRepositorio() As DiseñoRepositorio
        Get
            Return _diseñoRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property movimientoCuentaClienteRepositorio() As MovimientoCuentaClienteRepositorio
        Get
            Return _MovimientoCuentaClienteRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property tipoPrendaRepostirio() As TipoPrendaRepositorio
        Get
            Return _tipoPrendaRepostirio
        End Get
    End Property

    Public Shared ReadOnly Property maquinaRepositorio() As MaquinaRepositorio
        Get
            Return _maquinaRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property proveedorRepositorio() As ProveedorRepositorio
        Get
            Return _proveedorRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property movimientoCuentaProveedorRepositorio() As MovimientoCuentaProveedorRepositorio
        Get
            Return _movimientoCuentaProveedorRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property pedidoRepositorio() As PedidoRepositorio
        Get
            Return _pedidoRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property articuloRepositorio() As ArticuloRepositorio
        Get
            Return _articuloRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property lineaFacturaRepostorio() As LineaFacturaRepostorio
        Get
            Return _lineaFacturaRepostorio
        End Get
    End Property

    Public Shared ReadOnly Property facturaRepositorio() As FacturaRepositorio
        Get
            Return _facturaRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property lineaOrdenCompraRepositorio() As LineaOrdenCompraRepositorio
        Get
            Return _lineaOrdenCompraRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property ordenCompraRepositorio() As OrdenCompraRepositorio
        Get
            Return _ordenCompraRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property produccionRepositorio() As ProduccionRepositorio
        Get
            Return _produccionRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property insumoRepositorio() As InsumoRepositorio
        Get
            Return _insumoRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property materialesRepositorio() As MaterialesRepositorio
        Get
            Return _materialesRepositorio
        End Get
    End Property

    Public Shared ReadOnly Property encuestaRepositorio() As EncuestaRepositorio
        Get
            Return _encuestaRepositorio
        End Get
    End Property

End Class
