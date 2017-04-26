<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script language ="javascript">


        function validarCampos(campo) {
            var errores = '';

            if (!validarRequeridos(campo)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarRegex(campo, /^\d+$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, cantidadInvalido%>" />"  + "<br/>"
            }

            if (errores != '')  {
                var elemento = document.getElementById("errores");
                elemento.innerHTML = errores
                return false;
            } else {
                return true;
            }
        } 
    </script>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
            <asp:Panel ID="contenedorArtFrecuentes" runat="server" >
                <h3><asp:Label ID="Label5" class="label" runat="server" Text="<%$ Resources:home, pedidosFrecuentes %>"></asp:Label></h3>
                <div id="errores" class="errores"> </div>
                <asp:Panel ID="art1" CssClass="articuloFrecuente" runat="server">
                    <asp:Label ID="nombreArt1" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="cantidad1" runat="server" Width="43px"></asp:TextBox>
                    <asp:LinkButton ID="generarPedidoArt1" CssClass="submit" OnClientClick ="return validarCampos('cantidad1')"
                        runat="server" Text="<%$ Resources:botones, realizarPedido %>"></asp:LinkButton>
                </asp:Panel>
                <asp:Panel ID="art2" CssClass="articuloFrecuente"  Visible ="false" runat="server">
                    <asp:Label ID="nombreArt2" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="cantidad2" runat="server" Width="43px"></asp:TextBox>
                    <asp:LinkButton ID="generarPedidoArt2" CssClass="submit" OnClientClick ="return validarCampos('cantidad2')"
                         runat="server" Text="<%$ Resources:botones, realizarPedido %>"></asp:LinkButton>
                </asp:Panel>
                <asp:Panel ID="art3" CssClass="articuloFrecuente"  Visible ="false" runat="server">
                    <asp:Label ID="nombreArt3" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="cantidad3" runat="server" Height="20px" Width="43px"></asp:TextBox>
                    <asp:LinkButton ID="generarPedidoArt3" CssClass="submit" OnClientClick ="return validarCampos('cantidad3')"
                         runat="server" Text="<%$ Resources:botones, realizarPedido %>"></asp:LinkButton>
                </asp:Panel>
            </asp:Panel>              
			<div id="cB1">
				<h3><asp:Label ID="sobreUniprof" runat="server"></asp:Label></h3>
				<div class="news">
					<p>
                        <asp:Label ID="sobre1" runat="server"></asp:Label>
                    </p>
				</div>
				<div class="news">
                    <p>
                        <asp:Label ID="sobre2" runat="server"></asp:Label>
                    </p>
				</div>
				<div class="news">
                    <p>
                        <asp:Label ID="sobre3" runat="server"></asp:Label>
                    </p>
				</div>
				<div class="news">
                    <p>
                        <asp:Label ID="sobre4" runat="server"></asp:Label>
                    </p>
				</div>
				<div class="news">
                    <p>
                        <asp:Label ID="sobre5" runat="server"></asp:Label>
                    </p>
				</div>
			</div>
			<div id="cB2">
				<h3><asp:Label ID="nosCaracterizamos" runat="server"></asp:Label></h3>
				<div class="about">
					<ul>
						<li><asp:Label ID="caracteristica1" runat="server"></asp:Label> </li>
						<li><asp:Label ID="caracteristica2" runat="server"></asp:Label> </li>
                        <li><asp:Label ID="caracteristica3" runat="server"></asp:Label> </li>
                        <li><asp:Label ID="caracteristica4" runat="server"></asp:Label> </li>
                        <li><asp:Label ID="caracteristica5" runat="server"></asp:Label> </li>
                        <li><asp:Label ID="caracteristica6" runat="server"></asp:Label> </li>
                        <li><asp:Label ID="caracteristica7" runat="server"></asp:Label> </li>
                        <li><asp:Label ID="caracteristica8" runat="server"></asp:Label> </li>
					</ul>
				</div>
                <asp:Panel ID="newsletter" runat="server">
                    <div id="newsletter">
                    <span id="newsletter-title">                     
                        <asp:LinkButton ID="newsletterTittle" runat="server">Newsletter</asp:LinkButton>
                    </span>
                    <p id="newsletter-text">
                        <asp:LinkButton ID="newsletterText" runat="server"></asp:LinkButton>
                    </p></div>
                </asp:Panel>
			</div>
</asp:Content>
