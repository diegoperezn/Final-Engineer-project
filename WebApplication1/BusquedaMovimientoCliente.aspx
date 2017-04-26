<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaMovimientoCliente.aspx.vb" Inherits="WebApplication1.BusquedaCuentaCorriente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
        <asp:Label ID="labelTitulo" runat="server" 
              Text="<%$ Resources:labelsMovimientos, labelTituloListaMovimientos %>" ></asp:Label>
    </h2>
	<div class="formulario">
		<div class="campo">
			<span>
				<asp:Label class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsMovimientos, fechaDsd %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="fechaDsd" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label class="label" runat="server" Text="<%$ Resources:labelsMovimientos, fechaHst %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="fechaHst" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label class="label"  runat="server" Text="<%$ Resources:labelsMovimientos, montoDsd %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="montoDsd" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label class="label" runat="server" Text="<%$ Resources:labelsMovimientos, montoHst %>" > </asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="montoHst" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo" >
			<span>
				<asp:Label class="label" runat="server" Text="<%$ Resources:labelsMovimientos, tipoMovimiento %>"> </asp:Label>
			</span>
			<span>
                <asp:DropDownList class="input" ID="tipoMovimiento" runat="server">
                    <asp:ListItem  Selected =True  Value="1" Text ="Debito"></asp:ListItem>
                    <asp:ListItem Value="2" Text ="Credito"></asp:ListItem>
                </asp:DropDownList>
			</span>
		</div>
        <div class="campo">
		    <span>
			    <asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsMovimientos, cuenta %>"> </asp:Label>
		    </span>
		    <span>
                <asp:DropDownList class="input" ID="cuenta" runat="server" 
                DataSourceID="ObjectDataSource2" DataTextField="tipo" 
                DataValueField="codCuenta"  ></asp:DropDownList>
		    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                SelectMethod="listarCuentas" TypeName="Negocio.MovimientoClienteBusiness">
            </asp:ObjectDataSource>
		    </span>
		</div>
		<div class="campo">
			<span>
				<asp:Label class="label" runat="server" Text="<%$ Resources:labelsMovimientos, comentario %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="comentario" runat="server"></asp:TextBox>
			</span>
		</div>
        <asp:Panel ID="clientePanel" class="campo" runat="server">
			<span>
				<asp:Label class="label" runat="server" Text="<%$ Resources:labelsMovimientos, cliente %>"> </asp:Label>
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
        <asp:GridView ID="listaMovimientos" runat="server" 
            DataSourceID="cuentaCorrienteBusiness" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" CssClass="tablaResultado" ForeColor="Black" 
            GridLines="Vertical" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/masDetalle.png" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="nroMovimiento" 
                    HeaderText="<%$ Resources:labelsMovimientos, nroMovimiento %>" SortExpression="nroMovimiento" />
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsMovimientos, cliente %>" 
                    SortExpression="cliente">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cliente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="fecha" HeaderText="<%$ Resources:labelsMovimientos, fecha %>" 
                    SortExpression="fecha" DataFormatString="{0:g}" />
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsMovimientos, tipoMovimiento %>" 
                    SortExpression="tipoMovimiento">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("tipoMovimiento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsMovimientos, cuenta %>" 
                    SortExpression="cuenta">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("cuenta").tipo %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="monto" 
                    HeaderText="monto" 
                    SortExpression="<%$ Resources:labelsMovimientos, monto %>" 
                    DataFormatString="{0:c}" />
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
        <asp:ObjectDataSource ID="cuentaCorrienteBusiness" runat="server" 
            SelectMethod="buscarMovimientos" TypeName="Negocio.MovimientoClienteBusiness">
            <SelectParameters>
                <asp:ControlParameter ControlID="comentario" Name="com" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="fechaDsd" Name="fechaDsd" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="fechaHst" Name="fechaHst" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="cuenta" Name="cuenta" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="tipoMovimiento" Name="tipo" 
                    PropertyName="SelectedValue" Type="String" />
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
