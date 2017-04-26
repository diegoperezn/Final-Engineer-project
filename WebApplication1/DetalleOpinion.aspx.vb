Public Class DetalleOpinion
    Inherits BasePage

    Dim opinionBusiness As OpinionBusiness = BusinessFactory.opinionBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()
        MyBase.verificarPermisosYRedirecccionar(Permisos.detalle_opinion)

        If Request.Params("id") IsNot Nothing Then
            cargarOpinion(Long.Parse(Request.Params("id")))
        End If
    End Sub

    Private Sub cargarOpinion(ByVal id As Long)
        Dim Opinion As Opinion = Me.opinionBusiness.listarOpinionesPorId(id)

        With Opinion
            nombre.Text = .nombre
            mail.Text = .mail
            opiniontext.Text = .opinion
        End With
    End Sub

End Class