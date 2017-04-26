'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  ClienteRepositorio.vb
''  Implementation of the Class ClienteRepositorio
''  Generated by Enterprise Architect
''  Created on:      09-ago-2012 11:28:02 p.m.
''  Original author: Diego
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



Option Explicit On

Imports Dominio

Public Class ClienteRepositorio

    Dim TDGCliente As ClienteTDG
    Dim usuarioRepo As UsuarioRepositorio
    Dim TDGDise�o As Dise�oTDG
    Dim tdgFacturas As FacturaTDG
    Dim tdgPedidos As PedidoTDG
    Dim tdgMovCuenta As MovimientoCuentaClienteTDG


    Sub New(ByRef cliente As ClienteTDG, ByRef dise�oTDG As Dise�oTDG, ByVal uruarioRepo As UsuarioRepositorio,
            ByVal tdgFactura As FacturaTDG, ByVal tdgPedido As PedidoTDG, ByVal tdgMovCuenta As MovimientoCuentaClienteTDG)
        Me.TDGCliente = cliente
        Me.TDGDise�o = dise�oTDG
        Me.usuarioRepo = uruarioRepo
        Me.tdgFacturas = tdgFactura
        Me.tdgPedidos = tdgPedido
        Me.tdgMovCuenta = tdgMovCuenta
    End Sub

    Public Function CargarClientes() As List(Of Cliente)
        Dim clientes As List(Of Cliente) = TDGCliente.buscarClientes(Nothing)

        For Each cli As Cliente In clientes
            completarCliente(cli)
        Next

        Return clientes
    End Function

    Public Function CargarClientesNewsletter() As List(Of Cliente)
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ClienteTDG.NEWSLETTER, True, Restriccion.CONDICION_IGUAL))

        Dim clientes As List(Of Cliente) = TDGCliente.buscarClientes(criteria)

        For Each cli As Cliente In clientes
            completarCliente(cli)
        Next

        Return clientes
    End Function

    Public Sub guardarCliente(ByVal cliente As Cliente)
        usuarioRepo.grabarUsuario(cliente)
        TDGCliente.grabar(cliente)
    End Sub

    Public Sub borrarCliente(ByVal cliente As Cliente)
        TDGCliente.borrar(cliente)
        usuarioRepo.borrarUsuario(cliente)
    End Sub

    Public Sub actualizarCliente(ByVal cliente As Cliente)
        usuarioRepo.actualizarUsuario(cliente)
        TDGCliente.actualizar(cliente)
    End Sub

    Function CargarCliente(ByVal usr As Usuario) As Cliente
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ClienteTDG.USUARIO, usr.id, Restriccion.CONDICION_IGUAL))
        Dim cliente As Cliente = TDGCliente.buscarUnico(criteria)
        If cliente IsNot Nothing Then
            completarCliente(cliente)
            Return cliente
        Else
            Return Nothing
        End If
    End Function

    Function CargarClientePorId(ByVal id As Long) As Cliente
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(ClienteTDG.ID_CLIENTE, id, Restriccion.CONDICION_IGUAL))

        Dim cliente As Cliente = TDGCliente.buscarUnico(criteria)
        If cliente IsNot Nothing Then
            completarCliente(cliente)
        End If

        Return cliente
    End Function

    Private Sub completarCliente(ByRef cliente As Cliente)
        Dim criteria As New List(Of Restriccion)

        cliente.agregarUsuario(usuarioRepo.cargarUsuarioPorId(cliente.id))

        criteria.Clear()
        criteria.Add(New Restriccion(Dise�oTDG.CLIENTE, cliente.id))
        cliente.dise�o = TDGDise�o.cargarDise�os(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(FacturaTDG.CLIENTE, cliente.id))
        cliente.facturas = tdgFacturas.cargarFacturas(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(PedidoTDG.CLIENTE, cliente.id))
        cliente.pedido = tdgPedidos.cargarlistaPedidos(criteria)

        criteria.Clear()
        criteria.Add(New Restriccion(MovimientoCuentaClienteTDG.CLIENTE, cliente.id))
        cliente.movimientosCuentaCorriente = tdgMovCuenta.cargarMovimientos(criteria)
    End Sub



End Class ' ClienteRepositorio