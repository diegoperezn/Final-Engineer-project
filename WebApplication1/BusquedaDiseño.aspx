<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaDiseño.aspx.vb" Inherits="WebApplication1.BusquedaDiseñosUI" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<div class="cargaDisenios">
		<h2> 
            <asp:Label ID="labelTitulo" runat="server" Text="<%$ Resources:labelsDiseño, labelTituloLista %>" ></asp:Label>
        </h2>
		<div class="formulario">
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
			<div class="campo">
				<span>
					<asp:Label ID="label1" runat="server" Text="<%$ Resources:labelsDiseño, nombre %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="nombre" runat="server"></asp:TextBox>
				</span>
			</div>
			<div class="campo">
				<span>
					<asp:Label ID="label2" runat="server" Text="<%$ Resources:labelsDiseño, alturaDesde %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="alturaDesde" runat="server"></asp:TextBox>
				</span>
			</div>
            <div class="campo">
				<span>
					<asp:Label ID="label3" runat="server" Text="<%$ Resources:labelsDiseño, alturaHasta %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="alturaHasta" runat="server"></asp:TextBox>
				</span>
			</div>
			<div class="campo">
				<span>
					<asp:Label ID="label4" runat="server" Text="<%$ Resources:labelsDiseño, anchoDesde %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="anchoDesde" runat="server"></asp:TextBox>
				</span>
			</div>
            <div class="campo">
				<span>
					<asp:Label ID="label5" runat="server" Text="<%$ Resources:labelsDiseño, anchoHasta %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="anchoHasta" runat="server"></asp:TextBox>
				</span>
			</div>
			<div class="campo">
				<span>
                    <asp:Label ID="label6" runat="server" Text="<%$ Resources:labelsDiseño, puntadasdsd %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="puntadasdsd" runat="server"></asp:TextBox>
				</span>
			</div>
            <div class="campo">
				<span>
					<asp:Label ID="label7" runat="server" Text="<%$ Resources:labelsDiseño, puntadasHasta %>" ></asp:Label>
				</span>
				<span>
					<asp:TextBox class="input" ID="puntadasHasta" runat="server"></asp:TextBox>
				</span>
			</div>
            <div class="campo">
				<span>
					<asp:Label ID="label8" runat="server" Text="<%$ Resources:labelsDiseño, estado %>" ></asp:Label>
				</span>
				<span>
                    <asp:DropDownList ID="estado" runat="server">
                        <asp:ListItem Selected=True Value="" Text ="Seleccione"></asp:ListItem>
                        <asp:ListItem Value="1" Text ="Pendiente Realizacion"></asp:ListItem>
                        <asp:ListItem Value="2" Text ="Realizado"></asp:ListItem>
                    </asp:DropDownList>
				</span>
			</div>
        </div>
        <div class="submitContainer">
            <asp:LinkButton class="submit" ID="cancelar" onclick="history.back()"  >
                <asp:Label ID="cancelar" runat="server" Text="<%$ Resources:labels, cancelar %>"></asp:Label>
            </asp:LinkButton>
            <asp:LinkButton ID="buscar" runat="server" Text="<%$ Resources:labels, buscar %>" ></asp:LinkButton>
        </div>
        <div class ="clear">
            <asp:GridView ID="listaDiseños" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="tablaResultado" 
                DataSourceID="diseñoBusiness" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Image" EditImageUrl="~/images/editar.png" 
                        SelectImageUrl="~/images/masDetalle.png" ShowEditButton="True" 
                        ShowSelectButton="True" />
                    <asp:BoundField DataField="idDiseño" HeaderText="idDiseño" 
                        SortExpression="idDiseño" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" 
                        SortExpression="nombre" />
                    <asp:BoundField DataField="puntadas" HeaderText="puntadas" 
                        SortExpression="puntadas" />
                    <asp:BoundField DataField="alto" HeaderText="alto" 
                        SortExpression="alto" />
                    <asp:BoundField DataField="ancho" HeaderText="ancho" SortExpression="ancho" />
                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="estadoActual" 
                        SortExpression="estadoActual">
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("estadoActual") %>'></asp:Label>
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
            <asp:ObjectDataSource ID="diseñoBusiness" runat="server" 
                SelectMethod="BuscarDiseños" TypeName="Negocio.DiseñoBusiness">
                <SelectParameters>
                    <asp:ControlParameter ControlID="nombre" Name="Nombre" PropertyName="Text" 
                        Type="String" />
                    <asp:ControlParameter ControlID="puntadasdsd" Name="puntadasDesde" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="puntadasHasta" Name="puntadasHasta" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="anchoDesde" Name="anchoDesde" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="anchoHasta" Name="anchoHasta" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="alturaDesde" Name="altoDesde" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="alturaHasta" Name="altoHasta" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="cliente" Name="cliente" 
                        PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="estado" Name="estado" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div> 
</asp:Content>
