<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaInsumo.aspx.vb" Inherits="WebApplication1.BusquedaInsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
        <asp:Label ID="labelTitulo" runat="server" 
              Text="<%$ Resources:labelsInsumo, labelTituloLista %>" ></asp:Label>
    </h2>
	<div class="formulario">
		<div class="campo">
			<span>
				<asp:Label ID="Label1" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsInsumo, nombre %>" ></asp:Label>
			</span>
			<span>
                <asp:TextBox class="input" ID="nombre" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labelsInsumo, detalle %>"></asp:Label>
			</span>
			<span>
				<asp:TextBox class="input" ID="detalle" runat="server"></asp:TextBox>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label3" class="label"  runat="server" Text="<%$ Resources:labelsInsumo, tipo %>"></asp:Label>
			</span>
			<span>
                <asp:DropDownList ID="tipo" runat="server" DataSourceID="materialBusiness" 
                DataTextField="descripcion" DataValueField="tipo"></asp:DropDownList>
			<asp:ObjectDataSource ID="materialBusiness" runat="server" 
                SelectMethod="listarTipoInsumo" TypeName="Negocio.MaterialesBusiness">
            </asp:ObjectDataSource>
			</span>
		</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label4" class="label" runat="server" Text="<%$ Resources:labelsInsumo, color %>" > </asp:Label>
			</span>
			<span>
                <asp:DropDownList ID="color" runat="server" 
                DataSourceID="materialBusinessColor" DataTextField="color" 
                DataValueField="codColor"></asp:DropDownList>
			<asp:ObjectDataSource ID="materialBusinessColor" runat="server" 
                SelectMethod="listarColores" TypeName="Negocio.MaterialesBusiness">
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
        <asp:GridView ID="listaInsumos" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablaResultado" 
            DataSourceID="InsumoBusiness" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" EditImageUrl="~/images/editar.png" 
                    SelectImageUrl="~/images/masDetalle.png" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="codInsumo" HeaderText="<%$ Resources:labelsInsumo, codInsumo %>" 
                    SortExpression="codInsumo" />
                <asp:BoundField DataField="nombre" HeaderText="<%$ Resources:labelsInsumo, nombre %>" 
                    SortExpression="nombre" />
                <asp:BoundField DataField="detalle" HeaderText="<%$ Resources:labelsInsumo, detalle %>" 
                    SortExpression="detalle" />
                <asp:BoundField DataField="cantidadActual" HeaderText="<%$ Resources:labelsInsumo, cantidad %>" 
                    SortExpression="cantidadActual" />
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsInsumo, tipo %>" 
                    SortExpression="tipoInsumo">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("tipoInsumo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsInsumo, color %>" 
                    SortExpression="color">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("color") %>'></asp:Label>
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
        <asp:ObjectDataSource ID="InsumoBusiness" runat="server" 
            SelectMethod="listarInsumosConRestricciones" TypeName="Negocio.InsumoBusiness">
            <SelectParameters>
                <asp:ControlParameter ControlID="nombre" Name="nombre" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="detalle" Name="detalle" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="tipo" Name="idTipo" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="color" Name="idColor" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
