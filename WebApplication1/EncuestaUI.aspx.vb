Public Class EncuestaUI
    Inherits BasePage

    Private encuestaBusiness As EncuestaBusiness = BusinessFactory.encuestaBusiness
    Private usuarioBusiness As UsuarioBusiness = BusinessFactory.usuarioBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
    End Sub

    Protected Sub grabarOpinion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grabarOpinion.Click
        If isClienteLogueado() Then
            Dim cliente As Cliente = CType(getLoggedUser(), Cliente)
            Dim encuesta As New Encuesta(Nothing, atencion.SelectedValue, calidad.SelectedValue, eficiencia.SelectedValue)

            Me.encuestaBusiness.grabarEncuesta(encuesta)

            cliente.newsletter = False
            usuarioBusiness.actualizarCliente(cliente)

            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class