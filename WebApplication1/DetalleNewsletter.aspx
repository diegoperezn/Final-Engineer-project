<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleNewsletter.aspx.vb" Inherits="WebApplication1.DetalleNewsLetter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2> 
        <asp:Label ID="labelTitulo" runat="server" Text="<%$ Resources:labelsNewsletter, labelTituloDetalleNewsletter %>" ></asp:Label>
    </h2>
    <asp:HiddenField ID="idNewsletter" runat="server" />
    <div>
	    <div class="campo">
		    <span>
                <asp:Label ID="labelNombre" runat="server" Text="<%$ Resources:labelsNewsletter, nombre %>"></asp:Label>
		    </span>
		    <span>
			    <asp:Label ID="nombre" class="detalle" runat="server" ></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelEnviado" runat="server" Text="<%$ Resources:labelsNewsletter, enviado %>"></asp:Label>
		    </span>
		    <span>
			    <asp:Label ID="enviado" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
         
    </div>
   <asp:Panel ID="newsletterViewer" class="newsletterViewer" runat="server">
    </asp:Panel>
    <div class="submitContainer">
        <asp:Button class="submit" ID="enviar" runat="server" Text="<%$ Resources:labelsNewsletter, enviar %>" />
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
    </div>

</asp:Content>
