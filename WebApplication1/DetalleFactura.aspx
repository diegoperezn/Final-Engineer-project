<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleFactura.aspx.vb" Inherits="WebApplication1.DetalleFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="tituloDetalle" runat="server" Text="<%$ Resources:labelsFactura, tituloDetalle %>"></asp:Label> 
    </h2>
    <div>
    	<div class="campo">
		    <span>
			    <asp:Label ID="labelnroFactura" runat="server" Text="<%$ Resources:labelsFactura, nroFactura %>"></asp:Label>
		    </span>
		    <span>
		        <asp:Label ID="nroFactura" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="labelnroSucursal" runat="server" Text="<%$ Resources:labelsFactura, nroSucursal %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="nroSucursal" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labeltipoFactura" runat="server" Text="<%$ Resources:labelsFactura, tipoFactura %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="tipoFactura" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
                <asp:Label ID="labelcliente" runat="server" Text="<%$ Resources:labelsFactura, cliente %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="cliente" class="detalle" runat="server" ></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelmonto" runat="server" Text="<%$ Resources:labelsFactura, monto %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="monto" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="labelfecha" runat="server" Text="<%$ Resources:labelsFactura, fecha %>"></asp:Label>
		    </span>
		    <span>
				<asp:Label ID="fecha" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="clear">
            <asp:GridView ID="lineas" runat="server" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                CssClass="tablaResultado" ForeColor="Black" GridLines="Vertical" 
                AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="nroLinea" HeaderText="<%$ Resources:labelsFactura, nroLinea %>" />
                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsFactura, articulo %>">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("articulo.codArticulo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:BoundField DataField="cantidad" HeaderText="<%$ Resources:labelsFactura, cantidad %>" />
                    <asp:BoundField DataField="precio" HeaderText="<%$ Resources:labelsFactura, precio %>" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
        <asp:Panel ID="botones" class="submitContainer" runat="server">
            <asp:Button class="submit" style="float:right;margin:10px; " ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:Button>
        </asp:Panel>
    </div>
</asp:Content>
