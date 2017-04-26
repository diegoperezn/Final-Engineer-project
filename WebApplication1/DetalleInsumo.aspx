<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleInsumo.aspx.vb" Inherits="WebApplication1.DetalleInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="tituloDetalle" runat="server" Text="<%$ Resources:labelsInsumo, tituloDetalle %>"></asp:Label> 
    </h2>
    <div>
        <asp:HiddenField ID="idMaquina" runat="server" />
	    <div class="campo">
		    <span>
                <asp:Label ID="labelNombre" runat="server" Text="<%$ Resources:labelsInsumo, nombre %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="nombre" class="detalle" runat="server" ></asp:Label>
		    </span>
	    </div>
	    <div class="campo">
		    <span>
			    <asp:Label ID="labelVelodida" runat="server" Text="<%$ Resources:labelsInsumo, tipo %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="tipo" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="labelColores" runat="server" Text="<%$ Resources:labelsInsumo, cantidad %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="cantidad" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
        <div class="campo">
		    <span>
			    <asp:Label ID="label1" runat="server" Text="<%$ Resources:labelsInsumo, costo %>"></asp:Label>
		    </span>
		    <span>
				    <asp:Label ID="costo" class="detalle" runat="server"></asp:Label>
		    </span>
	    </div>
    </div>
    <div class="clear">
        <asp:GridView ID="listaMovimientos" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" 
            CssClass="tablaResultado">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="nroMovimiento" HeaderText="<%$ Resources:labelsInsumo, nroMovimiento %>" />
                <asp:BoundField DataField="fecha" 
                    HeaderText="<%$ Resources:labelsInsumo, fecha %>" DataFormatString="{0:g}" />
                <asp:BoundField DataField="cantidad" HeaderText="<%$ Resources:labelsInsumo, cantidad %>" />
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
