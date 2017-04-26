<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaCliente.aspx.vb" Inherits="WebApplication1.AltaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('nombre,apellido,mail,password,telFijo')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarRegex('mail', /^[^@\s]+@[^@\.\s]+(\.[^@\.\s]+)+$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, mailInvalido%>" />"  + "<br/>"
            }

            if (!validarRegex('telMovil', /^\d{2}-\d{4}-\d{4}$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, telMovilInvalido%>" />"  + "<br/>"
            }

            
            if (!validarRegex('telFijo', /^\d{4}-\d{4}$/)) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, telFijoInvalido%>" />"  + "xxxx-xxxx<br/>"
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
        <asp:Label ID="tituloCreacion" runat="server" Text="<%$ Resources:labelsUsuarios, labelTituloCreacionCliente %>"></asp:Label>
    </h2>
    <div>
        <div id="errores" class="errores">
        
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="nombreLabel" runat="server" Text="<%$ Resources:labelsUsuarios, nombre %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="nombre" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="apellidoLabel" runat="server" Text="<%$ Resources:labelsUsuarios, apellido %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="apellido" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="mailLabel" runat="server" Text="<%$ Resources:labelsUsuarios, mail %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="mail" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="passwordLabel" runat="server" Text="<%$ Resources:labelsUsuarios, password %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="password" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="telMovilLabel" runat="server" Text="<%$ Resources:labelsUsuarios, telMovil %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="telMovil" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="telFijoLabel" runat="server" Text="<%$ Resources:labelsUsuarios, telFijo %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="telFijo" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="submitContainer">
            <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:Button>
            <asp:Button class="submit" ID="grabar" OnClientClick="return  validarCampos()" runat="server" Text="<%$ Resources:labels, grabar %>" />
        </div>
     </div>
</asp:Content>
