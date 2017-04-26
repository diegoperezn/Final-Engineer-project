Public Class EstadoPedidosUI
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usr As Usuario = Session.Item("usuario")
        If usr Is Nothing Or Not usr.GetType = GetType(Cliente) Then
            Response.Redirect("~/ErrorPermisos.aspx")
        End If
    End Sub

    Protected Sub editarFamilia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editarFamilia.Click
        Response.Redirect("~/CargarPedidoUI.aspx")
    End Sub
End Class