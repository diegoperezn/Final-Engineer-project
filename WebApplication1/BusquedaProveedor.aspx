<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaProveedor.aspx.vb" Inherits="WebApplication1.BusquedaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="labelTitulo" runat="server" 
            Text="<%$ Resources:labelsProveedor, labelTituloLista %>" ></asp:Label>
    </h2>
    <asp:GridView ID="listaProveedores" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablaResultado" 
        DataSourceID="proveedorBusiness" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ButtonType="Image" EditImageUrl="~/images/editar.png" 
                ShowCancelButton="False" ShowEditButton="True" ShowSelectButton="True" 
                UpdateImageUrl="~/images/editar.png" 
                SelectImageUrl="~/images/masDetalle.png" />
            <asp:BoundField DataField="codProveedor" HeaderText="<%$ Resources:labelsProveedor, codProveedor %>" 
                SortExpression="codProveedor" />
            <asp:BoundField DataField="nombre" HeaderText="<%$ Resources:labelsProveedor, nombre %>" 
                SortExpression="nombre" />
            <asp:BoundField DataField="telefono" HeaderText="<%$ Resources:labelsProveedor, telefono %>" 
                SortExpression="telefono" />
            <asp:BoundField DataField="direccion" HeaderText="<%$ Resources:labelsProveedor, direccion %>" 
                SortExpression="direccion" />
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

    <asp:ObjectDataSource ID="proveedorBusiness" runat="server" 
        SelectMethod="listarProveedores" TypeName="Negocio.ProveedorBusiness">
    </asp:ObjectDataSource>

</asp:Content>
