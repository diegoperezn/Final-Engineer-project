Public Class AltaCliente
    Inherits BasePage

    Dim usuarioBusiness As UsuarioBusiness = BusinessFactory.usuarioBusiness
    Dim familiaBusiness As FamiliaBusiness = BusinessFactory.familiaBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()

    End Sub

    Protected Sub grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabar.Click
        Dim cliente As New Cliente(Nothing, apellido.Text, mail.Text, nombre.Text, password.Text, telFijo.Text, telMovil.Text, False, False)

        Dim familia As Familia = Me.familiaBusiness.cargarFamiliaPorId(1)

        cliente.familias.Add(familia)

        usuarioBusiness.grabarCliente(cliente)

        Session.Add("usuario", cliente)

        Response.Redirect("~\Default.aspx")
    End Sub
End Class