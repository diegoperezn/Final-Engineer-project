<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaModificacionProveedor.aspx.vb" Inherits="WebApplication1.AltaModificacionProveedor" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('nombre,telefono,direccion')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarRegex('telefono', /^(?:\d{2}-)?\d{4}-\d{4}$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, telefonoInvalido%>" />"  + "<br/>"
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
    <h2> 
        <asp:Label ID="tituloCreacion" runat="server" Text="<%$ Resources:labelsProveedor, labelTituloDetalle %>"></asp:Label>
        <asp:Label ID="tituloEdicion" runat="server" Text="<%$ Resources:labelsProveedor, labelTituloEdicion %>"></asp:Label>
    </h2>
    <div>
        <asp:HiddenField ID="idProveedor" runat="server" />
        <div id="errores" class="errores">
        
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="nombreLabel" runat="server" Text="<%$ Resources:labelsProveedor, nombre %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="nombre" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="telefonoLabel" runat="server" Text="<%$ Resources:labelsProveedor, telefono %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="telefono" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="direccionLabel" runat="server" Text="<%$ Resources:labelsProveedor, direccion %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="direccion" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
     </div>
     <div class="submitContainer">
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
        <asp:Button class="submit" ID="grabar" OnClientClick="return validarCampos()" runat="server" Text="<%$ Resources:labels, grabar %>" />
        <asp:Button class="submit" ID="editar" OnClientClick="return validarCampos()" runat="server" Text="<%$ Resources:labels, editar %>"/>
     </div>
</asp:Content>