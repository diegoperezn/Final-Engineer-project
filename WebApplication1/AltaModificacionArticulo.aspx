<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaModificacionArticulo.aspx.vb" Inherits="WebApplication1.AltaModificacionArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('precio,produccion')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarSelectRequeridos('diseño,tipoPrenda')) {
                if (errores = '') {
                    errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
                }
            }

            if (!validarRegex('precio', /^\d+(?:,\d{0,2})?$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, precioInvalido%>" />"  + "<br/>"
            }

            if (!validarRegex('produccion', /^\d+$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, precioInvalido%>" />"  + "<br/>"
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
        <asp:Label ID="labelTituloCreacion" runat="server" Text="<%$ Resources:labelsArticulo, labelTituloCreacion %>" ></asp:Label>
        <asp:Label ID="labelTituloEdicion" runat="server" Text="<%$ Resources:labelsArticulo, labelTituloEdicion %>" ></asp:Label>
        <asp:HiddenField ID="idArticulo" runat="server" />
    </h2>
    <div id="errores" class="errores"></div>
    <div class="campo">
        <span>
		    <asp:Label ID="Labelcliente" class="label" runat="server" Text="<%$ Resources:labelsArticulo, diseño %>"> </asp:Label>
	    </span>
	    <span>
            <asp:DropDownList class="input" ID="diseño" runat="server" 
            DataSourceID="ObjectDataSource1" DataTextField="nombre" 
            DataValueField="idDiseño"></asp:DropDownList>
	    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="listarDiseños" TypeName="Negocio.DiseñoBusiness">
        </asp:ObjectDataSource>
	    </span>
    </div>
        <div class="campo">
	    <span>
		    <asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsArticulo, tipoPrenda %>"> </asp:Label>
	    </span>
	    <span>
            <asp:DropDownList class="input" ID="tipoPrenda" runat="server" 
            DataSourceID="ObjectDataSource3" DataTextField="descripcion" 
            DataValueField="tipoPrenda"></asp:DropDownList>
	        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                SelectMethod="ListarPrendas" TypeName="Negocio.TipoPrendaBusiness">
            </asp:ObjectDataSource>
	    </span>
    </div>
    <div class="campo">
		<span>
			<asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labelsArticulo, produccion %>"></asp:Label>
		</span>
		<span>
				<asp:TextBox ID="produccion" class="input" runat="server"></asp:TextBox>
		</span>
	</div>
    <div class="campo">
		<span>
			<asp:Label ID="Label4" class="label" runat="server" Text="<%$ Resources:labelsArticulo, precio %>"></asp:Label>
		</span>
		<span>
				<asp:TextBox ID="precio" class="input" runat="server"></asp:TextBox>
		</span>
	</div>
	<div class="campo">
		<span>
			<asp:Label ID="Label3" class="label" runat="server" Text="<%$ Resources:labelsArticulo, comentario %>"></asp:Label>
		</span>
		<span>
				<asp:TextBox ID="comentario" class="input" runat="server" Rows="3" 
            TextMode="MultiLine"></asp:TextBox>
		</span>
	</div>
    <div class="submitContainer">
        <asp:Button class="submit" ID="grabar" OnClientClick ="return validarCampos()" runat="server" Text="<%$ Resources:labels, grabar %>" />
        <asp:Button class="submit" ID="editar" OnClientClick ="return validarCampos()" runat="server" Text="<%$ Resources:labels, editar %>" />
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
	</div>
</asp:Content>
