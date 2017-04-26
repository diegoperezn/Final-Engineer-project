Public Class DetalleFactura
    Inherits BasePage

    Dim facturaBusiness As FacturaBusiness = BusinessFactory.facturaBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detalleFactura)

        Dim nroFactura As Long = Long.Parse(Request.Params("nroFactura"))
        Dim nroSucursal As Long = Long.Parse(Request.Params("nroSucursal"))
        Dim tipoFactura As String = Request.Params("tipoFactura")

        If Not nroFactura = 0 AndAlso Not nroSucursal = 0 _
            AndAlso Not String.IsNullOrEmpty(tipoFactura) Then
            cargarFactura(nroFactura, nroSucursal, tipoFactura)
        End If
    End Sub

    Private Sub cargarFactura(ByVal nroFactura As Long, ByVal nroSucursal As Long, ByVal tipoFactura As String)
        Dim factura As Factura = Me.facturaBusiness.listarFacturasPorId(nroFactura, nroSucursal, tipoFactura)

        With factura
            Me.nroFactura.Text = .nroFactura
            Me.nroSucursal.Text = .nroSucursal
            Me.tipoFactura.Text = .tipoFactura
            Me.cliente.Text = .cliente.ToString
            Me.monto.Text = .monto.ToString("c")
            Me.fecha.Text = .fecha.ToString("g")

            Me.lineas.DataSource = .lineas
            Me.lineas.DataBind()
        End With
    End Sub

End Class