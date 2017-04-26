Public Class DetalleOrdenCompra
    Inherits BasePage

    Dim orderBusiness As OrdenCompraBusiness = BusinessFactory.ordenCompraBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detalleOrdenCompra)

        Dim nroOrdenCompra As Long = Long.Parse(Request.Params("nroOrdenCompra"))
        Dim nroSucursal As Long = Long.Parse(Request.Params("nroSucursal"))
        Dim tipoOrdenCompra As String = Request.Params("tipoOrdenCompra")

        If Not nroOrdenCompra = 0 AndAlso Not nroSucursal = 0 _
            AndAlso Not String.IsNullOrEmpty(tipoOrdenCompra) Then
            cargarOrdenCompra(nroOrdenCompra, nroSucursal, tipoOrdenCompra)
        End If
    End Sub

    Private Sub cargarOrdenCompra(ByVal nroOrdenCompra As Long, ByVal nroSucursal As Long, ByVal tipoOrdenCompra As String)
        Dim factura As OrdenDeCompra = Me.orderBusiness.listarOrdenDeComprasPorId(nroOrdenCompra, nroSucursal, tipoOrdenCompra)

        With factura
            Me.nroOrdenCompra.Text = .nroOrdenCompra
            Me.nroSucursal.Text = .nroSucursal
            Me.tipoOrdenCompra.Text = .tipoOrdenCompra
            Me.proveedor.Text = .proveedor.ToString
            Me.monto.Text = .monto.ToString("c")
            Me.fecha.Text = .fecha.ToString("g")
        End With
    End Sub

End Class