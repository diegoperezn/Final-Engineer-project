<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleProveedor.aspx.vb" Inherits="WebApplication1.DetalleProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2> 
        <asp:Label ID="tituloEdicion" runat="server" Text="<%$ Resources:labelsProveedor, labelTituloDetalle %>"></asp:Label>
    </h2>
    <div>
        <asp:HiddenField ID="idProveedor" runat="server" />
        <div id="errores" class="errores">
        
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="nombreLabel" runat="server" Text="<%$ Resources:labelsProveedor, nombre %>"></asp:Label>
            </span>
            <span>
                <asp:Label ID="nombre" class="detalle" runat="server"></asp:Label>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="telefonoLabel" runat="server" Text="<%$ Resources:labelsProveedor, telefono %>"></asp:Label>
            </span>
            <span>
                <asp:Label ID="telefono" class="detalle" runat="server"></asp:Label>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="direccionLabel" runat="server" Text="<%$ Resources:labelsProveedor, direccion %>"></asp:Label>
            </span>
            <span>
                <asp:Label ID="direccion" class="detalle" runat="server"></asp:Label>
            </span>
        </div>
     </div>
     <div class="submitContainer">
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
        <asp:Button class="submit" ID="editar" runat="server" Text="<%$ Resources:labels, editar %>"/>
     </div>
</asp:Content>
