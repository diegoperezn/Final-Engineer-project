<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaOrdenCompra.aspx.vb" Inherits="WebApplication1.BusquedaOrdenCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="labelTitulo" runat="server" 
              Text="<%$ Resources:labelsOrdenCompra, labelTituloLista %>" ></asp:Label>
    </h2>
	<div class="formulario">
		<div class="campo">
			<span>
				<asp:Label ID="LabelnroOrdenCompra" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsOrdenCompra, nroOrdenCompra %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="nroOrdenCompra" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabeltipoOrdenCompra" class="label" runat="server" Text="<%$ Resources:labelsOrdenCompra, tipoOrdenCompra %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="tipoOrdenCompra" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelnroSucursal" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsOrdenCompra, nroSucursal %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="nroSucursal" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelfechaDsd" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsOrdenCompra, fechaDsd %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="fechaDsd" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelfechaHst" class="label" runat="server" Text="<%$ Resources:labelsOrdenCompra, fechaHst %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="fechaHst" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelmontoDsd" class="label"  runat="server" Text="<%$ Resources:labelsOrdenCompra, montoDsd %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="montoDsd" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelmontoHst" class="label" runat="server" Text="<%$ Resources:labelsOrdenCompra, montoHst %>" > </asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="montoHst" runat="server"></asp:TextBox>
			</span>
		</div>
        <div class="campo">
			<span>
				<asp:Label ID="Labelproveedor" class="label" runat="server" Text="<%$ Resources:labelsOrdenCompra, proveedor %>"> </asp:Label>
			</span>
			<span>
                <asp:DropDownList class="input" ID="proveedor" runat="server" 
                DataSourceID="proveedorBusiness" DataTextField="nombre" 
                DataValueField="codProveedor"></asp:DropDownList>
			<asp:ObjectDataSource ID="proveedorBusiness" runat="server" 
                SelectMethod="listarProveedores" TypeName="Negocio.ProveedorBusiness">
            </asp:ObjectDataSource>
			</span>
		</div>
	</div>
    <div class="submitContainer">
        <asp:LinkButton class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:LinkButton>
        <asp:LinkButton ID="buscar" runat="server" Text="<%$ Resources:labels, buscar %>" ></asp:LinkButton>
    </div>
    <div class ="clear">
    <asp:GridView ID="listaOrdenCompras" runat="server" 
            DataSourceID="ordenCompraBusiness" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" CssClass="tablaResultado" ForeColor="Black" 
            GridLines="Vertical" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/masDetalle.png" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="nroDocumento" HeaderText="<%$ Resources:labelsOrdenCompra, nroDocumento %>" 
                    SortExpression="nroDocumento" />
                <asp:BoundField DataField="nroSucursal" HeaderText="<%$ Resources:labelsOrdenCompra, nroSucursal %>" 
                    SortExpression="nroSucursal" />
                <asp:BoundField DataField="nroOrdenCompra" HeaderText="<%$ Resources:labelsOrdenCompra, nroOrdenCompra %>" 
                    SortExpression="nroOrdenCompra" />
                <asp:BoundField DataField="tipoOrdenCompra" HeaderText="<%$ Resources:labelsOrdenCompra, tipoOrdenCompra %>" 
                    SortExpression="tipoOrdenCompra" />
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="proveedor" 
                    SortExpression="proveedor">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("proveedor") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="iva" DataFormatString="{0:c}" HeaderText="<%$ Resources:labelsOrdenCompra, iva %>" 
                    SortExpression="iva" />
                <asp:BoundField DataField="fecha" DataFormatString="{0:g}" HeaderText="<%$ Resources:labelsOrdenCompra, fecha %>" 
                    SortExpression="fecha" />
                <asp:BoundField DataField="monto" DataFormatString="{0:c}" HeaderText="<%$ Resources:labelsOrdenCompra, monto %>" 
                    SortExpression="monto" />
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
        <asp:ObjectDataSource ID="ordenCompraBusiness" runat="server" 
            SelectMethod="buscarOrdenes" TypeName="Negocio.OrdenCompraBusiness">
            <SelectParameters>
                <asp:ControlParameter ControlID="nroOrdenCompra" Name="nroOrden" 
                    PropertyName="Text" Type="Int64" />
                <asp:ControlParameter ControlID="nroSucursal" Name="nroSucursal" 
                    PropertyName="Text" Type="Int64" />
                <asp:ControlParameter ControlID="tipoOrdenCompra" Name="tipoOrden" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="fechaDsd" Name="fechaDsd" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="fechaHst" Name="fechaHst" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="montoDsd" Name="montoDesde" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="montoHst" Name="montoHasta" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="proveedor" Name="idCliente" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
