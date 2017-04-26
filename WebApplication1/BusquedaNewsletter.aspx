<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaNewsletter.aspx.vb" Inherits="WebApplication1.BusquedaNewsLetter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2> 
        <asp:Label ID="labelTitulo" runat="server" Text="<%$ Resources:labelsNewsletter, labelTituloListaNewsletter %>" ></asp:Label>
    </h2>
    <div class="clear ">
        <asp:GridView ID="listaNewsletter" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablaResultado" 
            DataSourceID="newsletterBusiness" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" EditImageUrl="~/images/editar.png" 
                    SelectImageUrl="~/images/masDetalle.png" ShowCancelButton="False" 
                    ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                <asp:BoundField DataField="nombre" HeaderText="nombre" 
                    SortExpression="nombre" />
                <asp:CheckBoxField DataField="enviado" HeaderText="enviado" ReadOnly="True" 
                    SortExpression="enviado" />
            </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:labels, listaVacia %>"></asp:Label>
        </EmptyDataTemplate>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />

        </asp:GridView>
        <asp:ObjectDataSource ID="newsletterBusiness" runat="server" 
            SelectMethod="listarNewsletter" TypeName="Negocio.NewsletterBusiness">
        </asp:ObjectDataSource>
    </div>
    <div class="submitContainer">
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
	</div>
</asp:Content>
