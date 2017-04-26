<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleMovimientoCliente.aspx.vb" Inherits="WebApplication1.DetalleMovimientoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="tituloDetalle" runat="server" Text="<%$ Resources:labelsMovimientos, tituloDetalle %>"></asp:Label> 
    </h2>
    <div>
	    <div class="campo">
		    <span>
                <asp:Label ID="labelcliente" runat="server" Text="<%$ Resources:labelsMovimientos, cliente %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="cliente" class="detalle" runat="server" ></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelmonto" runat="server" Text="<%$ Resources:labelsMovimientos, monto %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="monto" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="labelfecha" runat="server" Text="<%$ Resources:labelsMovimientos, fecha %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="fecha" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labeltipoCuenta" runat="server" Text="<%$ Resources:labelsMovimientos, tipoCuenta %>"></asp:Label>
		    </span>
		    <span>
		    <asp:Label ID="tipoCuenta" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			     <asp:Label ID="labeltipoMovimieto" runat="server" Text="<%$ Resources:labelsMovimientos, tipoMovimieto %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="tipoMovimieto" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			     <asp:Label ID="labelcomentario" runat="server" Text="<%$ Resources:labelsMovimientos, comentario %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="comentario" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>

        <asp:Panel ID="botones" class="submitContainer" runat="server">
            <asp:Button class="submit" style="float:right;margin:10px; " ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:Button>
        </asp:Panel>
    </div>
</asp:Content>
