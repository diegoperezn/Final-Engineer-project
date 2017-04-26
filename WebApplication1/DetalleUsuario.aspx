<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleUsuario.aspx.vb" Inherits="WebApplication1.DetalleUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="tituloEdicion" runat="server" Text="<%$ Resources:labelsUsuarios, labelTituloDetalle %>"></asp:Label> 
    </h2>
    <div>
        <asp:HiddenField ID="idUsuario" runat="server" />
        <div class="campo">
            <span>
                <asp:Label ID="nombreLabel" runat="server" Text="<%$ Resources:labelsUsuarios, nombre %>"></asp:Label>
            </span>
            <span>
                <asp:label ID="nombre" class="detalle" runat="server"></asp:label>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="apellidoLabel" runat="server" Text="<%$ Resources:labelsUsuarios, apellido %>"></asp:Label>
            </span>
            <span>
                <asp:label ID="apellido" class="detalle" runat="server"></asp:label>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="mailLabel" runat="server" Text="<%$ Resources:labelsUsuarios, mail %>"></asp:Label>
            </span>
            <span>
                <asp:label ID="mail" class="detalle" runat="server"></asp:label>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="passwordLabel" runat="server" Text="<%$ Resources:labelsUsuarios, password %>"></asp:Label>
            </span>
            <span>
                <asp:label ID="password" class="detalle" runat="server"></asp:label>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="telMovilLabel" runat="server" Text="<%$ Resources:labelsUsuarios, telMovil %>"></asp:Label>
            </span>
            <span>
                <asp:label ID="telMovil" class="detalle" runat="server"></asp:label>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="telFijoLabel" runat="server" Text="<%$ Resources:labelsUsuarios, telFijo %>"></asp:Label>
            </span>
            <span>
                <asp:label ID="telFijo" class="detalle" runat="server"></asp:label>
            </span>
        </div>
     </div>
     <div style="clear:both; height: 95%; margin-left : 1%">
             <div style="width:49%; float :left; height: 178px;">
                 <div>
                     <asp:Label ID="Label1" runat="server" Text="<%$ Resources:labelsUsuarios, familias %>"></asp:Label>
                 </div>
                 <asp:ListBox ID="familiasUsuario" runat="server" style="width:100%;"
                     Height="172px" Width="100%" SelectionMode="Multiple">
                 </asp:ListBox>
  
             </div>
             <div style="width:46%; float :right; margin-right :1%; height: 180px;">
                 <div>
                     <asp:Label ID="Label2" runat="server" Text="<%$ Resources:labelsUsuarios, patentes %>"></asp:Label>
                 </div>
                 <asp:ListBox ID="patentesUsuario" style="width:100%;" runat="server" 
                      Height="172px" Width="131px" SelectionMode="Multiple">
                 </asp:ListBox>
             </div>
     </div>
     <asp:Panel ID="botones" runat="server">
        <asp:Button class="submit" style="float:right;margin:10px; " ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="detalleAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
        <asp:Button  class="submit" style="float:right;margin:10px; " ID="editar" runat="server" Text="<%$ Resources:labels, editar %>"/>
     </asp:Panel>
</asp:Content>
