<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleOrdenCompra.aspx.vb" Inherits="WebApplication1.DetalleOrdenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
        <asp:Label ID="tituloDetalle" runat="server" Text="<%$ Resources:labelsOrdenCompra, tituloDetalle %>"></asp:Label> 
    </h2>
    <div>
    	<div class="campo">
		    <span>
			    <asp:Label ID="labelnroOrdenCompra" runat="server" Text="<%$ Resources:labelsOrdenCompra, nroOrdenCompra %>"></asp:Label>
		    </span>
		    <span>
		        <asp:Label ID="nroOrdenCompra" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="labelnroSucursal" runat="server" Text="<%$ Resources:labelsOrdenCompra, nroSucursal %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="nroSucursal" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labeltipoOrdenCompra" runat="server" Text="<%$ Resources:labelsOrdenCompra, tipoOrdenCompra %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="tipoOrdenCompra" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
                <asp:Label ID="labelproveedor" runat="server" Text="<%$ Resources:labelsOrdenCompra, proveedor %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="proveedor" class="detalle" runat="server" ></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelmonto" runat="server" Text="<%$ Resources:labelsOrdenCompra, monto %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="monto" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="labelfecha" runat="server" Text="<%$ Resources:labelsOrdenCompra, fecha %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="fecha" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <asp:Panel ID="botones" class="submitContainer" runat="server">
            <asp:Button class="submit" style="float:right;margin:10px; " ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:Button>
        </asp:Panel>
    </div>
</asp:Content>
