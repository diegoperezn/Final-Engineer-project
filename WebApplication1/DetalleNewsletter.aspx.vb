Public Class DetalleNewsLetter
    Inherits BasePage

    Dim newsletterBusiness As NewsletterBusiness = BusinessFactory.newsletterBusiness
    Dim administracionBusiness As AdministracionBusiness = BusinessFactory.administracionBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.detalle_newletter)

        If Request.Params("id") IsNot Nothing Then
            cargarNewsletter(Long.Parse(Request.Params("id")))
        End If
    End Sub

    Private Sub cargarNewsletter(ByVal id As Long)
        Dim newsletter As Newsletter = Me.newsletterBusiness.buscarNewsletterPorId(id)

        idNewsletter.Value = id

        With newsletter
            nombre.Text = .nombre
            If .enviado Then
                enviado.Text = "Si"
            Else
                enviado.Text = "No"
            End If

            newsletterViewer.Controls.Add(New LiteralControl(.newsletter))
        End With

    End Sub

    Protected Sub enviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles enviar.Click
        Me.administracionBusiness.enviarNewsletter(idNewsletter.Value)
    End Sub

End Class