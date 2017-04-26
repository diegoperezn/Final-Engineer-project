<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="EncuestaUI.aspx.vb" Inherits="WebApplication1.EncuestaUI" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Panel ID="panelOpinion" class="contenedorOpinion" runat="server">
        <div class="campo">
			<span>
				<asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labels, calidad %>"></asp:Label>
			</span>
			<asp:RadioButtonList ID="calidad" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
		</div>
        <div class="campo">
			<span>
				<asp:Label ID="Label3" class="label" runat="server" Text="<%$ Resources:labels, atencion %>"></asp:Label>
			<asp:RadioButtonList ID="atencion" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labels, eficiencia %>"></asp:Label>
			<asp:RadioButtonList ID="eficiencia" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
			</span>
		</div>
        <div class="submitContainer">
            <asp:Button ID="grabarOpinion"  class="submit" runat="server" Text="<%$ Resources:labels, ConfirmarEnviar %>" />
        </div>
    </asp:Panel>
</asp:Content>
