Public Class ProveedorBusiness

    Dim proveedorRepo As ProveedorRepositorio

    Sub New()
        Me.proveedorRepo = RepositorioFactory.proveedorRepositorio
    End Sub

    Sub New(ByVal proveedorRepo As ProveedorRepositorio)
        Me.proveedorRepo = proveedorRepo
    End Sub

    Public Sub grabar(ByVal proveedor As Proveedor)
        Me.proveedorRepo.grabar(proveedor)
    End Sub

    Public Sub actualizar(ByVal proveedor As Proveedor)
        Me.proveedorRepo.actualizar(proveedor)
    End Sub

    Public Function buscarProveedoresPorNombre(ByVal nombre As String) As List(Of Proveedor)
        Return Me.proveedorRepo.buscarProveedoresPorNombre(nombre)
    End Function

    Public Function listarProveedores() As List(Of Proveedor)
        Return Me.proveedorRepo.listarProveedores()
    End Function

    Public Function buscarProveedorPorCodigo(ByVal cod As Long) As Proveedor
        Return Me.proveedorRepo.buscarProveedorPorCodigo(cod)
    End Function

End Class
