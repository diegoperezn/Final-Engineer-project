Public Class ProveedorRepositorio

    Dim proveedorTdg As ProveedorTDG
    Dim ordenesCompraTdg As OrdenDeCompraTDG

    Sub New(ByVal proTdg As ProveedorTDG, ByVal ordenCompraTdg As OrdenDeCompraTDG)
        Me.proveedorTdg = proTdg
        Me.ordenesCompraTdg = ordenCompraTdg
    End Sub

    Public Sub grabar(ByVal proveedor As Proveedor)
        Me.proveedorTdg.grabar(proveedor)
        For Each orden As OrdenDeCompra In proveedor.ordenesDeCompra
            Me.ordenesCompraTdg.grabar(orden)
        Next
    End Sub

    Public Sub actualizar(ByVal proveedor As Proveedor)
        Me.proveedorTdg.actualizar(proveedor)
        For Each orden As OrdenDeCompra In proveedor.ordenesDeCompra
            Me.ordenesCompraTdg.actualizar(orden)
        Next
    End Sub

    Public Function buscarProveedoresPorNombre(ByVal nombre As String) As List(Of Proveedor)
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(proveedorTdg.NOMBRE, nombre, Restriccion.CONDICION_LIKE))
        Dim results As List(Of Proveedor) = Me.proveedorTdg.buscarLista(criteria)

        For Each prov As Proveedor In results
            cargarProveedor(prov)
        Next

        Return results
    End Function

    Public Function listarProveedores() As List(Of Proveedor)
        Dim results As List(Of Proveedor) = Me.proveedorTdg.buscarLista(Nothing)

        For Each prov As Proveedor In results
            cargarProveedor(prov)
        Next

        Return results
    End Function

    Public Function buscarProveedorPorCodigo(ByVal cod As Long) As Proveedor
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(proveedorTdg.COD_PROVEEDOR, cod))
        Dim result As Proveedor = Me.proveedorTdg.buscarUnico(criteria)

        cargarProveedor(result)

        Return result
    End Function

    Private Sub cargarProveedor(ByRef prov As Proveedor)
        Dim criteria As New List(Of Restriccion)

        criteria.Add(New Restriccion(OrdenDeCompraTDG.PROVEEDOR, prov.codProveedor))
        prov.ordenesDeCompra = Me.ordenesCompraTdg.cargarOrdenesDeCompras(criteria)
    End Sub

End Class
