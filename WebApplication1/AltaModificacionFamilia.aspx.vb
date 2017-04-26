Public Class AltaModificacionFamilia
    Inherits BasePage

    Dim familiaBusiness As FamiliaBusiness = BusinessFactory.familiaBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()

        If Not IsPostBack Then
            If Request.Params("id") IsNot Nothing Then
                MyBase.verificarPermisosYRedirecccionar(Permisos.EdicionFamilias)
                Me.cargarFamilia(Request.Params("id"))
                grabar.Visible = False
                labelTituloCreacion.Visible = False
            Else
                MyBase.verificarPermisosYRedirecccionar(Permisos.CreacionFamilias)
                editar.Visible = False
                labelTituloEdicion.Visible = False
            End If
        End If
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

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim familia As New Familia(Nothing, descripcion.Text, nombre.Text)

        For Each item As ListItem In patentesUsuario.Items
            familia.patentes.Add(New Patente(item.Value, Nothing, Nothing))
        Next

        familiaBusiness.guardarFamilia(familia)

        Response.Redirect("~/BusquedaFamilia.aspx")
    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        Dim familia As New Familia(idfamilia.Value, descripcion.Text, nombre.Text)

        For Each item As ListItem In patentesUsuario.Items
            familia.patentes.Add(New Patente(item.Value, Nothing, Nothing))
        Next

        familiaBusiness.actualizarFamilia(familia)

        Response.Redirect("~/BusquedaFamilia.aspx")
    End Sub
End Class