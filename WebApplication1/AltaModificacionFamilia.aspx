<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AltaModificacionFamilia.aspx.vb" Inherits="WebApplication1.AltaModificacionFamilia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <script language ="javascript">

        function validarCampos() {
            var errores = '';

            if (!validarRequeridos('nombre')) {
                errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
            }

            if (!validarSelectRequeridos('patentesUsuario')) {
                if (errores = '') {
                    errores += "<asp:Literal runat="server" Text="<%$ Resources:labels, camposRequeridos%>" />"  + "<br/>"
                }
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
        <asp:Label ID="labelTituloCreacion" runat="server" Text="<%$ Resources:labelsFamilia, labelTituloCreacion %>" ></asp:Label>
        <asp:Label ID="labelTituloEdicion" runat="server" Text="<%$ Resources:labelsFamilia, labelTituloEdicion %>" ></asp:Label>
    </h2>
    <div>
        <div id="errores" class="errores"></div> 
        <asp:HiddenField ID="idfamilia" runat="server" />
        <div class="campo">
            <span>
                <asp:Label ID="nombreLabel" class="label" runat="server" Text="<%$ Resources:labelsFamilia, nombre %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="nombre" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="descripcionLabel" class="label" runat="server" Text="<%$ Resources:labelsFamilia, descripcion %>"></asp:Label>
            </span>
            <span>
                <asp:TextBox ID="descripcion" class="input" runat="server"></asp:TextBox>
            </span>
        </div>
     </div>
     <div style="clear:both; height: 198px;">
         <div style="margin-right:10%;margin-left:10%;width:70%; float :left; height: 180px;">
              <asp:ListBox ID="patentesSistema" style="float:left  ;" runat="server" 
                  Height="172px" Width="40%" SelectionMode="Multiple" 
                  DataSourceID="ObjectDataSource1" DataTextField="permiso" 
                  DataValueField="patenteId">
             </asp:ListBox>
              <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                  SelectMethod="listaPatentes" TypeName="Negocio.PatenteBusiness">
              </asp:ObjectDataSource>
             <div style="float:left; height: 170px; width: 15%;">
                 <asp:Button class="submit" ID="agregarPatente" style="margin:15px" runat="server" Text=">>" />
                 <asp:Button class="submit" ID="quitarPatente" style="margin:15px" runat="server" Text="<<" />
             </div>
             <asp:ListBox ID="patentesUsuario" style="float:right ;" runat="server" 
                  Height="172px" Width="40%" SelectionMode="Multiple">
             </asp:ListBox>
         </div>
     </div>
	<div class="submitContainer">
        <asp:Button class="submit" ID="grabar" OnClientClick="return validarCampos()" runat="server" Text="<%$ Resources:labels, grabar %>" />
        <asp:Button class="submit" ID="editar" OnClientClick="return validarCampos()" runat="server" Text="<%$ Resources:labels, editar %>" />
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
	</div>
</asp:Content>
