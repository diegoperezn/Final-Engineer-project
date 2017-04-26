<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaModificacionInsumo.aspx.vb" Inherits="WebApplication1.AltaModificacionInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('nombre,descripcion,cantidad')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarSelectRequeridos('tipo,color')) {
                if (errores = '') {
                    errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
                }
            }

            if (!validarRegex('cantidad', /^\d+?$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, cantidadInvalido%>" />"  + "<br/>"
            }

            if (!validarRegex('costo', /^\d+(?:,\d{0,2})?$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, costoInvalido%>" />"  + "<br/>"
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
        <asp:Label ID="tituloEdicion" runat="server" Text="<%$ Resources:labelsInsumo, labelTituloEdicion %>"></asp:Label> 
        <asp:Label ID="tituloCreacion" runat="server" Text="<%$ Resources:labelsInsumo, labelTituloCreacion %>"></asp:Label>
    </h2>
    <div>
        <asp:HiddenField ID="idInsumo" runat="server" />
        <div id="errores" class="errores"></div> 
	    <div class="campo">
		    <span>
                <asp:Label ID="labelNombre" runat="server" Text="<%$ Resources:labelsInsumo, nombre %>"></asp:Label>
		    </span>
		    <span>
				    <asp:TextBox ID="nombre" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelVelodida" runat="server" Text="<%$ Resources:labelsInsumo, detalle %>"></asp:Label>
		    </span>
		    <span>
				    <asp:TextBox ID="descripcion" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="labelColores" runat="server" Text="<%$ Resources:labelsInsumo, tipo %>"></asp:Label>
		    </span>
		    <span>
                <asp:DropDownList ID="tipo" class="input" runat="server" DataSourceID="ObjectDataSource1" 
                DataTextField="descripcion" DataValueField="tipo"> </asp:DropDownList>
		    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="listarTipoInsumo" TypeName="Negocio.MaterialesBusiness">
            </asp:ObjectDataSource>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelCabezales" runat="server" Text="<%$ Resources:labelsInsumo, color %>"></asp:Label>
		    </span>
		    <span>
                <asp:DropDownList ID="color" class="input" runat="server" 
                DataSourceID="ObjectDataSource2" DataTextField="color" 
                DataValueField="codColor"> </asp:DropDownList>
		    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                SelectMethod="listarColores" TypeName="Negocio.MaterialesBusiness">
            </asp:ObjectDataSource>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			     <asp:Label ID="labelAlto" runat="server" Text="<%$ Resources:labelsInsumo, cantidad %>"></asp:Label>
		    </span>
		    <span>
				    <asp:TextBox ID="cantidad" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			     <asp:Label ID="labelCosto" runat="server" Text="<%$ Resources:labelsInsumo, costo %>"></asp:Label>
		    </span>
		    <span>
				    <asp:TextBox ID="costo" class="input" runat="server"></asp:TextBox>
		    </span>
	    </div>
    </div>
    <div class="submitContainer ">
        <asp:Button class="submit" OnClientClick="return validarCampos()" ID="grabar" runat="server" Text="<%$ Resources:labels, grabar %>" />
        <asp:Button class="submit" OnClientClick="return validarCampos()" ID="editar" runat="server" Text="<%$ Resources:labels, editar %>" />
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
    </div>
</asp:Content>
