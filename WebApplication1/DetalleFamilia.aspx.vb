Public Class DetalleFamilia
    Inherits BasePage

    Dim familiaBusiness As FamiliaBusiness = BusinessFactory.familiaBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detalleFamilias)

        If Request.Params("id") IsNot Nothing Then
            MyBase.verificarPermisosYRedirecccionar(Permisos.EdicionFamilias)
            Me.cargarFamilia(Request.Params("id"))
        End If
    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Response.Redirect("~\AltaModificacionFamilia.aspx?id=" + idfamilia.Value)
    End Sub

    Protected Sub cargarFamilia(ByVal id As Long)
        Dim familia As Familia = familiaBusiness.cargarFamiliaPorId(id)

        idfamilia.Value = id

        idfamilia.Value = familia.idFamilia
        descripcion.Text = familia.descripcion
        nombre.Text = familia.nombre

        patentesUsuario.Items.Clear()
        For Each pat As Patente In familia.patentes
            Dim item As New ListItem(pat.permiso, pat.patenteId)
            patentesUsuario.Items.Add(item)
        Next

        Me.familiaBusiness.actualizarFamilia(familia)
    End Sub
End Class