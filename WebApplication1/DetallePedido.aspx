<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetallePedido.aspx.vb" Inherits="WebApplication1.DetallePedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="cargaDisenios">
	<h2> 
        <asp:Label ID="labelTituloDetalle" runat="server" Text="<%$ Resources:labelsPedido, labelTituloDetalle %>" ></asp:Label>
    </h2>
	<div class="formulario">
        <div id="errores" class="errores">
            <asp:HiddenField ID="idDiseño" runat="server" />
        </div>
        <div class="clear">           
        <div><h3><asp:Label ID="Label3" class="label" runat="server" Text="<%$ Resources:labelsPedido, datosPedido %>"></asp:Label></h3></div>
        <div class="campo" >
                    
            <span>
				<asp:Label ID="Label55" class="label" runat="server" Text="<%$ Resources:labelsPedido, cliente %>"></asp:Label>
			</span>
			<span>
                <asp:Label ID="cliente" class="detalle" runat="server"></asp:Label>
			</span>
			</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label1" class="label" runat="server" Text="<%$ Resources:labelsPedido, comentario %>"></asp:Label>
			</span>
			<span>
					<asp:Label ID="comentario" class="detalle" runat="server" ></asp:Label>
			</span>
		</div>
        </div> 
        <div class="campo" >
            <span>
				<asp:Label ID="Label2" class="label" runat="server" Text="<%$ Resources:labelsPedido, fechaInicio %>"></asp:Label>
			</span>
			<span>
                <asp:Label ID="fechaInicio" class="detalle" runat="server"></asp:Label>
			</span>
			</div>
		<div class="campo">
			<span>
				<asp:Label ID="Label8" class="label" runat="server" Text="<%$ Resources:labelsPedido, fechaFinal %>"></asp:Label>
			</span>
			<span>
					<asp:Label ID="fechaFinal" class="detalle" runat="server" ></asp:Label>
			</span>
		</div>
    </div>

        <div class="clear">
            <div><h3><asp:Label ID="Label5" class="label" runat="server" Text="<%$ Resources:labelsPedido, listaProduccion %>"></asp:Label></h3></div>
            <asp:GridView ID="listaProduccion" runat="server" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                CssClass="tablaResultado" ForeColor="Black" GridLines="Vertical" 
                AllowPaging="True" AutoGenerateColumns="False" >
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/masDetalle.png" 
                        ShowSelectButton="True" />
                    <asp:BoundField DataField="codProduccion" 
                        HeaderText="<%$ Resources:labelsPedido, codProduccion %>"/>
                    <asp:TemplateField HeaderText="<%$ Resources:labelsPedido, maquina %>">
                        <ItemTemplate>
                            <asp:Label ID="Label333" runat="server" Text='<%# Eval("estadoActual").descripcion %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="cantidad" HeaderText="<%$ Resources:labelsPedido, cantidad %>" 
                        SortExpression="cantidad" />
                    <asp:BoundField DataField="fechaInicio" HeaderText="<%$ Resources:labelsPedido, fechaInicio %>" 
                        SortExpression="fechaInicio" />
                    <asp:BoundField DataField="fechaFinal" HeaderText="<%$ Resources:labelsPedido, fechaFinal %>" 
                        SortExpression="fechaFinal" />
                    <asp:BoundField DataField="porcentajeRealizacion" 
                        HeaderText="<%$ Resources:labelsPedido, porcentajeRealizacion %>" ReadOnly="True" 
                        SortExpression="porcentajeRealizacion" />
                    <asp:TemplateField HeaderText="<%$ Resources:labelsPedido, maquina %>">
                        <ItemTemplate>
                            <asp:Label ID="Label56" runat="server" Text='<%# Eval("maquina").nombre %>'></asp:Label>
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
        </div>  

    <div class="submitContainer">
        <asp:Button class="submit" ID="cancelar" runat="server" OnClientClick="history.back()" Text="<%$ Resources:labels, cancelar %>" />
	</div>
</div> 
</asp:Content>
