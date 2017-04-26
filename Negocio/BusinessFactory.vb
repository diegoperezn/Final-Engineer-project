Imports Repositorio
Imports Seguridad

Public Class BusinessFactory

    Private Shared _mailUtils As New MailUtils()
    Private Shared _usuarioBusiness As New UsuarioBusiness(RepositorioFactory.usuarioRepostorio, RepositorioFactory.clienteRepositorio)
    Private Shared _familiaBusiness As New FamiliaBusiness(RepositorioFactory.familiaRepositorio)
    Private Shared _patenteBusines As New PatenteBusiness(RepositorioFactory.patenteRepositorio)
    Private Shared _opinionBusiness As New OpinionBusiness(RepositorioFactory.opinionRepositorio)
    Private Shared _administracionBusiness As New AdministracionBusiness(_usuarioBusiness, RepositorioFactory.newsletterRepositorio, _mailUtils)
    Private Shared _newsletterBusiness As New NewsletterBusiness(RepositorioFactory.newsletterRepositorio)
    Private Shared _conversacionBusiness As New ConversacionBusiness(RepositorioFactory.conversacionRepositorio)
    Private Shared _diseñoBusiness As New DiseñoBusiness(RepositorioFactory.diseñoRepositorio)
    Private Shared _movimientoClienteBusiness As New MovimientoClienteBusiness(RepositorioFactory.movimientoCuentaClienteRepositorio)
    Private Shared _tipoPrendaBusiness As New TipoPrendaBusiness(RepositorioFactory.tipoPrendaRepostirio)
    Private Shared _proveedorBusiness As New ProveedorBusiness(RepositorioFactory.proveedorRepositorio)
    Private Shared _movimientoProveedorBusiness As New MovimientoProveedorBusiness(RepositorioFactory.movimientoCuentaProveedorRepositorio)
    Private Shared _pedidoBusiness As New PedidoBusiness(RepositorioFactory.pedidoRepositorio, RepositorioFactory.produccionRepositorio,
                                                        RepositorioFactory.newsletterRepositorio, RepositorioFactory.usuarioRepostorio,
                                                        RepositorioFactory.articuloRepositorio)
    Private Shared _articuloBusiness As New ArticuloBusiness(RepositorioFactory.articuloRepositorio)
    Private Shared _facturaBusiness As New FacturaBusiness(RepositorioFactory.facturaRepositorio, RepositorioFactory.produccionRepositorio)
    Private Shared _ordenCompraBusiness As OrdenCompraBusiness = New OrdenCompraBusiness(RepositorioFactory.ordenCompraRepositorio)
    Private Shared _insumoBusiness As InsumoBusiness = New InsumoBusiness(RepositorioFactory.insumoRepositorio, RepositorioFactory.articuloRepositorio,
                                                                          RepositorioFactory.diseñoRepositorio)
    Private Shared _produccionBusiness As ProduccionBusiness = New ProduccionBusiness(RepositorioFactory.produccionRepositorio, RepositorioFactory.maquinaRepositorio, _pedidoBusiness, _facturaBusiness, _insumoBusiness)
    Private Shared _encuestaBusiness As EncuestaBusiness = New EncuestaBusiness(RepositorioFactory.encuestaRepositorio)
    Private Shared _materialesBusiness As New MaterialesBusiness(RepositorioFactory.maquinaRepositorio, RepositorioFactory.materialesRepositorio, _produccionBusiness)

    Public Shared ReadOnly Property administracionBusiness() As AdministracionBusiness
        Get
            Return _administracionBusiness
        End Get
    End Property

    Public Shared ReadOnly Property usuarioBusiness() As UsuarioBusiness
        Get
            Return _usuarioBusiness
        End Get
    End Property

    Public Shared ReadOnly Property familiaBusiness() As FamiliaBusiness
        Get
            Return _familiaBusiness
        End Get
    End Property

    Public Shared ReadOnly Property patenteBusiness() As PatenteBusiness
        Get
            Return _patenteBusines
        End Get
    End Property

    Public Shared ReadOnly Property opinionBusiness() As OpinionBusiness
        Get
            Return _opinionBusiness
        End Get
    End Property

    Public Shared ReadOnly Property mailUtils() As MailUtils
        Get
            Return _mailUtils
        End Get
    End Property

    Public Shared ReadOnly Property newsletterBusiness() As NewsletterBusiness
        Get
            Return _newsletterBusiness
        End Get
    End Property

    Public Shared ReadOnly Property conversacionBusiness() As ConversacionBusiness
        Get
            Return _conversacionBusiness
        End Get
    End Property

    Public Shared ReadOnly Property diseñoBusiness() As DiseñoBusiness
        Get
            Return _diseñoBusiness
        End Get
    End Property

    Public Shared ReadOnly Property movimientoClienteBusiness() As MovimientoClienteBusiness
        Get
            Return _movimientoClienteBusiness
        End Get
    End Property

    Public Shared ReadOnly Property tipoPrendaBusiness() As TipoPrendaBusiness
        Get
            Return _tipoPrendaBusiness
        End Get
    End Property

    Public Shared ReadOnly Property materialesBusiness() As MaterialesBusiness
        Get
            Return _materialesBusiness
        End Get
    End Property

    Public Shared ReadOnly Property proveedorBusiness() As ProveedorBusiness
        Get
            Return _proveedorBusiness
        End Get
    End Property

    Public Shared ReadOnly Property movimientoProveedorBusiness() As MovimientoProveedorBusiness
        Get
            Return _movimientoProveedorBusiness
        End Get
    End Property

    Public Shared ReadOnly Property pedidoBusiness() As PedidoBusiness
        Get
            Return _pedidoBusiness
        End Get
    End Property

    Public Shared ReadOnly Property articuloBusiness() As ArticuloBusiness
        Get
            Return _articuloBusiness
        End Get
    End Property

    Public Shared ReadOnly Property facturaBusiness() As FacturaBusiness
        Get
            Return _facturaBusiness
        End Get
    End Property

    Public Shared ReadOnly Property ordenCompraBusiness() As OrdenCompraBusiness
        Get
            Return _ordenCompraBusiness
        End Get
    End Property

    Public Shared ReadOnly Property insumoBusiness() As InsumoBusiness
        Get
            Return _insumoBusiness
        End Get
    End Property

    Public Shared ReadOnly Property produccionBusiness() As ProduccionBusiness
        Get
            Return _produccionBusiness
        End Get
    End Property

    Public Shared ReadOnly Property encuestaBusiness() As EncuestaBusiness
        Get
            Return _encuestaBusiness
        End Get
    End Property


End Class

