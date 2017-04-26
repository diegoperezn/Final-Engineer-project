<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaConversacion.aspx.vb" Inherits="WebApplication1.BusquedaConversacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="labelTitulo" runat="server" 
            Text="<%$ Resources:labelsConversacion, labelTituloListaConversacion %>" ></asp:Label>
    </h2>
    <asp:GridView ID="listaConversaciones" runat="server" 
        AutoGenerateColumns="False" DataSourceID="conversacionBusiness" 
        AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
        BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" 
        CssClass="tablaResultado">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/masDetalle.png" 
                ShowCancelButton="False" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="<%$ Resources:labelsConversacion, id %>" SortExpression="id" />
            <asp:TemplateField HeaderText="<%$ Resources:labelsConversacion, remitente %>">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("remitente") %>'></asp:Label>
                    <strong >(<asp:Label ID="Label5" runat="server" Text='<%# Eval("mensajesRemitenteSinLeer") %>'></asp:Label>)</strong>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:labelsConversacion, destinatario %>">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("destinatario") %>'></asp:Label>
                    <strong >(<asp:Label ID="Label4" runat="server" Text='<%# Eval("mensajesDestinatarioSinLeer") %>'></asp:Label>)</strong>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:labelsConversacion, mensajes %>">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("mensajes").count %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
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
    <asp:ObjectDataSource ID="conversacionBusiness" runat="server" 
        SelectMethod="listarConversacionesPorUsuario" 
        TypeName="Negocio.ConversacionBusiness">
        <SelectParameters>
            <asp:SessionParameter Name="usuario" SessionField="usuario" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
