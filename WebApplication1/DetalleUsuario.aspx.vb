Public Class DetalleUsuario
    Inherits BasePage

    Dim usuarioBusiness As UsuarioBusiness = BusinessFactory.usuarioBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.detalle_usuarios)
        If Request.Params("id") IsNot Nothing Then
            MyBase.verificarPermisosYRedirecccionar(Permisos.Edicion_usuarios)
            Me.cargarUsuario(Request.Params("id"))
        End If
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

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Response.Redirect("~\AltaModificacionUsuario.aspx?id=" + idUsuario.Value)
    End Sub
End Class