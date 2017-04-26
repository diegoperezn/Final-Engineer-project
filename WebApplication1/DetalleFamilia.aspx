<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleFamilia.aspx.vb" Inherits="WebApplication1.DetalleFamilia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="labelTituloDetalle" runat="server" Text="<%$ Resources:labelsFamilia, labelTituloDetalle %>" ></asp:Label>
    </h2>
    <div>
        <asp:HiddenField ID="idfamilia" runat="server" />
        <div class="campo">
            <span>
                <asp:Label ID="nombreLabel" class="label" runat="server" Text="<%$ Resources:labelsFamilia, nombre %>"></asp:Label>
            </span>
            <span>
                <asp:label ID="nombre" class="detalle"  runat="server"></asp:label>
            </span>
        </div>
        <div class="campo">
            <span>
                <asp:Label ID="descripcionLabel" class="label" runat="server" Text="<%$ Resources:labelsFamilia, descripcion %>"></asp:Label>
            </span>
            <span>
                <asp:label ID="descripcion" class="detalle"  runat="server"></asp:label>
            </span>
        </div>
     </div>
     <div style="clear:both; height: 198px;">
         <div style="margin-right:10%;margin-left:10%;width:70%; float :left; height: 180px;">
             <asp:ListBox ID="patentesUsuario" style="float:right ;" runat="server" 
                  Height="172px" Width="40%" SelectionMode="Multiple">
             </asp:ListBox>
         </div>
     </div>
	<div class="submitContainer">
        <asp:Button class="submit" ID="editar" runat="server" Text="<%$ Resources:labels, editar %>" />
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
	</div>
</asp:Content>
