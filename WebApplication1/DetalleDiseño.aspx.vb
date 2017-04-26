Public Class DetalleDiseño
    Inherits BasePage

    Dim business As DiseñoBusiness = BusinessFactory.diseñoBusiness
    Dim insumoBusiness As InsumoBusiness = BusinessFactory.insumoBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeCulture()
        Me.verificarPermisosYRedirecccionar(Permisos.detalleDiseños)

        If Request.Params("id") IsNot Nothing Then
            cargarDiseño(Long.Parse(Request.Params("id")))
        End If
    End Sub

    Private Sub cargarDiseño(ByVal id As Long)
        Dim diseño As Diseño = Me.business.buscarDiseñoPorId(id)

        idDiseño.Value = id

        With diseño
            nombre.Text = .nombre
            altura.Text = .alto
            ancho.Text = .ancho
            puntadas.Text = .puntadas

            If Not String.IsNullOrEmpty(.pathImagen) Then
                imagenDiseño.ImageUrl = "~/images/clientes/" + .pathImagen
                imagen.Text = .pathImagen
                descargarImagen.Visible = True
            End If
            If Not String.IsNullOrEmpty(.pathDetalle) Then
                imagenFicha.ImageUrl = "~/images/clientes/" + .pathArchivoFinal
                ficha.Text = .pathDetalle
                descargarFicha.Visible = True
            End If
            If Not String.IsNullOrEmpty(.pathArchivoEditable) Then
                matrizEditable.Text = .pathArchivoEditable
                descargarEditable.Visible = True
            End If
            If Not String.IsNullOrEmpty(.pathArchivoFinal) Then
                matrizFinal.Text = .pathArchivoFinal
                descargarMatriz.Visible = True
            End If

            For Each Insumo As DiseñoInsumo In .insumos
                Insumo.insumo = Me.insumoBusiness.listarInsumosPorCodigo(Insumo.insumo.codInsumo)
            Next

            listaInsumo.DataSource = .insumos
            listaInsumo.DataBind()
        End With
    End Sub

    Protected Sub descargarImagen_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles descargarImagen.Click
        descargarArchivo("ImagenDiseño.", imagenDiseño.ImageUrl)
    End Sub

    Protected Sub descargarFicha_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles descargarFicha.Click
        descargarArchivo("FichaDiseño.", imagenFicha.ImageUrl)
    End Sub

    Protected Sub descargarMatriz_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles descargarMatriz.Click
        Dim diseño As Diseño = Me.business.buscarDiseñoPorId(idDiseño.Value)
        descargarArchivo("MatrizDiseño.", "~/images/clientes/" + diseño.pathArchivoFinal)
    End Sub

    Protected Sub descargarEditable_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles descargarEditable.Click
        Dim diseño As Diseño = Me.business.buscarDiseñoPorId(idDiseño.Value)
        descargarArchivo("MatrizEditableDiseño.", "~/images/clientes/" + diseño.pathArchivoFinal)
    End Sub

    Public Sub descargarArchivo(ByVal nombre As String, ByVal path As String)
        Response.Clear()
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", "attachment; filename=" + nombre + path.Split(".")(1))
        Response.Flush()
        Response.WriteFile(path)
        Response.End()
    End Sub

    Protected Sub editar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editar.Click
        verificarPermisosYRedirecccionar(Permisos.edicionDiseños)

        Response.Redirect("~\AltaModificacionDiseño.aspx?id=" + idDiseño.Value)
    End Sub

End Class