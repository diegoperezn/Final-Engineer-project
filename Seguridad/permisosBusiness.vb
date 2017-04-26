Imports Dominio

Public Class PermisosBusiness

    Public Function verificarPermiso(ByVal Permiso As String, ByVal usuario As Usuario) As Boolean
        If usuario Is Nothing Then
            Return False
        End If

        Dim patentes As Generic.ICollection(Of Patente) = usuario.patentes
        Dim familias As Generic.ICollection(Of Familia) = usuario.familias

        For Each patente As Patente In patentes
            If patente.permiso = Permiso Then
                Return True
            End If
        Next

        For Each familia As Familia In familias
            For Each patente As Patente In familia.patentes
                If patente.permiso = Permiso Then
                    Return True
                End If
            Next
        Next

        Return False
    End Function

    Public Function verificarPermiso(ByVal Permisos As List(Of String), ByVal usuario As Usuario) As Boolean
        If usuario Is Nothing Then
            Return False
        End If

        Dim patentes As Generic.ICollection(Of Patente) = usuario.patentes
        Dim familias As Generic.ICollection(Of Familia) = usuario.familias

        For Each patente As Patente In patentes
            If Permisos.Contains(patente.permiso) Then
                Return True
            End If
        Next

        For Each familia As Familia In familias
            For Each patente As Patente In familia.patentes
                If Permisos.Contains(patente.permiso) Then
                    Return True
                End If
            Next
        Next

        Return False
    End Function

End Class
