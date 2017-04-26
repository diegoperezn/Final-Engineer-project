<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaModificacionConversacion.aspx.vb" Inherits="WebApplication1.AltaModificacionConversacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('textoMensaje')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
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
        <asp:Label ID="tituloEdicion" runat="server" Text="<%$ Resources:labelsConversacion, labelTituloMensajes %>"></asp:Label>
    </h2>
    <div>
        <asp:HiddenField ID="idConversacion" runat="server" />
        <div id ="errores" class="errores"></div>
        <asp:Panel ID="usuariosPanel" class="campo" runat="server">
            <span>
                <asp:Label ID="nombreLabel" runat="server" Text="<%$ Resources:labelsConversacion, usuarios %>"></asp:Label>
            </span>
            <span>
                <asp:DropDownList ID="usuarios" runat="server" DataSourceID="usuarioBusiness" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
                <asp:ObjectDataSource ID="usuarioBusiness" runat="server" SelectMethod="listarUsuarios" TypeName="Negocio.UsuarioBusiness">
            </asp:ObjectDataSource>
            </span>
        </asp:Panel>
        <asp:Panel ID="mensajeroContenedor" class="mensajero"  runat="server">
            <asp:Panel ID="conversacionesContenedor" class="conversaciones" runat="server">
            </asp:Panel>
            <asp:Panel ID="mensajesContenedor" class="mensajes" runat="server">
                <asp:TextBox ID="textoMensaje" Style="width:99%" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                <div class="submitContainer">
                    <asp:LinkButton ID="enviarMensaje" class="submit" runat="server" OnClientClick="return validarCampos()"
                     Text="<%$ Resources:labelsConversacion, enviarMensaje %>" ></asp:LinkButton>
                </div>
            </asp:Panel>
        </asp:Panel>
    </div> 
</asp:Content>
