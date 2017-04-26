<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaFactura.aspx.vb" Inherits="WebApplication1.BusquedaFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="labelTitulo" runat="server" 
              Text="<%$ Resources:labelsFactura, labelTituloListaFacturas %>" ></asp:Label>
    </h2>
	<div class="formulario">
		<div class="campo">
			<span>
				<asp:Label ID="LabelnroFactura" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsFactura, nroFactura %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="nroFactura" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabeltipoFactura" class="label" runat="server" Text="<%$ Resources:labelsFactura, tipoFactura %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="tipoFactura" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelnroSucursal" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsFactura, nroSucursal %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="nroSucursal" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelfechaDsd" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsFactura, fechaDsd %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="fechaDsd" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelfechaHst" class="label" runat="server" Text="<%$ Resources:labelsFactura, fechaHst %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="fechaHst" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelmontoDsd" class="label"  runat="server" Text="<%$ Resources:labelsFactura, montoDsd %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="montoDsd" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelmontoHst" class="label" runat="server" Text="<%$ Resources:labelsFactura, montoHst %>" > </asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="montoHst" runat="server"></asp:TextBox>
			</span>
		</div>
        <asp:Panel ID="clientePanel" class="campo" runat="server">
			<span>
				<asp:Label ID="Labelcliente" class="label" runat="server" Text="<%$ Resources:labelsFactura, cliente %>"> </asp:Label>
			</span>
			<span>
                <asp:DropDownList class="input" ID="cliente" runat="server" 
                DataSourceID="ObjectDataSource1" DataTextField="nombre" 
                DataValueField="idCliente"></asp:DropDownList>
			<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="CargarClientes" TypeName="Negocio.UsuarioBusiness">
            </asp:ObjectDataSource>
			</span>
		</asp:Panel>
	</div>
    <div class="submitContainer">
        <asp:LinkButton class="submit" ID="cancelar" onclick="history.back()"  >
            <asp:Label ID="labelAnchqqo" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
        </asp:LinkButton>
        <asp:LinkButton ID="buscar" runat="server" Text="<%$ Resources:labels, buscar %>" ></asp:LinkButton>
    </div>
    <div class ="clear">
    <asp:GridView ID="listaFacturas" runat="server" 
            DataSourceID="facturaBusiness" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" CssClass="tablaResultado" ForeColor="Black" 
            GridLines="Vertical" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/masDetalle.png" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="nroDocumento" HeaderText="<%$ Resources:labelsFactura, nroDocumento %>" 
                    SortExpression="nroDocumento" />
                <asp:BoundField DataField="nroFactura" HeaderText="<%$ Resources:labelsFactura, nroFactura %>" 
                    SortExpression="nroFactura" />
                <asp:BoundField DataField="nroSucursal" HeaderText="<%$ Resources:labelsFactura, nroSucursal %>" 
                    SortExpression="nroSucursal" />
                <asp:BoundField DataField="tipoFactura" HeaderText="<%$ Resources:labelsFactura, tipoFactura %>" 
                    SortExpression="tipoFactura" />
                <asp:BoundField DataField="iva" HeaderText="iva" SortExpression="<%$ Resources:labelsFactura, iva %>" />
                <asp:BoundField DataField="fecha" DataFormatString="{0:g}" HeaderText="<%$ Resources:labelsFactura, fecha %>" 
                    SortExpression="fecha" />
                <asp:BoundField DataField="monto" DataFormatString="{0:c}" HeaderText="<%$ Resources:labelsFactura, monto %>" 
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
        <asp:ObjectDataSource ID="facturaBusiness" runat="server" 
            SelectMethod="buscarFacturas" TypeName="Negocio.FacturaBusiness">
            <SelectParameters>
                <asp:ControlParameter ControlID="nroFactura" Name="nroFactura" 
                    PropertyName="Text" Type="Int64" />
                <asp:ControlParameter ControlID="nroSucursal" Name="nroSucursal" 
                    PropertyName="Text" Type="Int64" />
                <asp:ControlParameter ControlID="tipoFactura" Name="tipoFactura" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="fechaDsd" Name="fechaDsd" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="fechaHst" Name="fechaHst" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="montoDsd" Name="montoDesde" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="montoHst" Name="montoHasta" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="cliente" Name="idCliente" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
