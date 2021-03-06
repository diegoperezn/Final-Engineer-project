'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  UsuarioRepositorio.vb
''  Implementation of the Class UsuarioRepositorio
''  Generated by Enterprise Architect
''  Created on:      09-ago-2012 11:28:03 p.m.
''  Original author: Diego
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



Option Explicit On

Imports Dominio

Public Class UsuarioRepositorio


    Private usuarioTDG As UsuarioTDG
    Private familiaRepositorio As FamiliaRepositorio
    Private patenteRepositorio As PatenteRepositorio
    Private clienteTDG As ClienteTDG

    Sub New(ByRef usr As UsuarioTDG, ByRef famRepo As FamiliaRepositorio, ByRef pat As PatenteRepositorio, ByRef clienteRepo As ClienteTDG)
        usuarioTDG = usr
        familiaRepositorio = famRepo
        patenteRepositorio = pat
        clienteTDG = clienteRepo
    End Sub

    Public Sub actualizarUsuario(ByVal usuario As Usuario)
        usuarioTDG.actualizar(usuario)
    End Sub

    ''' 
    ''' <param name="usuario"></param>
    Public Sub grabarUsuario(ByVal usuario As Usuario)
        usuarioTDG.grabar(usuario)
    End Sub

    Public Sub borrarUsuario(ByVal usr As Usuario)
        usuarioTDG.borrar(usr)
    End Sub

    Public Function listarUsuarios(ByVal criteria As List(Of Restriccion)) As List(Of Usuario)
        Dim usuarios As New List(Of Usuario)

        For Each usr As Usuario In usuarioTDG.cargarUsuarios(criteria)
            usr.familias = familiaRepositorio.cargarFamiliasPorUsuario(usr)
            usr.patentes = patenteRepositorio.cargarPatentesPorUsuario(usr)

            Dim idcliente As New Restriccion(clienteTDG.USUARIO, usr.id, Restriccion.CONDICION_IGUAL)
            Dim cliente As Cliente = clienteTDG.buscarUnico(idcliente)
            If cliente IsNot Nothing Then
                cliente.agregarUsuario(usr)
            End If

            usuarios.Add(usr)
        Next

        Return usuarios
    End Function

    Public Function listarUsuariosConRestricciones(ByVal nombre As String, ByVal apellido As String, ByVal mail As String,
                                                   ByVal telMovil As String, ByVal telfijo As String) As List(Of Usuario)
        Dim usuarios As New List(Of Usuario)

        Dim criterio As New List(Of Restriccion)
        If nombre IsNot Nothing Then
            criterio.Add(New Restriccion(usuarioTDG.NOMBRE, nombre, Restriccion.CONDICION_LIKE))
        End If
        If apellido IsNot Nothing Then
            criterio.Add(New Restriccion(usuarioTDG.APELLIDO, apellido, Restriccion.CONDICION_LIKE))
        End If
        If mail IsNot Nothing Then
            criterio.Add(New Restriccion(usuarioTDG.MAIL, mail, Restriccion.CONDICION_LIKE))
        End If
        If telfijo IsNot Nothing Then
            criterio.Add(New Restriccion(usuarioTDG.TELEFONO_FIJO, telfijo, Restriccion.CONDICION_LIKE))
        End If
        If telMovil IsNot Nothing Then
            criterio.Add(New Restriccion(usuarioTDG.TELEFONO_MOVIL, telMovil, Restriccion.CONDICION_LIKE))
        End If

        For Each usr As Usuario In usuarioTDG.cargarUsuarios(criterio)
            usr.familias = familiaRepositorio.cargarFamiliasPorUsuario(usr)
            usr.patentes = patenteRepositorio.cargarPatentesPorUsuario(usr)

            Dim idcliente As New Restriccion(clienteTDG.USUARIO, usr.id, Restriccion.CONDICION_IGUAL)
            Dim cliente As Cliente = clienteTDG.buscarUnico(idcliente)
            If cliente IsNot Nothing Then
                cliente.agregarUsuario(usr)
            End If

            usuarios.Add(usr)
        Next

        Return usuarios
    End Function


    Public Function cargarUsuarioPorId(ByVal id As Long) As Usuario
        Dim criteria As New List(Of Restriccion)
        criteria.Add(New Restriccion(usuarioTDG.ID_USUARIO, id, Restriccion.CONDICION_IGUAL))

        Return cargarUsuario(criteria)
    End Function


    Public Function cargarUsuario(ByVal criteria As List(Of Restriccion)) As Usuario
        Dim usr As Usuario = usuarioTDG.buscarUnico(criteria)

        If usr IsNot Nothing Then
            usr.familias = familiaRepositorio.cargarFamiliasPorUsuario(usr)
            usr.patentes = patenteRepositorio.cargarPatentesPorUsuario(usr)

            Dim idcliente As New Restriccion(clienteTDG.USUARIO, usr.id, Restriccion.CONDICION_IGUAL)
            Dim cliente As Cliente = clienteTDG.buscarUnico(idcliente)
            If cliente IsNot Nothing Then
                cliente.agregarUsuario(usr)
                usr = cliente
            End If
        End If

        Return usr
    End Function

End Class ' UsuarioRepositorio