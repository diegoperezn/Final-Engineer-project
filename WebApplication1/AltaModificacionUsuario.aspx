<%@ Page Title="Clientes" Language="vb" MasterPageFile="~/Site.Master" CodeBehind="AltaModificacionUsuario.aspx.vb" Inherits="WebApplication1.UsuarioUI" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('nombre,apellido,mail,password,telMovil,telFijo')) {
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
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2> 
        <asp:Label ID="tituloCreacion" runat="server" Text="<%$ Resources:labelsUsuarios, labelTituloCreacionCliente %>"></asp:Label>
        <asp:Label ID="tituloEdicion" runat="server" Text="<%$ Resources:labelsUsuarios, labelTituloEdicionCliente %>"></asp:Label>
    </h2>
    <div>
        <asp:HiddenField ID="idUsuario" runat="server" />
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
     <div style="clear:both; height: 95%; margin-left : 1%">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
             <div class="contenedorSeleccionMultiple">
                 <div>
                     <asp:Label ID="Label1" runat="server" Text="<%$ Resources:labelsUsuarios, familias %>"></asp:Label>
                 </div>
                 <div id="erroresInsumos" class="errores"></div>
                 <asp:ListBox class="origen" ID="familiasSistema" runat="server" SelectionMode="Multiple" 
                     DataSourceID="ObjectDataSource1" DataTextField="nombre" 
                     DataValueField="idFamilia" Rows="8">
                 </asp:ListBox>
                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                     SelectMethod="listarFamlias" TypeName="Negocio.FamiliaBusiness">
                 </asp:ObjectDataSource>
                 <div class="botones">
                     <asp:Button class="submit" ID="agregarFamilia" runat="server" Text=">>" />
                     <asp:Button class="submit" ID="quitarFamilia" runat="server" Text="<<" />
                 </div>
                 <asp:ListBox class="destino" ID="familiasUsuario" runat="server" 
                     SelectionMode="Multiple" Rows="8">
                 </asp:ListBox>
  
             </div>

             <div class="contenedorSeleccionMultiple">
                 <div>
                     <asp:Label ID="Label2" runat="server" Text="<%$ Resources:labelsUsuarios, patentes %>"></asp:Label>
                 </div>
                  <asp:ListBox class="origen" ID="patentesSistema" runat="server" SelectionMode="Multiple" 
                     DataSourceID="patenteBusiness" DataTextField="descripcion" 
                     DataValueField="patenteId" Rows="8">
                 </asp:ListBox>
                 <asp:ObjectDataSource ID="patenteBusiness" runat="server" 
                     SelectMethod="listaPatentes" TypeName="Negocio.PatenteBusiness">
                 </asp:ObjectDataSource>
                 <div class="botones">
                     <asp:Button class="submit" ID="agregarPatente" runat="server" Text=">>" />
                     <asp:Button class="submit" ID="quitarPatente" runat="server" Text="<<" />
                 </div>
                 <asp:ListBox class="destino" ID="patentesUsuario" runat="server" 
                     SelectionMode="Multiple" Rows="8">
                 </asp:ListBox>
             </div>
          </ContentTemplate>
         </asp:UpdatePanel>
     </div>
     <div class="submitContainer">
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
        <asp:Button class="submit" ID="grabar" OnClientClick="return  validarCampos()" runat="server" Text="<%$ Resources:labels, grabar %>" />
        <asp:Button class="submit" ID="editar" OnClientClick="return validarCampos()" runat="server" Text="<%$ Resources:labels, editar %>"/>
     </div>
     </div>
</asp:Content>

