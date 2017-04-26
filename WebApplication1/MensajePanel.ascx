<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MensajePanel.ascx.vb" Inherits="WebApplication1.MensajePanel" %>
<asp:Panel ID="mensaje" class="mensaje" runat="server">
    <p> fecha: <asp:Label ID="fecha" runat="server" Text="Label"></asp:Label></p>
    <p><asp:Label ID="msj" runat="server" Text="Label"></asp:Label></p>
</asp:Panel>