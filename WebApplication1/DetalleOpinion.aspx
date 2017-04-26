<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleOpinion.aspx.vb" Inherits="WebApplication1.DetalleOpinion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="tituloDetalle" runat="server" Text="<%$ Resources:labelsOpinion, tituloDetalle %>"></asp:Label> 
    </h2>
    <div>
        <asp:HiddenField ID="idMaquina" runat="server" />
	    <div class="campo">
		    <span>
                <asp:Label ID="labelNombre" runat="server" Text="<%$ Resources:labelsOpinion, nombre %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="nombre" class="detalle" runat="server" ></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelMail" runat="server" Text="<%$ Resources:labelsOpinion, mail %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="mail" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        	    <div class="campo" style="width: 100%;">
		    <span>
			    <asp:Label ID="labelOpinion" runat="server" Text="<%$ Resources:labelsOpinion, opinion %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label style="width: 80%;" ID="opiniontext" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
    </div>
    <div class="submitContainer">
        <asp:Button class="submit" style="float:right;margin:10px; " ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
    </div>
</asp:Content>
