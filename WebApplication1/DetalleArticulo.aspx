<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleArticulo.aspx.vb" Inherits="WebApplication1.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 	<h2> 
        <asp:Label ID="labelTituloDetalle" runat="server" Text="<%$ Resources:labelsArticulo, labelTituloDetalle %>" ></asp:Label>
        <asp:HiddenField ID="idArticulo" runat="server" />
    </h2>
    <div id="errores" class="errores"></div>
    <div class="campo">
        <span>
		    <asp:Label ID="Labelcliente" class="label" runat="server" Text="<%$ Resources:labelsArticulo, diseño %>"> </asp:Label>
	    </span>
	    <span>
            <asp:Label ID="diseño" runat="server" class="detalle"></asp:Label>
	    </span>
    </div>
        <div class="campo">
	    <span>
		    <asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsArticulo, tipoPrenda %>"> </asp:Label>
	    </span>
	    <span>
            <asp:Label ID="tipoPrenda" runat="server" class="detalle"></asp:Label>
	    </span>
    </div>
    <div class="campo">
		<span>
			<asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labelsArticulo, produccion %>"></asp:Label>
		</span>
		<span>
				<asp:Label ID="produccion" runat="server" class="detalle"></asp:Label>
		</span>
	</div>
    <div class="campo">
		<span>
			<asp:Label ID="Label4" class="label" runat="server" Text="<%$ Resources:labelsArticulo, precio %>"></asp:Label>
		</span>
		<span>
				<asp:Label ID="precio" runat="server" class="detalle"></asp:Label>
		</span>
	</div>
	<div class="campo">
		<span>
			<asp:Label ID="Label3" class="label" runat="server" Text="<%$ Resources:labelsArticulo, comentario %>"></asp:Label>
		</span>
		<span>
			<asp:Label ID="comentario" runat="server" class="detalle"></asp:Label>
		</span>
	</div>
    <div class="clear">
        <asp:GridView ID="listaPrecios" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" CssClass="tablaResultado"
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="nroLista" HeaderText="<%$ Resources:labelsArticulo, nroLista %>" 
                    SortExpression="nroLista" />
                <asp:BoundField DataField="fechaDesde" HeaderText="<%$ Resources:labelsArticulo, fechaDesde %>" 
                    SortExpression="fechaDesde" DataFormatString="{0:g}" />
                <asp:BoundField DataField="fechaHasta" HeaderText="<%$ Resources:labelsArticulo, fechaHasta %>" 
                    SortExpression="fechaHasta" DataFormatString="{0:g}" />
                <asp:BoundField DataField="precio" HeaderText="<%$ Resources:labelsArticulo, precio %>" 
                    SortExpression="precio" DataFormatString="{0:c}" />
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
    </div>
    <div class="submitContainer">
        <asp:Button class="submit" ID="editar" runat="server" Text="<%$ Resources:labels, editar %>" />
        <asp:Button class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:Button>
	</div>
</asp:Content>
