Public Class MensajePanel
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub setFecha(ByVal fecha As String)
        Me.fecha.Text = fecha
    End Sub

    Sub setMensaje(ByVal msj As String)
        Me.msj.Text = msj
    End Sub

    Sub setClaseCss(ByVal clase As String)
        Me.mensaje.CssClass = clase
    End Sub

End Class