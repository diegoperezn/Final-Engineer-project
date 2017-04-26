Imports System.Threading
Imports System.Globalization

Public Class BasePage
    Inherits System.Web.UI.Page

    Dim permisosBusiness As New PermisosBusiness
    Dim verificarPermisos As Boolean = True

    Protected Overrides Sub InitializeCulture()

        If Not Session("cultura") Is Nothing Then
            Dim cultura As String = Session("cultura").ToString

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultura)
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(cultura)
        End If

    End Sub

    Protected Sub verificarPermisosYRedirecccionar(ByVal permisos As List(Of String))
        If Not permisosBusiness.verificarPermiso(permisos, getLoggedUser()) AndAlso verificarPermisos Then
            Response.Redirect("~/ErrorPermisos.aspx")
        End If
    End Sub

    Protected Sub verificarPermisosYRedirecccionar(ByVal permiso As String)
        If Not permisosBusiness.verificarPermiso(permiso, getLoggedUser()) AndAlso verificarPermisos Then
            Response.Redirect("~/ErrorPermisos.aspx")
        End If
    End Sub

    Protected Function getLoggedUser() As Usuario
        Return Session.Item("usuario")
    End Function

    Protected Function verificarPermiso(ByVal permiso As String) As Boolean
        Return permisosBusiness.verificarPermiso(permiso, getLoggedUser()) OrElse Not verificarPermisos
    End Function


    Protected Function isClienteLogueado()
        Return getLoggedUser() IsNot Nothing AndAlso GetType(Cliente).Equals(getLoggedUser.GetType())
    End Function

End Class
