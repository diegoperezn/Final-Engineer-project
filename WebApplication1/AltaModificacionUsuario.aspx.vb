Imports Seguridad
Imports Negocio
Imports Dominio
Imports System.Threading


Public Class UsuarioUI
    Inherits BasePage

    Private usuarioBusiness As UsuarioBusiness = BusinessFactory.usuarioBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()

        If Not IsPostBack Then
            If Request.Params("id") IsNot Nothing Then
                MyBase.verificarPermisosYRedirecccionar(Permisos.Edicion_usuarios)
                Me.cargarUsuario(Request.Params("id"))
                grabar.Visible = False
                tituloCreacion.Visible = False
            Else
                MyBase.verificarPermisosYRedirecccionar(Permisos.Creacion_usuarios)
                editar.Visible = False
                tituloEdicion.Visible = False
            End If
        End If
    End Sub

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim usuario As New Usuario(Nothing, apellido.Text, mail.Text, nombre.Text, password.Text, telFijo.Text, telMovil.Text)

        For Each item As ListItem In patentesUsuario.Items
            usuario.patentes.Add(New Patente(item.Value, Nothing, Nothing))
        Next

        For Each item As ListItem In familiasUsuario.Items
            usuario.familias.Add(New Familia(item.Value, Nothing, Nothing))
        Next

        usuarioBusiness.crearUsuario(usuario)

        Response.Redirect("~\BusquedaUsuario.aspx")
    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Dim usuario As New Usuario(idUsuario.Value, apellido.Text, mail.Text, nombre.Text, password.Text, telFijo.Text, telMovil.Text)

        For Each item As ListItem In patentesUsuario.Items
            usuario.patentes.Add(New Patente(item.Value, Nothing, Nothing))
        Next

        For Each item As ListItem In familiasUsuario.Items
            usuario.familias.Add(New Familia(item.Value, Nothing, Nothing))
        Next

        usuarioBusiness.modificarUsuario(usuario)

        Response.Redirect("~\BusquedaUsuario.aspx")
    End Sub

    Protected Sub agregarFamilia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles agregarFamilia.Click
        Dim result As Integer() = familiasSistema.GetSelectedIndices()
        Dim vec As New List(Of String)
        For i As Integer = 0 To result.Length - 1
            If Not familiasUsuario.Items.Contains(familiasSistema.Items(result(i))) Then
                familiasUsuario.Items.Add(familiasSistema.Items(result(i)))
            End If
        Next
    End Sub

    Protected Sub quitarFamilia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitarFamilia.Click
        Dim result As Integer() = familiasUsuario.GetSelectedIndices()

        For i As Integer = result.Length - 1 To 0 Step -1
            familiasUsuario.Items.Remove(familiasUsuario.Items(result(i)))
        Next
    End Sub

    Protected Sub agregarPatente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles agregarPatente.Click
        Dim result As Integer() = patentesSistema.GetSelectedIndices()
        Dim vec As New List(Of String)
        For i As Integer = 0 To result.Length - 1
            If Not patentesUsuario.Items.Contains(patentesSistema.Items(result(i))) Then
                patentesUsuario.Items.Add(patentesSistema.Items(result(i)))
            End If
        Next
    End Sub

    Protected Sub quitarPatente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitarPatente.Click
        Dim result As Integer() = patentesUsuario.GetSelectedIndices()

        For i As Integer = result.Length - 1 To 0 Step -1
            patentesUsuario.Items.Remove(patentesUsuario.Items(result(i)))
        Next
    End Sub

    Protected Sub cargarUsuario(ByVal id As Long)
        Dim usr As Usuario = usuarioBusiness.buscarUsuarioPorId(id)

        idUsuario.Value = usr.id
        apellido.Text = usr.apellido
        mail.Text = usr.mail
        nombre.Text = usr.nombre
        password.Text = usr.password
        telFijo.Text = usr.telefonoFijo
        telMovil.Text = usr.telefonoMovil

        patentesUsuario.Items.Clear()
        For Each pat As Patente In usr.patentes
            Dim item As New ListItem(pat.permiso, pat.patenteId)
            patentesUsuario.Items.Add(item)
        Next

        familiasUsuario.Items.Clear()
        For Each fam As Familia In usr.familias
            Dim item As New ListItem(fam.nombre, fam.idFamilia)
            familiasUsuario.Items.Add(item)
        Next
    End Sub


End Class