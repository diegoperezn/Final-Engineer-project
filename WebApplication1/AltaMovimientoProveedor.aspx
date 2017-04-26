<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaMovimientoProveedor.aspx.vb" Inherits="WebApplication1.AltaMovimientoProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('monto')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarSelectRequeridos('proveedor')) {
                if (errores == '') {
                    errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
                }
            }

            if (!validarRegex('monto', /^\d+(?:,\d{0,2})?$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, montoInvalido%>" />"  + "<br/>"
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
        <asp:Label ID="labelTitulo" runat="server" 
              Text="<%$ Resources:labelsMovimientos, labelTituloCreacionMovimientos %>" ></asp:Label>
    </h2>
	<div class="formulario">
        <div id="errores" class ="errores" ></div>
        <div class="campo">
		    <span>
			    <asp:Label ID="Label7" class="label" runat="server" Text="<%$ Resources:labelsMovimientos, proveedor %>"> </asp:Label>
		    </span>
		    <span>
                <asp:DropDownList class="input" ID="proveedor" runat="server" 
                DataSourceID="proveedorBusiness" DataTextField="nombre" 
                DataValueField="codProveedor"></asp:DropDownList>
		    <asp:ObjectDataSource ID="proveedorBusiness" runat="server" 
                SelectMethod="listarProveedores" TypeName="Negocio.ProveedorBusiness">
            </asp:ObjectDataSource>
		    </span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label3" class="label"  runat="server" Text="<%$ Resources:labelsMovimientos, monto %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="monto" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label6" class="label" runat="server" Text="<%$ Resources:labelsMovimientos, comentario %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="comentario" runat="server" Rows="4" 
                TextMode="MultiLine"></asp:TextBox>
			</span>
		</div>
	</div>
    <div class="submitContainer">
        <asp:LinkButton class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:LinkButton>
        <asp:LinkButton ID="grabar" runat="server" OnClientClick ="return validarCampos()" Text="<%$ Resources:labels, grabar %>" ></asp:LinkButton>
    </div>
</asp:Content>
