<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaPedido.aspx.vb" Inherits="WebApplication1.BusquedaPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h3>        
        <asp:Label ID="labelTitulo" runat="server" 
              Text="<%$ Resources:labelsPedido, labelTituloLista %>" ></asp:Label>
    </h3>
	<div>
        <asp:Panel ID="panelCliente"  class="campo" runat="server">
			<span>
				<asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsPedido, clientes %>" ></asp:Label>
			</span>
			<span>
                <asp:DropDownList ID="clientes" runat="server" 
                DataSourceID="ObjectDataSource1" DataTextField="nombre" 
                DataValueField="idCliente">
                </asp:DropDownList>
			<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="CargarClientes" TypeName="Negocio.UsuarioBusiness">
            </asp:ObjectDataSource>
			</span>
        </asp:Panel>
        <div class="campo">
			<span>
				<asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labelsPedido, estado %>" ></asp:Label>
			</span>
			<span>
                <asp:DropDownList ID="estado" runat="server">
                    <asp:ListItem Value ="1" Text ="Pendiente recepcion" ></asp:ListItem>
                    <asp:ListItem Value ="2" Selected ="true" Text ="En taller" ></asp:ListItem>
                    <asp:ListItem Value ="3" Text ="En produccion" ></asp:ListItem>
                    <asp:ListItem Value ="4" Text ="Terminado" ></asp:ListItem>
                </asp:DropDownList>
			</span>
        </div>
        <div class="campo">
			<span>
				<asp:Label ID="LabelfechaDsdInicio" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsPedido, fechaDsdInicio %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="fechaDsdInicio" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelfechaHstInicio" class="label" runat="server" Text="<%$ Resources:labelsPedido, fechaHstInicio %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="fechaHstInicio" runat="server"></asp:TextBox>
			</span>
		</div>
        <div class="campo">
			<span>
				<asp:Label ID="LabelfechaDsdFinal" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsPedido, fechaDsdFinal %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="fechaDsdFinal" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="LabelfechaHst" class="label" runat="server" Text="<%$ Resources:labelsPedido, fechaHstFinal %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="fechaHstFinal" runat="server"></asp:TextBox>
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
        <asp:GridView ID="listaPedidos" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" CssClass="tablaResultado" DataSourceID="ObjectDataSource2" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/masDetalle.png" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="codPedido" HeaderText="<%$ Resources:labelsPedido, codPedido %>" 
                    SortExpression="codPedido" />
                <asp:BoundField DataField="fechaInicio" DataFormatString="{0:g}" 
                    HeaderText="<%$ Resources:labelsPedido, fechaInicio %>" SortExpression="fechaInicio" />
                <asp:BoundField DataField="fechaFinal" DataFormatString="{0:g}" 
                    HeaderText="<%$ Resources:labelsPedido, fechaFinal %>" SortExpression="fechaFinal" />
                <asp:BoundField DataField="porcentajeRealizacion" 
                    HeaderText="<%$ Resources:labelsPedido, porcentajeRealizacion %>" ReadOnly="True" 
                    SortExpression="porcentajeRealizacion" />
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsPedido, estadoActual %>" 
                    SortExpression="estadoActual">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("estadoActual") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsPedido, cliente %>" 
                    SortExpression="cliente">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("cliente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsPedido, trabajos %>" 
                    SortExpression="trabajos">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("trabajos").count %>'></asp:Label>
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
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="listarPedidosConRestriccion" TypeName="Negocio.PedidoBusiness">
            <SelectParameters>
                <asp:ControlParameter ControlID="clientes" Name="cliente" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="estado" Name="estadoActual" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="fechaDsdInicio" Name="fechaDesdeInicio" 
                    PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="fechaHstInicio" Name="fechaHastaInicio" 
                    PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="fechaDsdFinal" Name="fechaDesdeFinal" 
                    PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="fechaHstFinal" Name="fechaHastaFinal" 
                    PropertyName="Text" Type="DateTime" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
