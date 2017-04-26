<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleMaquina.aspx.vb" Inherits="WebApplication1.DetalleMaquina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="tituloDetalle" runat="server" Text="<%$ Resources:labelsMaquina, tituloDetalle %>"></asp:Label> 
    </h2>
    <div>
        <asp:HiddenField ID="idMaquina" runat="server" />
	    <div class="campo">
		    <span>
                <asp:Label ID="labelNombre" runat="server" Text="<%$ Resources:labelsMaquina, nombreMaquina %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="nombre" class="detalle" runat="server" ></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelVelodida" runat="server" Text="<%$ Resources:labelsMaquina, velocidadPromedio %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="velProm" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="labelColores" runat="server" Text="<%$ Resources:labelsMaquina, cantidadColores %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="colores" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelCabezales" runat="server" Text="<%$ Resources:labelsMaquina, cabezales %>"></asp:Label>
		    </span>
		    <span>
		    <asp:Label ID="cabezales" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			     <asp:Label ID="labelAlto" runat="server" Text="<%$ Resources:labelsMaquina, altoMargen %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="altoCampo" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			     <asp:Label ID="labelAncho" runat="server" Text="<%$ Resources:labelsMaquina, anchoMargen %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="anchoCampo" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div style="padding : 1% 25%; clear: both ;">
            <asp:ListBox ID="tiposPrendasSeleccionadas" runat="server" 
                    Height="172px" Width="135px" Enabled="False">
            </asp:ListBox>
        </div>
        <asp:Panel ID="botones" runat="server">
            <asp:Button class="submit" style="float:right;margin:10px; " ID="editar" runat="server" Text="<%$ Resources:labels, editar %>" />
            <asp:Button class="submit" style="float:right;margin:10px; " ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:Button>
        </asp:Panel>
    </div>

</asp:Content>
