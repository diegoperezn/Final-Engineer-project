<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaMovimientoCliente.aspx.vb" Inherits="WebApplication1.AltaMovimientoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('monto')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarSelectRequeridos('cliente,cuenta')) {
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
    	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="CargarClientes" TypeName="Negocio.UsuarioBusiness">
        </asp:ObjectDataSource>
        <div class="campo">
		    <span>
			    <asp:Label ID="Label7" class="label" runat="server" Text="<%$ Resources:labelsMovimientos, cliente %>"> </asp:Label>
		    </span>
		    <span>
                <asp:DropDownList class="input" ID="cliente" runat="server" 
                DataSourceID="ObjectDataSource1" DataTextField="nombre" 
                DataValueField="idCliente"></asp:DropDownList>
		    </span>
		</div>
        <div class="campo">
		    <span>
			    <asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsMovimientos, cuenta %>"> </asp:Label>
		    </span>
		    <span>
                <asp:DropDownList class="input" ID="cuenta" runat="server" 
                DataSourceID="ObjectDataSource2" DataTextField="tipo" 
                DataValueField="codCuenta"  ></asp:DropDownList>
		    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                SelectMethod="listarCuentas" TypeName="Negocio.MovimientoClienteBusiness">
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
