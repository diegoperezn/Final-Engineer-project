Imports System.Net.Mail

Public Class MailUtils

    Public Sub enviarMail(ByVal De As String, ByVal Para As String, ByVal Asunto As String, ByVal Cuerpo As String, Optional ByVal CC As String() = Nothing, Optional ByVal CCO As String() = Nothing)

        Dim Msg As New MailMessage ' Instancia para Manejar el Envio de Archivos
        Dim SMTP As New SmtpClient ' Uso de SMTP para el envio y codificacion de Archivos

        Try

            Msg.From = New System.Net.Mail.MailAddress(De, "", System.Text.Encoding.UTF8)
            Msg.To.Add(Para)

            Msg.Subject = CStr(Asunto)
            Msg.SubjectEncoding = System.Text.Encoding.UTF8

            Msg.Body = Cuerpo
            Msg.BodyEncoding = System.Text.Encoding.UTF8
            Msg.IsBodyHtml = True

            SMTP.UseDefaultCredentials = False
            SMTP.Credentials = New System.Net.NetworkCredential("uniprof.info@gmail.com", "un1pr0f1234")
            SMTP.Port = 587
            SMTP.Host = "smtp.gmail.com"
            SMTP.EnableSsl = True
            SMTP.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

            SMTP.Send(Msg)

        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            SMTP = Nothing
            Msg.Dispose()
            GC.Collect()
        End Try

    End Sub

End Class
