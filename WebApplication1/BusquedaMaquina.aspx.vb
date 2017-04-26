Imports System.Threading
Imports Dominio
Imports Negocio
Imports System.Globalization

Public Class BusquedaMaquina
    Inherits BasePage

    Dim materialBusiness As MaterialesBusiness = BusinessFactory.materialesBusiness

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.InitializeCulture()

        verificarPermisosYRedirecccionar(Permisos.listado_maquinas)
    End Sub

    Protected Sub listaMaquinas_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listaMaquinas.SelectedIndexChanged
        Dim id As String = listaMaquinas.Rows(listaMaquinas.SelectedIndex).Cells(1).Text

        Response.Redirect("~\DetalleMaquina.aspx?id=" + id)
    End Sub

    Protected Sub listaMaquinas_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles listaMaquinas.RowEditing
        Dim id As String = listaMaquinas.Rows(e.NewEditIndex).Cells(1).Text
        Response.Redirect("~\AltaModificacionMaquina.aspx?id=" + id)
    End Sub

End Class