<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaFamilia.aspx.vb" Inherits="WebApplication1.BusquedaFamilia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2> 
        <asp:Label ID="labelTitulo" runat="server" Text="<%$ Resources:labelsFamilia, labelTituloLista %>" ></asp:Label>
    </h2>
    <div class="clear">
        <asp:GridView ID="listaFamilias" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablaResultado" 
            DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" EditImageUrl="~/images/editar.png" 
                    SelectImageUrl="~/images/masDetalle.png" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="idFamilia" HeaderText="<%$ Resources:labelsFamilia, idFamilia %>" 
                    SortExpression="idFamilia" />
                <asp:BoundField DataField="nombre" HeaderText="<%$ Resources:labelsFamilia, nombre %>" 
                    SortExpression="nombre" />
                <asp:BoundField DataField="descripcion" HeaderText="<%$ Resources:labelsFamilia, descripcion %>" 
                    SortExpression="descripcion" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="listarFamlias" TypeName="Negocio.FamiliaBusiness">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
