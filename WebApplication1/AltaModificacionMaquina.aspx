<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaModificacionMaquina.aspx.vb" Inherits="WebApplication1.AltaModificacionMaquina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('nombre,colores,cabezales,altoCampo,anchoCampo')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarSelectRequeridos('tiposPrendasSeleccionadas')) {
                if (errores = '') {
                    errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
                }
            }

            if (!validarRegex('altoCampo', /^\d+?$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, alturaInvalido%>" />"  + "<br/>"
            }

            if (!validarRegex('anchoCampo', /^\d+(?:,\d{0,2})?$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, anchoInvalido%>" />"  + "<br/>"
            }

            if (!validarRegex('cabezales', /^\d+$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, cabezalesInvalido%>" />"  + "<br/>"
            }

            if (!validarRegex('colores', /^\d+$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, coloresInvalido%>" />"  + "<br/>"
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="tituloEdicion" runat="server" Text="<%$ Resources:labelsMaquina, labelTituloEdicion %>"></asp:Label> 
        <asp:Label ID="tituloCreacion" runat="server" Text="<%$ Resources:labelsMaquina, labelTituloCreacion %>"></asp:Label>
    </h2>
    <div>
        <asp:HiddenField ID="idMaquina" runat="server" />
        <div id="errores" class="errores"></div> 
	    <div class="campo">
		    <span>
                <asp:Label ID="labelNombre" runat="server" Text="<%$ Resources:labelsMaquina, nombreMaquina %>"></asp:Label>
		    </span>
		    <span>
				    <asp:TextBox ID="nombre" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelVelodida" runat="server" Text="<%$ Resources:labelsMaquina, velocidadPromedio %>"></asp:Label>
		    </span>
		    <span>
				    <asp:TextBox ID="velProm" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="labelColores" runat="server" Text="<%$ Resources:labelsMaquina, cantidadColores %>"></asp:Label>
		    </span>
		    <span>
				    <asp:TextBox ID="colores" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelCabezales" runat="server" Text="<%$ Resources:labelsMaquina, cabezales %>"></asp:Label>
		    </span>
		    <span>
		    <asp:TextBox ID="cabezales" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			     <asp:Label ID="labelAlto" runat="server" Text="<%$ Resources:labelsMaquina, altoMargen %>"></asp:Label>
		    </span>
		    <span>
				    <asp:TextBox ID="altoCampo" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			     <asp:Label ID="labelAncho" runat="server" Text="<%$ Resources:labelsMaquina, anchoMargen %>"></asp:Label>
		    </span>
		    <span>
				    <asp:TextBox ID="anchoCampo" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
        <div style="padding : 1% 25%; clear: both ;">
             <asp:ScriptManager ID="managerTipoPrenda" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="panelTipoPrenda" runat="server">
                <ContentTemplate>
                     <asp:ListBox ID="tipoPrendas" style="float:left  ;" runat="server" 
                            Height="172px" Width="140px" SelectionMode="Multiple" 
                         DataSourceID="TiposPrenda" DataTextField="descripcion" 
                         DataValueField="tipoPrenda">
                    </asp:ListBox>
                     <asp:ObjectDataSource ID="TiposPrenda" runat="server" 
                         SelectMethod="ListarPrendas" TypeName="Negocio.TipoPrendaBusiness">
                     </asp:ObjectDataSource>
                    <div style="float:left; height: 170px; width: 43px;">
                        <asp:Button class="submit" ID="agregarTipoPrenda" style="margin:5px" 
                            runat="server" Text=">>" />
                        <asp:Button class="submit" ID="quitarTipoPrenda" style="margin:5px" 
                            runat="server" Text="<<" />
                    </div>
                    <asp:ListBox ID="tiposPrendasSeleccionadas" style="float:right ;" runat="server" 
                         Height="172px" Width="135px" SelectionMode="Multiple">
                    </asp:ListBox>
                </ContentTemplate>
             </asp:UpdatePanel>
        </div>
        <div class="submitContainer ">
            <asp:Button class="submit" OnClientClick="return validarCampos()" ID="grabar" runat="server" Text="<%$ Resources:labels, grabar %>" />
            <asp:Button class="submit" OnClientClick="return validarCampos()" ID="editar" runat="server" Text="<%$ Resources:labels, editar %>" />
            <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:Button>
        </div>
    </div>
</asp:Content>
