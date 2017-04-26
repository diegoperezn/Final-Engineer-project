<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaMaquina.aspx.vb" Inherits="WebApplication1.BusquedaMaquina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="labelTitulo" runat="server" 
            Text="<%$ Resources:labelsMaquina, labelTituloListaMaquinas %>" ></asp:Label>
    </h2>
    <asp:GridView ID="listaMaquinas" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
        DataSourceID="Maquinas" ForeColor="Black" GridLines="Vertical" 
        CssClass="tablaResultado">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ButtonType="Image" EditImageUrl="~/images/editar.png" 
                SelectImageUrl="~/images/masDetalle.png" ShowCancelButton="False" 
                ShowEditButton="True" ShowSelectButton="True"  />
            <asp:BoundField DataField="codMaquina" HeaderText="<%$ Resources:labelsMaquina, codigoMaquina %>" 
                SortExpression="codMaquina" />
            <asp:BoundField DataField="nombre" HeaderText="<%$ Resources:labelsMaquina, nombreMaquina %>" 
                SortExpression="nombre" />
            <asp:BoundField DataField="cabezales" HeaderText="<%$ Resources:labelsMaquina, cabezales %>" 
                SortExpression="cabezales" />
            <asp:BoundField DataField="cantidadColores" HeaderText="<%$ Resources:labelsMaquina, cantidadColores %>" 
                SortExpression="cantidadColores" />
            <asp:BoundField DataField="altoMargen" HeaderText="<%$ Resources:labelsMaquina, altoMargen %>" 
                SortExpression="altoMargen" />
            <asp:BoundField DataField="anchoMargen" HeaderText="<%$ Resources:labelsMaquina, anchoMargen %>" 
                SortExpression="anchoMargen" />
            <asp:BoundField DataField="velocidadPromedio" HeaderText="<%$ Resources:labelsMaquina, velocidadPromedio %>" 
                SortExpression="velocidadPromedio" />
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:labels, listaVacia %>"></asp:Label>
        </EmptyDataTemplate>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />

<SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="Gray"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
    </asp:GridView>
    <asp:ObjectDataSource ID="Maquinas" runat="server" 
        SelectMethod="listarMaquinas" TypeName="Negocio.MaterialesBusiness">
    </asp:ObjectDataSource>
</asp:Content>
