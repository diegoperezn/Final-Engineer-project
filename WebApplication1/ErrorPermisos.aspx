<%@ Page Language="vb" MasterPageFile="~/Site.Master" CodeBehind="ErrorPermisos.aspx.vb" Inherits="WebApplication1.ErrorPermisos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin:2%;"align="center">
        ERROR
    </h1>
    <div style ="text-align :center;padding:2%;"" >
    <asp:Label ID="Label1" runat="server"  Text="<%$ Resources:labels, errorPermisos %>" Font-Bold="True" Font-Overline="False" 
        Font-Size="Small" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>

