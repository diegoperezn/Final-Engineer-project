<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BusquedaProduccion.aspx.vb" Inherits="WebApplication1.BusquedaProduccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h3>        
        <asp:Label ID="labelTitulo" runat="server" 
              Text="<%$ Resources:labelsProduccion, labelTituloLista %>" ></asp:Label>
    </h3>
    <div class="campo">
		<span>
			<asp:Label ID="Label5" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsProduccion, comentario %>" ></asp:Label>
		</span>
		<span>
            <asp:TextBox class="input" ID="comentario" runat="server"></asp:TextBox>
		</span>
	</div>
	<div class="campo">
		<span>
			<asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labelsProduccion, maquina %>"></asp:Label>
		</span>
		<span>
            <asp:DropDownList ID="maquina" runat="server" 
            DataSourceID="ObjectDataSource1" DataTextField="nombre" 
            DataValueField="codMaquina">
            </asp:DropDownList>
		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="listarMaquinas" TypeName="Negocio.MaterialesBusiness">
        </asp:ObjectDataSource>
		</span>
	</div>
	<div class="campo">
		<span>
			<asp:Label ID="Label4" class="label" runat="server" Text="<%$ Resources:labelsProduccion, estado %>"></asp:Label>
		</span>
		<span>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem value="1" Text ="<%$ Resources:labelsProduccion, enEspera %>" ></asp:ListItem>
                <asp:ListItem value="2" Text ="<%$ Resources:labelsProduccion, enProceso %>" ></asp:ListItem>
                <asp:ListItem value="3" Text ="<%$ Resources:labelsProduccion, finalizado %>" ></asp:ListItem>
            </asp:DropDownList>
		</span>
	</div>
    <div class="campo">
		<span>
			<asp:Label ID="LabelfechaDsdInicio" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsProduccion, fechaDsdInicio %>" ></asp:Label>
		</span>
		<span>
            <asp:TextBox class="input" ID="fechaDsdInicio" runat="server"></asp:TextBox>
		</span>
	</div>
	<div class="campo">
		<span>
			<asp:Label ID="LabelfechaHstInicio" class="label" runat="server" Text="<%$ Resources:labelsProduccion, fechaHstInicio %>"></asp:Label>
		</span>
		<span>
			<asp:TextBox class="input" ID="fechaHstInicio" runat="server"></asp:TextBox>
		</span>
	</div>
    <div class="campo">
		<span>
			<asp:Label ID="LabelfechaDsdFinal" class="labelFechaDsd"  runat="server" Text="<%$ Resources:labelsProduccion, fechaDsdFinal %>" ></asp:Label>
		</span>
		<span>
            <asp:TextBox class="input" ID="fechaDsdFinal" runat="server"></asp:TextBox>
		</span>
	</div>
	<div class="campo">
		<span>
			<asp:Label ID="LabelfechaHst" class="label" runat="server" Text="<%$ Resources:labelsProduccion, fechaHstFinal %>"></asp:Label>
		</span>
		<span>
			<asp:TextBox class="input" ID="fechaHstFinal" runat="server"></asp:TextBox>
		</span>
	</div>
    <div class="clear">
        <asp:GridView ID="listaProduccion" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            CssClass="tablaResultado" DataSourceID="ObjectDataSource2" ForeColor="Black" 
            GridLines="Vertical" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/masDetalle.png" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="codProduccion" HeaderText="<%$ Resources:labelsProduccion, codProduccion %>" 
                    SortExpression="codProduccion" />
                <asp:BoundField DataField="cantidad" HeaderText="<%$ Resources:labelsProduccion, cantidad %>" 
                    SortExpression="cantidad" />
                <asp:BoundField DataField="fechaInicio" DataFormatString="{0:g}" 
                    HeaderText="<%$ Resources:labelsProduccion, fechaInicio %>" SortExpression="fechaInicio" />
                <asp:BoundField DataField="fechaFinal" DataFormatString="{0:g}" 
                    HeaderText="<%$ Resources:labelsProduccion, fechaFinal %>" SortExpression="fechaFinal" />
                <asp:BoundField DataField="porcentajeRealizacion" 
                    HeaderText="<%$ Resources:labelsProduccion, realizacion %>" ReadOnly="True" 
                    SortExpression="porcentajeRealizacion" />
                <asp:BoundField DataField="utilizacion" HeaderText="<%$ Resources:labelsProduccion, utilizacion %>" 
                    SortExpression="utilizacion" />
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsProduccion, estadoActual %>" 
                    SortExpression="estadoActual">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" 
                            Text='<%# Eval("estadoActual").descripcion %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:labelsProduccion, diseño %>" 
                    SortExpression="articulo">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" 
                            Text='<%# Eval("Articulo").diseño.nombre %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="listarProduccionConRestricciones" 
            TypeName="Negocio.ProduccionBusiness">
            <SelectParameters>
                <asp:ControlParameter ControlID="comentario" Name="comentario" 
                    PropertyName="Text" Type="String" />
                <asp:Parameter Name="pedido" Type="Object" />
                <asp:ControlParameter ControlID="maquina" Name="maquina" 
                    PropertyName="SelectedValue" Type="Object" />
                <asp:Parameter Name="articulo" Type="Object" />
                <asp:ControlParameter ControlID="DropDownList1" Name="estado" 
                    PropertyName="SelectedValue" Type="Object" />
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
